﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back.Services
{
    public interface ISynchronizeService
    {
        Task SynchronizeAllCards();
    }
}
