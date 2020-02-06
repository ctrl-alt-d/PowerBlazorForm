using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PowerBlazorEditFormLib.BlazorControls
{
    /// <summary>
    /// És un ValidationSummary que només mostra els missatges que no apareixen lligats als membres.
    /// </summary>
    public class ValidationSummaryPlus : ValidationSummary
    {
        [CascadingParameter] EditContext? CurrentEditContext2 { get; set; }
        [CascadingParameter] EditFormPlus? EditFormPlus { get; set; }

        /// <inheritdoc />
        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {

            var excluded =
                CurrentEditContext2 != null 
                ?EditFormPlus?
                .ExcludeMembers
                .SelectMany(x =>
                    CurrentEditContext2
                    .GetValidationMessages(x)
                )
                .ToList() ?? new List<string>()
                :
                new List<string>();

            var validationMessages =
                CurrentEditContext2?
                .GetValidationMessages()
                .Where(x=>!excluded.Contains(x))
                .ToList()
                ??  throw new NullReferenceException()
                ;

            var first = true;
            foreach (var error in validationMessages)
            {
                if (first)
                {
                    first = false;

                    builder.OpenElement(0, "ul");
                    builder.AddMultipleAttributes(1, AdditionalAttributes);
                    builder.AddAttribute(2, "class", "validation-errors");
                }

                builder.OpenElement(3, "li");
                builder.AddAttribute(4, "class", "validation-message");
                builder.AddContent(5, error);
                builder.CloseElement();
            }

            if (!first)
            {
                // We have at least one validation message.
                builder.CloseElement();
            }
        }

    }
}

