using System;
using System.Collections.Generic;
using System.Linq;

namespace RelativeTime
{
    internal class Formatter
    {
        readonly IDictionary<TimeSpan, Func<TimeSpan, string>> thresholds = new Dictionary<TimeSpan, Func<TimeSpan, string>>
        {
            { TimeSpan.FromDays(13), t => string.Format("about {0} weeks ago", (int)(t.TotalDays / 7)) },
            { TimeSpan.FromDays(365), t => string.Format("about {0} years ago", (int)(t.TotalDays / 365)) }
        };

        public string Format(TimeSpan timeSpan)
        {
            var threshold = thresholds
                .Keys
                .OfType<TimeSpan?>()
                .OrderBy(t => t)
                .Where(t => timeSpan >= t)
                .LastOrDefault() ?? TimeSpan.MaxValue;

            var formatCallback = thresholds[threshold];
            
            return formatCallback(timeSpan);
        }
    }
}