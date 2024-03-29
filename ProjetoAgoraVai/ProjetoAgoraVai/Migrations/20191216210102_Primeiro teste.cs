﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoAgoraVai.Migrations
{
    public partial class Primeiroteste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "jogaadors",
                columns: table => new
                {
                    JogadorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    Idade = table.Column<int>(nullable: false),
                    Nacionalidade = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jogaadors", x => x.JogadorId);
                });

            migrationBuilder.CreateTable(
                name: "placars",
                columns: table => new
                {
                    PlacarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JogadorId = table.Column<int>(nullable: false),
                    Pontos = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_placars", x => x.PlacarId);
                    table.ForeignKey(
                        name: "FK_placars_jogaadors_JogadorId",
                        column: x => x.JogadorId,
                        principalTable: "jogaadors",
                        principalColumn: "JogadorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_placars_JogadorId",
                table: "placars",
                column: "JogadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "placars");

            migrationBuilder.DropTable(
                name: "jogaadors");
        }
    }
}
