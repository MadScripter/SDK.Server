using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MySql.Data.EntityFramework;

namespace NFive.SDK.Server.Storage
{
	[PublicAPI]
	[DbConfigurationType(typeof(MySqlEFConfiguration))]
	public abstract class MysqlContext : EFContext<MysqlContext>
	{
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Store booleans as MySQL BIT type
			modelBuilder.
				Properties<bool>()
				.Configure(c => c.HasColumnType("bit"));

			// Store strings as MySQL VARCHAR type
			modelBuilder
				.Properties()
				.Where(x => x.PropertyType == typeof(string) && !x.GetCustomAttributes(false).OfType<ColumnAttribute>().Any(q => q.TypeName != null && q.TypeName.Equals("varchar", StringComparison.InvariantCultureIgnoreCase)))
				.Configure(c => c.HasColumnType("varchar"));
		}
	}
}
