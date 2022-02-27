using ReviewsApp.Models.Settings.Constrains;
using System.ComponentModel.DataAnnotations;

namespace ReviewsApp.ViewModels;

public class TagViewModel
{
    [MaxLength(TagConstrains.TextMaxLength)]
    public string Tag1 { get; set; }

    [MaxLength(TagConstrains.TextMaxLength)]
    public string Tag2 { get; set; }

    [MaxLength(TagConstrains.TextMaxLength)]
    public string Tag3 { get; set; }

    [MaxLength(TagConstrains.TextMaxLength)]
    public string Tag4 { get; set; }

    [MaxLength(TagConstrains.TextMaxLength)]
    public string Tag5 { get; set; }
}