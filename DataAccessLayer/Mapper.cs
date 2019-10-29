using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Mapper
    {
        public void Assert(bool condition, string message)
        {
            if (condition)
            {
                //nothing should happen here. Theoretically.
            }
            else
            {
                throw new Exception(message);
            }
        }
    }
}
