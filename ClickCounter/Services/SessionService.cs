using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClickCounter.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ClickCounter.Services
{
    public class SessionService : ISessionService
    {
        private Dictionary<Guid, DateTime> ValidSessions = new Dictionary<Guid, DateTime>();
        private IConfiguration _Configuration;

        public SessionService(IConfiguration Configuration)
        {
            _Configuration = Configuration;
        }

        public bool CheckIfSessionValid(Guid sessionId)
        {
            DateTime now = DateTime.Now;
            DateTime expirationTime;

            if (ValidSessions.TryGetValue(sessionId, out expirationTime))
            {
                if (now.CompareTo(expirationTime) > 0)
                {
                    ValidSessions.Remove(sessionId);
                    return false;
                } else
                {
                    return true;
                }
            } else
            {
                return false;
            }
        }

        public Guid CreateSession()
        {
            Guid guid = Guid.NewGuid();
            DateTime timeOfExpiration = DateTime.Now.AddMinutes(_Configuration.GetValue<int>("SessionLength"));

            ValidSessions.Add(guid, timeOfExpiration);

            return guid;
        }
    }
}
