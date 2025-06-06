﻿
using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BuildingBlocks.Behaviors;
public class LoggingBehaviors<TRequest, TResponse>(ILogger<LoggingBehaviors<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest: notnull, IRequest<TResponse>
    where TResponse : notnull
{
    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        logger.LogInformation("[START] Handle request={Request} - Response ={Response} - RequestData={RequestData}",
            typeof(TRequest).Name, typeof(TResponse).Name, request);

        var timer = new Stopwatch();
        timer.Start();

        var response = next();
        timer.Stop();

        var timeTaken = timer.Elapsed;
        if(timeTaken.Seconds > 3)
        {
            logger.LogWarning("[PERFORMANCE] The request {Request} took {TimeTaken} s",
                typeof(TRequest).Name, timeTaken.Seconds);
        }

        logger.LogInformation("[END] Handled {Request} with {Response}", typeof(TRequest).Name, typeof(TResponse).Name);
        return response;
    }
}
