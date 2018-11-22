using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace text2data.Api
{
    public class Serializers
    {

        #region json serializers
        public static T FromJSON<T>(string json)
        {
            var jss = new JavaScriptSerializer();

            return jss.Deserialize<T>(json);
        }

        public static string ToJSON<T>(T objectDto)
        {
            var jss = new JavaScriptSerializer();

            return jss.Serialize(objectDto);
        }
        #endregion

        #region xml serializers
        public static string SerializeXML<T>(T obj)
        {
            string result = string.Empty;
            using (var ms = new MemoryStream())
            {
                var serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(ms, obj);
                result = Encoding.UTF8.GetString(ms.ToArray());
            }
            return result;
        }

        public static T DeserializeXML<T>(string input)
        {
            T obj = default(T);
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(input)))
            {
                var serializer = new XmlSerializer(typeof(T));
                obj = (T)serializer.Deserialize(ms);
            }
            return obj;
        }
        #endregion

    }
}
