namespace WpfApp2.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FeedOfAnimal")]
    public partial class FeedOfAnimal
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AnimalId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FeedId { get; set; }

        public bool IsDeleted { get; set; }

        public virtual AnimalData AnimalData { get; set; }

        public virtual Feed Feed { get; set; }
    }
}
