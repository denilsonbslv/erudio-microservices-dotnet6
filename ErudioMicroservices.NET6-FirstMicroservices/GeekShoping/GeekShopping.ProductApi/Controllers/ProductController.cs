using GeekShopping.ProductApi.Data.ValueObjects;
using GeekShopping.ProductApi.Repository;
using GeekShopping.ProductApi.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepotory _repository;

        public ProductController(IProductRepotory repository)
        {
            _repository = repository ?? throw new ArgumentException(nameof(repository));   
        }

        [HttpGet("{idProduct}")]
        [Authorize]
        public async Task<ActionResult<ProductVO>> FindById(long idProduct)
        {
            var product = await _repository.FindById(idProduct);
            if (product.Id <= 0) return NotFound();
            return Ok(product);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll(long idProduct)
        {
            var products = await _repository.FindAll();
            return Ok(products);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ProductVO>> Create([FromBody] ProductVO vo)
        {
            if(vo == null) return BadRequest();
            var product = await _repository.Create(vo);
            return Ok(product);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<ProductVO>> Update([FromBody] ProductVO vo)
        {
            if (vo == null) return BadRequest();
            var product = await _repository.Update(vo);
            return Ok(product);
        }

        [HttpDelete("{idProduct}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult> Delete(long idProduct)
        {
            var status = await _repository.Delete(idProduct);
            if (!status) return BadRequest();
            return Ok(status);
        }

    }
}
