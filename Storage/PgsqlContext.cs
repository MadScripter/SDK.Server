using JetBrains.Annotations;
using MySql.Data.EntityFramework;
using NFive.SDK.Server.Configuration;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using NFive.SDK.Server.Databases;

namespace NFive.SDK.Server.Storage
{
	/// <inheritdoc />
	/// <summary>
	/// Represents a PostgreSQL Entity Framework database context.
	/// </summary>
	/// <typeparam name="TContext">The type of the database context.</typeparam>
	/// <seealso cref="DbContext" />
	[PublicAPI]
	[DbConfigurationType(typeof(NpgSqlConfiguration))]
	public abstract class PgsqlContext : EFContext<PgsqlContext>
	{
		/// <inheritdoc />
		/// <summary>
		/// This method is called when the model for a derived context has been initialized, but before the model has been locked down and used to initialize the context.
		/// </summary>
		/// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.HasDefaultSchema("public");

			base.OnModelCreating(modelBuilder);
		}
	}
}
