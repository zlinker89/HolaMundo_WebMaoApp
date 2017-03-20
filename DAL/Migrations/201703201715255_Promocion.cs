namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Promocion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Promocion",
                c => new
                    {
                        PromocionId = c.Int(nullable: false, identity: true),
                        ImagePromocion = c.Binary(),
                        NombreImagen = c.String(),
                        Titulo = c.String(),
                        Mensaje = c.String(),
                    })
                .PrimaryKey(t => t.PromocionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Promocion");
        }
    }
}
