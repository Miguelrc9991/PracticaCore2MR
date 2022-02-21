using Newtonsoft.Json;
using System;

public class HelperSession
{
    public static string SerializarObjeto(Object obj)
    {
        string data = JsonConvert.SerializeObject(obj);
        return data;
    }

    public static T DeserializarObjeto<T>(string data)
    {
        return JsonConvert.DeserializeObject<T>(data);
    }
}