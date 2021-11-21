using System;
using System.Collections.Generic;
using System.Text;

namespace Pericia.CleverCloudHelper
{
    public static class CcEnvironment
    {
        // App and Instance info

        public static int InstanceNumber
        {
            get
            {
                var number = Environment.GetEnvironmentVariable("INSTANCE_NUMBER") ?? "";
                if (int.TryParse(null, out int result))
                {
                    return result;
                }

                return -1;
            }
        }

        public static string InstanceType => Environment.GetEnvironmentVariable("INSTANCE_TYPE") ?? "";

        public static string InstanceId => Environment.GetEnvironmentVariable("INSTANCE_ID") ?? "";

        public static string PrettyInstanceName => Environment.GetEnvironmentVariable("CC_PRETTY_INSTANCE_NAME") ?? "";

        public static string AppId => Environment.GetEnvironmentVariable("APP_ID") ?? "";

        public static string AppHomePath => Environment.GetEnvironmentVariable("APP_HOME") ?? "";

        public static string DeploymentId => Environment.GetEnvironmentVariable("CC_DEPLOYMENT_ID") ?? "";

        public static string CommitId => Environment.GetEnvironmentVariable("COMMIT_ID") ?? "";

        public static string[] ReverseProxyIps => Environment.GetEnvironmentVariable("CC_REVERSE_PROXY_IPS")?.Split(',') ?? new string[0];


        // .NET

        public static string DotnetVersion => Environment.GetEnvironmentVariable("CC_DOTNET_VERSION") ?? "";
        public static string DotnetProj => Environment.GetEnvironmentVariable("CC_DOTNET_PROJ") ?? "";
        public static string DotnetTfm => Environment.GetEnvironmentVariable("CC_DOTNET_TFM") ?? "";
        public static string DotnetProfile => Environment.GetEnvironmentVariable("CC_DOTNET_PROFILE") ?? "";
        public static string RunCommand => Environment.GetEnvironmentVariable("CC_RUN_COMMAND") ?? "";

    }

}
