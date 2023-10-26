using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntelAssessmentAPI.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    NickName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    ProfilePhoto = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Biography",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdProfile = table.Column<Guid>(type: "uuid", nullable: false),
                    Summary1 = table.Column<string>(type: "text", nullable: true),
                    Summary2 = table.Column<string>(type: "text", nullable: true),
                    Summary3 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biography", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Biography_Profile_IdProfile",
                        column: x => x.IdProfile,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Detail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdProfile = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Gender = table.Column<int>(type: "integer", nullable: true),
                    DateBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PassportNo = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    PhoneNo = table.Column<string>(type: "text", nullable: true),
                    Hobby = table.Column<string>(type: "text", nullable: true),
                    Skill = table.Column<string>(type: "text", nullable: true),
                    Pet = table.Column<string>(type: "text", nullable: true),
                    FreeTimeActivity = table.Column<string>(type: "text", nullable: true),
                    Interest = table.Column<string>(type: "text", nullable: true),
                    FavouriteFood = table.Column<string>(type: "text", nullable: true),
                    Weight = table.Column<double>(type: "double precision", nullable: true),
                    Height = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Detail_Profile_IdProfile",
                        column: x => x.IdProfile,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdProfile = table.Column<Guid>(type: "uuid", nullable: false),
                    InstitutionName = table.Column<string>(type: "text", nullable: true),
                    EducationLevel = table.Column<string>(type: "text", nullable: true),
                    StudyField = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Education_Profile_IdProfile",
                        column: x => x.IdProfile,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdProfile = table.Column<Guid>(type: "uuid", nullable: false),
                    ImagePath = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Profile_IdProfile",
                        column: x => x.IdProfile,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdProfile = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyName = table.Column<string>(type: "text", nullable: true),
                    Position = table.Column<string>(type: "text", nullable: true),
                    Department = table.Column<string>(type: "text", nullable: true),
                    JobDescription = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobHistory_Profile_IdProfile",
                        column: x => x.IdProfile,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocMed",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdProfile = table.Column<Guid>(type: "uuid", nullable: false),
                    NameOfMedia = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocMed", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocMed_Profile_IdProfile",
                        column: x => x.IdProfile,
                        principalTable: "Profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Biography_IdProfile",
                table: "Biography",
                column: "IdProfile");

            migrationBuilder.CreateIndex(
                name: "IX_Detail_IdProfile",
                table: "Detail",
                column: "IdProfile",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Education_IdProfile",
                table: "Education",
                column: "IdProfile");

            migrationBuilder.CreateIndex(
                name: "IX_Image_IdProfile",
                table: "Image",
                column: "IdProfile");

            migrationBuilder.CreateIndex(
                name: "IX_JobHistory_IdProfile",
                table: "JobHistory",
                column: "IdProfile");

            migrationBuilder.CreateIndex(
                name: "IX_SocMed_IdProfile",
                table: "SocMed",
                column: "IdProfile");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Biography");

            migrationBuilder.DropTable(
                name: "Detail");

            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "JobHistory");

            migrationBuilder.DropTable(
                name: "SocMed");

            migrationBuilder.DropTable(
                name: "Profile");
        }
    }
}
