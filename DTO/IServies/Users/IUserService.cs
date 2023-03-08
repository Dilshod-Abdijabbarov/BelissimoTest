using Domian.Configurations;
using Domian.Entities;
using Services.DTOs.Categories;
using Services.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServies.Users
{
    public interface IUserService
    {
        ValueTask<UserForViewDTO> CreateAsync(UserForCreationDTO userForCreationDTO);

        ValueTask<UserForViewDTO> UpdateAsync(int id, UserForUpdateDTO userForViewDTO);

        ValueTask<bool> DeleteAsync(int id);

        ValueTask<UserForViewDTO> GetAsync(Expression<Func<User, bool>> expression);

        ValueTask<IEnumerable<UserForViewDTO>> GetAllAsync(
            PaginationParams @params,
            Expression<Func<User, bool>> expression = null);

        ValueTask <bool> ChangePasswordAsync(UserForChangePasswordDTO userForChangePasswordDTO);
    }
}
