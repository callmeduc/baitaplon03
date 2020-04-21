using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_QLBGX.All_class
{
    public class findParse
    {
        public int parseIntParams(string property, int defaultParams = 1)
        {
            HttpContext context = HttpContext.Current;
            try
            {
                if (context.Request.QueryString.Get(property) != null)
                {
                    defaultParams = Int32.Parse(context.Request.QueryString.Get(property));
                }
                if (property.Equals("typecard"))
                    if (defaultParams < 1) defaultParams = -1;
                else if (defaultParams < 1) defaultParams = 1;
                return defaultParams;
            }catch(Exception ex) 
            {
                return defaultParams;
            }
        }
    }
}