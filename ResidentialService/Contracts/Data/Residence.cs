using CsvHelper.Configuration.Attributes;

namespace ResidentialService.Contracts
{
    public record Residence
    {
        [Name("type")]
        public string Type { get; set; }
        [Name("sq__ft")]
        public int SqFt { get; init; }

        [Name("street")]
        public string Street { get; }
        [Name("city")]
        public string City { get; init; }

        [Name("price")]
        public string Price { get; }

        [Name("beds")]
        public int Beds { get; }

        [Name("baths")]
        public int Baths { get; }

        public int Rooms => Beds + Baths;
}

public record ResidenceReportByMaxSqFt
{
        public string City { get; set; }
public int MaxSqFt { get; set; }
    }
}