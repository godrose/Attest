Feature: The user should be able to connect to Confluence

A short summary of the feature

@BDD-1
Scenario: The user should be able to get a Confluence page version
	Given There is an Atlassian account
	And There is a page which holds the current status content
	When I get the page
	Then I am able to see the version number

@BDD-1
Scenario: The user should be able to update current status
	Given There is an Atlassian account
	And There is a page which holds the current status content
	When I update the current status
	Then The status is updated
