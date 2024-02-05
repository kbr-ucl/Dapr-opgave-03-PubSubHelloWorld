using Dapr.Client;
using Hello.Crosscut.IntegrationMessages;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<IActionResult> PublishHello([FromBody] HelloMessage message)
    {
        _logger.LogInformation($"Publishing Hello message {message.Message}");
        try
        {
            await _daprClient.PublishEventAsync("pubsub", "hellotopic", message).ConfigureAwait(true);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error publishing message");
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }


        return Ok(message);
    }
}