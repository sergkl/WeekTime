namespace WeekTimeProgram
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            // Creating WeekTime object for Monday 10 AM;
            var weekTime = new WeekTime(DayOfWeek.Monday, TimeSpan.FromHours(10));

            // Adding 15 hours; The result is Tuesday 1 AM
            WeekTime addedWeekTime = weekTime + TimeSpan.FromHours(15);

            // Adding 10 days; The result is Thursday 10 AM
            WeekTime addedWeekTime2 = weekTime + TimeSpan.FromDays(10);

            // Adding 12 hours; The result is Monday 10 PM
            WeekTime addedWeekTime3 = weekTime + TimeSpan.FromHours(12);

            // Substracting 5 hours; The result is Monday 5 AM
            WeekTime substractedWeekTime = weekTime - TimeSpan.FromHours(5);

            // Substracting 5 days; The result is Wednesday 10 AM
            WeekTime substractedWeekTime2 = weekTime - TimeSpan.FromDays(5);
        }
    }
}
