using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop_API.Data;
using Shop_API.Data.Entities;
using Shop_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_API.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductRepository repository, ILogger<ProductsController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ProductModel[]>> GetAllProducts()
        {
            try
            {
                var results = await _repository.GetAllProductsAsync();

                ProductModel[] allProducts = _mapper.Map<ProductModel[]>(results);

                return Ok(allProducts);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Fatal Error: {ex}");
            }
        }

        [HttpGet("{productName}")]
        public async Task<ActionResult<ProductModel>> GetProductByName(string productName)
        {
            try
            {
                var result = await _repository.GetProductAsync(productName);
                if (result == null) return NotFound();

                return _mapper.Map<ProductModel>(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Fatal Error: {ex}");
            }
        }

        [HttpGet("{productId:int}")]
        public async Task<ActionResult<ProductModel>> GetProductById(int productId)
        {
            try
            {
                var result = await _repository.GetProductById(productId);
                if (result == null) return NotFound();

                return _mapper.Map<ProductModel>(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Fatal Error: {ex}");
            }
        }

        [HttpGet("category/{category}")]
        public async Task<ActionResult<ProductModel>> GetProductByCategory(string category)
        {
            try
            {
                var result = await _repository.GetProductsByCategory(category);
                if (result == null) return NotFound();


                ProductModel[] categoryProducts = _mapper.Map<ProductModel[]>(result);
                return Ok(categoryProducts);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Fatal Error: {ex}");
            }
        }


        [HttpPost]
        public async Task<ActionResult<ProductModel>> CreateNewProduct(ProductModel productModel)
        {
            try
            {
                var existing = await _repository.GetProductAsync(productModel.Name);
                if (existing != null)
                {
                    return BadRequest("Product with the same name already exists");
                }

                // Creating a new product
                var product = _mapper.Map<Product>(productModel);
                _repository.Add(product);
                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/products/{productModel.Name}", _mapper.Map<ProductModel>(product));
                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Fatal Error: {ex}");
            }
            return BadRequest();
        }

        [HttpPut("{productName}")]
        public async Task<ActionResult<ProductModel>> UpdateProduct(string productName, ProductModel productModel)
        {
            try
            {
                var selectedProduct = await _repository.GetProductAsync(productName);
                if (selectedProduct == null) return NotFound($"Could not find a product with the name: {productName}");

                _mapper.Map(productModel, selectedProduct);

                if (await _repository.SaveChangesAsync())
                {
                    return _mapper.Map<ProductModel>(selectedProduct);
                }

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Fatal Error: {ex}");
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<ActionResult<ProductModel>> DeleteProduct(string productName)
        {
            try
            {
                var selectedProduct = await _repository.GetProductAsync(productName);
                if (selectedProduct == null) return NotFound($"Could not find a product with the name: {productName}");

                _repository.Delete(selectedProduct);
                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Database Fatal Error: {ex}");
            }

            return BadRequest();
        }
    }
}
