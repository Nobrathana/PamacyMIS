using System;
using MyApp.Entity;
using System.Linq;

namespace MyApp.Functions
{
    public class CodeGenerate
    {

        public static string UserCode()
        {
            using(var db = new MADBEntities())
            {
                var count = db.tb_User.Where(x => x.STATUS == true).ToList().Count + 1;
                string UserCount = count.ToString().PadLeft(6, '0');
                string Code = $"MA-{UserCount}-{DateTime.Now.ToString("ddMMyy")}";
                return Code;
            }
        }

        public static string FLPassword()
        {
            Random ran = new Random();
            string code = (Convert.ToUInt32(((ran.NextDouble() * 900000) + 100000))).ToString();
            return code;
        }
    }
}