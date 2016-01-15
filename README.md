# AlexaApiWrapper

Project that wraps the ALEXA API into C# POCO objects, and implements authentication and all 5 API end points and their responses.

Usage:
```
var client = new AlexaClient(_alexaKey, _alexaSecretKey);
var urlInfo = client.GetUrlInfo("http://microsoft.com", UrlInfoResponseGroup.All);
```
