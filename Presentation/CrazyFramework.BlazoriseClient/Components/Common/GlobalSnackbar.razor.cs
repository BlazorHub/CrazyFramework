﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazorise.Snackbar;
using CrazyFramework.BlazoriseClient.Models;
using CrazyFramework.BlazoriseClient.Shared;
using Microsoft.AspNetCore.Components;

namespace CrazyFramework.BlazoriseClient.Components.Common
{
	public partial class GlobalSnackbar
	{
		protected Snackbar snackbar;
		protected SnackbarColor color = SnackbarColor.Info;
		protected MarkupString message = (MarkupString)string.Empty;

		[Inject]
		public NotificationService notificationService { get; set; }

		protected override void OnInitialized()
		{
			notificationService.SnackbarNotify += ToggleSnackbar;
		}

		private void ToggleSnackbar(SnackbarColor color, string message)
		{
			this.color = color;
			this.message = (MarkupString)message;

			snackbar.Show();
			StateHasChanged();
		}
	}
}