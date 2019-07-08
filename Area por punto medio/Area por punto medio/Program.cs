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

                double a, b, n;
                double midpoint = 0, aAcu = 0, bAcu = 0;
                double DeltaX = 0;
                Console.WriteLine("\n Selecciona metodo 1) Punto medio  2) Trapezio");
                Byte select= Convert.ToByte( Console.ReadLine());


                Console.WriteLine("\n Defina Expresión matematica");
                string expression = Console.ReadLine();
                Console.WriteLine("Defina limite inicial: ");
                a = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Defina limite final: ");
                b = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Defina cantidad de divisiones: ");
                n = Convert.ToDouble(Console.ReadLine());

                DeltaX = (b - a) / n;
                Console.WriteLine("DeltaX: " + DeltaX);
                Expression e = new Expression(expression);

                

                switch (select)
                {

                    case 1:
                        { 
                            for (int i = 0; i < n; i++)
                            {
                                if (i == 0)
                                {
                                    aAcu += a;
                                    bAcu = aAcu + DeltaX;
                                    e.Parameters["x"] = aAcu;
                                    e.Parameters["y"] = bAcu;
                                    e.Parameters["PI"] = Math.PI;
                                    e.Parameters["T"] = (aAcu + bAcu) / 2;
                                    Console.WriteLine(e.Evaluate());
                                    midpoint += (double)e.Evaluate();

                                }
                                else
                                {
                                    aAcu += DeltaX;
                                    bAcu = aAcu + DeltaX;
                                    e.Parameters["x"] = aAcu;
                                    e.Parameters["y"] = bAcu;
                                    e.Parameters["PI"] = Math.PI;
                                    e.Parameters["T"] = (aAcu + bAcu) / 2;
                                    Console.WriteLine(e.Evaluate());
                                    midpoint += (double)e.Evaluate();


                                }
                            }
                            Console.WriteLine("\n Area Promedio es igual a : ");
                            Console.Write(DeltaX * midpoint);
                            break;
                        }


                    case 2:
                        {
 
                            for (int i = 0; i <n+1; i++)
                            {
                                if (i.Equals(0))
                                {
                                    aAcu += a + DeltaX;
                                    e.Parameters["x"] = a;
                                    Console.WriteLine(a);
                                    e.Parameters["y"] = bAcu;
                                    e.Parameters["PI"] = Math.PI;
                                    e.Parameters["T"] = (aAcu + bAcu) / 2;
                                    Console.WriteLine(e.Evaluate());
                                    midpoint += 0.5 * ((double)e.Evaluate());
                                }
                                else if (i==n) {
                                    Console.WriteLine(i+"final");
                                    aAcu += a;
                                    e.Parameters["x"] =a + (i * DeltaX);
                                    Console.WriteLine(0.5 * (a + (i * DeltaX)));
                                    e.Parameters["y"] = bAcu;
                                    e.Parameters["PI"] = Math.PI;
                                    e.Parameters["T"] = (aAcu + bAcu) / 2;
                                    Console.WriteLine(0.5 * ((double)e.Evaluate()));
                                    midpoint += 0.5 * ((double)e.Evaluate());
                                }
                                else
                                {
                                    Console.WriteLine(i);
                                    aAcu += a;
                                    e.Parameters["x"] = a + (i * DeltaX);
                                    Console.WriteLine(a + (i * DeltaX));
                                    e.Parameters["y"] = bAcu;
                                    e.Parameters["PI"] = Math.PI;
                                    e.Parameters["T"] = (aAcu + bAcu) / 2;
                                    Console.WriteLine(e.Evaluate());
                                    midpoint += (double)e.Evaluate();
                                }

                              }
      
                            }
                            Console.WriteLine("\n Area Promedio es igual a : ");
                            Console.Write((DeltaX) * midpoint);
                            break;
                        }
                Console.WriteLine("\n\n Desea Continuar?");
                Cont = Console.ReadLine();
                Cont = Cont.ToUpper();

                }


            }
        }
    }



