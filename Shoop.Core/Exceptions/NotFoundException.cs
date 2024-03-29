using System;
namespace Shoop.Core.Exceptions
{
	public class NotFoundException:Exception
	{
		public NotFoundException(string msg):base(msg)
		{
		}
	}
}

