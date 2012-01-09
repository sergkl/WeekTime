
namespace WeekTimeProgram
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// This class helps to work with day of week and times
    /// </summary>
    [DebuggerDisplay("{DayOfWeek} {Time}")]
    public class WeekTime
    {
        /// <summary>
        /// Initializes a new instance of the WeekTime class. Constructor creates WeekTime 
        /// object with zero values
        /// </summary>
        public WeekTime()
        {
            Time = TimeSpan.Zero;
            DayOfWeek = DayOfWeek.Sunday;
        }

        /// <summary>
        /// Initializes a new instance of the WeekTime class. Constructor creates WeekTime 
        /// object with time which are set as parameter and DayOfWeek is Sunday
        /// </summary>
        /// <param name="time">Time whick will be set to object</param>
        public WeekTime(TimeSpan time)
        {
            Time = time;
            DayOfWeek = DayOfWeek.Sunday;
        }

        /// <summary>
        /// Initializes a new instance of the WeekTime class. Constructor creates WeekTime 
        /// object with TimeSpan.Zero for Time propery. DayOfWeek is set from constructor's parameter
        /// </summary>
        /// <param name="dayOfWeek">DayOfWeek is set from this value</param>
        public WeekTime(DayOfWeek dayOfWeek)
        {
            Time = TimeSpan.Zero;
            DayOfWeek = dayOfWeek;
        }

        /// <summary>
        /// Initializes a new instance of the WeekTime class. Constructor creates WeekTime 
        /// object selected values
        /// </summary>
        /// <param name="dayOfWeek">DayOfWeek is set from this value</param>
        /// <param name="time">Time is set from this value</param>
        public WeekTime(DayOfWeek dayOfWeek, TimeSpan time)
        {
            Time = time;
            DayOfWeek = dayOfWeek;
        }

        /// <summary>
        /// Initializes a new instance of the WeekTime class. Constructor creates WeekTime 
        /// object from WeekTime object and copies all properties to new object
        /// </summary>
        /// <param name="weekTime">DayOfWeek is set from this value</param>
        public WeekTime(WeekTime weekTime)
        {
            Time = weekTime.Time;
            DayOfWeek = weekTime.DayOfWeek;
        }

        /// <summary>
        /// Gets or sets day of week for the object
        /// </summary>
        public DayOfWeek DayOfWeek { get; set; }

        /// <summary>
        /// Gets or sets time of week for the object
        /// </summary>
        public TimeSpan Time { get; set; }

        /// <summary>
        /// Overloaded operator which allows to add TimeSpan value to WeekTime
        /// </summary>
        /// <param name="weekTime">WeekTime value</param>
        /// <param name="time">TimeSpan value</param>
        /// <returns>As a result receives WeekTime object equals WeekTime + TimeSpan</returns>
        public static WeekTime operator +(WeekTime weekTime, TimeSpan time)
        {
            var result = weekTime.Clone();
            result.Time += time;
            result.Normalize();
            return result;
        }

        /// <summary>
        /// Overloaded operator which allows to subtract TimeSpan value from WeekTime
        /// </summary>
        /// <param name="weekTime">WeekTime value</param>
        /// <param name="time">TimeSpan value</param>
        /// <returns>As a result it returns WeekTime object equals WeekTime - TimeSpan</returns>
        public static WeekTime operator -(WeekTime weekTime, TimeSpan time)
        {
            var result = weekTime.Clone();
            result.Time -= time;
            result.Normalize();
            return result;
        }

        /// <summary>
        /// Overloaded operator which allows to compare two WeekTime objects
        /// </summary>
        /// <param name="weekTime1">Left WeekTime object</param>
        /// <param name="weekTime2">Right WeekTime object</param>
        /// <returns>As a result it returns bool value as a result from comparison</returns>
        public static bool operator ==(WeekTime weekTime1, WeekTime weekTime2)
        {
            return weekTime1.Time == weekTime2.Time && weekTime1.DayOfWeek == weekTime2.DayOfWeek;
        }

        /// <summary>
        /// Overloaded operator which returns true if objects are not equal
        /// </summary>
        /// <param name="weekTime1">Left WeekTime object</param>
        /// <param name="weekTime2">Right WeekTime object</param>
        /// <returns>Returns true if objects are not equal</returns>
        public static bool operator !=(WeekTime weekTime1, WeekTime weekTime2)
        {
            return weekTime1.Time != weekTime2.Time || weekTime1.DayOfWeek != weekTime2.DayOfWeek;
        }

        /// <summary>
        /// Override the Object.Equals(object o) method:
        /// </summary>
        /// <param name="anotherWeekTime">Object for comparison with current object</param>
        /// <returns>Returns true if objects are equal</returns>
        public override bool Equals(object anotherWeekTime)
        {
            return this == (WeekTime)anotherWeekTime;
        }

        /// <summary>
        /// Overriding the Object.GetHashCode() method
        /// </summary>
        /// <returns>Returns hash code for the object</returns>
        public override int GetHashCode()
        {
            return (TimeSpan.FromDays((int)this.DayOfWeek) + this.Time).GetHashCode();
        }

        /// <summary>
        /// Method creates new cloned WeekTime object by current WeekTime object
        /// </summary>
        /// <returns>Returns new cloned WeekTime object by current WeekTime object</returns>
        public WeekTime Clone()
        {
            return new WeekTime(this);
        }

        /// <summary>
        /// Method normalize current object. I.e. if in TimeSpan we have days greater than 1 or 
        /// less than 0 then we change day of week and normalize TimeSpan object
        /// </summary>
        private void Normalize()
        {
            var result = this;

            if (result.Time.Days >= 1)
            {
                result.DayOfWeek = result.DayOfWeek.AddDays(result.Time.Days);
                result.Time -= TimeSpan.FromDays(result.Time.Days);
            }
            else if (result.Time.Days < 0)
            {
                result.DayOfWeek = result.DayOfWeek.AddDays(result.Time.Days);
                result.Time -= TimeSpan.FromDays(result.Time.Days);
                result.Time = TimeSpan.FromHours(24) + result.Time;
            }
        }
    }
}
