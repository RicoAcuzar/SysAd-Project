using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    /// <summary>
    /// Contains the record for a schedule.
    /// </summary>
    public class Schedule
    {
        //
        // Fields and Properties
        //
        #region Fields and Properties

        public int ScheduleID { get; set; }
        public int ApplianceID { get; set; }
        public short SetValue { get; set; }
        public string ScheduleType { get; set; }
        public string Repetition { get; set; }
        public DateTime LowerLimit { get; set; }
        public DateTime UpperLimit { get; set; }
        #endregion


        //
        // Constructors
        //
        #region Constructors

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        public Schedule()
        {
            ScheduleID = -1;
            ApplianceID = -1;
            SetValue = -1;
            ScheduleType = "";
            Repetition = "";
            LowerLimit = DateTime.MinValue;
            UpperLimit = DateTime.MinValue;
        }

        /// <summary>
        /// Creates an instance of this class.
        /// </summary>
        public Schedule(int scheduleID, int applianceID, short setValue, string scheduleType, string repetition, DateTime lowerLimit, DateTime upperLimit)
        {
            ScheduleID = scheduleID;
            ApplianceID = applianceID;
            SetValue = setValue;
            ScheduleType = scheduleType;
            Repetition = repetition;
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
        }
        #endregion
    }
}
