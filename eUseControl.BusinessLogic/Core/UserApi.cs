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

            using (var db = new UserContext())
            {
                result = db.Users.FirstOrDefault(u => u.Username == data.Username && u.Password == data.Password);
            }

            if (result == null)
            {
                return new ULoginResp
                {
                    Status = false,
                    StatusMsg = "Adresa de email sau parola este incorectă."
                };
            }
            return new ULoginResp { Status = true };
        }

        internal URegisterResp URegisterAction(URegisterData data)
        {
            UDbTable insert = new UDbTable
            {
                Username = data.Username,
                Password = data.Password,
                Email = data.Email,
                RegisterDate = DateTime.Now
            };
            int result;

            using (var db = new UserContext())
            {
                db.Users.Add(insert);
                result = db.SaveChanges();
            }

            if (result == 0)
            {
                return new URegisterResp
                {
                    Status = false,
                    StatusMsg = "Datele nu au putut fi salvate"
                };
            }
            return new URegisterResp
            {
                Status = true
            };
        }

    }
}
