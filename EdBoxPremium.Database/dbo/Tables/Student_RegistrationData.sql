CREATE TABLE [dbo].[Student_RegistrationData] (
    [Id]                    INT      IDENTITY (1, 1) NOT NULL,
    [SchoolId]              INT      NOT NULL,
    [SubSchoolId]           INT      NOT NULL,
    [SubSchoolDepartmentId] INT      NOT NULL,
    [StudentId]             INT      NOT NULL,
    [AcademicPeriodId]      INT      NOT NULL,
    [DateRegistered]        DATETIME NOT NULL,
    [IsDeleted]             BIT      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

