using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Jig.JigArchitect.Manual.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ApplicationId);
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    ClaimId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.ClaimId);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    LoginId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Password = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.LoginId);
                });

            migrationBuilder.CreateTable(
                name: "Schemas",
                columns: table => new
                {
                    SchemaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schemas", x => x.SchemaId);
                });

            migrationBuilder.CreateTable(
                name: "LoginClaims",
                columns: table => new
                {
                    ClaimId = table.Column<int>(nullable: false),
                    LoginId = table.Column<int>(nullable: false),
                    LoginClaimId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginClaims", x => new { x.ClaimId, x.LoginId });
                    table.ForeignKey(
                        name: "FK_LoginClaims_Claims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "Claims",
                        principalColumn: "ClaimId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoginClaims_Logins_LoginId",
                        column: x => x.LoginId,
                        principalTable: "Logins",
                        principalColumn: "LoginId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entities",
                columns: table => new
                {
                    EntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    PluralName = table.Column<string>(nullable: true),
                    SchemaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_Entities_Schemas_SchemaId",
                        column: x => x.SchemaId,
                        principalTable: "Schemas",
                        principalColumn: "SchemaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EndPointModels",
                columns: table => new
                {
                    EndPointModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntityId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndPointModels", x => x.EndPointModelId);
                    table.ForeignKey(
                        name: "FK_EndPointModels_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    PropertyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntityId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    PropertyType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_Properties_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Relationships",
                columns: table => new
                {
                    RelationshipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChildEntityEntityId = table.Column<int>(nullable: false),
                    ParentEntityEntityId = table.Column<int>(nullable: false),
                    RelationshipType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationships", x => x.RelationshipId);
                    table.ForeignKey(
                        name: "FK_Relationships_Entities_ChildEntityEntityId",
                        column: x => x.ChildEntityEntityId,
                        principalTable: "Entities",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Relationships_Entities_ParentEntityEntityId",
                        column: x => x.ParentEntityEntityId,
                        principalTable: "Entities",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnumProperties",
                columns: table => new
                {
                    EnumPropertyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    PropertyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnumProperties", x => x.EnumPropertyId);
                    table.ForeignKey(
                        name: "FK_EnumProperties_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IntProperties",
                columns: table => new
                {
                    IntPropertyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaxValue = table.Column<int>(nullable: false),
                    MinValue = table.Column<int>(nullable: false),
                    PropertyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntProperties", x => x.IntPropertyId);
                    table.ForeignKey(
                        name: "FK_IntProperties_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataSourceRelations",
                columns: table => new
                {
                    DataSourceRelationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntityRelationRelationshipId = table.Column<int>(nullable: true),
                    RecursiveRelationDataSourceRelationId = table.Column<int>(nullable: true),
                    UseChildEntity = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSourceRelations", x => x.DataSourceRelationId);
                    table.ForeignKey(
                        name: "FK_DataSourceRelations_Relationships_EntityRelationRelationshipId",
                        column: x => x.EntityRelationRelationshipId,
                        principalTable: "Relationships",
                        principalColumn: "RelationshipId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataSourceRelations_DataSourceRelations_RecursiveRelationDataSourceRelationId",
                        column: x => x.RecursiveRelationDataSourceRelationId,
                        principalTable: "DataSourceRelations",
                        principalColumn: "DataSourceRelationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnumPropertyValues",
                columns: table => new
                {
                    EnumPropertyValueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EnumPropertyId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnumPropertyValues", x => x.EnumPropertyValueId);
                    table.ForeignKey(
                        name: "FK_EnumPropertyValues_EnumProperties_EnumPropertyId",
                        column: x => x.EnumPropertyId,
                        principalTable: "EnumProperties",
                        principalColumn: "EnumPropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataSources",
                columns: table => new
                {
                    DataSourceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataSourceRelationId = table.Column<int>(nullable: true),
                    EntityPropertyPropertyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSources", x => x.DataSourceId);
                    table.ForeignKey(
                        name: "FK_DataSources_DataSourceRelations_DataSourceRelationId",
                        column: x => x.DataSourceRelationId,
                        principalTable: "DataSourceRelations",
                        principalColumn: "DataSourceRelationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DataSources_Properties_EntityPropertyPropertyId",
                        column: x => x.EntityPropertyPropertyId,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EndPoints",
                columns: table => new
                {
                    EndPointId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomEndPoint = table.Column<bool>(nullable: false),
                    EndPointModelId = table.Column<int>(nullable: false),
                    EndPointType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RootEndPointToRootEntityDataSourceId = table.Column<int>(nullable: true),
                    RootEntityEntityId = table.Column<int>(nullable: true),
                    Route = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndPoints", x => x.EndPointId);
                    table.ForeignKey(
                        name: "FK_EndPoints_EndPointModels_EndPointModelId",
                        column: x => x.EndPointModelId,
                        principalTable: "EndPointModels",
                        principalColumn: "EndPointModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EndPoints_DataSources_RootEndPointToRootEntityDataSourceId",
                        column: x => x.RootEndPointToRootEntityDataSourceId,
                        principalTable: "DataSources",
                        principalColumn: "DataSourceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EndPoints_Entities_RootEntityEntityId",
                        column: x => x.RootEntityEntityId,
                        principalTable: "Entities",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EndPointProperties",
                columns: table => new
                {
                    EndPointPropertyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataSourceId = table.Column<int>(nullable: true),
                    EndPointPropertyType = table.Column<int>(nullable: false),
                    EntityId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndPointProperties", x => x.EndPointPropertyId);
                    table.ForeignKey(
                        name: "FK_EndPointProperties_DataSources_DataSourceId",
                        column: x => x.DataSourceId,
                        principalTable: "DataSources",
                        principalColumn: "DataSourceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EndPointProperties_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeleteEndPoints",
                columns: table => new
                {
                    DeleteEndPointId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EndPointId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeleteEndPoints", x => x.DeleteEndPointId);
                    table.ForeignKey(
                        name: "FK_DeleteEndPoints_EndPoints_EndPointId",
                        column: x => x.EndPointId,
                        principalTable: "EndPoints",
                        principalColumn: "EndPointId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EndPointParameters",
                columns: table => new
                {
                    EndPointParameterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataSourceId = table.Column<int>(nullable: true),
                    DataType = table.Column<string>(nullable: true),
                    EndPointParameterName = table.Column<string>(nullable: true),
                    ParametersEndPointId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndPointParameters", x => x.EndPointParameterId);
                    table.ForeignKey(
                        name: "FK_EndPointParameters_DataSources_DataSourceId",
                        column: x => x.DataSourceId,
                        principalTable: "DataSources",
                        principalColumn: "DataSourceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EndPointParameters_EndPoints_ParametersEndPointId",
                        column: x => x.ParametersEndPointId,
                        principalTable: "EndPoints",
                        principalColumn: "EndPointId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GetAllEndPoints",
                columns: table => new
                {
                    GetAllEndPointId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EndPointId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetAllEndPoints", x => x.GetAllEndPointId);
                    table.ForeignKey(
                        name: "FK_GetAllEndPoints_EndPoints_EndPointId",
                        column: x => x.EndPointId,
                        principalTable: "EndPoints",
                        principalColumn: "EndPointId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GetDetailsEndPoints",
                columns: table => new
                {
                    GetDetailsEndPointId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EndPointId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetDetailsEndPoints", x => x.GetDetailsEndPointId);
                    table.ForeignKey(
                        name: "FK_GetDetailsEndPoints_EndPoints_EndPointId",
                        column: x => x.EndPointId,
                        principalTable: "EndPoints",
                        principalColumn: "EndPointId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostEndPoints",
                columns: table => new
                {
                    PostEndPointId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EndPointId = table.Column<int>(nullable: false),
                    InputModelEndPointModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostEndPoints", x => x.PostEndPointId);
                    table.ForeignKey(
                        name: "FK_PostEndPoints_EndPoints_EndPointId",
                        column: x => x.EndPointId,
                        principalTable: "EndPoints",
                        principalColumn: "EndPointId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostEndPoints_EndPointModels_InputModelEndPointModelId",
                        column: x => x.InputModelEndPointModelId,
                        principalTable: "EndPointModels",
                        principalColumn: "EndPointModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PutEndPoints",
                columns: table => new
                {
                    PutEndPointId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EndPointId = table.Column<int>(nullable: false),
                    InputModelEndPointModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PutEndPoints", x => x.PutEndPointId);
                    table.ForeignKey(
                        name: "FK_PutEndPoints_EndPoints_EndPointId",
                        column: x => x.EndPointId,
                        principalTable: "EndPoints",
                        principalColumn: "EndPointId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PutEndPoints_EndPointModels_InputModelEndPointModelId",
                        column: x => x.InputModelEndPointModelId,
                        principalTable: "EndPointModels",
                        principalColumn: "EndPointModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EndPointCollectionProperties",
                columns: table => new
                {
                    EndPointCollectionPropertyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EndPointPropertyId = table.Column<int>(nullable: false),
                    PropertiesEndPointPropertyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndPointCollectionProperties", x => x.EndPointCollectionPropertyId);
                    table.ForeignKey(
                        name: "FK_EndPointCollectionProperties_EndPointProperties_EndPointPropertyId",
                        column: x => x.EndPointPropertyId,
                        principalTable: "EndPointProperties",
                        principalColumn: "EndPointPropertyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EndPointCollectionProperties_EndPointProperties_PropertiesEndPointPropertyId",
                        column: x => x.PropertiesEndPointPropertyId,
                        principalTable: "EndPointProperties",
                        principalColumn: "EndPointPropertyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EndPointDefaultProperties",
                columns: table => new
                {
                    EndPointDefaultPropertyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataType = table.Column<string>(nullable: true),
                    EndPointPropertyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndPointDefaultProperties", x => x.EndPointDefaultPropertyId);
                    table.ForeignKey(
                        name: "FK_EndPointDefaultProperties_EndPointProperties_EndPointPropertyId",
                        column: x => x.EndPointPropertyId,
                        principalTable: "EndPointProperties",
                        principalColumn: "EndPointPropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EndPointModelProperties",
                columns: table => new
                {
                    EndPointModelPropertyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EndPointModelId = table.Column<int>(nullable: false),
                    EndPointPropertyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndPointModelProperties", x => x.EndPointModelPropertyId);
                    table.ForeignKey(
                        name: "FK_EndPointModelProperties_EndPointModels_EndPointModelId",
                        column: x => x.EndPointModelId,
                        principalTable: "EndPointModels",
                        principalColumn: "EndPointModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EndPointModelProperties_EndPointProperties_EndPointPropertyId",
                        column: x => x.EndPointPropertyId,
                        principalTable: "EndPointProperties",
                        principalColumn: "EndPointPropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataSources_DataSourceRelationId",
                table: "DataSources",
                column: "DataSourceRelationId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSources_EntityPropertyPropertyId",
                table: "DataSources",
                column: "EntityPropertyPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSourceRelations_EntityRelationRelationshipId",
                table: "DataSourceRelations",
                column: "EntityRelationRelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_DataSourceRelations_RecursiveRelationDataSourceRelationId",
                table: "DataSourceRelations",
                column: "RecursiveRelationDataSourceRelationId");

            migrationBuilder.CreateIndex(
                name: "IX_DeleteEndPoints_EndPointId",
                table: "DeleteEndPoints",
                column: "EndPointId");

            migrationBuilder.CreateIndex(
                name: "IX_EndPoints_EndPointModelId",
                table: "EndPoints",
                column: "EndPointModelId");

            migrationBuilder.CreateIndex(
                name: "IX_EndPoints_RootEndPointToRootEntityDataSourceId",
                table: "EndPoints",
                column: "RootEndPointToRootEntityDataSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_EndPoints_RootEntityEntityId",
                table: "EndPoints",
                column: "RootEntityEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EndPointCollectionProperties_EndPointPropertyId",
                table: "EndPointCollectionProperties",
                column: "EndPointPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_EndPointCollectionProperties_PropertiesEndPointPropertyId",
                table: "EndPointCollectionProperties",
                column: "PropertiesEndPointPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_EndPointDefaultProperties_EndPointPropertyId",
                table: "EndPointDefaultProperties",
                column: "EndPointPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_EndPointModels_EntityId",
                table: "EndPointModels",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EndPointModelProperties_EndPointModelId",
                table: "EndPointModelProperties",
                column: "EndPointModelId");

            migrationBuilder.CreateIndex(
                name: "IX_EndPointModelProperties_EndPointPropertyId",
                table: "EndPointModelProperties",
                column: "EndPointPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_EndPointParameters_DataSourceId",
                table: "EndPointParameters",
                column: "DataSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_EndPointParameters_ParametersEndPointId",
                table: "EndPointParameters",
                column: "ParametersEndPointId");

            migrationBuilder.CreateIndex(
                name: "IX_EndPointProperties_DataSourceId",
                table: "EndPointProperties",
                column: "DataSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_EndPointProperties_EntityId",
                table: "EndPointProperties",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Entities_SchemaId",
                table: "Entities",
                column: "SchemaId");

            migrationBuilder.CreateIndex(
                name: "IX_EnumProperties_PropertyId",
                table: "EnumProperties",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_EnumPropertyValues_EnumPropertyId",
                table: "EnumPropertyValues",
                column: "EnumPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_GetAllEndPoints_EndPointId",
                table: "GetAllEndPoints",
                column: "EndPointId");

            migrationBuilder.CreateIndex(
                name: "IX_GetDetailsEndPoints_EndPointId",
                table: "GetDetailsEndPoints",
                column: "EndPointId");

            migrationBuilder.CreateIndex(
                name: "IX_IntProperties_PropertyId",
                table: "IntProperties",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_LoginClaims_ClaimId",
                table: "LoginClaims",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_LoginClaims_LoginId",
                table: "LoginClaims",
                column: "LoginId");

            migrationBuilder.CreateIndex(
                name: "IX_PostEndPoints_EndPointId",
                table: "PostEndPoints",
                column: "EndPointId");

            migrationBuilder.CreateIndex(
                name: "IX_PostEndPoints_InputModelEndPointModelId",
                table: "PostEndPoints",
                column: "InputModelEndPointModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_EntityId",
                table: "Properties",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PutEndPoints_EndPointId",
                table: "PutEndPoints",
                column: "EndPointId");

            migrationBuilder.CreateIndex(
                name: "IX_PutEndPoints_InputModelEndPointModelId",
                table: "PutEndPoints",
                column: "InputModelEndPointModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Relationships_ChildEntityEntityId",
                table: "Relationships",
                column: "ChildEntityEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Relationships_ParentEntityEntityId",
                table: "Relationships",
                column: "ParentEntityEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "DeleteEndPoints");

            migrationBuilder.DropTable(
                name: "EndPointCollectionProperties");

            migrationBuilder.DropTable(
                name: "EndPointDefaultProperties");

            migrationBuilder.DropTable(
                name: "EndPointModelProperties");

            migrationBuilder.DropTable(
                name: "EndPointParameters");

            migrationBuilder.DropTable(
                name: "EnumPropertyValues");

            migrationBuilder.DropTable(
                name: "GetAllEndPoints");

            migrationBuilder.DropTable(
                name: "GetDetailsEndPoints");

            migrationBuilder.DropTable(
                name: "IntProperties");

            migrationBuilder.DropTable(
                name: "LoginClaims");

            migrationBuilder.DropTable(
                name: "PostEndPoints");

            migrationBuilder.DropTable(
                name: "PutEndPoints");

            migrationBuilder.DropTable(
                name: "EndPointProperties");

            migrationBuilder.DropTable(
                name: "EnumProperties");

            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "EndPoints");

            migrationBuilder.DropTable(
                name: "EndPointModels");

            migrationBuilder.DropTable(
                name: "DataSources");

            migrationBuilder.DropTable(
                name: "DataSourceRelations");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Relationships");

            migrationBuilder.DropTable(
                name: "Entities");

            migrationBuilder.DropTable(
                name: "Schemas");
        }
    }
}
