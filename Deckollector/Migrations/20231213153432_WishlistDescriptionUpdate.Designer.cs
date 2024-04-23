﻿// <auto-generated />
using System;
using Deckollector.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Deckollector.Migrations
{
    [DbContext(typeof(DeckollectorContext))]
    [Migration("20231213153432_WishlistDescriptionUpdate")]
    partial class WishlistDescriptionUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Deckollector.Models.Card", b =>
                {
                    b.Property<int>("CardID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CardID"));

                    b.Property<string>("CardColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardCost")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardSet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CardSetID")
                        .HasColumnType("int");

                    b.Property<string>("CardType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DeckID")
                        .HasColumnType("int");

                    b.Property<int?>("WishlistID")
                        .HasColumnType("int");

                    b.HasKey("CardID");

                    b.HasIndex("DeckID");

                    b.HasIndex("WishlistID");

                    b.ToTable("Card");
                });

            modelBuilder.Entity("Deckollector.Models.Collection", b =>
                {
                    b.Property<int>("CollectionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CollectionID"));

                    b.Property<string>("CollectionDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CollectionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CollectionID");

                    b.ToTable("Collection");
                });

            modelBuilder.Entity("Deckollector.Models.Deck", b =>
                {
                    b.Property<int>("DeckID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeckID"));

                    b.Property<int>("CollectionID")
                        .HasColumnType("int");

                    b.Property<string>("DeckDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeckName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeckID");

                    b.HasIndex("CollectionID");

                    b.ToTable("Deck");
                });

            modelBuilder.Entity("Deckollector.Models.Wishlist", b =>
                {
                    b.Property<int>("WishlistID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WishlistID"));

                    b.Property<string>("WishlistDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WishlistName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WishlistID");

                    b.ToTable("Wishlist");
                });

            modelBuilder.Entity("Deckollector.Models.Card", b =>
                {
                    b.HasOne("Deckollector.Models.Deck", "Decks")
                        .WithMany("Cards")
                        .HasForeignKey("DeckID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Deckollector.Models.Wishlist", "Wishlists")
                        .WithMany("Cards")
                        .HasForeignKey("WishlistID");

                    b.Navigation("Decks");

                    b.Navigation("Wishlists");
                });

            modelBuilder.Entity("Deckollector.Models.Deck", b =>
                {
                    b.HasOne("Deckollector.Models.Collection", "Collection")
                        .WithMany("Decks")
                        .HasForeignKey("CollectionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Collection");
                });

            modelBuilder.Entity("Deckollector.Models.Collection", b =>
                {
                    b.Navigation("Decks");
                });

            modelBuilder.Entity("Deckollector.Models.Deck", b =>
                {
                    b.Navigation("Cards");
                });

            modelBuilder.Entity("Deckollector.Models.Wishlist", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}