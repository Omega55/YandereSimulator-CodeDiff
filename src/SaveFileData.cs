using System;
using System.Xml.Serialization;

[XmlRoot]
[Serializable]
public class SaveFileData
{
	public ApplicationSaveData applicationData;

	public ClassSaveData classData;

	public ClubSaveData clubData;

	public CollectibleSaveData collectibleData;

	public ConversationSaveData conversationData;

	public DateSaveData dateData;

	public DatingSaveData datingData;

	public EventSaveData eventData;

	public GameSaveData gameData;

	public HomeSaveData homeData;

	public MissionModeSaveData missionModeData;

	public OptionSaveData optionData;

	public PlayerSaveData playerData;

	public PoseModeSaveData poseModeData;

	public SaveFileSaveData saveFileData;

	public SchemeSaveData schemeData;

	public SchoolSaveData schoolData;

	public SenpaiSaveData senpaiData;

	public StudentSaveData studentData;

	public TaskSaveData taskData;

	public YanvaniaSaveData yanvaniaData;

	public SaveFileData()
	{
		this.applicationData = new ApplicationSaveData();
		this.classData = new ClassSaveData();
		this.clubData = new ClubSaveData();
		this.collectibleData = new CollectibleSaveData();
		this.conversationData = new ConversationSaveData();
		this.dateData = new DateSaveData();
		this.datingData = new DatingSaveData();
		this.eventData = new EventSaveData();
		this.gameData = new GameSaveData();
		this.homeData = new HomeSaveData();
		this.missionModeData = new MissionModeSaveData();
		this.optionData = new OptionSaveData();
		this.playerData = new PlayerSaveData();
		this.poseModeData = new PoseModeSaveData();
		this.saveFileData = new SaveFileSaveData();
		this.schemeData = new SchemeSaveData();
		this.schoolData = new SchoolSaveData();
		this.senpaiData = new SenpaiSaveData();
		this.studentData = new StudentSaveData();
		this.taskData = new TaskSaveData();
		this.yanvaniaData = new YanvaniaSaveData();
	}
}
