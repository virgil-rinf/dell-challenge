using DellChallenge.D2.Web.Models;
using System.Collections.Generic;

namespace DellChallenge.D2.Web.Services
{
    public interface IValidationService
    {
        IEnumerable<string> AddOrUpdateErrors(NewProductModel productModel);
    }
}
