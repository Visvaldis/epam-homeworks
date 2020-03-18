﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Infrastructure
{
	public class ValidationException : Exception
	{
		public ValidationException() : base()
		{

		}
		public ValidationException(string message) : base(message)
		{

		}

	}
}
