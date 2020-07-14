﻿using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrazyFramework.API.Controllers
{
	[AllowAnonymous]
	[ApiExplorerSettings(IgnoreApi = true)]
	public class OidcConfigurationController : Controller
	{
		public OidcConfigurationController(IClientRequestParametersProvider clientRequestParametersProvider)
		{
			ClientRequestParametersProvider = clientRequestParametersProvider;
		}

		public IClientRequestParametersProvider ClientRequestParametersProvider { get; }

		[HttpGet("_configuration/{clientId}")]
		public IActionResult GetClientRequestParameters([FromRoute] string clientId)
		{
			var parameters = ClientRequestParametersProvider.GetClientParameters(HttpContext, clientId);
			return Ok(parameters);
		}
	}
}