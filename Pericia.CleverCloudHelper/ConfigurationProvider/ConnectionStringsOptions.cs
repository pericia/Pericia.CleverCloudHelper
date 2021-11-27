using System;
using System.Collections.Generic;
using System.Text;

namespace Pericia.CleverCloudHelper
{
    public class ConnectionStringsOptions
    {
        public string PostgreSqlKey { get; set; } = "ConnectionStrings:PostgreSql";
        public string MySqlKey { get; set; } = "ConnectionStrings:MySql";
    }
}
