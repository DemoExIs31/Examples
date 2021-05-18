namespace WpfApp2.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SalarOfEmployee")]
    public partial class SalarOfEmployee
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WorkShiftScheduleId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserDataId { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SalaryCoeffiecientId { get; set; }

        public bool IsDeleted { get; set; }

        public virtual SalaryCoeffiecient SalaryCoeffiecient { get; set; }

        public virtual UserData UserData { get; set; }

        public virtual WorkShiftSchedule WorkShiftSchedule { get; set; }
    }
}
