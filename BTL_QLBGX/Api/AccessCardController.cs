﻿using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BTL_QLBGX.Api
{
    public class AccessCardController : ApiController
    {
        // GET api/<controller> 
        public string Get()
        {
            ArrayList al = new ArrayList { "Hello", "World", "From", "Sample", "Application" };
            return JsonConvert.SerializeObject(al);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public int Delete(int id)
        {
            return id;
        }
    }
}