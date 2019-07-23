using DellChallenge.D1.Api.Dal;
using DellChallenge.D1.Api.Dto;

namespace DellChallenge.D1.Api.common
{
    public static class Extensions
    {
        public static void UpdateValues(this Product product, NewProductDto newProductDto)
        {
            product.Name = newProductDto.Name;
            product.Category = newProductDto.Category;
        }
    }
}
