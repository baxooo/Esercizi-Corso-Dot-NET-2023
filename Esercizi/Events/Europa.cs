using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    internal class Europa
    {
        int _allPositives;
        private static List<Nazione> Nazioni = new List<Nazione>();
        public int AllPositives
        {
            get {  return _allPositives; }
        }

        public void AddNation(Nazione nazione)
        {
            Nazioni.Add(nazione);

            nazione.PositivesChanged += CalculatePositives;
        }

        private void CalculatePositives(object sender, PositivesEventArgs e)
        {
            _allPositives = Nazioni.Sum(x => x.Positives);
        }
    }
}
