namespace WpfApp2.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StoredOfFeed")]
    public partial class StoredOfFeed
    {
        public int Id { get; set; }

        public int? FeedId { get; set; }

        public int Count { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public virtual Feed Feed { get; set; }
    }
}
