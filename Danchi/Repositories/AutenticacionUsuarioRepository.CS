﻿using Danchi.Models;
using Danchi.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Danchi.Context;
using System;

namespace Danchi.Repositories
{
    public class AutenticacionUsuarioRepository : IAutenticacionUsuarioRepository
    {
        private readonly Danchi_Context context;

        public AutenticacionUsuarioRepository(Danchi_Context context)
        {
            this.context = context;
        }

        public async Task<List<AutenticacionUsuario>> GetAutenticacionUsuario()
        {
            var data = await context.autenticacionUsuario.ToListAsync();
            return data;
        }
        public async Task<AutenticacionUsuario> GetAutenticacionUsuarioById(int id)
        {
            var data = await context.autenticacionUsuario.Where(x => x.IdAutenticacion == id).FirstOrDefaultAsync();
            return data;
        }
        public async Task<AutenticacionUsuario> GetAutenticacionUsuarioByName(string Usuario)
        {
            var data = await context.autenticacionUsuario.Where(x => x.TipoUsuario == Usuario).FirstOrDefaultAsync();
            return data;
        }

        public async Task<bool> PostAutenticacionUsuario(AutenticacionUsuario autenticacionUsuario)
        {
            await context.autenticacionUsuario.AddAsync(autenticacionUsuario);
            await context.SaveAsync();
            return true;
        }

        public async Task<bool> PutAutenticacionUsuario(AutenticacionUsuario autenticacionUsuario)
        {
            context.autenticacionUsuario.Update(autenticacionUsuario);
            await context.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAutenticacionUsuario(int id)
        {
            var autenticacionUsuario = await context.autenticacionUsuario.FindAsync(id);

            if (autenticacionUsuario == null)
            {
                return false;
            }
            context.autenticacionUsuario.Remove(autenticacionUsuario);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
