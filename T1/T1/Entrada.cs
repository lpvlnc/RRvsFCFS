using System.Collections.Generic;

namespace T1
{
    public class Entrada
    {
        public int Quantidade { get; set; }

        public List<Tarefa> Tarefas { get; set; }
    }

    public class Tarefa
    {
        public string Nome { get; set; }
        public int Inicio { get; set; }
        public int Duracao { get; set; }

        public override string ToString() => $"Nome: {Nome}\nInício: {Inicio}\nDuração: {Duracao}";
    }
}