using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumBackEnd.Models
{
    public class ObjectToJsonConverter
    {
        public static string ObjectToJson(object test)
        {
            string testToJson= JsonConvert.SerializeObject(test);
            return testToJson;
        }
    }
}
