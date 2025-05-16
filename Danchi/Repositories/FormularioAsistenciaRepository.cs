using Danchi.Context;
using Danchi.Models;
using Danchi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace Danchi.Repositories
{
    public class FormularioAsistenciaRepository : IFormularioAsistenciaRepositoy
    {
        private readonly Danchi_Context context;

        public FormularioAsistenciaRepository(Danchi_Context context)
        {
            this.context = context;
        }

        public async Task<List<FormularioAsistencia>> GetFormularioAsistencia()
        {
            var data = await context.FormularioAsistencia.ToListAsync();
            return data;
        }

        public async Task<FormularioAsistencia> GetFormularioAsistenciaById(int id)
        {
            var data = await context.FormularioAsistencia.Where(x => x.IdFormulario == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<FormularioAsistencia> GetFormularioAsistenciaByName(string NombreResidente)
        {
            var data = await context.FormularioAsistencia.Where(x => x.NombreResidente == NombreResidente).FirstOrDefaultAsync();
            return data;
        }

        public async Task<bool> PostFormularioAsistencia(FormularioAsistencia formularioAsistencia)
        {
            await context.FormularioAsistencia.AddAsync(formularioAsistencia);
            await context.SaveAsync();
            return true;
        }

        public async Task<bool> PutFormularioAsistencia(FormularioAsistencia formularioAsistencia)
        {
            context.FormularioAsistencia.Update(formularioAsistencia);
            await context.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteFormularioAsistencia(int id)
        {
            var FormularioAsistencia = await context.FormularioAsistencia.FindAsync(id);

            if (FormularioAsistencia == null)
            {
                return false;
            }

            context.FormularioAsistencia.Remove(FormularioAsistencia);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
