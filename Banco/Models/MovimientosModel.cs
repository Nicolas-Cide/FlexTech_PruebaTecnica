namespace Banco.Models
{
    public class MovimientosModel
    {
        public string Operatoria { get; set; }
        public string Transaccion { get; set; }
        public string EntidadDeudora { get; set; }
        public string CuentaDeudora { get; set; }
        public string EntidadAcreedora { get; set; }
        public string CuentaAcreedora { get; set; }
        public decimal Importe { get; set; }
        public string InstruccionDePago { get; set; }
        public DateTime FechaProcesado { get; set; }
        public string NumeroInterno { get; set; }
    }
}
