﻿#nullable disable

namespace Greenovative.Identity.App.ViewModels;

public partial class StoreViewModel
{
    public StoreViewModel()
    {

    }

    public int Id { get; set; }
    public int? ClientId { get; set; }
    public string StoreNumber { get; set; }
    public string StoreName { get; set; }
    public string RegisteredName { get; set; }
    public string Tinno { get; set; }
    //public byte? BusinessTypeId { get; set; }
    //public byte? BusinessCategoryId { get; set; }
    public bool? IsActive { get; set; }

}
