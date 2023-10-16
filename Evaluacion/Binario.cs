using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace Evaluacion
{
    internal class Binario
    {
        #region Constructor
        // Constructor que recibe dos números enteros

        private int num1, num2;
        public Binario(int num1, int num2)
        {
            if (num1 < num2)
            {
                throw new ArgumentException("El primer número debe ser mayor que el segundo");
            }

            this.num1 = num1;
            this.num2 = num2;
        }
        #endregion

        #region Método Conversión
        // Método para convertir un número a binario usando un bucle while
        public string Conversion(int num)
        {
            string binario = "";
            while (num > 0)
            {
                binario = (num % 2) + binario;
                num /= 2;
            }
            return binario;
        }
        #endregion

        #region Método Carga
        // Método para cargar los números
        public void Carga()
        {
            Console.WriteLine("El primer número en binario es: " + Conversion(num1));
            Console.WriteLine("El segundo número en binario es: " + Conversion(num2));
        }
        #endregion

        #region Método Suma
        // Método para sumar los números en binario
        public string Suma()
        {
            string binario1 = Conversion(num1);
            string binario2 = Conversion(num2);

            // Revisar que los dos números tengan la misma longitud
            int longitud = Math.Max(binario1.Length, binario2.Length);
            binario1 = binario1.PadLeft(longitud, '0');
            binario2 = binario2.PadLeft(longitud, '0');

            string resultado = "";
            int acarreo = 0;

            for (int i = longitud - 1; i >= 0; i--)
            {
                int bit1 = binario1[i] - '0';
                int bit2 = binario2[i] - '0';

                // Suma de bits
                int suma = bit1 + bit2 + acarreo;
                resultado = (suma % 2) + resultado;

                // Actualiza el acarreo
                acarreo = suma / 2;
            }

            // Si hay un acarreo después del último paso, lo añade al resultado
            if (acarreo != 0)
            {
                resultado = acarreo + resultado;
            }

            return resultado;
        }
        #endregion

        #region Método Resta
        // Método para restar los números en binario usando el complemento a dos
        public string Resta()
        {
            string binario1 = Conversion(num1);
            string binario2 = Conversion(num2);

            // Revisar que los dos números tengan la misma longitud
            int longitud = Math.Max(binario1.Length, binario2.Length);
            binario1 = binario1.PadLeft(longitud, '0');
            binario2 = binario2.PadLeft(longitud, '0');

            string resultado = "";

            // Complemento a dos del segundo número

            string complementonum2 = "";

            for (int i = 0; i < binario2.Length; i++)
            {
                if (binario2[i] == '0')
                    complementonum2 += '1';
                else
                    complementonum2 += '0';
            }

            // Sumar 1 al complemento del segundo número

            int acarreo = 1;
            char[] complementoarray = complementonum2.ToCharArray();

            for (int i = complementoarray.Length - 1; i >= 0; i--)
            {
                int bit = complementoarray[i] - '0';

                int sumacom = bit + acarreo;
                complementoarray[i] = (sumacom % 2).ToString()[0];
                acarreo = sumacom / 2;
            }

            // Sumar el primer número con el complemento a dos del segundo número

            acarreo = 0;

            for (int i = longitud - 1; i >= 0; i--)
            {
                int bit1 = binario1[i] - '0';
                int bit2 = complementoarray[i] - '0';

                int suma = bit1 + bit2 + acarreo;
                resultado = (suma % 2).ToString()[0] + resultado;
                acarreo = suma / 2;
            }

            //Eliminar ceros

            resultado = resultado.TrimStart('0');
            
            if (resultado.Length > 0)
            {
                return resultado;
            }
            else
            {
                return "0";
            }
        }
        #endregion
    }
}

