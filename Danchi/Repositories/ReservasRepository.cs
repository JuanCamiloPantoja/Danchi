using Danchi.Context;
using Danchi.Models;
using Danchi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Runtime.CompilerServices;
namespace Danchi.Repositories
{
    public class ReservasRepository : IReservasRepository
    {
        private readonly Danchi_Context context;

        public ReservasRepository(Danchi_Context context)
        {
            this.context = context;
        }

        public async Task<List<Reservas>> GetReservas()
        {
            var data = await context.Reservas.ToListAsync();
            return data;
        }

        public async Task<Reservas> GetReservasById(int id)
        {
            var data = await context.Reservas.Where(x => x.IdReservas == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<Reservas> GetReservasByName(int IdReservas)
        {
            var data = await context.Reservas.Where(x => x.IdReservas == IdReservas).FirstOrDefaultAsync();
            return data;
        }

        public async Task<bool> PostReservas(Reservas reservas)
        {
            await context.Reservas.AddAsync(reservas);
            await context.SaveAsync();
            return true;
        }

        public async Task<bool> PutReservas(Reservas reservas)
        {
            context.Reservas.Update(reservas);
            await context.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteReservas(int id)
        {
            var Reservas = await context.Reservas.FindAsync(id);

            if (Reservas == null)
            {
                return false;
            }

            context.Reservas.Remove(Reservas);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
