using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using text2data.Api.DTO;

namespace text2data.Api
{
    public class API
    {
        public const string ApiUrl = "http://api.text2data.com/root/";
        public const SerializeFormats ApiSerializeFormat = SerializeFormats.Json;
        public const bool ApiUseCompression = true;
        

        public static DocumentResult GetDocumentAnalysisResult(Document reqDoc)
        {
            var docRes = SendRequest(reqDoc);
            
            return docRes;
        }

        private static DocumentResult SendRequest(Document requestDto)
        {
            try
            {
                requestDto.SerializeFormat = (int)ApiSerializeFormat;
				ServicePointManager.ServerCertificateValidationCallback = (a, b, c, d) => true;
                //////
                var request = (HttpWebRequest)WebRequest.Create(ApiUrl);
                request.Method = "POST";
                if (ApiUseCompression)
                {
                    request.Headers.Add("Accept-Encoding", "gzip,deflate");
                    request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                }
                request.ContentType = ApiSerializeFormat == SerializeFormats.Json ? "application/json" : "application/xml";
                request.Timeout = 60000;// should be between 30s to max 1 min for very long documents

                #region send request
                using (var requestWriter = new StreamWriter(request.GetRequestStream()))
                {
                    if (ApiSerializeFormat == SerializeFormats.Json)
                    {
                        requestWriter.Write(Serializers.ToJSON<Document>(requestDto));
                    }
                    else
                    {
                        requestWriter.Write(Serializers.SerializeXML<Document>(requestDto));
                    }
                }
                #endregion

                #region read response
                var response = (HttpWebResponse)request.GetResponse();
                using (var resStream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(resStream))
                    {
                        if (ApiSerializeFormat == SerializeFormats.Json)
                        {
                            return Serializers.FromJSON<DocumentResult>(reader.ReadToEnd());
                        }
                        else
                        {
                            return Serializers.DeserializeXML<DocumentResult>(reader.ReadToEnd());
                        }
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                return new DocumentResult() { Status = (int)DocumentResultStatus.GenericError, ErrorMessage = ex.Message };
            }
        }

    }
}
