using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteProgramacaoMF.Profissionais.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCargo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Cargos(Id, Nome) VALUES(newid(), 'Engenheiro');");
            migrationBuilder.Sql("INSERT INTO Cargos(Id, Nome) VALUES(newid(), 'Pedreiro');");
            migrationBuilder.Sql("INSERT INTO Cargos(Id, Nome) VALUES(newid(), 'Servente');");
            migrationBuilder.Sql("INSERT INTO Cargos(Id, Nome) VALUES(newid(), 'Encarregado de Obra');");
            migrationBuilder.Sql("INSERT INTO Cargos(Id, Nome) VALUES(newid(), 'Eletricista');");

            migrationBuilder.Sql("INSERT INTO Obras(Id, Nome) VALUES(newid(), 'Residencial Vale Verde');");
            migrationBuilder.Sql("INSERT INTO Obras(Id, Nome) VALUES(newid(), 'Campina Nova');");
            migrationBuilder.Sql("INSERT INTO Obras(Id, Nome) VALUES(newid(), 'Plaza Shopping');");
            migrationBuilder.Sql("INSERT INTO Obras(Id, Nome) VALUES(newid(), 'Residencial Meridien');");
            migrationBuilder.Sql("INSERT INTO Obras(Id, Nome) VALUES(newid(), 'Albuquerque Buildings');");
            migrationBuilder.Sql("INSERT INTO Obras(Id, Nome) VALUES(newid(), 'Garden Park');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Cargos WHERE Nome = 'Engenheiro';");
            migrationBuilder.Sql("DELETE FROM Cargos WHERE Nome = 'Pedreiro';");
            migrationBuilder.Sql("DELETE FROM Cargos WHERE Nome = 'Servente';");
            migrationBuilder.Sql("DELETE FROM Cargos WHERE Nome = 'Encarregado de Obra';");
            migrationBuilder.Sql("DELETE FROM Cargos WHERE Nome = 'Eletricista';");

            migrationBuilder.Sql("DELETE FROM Obras WHERE Nome = 'Residencial Vale Verde';");
            migrationBuilder.Sql("DELETE FROM Obras WHERE Nome = 'Campina Nova';");
            migrationBuilder.Sql("DELETE FROM Obras WHERE Nome = 'Plaza Shopping';");
            migrationBuilder.Sql("DELETE FROM Obras WHERE Nome = 'Residencial Meridien';");
            migrationBuilder.Sql("DELETE FROM Obras WHERE Nome = 'Albuquerque Buildings';");
            migrationBuilder.Sql("DELETE FROM Obras WHERE Nome = 'Garden Park';");
        }
    }
}
