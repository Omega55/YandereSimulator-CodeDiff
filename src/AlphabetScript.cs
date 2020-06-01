using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlphabetScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public InventoryScript Inventory;

	public GameObject BodyHidingLockers;

	public GameObject AmnesiaBombBox;

	public GameObject SmokeBombBox;

	public GameObject StinkBombBox;

	public GameObject AmnesiaBomb;

	public GameObject PuzzleCube;

	public GameObject SuperRobot;

	public GameObject SmokeBomb;

	public GameObject StinkBomb;

	public GameObject WeaponBag;

	public GameObject Jukebox;

	public UILabel ChallengeFailed;

	public UILabel TargetLabel;

	public UILabel BombLabel;

	public UITexture BombTexture;

	public Transform LocalArrow;

	public Transform Yandere;

	public int RemainingBombs;

	public int CurrentTarget;

	public float Timer;

	public int[] IDs;

	public AudioSource Music;

	private void Start()
	{
		if (GameGlobals.AlphabetMode)
		{
			this.TargetLabel.transform.parent.gameObject.SetActive(true);
			this.StudentManager.Yandere.NoDebug = true;
			this.BodyHidingLockers.SetActive(true);
			this.AmnesiaBombBox.SetActive(true);
			this.SmokeBombBox.SetActive(true);
			this.StinkBombBox.SetActive(true);
			this.SuperRobot.SetActive(true);
			this.PuzzleCube.SetActive(true);
			this.WeaponBag.SetActive(true);
			this.Jukebox.SetActive(false);
			ClassGlobals.PhysicalGrade = 5;
			this.Music.Play();
			this.UpdateText();
			return;
		}
		this.TargetLabel.transform.parent.gameObject.SetActive(false);
		this.BombLabel.transform.parent.gameObject.SetActive(false);
		base.gameObject.SetActive(false);
		base.enabled = false;
	}

	private void Update()
	{
		if (this.CurrentTarget < this.IDs.Length)
		{
			if (this.StudentManager.Yandere.CanMove && (Input.GetButtonDown("LS") || Input.GetKeyDown(KeyCode.T)))
			{
				if (this.StudentManager.Yandere.Inventory.SmokeBomb)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.SmokeBomb, this.Yandere.position, Quaternion.identity);
					this.RemainingBombs--;
					this.BombLabel.text = string.Concat(this.RemainingBombs);
					if (this.RemainingBombs == 0)
					{
						this.StudentManager.Yandere.Inventory.SmokeBomb = false;
					}
				}
				else if (this.StudentManager.Yandere.Inventory.StinkBomb)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.StinkBomb, this.Yandere.position, Quaternion.identity);
					this.RemainingBombs--;
					this.BombLabel.text = string.Concat(this.RemainingBombs);
					if (this.RemainingBombs == 0)
					{
						this.StudentManager.Yandere.Inventory.StinkBomb = false;
					}
				}
				else if (this.StudentManager.Yandere.Inventory.AmnesiaBomb)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.AmnesiaBomb, this.Yandere.position, Quaternion.identity);
					this.RemainingBombs--;
					this.BombLabel.text = string.Concat(this.RemainingBombs);
					if (this.RemainingBombs == 0)
					{
						this.StudentManager.Yandere.Inventory.AmnesiaBomb = false;
					}
				}
			}
			this.LocalArrow.LookAt(this.StudentManager.Students[this.IDs[this.CurrentTarget]].transform.position);
			base.transform.eulerAngles = this.LocalArrow.eulerAngles - new Vector3(0f, this.StudentManager.MainCamera.transform.eulerAngles.y, 0f);
			if ((this.StudentManager.Yandere.Attacking && this.StudentManager.Yandere.TargetStudent.StudentID != this.IDs[this.CurrentTarget]) || (this.StudentManager.Yandere.Struggling && this.StudentManager.Yandere.TargetStudent.StudentID != this.IDs[this.CurrentTarget]) || this.StudentManager.Police.Show)
			{
				this.ChallengeFailed.enabled = true;
			}
			if (!this.StudentManager.Students[this.IDs[this.CurrentTarget]].Alive)
			{
				this.CurrentTarget++;
				if (this.CurrentTarget > 77)
				{
					this.TargetLabel.text = "Challenge Complete!";
					SceneManager.LoadScene("OsanaJokeScene");
				}
				else
				{
					this.UpdateText();
				}
			}
			if (this.ChallengeFailed.enabled)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 3f)
				{
					SceneManager.LoadScene("LoadingScene");
				}
			}
		}
	}

	public void UpdateText()
	{
		this.TargetLabel.text = string.Concat(new object[]
		{
			"(",
			this.CurrentTarget,
			"/77) Current Target: ",
			this.StudentManager.JSON.Students[this.IDs[this.CurrentTarget]].Name
		});
		if (this.RemainingBombs > 0)
		{
			this.BombLabel.transform.parent.gameObject.SetActive(true);
			if (this.BombTexture.color.a < 1f)
			{
				if (this.Inventory.StinkBomb)
				{
					this.BombTexture.color = new Color(0f, 0.5f, 0f, 1f);
					return;
				}
				if (this.Inventory.AmnesiaBomb)
				{
					this.BombTexture.color = new Color(1f, 0.5f, 1f, 1f);
					return;
				}
				this.BombTexture.color = new Color(0.5f, 0.5f, 0.5f, 1f);
			}
		}
	}
}
