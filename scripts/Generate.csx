#! "netcoreapp2.1"

#r "nuget:Portable.Licensing,1.1.0"

using System;
using Portable.Licensing;
using System.IO;


var keyGenerator = Portable.Licensing.Security.Cryptography.KeyGenerator.Create();
var keyPair = keyGenerator.GenerateKeyPair();
var privateKey = keyPair.ToEncryptedPrivateKeyString("!@#$%^&*()_+");
var publicKey = keyPair.ToPublicKeyString();

File.WriteAllText(".public", publicKey);
File.WriteAllText(".private", privateKey);