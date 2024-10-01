﻿// <auto-generated />
using ComuniQBD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ComuniQBD.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20240924164927_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ComuniQBD.Models.Bairro", b =>
                {
                    b.Property<int>("BairroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("BairroId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BairroId"));

                    b.Property<string>("BairroNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("BairroNome");

                    b.Property<int>("CidadeId")
                        .HasColumnType("int");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.HasKey("BairroId");

                    b.HasIndex("CidadeId");

                    b.HasIndex("EstadoId");

                    b.ToTable("Bairro");
                });

            modelBuilder.Entity("ComuniQBD.Models.Campanha", b =>
                {
                    b.Property<int>("CampanhaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CampanhaId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CampanhaId"));

                    b.Property<string>("CampanhaDescricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CampanhaDescricao");

                    b.Property<string>("CampanhaMidia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CampanhaMidia");

                    b.Property<string>("CampanhaTitulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CampanhaTitulo");

                    b.Property<int>("CidadeId")
                        .HasColumnType("int");

                    b.Property<int>("TipoCampanhaId")
                        .HasColumnType("int");

                    b.HasKey("CampanhaId");

                    b.HasIndex("CidadeId");

                    b.HasIndex("TipoCampanhaId");

                    b.ToTable("Campanha");
                });

            modelBuilder.Entity("ComuniQBD.Models.Cidade", b =>
                {
                    b.Property<int>("CidadeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CidadeId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CidadeId"));

                    b.Property<string>("CidadeNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CidadeNome");

                    b.HasKey("CidadeId");

                    b.ToTable("Cidade");
                });

            modelBuilder.Entity("ComuniQBD.Models.Comentario", b =>
                {
                    b.Property<int>("ComentarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ComentarioId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComentarioId"));

                    b.Property<string>("ComentarioTexto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ComentarioTexto");

                    b.Property<int>("PublicacaoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("ComentarioId");

                    b.HasIndex("PublicacaoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Comentario");
                });

            modelBuilder.Entity("ComuniQBD.Models.Denuncia", b =>
                {
                    b.Property<int>("DenunciaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DenunciaId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DenunciaId"));

                    b.Property<int>("BairroId")
                        .HasColumnType("int");

                    b.Property<string>("DenunciaDescricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DenunciaDescricao");

                    b.Property<string>("DenunciaMidia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DenunciaMidia");

                    b.Property<string>("DenunciaTitulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DenunciaTitulo");

                    b.Property<int>("TipoDenunciaId")
                        .HasColumnType("int");

                    b.HasKey("DenunciaId");

                    b.HasIndex("BairroId");

                    b.HasIndex("TipoDenunciaId");

                    b.ToTable("Denuncia");
                });

            modelBuilder.Entity("ComuniQBD.Models.Estado", b =>
                {
                    b.Property<int>("EstadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EstadoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstadoId"));

                    b.Property<string>("EstadoNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EstadoNome");

                    b.HasKey("EstadoId");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("ComuniQBD.Models.Publicacao", b =>
                {
                    b.Property<int>("PublicacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PublicacaoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PublicacaoId"));

                    b.Property<int>("BairroId")
                        .HasColumnType("int");

                    b.Property<string>("PublicacaoDescricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PublicacaoDescricao");

                    b.Property<string>("PublicacaoMidia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PublicacaoMidia");

                    b.Property<string>("PublicacaoTitulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PublicacaoTitulo");

                    b.HasKey("PublicacaoId");

                    b.HasIndex("BairroId");

                    b.ToTable("Publicacao");
                });

            modelBuilder.Entity("ComuniQBD.Models.PublicacaoUsuario", b =>
                {
                    b.Property<int>("PublicacaoUsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PublicacaoUsuarioId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PublicacaoUsuarioId"));

                    b.Property<int>("PublicacaoId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("PublicacaoUsuarioId");

                    b.HasIndex("PublicacaoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("PublicacaoUsuario");
                });

            modelBuilder.Entity("ComuniQBD.Models.TipoCampanha", b =>
                {
                    b.Property<int>("TipoCampanhaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TipoCampanhaId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoCampanhaId"));

                    b.Property<string>("TipoCampanhaNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TipoCampanhaNome");

                    b.HasKey("TipoCampanhaId");

                    b.ToTable("TipoCampanha");
                });

            modelBuilder.Entity("ComuniQBD.Models.TipoDenuncia", b =>
                {
                    b.Property<int>("TipoDenunciaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TipoDenunciaId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoDenunciaId"));

                    b.Property<string>("TipoDenunciaNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TipoDenunciaNome");

                    b.HasKey("TipoDenunciaId");

                    b.ToTable("TipoDenuncia");
                });

            modelBuilder.Entity("ComuniQBD.Models.TipoPerfil", b =>
                {
                    b.Property<int>("TipoPerfilId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TipoPerfilId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoPerfilId"));

                    b.Property<string>("TipoPerfilNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TipoPerfilNome");

                    b.HasKey("TipoPerfilId");

                    b.ToTable("TipoPerfil");
                });

            modelBuilder.Entity("ComuniQBD.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UsuarioId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"));

                    b.Property<string>("UssuarioBairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UssuarioBairro");

                    b.Property<string>("UsuarioApelido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UsuarioApelido");

                    b.Property<int>("UsuarioCEP")
                        .HasColumnType("int")
                        .HasColumnName("UsuarioCEP");

                    b.Property<string>("UsuarioCPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UsuarioCPF");

                    b.Property<string>("UsuarioCidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UsuarioCidade");

                    b.Property<string>("UsuarioEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UsuarioEmail");

                    b.Property<string>("UsuarioEstado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UsuarioEstado");

                    b.Property<string>("UsuarioNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UsuarioNome");

                    b.Property<string>("UsuarioSenha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UsuarioSenha");

                    b.Property<string>("UsuarioSobrenome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UsuarioSobrenome");

                    b.Property<int>("UsuarioTelefone")
                        .HasColumnType("int")
                        .HasColumnName("UsuarioTelefone");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("ComuniQBD.Models.Bairro", b =>
                {
                    b.HasOne("ComuniQBD.Models.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComuniQBD.Models.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cidade");

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("ComuniQBD.Models.Campanha", b =>
                {
                    b.HasOne("ComuniQBD.Models.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComuniQBD.Models.TipoCampanha", "TipoCampanha")
                        .WithMany()
                        .HasForeignKey("TipoCampanhaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cidade");

                    b.Navigation("TipoCampanha");
                });

            modelBuilder.Entity("ComuniQBD.Models.Comentario", b =>
                {
                    b.HasOne("ComuniQBD.Models.Publicacao", "Publicacao")
                        .WithMany()
                        .HasForeignKey("PublicacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComuniQBD.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publicacao");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ComuniQBD.Models.Denuncia", b =>
                {
                    b.HasOne("ComuniQBD.Models.Bairro", "Bairro")
                        .WithMany()
                        .HasForeignKey("BairroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComuniQBD.Models.TipoDenuncia", "TipoDenuncia")
                        .WithMany()
                        .HasForeignKey("TipoDenunciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bairro");

                    b.Navigation("TipoDenuncia");
                });

            modelBuilder.Entity("ComuniQBD.Models.Publicacao", b =>
                {
                    b.HasOne("ComuniQBD.Models.Bairro", "Bairro")
                        .WithMany()
                        .HasForeignKey("BairroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bairro");
                });

            modelBuilder.Entity("ComuniQBD.Models.PublicacaoUsuario", b =>
                {
                    b.HasOne("ComuniQBD.Models.Publicacao", "Publicacao")
                        .WithMany()
                        .HasForeignKey("PublicacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ComuniQBD.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publicacao");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}