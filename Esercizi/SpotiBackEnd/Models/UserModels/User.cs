using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotiBackEnd.Models.MediaModels;

namespace SpotiBackEnd.Models.UserModels
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
