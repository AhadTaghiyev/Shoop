using System;
using System.ComponentModel.DataAnnotations;
using Shoop.Core.Entities.BaseEntities;

namespace Shoop.Core.Entities
{
	public class Category:BaseEntity
	{
		public string Name { get; set; } = null!;
	}
}

