using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GenioAdivinhacaoBonus
{
    class Program
    {
        static void Main(string[] args)
        {
            var jogadas = new List<int>();
            var file = @"C:\Arquivo Prova\entradaAdivinhacao.txt";
            if (File.Exists(file))
            {
                using (Stream entrada = File.Open(file, FileMode.Open))
                using (StreamReader leitor = new StreamReader(entrada))
                {
                    string linha = leitor.ReadLine();

                    // Percorre o arquivo inteiro
                    while (leitor.Peek() >= 0 && !string.IsNullOrWhiteSpace(linha))
                    {
                        int primeiro = 0;
                        var operacoes = new List<Operacoes>();

                        primeiro = Convert.ToInt32(linha);

                        // Percorre todos os testes disponíveis
                        for (int i = 0; i < primeiro; i++)
                        {
                            linha = leitor.ReadLine();
                            Console.WriteLine(linha);
                            var colunas = linha.Split(" ");

                            var sacola = new Operacoes()
                            {
                                Comando = int.Parse(colunas[0]),
                                Elemento = int.Parse(colunas[1])
                            };

                            operacoes.Add(sacola);
                        }

                        var tipoEstrutura = TipoEstrutura(operacoes);
                        Console.WriteLine(tipoEstrutura);

                        linha = leitor.ReadLine();
                    }
                }
            }
        }

        static string TipoEstrutura(IEnumerable<Operacoes> operacoes)
        {
            
            var entradas = operacoes.Where(x => x.Comando == 1).ToList();
            var saidas = operacoes.Where(x => x.Comando == 2).ToList();

            var resultados = new Dictionary<string, bool>();

            resultados.Add("Fila", EhFila(entradas, saidas));
            resultados.Add("Pilha", EhPilha(entradas, saidas));
            resultados.Add("Impossivel", EhImpossivel(entradas, saidas));


            var ehNotSure = resultados.Values.Count(x => x) > 1;


            if (ehNotSure)
                return "not sure";

            else if (resultados["Impossivel"])
                return "Impossivel";

            else if (resultados["Pilha"])
                return "Stack";

            else if (resultados["Fila"])
                return "Queue";

            else {
                return "Queue Prioridade";
            }
            
           
        }

        static bool EhImpossivel(IEnumerable<Operacoes> entradas, IEnumerable<Operacoes> saidas)
        {
            var x = saidas.ToArray();

            if(x.Length == 1)
            {

            }

            for (int i = 0; i < saidas.Count(); i++)
            {
                var contemElemento = entradas.Any(e => e.Elemento == x[i].Elemento);
                if (!contemElemento) return true;
            }

            return false;
        }

        static bool EhPilha(IEnumerable<Operacoes> entradas, IEnumerable<Operacoes> saidas)
        {
            var x = saidas.ToArray();
            var y = entradas.ToArray();
            for (int i = 0; i < saidas.Count(); i++)
            {
                var j = (saidas.Count() - 1) - i;

                if (x[i].Elemento != y[j].Elemento)
                {
                    return false;
                }
            }
            return true;

        }

        static bool EhFila(IEnumerable<Operacoes> entradas, IEnumerable<Operacoes> saidas)
        {
           
            var x = saidas.ToArray();
            var y = entradas.ToArray();
            for (int i = 0; i < saidas.Count(); i++)
            {
                if (x[i].Elemento != y[i].Elemento)
                {
                    return false;
                }
            }
            return true;

        }

      
        
    }

}
