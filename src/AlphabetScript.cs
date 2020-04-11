using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlphabetScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

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

	public UILabel ChallengeFailed;

	public UILabel TargetLabel;

	public UILabel BombLabel;

	public Transform LocalArrow;

	public Transform Yandere;

	public int RemainingBombs;

	public int CurrentTarget;

	public float Timer;

	public int[] IDs;

	private void Start()
	{
		if (GameGlobals.AlphabetMode)
		{
			this.TargetLabel.text = string.Concat(new object[]
			{
				"(",
				this.CurrentTarget,
				"/77) Current Target: ",
				this.StudentManager.JSON.Students[this.IDs[this.CurrentTarget]].Name
			});
			this.TargetLabel.transform.parent.gameObject.SetActive(true);
			this.StudentManager.Yandere.NoDebug = true;
			this.BodyHidingLockers.SetActive(true);
			this.AmnesiaBombBox.SetActive(true);
			this.SmokeBombBox.SetActive(true);
			this.StinkBombBox.SetActive(true);
			this.SuperRobot.SetActive(true);
			this.PuzzleCube.SetActive(true);
			this.WeaponBag.SetActive(true);
			ClassGlobals.PhysicalGrade = 5;
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
					Object.Instantiate<GameObject>(this.SmokeBomb, this.Yandere.position, Quaternion.identity);
					this.RemainingBombs--;
					this.BombLabel.text = string.Concat(this.RemainingBombs);
					if (this.RemainingBombs == 0)
					{
						this.StudentManager.Yandere.Inventory.SmokeBomb = false;
					}
				}
				else if (this.StudentManager.Yandere.Inventory.StinkBomb)
				{
					Object.Instantiate<GameObject>(this.StinkBomb, this.Yandere.position, Quaternion.identity);
					this.RemainingBombs--;
					this.BombLabel.text = string.Concat(this.RemainingBombs);
					if (this.RemainingBombs == 0)
					{
						this.StudentManager.Yandere.Inventory.StinkBomb = false;
					}
				}
				else if (this.StudentManager.Yandere.Inventory.AmnesiaBomb)
				{
					Object.Instantiate<GameObject>(this.AmnesiaBomb, this.Yandere.position, Quaternion.identity);
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
			if ((this.StudentManager.Yandere.Attacking && this.StudentManager.Yandere.TargetStudent.StudentID != this.IDs[this.CurrentTarget]) || this.StudentManager.Police.Show)
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
					this.TargetLabel.text = string.Concat(new object[]
					{
						"(",
						this.CurrentTarget,
						"/77) Current Target: ",
						this.StudentManager.Students[this.IDs[this.CurrentTarget]].Name
					});
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
}
