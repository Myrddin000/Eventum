CREATE TABLE [dbo].[Reminders]
(
	[Reminder_id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(), 
    [Reminder_title] NVARCHAR(50) NOT NULL, 
    [Reminder_time] DATETIME NOT NULL, 
    CONSTRAINT [PK_Reminders] PRIMARY KEY ([Reminder_id])
)
