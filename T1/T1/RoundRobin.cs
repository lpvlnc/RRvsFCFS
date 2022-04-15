using System;
using System.Collections.Generic;

namespace T1
{
    public class RoundRobin
    {
        public int quantum = 0;
        readonly List<Tarefa> tarefas;
        readonly List<Tarefa> processadas = new();
        readonly List<Log> log = new();
        public List<int> tempo = new();

        public RoundRobin(List<Tarefa> tarefas)
        {
            this.tarefas = tarefas;
        }

        public void ExecutarRoundRobin()
        {
            bool respostaValida = false;
            while(!respostaValida)
            {
                try
                {
                    Console.WriteLine("Informe o quantum (time slice) para ser usado no Round Robin: ");
                    quantum = Convert.ToInt32(Console.ReadLine());
                    respostaValida = quantum > 0;
                    if (!respostaValida)
                        Console.Write("O quantum precisa ser um número inteiro maior que 0.");
                }
                catch
                {
                    respostaValida = false;
                }
            }
            
            Utils.Titulo("Execução do Round Robin");
            while (tarefas.Count > 0)
            {
                Tarefa tarefa = tarefas[0];
                int index = log.FindLastIndex(x => x.Nome.Equals(tarefa.Nome));
                if (index > -1)
                {
                    int t = 0;
                    for (int i = index + 1; i < log.Count; i++)
                    {
                        t += log[i].TempoExecutado;
                    }
                    tempo.Add(t);
                }
                else
                {
                    if (tempo.Count == 0)
                        tempo.Add(0);
                    else
                        if (tarefa.Duracao > quantum)
                            tempo.Add(tempo[^1] + quantum);
                        else
                            tempo.Add(tempo[^1] + tarefa.Duracao);

                }

                tarefas.RemoveAt(0);
                int tempoExecutado = tarefa.Duracao > quantum ? quantum : tarefa.Duracao;
                tarefa.Duracao = tarefa.Duracao > quantum ? tarefa.Duracao - quantum : tarefa.Duracao - tarefa.Duracao;

                if (tarefa.Duracao > 0)
                    tarefas.Add(tarefa);
                else
                    processadas.Add(tarefa);
                Console.WriteLine($"\nExecutando tarefa: {tarefa.Nome}\n{tarefa.ToString()}\nEspera: {tempo[^1]}");
                log.Add(new Log { Nome = tarefa.Nome, TempoExecutado = tempoExecutado });
            }
            Console.WriteLine($"\nEspera média: {CalcularMedia()}");
        }
        public decimal CalcularMedia()
        {
            int total = 0;
            for (int i = 0; i < tempo.Count; i++)
            {
                total += tempo[i];
            }
            return total / processadas.Count;
        }
    }

    public class Log
    {
        public string Nome { get; set; }
        public int TempoExecutado { get; set; }
    }
}