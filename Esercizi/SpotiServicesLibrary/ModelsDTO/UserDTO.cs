using SpotiBackEnd.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiServicesLibrary.ModelsDTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public UserDTO(UserListener user)
        {
            Id = user.Id;
        }
    }
}
