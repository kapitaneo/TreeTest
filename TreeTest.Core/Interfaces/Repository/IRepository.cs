﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeTest.Core.Interfaces.Repository
{
    public interface IRepository<TEntity> where TEntity : IEntity<string>
    {
    }
}
