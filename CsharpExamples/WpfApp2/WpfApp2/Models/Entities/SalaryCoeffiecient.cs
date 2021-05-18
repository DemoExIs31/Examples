namespace WpfApp2.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SalaryCoeffiecient")]
    public partial class SalaryCoeffiecient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SalaryCoeffiecient()
        {
            SalarOfEmployee = new HashSet<SalarOfEmployee>();
        }

        public int Id { get; set; }

        [Column(TypeName = "money")]
        public decimal MinSalaryValue { get; set; }

        public decimal Coeff { get; set; }

        public bool IsDeleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalarOfEmployee> SalarOfEmployee { get; set; }
    }
}
