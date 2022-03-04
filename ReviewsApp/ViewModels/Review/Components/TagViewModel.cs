using ReviewsApp.Models.Settings.Constrains;
using System.ComponentModel.DataAnnotations;

namespace ReviewsApp.ViewModels.Review.Components;

public class TagViewModel
{
    public int Tag1Id { get; set; }
    [MaxLength(TagConstrains.TextMaxLength)]
    public string Tag1 { get; set; }

    public int Tag2Id { get; set; }
    [MaxLength(TagConstrains.TextMaxLength)]
    public string Tag2 { get; set; }

    public int Tag3Id { get; set; }
    [MaxLength(TagConstrains.TextMaxLength)]
    public string Tag3 { get; set; }

    public int Tag4Id { get; set; }
    [MaxLength(TagConstrains.TextMaxLength)]
    public string Tag4 { get; set; }

    public int Tag5Id { get; set; }
    [MaxLength(TagConstrains.TextMaxLength)]
    public string Tag5 { get; set; }
}