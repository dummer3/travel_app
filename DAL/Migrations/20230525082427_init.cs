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
                name: "UIDs",
                columns: table => new
                {
                    IdUID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UIDs", x => x.IdUID);
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
                    IdUID = table.Column<int>(type: "int", nullable: false),
                    TravelMode = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonaIdPersona = table.Column<int>(type: "int", nullable: false),
                    UniversityIdUniversity = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_Users_IdUID",
                table: "Users",
                column: "IdUID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonaIdPersona",
                table: "Users",
                column: "PersonaIdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UniversityIdUniversity",
                table: "Users",
                column: "UniversityIdUniversity");

            migrationBuilder.Sql("SET IDENTITY_INSERT UIDs ON");

            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (1, '4afafbd7000')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (2, '4aeafbd7000')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (3, '4adafbd7000')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (4, '4acafbd7000')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (5, '495afbd7000')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (6, '496afbd7000')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (7, '497afbd7000')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (8, '498afbd7000')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (9, '499afbd7000')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (10, '49aafbd7000')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (11, '49bafbd7000')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (12, '49cafbd7000')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (13, '49dafbd7000 ')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (14, '49eafbd7000')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (15, '49fafbd7000')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (16, '4a0afbd7000')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (17, '4a1afbd7000')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (18, '4a2afbd7000')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (19, '4c8afbd7000')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (20, '4a3afbd7000')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (21, '4a4afbd7000')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (22, '4a5afbd7000')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (23, '4a6afbd7000')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (24, '4a7afbd7000')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (25, '4a8afbd7000')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (26, '4c9afbd7000')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (27, '4a9afbd7000')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (28, '4aaafbd7000')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (29, '4abafbd7000')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (30, '423afbd7000')");

            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (31, '42df43e7300')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (32, '4dce33e7300')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (33, '41b0d407300')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (34, '40ef73e7300')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (35, '400483f7300')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (36, '409253f7300')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (37, '47f8b3f7300')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (38, '4f1fa3f7300')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (39, '441643f7300')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (40, '494df3f7300')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (41, '4d7f33e7300')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (42, '4fbd73f7300')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (43, '40ede3f7300')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (44, '456e33e7300')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (45, '4479d3f7300')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (46, '485c33f300')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (47, '484f03f7300')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (48, '4c13e3f7300')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (49, '46d5a3f7300')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (50, '40eda3f7300')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (51, '4304e3f7300')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (52, '419ec3e7300')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (53, '4e8e93e7300')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (54, '471123f7300')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (55, '443d73e7300')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (56, '442b13f7300')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (57, '46ee93f7300')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (58, '4f0933f7300')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (59, '46b7c3f7300')");
            migrationBuilder.Sql("INSERT into UIDs (IdUID,UID) VALUES (60, '490f93f7300')");

            migrationBuilder.Sql("SET IDENTITY_INSERT UIDs OFF");
            migrationBuilder.Sql("SET IDENTITY_INSERT Universities ON");

            migrationBuilder.Sql("INSERT into Universities (IdUniversity,Name,ImagePath) VALUES (1, 'Alto', 'assets/colleges/college-logo-1.png')");
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

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UIDs");

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
