﻿Feature: Event Invocation
	In order to test my app for different scenarios
	As an app developer
	I want to be able to simulate events invocation

Background: 
	Given Moq setup is used	

Scenario: Simulating an event invocation should raise correspondent event
	Given The Arrived event is to be tested
	When I simulate Arrived event
	Then The event arguments should pass as expected

Scenario: Simulating a data event invocation should raise correspondent event
	Given The Data Arrived event is to be tested
	When I simulate Data Arrived event
	Then The data event arguments should pass as expected

Scenario: Simulating a custom event invocation should raise correspondent event
	Given The Custom event is to be tested
	When I simulate Custom event
	Then The custom event arguments should pass as expected
