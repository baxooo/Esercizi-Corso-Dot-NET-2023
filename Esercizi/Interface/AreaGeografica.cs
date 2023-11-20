using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    internal class AreaGeografica
    {
        protected int _positionX;
        protected int _positionY;

        public AreaGeografica(int positionX, int positionY)
        {
            _positionX = positionX;
            _positionY = positionY;
        }
    }
}
