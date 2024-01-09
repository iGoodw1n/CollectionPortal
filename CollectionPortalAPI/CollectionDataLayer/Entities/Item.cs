namespace CollectionDataLayer.Entities;

public class Item
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public ICollection<Tag> Tags { get; } = new List<Tag>();

    public string? CustomString1 { get; set; }

    public string? CustomString2 { get; set; }

    public string? CustomString3 { get; set; }

    public int? CustomInt1 { get; set; }

    public int? CustomInt2 { get; set; }

    public int? CustomInt3 { get; set; }

    public string? CustomText1 { get; set; }

    public string? CustomText2 { get; set; }

    public string? CustomText3 { get; set; }

    public bool? CustomCheckBox1 { get; set; }

    public bool? CustomCheckBox2 { get; set; }

    public bool? CustomCheckBox3 { get; set; }

    public DateTime? CustomDate1 { get; set; }

    public DateTime? CustomDate2 { get; set; }

    public DateTime? CustomDate3 { get; set; }
}
