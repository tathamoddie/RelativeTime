using System;
using System.Collections.Generic;
using System.Linq;

namespace RelativeTime
{
    internal class Formatter
    {
        readonly IDictionary<TimeSpan, Func<TimeSpan, string>> thresholds = new Dictionary<TimeSpan, Func<TimeSpan, string>>
        {
            {
                TimeSpan.FromSeconds(0),
                t => "just now"
            },
            {
                TimeSpan.FromSeconds(30),
                t => "less than a minute ago"
            },
            {
                TimeSpan.FromMinutes(1),
                t => "about a minute ago"
            },
            {
                TimeSpan.FromMinutes(1.5),
                t => string.Format("about {0} minutes ago", Math.Round(t.TotalMinutes, 0))
            },
            {
                TimeSpan.FromMinutes(50),
                t => "about an hour ago"
            },
            {
                TimeSpan.FromHours(1.5),
                t => string.Format("about {0} hours ago", Math.Round(t.TotalHours, 0))
            },
            {
                TimeSpan.FromHours(20),
                t => "yesterday"
            },
            {
                TimeSpan.FromDays(1.5),
                t => string.Format("about {0} days ago", Math.Round(t.TotalDays, 0))
            },
            {
                TimeSpan.FromDays(6),
                t => "last week"
            },
            {
                TimeSpan.FromDays(13),
                t => string.Format("about {0} weeks ago", Math.Round(t.TotalDays / 7, 0))
            },
            {
                TimeSpan.FromDays(30),
                t => "about a month ago"
            },
            {
                TimeSpan.FromDays(60),
                t => string.Format("about {0} months ago", Math.Round(t.TotalDays / 30, 0))
            },
            {
                TimeSpan.FromDays(345),
                t => "about a year ago"
            },
            {
                TimeSpan.FromDays(547.5),
                t => string.Format("about {0} years ago", Math.Round(t.TotalDays / 365, 0))
            }
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