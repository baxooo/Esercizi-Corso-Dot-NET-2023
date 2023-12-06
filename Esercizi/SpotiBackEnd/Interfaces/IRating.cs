using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiBackEnd.Interfaces
{
    public interface IRating
    {
        public int Id { get; set; }
        public int Rating { get; set; }
    }
}
