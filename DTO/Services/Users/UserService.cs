using AutoMapper;
using Domian.Configurations;
using Domian.Entities;
using IRepository.IGenericRepository;
using Microsoft.EntityFrameworkCore;
using Services.DTOs.Users;
using Services.Exceptions;
using Services.Extensions;
using Services.IServies.Users;
using System.Linq.Expressions;

namespace Services.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IGenericRepositoryAsync<User> userRepository;
        private readonly IMapper mapper;
        public UserService(IGenericRepositoryAsync<User> userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async ValueTask<UserForViewDTO> CreateAsync(UserForCreationDTO userForCreationDTO)
        {
           var alreadyuser = await  userRepository.GetAsync(c=>c.FirstName==userForCreationDTO.FirstName);

            if (alreadyuser != null)
                throw new BelissimoCloneWPFException(400, "User with such username already exist");

            var user = await userRepository.CreateAsync(mapper.Map<User>(userForCreationDTO));

            await userRepository.SaveChangesAsync();

            return mapper.Map<UserForViewDTO>(user);
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isdelete= await userRepository.DeleteAsync(c=>c.Id==id);

            if (!isdelete)
                throw new BelissimoCloneWPFException(404, "User Not Delete");

            await userRepository.SaveChangesAsync();

            return isdelete;
        }

        public async ValueTask<IEnumerable<UserForViewDTO>> GetAllAsync(PaginationParams @params, Expression<Func<User, bool>> expression = null)
        {
            var users = userRepository.GetAllAsync(expression: expression, isTracking: true);

            return mapper.Map<IEnumerable<UserForViewDTO>>(await users.ToPagedList(@params).ToListAsync());
        }

        public async ValueTask<UserForViewDTO> GetAsync(Expression<Func<User, bool>> expression)
        {
            var user = await userRepository.GetAsync(expression);

            if (user == null)
                throw new BelissimoCloneWPFException(404, "User Not fount");

            return mapper.Map<UserForViewDTO>(user);
        }

        public async ValueTask<UserForViewDTO> UpdateAsync(int id, UserForUpdateDTO userForUpdateDTO)
        {
           var userData = await userRepository.GetAsync(c=>c.Id== id);

            if (userData == null)
                throw new BelissimoCloneWPFException(404, "User Not Update");

            userData = userRepository.Update(mapper.Map(userForUpdateDTO, userData));

            await userRepository.SaveChangesAsync();

            return mapper.Map<UserForViewDTO>(userData);
        }

       public  async ValueTask<bool> ChangePasswordAsync(UserForChangePasswordDTO changePassword)
        {
            var user = await userRepository.GetAsync(x => x.Login.Equals(changePassword.Login) && x.Password.Equals(changePassword.OldPassword));

            if (user == null)
                throw new BelissimoCloneWPFException(400, "User Not Found");

            if (user.Password == changePassword.NewPassword)
                throw new BelissimoCloneWPFException(400, "Password in Incorrect");

            user.Password=changePassword.NewPassword;

            userRepository.Update(user);

            await userRepository.SaveChangesAsync();

            return true;  
        }
    }
}
