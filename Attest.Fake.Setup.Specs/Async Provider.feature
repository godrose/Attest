Feature: Async Provider
	In order to support asyncronous data flow
	As an app developer
	I want to be able to setup asynchronous data providers

Background: 
	Given Moq setup is used	

Scenario: Setting up method with no parameters and return value should return correct value
	Given There is provider builder with a collection of items
	When The provider for return value case is created
	And The provider is passed no parameters and asked to return a collection of items
	Then The returned collection should be identical to the original one

Scenario: Setting up method with one parameter and return value should return correct value
	Given There is provider builder with a collection of items
	When The provider for return value case is created
	And The provider is passed one parameter and asked to return a collection of items
	Then The returned collection should be identical to the original one

Scenario: Setting up method with two parameters and return value should return correct value
	Given There is provider builder with a collection of items
	When The provider for return value case is created
	And The provider is passed two parameters and asked to return a collection of items
	Then The returned collection should be identical to the original one

Scenario: Setting up method with three parameters and return value should return correct value
	Given There is provider builder with a collection of items
	When The provider for return value case is created
	And The provider is passed three parameters and asked to return a collection of items
	Then The returned collection should be identical to the original one

	Scenario: Setting up method with four parameters and return value should return correct value
	Given There is provider builder with a collection of items
	When The provider for return value case is created
	And The provider is passed four parameters and asked to return a collection of items
	Then The returned collection should be identical to the original one

Scenario: Setting up method with five parameters and return value should return correct value
	Given There is provider builder with a collection of items
	When The provider for return value case is created
	And The provider is passed five parameters and asked to return a collection of items
	Then The returned collection should be identical to the original one

Scenario: Setting up method with no parameters and no return value should execute expected functionality
	Given There is provider builder with expected functionality
	When The provider for no return value case is created
	And The provider is passed no parameters and asked to execute specific functionality
	Then The actual functionality is executed as expected

Scenario: Setting up method with one parameter and no return value should execute expected functionality
	Given There is provider builder with expected functionality
	When The provider for no return value case is created
	And The provider is passed one parameter and asked to execute specific functionality
	Then The actual functionality is executed as expected

Scenario: Setting up method with two parameters and no return value should execute expected functionality
	Given There is provider builder with expected functionality
	When The provider for no return value case is created
	And The provider is passed two parameters and asked to execute specific functionality
	Then The actual functionality is executed as expected

Scenario: Setting up method with three parameters and no return value should execute expected functionality
	Given There is provider builder with expected functionality
	When The provider for no return value case is created
	And The provider is passed three parameters and asked to execute specific functionality
	Then The actual functionality is executed as expected

Scenario: Setting up method with four parameters and no return value should execute expected functionality
	Given There is provider builder with expected functionality
	When The provider for no return value case is created
	And The provider is passed four parameters and asked to execute specific functionality
	Then The actual functionality is executed as expected

Scenario: Setting up method with five parameters and no return value should execute expected functionality
	Given There is provider builder with expected functionality
	When The provider for no return value case is created
	And The provider is passed five parameters and asked to execute specific functionality
	Then The actual functionality is executed as expected
