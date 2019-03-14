public class EffectData
{
	public sbyte[] data;

	public long timeremove;

	public MyVector listFrame = new MyVector();

	public MyVector listAnima = new MyVector();

	public SmallImage[] smallImage;

	public sbyte[][] frameChar = new sbyte[4][];

	public sbyte[] sequence;

	public int fw;

	public int fh;

	public sbyte[] indexStartSkill;

	public bool isLoad;

	public void setdata(sbyte[] data)
	{
		if (!isLoad)
		{
			DataSkillEff dataSkillEff = new DataSkillEff();
			dataSkillEff.loadData(data);
			listFrame = dataSkillEff.listFrame;
			smallImage = dataSkillEff.smallImage;
			fw = dataSkillEff.fw;
			fh = dataSkillEff.fh;
			sequence = dataSkillEff.sequence;
			indexStartSkill = dataSkillEff.indexSplash;
			frameChar = dataSkillEff.frameChar;
			isLoad = true;
		}
	}
}
