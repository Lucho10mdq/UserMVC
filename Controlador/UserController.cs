using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
   public  class UserController
    {
        private RepositorioUserBD UserList = RepositorioUserBD.GetInstance();

       public bool UserAdd(string pName, string pLastName,string pPass,string pEmail,int pLevelAccess,DateTime pCreation,DateTime AccesLast)
        {
            var result = false;

            User oUser = new User(pName, pLastName, pPass,pEmail, pLevelAccess, pCreation, AccesLast);

            if(UserList.BuscarPorMails(pEmail)==null)
             {
                 UserList.Agregar(oUser);
                 result = true;
             }
            return result;
        }

        public int BorrarUsuario(string email)
        {
            var result = 0;
            return result= UserList.EliminarPorEmail(email);
        }
        public List<User> ReturnAll()
        {
            return UserList.DevolverTodos();
        }

        public List<User>ReturnUsuariosPorApellido(string lastname)
        {
            return UserList.BuscarUsuarioPorApellido(lastname);
        }
    }
}
