using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulApplication.XamarinForms.Services
{
  public static  class Settings
    {
        private const string Test_BaseUrl = "http://localhost/mnelisi/Api/";
        private const string Live_BaseUrl = "http://mnelisi.com/Api/";

        public static string GetBaseURL(string PhpFile) 
        {
#if RELEASE
            return Live_BaseUrl+ PhpFile;
#else
            return Test_BaseUrl+ PhpFile;
    #endif
        }



    }
}
