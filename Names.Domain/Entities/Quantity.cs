namespace Names.Domain.Entities
{
    public class Quantity
    {
        public int QuantityId { get; set; }

        public int Value { get; set; }

        public float PerThousand { get; set; }

        public int NameId { get; set; }
        public Name Name { get; set; }

        public int YearId { get; set; }
        public Year Year { get; set; }

        public int ProvinceId { get; set; }
        public Province Province { get; set; }
    }
}
