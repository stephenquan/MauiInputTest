using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Maui.Controls.Shapes;

namespace MauiInputTest;

/// <summary>
/// A customized Entry component that has some additional properties and methods.
/// </summary>
public partial class InputBox : Entry
{
	/// <summary>
	/// Bindable property for <see cref="InputBoxKeyboard"/>.
	/// </summary>
	public static BindableProperty InputBoxKeyboardProperty = BindableProperty.Create(nameof(InputBoxKeyboard), typeof(InputBoxKeyboard), typeof(InputBox), InputBoxKeyboard.Default);

	/// <summary>
	/// Gets or sets the keyboard type for the input box.
	/// </summary>
	public InputBoxKeyboard InputBoxKeyboard
	{
		get => (InputBoxKeyboard)GetValue(InputBoxKeyboardProperty);
		set => SetValue(InputBoxKeyboardProperty, value);
	}

	/// <summary>
	/// Bindable property for <see cref="IsPointerOver"/>.
	/// </summary>
	public static BindableProperty IsPointerOverProperty = BindableProperty.Create(nameof(IsPointerOver), typeof(bool), typeof(InputBox), false);

	/// <summary>
	/// Gets or sets a value indicating whether the pointer is over the input box.
	/// </summary>
	public bool IsPointerOver
	{
		get => (bool)GetValue(IsPointerOverProperty);
		internal set => SetValue(IsPointerOverProperty, value);
	}

	/// <summary>
	/// Gets the clip geometry that removes the Entry's border and underline.
	/// </summary>
	public RectangleGeometry ClipGeometry =>
		Width >= 8 && Height >= 24
#if WINDOWS
        ? new RectangleGeometry() {Rect = new Rect(4, 6, Width - 8, Height - 12) }
#elif ANDROID
		? new RectangleGeometry() { Rect = new Rect(4, 12, Width - 8, Height - 24) }
#else
        ? new RectangleGeometry() { Rect = new Rect(0, 0, Width, Height) }
#endif
		: new RectangleGeometry() { Rect = new Rect(0, 0, 100, 32) };

	/// <summary>
	/// Initializes a new instance of the <see cref="InputBox"/> class.
	/// </summary>
	public InputBox()
	{
		InitializeComponent();

		this.PropertyChanged += (s, e) =>
		{
			switch (e.PropertyName)
			{
				case nameof(IsFocused):
					WeakReferenceMessenger.Default.Send(new FocusChangedMessage(this));
					break;

				case nameof(Width):
				case nameof(Height):
					OnPropertyChanged(nameof(ClipGeometry));
					break;
			}
		};
	}
}
