using System;

namespace FibonacciInteressante
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insira um numero");
            int numero  = Convert.ToInt32(Console.ReadLine());

            if (numero > 45)
            {
                Console.WriteLine("Insira um numero novamente: ");
            }
            else
            {
                Console.WriteLine(Fibonacci(numero));
            }

            Console.ReadKey();
        }

        static int Fibonacci(int n)
        {
            if(n == 1)
            {
                return 0;
            }
            else if(n <= 1){
                return 1;
            }
            else
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }

        }
    }
}
