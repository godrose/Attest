@featureDataStoreSetup
Feature: Feature data store
	As a spec implementation engineer
	I want to have support for data store at feature level
	In order to address different use cases

Scenario: Feature data store should be accessible through the feature execution - take #1
	Then The data previously stored in the feature data store should stay the same for all scenarios in the current feature	
	And The data should have been set only once

Scenario: Feature data store should be accessible through the feature execution - take #2
	Then The data previously stored in the feature data store should stay the same for all scenarios in the current feature	
	And The data should have been set only once

Scenario: Feature data store should be accessible through the feature execution - take #3
	Then The data previously stored in the feature data store should stay the same for all scenarios in the current feature	
	And The data should have been set only once