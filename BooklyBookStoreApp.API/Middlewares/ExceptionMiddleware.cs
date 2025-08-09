using BooklyBookStoreApp.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace BooklyBookStoreApp.API.Middlewares
{
    public static class ExceptionMiddleware
    {
        // global hata yönetimi için middleware uzantısı
        public static void ConfigureExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {

                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>(); // fırlatılan hatayı yakalar
                    if (contextFeature is not null)  // hata varsa 
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            _ => StatusCodes.Status500InternalServerError
                        };
                       
                        await context.Response.WriteAsync(new ErrorModel()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message
                        }.ToString());
                       
                    }
                });
            });

        }
    }
}
