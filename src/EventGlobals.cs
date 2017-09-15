using System;

public static class EventGlobals
{
	private const string Str_BefriendConversation = "BefriendConversation";

	private const string Str_Event1 = "Event1";

	private const string Str_Event2 = "Event2";

	private const string Str_KidnapConversation = "KidnapConversation";

	private const string Str_LivingRoom = "LivingRoom";

	public static bool BefriendConversation
	{
		get
		{
			return GlobalsHelper.GetBool("BefriendConversation");
		}
		set
		{
			GlobalsHelper.SetBool("BefriendConversation", value);
		}
	}

	public static bool Event1
	{
		get
		{
			return GlobalsHelper.GetBool("Event1");
		}
		set
		{
			GlobalsHelper.SetBool("Event1", value);
		}
	}

	public static bool Event2
	{
		get
		{
			return GlobalsHelper.GetBool("Event2");
		}
		set
		{
			GlobalsHelper.SetBool("Event2", value);
		}
	}

	public static bool KidnapConversation
	{
		get
		{
			return GlobalsHelper.GetBool("KidnapConversation");
		}
		set
		{
			GlobalsHelper.SetBool("KidnapConversation", value);
		}
	}

	public static bool LivingRoom
	{
		get
		{
			return GlobalsHelper.GetBool("LivingRoom");
		}
		set
		{
			GlobalsHelper.SetBool("LivingRoom", value);
		}
	}

	public static void DeleteAll()
	{
		Globals.Delete("BefriendConversation");
		Globals.Delete("Event1");
		Globals.Delete("Event2");
		Globals.Delete("KidnapConversation");
		Globals.Delete("LivingRoom");
	}
}
