using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonMethod
{
    public static class ExtentionMethod
    {
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T ToObject<T>(this string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }

    }
}
