using Itbit.WebAPI.Domain.Models;
using Itbit.WebAPI.Outbound.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace Itbit.WebAPI.Domain.Services
{
    public class SexoService
    {
        private readonly ItbitContext _context;

        public SexoService(ItbitContext context)
        {
            _context = context;
        }

        public IEnumerable<Sexo> Get()
        {
            return _context.Sexos.AsEnumerable();
        }

        public Sexo GetById(int id)
        {
            return _context.Sexos.Find(id);
        }

        public Sexo Create(Sexo sexo)
        {
            _context.Sexos.Add(sexo);
            _context.SaveChanges();
            return sexo;
        }

        public void Delete(int id)
        {
            var sexo = GetById(id);
            _context.Sexos.Remove(sexo);
            _context.SaveChanges();
        }

        public bool Exist()
        {
            return _context.Sexos.Any();
        }

        public bool Exist(int id)
        {
            return _context.Sexos.Any(o => o.Id == id);
        }
    }
}
