using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pericia.CleverCloudHelper
{
    internal class CleverCloudConnectionStringsConfigurationSource : IConfigurationSource
    {
        private readonly ConnectionStringsOptions connectionStringsNames;

        public CleverCloudConnectionStringsConfigurationSource(ConnectionStringsOptions connectionStringsNames)
        {
            this.connectionStringsNames = connectionStringsNames;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new CleverCloudConnectionStringsConfigurationProvider(connectionStringsNames);
        }
    }

}
