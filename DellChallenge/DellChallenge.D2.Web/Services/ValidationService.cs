using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DellChallenge.D2.Web.Models;

namespace DellChallenge.D2.Web.Services
{
    public class ValidationService : IValidationService
    {
        public IEnumerable<string> AddOrUpdateErrors(NewProductModel productModel)
        {
            if(productModel.Name == null || productModel.Name == string.Empty)
            {
                yield return "Name cannot be empty";
            }
            if (productModel.Category == null || productModel.Category == string.Empty)
            {
                yield return "Category cannot be empty";
            }
        }
    }
}
