CREATE TABLE [dbo].[System_Setting] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [SettingKey]   INT           NOT NULL,
    [SettingValue] VARCHAR (MAX) NOT NULL,
    [SettingDate]  DATETIME      DEFAULT (getdate()) NOT NULL,
    [IsDeleted]    BIT           DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

