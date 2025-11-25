using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public class UsuarioRepository: Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ETFormulasDBContext context) : base(context)
        {
        }

        public async Task<Usuario?> GetByUserNameAsync(string user)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Usuario1 == user);
        }
    }
}
