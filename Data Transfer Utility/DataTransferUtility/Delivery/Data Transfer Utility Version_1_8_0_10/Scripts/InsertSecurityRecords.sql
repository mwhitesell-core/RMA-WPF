USE [%DatabaseName%]

INSERT INTO dbo.Renaissance_Designer_Security (Role, Screen, Desiner_Name, Enable) VALUES ('Administrators', 'D020', 'OVER', 0)
INSERT INTO dbo.Renaissance_Designer_Security (Role, Screen, Desiner_Name, Enable) VALUES ('Administrators', 'M020', 'PASS', 0)

INSERT INTO dbo.Renaissance_Menu_Security (Role, Tag,Visible) VALUES ('Administrators', 'D020', 0)

INSERT INTO dbo.Renaissance_Roles (Role_Name, Role_Priority) VALUES ('Domain Users', 10)
INSERT INTO dbo.Renaissance_Roles (Role_Name, Role_Priority) VALUES ('TFS_USERS', 0)
INSERT INTO dbo.Renaissance_Roles (Role_Name, Role_Priority) VALUES ('Administrators', 0)

INSERT INTO dbo.Renaissance_Screen_Security (Screen, Role, Screen_Entry, Screen_Find, Screen_Change, Screen_Delete) VALUES ('D020', 'TFS_USERS', 1, 1, 1, 1)
INSERT INTO dbo.Renaissance_Screen_Security (Screen, Role, Screen_Entry, Screen_Find, Screen_Change, Screen_Delete) VALUES ('M020', 'TFS_USERS', 0, 1, 1, 1)
