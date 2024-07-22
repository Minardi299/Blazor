using Google.Apis.Requests;
using Google.Apis.Walletobjects.v1.Data;
using MudBlazorWebApp1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MudBlazorWebApp1.Model.Gwallet
{
    public class GenericPassObject
    {
        public GenericObject WalletObject;
        public string issuerId { get; set; }
        public string classSuffix { get; set; }
        public string objectSuffix { get; set; }
        [Required]
        public string Name {  get; set; }
        [Required]
        public string Phone { get; set; }
        private string _barCode;
        [Required]
        public string BarCode
        {
            get => _barCode;
            set
            {
                _barCode = value;
                objectSuffix = value; // Update objectSuffix whenever BarCode changes
				

			}
        }
        public string HexColor { get;set; }
		public void InitializeWalletObject()
		{
			string currentDateTimeIso = System.DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
			string oneYearFromNowIso = System.DateTime.UtcNow.AddYears(1).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

			WalletObject = new GenericObject
			{
				Id = $"{issuerId}.{objectSuffix}",
				ClassId = $"{issuerId}.{classSuffix}",
				State = "ACTIVE",
				Logo = new Image
				{
					SourceUri = new ImageUri
					{
						Uri = "https://storage.googleapis.com/wallet-lab-tools-codelab-artifacts-public/pass_google_logo.jpg"
					},
					ContentDescription = new LocalizedString
					{
						DefaultValue = new TranslatedString
						{
							Language = "en-US",
							Value = "Logo"
						}
					}
				},
				CardTitle = new LocalizedString
				{
					DefaultValue = new TranslatedString
					{
						Language = "en-US",
						Value = "XYZ"
					}
				},
				Subheader = new LocalizedString
				{
					DefaultValue = new TranslatedString
					{
						Language = "en-US",
						Value = "Ten"
					}
				},
				Header = new LocalizedString
				{
					DefaultValue = new TranslatedString
					{
						Language = "en-US",
						Value = this.Name
					}
				},
				TextModulesData = new List<TextModuleData>
				{
					new TextModuleData
					{
						Header = "Valid from",
						Body = System.DateTime.Parse(currentDateTimeIso).ToString("yyyy-MM-dd"),
						Id = "valid"
					},
					new TextModuleData
					{
						Header = "Expire",
						Body = System.DateTime.Parse(oneYearFromNowIso).ToString("yyyy-MM-dd"),
						Id = "expiration"
					},
					new TextModuleData
					{
						Header ="Tel.",
						Body = this.Phone,
						Id = "phone"
					}
				},
				HeroImage = new Image
				{
					SourceUri = new ImageUri
					{
						Uri = "https://farm4.staticflickr.com/3723/11177041115_6e6a3b6f49_o.jpg"
					},
					ContentDescription = new LocalizedString
					{
						DefaultValue = new TranslatedString
						{
							Language = "en-US",
							Value = "Hero image description"
						}
					}
				},
				ValidTimeInterval = new TimeInterval
				{
					Start = new Google.Apis.Walletobjects.v1.Data.DateTime
					{
						Date = currentDateTimeIso
					},
					End = new Google.Apis.Walletobjects.v1.Data.DateTime
					{
						Date = oneYearFromNowIso
					}
				},

				LinksModuleData = new LinksModuleData
				{
					Uris = new List<Google.Apis.Walletobjects.v1.Data.Uri>
					{
						new Google.Apis.Walletobjects.v1.Data.Uri
						{
						UriValue = "http://maps.google.com/",
						Description = "Link module URI description",
						Id = "LINK_MODULE_URI_ID"
						},
						new Google.Apis.Walletobjects.v1.Data.Uri
						{
						UriValue = $"tel:{this.Phone}",
						Description = "Link module tel description",
						Id = "LINK_MODULE_TEL_ID"
						}
					}
				},
				Barcode = new Barcode
				{
					Type = "QR_CODE",
					Value = this.BarCode,
				},
				HexBackgroundColor = this.HexColor,
			};
		}

		public GenericPassObject(GenericPassClass genericClass) 
        {
            this.issuerId = genericClass.issuerId;
            this.classSuffix = genericClass.classSuffix;
            
        }
        public GenericPassObject(string name,string phone, string personID, string hexColor,  GenericPassClass genericClass)
        {
            //TODO, customize the card
            this.Name = name;
            this.Phone = phone; 
            this.BarCode = personID;
            this.HexColor = hexColor;

            issuerId = genericClass.issuerId;
            classSuffix = genericClass.classSuffix;
            this.objectSuffix = personID;
            string currentDateTimeIso = System.DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            string oneYearFromNowIso = System.DateTime.UtcNow.AddYears(1).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            WalletObject = new GenericObject
            {
                Id = $"{issuerId}.{objectSuffix}",
                ClassId = $"{issuerId}.{classSuffix}",
                State = "ACTIVE",
                Logo = new Image
                {
                    SourceUri = new ImageUri
                    {
                        Uri = "https://storage.googleapis.com/wallet-lab-tools-codelab-artifacts-public/pass_google_logo.jpg"
                    },
                    ContentDescription = new LocalizedString
                    {
                        DefaultValue = new TranslatedString
                        {
                            Language = "en-US",
                            Value = "Logo"
                        }
                    }
                },
                CardTitle = new LocalizedString
                {
                    DefaultValue = new TranslatedString
                    {
                        Language = "en-US",
                        Value = "XYZ"
                    }
                },
                Subheader = new LocalizedString
                {
                    DefaultValue = new TranslatedString
                    {
                        Language = "en-US",
                        Value = "Ten"
                    }
                },
                Header = new LocalizedString
                {
                    DefaultValue = new TranslatedString
                    {
                        Language = "en-US",
                        Value = this.Name
                    }
                },
                TextModulesData = new List<TextModuleData>
                {
                    new TextModuleData
                    {
                        Header = "Valid from",
                        Body = System.DateTime.Parse(currentDateTimeIso).ToString("yyyy-MM-dd"),
                        Id = "valid"
                    },
                    new TextModuleData
                    {
                        Header = "Expire",
                        Body = System.DateTime.Parse(oneYearFromNowIso).ToString("yyyy-MM-dd"),
                        Id = "expiration"
                    },
                    new TextModuleData
                    {
                        Header ="Tel.",
                        Body = this.Phone,
                        Id = "phone"
                    }
                },
                HeroImage = new Image
                {
                    SourceUri = new ImageUri
                    {
                        Uri = "https://farm4.staticflickr.com/3723/11177041115_6e6a3b6f49_o.jpg"
                    },
                    ContentDescription = new LocalizedString
                    {
                        DefaultValue = new TranslatedString
                        {
                            Language = "en-US",
                            Value = "Hero image description"
                        }
                    }
                },
                ValidTimeInterval = new TimeInterval
                {
                    Start = new Google.Apis.Walletobjects.v1.Data.DateTime
                    {
                        Date = currentDateTimeIso
                    },
                    End = new Google.Apis.Walletobjects.v1.Data.DateTime
                    {
                        Date = oneYearFromNowIso
                    }
                },

                LinksModuleData = new LinksModuleData
                {
                    Uris = new List<Google.Apis.Walletobjects.v1.Data.Uri>
                    {
                        new Google.Apis.Walletobjects.v1.Data.Uri
                        {
                        UriValue = "http://maps.google.com/",
                        Description = "Link module URI description",
                        Id = "LINK_MODULE_URI_ID"
                        },
                        new Google.Apis.Walletobjects.v1.Data.Uri
                        {
                        UriValue = $"tel:{this.Phone}",
                        Description = "Link module tel description",
                        Id = "LINK_MODULE_TEL_ID"
                        }
                    }
                },
                /*ImageModulesData = new List<ImageModuleData>
                {
                    new ImageModuleData
                    {
                        MainImage = new Image
                        {
                        SourceUri = new ImageUri
                        {
                            Uri = "http://farm4.staticflickr.com/3738/12440799783_3dc3c20606_b.jpg"
                        },
                        ContentDescription = new LocalizedString
                        {
                            DefaultValue = new TranslatedString
                            {
                            Language = "en-US",
                            Value = "Image module description"
                            }
                        }
                        },
                        Id = "IMAGE_MODULE_ID"
                    }
                },*/
                Barcode = new Barcode
                {
                    Type = "QR_CODE",
                    Value = this.BarCode,
                    /*                    AlternateText = "hello"*/
                },

                HexBackgroundColor = this.HexColor,

            };

        }
    }
}

