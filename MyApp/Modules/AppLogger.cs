using System;
using System.IO;
using System.Text;

namespace MyApp.Modules
{
    public class AppLogger
    {
        public static void writeLog(string par ,string Message)
        {
            string path = @"D:\Log FIle\";
            string filePath = path + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
            AppLogger app = new AppLogger();

            if (!System.IO.File.Exists(filePath))
            {
                app.writeHeader(filePath);
                app.writeLogText(filePath, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), "ControllerName", "Action", par, Message);
            }
            else
            {
                app.writeLogText(filePath, DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), "ControllerName", "Action", par, Message);
            }
        }

        private void writeHeader(string filePath)
        {
            try
            {
                StringBuilder st = new StringBuilder();
                st.AppendLine("My app Log file header");
                st.AppendLine(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
                st.AppendLine("===========================================================================================================================================================================================================================");
                st.AppendLine("");
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.Write(st);
                    sw.Close();
                    st.Clear();
                }
            }
            catch (Exception) { }
        }

        private void writeLogText(string filePath, string datetime, string controller, string action, string para, string message)
        {
            try
            {
                StringBuilder st = new StringBuilder();
                st.Append("Date Time: " + datetime);
                st.Append("| Controller: " + controller);
                st.Append("| Action: " + action);
                st.Append("| Par: " + para);
                st.Append("| Message: " + message);

                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine(st);
                    sw.Close();
                    st.Clear();
                }
            }
            catch (Exception) { }
        }
       
    }
}