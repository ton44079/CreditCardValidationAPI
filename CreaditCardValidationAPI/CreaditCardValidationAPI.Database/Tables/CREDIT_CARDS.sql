﻿CREATE TABLE [dbo].[CREDIT_CARDS]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CARD_NUMBER] NUMERIC(16) NOT NULL, 
    [EXPIRY_DATE] DATE NOT NULL
)