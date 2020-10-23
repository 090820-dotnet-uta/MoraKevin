using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using P1.Models;

namespace P1.DAOs
{
    public class UserAccountDAO
    {
        public static void AddUserAccount(UserAccount user, P1Context DB)
        {
            DB.UserAccounts.Add(user);
            DB.SaveChanges();
        }

        internal static void UpdateUserAccount(UserAccount user, P1Context DB)
        {
            DB.UserAccounts.Update(user);
            DB.SaveChanges();
        }

        internal static void RemoveUserAccount(UserAccount user, P1Context DB)
        {
            DB.UserAccounts.Remove(user);
            DB.SaveChanges();
        }

        public static void LoadUserAccountsList(P1Context DB)
        {
            DB.UserAccountsList =  DB.UserAccounts.ToList();
        }
    }
}
