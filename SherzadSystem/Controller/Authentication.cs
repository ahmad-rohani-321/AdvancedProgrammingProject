using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SherzadSystem.Model;

namespace SherzadSystem.Controller
{
    public class Authentication
    {
        #region Gets
        public static byte GetUser(string Username, string Password)
        {
            byte Done = default;
            using(ShirzadSystem s = new ShirzadSystem())
            {
                try
                {
                    var GetUser = s.Users.FirstOrDefault(x => x.UserName == Username && x.Password == Password);
                    if(GetUser != null)
                    {
                        if (GetUser.IsDeleted != false)
                        {
                            Done = 1;
                            Defaults.UserInfo = GetUser;
                        }
                        else
                        {
                            Done = 0;
                        }
                    }
                    else
                    {
                        Done = 2;
                    }
                }
                catch(Exception ex)
                {
                    Defaults.SetLog(ex);
                    Done = 3;
                }
            }
            return Done;
        }
        public static List<Users> GetAllUsers()
        {
            List<Users> users = new List<Users>();
            using(ShirzadSystem s = new ShirzadSystem())
            {
                try
                {
                    users = s.Users.ToList();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                }
            }
            return users;
        }
        #endregion

        #region Adds
        public static bool isAdded(Users u)
        {
            bool IsAdded = default;
            using (ShirzadSystem s = new ShirzadSystem())
            {
                try
                {
                    s.Users.Add(u);
                    s.SaveChanges();
                    IsAdded = true;
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                    IsAdded = false;
                }
            }
            return IsAdded;
        }
        #endregion

        internal static bool IsUpdated (Model.Users users)
        {
            bool update = true;
            using (Model.ShirzadSystem s = new ShirzadSystem())
            {
                try
                {
                    var row = s.Users.FirstOrDefault(x => x.Uid == users.Uid);
                    row.Name = users.Name;
                    row.UserName = users.UserName;
                    row.IsDeleted = users.IsDeleted;
                    row.Password = users.Password;

                    s.SaveChanges();
                }
                catch (Exception ex)
                {
                    Defaults.SetLog(ex);
                    update = false;
                }
            }
            return update;
        }
    }
}
