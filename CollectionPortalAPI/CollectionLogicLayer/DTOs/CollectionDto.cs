using Microsoft.AspNetCore.Http;

namespace CollectionLogicLayer.DTOs;

public record CollectionDto
{
    public string Name { get; set; } = null!;

    public int CategoryId { get; set; }

    public string? Description { get; set; }

    public IFormFile? Image { get; set; }

    public bool CustomString1State { get; set; }

    public string? CustomString1Name { get; set; }

    public bool CustomString2State { get; set; }

    public string? CustomString2Name { get; set; }

    public bool CustomString3State { get; set; }

    public string? CustomString3Name { get; set; }

    public bool CustomInt1State { get; set; }

    public string? CustomInt1Name { get; set; }

    public bool CustomInt2State { get; set; }

    public string? CustomInt2Name { get; set; }

    public bool CustomInt3State { get; set; }

    public string? CustomInt3Name { get; set; }

    public bool CustomDate1State { get; set; }

    public string? CustomDate1Name { get; set; }

    public bool CustomDate2State { get; set; }

    public string? CustomDate2Name { get; set; }

    public bool CustomDate3State { get; set; }

    public string? CustomDate3Name { get; set; }

    public bool CustomText1State { get; set; }

    public string? CustomText1Name { get; set; }

    public bool CustomText2State { get; set; }

    public string? CustomText2Name { get; set; }

    public bool CustomText3State { get; set; }

    public string? CustomText3Name { get; set; }

    public bool CustomCheckBox1State { get; set; }

    public string? CustomCheckBox1Name { get; set; }

    public bool CustomCheckBox2State { get; set; }

    public string? CustomCheckBox2Name { get; set; }

    public bool CustomCheckBox3State { get; set; }

    public string? CustomCheckBox3Name { get; set; }
}


