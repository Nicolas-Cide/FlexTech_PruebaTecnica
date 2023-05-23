using Banco.Models;

namespace Banco.Interfaces
{
    public interface IRequestService
    {
        public Task<List<MovimientosModel>> GetMovimientosByCuenta(string cuenta);
    }
}
