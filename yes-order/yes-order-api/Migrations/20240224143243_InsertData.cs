using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace yes_order_api.Migrations
{
    /// <inheritdoc />
    public partial class InsertData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[Users]([Id],[Username]) VALUES(NEWID(),'Gustav'),(NEWID(),'Mary'),(NEWID(),'Luke'), (NEWID(), 'Jules'),(NEWID(), 'Robert');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
