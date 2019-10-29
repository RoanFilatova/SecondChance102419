using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserDAL
    {
        #region columns from primary table
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
        public int RoleID { get; set; }

        
        #endregion

        public override string ToString()
        {
            return $"UserID:{UserID, 0}, UserName:{UserName,0},Name{Name,0}, Address{Address,0},Email{Email,0}, Hash{Hash,0}, Salt{Salt,0} RoleID{RoleID,0}";
        }
    }
}
