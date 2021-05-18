namespace WpfApp2.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AnimalsInAvairy")]
    public partial class AnimalsInAvairy
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AnimalId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AvairyId { get; set; }

        public bool IsDeleted { get; set; }

        public virtual AnimalData AnimalData { get; set; }

        public virtual Aviary Aviary { get; set; }
    }
}
