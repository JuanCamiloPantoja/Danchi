using Danchi.Models;

namespace Danchi.Repositories.Interfaces
{
    public interface IReservasRepository
    {
        Task<List<Reservas>> GetReservas();

        Task<Reservas> GetReservasById(int id);

        Task<Reservas> GetReservasByName(int IdReservas);

        Task<bool> PostReservas(Reservas reservas);

        Task<bool> PutReservas(Reservas reservas);

        Task<bool> DeleteReservas(int id);
    }
}
