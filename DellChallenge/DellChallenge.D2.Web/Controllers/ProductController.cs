using DellChallenge.D2.Web.Models;
using DellChallenge.D2.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DellChallenge.D2.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IValidationService _validationService;
        public ProductController(IProductService productService, IValidationService validationService)
        {
            _productService = productService;
            _validationService = validationService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _productService.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new NewProductModel());
        }

        [HttpPost]
        public IActionResult Add(NewProductModel newProduct)
        {
            var errors = _validationService.AddOrUpdateErrors(newProduct);
            if (errors.Any())
            {
                newProduct.Errors = errors;
                return View(newProduct);
            }

            _productService.Add(newProduct);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Update(string id)
        {
            var prod = _productService.Get(id);
            return View(prod);
        }

        [HttpPost]
        public IActionResult Update(ProductModel product)
        {
            var errors = _validationService.AddOrUpdateErrors(product);
            if (errors.Any())
            {
                product.Errors = errors;
                return View(product);
            }

            _productService.Update(product);
            return RedirectToAction("Index");
        }

        [AcceptVerbs("GET", "DELETE")]
        public IActionResult Delete(string id)
        {
            _productService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}