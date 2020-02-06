# Blazor EditForm Plus

### Learning #Blazor


This project is a demo about how to customize EditForm, ValidationMessage and ValidationSummary via inheritance to avoid dup messages. Ussualy messages  appear for twice: on member and on summary. This customization avoid dups.

```c#

<EditFormPlus EditContext="@MyEditContext" OnValidSubmit="HandleValidSubmit">
    <DataAnnotationsValidator />
    <p>
        <label>
            Identifier:
            <InputText @bind-Value="_starship.Identifier" />
            <ValidationMessagePlus For="@( ()=>_starship.Identifier )" />
            <!-- It has validation message, will not appears dup on summary -->
        </label>
    </p>

    <p>
        <label>
            <InputCheckbox @bind-Value="_starship.IsValidatedDesign" />
            Engineering Approval (No <em>ValidationMessage</em> on input):
            <!-- It does not have validation message, will be appear on summary -->
        </label>
    </p>

    <p style="border: 1px solid; padding: 20px; margin-top: 10px">
        Summary Validations area, only for "Engineering Approval"
        <ValidationSummaryPlus />
    </p>

</EditFormPlus>
```

#### Screen shot 

_(because all us love screenshots)_

![screenshot demo](./ScreenShots/validations.gif)


