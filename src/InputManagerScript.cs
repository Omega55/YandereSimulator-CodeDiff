using System;
using UnityEngine;

[Serializable]
public class InputManagerScript : MonoBehaviour
{
	public bool TappedUp;

	public bool TappedDown;

	public bool TappedRight;

	public bool TappedLeft;

	public bool DPadUp;

	public bool StickUp;

	public bool DPadDown;

	public bool StickDown;

	public bool DPadRight;

	public bool StickRight;

	public bool DPadLeft;

	public bool StickLeft;

	public virtual void Update()
	{
		if (Input.GetAxis("DpadY") > 0.5f)
		{
			if (!this.DPadUp)
			{
				this.TappedUp = true;
			}
			else
			{
				this.TappedUp = false;
			}
			this.DPadUp = true;
		}
		else if (Input.GetAxis("DpadY") < -0.5f)
		{
			if (!this.DPadDown)
			{
				this.TappedDown = true;
			}
			else
			{
				this.TappedDown = false;
			}
			this.DPadDown = true;
		}
		else
		{
			this.DPadUp = false;
			this.DPadDown = false;
		}
		if (Input.GetAxis("Vertical") > 0.5f)
		{
			if (!this.StickUp)
			{
				this.TappedUp = true;
			}
			else
			{
				this.TappedUp = false;
			}
			this.StickUp = true;
		}
		else if (Input.GetAxis("Vertical") < -0.5f)
		{
			if (!this.StickDown)
			{
				this.TappedDown = true;
			}
			else
			{
				this.TappedDown = false;
			}
			this.StickDown = true;
		}
		else
		{
			this.StickUp = false;
			this.StickDown = false;
		}
		if (Input.GetAxis("DpadX") > 0.5f)
		{
			if (!this.DPadRight)
			{
				this.TappedRight = true;
			}
			else
			{
				this.TappedRight = false;
			}
			this.DPadRight = true;
		}
		else if (Input.GetAxis("DpadX") < -0.5f)
		{
			if (!this.DPadLeft)
			{
				this.TappedLeft = true;
			}
			else
			{
				this.TappedLeft = false;
			}
			this.DPadLeft = true;
		}
		else
		{
			this.DPadRight = false;
			this.DPadLeft = false;
		}
		if (Input.GetAxis("Horizontal") > 0.5f)
		{
			if (!this.StickRight)
			{
				this.TappedRight = true;
			}
			else
			{
				this.TappedRight = false;
			}
			this.StickRight = true;
		}
		else if (Input.GetAxis("Horizontal") < -0.5f)
		{
			if (!this.StickLeft)
			{
				this.TappedLeft = true;
			}
			else
			{
				this.TappedLeft = false;
			}
			this.StickLeft = true;
		}
		else
		{
			this.StickRight = false;
			this.StickLeft = false;
		}
		if (Input.GetAxis("Horizontal") < 0.5f && Input.GetAxis("Horizontal") > -0.5f && Input.GetAxis("DpadX") < 0.5f && Input.GetAxis("DpadX") > -0.5f)
		{
			this.TappedRight = false;
			this.TappedLeft = false;
		}
		if (Input.GetAxis("Vertical") < 0.5f && Input.GetAxis("Vertical") > -0.5f && Input.GetAxis("DpadY") < 0.5f && Input.GetAxis("DpadY") > -0.5f)
		{
			this.TappedUp = false;
			this.TappedDown = false;
		}
	}

	public virtual void Main()
	{
	}
}
