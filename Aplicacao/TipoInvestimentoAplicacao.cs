using Dominio;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao
{
    public class TipoInvestimentoAplicacao
    {
        private readonly TipoInvestimentoRepositorio _repositorio;

        public TipoInvestimentoAplicacao()
        {
            _repositorio = new TipoInvestimentoRepositorio();
        }

        public void Salvar(TipoInvestimento tipoInvestimento)
        {
            _repositorio.Salvar(tipoInvestimento);
        }

        public void Excluir(int id)
        {
            _repositorio.Excluir(id);
        }

        public IEnumerable<TipoInvestimento> Listar()
        {
            return _repositorio.Listar();
        }

        public TipoInvestimento ListarPorId(int id)
        {
            return _repositorio.ListarPorId(id);
        }
    }
}
