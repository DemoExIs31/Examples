namespace WpfApp2.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UsersWithPosition")]
    public partial class UsersWithPosition
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Name { get; set; }

        [Key]
        [Column("Middle name", Order = 1)]
        [StringLength(50)]
        public string Middle_name { get; set; }

        [Key]
        [Column("Last name", Order = 2)]
        [StringLength(50)]
        public string Last_name { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(25)]
        public string Position { get; set; }
    }
}
