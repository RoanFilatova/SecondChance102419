using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserDogsDAL
    {
        public int UserID { get; set; }
        public int DogID { get; set; }

        public override string ToString()
        {
            return $"UserID:{UserID, 0}, DogID:{DogID,0}";
        }
    }
}
