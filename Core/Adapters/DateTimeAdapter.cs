using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Adapters
{
    public class DateTimeAdapter : IDateTimeService
    {
        public DateTime Now => DateTime.Now;
    }
}
