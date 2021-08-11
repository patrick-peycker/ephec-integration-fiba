using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiba.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    GenderId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Position = table.Column<string>(nullable: true),
                    GenderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_Players_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    SeasonId = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    GenderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.SeasonId);
                    table.ForeignKey(
                        name: "FK_Seasons_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    GenderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Teams_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeasonTeams",
                columns: table => new
                {
                    SeasonId = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonTeams", x => new { x.TeamId, x.SeasonId });
                    table.ForeignKey(
                        name: "FK_SeasonTeams_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "SeasonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SeasonTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamPlayers",
                columns: table => new
                {
                    TeamId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamPlayers", x => new { x.TeamId, x.PlayerId });
                    table.ForeignKey(
                        name: "FK_TeamPlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamPlayers_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    Date = table.Column<DateTimeOffset>(nullable: false),
                    Period = table.Column<int>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    HomeTeamScore = table.Column<int>(nullable: false),
                    VisitorTeamScore = table.Column<int>(nullable: false),
                    HomeTeamSeasonId = table.Column<int>(nullable: false),
                    HomeTeamId = table.Column<int>(nullable: false),
                    VisitorTeamSeasonId = table.Column<int>(nullable: false),
                    VisitorTeamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_Matches_SeasonTeams_HomeTeamId_HomeTeamSeasonId",
                        columns: x => new { x.HomeTeamId, x.HomeTeamSeasonId },
                        principalTable: "SeasonTeams",
                        principalColumns: new[] { "TeamId", "SeasonId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_SeasonTeams_VisitorTeamId_VisitorTeamSeasonId",
                        columns: x => new { x.VisitorTeamId, x.VisitorTeamSeasonId },
                        principalTable: "SeasonTeams",
                        principalColumns: new[] { "TeamId", "SeasonId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    StatisticId = table.Column<int>(nullable: false),
                    Assist = table.Column<int>(nullable: false),
                    Block = table.Column<int>(nullable: false),
                    DefensiveRebound = table.Column<int>(nullable: false),
                    ThreePointFieldGoalPourcentage = table.Column<decimal>(nullable: false),
                    ThreePointFieldGoalAttempted = table.Column<int>(nullable: false),
                    ThreePointFieldGoalMade = table.Column<int>(nullable: false),
                    FieldGoalPourcentage = table.Column<decimal>(nullable: false),
                    FieldGoalAttempted = table.Column<int>(nullable: false),
                    FieldGoalMade = table.Column<int>(nullable: false),
                    FreeTrowPourcentage = table.Column<decimal>(nullable: false),
                    FreeTrowAttempted = table.Column<int>(nullable: false),
                    FreeTrowMade = table.Column<int>(nullable: false),
                    OffensiveRebound = table.Column<int>(nullable: false),
                    PersonnalFoul = table.Column<int>(nullable: false),
                    Point = table.Column<int>(nullable: false),
                    Rebound = table.Column<int>(nullable: false),
                    Steal = table.Column<int>(nullable: false),
                    Turnover = table.Column<int>(nullable: false),
                    MatchId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.StatisticId);
                    table.ForeignKey(
                        name: "FK_Statistics_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Statistics_TeamPlayers_TeamId_PlayerId",
                        columns: x => new { x.TeamId, x.PlayerId },
                        principalTable: "TeamPlayers",
                        principalColumns: new[] { "TeamId", "PlayerId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "GenderId", "Name" },
                values: new object[] { new Guid("eddf827d-8795-4054-93b9-19276dd4af26"), "Female" });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "GenderId", "Name" },
                values: new object[] { new Guid("7a8e0b6f-3e77-4c55-9227-d47325088b25"), "Male" });

            migrationBuilder.CreateIndex(
                name: "IX_Genders_Name",
                table: "Genders",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HomeTeamId_HomeTeamSeasonId",
                table: "Matches",
                columns: new[] { "HomeTeamId", "HomeTeamSeasonId" });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_VisitorTeamId_VisitorTeamSeasonId",
                table: "Matches",
                columns: new[] { "VisitorTeamId", "VisitorTeamSeasonId" });

            migrationBuilder.CreateIndex(
                name: "IX_Players_GenderId",
                table: "Players",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_GenderId_Year",
                table: "Seasons",
                columns: new[] { "GenderId", "Year" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SeasonTeams_SeasonId",
                table: "SeasonTeams",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_MatchId",
                table: "Statistics",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_TeamId_PlayerId",
                table: "Statistics",
                columns: new[] { "TeamId", "PlayerId" });

            migrationBuilder.CreateIndex(
                name: "IX_TeamPlayers_PlayerId",
                table: "TeamPlayers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_GenderId",
                table: "Teams",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Name_GenderId",
                table: "Teams",
                columns: new[] { "Name", "GenderId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "TeamPlayers");

            migrationBuilder.DropTable(
                name: "SeasonTeams");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Genders");
        }
    }
}
