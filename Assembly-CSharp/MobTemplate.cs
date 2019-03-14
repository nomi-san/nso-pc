public class MobTemplate
{
	public sbyte rangeMove;

	public sbyte speed;

	public sbyte type;

	public sbyte typeFly;

	public short mobTemplateId;

	public int hp;

	public string name;

	public Image[] imgs;

	public ImageInfo[] imginfo;

	public Frame[] frameBoss;

	public sbyte[] frameBossMove;

	public sbyte[][] frameBossAttack;

	public ImageInfo getImgInfo(sbyte frame)
	{
		return imginfo[frame];
	}
}
