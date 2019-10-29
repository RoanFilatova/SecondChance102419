using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class BreedBLL
    {
        public int BreedID { get; set; }
        public string BreedName { get; set; }

        public BreedBLL (BreedDAL breed)
        {
            BreedID = breed.BreedID;
            BreedName = breed.BreedName;
        }
        public BreedBLL()
        {
            //default ctor
        }
    }
}
