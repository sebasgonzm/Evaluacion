using Microsoft.VisualBasic;
using System;

namespace Evaluacion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1, num2;
            Binario binario;


            // Validación para que el primer número sea mayor que el segundo
            do
            {
                Console.Write("Ingrese el primer número: ");
                num1 = int.Parse(Console.ReadLine());

                Console.Write("Ingrese el segundo número: ");
                num2 = int.Parse(Console.ReadLine());

                try
                {
                    binario = new Binario(num1, num2);
                    break;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.ReadKey();
                Console.Clear();

            } while (true);

            // Muestra los números de forma binaria
            binario.Carga();

            // Menú de opciones para que el usuario indique la acción a realizar
            Console.WriteLine("Selecciona una opción:");
            Console.WriteLine("1. Sumar los números en binario");
            Console.WriteLine("2. Restar los números en binario");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine("La suma de los números en binario es: ");
                    Console.WriteLine(binario.Conversion(num1)+"+");
                    Console.WriteLine(binario.Conversion(num2));
                    Console.WriteLine("----------");
                    Console.WriteLine(binario.Suma());
                    break;
                case 2:
                    Console.WriteLine("La resta de los números en binario es: ");
                    Console.WriteLine(binario.Conversion(num1) + "-");
                    Console.WriteLine(binario.Conversion(num2));
                    Console.WriteLine("----------");
                    Console.WriteLine(binario.Resta());
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}
