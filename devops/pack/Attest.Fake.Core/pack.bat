cd contents
rmdir /Q /S lib
mkdir lib
cd lib
mkdir netstandard2.0\
robocopy ../../../../../src/Bin/netstandard/Release netstandard2.0 Attest.Fake.Core.* /E
cd ../../
nuget pack contents/Attest.Fake.Core.nuspec -OutputDirectory ../../../output