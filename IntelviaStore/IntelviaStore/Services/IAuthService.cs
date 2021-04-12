using IntelviaStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelviaStore.Services
{
   public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> GetTokenAsync(TokenRequestModel model);
        Task<string> AddRoleAsync(AddRoleModel model);
        Task<IEnumerable<ProductModel>> Get();
        Task<ProductModel> Get(int Id);
        Task<ProductModel> Create(ProductModel productModel);
        Task Update(ProductModel productModel);
        Task Delete(int Id);
    }
}
