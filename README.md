# Blazor
# Getting started with Google Wallet API
https://developers.google.com/wallet/generic/getting-started/onboarding-guide \n
-setting up account \n
https://developers.google.com/wallet/generic/getting-started/issuer-onboarding \n
-enable wallet api for your account + generate your private key + generate an email account to authenthicate all API request \n
https://developers.google.com/wallet/generic/getting-started/auth/rest
-pass builder to get an general idea of what the pass would look like. After building the pass, use the json generated to translate to code (use this link to get the 
type of each field https://developers.google.com/wallet/reference/rest/v1/genericobject). Example can be found in
Model/WalletObect/GenericPassObject.cs
https://developers.google.com/wallet/generic/getting-started/build-your-first-pass
-generic pass example
https://developers.google.com/wallet/generic/resources/pass-builder
-event ticket pass example
https://developers.google.com/wallet/tickets/events/resources/pass-builder
-the basic of pass class and pass object
tldr: class is the template, ie an event would be a class, with the universal informations: event name, location, etc. Object is the unique pass for each individual,
containing name, unique identifier, etc.
https://developers.google.com/wallet/generic/resources/terminology
https://developers.google.com/wallet/generic/overview/how-classes-objects-work
-work flow of issuing a pass 
https://developers.google.com/wallet/generic/overview/add-to-google-wallet-flow
https://developers.google.com/wallet/generic/web
# PASS IS NOT PUBLIC YET AND CAN ONLY BE USED FOR TESTING, TO PUBLISH, VISIT
https://developers.google.com/wallet/generic/test-and-go-live/request-publishing-access
# Sample code for each type of pass in dotnet
https://github.com/google-wallet/rest-samples/tree/main/dotnet

# In this repository
The Google Wallet Form will take as input a name, a phone number, an unique employee id and a colour which then will be use to create a GenericPassObject.
The Generic Card will act as a manager, has methods such as authenthicate, create, modify, sign JWT token, and delete, it will take as input a generic class and a generic object.
Code is very similar to the samples provided above.
# BEFORE TRYING THE CODE, YOU WILL HAVE TO INCLUDE YOUR OWN PRIVATE KEY IN THE MODEL FOLDER AND REPLACE THE CODE IN GenericCard.cs line 39