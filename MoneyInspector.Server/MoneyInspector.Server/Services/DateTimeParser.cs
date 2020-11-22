using MoneyInspector.Server.Models;
using MoneyInspector.Server.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyInspector.Server.Services
{
    public class DateTimeParser : IDateTimeParser
    {
        private DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public DateTimePeriod GetDateTimePeriod(long startDateMs, long endDateMs)
        {
            return new DateTimePeriod { StartDate = unixEpoch.AddMilliseconds(startDateMs), EndDate = unixEpoch.AddMilliseconds(endDateMs) };
        }
    }
}
