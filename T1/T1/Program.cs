using System;

namespace T1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] linhas = Utils.LerLinhas();
            Entrada entrada = Utils.CriarObjetoDeEntrada(linhas);
            Utils.ExibirInformacoesDeEntrada(entrada);

            RoundRobin rr = new(Utils.CriarObjetoDeEntrada(linhas).Tarefas);
            rr.ExecutarRoundRobin();

            FCFS fcfs = new(entrada.Tarefas);
            fcfs.ExecutarFCFS();
            Console.WriteLine("\nFim da execução.\nPressione qualquer tecla para encerrar.");
            Console.ReadLine();
        }
    }
}
