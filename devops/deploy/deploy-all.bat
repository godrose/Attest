rem TODO: Use common source for all version instances
SET version=2.2.2
rem TODO: Refactor using loop and automatic discovery
call deploy-single.bat Attest.Fake.Builders %version% 
call deploy-single.bat Attest.Fake.Conventions %version% 
call deploy-single.bat Attest.Fake.Core %version% 
call deploy-single.bat Attest.Fake.Data %version% 
call deploy-single.bat Attest.Fake.LightMock %version% 
call deploy-single.bat Attest.Fake.Moq %version% 
call deploy-single.bat Attest.Fake.Registration %version% 
call deploy-single.bat Attest.Fake.Setup %version% 
call deploy-single.bat Attest.Testing.Contracts %version% 
call deploy-single.bat Attest.Tests.Core %version% 
call deploy-single.bat Attest.Tests.NUnit %version% 
call deploy-single.bat Attest.Tests.SpecFlow %version% 
call deploy-single.bat Attest.Tests.xUnit %version%