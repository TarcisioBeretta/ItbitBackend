using Itbit.WebAPI.Domain.Models;
using Itbit.WebAPI.Outbound.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Itbit.WebAPI.Domain.Services
{
    public class UsuarioService
    {
        private readonly ItbitContext _context;

        public UsuarioService(ItbitContext context)
        {
            _context = context;
        }

        public IEnumerable<Usuario> Get(string nome, bool? ativo)
        {
            var usuarios = _context.Usuarios.Include(o => o.Sexo).AsEnumerable();

            if (nome != null)
            {
                usuarios = usuarios.Where(o => o.Nome.ToUpper().Contains(nome.ToUpper()));
            }

            if (ativo != null)
            {
                usuarios = usuarios.Where(o => o.Ativo == ativo);
            }

            return usuarios.AsEnumerable();
        }

        public Usuario GetById(int id)
        {
            return _context.Usuarios.Include(o => o.Sexo).Single(o => o.Id == id);
        }

        public Usuario Create(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return GetById(usuario.Id);
        }

        public Usuario Update(int id, Usuario usuarioEditado)
        {
            var usuario = GetById(id);
            usuario.Nome = usuarioEditado.Nome;
            usuario.DataNascimento = usuarioEditado.DataNascimento;
            usuario.Email = usuarioEditado.Email;
            usuario.Senha = usuarioEditado.Senha;
            usuario.Ativo = usuarioEditado.Ativo;
            usuario.SexoId = usuarioEditado.SexoId;

            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
            return GetById(usuario.Id);
        }

        public Usuario UpdateStatus(int id, bool status)
        {
            var usuario = GetById(id);
            usuario.Ativo = status;

            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
            return GetById(usuario.Id);
        }

        public void Delete(int id)
        {
            var usuario = GetById(id);
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }

        public bool Exist()
        {
            return _context.Usuarios.Any();
        }

        public bool Exist(int id)
        {
            return _context.Usuarios.Any(o => o.Id == id);
        }
    }
}
