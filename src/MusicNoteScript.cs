using System;
using UnityEngine;

public class MusicNoteScript : MonoBehaviour
{
	public MusicMinigameScript MusicMinigame;

	public InputManagerScript InputManager;

	public GameObject Ripple;

	public GameObject Perfect;

	public GameObject Wrong;

	public GameObject Early;

	public GameObject Late;

	public GameObject Miss;

	public GameObject Rating;

	public string XboxDirection;

	public string Direction;

	public string Tapped;

	public bool GaveInput;

	public bool Proceed;

	public float Speed;

	public int ID;

	private void Update()
	{
		base.transform.localPosition += new Vector3(this.Speed * Time.deltaTime * -1f, 0f, 0f);
		if (!this.MusicMinigame.KeyDown)
		{
			this.GaveInput = false;
			if (this.InputManager.TappedUp)
			{
				this.GaveInput = true;
				this.Tapped = "up";
			}
			else if (this.InputManager.TappedDown)
			{
				this.GaveInput = true;
				this.Tapped = "down";
			}
			else if (this.InputManager.TappedRight)
			{
				this.GaveInput = true;
				this.Tapped = "right";
			}
			else if (this.InputManager.TappedLeft)
			{
				this.GaveInput = true;
				this.Tapped = "left";
			}
			if (Input.GetKeyDown(this.Direction) || (this.GaveInput && this.Tapped == this.Direction))
			{
				if (this.MusicMinigame.CurrentNote == this.ID)
				{
					if (base.transform.localPosition.x > -0.6f && base.transform.localPosition.x < -0.4f)
					{
						this.Rating = Object.Instantiate<GameObject>(this.Perfect, base.transform.position, Quaternion.identity);
						this.Proceed = true;
						this.MusicMinigame.Health += 1f;
						this.MusicMinigame.CringeTimer = 0f;
						this.MusicMinigame.UpdateHealthBar();
					}
					else if (base.transform.localPosition.x > -0.4f && base.transform.localPosition.x < -0.2f)
					{
						this.Rating = Object.Instantiate<GameObject>(this.Early, base.transform.position, Quaternion.identity);
						this.MusicMinigame.CringeTimer = 0f;
						this.Proceed = true;
					}
					else if (base.transform.localPosition.x > -0.8f && base.transform.localPosition.x < -0.4f)
					{
						this.Rating = Object.Instantiate<GameObject>(this.Late, base.transform.position, Quaternion.identity);
						this.MusicMinigame.CringeTimer = 0f;
						this.Proceed = true;
					}
				}
			}
			else if (Input.anyKeyDown && base.transform.localPosition.x > -0.8f && base.transform.localPosition.x < -0.2f && !this.MusicMinigame.GameOver)
			{
				this.Rating = Object.Instantiate<GameObject>(this.Wrong, base.transform.position, Quaternion.identity);
				this.Proceed = true;
				this.MusicMinigame.Cringe();
				if (!this.MusicMinigame.LockHealth)
				{
					this.MusicMinigame.Health -= 10f;
				}
				this.MusicMinigame.UpdateHealthBar();
			}
		}
		if (this.Proceed)
		{
			GameObject gameObject = Object.Instantiate<GameObject>(this.Ripple, base.transform.position, Quaternion.identity);
			gameObject.transform.parent = base.transform.parent;
			gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
			this.Rating.transform.parent = base.transform.parent;
			this.Rating.transform.localPosition = new Vector3(-0.5f, 0.25f, 0f);
			this.Rating.transform.localScale = new Vector3(0.3f, 0.15f, 0.15f);
			this.MusicMinigame.CurrentNote++;
			this.MusicMinigame.KeyDown = true;
			Object.Destroy(base.gameObject);
		}
		else if (base.transform.localPosition.x < -0.65f && this.MusicMinigame.CurrentNote == this.ID)
		{
			this.MusicMinigame.CurrentNote++;
		}
		if (base.transform.localPosition.x < -0.94f && !this.MusicMinigame.GameOver)
		{
			this.Rating = Object.Instantiate<GameObject>(this.Miss, base.transform.position, Quaternion.identity);
			this.Rating.transform.parent = base.transform.parent;
			this.Rating.transform.localPosition = new Vector3(-0.94f, 0.25f, 0f);
			this.Rating.transform.localScale = new Vector3(0.3f, 0.15f, 0.15f);
			Object.Destroy(base.gameObject);
			this.MusicMinigame.Cringe();
			if (!this.MusicMinigame.LockHealth)
			{
				this.MusicMinigame.Health -= 10f;
			}
			this.MusicMinigame.UpdateHealthBar();
		}
	}
}
