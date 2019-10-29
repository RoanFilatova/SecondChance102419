using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class RoleMapper : Mapper
    {
        int OffsetToRoleID; //should be 0
        int OffsetToRoleName; //should be 1
       
        public RoleMapper(SqlDataReader reader)
        {
            OffsetToRoleID = reader.GetOrdinal("RoleID");
            Assert(0 == OffsetToRoleID, $"RoleID is {OffsetToRoleID} instead of 0 as anticipated.");
            OffsetToRoleName = reader.GetOrdinal("RoleName");
            Assert(1 == OffsetToRoleName, $"RoleName is {OffsetToRoleName} instead of 1 as anticipated.");
           
        }
        public RoleDAL ToRole(SqlDataReader reader)
        {
            RoleDAL proposedReturnValue = new RoleDAL
            {
                RoleID = reader.GetInt32(OffsetToRoleID),
                RoleName = reader.GetString(OffsetToRoleName),
                
            };
            return proposedReturnValue;
        }
    }
}
