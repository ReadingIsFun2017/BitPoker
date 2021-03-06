﻿using System;
using System.Collections.Generic;
using BitPoker.Models;
using BitPoker.Models.Contracts;
using BitPoker.Repository;

namespace BitPoker.Net.RestHost.Controllers
{
    public interface ITablesController
    {
        ITableRepository TableRepo { get; set; }

        IEnumerable<Table> Get();

        Table Get(Guid id);

        void Post(IRequest request);
    }
}