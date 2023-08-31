INSERT INTO [dbo].[Users]
           ([Id]
           ,[Username])
     VALUES
           (NEWID(), 'Gustavo'),
           (NEWID(), 'Maria'),
           (NEWID(), 'Luca'),
           (NEWID(), 'Giulia'),
           (NEWID(), 'Alessandro');

USE [photosi]
GO

INSERT INTO [dbo].[Address]
           ([Id]
           ,[StreetAddress]
           ,[City]
           ,[State]
           ,[PostalCode]
           ,[Country])
     VALUES
           (NEWID(), 'Via Roma 123', 'Roma', 'Lazio', '00100', 'Italy'),
           (NEWID(), 'Corso Italia 456', 'Milano', 'Lombardia', '20121', 'Italy'),
           (NEWID(), 'Piazza San Marco 789', 'Venezia', 'Veneto', '30100', 'Italy'),
           (NEWID(), 'Viale Napoli 101', 'Napoli', 'Campania', '80100', 'Italy'),
           (NEWID(), 'Strada Firenze 202', 'Firenze', 'Toscana', '50100', 'Italy');
GO

INSERT INTO [dbo].[Category]
           ([Id]
           ,[Name])
     VALUES
           (NEWID(), 'Elettronica'),
           (NEWID(), 'Abbigliamento'),
           (NEWID(), 'Casa e Giardino'),
           (NEWID(), 'Alimentari'),
           (NEWID(), 'Bellezza');
GO

INSERT INTO [dbo].[Products]
           ([Id]
           ,[Name]
           ,[CategoryId])
     VALUES
           (NEWID(), 'Televisore LED 50 pollici', '3F01D770-63B5-4368-ADA1-9481710B9B61'),
           (NEWID(), 'Maglia a maniche lunghe', 'F65EC106-3FEE-433E-A7F2-095C0CA9B5C9'),
           (NEWID(), 'Set da cucina in acciaio', '3DFFB386-3706-47C4-96F1-7335F4E7EAFD'),
           (NEWID(), 'Parmigiano Reggiano DOP','3DFFB386-3706-47C4-96F1-7335F4E7EAFD'),
           (NEWID(), 'Crema viso idratante', 'F873DB60-AF66-4029-ADBD-7826BA121B9A' );
GO

