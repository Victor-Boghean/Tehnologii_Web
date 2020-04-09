using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic.Core
{
    public class UserApi
    {
        internal ULoginResp ULoginAction(ULoginData data)
        {
            UDbTable result;

            using(var db = new UserContext())
            {
                result = db.Users.FirstOrDefault(u => u.Username == data.Username && u.Password == data.Password);
            }
            
            if(result == null)
            {
                return new ULoginResp
                {
                    Status = false,
                    StatusMsg = "The username or password is incorrect"
                };
            }
            return new ULoginResp { Status = true };
        }
    }
}
