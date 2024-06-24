using DVLD_Database_Layer.Licenses.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer.Licenses.Drivers
{
    public class clsDrivers
    {
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public enum Mode { New = 1, Update = 2 }
        public Mode enMode { get; set; }

        public clsDrivers(int personID, int createdByUserID)
        {
            PersonID = personID;
            CreatedByUserID = createdByUserID;
            CreatedDate = DateTime.Now;
            enMode = Mode.New;
        }

        private bool AddNewDriver()
        {
            this.DriverID = clsDriversDB.AddNewDriver(this.PersonID,this.CreatedByUserID);
            return this.DriverID != -1;
        }

        public bool SaveDriver()
        {
            switch (enMode)
            {
                case Mode.New:
                    enMode = Mode.Update;
                    return AddNewDriver();
                default:
                   return false;
            }
        }

        public static int GetDriverID(int personID)
        {
            return clsDriversDB.GetDriverID(personID);
        }

    }
}
