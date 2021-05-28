using Dominio;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao
{
    public class CarteiraAplicacao
    {
        private readonly CarteiraRepositorio _repositorio;

        public CarteiraAplicacao()
        {
            _repositorio = new CarteiraRepositorio();
        }

        public void Salvar(Carteira carteira)
        {
            _repositorio.Salvar(carteira);
        }

        public void Excluir(int id)
        {
            _repositorio.Excluir(id);
        }

        public IEnumerable<Carteira> Listar()
        {
            return _repositorio.Listar();
        }

        public Carteira ListarPorId(int id)
        {
            return _repositorio.ListarPorId(id);
        }
    }
}
