CREATE TABLE [dbo].[School_SubSchoolDepartment] (
    [Id]                      INT           IDENTITY (1, 1) NOT NULL,
    [SubSchoolId]             INT           NOT NULL,
    [SubSchoolDepartmentName] VARCHAR (100) NOT NULL,
    [IsDeleted]               BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

