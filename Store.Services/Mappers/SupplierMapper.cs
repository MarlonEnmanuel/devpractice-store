﻿using AutoMapper;
using Store.Core.Dtos;
using Store.Db.Entities;

namespace Store.Core.Mappers
{
    internal class SupplierMapper :Profile
    {
        public SupplierMapper() {
            CreateMap<Supplier, SupplierDto>();
            CreateMap<SaveSupplierDto, Supplier>();
        }
    }
}
