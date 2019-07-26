using System;

namespace ExtracaoDeDiamantes
{
    class Program
    {
        static int Main(string[] args)
        {
            int numero;
            string teste;
            int count;
            int temp;

            Console.WriteLine("Insira a quantidade de teste: ");
            numero = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Insira o teste: ");
            for (int i = 0; i < numero; ++i)
            {
                teste = Console.ReadLine();
                int x = teste.Length;
                Console.WriteLine(x);
                count = 0;
                temp = 0;


                for (int j = 0; j < x; ++j)
                {
                    if (teste[j] == '<')
                    {
                        temp++;
                    }
                    if (teste[j] == '>' && temp > 0)
                    {
                        count++;
                        temp--;
                    }
                }
                Console.WriteLine("Saida: " + count);
            }
            return 0;

        }

    }
}
