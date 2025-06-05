using be_adminsisters.Services;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace be_adminsisters.Common.Extensions;

public static class PostgresJsonExtensions
{
    public static NpgsqlDbContextOptionsBuilder UseJsonDocumentDbApi(
        this NpgsqlDbContextOptionsBuilder optionsBuilder)
    {
        var coreOptionsBuilder = ((IRelationalDbContextOptionsBuilderInfrastructure)optionsBuilder).OptionsBuilder;

        coreOptionsBuilder.ReplaceService<IJsonValueReaderWriterSource, CustomJsonValueReaderWriterSource>();

        return optionsBuilder;
    }
}
