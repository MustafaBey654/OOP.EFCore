using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OOP.EFCore.ConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.EFCore.ConsoleApp.DAL.Mapping
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            //Primery key olmalı haskey ile
            builder.HasKey(b => b.BookId);

            //Title kısmı zorunlu olmalı ve 250 karekter maximum olmalıdır.
            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(250);

            //Güncel tarih bilgisini al
            builder.Property(b => b.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            //Birden fazla kitap verisi ekleme
            builder.HasData(
                new Book { BookId = 1, Title="Devlet",CategoryId=3},
                new Book { BookId = 2, Title="Yoldaki İşaretler",CategoryId=3}
                );

            //İlişki tanımı 

            builder.HasOne(b => b.Category)
                .WithMany(c => c.Books)//Çoklu ilişki durumu
                .HasForeignKey(b => b.CategoryId)//yabancı anahtar primery key
                .OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}
