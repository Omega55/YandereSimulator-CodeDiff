using System;
using System.Xml.Serialization;

[XmlRoot]
[Serializable]
public class SaveFileData
{
	public int Kills;

	public float Atmosphere;

	public int Alerts;

	public int Week;

	public string Day;

	public string Rival;

	public float Reputation;

	public string Club;

	public int Friends;
}
