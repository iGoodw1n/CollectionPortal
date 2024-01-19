using CollectionDataLayer.Consts;
using System.ComponentModel.DataAnnotations;

namespace CollectionDataLayer.Entities;

public class Collection
{
    public int Id { get; set; }

    [MinLength(1)]
    public string Name { get; set; } = null!;

    [MaxLength(ParamsData.MaxLengthForStringField)]
    public string? Description { get; set; }

    public int? PhotoId { get; set; }

    public Photo? Photo { get; set; }

    public int UserId { get; set; }

    public AppUser User { get; set; } = null!;

    public int CategoryId { get; set; }

    public Category Category { get; set; } = null!;

    public bool CustomString1State { get; set; }

    [MaxLength(ParamsData.MaxLengthForStringField)]
    public string? CustomString1Name { get; set; }

    public bool CustomString2State { get; set; }

    [MaxLength(ParamsData.MaxLengthForStringField)]
    public string? CustomString2Name { get; set; }

    public bool CustomString3State { get; set; }

    [MaxLength(ParamsData.MaxLengthForStringField)]
    public string? CustomString3Name { get; set; }

    public bool CustomInt1State { get; set; }

    [MaxLength(ParamsData.MaxLengthForStringField)]
    public string? CustomInt1Name { get; set; }

    public bool CustomInt2State { get; set; }

    [MaxLength(ParamsData.MaxLengthForStringField)]
    public string? CustomInt2Name { get; set; }

    public bool CustomInt3State { get; set; }

    [MaxLength(ParamsData.MaxLengthForStringField)]
    public string? CustomInt3Name { get; set; }

    public bool CustomDate1State { get; set; }

    [MaxLength(ParamsData.MaxLengthForStringField)]
    public string? CustomDate1Name { get; set; }

    public bool CustomDate2State { get; set; }

    [MaxLength(ParamsData.MaxLengthForStringField)]
    public string? CustomDate2Name { get; set; }

    public bool CustomDate3State { get; set; }

    [MaxLength(ParamsData.MaxLengthForStringField)]
    public string? CustomDate3Name { get; set; }

    public bool CustomText1State { get; set; }

    [MaxLength(ParamsData.MaxLengthForStringField)]
    public string? CustomText1Name { get; set; }

    public bool CustomText2State { get; set; }

    [MaxLength(ParamsData.MaxLengthForStringField)]
    public string? CustomText2Name { get; set; }

    public bool CustomText3State { get; set; }

    [MaxLength(ParamsData.MaxLengthForStringField)]
    public string? CustomText3Name { get; set; }

    public bool CustomCheckBox1State { get; set; }

    [MaxLength(ParamsData.MaxLengthForStringField)]
    public string? CustomCheckBox1Name { get; set; }

    public bool CustomCheckBox2State { get; set; }

    [MaxLength(ParamsData.MaxLengthForStringField)]
    public string? CustomCheckBox2Name { get; set; }

    public bool CustomCheckBox3State { get; set; }

    [MaxLength(ParamsData.MaxLengthForStringField)]
    public string? CustomCheckBox3Name { get; set; }
}
