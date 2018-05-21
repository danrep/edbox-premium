CREATE TABLE [dbo].[Administration_AccessCredential] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [Username]     VARCHAR (100) NOT NULL,
    [PasswordData] VARCHAR (MAX) NOT NULL,
    [PasswordSalt] VARCHAR (MAX) NOT NULL,
    [IsDeleted]    BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

