using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaCore2MR.Extensions
{
    public static class SessionExtensions
    {
        public static void SetObject(this ISession session, string key, Object obj)
        {
            string data = HelperSession.SerializarObjeto(obj);
            session.SetString(key, data);
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            string data = session.GetString(key);

            if (data == null)
            {
                return default(T);
            }
            else
            {
                return HelperSession.DeserializarObjeto<T>(data);
            }
        }
    }
}
