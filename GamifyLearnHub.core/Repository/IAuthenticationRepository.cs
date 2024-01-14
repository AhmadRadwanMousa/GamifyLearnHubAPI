using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Repository
{
    public interface IAuthenticationRepository
    {

        Task<TokenPayload> Login(LoginCredentails loginDetails);
        Task<int> IsUserNameExist(string userName);
        Task<int> ResetPassword(LoginCredentails loginDetails);

    }
}
