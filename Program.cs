using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using text2data.Api;
using text2data.Api.DTO;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputText = "Excellent location, opposite a very large mall with wide variety of shops, restaurants and more.";
            var privateKey = ""; //add your private key here (you can find it in the admin panel once you sign-up)
            var secret = ""; //this should be set-up in admin panel as well
            /////////////////////////

            #region Create request object
            var doc = new Document()
                {
                    DocumentText = inputText,
                    IsTwitterContent = false,
                    UserCategoryModelName = "", //name of your trained model, leave empty for default
                    PrivateKey = privateKey,
                    Secret = secret
                };
            #endregion

            var docResult = API.GetDocumentAnalysisResult(doc); //execute request

            if (docResult.Status == (int)DocumentResultStatus.OK) //check status
            {
                #region Display results
                //display document level score
                Console.WriteLine(string.Format("This document is: {0}{1} {2}", docResult.DocSentimentPolarity, docResult.DocSentimentResultString, docResult.DocSentimentValue.ToString("0.000")));

                #region display entity scores if any found
                if (docResult.Entities != null && docResult.Entities.Any())
                {
                    Console.WriteLine(Environment.NewLine + "Entities:");
                    foreach (var entity in docResult.Entities)
                    {
                        Console.WriteLine(string.Format("{0} ({1}) {2}{3} {4}", entity.Text, entity.KeywordType, entity.SentimentPolarity, entity.SentimentResult, entity.SentimentValue.ToString("0.0000")));
                    }
                }
                #endregion

                #region display keyword scores if any found

                if (docResult.Keywords != null && docResult.Keywords.Any())
                {
                    Console.WriteLine(Environment.NewLine + "Keywords:");
                    foreach (var keyword in docResult.Keywords)
                    {
                        Console.WriteLine(string.Format("{0} {1}{2} {3}", keyword.Text, keyword.SentimentPolarity, keyword.SentimentResult, keyword.SentimentValue.ToString("0.0000")));
                    }
                }
                #endregion


                //display more information below if required 

                #endregion
            }
            else
            {
                Console.WriteLine(docResult.ErrorMessage);
            }

            Console.ReadLine();
        }
    }
}
