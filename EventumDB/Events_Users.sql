CREATE TABLE [dbo].[Events_Users]
(
	[Event_id] UNIQUEIDENTIFIER NOT NULL, 
    [User_id] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_Events_Users_Events] FOREIGN KEY ([Event_id]) REFERENCES [Events]([Event_id]), 
    CONSTRAINT [FK_Events_Users_Users] FOREIGN KEY ([User_id]) REFERENCES [Users]([User_id]) 
)
