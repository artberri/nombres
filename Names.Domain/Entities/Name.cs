using System.ComponentModel.DataAnnotations.Schema;

namespace Names.Domain.Entities
{
    [Table("names")]
    public class Name
    {
        [Column("id")]
        public int NameId { get; set; }

        [Column("name", TypeName = "varchar(200)")]
        public string Value { get; set; }

        [Column("gender", TypeName = "boolean")]
        public bool Gender { get; set; }

        [Column("compound", TypeName = "boolean")]
        public bool Compound { get; set; }
    }
}
