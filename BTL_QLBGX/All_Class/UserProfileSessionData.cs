using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_QLBGX.All_class
{
    public class UserProfileSessionData
    {
        public int userID { get; set; }
        public string fullname { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int permissionID { get; set; }
        public int isBlock { get; set; }
        public string createAt { get; set; }
    }
} 