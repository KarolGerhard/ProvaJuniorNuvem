using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Lanchinho
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciou!");

            var dadosPedido = obterDadosArquivoPedido();
            var dadosProduto = obterDadosArquivoProduto();

            Console.WriteLine("Fechando a conta...");

            var dadosConta = (
                from Pedido pedido in dadosPedido
                join Produto produto in dadosProduto on pedido.codigo equals produto.codigo
                select new Conta
                {
                    total = pedido.quantidade * produto.preco
                }).ToList();

            Console.WriteLine("Gerando novo arquivo!");

            StreamWriter conta;
            string caminhoArquivo = @"C:\Arquivo Prova\saida.txt";

            conta = File.CreateText(caminhoArquivo);

            foreach (Conta i in dadosConta)
            {
                conta.WriteLine((i));
            }

            Console.WriteLine("Sucesso!  Arquivo gerado");
            conta.Close();

            static List<Pedido> obterDadosArquivoPedido()
            {
                var pedidos = new List<Pedido>();
                var file = @"C:\Arquivo Prova\entrada.csv";
                if (File.Exists(file))
                {
                    using (Stream entrada = File.Open(file, FileMode.Open))
                    using (StreamReader leitor = new StreamReader(entrada))
                    {
                        string linha = leitor.ReadLine();
                        var ehPrimeiraLinha = true;

                        while (!string.IsNullOrWhiteSpace(linha))
                        {
                            if (ehPrimeiraLinha)
                            {
                                linha = leitor.ReadLine();
                                ehPrimeiraLinha = false;
                            }

                            var colunas = linha.Split(";");

                            Pedido pedido = new Pedido()
                            {
                                codigo = int.Parse(colunas[0]),
                                quantidade = int.Parse(colunas[1])
                            };

                            pedidos.Add(pedido);

                            linha = leitor.ReadLine();
                        }
                    }
                }
                return pedidos;
            }

            static List<Produto> obterDadosArquivoProduto()
            {
                var produtos = new List<Produto>();
                var file = @"C:\Arquivo Prova\entradaLanchinho.csv";
                if (File.Exists(file))
                {
                    using (Stream entrada = File.Open(file, FileMode.Open))
                    using (StreamReader leitor = new StreamReader(entrada))
                    {
                        string linha = leitor.ReadLine();
                        var ehPrimeiraLinha = true;

                        while (!string.IsNullOrWhiteSpace(linha))
                        {
                            if (ehPrimeiraLinha)
                            {
                                linha = leitor.ReadLine();
                                ehPrimeiraLinha = false;
                            }

                            var colunas = linha.Split(";");

                            var produto = new Produto()
                            {
                                codigo = int.Parse(colunas[0]),
                                especificacao = colunas[1],
                                preco = double.Parse(colunas[2].Replace('.', ','))
                            };

                            produtos.Add(produto);

                            linha = leitor.ReadLine();
                        }
                    }
                }
                return produtos;
            }
        }
    }
}
