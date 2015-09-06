using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Appliance
    {
        //
        // Fields and Properties
        //
        #region Fields and Properties

        public int ApplianceID { get; set; }
        public string Name { get; set; }
        public string ApplianceType { get; set; }
        public double Wattage { get; set; }
        public short PinID { get; set; }
        public bool IsDigital { get; set; }
        public bool Active { get; set; }
        public bool Restricted { get; set; }
        public int AddedBy { get; set; }
        #endregion


        //
        // Constructors
        //
        #region Constructors

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        public Appliance()
        {
            ApplianceID = -1;
            Name = "";
            ApplianceType = "";
            Wattage = -1d;
            PinID = -1;
            IsDigital = false;
            Active = false;
            Restricted = true;
            AddedBy = -1;
        }

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        public Appliance(int applianceID, string name, string applianceType, double wattage, short pinID, bool isDigital, bool active, bool restricted, int addedBy)
        {
            ApplianceID = applianceID;
            Name = name;
            ApplianceType = applianceType;
            Wattage = wattage;
            PinID = pinID;
            IsDigital = isDigital;
            Active = active;
            Restricted = restricted;
            AddedBy = addedBy;
        }
        #endregion
    }
}
