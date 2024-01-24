using CollectionDataLayer.Consts;
using System.ComponentModel.DataAnnotations;

namespace CollectionDataLayer.Entities;

public class Item
{
    public int Id { get; set; }

    [MaxLength(ParamsData.MaxLengthForStringField)]
    public string Name { get; set; } = null!;

    public List<Tag> Tags { get; } = [];

    [MaxLength(ParamsData.MaxLengthForStringField)]
    public string? CustomString1 { get; set; }

    [MaxLength(ParamsData.MaxLengthForStringField)]
    public string? CustomString2 { get; set; }

    [MaxLength(ParamsData.MaxLengthForStringField)]
    public string? CustomString3 { get; set; }

    public int? CustomInt1 { get; set; }

    public int? CustomInt2 { get; set; }

    public int? CustomInt3 { get; set; }

    [MaxLength(ParamsData.MaxLengthForTextField)]
    public string? CustomText1 { get; set; }

    [MaxLength(ParamsData.MaxLengthForTextField)]
    public string? CustomText2 { get; set; }

    [MaxLength(ParamsData.MaxLengthForTextField)]
    public string? CustomText3 { get; set; }

    public bool? CustomCheckBox1 { get; set; }

    public bool? CustomCheckBox2 { get; set; }

    public bool? CustomCheckBox3 { get; set; }

    public DateOnly? CustomDate1 { get; set; }

    public DateOnly? CustomDate2 { get; set; }

    public DateOnly? CustomDate3 { get; set; }

    public int CollectionId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public Collection Collection { get; set; } = null!;

    public List<Comment> Comments { get; set; } = [];
}
