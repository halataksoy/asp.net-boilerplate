using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Xelat.Project.EntityFrameworkCore
{
    public static class ProjectDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ProjectDbContext> builder, string connectionString)
        {
            //builder.UseSqlServer(connectionString);
            //builder.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));
            var serverVersion = ServerVersion.AutoDetect(connectionString);
            builder.UseMySql(connectionString, serverVersion);
        }

        public static void Configure(DbContextOptionsBuilder<ProjectDbContext> builder, DbConnection connection)
        {
            //builder.UseSqlServer(connection);
            //builder.UseMySql(connection,ServerVersion.AutoDetect(connection.ConnectionString));
            var serverVersion = ServerVersion.AutoDetect(connection.ConnectionString);
            builder.UseMySql(connection, serverVersion);
        }
    }
}
 