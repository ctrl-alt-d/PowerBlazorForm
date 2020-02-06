using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace PowerBlazorEditFormLib.BlazorControls
{
    /// <summary>
    /// És un ValidationMessage que a més registgre els fors quan es treballa amb un EditFormPlus.
    /// https://github.com/dotnet/aspnetcore/blob/master/src/Components/Web/src/Forms/ValidationMessage.cs
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public class ValidationMessagePlus<TValue> : ValidationMessage<TValue>
    {

        protected override void OnParametersSet()
        {

            base.OnParametersSet();

            if (For != _previousFieldAccessor)
            {
                var _fieldIdentifier = FieldIdentifier.Create(For);
                Register(_fieldIdentifier,_previousFieldIdentifier);
                _previousFieldAccessor = For;
                _previousFieldIdentifier = _fieldIdentifier;
            }

        }
        #region custom
        [CascadingParameter] EditFormPlus? EditFormPlus { get; set; }
        private FieldIdentifier? _previousFieldIdentifier;
        private Expression<Func<TValue>>? _previousFieldAccessor;

        private void Register(FieldIdentifier? fieldIdentifier, FieldIdentifier? previousFieldAccessor)
        {
            if (EditFormPlus == null) return;
            if (previousFieldAccessor != null)
                EditFormPlus.ExcludeMembers =
                    EditFormPlus
                    .ExcludeMembers
                    .Where(
                        x=> x.FieldName != ( previousFieldAccessor ?? throw new NullReferenceException()).FieldName )
                    .ToList();
            if (fieldIdentifier != null) EditFormPlus.ExcludeMembers.Add(fieldIdentifier ?? throw new NullReferenceException());
        }
        #endregion
    }
}
