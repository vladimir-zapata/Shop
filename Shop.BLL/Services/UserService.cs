using System;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Extensions.Logging;
using Shop.BLL.Contract;
using Shop.BLL.Core;
using Shop.BLL.Dtos;
using Shop.BLL.Models;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;


namespace Shop.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly ILogger<UserService> logger;
       

        public UserService(IUserRepository userRepository,
                           ILogger<UserService> logger)
        {
            this.userRepository = userRepository;
            this.logger = logger;
        }
        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("consultando los usuarios");
                var users = this.userRepository
                                .GetEntities()
                                .Select(us => new UserModel() 
                                {
                                 UserId= us.UserId,
                                 Email= us.Email,
                                 Name= us.Name,
                                }).ToList();
                result.Data = users;
                this.logger.LogInformation("Se han consultados los Usuarios");

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los usuarios";
                this.logger.LogError($"{result.Message}",ex.ToString());
            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                this.logger.LogInformation("consultando el usuario");

                var user = this.userRepository.GetEntity(id);  
                UserModel usermodel = new UserModel() 
                {
                    UserId = user.UserId,
                    Email = user.Email,
                    Name = user.Name,
                };
                result.Data = usermodel;

                this.logger.LogInformation("se consulto el usuario");
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error obteniendo el usuario";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }

        public ServiceResult RemoveUser(UserRemoveDtos userRemove)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var user = userRepository.GetEntity(userRemove.UserId);

                user.DeleteUser = userRemove.RequestUser;
                user.DeleteDate= DateTime.Now;  
                user.Deleted= true; 


                this.userRepository.Update(user);
            }
            catch (Exception ex)
            {
                result.Message = "Error removiendo el usuario";
                result.Success = false;
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;  
        }
        public ServiceResult SaveUser(UserAddDtos userAddDtos)
        {
            ServiceResult result = new ServiceResult();

            User user = new User() 
            {
                CreationDate= DateTime.Now,
                Name = userAddDtos.Name,
                Email= userAddDtos.Email,
                Password= userAddDtos.Password,
                CreationUser= userAddDtos.RequestUser
            };

            try
            {
                this.userRepository.Save(user);
            }
            catch (Exception ex)
            {
                result.Message = "Error agregando el usuario";
                result.Success = false;
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
        public ServiceResult UpdateUser(UserUpdateDtos userUpdateDtos)
        {
            ServiceResult result = new ServiceResult();

            User user = this.userRepository.GetEntity(userUpdateDtos.UserId);

            if (user == null) 
            {
                result.Success = false;
                result.Message = "Usuario no encontrado";
                return result;
            }

            user.ModifyDate = DateTime.Now;
            user.Name = userUpdateDtos.Name;
            user.Email = userUpdateDtos.Email;
            user.Password = userUpdateDtos.Password;
            user.ModifyUser = userUpdateDtos.RequestUser;

            try
            {
                this.userRepository.Update(user);
            }
            catch (Exception ex)
            {
                result.Message = "Error agregando el usuario";
                result.Success = false;
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;
        }
    }
}
