using System;

namespace Spk.Common.Helpers.Enum
{
    [Flags, Serializable]
    public enum DaysOfWeek
    {
        /// <summary>No days</summary>
        None = 0,
        /// <summary>Occurs on Sunday</summary>
        Sunday = 1,
        /// <summary>Occurs on Monday</summary>
        Monday = 2,
        /// <summary>Occurs on Tuesday</summary>
        Tuesday = 4,
        /// <summary>Occurs on Wednesday</summary>
        Wednesday = 8,
        /// <summary>Occurs on Thursday</summary>
        Thursday = 16,
        /// <summary>Occurs on Friday</summary>
        Friday = 32,
        /// <summary>Occurs on Saturday</summary>
        Saturday = 64,
        /// <summary>Occurs on weekdays only (Monday through Friday)</summary>
        Weekdays = 62,
        /// <summary>Occurs on weekends only (Saturday and Sunday)</summary>
        Weekends = 65,
        /// <summary>Occurs on every day of the week</summary>
        EveryDay = 127
    }
}
