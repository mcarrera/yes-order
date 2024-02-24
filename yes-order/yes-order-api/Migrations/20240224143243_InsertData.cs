using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using yes_orders_api.Data.Entities;

#nullable disable

namespace yes_order_api.Migrations
{
    /// <inheritdoc />
    public partial class InsertData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@$"INSERT INTO [Users]([Id],[Username]) VALUES
                                    ('{Guid.NewGuid()}','Gustav'),
                                    ('{Guid.NewGuid()}','Mary'),
                                    ('{Guid.NewGuid()}','Luke'),
                                    ('{Guid.NewGuid()}', 'Jules'),
                                    ('{Guid.NewGuid()}', 'Robert');");

            migrationBuilder.Sql(@$"INSERT INTO [Address] ([Id], [StreetAddress], [City], [State], [PostalCode], [Country]) VALUES
                                     ('{Guid.NewGuid()}', 'Via Roma 123', 'Roma', 'Lazio', '00100', 'Italy'),
                                     ('{Guid.NewGuid()}', 'Corso Italia 456', 'Milano', 'Lombardia', '20121', 'Italy'),
                                     ('{Guid.NewGuid()}', 'Piazza San Marco 789', 'Venezia', 'Veneto', '30100', 'Italy'),
                                     ('{Guid.NewGuid()}', 'Viale Napoli 101', 'Napoli', 'Campania', '80100', 'Italy'),
                                     ('{Guid.NewGuid()}', 'Strada Firenze 202', 'Firenze', 'Toscana', '50100', 'Italy');");



            migrationBuilder.Sql(@$"INSERT INTO [Category] ([Id] , [Name]) VALUES
                                 ('{Guid.NewGuid()}', 'Elettronica'),
                                 ('{Guid.NewGuid()}', 'Abbigliamento'),
                                 ('{Guid.NewGuid()}', 'Casa e Giardino'),
                                 ('{Guid.NewGuid()}', 'Alimentari'),
                                 ('{Guid.NewGuid()}', 'Bellezza');");

            migrationBuilder.Sql(@$"INSERT INTO [Products] ([Id] , [Name] , [CategoryId]) VALUES
                             ('{Guid.NewGuid()}', 'Televisore LED 50 pollici', (SELECT Id FROM[Category] WHERE[Name] = 'Elettronica')),
                             ('{Guid.NewGuid()}', 'Maglia a maniche lunghe', (SELECT Id FROM[Category] WHERE[Name] = 'Abbigliamento')),
                             ('{Guid.NewGuid()}', 'Set da cucina in acciaio', (SELECT Id FROM[Category] WHERE[Name] = 'Casa e Giardino')),
                             ('{Guid.NewGuid()}', 'Parmigiano Reggiano DOP', (SELECT Id FROM[Category] WHERE[Name] = 'Alimentari')),
                             ('{Guid.NewGuid()}', 'Crema viso idratante', (SELECT Id FROM[Category] WHERE[Name] = 'Bellezza'));");

            migrationBuilder.Sql(@$"INSERT INTO [ORDERS}");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
