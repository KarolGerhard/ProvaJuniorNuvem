using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HallDosAssasinos
{
    class Program
    {
        static void Main(string[] args)
        {

            var dadosAssassinatos = obterDados();
            var assassinados = dadosAssassinatos.Select(x => x.Assassinado);

            var dadosSaida = dadosAssassinatos.Where(d => !assassinados.Contains(d.Assassino))
                .GroupBy(d => d.Assassino)
                .Select(d => new
                {
                    Assassino = d.Key,
                    Quantidade = d.Count()
                }).ToList();

            Console.WriteLine("HALL DOS ASSASSINOS");

            dadosSaida.ForEach(x => Console.WriteLine($"{x.Assassino} {x.Quantidade}"));

        }

        static List<Assassinato> obterDados()
        {
            var assassinatos = new List<Assassinato>();
            var file = @"C:\Arquivo Prova\entradaHallAssasinos.txt";
            if (File.Exists(file))
            {
                using (Stream entrada = File.Open(file, FileMode.Open))
                using (StreamReader leitor = new StreamReader(entrada))
                {
                    string linha = leitor.ReadLine();

                    while (!string.IsNullOrWhiteSpace(linha))
                    {
                        var colunas = linha.Split(" ");

                        var assassinato = new Assassinato()
                        {
                            Assassino = colunas[0],
                            Assassinado = colunas[1]
                        };

                        assassinatos.Add(assassinato);

                        linha = leitor.ReadLine();
                    }
                }
            }

            if (assassinatos.Count > 105)
            {
                throw new Exception("Devera conter no maximo 105 entradas");
            }
            return assassinatos;
        }
    }
}

