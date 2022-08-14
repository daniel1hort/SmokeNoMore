using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using SmokeNoMore.Core;
using SmokeNoMore.Tools;
using SqlKata.Compilers;
using System.Data.Common;
using Scrutor;

var serviceProvider = new ServiceCollection()
    .AddScoped<DbConnection, SqliteConnection>(sp
        => new SqliteConnection("Data Source=data.sqlite"))
    .AddScoped<Compiler, SqliteCompiler>()
    .Scan(s =>
        s.FromCallingAssembly()
        .AddClasses(a => a.AssignableToAny(typeof(IToolProcess)))
        .UsingRegistrationStrategy(RegistrationStrategy.Append)
        .AsSelf()
        .WithScopedLifetime())
    .BuildServiceProvider();

var createSchemaProcess = serviceProvider.GetService<CreateSchemaIfNotExists>();
var populateSchemaProcess = serviceProvider.GetService<PopulateSchema>();
//createSchemaProcess?.Execute();
//populateSchemaProcess?.Execute();
