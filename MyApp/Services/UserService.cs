using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyApp.Models;
using MyApp.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using MyApp.Functions;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace MyApp.Services
{
    public class UserService : IRepository<UserViewModels>
    {
        public IEnumerable<UserAccountListTemplate> List
        {
            get
            {
                using (var db = new MADBEntities())
                {
                    var result = (from u in db.tb_User
                                  where u.STATUS == true
                                  select new UserAccountListTemplate()
                                  {
                                      id = u.USER_ID,
                                      code = u.USER_CODE,
                                      name = u.LAST_NAME + " " + u.FIRST_NAME,
                                      phone_number = u.PHONE_NUMBER,
                                      role_id = u.ROLE_ID
                                  }).ToList();
                    return result;
                }
            }
        }

        public void Add(UserViewModels entity)
        {
            using(var db = new MADBEntities())
            {
                var obj = new tb_User();
                obj.USER_ID = CreateUser(entity);
                obj.USER_CODE = CodeGenerate.UserCode();
                obj.FIRST_NAME = entity.First_Name;
                obj.LAST_NAME = entity.Last_Name;
                obj.GENDER = entity.Gender;
                obj.DOB = entity.DOB;
                obj.PHONE_NUMBER = entity.Phone_Number;
                obj.ADDRESS = entity.Address;
                obj.USER_NAME = entity.User_Name;
                obj.PWD = Crypto.HashPassword(entity.Password);
                obj.STATUS = entity.Status;
                obj.IS_FIRST_LOG = true;
                obj.ROLE_ID = entity.User_Role;
                obj.CREATE_AT = DateTime.Now;
                obj.CREATE_BY = HttpContext.Current.User.Identity.GetUserId();
                db.tb_User.Add(obj);
                db.SaveChanges();

                Task.Run(async () => await AssignRole(entity.User_Role, obj.USER_ID));
            }
        }

        public void Delete(UserViewModels entity)
        {
            throw new NotImplementedException();
        }

        public UserViewModels FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(UserViewModels entity)
        {
            throw new NotImplementedException();
        }

        private string CreateUser(UserViewModels model)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!context.Users.Any(t => t.UserName == model.User_Name))
            {
                var user = new ApplicationUser();
                user.UserName = model.User_Name;
                userManager.Create(user, model.Password);
                context.SaveChanges();
                return user.Id;
            }
            return null;
        }

        private async Task AssignRole(int ID, string UserID)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            foreach(var RoleName in Functions.Functions.getRoleByID(ID))
            {
                var isInRole = await userManager.IsInRoleAsync(UserID, RoleName);
                if (!isInRole)
                {
                    await userManager.AddToRoleAsync(UserID, RoleName);
                }
            }
        }

        public void ChangePassword(ChangeNewPassword model)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var user = userManager.FindById(HttpContext.Current.User.Identity.GetUserId());
            if(user != null)
            {
                userManager.RemovePassword(user.Id);
                userManager.AddPassword(user.Id, model.ConfirmPassword);

                using(var db = new MADBEntities())
                {
                    db.pm_AppFirstLog(user.Id, Crypto.HashPassword(model.ConfirmPassword));
                }
            }
        }

        public static bool IsFirstLogIn(string userName, string pwd)
        {
            using (var db = new MADBEntities())
            {
                var user = db.tb_User.Where(x => x.USER_NAME.Equals(userName)).FirstOrDefault();
                if (user != null && Crypto.VerifyHashedPassword(user.PWD, pwd) && user.IS_FIRST_LOG != null) return true;
            }
            return false;
        }
    }


    public class UserAccountListTemplate
    {
        public string id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string phone_number { get; set; }
        public int? role_id { get; set; }

        public string getRoleName()
        {
            using(var db = new MADBEntities())
            {
                var name = db.tb_Role_Permission.Find(this.role_id).ROLE_NAME;
                return name;
            }
        }
    }
}