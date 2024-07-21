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
    public class GenericPassClass
    {
        public string issuerId { get; set; }
        public string classSuffix { get; set; }
        public GenericClass WalletClass { get; set; }
        public GenericPassClass(string issuerId, string classSuffix)
        {
            this.WalletClass = new GenericClass
            {
                Id = $"{issuerId}.{classSuffix}",
                ClassTemplateInfo = new ClassTemplateInfo
                {
                    CardTemplateOverride = new CardTemplateOverride
                    {
                        CardRowTemplateInfos = new List<CardRowTemplateInfo>
                        {
                            new CardRowTemplateInfo
                            {
                                TwoItems = new CardRowTwoItems
                                {
                                    StartItem = new TemplateItem
                                    {
                                        FirstValue = new FieldSelector
                                        {
                                            Fields = new List<FieldReference>
                                            {
                                                new FieldReference
                                                {
                                                    FieldPath ="object.textModulesData['valid']",
                                                    DateFormat = "DATE_TIME_YEAR"
                                                }
                                            }
                                        }
                                    },
                                    EndItem = new TemplateItem
                                    {
                                        FirstValue = new FieldSelector
                                        {
                                            Fields = new List<FieldReference>
                                            {
                                                new FieldReference
                                                {
                                                    FieldPath ="object.textModulesData['expiration']",
                                                    DateFormat = "DATE_TIME_YEAR"

                                                }
                                            }
                                        }
                                    }
                                }
                            },
                            new CardRowTemplateInfo
                            {
                                OneItem = new CardRowOneItem
                                {
                                    Item = new TemplateItem
                                    {
                                        FirstValue = new FieldSelector
                                        {
                                            Fields = new List<FieldReference>
                                            {
                                                new FieldReference
                                                {
                                                    FieldPath ="object.textModulesData['phone']"
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
            this.issuerId = issuerId;
            this.classSuffix = classSuffix;
        }

    }
}
