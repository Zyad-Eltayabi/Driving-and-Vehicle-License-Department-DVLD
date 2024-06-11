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
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public enum Mode { Add, Update }

        public Mode enMode { get; set; }

        public clsUsers()
        {
            UserID = 0;
            PersonID = 0;
            UserName = string.Empty;
            Password = string.Empty;
            IsActive = false;
            enMode = Mode.Add;
        }

        private clsUsers(int userID, int personID, string userName, string password, bool isActive)
        {
            UserID = userID;
            PersonID = personID;
            UserName = userName;
            Password = password;
            IsActive = isActive;
            this.enMode = Mode.Update;
        }

        public static clsUsers GetUserByID(int userID)
        {
            int personID = 0;
            string userName = string.Empty;
            string password = string.Empty;
            bool isActive = false;

            if (clsUsersDB.GetUserByID(userID, ref personID, ref userName, ref password, ref isActive))
            {
                return new clsUsers(userID, personID, userName, password, isActive);
            }
            return null;
        }

        private bool AddNewUser()
        {
            this.UserID = clsUsersDB.AddNewUser(PersonID, UserName, Password, IsActive);
            return this.UserID != -1;
        }
        public static DataTable GetUsers()
        {
            return clsUsersDB.GetUsers();
        }

        public static bool IsPersonAlreadyUser(int personID)
        {
            return clsUsersDB.IsPersonAlreadyUser(personID);
        }

        private bool UpdateUser()
        {
            return clsUsersDB.UpdateUser(this.UserID, this.UserName, this.Password, this.IsActive);
        }

        public bool Save()
        {
            switch (enMode)
            {
                case Mode.Add:
                    enMode = Mode.Update;
                    return this.AddNewUser();
                case Mode.Update:
                    return UpdateUser();
                default:
                    return false;
            }

        }
    }
}
