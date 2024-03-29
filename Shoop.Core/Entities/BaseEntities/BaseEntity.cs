using System;
namespace Shoop.Core.Entities.BaseEntities
{
	public class BaseEntity
	{
		public Guid Id { get; set; }
		public DateTime CratedAt { get; set; }
		public DateTime UpdateAt { get; set; }
		public bool IsDeleted { get; set; }
    }
}

