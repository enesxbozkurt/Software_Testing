Feature: Example Scenario
  Background:
    Given settingDriver

  Scenario Outline: Go to website and login test
    Given go to login page
    And type username "<username>"
    And type password "<password>"
    When click button
    Then assert to success message
    Examples:
      | username | password |
      | student | Password123 |

  Scenario: homepage loading test
    Given go to homepage
    When wait two seconds
    Then see "Hello" text
