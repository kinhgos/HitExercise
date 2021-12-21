using HitExercise.DataAccess.Core.Entities;
using HitExercise.DataAccess.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HitExercise.DataAccess.HelperClasses
{
    public static class MyValidation
    {
        public static bool ValidateSupplier(int id,string afm, string name, IDataAccess dataAccess)
        {
            if (!ValidateAFM(afm))            
                return false;            

            if (!NameIsUnique(id,name, dataAccess))            
                return false;         
            
            return true;
            
        }


        public static bool ValidateAFM(string afm)
        {
            bool afmToInt = int.TryParse(afm,out int result);
            if (!afmToInt)
                return false;
            int sumToInt = 0;
            while (result != 0)
            {
                sumToInt += result % 10;
                result /= 10;
            }
            if (sumToInt == 0)
                return false;

            int _numAFM = 0;
            if (afm.Length != 9 || !int.TryParse(afm, out _numAFM))
                return false;
            else
            {
                double sum = 0;
                int iter = afm.Length - 1;
                afm.ToCharArray().Take(iter).ToList().ForEach(c =>
                {
                    sum += double.Parse(c.ToString()) * Math.Pow(2, iter);
                    iter--;
                });
                if (sum % 11 == double.Parse(afm.Substring(8)) || double.Parse(afm.Substring(8)) == 0)
                    return true;
                else
                    return false;
            }
        }

        private static bool NameIsUnique(int id,string name, IDataAccess dataAccess)
        {
            return !dataAccess.Suppliers.GetAll().Where(s=>s.Name == name && s.Id != id).Any();
        }

       
    }
}
