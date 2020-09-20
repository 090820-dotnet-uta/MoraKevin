using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using P0.Models;

namespace P0.DAOs
{
    class UserAccountDAO
    {
        internal static void AddUserAccount(UserAccount user, P0Context DB)
        {
            DB.UserAccounts.Add(user);
            DB.SaveChanges();
        }

        internal static void UpdateUserAccount(UserAccount user, P0Context DB)
        {
            DB.UserAccounts.Update(user);
            DB.SaveChanges();
        }

        internal static void RemoveUserAccount(UserAccount user, P0Context DB)
        {
            DB.UserAccounts.Remove(user);
            DB.SaveChanges();
        }

        internal static void LoadUserAccountsList(P0Context DB)
        {
            DB.UserAccountsList =  DB.UserAccounts.ToList();
        }
    }
}
