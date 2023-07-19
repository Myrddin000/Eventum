CREATE TABLE [dbo].[Users]
(
	[User_id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(), 
    [User_pseudo] NVARCHAR(50) NOT NULL, 
    [User_email] NVARCHAR(50) NOT NULL, 
    [User_password] NVARCHAR(255) NOT NULL, 
    CONSTRAINT [PK_Users] PRIMARY KEY ([User_id]), 
    CONSTRAINT [CK_Users_pseudo] UNIQUE ([User_pseudo]),
    CONSTRAINT [CK_Users_email] UNIQUE ([User_email]),
    
)
