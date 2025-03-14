namespace MauiInputTest;

/// <summary>
/// Specifies the type of keyboard to display for an <see cref="InputBox"/>.
/// </summary>
public enum InputBoxKeyboard
{
	/*
    Number = Keyboard.Numeric,
    Phone = Keyboard.Telephone,
    Email = Keyboard.Email,
    Url = Keyboard.Url,
    Chat = Keyboard.Chat,
    Default = Keyboard.Default,
    */
	/// <summary>
	/// No keyboard specified.
	/// </summary>
	None,

	/// <summary>
	/// The default keyboard.
	/// </summary>
	Default,

	/// <summary>
	/// A keyboard for entering numbers.
	/// </summary>
	Number,

	/// <summary>
	/// A keyboard for calculating numbers.
	/// </summary>
	Calculator,
}
