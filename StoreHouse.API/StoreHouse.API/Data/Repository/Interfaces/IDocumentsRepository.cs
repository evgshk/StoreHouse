﻿using StoreHouse.API.Data.StoreHouseStorage.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreHouse.API.Data.Repository.Interfaces
{
    public interface IDocumentsRepository: IRepositoryBase<Documents>
    {
        void Add(Documents entity);
    }
}
