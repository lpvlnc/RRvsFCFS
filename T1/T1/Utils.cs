using System;
using System.Collections.Generic;
using System.IO;

namespace T1
{
    public class Utils
    {
        public static string[] LerLinhas()
        {
            try
            {
                return File.ReadAllLines("input.txt");
            }
            catch
            {
                Console.WriteLine("Erro ao abrir o arquivo de texto. Certifique-se de que o arquivo esteja no mesmo diretório que o .exe.");
                throw;
            }
        }

        public static Entrada CriarObjetoDeEntrada(string[] linhas)
        {
            try
            {
                bool primeiraLinha = true;
                Entrada entrada = new()
                {
                    Quantidade = Convert.ToInt32(linhas[0].Split(';')[0].ToString().Trim()),
                    Tarefas = new List<Tarefa>()
                };

                foreach (string linha in linhas)
                {
                    if (primeiraLinha)
                    {
                        primeiraLinha = false;
                        continue;
                    }
                    string[] info = linha.Split(',');
                    Tarefa tarefa = new()
                    {
                        Nome = info[0].Trim(),
                        Inicio = Convert.ToInt32(info[1].Trim()),
                        Duracao = Convert.ToInt32(info[2].Split(';')[0].Trim())
                    };
                    entrada.Tarefas.Add(tarefa);
                }
                entrada.Tarefas.Sort((x, y) => x.Inicio.CompareTo(y.Inicio));
                return entrada;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Não foi possível ler os dados de entrada. Certifique-se de que o arquivo de entrada está formatado corretamente. [{e.Message}]");
                throw;
            }
        }

        public static void ExibirInformacoesDeEntrada(Entrada entrada)
        {
            Console.WriteLine("\nQuantidade: " + entrada.Quantidade);
            Console.WriteLine("==============");
            foreach (Tarefa tarefa in entrada.Tarefas)
            {
                Console.WriteLine(tarefa.ToString());
                Console.WriteLine("==============");
            }
        }
        
        public static void Titulo(string titulo, char separador = '#')
        {
            Console.WriteLine("");
            Utils.Separador(titulo.Length + 4, separador);
            Console.WriteLine(separador.ToString() + ' ' + titulo + ' ' + separador.ToString());
            Utils.Separador(titulo.Length + 4, separador);
        }
        public static void Separador(int quantidade, char separador)
        {
            Console.WriteLine(new string(separador, quantidade));
        }
    }
}