using AutoMapper;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Entities.Product;
using eUseControl.Domain.Entities.User;
using eUseControl.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace eUseControl.BusinessLogic.Core
{
    public class UserApi
    {   
        
        internal ULoginResp ULoginAction(ULoginData data)
        {
            UDbTable result;
            var validate = new EmailAddressAttribute();

            var pass = LoginHelper.HashGen(data.Password);
            using (var db = new UserContext())
            {
                result = db.Users.FirstOrDefault(u => u.Email == data.Email && u.Password == pass);
            }

            if (result == null)
            {
                return new ULoginResp
                {
                    Status = false,
                    StatusMsg = "Adresa de email sau parola este incorectă."
                };
            }

            using (var todo = new UserContext())
            {
                result.LasIp = data.LoginIp;
                result.LastLogin = data.LoginDateTime;
                todo.Entry(result).State = EntityState.Modified;
                todo.SaveChanges();
            }
            return new ULoginResp { Status = true };
        }

       
        
        internal URegisterResp URegisterAction(URegisterData data)
        {
            var pass = LoginHelper.HashGen(data.Password);
            UDbTable insert = new UDbTable
            {
                Username = data.Username,
                Password = pass,
                Email = data.Email,
                Level = "User",
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

        
        
        internal HttpCookie Cookie(string Email)
        {
            var apiCookie = new HttpCookie("X-KEY")
            {
                Value = CookieGenerator.Create(Email)
            };

            using (var db = new SessionContext())
            {
                Session curent;
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(Email))
                {
                    curent = (from e in db.Sessions where e.Username == Email select e).FirstOrDefault();
                }
                else
                {
                    curent = (from e in db.Sessions where e.Username == Email select e).FirstOrDefault();
                }

                if (curent != null)
                {
                    curent.CookieString = apiCookie.Value;
                    curent.ExpireTime = DateTime.Now.AddMinutes(60);
                    using (var todo = new SessionContext())
                    {
                        todo.Entry(curent).State = EntityState.Modified;
                        todo.SaveChanges();
                    }
                }
                else
                {
                    db.Sessions.Add(new Session
                    {
                        Username = Email,
                        CookieString = apiCookie.Value,
                        ExpireTime = DateTime.Now.AddMinutes(60)
                    });
                    db.SaveChanges();
                }
            }
            return apiCookie;
        }

        
        
        internal UserMinimal UserCookie(string cookie)
        {
            Session session;
            UDbTable curentUser;

            using (var db = new SessionContext())
            {
                session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
            }

            if (session == null) return null;
            using (var db = new UserContext())
            {
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(session.Username))
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Email == session.Username);
                }
                else
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Username == session.Username);
                }
            }

            if (curentUser == null) return null;
            Mapper.Initialize(cfg => cfg.CreateMap<UDbTable, UserMinimal>());
            var userminimal = Mapper.Map<UserMinimal>(curentUser);

            return userminimal;

        }

       
        
        internal PEditResp PEditAction(PEditData data)
        {

            ProductDbTable edit = new ProductDbTable()
            {
                Id = data.Id,
                Price = data.Price,
                ProdusName = "Dell XPS 13 7390"
            };
            int result;
            using(var db = new ProductContext())
            {
                db.Entry(edit).State = EntityState.Modified;
                result = db.SaveChanges();
            }
            result = 1;
            if(result == 0)
            {
                return new PEditResp 
                {
                    Status = false,
                    StatusMsg = "Datele nu au putut fi salvate"
                };
            }
            else
            {
                return new PEditResp { Status = true };
            }    


            
        }

       
        
        internal PRegisterResp PRegisterAction(PRegisterData data)
        {
            ProductDbTable insert = new ProductDbTable()
            {
                Price = "30.999",
                ProdusName = "DELL XPS 1379"
            };
            int result;

            using (var db = new ProductContext())
            {
                db.Products.Add(insert);
                result = db.SaveChanges();
            }

            if (result == 0)
            {
                return new PRegisterResp
                {
                    Status = false,
                    StatusMsg = "Datele nu au putut fi salvate"
                };
            }
            return new PRegisterResp
            {
                Status = true
            };
        }

    }
}
