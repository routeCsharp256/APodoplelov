using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;

namespace MerchandiseService.Infrastructure.Middlewares {
	public class LogRequestMiddleware {
		private readonly RequestDelegate NextDelegate;
		private readonly ILogger<LogRequestMiddleware> Logger;

		public LogRequestMiddleware(RequestDelegate next, ILogger<LogRequestMiddleware> logger) {
			this.NextDelegate = next;
			this.Logger = logger;
		}

		public async Task InvokeAsync(HttpContext context) {
			// TODO exclude grpc requests
			this.LogRequest(context);

			await this.NextDelegate(context);
		}

		private const string LogTemplate = "{result}"; 
		
		private void LogRequest(HttpContext context)
		{
			var sb = new StringBuilder();
			sb.Append($"Request path: {context.Request.Path.Value}{Environment.NewLine}{Environment.NewLine}");

			foreach ((var key, StringValues value) in context.Request.Headers)
			{
				sb.Append($"{key}: {value}{Environment.NewLine}");
			}

			this.Logger.LogInformation(LogTemplate, sb.ToString().Trim());
		}
	}
}