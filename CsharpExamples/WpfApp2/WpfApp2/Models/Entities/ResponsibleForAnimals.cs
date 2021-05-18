namespace WpfApp2.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ResponsibleForAnimals
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AnimalId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ResponsibleId { get; set; }

        public bool IsDeleted { get; set; }

        public virtual AnimalData AnimalData { get; set; }

        public virtual UserData UserData { get; set; }
    }
}
