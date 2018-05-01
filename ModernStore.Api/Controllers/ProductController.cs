using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Repositories;
using System;

namespace ModernStore.Api.Controllers
{
    public class ProductController: Controller
    {
        private readonly IProtuctRepository _reposiotry;

        public ProductController(IProtuctRepository reposiotry)
        {
            _reposiotry = reposiotry;
        }
        [HttpGet]
        [Route("v1/products")]
        public IActionResult Get()
        {
            return Ok(_reposiotry.Get());
        }

        [HttpGet]
        [Route("v1/products/{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok($"Lista de produtos {id}");
        }

        [HttpPost]
        [Route("v1/products")]
        public IActionResult Post()
        {
            return Ok($"Criar um novo de produtos");
        }
    }
}
