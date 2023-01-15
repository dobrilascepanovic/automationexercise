Feature: Authentication
	As a user
	I wont to be able to autnenticate to the app
	So I can work with restricted web app content

@mytag
Scenario: User can log in
	Given user opens sing in page
	And enters correct credentials
	When user submits login form
	Then user will be logged in

	Scenario: User can sing up
	Given user opens sing in page
		And enters'Dobrila'name and valid email addres
		And user clicks on SingnUp button
	When user fills in all requires fields
		And submits the signup form
	Then user will get 'Account Created!' success message
		And user will be logged in

Scenario: User can delete their account
      Given user reregisters new account with 'Dobrila' name
	  When user selects option for deleting the account
	  Then account will be deleted with 'Account Deleted!' message
		

