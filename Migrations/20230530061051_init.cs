using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalvinSAD.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MiddleName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Abbreviation = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Type = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Key = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    StartTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PatientID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Visit = table.Column<int>(type: "int", nullable: false),
                    FDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Appointments_Clients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Clients",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ClientID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MiddleName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RoleID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AppointmentID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Payments_Appointments_AppointmentID",
                        column: x => x.AppointmentID,
                        principalTable: "Appointments",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AppointmentID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Providers_Appointments_AppointmentID",
                        column: x => x.AppointmentID,
                        principalTable: "Appointments",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AppointmentID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Appointments_AppointmentID",
                        column: x => x.AppointmentID,
                        principalTable: "Appointments",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    RoleID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApptPayment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AppointmentId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    FindingId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApptPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApptPayment_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ApptPayment_Payments_FindingId",
                        column: x => x.FindingId,
                        principalTable: "Payments",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApptProviders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProviderId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    AppointmetId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    AppointmentID = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApptProviders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApptProviders_Appointments_AppointmentID",
                        column: x => x.AppointmentID,
                        principalTable: "Appointments",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ApptProviders_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ApptSevices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AppointmentId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    ServiceId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApptSevices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApptSevices_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ApptSevices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ID", "Address", "BirthDate", "FirstName", "Gender", "LastName", "MiddleName" },
                values: new object[,]
                {
                    { new Guid("2b792220-f333-49ec-abe2-3a6fc4edb0c2"), "Luakan,Dinalupihan, Bataan", new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luisa Katrina", 0, "Reyes", "Pangilinan" },
                    { new Guid("5a7e7bc3-8816-41df-b44d-eeb60ae99b5b"), "Luakan,Dinalupihan, Bataan", new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clarissa Joy", 0, "Flores", "Gozon" },
                    { new Guid("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"), "Bacong,Hermosa, Bataan", new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Raniel", 1, "David", "Mallari" }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "ID", "AppointmentID", "FName" },
                values: new object[,]
                {
                    { new Guid("332d1fb4-35f1-48d8-ac19-f66472fce607"), null, "Debit Card" },
                    { new Guid("629d1da5-bf42-4dd5-9eda-614ba1260f03"), null, "Mobile Payment" },
                    { new Guid("672a4093-269e-47aa-879c-738cf2bf5e55"), null, "Checks" },
                    { new Guid("ab7f6ecf-7e82-4281-b90d-69f4ef72b66a"), null, "Electronic Bank Transfer" },
                    { new Guid("efd1381a-4c3d-4260-aaf2-04a0a26591bc"), null, "Cash" }
                });

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "Id", "AppointmentID", "Name" },
                values: new object[,]
                {
                    { new Guid("3042ec44-a9b3-4bee-8a3d-14fd9f5167f7"), null, "VANGIE" },
                    { new Guid("70b4d9b7-e5bf-4da4-a355-a0af2da1d587"), null, "SID" },
                    { new Guid("7f28dca4-e0f4-4798-a823-f44cdcd2a3b0"), null, "CJ" },
                    { new Guid("912f8c3e-3ca7-4703-a858-2b9bc7612096"), null, "GING" },
                    { new Guid("9f87d3db-3842-4a4d-8552-b568c7f44620"), null, "5" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "Abbreviation", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a"), "Pt", "One who receives medical treatment", "patient" },
                    { new Guid("54f00f70-72b8-4d34-a953-83321ff6b101"), "Adm", "One who manages the system", "admin" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "AppointmentID", "Name" },
                values: new object[,]
                {
                    { new Guid("0bd555b4-5d90-4033-abd7-2b19dfce9f41"), null, "Manicure" },
                    { new Guid("10cbac3c-2dbf-45c9-8832-e6d2dd0b2168"), null, "Foot spa" },
                    { new Guid("32d18f17-4f8f-4534-9394-703261e2390b"), null, "Body Massage" },
                    { new Guid("e0d9efd5-c988-4692-aafd-c0096b0093ff"), null, "Pedicure" }
                });

            migrationBuilder.InsertData(
                table: "UserLogins",
                columns: new[] { "ID", "Key", "Type", "UserID", "Value" },
                values: new object[,]
                {
                    { new Guid("4760ace8-5848-4d8c-8fd9-286bf33d6d09"), "IsActive", "General", new Guid("7e5e4f74-9902-43da-9974-4b2a08814398"), "true" },
                    { new Guid("47942bd7-37cf-4a0c-a4e5-04e3c4e211be"), "LoginRetries", "General", new Guid("00acfb7f-6c90-459a-b53f-bf73ddac85b4"), "0" },
                    { new Guid("47c7bfe9-8d9d-42c7-9b31-8d76dd028079"), "LoginRetries", "General", new Guid("1bd5f519-b891-4491-9a7c-a86cd0c2a15e"), "0" },
                    { new Guid("4e60af73-a47a-4e85-aef2-acec3e7e2d28"), "Password", "General", new Guid("1bd5f519-b891-4491-9a7c-a86cd0c2a15e"), "$2a$11$gZfAyzkqusAv/ZhSR2YXouYeg99H4lGaODp4uOHMPsw5j8lp8B2wO" },
                    { new Guid("6211da11-be82-4cbc-8588-91ca023e4da5"), "Password", "General", new Guid("0352c124-f290-4f99-b1a5-e235cafcd836"), "$2a$11$zXujKkUmz4JwsRZrTtgdYugkPxOUlb7DkUZ1pV1PwCV6gcadgqO16" },
                    { new Guid("75a93ef0-c4b4-4c53-83aa-e5de165233b5"), "LoginRetries", "General", new Guid("0352c124-f290-4f99-b1a5-e235cafcd836"), "0" },
                    { new Guid("81f89749-9d28-48b7-85e4-b5a1144a1365"), "Password", "General", new Guid("d7dbd16f-1c71-4415-a147-22a2b428bf95"), "$2a$11$kmtJOUCz0cEKCY6PG5U0X.83eNkkHVaNGDa4Z9Y3D55zcM8Cs.I5y" },
                    { new Guid("847d8e91-150e-4a5e-929a-1c1e24197694"), "LoginRetries", "General", new Guid("7e5e4f74-9902-43da-9974-4b2a08814398"), "0" },
                    { new Guid("9fb47c97-0f03-48a7-9f6c-d0bcd4f52954"), "IsActive", "General", new Guid("00acfb7f-6c90-459a-b53f-bf73ddac85b4"), "true" },
                    { new Guid("c140470d-4ae7-4258-8543-aeb3b22ca79c"), "IsActive", "General", new Guid("d7dbd16f-1c71-4415-a147-22a2b428bf95"), "true" },
                    { new Guid("c8b508ed-b0aa-4e8d-9ddf-2a58916503e2"), "Password", "General", new Guid("7e5e4f74-9902-43da-9974-4b2a08814398"), "$2a$11$uBBzjFKzFBxV4KvGZsJeVuDAWIeU8sQfCFKAGFhd/95reZ/Hjv4ki" },
                    { new Guid("cebece6f-e3bf-4448-93f7-6600437f0fdd"), "IsActive", "General", new Guid("0352c124-f290-4f99-b1a5-e235cafcd836"), "true" },
                    { new Guid("e5914513-c1ae-4dff-a7aa-97f4cc435b42"), "LoginRetries", "General", new Guid("d7dbd16f-1c71-4415-a147-22a2b428bf95"), "0" },
                    { new Guid("eecd8aad-67f3-4ecc-9492-a462feb57faa"), "Password", "General", new Guid("00acfb7f-6c90-459a-b53f-bf73ddac85b4"), "$2a$11$2iYZFb6AprWXhZYTnNjO/.ioNa67G3.gnichLh5R3HXni438jvjiq" },
                    { new Guid("f1029800-e93d-420c-94ee-8c1fe3bd1e5f"), "IsActive", "General", new Guid("1bd5f519-b891-4491-9a7c-a86cd0c2a15e"), "true" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Address", "BirthDate", "ClientID", "Email", "FirstName", "Gender", "LastName", "MiddleName", "RoleID" },
                values: new object[,]
                {
                    { new Guid("00acfb7f-6c90-459a-b53f-bf73ddac85b4"), "Dinalupihan, Orani , Bataan", new DateTime(2002, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Admin@yahoo.com", "Roberto", 0, "Escobar", "Adan", new Guid("54f00f70-72b8-4d34-a953-83321ff6b101") },
                    { new Guid("0352c124-f290-4f99-b1a5-e235cafcd836"), "Dinalupihan, Orani, Bataan", new DateTime(2001, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2b792220-f333-49ec-abe2-3a6fc4edb0c2"), "luisa@yahoo.com", "Luisa Katrina", 0, "Pangilinan", "Reyes", new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a") },
                    { new Guid("1bd5f519-b891-4491-9a7c-a86cd0c2a15e"), "Dinalupihan, Orani , Bataan", new DateTime(2002, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@yahoo.com", "Calvin", 0, "Admin", "NicDao", new Guid("54f00f70-72b8-4d34-a953-83321ff6b101") },
                    { new Guid("7e5e4f74-9902-43da-9974-4b2a08814398"), "Dinalupihan, Orani, Bataan", new DateTime(2001, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8664a4bd-0ec6-4aaa-83e6-7d2bd0315b5a"), "client@yahoo.com", "Calvin", 1, "CLient", "NicDao", new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a") },
                    { new Guid("d7dbd16f-1c71-4415-a147-22a2b428bf95"), "Dinalupihan, Orani, Bataan", new DateTime(2001, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5a7e7bc3-8816-41df-b44d-eeb60ae99b5b"), "joy@yahoo.com", "Clarissa Joy", 1, "Gozon", "Flores", new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleID", "UserID" },
                values: new object[,]
                {
                    { new Guid("3d1eccea-8f96-4838-80e7-e0a338439d66"), new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a"), new Guid("0352c124-f290-4f99-b1a5-e235cafcd836") },
                    { new Guid("50a5672a-79ab-430a-9384-b3576dba9b60"), new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a"), new Guid("d7dbd16f-1c71-4415-a147-22a2b428bf95") },
                    { new Guid("78197ad3-c2a2-49a8-91ad-a82b2a65acbb"), new Guid("54f00f70-72b8-4d34-a953-83321ff6b101"), new Guid("00acfb7f-6c90-459a-b53f-bf73ddac85b4") },
                    { new Guid("89549921-1f5f-4852-abfd-28b1adb1bcc2"), new Guid("2afa881f-e519-4e67-a841-e4a2630e8a2a"), new Guid("7e5e4f74-9902-43da-9974-4b2a08814398") },
                    { new Guid("b6889cbd-c9cc-4853-8197-ab2b7d88d923"), new Guid("54f00f70-72b8-4d34-a953-83321ff6b101"), new Guid("1bd5f519-b891-4491-9a7c-a86cd0c2a15e") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientID",
                table: "Appointments",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_ApptPayment_AppointmentId",
                table: "ApptPayment",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApptPayment_FindingId",
                table: "ApptPayment",
                column: "FindingId");

            migrationBuilder.CreateIndex(
                name: "IX_ApptProviders_AppointmentID",
                table: "ApptProviders",
                column: "AppointmentID");

            migrationBuilder.CreateIndex(
                name: "IX_ApptProviders_ProviderId",
                table: "ApptProviders",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ApptSevices_AppointmentId",
                table: "ApptSevices",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApptSevices_ServiceId",
                table: "ApptSevices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_AppointmentID",
                table: "Payments",
                column: "AppointmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_AppointmentID",
                table: "Providers",
                column: "AppointmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Services_AppointmentID",
                table: "Services",
                column: "AppointmentID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleID",
                table: "UserRoles",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserID",
                table: "UserRoles",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ClientID",
                table: "Users",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApptPayment");

            migrationBuilder.DropTable(
                name: "ApptProviders");

            migrationBuilder.DropTable(
                name: "ApptSevices");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
