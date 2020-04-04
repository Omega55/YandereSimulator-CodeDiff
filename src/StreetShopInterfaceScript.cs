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

	public UISprite[] Icons;

	public bool[] AdultProducts;

	public float[] Costs;

	public UITexture Shopkeeper;

	public Transform SpeechBubbleParent;

	public Transform MaidWindow;

	public Transform Highlight;

	public Transform Interface;

	public GameObject FakeIDBox;

	public AudioSource MyAudio;

	public int ShopkeeperPosition;

	public int SpeechPhase;

	public int Selected;

	public int Limit;

	public float BlurAmount;

	public float Timer;

	public bool ShowMaid;

	public bool Show;

	public ShopType CurrentStore;

	private void Start()
	{
		this.Shopkeeper.transform.localPosition = new Vector3(1485f, 0f, 0f);
		this.Interface.localPosition = new Vector3(-815.5f, 0f, 0f);
		this.SpeechBubbleParent.localScale = new Vector3(0f, 0f, 0f);
		this.UpdateFakeID();
	}

	private void Update()
	{
		if (this.Show)
		{
			this.Shopkeeper.transform.localPosition = Vector3.Lerp(this.Shopkeeper.transform.localPosition, new Vector3((float)this.ShopkeeperPosition, 0f, 0f), Time.deltaTime * 10f);
			this.Interface.localPosition = Vector3.Lerp(this.Interface.localPosition, new Vector3(100f, 0f, 0f), Time.deltaTime * 10f);
			this.BlurAmount = Mathf.Lerp(this.BlurAmount, 0f, Time.deltaTime * 10f);
			if (Input.GetButtonUp("B"))
			{
				this.Yandere.RPGCamera.enabled = true;
				this.PromptBar.Show = false;
				this.Yandere.CanMove = true;
				this.Show = false;
			}
			if (this.Timer > 0.5f && Input.GetButtonUp("A") && this.Icons[this.Selected].spriteName != "Yes")
			{
				this.CheckStore();
				this.UpdateIcons();
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

	public void CheckStore()
	{
		if (this.AdultProducts[this.Selected] && !PlayerGlobals.FakeID)
		{
			this.SpeechBubbleLabel.text = this.ShopkeeperSpeeches[3];
			this.SpeechBubbleParent.localScale = new Vector3(0f, 0f, 0f);
			this.SpeechPhase = 0;
			this.Timer = 1f;
		}
		else if (PlayerGlobals.Money < this.Costs[this.Selected])
		{
			this.StreetManager.Clock.MoneyFail();
			this.SpeechBubbleLabel.text = this.ShopkeeperSpeeches[4];
			this.SpeechBubbleParent.localScale = new Vector3(0f, 0f, 0f);
			this.SpeechPhase = 0;
			this.Timer = 1f;
		}
		else
		{
			switch (this.CurrentStore)
			{
			case ShopType.Nonfunctional:
				this.SpeechBubbleLabel.text = this.ShopkeeperSpeeches[6];
				this.SpeechBubbleParent.localScale = new Vector3(0f, 0f, 0f);
				this.SpeechPhase = 0;
				this.Timer = 1f;
				break;
			case ShopType.Manga:
				this.PurchaseEffect();
				switch (this.Selected)
				{
				case 1:
					CollectibleGlobals.SetMangaCollected(6, true);
					break;
				case 2:
					CollectibleGlobals.SetMangaCollected(7, true);
					break;
				case 3:
					CollectibleGlobals.SetMangaCollected(8, true);
					break;
				case 4:
					CollectibleGlobals.SetMangaCollected(9, true);
					break;
				case 5:
					CollectibleGlobals.SetMangaCollected(10, true);
					break;
				case 6:
					CollectibleGlobals.SetMangaCollected(1, true);
					break;
				case 7:
					CollectibleGlobals.SetMangaCollected(2, true);
					break;
				case 8:
					CollectibleGlobals.SetMangaCollected(3, true);
					break;
				case 9:
					CollectibleGlobals.SetMangaCollected(4, true);
					break;
				case 10:
					CollectibleGlobals.SetMangaCollected(5, true);
					break;
				}
				break;
			case ShopType.Salon:
				this.SpeechBubbleLabel.text = this.ShopkeeperSpeeches[6];
				this.SpeechBubbleParent.localScale = new Vector3(0f, 0f, 0f);
				this.SpeechPhase = 0;
				this.Timer = 1f;
				break;
			case ShopType.Gift:
				this.PurchaseEffect();
				if (this.Selected < 6)
				{
					CollectibleGlobals.SenpaiGifts++;
				}
				else
				{
					CollectibleGlobals.MatchmakingGifts++;
				}
				CollectibleGlobals.SetGiftPurchased(this.Selected, true);
				break;
			case ShopType.Lingerie:
				this.PurchaseEffect();
				CollectibleGlobals.SetPantyPurchased(this.Selected, true);
				break;
			}
		}
	}

	public void PurchaseEffect()
	{
		this.SpeechBubbleLabel.text = this.ShopkeeperSpeeches[5];
		this.SpeechBubbleParent.localScale = new Vector3(0f, 0f, 0f);
		this.SpeechPhase = 0;
		this.Timer = 1f;
		PlayerGlobals.Money -= this.Costs[this.Selected];
		this.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2");
		this.StreetManager.Clock.UpdateMoneyLabel();
		this.MyAudio.Play();
	}

	public void UpdateFakeID()
	{
		this.FakeIDBox.SetActive(PlayerGlobals.FakeID);
	}

	public void UpdateIcons()
	{
		for (int i = 1; i < 11; i++)
		{
			this.Icons[i].spriteName = string.Empty;
			this.Icons[i].gameObject.SetActive(false);
			this.ProductsLabel[i].color = new Color(1f, 1f, 1f, 1f);
		}
		for (int i = 1; i < 11; i++)
		{
			if (this.AdultProducts[i])
			{
				this.Icons[i].spriteName = "18+";
			}
		}
		ShopType currentStore = this.CurrentStore;
		if (currentStore != ShopType.Manga)
		{
			if (currentStore != ShopType.Gift)
			{
				if (currentStore == ShopType.Lingerie)
				{
					for (int i = 1; i < 11; i++)
					{
						if (CollectibleGlobals.GetPantyPurchased(i))
						{
							this.Icons[i].spriteName = "Yes";
							this.PricesLabel[i].text = "Owned";
						}
					}
				}
			}
			else
			{
				for (int i = 1; i < 11; i++)
				{
					if (CollectibleGlobals.GetGiftPurchased(i))
					{
						this.Icons[i].spriteName = "Yes";
						this.PricesLabel[i].text = "Owned";
					}
				}
			}
		}
		else
		{
			if (CollectibleGlobals.GetMangaCollected(1))
			{
				this.Icons[6].spriteName = "Yes";
				this.PricesLabel[6].text = "Owned";
			}
			if (CollectibleGlobals.GetMangaCollected(2))
			{
				this.Icons[7].spriteName = "Yes";
				this.PricesLabel[7].text = "Owned";
			}
			if (CollectibleGlobals.GetMangaCollected(3))
			{
				this.Icons[8].spriteName = "Yes";
				this.PricesLabel[8].text = "Owned";
			}
			if (CollectibleGlobals.GetMangaCollected(4))
			{
				this.Icons[9].spriteName = "Yes";
				this.PricesLabel[9].text = "Owned";
			}
			if (CollectibleGlobals.GetMangaCollected(5))
			{
				this.Icons[10].spriteName = "Yes";
				this.PricesLabel[10].text = "Owned";
			}
			if (CollectibleGlobals.GetMangaCollected(6))
			{
				this.Icons[1].spriteName = "Yes";
				this.PricesLabel[1].text = "Owned";
			}
			if (CollectibleGlobals.GetMangaCollected(7))
			{
				this.Icons[2].spriteName = "Yes";
				this.PricesLabel[2].text = "Owned";
			}
			if (CollectibleGlobals.GetMangaCollected(8))
			{
				this.Icons[3].spriteName = "Yes";
				this.PricesLabel[3].text = "Owned";
			}
			if (CollectibleGlobals.GetMangaCollected(9))
			{
				this.Icons[4].spriteName = "Yes";
				this.PricesLabel[4].text = "Owned";
			}
			if (CollectibleGlobals.GetMangaCollected(10))
			{
				this.Icons[5].spriteName = "Yes";
				this.PricesLabel[5].text = "Owned";
			}
		}
		for (int i = 1; i < 11; i++)
		{
			if (this.Icons[i].spriteName != string.Empty)
			{
				this.Icons[i].gameObject.SetActive(true);
				if (this.Icons[i].spriteName == "Yes")
				{
					this.ProductsLabel[i].color = new Color(1f, 1f, 1f, 0.5f);
				}
			}
		}
	}
}
