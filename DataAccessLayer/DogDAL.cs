using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DogDAL
    {
        #region Primary Columns
        public int DogID { get; set; }
        public string Name { get; set; }
        public int BreedID { get; set; } //Foreign Key relation
        public bool IsSmallBreed { get; set; }
        public bool IsDogHairless { get; set; }
        public string Medical { get; set; }
        public DateTime AdoptDate { get; set; }
        public DateTime SurrenderDate { get; set; }

        #endregion

        
        public override string ToString()
        {
            return $"DogID{DogID,0}, Name{Name,0}, BreedID{BreedID,0}, IsSmallBreed{IsSmallBreed,0}, IsDogHairless{IsDogHairless,0},Medical{Medical,0},AdoptDate{AdoptDate,0000-00-00} SurrenderDate{SurrenderDate,0000-00-00}";
        }

    }
}
