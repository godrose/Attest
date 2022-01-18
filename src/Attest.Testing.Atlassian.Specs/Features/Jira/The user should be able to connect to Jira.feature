@BDD-1
Feature: The user should be able to connect to Jira

In order to see clearer picture
As a stakeholder
I would like an option to filter issues easily

@BDD-1
Scenario: The user should be able to find out whether ticket belongs to the current sprint
	Given There is an Atlassian account
	And There is a ticket with id 1 which belongs to the current sprint
	When The user wants to find out whether this ticket belongs to the current sprint
	Then The result is positive
