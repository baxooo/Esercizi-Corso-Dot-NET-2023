using System;
using System.ComponentModel.DataAnnotations;
using static Delegates.Program;

namespace Delegates
{
    internal class Program
    {
        public delegate int SommaDelegate(int a, int b);
        public delegate int ExecuteDelegate(SommaDelegate sumFunction);
        
        private static int _x = 3;
        private static int _y = 5;
        static void Main()
        {
            SommaDelegate sumFunction = Somma;

            ExecuteDelegate exeDelegate = Esegui;

            EseguiTutto(exeDelegate);

            DelegatesSecondoEsercizio.DelegateSecondoEsercizio(_x,_y,6);


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
            int risultato = funzioneSomma(_x,_y);
            Console.WriteLine(risultato);
            return risultato;
        }
    }
}
