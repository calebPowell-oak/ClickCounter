using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClickCounter.Services.Interfaces
{
    public interface ISessionService
    {
        public Guid CreateSession();
        public bool CheckIfSessionValid(Guid sessionId);
    }
}
