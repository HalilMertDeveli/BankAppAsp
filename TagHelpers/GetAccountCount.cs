﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using Udemy.BankApp.Data.Context;

namespace Udemy.BankApp.TagHelpers
{
    [HtmlTargetElement("getAccountCount")]
    public class GetAccountCount : TagHelper
    {
        public int ApplicationUserId { get; set; }
        private readonly BankContext _context;
        public GetAccountCount(BankContext context)
        {
            _context = context;
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var accountCount = _context.Accounts.Count(x=>x.ApplicationUserId == ApplicationUserId);

            var html = $"<span class = 'badge bg-danger'>{accountCount} <span/> ";


            output.Content.SetHtmlContent(html);
            base.Process(context, output);
        }
    }
}
