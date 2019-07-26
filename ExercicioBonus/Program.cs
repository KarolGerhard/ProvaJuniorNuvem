using System;
using System.Collections.Generic;
using System.IO;

namespace ExercicioBonus
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            //static List<Assassinato> obterDados()
            //{
            //    var assassinatos = new List<Assassinato>();
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
                        //x = linha.
                        //var colunas = linha.Split(" ");
                        if (ehPrimeiraLinha)
                        {
                             primeiro = Convert.ToInt32(linha);
                            Console.WriteLine(primeiro);

                        }

                        for (int i = 0; i <= primeiro; i++)
                        {

                        }




                        linha = leitor.ReadLine();
                    }
                }
            }

            //if (assassinatos.Count > 105)
            //{
            //    throw new Exception("Devera conter no maximo 105 entradas");
            //}
            //return assassinatos;
        }
    }

}

