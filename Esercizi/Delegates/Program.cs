using System;
using static Delegates.Program;

namespace Delegates
{
    internal class Program
    {
        public delegate int SommaDelegate(int a, int b);
        public delegate int ExecuteDelegate(SommaDelegate sumFunction);

        static void Main()
        {
            SommaDelegate sumFunction = Somma;

            ExecuteDelegate exeDelegate = Esegui;

            EseguiTutto(exeDelegate);

            Console.ReadLine();
        }

        public static void EseguiTutto(ExecuteDelegate exeDelegate)
        {
            exeDelegate(Somma);
        }

        public static int Somma(int a, int b)
        { 
            return a + b; 
        }
        public static int Esegui(SommaDelegate funzioneSomma)
        {
            int risultato = funzioneSomma(3,5);
            Console.WriteLine(risultato);
            return risultato;
        }

    }
}
