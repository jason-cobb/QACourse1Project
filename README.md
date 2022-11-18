# New Feature Test Plan with Test Cases
## Papa Johns: New Papa Bowls
## Jason Cobb 
## Report Date:  11/01/2022

## Description
The newly added feature is a new offering for Papa Bowls on the Pizza Company website. 
There is a link to this menu item from the promotion on the home page, as well as from the menu and specials pages.

We are testing the Papa Bowls page. It has been newly created in the launch of this new Menu Item with 3 offerings as well as a Create Your Own option. 
### Four Options are:
- Italian Meats Trio Bowl
- Garden Veggie Papa Bowl
- Chicken Alfredo Bowl
- Create Your Own Papa Bowl

## Assumptions: 
- You are able to gain access to Papa Johns Website Homepage at https://www.papajohns.com/
- Navigate to the Papa Bowls page: https://www.papajohns.com/order/dealbuilder?dealId=33605 or from a homepage link to Papa Bowls

------
# Test Cases: PB1 to PB 13

Case ID - PB1
- Date- 10/8/22 
- Test Type - Critical Path
- Preconditions: Get to the Papa Bowls page: https://www.papajohns.com/order/dealbuilder?dealId=33605 or from a homepage link to Papa Bowls
- Test Steps: Click the Italian Meats Trio Bowl - Add To Cart button
- Expected Results: Bowl is added to the cart
- Post Conditions: Pop up has appeared for additional item offerings
- Actual test result: Bowl is added to the cart
- Pass/Fail : Pass


Case ID - PB2
- Date- 10/8/22
- Test Type - Critical Path
- Preconditions - Get to the Papa Bowls page: https://www.papajohns.com/order/dealbuilder?dealId=33605 or from a homepage link to Papa Bowls
- Test Steps: Click the Italian Meats Trio Bowl - Customize button
- Expected Results: Customize page pops up
- Post Conditions: Pop up has appeared to customize the bowl with Base, Cheese, Meats, Veggies options
- Actual test result: Pop up customizer appears with Add To Deal, and Cancel buttons
- Pass/Fail : Pass

Case ID - PB3
- Date - 10/8/2022
- Test Type - Critical Path
- Preconditions - Get to the Papa Bowls page: https://www.papajohns.com/order/dealbuilder?dealId=33605 or from a homepage link to Papa Bowls
- Test Steps: Click the Garden Veggie Papa Bowl  Add To Cart  button
- Expected Results: Bowl is added to the cart
- Post Conditions: Pop up has appeared for additional item offerings
- Actual test result: Bowl is added to the cart
- Pass/Fail : Pass

Case ID - PB4
- Date- 10/8/22
- Test Type - Critical Path
- Preconditions - Get to the Papa Bowls page: https://www.papajohns.com/order/dealbuilder?dealId=33605 or from a homepage link to Papa Bowls
- Test Steps: Click the Garden Veggie Bowl - Customize button
- Expected Results: Customize page pops up
- Post Conditions: Pop up has appeared to customize the bowl with Base, Cheese, Meats, Veggies options
- Actual test result: Pop up customizer appears with Add To Deal, and Cancel buttons
- Pass/Fail : Pass

Case ID - PB5
- Date - 10/8/2022
- Test Type - Critical Path
- Preconditions - Get to the Papa Bowls page: https://www.papajohns.com/order/dealbuilder?dealId=33605 or from a homepage link to Papa Bowls
- Test Steps: Click the Chicken Alfredo Papa Bowl Add To Cart button
- Expected Results: Bowl is added to the cart
- Post Conditions: Pop up has appeared for additional item offerings
- Actual test result: Bowl is added to the cart
- Pass/Fail : Pass

Case ID - PB6
- Date- 10/8/22
- Test Type - Critical Path
- Preconditions - Get to the Papa Bowls page: https://www.papajohns.com/order/dealbuilder?dealId=33605 or from a homepage link to Papa Bowls
- Test Steps: Click the Chicken Alfredo Bowl - Customize button
- Expected Results: Customize page pops up
- Post Conditions: Pop up has appeared to customize the bowl with Base, Cheese, Meats, Veggies options
- Actual test result: Pop up customizer appears with Add To Deal, and Cancel buttons
- Pass/Fail : Pass


