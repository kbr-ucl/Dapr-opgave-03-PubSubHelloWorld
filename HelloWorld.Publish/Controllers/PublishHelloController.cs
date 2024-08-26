using Dapr.Client;
using Hello.Crosscut.IntegrationMessages;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using System.Threading;

namespace HelloWorld.Publish.Controllers;

[Route("[controller]")]
[ApiController]
public class PublishHelloController : ControllerBase
{
    private readonly DaprClient _daprClient;
    private readonly ILogger<PublishHelloController> _logger;

    public PublishHelloController(DaprClient daprClient, ILogger<PublishHelloController> logger)
    {
        _daprClient = daprClient;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> PublishHello([FromBody] HelloMessage message, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Publishing Hello message {message.Message}");
        try
        {
            // https://docs.dapr.io/developing-applications/sdks/dotnet/dotnet-client/
            await _daprClient.InvokeMethodAsync("helloworldsubscribe", "SubscribeHello",
                message, cancellationToken);
            await _daprClient.InvokeMethodAsync("helloworldsubscribe2", "SubscribeHello",
                message, cancellationToken);
            _logger.LogInformation($"Publish successful");
            return Ok(message);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error publishing message");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }


        
    }
}