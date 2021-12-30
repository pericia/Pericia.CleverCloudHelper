using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pericia.CleverCloudHelper
{
    internal class CleverCloudEnvironmentConfigurationSource : IConfigurationSource
    {
        private readonly EnvironmentOptions environmentOptions;

        public CleverCloudEnvironmentConfigurationSource(EnvironmentOptions environmentOptions)
        {
            this.environmentOptions = environmentOptions;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new CleverCloudEnvironmentConfigurationProvider(environmentOptions);
        }
    }

}
