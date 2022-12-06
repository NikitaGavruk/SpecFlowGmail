Feature: GmailMenu
	In order to mail usage
	As a specflow user
	I want to use gmail 
Background: 
	Given Login to mail

@smoke
Scenario: Navigate to page and verify title
	When Navigate to 'Drafts'
	Then Verify that 'Drafts' title is correct

@smoke
Scenario Outline: Send message from gmail main menu and verify it
	When Write mail to '<To>' with '<Subject>' subject and '<BodyMail>' bodyMail
	When Send mail
	When Navigate to Sent page
	Then Verfiy mail with '<Subject>' subject succesfully sent

	Examples: 
	| To                   | Subject | BodyMail |
	| gavruk1337@gmail.com | Hi!     | How are you! |
	| gavruk1337@gmail.com | Did not get answer     | Why you did not reply me? :( |