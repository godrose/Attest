@BDD-1
Feature: The user should be able to connect to Confluence

In order to see the last project status
As a stakeholder
I would like the system to update the status automtically based on automated execution report

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
