CREATE TABLE [dbo].[DoctorTbl] (
    [DocId]    INT          NOT NULL,
    [DocName]  VARCHAR (50) NOT NULL,
    [DocJoin]  DATE         NOT NULL,
    [DocGen]   VARCHAR (10) NOT NULL,
    [DOCSPEC]  VARCHAR (50) NOT NULL,
    [DOCEXP]   INT          NOT NULL,
    [DOCPHONE] VARCHAR (50) NOT NULL,
    [DocAdd]   VARCHAR (50) NOT NULL,
    [DocPass]  VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([DocId] ASC)
);

