INSERT INTO [dbo].[Users]
           ([Id]
           ,[Username])
     VALUES
           (NEWID(), 'Gustavo'),
           (NEWID(), 'Maria'),
           (NEWID(), 'Luca'),
           (NEWID(), 'Giulia'),
           (NEWID(), 'Alessandro');

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
           (NEWID(), 'Televisore LED 50 pollici', (SELECT Id FROM [Category] WHERE [Name] = 'Elettronica')),
           (NEWID(), 'Maglia a maniche lunghe', (SELECT Id FROM [Category] WHERE [Name] = 'Abbigliamento')),
           (NEWID(), 'Set da cucina in acciaio', (SELECT Id FROM [Category] WHERE [Name] = 'Casa e Giardino')),
           (NEWID(), 'Parmigiano Reggiano DOP', (SELECT Id FROM [Category] WHERE [Name] = 'Alimentari')),
           (NEWID(), 'Crema viso idratante', (SELECT Id FROM [Category] WHERE [Name] = 'Bellezza'));

GO