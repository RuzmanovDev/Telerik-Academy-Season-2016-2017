//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PetStore.Data.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pet
    {
        public int Id { get; set; }
        public System.DateTime TimeOfBirth { get; set; }
        public decimal Price { get; set; }
        public int ColorId { get; set; }
        public string Breed { get; set; }
        public int SpeciesId { get; set; }
    
        public virtual Color Color { get; set; }
        public virtual Species Species { get; set; }
    }
}
