using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewerTestFramework.Utilities;

namespace ViewerTestFramework.Main.Helpers
{
    public static class JSONHelper
    {
        public static dynamic jsonVals;
        public static dynamic GetEnvironmentData(string env, string fileName)
        {
            dynamic json = JsonUtils.LoadJsonData(fileName);
            jsonVals = json[env];
            return json[env];
        }

        public static string GetUserCredentials(string userType, string credentialType)
        {
            return jsonVals["usercreds"][userType][credentialType].ToString();
        }

        public static string GetJSONKeyValue(string key)
        {
            return jsonVals[key].ToString();
        }

        public static string GetProjectID()
        {
            string projectID = ConfigurationManager.AppSettings["Project"];
            return jsonVals["ProjectTest"][projectID]["project"].ToString();
        }

    }
}
