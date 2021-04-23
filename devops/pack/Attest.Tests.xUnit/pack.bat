cd contents
rmdir /Q /S lib
mkdir lib
cd lib
mkdir netstandard2.0\
robocopy ../../../../../Bin/netstandard/Release netstandard2.0 Attest.Testing.xUnit.* /E
cd ../../
nuget pack contents/Attest.Tests.xUnit.nuspec -OutputDirectory ../../../output