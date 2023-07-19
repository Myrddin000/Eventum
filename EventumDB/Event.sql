CREATE TABLE [dbo].[Events]
(
	[Event_id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(), 
    [Event_title] NVARCHAR(50) NOT NULL, 
    [Event_start_time] DATETIME NOT NULL, 
    [Event_end_time] DATETIME NOT NULL, 
    [Reminder_id] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [PK_Event] PRIMARY KEY ([Event_id]), 
    CONSTRAINT [FK_Event_Reminders] FOREIGN KEY ([Reminder_id]) REFERENCES [Reminders]([Reminder_id]),
    
    
)
