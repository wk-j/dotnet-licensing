#! "netcoreapp2.1"

#r "nuget:Portable.Licensing,1.1.0"
#r "nuget:FSharp.Core,4.5.4"
#r "nuget:EasyMachine,1.1.0"

using System;
using Portable.Licensing;
using System.IO;
using Portable.Licensing.Validation;

var key = File.ReadAllText(".public");
var mac = EasyMachine.MachineService.GetComputerUuid();

var license = License.Load(File.ReadAllText(".license"));
license.ProductFeatures.Remove("Machine");
license.ProductFeatures.Add("Machine", mac);

var failures = license.Validate()
    .ExpirationDate()
    .And()
    .Signature(key)
    .AssertValidLicense();

foreach (var item in failures) {
    Console.WriteLine(item.Message);
}