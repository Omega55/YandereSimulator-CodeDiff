using System;
using System.Globalization;
using UnityEngine;

public class StreetShopScript : MonoBehaviour
{
	public StreetShopInterfaceScript StreetShopInterface;

	public StreetManagerScript StreetManager;

	public InputDeviceScript InputDevice;

	public StalkerYandereScript Yandere;

	public PromptBarScript PromptBar;

	public HomeClockScript HomeClock;

	public GameObject BinocularOverlay;

	public Renderer BinocularRenderer;

	public Camera BinocularCamera;

	public AudioSource MyAudio;

	public AudioClip InsertCoin;

	public AudioClip Fail;

	public UILabel MyLabel;

	public Texture[] ShopkeeperPortraits;

	public string[] ShopkeeperSpeeches;

	public bool[] AdultProducts;

	public string[] Products;

	public float[] Costs;

	public float RotationX;

	public float RotationY;

	public float Alpha;

	public float Zoom;

	public int ShopkeeperPosition = 500;

	public int Limit;

	public bool Binoculars;

	public bool MaidCafe;

	public bool Exit;

	public string StoreName;

	public ShopType StoreType;

	private void Start()
	{
		this.MyLabel.color = new Color(1f, 1f, 1f, 0f);
	}

	private void Update()
	{
		if (Vector3.Distance(this.Yandere.transform.position, base.transform.position) < 1f)
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * 10f);
		}
		else
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime * 10f);
		}
		this.MyLabel.color = new Color(1f, 0.75f, 1f, this.Alpha);
		if (this.Alpha == 1f && Input.GetButtonDown("A"))
		{
			if (this.Exit)
			{
				this.StreetManager.FadeOut = true;
				this.Yandere.MyAnimation.CrossFade(this.Yandere.IdleAnim);
				this.Yandere.CanMove = false;
			}
			else if (this.MaidCafe)
			{
				this.StreetShopInterface.ShowMaid = true;
				this.Yandere.MyAnimation.CrossFade(this.Yandere.IdleAnim);
				this.Yandere.RPGCamera.enabled = false;
				this.Yandere.CanMove = false;
			}
			else if (!this.Binoculars)
			{
				if (!this.StreetShopInterface.Show)
				{
					this.StreetShopInterface.CurrentStore = this.StoreType;
					this.StreetShopInterface.Show = true;
					this.PromptBar.ClearButtons();
					this.PromptBar.Label[0].text = "Purchase";
					this.PromptBar.Label[1].text = "Exit";
					this.PromptBar.UpdateButtons();
					this.PromptBar.Show = true;
					this.Yandere.MyAnimation.CrossFade(this.Yandere.IdleAnim);
					this.Yandere.CanMove = false;
					this.UpdateShopInterface();
				}
			}
			else if (PlayerGlobals.Money >= 0.25f)
			{
				this.MyAudio.clip = this.InsertCoin;
				PlayerGlobals.Money -= 0.25f;
				this.HomeClock.UpdateMoneyLabel();
				this.BinocularCamera.gameObject.SetActive(true);
				this.BinocularRenderer.enabled = false;
				this.BinocularOverlay.SetActive(true);
				this.PromptBar.ClearButtons();
				this.PromptBar.Label[1].text = "Exit";
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = true;
				this.Yandere.MyAnimation.CrossFade(this.Yandere.IdleAnim);
				this.Yandere.transform.position = new Vector3(5f, 0f, 3f);
				this.Yandere.CanMove = false;
				this.MyAudio.Play();
			}
			else
			{
				this.HomeClock.MoneyFail();
			}
		}
		if (this.Binoculars && this.BinocularCamera.gameObject.activeInHierarchy)
		{
			if (this.InputDevice.Type == InputDeviceType.MouseAndKeyboard)
			{
				this.RotationX -= Input.GetAxis("Mouse Y") * (this.BinocularCamera.fieldOfView / 60f);
				this.RotationY += Input.GetAxis("Mouse X") * (this.BinocularCamera.fieldOfView / 60f);
			}
			else
			{
				this.RotationX -= Input.GetAxis("Mouse Y") * (this.BinocularCamera.fieldOfView / 60f);
				this.RotationY += Input.GetAxis("Mouse X") * (this.BinocularCamera.fieldOfView / 60f);
			}
			this.BinocularCamera.transform.eulerAngles = new Vector3(this.RotationX, this.RotationY + 90f, 0f);
			if (this.RotationX > 45f)
			{
				this.RotationX = 45f;
			}
			if (this.RotationX < -45f)
			{
				this.RotationX = -45f;
			}
			if (this.RotationY > 90f)
			{
				this.RotationY = 90f;
			}
			if (this.RotationY < -90f)
			{
				this.RotationY = -90f;
			}
			this.Zoom -= Input.GetAxis("Mouse ScrollWheel") * 10f;
			this.Zoom -= Input.GetAxis("Vertical") * 0.1f;
			if (this.Zoom > 60f)
			{
				this.Zoom = 60f;
			}
			else if (this.Zoom < 1f)
			{
				this.Zoom = 1f;
			}
			this.BinocularCamera.fieldOfView = Mathf.Lerp(this.BinocularCamera.fieldOfView, this.Zoom, Time.deltaTime * 10f);
			this.StreetManager.CurrentlyActiveJukebox.volume = this.BinocularCamera.fieldOfView / 60f * 0.5f;
			if (Input.GetButtonUp("B"))
			{
				this.BinocularCamera.gameObject.SetActive(false);
				this.BinocularRenderer.enabled = true;
				this.BinocularOverlay.SetActive(false);
				this.RotationX = 0f;
				this.RotationY = 0f;
				this.Zoom = 60f;
				this.StreetManager.CurrentlyActiveJukebox.volume = 0.5f;
				this.PromptBar.ClearButtons();
				this.PromptBar.Show = false;
				this.Yandere.CanMove = true;
			}
		}
	}

	private void UpdateShopInterface()
	{
		this.Yandere.MainCamera.GetComponent<RPG_Camera>().enabled = false;
		this.StreetShopInterface.StoreNameLabel.text = this.StoreName;
		this.StreetShopInterface.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2", NumberFormatInfo.InvariantInfo);
		this.StreetShopInterface.Shopkeeper.mainTexture = this.ShopkeeperPortraits[1];
		this.StreetShopInterface.SpeechBubbleLabel.text = this.ShopkeeperSpeeches[1];
		this.StreetShopInterface.ShopkeeperPortraits = this.ShopkeeperPortraits;
		this.StreetShopInterface.ShopkeeperSpeeches = this.ShopkeeperSpeeches;
		this.StreetShopInterface.ShopkeeperPosition = this.ShopkeeperPosition;
		this.StreetShopInterface.AdultProducts = this.AdultProducts;
		this.StreetShopInterface.SpeechPhase = 0;
		this.StreetShopInterface.Costs = this.Costs;
		this.StreetShopInterface.Limit = this.Limit;
		this.StreetShopInterface.Selected = 1;
		this.StreetShopInterface.Timer = 0f;
		this.StreetShopInterface.UpdateHighlight();
		for (int i = 1; i < 11; i++)
		{
			this.StreetShopInterface.ProductsLabel[i].text = this.Products[i];
			this.StreetShopInterface.PricesLabel[i].text = "$" + this.Costs[i];
			if (this.StreetShopInterface.PricesLabel[i].text == "$0")
			{
				this.StreetShopInterface.PricesLabel[i].text = "";
			}
			if (this.StoreType == ShopType.Salon)
			{
				this.StreetShopInterface.PricesLabel[i].text = "Free";
			}
		}
		this.StreetShopInterface.UpdateIcons();
	}
}
