/*using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Walletobjects.v1;
using Google.Apis.Walletobjects.v1.Data;
using Microsoft.IdentityModel.Tokens;
using MudBlazorWebApp1.Model.Gwallet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;

namespace MudBlazorWebApp1.Model.Gwallet
{
    public class PassManager
    {
        public static ServiceAccountCredential credentials;
        public static string keyFilePath;
        public static WalletobjectsService service;
        public PassManager(string keyFilePath)
        {

            *//*keyFilePath = Environment.GetEnvironmentVariable(
        "GOOGLE_APPLICATION_CREDENTIALS") ?? "/path/to/key.json";*//*
            keyFilePath = "dulcet-voyager-385103-4c4243a8107d.json";
        }
        public void Auth()
        {
            credentials = (ServiceAccountCredential)GoogleCredential
                .FromFile(keyFilePath)
                .CreateScoped(new List<string>
                {
                    WalletobjectsService.ScopeConstants.WalletObjectIssuer
                }).UnderlyingCredential;
            service = new WalletobjectsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credentials
            });
        }
        public string CreateGenericClass(GenericPassClass newPassClass)
        {
            string issuerId = newPassClass.issuerId;
            string classSuffix = newPassClass.classSuffix;
            GenericClass newClass = newPassClass.WalletClass;
            // Check if the class exists
            Stream responseStream = service.Genericclass
            .Get($"{issuerId}.{classSuffix}")
            .ExecuteAsStream();

            StreamReader responseReader = new StreamReader(responseStream);
            JObject jsonResponse = JObject.Parse(responseReader.ReadToEnd());

            if (!jsonResponse.ContainsKey("error"))
            {
                Console.WriteLine($"Class {issuerId}.{classSuffix} already exists!");
                return $"{issuerId}.{classSuffix}";
            }
            else if (jsonResponse["error"].Value<int>("code") != 404)
            {
                // Something else went wrong...
                Console.WriteLine(jsonResponse.ToString());
                return $"{issuerId}.{classSuffix}";
            }

            // See link below for more information on required properties
            // https://developers.google.com/wallet/generic/rest/v1/genericclass


            responseStream = service.Genericclass
                .Insert(newClass)
                .ExecuteAsStream();

            responseReader = new StreamReader(responseStream);
            jsonResponse = JObject.Parse(responseReader.ReadToEnd());

            Console.WriteLine("Class insert response");
            Console.WriteLine(jsonResponse.ToString());

            return $"{issuerId}.{classSuffix}";
        }
        // [END createClass]


        public string CreateClass(EventPassClass newPassClass)
        {
            string issuerId = newPassClass.issuerId;
            string classSuffix = newPassClass.classSuffix;
            EventTicketClass newClass = newPassClass.WalletClass;
            // Check if the class exists
            Stream responseStream = service.Eventticketclass
                .Get($"{issuerId}.{classSuffix}")
                .ExecuteAsStream();

            StreamReader responseReader = new StreamReader(responseStream);
            JObject jsonResponse = JObject.Parse(responseReader.ReadToEnd());

            if (!jsonResponse.ContainsKey("error"))
            {
                Console.WriteLine($"Class {issuerId}.{classSuffix} already exists!");
                return $"{issuerId}.{classSuffix}";
            }
            else if (jsonResponse["error"].Value<int>("code") != 404)
            {
                // Something else went wrong...
                Console.WriteLine(jsonResponse.ToString());
                return $"{issuerId}.{classSuffix}";
            }

            // See link below for more information on required properties
            // https://developers.google.com/wallet/tickets/events/rest/v1/eventticketclass
            // EventTicketClass newClass = this.newClass;

            responseStream = service.Eventticketclass
                .Insert(newClass)
                .ExecuteAsStream();

            responseReader = new StreamReader(responseStream);
            jsonResponse = JObject.Parse(responseReader.ReadToEnd());

            Console.WriteLine("Class insert response");
            Console.WriteLine(jsonResponse.ToString());

            return $"{issuerId}.{classSuffix}";
        }
        // [END createClass]

        public string CreateGenericObject(GenericPassObject newPassObject)
        {
            string issuerId = newPassObject.issuerId;
            string objectSuffix = newPassObject.objectSuffix;
            GenericObject newObject = newPassObject.WalletObject;
            // Check if the object exists
            Stream responseStream = service.Genericobject
                .Get($"{issuerId}.{objectSuffix}")
                .ExecuteAsStream();

            StreamReader responseReader = new StreamReader(responseStream);
            JObject jsonResponse = JObject.Parse(responseReader.ReadToEnd());

            if (!jsonResponse.ContainsKey("error"))
            {
                Console.WriteLine($"Object {issuerId}.{objectSuffix} already exists!");
                return $"{issuerId}.{objectSuffix}";
            }
            else if (jsonResponse["error"].Value<int>("code") != 404)
            {
                // Something else went wrong...
                Console.WriteLine(jsonResponse.ToString());
                return $"{issuerId}.{objectSuffix}";
            }

            // See link below for more information on required properties
            // https://developers.google.com/wallet/generic/rest/v1/genericobject


            responseStream = service.Genericobject
                .Insert(newObject)
                .ExecuteAsStream();
            responseReader = new StreamReader(responseStream);
            jsonResponse = JObject.Parse(responseReader.ReadToEnd());

            Console.WriteLine("Object insert response");
            Console.WriteLine(jsonResponse.ToString());

            return $"{issuerId}.{objectSuffix}";
        }
        // [END createObject]

        public string CreateEventObject(EventPassObject newPassObject)
        {
            string issuerId = newPassObject.issuerId;
            string objectSuffix = newPassObject.objectSuffix;
            EventTicketObject newObject = newPassObject.WalletObject;
            // Check if the object exists
            Stream responseStream = service.Eventticketobject
                .Get($"{issuerId}.{objectSuffix}")
                .ExecuteAsStream();

            StreamReader responseReader = new StreamReader(responseStream);
            JObject jsonResponse = JObject.Parse(responseReader.ReadToEnd());

            if (!jsonResponse.ContainsKey("error"))
            {
                Console.WriteLine($"Object {issuerId}.{objectSuffix} already exists!");
                return $"{issuerId}.{objectSuffix}";
            }
            else if (jsonResponse["error"].Value<int>("code") != 404)
            {
                // Something else went wrong...
                Console.WriteLine(jsonResponse.ToString());
                return $"{issuerId}.{objectSuffix}";
            }

            // See link below for more information on required properties
            // https://developers.google.com/wallet/tickets/events/rest/v1/eventticketobject
            
            responseStream = service.Eventticketobject
                .Insert(newObject)
                .ExecuteAsStream();
            responseReader = new StreamReader(responseStream);
            jsonResponse = JObject.Parse(responseReader.ReadToEnd());

            Console.WriteLine("Object insert response");
            Console.WriteLine(jsonResponse.ToString());

            return $"{issuerId}.{objectSuffix}";
        }
        // [END createObject]
        *//*public string CreateJWTNewObjects(
            )
        {
            // Ignore null values when serializing to/from JSON
            JsonSerializerSettings excludeNulls = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            // See link below for more information on required properties
            // https://developers.google.com/wallet/generic/rest/v1/genericclass
            // Create JSON representations of the class and object
            JObject serializedClass = JObject.Parse(
                JsonConvert.SerializeObject(newClass, excludeNulls));
            JObject serializedObject = JObject.Parse(
                JsonConvert.SerializeObject(newObject, excludeNulls));

            // Create the JWT as a JSON object
            JObject jwtPayload = JObject.Parse(JsonConvert.SerializeObject(new
            {
                iss = credentials.Id,
                aud = "google",
                origins = new List<string>
                {
                "www.example.com"
                },
                typ = "savetowallet",
                payload = JObject.Parse(JsonConvert.SerializeObject(new
                {
                    // The listed classes and objects will be created
                    // when the user saves the pass to their wallet
                    genericClasses = new List<JObject>
                    {
                        serializedClass
                    },
                    genericObjects = new List<JObject>
                    {
                        serializedObject
                    }
                }))
            }));

            // Deserialize into a JwtPayload
            JwtPayload claims = JwtPayload.Deserialize(jwtPayload.ToString());

            // The service account credentials are used to sign the JWT
            RsaSecurityKey key = new RsaSecurityKey(credentials.Key);
            SigningCredentials signingCredentials = new SigningCredentials(
                key, SecurityAlgorithms.RsaSha256);
            JwtSecurityToken jwt = new JwtSecurityToken(
                new JwtHeader(signingCredentials), claims);
            string token = new JwtSecurityTokenHandler().WriteToken(jwt);

            Console.WriteLine("Add to Google Wallet link");
            Console.WriteLine($"https://pay.google.com/gp/v/save/{token}");

            return $"https://pay.google.com/gp/v/save/{token}";
        }
        // [END jwtNew]
*//*
        public string CreateJWTNewObjects<TClass, TObject>(TClass newClass, TObject newObject, string passType)
        {
            // Ignore null values when serializing to/from JSON
            JsonSerializerSettings excludeNulls = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            // Create JSON representations of the class and object
            JObject serializedClass = JObject.Parse(
                JsonConvert.SerializeObject(newClass, excludeNulls));
            JObject serializedObject = JObject.Parse(
                JsonConvert.SerializeObject(newObject, excludeNulls));

            // Determine the class and object keys based on the pass type
            string classesKey, objectsKey;
            switch (passType)
            {
                case "generic":
                    classesKey = "genericClasses";
                    objectsKey = "genericObjects";
                    break;
                case "eventTicket":
                    classesKey = "eventTicketClasses";
                    objectsKey = "eventTicketObjects";
                    break;
                default:
                    throw new ArgumentException("Invalid pass type specified.");
            }
            var payloadDict = new Dictionary<string, object>
            {
                { classesKey, new List<JObject> { serializedClass } },
                { objectsKey, new List<JObject> { serializedObject } }
            };
            var jwtPayloadDict = new Dictionary<string, object>
            {
                { "iss", credentials.Id },
                { "aud", "google" },
                { "origins", new List<string> { "www.example.com" } },
                { "typ", "savetowallet" },
                { "payload", payloadDict }
            };
            // Create the JWT as a JSON object
            string jwtPayload = JsonConvert.SerializeObject(jwtPayloadDict);

            // Deserialize into a JwtPayload
            JwtPayload claims = JwtPayload.Deserialize(jwtPayload);

            // The service account credentials are used to sign the JWT
            RsaSecurityKey key = new RsaSecurityKey(credentials.Key);
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.RsaSha256);
            JwtSecurityToken jwt = new JwtSecurityToken(
                new JwtHeader(signingCredentials), claims);
            string token = new JwtSecurityTokenHandler().WriteToken(jwt);

            Console.WriteLine("Add to Google Wallet link");
            Console.WriteLine($"https://pay.google.com/gp/v/save/{token}");

            return $"https://pay.google.com/gp/v/save/{token}";
        }

        // Example usage for GenericClass
        public string CreateGenericJWT(GenericClass newClass, GenericObject newObject)
        {
            return CreateJWTNewObjects(newClass, newObject, "generic");
        }

        // Example usage for EventTicketClass
        public string CreateEventTicketJWT(EventTicketClass newClass, EventTicketObject newObject)
        {
            return CreateJWTNewObjects(newClass, newObject, "eventTicket");
        }

    }
}
*/