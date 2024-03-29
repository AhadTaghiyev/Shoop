using System;
namespace Shoop.Core.Dtos
{
	public class CategoryPostDto
	{
		public string Name { get; set; } = null!;
	}

    public class CategoryGetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
    }
}

