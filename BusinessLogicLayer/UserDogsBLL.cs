using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class UserDogsBLL
    {
        public int UserID { get; set; }
        public int DogID { get; set; }

        public UserDogsBLL(UserDogsDAL userDogs)
        {
            UserID = userDogs.UserID;
            DogID = userDogs.DogID;
        }

        public UserDogsBLL()
        {
            //default ctor
        }
    }
}
