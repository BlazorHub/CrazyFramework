﻿using System;

namespace CrazyFramework.App.Common
{
	// note: this class should be thread safe because its scope is Singleton
	public class DateTimeService : IDateTime
	{
		public DateTimeOffset Now => DateTimeOffset.Now;
		public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
	}
}