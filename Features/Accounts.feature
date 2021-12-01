Feature: Accounts

As a user, i would like to be able to choose an item
Add to basket
Create account via check out
Purchase using wire and finally Logout

@transaction
Scenario: End to End test - AddtoBasket/CreateAccount/Purchase/Logout
	Given I am on automationpractice page
	When I choose item 'Blouse' and select size as 'L' from dropDown, colour 'White' 
		And I click 'add_to_cart' to add item to basket
		And I click 'Proceed to checkout' of 'layer_cart'
		And I click 'Proceed to checkout' of 'center_column'
		And I enter email as 'abc{0}@abc.com'
		And I click create account button
	Then I am on 'Create an account' page
	When I select title Mr radio button
		And I create account with the following personal details:
		| FirName | LastName | Password | DOB       |
		| testFn  | testLn   | testPass | 14:7:1980 |
		And I enter address details as:
		| Address       | City        | State      | ZipCode | Country       | MobilePhone | AddressAlias |
		| 1 test address| los angeles | California | 70201   | United States | 07867654329 | testAlias    |
		And I click register button
		And I click 'Proceed to checkout' of 'center_column'
		And I click Terms of service check box
		And I click 'Proceed to checkout' of 'processCarrier'
	Then I am on 'Please choose your payment method' page
	When I select pay by 'bankwire'
		And I click 'I confirm my order' of 'cart_navigation'
	Then I am on 'Order confirmation' page
		And I see 'Your order on My Store is complete.' on order confirmation page
		And I Logout