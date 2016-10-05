using System;
using System.Data.Entity;
using System.Configuration;

namespace DataAccess
{
    public partial class SchoolEntities : DbContext
    {
        private const string _entityFrameworWrapper =
            "metadata=res://*/School.csdl|res://*/School.ssdl|res://*/School.msl;provider=System.Data.SqlClient;provider connection string=\"{0};App=EntityFramework\"";

        private SchoolEntities(string efConnectionNameorEFConnectionString) : base(efConnectionNameorEFConnectionString)
        {           
        }

        public static SchoolEntities CreateWithADOConnectionString(string adoConnectionString)
        {
            string entityFrameworkConnectionString = String.Format(_entityFrameworWrapper, adoConnectionString);

            return new SchoolEntities(entityFrameworkConnectionString);
        }

        public static SchoolEntities CreateWithEntityFrameworkConnectionString(string efConnectionString)
        {
            return new SchoolEntities(efConnectionString);
        }

        public static SchoolEntities CreateWithADOConfigurationConnectionName(string adoConnectionName)
        {
            string adoConnectionString = ConfigurationManager.ConnectionStrings[adoConnectionName].ConnectionString;

            return CreateWithADOConnectionString(adoConnectionString);
        }

        public static SchoolEntities CreateWithEntityFrameworkConfgurationConnectionName(string efConnectionName)
        {
            return new SchoolEntities(efConnectionName);
        }
    }
}

