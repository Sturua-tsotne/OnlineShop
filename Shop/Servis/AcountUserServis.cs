using Shop.Models;
using Shop.Models.DB;
using System;
using System.Linq;
using WebApplication1.Helper;

namespace Acount.Servise
{
    public class AcountUserServis 
    {
        public bool InsertUserNotRegister(RegistrationModel RegistrationModel)
        {

            using (GeotonEntities db = new GeotonEntities())
            {


                var Email = db.AuthenticUsers.FirstOrDefault(x => x.Email == RegistrationModel.Email);
                if (Email != null)
                {
                    return false;
                }
                else
                {
                    var ConfirmatioCodeqsh = GlobalHelper.Random32();
                    db.UserNotRegistrations.Add(new UserNotRegistration()
                    {
                        Name = RegistrationModel.Name,
                        Surname = RegistrationModel.Surname,
                        Email = RegistrationModel.Email,
                        CreateData = DateTime.Now,
                        ConfirmatioCode = ConfirmatioCodeqsh,
                        Password = GlobalHelper.MD5Hash(RegistrationModel.Password)
                    });

                    db.SaveChanges();
                    return true;
                }


            }

        }

        public bool UserConfirmation(string id)
        {
            using (GeotonEntities db = new GeotonEntities())
            {
                var ConfiUser = db.UserNotRegistrations.FirstOrDefault(x => x.ConfirmatioCode == id);
                if (ConfiUser != null)
                {           
                        db.AuthenticUsers.Add(new AuthenticUser()
                        {
                            Name = ConfiUser.Name,
                            Surname = ConfiUser.Surname,
                            Email = ConfiUser.Email,
                            Password = ConfiUser.Password,
                            CreateData = DateTime.Now,

                        });
                        db.UserNotRegistrations.RemoveRange(db.UserNotRegistrations.Where(x => x.Email == ConfiUser.Email));
                        db.SaveChanges();
                    
                   
                       return true;
                    

                }

                else
                {

                    return false;

                }
            }
        }

        public AuthenticUser Login(LoginModel loginModel)
        {
            using (GeotonEntities db = new GeotonEntities())
            {
                var PasMD5 = GlobalHelper.MD5Hash(loginModel.Password);
                var user = db.AuthenticUsers
                    .Where(x => x.Email == loginModel.Email && x.Password == PasMD5).Select(x => x).FirstOrDefault();
                return user;
            }
        }
    }




}