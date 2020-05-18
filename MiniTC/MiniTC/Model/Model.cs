using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTC.Model
{
    class Model
    {
        #region fields
        #endregion

        #region methods
        public Model()
        {
        }

        public string[] GetDrives()
        {
            string[] result = Directory.GetLogicalDrives();
            return result;
        }

        public bool CopyFile(string source, string destination)
        {
            if (source == ".." || source.Contains("<D>") || destination == null || destination == "")
            {
                return false;
            }
            string[] tmp = source.Split('\\');
            string filename = tmp[tmp.Length - 1];
            string finalDest = destination + "\\" + filename;
            try
            {
            File.Copy(source, finalDest, true);
            }
            catch (Exception)
            {
                Debug.WriteLine("brak dostępu");
                return false;
            }
            return true;
        }

        public string[] GetFiles(string path)
        {
            string[] tmpDirectories = Directory.GetDirectories(path);
            string[] tmpFiles = Directory.GetFiles(path);
            int maxLength = tmpDirectories.Length + tmpFiles.Length + 1;
            string[] result = new string[maxLength];
            int j = 0;
            result[j] = "..";
            j++;
            for (int i = 0; i < tmpDirectories.Length; i++)
            {
                result[j] = "<D>" + tmpDirectories[i];
                j++;
            }
            for (int i = 0; i < tmpFiles.Length; i++)
            {
                result[j] = tmpFiles[i];
                j++;
            }
            return result;
        }
        #endregion
    }
}
