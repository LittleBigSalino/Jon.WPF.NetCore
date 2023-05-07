

# Password Strength Indicator (C# .NET v6.0)

A custom WPF user control for C# .NET v6.0 applications that provides a visual representation of a password's strength while meeting customizable password requirements. This control will update in real-time as the user types and offers additional information when hovered.

## Features

- A series of selectable enum properties for setting password requirements:
  - `PasswordRequirementComponent.RequireUpper`
  - `PasswordRequirementComponent.RequireLower`
  - `PasswordRequirementComponent.RequireNumber`
  - `PasswordRequirementComponent.RequireSymbol`
  - `PasswordRequirementComponent.RequireNonsequentialAlpha`
  - `PasswordRequirementComponent.RequireNonsequentialKeyboardLayoutASDF`
  - `PasswordRequirementComponent.RequireMixedCase`
  - `PasswordRequirementComponent.RequireNoCommonPatterns`
  - `PasswordRequirementComponent.RequireNoDictionaryWords`
  - `PasswordRequirementComponent.RequireNoRepeatedCharacters`
  
- Configurable character length requirements:
  - `MinCharacters` (default: 8)
  - `NumCharactersStrongPassword` (default: 12)

- Real-time password strength updates:
  - Visual representation using a colored textual string
  - Color and text change based on password strength
    - Red: "Does not meet requirements"
    - Orange: "Weak Password"
    - Yellow: "Meets Requirements" (carefully selected for visibility)
    - Green: "Strong Password"

- Hovering behavior:
  - When the user hovers over the strength indicator, a tooltip will explain the strength assessment.

- Customizability:
  - Set the color and verbiage for each strength level
  - Normal customizability for font sizes and families

- Binding:
  - A dependency property for the password itself
  - Allows the user to implement any password input control and bind the string value

## Usage

1. Add the Password Strength Indicator user control to your C# .NET v6.0 WPF project.
2. Configure the desired password requirements and character length requirements.
3. Bind the password value from the input control to the Password Strength Indicator control.
4. Implement any additional customizations for colors, font styles, or strength level verbiage as needed.