using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public int ListarQuantidadeInvestimentos(int id)
        {
            var carteira = _contexto.Carteiras
                .Include(ic => ic.Investimentos)
                .ThenInclude(c => c.InvestimentoSelecionado.TipoInvestimento)
                .First(x => x.CarteiraId == id);
            return carteira.Investimentos.ToList().Count();
        }

        public async Task<IEnumerable<Carteira>> Listar()
        {
            return await _contexto.Carteiras
                .Include(i => i.Investimentos)
                .ThenInclude(c => c.InvestimentoSelecionado.TipoInvestimento)
                .ToListAsync();
        }

        public Carteira ListarPorId(int id)
        {
            return _contexto.Carteiras
                .Include(x => x.Usuario)
                .Include(ic => ic.Investimentos)
                .ThenInclude(c => c.InvestimentoSelecionado.TipoInvestimento)
                .First(x => x.CarteiraId == id);
        }

        public void AdicionarInvestimento(Investimento investimento)
        {
            _contexto.Set<Investimento>().Add(investimento);
            _contexto.SaveChanges();
        }

        public void Adicionar(Carteira carteira)
        {
            carteira.Usuario = _contexto.Usuario
                .Include(x => x.Enderecos)
                .ToList()
                .Where(x => x.UsuarioId == carteira.Usuario.UsuarioId)
                .FirstOrDefault();
            _contexto.Carteiras.Add(carteira);
            _contexto.SaveChanges();
        }

        public void Alterar(Carteira carteira)
        {
            Carteira carteiraSalvar = _contexto.Carteiras.Where(x => x.CarteiraId == carteira.CarteiraId).First();
            carteiraSalvar.Nome = carteira.Nome;
            _contexto.SaveChanges();
        }

        public string Excluir(int id)
        {
            Carteira carteiraExcluir = _contexto.Carteiras.Where(x => x.CarteiraId == id).First();
            //carteiraExcluir.Investimentos = null;
            _contexto.Investimentos.RemoveRange(_contexto.Investimentos.Where(x => x.Carteira.CarteiraId == id));
            _contexto.Carteiras.Remove(carteiraExcluir);
            _contexto.SaveChanges();
            return "Excluído com sucesso!";
        }
    }
}
