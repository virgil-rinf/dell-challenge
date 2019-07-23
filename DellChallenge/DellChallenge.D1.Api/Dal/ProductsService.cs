using System.Collections.Generic;
using System.Linq;
using DellChallenge.D1.Api.common;
using DellChallenge.D1.Api.Dto;

namespace DellChallenge.D1.Api.Dal
{
    public class ProductsService : IProductsService
    {
        private readonly ProductsContext _context;

        public ProductsService(ProductsContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return _context.Products.Select(p => MapToDto(p));
        }

        public ProductDto Get(string id)
        {
            var product =  _context.Products.FirstOrDefault(p => p.Id == id);
            return product != null ? MapToDto(product) : null;
        }

        public ProductDto Add(NewProductDto newProduct)
        {
            var product = MapToData(newProduct);
            _context.Products.Add(product);
            _context.SaveChanges();
            var addedDto = MapToDto(product);
            return addedDto;
        }

        public ProductDto Update(string id, NewProductDto newProduct)
        {
            var product = _context.Products.First(x => x.Id == id);
            product.UpdateValues(newProduct);
            _context.SaveChanges();
            return MapToDto(product);
        }

        public ProductDto Delete(string id)
        {
            var product = _context.Products.First(x => x.Id == id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return MapToDto(product);
        }

        private Product MapToData(NewProductDto newProduct)
        {
            return new Product
            {
                Category = newProduct.Category,
                Name = newProduct.Name
            };
        }

        private ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category
            };
        }
    }
}
