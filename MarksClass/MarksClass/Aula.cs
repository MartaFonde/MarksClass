using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarksClass
{
    class Aula
    {
        private int[,] notas;
        public string[] alumnos;
        public string[] asignaturas;
        private double total;
        public List<int> listAprob = new List<int>();

        public Aula(string[] alum)
        {
            alumnos = alum;
            asignaturas = Enum.GetNames(typeof(Asignaturas));
            notas = new int[alum.Length, Enum.GetNames(typeof(Asignaturas)).Length];
            AsignacionNotas();
        }
        public int this[int alum, int asig]
        {
            get
            {
                return notas[alum, asig];
            }
        }        
        public void AsignacionNotas()
        {
            Random nota = new Random();
            Random prob = new Random();
            int p;

            for (int i = 0; i < notas.GetLength(0); i++)
            {
                for (int j = 0; j < notas.GetLength(1); j++)
                {
                    p = prob.Next(1, 46);
                    if (p < 5)
                    {
                        notas[i, j] = nota.Next(0, 3);
                    }
                    else if (p < 15)
                    {
                        notas[i, j] = 3;
                    }
                    else if (p < 30)
                    {
                        notas[i, j] = nota.Next(4, 7);
                    }
                    else if (p < 40)
                    {
                        notas[i, j] = nota.Next(7, 9);
                    }
                    else
                    {
                        notas[i, j] = nota.Next(9, 11);
                    }
                }
            }
        }
        public double MediaTabla()
        {
            total = 0;
            for (int i = 0; i < notas.GetLength(0); i++)
            {
                for (int j = 0; j < notas.GetLength(1); j++)
                {
                    total += notas[i, j];
                }
            }
            return total / (notas.GetLength(0) * notas.GetLength(1));
        }

        public double MediaAlumno(int alum)
        {
            total = 0;
            for (int i = 0; i < notas.GetLength(1); i++)
            {
                total += notas[alum, i];
            }
            return total / notas.GetLength(1);
        }

        public double MediaAsignatura(int asig)
        {
            total = 0;
            for (int i = 0; i < notas.GetLength(0); i++)
            {
                total += notas[i, asig];
            }
            return total / notas.GetLength(0);
        }

        public int[] NotasAlumno(int r)
        {
            int[] row = new int[notas.GetLength(1)];
            for (int i = 0; i < notas.GetLength(1); i++)
            {
                row[i] = notas[r, i];
            }
            return row;
        }

        public int[] NotasAsignatura(int c)
        {
            int[] col = new int[notas.GetLength(0)];
            for (int i = 0; i < notas.GetLength(0); i++)
            {
                col[i] = notas[i, c];
            }
            return col;
        }
        public void NotaMinMax(int alum, ref int min, ref int max)
        {
            for (int i = 0; i < notas.GetLength(1); i++)
            {
                if (notas[alum, i] < min)
                {
                    min = notas[alum, i];
                }
                if (notas[alum, i] > max)
                {
                    max = notas[alum, i];
                }
            }
        }
        public int[,] Aprobados()
        {            
            for (int i = 0; i < alumnos.Length; i++)
            {
                int min = 10;
                int max = 0;
                NotaMinMax(i, ref min, ref max);
                if (min >= 5)
                {
                    listAprob.Add(i);   //id de alum aprobados --> row
                }                
            }
            int[,] tablaAprobados = new int[listAprob.Count,notas.GetLength(1)];
            for (int i = 0; i < tablaAprobados.GetLength(0); i++)
            {
                for (int j = 0; j < tablaAprobados.GetLength(1); j++)
                {
                    tablaAprobados[i, j] = this[listAprob.ElementAt(i), j];
                }
            }
            return tablaAprobados;
        }
    }
}