Case ID - PB7
- Date- 10/8/22
- Test Type - Critical Path
- Preconditions - Get to the Papa Bowls page: https://www.papajohns.com/order/dealbuilder?dealId=33605 or from a homepage link to Papa Bowls
- Test Steps: Click the Create Your Own Papa Bowl Add and Customize Button
- Expected Results: Customize page pops up
- Post Conditions: Pop up has appeared to customize the bowl with Base, Cheese, Meats, and Veggies options
- Actual test result: Pop up customizer appears 
- Pass/Fail : Pass


Case ID - PB8
- Date- 10/8/22
- Test Type - Critical Path
- Preconditions - Get to the Papa Johns homepage.
https://www.papajohns.com
- Test Steps: Scroll down to the Try New Papa Bowls rectangle and click Order Now or the bowl picture
- Expected Results: Link taken to the Papa Bowls order page
- Post Conditions: Taken to the Papa Bowls order page
- Actual test result: Taken to the Papa Bowls order page
- Pass/Fail : Pass

Case ID - PB9
- Date- 10/8/22
- Test Type - Critical Path
- Preconditions - Get to the Papa Johns Menu page
https://www.papajohns.com/order/menu or from a homepage link to Menu
- Test Steps: Choose Papa Bowls from one of the eight features across the top of the menu page, click on it
- Expected Results: Link taken to the Papa Bowls order page
- Post Conditions: Taken to the Papa Bowls order page
- Actual test result: Taken to the Papa Bowls order page
- Pass/Fail : Pass

Case ID - PB10
- Date- 10/8/22
- Test Type - Critical Path
- Preconditions - Get to the Papa Johns Specials page
https://www.papajohns.com/order/specials or from a homepage link to Specials
- Test Steps: Scroll down to the second option which is the Try Papa Bowls option, click Order Now or the picture.
- Expected Results: Link taken to the Papa Bowls order page
- Post Conditions: Taken to the Papa Bowls order page for only the Order Now button
- Actual test result: Taken to the Papa Bowls order page for the Order Now button but not for the picture
- Pass/Fail : **FAIL**
- Notes: Hyperlink needs to be added to the picture on the Specials page as it is on the Menu page


Case ID - PB11
- Date- 10/8/22
- Test Type - Regression - Test previous functionality of most popular order items from page where new link was added for the new Papa Bowl item
- Preconditions - Get to the Papa Johns Menu page
https://www.papajohns.com/order/menu
- Test Steps: Find "Create Your Own Pizza" Section from the options.
Six Different Crust Options are available in scrollable Boxes : Find Original Crust Rectangle, Click the Customize Button
- Expected Results: Link taken to the Customize Pizza Order page for Original Crust
- Post Conditions: Taken to the Customize Pizza Order page for Original Crust
- Actual test result: Taken to the Customize Pizza Order page for Original Crust
- Pass/Fail : Pass

Case ID - PB12
- Date- 10/8/22
- Test Type - Regression - Test previous functionality of most popular order items from page where new link was added for the new Papa Bowl item
- Preconditions - Get to the Papa Johns Specials Page
https://www.papajohns.com/order/specials
- Test Steps: Scroll down to: Special - Large 1-Topping with Original or Thin Crust Box, Click the Order Now button
- Expected Results: Link taken to the Customize Pizza Order page for 1-Topping Pizza
- Post Conditions: Taken to the Customize Pizza Order page for 1-Topping Pizza
- Actual test result: Taken to the Customize Pizza Order page for 1-Topping Pizza
- Pass/Fail : Pass

Case ID - PB13
- Date- 10/8/22
- Test Type - Regression - Test previous functionality of most popular order items from page where new link was added for the new Papa Bowl item
- Preconditions - Get to the Papa Johns Homepage
https://www.papajohns.com/
- Test Steps: Scroll across the options on the page to get to the Any Large Specialty or up to 5 Toppings rectangle, Click the Order Now button.
- Expected Results: Link taken to the Any Large Specialty Pizza options page 
- Post Conditions: Taken to the Any Large Specialty Pizza  Order page 
- Actual test result: Taken to the Any Large Specialty Pizza Order page
- Pass/Fail : Pass

## Bug Report
### One test failed: Case ID PB10. 
This bug is only a partial fail to the consistency of the rest of the site because one of the two components still resulted in the user ability to process to the desired link of "Order Now" but was not consistant with the other area of the site where the picture of the bowl also had a hyperlink to take the user to the order page.  The addition of the code to make this hyperlink active on the picture on the Specials page.
To get to this bug:
https://www.papajohns.com/order/specials or from a homepage link to Specials
- Test Steps: Scroll down to the second option which is the Try Papa Bowls option, click Order Now or the picture.
- Expected Results: Link taken to the Papa Bowls order page

