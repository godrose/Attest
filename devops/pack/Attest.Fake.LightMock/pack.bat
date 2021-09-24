cd contents
rmdir /Q /S lib
mkdir lib
cd lib
mkdir netstandard2.0\
robocopy ../../../../../src/Bin/netstandard/Release netstandard2.0 Attest.Fake.LightMock.* /E
robocopy ../../../../../src/Bin/netstandard/Release netstandard2.0 LightMock.* /E
cd ../../
nuget pack contents/Attest.Fake.LightMock.nuspec -OutputDirectory ../../../output