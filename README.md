# GFT_CSuisse

# Problem: Categorize trades in a bank´s portfolio 
# ...
# Question 1: Write a C# console application
# ...
# Question 2: A new category was created called PEP (politically exposed person). Also, a new bool property IsPoliticallyExposed was created in the ITrade interface.
# A trade shall be categorized as PEP if IsPoliticallyExposed is true. Describe in at most 1 paragraph what you must do in your design to account for this new category.
#   Answer 2: 
#       Create a new IPEP contract with the signatures of the necessary methods and objects.
#       Include the IPEP inheritance in ITrade and implement the IPEP contract in the Trade class that inherits from ITrade. 
#       The source code presents this structure.
