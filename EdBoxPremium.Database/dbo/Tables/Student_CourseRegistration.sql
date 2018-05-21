CREATE TABLE [dbo].[Student_CourseRegistration] (
    [Id]                    INT IDENTITY (1, 1) NOT NULL,
    [CourseId]              INT NOT NULL,
    [AcademicPeriodId]      INT NOT NULL,
    [StudentId]             INT NOT NULL,
    [SchoolIdId]            INT NOT NULL,
    [SubSchoolId]           INT NOT NULL,
    [SubSchoolDepartmentId] INT NOT NULL,
    [IsDeleted]             BIT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

