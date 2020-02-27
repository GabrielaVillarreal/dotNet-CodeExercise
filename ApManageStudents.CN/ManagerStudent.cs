using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApManageStudents.CN
{
    public class ManagerStudent
    {
        public string[] SearchStudent(string[] lines, int criteria, string value)
        {
            string[] valuesReturn=new string[lines.Count()];
            int i = 0;
            foreach (var line in lines)
            {
                var values = line.Split(';');
                
                if (values[criteria - 1].Contains(value))
                {
                    valuesReturn[i] = line;
                    i++;                   
                }
            }
            return valuesReturn;
        }
        public string[] RegisterStudent(string[] lines, string typeStudent, string Name, string Gender )
        {
            string[] valuesReturn = new string[lines.Count()];
            int vUltimoId = 0;
            string lineAdd = string.Empty;
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location).Replace("\\bin\\Debug", "");
            StringBuilder ObjStringBuilder = new StringBuilder();
            foreach (var line in lines)
            {
                
                var values = line.Split(';');
                if (values[0] != "ID")
                {
                    vUltimoId = Convert.ToInt32(values[0]);
                    ObjStringBuilder.AppendLine(line.TrimEnd('\r'));
                }
            }
            lineAdd = (vUltimoId +1) + ";" + typeStudent + ";" + Name + ";" + Gender + ";" + DateTime.Now.ToString("yyyyMMddHHmmss");
            ObjStringBuilder.AppendLine(lineAdd.TrimEnd('\r'));
          
            File.WriteAllText(path + @"/Files/studentSolution.csv", ObjStringBuilder.ToString());
            return valuesReturn;
        }
        public string[] DeleteStudent(string[] lines, string value)
        {
            string[] valuesReturn = new string[lines.Count()];
            int i = 0;
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location).Replace("\\bin\\Debug", "");
            StringBuilder ObjStringBuilder = new StringBuilder();
            foreach (var line in lines)
            {
                var values = line.Split(';');
                if (values[0] == value)
                {
                    valuesReturn[i] = line;
                    i++;
                    continue;
                }
                ObjStringBuilder.AppendLine(line.TrimEnd('\r'));
            }
            ObjStringBuilder.ToString().Remove(ObjStringBuilder.Length - 1);
            File.WriteAllText(path + @"/Files/studentSolution.csv", ObjStringBuilder.ToString());
            return valuesReturn;
        }
        public string[] ModifyStudent(string[] lines, int criteria, string idStudent, string value)
        {
            string[] valuesReturn = null;
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location).Replace("\\bin\\Debug", "");
            StringBuilder ObjStringBuilder = new StringBuilder();
            foreach (var line in lines)
            {
                var values = line.Split(';');
                if (values[0] == idStudent)
                {
                    valuesReturn = values;

                    ObjStringBuilder.AppendLine(line.Replace(values[criteria].ToString(), value).TrimEnd('\r'));
                    ObjStringBuilder.AppendLine(line.Replace(values[4].ToString(), DateTime.Now.ToString("yyyyMMddHHmmss")).TrimEnd('\r'));
                }
                else
                    ObjStringBuilder.AppendLine(line.TrimEnd('\r'));
            }
            File.WriteAllText(path + @"/Files/studentSolution.csv", ObjStringBuilder.ToString());
            return valuesReturn;
        }
       
    }
}
