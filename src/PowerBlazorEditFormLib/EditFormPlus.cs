using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using System.Collections.Generic;

namespace PowerBlazorEditFormLib.BlazorControls
{

    /// <summary>
    /// És un EditForm que a més envia un cascadevalue dels membres a excloure a sumari.
    /// </summary>
    public class EditFormPlus: EditForm
    {

        public List<FieldIdentifier> ExcludeMembers = new List<FieldIdentifier>();

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {

            RenderFragment r = (b2) => { base.BuildRenderTree(b2); };

            builder.OpenRegion(EditContext.GetHashCode() + 1);

            builder.OpenComponent<CascadingValue<EditFormPlus>>(1);
            builder.AddAttribute(2, "Value", this);
            builder.AddAttribute(3, "ChildContent", r );
            builder.CloseComponent();
            builder.CloseRegion();


        }
    }
}
