#This Program changes all variables to a specific language.

#Notes
- Resource keys last two letters should be the language for the resource key/value pair.


#How to
1. paste the resx file you want to edit into the labels.resx file in this project
2. In Programm.cs add all the languages that you have in the resource file and want to Translate variables for. (line 7)
3. on line 8 fill in the language you want to change the variables to.
4. set a breakpoint on 32
	- I could not get this program to create the correct resource file so from this part on this is a workaround.
5. run the program.
6. in local: open resourceWriter > non-public members
7. press the View button > IEnumerableVisualizer
8. now copy this list to a excel (do not press Export as it will change certain letters f.e. : ë)
9. now you have your new list with the variables you want.