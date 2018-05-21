CREATE TABLE [dbo].[School_Course] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [CourseCode] VARCHAR (100) NOT NULL,
    [CourseName] VARCHAR (100) NOT NULL,
    [IsDeleted]  BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

