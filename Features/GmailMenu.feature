Feature: GmailMenu
	In order to mail usage
	As a specflow user
	I want to use gmail 

@smoke
Scenario: Navigate to page and verify title
	Given Login to mail
	When Navigate to 'Drafts'
	Then Verify that 'Drafts' title is correct
	And Log out

@smoke
Scenario Outline: Send message from gmail main menu and verify it
	Given Login to mail
	When Write mail to '<To>' with '<Subject>' subject and '<BodyMail>' bodyMail
	When Send mail
	Then Navigate to Sent page
	And Verfiy mail with '<Subject>' subject succesfully sent
	And Log out

	Examples: 
	| To                   | Subject | BodyMail |
	| gavruk1337@gmail.com | Hi!     | How are you! |
	| gavruk1337@gmail.com | Did not get answer     | Why you did not reply me? :( |