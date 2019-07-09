using FluentMigrator;

namespace Banking.Infrastructure.Migrations.MySQL
{
    [Migration(45)]
    public class CreateAgentTable : Migration
    {
        public override void Up()
        {
            Execute.EmbeddedScript("0_CreateAgentTable.sql");
        }

        public override void Down()
        {
        }
    }
}
