using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class UserRepository:Singleton<UserRepository>
    {
      //private static void id = 0; incrementra el id
        private List<User> UserList = new List<User>();
        static UserRepository instance = null;

 
        public void UserAdd(User u)
        {
          /*id++;
            u.id = id*/
            UserList.Add(u);
        }

        public void UserRemove(User u)
        {
            UserList.Remove(u);
        }

        public List<User> ReturnAll()
        {
            return UserList;
        }

        public User GetByEmail(string pEmail)
        {
            User aux = null;
            foreach(User oUser in UserList)
                if(oUser.Email==pEmail)
                {
                    return oUser;
                }
            return aux;
        }
    }
}
