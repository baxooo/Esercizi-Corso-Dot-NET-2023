using SpotiBackEnd.Models.UserModels;

namespace SpotiServicesLibrary.ModelsDTO
{
    public class UserDTO : User
    {
        public UserDTO(UserListener user)
        {
            Id = user.Id;
        }
        public UserDTO()
        {
            
        }
    }
}
