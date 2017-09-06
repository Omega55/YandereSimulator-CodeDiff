using System;

[Serializable]
public class ClubSaveData
{
	public ClubType club;

	public ClubTypeHashSet clubClosed;

	public ClubTypeHashSet clubKicked;

	public ClubTypeHashSet quitClub;

	public ClubSaveData()
	{
		this.club = ClubType.None;
		this.clubClosed = new ClubTypeHashSet();
		this.clubKicked = new ClubTypeHashSet();
		this.quitClub = new ClubTypeHashSet();
	}

	public static ClubSaveData ReadFromGlobals()
	{
		ClubSaveData clubSaveData = new ClubSaveData();
		clubSaveData.club = ClubGlobals.Club;
		foreach (ClubType item in ClubGlobals.KeysOfClubClosed())
		{
			clubSaveData.clubClosed.Add(item);
		}
		foreach (ClubType item2 in ClubGlobals.KeysOfClubKicked())
		{
			clubSaveData.clubKicked.Add(item2);
		}
		foreach (ClubType item3 in ClubGlobals.KeysOfQuitClub())
		{
			clubSaveData.quitClub.Add(item3);
		}
		return clubSaveData;
	}

	public static void WriteToGlobals(ClubSaveData data)
	{
		ClubGlobals.Club = data.club;
		foreach (ClubType clubID in data.clubClosed)
		{
			ClubGlobals.SetClubClosed(clubID, true);
		}
		foreach (ClubType clubID2 in data.clubKicked)
		{
			ClubGlobals.SetClubKicked(clubID2, true);
		}
		foreach (ClubType clubID3 in data.quitClub)
		{
			ClubGlobals.SetQuitClub(clubID3, true);
		}
	}
}
