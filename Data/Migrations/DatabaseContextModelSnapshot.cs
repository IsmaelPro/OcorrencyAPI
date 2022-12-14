// <auto-generated />
using System;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Entites.Ocorrencia", b =>
                {
                    b.Property<int>("IdOcorrencia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("HoraOcorrencia")
                        .HasColumnType("datetime2");

                    b.Property<int>("IndFinalizadora")
                        .HasColumnType("int");

                    b.Property<int?>("PedidoIdPedido")
                        .HasColumnType("int");

                    b.Property<string>("TipoOcorrencia")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdOcorrencia");

                    b.HasIndex("PedidoIdPedido");

                    b.ToTable("Ocorrencia");
                });

            modelBuilder.Entity("Models.Entites.Pedido", b =>
                {
                    b.Property<int>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("HoraPedido")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IndCancelado")
                        .HasColumnType("bit");

                    b.Property<bool>("IndConcluido")
                        .HasColumnType("bit");

                    b.Property<int>("NumeroPedido")
                        .HasColumnType("int");

                    b.HasKey("IdPedido");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("Models.Entites.Ocorrencia", b =>
                {
                    b.HasOne("Models.Entites.Pedido", null)
                        .WithMany("Ocorrencias")
                        .HasForeignKey("PedidoIdPedido");
                });
#pragma warning restore 612, 618
        }
    }
}
