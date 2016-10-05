using System;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;

using DataAccess;

namespace MainApplication
{
    class Program
    {
        static void ReadSomeSQLDataViaEntityFramework(SchoolEntities entities)
        {
            foreach (UserType userType in entities.UserTypes)
            {
                Console.WriteLine("User type: " + userType.UserTypeName);
            }
        }

        private const string _adoConnectionName = "MainApplication.Properties.Settings.SchoolEntities";

        private const string _entityFrameworkConnectionName = "SchoolEntities";

        static void Main(string[] args)
        {
            ConnectionStringSettingsCollection connectionStrings = ConfigurationManager.ConnectionStrings;

            using (SchoolEntities entities =
                SchoolEntities.CreateWithEntityFrameworkConfgurationConnectionName(
                    _entityFrameworkConnectionName))
            {
                ReadSomeSQLDataViaEntityFramework(entities);
            }

            using (SchoolEntities entities =
                SchoolEntities.CreateWithEntityFrameworkConnectionString(
                    connectionStrings[_entityFrameworkConnectionName].ConnectionString))
            {
                ReadSomeSQLDataViaEntityFramework(entities);
            }

            using (SchoolEntities entities =
                SchoolEntities.CreateWithADOConfigurationConnectionName(
                    _adoConnectionName))
            {
                ReadSomeSQLDataViaEntityFramework(entities);
            }

            using (SchoolEntities entities =
                SchoolEntities.CreateWithADOConnectionString(
                    connectionStrings[_adoConnectionName].ConnectionString))
            {
                ReadSomeSQLDataViaEntityFramework(entities);
            }
        }
    }
}
