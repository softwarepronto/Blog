using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using DataAccess;

namespace MainApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SchoolEntities entities = new SchoolEntities())
            {
                foreach (UserType userType in entities.UserTypes)
                {
                }
            }
        }
    }
}
