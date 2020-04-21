using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_QLBGX.All_class
{
    public class utils
    {
        public string parseUrl(string url, int page, int limit, string search)
        {
            return url + "?page=" + page + "&limit=" + limit + "&search=" + search;
        }
        public string parseUrl(string url,int page, int limit, int typeCard, string search)
        {
            return url + "?page="+page+"&limit="+limit+"&typecard="+typeCard + "&search=" + search;
        }
        public string parseUrlUser(string url, int page, int limit)
        {
            return url + "?page=" + page + "&limit=" + limit;
        } 
    }
}