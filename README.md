# TaxManager
Application for tax managing

# Installation instructions

1) Copy the db catalog to directory C:\ so we have our database path looking like this: C:\db\TaxManagerDB.mdf <br/>
Note: while doing the task I have came to some strange permission issues accessing database. Setting Full Control permissions on folder C:\db for Everyone solves the issue. Probably not the best practice but had no time to figure out what was actually wrong. <br/> 

2) Copy file import.json to directory C:\ <br/>
3) Build the project <br/>
4) Open command prompt in path TaxManager\TaxManager\bin\Debug <br/>
5) Run Command InstallUtil TaxManager.exe <br/>
Note: once again, to avoid permission issues, set up windows service to run on your personal Windows account.
