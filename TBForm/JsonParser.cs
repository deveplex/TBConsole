using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace TBForm
{
    public static class JsonSerializer
    {
        public static string Serialize<T>(T obj)
        {
            //去掉Dictionary的Key和Value
            return Serialize<T>(obj, new DataContractJsonSerializerSettings()
            {
                UseSimpleDictionaryFormat = true
            });
        }

        // Object->Json
        public static string Serialize<T>(T obj, DataContractJsonSerializerSettings jsonSerializerSettings)
        {
            if (jsonSerializerSettings.UseSimpleDictionaryFormat == true)
            {
                //Newtonsoft.Json默认去掉Dictionary的Key和Value
                return Newtonsoft.Json.JsonConvert.SerializeObject(obj);

                /// v4.5
                //DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(obj.GetType(), new DataContractJsonSerializerSettings()
                //{
                //    UseSimpleDictionaryFormat = true,    //去掉Dictionary的Key和Value
                //});
                //string json = "";
                //using (MemoryStream stream = new MemoryStream())
                //{
                //    jsonSerializer.WriteObject(stream, obj);
                //    json = Encoding.UTF8.GetString(stream.ToArray());
                //}
                //return json;
            }
            else
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(obj.GetType()/*, new DataContractJsonSerializerSettings()
                {
                    UseSimpleDictionaryFormat = false,     //保留Dictionary的Key和Value
                }*/);
                string json = "";
                using (MemoryStream stream = new MemoryStream())
                {
                    jsonSerializer.WriteObject(stream, obj);
                    json = Encoding.UTF8.GetString(stream.ToArray());
                }
                return json;
            }
        }

        // Json->Object
        public static T Deserialize<T>(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);

            //T obj = default(T);
            //using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            //{
            //    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
            //    obj = (T)jsonSerializer.ReadObject(ms);
            //}
            //return obj;
        }
    }

    //public sealed class KeyValueCollection    {
    //    public KeyValuePair<string, object>[] KeyValueArray { get; set; }

    //    public void Add(string key, string value)
    //    {
    //        Type t = this.GetType();
    //        System.Reflection.PropertyInfo[] properties = t.GetProperties();
    //        properties.
    //        System.Reflection.PropertyInfo pt = getPropertys( this.a
    //    }
    //}
    public static class NameValueCollectionExtends
    {
        public static IDictionary<string, string> ToDictionary(this NameValueCollection source)
        {
            return source.AllKeys.ToDictionary(k => k, v => source[v]);
        }
    }
}
