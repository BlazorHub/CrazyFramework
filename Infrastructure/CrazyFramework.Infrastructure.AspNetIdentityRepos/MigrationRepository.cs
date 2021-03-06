﻿using CrazyFramework.Infrastructure.AspNetIdentityRepos.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CrazyFramework.Infrastructure.AspNetIdentityRepos
{
	public class MigrationRepository
	{
		public static async Task MigrateDatabase(IServiceProvider serviceProvider)
		{
			using (var scope = serviceProvider.CreateScope())
			{
				try
				{
					var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
					await dbContext.Database.MigrateAsync();
				}
				catch (Exception ex)
				{
					var logger = scope.ServiceProvider.GetRequiredService<ILogger<MigrationRepository>>();
					logger.LogError(ex, "An error occurred while migrating database.");
				}
			}
		}

		public static async Task SeedInitialData(IServiceProvider serviceProvider)
		{
			using (var scope = serviceProvider.CreateScope())
			{
				try
				{
					var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserDAO>>();
					var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
					await ApplicationDbContextSeed.SeedAccountsAsync(userManager, roleManager);

					var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
					await ApplicationDbContextSeed.SeedJobTitlesAsync(dbContext);
					await ApplicationDbContextSeed.SeedEvaluationSectionsAsync(dbContext);
				}
				catch (Exception ex)
				{
					var logger = scope.ServiceProvider.GetRequiredService<ILogger<MigrationRepository>>();
					logger.LogError(ex, "An error occurred while migrating database.");
				}
			}
		}
	}
}