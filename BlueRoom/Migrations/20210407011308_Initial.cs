using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueRoom.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Locale",
                columns: table => new
                {
                    LocaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locale", x => x.LocaleId);
                });

            migrationBuilder.CreateTable(
                name: "MediaType",
                columns: table => new
                {
                    MediaTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaType", x => x.MediaTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    NoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Index = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.NoteId);
                });

            migrationBuilder.CreateTable(
                name: "SetNumber",
                columns: table => new
                {
                    SetNumberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SetIndex = table.Column<int>(type: "int", nullable: false),
                    SetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullSet = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetNumber", x => x.SetNumberId);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    SongId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalArtistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.SongId);
                    table.ForeignKey(
                        name: "FK_Songs_Artists_OriginalArtistId",
                        column: x => x.OriginalArtistId,
                        principalTable: "Artists",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    VenueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocaleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.VenueId);
                    table.ForeignKey(
                        name: "FK_Venues_Locale_LocaleId",
                        column: x => x.LocaleId,
                        principalTable: "Locale",
                        principalColumn: "LocaleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExternalMediaObject",
                columns: table => new
                {
                    ExternalMediaObjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeMediaTypeId = table.Column<int>(type: "int", nullable: true),
                    SongId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalMediaObject", x => x.ExternalMediaObjectId);
                    table.ForeignKey(
                        name: "FK_ExternalMediaObject_MediaType_TypeMediaTypeId",
                        column: x => x.TypeMediaTypeId,
                        principalTable: "MediaType",
                        principalColumn: "MediaTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExternalMediaObject_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    ShowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VenueId = table.Column<int>(type: "int", nullable: false),
                    PerformingArtistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.ShowId);
                    table.ForeignKey(
                        name: "FK_Shows_Artists_PerformingArtistId",
                        column: x => x.PerformingArtistId,
                        principalTable: "Artists",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shows_Venues_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venues",
                        principalColumn: "VenueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistExternalMediaObject",
                columns: table => new
                {
                    ArtistsId = table.Column<int>(type: "int", nullable: false),
                    ExternalMediaObjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistExternalMediaObject", x => new { x.ArtistsId, x.ExternalMediaObjectsId });
                    table.ForeignKey(
                        name: "FK_ArtistExternalMediaObject_Artists_ArtistsId",
                        column: x => x.ArtistsId,
                        principalTable: "Artists",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistExternalMediaObject_ExternalMediaObject_ExternalMediaObjectsId",
                        column: x => x.ExternalMediaObjectsId,
                        principalTable: "ExternalMediaObject",
                        principalColumn: "ExternalMediaObjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShowId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comment_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "ShowId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExternalMediaObjectShow",
                columns: table => new
                {
                    ExternalMediaObjectsId = table.Column<int>(type: "int", nullable: false),
                    ShowsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalMediaObjectShow", x => new { x.ExternalMediaObjectsId, x.ShowsId });
                    table.ForeignKey(
                        name: "FK_ExternalMediaObjectShow_ExternalMediaObject_ExternalMediaObjectsId",
                        column: x => x.ExternalMediaObjectsId,
                        principalTable: "ExternalMediaObject",
                        principalColumn: "ExternalMediaObjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExternalMediaObjectShow_Shows_ShowsId",
                        column: x => x.ShowsId,
                        principalTable: "Shows",
                        principalColumn: "ShowId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NoteShow",
                columns: table => new
                {
                    NotesId = table.Column<int>(type: "int", nullable: false),
                    ShowsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteShow", x => new { x.NotesId, x.ShowsId });
                    table.ForeignKey(
                        name: "FK_NoteShow_Note_NotesId",
                        column: x => x.NotesId,
                        principalTable: "Note",
                        principalColumn: "NoteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteShow_Shows_ShowsId",
                        column: x => x.ShowsId,
                        principalTable: "Shows",
                        principalColumn: "ShowId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SongPerformance",
                columns: table => new
                {
                    SongPerformanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SetNumberId = table.Column<int>(type: "int", nullable: false),
                    SetSongIndex = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: true),
                    MediaLinkId = table.Column<int>(type: "int", nullable: true),
                    ShowId = table.Column<int>(type: "int", nullable: false),
                    SongId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongPerformance", x => x.SongPerformanceId);
                    table.ForeignKey(
                        name: "FK_SongPerformance_ExternalMediaObject_MediaLinkId",
                        column: x => x.MediaLinkId,
                        principalTable: "ExternalMediaObject",
                        principalColumn: "ExternalMediaObjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SongPerformance_SetNumber_SetNumberId",
                        column: x => x.SetNumberId,
                        principalTable: "SetNumber",
                        principalColumn: "SetNumberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongPerformance_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "ShowId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SongPerformance_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NoteSongPerformance",
                columns: table => new
                {
                    NotesId = table.Column<int>(type: "int", nullable: false),
                    SongPerformancessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteSongPerformance", x => new { x.NotesId, x.SongPerformancessId });
                    table.ForeignKey(
                        name: "FK_NoteSongPerformance_Note_NotesId",
                        column: x => x.NotesId,
                        principalTable: "Note",
                        principalColumn: "NoteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteSongPerformance_SongPerformance_SongPerformancessId",
                        column: x => x.SongPerformancessId,
                        principalTable: "SongPerformance",
                        principalColumn: "SongPerformanceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistExternalMediaObject_ExternalMediaObjectsId",
                table: "ArtistExternalMediaObject",
                column: "ExternalMediaObjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ShowId",
                table: "Comment",
                column: "ShowId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalMediaObject_SongId",
                table: "ExternalMediaObject",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalMediaObject_TypeMediaTypeId",
                table: "ExternalMediaObject",
                column: "TypeMediaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalMediaObjectShow_ShowsId",
                table: "ExternalMediaObjectShow",
                column: "ShowsId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteShow_ShowsId",
                table: "NoteShow",
                column: "ShowsId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteSongPerformance_SongPerformancessId",
                table: "NoteSongPerformance",
                column: "SongPerformancessId");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_PerformingArtistId",
                table: "Shows",
                column: "PerformingArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Shows_VenueId",
                table: "Shows",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_SongPerformance_MediaLinkId",
                table: "SongPerformance",
                column: "MediaLinkId");

            migrationBuilder.CreateIndex(
                name: "IX_SongPerformance_SetNumberId",
                table: "SongPerformance",
                column: "SetNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_SongPerformance_ShowId",
                table: "SongPerformance",
                column: "ShowId");

            migrationBuilder.CreateIndex(
                name: "IX_SongPerformance_SongId",
                table: "SongPerformance",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_OriginalArtistId",
                table: "Songs",
                column: "OriginalArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Venues_LocaleId",
                table: "Venues",
                column: "LocaleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistExternalMediaObject");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "ExternalMediaObjectShow");

            migrationBuilder.DropTable(
                name: "NoteShow");

            migrationBuilder.DropTable(
                name: "NoteSongPerformance");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "SongPerformance");

            migrationBuilder.DropTable(
                name: "ExternalMediaObject");

            migrationBuilder.DropTable(
                name: "SetNumber");

            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.DropTable(
                name: "MediaType");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Venues");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Locale");
        }
    }
}
