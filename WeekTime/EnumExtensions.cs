
namespace WeekTimeProgram
{
    using System;

    public static class EnumExtensions
    {
        /// <summary>
        /// Returns previous day of week according selected day of week
        /// </summary>
        /// <param name="dayOfWeek">Selected day of week</param>
        /// <returns>Previous day of week</returns>
        public static DayOfWeek PreviousDayOfWeek(this DayOfWeek dayOfWeek)
        {
            DayOfWeek previousDayOfWeek;

            if ((int)dayOfWeek > 0)
            {
                previousDayOfWeek = (DayOfWeek)((int)dayOfWeek - 1);
            }
            else
            {
                previousDayOfWeek = DayOfWeek.Saturday;
            }

            return previousDayOfWeek;
        }

        /// <summary>
        /// Returns next day of week according selected day of week
        /// </summary>
        /// <param name="dayOfWeek">Selected day of week</param>
        /// <returns>Next day of week</returns>
        public static DayOfWeek NextDayOfWeek(this DayOfWeek dayOfWeek)
        {
            DayOfWeek nextDayOfWeek;

            // Calculating next day of week
            if ((int)dayOfWeek < 6)
            {
                nextDayOfWeek = (DayOfWeek)((int)dayOfWeek + 1);
            }
            else
            {
                nextDayOfWeek = DayOfWeek.Sunday;
            }

            return nextDayOfWeek;
        }

        /// <summary>
        /// Returns day of week according added additional days. 
        /// For example {Monday}.AddDays(2) = Wednesday, {Monday}.AddDays(-1) = Sunday.
        /// </summary>
        /// <param name="dayOfWeek">Selected day of week</param>
        /// <param name="daysNumber">Days number</param>
        /// <returns>Returns day of week according added additional days</returns>
        public static DayOfWeek AddDays(this DayOfWeek dayOfWeek, int daysNumber)
        {
            var currentNumericDay = (int)dayOfWeek;
            var modifiedDayOfWeek = (DayOfWeek)Math.Abs((currentNumericDay + daysNumber) % 7);

            return modifiedDayOfWeek;
        }

        /// <summary>
        /// Returns day of week according substracted additional days. 
        /// For example {Monday}.SubstractDays(2) = Saturday, {Monday}.SubstractDays(-1) = Tuesday.
        /// </summary>
        /// <param name="dayOfWeek">Selected day of week</param>
        /// <param name="daysNumber">Days number</param>
        /// <returns>Returns day of week according substracted additional days</returns>
        public static DayOfWeek SubstractDays(this DayOfWeek dayOfWeek, int daysNumber)
        {
            var currentNumericDay = (int)dayOfWeek;
            var modifiedDayOfWeek = (DayOfWeek)Math.Abs((currentNumericDay - daysNumber) % 7);

            return modifiedDayOfWeek;
        }
    }
}

