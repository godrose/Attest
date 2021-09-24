cd contents
rmdir /Q /S lib
mkdir lib
cd lib
mkdir netstandard2.0\
robocopy ../../../../../src/Bin/netstandard/Release netstandard2.0 Attest.Fake.Conventions.* /E
cd ../../
nuget pack contents/Attest.Fake.Conventions.nuspec -OutputDirectory ../../../output