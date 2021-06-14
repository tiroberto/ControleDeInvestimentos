using Aplicacao;
using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            InvestimentoAplicacao appAplicacao;
            appAplicacao = new InvestimentoAplicacao();

            var data = appAplicacao.Listar();//.ToArray();

            foreach(var item in data)
            {
                Console.WriteLine(item.Nome);
            }

            Console.WriteLine(data);

            Console.ReadKey();
        }
    }
}
