using DVLD_Database_Layer.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer.Login
{
    public static class clsLogin
    {
        public static int userID;
        public static int personID;
        public static string userName = string.Empty;
        public static string password = string.Empty;


        public static bool IsExists(string userName, string password)
        {
            if (clsLoginDB.IsExists(ref clsLogin.userID, ref clsLogin.personID, userName, password))
            {
                clsLogin.userName = userName;
                clsLogin.password = password;
                return true;
            }
            return false;
        }

        public static bool IsActive(string userName, string password)
        {
            return clsLoginDB.IsActive(userName, password);
        }

    }
}
