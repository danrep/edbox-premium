CREATE TABLE [dbo].[School_SubSchool] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [SubSchoolName] VARCHAR (100) NOT NULL,
    [IsDeleted]     BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

