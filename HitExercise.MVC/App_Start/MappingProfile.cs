using AutoMapper;
using HitExercise.DataAccess.Core.Entities;
using HitExercise.MVC.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HitExercise.MVC.App_Start
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Supplier, SupplierDto>();
            Mapper.CreateMap<SupplierDto, Supplier>();
        }
    }
}