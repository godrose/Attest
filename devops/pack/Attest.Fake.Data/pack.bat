cd contents
rmdir /Q /S lib
mkdir lib
cd lib
mkdir netstandard2.0\
robocopy ../../../../../Bin/netstandard/Release netstandard2.0 Attest.Fake.Data.* /E
cd ../../
nuget pack contents/Attest.Fake.Data.nuspec -OutputDirectory ../../../output