
namespace WeekTimeProgram
{
    using System;

    public class WeekRange
    {
        /// <summary>
        /// Initializes a new instance of the WeekRange class. Constructor creates WeekRange object by selected values
        /// </summary>
        /// <param name="dayOfWeek">DayOfWeek when period starts</param>
        /// <param name="startTime">Start time</param>
        /// <param name="endTime">End time</param>
        public WeekRange(DayOfWeek dayOfWeek, TimeSpan startTime, TimeSpan endTime)
        {
            if (startTime.Days > 0 || endTime.Days > 0)
            {
                throw new Exception("To WeekRange constructor was passed TimeSpan parameters where days is greater then 0");
            }

            Start = new WeekTime(dayOfWeek, startTime);
            End = new WeekTime(startTime >= endTime ? dayOfWeek.NextDayOfWeek() : dayOfWeek, endTime);
        }

        /// <summary>
        /// Initializes a new instance of the WeekRange class. Constructor creates WeekRange object by selected values
        /// </summary>
        /// <param name="start">WeekTime object with starting value</param>
        /// <param name="end">WeekTime object with end value</param>
        public WeekRange(WeekTime start, WeekTime end)
        {
            Start = start;
            End = end;
        }

        /// <summary>
        /// Gets or sets weekTime object with starting value
        /// </summary>
        public WeekTime Start { get; set; }

        /// <summary>
        /// Gets or sets weekTime object with end value
        /// </summary>
        public WeekTime End { get; set; }

        /// <summary>
        /// Overloaded operator which allows to add TimeSpan value from WeekRange. It will be affected on WeekStart and WeekEnd values
        /// </summary>
        /// <param name="weekRange">WeekRange value</param>
        /// <param name="time">TimeSpan value</param>
        /// <returns>As a result it returns WeekRange object equals WeekTime (Start) + TimeSpan and WeekTime (End) + TimeSpan</returns>
        public static WeekRange operator +(WeekRange weekRange, TimeSpan time)
        {
            return new WeekRange(weekRange.Start + time, weekRange.End + time);
        }

        /// <summary>
        /// Overloaded operator which allows to substract TimeSpan value from WeekRange. It will be affected on WeekStart and WeekEnd values
        /// </summary>
        /// <param name="weekRange">WeekRange value</param>
        /// <param name="time">TimeSpan value</param>
        /// <returns>As a result it returns WeekRange object equals WeekTime (Start) - TimeSpan and WeekTime (End) - TimeSpan</returns>
        public static WeekRange operator -(WeekRange weekRange, TimeSpan time)
        {
            return new WeekRange(weekRange.Start - time, weekRange.End - time);
        }

        /// <summary>
        /// Method creates new cloned WeekRange object by current WeekRange object
        /// </summary>
        /// <returns>Returns new cloned WeekRange object by current WeekRange object</returns>
        public WeekRange Clone()
        {
            return new WeekRange(Start.Clone(), End.Clone());
        }
    }
}
