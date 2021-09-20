Feature: ExtraTaskTests
	As an User 
	I want to be able to mark favorite news
	So that I could list all my favorite news


Scenario: Saved favorite news are correctly shown in the favorites tab
	Given User skips tutorial
	When The user goes to news source 'ABC News'
	And Saves first article as a favorite
	Then Favorite tab has the same article