﻿using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetCoreIdentityApp.Web.TagHelpers
{
    public class UserPictureThumbnailTagHelper : TagHelper
    {

        public string? PictureUrl { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img";
            if (String.IsNullOrEmpty(PictureUrl))
            {
                output.Attributes.SetAttribute("src", "/userpictures/default_user_pictures.jpg");
            }
            else
            {
                output.Attributes.SetAttribute("src", $"/userpictures/{PictureUrl}");
            }
        }
    }
}