using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using NCalc;

namespace Area_por_punto_medio
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sqrt(([x] +[y]) / 2)
            //8 / (Pow((([x] + [y]) / 2), 2) + 1)
            //Tan((PI*([x] + [y]) / 2)/8)
            //Cos(Sqrt(([x] + [y]) / 2))

            string Cont = "SI";
            while (Cont == "SI")
            {
                Console.WriteLine("\n Defina Expresión matematica");
                string expression = Console.ReadLine();
                double a, b, n;
                double midpoint = 0, aAcu = 0, bAcu = 0;
                double DeltaX = 0;

                Console.WriteLine("Defina limite inicial: ");
                a = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Defina limite final: ");
                b = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Defina cantidad de rectangulos: ");
                n = Convert.ToDouble(Console.ReadLine());

                DeltaX = (b - a) / n;

                Expression e = new Expression(expression);

                // aAcu = a + DeltaX;
                // midpoint += Math.Sqrt((aAcu)) / 2;
                //   Console.WriteLine(DeltaX);
                //   Console.WriteLine(midpoint);

                // ejercicio 77
                /*
                for (int i = 0; i < n; i++)
                {
                    if (i == 0)
                    {
                        aAcu += a;
                        bAcu = aAcu + DeltaX;
                        Console.WriteLine("a: "+aAcu);
                        Console.WriteLine("b: " + bAcu);
                        Console.WriteLine("result: " + Math.Sqrt((aAcu + bAcu) / 2));
                        midpoint += Math.Sqrt((aAcu + bAcu) / 2);
                        Console.WriteLine(midpoint);
                    }
                    else
                    {
                        aAcu += DeltaX;
                        bAcu = aAcu + DeltaX;
                      //  Console.WriteLine("a: " + aAcu);
                     //   Console.WriteLine("b: " + bAcu);
                        Console.WriteLine("result: " + Math.Sqrt((aAcu + bAcu) / 2));
                        midpoint += Math.Sqrt((aAcu + bAcu)/ 2) ;
                   //     Console.WriteLine(midpoint);
                    }
                }
                */

                //Ejercicio 78
                /*
                for (int i = 0; i < n; i++)
                {
                    if (i == 0)
                    {
                        aAcu += a;
                        bAcu = aAcu + DeltaX;
                        Console.WriteLine("a: " + aAcu);
                        Console.WriteLine("b: " + bAcu);
                        Console.WriteLine("result: " + 8/(Math.Pow(((aAcu + bAcu) / 2),2)+1));
                        midpoint += 8 / (Math.Pow(((aAcu + bAcu) / 2), 2)+ 1);
                Console.WriteLine(midpoint);
                    }
                    else
                    {
                        aAcu += DeltaX;
                        bAcu = aAcu + DeltaX;
                        //  Console.WriteLine("a: " + aAcu);
                        //   Console.WriteLine("b: " + bAcu);
                        Console.WriteLine("result: " + 8 / (Math.Pow(((aAcu + bAcu) / 2), 2) + 1));
                        midpoint += 8 / (Math.Pow(((aAcu + bAcu) / 2), 2) + 1);
                        //     Console.WriteLine(midpoint);
                    }
                }
                */
                //ejercicio 79
                /*
                for (int i = 0; i < n; i++)
                {
                    if (i == 0)
                    {
                        aAcu += a;
                        bAcu = aAcu + DeltaX;
                        Console.WriteLine("a: " + aAcu);
                        Console.WriteLine("b: " + bAcu);
                        Console.WriteLine("result: " + Math.Tan((Math.PI*(aAcu + bAcu) / 2)/8));
                        midpoint += Math.Tan((Math.PI * (aAcu + bAcu) / 2) / 8);
                        Console.WriteLine(midpoint);
                    }
                    else
                    {
                        aAcu += DeltaX;
                        bAcu = aAcu + DeltaX;
                        //  Console.WriteLine("a: " + aAcu);
                        //   Console.WriteLine("b: " + bAcu);
                        Console.WriteLine("result: " + Math.Tan((Math.PI * (aAcu + bAcu) / 2) / 8));
                        midpoint += Math.Tan((Math.PI * (aAcu + bAcu) / 2) / 8);
                        //     Console.WriteLine(midpoint);
                    }
                }
                */

                for (int i = 0; i < n; i++)
                {
                    if (i == 0)
                    {
                        aAcu += a;
                        bAcu = aAcu + DeltaX;
                        //  Console.WriteLine("a: " + aAcu);
                        //  Console.WriteLine("b: " + bAcu);
                        e.Parameters["x"] = aAcu;
                        e.Parameters["y"] = bAcu;
                        e.Parameters["PI"] = Math.PI;

                        Console.WriteLine(e.Evaluate());

                        midpoint += (double)e.Evaluate();

                    }
                    else
                    {
                        aAcu += DeltaX;
                        bAcu = aAcu + DeltaX;
                        e.Parameters["x"] = aAcu;
                        e.Parameters["y"] = bAcu;

                        Console.WriteLine(e.Evaluate());

                        midpoint += (double)e.Evaluate();


                    }
                }
                Console.WriteLine("\n Area Primedio es igual a : ");
                Console.WriteLine(DeltaX * midpoint);

                Console.WriteLine("\n Desea Continuar?");
                Cont = Console.ReadLine();
                Cont = Cont.ToUpper();

            }
        }
    }
}


