using MyApp.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces.Services
{
    public interface IUserServices
    {
        public Task<ResponseDTO<IEnumerable<UserDTO>>> GetAllUserAsync();
        public Task<ResponseDTO<UserDTO>> GetUserByIDAsync(int id);
        public Task<ResponseDTO<UserDTO>> AddUserAsync(AddUserDTO dto);
        public Task<ResponseDTO<UserDTO>> DeleteUserAsync(int id);
        public Task<ResponseDTO<UserDTO>> UpdateUserAsync(UpdateUserDTO dto);
        public Task<ResponseDTO<UserDTO>> UpdatePasswordUserAsync(ChangePasswordUserDTO dto);
    }
}
