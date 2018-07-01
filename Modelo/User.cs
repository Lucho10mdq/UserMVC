using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class User
    {
        private int id;
        private string name;
        private string lastName;
        private string password;
        private string email;
        private int LevelAccess;
        private DateTime creationTime;
        private DateTime accessLast;

        public User(string pName, string pLastName, string pPassword, string pEmail, int pLevelAccess, DateTime pCreationTime, DateTime pAccessLast)
        {
            
            name = pName;
            lastName = pLastName;
            password = pPassword;
            email = pEmail;
            LevelAccess = pLevelAccess;
            creationTime = pCreationTime;
            accessLast = pAccessLast;
        }

        public string Name
            {
                get
                {
                    return name;
                }

                set
                {
                    name = value;
                }
            }

            public string LastName
            {
                get
                {
                    return lastName;
                }

                set
                {
                    lastName = value;
                }
            }

            public string Password
            {
                get
                {
                    return password;
                }

                set
                {
                    password = value;
                }
            }

            public string Email
            {
                get
                {
                    return email;
                }

                set
                {
                    email = value;
                }
            }

            public int LevelAccess1
            {
                get
                {
                    return LevelAccess;
                }

                set
                {
                    LevelAccess = value;
                }
            }

            public DateTime CreationTime
            {
                get
                {
                    return creationTime;
                }

                set
                {
                    creationTime = value;
                }
            }

            public DateTime AccessLast
            {
                get
                {
                    return accessLast;
                }
                set
                {
                    accessLast = value;
                }
            }
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
    }
    }

