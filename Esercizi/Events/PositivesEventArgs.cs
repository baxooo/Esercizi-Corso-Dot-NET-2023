using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    internal class PositivesEventArgs : EventArgs
    {
        int _newPositivesCount;

        public int NewPositivesCount { get { return _newPositivesCount; } }

        public PositivesEventArgs(int newPositivesCount)
        {
            _newPositivesCount = newPositivesCount;
        }
    }
}
