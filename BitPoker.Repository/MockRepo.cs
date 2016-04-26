﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitPoker.Repository
{
    public class MockRepo : IPlayerRepository
    {
        public IEnumerable<BitPoker.Models.PlayerInfo> All()
        {
            BitPoker.Models.PlayerInfo alice = new BitPoker.Models.PlayerInfo()
            {
                BitcoinAddress = "msPJhg9GPzMN6twknwmSQvrUKZbZnk51Tv"
            };

            BitPoker.Models.PlayerInfo bob = new BitPoker.Models.PlayerInfo()
            {
                BitcoinAddress = "mhSW3EUNoVkD1ZQV1ZpnxdRMBjo648enyo"
            };

            List<BitPoker.Models.PlayerInfo> mockPlayers = new List<BitPoker.Models.PlayerInfo>();
            mockPlayers.Add(alice);
            mockPlayers.Add(bob);

            return mockPlayers;
        }

        public BitPoker.Models.PlayerInfo Find(String address)
        {
            BitPoker.Models.PlayerInfo alice = new BitPoker.Models.PlayerInfo()
            {
                BitcoinAddress = "msPJhg9GPzMN6twknwmSQvrUKZbZnk51Tv"
            };

            return alice;
        }
    }
}
