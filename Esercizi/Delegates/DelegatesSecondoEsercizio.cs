using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    internal static class DelegatesSecondoEsercizio
    {
        public static void DelegateSecondoEsercizio(int x , int y, int max)
        {
            Func<int, int, int> sommaProdotto = (a, b) => a * b;

            Predicate<int> verificaProdotto = risultato => risultato > max;

            Action callback = () =>
            {
                Console.WriteLine($"Il prodotto è maggiore di {max}.");
            };

            EseguiOperazione(sommaProdotto, verificaProdotto, callback,x,y);
        }

        private static void EseguiOperazione(Func<int, int, int> sommaProdotto,
            Predicate<int> verificaProdotto, Action callback, int x, int y)
        {
            int risultatoProdotto = sommaProdotto(x, y);

            if (verificaProdotto(risultatoProdotto)) callback();
        }
    }
}
