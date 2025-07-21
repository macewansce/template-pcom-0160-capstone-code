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
                $"IF ( OBJECT_ID('Users') IS NOT NULL ) BEGIN PRINT 'Users Table Exists' END ELSE BEGIN CREATE TABLE Users ( Id int NOT NULL IDENTITY, FirstName nvarchar(max) NOT NULL, LastName nvarchar(max) NOT NULL, Email nvarchar(max) NOT NULL, Username nvarchar(max) NOT NULL, PasswordHash nvarchar(max) NOT NULL, Role nvarchar(max) NOT NULL, CONSTRAINT PK_Users PRIMARY KEY (Id) ) END"
            );
            //migrationBuilder.CreateTable
            //(
            //    name: "Users",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Users", x => x.Id);
            //    }
            //);
            string apassword = BCrypt.Net.BCrypt.HashPassword("admin-password");
            string gpassword = BCrypt.Net.BCrypt.HashPassword("general-password");
            migrationBuilder.Sql
            (
                $"IF NOT EXISTS (SELECT Username from Users where Username='admin') BEGIN INSERT INTO Users (FirstName, LastName, Email, Username, PasswordHash, Role) VALUES ('Admin', 'User', 'admin@example.com', 'admin', '{apassword}', 'Administrator') END IF NOT EXISTS (SELECT Username from Users where Username='general') BEGIN INSERT INTO Users (FirstName, LastName, Email, Username, PasswordHash, Role) VALUES ('General', 'User', 'general@example.com', 'general', '{gpassword}', 'General') END;"
            );
            //migrationBuilder.InsertData
            //(
            //    table: "Users",
            //    columns: new[] { "FirstName", "LastName", "Email", "Username", "PasswordHash", "Role" },
            //    values: new object[,]
            //    {
            //        { "Admin", "User", "admin@example.com", "admin",  BCrypt.Net.BCrypt.HashPassword("admin-password"), "Administrator" },
            //        { "General", "User", "general@example.com", "general",  BCrypt.Net.BCrypt.HashPassword("general-password"), "General" }
            //    }
            //);
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
