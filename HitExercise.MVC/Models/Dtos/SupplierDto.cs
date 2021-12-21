using HitExercise.DataAccess.Core.Entities;
using HitExercise.MVC.HelperClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HitExercise.MVC.Models.Dtos
{
    public class SupplierDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Supplier's name is required")]
        [StringLength(80,MinimumLength =3,ErrorMessage = "Supplier's name must be between 3 - 80 characters")]
        [Display(Name ="Supplier's Name")]
        public string Name { get; set; }
        public SupplierCategory Category { get; set; }
        
        [Required(ErrorMessage ="Supplier must belong to a Category")]
        [Display(Name ="Category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage ="Suppleir's AFM is required")]
        //[RegularExpression("^[0-9]{9}$",ErrorMessage = "AFM must have only 9 digits")]
        [Display(Name = "AFM")]
        [MyAFMValidation(ErrorMessage ="Wrong AFM")]
        public string Afm { get; set; }

        [StringLength(100, MinimumLength = 5, ErrorMessage = "Supplier's Address must be between 5 - 100 characters")]
        public string Address { get; set; }

        [StringLength(10, MinimumLength = 10, ErrorMessage = "Telephone number is 10 digits long")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Telephone is Required")]
        public string Telephone { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage ="Wrong Email Format")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Supplier's Email must be between 3 - 80 characters")]
        [Required(ErrorMessage ="Email is Required")]
        public string Email { get; set; }

        public Country Country { get; set; }

        [Display(Name ="Country Code")]
        [Required(ErrorMessage ="Country code is required")]
        public int CountryId { get; set; }

        
        public bool Inactive { get; set; }

        
    }
}