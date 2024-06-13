using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public class HttpTrigger1
    {
        // connection to service bus
        private static string connectionString = 
            "";
        private static string topicName = "oddeven";
        private static ServiceBusClient client = null!;
        private static ServiceBusSender sender = null!;

        private readonly ILogger<HttpTrigger1> _logger;

        public HttpTrigger1(ILogger<HttpTrigger1> logger)
        {
            _logger = logger;
        }

        [Function("HttpTrigger1")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            client = new ServiceBusClient(connectionString);
            sender = client.CreateSender(topicName);

            using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();
            if (!messageBatch.TryAddMessage(new ServiceBusMessage(requestBody)))
            {
                throw new Exception("The message is too large to fit the batch");
            }

            try
            {
                await sender.SendMessagesAsync(messageBatch);
                Console.WriteLine("A batch of messages has been published to the topic");
            }
            finally
            {
                await sender.DisposeAsync();
                await client.DisposeAsync();
            }

            return new OkObjectResult("Payload Received");
        }
    }
}
