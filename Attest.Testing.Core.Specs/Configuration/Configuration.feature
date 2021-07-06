Feature: Configuration
	In order to support development with configuration
	As an app developer
	I want the framework to be able to resolve value by key

Scenario: Resolving simple value by an existing key should return value
	Given The configuration uses environment variable compatible key splitter
	And The configuration contains the key "key" mapped to value "value"
	When I get the value by this key
	Then The value is resolved successfully

Scenario: Resolving simple value by a non-existing key should return null
	Given The configuration uses environment variable compatible key splitter
	And The configuration does not contain the key "key"
	When I get the value by this key
	Then The value is returned as null