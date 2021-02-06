using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClickCounter.Services.Interfaces
{
    public interface ICountService
    {
        int CountUp();
        int CountDown();
        int GetCurrentCount();
    }
}
