cd contents
rmdir /Q /S lib
mkdir lib
cd lib
mkdir netstandard2.0\
robocopy ../../../../../src/Bin/netstandard/Release netstandard2.0 Attest.Fake.Registration.dll /E
robocopy ../../../../../src/Bin/netstandard/Release netstandard2.0 Attest.Fake.Registration.xml /E
robocopy ../../../../../src/Bin/netstandard/Release netstandard2.0 Attest.Fake.Registration.deps.json /E
cd ../../
nuget pack contents/Attest.Fake.Registration.nuspec -OutputDirectory ../../../output