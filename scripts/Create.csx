#! "netcoreapp2.1"

#r "nuget:Portable.Licensing,1.1.0"
#r "nuget:FSharp.Core,4.5.4"
#r "nuget:EasyMachine,1.1.0"

using System;
using Portable.Licensing.Validation;
using System.IO;
using Portable.Licensing;

var privateKey = File.ReadAllText(".private");

var mac = EasyMachine.MachineService.GetComputerUuid();

var license = License.New()
    .WithUniqueIdentifier(Guid.NewGuid())
    .As(LicenseType.Standard)
    .ExpiresAt(DateTime.Now.AddYears(1))
    .WithMaximumUtilization(1)
    .WithProductFeatures(new Dictionary<string, string> {
        { "Machine", mac }
    })
    .LicensedTo("Customer", "customer@gmail.com")
    .CreateAndSignWithPrivateKey(privateKey, "!@#$%^&*()_+");

File.WriteAllText(".license", license.ToString(), Encoding.UTF8);

