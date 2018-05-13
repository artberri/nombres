using System.ComponentModel.DataAnnotations.Schema;

namespace Names.Domain.Entities
{
    [Table("provinces")]
    public class Province
    {
        [Column("id")]
        public int ProvinceId { get; set; }

        [Column("name", TypeName = "varchar(150)")]
        public string Value { get; set; }
    }
}
