using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalSolutionC_.Migrations
{
    public partial class RevertRemoveLixeiraId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lixeiras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Localizacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lixeiras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItensLixeira",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    LixeiraId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensLixeira", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensLixeira_Lixeiras_LixeiraId",
                        column: x => x.LixeiraId,
                        principalTable: "Lixeiras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pontos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Quantidade = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pontos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pontos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensLixeira_LixeiraId",
                table: "ItensLixeira",
                column: "LixeiraId");

            migrationBuilder.CreateIndex(
                name: "IX_Pontos_UsuarioId",
                table: "Pontos",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensLixeira");

            migrationBuilder.DropTable(
                name: "Pontos");

            migrationBuilder.DropTable(
                name: "Lixeiras");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
