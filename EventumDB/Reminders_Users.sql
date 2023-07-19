CREATE TABLE [dbo].[Reminders_Users]
(
	[Reminder_id] UNIQUEIDENTIFIER NOT NULL, 
    [User_id] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_Reminders_Users_Reminders] FOREIGN KEY ([Reminder_id]) REFERENCES [Reminders]([Reminder_id]), 
    CONSTRAINT [FK_Reminders_Users_Users] FOREIGN KEY ([User_id]) REFERENCES [Users]([User_id]) 
)
