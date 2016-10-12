# Exercise
Lab Exercise for Shopping Basket

Task Details:
You have been asked to model a shopping basket. We must be able to:
 
·         Add items to the shopping basket
·         Remove items from the shopping basket
·         Empty the shopping basket
 
Additionally, we must be able to calculate the total of the shopping basket accounting for:
 
·         Buy one get one free discounts on items
·         10% off on totals greater than £20 (after BOGOF)
·         2% off on total (after all other discounts) for customers with loyalty cards
 
There is no requirement to create a GUI or Database but we must be able to see the code running correctly.
C# is preferred, but other similar languages acceptable.
Solution must contain everything required to build & run on a Windows 10 machine with latest .Net frameworks already installed

Tests:

Basket 1: 
1 Hat @ 10.50
1 Jumper @ 54.65
BOGOF offer for Category:Hats

Total: £65.15


Basket 2: 
2 Hat @ 10.50
1 Jumper @ 54.65
BOGOF offer for Category:Hats
Total: £65.15
Message: BOGOF discount £10.50 applied

Basket 3:

3 Hat @ 10.50
1 Jumper @ 54.65
BOGOF offer for Category:Hats
Total: £75.65
Message: BOGOF discount £10.50 applied


Basket 4: 

2 Hat @ 4.65
1 Jumper @ 14.45

BOGOF offer for Category:Hats
10% off on totals greater than £20 (after BOGOF)
Total: £19.10
Message: BOGOF discount £4.65 applied
Message: “You have not reached the spend threshold for voucher YYY-YYY. Spend another £0.91 or more to receive 10% off your basket total.”


Basket 5: 
2 Hat @ 6.70
2 Jumper @ 12.65

BOGOF offer for Category:Hats
10% off on totals greater than £20 (after BOGOF)

Basket Total: £28.80
Message: BOGOF discount £6.70 applied
message: OfferVoucher discount £3.20 applied.


Basket 6:

3 Hat @ 4.75
2 Jumper @ 15.25

10% off on totals greater than £20 (after BOGOF)
2% off on total for customers with Loyalty cards

Basket Total: £35.28
Message: BOGOF discount £4.75 applied
message: OfferVoucher discount £4.00 applied.
message: Loyalty discount £0.72 applied.
