using System;

namespace MarksClass
{
    public enum Asignaturas
    {
        LINGUA,
        MATEMÁTICAS,
        HISTORIA,
        FILOSOFÍA
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] alum = { "CARLOS GONZÁLEZ", "LUCÍA CACHEDA", "JAVIER HITA", "SANTIAGO GARCÍA", "MARTÍN ZALABEITE", "SANDRA LÓPEZ", "LAURA MATO", "MILAGROS RODRÍGUEZ", "ALEJANDRO CACHEDA", "JUAN RABELO", "SONIA LEDO", "NOELIA PEREIRA" };
            Aula aula = new Aula(alum);
            int numAsig = Enum.GetNames(typeof(Asignaturas)).Length;

            string opcion;
            int op = 0;
            string id = "";
            int ind;
            bool valido = false;

            do
            {
                Console.WriteLine("--- ALUMNOS / NOTAS ---");
                Console.WriteLine("1. Calcular la media de notas de todos los alumnos");
                Console.WriteLine("2. Media de un alumno");
                Console.WriteLine("3. Media de una asignatura");
                Console.WriteLine("4. Visualizar notas de un alumno");
                Console.WriteLine("5. Visualizar notas de una asignatura");
                Console.WriteLine("6. Visualizar nota de un alumno en una asignatura");
                Console.WriteLine("7. Nota máxima y mínima de un alumno");
                Console.WriteLine("8. Tabla sólo de aprobados");
                Console.WriteLine("9. Visualizar tabla completa de notas");
                Console.WriteLine("10. Salir");
                if (valido = MuestraDatos.PedirDato(out opcion, 1, 10) && alum.Length > 0)
                {
                    op = Convert.ToInt32(opcion);
                    switch (op)
                    {
                        case 1:
                            Console.WriteLine("Media: {0:0.00}", aula.MediaTabla());
                            break;
                        case 2:
                            Console.WriteLine("Introduce el ID del alumno: ");
                            if (MuestraDatos.PedirDato(out id, 0, alum.Length - 1))
                            {
                                ind = Convert.ToInt32(id);
                                Console.WriteLine("Alumno: {0}\nMedia: {1:0.00}", alum[ind], aula.MediaAlumno(ind));
                            }
                            break;
                        case 3:
                            Console.WriteLine("Introduce el ID de la asignatura: ");
                            if (MuestraDatos.PedirDato(out id, 0, numAsig - 1))
                            {
                                ind = Convert.ToInt32(id);
                                Console.WriteLine("Asignatura: {0}\nMedia: {1:0.00}", Enum.GetName(typeof(Asignaturas), ind), aula.MediaAsignatura(ind));
                            }
                            break;
                        case 4:
                            Console.WriteLine("Introduce el ID del alumno: ");
                            if (MuestraDatos.PedirDato(out id, 0, alum.Length - 1))
                            {
                                MuestraDatos.NotasAlumno(aula, Convert.ToInt32(id));
                            }
                            break;
                        case 5:
                            Console.WriteLine("Introduce el ID de la asignatura: ");
                            if (MuestraDatos.PedirDato(out id, 0, numAsig - 1))
                            {
                                MuestraDatos.NotasAsignatura(aula, Convert.ToInt32(id));
                            }
                            break;
                        case 6:
                            Console.WriteLine("Introduce el ID del alumno: ");
                            if (MuestraDatos.PedirDato(out id, 0, alum.Length - 1))
                            {
                                int alu = Convert.ToInt32(id);
                                Console.WriteLine("Introduce el ID de la asignatura: ");
                                if (MuestraDatos.PedirDato(out id, 0, numAsig - 1))
                                {
                                    int asig = Convert.ToInt32(id);
                                    MuestraDatos.NotasAsigAlumno(aula, alu, asig);
                                }
                            }
                            break;
                        case 7:
                            Console.WriteLine("Introduce el ID del alumno: ");
                            if (MuestraDatos.PedirDato(out id, 0, alum.Length - 1))
                            {
                                int min = 10;
                                int max = 0;
                                ind = Convert.ToInt32(id);
                                aula.NotaMinMax(ind, ref min, ref max);
                                Console.WriteLine("Alumno: {0}\nNota mínima: {1}\nNota máxima: {2}", alum[ind], min, max);
                            }
                            break;
                        case 8:
                            MuestraDatos.TablaAprobados(aula);
                            break;
                        case 9:
                            MuestraDatos.Tabla(aula);
                            break;
                        case 10:
                            Console.WriteLine("Abur");
                            break;
                    }
                    Console.WriteLine();
                }
            } while (op != 10 || !valido);
        }
    }
}

