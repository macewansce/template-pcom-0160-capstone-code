using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Data;

#nullable disable

namespace capstone.web.api.Migrations
{
    /// <inheritdoc />
    public partial class CreateInitialSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql
            (
                $"IF OBJECT_ID(N'[Users]') IS NOT NULL BEGIN PRINT 'Table [Users] Exists' END ELSE BEGIN CREATE TABLE [Users] ( [Id] int NOT NULL IDENTITY, [FirstName] nvarchar(max) NOT NULL, [LastName] nvarchar(max) NOT NULL, [Email] nvarchar(max) NOT NULL, [Username] nvarchar(max) NOT NULL, [PasswordHash] nvarchar(max) NOT NULL, [Role] nvarchar(max) NOT NULL, CONSTRAINT [PK_Users] PRIMARY KEY ([Id]) ) END;"
            );
            string apassword = BCrypt.Net.BCrypt.HashPassword("admin-password");
            migrationBuilder.Sql
            (
                $"IF EXISTS (SELECT [Username] from [Users] where Username='admin') BEGIN PRINT 'User [admin] exists' END ELSE BEGIN INSERT INTO [Users] ([FirstName], [LastName], [Email], [Username], [PasswordHash], [Role]) VALUES ('Admin', 'User', 'admin@example.com', 'admin', '{apassword}', 'Administrator') END;" 
            );
            string gpassword = BCrypt.Net.BCrypt.HashPassword("general-password");
            migrationBuilder.Sql
            (
                $"IF EXISTS (SELECT [Username] from [Users] where Username='general') BEGIN PRINT 'User [general] exists' END ELSE BEGIN INSERT INTO [Users] ([FirstName], [LastName], [Email], [Username], [PasswordHash], [Role]) VALUES ('General', 'User', 'general@example.com', 'general', '{gpassword}', 'General') END;"
            );
        }

        /// <inheritdoc />0
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable
            (
                name: "Users"
            );
        }
    }
}
