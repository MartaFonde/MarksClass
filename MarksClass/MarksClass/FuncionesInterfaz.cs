using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarksClass
{
    class FuncionesInterfaz
    { 
        public static bool PedirDato(out string id, int min = 0, int max = 9)
        {
            bool valido = false;
            id = "";
            int num;
            while (!valido)
            {
                try
                {
                    valido = true;
                    id = Console.ReadLine().Trim();
                    num = Convert.ToInt32(id);
                    if (num < min || num > max)
                    {
                        throw new ArgumentException();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Debes introducir un número");
                    valido = false;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Dato inválido");
                    valido = false;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Valor fuera de rango (" + min + "-" + max + ")");
                    valido = false;
                }
            }
            return valido;
        }

        public static void TablaNotas(Aula a, string[] alumnos, int numAsig, int posAlum = -1, int posAsig = -1)
        {
            Console.Write("{0, 24} |", " ");

            if (posAsig != -1)      // 1 asig
            {
                Console.Write("{0,2}. {1,11} |\n", posAsig, Enum.GetName(typeof(Asignaturas), posAsig));
            }
            else      //todas asig
            {
                for (int i = 0; i < numAsig; i++)
                {
                    if (posAlum != -1 || (posAlum == -1 && posAsig == -1))
                    {
                        Console.Write(i < numAsig - 1 ? "{0,2}. {1,11} |" : "{0,2}. {1,11} |\n", i, Enum.GetName(typeof(Asignaturas), i));
                    }
                }
            }
            if (posAlum != -1)      // 1 alum
            {
                Console.Write("{0,2}. {1, 20} |", posAlum, alumnos[posAlum]);
                if (posAsig != -1)       // 1 asig
                {
                    Console.WriteLine("{0,15} |\n", a[posAlum, posAsig]);
                }
                else         //todas asig
                {
                    for (int k = 0; k < numAsig; k++)
                    {
                        Console.Write(k < numAsig - 1 ? "{0,15} |" : "{0,15} |\n", a[posAlum, k]);
                    }
                }
            }
            else
            {
                for (int j = 0; j < alumnos.Length; j++)        //todos alum
                {
                    Console.Write("{0,2}. {1, 20} |", j, alumnos[j]);
                    if (posAlum == -1 && posAsig != -1)           // 1 nota/alum -> 1 asig
                    {
                        Console.Write("{0,15} |\n", a[j, posAsig]);
                    }
                    else
                    {
                        for (int k = 0; k < numAsig; k++)       //todas las notas
                        {
                            Console.Write(k < numAsig - 1 ? "{0,15} |" : "{0,15} |\n", a[j, k]);
                        }
                    }
                }
            }
        }
        public static void TablaAprobados(Aula a, string[] alumnos, int numAsig, List<int> aprob)
        {
            if (aprob.Count > 0)
            {
                int k = 0;
                Console.Write("{0, 24} |", " ");

                for (int i = 0; i < numAsig; i++)
                {
                    Console.Write(i < numAsig - 1 ? "{0,2}. {1,11} |" : "{0,2}. {1,11} |\n", i, Enum.GetName(typeof(Asignaturas), i));
                }
                for (int i = 0; i < alumnos.Length; i++)
                {
                    if (i == aprob.ElementAt(k))
                    {
                        Console.Write("{0,2}. {1, 20} |", i, alumnos[i]);
                        for (int j = 0; j < numAsig; j++)
                        {
                            Console.Write(j < numAsig - 1 ? "{0,15} |" : "{0,15} |\n", a[i, j]);
                        }
                        k++;
                        if (k == aprob.Count)
                        {
                            i = alumnos.Length;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Ningún alumno ha aprobado todo");
            }
        }
    }
}
