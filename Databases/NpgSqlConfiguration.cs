using System.Data.Entity;
using Npgsql;

namespace NFive.SDK.Server.Databases
{
	public class NpgSqlConfiguration : DbConfiguration
	{
		public NpgSqlConfiguration()
		{
			var name = "Npgsql";

			SetProviderFactory(providerInvariantName: name,
				providerFactory: NpgsqlFactory.Instance);

			SetProviderServices(providerInvariantName: name,
				provider: NpgsqlServices.Instance);

			SetDefaultConnectionFactory(connectionFactory: new NpgsqlConnectionFactory());
		}
	}
}
