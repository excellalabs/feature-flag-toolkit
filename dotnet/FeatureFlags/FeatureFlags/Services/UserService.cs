using FeatureFlags.Models;
using FeatureFlags.Models.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeatureFlags.Services
{
    public class UserService
    {
        private readonly DatabaseContexts _context = new DatabaseContexts();

        public bool IsUserAdmin()
        {
            return _context.FeatureFlagUsers.First(x => x.IsLoggedIn).IsAdmin;
        }
    }
}
