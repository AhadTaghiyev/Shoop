using System;
using Shoop.Core.Entities.BaseEntities;

namespace Shoop.Core.Entities
{
	public class Product:BaseEntity
	{
		public string Name { get; set; } = null!;	
		public string Description { get; set; } = null!;
		public decimal Price { get; set; }
		public Guid CategoryId { get; set; }
        public string Image { get; set; } = null!;
        public string ImagePath { get; set; } = null!;
        public string Storage { get; set; } = null!;
        public Category Category { get; set; } = null!;
    }
}

