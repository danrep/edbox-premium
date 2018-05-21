CREATE TABLE [dbo].[Student_ProfileData] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [MatricNumber] VARCHAR (100) NOT NULL,
    [TagId]        VARCHAR (100) NULL,
    [FirstName]    VARCHAR (100) NOT NULL,
    [LastName]     VARCHAR (100) NOT NULL,
    [Sex]          VARCHAR (10)  NOT NULL,
    [Phone]        VARCHAR (100) NOT NULL,
    [Email]        VARCHAR (100) NOT NULL,
    [BloodGroup]   VARCHAR (100) NULL,
    [Picture]      VARCHAR (MAX) NULL,
    [IsDeleted]    BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

