namespace WindowsLaboratorioExtra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carrera",
                c => new
                    {
                        CarreraId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.CarreraId);
            
            CreateTable(
                "dbo.Curso",
                c => new
                    {
                        CursoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.CursoId);
            
            CreateTable(
                "dbo.Detalle",
                c => new
                    {
                        DetalleId = c.Int(nullable: false, identity: true),
                        IdEstado = c.Int(nullable: false),
                        IdPlanilla = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DetalleId)
                .ForeignKey("dbo.Estado", t => t.IdEstado)
                .ForeignKey("dbo.Planillas", t => t.IdPlanilla)
                .Index(t => t.IdEstado)
                .Index(t => t.IdPlanilla);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        EstadoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.EstadoId);
            
            CreateTable(
                "dbo.Planillas",
                c => new
                    {
                        PlanillaId = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        IdCarrera = c.Int(nullable: false),
                        IdMateria = c.Int(nullable: false),
                        IdProfesor = c.Int(nullable: false),
                        IdCurso = c.Int(nullable: false),
                        IdDetalles = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlanillaId)
                .ForeignKey("dbo.Carrera", t => t.IdCarrera)
                .ForeignKey("dbo.Curso", t => t.IdCurso)
                .ForeignKey("dbo.Materias", t => t.IdMateria)
                .ForeignKey("dbo.Profesors", t => t.IdProfesor)
                .Index(t => t.IdCarrera)
                .Index(t => t.IdMateria)
                .Index(t => t.IdProfesor)
                .Index(t => t.IdCurso);
            
            CreateTable(
                "dbo.Materias",
                c => new
                    {
                        MateriaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        IdPlanilla = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MateriaId);
            
            CreateTable(
                "dbo.Profesors",
                c => new
                    {
                        ProfesorId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        IdPlanilla = c.Int(nullable: false),
                        IdLocalidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProfesorId)
                .ForeignKey("dbo.Localidad", t => t.IdLocalidad)
                .Index(t => t.IdLocalidad);
            
            CreateTable(
                "dbo.Localidad",
                c => new
                    {
                        LocalidadId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        IdProfesor = c.Int(nullable: false),
                        IdEstudiante = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LocalidadId);
            
            CreateTable(
                "dbo.Estudiante",
                c => new
                    {
                        EstudianteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        Apellido = c.String(nullable: false, maxLength: 50, unicode: false),
                        Telefono = c.String(nullable: false, maxLength: 50, unicode: false),
                        Calle = c.String(nullable: false, maxLength: 50, unicode: false),
                        Numero = c.String(nullable: false, maxLength: 50, unicode: false),
                        IdLocalidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EstudianteId)
                .ForeignKey("dbo.Localidad", t => t.IdLocalidad)
                .Index(t => t.IdLocalidad);
            
            CreateTable(
                "dbo.Evaluacion",
                c => new
                    {
                        EvaluacionId = c.Int(nullable: false, identity: true),
                        Nota = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdTipo = c.Int(nullable: false),
                        IdDetalle = c.Int(nullable: false),
                        IdEstudiante = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EvaluacionId)
                .ForeignKey("dbo.Detalle", t => t.IdDetalle)
                .ForeignKey("dbo.Estudiante", t => t.IdEstudiante)
                .ForeignKey("dbo.Tipoes", t => t.IdTipo)
                .Index(t => t.IdTipo)
                .Index(t => t.IdDetalle)
                .Index(t => t.IdEstudiante);
            
            CreateTable(
                "dbo.Tipoes",
                c => new
                    {
                        TipoId = c.Int(nullable: false),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.TipoId);
            
            CreateTable(
                "dbo.Plans",
                c => new
                    {
                        PlanId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        IdCarrera = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlanId)
                .ForeignKey("dbo.Carrera", t => t.IdCarrera)
                .Index(t => t.IdCarrera);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Plans", "IdCarrera", "dbo.Carrera");
            DropForeignKey("dbo.Evaluacion", "IdTipo", "dbo.Tipoes");
            DropForeignKey("dbo.Evaluacion", "IdEstudiante", "dbo.Estudiante");
            DropForeignKey("dbo.Evaluacion", "IdDetalle", "dbo.Detalle");
            DropForeignKey("dbo.Planillas", "IdProfesor", "dbo.Profesors");
            DropForeignKey("dbo.Profesors", "IdLocalidad", "dbo.Localidad");
            DropForeignKey("dbo.Estudiante", "IdLocalidad", "dbo.Localidad");
            DropForeignKey("dbo.Planillas", "IdMateria", "dbo.Materias");
            DropForeignKey("dbo.Detalle", "IdPlanilla", "dbo.Planillas");
            DropForeignKey("dbo.Planillas", "IdCurso", "dbo.Curso");
            DropForeignKey("dbo.Planillas", "IdCarrera", "dbo.Carrera");
            DropForeignKey("dbo.Detalle", "IdEstado", "dbo.Estado");
            DropIndex("dbo.Plans", new[] { "IdCarrera" });
            DropIndex("dbo.Evaluacion", new[] { "IdEstudiante" });
            DropIndex("dbo.Evaluacion", new[] { "IdDetalle" });
            DropIndex("dbo.Evaluacion", new[] { "IdTipo" });
            DropIndex("dbo.Estudiante", new[] { "IdLocalidad" });
            DropIndex("dbo.Profesors", new[] { "IdLocalidad" });
            DropIndex("dbo.Planillas", new[] { "IdCurso" });
            DropIndex("dbo.Planillas", new[] { "IdProfesor" });
            DropIndex("dbo.Planillas", new[] { "IdMateria" });
            DropIndex("dbo.Planillas", new[] { "IdCarrera" });
            DropIndex("dbo.Detalle", new[] { "IdPlanilla" });
            DropIndex("dbo.Detalle", new[] { "IdEstado" });
            DropTable("dbo.Plans");
            DropTable("dbo.Tipoes");
            DropTable("dbo.Evaluacion");
            DropTable("dbo.Estudiante");
            DropTable("dbo.Localidad");
            DropTable("dbo.Profesors");
            DropTable("dbo.Materias");
            DropTable("dbo.Planillas");
            DropTable("dbo.Estado");
            DropTable("dbo.Detalle");
            DropTable("dbo.Curso");
            DropTable("dbo.Carrera");
        }
    }
}
