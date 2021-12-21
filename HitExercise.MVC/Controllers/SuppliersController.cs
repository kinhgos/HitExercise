using AutoMapper;
using HitExercise.DataAccess.Core.Entities;
using HitExercise.DataAccess.Core.Interfaces;
using HitExercise.MVC.HelperClasses;
using HitExercise.MVC.Models.Dtos;
using HitExercise.MVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace HitExercise.MVC.Controllers
{
    [Authorize]
    public class SuppliersController : Controller
    {
        private readonly IDataAccess _dataAccess;

        public SuppliersController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        // GET: Suppliers
        public ActionResult Index()
        {
            var supplierViewModel = new SupplierViewModel()
            {
                Categories = _dataAccess.Categories.GetAll().ToList(),
                Countries = _dataAccess.Countries.GetAll().ToList()
            };
            return View(supplierViewModel);
        }

        [HttpPost]
        public ActionResult Add(SupplierViewModel supplierViewModel)
        {
            var supplierDto = supplierViewModel.Supplier;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44301/api/");
                var postTask = client.PostAsJsonAsync<SupplierDto>("suppliers/", supplierDto);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var email = new SendEmail();
                    email.SendEmailToSupplier(supplierDto);
                    supplierViewModel.Supplier = new SupplierDto();
                    return RedirectToAction("index");
                }
            }
            supplierViewModel.Categories = _dataAccess.Categories.GetAll().ToList();
            supplierViewModel.Countries = _dataAccess.Countries.GetAll().ToList();
            return View("Index",supplierViewModel);
        }
        
        
        public ActionResult Edit(int id)
        {
            //using the Api to get supplier using id
            var supplier = new Supplier();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44301/api/");

                var readData = client.GetAsync($"suppliers/{id}");
                readData.Wait();

                var resultData = readData.Result;

                //if the api call is not successful
                if (!resultData.IsSuccessStatusCode)
                {
                    return HttpNotFound();

                }

                var data = resultData.Content.ReadAsAsync<Supplier>();
                data.Wait();
                supplier = data.Result;
            }   
            //automap supplierfromdb to supplierDto
            var supplierDto = Mapper.Map<Supplier, SupplierDto>(supplier);

            var supplierViewModel = new SupplierViewModel()
            {
                Supplier = supplierDto,
                Categories = _dataAccess.Categories.GetAll().ToList(),
                Countries = _dataAccess.Countries.GetAll().ToList()
            };
            return View(supplierViewModel);
        }

        [HttpPost]
        public ActionResult Edit(SupplierViewModel supplierViewModel)
        {
            var supplierDto = supplierViewModel.Supplier;
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44301/api/");
                var putTask = client.PutAsJsonAsync<SupplierDto>($"suppliers/{supplierDto.Id}",supplierDto);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                    return RedirectToAction("index");               

            }
            supplierViewModel = new SupplierViewModel()
            {
                Supplier = supplierDto,
                Categories = _dataAccess.Categories.GetAll().ToList(),
                Countries = _dataAccess.Countries.GetAll().ToList()
            };
            return View(supplierViewModel);
        }




    }
}