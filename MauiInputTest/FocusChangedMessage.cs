using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MauiInputTest;

/// <summary>
/// A message for notifying when an InputBox has received or lost focus.
/// </summary>
public class FocusChangedMessage : ValueChangedMessage<BindableObject>
{
	/// <summary>
	/// Initializes a new instance of the <see cref="FocusChangedMessage"/> class.
	/// </summary>
	/// <param name="value"></param>
	public FocusChangedMessage(BindableObject value) : base(value)
	{
	}
}
