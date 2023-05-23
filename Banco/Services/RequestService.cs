using Banco.Interfaces;
using Banco.Models;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Configuration;

namespace Banco.Services
{
    public class RequestService: IRequestService
    {
        private readonly string _connectionString;

        public RequestService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        public async Task<List<MovimientosModel>> GetMovimientosByCuenta(string cuenta) 
        {
            List<MovimientosModel> movimientos = new List<MovimientosModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString)) 
            {
                await connection.OpenAsync();

                string sqlQuery = "SELECT * FROM [Banco].[dbo].[movimientosBcra] WHERE cuentaAcreedora = @cuenta";
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.AddWithValue("cuenta", cuenta);

                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (reader.Read()) 
                {
                    MovimientosModel movimiento = new MovimientosModel
                    {
                        Operatoria = reader.GetString(reader.GetOrdinal("operatoria")),
                        Transaccion = reader.GetString(reader.GetOrdinal("transaccion")),
                        EntidadDeudora = reader.GetString(reader.GetOrdinal("entidadDeudora")),
                        CuentaDeudora = reader.GetString(reader.GetOrdinal("cuentaDeudora")),
                        EntidadAcreedora = reader.GetString(reader.GetOrdinal("entidadAcreedora")),
                        CuentaAcreedora = reader.GetString(reader.GetOrdinal("cuentaAcreedora")),
                        Importe = reader.GetDecimal(reader.GetOrdinal("importe")),
                        InstruccionDePago = reader.GetString(reader.GetOrdinal("instruccionDePago")),
                        FechaProcesado = reader.GetDateTime(reader.GetOrdinal("fechaProcesado")),
                        NumeroInterno = reader.GetString(reader.GetOrdinal("numeroInterno"))
                    };

                    movimientos.Add(movimiento);
                }

                reader.Close();
            }

            return movimientos;
        }
    }
}
