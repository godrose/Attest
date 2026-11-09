Feature: Using complex types in scenario data store
	As a spec implementation engineer
	I want seamless support for complex type
	In order to be able to implement more elaborate scenarios

Scenario: Using dictionary should not require any additional setup
	Given The scenario data store contains property with Dictionary type
	When I add an entry to this property
	Then No exception is thrown
	And The entry has been added to this property