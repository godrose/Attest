@BDD-
Feature: The user should be able to update issue description automatically

In order to have single source of truth
As a product owner 
I would like to have the ability to sync between feature files and the correspondent issue description

@BDD-2
Scenario: The system can update issue description automatically from the correspondent feature files
	Given There is an Atlassian account
	And There is an issue with id 1 with specs section
	When I update the user story description from the correspondent feature files
	Then The user story description is updated
