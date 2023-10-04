﻿using AutoMapper;
using Store.Db;
using Store.Services.Dtos;
using Store.Services.Interface;

namespace Store.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly StoreDBContext _context;
        private readonly IMapper _mapper;


        public SupplierService(StoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Delete(int idSupplier)
        {
            var currentSupplier = _context.Suppliers.Find(idSupplier);
            if (currentSupplier != null)
            {
                _context.Suppliers.Remove(currentSupplier);
                _context.SaveChanges();
            }
        }

        public IList<SupplierDto> Get()
        {
            var supplierList = _context.Suppliers.ToList();
            return _mapper.Map<IList<SupplierDto>>(supplierList);
        }

        public SupplierDto GetById(int idSupplier)
        {
            var currentSupplier = _context.Suppliers.Find(idSupplier);
            return _mapper.Map<SupplierDto>(currentSupplier);
        }

        public void Save(SaveSupplierDto dto)
        {
            var supplierNow = _mapper.Map<Supplier>(dto);
            _context.Suppliers.Add(supplierNow);
            _context.SaveChanges();
        }

        public void Update(int idSupplier, SaveSupplierDto dto)
        {
            var currentSupplier = _context.Suppliers.Find(idSupplier);
            if (currentSupplier != null && currentSupplier.Id == dto.Id)
            {
                currentSupplier.RucSupplier = dto.RucSupplier;
                currentSupplier.BusinessName = dto.BusinessName;
                _context.SaveChanges();
            }
        }
    }
}
