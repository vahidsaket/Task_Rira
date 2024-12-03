﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TaskRira.DataAccess.Persistence
{
    public static class AutomatedMigration
    {
        public static async Task MigrateAsync(IServiceProvider services)
        {
            var context = services.GetRequiredService<DatabaseContext>();

            if (context.Database.IsSqlServer()) await context.Database.MigrateAsync();

        }
    }

}
