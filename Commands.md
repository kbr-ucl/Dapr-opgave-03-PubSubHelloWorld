Start a RabbitMQ message broker by entering the following command:
docker run -d -p 5672:5672 -p 15672:15672 --name dtc-rabbitmq rabbitmq:3-management

RabibtMq monitor

http://localhost:15672/


cd C:\Dropbox\SourceCode\dapr\Dapr-opgave-03-PubSubHelloWorld
cd ./HelloWorld.Publish

dapr run --app-id helloworldpublish --app-port 5243 --dapr-http-port 3601 --dapr-grpc-port 60001 --resources-path .././myComponents dotnet run

http://localhost:5243/swagger/index.html


C:\Dropbox\SourceCode\dapr\Dapr-opgave-03-PubSubHelloWorld
cd ./HelloWorld.Subscribe

dapr run --app-id helloworldsubscribe --app-port 5181 --dapr-http-port 3602 --dapr-grpc-port 60002 --resources-path .././myComponents dotnet run





