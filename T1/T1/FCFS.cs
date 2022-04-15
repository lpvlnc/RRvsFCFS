using System;
using System.Collections.Generic;

namespace T1
{
    public class FCFS
    {
        private readonly List<Tarefa> tarefas;
        private readonly List<Tarefa> processadas = new();
        public List<int> tempo = new() { 0 };

        public FCFS(List<Tarefa> tarefas)
        {
            this.tarefas = tarefas;
        }

        public void ExecutarFCFS()
        {
            ProcessarDados();
            ProcessarResultado();
        }

        public void ProcessarDados()
        {
            Utils.Titulo("Execução do First-Come, First-Served (FCFS)");
            while (tarefas.Count > 0)
            {
                Tarefa tarefa = tarefas[0];
                Console.WriteLine($"\nExecutando tarefa: {tarefa.Nome}\n" + tarefa.ToString());
                tempo.Add(tempo[^1] + tarefa.Duracao);
                tarefas.RemoveAt(0);
                processadas.Add(tarefa);
            }
        }

        public void ProcessarResultado()
        {
            Utils.Titulo("Resultados FCFS");
            Console.Write("\nTempo de espera dos processos: ");
            for (int i = 0; i < processadas.Count; i++)
            {
                Console.Write($"|{processadas[i].Nome}: {tempo[i]}");
            }
            Console.Write("|");
            decimal media = CalcularMedia();
            Console.WriteLine($"\nEspera média: {media}");
        }

        public decimal CalcularMedia()
        {
            int total = 0;
            for (int i = 0; i < tempo.Count - 1; i++)
            {
                total += tempo[i];
            }
            return total / (tempo.Count - 1);
        }
    }
}