using System;
using System.Collections.Generic;
using System.IO;

namespace GenioAdivinhacaoBonus
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var jogadas = new List<Operacoes>();
            var file = @"C:\Arquivo Prova\entradaAdivinhacao.txt";
            if (File.Exists(file))
            {
                using (Stream entrada = File.Open(file, FileMode.Open))
                using (StreamReader leitor = new StreamReader(entrada))
                {
                    string linha = leitor.ReadLine();
                    var ehPrimeiraLinha = true;

                    while (!string.IsNullOrWhiteSpace(linha))
                    {
                        int primeiro = 0;
                        if (ehPrimeiraLinha)
                        {
                            primeiro = Convert.ToInt32(linha);
                            Console.WriteLine(primeiro);
                        }

                        int N = primeiro;

                        for (int i = 0; i < N; i++)
                        {
                            linha = leitor.ReadLine();
                            Console.WriteLine(linha[0]);
                            var colunas = linha.Split(" ");
                            

                            var sacola = new Operacoes()
                            {
                                Comando = Convert.ToInt32(colunas[i]),
                                Elemento = Convert.ToInt32(colunas[i])
                            };

                            jogadas.Add(sacola);
                            Console.WriteLine(Convert.ToString(sacola.Comando), Convert.ToString(sacola.Elemento));
                        }



                        linha = leitor.ReadLine();
                    }
                }
            }


        }
    }

}
