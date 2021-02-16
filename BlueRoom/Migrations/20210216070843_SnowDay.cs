using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlueRoom.Migrations
{
    public partial class SnowDay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "artist",
                columns: table => new
                {
                    ArtistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_artist", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "locale",
                columns: table => new
                {
                    LocaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locale", x => x.LocaleId);
                });

            migrationBuilder.CreateTable(
                name: "note",
                columns: table => new
                {
                    NoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Index = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_note", x => x.NoteId);
                });

            migrationBuilder.CreateTable(
                name: "song",
                columns: table => new
                {
                    SongId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalArtistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_song", x => x.SongId);
                    table.ForeignKey(
                        name: "FK_song_artist_OriginalArtistId",
                        column: x => x.OriginalArtistId,
                        principalTable: "artist",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "venue",
                columns: table => new
                {
                    VenueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocaleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_venue", x => x.VenueId);
                    table.ForeignKey(
                        name: "FK_venue_locale_LocaleId",
                        column: x => x.LocaleId,
                        principalTable: "locale",
                        principalColumn: "LocaleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "external_media_object",
                columns: table => new
                {
                    ExternalMediaObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    SongId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_external_media_object", x => x.ExternalMediaObjectId);
                    table.ForeignKey(
                        name: "FK_external_media_object_song_SongId",
                        column: x => x.SongId,
                        principalTable: "song",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "setlist",
                columns: table => new
                {
                    SetlistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VenueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PerformingArtistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_setlist", x => x.SetlistId);
                    table.ForeignKey(
                        name: "FK_setlist_artist_PerformingArtistId",
                        column: x => x.PerformingArtistId,
                        principalTable: "artist",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_setlist_venue_VenueId",
                        column: x => x.VenueId,
                        principalTable: "venue",
                        principalColumn: "VenueId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistExternalMediaObject",
                columns: table => new
                {
                    ArtistsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExternalMediaObjectsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistExternalMediaObject", x => new { x.ArtistsId, x.ExternalMediaObjectsId });
                    table.ForeignKey(
                        name: "FK_ArtistExternalMediaObject_artist_ArtistsId",
                        column: x => x.ArtistsId,
                        principalTable: "artist",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistExternalMediaObject_external_media_object_ExternalMediaObjectsId",
                        column: x => x.ExternalMediaObjectsId,
                        principalTable: "external_media_object",
                        principalColumn: "ExternalMediaObjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SetlistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_comment_setlist_SetlistId",
                        column: x => x.SetlistId,
                        principalTable: "setlist",
                        principalColumn: "SetlistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExternalMediaObjectSetlist",
                columns: table => new
                {
                    ExternalMediaObjectsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SetlistsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalMediaObjectSetlist", x => new { x.ExternalMediaObjectsId, x.SetlistsId });
                    table.ForeignKey(
                        name: "FK_ExternalMediaObjectSetlist_external_media_object_ExternalMediaObjectsId",
                        column: x => x.ExternalMediaObjectsId,
                        principalTable: "external_media_object",
                        principalColumn: "ExternalMediaObjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExternalMediaObjectSetlist_setlist_SetlistsId",
                        column: x => x.SetlistsId,
                        principalTable: "setlist",
                        principalColumn: "SetlistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NoteSetlist",
                columns: table => new
                {
                    NotesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SetlistsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteSetlist", x => new { x.NotesId, x.SetlistsId });
                    table.ForeignKey(
                        name: "FK_NoteSetlist_note_NotesId",
                        column: x => x.NotesId,
                        principalTable: "note",
                        principalColumn: "NoteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteSetlist_setlist_SetlistsId",
                        column: x => x.SetlistsId,
                        principalTable: "setlist",
                        principalColumn: "SetlistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "song_performance",
                columns: table => new
                {
                    SongPerformanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SetIndex = table.Column<int>(type: "int", nullable: false),
                    SetlistSongIndex = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: true),
                    MediaLinkId = table.Column<int>(type: "int", nullable: true),
                    MediaLinkId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SetlistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SongId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_song_performance", x => x.SongPerformanceId);
                    table.ForeignKey(
                        name: "FK_song_performance_external_media_object_MediaLinkId1",
                        column: x => x.MediaLinkId1,
                        principalTable: "external_media_object",
                        principalColumn: "ExternalMediaObjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_song_performance_setlist_SetlistId",
                        column: x => x.SetlistId,
                        principalTable: "setlist",
                        principalColumn: "SetlistId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_song_performance_song_SongId",
                        column: x => x.SongId,
                        principalTable: "song",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NoteSongPerformance",
                columns: table => new
                {
                    NotesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SongPerformancessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteSongPerformance", x => new { x.NotesId, x.SongPerformancessId });
                    table.ForeignKey(
                        name: "FK_NoteSongPerformance_note_NotesId",
                        column: x => x.NotesId,
                        principalTable: "note",
                        principalColumn: "NoteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteSongPerformance_song_performance_SongPerformancessId",
                        column: x => x.SongPerformancessId,
                        principalTable: "song_performance",
                        principalColumn: "SongPerformanceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistExternalMediaObject_ExternalMediaObjectsId",
                table: "ArtistExternalMediaObject",
                column: "ExternalMediaObjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_comment_SetlistId",
                table: "comment",
                column: "SetlistId");

            migrationBuilder.CreateIndex(
                name: "IX_external_media_object_SongId",
                table: "external_media_object",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalMediaObjectSetlist_SetlistsId",
                table: "ExternalMediaObjectSetlist",
                column: "SetlistsId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteSetlist_SetlistsId",
                table: "NoteSetlist",
                column: "SetlistsId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteSongPerformance_SongPerformancessId",
                table: "NoteSongPerformance",
                column: "SongPerformancessId");

            migrationBuilder.CreateIndex(
                name: "IX_setlist_PerformingArtistId",
                table: "setlist",
                column: "PerformingArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_setlist_VenueId",
                table: "setlist",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_song_OriginalArtistId",
                table: "song",
                column: "OriginalArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_song_performance_MediaLinkId1",
                table: "song_performance",
                column: "MediaLinkId1");

            migrationBuilder.CreateIndex(
                name: "IX_song_performance_SetlistId",
                table: "song_performance",
                column: "SetlistId");

            migrationBuilder.CreateIndex(
                name: "IX_song_performance_SongId",
                table: "song_performance",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_venue_LocaleId",
                table: "venue",
                column: "LocaleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistExternalMediaObject");

            migrationBuilder.DropTable(
                name: "comment");

            migrationBuilder.DropTable(
                name: "ExternalMediaObjectSetlist");

            migrationBuilder.DropTable(
                name: "NoteSetlist");

            migrationBuilder.DropTable(
                name: "NoteSongPerformance");

            migrationBuilder.DropTable(
                name: "note");

            migrationBuilder.DropTable(
                name: "song_performance");

            migrationBuilder.DropTable(
                name: "external_media_object");

            migrationBuilder.DropTable(
                name: "setlist");

            migrationBuilder.DropTable(
                name: "song");

            migrationBuilder.DropTable(
                name: "venue");

            migrationBuilder.DropTable(
                name: "artist");

            migrationBuilder.DropTable(
                name: "locale");
        }
    }
}
