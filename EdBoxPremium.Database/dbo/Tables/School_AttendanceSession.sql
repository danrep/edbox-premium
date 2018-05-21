CREATE TABLE [dbo].[School_AttendanceSession] (
    [Id]                    BIGINT        IDENTITY (1, 1) NOT NULL,
    [CourseId]              INT           NOT NULL,
    [AcademicPeriodId]      INT           NOT NULL,
    [AttendanceFunctionId]  INT           NOT NULL,
    [AttendanceDescription] VARCHAR (100) NOT NULL,
    [DateRecorded]          DATETIME      NOT NULL,
    [UserRecorded]          INT           NOT NULL,
    [IsUploaded]            BIT           NOT NULL,
    [IsDeleted]             BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

