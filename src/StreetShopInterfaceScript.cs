using System;
using UnityEngine;
using UnityEngine.PostProcessing;

public class StreetShopInterfaceScript : MonoBehaviour
{
	public StreetManagerScript StreetManager;

	public InputManagerScript InputManager;

	public PostProcessingProfile Profile;

	public StalkerYandereScript Yandere;

	public PromptBarScript PromptBar;

	public UILabel SpeechBubbleLabel;

	public UILabel StoreNameLabel;

	public UILabel MoneyLabel;

	public Texture[] ShopkeeperPortraits;

	public string[] ShopkeeperSpeeches;

	public UILabel[] ProductsLabel;

	public UILabel[] PricesLabel;

	public UITexture Shopkeeper;

	public Transform SpeechBubbleParent;

	public Transform MaidWindow;

	public Transform Highlight;

	public Transform Interface;

	public float BlurAmount;

	public float Timer;

	public int SpeechPhase;

	public int Selected;

	public int Limit;

	public bool ShowMaid;

	public bool Show;

	private void Start()
	{
		this.Shopkeeper.transform.localPosition = new Vector3(1485f, 0f, 0f);
		this.Interface.localPosition = new Vector3(-815.5f, 0f, 0f);
		this.SpeechBubbleParent.localScale = new Vector3(0f, 0f, 0f);
	}

	private void Update()
	{
		if (this.Show)
		{
			this.Shopkeeper.transform.localPosition = Vector3.Lerp(this.Shopkeeper.transform.localPosition, new Vector3(500f, 0f, 0f), Time.deltaTime * 10f);
			this.Interface.localPosition = Vector3.Lerp(this.Interface.localPosition, new Vector3(100f, 0f, 0f), Time.deltaTime * 10f);
			this.BlurAmount = Mathf.Lerp(this.BlurAmount, 0f, Time.deltaTime * 10f);
			if (Input.GetButtonUp("B"))
			{
				this.Yandere.RPGCamera.enabled = true;
				this.PromptBar.Show = false;
				this.Yandere.CanMove = true;
				this.Show = false;
			}
			if (this.Timer > 0.5f && Input.GetButtonUp("A"))
			{
				this.SpeechBubbleLabel.text = this.ShopkeeperSpeeches[3];
				this.SpeechBubbleParent.localScale = new Vector3(0f, 0f, 0f);
				this.SpeechPhase = 0;
				this.Timer = 1f;
			}
			if (this.InputManager.TappedDown)
			{
				this.Selected++;
				if (this.Selected > this.Limit)
				{
					this.Selected = 1;
				}
				this.UpdateHighlight();
			}
			else if (this.InputManager.TappedUp)
			{
				this.Selected--;
				if (this.Selected < 1)
				{
					this.Selected = this.Limit;
				}
				this.UpdateHighlight();
			}
			this.Timer += Time.deltaTime;
			if (this.Timer > 0.5f)
			{
				this.SpeechBubbleParent.localScale = Vector3.Lerp(this.SpeechBubbleParent.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			}
			if (this.SpeechPhase == 0)
			{
				this.Shopkeeper.mainTexture = this.ShopkeeperPortraits[1];
				this.SpeechPhase++;
			}
			else if (this.Timer > 10f)
			{
				if (this.SpeechPhase == 1)
				{
					this.SpeechBubbleLabel.text = this.ShopkeeperSpeeches[2];
					this.Shopkeeper.mainTexture = this.ShopkeeperPortraits[2];
					this.SpeechBubbleParent.localScale = new Vector3(0f, 0f, 0f);
					this.SpeechPhase++;
				}
				else if (this.SpeechPhase == 2 && this.Timer > 10.1f)
				{
					int num = UnityEngine.Random.Range(2, 4);
					this.Shopkeeper.mainTexture = this.ShopkeeperPortraits[num];
					this.Timer = 10f;
				}
			}
		}
		else
		{
			this.SpeechBubbleParent.localScale = new Vector3(0f, 0f, 0f);
			this.Shopkeeper.transform.localPosition = Vector3.Lerp(this.Shopkeeper.transform.localPosition, new Vector3(1604f, 0f, 0f), Time.deltaTime * 10f);
			this.Interface.localPosition = Vector3.Lerp(this.Interface.localPosition, new Vector3(-815.5f, 0f, 0f), Time.deltaTime * 10f);
			if (this.ShowMaid)
			{
				this.BlurAmount = Mathf.Lerp(this.BlurAmount, 0f, Time.deltaTime * 10f);
				this.MaidWindow.localScale = Vector3.Lerp(this.MaidWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				if (Input.GetButtonDown("A"))
				{
					this.StreetManager.FadeOut = true;
					this.StreetManager.GoToCafe = true;
				}
				else if (Input.GetButtonDown("B"))
				{
					this.Yandere.RPGCamera.enabled = true;
					this.Yandere.CanMove = true;
					this.ShowMaid = false;
				}
			}
			else
			{
				this.BlurAmount = Mathf.Lerp(this.BlurAmount, 0.6f, Time.deltaTime * 10f);
				this.MaidWindow.localScale = Vector3.Lerp(this.MaidWindow.localScale, new Vector3(0f, 0f, 0f), Time.deltaTime * 10f);
			}
		}
		this.AdjustBlur();
	}

	private void AdjustBlur()
	{
		DepthOfFieldModel.Settings settings = this.Profile.depthOfField.settings;
		settings.focusDistance = this.BlurAmount;
		this.Profile.depthOfField.settings = settings;
	}

	public void UpdateHighlight()
	{
		this.Highlight.localPosition = new Vector3(-50f, (float)(50 - 50 * this.Selected), 0f);
	}
}
