using eUseControl.Domain.Entities.Product;
using eUseControl.Domain.Entities.User;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic.Interfaces
{
    public interface ISession
    {
        ULoginResp UserLogin(ULoginData data);
        URegisterResp UserRegister(URegisterData data);
        PRegisterResp ProductRegister(PRegisterData data);
        PEditResp ProductEdit(PEditData data);
        HttpCookie GenCookie(string Email);
        UserMinimal GetUserByCookie(string apiCookieValue);
    }
}
