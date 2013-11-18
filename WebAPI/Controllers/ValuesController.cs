using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers {
    public class ValuesController : ApiController {
        public static List<string> data = new List<string> { "value1", "value2" };
        // GET api/values
        public IEnumerable<string> Get() {
            return data;
        }

        // GET api/values/5
        public string Get(int id) {
            return data[id];
        }

        // POST api/values
        public void Post([FromBody]string value) {
            data.Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value) {
            data[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id) {
            data.RemoveAt(id);
        }
    }
}