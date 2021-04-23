# Random Number Generator Game

Hello! Thanks for reviewing my back-end project for Code Louisville C# 2021!

Inspired by the movie, Third Eye Spies, I thought a random number generator that kept score and gave feedback based on user-input would be a rewarding project. A user is prompted to guess a number 1-5. Then, based on the user's input, messages are displayed related to the validity of input, and accuracy of the user's guess.
The user can choose to exit, or restart the game at any point they're prompted to guess a random number.

From the Code Louisville Project Requirements, I completed the following special features:
Implemented a Master Loop, that asks for user input, validates the input, checks for accuracy, then displays feedback and running score before starting the loop over again. This continues until the user exits the program.
Implement a log that records errors - FormatExceptions are added to a text file called ErrorLogs.txt with added details about what occurred.
Read data from an external file and display it in your application - Upon exiting the program, it checks to see if any errors were recorded that game by reading the ErrorLogs.txt file, then displaying errors to the console. The user is also notified of the path in which the errors are saved.
