using HitExercise.DataAccess.Core.Entities;
using HitExercise.MVC.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HitExercise.MVC.Models.ViewModels
{
    public class SupplierViewModel
    {
        public SupplierDto Supplier { get; set; }

        public List<SupplierCategory> Categories { get; set; }

        public List<Country> Countries { get; set; }


    }
}