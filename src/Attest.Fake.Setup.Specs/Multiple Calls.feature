Feature: Multiple Calls
	In order to support different app scenarios
	As an app developer
	I want to make sure multiple calls case is supported

Scenario: Setting calls to return different result for different parameter values should work as expected
	Given Moq setup is used
	And There is a multiple calls setup with different results
	When The provider for multiple calls is created
	And The provider for multiple calls is invoked with the first id
	And The provider for multiple calls is invoked with the second id
	Then The provider calls should return different results for different ids
