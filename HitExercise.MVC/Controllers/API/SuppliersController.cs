using AutoMapper;
using HitExercise.DataAccess.Core.Entities;
using HitExercise.DataAccess.Core.Interfaces;
using HitExercise.DataAccess.HelperClasses;
using HitExercise.MVC.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;

namespace HitExercise.MVC.Controllers.API
{
    
    public class SuppliersController : ApiController
    {
        private readonly IDataAccess _dataAccess;

        public SuppliersController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        //Get All
        [HttpGet]
        public IHttpActionResult GetSuppliers()
        {
            var suppliers = _dataAccess
                .Suppliers
                .GetAll()
                .Select(Mapper.Map<Supplier,SupplierDto>);

            return Ok(suppliers);
        }

        //Get with ID
        [HttpGet]
        public IHttpActionResult GetSupplier(int id)
        {
            var supplier = _dataAccess.Suppliers.GetById(id);

            if (supplier == null)
                return NotFound();

            return Ok(Mapper.Map<Supplier,SupplierDto>(supplier));
        }

        //Create
        [HttpPost]
        public IHttpActionResult AddSupplier(SupplierDto supplierDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            
            if (!MyValidation.ValidateSupplier(supplierDto.Id,supplierDto.Afm,supplierDto.Name,_dataAccess))
                return BadRequest("Supplier is not Valid");

            var supplier = Mapper.Map<SupplierDto, Supplier>(supplierDto);


            _dataAccess.Suppliers.Create(supplier);
            _dataAccess.Complete();

            

            return Created(new Uri(Request.RequestUri + "/" + supplier.Id),supplierDto);
        }

        //Edit
        [HttpPut]
        public IHttpActionResult UpdateSupplier(int id, SupplierDto supplierDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var supplierInDb = _dataAccess.Suppliers.GetById(id);

            if (supplierInDb == null)
                return NotFound();
            
            if (!MyValidation.ValidateSupplier(supplierDto.Id,supplierDto.Afm,supplierDto.Name, _dataAccess))
                return BadRequest("Supplier is not Valid");

            supplierDto.Category = _dataAccess.Categories.GetById(supplierDto.CategoryId);
            supplierDto.Country = _dataAccess.Countries.GetById(supplierDto.CountryId);
            
            

            Mapper.Map(supplierDto, supplierInDb);


            _dataAccess.Complete();

            return StatusCode(HttpStatusCode.NoContent);
        }

        //Delete
        [HttpDelete]
        public IHttpActionResult DeleteSupplier(int id)
        {
            var supplierInDb = _dataAccess.Suppliers.GetById(id);

            if (supplierInDb == null)
                return NotFound();

            _dataAccess.Suppliers.Delete(id);
            _dataAccess.Complete();

            return Ok(supplierInDb);
        }
    }
}
