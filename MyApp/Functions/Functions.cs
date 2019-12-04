using MyApp.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApp.Functions
{
    public class RoleTemplateList
    {
        public string ROLENAME { get; set; }
        public string ROLE_LABEL { get; set; }

        public List<String> SUB_ROLES = new List<string>();
    }
    public class Functions
    {
        public static List<SelectListItem> getGenderList()
        {
            if(LanguageManager.getCurrentLanguage() == "KH")
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem() { Text = "ស្រី", Value = "Female" },
                    new SelectListItem() { Text = "ប្រុស", Value = "Male" }
                };
            }

                return new List<SelectListItem>()
                {
                    new SelectListItem() { Text = "Female", Value = "Female" },
                    new SelectListItem() { Text = "Male", Value = "Male" }
                };
        }

        public static List<SelectListItem> getRoleList()
        {
            using (var db = new Entity.MADBEntities())
            {
                var list = db.tb_Role_Permission
                             .Where(x => x.STATUS != false)
                             .Select(x => new SelectListItem()
                             {
                                Value = x.RP_ID.ToString(),
                                Text = x.ROLE_NAME
                             })
                             .ToList();
                return list;
            }
        }

        public static List<RoleTemplateList> getRoleMasterList()
        {
            using(var db = new Entity.MADBEntities())
            {
                var lang = LanguageManager.getCurrentLanguage();
                var list = db.AspNetRoles
                             .Where(x => x.Name != "Admin" && x.IS_MASTER_ROLE == true)
                             .Select(x => new RoleTemplateList() {
                                 ROLENAME = x.Name,
                                 ROLE_LABEL = db.tb_LblCaption.FirstOrDefault(y => y.APP == x.Name && y.LANGUAGE_CODE == lang).LB_CAPTION,
                                 SUB_ROLES = db.AspNetRoles.Where(y => y.PARENTS_KEY.Equals(x.Name)).OrderBy(y => y.ORDER_NUM).Select(y => y.Name).ToList()
                             })
                             .ToList();
                return list;
            }
        }

        public static List<string> getRoleByID(int ID)
        {
            using(var db = new Entity.MADBEntities())
            {
                var list = (from r in db.tb_Role_Permission
                            join rd in db.tb_Role_Prsn_Detail on r.RP_ID equals rd.RP_ID
                            where r.RP_ID == ID
                            select rd.ROLE_NAME
                            ).ToList();
                return list;
            }
        }

    }
}