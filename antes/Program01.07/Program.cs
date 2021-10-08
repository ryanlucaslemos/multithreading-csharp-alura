using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Program01._07
{
    class Program
    {
        static void Main(string[] args)
        {
            Task tarefa = Task.Run(() => Ola());
            tarefa.ContinueWith((t) => Mundo(), TaskContinuationOptions.NotOnFaulted);
            tarefa.ContinueWith((t) => Erro(t), TaskContinuationOptions.OnlyOnFaulted);
            Console.ReadLine();
        }

        private static void Mundo()
        {
            Console.WriteLine("Mundo");
        }

        private static void Ola()
        {
            Console.WriteLine("Olá");

            throw new ApplicationException("Opa! Ocorreu erro no método Olá");
        }

        private static void Erro(Task tarefaAnterior)
        {
            var excecoes = tarefaAnterior.Exception.InnerExceptions;
            foreach (var excecao in excecoes)
            {
                Console.WriteLine(excecao);
            }
        }
    }
}
