using Buhler.DevChallenge.WebApi.Client;

var workingDirectory = args[0];
        
const string swaggerJsonUrl = "http://localhost:5000/swagger/v1/swagger.json"; 
const string clientName = "DevChallengeClient"; 
const string @namespace = "Buhler.DevChallenge.WebApi.Client";
        
await NswagClientGenerator.GenerateAsync(workingDirectory, swaggerJsonUrl, clientName, @namespace);