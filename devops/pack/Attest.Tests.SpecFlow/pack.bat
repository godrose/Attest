cd contents
rmdir /Q /S lib
mkdir lib
cd lib
mkdir netstandard2.0\
robocopy ../../../../../src/Bin/netstandard/Release netstandard2.0 Attest.Testing.SpecFlow.* /E
cd ../../
nuget pack contents/Attest.Tests.SpecFlow.nuspec -OutputDirectory ../../../output