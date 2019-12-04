using System.Linq;

namespace MyApp.Modules
{
    public enum SweetAlertType
    {
        success,
        warning,
        info
    }

    public class SweetAlert2Helper
    {
        public string type { get; set; }
        public string header { get; set; }
        public string message { get; set; }



        public SweetAlert2Helper(string code, SweetAlertType sweetType)
        {
            switch (sweetType)
            {
                case SweetAlertType.success:
                    this.header = Resource.Successfully;
                    this.type = sweetType.ToString();
                    break;

                case SweetAlertType.warning:
                    this.header = Resource.Successfully;
                    this.type = sweetType.ToString();
                    break;
            }
            this.message = new Entity.MADBEntities().pm_GetMessage(code, LanguageManager.getCurrentLanguage()).First<string>();
        }

        public SweetAlert2Helper(string header, string message, string type)
        {
            this.header = header;
            this.message = message;
            this.type = type;
        }
    }
}