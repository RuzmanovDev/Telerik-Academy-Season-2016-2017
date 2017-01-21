//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Computers.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Computer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Computer()
        {
            this.Gpus = new HashSet<Gpu>();
            this.Storages = new HashSet<Storage>();
        }
    
        public int Id { get; set; }
        public double Memory { get; set; }
        public int CpuId { get; set; }
        public int TypeId { get; set; }
        public string Model { get; set; }
        public int VendorId { get; set; }
    
        public virtual ComputerType ComputerType { get; set; }
        public virtual Cpu Cpu { get; set; }
        public virtual Vendor Vendor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gpu> Gpus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Storage> Storages { get; set; }
    }
}