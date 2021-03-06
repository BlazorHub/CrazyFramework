﻿using CrazyFramework.App.Business.Products;
using CrazyFramework.App.Common;
using CrazyFramework.App.Common.Behaviours;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CrazyFramework.App
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddMediatR(Assembly.GetExecutingAssembly());
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

			services.AddSingleton<IDateTime, DateTimeService>();

			services.AddScoped<IProductBusiness, ProductBusiness>();

			return services;
		}
	}
}