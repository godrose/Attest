cd contents
rmdir /Q /S lib
mkdir lib
cd lib
mkdir netstandard2.0\
robocopy ../../../../../src/Bin/netstandard/Release netstandard2.0 Attest.Testing.Core.* /E
cd ../../
nuget pack contents/Attest.Tests.Core.nuspec -OutputDirectory ../../../output