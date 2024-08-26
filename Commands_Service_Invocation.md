cd C:\Dropbox\SourceCode\dapr\Dapr-opgave-03-PubSubHelloWorld\HelloWorld.Publish
Alternativt: cd ./HelloWorld.Publish

dapr run --app-id helloworldpublish --app-port 5243 --dapr-http-port 3601 --dapr-grpc-port 60001 dotnet run

http://localhost:5243/swagger/index.html

cd C:\Dropbox\SourceCode\dapr\Dapr-opgave-03-PubSubHelloWorld\HelloWorld.Subscribe
Alternativt: cd ./HelloWorld.Subscribe

dapr run --app-id helloworldsubscribe --app-port 5181 --dapr-http-port 3602 --dapr-grpc-port 60002 dotnet run

dapr run --app-id helloworldsubscribe2 --app-port 5182 --dapr-http-port 3603 --dapr-grpc-port 60003 dotnet run





