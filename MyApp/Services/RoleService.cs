using MyApp.Models;
using System;
using System.Collections.Generic;


namespace MyApp.Services
{
    public class RoleService : IRepository<RoleViewModels>
    {
        public IEnumerable<RoleViewModels> List
        {
            get
            {
                return this.getList();
            }
        }

        public void Add(RoleViewModels entity)
        {
            try
            {
                using (var db = new Entity.MADBEntities())
                {
                    var role = new Entity.tb_Role_Permission();
                    role.ROLE_NAME = entity.name;
                    role.DESCRIPTION = entity.description;
                    db.tb_Role_Permission.Add(role);
                    db.SaveChanges();

                    //Save Role Name
                    foreach (var i in entity.roles)
                    {
                        var roleDetail = new Entity.tb_Role_Prsn_Detail();
                        roleDetail.RP_ID = role.RP_ID;
                        roleDetail.ROLE_NAME = i;
                        db.tb_Role_Prsn_Detail.Add(roleDetail);
                        db.SaveChanges();
                    }
                }
            }
            catch(Exception ex)
            {
                Modules.AppLogger.writeLog(entity.ToString(), ex.Message);
            }
        }

        public void Delete(RoleViewModels entity)
        {
            throw new NotImplementedException();
        }

        public RoleViewModels FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(RoleViewModels entity)
        {
            throw new NotImplementedException();
        }


        private IEnumerable<RoleViewModels> getList()
        {
            return null;
        }
    }
}