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
    public class EventPassObject
    {
        public EventTicketObject WalletObject;
        public string issuerId { get; set; }
        public string classSuffix { get; set; }
        public string objectSuffix { get; set; }



        public EventPassObject(string barcode,string hexColor, string objectSuffix, EventPassClass eventClass)
        {
            this.issuerId = eventClass.issuerId;
            this.classSuffix = eventClass.classSuffix;
            this.objectSuffix = objectSuffix;
            this.WalletObject = new EventTicketObject
            {
                Id = $"{issuerId}.{objectSuffix}",
                ClassId = $"{issuerId}.{classSuffix}",
                State = "ACTIVE",
                SeatInfo = new EventSeat
                {
                    Seat = new LocalizedString
                    {
                        DefaultValue = new TranslatedString
                        {
                            Language = "en-US",
                            Value = "5"
                        }
                    },
                    Row = new LocalizedString
                    {
                        DefaultValue = new TranslatedString
                        {
                            Language = "en-US",
                            Value = "G"
                        }
                    },
                    Section = new LocalizedString
                    {
                        DefaultValue = new TranslatedString
                        {
                            Language = "en-US",
                            Value = "40"
                        }
                    },
                    Gate = new LocalizedString
                    {
                        DefaultValue = new TranslatedString
                        {
                            Language = "en-US",
                            Value = "3A"
                        }
                    }
                },
                Barcode = new Barcode
                {
                    Type = "QR_CODE",
                    Value = barcode,
/*                    AlternateText = "hello"*/
                },
            };
  
        }
        
    }
}