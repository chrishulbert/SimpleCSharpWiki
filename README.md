Simple C# Wiki
==============

Wiki in C# / Asp.Net for small teams, running on intranets with active directory
License: Public domain or any OSI-approved license (your choice)

Features:
---------

* Designed for small enterprise-environment asp.net development teams
* Very simple, unlike most wikis
* Integrates well in an enterprise environment, eg with IIS, Sql Server, and Active Directory
* Single sign-on, so you don't need to remember another frigging login/password
* Clean interface
* Shows a tree view on the left pane of all wiki documents

Screenshots:
------------
![Wiki](http://imgur.com/295Rm.jpg)
![Edit](http://imgur.com/74NCI.jpg)

To deploy:
----------
* Create a Sql Server database, create a user/password with db_owner priveliges on that database
* Create a Virtual Directory in IIS, with 'Read' and 'Run Scripts' permissions
* Upload all the source files to that directory
* Edit the web.config:
 - Change the 'AdminGroup' to a Active Directory group name for people you want to be able to edit pages.
 - Change the 'connectionString' to point to your database server and have the correct login details.

That should be it! Please email me if you use this wiki, i hope its useful.
Chris  
chris.hulbert@gmail.com
