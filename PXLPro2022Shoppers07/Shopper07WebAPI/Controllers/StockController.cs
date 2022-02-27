using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PXLPro2022Shoppers07.Shared;
using Shopper07WebAPI.Services;

namespace Shopper07WebAPI.Controllers
{
    [ApiController]
    [Route("api/stock")]
    public class StockController : ControllerBase
    {
        IProductStockRepository _productStock;
        public StockController(IProductStockRepository productStock)
        {
            _productStock = productStock;
        }


        [HttpHead]
        [HttpGet]
        public ActionResult<IEnumerable<ProductStock>> GetProductStocks()
        {
            var products = _productStock.GetProductStocks();
            return Ok(products);
        }


        [HttpGet("{ProductStockId}", Name = "ProductStock")]
        public ActionResult<ProductStock> ProductStock(int ProductStockId)
        {
            var stock = _productStock.CheckProductStock(ProductStockId);
            if (stock != null) return Ok(stock);
            return NotFound("There is no product with that id");
        }


        [HttpPost(Name = "UpdateProductStock")]
        public async Task<IActionResult> UpdateProductStock(ProductStock productStock)
        {
            if (ModelState.IsValid)
            {
                var stock = _productStock.ChangeProductStock(productStock, productStock.Amount);
                return Ok(stock);
            }
            return BadRequest();
        }




    }
}
