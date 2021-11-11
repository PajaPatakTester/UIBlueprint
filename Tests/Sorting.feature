Feature: Sorting
	As end user I want to
	Sort search term based on selected criterium

Scenario: Search term sorted based on price starting from highest
	Given User land on home page
	And He search for term 'Marantz'
	When He select sorting criteria 'Skuplje'
	Then The results on first page should be the list of products sorted by price starting from highest

	Scenario: Test that should present fail scenario
	Given User land on home page
	And He search for term 'Marantz'
	When He select sorting criteria 'Jeftinije'
	Then The results on first page should be the list of products sorted by price starting from highest