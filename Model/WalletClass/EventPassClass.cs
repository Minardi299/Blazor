using Google.Apis.Requests;
using Google.Apis.Walletobjects.v1.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MudBlazorWebApp1.Model.Gwallet
{
    public class EventPassClass
    {
        public string issuerId { get; set; }
        public string classSuffix { get; set; }
        public EventTicketClass WalletClass { get; set; }
        public EventPassClass(string issuerId, string classSuffix)
        {
            this.WalletClass = new EventTicketClass
            {
                Id = $"{issuerId}.{classSuffix}",
                IssuerName = "[TEST ONLY] Heraldic Event",
                LocalizedIssuerName = new LocalizedString
                {
                    DefaultValue = new TranslatedString
                    {
                        Language = "en-US",
                        Value = "[TEST ONLY] Heraldic Event"
                    }
                },
                Logo = new Image
                {
                    SourceUri = new ImageUri
                    {
                        Uri = "https://images.unsplash.com/photo-1475721027785-f74eccf877e2?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=660&h=660"
                    },
                    ContentDescription = new LocalizedString
                    {
                        DefaultValue = new TranslatedString
                        {
                            Language = "en-US",
                            Value = "LOGO_IMAGE_DESCRIPTION"
                        }
                    }
                },
                EventName = new LocalizedString
                {
                    DefaultValue = new TranslatedString
                    {
                        Language = "en-US",
                        Value = "Google Live"
                    }
                },
                Venue = new EventVenue
                {
                    Name = new LocalizedString
                    {
                        DefaultValue = new TranslatedString
                        {
                            Language = "en-US",
                            Value = "Shoreline Amphitheater"
                        }
                    },
                    Address = new LocalizedString
                    {
                        DefaultValue = new TranslatedString
                        {
                            Language = "en-US",
                            Value = "ADDRESS_OF_THE_VENUE"
                        }
                    }
                },
                DateTime = new EventDateTime
                {
                    Start = "2023-04-12T11:30"
                },
                ReviewStatus = "UNDER_REVIEW",
                HexBackgroundColor = "#264750",
                HeroImage = new Image
                {
                    SourceUri = new ImageUri
                    {
                        Uri = "https://images.unsplash.com/photo-1501281668745-f7f57925c3b4?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1032&h=336"
                    },
                    ContentDescription = new LocalizedString
                    {
                        DefaultValue = new TranslatedString
                        {
                            Language = "en-US",
                            Value = "HERO_IMAGE_DESCRIPTION"
                        }
                    }
                }
            };
            this.issuerId = issuerId;
            this.classSuffix = classSuffix;
        
    
        }
    }
}