using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class DDRManager : MonoBehaviour
{
	public GameState GameState;

	public YandereScript Yandere;

	public Transform FinishLocation;

	public Renderer OriginalRenderer;

	public GameObject OverlayCanvas;

	public GameObject GameUI;

	[Header("General")]
	public DDRLevel LoadedLevel;

	[SerializeField]
	private DDRLevel[] levels;

	[SerializeField]
	private InputManagerScript inputManager;

	[SerializeField]
	private DDRMinigame ddrMinigame;

	[SerializeField]
	private AudioSource audioSource;

	[SerializeField]
	private Transform standPoint;

	[SerializeField]
	private float transitionSpeed = 2f;

	[Header("Camera")]
	[SerializeField]
	private Transform minigameCamera;

	[SerializeField]
	private Transform startPoint;

	[SerializeField]
	private Transform screenPoint;

	[SerializeField]
	private Transform watchPoint;

	[Header("Animation")]
	[SerializeField]
	private Animation machineScreenAnimation;

	[SerializeField]
	private Animation yandereAnim;

	[Header("UI")]
	[SerializeField]
	private Image fadeImage;

	[SerializeField]
	private RawImage[] overlayImages;

	[SerializeField]
	private VideoPlayer backgroundVideo;

	[SerializeField]
	private Transform levelSelect;

	[SerializeField]
	private GameObject endScreen;

	[SerializeField]
	private GameObject defeatScreen;

	[SerializeField]
	private Text continueText;

	[SerializeField]
	private ColorCorrectionCurves gameplayColorCorrection;

	private Transform target;

	private bool booted;

	public bool DebugMode;

	public bool CheckingForEnd;

	private void Start()
	{
		if (this.DebugMode)
		{
			this.BeginMinigame();
		}
	}

	public void Update()
	{
		this.minigameCamera.position = Vector3.Slerp(this.minigameCamera.position, this.target.position, this.transitionSpeed * Time.deltaTime);
		this.minigameCamera.rotation = Quaternion.Slerp(this.minigameCamera.rotation, this.target.rotation, this.transitionSpeed * Time.deltaTime);
		if (this.target == null)
		{
			return;
		}
		Vector3 position = this.standPoint.position;
		if (this.LoadedLevel != null)
		{
			this.ddrMinigame.UpdateGame(this.audioSource.time);
			this.GameState.Health -= Time.deltaTime;
			this.GameState.Health = Mathf.Clamp(this.GameState.Health, 0f, 100f);
			if (this.inputManager.TappedLeft)
			{
				this.yandereAnim["f02_danceLeft_00"].time = 0f;
				this.yandereAnim.Play("f02_danceLeft_00");
			}
			else if (this.inputManager.TappedDown)
			{
				this.yandereAnim["f02_danceDown_00"].time = 0f;
				this.yandereAnim.Play("f02_danceDown_00");
			}
			if (this.inputManager.TappedRight)
			{
				this.yandereAnim["f02_danceRight_00"].time = 0f;
				this.yandereAnim.Play("f02_danceRight_00");
			}
			else if (this.inputManager.TappedUp)
			{
				this.yandereAnim["f02_danceUp_00"].time = 0f;
				this.yandereAnim.Play("f02_danceUp_00");
			}
		}
		this.yandereAnim.transform.position = Vector3.Lerp(this.yandereAnim.transform.position, position, 10f * Time.deltaTime);
		if (this.CheckingForEnd && !this.audioSource.isPlaying)
		{
			this.ddrMinigame.LevelIconsSpawned = false;
			this.OverlayCanvas.SetActive(false);
			this.GameUI.SetActive(false);
			this.CheckingForEnd = false;
			Debug.Log("End() was called because song ended.");
			base.StartCoroutine(this.End());
		}
		if (this.GameState.Health <= 0f && this.audioSource.pitch < 0.01f)
		{
			this.ddrMinigame.LevelIconsSpawned = false;
			this.OverlayCanvas.SetActive(false);
			this.GameUI.SetActive(false);
			if (this.audioSource.isPlaying)
			{
				Debug.Log("End() was called because we ranout of health.");
				base.StartCoroutine(this.End());
			}
		}
	}

	public void BeginMinigame()
	{
		Debug.Log("BeginMinigame() was called.");
		this.yandereAnim["f02_danceMachineIdle_00"].layer = 0;
		this.yandereAnim["f02_danceRight_00"].layer = 1;
		this.yandereAnim["f02_danceLeft_00"].layer = 2;
		this.yandereAnim["f02_danceUp_00"].layer = 1;
		this.yandereAnim["f02_danceDown_00"].layer = 2;
		this.yandereAnim["f02_danceMachineIdle_00"].weight = 1f;
		this.yandereAnim["f02_danceRight_00"].weight = 1f;
		this.yandereAnim["f02_danceLeft_00"].weight = 1f;
		this.yandereAnim["f02_danceUp_00"].weight = 1f;
		this.yandereAnim["f02_danceDown_00"].weight = 1f;
		this.OverlayCanvas.SetActive(true);
		this.GameUI.SetActive(true);
		this.ddrMinigame.LoadLevelSelect(this.levels);
		base.StartCoroutine(this.minigameFlow());
	}

	public void BootOut()
	{
		Debug.Log("BootOut() was called.");
		base.StartCoroutine(this.fade(true, this.fadeImage, 5f));
		this.target = this.startPoint;
		this.ddrMinigame.LevelIconsSpawned = false;
		this.ReturnToNormalGameplay();
	}

	private IEnumerator minigameFlow()
	{
		this.levelSelect.gameObject.SetActive(true);
		this.defeatScreen.gameObject.SetActive(false);
		this.endScreen.gameObject.SetActive(false);
		this.audioSource.pitch = 1f;
		this.target = this.screenPoint;
		if (!this.booted)
		{
			yield return new WaitForSecondsRealtime(0.2f);
			base.StartCoroutine(this.fade(false, this.fadeImage, 1f));
			while (this.fadeImage.color.a > 0.4f)
			{
				yield return null;
			}
			this.machineScreenAnimation.Play();
			this.booted = true;
		}
		yield return new WaitForEndOfFrame();
		while (Input.GetAxis("A") != 0f)
		{
			yield return null;
		}
		while (this.LoadedLevel == null)
		{
			this.ddrMinigame.UpdateLevelSelect();
			yield return null;
		}
		this.ddrMinigame.LoadLevel(this.LoadedLevel);
		this.GameState = new GameState();
		yield return new WaitForSecondsRealtime(0.2f);
		this.transitionSpeed *= 2f;
		this.target = this.watchPoint;
		this.backgroundVideo.Play();
		this.backgroundVideo.playbackSpeed = 0f;
		base.StartCoroutine(this.fadeGameUI(true));
		this.backgroundVideo.playbackSpeed = 1f;
		this.audioSource.clip = this.LoadedLevel.Song;
		this.audioSource.Play();
		this.CheckingForEnd = true;
		while (this.audioSource.time < this.audioSource.clip.length)
		{
			if (this.GameState.Health <= 0f)
			{
				this.GameState.FinishStatus = DDRFinishStatus.Failed;
				while (this.audioSource.pitch > 0f)
				{
					this.audioSource.pitch = Mathf.MoveTowards(this.audioSource.pitch, 0f, 0.2f * Time.deltaTime);
					if (this.audioSource.pitch == 0f)
					{
						Debug.Log("Pitch reached zero.");
						this.audioSource.time = this.audioSource.clip.length;
						this.ddrMinigame.LevelIconsSpawned = false;
						this.OverlayCanvas.SetActive(false);
						this.GameUI.SetActive(false);
					}
					yield return null;
				}
				break;
			}
			yield return null;
		}
		yield break;
	}

	private IEnumerator End()
	{
		this.audioSource.Stop();
		this.levelSelect.gameObject.SetActive(false);
		base.StopCoroutine(this.fadeGameUI(true));
		base.StartCoroutine(this.fadeGameUI(false));
		if (this.GameState.FinishStatus == DDRFinishStatus.Complete)
		{
			this.endScreen.gameObject.SetActive(true);
			this.ddrMinigame.UpdateEndcard(this.GameState);
		}
		else
		{
			this.defeatScreen.SetActive(true);
		}
		this.target = this.screenPoint;
		this.LoadedLevel = null;
		this.ddrMinigame.UnloadLevelSelect();
		yield return new WaitForSecondsRealtime(2f);
		base.StartCoroutine(this.fade(true, this.continueText, 1f));
		while (!Input.anyKeyDown || Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2))
		{
			yield return null;
		}
		this.ddrMinigame.Unload();
		this.onLevelFinish(this.GameState.FinishStatus);
		yield break;
	}

	private IEnumerator fadeGameUI(bool fadein)
	{
		float destination = (float)((!fadein) ? 0 : 1);
		float amount = (float)((!fadein) ? 1 : 0);
		while (amount != destination)
		{
			amount = Mathf.Lerp(amount, destination, 10f * Time.deltaTime);
			foreach (RawImage rawImage in this.overlayImages)
			{
				Color color = rawImage.color;
				color.a = amount;
				rawImage.color = color;
			}
			yield return null;
		}
		yield break;
	}

	private IEnumerator fade(bool fadein, MaskableGraphic graphic, float speed = 1f)
	{
		float destination = (float)((!fadein) ? 0 : 1);
		float amount = (float)((!fadein) ? 1 : 0);
		while (amount != destination)
		{
			amount = Mathf.Lerp(amount, destination, speed * Time.deltaTime);
			Color color = graphic.color;
			color.a = amount;
			graphic.color = color;
			yield return null;
		}
		yield break;
	}

	private void onLevelFinish(DDRFinishStatus status)
	{
		this.BootOut();
	}

	public void ReturnToNormalGameplay()
	{
		Debug.Log("ReturnToNormalGameplay() was called.");
		this.yandereAnim["f02_danceMachineIdle_00"].weight = 0f;
		this.yandereAnim["f02_danceRight_00"].weight = 0f;
		this.yandereAnim["f02_danceLeft_00"].weight = 0f;
		this.yandereAnim["f02_danceUp_00"].weight = 0f;
		this.yandereAnim["f02_danceDown_00"].weight = 0f;
		this.Yandere.transform.position = this.FinishLocation.position;
		this.Yandere.transform.rotation = this.FinishLocation.rotation;
		this.Yandere.StudentManager.Clock.StopTime = false;
		this.Yandere.MyController.enabled = true;
		this.Yandere.StudentManager.ComeBack();
		this.Yandere.CanMove = true;
		this.Yandere.enabled = true;
		this.Yandere.HeartCamera.enabled = true;
		this.Yandere.HUD.enabled = true;
		this.Yandere.HUD.transform.parent.gameObject.SetActive(true);
		this.Yandere.MainCamera.gameObject.SetActive(true);
		this.Yandere.Jukebox.Volume = this.Yandere.Jukebox.LastVolume;
		this.OriginalRenderer.enabled = true;
		Physics.SyncTransforms();
		base.transform.parent.gameObject.SetActive(false);
	}
}
