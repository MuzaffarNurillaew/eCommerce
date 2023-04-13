using eCommerce.Domain.Configurations;
using eCommerce.Service.Interfaces;
using eCommerce.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 3, string searchString = null)
        {

            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            if (pageSize < 1)
            {
                pageSize = 1;
            }

            if (searchString is not null)
            {

                var products = await productService
                    .GetAllAsync(
                        new PaginationParams()
                        {
                            PageIndex = pageIndex,
                            PageSize = (short)pageSize
                        }, product => product.Name.Contains(searchString));

                return View(products);
            }
            else
            {
                var products = await productService
                    .GetAllAsync(
                        new PaginationParams()
                        {
                            PageIndex = pageIndex,
                            PageSize = (short)pageSize
                        });

                return View(products);
            }
        }
    }
}
