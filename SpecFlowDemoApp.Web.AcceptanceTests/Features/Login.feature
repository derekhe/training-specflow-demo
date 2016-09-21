Feature: Login

Scenario: Logging in with valid credentials
Given I am at the 'Login' page
When I fill in the following form
| field    | value    |
| Username | testuser |
| Password | testpass |
And I click the 'Login' button
Then I should be at the 'Home' page

Scenario: Logging in with invlaid credentials
Given I am at the 'Login' page
When I fill in the following form
| field    | value    |
| Username | testuser |
| Password | badpassword |
And I click the 'Login' button
Then I should be at the 'Login' page