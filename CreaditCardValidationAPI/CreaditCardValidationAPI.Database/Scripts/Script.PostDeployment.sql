/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

if not exists (select * from [CREDIT_CARDS])
begin

INSERT [dbo].[CREDIT_CARDS] ([CARD_NUMBER], [EXPIRY_DATE]) VALUES (4123345678910234,'2016-05-11')
INSERT [dbo].[CREDIT_CARDS] ([CARD_NUMBER], [EXPIRY_DATE]) VALUES (5123345678910234,'2003-05-11')
INSERT [dbo].[CREDIT_CARDS] ([CARD_NUMBER], [EXPIRY_DATE]) VALUES (1123345678910234,'2003-05-11')
INSERT [dbo].[CREDIT_CARDS] ([CARD_NUMBER], [EXPIRY_DATE]) VALUES (3123345678910234,'2019-05-11')
INSERT [dbo].[CREDIT_CARDS] ([CARD_NUMBER], [EXPIRY_DATE]) VALUES (312334567891023 ,'2018-05-11')
INSERT [dbo].[CREDIT_CARDS] ([CARD_NUMBER], [EXPIRY_DATE]) VALUES (4199999999999999,'2015-05-11')
INSERT [dbo].[CREDIT_CARDS] ([CARD_NUMBER], [EXPIRY_DATE]) VALUES (5199999999999999,'2004-05-11')
INSERT [dbo].[CREDIT_CARDS] ([CARD_NUMBER], [EXPIRY_DATE]) VALUES (9999999999999999,'2018-07-04')

end


--4123345678910234	2016-05-11
--5123345678910234	2003-05-11
--1123345678910234	2003-05-11
--3123345678910234	2019-05-11
--312334567891023	2018-05-11
--4199999999999999	2015-05-11
--5199999999999999	2004-05-11
--9999999999999999	2018-07-04


