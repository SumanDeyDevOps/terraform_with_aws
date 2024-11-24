using System;
using Constructs;
using HashiCorp.Cdktf;

using HashiCorp.Cdktf.Providers.Aws.Provider;
using HashiCorp.Cdktf.Providers.Aws.Instance;

namespace MyCompany.MyApp
{
    class MainStack : TerraformStack
    {
        public MainStack(Construct scope, string id) : base(scope, id)
        {
            new AwsProvider(this, "AWS", new AwsProviderConfig { Region = "eu-west-1" });

            Instance instance = new Instance(this, "compute", new InstanceConfig
            {
                Ami = "ami-02141377eee7defb9",
                InstanceType = "t2.micro",
            });

            new TerraformOutput(this, "public_ip", new TerraformOutputConfig
            {
                Value = instance.PublicIp
            });
        }
    }
}