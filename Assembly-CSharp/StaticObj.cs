public class StaticObj
{
	public const string SAVE_SKILL = "skill";

	public const string SAVE_VERSIONUPDATE = "versionUpdate";

	public const string SAVE_KEYKILL = "keyskill";

	public const string SAVE_ITEM = "item";

	public const int NORMAL = 0;

	public const int UP_FALL = 1;

	public const int UP_RUN = 2;

	public const int FALL_RIGHT = 3;

	public const int FALL_LEFT = 4;

	public const int MOD_ATTACK_ME = 100;

	public const int TYPE_PLAYER = 3;

	public const int TYPE_NON = 0;

	public const int TYPE_VUKHI = 1;

	public const int TYPE_AO = 2;

	public const int TYPE_LIEN = 3;

	public const int TYPE_TAY = 4;

	public const int TYPE_NHAN = 5;

	public const int TYPE_QUAN = 6;

	public const int TYPE_BOI = 7;

	public const int TYPE_GIAY = 8;

	public const int TYPE_PHU = 9;

	public const int TYPE_OTHER = 11;

	public const int TYPE_CRYSTAL = 15;

	public const int FOCUS_MOD = 1;

	public const int FOCUS_ITEM = 2;

	public const int FOCUS_PLAYER = 3;

	public const int FOCUS_ZONE = 4;

	public const int FOCUS_NPC = 5;

	public static int TOP_CENTER = mGraphics.TOP | mGraphics.HCENTER;

	public static int TOP_LEFT = mGraphics.TOP | mGraphics.LEFT;

	public static int TOP_RIGHT = mGraphics.TOP | mGraphics.RIGHT;

	public static int BOTTOM_HCENTER = mGraphics.BOTTOM | mGraphics.HCENTER;

	public static int BOTTOM_LEFT = mGraphics.BOTTOM | mGraphics.LEFT;

	public static int BOTTOM_RIGHT = mGraphics.BOTTOM | mGraphics.RIGHT;

	public static int VCENTER_HCENTER = mGraphics.VCENTER | mGraphics.HCENTER;

	public static int VCENTER_LEFT = mGraphics.VCENTER | mGraphics.LEFT;

	public static int[][] TYPEBG = new int[17][]
	{
		new int[4],
		new int[4]
		{
			1,
			1,
			1,
			1
		},
		new int[4],
		new int[4]
		{
			2,
			2,
			2,
			2
		},
		new int[4]
		{
			3,
			3,
			3,
			3
		},
		new int[4]
		{
			4,
			-1,
			-1,
			4
		},
		new int[4]
		{
			5,
			5,
			5,
			-1
		},
		new int[4]
		{
			6,
			6,
			6,
			5
		},
		new int[4]
		{
			7,
			7,
			-1,
			-1
		},
		new int[4]
		{
			8,
			8,
			8,
			7
		},
		new int[4]
		{
			9,
			-1,
			-1,
			8
		},
		new int[4]
		{
			10,
			-1,
			-1,
			9
		},
		new int[4]
		{
			11,
			-1,
			-1,
			-1
		},
		new int[4]
		{
			13,
			13,
			-1,
			-1
		},
		new int[4]
		{
			14,
			14,
			14,
			-1
		},
		new int[4]
		{
			15,
			15,
			-1,
			-1
		},
		new int[4]
		{
			16,
			16,
			16,
			-1
		}
	};

	public static int[] SKYCOLOR = new int[17]
	{
		5944047,
		4751608,
		1052688,
		2672631,
		3262455,
		0,
		12451839,
		3248838,
		1513480,
		16760764,
		0,
		1285290,
		1285290,
		0,
		4882101,
		3018762,
		4352644
	};
}
