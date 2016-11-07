using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Jig.JigArchitect.Manual;

namespace Jig.JigArchitect.Manual.Migrations
{
    [DbContext(typeof(WrappedContext))]
    [Migration("20161106235511_migration4")]
    partial class migration4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.Application", b =>
                {
                    b.Property<int>("ApplicationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Icon");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ApplicationId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.Claim", b =>
                {
                    b.Property<int>("ClaimId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ClaimId");

                    b.ToTable("Claims");
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.DataSource", b =>
                {
                    b.Property<int>("DataSourceId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DataSourceRelationId");

                    b.Property<int?>("EntityPropertyPropertyId");

                    b.HasKey("DataSourceId");

                    b.HasIndex("DataSourceRelationId");

                    b.HasIndex("EntityPropertyPropertyId");

                    b.ToTable("DataSources");
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.DataSourceRelation", b =>
                {
                    b.Property<int>("DataSourceRelationId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EntityRelationRelationshipId");

                    b.Property<int?>("RecursiveRelationDataSourceRelationId");

                    b.Property<bool>("UseChildEntity");

                    b.HasKey("DataSourceRelationId");

                    b.HasIndex("EntityRelationRelationshipId");

                    b.HasIndex("RecursiveRelationDataSourceRelationId");

                    b.ToTable("DataSourceRelations");
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.DeleteEndPoint", b =>
                {
                    b.Property<int>("DeleteEndPointId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EndPointId");

                    b.HasKey("DeleteEndPointId");

                    b.HasIndex("EndPointId");

                    b.ToTable("DeleteEndPoints");
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.EndPoint", b =>
                {
                    b.Property<int>("EndPointId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CustomEndPoint");

                    b.Property<int>("EndPointModelId");

                    b.Property<int>("EndPointType");

                    b.Property<string>("Name");

                    b.Property<int?>("RootEndPointToRootEntityDataSourceId");

                    b.Property<int?>("RootEntityEntityId");

                    b.Property<string>("Route");

                    b.Property<int>("ServiceId");

                    b.HasKey("EndPointId");

                    b.HasIndex("EndPointModelId");

                    b.HasIndex("RootEndPointToRootEntityDataSourceId");

                    b.HasIndex("RootEntityEntityId");

                    b.HasIndex("ServiceId");

                    b.ToTable("EndPoints");
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.EndPointCollectionProperty", b =>
                {
                    b.Property<int>("EndPointCollectionPropertyId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EndPointPropertyId");

                    b.Property<int?>("PropertiesEndPointPropertyId");

                    b.HasKey("EndPointCollectionPropertyId");

                    b.HasIndex("EndPointPropertyId");

                    b.HasIndex("PropertiesEndPointPropertyId");

                    b.ToTable("EndPointCollectionProperties");
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.EndPointDefaultProperty", b =>
                {
                    b.Property<int>("EndPointDefaultPropertyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DataType");

                    b.Property<int>("EndPointPropertyId");

                    b.HasKey("EndPointDefaultPropertyId");

                    b.HasIndex("EndPointPropertyId");

                    b.ToTable("EndPointDefaultProperties");
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.EndPointModel", b =>
                {
                    b.Property<int>("EndPointModelId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EntityId");

                    b.Property<string>("Name");

                    b.HasKey("EndPointModelId");

                    b.HasIndex("EntityId");

                    b.ToTable("EndPointModels");
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.EndPointModelProperty", b =>
                {
                    b.Property<int>("EndPointModelPropertyId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EndPointModelId");

                    b.Property<int>("EndPointPropertyId");

                    b.HasKey("EndPointModelPropertyId");

                    b.HasIndex("EndPointModelId");

                    b.HasIndex("EndPointPropertyId");

                    b.ToTable("EndPointModelProperties");
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.EndPointParameter", b =>
                {
                    b.Property<int>("EndPointParameterId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DataSourceId");

                    b.Property<string>("DataType");

                    b.Property<string>("EndPointParameterName");

                    b.Property<int>("ParametersEndPointId");

                    b.HasKey("EndPointParameterId");

                    b.HasIndex("DataSourceId");

                    b.HasIndex("ParametersEndPointId");

                    b.ToTable("EndPointParameters");
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.EndPointProperty", b =>
                {
                    b.Property<int>("EndPointPropertyId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DataSourceId");

                    b.Property<int>("EndPointPropertyType");

                    b.Property<int>("EntityId");

                    b.Property<string>("Name");

                    b.HasKey("EndPointPropertyId");

                    b.HasIndex("DataSourceId");

                    b.HasIndex("EntityId");

                    b.ToTable("EndPointProperties");
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.Entity", b =>
                {
                    b.Property<int>("EntityId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PluralName");

                    b.Property<int>("SchemaId");

                    b.HasKey("EntityId");

                    b.HasIndex("SchemaId");

                    b.ToTable("Entities");
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.EnumProperty", b =>
                {
                    b.Property<int>("EnumPropertyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("PropertyId");

                    b.HasKey("EnumPropertyId");

                    b.HasIndex("PropertyId");

                    b.ToTable("EnumProperties");
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.EnumPropertyValue", b =>
                {
                    b.Property<int>("EnumPropertyValueId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EnumPropertyId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("EnumPropertyValueId");

                    b.HasIndex("EnumPropertyId");

                    b.ToTable("EnumPropertyValues");
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.GetAllEndPoint", b =>
                {
                    b.Property<int>("GetAllEndPointId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EndPointId");

                    b.HasKey("GetAllEndPointId");

                    b.HasIndex("EndPointId");

                    b.ToTable("GetAllEndPoints");
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.GetDetailsEndPoint", b =>
                {
                    b.Property<int>("GetDetailsEndPointId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EndPointId");

                    b.HasKey("GetDetailsEndPointId");

                    b.HasIndex("EndPointId");

                    b.ToTable("GetDetailsEndPoints");
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.IntProperty", b =>
                {
                    b.Property<int>("IntPropertyId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MaxValue");

                    b.Property<int>("MinValue");

                    b.Property<int>("PropertyId");

                    b.HasKey("IntPropertyId");

                    b.HasIndex("PropertyId");

                    b.ToTable("IntProperties");
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.Login", b =>
                {
                    b.Property<int>("LoginId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("LoginId");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.LoginClaim", b =>
                {
                    b.Property<int>("ClaimId");

                    b.Property<int>("LoginId");

                    b.Property<int>("LoginClaimId");

                    b.HasKey("ClaimId", "LoginId");

                    b.HasIndex("ClaimId");

                    b.HasIndex("LoginId");

                    b.ToTable("LoginClaims");
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.PostEndPoint", b =>
                {
                    b.Property<int>("PostEndPointId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EndPointId");

                    b.Property<int?>("InputModelEndPointModelId");

                    b.HasKey("PostEndPointId");

                    b.HasIndex("EndPointId");

                    b.HasIndex("InputModelEndPointModelId");

                    b.ToTable("PostEndPoints");
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.Property", b =>
                {
                    b.Property<int>("PropertyId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EntityId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("PropertyType");

                    b.HasKey("PropertyId");

                    b.HasIndex("EntityId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.PutEndPoint", b =>
                {
                    b.Property<int>("PutEndPointId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EndPointId");

                    b.Property<int?>("InputModelEndPointModelId");

                    b.HasKey("PutEndPointId");

                    b.HasIndex("EndPointId");

                    b.HasIndex("InputModelEndPointModelId");

                    b.ToTable("PutEndPoints");
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.Relationship", b =>
                {
                    b.Property<int>("RelationshipId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ChildEntityEntityId");

                    b.Property<int>("ParentEntityEntityId");

                    b.Property<int>("RelationshipType");

                    b.HasKey("RelationshipId");

                    b.HasIndex("ChildEntityEntityId");

                    b.HasIndex("ParentEntityEntityId");

                    b.ToTable("Relationships");
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.Schema", b =>
                {
                    b.Property<int>("SchemaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplicationId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("SchemaId");

                    b.HasIndex("ApplicationId");

                    b.ToTable("Schemas");
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplicationId");

                    b.Property<string>("Name");

                    b.Property<string>("PluralName");

                    b.HasKey("ServiceId");

                    b.HasIndex("ApplicationId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.DataSource", b =>
                {
                    b.HasOne("Jig.JigArchitect.Domain.Entities.DataSourceRelation")
                        .WithMany()
                        .HasForeignKey("DataSourceRelationId");

                    b.HasOne("Jig.JigArchitect.Domain.Entities.Property")
                        .WithMany()
                        .HasForeignKey("EntityPropertyPropertyId");
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.DataSourceRelation", b =>
                {
                    b.HasOne("Jig.JigArchitect.Domain.Entities.Relationship")
                        .WithMany()
                        .HasForeignKey("EntityRelationRelationshipId");

                    b.HasOne("Jig.JigArchitect.Domain.Entities.DataSourceRelation")
                        .WithMany()
                        .HasForeignKey("RecursiveRelationDataSourceRelationId");
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.DeleteEndPoint", b =>
                {
                    b.HasOne("Jig.JigArchitect.Domain.Entities.EndPoint")
                        .WithOne()
                        .HasForeignKey("Jig.JigArchitect.Domain.Entities.DeleteEndPoint", "EndPointId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.EndPoint", b =>
                {
                    b.HasOne("Jig.JigArchitect.Domain.Entities.EndPointModel")
                        .WithOne()
                        .HasForeignKey("Jig.JigArchitect.Domain.Entities.EndPoint", "EndPointModelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Jig.JigArchitect.Domain.Entities.DataSource")
                        .WithMany()
                        .HasForeignKey("RootEndPointToRootEntityDataSourceId");

                    b.HasOne("Jig.JigArchitect.Domain.Entities.Entity")
                        .WithMany()
                        .HasForeignKey("RootEntityEntityId");

                    b.HasOne("Jig.JigArchitect.Domain.Entities.Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.EndPointCollectionProperty", b =>
                {
                    b.HasOne("Jig.JigArchitect.Domain.Entities.EndPointProperty")
                        .WithMany()
                        .HasForeignKey("EndPointPropertyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Jig.JigArchitect.Domain.Entities.EndPointProperty")
                        .WithMany()
                        .HasForeignKey("PropertiesEndPointPropertyId");
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.EndPointDefaultProperty", b =>
                {
                    b.HasOne("Jig.JigArchitect.Domain.Entities.EndPointProperty")
                        .WithMany()
                        .HasForeignKey("EndPointPropertyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.EndPointModel", b =>
                {
                    b.HasOne("Jig.JigArchitect.Domain.Entities.Entity")
                        .WithMany()
                        .HasForeignKey("EntityId");
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.EndPointModelProperty", b =>
                {
                    b.HasOne("Jig.JigArchitect.Domain.Entities.EndPointModel")
                        .WithMany()
                        .HasForeignKey("EndPointModelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Jig.JigArchitect.Domain.Entities.EndPointProperty")
                        .WithMany()
                        .HasForeignKey("EndPointPropertyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.EndPointParameter", b =>
                {
                    b.HasOne("Jig.JigArchitect.Domain.Entities.DataSource")
                        .WithMany()
                        .HasForeignKey("DataSourceId");

                    b.HasOne("Jig.JigArchitect.Domain.Entities.EndPoint")
                        .WithMany()
                        .HasForeignKey("ParametersEndPointId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.EndPointProperty", b =>
                {
                    b.HasOne("Jig.JigArchitect.Domain.Entities.DataSource")
                        .WithMany()
                        .HasForeignKey("DataSourceId");

                    b.HasOne("Jig.JigArchitect.Domain.Entities.Entity")
                        .WithMany()
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.Entity", b =>
                {
                    b.HasOne("Jig.JigArchitect.Domain.Entities.Schema")
                        .WithMany()
                        .HasForeignKey("SchemaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.EnumProperty", b =>
                {
                    b.HasOne("Jig.JigArchitect.Domain.Entities.Property")
                        .WithOne()
                        .HasForeignKey("Jig.JigArchitect.Domain.Entities.EnumProperty", "PropertyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.EnumPropertyValue", b =>
                {
                    b.HasOne("Jig.JigArchitect.Domain.Entities.EnumProperty")
                        .WithMany()
                        .HasForeignKey("EnumPropertyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.GetAllEndPoint", b =>
                {
                    b.HasOne("Jig.JigArchitect.Domain.Entities.EndPoint")
                        .WithOne()
                        .HasForeignKey("Jig.JigArchitect.Domain.Entities.GetAllEndPoint", "EndPointId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.GetDetailsEndPoint", b =>
                {
                    b.HasOne("Jig.JigArchitect.Domain.Entities.EndPoint")
                        .WithOne()
                        .HasForeignKey("Jig.JigArchitect.Domain.Entities.GetDetailsEndPoint", "EndPointId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.IntProperty", b =>
                {
                    b.HasOne("Jig.JigArchitect.Domain.Entities.Property")
                        .WithOne()
                        .HasForeignKey("Jig.JigArchitect.Domain.Entities.IntProperty", "PropertyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.LoginClaim", b =>
                {
                    b.HasOne("Jig.JigArchitect.Domain.Entities.Claim")
                        .WithMany()
                        .HasForeignKey("ClaimId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Jig.JigArchitect.Domain.Entities.Login")
                        .WithMany()
                        .HasForeignKey("LoginId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.PostEndPoint", b =>
                {
                    b.HasOne("Jig.JigArchitect.Domain.Entities.EndPoint")
                        .WithOne()
                        .HasForeignKey("Jig.JigArchitect.Domain.Entities.PostEndPoint", "EndPointId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Jig.JigArchitect.Domain.Entities.EndPointModel")
                        .WithMany()
                        .HasForeignKey("InputModelEndPointModelId");
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.Property", b =>
                {
                    b.HasOne("Jig.JigArchitect.Domain.Entities.Entity")
                        .WithMany()
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.PutEndPoint", b =>
                {
                    b.HasOne("Jig.JigArchitect.Domain.Entities.EndPoint")
                        .WithOne()
                        .HasForeignKey("Jig.JigArchitect.Domain.Entities.PutEndPoint", "EndPointId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Jig.JigArchitect.Domain.Entities.EndPointModel")
                        .WithMany()
                        .HasForeignKey("InputModelEndPointModelId");
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.Relationship", b =>
                {
                    b.HasOne("Jig.JigArchitect.Domain.Entities.Entity")
                        .WithMany()
                        .HasForeignKey("ChildEntityEntityId");

                    b.HasOne("Jig.JigArchitect.Domain.Entities.Entity")
                        .WithMany()
                        .HasForeignKey("ParentEntityEntityId");
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.Schema", b =>
                {
                    b.HasOne("Jig.JigArchitect.Domain.Entities.Application")
                        .WithMany()
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Jig.JigArchitect.Domain.Entities.Service", b =>
                {
                    b.HasOne("Jig.JigArchitect.Domain.Entities.Application")
                        .WithMany()
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
