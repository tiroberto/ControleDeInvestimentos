using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class CarteiraRepositorio
    {
        public Contexto _contexto;

        public CarteiraRepositorio()
        {
            _contexto = new Contexto();
        }

        public void Salvar(Carteira carteira)
        {
            if(carteira.Id > 0)
            {
                Alterar(carteira);
            }
            else
            {
                Adicionar(carteira);
            }
        }

        public IEnumerable<Carteira> Listar()
        {
            return _contexto.Carteiras.Include(x => x.Investimentos).Include(x => x.Investimentos.Select(i => i.TipoInvestimento)).ToList();
        }

        public Carteira ListarPorId(int id)
        {
            return _contexto.Carteiras.Find(id);
        }

        public void Adicionar(Carteira carteira)
        {
            carteira.Investimentos = carteira.Investimentos.Select(investimento => _contexto.Investimentos.FirstOrDefault(x => x.Id == investimento.Id)).ToList();
            _contexto.Carteiras.Add(carteira);
            _contexto.SaveChanges();
        }

        public void Alterar(Carteira carteira)
        {
            Carteira carteiraSalvar = _contexto.Carteiras.Where(x => x.Id == carteira.Id).First();
            carteiraSalvar.Investimentos = carteira.Investimentos.Select(investimento => _contexto.Investimentos.FirstOrDefault(x => x.Id == investimento.Id)).ToList();
            carteiraSalvar.Nome = carteira.Nome;
            _contexto.SaveChanges();
        }

        public void Excluir(int id)
        {
            Carteira carteiraExcluir = _contexto.Carteiras.Where(x => x.Id == id).First();
            carteiraExcluir.Investimentos = null;
            _contexto.Set<Carteira>().Remove(carteiraExcluir);
            _contexto.SaveChanges();
        }
    }
}
