using MyApp.Application.DTO;
using MyApp.Application.Interfaces.Repositories;
using MyApp.Application.Interfaces.Security;
using MyApp.Application.Interfaces.Services;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepo;
        private readonly IPasswordHasher _passwordHasher;

        public UserServices(IUserRepository userRepo, IPasswordHasher passwordHasher)
        {
            _userRepo = userRepo;
            _passwordHasher = passwordHasher;
        }

        public async Task<ResponseDTO<UserDTO>> AddUserAsync(AddUserDTO dto)
        {
            try
            {
                var hashPassword = _passwordHasher.HashPassword(dto.Password);

                var user = new User(dto.FirstName, dto.MiddleName, dto.LastName, dto.Email, hashPassword, dto.Role);

                var addUser = await _userRepo.addUserAsync(user);

                return new ResponseDTO<UserDTO>
                {
                    Success = true,
                    Message = "User added successfully.",
                    Data = new UserDTO
                    {
                        UserId = addUser.UserId,
                        FirstName = addUser.FirstName,
                        MiddleName = addUser.MiddleName,
                        LastName = addUser.LastName,
                        Email = addUser.Email,
                        Role = addUser.Role
                    }
                };
            }
            catch(ArgumentException ex)
            {
                return new ResponseDTO<UserDTO>
                {
                    Success = false,
                    Message = ex.Message
                };

            }
        }

        public async Task<ResponseDTO<UserDTO>> DeleteUserAsync(int id)
        {
            try
            {
                var response = await _userRepo.deleteUserAsync(id);
                if(!response)
                {
                    return new ResponseDTO<UserDTO>
                    {
                        Success = false,
                        Message = "User not found."
                    };
                }

                await _userRepo.SaveChangesAsync();

                return new ResponseDTO<UserDTO>
                {
                    Success = true,
                    Message = "User deleted successfully."
                };


            }
            catch (Exception ex)
            {
                return new ResponseDTO<UserDTO>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ResponseDTO<IEnumerable<UserDTO>>> GetAllUserAsync()
        {
            try
            {
                var response = await _userRepo.getAllUserAsync();
                var user = response.Select(u => new UserDTO
                {
                    UserId = u.UserId,
                    FirstName = u.FirstName,
                    MiddleName = u.MiddleName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Role = u.Role
                });

                return new ResponseDTO<IEnumerable<UserDTO>>
                {
                    Success = true,
                    Message = "User's lists.",
                    Data = user
                };
            }
            catch(Exception ex)
            {
                return new ResponseDTO<IEnumerable<UserDTO>>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ResponseDTO<UserDTO>> GetUserByIDAsync(int id)
        {
            try
            {
                var response = await _userRepo.findUserByIDAsync(id);
                if(response == null)
                {
                    return new ResponseDTO<UserDTO>
                    {
                        Success = false,
                        Message = "User not found."
                    };
                }

                return new ResponseDTO<UserDTO>
                {
                    Success = true,
                    Message = "User information.",
                    Data = new UserDTO
                    {
                        UserId = response.UserId,
                        FirstName = response.FirstName,
                        MiddleName = response.MiddleName,
                        LastName = response.LastName,
                        Email = response.Email,
                        Role = response.Role
                    }
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<UserDTO>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ResponseDTO<UserDTO>> UpdatePasswordUserAsync(ChangePasswordUserDTO dto)
        { 
            try
            {
                var response = await _userRepo.findUserByIDAsync(dto.UserId);
                if(response == null)
                {
                    return new ResponseDTO<UserDTO>
                    {
                        Success = false,
                        Message = "User not found."
                    };
                }   
                
                var verifyPassword = _passwordHasher.VerifyPassword(response.HashPassword, dto.CurrentPassword);
                if(!verifyPassword)
                {
                    return new ResponseDTO<UserDTO>
                    {
                        Success = false,
                        Message = "Password mismatch."
                    };
                }

                var newPassword = _passwordHasher.HashPassword(dto.NewPassword);
                response.UpdatePassword(newPassword);

                await _userRepo.SaveChangesAsync();

                return new ResponseDTO<UserDTO>
                {
                    Success = true,
                    Message = "Password updated successfully.",
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO<UserDTO>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ResponseDTO<UserDTO>> UpdateUserAsync(UpdateUserDTO dto)
        {
            try
            {
                var user = await _userRepo.findUserByIDAsync(dto.UserId);
                if(user == null)
                {
                    return new ResponseDTO<UserDTO>
                    {
                        Success = false,
                        Message = "User not found."
                    };
                }

                user.UpdateUser(dto.FirstName, dto.MiddleName, dto.LastName, dto.Email, dto.Role);
                await _userRepo.SaveChangesAsync();

                return new ResponseDTO<UserDTO>
                {
                    Success = true,
                    Message = "User updated successfully.",
                    Data = new UserDTO
                    {
                        UserId = user.UserId,
                        FirstName = user.FirstName,
                        MiddleName = user.MiddleName,
                        LastName = user.LastName,
                        Email = user.Email,
                        Role = dto.Role
                    }
                };
            }
            catch (ArgumentException ex)
            {
                return new ResponseDTO<UserDTO>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
