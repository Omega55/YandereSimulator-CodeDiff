using System;
using UnityEngine;

public class PromptSwapScript : MonoBehaviour
{
	public InputDeviceScript InputDevice;

	public UISprite MySprite;

	public string KeyboardName = string.Empty;

	public string GamepadName = string.Empty;

	private int LastType = 1;

	private void Start()
	{
		if (this.InputDevice == null)
		{
			this.InputDevice = base.transform.parent.gameObject.GetComponent<InputDeviceScript>();
		}
	}

	private void Update()
	{
		if (this.InputDevice != null)
		{
			if (this.InputDevice.Type != this.LastType)
			{
				this.MySprite.spriteName = ((this.InputDevice.Type != 1) ? this.KeyboardName : this.GamepadName);
			}
			this.LastType = this.InputDevice.Type;
		}
		else
		{
			Debug.Log("My name is " + base.gameObject.name);
		}
	}
}
