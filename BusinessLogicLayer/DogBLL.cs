using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class DogBLL
    {
        public int DogID { get; set; }
        public string Name { get; set; }
        public int BreedID { get; set; }
        public bool IsSmallBreed { get; set; }
        public bool IsDogHairless { get; set; }
        public string Medical { get; set; }
        public DateTime AdoptDate { get; set; }
        public DateTime SurrenderDate { get; set; }
        
        public DogBLL (DataAccessLayer.DogDAL dog)
        {
            DogID = dog.DogID;
            Name = dog.Name;
            BreedID = dog.BreedID;
            IsSmallBreed = dog.IsSmallBreed;
            IsDogHairless = dog.IsDogHairless;
            Medical = dog.Medical;
            AdoptDate = dog.AdoptDate;
            SurrenderDate = dog.SurrenderDate;
        }
        public DogBLL()
        {
            //default ctor
        }

    }
}
