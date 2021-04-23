cd contents
rmdir /Q /S lib
mkdir lib
cd lib
mkdir netstandard2.0\
robocopy ../../../../../Bin/netstandard/Release netstandard2.0 Attest.Fake.Moq.* /E
cd ../../
nuget pack contents/Attest.Fake.Moq.nuspec -OutputDirectory ../../../output