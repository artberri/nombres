using System.ComponentModel.DataAnnotations.Schema;

namespace Names.Domain.Entities
{
    [Table("quantity")]
    public class Quantity
    {
        [Column("id")]
        public int QuantityId { get; set; }

        [Column("quantity")]
        public int Value { get; set; }

        [Column("perthousand")]
        public float PerThousand { get; set; }

        [Column("name")]
        public int NameId { get; set; }
        public Name Name { get; set; }

        [Column("year")]
        public int YearId { get; set; }
        public Year Year { get; set; }

        [Column("province")]
        public int ProvinceId { get; set; }
        public Province Province { get; set; }
    }
}
