﻿using CrazyFramework.Core.Common;
using CrazyFramework.Services.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrazyFramework.Services
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddSingleton<IDateTime, DateTimeService>();

			return services;
		}
	}
}