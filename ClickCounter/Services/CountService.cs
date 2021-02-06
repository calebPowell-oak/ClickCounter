using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClickCounter.Services.Interfaces;

namespace ClickCounter.Services
{
    public class CountService : ICountService
    {
        private int ClickCount = 0;

        public int CountDown()
        {
            return --ClickCount;
        }

        public int CountUp()
        {
            return ++ClickCount;
        }

        public int GetCurrentCount()
        {
            return ClickCount;
        }
    }
}
