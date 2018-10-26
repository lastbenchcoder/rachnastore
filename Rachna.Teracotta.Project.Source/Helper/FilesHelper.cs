using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Rachna.Teracotta.Project.Source.Helper
{
    public static class FilesHelper
    {
        public static void DeleteFilesOlderThen5Days()
        {
            if (File.Exists(HttpContext.Current.Server.MapPath("~/Db_Script/")) && File.Exists(HttpContext.Current.Server.MapPath("~/Web_Source/")))
            {
                string[] filesDB = Directory.GetFiles(HttpContext.Current.Server.MapPath("~/Db_Script/"));
                foreach (string file in filesDB)
                {
                    FileInfo fi = new FileInfo(file);
                    if (fi.LastAccessTime < DateTime.Now.AddDays(-5))
                        fi.Delete();
                }

                string[] filesWeb = Directory.GetFiles(System.Web.HttpContext.Current.Server.MapPath("~/Web_Source/"));
                foreach (string file in filesWeb)
                {
                    FileInfo fi = new FileInfo(file);
                    if (fi.LastAccessTime < DateTime.Now.AddDays(-5))
                        fi.Delete();
                }
            }
        }
    }
}