Feature: Serialization
	In order to test different data-related scenarios in my app
	As an app developer
	I want to make sure data is serialized correctly

Background: 
	Given The system runs in .NETStandard environment
	And Moq setup is used

Scenario: Serializing and deserializing a collection of items should not affect its contents
	Given The collection of items is created
	When The items are added to the current context
	And The current context is serialized
	And The current context is deserialized
	Then The collection of items inside the current context is identical to the original one

Scenario: Serializing and deserializing multiple builders should not affect their contents
	Given The collection of items is created
	And The single item is created
	When The items are added to the current context
	And The single item is added to the current context
	And The current context is serialized
	And The current context is deserialized
	Then The collection of items inside the current context is identical to the original one
	And The item inside the current context is identical to the original one

Scenario: Serializing and deserializing an inherited object should not affect its contents
	Given The inherited object is created
	When The inherited object is added to the current context
	And The current context is serialized
	And The current context is deserialized
	Then The inherited object inside the current context is identical to the original one
