using System;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace ServerlessHelloWorld
{
    public class Function
    {
        public Function()
        {
        }

        public APIGatewayProxyResponse HandleHello(APIGatewayProxyRequest request, ILambdaContext context)
        {
            Console.WriteLine(JsonSerializer.Serialize(new
            {
                request.RequestContext,
                request.Body,
            }));

            APIGatewayProxyResponse response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = JsonSerializer.Serialize(new { Message = "Hello World!" }),
                Headers = new Dictionary<string, string> { { "Content-Type", "text/json" } }
            };

            return response;
        }
    }
}
