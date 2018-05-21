CREATE TABLE [dbo].[Administration_AccessCredentialRole] (
    [Id]           INT IDENTITY (1, 1) NOT NULL,
    [CredentialId] INT NOT NULL,
    [PermissionId] INT NOT NULL,
    [IsDeleted]    BIT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

