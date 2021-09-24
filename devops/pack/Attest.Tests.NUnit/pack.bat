cd contents
rmdir /Q /S lib
mkdir lib
cd lib
mkdir netstandard2.0\
robocopy ../../../../../src/Bin/netstandard/Release netstandard2.0 Attest.Testing.NUnit.* /E
cd ../../
nuget pack contents/Attest.Tests.NUnit.nuspec -OutputDirectory ../../../output