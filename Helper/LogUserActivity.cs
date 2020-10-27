using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Amingo.Helpers
{
	public class LogUserActivity : IAsyncActionFilter
	{
		public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			throw new System.NotImplementedException();
		}
	}
}