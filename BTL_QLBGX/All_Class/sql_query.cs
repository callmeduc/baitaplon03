using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_QLBGX.All_class
{
    public class sql_query
    {
        // typecard 
        public static string SELECT_ALL_TYPECARD = "select * from typecard";
        // typecard
        public static string SELECT_ALL_PRODUCER= "select * from producer";
        // users
        public static string SELECT_ALL_USERS = "select userId,email,fullname from users";
        public static string SELECT_COUNT_USERS = "select count(*) from users";
        public static string SELECT_COUNT_PARKING = "select count(*) from parking";
        public static string SELECT_SUM_AMOUNT_PARKING = "select sum(amount) as 'sum' from parking";
        
        // SELECT_ALL_USERS_NOT_ACCESSCARD
        public static string SELECT_ALL_USERS_NOT_ACCESSCARD = "select u.userId,u.email,u.fullname from users u left join AccessCard a on a.accessCardId = u.userId where a.userId is null";
        // accesscard
        public static string SELECT_COUNT_ACCESSCARD(int typeCard = -1, string search = "") {
            string searchCard = "";
            if (typeCard > 0)
            {
                searchCard = "where a.typeCardId = " + typeCard;
                if (!search.Equals("")) searchCard += " or u.email like N'%" + search + "%' or u.fullname like N'%" + search + "%'";
            }
            else
            {
                if (!search.Equals(""))
                    searchCard += "where u.email like N'%"+search+ "%' or u.fullname like N'%" + search + "%'";
            }
            return "select count(*) from AccessCard a left join users u on a.userId = u.userId " + searchCard;
        }
        // accesscard paignation
        public static string SELECT_ACCESSCARD_PAGINATION(int offset, int limit, int typeCard = 0, string search = "")
        {
            string searchCard = "";
            if(typeCard> 0)
            {
                searchCard = "where tc.typeCardId = " + typeCard;
                if (!search.Equals("")) searchCard += " or u.email like '%" + search + "%' or u.fullname like '%" + search + "%'";
            }
            else
            {
                if (!search.Equals(""))
                    searchCard += "where u.email like '%" + search + "%' or u.fullname like '%" + search + "%'";
            }

            return @"select u.fullname,u.email,tc.name,FORMAT(a.expired, 'dd-MM-yyyy') as 'expired',a.licensePlate,p.name as 'producer', a.typeCar, FORMAT(a.createdAt, 'dd-MM-yyyy hh:mm') as 'createdAt', u.userId, a.accessCardId from AccessCard a left join users u on u.userId = a.userId join typeCard tc on tc.typeCardId = a.typeCardId left join producer p on p.producerId = a.producerId " + searchCard + " order by a.createdAt desc OFFSET " + offset + " rows FETCH NEXT " + limit + " ROWS ONLY";
        }
        public static string SELECT_ACCESSCARD_USER_BY_ID(int id)
        {
            return @"select u.userId,u.fullname,u.email from AccessCard a join users u on a.userId = u.userId where a.accessCardId=" + id;
        }
        // accesscard id 
        public static string SELECT_ACCESSCARD_BY_ID(int id)
        {
            return @"select a.accessCardId,u.fullname,u.email,a.typeCardId,format(a.expired,'yyyy-MM-dd') as 'expired',a.licensePlate,a.typeCar, a.producerId
                    from AccessCard a join users u on u.userId= a.userId
                    where a.accessCardId = " + id;
        }
        public static string UPDATE_ACCESSCARD_BY_ID(int id, string expired, string licensePlate,string typeCar, int producerId = -1, int typeCardId = -1, int userId = -1)
        {
            string listUpdate = "expired = '" + expired + "', licensePlate = '" + licensePlate + "', producerId = '" + producerId + "', typeCar = N'" + typeCar + "' , typeCardId = '" + typeCardId + "'";
            if (userId > -1) listUpdate += ", userId = '" + userId + "'";
            return @"update AccessCard set "+listUpdate+"  where accessCardId = " + id;
        }
        public static string SELECT_COUNT_USER_PARKING(string search = "")
        {
            string searchparking = "";
            if (!search.Equals(""))
                searchparking += "AND [licensePlateIn] like N'%" + search + "%'";
            return "SELECT COUNT([fullname]) " +
                    "FROM [dbo].[users],[dbo].[parking],[dbo].[AccessCard] " +
                    "WHERE [dbo].[users].userId = [dbo].[AccessCard].userId AND [dbo].[parking].accessCardId = [dbo].[AccessCard].accessCardId " + searchparking;
        }

        public static string SELECT_INFO_USER_PARKING(int offset, int limit, string search = "")
        {
            string searchCard = "";
            if (!search.Equals(""))
                searchCard += "AND [licensePlateIn] like N'%" + search + "%'";
            return @"SELECT [fullname],[email],[licensePlateIn],[licensePlateOut],[dateIn],[dateOut],[amount] " +
                    "FROM [dbo].[users],[dbo].[parking],[dbo].[AccessCard] " +
                    "WHERE [dbo].[users].userId = [dbo].[AccessCard].userId AND [dbo].[parking].accessCardId = [dbo].[AccessCard].accessCardId " + searchCard +
                    "group by [fullname],[email],[licensePlateIn],[licensePlateOut],[dateIn],[dateOut],[amount] order by [dateIn] desc OFFSET " + offset + "  rows FETCH NEXT  " + limit + "  ROWS ONLY;";
        }
    }
}