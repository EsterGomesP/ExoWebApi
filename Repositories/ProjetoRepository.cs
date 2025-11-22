using Exo.WebApi.Contexts;
using Exo.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Exo.WebApi.Repositories
{
    public class ProjetoRepository
    {
        private readonly ExoContext _context;
        public ProjetoRepository(ExoContext context)
        {
            _context = context;
        }
        public List<Projeto> Listar()
        {
            return _context.Projetos.ToList();
        }

        public Projeto Criar(Projeto projeto)
        {
            _context.Projetos.Add(projeto);
            _context.SaveChanges();
            return projeto;
        }

        public Projeto Editar(Projeto projeto)
        {
            var projetoExistente = _context.Projetos.FirstOrDefault(p => p.Id == projeto.Id);
            
            if (projetoExistente != null)
            {
                projetoExistente.NomeDoProjeto = projeto.NomeDoProjeto;
                projetoExistente.Area = projeto.Area;
                projetoExistente.Status = projeto.Status;
                
                _context.SaveChanges();
            }
            
            return projetoExistente;
        }

        public bool Remover(int id)
        {
            var projetoExistente = _context.Projetos.FirstOrDefault(p => p.Id == id);
            
            if (projetoExistente != null)
            {
                _context.Projetos.Remove(projetoExistente);
                _context.SaveChanges();
                return true;
            }
            
            return false;
        }


    }
}
