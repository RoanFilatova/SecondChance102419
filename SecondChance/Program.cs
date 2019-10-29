﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace SecondChance
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ContextDAL ctx = new ContextDAL())
            {
                ctx.ConnectionString = "Data Source =.\\sqlexpress; Initial Catalog = SecondChance; Integrated Security = True";
            }
                
        }
    }
}
