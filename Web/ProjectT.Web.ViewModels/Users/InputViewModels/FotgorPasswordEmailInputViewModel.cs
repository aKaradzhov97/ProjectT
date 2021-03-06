﻿namespace ProjectT.Web.ViewModels.Users.InputViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class ForgotPasswordEmailInputViewModel
    {
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}