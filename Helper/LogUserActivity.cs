using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Amingo.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Amingo.Helpers
{
	public class LogUserActivity : IAsyncActionFilter
	{
		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			//this will happen at the end of any action execution
			var resultContext = await next();

			var userId = int.Parse(resultContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
			var repo = resultContext.HttpContext.RequestServices.GetService<IAmingoRepo>();

			var user = await repo.GetUser(userId);
			user.LastActive = DateTime.Now;
			await repo.SaveAll();
		}
	}
}