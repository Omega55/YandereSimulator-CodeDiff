using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DDRMinigame : MonoBehaviour
{
	[Header("General")]
	[SerializeField]
	private DDRManager manager;

	[SerializeField]
	private InputManagerScript inputManager;

	[Header("Level select")]
	[SerializeField]
	private GameObject levelIconPrefab;

	[SerializeField]
	private RectTransform levelSelectParent;

	[SerializeField]
	private Text levelNameLabel;

	private DDRLevel[] levels;

	[Header("Gameplay")]
	[SerializeField]
	private Text comboText;

	[SerializeField]
	private Text longestComboText;

	[SerializeField]
	private Text rankText;

	[SerializeField]
	private Text scoreText;

	[SerializeField]
	private Image healthImage;

	[SerializeField]
	private GameObject arrowPrefab;

	[SerializeField]
	private GameObject ratingTextPrefab;

	[SerializeField]
	private RectTransform gameplayUiParent;

	[SerializeField]
	private RectTransform[] uiTracks;

	[SerializeField]
	private Vector2 offset;

	[SerializeField]
	private float speed;

	[Header("Colors")]
	[SerializeField]
	private Color perfectColor;

	[SerializeField]
	private Color greatColor;

	[SerializeField]
	private Color goodColor;

	[SerializeField]
	private Color okColor;

	[SerializeField]
	private Color earlyColor;

	private float levelSelectScroll;

	private int selectedLevel;

	private Dictionary<RectTransform, DDRLevel> levelSelectCache;

	private Dictionary<float, RectTransform>[] trackCache;

	public void LoadLevel(DDRLevel level)
	{
		this.gameplayUiParent.anchoredPosition = Vector2.zero;
		this.gameplayUiParent.rotation = Quaternion.identity;
		this.trackCache = new Dictionary<float, RectTransform>[4];
		for (int i = 0; i < this.trackCache.Length; i++)
		{
			this.trackCache[i] = new Dictionary<float, RectTransform>();
			foreach (float key in level.Tracks[i].Nodes)
			{
				RectTransform component = UnityEngine.Object.Instantiate<GameObject>(this.arrowPrefab, this.uiTracks[i]).GetComponent<RectTransform>();
				switch (i)
				{
				case 0:
					component.rotation = Quaternion.Euler(0f, 0f, 90f);
					break;
				case 1:
					component.rotation = Quaternion.Euler(0f, 0f, 180f);
					break;
				case 2:
					component.rotation = Quaternion.Euler(0f, 0f, 0f);
					break;
				case 3:
					component.rotation = Quaternion.Euler(0f, 0f, -90f);
					break;
				}
				this.trackCache[i].Add(key, component);
			}
		}
	}

	public void LoadLevelSelect(DDRLevel[] levels)
	{
		this.levelSelectCache = new Dictionary<RectTransform, DDRLevel>();
		this.levels = levels;
		for (int i = 0; i < levels.Length; i++)
		{
			RectTransform component = UnityEngine.Object.Instantiate<GameObject>(this.levelIconPrefab, this.levelSelectParent).GetComponent<RectTransform>();
			component.GetComponent<Image>().sprite = levels[i].LevelIcon;
			this.levelSelectCache.Add(component, levels[i]);
		}
		this.positionLevels(true);
	}

	public void UnloadLevelSelect()
	{
		foreach (KeyValuePair<RectTransform, DDRLevel> keyValuePair in this.levelSelectCache)
		{
			UnityEngine.Object.Destroy(keyValuePair.Key.gameObject);
		}
		this.levelSelectCache = new Dictionary<RectTransform, DDRLevel>();
	}

	public void UpdateLevelSelect()
	{
		if (this.inputManager.TappedLeft)
		{
			this.levelSelectScroll -= 1f;
		}
		else if (this.inputManager.TappedRight)
		{
			this.levelSelectScroll += 1f;
		}
		this.levelSelectScroll = Mathf.Clamp(this.levelSelectScroll, 0f, (float)(this.levels.Length - 1));
		this.selectedLevel = (int)Mathf.Round(this.levelSelectScroll);
		this.positionLevels(false);
		if (Input.GetButtonDown("A"))
		{
			this.manager.LoadedLevel = this.levels[this.selectedLevel];
		}
		if (Input.GetButtonDown("B"))
		{
			this.manager.BootOut();
		}
	}

	private void positionLevels(bool instant = false)
	{
		for (int i = 0; i < this.levelSelectCache.Keys.Count; i++)
		{
			RectTransform key = this.levelSelectCache.ElementAt(i).Key;
			Vector2 vector = new Vector2((float)(-(float)this.selectedLevel * 400 + i * 400), 0f);
			key.anchoredPosition = (instant ? vector : Vector2.Lerp(key.anchoredPosition, vector, 10f * Time.deltaTime));
			this.levelNameLabel.text = this.levels[this.selectedLevel].LevelName;
		}
	}

	public void UpdateGame(float time)
	{
		if (this.trackCache == null)
		{
			return;
		}
		bool flag = this.manager.GameState.FinishStatus == DDRFinishStatus.Failed;
		if (!flag)
		{
			this.pollInput(time);
			this.gameplayUiParent.anchoredPosition = Vector2.Lerp(this.gameplayUiParent.anchoredPosition, Vector2.zero, 10f * Time.deltaTime);
			this.gameplayUiParent.rotation = Quaternion.identity;
		}
		else
		{
			this.gameplayUiParent.anchoredPosition += Vector2.down * 50f * Time.deltaTime;
			this.gameplayUiParent.Rotate(Vector3.forward * -2f * Time.deltaTime);
			this.shakeUi(0.5f);
		}
		this.healthImage.fillAmount = Mathf.Lerp(this.healthImage.fillAmount, this.manager.GameState.Health / 100f, 10f * Time.deltaTime);
		for (int i = 0; i < this.trackCache.Length; i++)
		{
			Dictionary<float, RectTransform> dictionary = this.trackCache[i];
			foreach (float num in dictionary.Keys)
			{
				float num2 = num - time;
				if (num2 < -0.05f)
				{
					if (!flag)
					{
						this.displayHitRating(i, DDRRating.Miss);
					}
					this.assignPoints(DDRRating.Miss);
					this.updateCombo(DDRRating.Miss);
					this.removeNodeAt(this.trackCache.ToList<Dictionary<float, RectTransform>>().IndexOf(dictionary), 0f);
					return;
				}
				dictionary[num].anchoredPosition = new Vector2(0f, -num2 * this.speed) + this.offset;
			}
		}
	}

	public void UpdateEndcard(GameState state)
	{
		this.scoreText.text = string.Format("Score: {0}", state.Score);
		Color color;
		this.rankText.text = this.getRank(state, out color);
		this.rankText.color = color;
		this.longestComboText.text = string.Format("Biggest combo: {0}", state.LongestCombo.ToString());
	}

	private DDRRating getRating(int track, float time)
	{
		float num;
		RectTransform rectTransform;
		this.getFirstNodeOn(track, out num, out rectTransform);
		DDRRating result = DDRRating.Miss;
		float num2 = this.offset.y - rectTransform.localPosition.y;
		if (num2 < 130f)
		{
			result = DDRRating.Early;
			if (num2 < 75f)
			{
				result = DDRRating.Ok;
			}
			if (num2 < 65f)
			{
				result = DDRRating.Good;
			}
			if (num2 < 50f)
			{
				result = DDRRating.Great;
			}
			if (num2 < 30f)
			{
				result = DDRRating.Perfect;
			}
			if (num2 < -30f)
			{
				result = DDRRating.Ok;
			}
			if (num2 < -130f)
			{
				result = DDRRating.Miss;
			}
		}
		return result;
	}

	private string getRank(GameState state, out Color resultColor)
	{
		string result = "F";
		int num = 0;
		int perfectScorePoints = this.manager.LoadedLevel.PerfectScorePoints;
		foreach (DDRTrack ddrtrack in this.manager.LoadedLevel.Tracks)
		{
			num += ddrtrack.Nodes.Count * perfectScorePoints;
		}
		float num2 = (float)state.Score / (float)num * 100f;
		if (num2 >= 30f)
		{
			result = "D";
		}
		if (num2 >= 50f)
		{
			result = "C";
		}
		if (num2 >= 75f)
		{
			result = "B";
		}
		if (num2 >= 80f)
		{
			result = "A";
		}
		if (num2 >= 95f)
		{
			result = "S";
		}
		if (num2 >= 100f)
		{
			result = "S+";
		}
		resultColor = Color.Lerp(Color.red, Color.green, num2 / 100f);
		return result;
	}

	private void pollInput(float time)
	{
		if (this.inputManager.TappedLeft)
		{
			this.registerKeypress(0, time);
		}
		if (this.inputManager.TappedDown)
		{
			this.registerKeypress(1, time);
		}
		if (this.inputManager.TappedUp)
		{
			this.registerKeypress(2, time);
		}
		if (this.inputManager.TappedRight)
		{
			this.registerKeypress(3, time);
		}
	}

	private void registerKeypress(int track, float time)
	{
		DDRRating rating = this.getRating(track, time);
		this.displayHitRating(track, rating);
		this.assignPoints(rating);
		this.registerRating(rating);
		this.updateCombo(rating);
		if (rating != DDRRating.Miss)
		{
			this.removeNodeAt(track, 0f);
		}
	}

	private void registerRating(DDRRating rating)
	{
		Dictionary<DDRRating, int> ratings = this.manager.GameState.Ratings;
		ratings[rating]++;
		from x in this.manager.GameState.Ratings
		orderby x.Value
		select x;
	}

	private void updateCombo(DDRRating rating)
	{
		this.comboText.text = "";
		this.comboText.color = Color.white;
		this.comboText.GetComponent<Animation>().Play();
		if (rating != DDRRating.Miss && rating != DDRRating.Early)
		{
			this.manager.GameState.Combo++;
			if (this.manager.GameState.Combo > this.manager.GameState.LongestCombo)
			{
				this.manager.GameState.LongestCombo = this.manager.GameState.Combo;
				this.comboText.color = Color.yellow;
			}
			if (this.manager.GameState.Combo >= 2)
			{
				this.comboText.text = string.Format("x{0} combo", this.manager.GameState.Combo);
				this.comboText.color = Color.white;
				return;
			}
		}
		else
		{
			this.manager.GameState.Combo = 0;
		}
	}

	private void removeNodeAt(int trackId, float delay = 0f)
	{
		Dictionary<float, RectTransform> dictionary = this.trackCache[trackId];
		float[] array = dictionary.Keys.ToArray<float>();
		Array.Sort<float>(array, (float a, float b) => a.CompareTo(b));
		UnityEngine.Object.Destroy(dictionary[array[0]].gameObject, delay);
		dictionary.Remove(array[0]);
	}

	private void getFirstNodeOn(int track, out float time, out RectTransform rect)
	{
		Dictionary<float, RectTransform> dictionary = this.trackCache[track];
		float[] array = dictionary.Keys.ToArray<float>();
		Array.Sort<float>(array, (float a, float b) => a.CompareTo(b));
		time = array[0];
		rect = dictionary[time];
	}

	private void displayHitRating(int track, DDRRating rating)
	{
		Text component = UnityEngine.Object.Instantiate<GameObject>(this.ratingTextPrefab, this.uiTracks[track]).GetComponent<Text>();
		component.rectTransform.anchoredPosition = new Vector2(0f, 280f);
		switch (rating)
		{
		case DDRRating.Perfect:
			component.text = "Perfect";
			component.color = this.perfectColor;
			break;
		case DDRRating.Great:
			component.text = "Great";
			component.color = this.greatColor;
			break;
		case DDRRating.Good:
			component.text = "Good";
			component.color = this.goodColor;
			break;
		case DDRRating.Ok:
			component.text = "Ok";
			component.color = this.okColor;
			break;
		case DDRRating.Miss:
			component.text = "Miss";
			component.color = Color.red;
			this.shakeUi(5f);
			break;
		case DDRRating.Early:
			component.text = "Early";
			component.color = this.earlyColor;
			break;
		}
		UnityEngine.Object.Destroy(component, 1f);
	}

	private void assignPoints(DDRRating rating)
	{
		int num = 0;
		switch (rating)
		{
		case DDRRating.Perfect:
			num = this.manager.LoadedLevel.PerfectScorePoints;
			break;
		case DDRRating.Great:
			num = this.manager.LoadedLevel.GreatScorePoints;
			break;
		case DDRRating.Good:
			num = this.manager.LoadedLevel.GoodScorePoints;
			break;
		case DDRRating.Ok:
			num = this.manager.LoadedLevel.OkScorePoints;
			break;
		case DDRRating.Miss:
			num = this.manager.LoadedLevel.MissScorePoints;
			break;
		case DDRRating.Early:
			num = this.manager.LoadedLevel.EarlyScorePoints;
			break;
		}
		if (rating != DDRRating.Miss)
		{
			this.manager.GameState.Score += num;
		}
		this.manager.GameState.Health += (float)num;
	}

	private void shakeUi(float factor)
	{
		Vector2 b = new Vector2(UnityEngine.Random.Range(-factor, factor), UnityEngine.Random.Range(-factor, factor));
		this.gameplayUiParent.anchoredPosition += b;
	}

	public void Unload()
	{
		this.UnloadLevelSelect();
	}
}
