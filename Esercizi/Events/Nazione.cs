using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    internal class Nazione
    {
        public string Name { get; set; }
        public delegate void OnPositivesChangedEventHandler(object sender, PositivesEventArgs e);
        public event OnPositivesChangedEventHandler PositivesChanged;
        int _positives;

        public int Positives
        {
            get { return _positives; }
            set
            {
                if (_positives != value)
                {

                    PositivesEventArgs e = new PositivesEventArgs(value);
                    
                    _positives = value;

                    PositivesChanged(this, e);
                }
            }
        }
    }
}
