using AutoMapper;
using DevReviews.API.Entities;
using DevReviews.API.Models;
using DevReviews.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DevReviews.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly DevReviewsDbContext _DbContext;
        private readonly IMapper _mapper;

        public ProductsController(DevReviewsDbContext dbContext, IMapper mapper)
        {
            _DbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _DbContext.Products;

            //var productsViewModel = products.Select(p => new ProductViewModel(p.Id, p.Title, p.Price));

            var productsViewModel = _mapper.Map<List<ProductViewModel>>(products);

            return Ok(productsViewModel);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _DbContext.Products.SingleOrDefault(p => p.Id == id);

            if(product == null)
            {
                return NotFound();
            }

            //var reviewsViewModel = product.Reviews
            //    .Select(r => new ProductReviewViewModel(r.Id, r.Author, r.Rating, r.Comments, r.RegisteredAt))
            //    .ToList();

            //var productDetails = new ProductDetailsViewModel(
            //    product.Id,
            //    product.Title,
            //    product.Description,
            //    product.Price,
            //    product.RegisteredAt,
            //    reviewsViewModel
            //    );

            var productDetails = _mapper.Map<ProductDetailsViewModel>(product);

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post(AddProductInputModel model)
        {
            var product = new Product(model.Title, model.Description, model.Price);

            _DbContext.Products.Add(product);

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateProductInputModel model)
        {
            if(model.Description.Length > 50)
            {
                return BadRequest();
            }

            var product = _DbContext.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            product.Update(model.Description, model.Price);

            return NoContent();
        }
    }
}