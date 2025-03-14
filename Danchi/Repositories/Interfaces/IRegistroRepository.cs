using Danchi.Models;

namespace Danchi.Repositories.Interfaces
{
    public interface IRegistroRepository
    {
        Task<List<Registro>> GetRegistro();

        Task<Registro> GetRegistroById(int id);

        Task<Registro> GetRegistroByName(string Apartamento);

        Task<bool> PostRegistro(Registro registro);

        Task<bool> PutRegistro(Registro registro);

        Task<bool> DeleteRegistro(int id);
    }
}
