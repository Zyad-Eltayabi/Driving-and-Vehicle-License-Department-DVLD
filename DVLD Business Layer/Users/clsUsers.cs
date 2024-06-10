using DVLD_Database_Layer.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer.Users
{
    public class clsUsers
    {



        public static DataTable GetUsers()
        {
            return clsUsersDB.GetUsers();
        }
    }
}
