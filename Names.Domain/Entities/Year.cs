using System.ComponentModel.DataAnnotations.Schema;

namespace Names.Domain.Entities
{
    [Table("years")]
    public class Year
    {
        [Column("id")]
        public int YearId { get; set; }

        [Column("year")]
        public int Value { get; set; }
    }
}
