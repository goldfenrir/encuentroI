using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpgGame
{
    class LoadFiles
    {
        public string[] getArchs()
        {
            
            // obtain names of all logical drives on the computer.
            System.IO.DriveInfo di = new System.IO.DriveInfo(@"C:\");
            System.IO.DirectoryInfo dirInfo = di.RootDirectory;
            System.IO.FileInfo[] fileNames = dirInfo.GetFiles("*.*");
            string currentDirName = System.IO.Directory.GetCurrentDirectory();
            string[] files = System.IO.Directory.GetFiles(currentDirName, "*.bin");

            return files;
        }
    }

}
