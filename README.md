# semester-group-assignment-group-4
semester-group-assignment-group-4 created by GitHub Classroom

Setup a local instance of SQL Server:
1)	Download from:
-	https://www.microsoft.com/en-us/sql-server/sql-server-editions-express
2)	Run setup wizard, select basic setup. 
3)	Once completed there should an option to download SQL Server Management Studio (SSMS).
a.	Download if not yet installed
4)	Launch SSMS, the SQL server instance that was just recently installed should be displayed as Server Name (should be your pc’s name)
a.	If it is not default set then click the drop down -> browse -> Database Engine -> should be the only option
5)	Connect
6)	Right click ‘Databases’ folder -> New Database -> Name it CCG4

Install and Setup Source Tree:
Source tree is a GUI for github, it facilitates branching and committing.
1)	Download from:
-	https://www.sourcetreeapp.com/
a.	Creating an account will be needed
2)	Once installed in the new tab -> clone
a.	Paste the github repo link in the ‘Source Path/ URL’
b.	In  ‘Destination Path’ browse to any folder you would like (best to make a new one, also make sure to disable oneDrive sync because it can and will cause issues)
c.	Name it anything you’d like
d.	Clone

Checking Out with Source Tree:
1)	Under Remotes -> origin -> right click branch you would like to check out -> Checkout origin/Branch Name
The branch should now be checked out under ‘Branches’

Creating a New Branch in Source Tree:
It would be a good idea to create branched to avoid breaking issues and road blocks, we will typically want to branch of from a ‘main’ branch.
1)	Under Branches -> double click the name of the one you want to branch off from
2)	On the Top click ‘Branch’ -> Give it a name (No spaces) -> create branch
3)	On the left panel make sure that the new branch is the one that is selected (Bolded letters)

Committing changes in Source Tree:
1)	On the left panel under ‘WORKSPACE’ -> File Statue
2)	Under the ‘Unstaged files’ select all that you want to commit and discard all that you don’t need, make sure that everything goes up to the ‘Staged files’.
3)	Write a useful comment
4)	Commit (you can ignore the check box that says push changes immediately to - )
5)	Then under ‘BRANCHES’ right click the branch that you committed -> Push to -> origin (In case something happens to machine it is now in the cloud)

Pulling Most Recent Version of a Branch in Source Tree:
This should typically be used only for updating the local version of the ‘main’ branch in order to rebase on top of it.
1)	Double click the branch you want to pull, make sure it gets selected
2)	On the top click ‘Fetch’ -> ok
3)	On the top click ‘Pull’ -> ok

Rebasing from Visual Studio:
In Source Tree:
1)	Make sure that changes are committed and pushed to origin (This will give a backup in case rebasing goes horribly wrong so make sure it is done)
2)	Make sure that you have the most recent ‘main’ branch copy (see above for pull)
3)	Double check that you do in fact have the most recent ‘main’ branch changes
4)	Switch to the branch you want to rebase (double click), double check that you have switched
In VS:
	Note*: If VS was open with you were switching branches it will prompt you to reload, hit ‘yes all’
1)	Click ‘Team Explorer’ (if not on the right-side search it up at the top)
2)	Click the Home Icon at the top -> Branches
3)	Click Rebase
a.	Rebase from the current branch: (should be the name of the branch you are on)
b.	Onto branch: Select the ‘main’ branch
4)	Click rebase
5)	(Look at resolving merge conflicts)
