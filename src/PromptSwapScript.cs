using System;
using UnityEngine;

public class PromptSwapScript : MonoBehaviour
{
	public InputDeviceScript InputDevice;

	public UISprite MySprite;

	public string KeyboardName = string.Empty;

	public string GamepadName = string.Empty;

	private void Awake()
	{
		if (this.InputDevice == null)
		{
			this.InputDevice = UnityEngine.Object.FindObjectOfType<InputDeviceScript>();
		}
	}

	public void UpdateSpriteType(InputDeviceType deviceType)
	{
		this.MySprite.spriteName = ((deviceType != InputDeviceType.Gamepad) ? this.KeyboardName : this.GamepadName);
	}
}
