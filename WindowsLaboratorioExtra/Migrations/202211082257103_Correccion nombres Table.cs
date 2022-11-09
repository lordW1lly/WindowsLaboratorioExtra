namespace WindowsLaboratorioExtra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorreccionnombresTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Planillas", newName: "Planilla");
            RenameTable(name: "dbo.Materias", newName: "Materia");
            RenameTable(name: "dbo.Profesors", newName: "Profesor");
            RenameTable(name: "dbo.Tipoes", newName: "Tipo");
            RenameTable(name: "dbo.Plans", newName: "Plan");
            DropForeignKey("dbo.Evaluacion", "IdTipo", "dbo.Tipoes");
            DropPrimaryKey("dbo.Tipo");
            AlterColumn("dbo.Tipo", "TipoId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Tipo", "TipoId");
            AddForeignKey("dbo.Evaluacion", "IdTipo", "dbo.Tipo", "TipoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evaluacion", "IdTipo", "dbo.Tipo");
            DropPrimaryKey("dbo.Tipo");
            AlterColumn("dbo.Tipo", "TipoId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Tipo", "TipoId");
            AddForeignKey("dbo.Evaluacion", "IdTipo", "dbo.Tipoes", "TipoId");
            RenameTable(name: "dbo.Plan", newName: "Plans");
            RenameTable(name: "dbo.Tipo", newName: "Tipoes");
            RenameTable(name: "dbo.Profesor", newName: "Profesors");
            RenameTable(name: "dbo.Materia", newName: "Materias");
            RenameTable(name: "dbo.Planilla", newName: "Planillas");
        }
    }
}
