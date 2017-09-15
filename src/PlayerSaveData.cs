using System;

[Serializable]
public class PlayerSaveData
{
	public int alerts;

	public int enlightenment;

	public int enlightenmentBonus;

	public bool headset;

	public int kills;

	public int numbness;

	public int numbnessBonus;

	public int pantiesEquipped;

	public int pantyShots;

	public IntHashSet photo;

	public float reputation;

	public int seduction;

	public int seductionBonus;

	public IntHashSet senpaiPhoto;

	public int senpaiShots;

	public int socialBonus;

	public int speedBonus;

	public int stealthBonus;

	public IntHashSet studentFriend;

	public StringHashSet studentPantyShot;

	public PlayerSaveData()
	{
		this.alerts = 0;
		this.enlightenment = 0;
		this.enlightenmentBonus = 0;
		this.headset = false;
		this.kills = 0;
		this.numbness = 0;
		this.numbnessBonus = 0;
		this.pantiesEquipped = 0;
		this.pantyShots = 0;
		this.photo = new IntHashSet();
		this.reputation = 0f;
		this.seduction = 0;
		this.seductionBonus = 0;
		this.senpaiPhoto = new IntHashSet();
		this.senpaiShots = 0;
		this.socialBonus = 0;
		this.speedBonus = 0;
		this.stealthBonus = 0;
		this.studentFriend = new IntHashSet();
		this.studentPantyShot = new StringHashSet();
	}

	public static PlayerSaveData ReadFromGlobals()
	{
		PlayerSaveData playerSaveData = new PlayerSaveData();
		playerSaveData.alerts = PlayerGlobals.Alerts;
		playerSaveData.enlightenment = PlayerGlobals.Enlightenment;
		playerSaveData.enlightenmentBonus = PlayerGlobals.EnlightenmentBonus;
		playerSaveData.headset = PlayerGlobals.Headset;
		playerSaveData.kills = PlayerGlobals.Kills;
		playerSaveData.numbness = PlayerGlobals.Numbness;
		playerSaveData.numbnessBonus = PlayerGlobals.NumbnessBonus;
		playerSaveData.pantiesEquipped = PlayerGlobals.PantiesEquipped;
		playerSaveData.pantyShots = PlayerGlobals.PantyShots;
		foreach (int num in PlayerGlobals.KeysOfPhoto())
		{
			if (PlayerGlobals.GetPhoto(num))
			{
				playerSaveData.photo.Add(num);
			}
		}
		playerSaveData.reputation = PlayerGlobals.Reputation;
		playerSaveData.seduction = PlayerGlobals.Seduction;
		playerSaveData.seductionBonus = PlayerGlobals.SeductionBonus;
		foreach (int num2 in PlayerGlobals.KeysOfSenpaiPhoto())
		{
			if (PlayerGlobals.GetSenpaiPhoto(num2))
			{
				playerSaveData.senpaiPhoto.Add(num2);
			}
		}
		playerSaveData.senpaiShots = PlayerGlobals.SenpaiShots;
		playerSaveData.socialBonus = PlayerGlobals.SocialBonus;
		playerSaveData.speedBonus = PlayerGlobals.SpeedBonus;
		playerSaveData.stealthBonus = PlayerGlobals.StealthBonus;
		foreach (int num3 in PlayerGlobals.KeysOfStudentFriend())
		{
			if (PlayerGlobals.GetStudentFriend(num3))
			{
				playerSaveData.studentFriend.Add(num3);
			}
		}
		foreach (string text in PlayerGlobals.KeysOfStudentPantyShot())
		{
			if (PlayerGlobals.GetStudentPantyShot(text))
			{
				playerSaveData.studentPantyShot.Add(text);
			}
		}
		return playerSaveData;
	}

	public static void WriteToGlobals(PlayerSaveData data)
	{
		PlayerGlobals.Alerts = data.alerts;
		PlayerGlobals.Enlightenment = data.enlightenment;
		PlayerGlobals.EnlightenmentBonus = data.enlightenmentBonus;
		PlayerGlobals.Headset = data.headset;
		PlayerGlobals.Kills = data.kills;
		PlayerGlobals.Numbness = data.numbness;
		PlayerGlobals.NumbnessBonus = data.numbnessBonus;
		PlayerGlobals.PantiesEquipped = data.pantiesEquipped;
		PlayerGlobals.PantyShots = data.pantyShots;
		foreach (int photoID in data.photo)
		{
			PlayerGlobals.SetPhoto(photoID, true);
		}
		PlayerGlobals.Reputation = data.reputation;
		PlayerGlobals.Seduction = data.seduction;
		PlayerGlobals.SeductionBonus = data.seductionBonus;
		foreach (int photoID2 in data.senpaiPhoto)
		{
			PlayerGlobals.SetSenpaiPhoto(photoID2, true);
		}
		PlayerGlobals.SenpaiShots = data.senpaiShots;
		PlayerGlobals.SocialBonus = data.socialBonus;
		PlayerGlobals.SpeedBonus = data.speedBonus;
		PlayerGlobals.StealthBonus = data.stealthBonus;
		foreach (int studentID in data.studentFriend)
		{
			PlayerGlobals.SetStudentFriend(studentID, true);
		}
		foreach (string studentName in data.studentPantyShot)
		{
			PlayerGlobals.SetStudentPantyShot(studentName, true);
		}
	}
}
