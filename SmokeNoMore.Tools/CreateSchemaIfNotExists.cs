using SmokeNoMore.Core;
using SqlKata.Compilers;
using System.Data.Common;
using Dapper;

namespace SmokeNoMore.Tools
{
    public class CreateSchemaIfNotExists : IToolProcess
    {
        private readonly DbConnection connection;
        private readonly Compiler compiler;

        public CreateSchemaIfNotExists(DbConnection connection, Compiler compiler)
        {
            this.connection = connection;
            this.compiler = compiler;
        }

        public void Execute()
        {
            var dropTablesQuery =
@"DROP TABLE IF EXISTS Settings;
DROP TABLE IF EXISTS Consumption;
DROP TABLE IF EXISTS Poison;
DROP TABLE IF EXISTS PoisonType;";

            var createSettingsTableQuery = 
@"CREATE TABLE IF NOT EXISTS Settings(
	Username VARCHAR(100) NULL,
	LastAccess DATETIME NULL,
	RunAtStartup TINYINT DEFAULT 0,
	MorningReport TINYINT DEFAULT 1
);";
            var createPoisonTypeTableQuery =
@"CREATE TABLE IF NOT EXISTS PoisonType(
	Id CHAR(36) PRIMARY KEY,
	Name VARCHAR(100) NOT NULL UNIQUE,
	Warning TEXT NOT NULL
);";
            var createPoisonTableQuery =
@"CREATE TABLE IF NOT EXISTS Poison(
	Id CHAR(36) PRIMARY KEY,
	Name VARCHAR(100) NOT NULL UNIQUE,
	Price INT DEFAULT 0,
	Quantity INT DEFAULT 1,
	ItemName VARCHAR(100) NULL,
	TypeId CHAR(36) NOT NULL,
	CONSTRAINT 'FK_PoisonType' FOREIGN KEY(TypeId) REFERENCES PoisonType(Id) ON DELETE NO ACTION
);";
            var createConsumptionTableQuery =
@"CREATE TABLE IF NOT EXISTS Consumption(
	Id CHAR(36) PRIMARY KEY,
	PoisonId CHAR(36) NOT NULL,
	TakenAt DATETIME NOT NULL,
	CONSTRAINT 'FK_Poison' FOREIGN KEY(PoisonId) REFERENCES Poison(Id) ON DELETE NO ACTION
);";
			var createTriggerAutoGuidPoisonType = (string table) => 
@$"DROP TRIGGER IF EXISTS AutoGuid{table};
CREATE TRIGGER AutoGuid{table}
AFTER INSERT ON {table}
FOR EACH ROW
WHEN (NEW.Id IS NULL)
BEGIN
   UPDATE {table} SET Id = (select lower(hex( randomblob(4)) || '-' || hex( randomblob(2))
             || '-' || '4' || substr( hex( randomblob(2)), 2) || '-'
             || substr('AB89', 1 + (abs(random()) % 4) , 1)  ||
             substr(hex(randomblob(2)), 2) || '-' || hex(randomblob(6))) ) WHERE rowid = NEW.rowid;
END;";
            connection.Open();
            using var scope = connection.BeginTransaction();
            var n = Environment.NewLine;
            var query =
                dropTablesQuery + n +
                createSettingsTableQuery + n +
                createPoisonTypeTableQuery + n +
                createPoisonTableQuery + n +
                createConsumptionTableQuery + n +
                createTriggerAutoGuidPoisonType("PoisonType") + n +
                createTriggerAutoGuidPoisonType("Poison") + n +
                createTriggerAutoGuidPoisonType("Consumption");
            connection.Execute(query);
            scope.Commit();
            connection.Close();
        }
    }
}
