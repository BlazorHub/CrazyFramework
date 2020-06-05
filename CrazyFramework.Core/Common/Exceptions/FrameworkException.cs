﻿using System;

namespace CrazyFramework.Core.Common.Exceptions
{
	public class FrameworkException : Exception
	{
		public string ErrorCode { get; }

		public FrameworkException(string errorCode)
		{
			ErrorCode = errorCode;
		}

		public FrameworkException(string errorCode, string message) : base(message)
		{
			ErrorCode = errorCode;
		}

		public FrameworkException(string errorCode, string message, Exception innerException) : base(message, innerException)
		{
			ErrorCode = errorCode;
		}
	}
}