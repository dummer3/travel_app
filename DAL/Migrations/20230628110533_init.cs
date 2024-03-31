using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    IdPersona = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TravelScore = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.IdPersona);
                });

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    IdUniversity = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.IdUniversity);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Point = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TravelMode = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PersonaIdPersona = table.Column<int>(type: "int", nullable: false),
                    UniversityIdUniversity = table.Column<int>(type: "int", nullable: false),
                    JsonContent = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_Users_Personas_PersonaIdPersona",
                        column: x => x.PersonaIdPersona,
                        principalTable: "Personas",
                        principalColumn: "IdPersona");
                    table.ForeignKey(
                        name: "FK_Users_Universities_UniversityIdUniversity",
                        column: x => x.UniversityIdUniversity,
                        principalTable: "Universities",
                        principalColumn: "IdUniversity");
                });

            migrationBuilder.CreateTable(
                name: "UserDALUserDAL",
                columns: table => new
                {
                    FriendsIdUser = table.Column<int>(type: "int", nullable: false),
                    UserDALIdUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDALUserDAL", x => new { x.FriendsIdUser, x.UserDALIdUser });
                    table.ForeignKey(
                        name: "FK_UserDALUserDAL_Users_FriendsIdUser",
                        column: x => x.FriendsIdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDALUserDAL_Users_UserDALIdUser",
                        column: x => x.UserDALIdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserDALUserDAL_UserDALIdUser",
                table: "UserDALUserDAL",
                column: "UserDALIdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonaIdPersona",
                table: "Users",
                column: "PersonaIdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UniversityIdUniversity",
                table: "Users",
                column: "UniversityIdUniversity");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);

            migrationBuilder.Sql("SET IDENTITY_INSERT Universities ON");

            migrationBuilder.Sql("INSERT into Universities (IdUniversity,Name,ImagePath) VALUES (1, 'Aalto', 'assets/colleges/college-logo-1.png')");
            migrationBuilder.Sql("INSERT into Universities (IdUniversity,Name,ImagePath) VALUES (2, 'LiU', 'assets/colleges/college-logo-2.png')");
            migrationBuilder.Sql("INSERT into Universities (IdUniversity,Name,ImagePath) VALUES (3, 'KIT', 'assets/colleges/college-logo-3.png')");
            migrationBuilder.Sql("INSERT into Universities (IdUniversity,Name,ImagePath) VALUES (4, 'Mannheim', 'assets/colleges/college-logo-4.png')");
            migrationBuilder.Sql("INSERT into Universities (IdUniversity,Name,ImagePath) VALUES (5, 'd.school', 'assets/colleges/college-logo-5.png')");
            migrationBuilder.Sql("INSERT into Universities (IdUniversity,Name,ImagePath) VALUES (6, 'USP', 'assets/colleges/college-logo-6.png')");
            migrationBuilder.Sql("INSERT into Universities (IdUniversity,Name,ImagePath) VALUES (7, 'HPI', 'assets/colleges/college-logo-7.png')");
            migrationBuilder.Sql("INSERT into Universities (IdUniversity,Name,ImagePath) VALUES (8, 'Côte d''Azur', 'assets/colleges/college-logo-8.png')");
            migrationBuilder.Sql("INSERT into Universities (IdUniversity,Name,ImagePath) VALUES (9, 'Javeriana', 'assets/colleges/college-logo-9.png')");
            migrationBuilder.Sql("INSERT into Universities (IdUniversity,Name,ImagePath) VALUES (10, 'ISDI', 'assets/colleges/college-logo-10.png')");
            migrationBuilder.Sql("INSERT into Universities (IdUniversity,Name,ImagePath) VALUES (11, 'SUTD', 'assets/colleges/college-logo-11.png')");
            migrationBuilder.Sql("INSERT into Universities (IdUniversity,Name,ImagePath) VALUES (12, 'TCD', 'assets/colleges/college-logo-12.png')");
            migrationBuilder.Sql("INSERT into Universities (IdUniversity,Name,ImagePath) VALUES (13, 'Other', 'assets/colleges/college-logo-13.png')");

            migrationBuilder.Sql("SET IDENTITY_INSERT Universities OFF");

            migrationBuilder.Sql("SET IDENTITY_INSERT Personas ON");

            migrationBuilder.Sql("INSERT into Personas (IdPersona,TravelScore) VALUES (1, '[0,0,77,100,100]')");
            migrationBuilder.Sql("INSERT into Personas (IdPersona,TravelScore) VALUES (2, '[0,0,68,77,77]')");
            migrationBuilder.Sql("INSERT into Personas (IdPersona,TravelScore) VALUES (3, '[0,0,69,75,75]')");
            migrationBuilder.Sql("INSERT into Personas (IdPersona,TravelScore) VALUES (4, '[0,0,51,66,80]')");
            migrationBuilder.Sql("INSERT into Personas (IdPersona,TravelScore) VALUES (5, '[0,0,47,39,39]')");
            migrationBuilder.Sql("INSERT into Personas (IdPersona,TravelScore) VALUES (6, '[0,0,48,50,50]')");
            migrationBuilder.Sql("INSERT into Personas (IdPersona,TravelScore) VALUES (7, '[0,0,34,37,37]')");

            migrationBuilder.Sql("SET IDENTITY_INSERT Personas OFF");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserDALUserDAL");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Universities");
        }
    }
}
