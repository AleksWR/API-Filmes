using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace FilmesApi
{
    public static class ExceptionsInterceptor
    {
        public static void UseProblemDetailsExceptionHandler(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (exceptionHandlerFeature != null)
                    {
                        var exception = exceptionHandlerFeature.Error;

                        var problemDetails = new ProblemDetails
                        {
                            Instance = context.Request.HttpContext.Request.Path
                        };
                        if (exception is BadHttpRequestException badHttpRequestException)
                        {
                            problemDetails.Title = "The request is invalid";
                            problemDetails.Status = StatusCodes.Status400BadRequest;
                            problemDetails.Detail = badHttpRequestException.Message;
                        }
                        else
                        {
                            var logger = loggerFactory.CreateLogger("GlobalExceptionHandler");
                            logger.LogError($"Unexpected error: {exceptionHandlerFeature.Error}");

                            problemDetails.Title = exception.Message;
                            problemDetails.Status = StatusCodes.Status500InternalServerError;
                            problemDetails.Detail = exception.ToString();
                        }

                        context.Response.StatusCode = problemDetails.Status.Value;
                        context.Response.ContentType = "application/problem+json";

                        var json = JsonConvert.SerializeObject(problemDetails);

                        var caminhoLogs = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                        string caminhoArquivoLog = Path.Combine(caminhoLogs, "ErrorLogs.txt");
                        if (!File.Exists(caminhoArquivoLog))
                        {
                            FileStream arquivo = File.Create(caminhoArquivoLog);
                            arquivo.Close();
                        }
                        using (StreamWriter w = File.AppendText(caminhoArquivoLog))
                        {
                            AppendLog(json, w);
                        }

                        await context.Response.WriteAsync(json);
                    }
                });
            });
        }

        private static void AppendLog(string logMensagem, TextWriter txtWriter)
        {
            txtWriter.Write("\r\nLog Entrada : ");
            txtWriter.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            txtWriter.WriteLine("  :");
            txtWriter.WriteLine($"  :{logMensagem}");
            txtWriter.WriteLine("------------------------------------");
        }


    }
}
