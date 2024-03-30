using System;
using Microsoft.AspNetCore.Http;
using Shoop.Core.Entities;

namespace Shoop.Core.Dtos
{
    public class ProductPostDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public IFormFile Image {get;set;} = null!;
    }

    public class ProductGetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public string Image { get; set; } = null!;
        public string ImagePath { get; set; } = null!;
        public string Storga { get; set; } = null!;
    }

    public class ProductUpdateDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public IFormFile? Image { get; set; } = null!;
    }
}

