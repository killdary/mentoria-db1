using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurante.Infra.Writting.Data.Migrations
{
    public partial class AddTablesIngredienteReceitasPorcoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingrediente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    DateUpdate = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    IngredienteCategoriaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingrediente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingrediente_IngredienteCategorias_IngredienteCategoriaId",
                        column: x => x.IngredienteCategoriaId,
                        principalTable: "IngredienteCategorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Receita",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    DateUpdate = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receita", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Porcao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    DateUpdate = table.Column<DateTime>(nullable: false),
                    IngredienteId = table.Column<Guid>(nullable: true),
                    ReceitaId = table.Column<Guid>(nullable: true),
                    Quantidade = table.Column<float>(nullable: false),
                    Unidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Porcao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Porcao_Ingrediente_IngredienteId",
                        column: x => x.IngredienteId,
                        principalTable: "Ingrediente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Porcao_Receita_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingrediente_IngredienteCategoriaId",
                table: "Ingrediente",
                column: "IngredienteCategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Porcao_IngredienteId",
                table: "Porcao",
                column: "IngredienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Porcao_ReceitaId",
                table: "Porcao",
                column: "ReceitaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Porcao");

            migrationBuilder.DropTable(
                name: "Ingrediente");

            migrationBuilder.DropTable(
                name: "Receita");
        }
    }
}
