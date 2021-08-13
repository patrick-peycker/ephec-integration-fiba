using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiba.DAL.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    GenderId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
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
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
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
                    SeasonId = table.Column<Guid>(nullable: false),
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
                    Name = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Abbreviation = table.Column<string>(nullable: true),
                    ThumbUrl = table.Column<string>(nullable: true),
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
                name: "Matches",
                columns: table => new
                {
                    MatchId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    HomeTeamScore = table.Column<int>(nullable: false),
                    Period = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    VisitorTeamScore = table.Column<int>(nullable: false),
                    Postseason = table.Column<bool>(nullable: false),
                    SeasonId = table.Column<Guid>(nullable: false),
                    HomeTeamId = table.Column<int>(nullable: false),
                    VisitorTeamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "SeasonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_VisitorTeamId",
                        column: x => x.VisitorTeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayersTeams",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: false),
                    StartOfContract = table.Column<DateTime>(nullable: false),
                    EndOfContract = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayersTeams", x => new { x.PlayerId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_PlayersTeams_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayersTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SeasonsTeams",
                columns: table => new
                {
                    SeasonId = table.Column<Guid>(nullable: false),
                    TeamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonsTeams", x => new { x.TeamId, x.SeasonId });
                    table.ForeignKey(
                        name: "FK_SeasonsTeams_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "SeasonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SeasonsTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
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
                    ThreePointsFieldGoalPourcentage = table.Column<decimal>(nullable: false),
                    ThreePointsFieldGoalAttempted = table.Column<int>(nullable: false),
                    ThreePointsFieldGoalMade = table.Column<int>(nullable: false),
                    FieldGoalPourcentage = table.Column<decimal>(nullable: false),
                    FieldGoalAttempted = table.Column<int>(nullable: false),
                    FieldGoalMade = table.Column<int>(nullable: false),
                    FreeTrowPourcentage = table.Column<decimal>(nullable: false),
                    FreeTrowAttempted = table.Column<int>(nullable: false),
                    FreeTrowMade = table.Column<int>(nullable: false),
                    Minutes = table.Column<DateTime>(nullable: false),
                    OffensiveRebound = table.Column<int>(nullable: false),
                    PersonnalFoul = table.Column<int>(nullable: false),
                    Points = table.Column<int>(nullable: false),
                    Rebound = table.Column<int>(nullable: false),
                    Steal = table.Column<int>(nullable: false),
                    Turnover = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false),
                    MatchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.StatisticId);
                    table.ForeignKey(
                        name: "FK_Statistics_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "MatchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Statistics_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Statistics_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Genders_Name",
                table: "Genders",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_HomeTeamId",
                table: "Matches",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_SeasonId",
                table: "Matches",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_VisitorTeamId",
                table: "Matches",
                column: "VisitorTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_GenderId",
                table: "Players",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayersTeams_TeamId",
                table: "PlayersTeams",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_GenderId_Year",
                table: "Seasons",
                columns: new[] { "GenderId", "Year" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SeasonsTeams_SeasonId",
                table: "SeasonsTeams",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_MatchId",
                table: "Statistics",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_PlayerId",
                table: "Statistics",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_TeamId",
                table: "Statistics",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_GenderId",
                table: "Teams",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Name_GenderId",
                table: "Teams",
                columns: new[] { "Name", "GenderId" },
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayersTeams");

            migrationBuilder.DropTable(
                name: "SeasonsTeams");

            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "Genders");
        }
    }
}
