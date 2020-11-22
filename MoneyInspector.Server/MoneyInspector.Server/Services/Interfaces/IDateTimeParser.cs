using MoneyInspector.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyInspector.Server.Services.Interfaces
{
    public interface IDateTimeParser
    {
        public DateTimePeriod GetDateTimePeriod(long startDateMs, long endDateMs);
    }
}
