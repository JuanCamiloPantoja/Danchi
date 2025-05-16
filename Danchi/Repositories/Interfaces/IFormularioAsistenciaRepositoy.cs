using Danchi.Models;

namespace Danchi.Repositories.Interfaces
{
    public interface IFormularioAsistenciaRepositoy
    {
        Task<List<FormularioAsistencia>> GetFormularioAsistencia();

        Task<FormularioAsistencia> GetFormularioAsistenciaById(int id);

        Task<FormularioAsistencia> GetFormularioAsistenciaByName(string NombreResidente);

        Task<bool> PostFormularioAsistencia(FormularioAsistencia formularioAsistencia);

        Task<bool> PutFormularioAsistencia(FormularioAsistencia formularioAsistencia);

        Task<bool> DeleteFormularioAsistencia(int id);
    }
}
