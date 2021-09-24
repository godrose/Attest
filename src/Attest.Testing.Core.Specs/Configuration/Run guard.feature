Feature: Run guard
	In order to be able to optionally exclude certain scenarios
	As an app developer
	I want the framework to resolve the correspondent value from the configuration

Scenario: Having run flag set to truthy value should allow running scenarios
	Given The configuration uses environment variable compatible key splitter
	And The run guard info is defined with key "key" and can run for value 1
	And The configuration contains the key "key" mapped to value "1"
	#TODO: Think about formulation
	When I check whether scenarios can be run
	Then The scenarios can be run

Scenario: Having run flag set to non-truthy value should disallow running scenarios
	Given The configuration uses environment variable compatible key splitter
	And The run guard info is defined with key "key" and can run for value 1
	And The configuration contains the key "key" mapped to value "0"
	#TODO: Think about formulation
	When I check whether scenarios can be run
	Then The scenarios cannot be run

Scenario: Having run flag not set to any value should disallow running scenarios
	Given The configuration uses environment variable compatible key splitter
	And The run guard info is defined with key "key" and can run for value 1
	And The configuration does not contain the key "key"
	#TODO: Think about formulation
	When I check whether scenarios can be run
	Then The scenarios cannot be run