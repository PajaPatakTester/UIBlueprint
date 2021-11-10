Feature: Search
	As end user I want to
	Input search term and see list of suggested categories that are realted to my search

Scenario: User see a list of suggested categories
	Given User land on home page
	When He perform search for term 'Audio'
	Then He should see the list of suggested categories

Scenario: User see a list of adequate suggested categories
	Given User land on home page
	When He perform search for listed companies
	Then He should see adequate category:
		| company | category         |
		| Samsung | Mobilni telefoni |
		| Lada    | Automobili       |
		| Marantz | Audio            |