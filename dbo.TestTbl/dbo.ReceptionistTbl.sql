CREATE TABLE [dbo].[ReceptionistTbl] (
    [RecepId]    INT          NOT NULL,
    [RecepName]  VARCHAR (50) NOT NULL,
    [RecepPhone] VARCHAR (15) NOT NULL,
    [RecepAdd]   VARCHAR (50) NOT NULL,
    [RecepPass]  VARCHAR (10) NOT NULL,
    [RecepGen]   VARCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([RecepId] ASC)
);

