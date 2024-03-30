using System;
using System.ComponentModel.DataAnnotations;
using Shoop.Core.Entities.BaseEntities;

namespace Shoop.Core.Entities
{
	public class Category:BaseEntity
	{
		public string Name { get; set; } = null!;
		public HashSet<Product> Products { get; set; }
	
        public Category()
		{
			Products = new HashSet<Product>();
		}
	}
}

