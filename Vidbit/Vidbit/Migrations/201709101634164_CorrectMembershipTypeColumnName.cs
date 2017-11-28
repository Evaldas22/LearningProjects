namespace Vidbit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectMembershipTypeColumnName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Anual' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
