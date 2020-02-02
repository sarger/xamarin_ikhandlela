using System;
using System.Collections.Generic;
using System.Text;

namespace FarmingApp.Helper
{
  
        public static class Settings
        {
            private const string Test_BaseUrl = "http://mnelisi.com/Api/";
            private const string Live_BaseUrl = "http://mnelisi.com/Api/";

            public static string GetBaseURL(string PhpFile)
            {
#if RELEASE
            return Live_BaseUrl+ PhpFile;
#else
                return Test_BaseUrl + PhpFile;
#endif
            }



        }


    public class Version 
    {

        public async System.Threading.Tasks.Task isAppUpdatedAsync()
        {

           

        }
    
    }
  
}
