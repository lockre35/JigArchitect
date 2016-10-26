using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jig.JigArchitect.Domain.Entities;

namespace Jig.JigArchitect.Domain
{
    public class DomainContext : DbContext
    {
        public DomainContext() : base()
        {
        }

        public DbSet<Login> Logins { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<LoginClaim> LoginClaims { get; set; }
		public DbSet<Schema> Schemas { get; set; }
		public DbSet<Entity> Entities { get; set; }
		public DbSet<Property> Properties { get; set; }
		public DbSet<IntProperty> IntProperties { get; set; }
		public DbSet<EnumProperty> EnumProperties { get; set; }
		public DbSet<EnumPropertyValue> EnumPropertyValues { get; set; }
		public DbSet<Relationship> Relationships { get; set; }
		public DbSet<Application> Applications { get; set; }
		public DbSet<EndPoint> EndPoints { get; set; }
		public DbSet<GetAllEndPoint> GetAllEndPoints { get; set; }
		public DbSet<DeleteEndPoint> DeleteEndPoints { get; set; }
		public DbSet<PostEndPoint> PostEndPoints { get; set; }
		public DbSet<PutEndPoint> PutEndPoints { get; set; }
		public DbSet<GetDetailsEndPoint> GetDetailsEndPoints { get; set; }
		public DbSet<EndPointModel> EndPointModels { get; set; }
		public DbSet<EndPointProperty> EndPointProperties { get; set; }
		public DbSet<EndPointModelProperty> EndPointModelProperties { get; set; }
		public DbSet<EndPointCollectionProperty> EndPointCollectionProperties { get; set; }
		public DbSet<EndPointDefaultProperty> EndPointDefaultProperties { get; set; }
		public DbSet<DataSource> DataSources { get; set; }
		public DbSet<DataSourceRelation> DataSourceRelations { get; set; }
		public DbSet<EndPointParameter> EndPointParameters { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=JigArchitect;Integrated Security=SSPI;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginClaim>().HasKey(x => new { x.ClaimId, x.LoginId });
			modelBuilder.Entity<Schema>()
				.HasMany(x => x.Entities)
				.WithOne(x => x.Schema);
			modelBuilder.Entity<Entity>()
				.HasMany(x => x.Properties)
				.WithOne(x => x.Entity);
			modelBuilder.Entity<Entity>()
				.HasMany(x => x.ParentRelationships)
				.WithOne(x => x.ParentEntity)
				.OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict);
			modelBuilder.Entity<Entity>()
				.HasMany(x => x.ChildrenRelationships)
				.WithOne(x => x.ChildEntity)
				.OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict);
			modelBuilder.Entity<Entity>()
				.HasMany(x => x.EndPointProperties)
				.WithOne(x => x.Entity);
			modelBuilder.Entity<Property>()
				.HasOne(x => x.IntProperty)
				.WithOne(x => x.Property)
				.HasForeignKey<IntProperty>(x => x.PropertyId);
			modelBuilder.Entity<Property>()
				.HasOne(x => x.EnumProperty)
				.WithOne(x => x.Property)
				.HasForeignKey<EnumProperty>(x => x.PropertyId);
			modelBuilder.Entity<EnumProperty>()
				.HasMany(x => x.EnumPropertyValues)
				.WithOne(x => x.EnumProperty);
			modelBuilder.Entity<EndPoint>()
				.HasOne(x => x.GetAllEndPoint)
				.WithOne(x => x.EndPoint)
				.HasForeignKey<GetAllEndPoint>(x => x.EndPointId);
			modelBuilder.Entity<EndPoint>()
				.HasOne(x => x.DeleteEndPoint)
				.WithOne(x => x.EndPoint)
				.HasForeignKey<DeleteEndPoint>(x => x.EndPointId);
			modelBuilder.Entity<EndPoint>()
				.HasOne(x => x.PostEndPoint)
				.WithOne(x => x.EndPoint)
				.HasForeignKey<PostEndPoint>(x => x.EndPointId);
			modelBuilder.Entity<EndPoint>()
				.HasOne(x => x.PutEndPoint)
				.WithOne(x => x.EndPoint)
				.HasForeignKey<PutEndPoint>(x => x.EndPointId);
			modelBuilder.Entity<EndPoint>()
				.HasOne(x => x.GetDetailsEndPoint)
				.WithOne(x => x.EndPoint)
				.HasForeignKey<GetDetailsEndPoint>(x => x.EndPointId);
			modelBuilder.Entity<EndPoint>()
				.HasMany(x => x.EndPointParameters)
				.WithOne(x => x.Parameters);
			modelBuilder.Entity<EndPointModel>()
				.HasOne(x => x.EndPoint)
				.WithOne(x => x.EndPointModel)
				.HasForeignKey<EndPoint>(x => x.EndPointModelId);
			modelBuilder.Entity<EndPointModel>()
				.HasMany(x => x.EndPointModelProperties)
				.WithOne(x => x.EndPointModel);
			modelBuilder.Entity<EndPointProperty>()
				.HasMany(x => x.EndPointModelProperties)
				.WithOne(x => x.EndPointProperty);
			modelBuilder.Entity<EndPointProperty>()
				.HasMany(x => x.EndPointCollectionProperties)
				.WithOne(x => x.EndPointProperty);
			modelBuilder.Entity<EndPointProperty>()
				.HasMany(x => x.EndPointDefaultProperties)
				.WithOne(x => x.EndPointProperty);

        }
    }
}
