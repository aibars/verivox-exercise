using GenFu;
using System;
using System.Collections.Generic;
using System.Linq;
using Verivox.Domain.Models;

namespace Verivox.Providers.Tests
{
    public static class FakeData
    {
        private static Guid Guid = Guid.NewGuid();
        public static List<Consumption> GetConsumptions()
        {
            var rnd = new Random();
            var values = A.ListOf<Consumption>(26);

            values.ForEach(y => { y.Id = Guid.NewGuid(); });
            return values.Select(_ => _).ToList();
        }

        public static List<ApplicationUser> GetUsers()
        {
            var users = A.ListOf<ApplicationUser>(5);
            users.ForEach(y => y.Id = Guid.NewGuid());
            users[0].Id = Guid;
            return users.Select(_ => _).ToList();
        }
    }
}
