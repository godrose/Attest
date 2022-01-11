@echo off
echo Executing Scenarios
dotnet test .\Attest.Testing.Atlassian.Specs\Attest.Testing.Atlassian.Specs.csproj
copy .\Attest.Testing.Atlassian.Specs\bin\Debug\TestExecution.json .\TestExecution.json
echo Creating Living Documentation
livingdoc test-assembly .\Attest.Testing.Atlassian.Specs\bin\Debug\Attest.Testing.Atlassian.Specs.dll --output-type JSON --output "FeatureData.json"
echo Updating the Report page
dotnet run --project .\ReportParserToJira\ReportParserToJira.csproj
pause