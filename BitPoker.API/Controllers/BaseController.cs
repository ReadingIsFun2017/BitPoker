﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web.Http;

namespace BitPoker.API.Controllers
{
    public abstract class BaseController : ApiController
    {
        public Boolean Verify(String address, String message, String signature)
        {
            NBitcoin.BitcoinAddress a = NBitcoin.BitcoinAddress.Create(address);
            var pubKey = new NBitcoin.BitcoinPubKeyAddress(address);
            bool verified = pubKey.VerifyMessage(message, signature);

            return verified;
        }

        [Obsolete]
        public Models.Table GetTableFromCache(Guid tableId)
        {
            if (MemoryCache.Default.Contains(tableId.ToString()))
            {
                Models.Table table = (Models.Table)MemoryCache.Default[tableId.ToString()];
                return table;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        [Obsolete]
        public Models.Hand GetHandFromCache(Guid tableId, Guid handId)
        {
            if (MemoryCache.Default.Contains(tableId.ToString()))
            {
                Models.Table table = (Models.Table)MemoryCache.Default[tableId.ToString()];
                if (table != null)
                {
                    return table.Hands.First(h => h.Id.ToString() == handId.ToString());
                }
                else
                {
                    throw new Exceptions.HandNotFoundException();
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
