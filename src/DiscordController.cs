using System;
using UnityEngine;
using UnityEngine.Events;

public class DiscordController : MonoBehaviour
{
	public DiscordRpc.RichPresence presence;

	public string applicationId;

	public string optionalSteamId;

	public int callbackCalls;

	public int clickCounter;

	public DiscordRpc.JoinRequest joinRequest;

	public UnityEvent onConnect;

	public UnityEvent onDisconnect;

	public UnityEvent hasResponded;

	public DiscordJoinEvent onJoin;

	public DiscordJoinEvent onSpectate;

	public DiscordJoinRequestEvent onJoinRequest;

	private DiscordRpc.EventHandlers handlers;

	public void OnClick(bool disconnect)
	{
		if (disconnect)
		{
			Debug.Log("Discord: on click - shutdown");
			DiscordRpc.Shutdown();
		}
		else
		{
			Debug.Log("Discord: on click!");
			this.clickCounter++;
			this.presence.details = string.Format("Button clicked {0} times", this.clickCounter);
			DiscordRpc.UpdatePresence(ref this.presence);
		}
	}

	public void RequestRespondYes()
	{
		Debug.Log("Discord: responding yes to Ask to Join request");
		DiscordRpc.Respond(this.joinRequest.userId, DiscordRpc.Reply.Yes);
		this.hasResponded.Invoke();
	}

	public void RequestRespondNo()
	{
		Debug.Log("Discord: responding no to Ask to Join request");
		DiscordRpc.Respond(this.joinRequest.userId, DiscordRpc.Reply.No);
		this.hasResponded.Invoke();
	}

	public void ReadyCallback()
	{
		this.callbackCalls++;
		Debug.Log("Discord: ready");
		this.onConnect.Invoke();
	}

	public void ForceDisconnect()
	{
		this.DisconnectedCallback(0, "Forcing disconnection by user");
	}

	public void DisconnectedCallback(int errorCode, string message)
	{
		this.callbackCalls++;
		Debug.Log(string.Format("Discord: disconnect {0}: {1}", errorCode, message));
		this.onDisconnect.Invoke();
	}

	public void ErrorCallback(int errorCode, string message)
	{
		this.callbackCalls++;
		Debug.Log(string.Format("Discord: error {0}: {1}", errorCode, message));
	}

	public void JoinCallback(string secret)
	{
		this.callbackCalls++;
		Debug.Log(string.Format("Discord: join ({0})", secret));
		this.onJoin.Invoke(secret);
	}

	public void SpectateCallback(string secret)
	{
		this.callbackCalls++;
		Debug.Log(string.Format("Discord: spectate ({0})", secret));
		this.onSpectate.Invoke(secret);
	}

	public void RequestCallback(ref DiscordRpc.JoinRequest request)
	{
		this.callbackCalls++;
		Debug.Log(string.Format("Discord: join request {0}#{1}: {2}", request.username, request.discriminator, request.userId));
		this.joinRequest = request;
		this.onJoinRequest.Invoke(request);
	}

	private void Start()
	{
	}

	private void Update()
	{
		DiscordRpc.RunCallbacks();
	}

	private void OnEnable()
	{
		Debug.Log("Discord: init");
		this.callbackCalls = 0;
		this.handlers = default(DiscordRpc.EventHandlers);
		this.handlers.readyCallback = new DiscordRpc.ReadyCallback(this.ReadyCallback);
		this.handlers.disconnectedCallback = (DiscordRpc.DisconnectedCallback)Delegate.Combine(this.handlers.disconnectedCallback, new DiscordRpc.DisconnectedCallback(this.DisconnectedCallback));
		this.handlers.errorCallback = (DiscordRpc.ErrorCallback)Delegate.Combine(this.handlers.errorCallback, new DiscordRpc.ErrorCallback(this.ErrorCallback));
		this.handlers.joinCallback = (DiscordRpc.JoinCallback)Delegate.Combine(this.handlers.joinCallback, new DiscordRpc.JoinCallback(this.JoinCallback));
		this.handlers.spectateCallback = (DiscordRpc.SpectateCallback)Delegate.Combine(this.handlers.spectateCallback, new DiscordRpc.SpectateCallback(this.SpectateCallback));
		this.handlers.requestCallback = (DiscordRpc.RequestCallback)Delegate.Combine(this.handlers.requestCallback, new DiscordRpc.RequestCallback(this.RequestCallback));
		DiscordRpc.Initialize(this.applicationId, ref this.handlers, true, this.optionalSteamId);
	}

	private void OnDisable()
	{
		Debug.Log("Discord: shutdown");
		DiscordRpc.Shutdown();
	}

	private void OnDestroy()
	{
	}
}
