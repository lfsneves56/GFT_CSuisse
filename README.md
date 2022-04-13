# GFT_CSuisse

# Problem: Categorize trades in a bank´s portfolio 
# A bank has a portfolio of thousands of trades and they need to be categorized. A trade is a commercial negotiation between a bank and a client. 
# A trade has many characteristics, including:
# ...
# Question 1: Write a C# console application using object oriented design that classifies all trades in a given portfolio.
# Keep in mind that the real application may # have dozens of categories, so your design must be extensible allowing those categories to be easily added/removed/modified in the future
# ...
# Question 2: A new category was created called PEP (politically exposed person). Also, a new bool property IsPoliticallyExposed was created in the ITrade interface.
# A trade shall be categorized as PEP if IsPoliticallyExposed is true. Describe in at most 1 paragraph what you must do in your design to account for this new category.
#   Answer: 
#       Create a new IPEP contract with the signatures of the necessary methods and objects.
#       Include the IPEP inheritance in ITrade and implement the IPEP contract in the Trade class that inherits from ITrade. 
#       The source code presents this structure.
