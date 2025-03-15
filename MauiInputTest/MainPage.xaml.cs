using CommunityToolkit.Maui.Core.Platform;
using CommunityToolkit.Mvvm.Messaging;

namespace MauiInputTest;

/// <summary>
/// The main page of the application.
/// </summary>
public partial class MainPage : ContentPage
{
	InputBox? activeFocus;

	/// <summary>
	/// Gets the currently focused input box.
	/// </summary>
	public InputBox? ActiveFocus
	{
		get => activeFocus;
		internal set
		{
			if (activeFocus != value)
			{
				activeFocus = value;
				OnPropertyChanged(nameof(ActiveFocus));
			}
		}
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="MainPage"/> class.
	/// </summary>
	public MainPage()
	{
		InitializeComponent();

		WeakReferenceMessenger.Default.Register<FocusChangedMessage>(this, (r, m) =>
		{
			if (m.Value is InputBox inputBox)
			{
				if (inputBox.IsFocused)
				{
					ActiveFocus = inputBox;
					ShowInputBoxKeyboard(inputBox.InputBoxKeyboard, inputBox);
				}
				else if (ActiveFocus == inputBox)
				{
					ActiveFocus = null;
					ShowInputBoxKeyboard(InputBoxKeyboard.None);
				}
			}
		});
	}

	void ShowInputBoxKeyboard(InputBoxKeyboard keyboard, InputBox? inputBox = null)
	{
		switch (keyboard)
		{
			case InputBoxKeyboard.None:
				bottomGrid.IsVisible = false;
				keyboardContentView.ControlTemplate = null;
				break;
			case InputBoxKeyboard.Default:
				bottomGrid.IsVisible = false;
				keyboardContentView.ControlTemplate = null;
				break;
			case InputBoxKeyboard.Number:
				bottomGrid.IsVisible = true;
				keyboardContentView.ControlTemplate = (ControlTemplate)Resources["NumberKeyboard"];
#if ANDROID
				this.Dispatcher.Dispatch(async () =>
				{
					await KeyboardExtensions.HideKeyboardAsync(inputBox!);
					await Task.Delay(50);
					await KeyboardExtensions.HideKeyboardAsync(inputBox!);
				});
#endif
				break;
			case InputBoxKeyboard.Calculator:
				bottomGrid.IsVisible = true;
				keyboardContentView.ControlTemplate = (ControlTemplate)Resources["CalculatorKeyboard"];
#if ANDROID
				this.Dispatcher.Dispatch(async () =>
				{
					await KeyboardExtensions.HideKeyboardAsync(inputBox!);
					await Task.Delay(50);
					await KeyboardExtensions.HideKeyboardAsync(inputBox!);
				});
#endif
				break;
		}
	}
}
