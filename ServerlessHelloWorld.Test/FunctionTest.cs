using Amazon.Lambda.TestUtilities;
using Amazon.Lambda.APIGatewayEvents;
using System.Text.Json;
using Xunit;

namespace ServerlessHelloWorld.Tests
{
    public class FunctionTest
    {
        public FunctionTest()
        {
        }

        [Fact]
        public void TestGetMethod()
        {
            Function functions = new Function();
            
            APIGatewayProxyRequest request = new APIGatewayProxyRequest();
            TestLambdaContext context = new TestLambdaContext();
            APIGatewayProxyResponse response = functions.HandleHello(request, context);
            
            Assert.Equal(200, response.StatusCode);
            Assert.Equal(JsonSerializer.Serialize(new { Message = "Hello World!" }), response.Body);
        }
    }
}
