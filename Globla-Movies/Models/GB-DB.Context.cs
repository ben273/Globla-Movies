﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Globla_Movies.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GMEntities : DbContext
    {
        public GMEntities()
            : base("name=GMEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Director> Directors { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Movie_Cast> Movie_Cast { get; set; }
        public virtual DbSet<Movie_Dir> Movie_Dir { get; set; }
        public virtual DbSet<Movie_Genre> Movie_Genre { get; set; }
        public virtual DbSet<rating> ratings { get; set; }
        public virtual DbSet<Reviwer> Reviwers { get; set; }
    }
}
