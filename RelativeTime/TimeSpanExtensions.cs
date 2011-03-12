using System;

namespace RelativeTime
{
    public static class TimeSpanExtensions
    {
        static readonly Formatter formatter = new Formatter();

        public static string ToHumanString(this TimeSpan timeSpan)
        {
            return formatter.Format(timeSpan);
        }
    }
}