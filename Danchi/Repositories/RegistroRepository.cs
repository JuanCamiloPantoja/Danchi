using Danchi.Context;
using Danchi.Models;
using Danchi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace Danchi.Repositories
{
    public class RegistroRepository : IRegistroRepository
    {
        private readonly Danchi_Context context;

        public RegistroRepository(Danchi_Context context)
        {
            this.context = context;
        }

        public async Task<List<Registro>> GetRegistro()
        {
            var data = await context.Registro.ToListAsync();
            return data;
        }

        public async Task<Registro> GetRegistroById(int id)
        {
            var data = await context.Registro.Where(x => x.IDRegistro == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<Registro> GetRegistroByName(string Apartamento)
        {
            var data = await context.Registro.Where(x => x.Apartamento == Apartamento).FirstOrDefaultAsync();
            return data;
        }

        public async Task<bool> PostRegistro(Registro registro)
        {
            await context.Registro.AddAsync(registro);
            await context.SaveAsync();
            return true;
        }

        public async Task<bool> PutRegistro(Registro registro)
        {
            context.Registro.Update(registro);
            await context.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteRegistro(int id)
        {
            var Registro = await context.Registro.FindAsync(id);

            if (Registro == null)
            {
                return false;
            }

            context.Registro.Remove(Registro);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
