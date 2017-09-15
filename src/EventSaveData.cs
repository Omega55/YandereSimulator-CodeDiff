using System;

[Serializable]
public class EventSaveData
{
	public bool befriendConversation;

	public bool event1;

	public bool event2;

	public bool kidnapConversation;

	public bool livingRoom;

	public EventSaveData()
	{
		this.befriendConversation = false;
		this.event1 = false;
		this.event2 = false;
		this.kidnapConversation = false;
		this.livingRoom = false;
	}

	public static EventSaveData ReadFromGlobals()
	{
		return new EventSaveData
		{
			befriendConversation = EventGlobals.BefriendConversation,
			event1 = EventGlobals.Event1,
			event2 = EventGlobals.Event2,
			kidnapConversation = EventGlobals.KidnapConversation,
			livingRoom = EventGlobals.LivingRoom
		};
	}

	public static void WriteToGlobals(EventSaveData data)
	{
		EventGlobals.BefriendConversation = data.befriendConversation;
		EventGlobals.Event1 = data.event1;
		EventGlobals.Event2 = data.event2;
		EventGlobals.KidnapConversation = data.kidnapConversation;
		EventGlobals.LivingRoom = data.livingRoom;
	}
}
