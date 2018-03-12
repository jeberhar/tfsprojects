TFS Projects will provide a list of all users, by group, for each project or for only one project on a given Team Foundation Server instance via the TFS API.  

Direct installer link: https://github.com/jeberhar/tfsprojects/blob/master/TFSProjects.msi

The default port for the instance is required, which is usually 8080 unless it has been customized, in which case you can specify your port in the app.  If you don't know the default port, ask your Team Foundation Server administrator.

There is much more information about each user that could be displayed, look at the IGroupSecurityService2 object for more info.  For this program I only used Name and MailAddress for the sake of brevity.

TFS Projects is a Windows Forms application, requiring .Net 4.5.  To make modifications download the source and load up in Visual Studio, the full project is in the zip file to make customizations easier.

If you are using TFS 2005, check out http://github.com/jeberhar/tfsusers for a comprehensive user audit check for that version of TFS.

![](Home_TFSProjectsScreenshot.jpg)

Copyright 2018 Jay Eberhard.
