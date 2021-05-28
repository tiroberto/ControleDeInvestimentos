using Dominio;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao
{
    public class InvestimentoAplicacao
    {
        private readonly InvestimentoRepositorio _repositorio;

        public InvestimentoAplicacao()
        {
            _repositorio = new InvestimentoRepositorio();
        }

        public void Salvar(Investimento investimento)
        {
            _repositorio.Salvar(investimento);
        }

        public void Excluir(int id)
        {
            _repositorio.Excluir(id);
        }

        public IEnumerable<Investimento> Listar()
        {
            return _repositorio.Listar();
        }

        public Investimento ListarPorId(int id)
        {
            return _repositorio.ListarPorId(id);
        }
    }
}
