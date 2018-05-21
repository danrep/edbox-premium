CREATE TABLE [dbo].[School_Attendance] (
    [Id]                  BIGINT   IDENTITY (1, 1) NOT NULL,
    [StudentId]           INT      NOT NULL,
    [DateRecorded]        DATETIME NOT NULL,
    [AttendanceSessionId] INT      NOT NULL,
    [IsDeleted]           BIT      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

