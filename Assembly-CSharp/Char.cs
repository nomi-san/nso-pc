using System;

public class Char : MainObject
{
	public const sbyte A_STAND = 1;

	public const sbyte A_RUN = 2;

	public const sbyte A_JUMP = 3;

	public const sbyte A_FALL = 4;

	public const sbyte A_DEADFLY = 5;

	public const sbyte A_NOTHING = 6;

	public const sbyte A_ATTK = 7;

	public const sbyte A_INJURE = 8;

	public const sbyte A_AUTOJUMP = 9;

	public const sbyte A_WATERRUN = 10;

	public const sbyte A_WATERDOWN = 11;

	public const sbyte SKILL_STAND = 12;

	public const sbyte SKILL_FALL = 13;

	public const sbyte A_DEAD = 14;

	public const sbyte A_HIDE = 15;

	public const sbyte PK_NORMAL = 0;

	public const sbyte PK_PHE = 1;

	public const sbyte PK_BANG = 2;

	public const sbyte PK_DOSAT = 3;

	public bool isHuman;

	public bool isNhanban;

	public bool isCaptcha;

	private int tickEffWolf;

	private int timeBocdau;

	public long lastUpdateTime;

	public ChatPopup chatPopup;

	public long cEXP;

	public long cExpDown;

	public long cExpR;

	public int lcx;

	public int lcy;

	public int cx = 24;

	public int cy = 24;

	public int cvx;

	public int cvy;

	public int cp1;

	public int cp2;

	public int cp3;

	public int statusMe = 5;

	public int cdir = 1;

	public int charID;

	public int cgender;

	public int ctaskId;

	public int cBonusSpeed;

	public int cspeed;

	public int ccurrentAttack;

	public int cdame;

	public int cdameDown;

	public int clevel;

	public int cMP;

	public int cMaxMP;

	public int cHP;

	public int cHpNew;

	public int cMaxHP;

	public int cMaxEXP;

	public int HPShow;

	public int xReload;

	public int yReload;

	public int cyStartFall;

	public int saveStatus;

	public int eff5BuffHp;

	public int eff5BuffMp;

	public int autoUpHp;

	public int pPoint;

	public int sPoint;

	public int pointUydanh;

	public int pointNon;

	public int pointVukhi;

	public int pointAo;

	public int pointLien;

	public int pointGangtay;

	public int pointNhan;

	public int pointQuan;

	public int pointNgocboi;

	public int pointGiay;

	public int pointPhu;

	public int pointTinhTu;

	public int countFinishDay;

	public int countLoopBoos;

	public int limitTiemnangso;

	public int limitKynangso;

	public int limitPhongLoi;

	public int limitBangHoa;

	public int countPB;

	public int[] potential = new int[4];

	public string cName;

	public int cw = 22;

	public int ch = 32;

	public int chw = 11;

	public int chh = 16;

	public bool canJumpHigh = true;

	public bool cmtoChar;

	public bool me;

	public bool cchistlast;

	public bool isAttack;

	public bool isAttFly;

	public int cf;

	public int tick;

	public static bool fallAttack;

	public bool isJump;

	public bool autoFall;

	public bool isMoto;

	public bool isWolf;

	public bool isMotoBehind;

	public bool isBocdau;

	public int xu;

	public int xuInBox;

	public int yen;

	public int gold_lock;

	public int luong;

	public NClass nClass;

	public MyVector vSkill = new MyVector();

	public MyVector vSkillFight = new MyVector();

	public MyVector vEff = new MyVector();

	public MyVector vDomsang = new MyVector();

	public Skill myskill;

	public Task taskMaint;

	public bool paintName = true;

	public Item[] arrItemBag;

	public Item[] arrItemBox;

	public Item[] arrItemBody;

	public Item[] arrItemMounts = new Item[5];

	public sbyte[] mountsPoint = new sbyte[10];

	public short cResFire;

	public short cResIce;

	public short cResWind;

	public short cMiss;

	public short cExactly;

	public short cFatal;

	public sbyte cPk;

	public sbyte cTypePk;

	public short cReactDame;

	public short sysUp;

	public short sysDown;

	public int skillTemplateId;

	public Mob mobFocus;

	public Mob mobMe;

	public Npc npcFocus;

	public Char charFocus;

	public ItemMap itemFocus;

	public MyVector focus = new MyVector();

	public Mob[] attMobs;

	public Char[] attChars;

	public short[] moveFast;

	public int testCharId = -9999;

	public int killCharId = -9999;

	public sbyte resultTest;

	public int countKill;

	public int countKillMax;

	public int tickCoat;

	public int tickEffmoto;

	public int tickEffFireW;

	public bool isInvisible;

	public long timeStartBlink;

	public static bool isAHP;

	public static bool isAMP;

	public static bool isAFood;

	public static bool isABuff;

	public static bool isAResuscitate;

	public static bool isAPickYen;

	public static bool isAPickYHM;

	public static bool isAPickYHMS;

	public static bool isANoPick;

	public static bool isAFocusDie;

	public static int aHpValue = 20;

	public static int aMpValue = 20;

	public static int aFoodValue = 70;

	public static int aCID;

	public long lastTimeUseSkill;

	public static sbyte PK_NHOM = 1;

	public static sbyte PK_PHE1 = 4;

	public static sbyte PK_PHE2 = 5;

	public MyVector taskOrders = new MyVector();

	public string cClanName = string.Empty;

	public sbyte ctypeClan;

	public static Clan clan;

	public static int pointPB;

	public static int pointChienTruong;

	public long timeSummon;

	public static readonly int[][][] CharInfo = new int[30][][]
	{
		new int[4][]
		{
			new int[3]
			{
				0,
				-10,
				32
			},
			new int[3]
			{
				1,
				-7,
				7
			},
			new int[3]
			{
				1,
				-11,
				15
			},
			new int[3]
			{
				1,
				-9,
				45
			}
		},
		new int[4][]
		{
			new int[3]
			{
				0,
				-10,
				33
			},
			new int[3]
			{
				1,
				-7,
				7
			},
			new int[3]
			{
				1,
				-11,
				16
			},
			new int[3]
			{
				1,
				-9,
				46
			}
		},
		new int[4][]
		{
			new int[3]
			{
				1,
				-10,
				33
			},
			new int[3]
			{
				2,
				-10,
				11
			},
			new int[3]
			{
				2,
				-9,
				16
			},
			new int[3]
			{
				1,
				-12,
				49
			}
		},
		new int[4][]
		{
			new int[3]
			{
				1,
				-10,
				32
			},
			new int[3]
			{
				3,
				-11,
				9
			},
			new int[3]
			{
				3,
				-11,
				16
			},
			new int[3]
			{
				1,
				-13,
				47
			}
		},
		new int[4][]
		{
			new int[3]
			{
				1,
				-10,
				34
			},
			new int[3]
			{
				4,
				-9,
				9
			},
			new int[3]
			{
				4,
				-8,
				16
			},
			new int[3]
			{
				1,
				-12,
				47
			}
		},
		new int[4][]
		{
			new int[3]
			{
				1,
				-10,
				34
			},
			new int[3]
			{
				5,
				-11,
				11
			},
			new int[3]
			{
				5,
				-10,
				17
			},
			new int[3]
			{
				1,
				-13,
				49
			}
		},
		new int[4][]
		{
			new int[3]
			{
				1,
				-10,
				33
			},
			new int[3]
			{
				6,
				-9,
				9
			},
			new int[3]
			{
				6,
				-8,
				16
			},
			new int[3]
			{
				1,
				-12,
				47
			}
		},
		new int[4][]
		{
			new int[3]
			{
				0,
				-9,
				36
			},
			new int[3]
			{
				7,
				-5,
				15
			},
			new int[3]
			{
				7,
				-10,
				21
			},
			new int[3]
			{
				1,
				-8,
				49
			}
		},
		new int[4][]
		{
			new int[3]
			{
				4,
				-13,
				26
			},
			new int[3],
			new int[3],
			new int[3]
		},
		new int[4][]
		{
			new int[3]
			{
				5,
				-13,
				25
			},
			new int[3],
			new int[3],
			new int[3]
		},
		new int[4][]
		{
			new int[3]
			{
				6,
				-12,
				26
			},
			new int[3],
			new int[3],
			new int[3]
		},
		new int[4][]
		{
			new int[3]
			{
				7,
				-13,
				25
			},
			new int[3],
			new int[3],
			new int[3]
		},
		new int[4][]
		{
			new int[3]
			{
				0,
				-9,
				35
			},
			new int[3]
			{
				8,
				-4,
				13
			},
			new int[3]
			{
				8,
				-14,
				27
			},
			new int[3]
			{
				1,
				-9,
				49
			}
		},
		new int[4][]
		{
			new int[3]
			{
				0,
				-9,
				31
			},
			new int[3]
			{
				9,
				-11,
				8
			},
			new int[3]
			{
				10,
				-10,
				17
			},
			new int[3]
		},
		new int[4][]
		{
			new int[3]
			{
				2,
				-7,
				33
			},
			new int[3]
			{
				9,
				-11,
				8
			},
			new int[3]
			{
				11,
				-8,
				15
			},
			new int[3]
		},
		new int[4][]
		{
			new int[3]
			{
				2,
				-8,
				32
			},
			new int[3]
			{
				9,
				-11,
				8
			},
			new int[3]
			{
				12,
				-8,
				14
			},
			new int[3]
		},
		new int[4][]
		{
			new int[3]
			{
				2,
				-7,
				32
			},
			new int[3]
			{
				9,
				-11,
				8
			},
			new int[3]
			{
				13,
				-12,
				15
			},
			new int[3]
		},
		new int[4][]
		{
			new int[3]
			{
				0,
				-11,
				31
			},
			new int[3]
			{
				9,
				-11,
				8
			},
			new int[3]
			{
				14,
				-15,
				18
			},
			new int[3]
		},
		new int[4][]
		{
			new int[3]
			{
				2,
				-9,
				32
			},
			new int[3]
			{
				9,
				-11,
				8
			},
			new int[3]
			{
				15,
				-13,
				19
			},
			new int[3]
		},
		new int[4][]
		{
			new int[3]
			{
				2,
				-9,
				31
			},
			new int[3]
			{
				9,
				-11,
				8
			},
			new int[3]
			{
				16,
				-7,
				22
			},
			new int[3]
		},
		new int[4][]
		{
			new int[3]
			{
				2,
				-9,
				32
			},
			new int[3]
			{
				9,
				-11,
				8
			},
			new int[3]
			{
				17,
				-11,
				18
			},
			new int[3]
		},
		new int[4][]
		{
			new int[3]
			{
				3,
				-12,
				34
			},
			new int[3]
			{
				8,
				-4,
				13
			},
			new int[3]
			{
				8,
				-15,
				25
			},
			new int[3]
			{
				1,
				-10,
				46
			}
		},
		new int[4][]
		{
			new int[3]
			{
				0,
				-9,
				32
			},
			new int[3]
			{
				8,
				-4,
				9
			},
			new int[3]
			{
				10,
				-10,
				18
			},
			new int[3]
		},
		new int[4][]
		{
			new int[3]
			{
				2,
				-7,
				34
			},
			new int[3]
			{
				8,
				-4,
				9
			},
			new int[3]
			{
				11,
				-8,
				16
			},
			new int[3]
		},
		new int[4][]
		{
			new int[3]
			{
				2,
				-8,
				33
			},
			new int[3]
			{
				8,
				-4,
				9
			},
			new int[3]
			{
				12,
				-8,
				15
			},
			new int[3]
		},
		new int[4][]
		{
			new int[3]
			{
				2,
				-7,
				33
			},
			new int[3]
			{
				8,
				-4,
				9
			},
			new int[3]
			{
				13,
				-12,
				16
			},
			new int[3]
		},
		new int[4][]
		{
			new int[3]
			{
				0,
				-11,
				32
			},
			new int[3]
			{
				7,
				-5,
				9
			},
			new int[3]
			{
				14,
				-15,
				19
			},
			new int[3]
		},
		new int[4][]
		{
			new int[3]
			{
				2,
				-9,
				33
			},
			new int[3]
			{
				7,
				-5,
				9
			},
			new int[3]
			{
				15,
				-13,
				20
			},
			new int[3]
		},
		new int[4][]
		{
			new int[3]
			{
				2,
				-9,
				32
			},
			new int[3]
			{
				7,
				-5,
				9
			},
			new int[3]
			{
				16,
				-7,
				23
			},
			new int[3]
		},
		new int[4][]
		{
			new int[3]
			{
				2,
				-9,
				33
			},
			new int[3]
			{
				7,
				-5,
				9
			},
			new int[3]
			{
				17,
				-11,
				19
			},
			new int[3]
		}
	};

	public int[] CHAR_WEAPONX = new int[11]
	{
		-2,
		-6,
		22,
		21,
		19,
		22,
		10,
		-2,
		-2,
		5,
		19
	};

	public int[] CHAR_WEAPONY = new int[11]
	{
		9,
		22,
		25,
		17,
		26,
		37,
		36,
		49,
		50,
		52,
		36
	};

	private static Char myChar;

	public static int[] listAttack;

	public static int[][] listIonC;

	public int cvyJump;

	private int indexUseSkill = -1;

	public int cxSend;

	public int cySend;

	public int cdirSend = 1;

	public int cxFocus;

	public int cyFocus;

	public int cxMoveLast;

	public int cyMoveLast;

	public int cactFirst = 5;

	public MyVector vMovePoints = new MyVector();

	public static bool flag;

	public static bool ischangingMap;

	public static bool isLockKey;

	public bool isLockMove;

	public bool isLockAttack;

	public bool isBlinking;

	public MovePoint currentMovePoint;

	public int bom;

	public int count;

	public bool isEffBatTu;

	public long lastUseHP = mSystem.currentTimeMillis();

	public bool beginSound;

	public long timeBeGinRun;

	public int vitaWolf;

	public long timeSendmove;

	public static bool isSendMove = true;

	public long time;

	private int cX0;

	private int cY0;

	private int inAir;

	private long currMove;

	public bool isLastMove;

	public static sbyte[] locate = new sbyte[12]
	{
		0,
		0,
		0,
		-1,
		-1,
		-1,
		-2,
		-2,
		-2,
		-1,
		-1,
		-1
	};

	private long timeLastCheck;

	public long timelastSendmove;

	public static short delaySendmove = 250;

	public short head;

	public short leg;

	public short body;

	public short wp;

	public short coat = -1;

	public short glove = -1;

	public int indexEff = -1;

	public int indexEffTask = -1;

	public EffectCharPaint eff;

	public EffectCharPaint effTask;

	public int indexSkill;

	public int i0;

	public int i1;

	public int i2;

	public int dx0;

	public int dx1;

	public int dx2;

	public int dy0;

	public int dy1;

	public int dy2;

	public EffectCharPaint eff0;

	public EffectCharPaint eff1;

	public EffectCharPaint eff2;

	public Arrow arr;

	public SkillPaint skillPaint;

	public EffectPaint[] effPaints;

	public int sType;

	public sbyte isInjure;

	private int dxHead;

	private int dyHead;

	private int dxBody;

	private int dyBody;

	private int tickWolf;

	private int dy;

	private int hdx;

	private int hdy;

	private int[] idWolfW = new int[4]
	{
		1715,
		1737,
		1714,
		1738
	};

	public static bool isManualFocus = false;

	private int nInjure;

	public short wdx;

	public short wdy;

	public bool isDirtyPostion;

	public Skill lastNormalSkill;

	public bool currentFireByShortcut;

	private int EffdefautX;

	private int EffdefautY;

	private int Effx;

	private int Effy;

	private int tickEffyesWolfmove;

	private int EffdefautX1;

	private int EffdefautY1;

	private bool isPaintNo = true;

	private FrameImage img;

	private static Image imgNo;

	private int f;

	private int countNo;

	private int dyNo;

	private int dxNo;

	public Char()
	{
		statusMe = 6;
	}

	public int getdxSkill()
	{
		if (myskill != null)
		{
			return myskill.dx;
		}
		return 0;
	}

	public int getdySkill()
	{
		if (myskill != null)
		{
			return myskill.dy;
		}
		return 0;
	}

	public int getSys()
	{
		if (nClass.classId == 1 || nClass.classId == 2)
		{
			return 1;
		}
		if (nClass.classId == 3 || nClass.classId == 4)
		{
			return 2;
		}
		if (nClass.classId == 5 || nClass.classId == 6)
		{
			return 3;
		}
		return 0;
	}

	public int getSpeed()
	{
		if (isWolf || isMoto)
		{
			return cspeed + 2;
		}
		return cspeed;
	}

	public bool isUseLongRangeWeapon()
	{
		return nClass.classId == 2 || nClass.classId == 4 || nClass.classId == 6;
	}

	public static Char getMyChar()
	{
		if (myChar == null)
		{
			myChar = new Char();
			myChar.me = true;
			myChar.cmtoChar = true;
			myChar.timelastSendmove = mSystem.currentTimeMillis();
		}
		return myChar;
	}

	public static void clearMyChar()
	{
		isABuff = (isAFocusDie = (isAFood = (isAHP = (isAMP = (isANoPick = (isAPickYen = (isAPickYHM = (isAPickYHMS = (isAResuscitate = false)))))))));
		myChar = null;
	}

	public void readParam(Message msg, string pos)
	{
		try
		{
			cspeed = msg.reader().readByte();
			cMaxHP = msg.reader().readInt();
			cMaxMP = msg.reader().readInt();
		}
		catch (Exception)
		{
		}
	}

	public void bagSort()
	{
		try
		{
			MyVector myVector = new MyVector();
			for (int i = 0; i < arrItemBag.Length; i++)
			{
				Item item = arrItemBag[i];
				if (item != null && item.template.isUpToUp && !item.isExpires)
				{
					myVector.addElement(item);
				}
			}
			for (int j = 0; j < myVector.size(); j++)
			{
				Item item2 = (Item)myVector.elementAt(j);
				if (item2 != null)
				{
					for (int k = j + 1; k < myVector.size(); k++)
					{
						Item item3 = (Item)myVector.elementAt(k);
						if (item3 != null && item2.template.Equals(item3.template) && item2.isLock == item3.isLock)
						{
							item2.quantity += item3.quantity;
							arrItemBag[item3.indexUI] = null;
							myVector.setElementAt(null, k);
						}
					}
				}
			}
			for (int l = 0; l < arrItemBag.Length; l++)
			{
				if (arrItemBag[l] != null)
				{
					for (int m = 0; m <= l; m++)
					{
						if (arrItemBag[m] == null)
						{
							arrItemBag[m] = arrItemBag[l];
							arrItemBag[m].indexUI = m;
							arrItemBag[l] = null;
							break;
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			Out.println(ex.Message + ex.StackTrace);
			Out.println("Char.bagSort()");
		}
	}

	public void boxSort()
	{
		try
		{
			MyVector myVector = new MyVector();
			for (int i = 0; i < arrItemBox.Length; i++)
			{
				Item item = arrItemBox[i];
				if (item != null && item.template.isUpToUp && !item.isExpires)
				{
					myVector.addElement(item);
				}
			}
			for (int j = 0; j < myVector.size(); j++)
			{
				Item item2 = (Item)myVector.elementAt(j);
				if (item2 != null)
				{
					for (int k = j + 1; k < myVector.size(); k++)
					{
						Item item3 = (Item)myVector.elementAt(k);
						if (item3 != null && item2.template.Equals(item3.template) && item2.isLock == item3.isLock)
						{
							item2.quantity += item3.quantity;
							arrItemBox[item3.indexUI] = null;
							myVector.setElementAt(null, k);
						}
					}
				}
			}
			for (int l = 0; l < arrItemBox.Length; l++)
			{
				if (arrItemBox[l] != null)
				{
					for (int m = 0; m <= l; m++)
					{
						if (arrItemBox[m] == null)
						{
							arrItemBox[m] = arrItemBox[l];
							arrItemBox[m].indexUI = m;
							arrItemBox[l] = null;
							break;
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			Out.println(ex.Message + ex.StackTrace);
			Out.println("Char.boxSort()");
		}
	}

	public void useItem(int indexUI)
	{
		Item item = arrItemBag[indexUI];
		if (item.isTypeBody())
		{
			item.isLock = true;
			item.typeUI = 5;
			Item item2 = arrItemBody[item.template.type];
			arrItemBag[indexUI] = null;
			if (item2 != null)
			{
				item2.typeUI = 3;
				arrItemBody[item.template.type] = null;
				item2.indexUI = indexUI;
				arrItemBag[indexUI] = item2;
			}
			item.indexUI = item.template.type;
			arrItemBody[item.indexUI] = item;
			for (int i = 0; i < arrItemBody.Length; i++)
			{
				Item item3 = arrItemBody[i];
				if (item3 != null)
				{
					if (item3.template.type == 1)
					{
						wp = item3.template.part;
					}
					else if (item3.template.type == 2)
					{
						body = item3.template.part;
					}
					else if (item3.template.type == 6)
					{
						leg = item3.template.part;
					}
				}
			}
		}
		else
		{
			if (!item.isTypeMounts())
			{
				return;
			}
			item.isLock = true;
			item.typeUI = 41;
			arrItemBag[indexUI] = null;
			int num = 0;
			int num2;
			while (true)
			{
				if (num < arrItemMounts.Length)
				{
					num2 = item.template.type - 29;
					if (num2 == num)
					{
						break;
					}
					num++;
					continue;
				}
				return;
			}
			Item item4 = arrItemMounts[num2];
			if (item4 != null)
			{
				item4.typeUI = 41;
				arrItemMounts[num2] = null;
				item4.indexUI = indexUI;
				arrItemBag[indexUI] = item4;
			}
			item.indexUI = item.template.type;
			arrItemMounts[num2] = item;
		}
	}

	public Skill getSkill(SkillTemplate skillTemplate)
	{
		for (int i = 0; i < vSkill.size(); i++)
		{
			Skill skill = (Skill)vSkill.elementAt(i);
			if (skill.template.Equals(skillTemplate))
			{
				return skill;
			}
		}
		return null;
	}

	public bool isInWaypoint()
	{
		int num = TileMap.vGo.size();
		for (sbyte b = 0; b < num; b = (sbyte)(b + 1))
		{
			Waypoint waypoint = (Waypoint)TileMap.vGo.elementAt(b);
			if (cx >= waypoint.minX && cx <= waypoint.maxX && cy >= waypoint.minY && cy <= waypoint.maxY)
			{
				return true;
			}
		}
		return false;
	}

	private void updateCharSound()
	{
		if (me && getMyChar().statusMe == 2 && !Sound.isPlayingSound())
		{
			Sound.playSoundRun(Sound.MBuocChan, 0.8f);
		}
	}

	public void sendMove()
	{
		if (me && cHP > 0)
		{
			int distance = getDistance(cxSend, cx);
			int distance2 = getDistance(cySend, cy);
			if ((distance > 0 || distance2 > 0) && mSystem.currentTimeMillis() - timeSendmove >= 250)
			{
				isSendMove = true;
			}
			if (isSendMove)
			{
				isSendMove = false;
				Service.gI().charMove("--1:", cx, cy);
				timeSendmove = mSystem.currentTimeMillis();
				cxSend = cx;
				cySend = cy;
				cdirSend = cdir;
				cactFirst = statusMe;
			}
		}
	}

	public static int getDistance(int x, int x2)
	{
		return Res.abs(x - x2);
	}

	public virtual void update()
	{
		cX0 = cx;
		cY0 = cy;
		update_No();
		sendMove();
		if (mobMe != null)
		{
			updateMobMe();
		}
		isEffBatTu = false;
		if (resultTest > 0 && GameCanvas.gameTick % 2 == 0)
		{
			resultTest--;
			if (resultTest == 30 || resultTest == 60)
			{
				resultTest = 0;
			}
		}
		updateSkillPaint();
		if (mobMe != null)
		{
			mobMe.update();
		}
		if (arr != null)
		{
			arr.update();
		}
		if (arrItemMounts[4] != null && arrItemMounts[4].options != null)
		{
			for (int i = 0; i < arrItemMounts[4].options.size(); i++)
			{
				ItemOption itemOption = (ItemOption)arrItemMounts[4].options.elementAt(i);
				if (itemOption.optionTemplate.id == 66)
				{
					vitaWolf = itemOption.param;
				}
			}
		}
		if (isWolf && vitaWolf < 500)
		{
			isWolf = false;
		}
		if (isWolf)
		{
			updateEffwolfMove();
			for (int j = 0; j < vDomsang.size(); j++)
			{
				Domsang domsang = (Domsang)vDomsang.elementAt(j);
				domsang.update();
				if (domsang.frame >= 6)
				{
					vDomsang.removeElementAt(j);
				}
			}
		}
		else if (isMoto)
		{
			updateEffmotoMove();
			for (int k = 0; k < vDomsang.size(); k++)
			{
				Domsang domsang2 = (Domsang)vDomsang.elementAt(k);
				domsang2.update();
				if (domsang2.frame >= 6)
				{
					vDomsang.removeElementAt(k);
				}
			}
		}
		if (me && isAHP && cHP < cMaxHP * aHpValue / 100 && mSystem.currentTimeMillis() - lastUseHP > 5000 && statusMe != 14 && statusMe != 5 && cHP > 0)
		{
			if (vEff.size() == 0)
			{
				for (int l = 0; l < arrItemBag.Length; l++)
				{
					Item item = arrItemBag[l];
					if (item != null && item.template.type == 16 && item.template.level == aHpValue)
					{
						GameScr.gI().doUseHP();
						lastUseHP = mSystem.currentTimeMillis();
						break;
					}
				}
			}
			else
			{
				for (int m = 0; m < vEff.size(); m++)
				{
					Effect effect = (Effect)getMyChar().vEff.elementAt(m);
					if (effect.template.type == 17)
					{
						break;
					}
					if (m == vEff.size() - 1)
					{
						GameScr.gI().doUseHP();
						lastUseHP = mSystem.currentTimeMillis();
					}
				}
			}
		}
		if (me && isAFood && GameCanvas.gameTick % 10 == 0 && !GameScr.isPaintAuto && statusMe != 14 && statusMe != 5 && cHP > 0)
		{
			if (vEff.size() == 0)
			{
				for (int n = 0; n < arrItemBag.Length; n++)
				{
					Item item2 = arrItemBag[n];
					if (item2 != null && item2.template.type == 18 && item2.template.level == aFoodValue)
					{
						Service.gI().useItem(n);
						break;
					}
				}
			}
			else
			{
				for (int num = 0; num < vEff.size(); num++)
				{
					Effect effect2 = (Effect)getMyChar().vEff.elementAt(num);
					if (effect2.template.type == 0)
					{
						break;
					}
					if (num != vEff.size() - 1)
					{
						continue;
					}
					for (int num2 = 0; num2 < arrItemBag.Length; num2++)
					{
						Item item3 = arrItemBag[num2];
						if (item3 != null && item3.template.type == 18 && item3.template.level == aFoodValue)
						{
							Service.gI().useItem(num2);
							break;
						}
					}
				}
			}
		}
		if (me && isABuff && getMyChar().statusMe != 14 && getMyChar().statusMe != 5 && cHP > 0 && mSystem.currentTimeMillis() - lastTimeUseSkill > 500)
		{
			for (int num3 = 0; num3 < vSkill.size(); num3++)
			{
				bool flag = false;
				Skill skill = (Skill)vSkill.elementAt(num3);
				if ((skill.template.id >= 67 && skill.template.id <= 72) || skill == null || skill.template.type != 2 || skill.isCooldown())
				{
					continue;
				}
				for (int num4 = 0; num4 < vEff.size(); num4++)
				{
					Effect effect3 = (Effect)vEff.elementAt(num4);
					if (effect3 != null && effect3.template.iconId == skill.template.iconId)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					GameScr.gI().doUseSkill(skill, isShortcut: true);
					Service.gI().sendUseSkillMyBuff();
					saveLoadPreviousSkill();
					lastTimeUseSkill = mSystem.currentTimeMillis();
					break;
				}
			}
		}
		if (me && isAMP && cMP < cMaxMP * aMpValue / 100 && GameCanvas.gameTick % 4 == 0 && statusMe != 14 && statusMe != 5 && cHP > 0)
		{
			GameScr.gI().doUseMP();
		}
		if (me && isAResuscitate && nClass.classId == 6 && aCID > 0 && getMyChar().statusMe != 14 && getMyChar().statusMe != 5)
		{
			Char @char = GameScr.findCharInMap(aCID);
			if (@char != null && (@char.cHP <= 0 || @char.statusMe == 14 || @char.statusMe == 5 || isAFocusDie))
			{
				for (int num5 = 0; num5 < vSkill.size(); num5++)
				{
					Skill skill2 = (Skill)getMyChar().vSkill.elementAt(num5);
					if (skill2 != null && skill2.template.type == 4)
					{
						if (Res.abs(cx - @char.cx) < skill2.dx && Res.abs(cy - @char.cy) < skill2.dy)
						{
							getMyChar().myskill = skill2;
							GameScr.gI().doRescuedOtherChar(aCID);
							isAFocusDie = false;
							saveLoadPreviousSkill();
						}
						else
						{
							InfoMe.addInfo(mResources.LIVE_TEXT, 20, mFont.tahoma_7_white);
						}
						break;
					}
				}
			}
		}
		if (cHP > 0)
		{
			for (int num6 = 0; num6 < vEff.size(); num6++)
			{
				Effect effect4 = (Effect)vEff.elementAt(num6);
				if (effect4.template.type == 0 || effect4.template.type == 12)
				{
					if (GameCanvas.isEff1)
					{
						cHP += effect4.param;
						cMP += effect4.param;
					}
				}
				else if (effect4.template.type == 4 || effect4.template.type == 17)
				{
					if (GameCanvas.isEff1)
					{
						cHP += effect4.param;
					}
				}
				else if (effect4.template.type == 13)
				{
					if (GameCanvas.isEff1)
					{
						cHP -= cMaxHP * 3 / 100;
						if (cHP < 1)
						{
							cHP = 1;
						}
					}
				}
				else if (effect4.template.type == 7)
				{
					isEffBatTu = true;
				}
				else if (effect4.template.type == 1)
				{
					cHP += autoUpHp;
				}
			}
			if (isEffBatTu)
			{
				count++;
			}
			else
			{
				count = 0;
			}
			if (eff5BuffHp > 0 && GameCanvas.isEff2)
			{
				cHP += eff5BuffHp;
			}
			if (eff5BuffMp > 0 && GameCanvas.isEff2)
			{
				cMP += eff5BuffMp;
			}
			if (cHP > cMaxHP)
			{
				cHP = cMaxHP;
			}
			if (cMP > cMaxMP)
			{
				cMP = cMaxMP;
			}
		}
		if (cmtoChar)
		{
			GameScr.cmtoX = cx - GameScr.gW2 + GameScr.gW6 * cdir;
			GameScr.cmtoY = cy - GameScr.gH23;
		}
		tick = (tick + 1) % 100;
		if (me)
		{
			if (charFocus != null && !GameScr.vCharInMap.contains(charFocus))
			{
				charFocus = null;
			}
			if (cx < 10)
			{
				cvx = 0;
				cx = 10;
			}
			else if (cx > TileMap.pxw - 10)
			{
				cx = TileMap.pxw - 10;
				cvx = 0;
			}
			if (!ischangingMap && isInWaypoint())
			{
				isSendMove = true;
				Service.gI().requestChangeMap();
				isLockKey = true;
				ischangingMap = true;
				GameCanvas.clearKeyHold();
				GameCanvas.clearKeyPressed();
				return;
			}
			if (isBlinking)
			{
				isBlinking = (mSystem.currentTimeMillis() - timeStartBlink < 2000);
			}
			else if (statusMe != 4 && (Res.abs(cx - cxSend) >= 90 || Res.abs(cy - cySend) >= 90) && cy - cySend > 0)
			{
			}
			if (isLockMove)
			{
				currentMovePoint = null;
			}
			if (currentMovePoint != null && (statusMe == 1 || statusMe == 2))
			{
				statusMe = 2;
				if (cx - currentMovePoint.xEnd > 0)
				{
					cdir = -1;
					if (cx - currentMovePoint.xEnd <= 10)
					{
						currentMovePoint = null;
					}
				}
				else
				{
					cdir = 1;
					if (cx - currentMovePoint.xEnd >= -10)
					{
						currentMovePoint = null;
					}
				}
				if (currentMovePoint != null)
				{
					cvx = getSpeed() * cdir;
					cvy = 0;
				}
			}
			searchFocus();
			if (statusMe == 1 || statusMe == 6)
			{
				if (mSystem.currentTimeMillis() - currMove > 500 && isLastMove)
				{
					isSendMove = true;
					isLastMove = false;
					currMove = mSystem.currentTimeMillis();
				}
			}
			else
			{
				currMove = mSystem.currentTimeMillis();
				isLastMove = true;
			}
		}
		else
		{
			if (GameCanvas.gameTick % 20 == 0 && charID >= 0)
			{
				paintName = true;
				for (int num7 = 0; num7 < GameScr.vCharInMap.size(); num7++)
				{
					Char char2 = null;
					try
					{
						char2 = (Char)GameScr.vCharInMap.elementAt(num7);
					}
					catch (Exception)
					{
					}
					if (char2 != null && !char2.Equals(this) && ((char2.cy == cy && Res.abs(char2.cx - cx) < 35) || (cy - char2.cy < 32 && cy - char2.cy > 0 && Res.abs(char2.cx - cx) < 24)))
					{
						paintName = false;
					}
				}
			}
			if (statusMe == 1 || statusMe == 6)
			{
				bool flag2 = false;
				if (currentMovePoint != null)
				{
					if (abs(currentMovePoint.xEnd - cx) < 4 && abs(currentMovePoint.yEnd - cy) < 4)
					{
						cx = currentMovePoint.xEnd;
						cy = currentMovePoint.yEnd;
						currentMovePoint = null;
						if ((TileMap.tileTypeAtPixel(cx, cy) & TileMap.T_TOP) == TileMap.T_TOP)
						{
							changeStatusStand();
							GameCanvas.gI().startDust(-1, cx - -8, cy);
							GameCanvas.gI().startDust(1, cx - 8, cy);
						}
						else
						{
							statusMe = 4;
							cvy = 0;
						}
						flag2 = true;
					}
					else if (cy == currentMovePoint.yEnd)
					{
						if (cx != currentMovePoint.xEnd)
						{
							cx = (cx + currentMovePoint.xEnd) / 2;
							cf = GameCanvas.gameTick % 5 + 2;
						}
					}
					else if (cy < currentMovePoint.yEnd)
					{
						cf = 12;
						cx = (cx + currentMovePoint.xEnd) / 2;
						if (cvy < 0)
						{
							cvy = 0;
						}
						cy += cvy;
						if ((TileMap.tileTypeAtPixel(cx, cy) & TileMap.T_TOP) == TileMap.T_TOP)
						{
							GameCanvas.gI().startDust(-1, cx - -8, cy);
							GameCanvas.gI().startDust(1, cx - 8, cy);
						}
						cvy++;
						if (cvy > 16)
						{
							cy = (cy + currentMovePoint.yEnd) / 2;
						}
					}
					else
					{
						cf = 7;
						cx = (cx + currentMovePoint.xEnd) / 2;
						cy = (cy + currentMovePoint.yEnd) / 2;
					}
				}
				else
				{
					flag2 = true;
				}
				if (flag2 && vMovePoints.size() > 0)
				{
					if (vMovePoints.size() > 5)
					{
						currentMovePoint = (MovePoint)vMovePoints.lastElement();
						vMovePoints.removeElementAt(0);
						cx = currentMovePoint.xEnd;
						cy = currentMovePoint.yEnd;
						vMovePoints.removeAllElements();
						statusMe = 6;
						currentMovePoint = null;
						return;
					}
					currentMovePoint = (MovePoint)vMovePoints.firstElement();
					vMovePoints.removeElementAt(0);
					if (currentMovePoint.status == 2)
					{
						statusMe = 2;
						if (cx - currentMovePoint.xEnd > 0)
						{
							cdir = -1;
						}
						else if (cx - currentMovePoint.xEnd < 0)
						{
							cdir = 1;
						}
						cvx = 5 * cdir;
						cvy = 0;
					}
					else if (currentMovePoint.status == 3)
					{
						statusMe = 3;
						GameCanvas.gI().startDust(-1, cx - -8, cy);
						GameCanvas.gI().startDust(1, cx - 8, cy);
						if (cx - currentMovePoint.xEnd > 0)
						{
							cdir = -1;
						}
						else if (cx - currentMovePoint.xEnd < 0)
						{
							cdir = 1;
						}
						cvx = abs(cx - currentMovePoint.xEnd) / 9 * cdir;
						cvy = -10;
					}
					else if (currentMovePoint.status == 4)
					{
						statusMe = 4;
						if (cx - currentMovePoint.xEnd > 0)
						{
							cdir = -1;
						}
						else if (cx - currentMovePoint.xEnd < 0)
						{
							cdir = 1;
						}
						cvx = abs(cx - currentMovePoint.xEnd) / 9 * cdir;
						cvy = 0;
					}
					else
					{
						cx = currentMovePoint.xEnd;
						cy = currentMovePoint.yEnd;
						currentMovePoint = null;
					}
				}
				if (statusMe == 6)
				{
					if (cf >= 8 && cf <= 11)
					{
						cf++;
						cp1++;
						if (cf > 11)
						{
							cf = 8;
						}
						if (cp1 > 5)
						{
							cf = 0;
						}
					}
					if (cf <= 1)
					{
						cp1++;
						if (cp1 > 6)
						{
							cf = 0;
						}
						else
						{
							cf = 1;
						}
						if (cp1 > 10)
						{
							cp1 = 0;
						}
					}
				}
				lcx = cx;
				lcy = cy;
				if (mSystem.currentTimeMillis() - timeSummon > 7000)
				{
					if (!isWolf && isHaveWolf() && vitaWolf >= 500)
					{
						isWolf = true;
						ServerEffect.addServerEffect(60, this, 1);
					}
					if (isMoto && isHaveMoto())
					{
						isMoto = false;
						isMotoBehind = true;
					}
				}
			}
		}
		if (isInjure > 0)
		{
			cf = 21;
			isInjure--;
		}
		else
		{
			switch (statusMe)
			{
			case 1:
				isBocdau = false;
				timeBocdau = 0;
				if (isWolf)
				{
					if (cdir == 1)
					{
						EffdefautX = cx + 21 + 4;
						EffdefautY = cy - 15;
					}
					else
					{
						EffdefautX = cx - 24 - 4;
						EffdefautY = cy - 15;
					}
				}
				updateCharStand();
				break;
			case 2:
				if (isMoto)
				{
					timeBocdau++;
					if (arrItemMounts[4].template.id == 485 && arrItemMounts[4].sys >= 4)
					{
						isBocdau = true;
					}
					if (timeBocdau > 20)
					{
						isBocdau = false;
					}
				}
				if (isWolf)
				{
					if (cdir == 1)
					{
						if (idWolfW[tickWolf] == 1737)
						{
							EffdefautX = cx + 21 + 4;
							EffdefautY = cy - 19;
						}
						else
						{
							EffdefautX = cx + 21 + 4;
							EffdefautY = cy - 16;
						}
					}
					else if (idWolfW[tickWolf] == 1737)
					{
						EffdefautX = cx - 24 - 4;
						EffdefautY = cy - 19;
					}
					else
					{
						EffdefautX = cx - 24 - 4;
						EffdefautY = cy - 16;
					}
				}
				else if (isMoto)
				{
					if (cdir == 1)
					{
						EffdefautX = cx + 15;
						EffdefautX1 = cx - 25;
						EffdefautY = cy;
						EffdefautY1 = cy;
					}
					else
					{
						EffdefautX = cx - 18;
						EffdefautX1 = cx + 25;
						EffdefautY = cy;
						EffdefautY1 = cy;
					}
				}
				updateCharRun();
				break;
			case 3:
				isBocdau = false;
				timeBocdau = 0;
				if (isWolf)
				{
					if (cdir == 1)
					{
						EffdefautX = cx + 21 + 4;
						EffdefautY = cy - 30;
					}
					else
					{
						EffdefautX = cx - 23 - 4;
						EffdefautY = cy - 30;
					}
				}
				updateCharJump();
				break;
			case 4:
				isBocdau = false;
				timeBocdau = 0;
				if (isWolf)
				{
					if (cdir == 1)
					{
						EffdefautX = cx + 21 + 4;
						EffdefautY = cy - 19;
					}
					else
					{
						EffdefautX = cx - 24;
						EffdefautY = cy - 20;
					}
				}
				updateCharFall();
				break;
			case 5:
				isBocdau = false;
				timeBocdau = 0;
				updateCharDeadFly();
				break;
			case 9:
				isBocdau = false;
				timeBocdau = 0;
				updateCharAutoJump();
				break;
			case 10:
				isBocdau = false;
				timeBocdau = 0;
				updateCharWaterRun();
				break;
			case 11:
				isBocdau = false;
				timeBocdau = 0;
				updateCharWaterDown();
				break;
			case 12:
				isBocdau = false;
				timeBocdau = 0;
				updateSkillStand();
				break;
			case 13:
				isBocdau = false;
				timeBocdau = 0;
				updateSkillFall();
				break;
			case 14:
				isBocdau = false;
				timeBocdau = 0;
				break;
			case 6:
				isBocdau = false;
				timeBocdau = 0;
				if (cf == 21 && isInjure <= 0)
				{
					cf = 0;
				}
				break;
			}
		}
		if (wdx != 0 || wdy != 0)
		{
			startDie(wdx, wdy);
			wdx = 0;
			wdy = 0;
		}
		if (moveFast != null)
		{
			if (moveFast[0] == 0)
			{
				moveFast[0]++;
				ServerEffect.addServerEffect(60, this, 1);
			}
			else if (moveFast[0] < 10)
			{
				moveFast[0]++;
			}
			else
			{
				cx = moveFast[1];
				cy = moveFast[2];
				moveFast = null;
				ServerEffect.addServerEffect(60, this, 1);
				if (me)
				{
					if ((TileMap.tileTypeAtPixel(cx, cy) & TileMap.T_TOP) != TileMap.T_TOP)
					{
						statusMe = 4;
						getMyChar().setAutoSkillPaint(GameScr.sks[38], 1);
					}
					else
					{
						getMyChar().setAutoSkillPaint(GameScr.sks[38], 0);
					}
				}
			}
		}
		if (!me && vMovePoints.size() == 0 && cxMoveLast != 0 && cyMoveLast != 0 && currentMovePoint == null)
		{
			if (cxMoveLast != cx)
			{
				cx = cxMoveLast;
			}
			if (cyMoveLast != cy)
			{
				cy = cyMoveLast;
			}
			if (cHP > 0)
			{
				statusMe = 6;
			}
		}
		updateEffectWolf();
		fixMove();
		updateDataEff(0, statusMe);
	}

	public void fixMove()
	{
		if (me)
		{
			return;
		}
		if (cf == 12 && cX0 == cx && cY0 == cy)
		{
			inAir++;
		}
		else if (cf == 0 && (TileMap.tileTypeAtPixel(cx, cy) & TileMap.T_TOP) != TileMap.T_TOP)
		{
			inAir++;
		}
		else
		{
			inAir = 0;
		}
		if (inAir <= 1)
		{
			return;
		}
		int num = cy;
		while (true)
		{
			if (num < cy + 150)
			{
				if ((TileMap.tileTypeAtPixel(cx, num) & TileMap.T_TOP) != TileMap.T_TOP)
				{
					break;
				}
				num += 24;
				continue;
			}
			return;
		}
		int num2 = TileMap.tileYofPixel(num) + 24;
		if (num2 - cy > 24)
		{
			cy += (num2 - cy) / 2;
			if (!isMoto && !isWolf)
			{
				cf = 12;
			}
			vMovePoints.removeAllElements();
			currentMovePoint = null;
		}
		else
		{
			statusMe = 1;
			vMovePoints.removeAllElements();
			currentMovePoint = null;
			cvx = 0;
			cvy = 0;
			cp1 = 0;
			cp2 = 0;
			cp3 = 0;
			inAir = 0;
			cxMoveLast = 0;
			cyMoveLast = 0;
			cy = num2;
		}
		lcy = cy;
	}

	private void autoPickItemMap()
	{
		if (!me || cHP <= 0 || statusMe == 14 || statusMe == 5 || testCharId != -9999)
		{
			return;
		}
		int num = 70;
		if (GameScr.isUseitemAuto)
		{
			num = 240;
		}
		if (!isAPickYen && !isAPickYHM && !isAPickYHMS)
		{
			return;
		}
		for (int i = 0; i < GameScr.vItemMap.size(); i++)
		{
			ItemMap itemMap = (ItemMap)GameScr.vItemMap.elementAt(i);
			if (itemMap == null)
			{
				continue;
			}
			int num2 = Math.abs(getMyChar().cx - itemMap.x);
			int num3 = Math.abs(getMyChar().cy - itemMap.y);
			if (num2 <= num && num3 <= num)
			{
				if ((isAPickYen || isAPickYHM || isAPickYHMS) && itemMap.template.type == 19)
				{
					Service.gI().pickItem(itemMap.itemMapID);
				}
				else if ((itemMap.template.type == 16 || itemMap.template.type == 17) && (isAPickYHM || isAPickYHMS))
				{
					Service.gI().pickItem(itemMap.itemMapID);
				}
				else if (itemMap.template.id == 27 && isAPickYHMS)
				{
					Service.gI().pickItem(itemMap.itemMapID);
				}
			}
		}
	}

	private void updateMobMe()
	{
		if (mobMe.templateId == 122 || mobMe.templateId == 70 || (mobMe.getTemplate() != null && mobMe.getTemplate().typeFly == 1))
		{
			if (mobMe.status != 3)
			{
				mobMe.xFirst = cx + (3 - GameCanvas.gameTick % 6) * 6;
				mobMe.yFirst = cy - 60;
				int num = mobMe.xFirst - mobMe.x;
				int num2 = mobMe.yFirst - mobMe.y;
				if (num > 50 || num < -50)
				{
					mobMe.x += num / 10;
				}
				if (num2 > 50 || num2 < -50)
				{
					mobMe.y += num2 / 10;
				}
			}
			mobMe.update();
			return;
		}
		if (mobMe.status != 3)
		{
			if (cdir == -1)
			{
				mobMe.xFirst = cx + 20;
				mobMe.yFirst = cy;
				mobMe.dir = cdir;
				mobMe.y = cy - 20;
			}
			else
			{
				mobMe.xFirst = cx - 20;
				mobMe.yFirst = cy;
				mobMe.dir = cdir;
				mobMe.y = cy - 20;
			}
			int num3 = mobMe.xFirst - mobMe.x;
			int num4 = mobMe.yFirst - mobMe.y;
			if (num3 > 50 || num3 < -50)
			{
				mobMe.x += num3 / 10;
			}
			else
			{
				mobMe.x += num3;
			}
			if (num4 > 50 || num4 < -50)
			{
				mobMe.y += num4 / 10;
			}
		}
		mobMe.update();
	}

	private void updateSkillPaint()
	{
		if (statusMe == 14 || statusMe == 5)
		{
			return;
		}
		if (skillPaint != null && mobFocus != null && mobFocus.status == 0)
		{
			if (!me)
			{
				if ((TileMap.tileTypeAtPixel(cx, cy) & TileMap.T_TOP) == TileMap.T_TOP)
				{
					changeStatusStand();
				}
				else
				{
					statusMe = 6;
				}
			}
			indexSkill = 0;
			skillPaint = null;
			eff0 = (eff1 = (eff2 = null));
			i0 = (i1 = (i2 = 0));
			mobFocus = null;
			effPaints = null;
			arr = null;
		}
		if (skillPaint != null && arr == null && indexSkill >= skillInfoPaint1().Length)
		{
			if (!me)
			{
				if ((TileMap.tileTypeAtPixel(cx, cy) & TileMap.T_TOP) == TileMap.T_TOP)
				{
					changeStatusStand();
				}
				else
				{
					statusMe = 6;
				}
			}
			indexSkill = 0;
			skillPaint = null;
			eff0 = (eff1 = (eff2 = null));
			i0 = (i1 = (i2 = 0));
			arr = null;
		}
		SkillInfoPaint[] array = skillInfoPaint1();
		if (array == null)
		{
			return;
		}
		if (me && myskill.template.type == 2)
		{
			if (indexSkill == array.Length - array.Length / 3)
			{
				Service.gI().sendUseSkillMyBuff();
				saveLoadPreviousSkill();
			}
		}
		else if ((mobFocus != null || (!me && charFocus != null) || (me && charFocus != null && isMeCanAttackOtherPlayer(charFocus))) && arr == null && indexSkill == array.Length - array.Length / 3)
		{
			setAttack();
			if (me)
			{
				saveLoadPreviousSkill();
			}
		}
	}

	public void saveLoadPreviousSkill()
	{
		if (mSystem.currentTimeMillis() - timeLastCheck <= 500)
		{
			return;
		}
		if (myskill.template.type != 1 && lastNormalSkill != null)
		{
			myskill = lastNormalSkill;
			Service.gI().selectSkill(myskill.template.id);
		}
		if (currentFireByShortcut)
		{
			if (lastNormalSkill != null)
			{
				myskill = lastNormalSkill;
				Service.gI().selectSkill(myskill.template.id);
			}
		}
		else if (GameScr.auto != 1)
		{
			lastNormalSkill = myskill;
		}
		timeLastCheck = mSystem.currentTimeMillis();
	}

	private void updateCharDeadFly()
	{
		cp1++;
		cx += (cp2 - cx) / 4;
		if (cp1 > 7)
		{
			cy += (cp3 - cy) / 4;
		}
		else
		{
			cy += cp1 - 10;
		}
		if (Res.abs(cp2 - cx) < 4 && Res.abs(cp3 - cy) < 10)
		{
			cx = cp2;
			cy = cp3;
			statusMe = 14;
			callEff(60);
			if (me)
			{
				GameScr.gI().resetButton();
			}
		}
		cf = 21;
	}

	public void setAttk()
	{
		cp1++;
		if (cdir == 1)
		{
			if ((TileMap.tileTypeAtPixel(cx + chw, cy - chh) & TileMap.T_LEFT) == TileMap.T_LEFT)
			{
				cvx = 0;
			}
		}
		else if ((TileMap.tileTypeAtPixel(cx - chw, cy - chh) & TileMap.T_RIGHT) == TileMap.T_RIGHT)
		{
			cvx = 0;
		}
		if (cy > ch && TileMap.tileTypeAt(cx, cy - ch, TileMap.T_BOTTOM))
		{
			if (!TileMap.tileTypeAt(cx, cy, TileMap.T_TOP))
			{
				statusMe = 4;
				cp1 = 0;
				cp2 = 0;
				cvy = 1;
			}
			else
			{
				cy = TileMap.tileYofPixel(cy);
			}
		}
		cx += cvx;
		cy += cvy;
		if (cy < 0)
		{
			cy = (cvy = 0);
		}
		if (cvy == 0)
		{
			if ((TileMap.tileTypeAtPixel(cx, cy) & TileMap.T_TOP) != TileMap.T_TOP)
			{
				statusMe = 4;
				cvx = (getSpeed() >> 1) * cdir;
				cp1 = (cp2 = 0);
			}
		}
		else if (cvy < 0)
		{
			cvy++;
			if (cvy == 0)
			{
				cvy = 1;
			}
		}
		else
		{
			if (cvy < 20 && cp1 % 5 == 0)
			{
				cvy++;
			}
			if (cvy > 3)
			{
				cvy = 3;
			}
			if ((TileMap.tileTypeAtPixel(cx, cy + 3) & TileMap.T_TOP) == TileMap.T_TOP && cy <= TileMap.tileXofPixel(cy + 3))
			{
				cvx = (cvy = 0);
				cy = TileMap.tileXofPixel(cy + 3);
			}
			if (TileMap.tileTypeAt(cx, cy, TileMap.T_WATERFLOW) && cy % TileMap.size > 8)
			{
				statusMe = 10;
				cvx = cdir << 1;
				cvy >>= 2;
				cy = TileMap.tileYofPixel(cy) + 12;
				statusMe = 11;
				return;
			}
			if (TileMap.tileTypeAt(cx, cy, TileMap.T_UNDERWATER))
			{
				statusMe = 11;
				return;
			}
		}
		if (cvx > 0)
		{
			cvx--;
		}
		else if (cvx < 0)
		{
			cvx++;
		}
	}

	private void playSound(SkillPaint skillPaint)
	{
		int num = NinjaUtil.randomNumber(3);
		float num2 = 0f;
		num2 = (me ? 0.8f : 0.4f);
		switch (nClass.classId)
		{
		case 0:
			Sound.play(Sound.MKiemGo, num2);
			break;
		case 1:
			switch (num)
			{
			case 0:
				Sound.play(Sound.MKiem, num2);
				break;
			case 1:
				Sound.play(Sound.MKiem2, num2);
				break;
			default:
				Sound.play(Sound.MKiem3, num2);
				break;
			}
			break;
		case 2:
			Sound.play(Sound.MTieu, num2);
			break;
		case 3:
			Sound.play(Sound.MKunai, num2);
			break;
		case 4:
			switch (num)
			{
			case 0:
				Sound.play(Sound.MCung, num2);
				break;
			case 1:
				Sound.play(Sound.MCung2, num2);
				break;
			default:
				Sound.play(Sound.MCung3, num2);
				break;
			}
			break;
		case 5:
			if (skillPaint.id == 41)
			{
				Sound.play(Sound.MDao2, num2);
			}
			else if (skillPaint.id == 45)
			{
				Sound.play(Sound.MDao3, num2);
			}
			else
			{
				Sound.play(Sound.MDao, num2);
			}
			break;
		case 6:
			Sound.play(Sound.MQuat, num2);
			break;
		}
	}

	public void updateSkillFall()
	{
	}

	public void updateSkillStand()
	{
		setAttk();
	}

	public void updateCharAutoJump()
	{
		cx += cvx * cdir;
		cy += cvyJump;
		cvyJump++;
		if (cp1 == 0)
		{
			cf = 7;
		}
		else
		{
			cf = 23;
		}
		if (canJumpHigh)
		{
			if (cvyJump == -3)
			{
				cf = 8;
			}
			else if (cvyJump == -2)
			{
				cf = 9;
			}
			else if (cvyJump == -1)
			{
				cf = 10;
			}
			else if (cvyJump == 0)
			{
				cf = 11;
			}
		}
		if (cvyJump == 0)
		{
			statusMe = 6;
			((MovePoint)vMovePoints.firstElement()).status = 4;
			isJump = true;
			cp1 = 0;
			cvy = 1;
		}
	}

	public int getVx(int size, int dx, int dy)
	{
		if (dy > 0 && !TileMap.tileTypeAt(cx, cy, TileMap.T_TOP))
		{
			if (dx - dy <= 10)
			{
				return 5;
			}
			if (dx - dy <= 30)
			{
				return 6;
			}
			if (dx - dy <= 50)
			{
				return 7;
			}
			if (dx - dy <= 70)
			{
				return 8;
			}
		}
		if (dx <= 30)
		{
			return 4;
		}
		if (dx <= 160)
		{
			return 5;
		}
		if (dx <= 270)
		{
			return 6;
		}
		if (dx <= 320)
		{
			return 7;
		}
		return 8;
	}

	public int getVy(int size, int dx, int dy)
	{
		if (dy <= 10)
		{
			return 5;
		}
		if (dy <= 20)
		{
			return 6;
		}
		if (dy <= 30)
		{
			return 7;
		}
		if (dy <= 40)
		{
			return 8;
		}
		if (dy <= 50)
		{
			return 9;
		}
		return 10;
	}

	public int returnAct(int xFirst, int yFirst, int xEnd, int yEnd)
	{
		int num = xEnd - xFirst;
		int num2 = yEnd - yFirst;
		if (num == 0 && num2 == 0)
		{
			return 1;
		}
		if (num2 == 0 && yFirst % 24 == 0 && TileMap.tileTypeAt(xFirst, yFirst, TileMap.T_TOP))
		{
			return 2;
		}
		if (num2 > 0 && (yFirst % 24 != 0 || !TileMap.tileTypeAt(xFirst, yFirst, TileMap.T_TOP)))
		{
			return 4;
		}
		cvy = -10;
		cp1 = 0;
		cdir = ((num > 0) ? 1 : (-1));
		if (num <= 5)
		{
			cvx = 0;
		}
		else if (num <= 10)
		{
			cvx = 3;
		}
		else
		{
			cvx = 5;
		}
		return 9;
	}

	public void setAutoJump()
	{
		int num = ((MovePoint)vMovePoints.firstElement()).xEnd - cx;
		if (canJumpHigh)
		{
			cvyJump = -10;
		}
		else
		{
			cvyJump = -8;
		}
		cp1 = 0;
		cdir = ((num > 0) ? 1 : (-1));
		if (num <= 6)
		{
			cvx = 0;
		}
		else if (num <= 20)
		{
			cvx = 3;
		}
		else
		{
			cvx = 5;
		}
	}

	public void updateCharStand()
	{
		isAttack = false;
		isAttFly = false;
		cvx = 0;
		cvy = 0;
		cp1++;
		lcx = cx;
		lcy = cy;
		if (cp1 > 30)
		{
			cp1 = 0;
		}
		if (cp1 % 15 < 5)
		{
			cf = 0;
		}
		else
		{
			cf = 1;
		}
		updateCharInBridge();
		if (mSystem.currentTimeMillis() - timeSummon > 7000)
		{
			if (!isWolf && isHaveWolf() && vitaWolf >= 500)
			{
				isWolf = true;
				ServerEffect.addServerEffect(60, this, 1);
			}
			if (isMoto && isHaveMoto())
			{
				isMoto = false;
				isMotoBehind = true;
			}
		}
	}

	public void updateCharRun()
	{
		int num = 0;
		if (!me && currentMovePoint != null)
		{
			num = abs(cx - currentMovePoint.xEnd);
		}
		cp1++;
		if (cp1 >= 10)
		{
			cp1 = 0;
			cBonusSpeed = 0;
		}
		cf = (cp1 >> 1) + 2;
		if ((TileMap.tileTypeAtPixel(cx, cy - 1) & TileMap.T_WATERFLOW) == TileMap.T_WATERFLOW)
		{
			cx += cvx >> 1;
		}
		else
		{
			cx += cvx;
		}
		if (cdir == 1)
		{
			if (GameScr.auto != 1)
			{
				if (TileMap.tileTypeAt(cx + chw, cy - chh, TileMap.T_LEFT))
				{
					if (me)
					{
						cvx = 0;
						cx = TileMap.tileXofPixel(cx + chw) - chw;
					}
					else
					{
						stop();
					}
				}
			}
			else if (TileMap.tileTypeAt(cx + chw, cy - chh, TileMap.T_LEFT))
			{
				if (me)
				{
					statusMe = 3;
					if (statusMe == 3)
					{
						cvy -= 10;
					}
				}
				else
				{
					stop();
				}
			}
		}
		else if (GameScr.auto != 1)
		{
			if (TileMap.tileTypeAt(cx - chw - 1, cy - chh, TileMap.T_RIGHT))
			{
				if (me)
				{
					cvx = 0;
					cx = TileMap.tileXofPixel(cx - chw - 1) + TileMap.size + chw;
				}
				else
				{
					stop();
				}
			}
		}
		else if (TileMap.tileTypeAt(cx - chw - 1, cy - chh, TileMap.T_RIGHT))
		{
			if (me)
			{
				statusMe = 3;
				if (statusMe == 3)
				{
					cvy -= 10;
				}
			}
			else
			{
				stop();
			}
		}
		if (!isMoto && isHaveMoto())
		{
			isMoto = true;
			isMotoBehind = false;
		}
		if (!isWolf && isHaveWolf() && vitaWolf >= 500)
		{
			dx0 = Res.abs(cx - lcx);
			dy0 = Res.abs(cy - lcy);
			dx0 = ((dx0 <= dy0) ? dy0 : dx0);
			if ((me && dx0 > 150) || (!me && dx0 > 40))
			{
				isWolf = true;
				ServerEffect.addServerEffect(60, this, 1);
			}
			dx0 = (dy0 = 0);
		}
		if (me)
		{
			if (cvx > 0)
			{
				cvx--;
			}
			else if (cvx < 0)
			{
				cvx++;
			}
			else
			{
				if (cx - cxSend != 0)
				{
				}
				changeStatusStand();
				cBonusSpeed = 0;
			}
		}
		if ((TileMap.tileTypeAtPixel(cx, cy) & TileMap.T_TOP) != TileMap.T_TOP)
		{
			if (me)
			{
				cf = 7;
				statusMe = 4;
				cvx = 3 * cdir;
				cp2 = 0;
			}
			else
			{
				stop();
			}
		}
		if (!me && currentMovePoint != null)
		{
			int num2 = abs(cx - currentMovePoint.xEnd);
			if (num2 > num)
			{
				stop();
			}
		}
		if (isMoto)
		{
			if (GameCanvas.gameTick % 5 == 0)
			{
				ServerEffect.addServerEffect(120, cx - (cdir << 5), cy, 0, (sbyte)cdir);
			}
		}
		else
		{
			GameCanvas.gI().startDust(cdir, cx - (cdir << 3), cy);
		}
		updateCharInBridge();
		startCoatEffect(cx - (cdir << 4), cy);
	}

	private void stop()
	{
		statusMe = 6;
		cvx = 0;
		cvy = 0;
		cp1 = (cp2 = 0);
	}

	public static int abs(int i)
	{
		return (i <= 0) ? (-i) : i;
	}

	public void updateCharJump()
	{
		if (GameScr.auto == 1)
		{
			if (cdir == 1)
			{
				cvx = 5;
			}
			else
			{
				cvx = -5;
			}
		}
		if (isHaveMoto())
		{
			isMoto = true;
			isMotoBehind = false;
		}
		cx += cvx;
		cy += cvy;
		if (cy < 0)
		{
			cy = 0;
			cvy = -1;
		}
		cvy++;
		if (!me && currentMovePoint != null)
		{
			int num = currentMovePoint.xEnd - cx;
			if (num > 0)
			{
				if (cvx > num)
				{
					cvx = num;
				}
				if (cvx < 0)
				{
					cvx = num;
				}
			}
			else if (num < 0)
			{
				if (cvx < num)
				{
					cvx = num;
				}
				if (cvx > 0)
				{
					cvx = num;
				}
			}
			else
			{
				cvx = num;
			}
		}
		if (cp1 == 0)
		{
			cf = 7;
		}
		else
		{
			cf = 23;
		}
		if (canJumpHigh)
		{
			if (cvy == -3)
			{
				cf = 8;
			}
			else if (cvy == -2)
			{
				cf = 9;
			}
			else if (cvy == -1)
			{
				cf = 10;
			}
			else if (cvy == 0)
			{
				cf = 11;
			}
		}
		if (cdir == 1)
		{
			if ((TileMap.tileTypeAtPixel(cx + chw, cy - 1) & TileMap.T_LEFT) == TileMap.T_LEFT && cx <= TileMap.tileXofPixel(cx + chw) + 12)
			{
				cx = TileMap.tileXofPixel(cx + chw) - chw;
				cvx = 0;
			}
		}
		else if ((TileMap.tileTypeAtPixel(cx - chw, cy - 1) & TileMap.T_RIGHT) == TileMap.T_RIGHT && cx >= TileMap.tileXofPixel(cx - chw) + 12)
		{
			cx = TileMap.tileXofPixel(cx + 24 - chw) + chw;
			cvx = 0;
		}
		if (cvy == 0)
		{
			if (!isAttFly)
			{
				if (me)
				{
					setCharFallFromJump();
				}
				else
				{
					stop();
				}
			}
			else
			{
				setCharFallFromJump();
			}
		}
		if (me && !ischangingMap && isInWaypoint())
		{
			InfoDlg.hide();
			isSendMove = true;
			Service.gI().requestChangeMap();
			isLockKey = true;
			ischangingMap = true;
			GameCanvas.clearKeyHold();
			GameCanvas.clearKeyPressed();
			return;
		}
		if (cp3 < 0)
		{
			cp3++;
		}
		if (cy > ch && TileMap.tileTypeAt(cx, cy - ch, TileMap.T_BOTTOM))
		{
			if (me)
			{
				statusMe = 4;
				cp1 = 0;
				cp2 = 0;
				cvy = 1;
			}
			else
			{
				stop();
			}
		}
		if (!me && currentMovePoint != null && cy < currentMovePoint.yEnd)
		{
			stop();
		}
	}

	public bool checkInRangeJump(int x1, int xw1, int xmob, int y1, int yh1, int ymob)
	{
		if (xmob > xw1 || xmob < x1 || ymob > y1 || ymob < yh1)
		{
			return false;
		}
		return true;
	}

	public void setCharFallFromJump()
	{
		cyStartFall = cy;
		statusMe = 4;
		cp1 = 0;
		if (canJumpHigh)
		{
			cp2 = 1;
		}
		else
		{
			cp2 = 0;
		}
		cvy = 1;
		if (!me)
		{
		}
	}

	public void updateCharFall()
	{
		if (cy + 4 >= TileMap.pxh)
		{
			changeStatusStand();
			cvx = (cvy = 0);
			return;
		}
		if (cy % 24 == 0 && (TileMap.tileTypeAtPixel(cx, cy) & TileMap.T_TOP) == TileMap.T_TOP)
		{
			if (me)
			{
				cvx = (cvy = 0);
				cp1 = (cp2 = 0);
				changeStatusStand();
				return;
			}
			stop();
			cf = 0;
			GameCanvas.gI().startDust(-1, cx - -8, cy);
			GameCanvas.gI().startDust(1, cx - 8, cy);
		}
		cf = 12;
		cx += cvx;
		if (!me && currentMovePoint != null)
		{
			int num = currentMovePoint.xEnd - cx;
			if (num > 0)
			{
				if (cvx > num)
				{
					cvx = num;
				}
				if (cvx < 0)
				{
					cvx = num;
				}
			}
			else if (num < 0)
			{
				if (cvx < num)
				{
					cvx = num;
				}
				if (cvx > 0)
				{
					cvx = num;
				}
			}
			else
			{
				cvx = num;
			}
		}
		cy += cvy;
		if (cvy < 20)
		{
			cvy++;
		}
		if (cdir == 1)
		{
			if ((TileMap.tileTypeAtPixel(cx + chw, cy - 1) & TileMap.T_LEFT) == TileMap.T_LEFT && cx <= TileMap.tileXofPixel(cx + chw) + 12)
			{
				cx = TileMap.tileXofPixel(cx + chw) - chw;
				cvx = 0;
			}
		}
		else if ((TileMap.tileTypeAtPixel(cx - chw, cy - 1) & TileMap.T_RIGHT) == TileMap.T_RIGHT && cx >= TileMap.tileXofPixel(cx - chw) + 12)
		{
			cx = TileMap.tileXofPixel(cx + 24 - chw) + chw;
			cvx = 0;
		}
		if (cvy > 4 && (cyStartFall == 0 || cyStartFall <= TileMap.tileYofPixel(cy + 3)) && (TileMap.tileTypeAtPixel(cx, cy + 3) & TileMap.T_TOP) == TileMap.T_TOP)
		{
			if (me)
			{
				cyStartFall = 0;
				cvx = (cvy = 0);
				cp1 = (cp2 = 0);
				cy = TileMap.tileXofPixel(cy + 3);
				changeStatusStand();
				GameCanvas.gI().startDust(-1, cx - -8, cy);
				GameCanvas.gI().startDust(1, cx - 8, cy);
			}
			else
			{
				stop();
				cy = TileMap.tileXofPixel(cy + 3);
				cf = 0;
				GameCanvas.gI().startDust(-1, cx - -8, cy);
				GameCanvas.gI().startDust(1, cx - 8, cy);
			}
			return;
		}
		if (cp2 == 1)
		{
			if (cvy == 3)
			{
				cf = 11;
			}
			else if (cvy == 2)
			{
				cf = 8;
			}
			else if (cvy == 1)
			{
				cf = 9;
			}
			else if (cvy == 0)
			{
				cf = 10;
			}
		}
		else
		{
			cf = 12;
		}
		if (cvy > 6 && TileMap.tileTypeAt(cx, cy, TileMap.T_WATERFLOW) && cy % TileMap.size > 8)
		{
			cy = TileMap.tileYofPixel(cy) + 8;
			statusMe = 10;
			cvx = cdir << 1;
			cvy >>= 2;
			cy = TileMap.tileYofPixel(cy) + 12;
		}
		if (me)
		{
			if (!isAttack)
			{
			}
			return;
		}
		if ((TileMap.tileTypeAtPixel(cx, cy + 1) & TileMap.T_TOP) == TileMap.T_TOP)
		{
			cf = 0;
		}
		if (currentMovePoint != null && cy > currentMovePoint.yEnd)
		{
			stop();
		}
	}

	public void updateCharWaterRun()
	{
		if (!TileMap.tileTypeAt(cx, cy, TileMap.T_WATERFLOW))
		{
			statusMe = 4;
		}
		cp1++;
		if (cp1 >= 5)
		{
			cp1 = 0;
			cBonusSpeed = 0;
		}
		cf = cp1 + 2;
		if (cdir == 1)
		{
			if (TileMap.tileTypeAt(cx + chw, cy - 1, TileMap.T_LEFT))
			{
				cvx = 0;
				cx = TileMap.tileXofPixel(cx + chw) - chw;
			}
		}
		else if (TileMap.tileTypeAt(cx - chw - 1, cy - 1, TileMap.T_RIGHT))
		{
			cvx = 0;
			cx = TileMap.tileXofPixel(cx - chw - 1) + TileMap.size + chw;
		}
		cx += cvx;
		if (cvx > 0)
		{
			cvx--;
		}
		else if (cvx < 0)
		{
			cvx++;
		}
		else
		{
			if (me && mSystem.currentTimeMillis() - (timelastSendmove + delaySendmove) >= 0)
			{
				isSendMove = true;
			}
			statusMe = 11;
			cBonusSpeed = 0;
		}
		if (GameCanvas.gameTick % 8 == 0)
		{
		}
		GameCanvas.gI().startWaterSplash(cx, cy);
		GameCanvas.gI().startDust(cdir, cx - (cdir << 3), cy);
	}

	public void updateCharWaterDown()
	{
		cy += cvy;
		if (cvy < 20 && GameCanvas.gameTick % 2 == 0)
		{
			cvy++;
		}
		cf = 7;
		if (cy >= TileMap.pxh)
		{
			cHP = 0;
			statusMe = 5;
		}
		else if (TileMap.tileTypeAt(cx, cy, TileMap.T_TOP))
		{
			changeStatusStand();
			cvx = (cvy = 0);
			cp1 = (cp2 = 0);
			cy = TileMap.tileXofPixel(cy);
		}
		else if (TileMap.tileTypeAt(cx, cy, TileMap.T_UNDERWATER))
		{
			cHP = 0;
			statusMe = 5;
		}
	}

	public void setDefaultPart()
	{
		setDefaultWeapon();
		setDefaultBody();
		setDefaultLeg();
	}

	public void setDefaultWeapon()
	{
		wp = 15;
	}

	public Part getDefaultHead(int gender)
	{
		try
		{
			if (gender == 0)
			{
				return GameScr.parts[27];
			}
			return GameScr.parts[2];
			IL_0021:;
		}
		catch (Exception)
		{
		}
		return null;
	}

	public void setDefaultBody()
	{
		if (cgender == 0)
		{
			body = 10;
		}
		else
		{
			body = 1;
		}
	}

	public void setDefaultLeg()
	{
		if (cgender == 0)
		{
			leg = 9;
		}
		else
		{
			leg = 0;
		}
	}

	public void setSkillPaint(SkillPaint skillPaint, int sType)
	{
		long currentTimeMillis = mSystem.getCurrentTimeMillis();
		if (me)
		{
			if (currentTimeMillis - myskill.lastTimeUseThisSkill < myskill.coolDown)
			{
				myskill.paintCanNotUseSkill = true;
				return;
			}
			myskill.lastTimeUseThisSkill = currentTimeMillis;
			cMP -= myskill.manaUse;
			if (cMP < 0)
			{
				cMP = 0;
			}
			playSound(skillPaint);
		}
		else if (isCharInScreen(this))
		{
			playSound(skillPaint);
		}
		setAutoSkillPaint(skillPaint, sType);
	}

	public void setAutoSkillPaint(SkillPaint skillPaint, int sType)
	{
		this.skillPaint = skillPaint;
		this.sType = sType;
		indexSkill = 0;
		i0 = (i1 = (i2 = (dx0 = (dx1 = (dx2 = (dy0 = (dy1 = (dy2 = 0))))))));
		eff0 = null;
		eff1 = null;
		eff2 = null;
	}

	public SkillInfoPaint[] skillInfoPaint1()
	{
		if (skillPaint == null)
		{
			return null;
		}
		if (sType == 0)
		{
			return skillPaint.skillStand;
		}
		return skillPaint.skillfly;
	}

	public void paintHead(mGraphics g, int xStart, int yStart)
	{
		Part part = GameScr.parts[head];
		Part part2 = GameScr.parts[leg];
		Part part3 = GameScr.parts[body];
		if (arrItemBody != null && arrItemBody[11] != null)
		{
			part = GameScr.parts[arrItemBody[11].template.part];
		}
		if (cdir == 1)
		{
			SmallImage.drawSmallImage(g, part.pi[CharInfo[cf][0][0]].id, xStart + CharInfo[cf][0][1] + part.pi[CharInfo[cf][0][0]].dx, yStart - CharInfo[cf][0][2] + part.pi[CharInfo[cf][0][0]].dy, 0, 0);
			SmallImage.drawSmallImage(g, part2.pi[CharInfo[cf][1][0]].id, xStart + CharInfo[cf][1][1] + part2.pi[CharInfo[cf][1][0]].dx, yStart - CharInfo[cf][1][2] + part2.pi[CharInfo[cf][1][0]].dy, 0, 0);
			SmallImage.drawSmallImage(g, part3.pi[CharInfo[cf][2][0]].id, xStart + CharInfo[cf][2][1] + part3.pi[CharInfo[cf][2][0]].dx, yStart - CharInfo[cf][2][2] + part3.pi[CharInfo[cf][2][0]].dy, 0, 0);
		}
		else
		{
			SmallImage.drawSmallImage(g, part.pi[CharInfo[cf][0][0]].id, xStart - CharInfo[cf][0][1] - part.pi[CharInfo[cf][0][0]].dx, yStart - CharInfo[cf][0][2] + part.pi[CharInfo[cf][0][0]].dy, 2, 24);
			SmallImage.drawSmallImage(g, part2.pi[CharInfo[cf][1][0]].id, xStart - CharInfo[cf][1][1] - part2.pi[CharInfo[cf][1][0]].dx, yStart - CharInfo[cf][1][2] + part2.pi[CharInfo[cf][1][0]].dy, 2, 24);
			SmallImage.drawSmallImage(g, part3.pi[CharInfo[cf][2][0]].id, xStart - CharInfo[cf][2][1] - part3.pi[CharInfo[cf][2][0]].dx, yStart - CharInfo[cf][2][2] + part3.pi[CharInfo[cf][2][0]].dy, 2, 24);
		}
	}

	public void setAttack()
	{
		int num = 0;
		try
		{
			GameCanvas.debug("SetAttk", 0);
			if (!me)
			{
				if (skillPaint != null && (mobFocus != null || charFocus != null))
				{
					num = 2;
					GameCanvas.debug("SkB", 0);
					if (attMobs != null && attChars != null)
					{
						num = 3;
						effPaints = new EffectPaint[attMobs.Length + attChars.Length];
						for (int i = 0; i < attMobs.Length; i++)
						{
							effPaints[i] = new EffectPaint();
							effPaints[i].effCharPaint = GameScr.efs[skillPaint.effId - 1];
							effPaints[i].eMob = attMobs[i];
						}
						for (int j = 0; j < attChars.Length; j++)
						{
							effPaints[j + attMobs.Length] = new EffectPaint();
							effPaints[j + attMobs.Length].effCharPaint = GameScr.efs[skillPaint.effId - 1];
							effPaints[j + attMobs.Length].eChar = attChars[j];
						}
						attMobs = null;
						attChars = null;
					}
					else if (attMobs != null)
					{
						num = 4;
						effPaints = new EffectPaint[attMobs.Length];
						for (int k = 0; k < attMobs.Length; k++)
						{
							effPaints[k] = new EffectPaint();
							effPaints[k].effCharPaint = GameScr.efs[skillPaint.effId - 1];
							effPaints[k].eMob = attMobs[k];
						}
						attMobs = null;
					}
					else if (attChars != null)
					{
						num = 5;
						effPaints = new EffectPaint[attChars.Length];
						for (int l = 0; l < attChars.Length; l++)
						{
							effPaints[l] = new EffectPaint();
							effPaints[l].effCharPaint = GameScr.efs[skillPaint.effId - 1];
							effPaints[l].eChar = attChars[l];
						}
						attChars = null;
					}
					GameCanvas.debug("SkC", 0);
					num = 6;
					if (effPaints.Length > 1 && effPaints[0] != null)
					{
						num = 7;
						EPosition firstPos = new EPosition();
						if (effPaints[0].eMob != null)
						{
							firstPos = new EPosition(effPaints[0].eMob.x, effPaints[0].eMob.y);
						}
						else if (effPaints[0].eChar != null)
						{
							firstPos = new EPosition(effPaints[0].eChar.cx, effPaints[0].eChar.cy);
						}
						num = 8;
						MyVector myVector = new MyVector();
						for (int m = 1; m < effPaints.Length; m++)
						{
							if (effPaints[m].eMob != null)
							{
								myVector.addElement(new EPosition(effPaints[m].eMob.x, effPaints[m].eMob.y));
							}
							else if (effPaints[m].eChar != null)
							{
								myVector.addElement(new EPosition(effPaints[m].eChar.cx, effPaints[m].eChar.cy));
							}
							if (m > 5)
							{
								break;
							}
						}
						num = 9;
						Lightning.addLight(myVector, firstPos, isContinue: true, getClassColor());
					}
					GameCanvas.debug("SkD", 0);
				}
				goto IL_0d9c;
			}
			num = 1;
			GameCanvas.debug("Sk1", 0);
			if (myskill.template.type != 2)
			{
				if (myskill.template.id == 42 && !myskill.isCooldown())
				{
					isBlinking = true;
					timeStartBlink = mSystem.getCurrentTimeMillis();
				}
				GameCanvas.debug("Sk2", 0);
				if (skillPaint != null && (mobFocus != null || (charFocus != null && isMeCanAttackOtherPlayer(charFocus))))
				{
					int dx;
					int num2;
					if (isUseLongRangeWeapon())
					{
						dx = myskill.dx;
						num2 = myskill.dy;
					}
					else
					{
						dx = myskill.dx;
						num2 = myskill.dy;
					}
					GameCanvas.debug("Sk3", 0);
					MyVector myVector2 = new MyVector();
					MyVector myVector3 = new MyVector();
					if (charFocus != null)
					{
						GameCanvas.debug("Sk5", 0);
						myVector3.addElement(charFocus);
						for (int n = 0; n < GameScr.vCharInMap.size(); n++)
						{
							if (myVector2.size() + myVector3.size() >= myskill.maxFight)
							{
								break;
							}
							Char @char = (Char)GameScr.vCharInMap.elementAt(n);
							if (@char.statusMe != 14 && @char.statusMe != 5 && @char.statusMe != 15 && !@char.isInvisible && !@char.Equals(charFocus) && isMeCanAttackOtherPlayer(@char) && charFocus.cx - dx <= @char.cx && @char.cx <= charFocus.cx + dx && charFocus.cy - num2 <= @char.cy && @char.cy <= charFocus.cy + num2 && ((cdir == -1 && @char.cx <= cx) || (cdir == 1 && @char.cx >= cx)))
							{
								myVector3.addElement(@char);
							}
						}
						for (int num3 = 0; num3 < GameScr.vMob.size(); num3++)
						{
							if (myVector2.size() + myVector3.size() >= myskill.maxFight)
							{
								break;
							}
							Mob mob = (Mob)GameScr.vMob.elementAt(num3);
							if (mob.status != 1 && mob.status != 0 && charFocus.cx - dx <= mob.x && mob.x <= charFocus.cx + dx && charFocus.cy - num2 <= mob.y && mob.y <= charFocus.cy + num2 && ((cdir == -1 && mob.x <= cx) || (cdir == 1 && mob.x >= cx)))
							{
								myVector2.addElement(mob);
							}
						}
					}
					else if (mobFocus != null && mobFocus.status != 1 && mobFocus.status != 0)
					{
						GameCanvas.debug("Sk6", 0);
						myVector2.addElement(mobFocus);
						for (int num4 = 0; num4 < GameScr.vMob.size(); num4++)
						{
							if (myVector2.size() + myVector3.size() >= myskill.maxFight)
							{
								break;
							}
							Mob mob2 = (Mob)GameScr.vMob.elementAt(num4);
							if (mob2.status != 1 && mob2.status != 0 && !mob2.Equals(mobFocus) && mobFocus.x - 100 <= mob2.x && mob2.x <= mobFocus.x + 100 && mobFocus.y - 50 <= mob2.y && mob2.y <= mobFocus.y + 50)
							{
								myVector2.addElement(mob2);
							}
						}
						for (int num5 = 0; num5 < GameScr.vCharInMap.size(); num5++)
						{
							if (myVector2.size() + myVector3.size() >= myskill.maxFight)
							{
								break;
							}
							Char char2 = (Char)GameScr.vCharInMap.elementAt(num5);
							if (char2.statusMe != 14 && char2.statusMe != 5 && char2.statusMe != 15 && !char2.isInvisible && ((cTypePk == PK_PHE1 && char2.cTypePk == PK_PHE2) || (cTypePk == PK_PHE2 && char2.cTypePk == PK_PHE1) || char2.cTypePk == 3 || cTypePk == 3 || (char2.cTypePk == PK_NHOM && cTypePk == PK_NHOM) || (testCharId >= 0 && testCharId == char2.charID) || (killCharId >= 0 && killCharId == char2.charID)) && mobFocus.x - dx <= char2.cx && char2.cx <= mobFocus.x + dx && mobFocus.y - num2 <= char2.cy && char2.cy <= mobFocus.y + num2 && ((cdir == -1 && char2.cx <= cx) || (cdir == 1 && char2.cx >= cx)))
							{
								myVector3.addElement(char2);
							}
						}
					}
					GameCanvas.debug("Sk7", 0);
					effPaints = new EffectPaint[myVector2.size() + myVector3.size()];
					for (int num6 = 0; num6 < myVector2.size(); num6++)
					{
						effPaints[num6] = new EffectPaint();
						effPaints[num6].effCharPaint = GameScr.efs[skillPaint.effId - 1];
						effPaints[num6].eMob = (Mob)myVector2.elementAt(num6);
					}
					for (int num7 = 0; num7 < myVector3.size(); num7++)
					{
						effPaints[num7 + myVector2.size()] = new EffectPaint();
						effPaints[num7 + myVector2.size()].effCharPaint = GameScr.efs[skillPaint.effId - 1];
						effPaints[num7 + myVector2.size()].eChar = (Char)myVector3.elementAt(num7);
					}
					GameCanvas.debug("Sk8", 0);
					if (effPaints.Length > 1)
					{
						EPosition firstPos2 = new EPosition();
						if (effPaints[0].eMob != null)
						{
							firstPos2 = new EPosition(effPaints[0].eMob.x, effPaints[0].eMob.y);
						}
						else if (effPaints[0].eChar != null)
						{
							firstPos2 = new EPosition(effPaints[0].eChar.cx, effPaints[0].eChar.cy);
						}
						MyVector myVector4 = new MyVector();
						for (int num8 = 1; num8 < effPaints.Length; num8++)
						{
							if (effPaints[num8].eMob != null)
							{
								myVector4.addElement(new EPosition(effPaints[num8].eMob.x, effPaints[num8].eMob.y));
							}
							else if (effPaints[num8].eChar != null)
							{
								myVector4.addElement(new EPosition(effPaints[num8].eChar.cx, effPaints[num8].eChar.cy));
							}
							if (num8 > 5)
							{
								break;
							}
						}
						Lightning.addLight(myVector4, firstPos2, isContinue: true, getClassColor());
					}
					GameCanvas.debug("Sk9", 0);
					int type = 0;
					if (mobFocus != null)
					{
						type = 1;
					}
					else if (charFocus != null)
					{
						type = 2;
					}
					if (me)
					{
						Service.gI().sendPlayerAttack(myVector2, myVector3, type);
					}
					GameCanvas.debug("SkA", 0);
				}
				goto IL_0d9c;
			}
			goto end_IL_0002;
			IL_0d9c:
			GameCanvas.debug("SkE", 0);
			end_IL_0002:;
		}
		catch (Exception)
		{
		}
	}

	public bool isHaveWolf()
	{
		if (arrItemMounts != null && arrItemMounts[4] != null && arrItemMounts[4].template != null && (arrItemMounts[4].template.id == 443 || arrItemMounts[4].template.id == 523))
		{
			return true;
		}
		return false;
	}

	public bool isHaveMoto()
	{
		if (arrItemMounts != null && arrItemMounts[4] != null && arrItemMounts[4].template != null && (arrItemMounts[4].template.id == 485 || arrItemMounts[4].template.id == 524))
		{
			return true;
		}
		return false;
	}

	public bool isPaint()
	{
		if (cx < GameScr.cmx)
		{
			return false;
		}
		if (cx > GameScr.cmx + GameScr.gW)
		{
			return false;
		}
		if (cy < GameScr.cmy)
		{
			return false;
		}
		if (cy > GameScr.cmy + GameScr.gH + 30)
		{
			return false;
		}
		return true;
	}

	public virtual void paint(mGraphics g)
	{
		if (!isPaint())
		{
			if (skillPaint != null)
			{
				indexSkill = skillInfoPaint1().Length;
				skillPaint = null;
				effPaints = null;
				eff = null;
				effTask = null;
				indexEff = -1;
				indexEffTask = -1;
			}
			return;
		}
		paintBottomDataEff(g, cx, cy, getStartPointPaintFly());
		if (statusMe == 15 || (moveFast != null && moveFast[0] > 0))
		{
			return;
		}
		if (statusMe == 1 || statusMe == 6)
		{
			paint_No(g);
		}
		paintCharName_HP_MP_Overhead(g);
		if (skillPaint != null && indexSkill < skillInfoPaint1().Length)
		{
			paintCharWithSkill(g);
		}
		else
		{
			paintCharWithoutSkill(g);
		}
		paintArrowAttack(g);
		if (effPaints != null)
		{
			for (int i = 0; i < effPaints.Length; i++)
			{
				if (effPaints[i] == null)
				{
					continue;
				}
				if (effPaints[i].eMob != null)
				{
					if (!effPaints[i].isFly)
					{
						effPaints[i].eMob.setInjure();
						effPaints[i].eMob.injureBy = this;
						if (me)
						{
							effPaints[i].eMob.hpInjure = getMyChar().cdame / 2 - getMyChar().cdame * NinjaUtil.randomNumber(11) / 100;
						}
						if (effPaints[i].eMob.templateId != 98 && effPaints[i].eMob.templateId != 99)
						{
							GameScr.startSplash(effPaints[i].eMob.x, effPaints[i].eMob.y - (effPaints[i].eMob.h >> 1), cdir);
						}
						effPaints[i].isFly = true;
					}
					SmallImage.drawSmallImage(g, effPaints[i].getImgId(), effPaints[i].eMob.x, effPaints[i].eMob.y, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
				}
				else if (effPaints[i].eChar != null)
				{
					if (!effPaints[i].isFly)
					{
						if (effPaints[i].eChar.charID >= 0)
						{
							effPaints[i].eChar.doInjure();
						}
						GameScr.startSplash(effPaints[i].eChar.cx, effPaints[i].eChar.cy - (effPaints[i].eChar.ch >> 1), cdir);
						effPaints[i].isFly = true;
					}
					SmallImage.drawSmallImage(g, effPaints[i].getImgId(), effPaints[i].eChar.cx, effPaints[i].eChar.cy, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
				}
				effPaints[i].index++;
				if (effPaints[i].index >= effPaints[i].effCharPaint.arrEfInfo.Length)
				{
					effPaints[i] = null;
				}
			}
		}
		if (indexEff >= 0 && eff != null)
		{
			SmallImage.drawSmallImage(g, eff.arrEfInfo[indexEff].idImg, cx + eff.arrEfInfo[indexEff].dx, cy + eff.arrEfInfo[indexEff].dy, 0, mGraphics.VCENTER | mGraphics.HCENTER);
			if (Main.isPC)
			{
				if (GameCanvas.gameTick % 2 == 0)
				{
					indexEff++;
					if (indexEff >= eff.arrEfInfo.Length)
					{
						indexEff = -1;
						eff = null;
					}
				}
			}
			else
			{
				indexEff++;
				if (indexEff >= eff.arrEfInfo.Length)
				{
					indexEff = -1;
					eff = null;
				}
			}
		}
		if (indexEffTask >= 0 && effTask != null)
		{
			SmallImage.drawSmallImage(g, effTask.arrEfInfo[indexEffTask].idImg, cx + effTask.arrEfInfo[indexEffTask].dx, cy + effTask.arrEfInfo[indexEffTask].dy, 0, mGraphics.VCENTER | mGraphics.HCENTER);
			if (GameCanvas.gameTick % 2 == 0)
			{
				indexEffTask++;
				if (indexEffTask >= effTask.arrEfInfo.Length)
				{
					indexEffTask = -1;
					effTask = null;
				}
			}
		}
		if (isEffBatTu)
		{
			if (count < 2)
			{
				SmallImage.drawSmallImage(g, 1366, cx, cy - chh, 0, mGraphics.VCENTER | mGraphics.HCENTER);
			}
			else if (count < 4)
			{
				SmallImage.drawSmallImage(g, 1367, cx, cy - chh, 0, mGraphics.VCENTER | mGraphics.HCENTER);
			}
			else if (count < 8)
			{
				SmallImage.drawSmallImage(g, 1368, cx, cy - chh, 0, mGraphics.VCENTER | mGraphics.HCENTER);
			}
			else if (GameCanvas.gameTick % 2 == 0)
			{
				SmallImage.drawSmallImage(g, 1369, cx, cy - chh, 0, mGraphics.VCENTER | mGraphics.HCENTER);
			}
			else
			{
				SmallImage.drawSmallImage(g, 1370, cx, cy - chh, 0, mGraphics.VCENTER | mGraphics.HCENTER);
			}
		}
		if (mobMe != null)
		{
			mobMe.paint(g);
		}
		if (statusMe != 1 && statusMe != 6)
		{
			for (int j = 0; j < vDomsang.size(); j++)
			{
				Domsang domsang = (Domsang)vDomsang.elementAt(j);
				domsang.paint(g);
			}
		}
		paintTopDataEff(g, cx, cy, getStartPointPaintFly());
	}

	private void paintArrowAttack(mGraphics g)
	{
		if (arr != null)
		{
			arr.paint(g);
		}
	}

	public void paintHp(mGraphics g, int px, int py)
	{
		int num = cHP * 26 / cMaxHP;
		if (statusMe != 5 && statusMe != 14 && num < 2)
		{
			num = 2;
		}
		else if (statusMe == 5 || statusMe == 14)
		{
			num = 0;
		}
		if (num > 26)
		{
			num = 0;
		}
		g.setColor(16777215);
		g.fillRect(px, py, 26, 4);
		g.setColor(getClassColor());
		g.fillRect(px, py, num, 4);
		g.setColor(0);
		g.drawRect(px, py, 26, 4);
	}

	public void startCoatEffect(int x, int y)
	{
		if (isWolf && arrItemMounts[4].sys >= 4 && getSys() > 0 && GameCanvas.gameTick % 8 == 0)
		{
			if (getSys() == 1)
			{
				ServerEffect.addServerEffect(116, x, y, 2);
			}
			else if (getSys() == 2)
			{
				ServerEffect.addServerEffect(117, x, y, 2);
			}
			else if (getSys() == 3)
			{
				ServerEffect.addServerEffect(118, x, y, 2);
			}
		}
	}

	public int[] getClassCoat()
	{
		int[] result = null;
		int num = -1;
		if (me)
		{
			if (arrItemBody[12] != null)
			{
				num = arrItemBody[12].template.id;
			}
		}
		else
		{
			num = coat;
		}
		switch (num)
		{
		case -1:
			return null;
		case 420:
			result = new int[4]
			{
				1635,
				1636,
				1637,
				1636
			};
			break;
		case 421:
			result = new int[4]
			{
				1652,
				1653,
				1654,
				1653
			};
			break;
		case 422:
			result = new int[4]
			{
				1655,
				1656,
				1657,
				1656
			};
			break;
		}
		return result;
	}

	public int getClassColor()
	{
		int result = 9145227;
		if (nClass.classId == 1 || nClass.classId == 2)
		{
			result = 16711680;
		}
		else if (nClass.classId == 3 || nClass.classId == 4)
		{
			result = 33023;
		}
		else if (nClass.classId == 5 || nClass.classId == 6)
		{
			result = 7443811;
		}
		return result;
	}

	public void paintNameInSameParty(mGraphics g)
	{
		if (isPaint())
		{
			if (getMyChar().charFocus == null || !getMyChar().charFocus.Equals(this))
			{
				mFont.tahoma_7_yellow.drawString(g, cName, cx, cy - (ch + 5 + mFont.tahoma_7.getHeight()), mFont.CENTER);
			}
			else if (getMyChar().charFocus != null && getMyChar().charFocus.Equals(this))
			{
				mFont.tahoma_7_yellow.drawString(g, cName, cx, cy - ch - mFont.tahoma_7_green.getHeight() - 10, mFont.CENTER, mFont.tahoma_7_grey);
			}
		}
	}

	public void paintCharName_HP_MP_Overhead(mGraphics g)
	{
		int num = ch + 5;
		num += ((isWolf || isMoto) ? 15 : 0);
		if (isInvisible && !me)
		{
			return;
		}
		bool flag = false;
		if (me)
		{
			if (GameScr.auto == 1)
			{
				if (!GameScr.gI().lockAutoMove)
				{
					num += mFont.tahoma_7.getHeight();
					mFont.tahoma_7_yellow.drawString(g, mResources.AUTO_FIRE, cx, cy - num, mFont.CENTER, mFont.tahoma_7_grey);
					num++;
				}
				else
				{
					num += mFont.tahoma_7.getHeight();
					mFont.tahoma_7_yellow.drawString(g, mResources.UNMOVE, cx, cy - num, mFont.CENTER, mFont.tahoma_7_grey);
					num++;
				}
			}
			else if (npcFocus == null && charFocus == null && mobFocus == null && itemFocus == null)
			{
				flag = true;
				num += mFont.tahoma_7.getHeight();
				if (!isHumanz())
				{
					mFont.tahoma_7_blue1.drawString(g, cName, cx, cy - num, mFont.CENTER, mFont.tahoma_7_grey);
				}
				else
				{
					mFont.tahoma_7_white.drawString(g, cName, cx, cy - num, mFont.CENTER, mFont.tahoma_7_grey);
				}
				num++;
			}
		}
		else if (getMyChar().charFocus != null && getMyChar().charFocus.Equals(this))
		{
			flag = true;
			num += 5;
			paintHp(g, cx - 13, cy - num);
			num += mFont.tahoma_7.getHeight();
			if (!isHumanz())
			{
				mFont.tahoma_7_blue1.drawString(g, cName, cx, cy - num, mFont.CENTER, mFont.tahoma_7_grey);
			}
			else
			{
				mFont.tahoma_7_white.drawString(g, cName, cx, cy - num, mFont.CENTER, mFont.tahoma_7_grey);
			}
			num++;
		}
		else if (paintName)
		{
			flag = true;
			num += mFont.tahoma_7.getHeight();
			if (!isHumanz())
			{
				mFont.tahoma_7_blue1.drawString(g, cName, cx, cy - num, mFont.CENTER, mFont.tahoma_7_grey);
			}
			else
			{
				mFont.tahoma_7_white.drawString(g, cName, cx, cy - num, mFont.CENTER, mFont.tahoma_7_grey);
			}
			num++;
		}
		if (charID == -getMyChar().charID)
		{
			num += mFont.tahoma_7.getHeight();
			mFont.tahoma_7_yellow.drawString(g, mResources.BY + " " + getMyChar().cName + " " + mResources.PROTECT, cx, cy - num, mFont.CENTER, mFont.tahoma_7_grey);
			num++;
		}
		if (!cClanName.Equals(string.Empty) && flag)
		{
			num += mFont.tahoma_7.getHeight() - 1;
			int num2 = 0;
			if (ctypeClan > 0)
			{
				num2 = 5;
			}
			mFont.tahoma_7_white.drawString(g, cClanName, cx + num2, cy - num, mFont.CENTER, mFont.tahoma_7_blue);
			if (ctypeClan == 3)
			{
				SmallImage.drawSmallImage(g, 1215, cx - (mFont.tahoma_7_white.getWidth(cClanName) / 2 + (7 - num2)), cy - num + 1, 0, mGraphics.HCENTER | mGraphics.TOP);
			}
			else if (ctypeClan == 4)
			{
				SmallImage.drawSmallImage(g, 1216, cx - (mFont.tahoma_7_white.getWidth(cClanName) / 2 + (7 - num2)), cy - num + 1, 0, mGraphics.HCENTER | mGraphics.TOP);
			}
			else if (ctypeClan == 2)
			{
				SmallImage.drawSmallImage(g, 1217, cx - (mFont.tahoma_7_white.getWidth(cClanName) / 2 + (7 - num2)), cy - num + 1, 0, mGraphics.HCENTER | mGraphics.TOP);
			}
			num++;
		}
		if (resultTest > 0 && resultTest < 30)
		{
			num += SmallImage.smallImg[1117][4];
			SmallImage.drawSmallImage(g, 1117, cx, cy - num, 0, mGraphics.HCENTER | mGraphics.TOP);
			num++;
		}
		else if (resultTest > 30 && resultTest < 60)
		{
			num += SmallImage.smallImg[1117][4];
			SmallImage.drawSmallImage(g, 1126, cx, cy - num, 0, mGraphics.HCENTER | mGraphics.TOP);
			num++;
		}
		else if (resultTest > 60 && resultTest < 90)
		{
			num += SmallImage.smallImg[1117][4];
			SmallImage.drawSmallImage(g, 1118, cx, cy - num, 0, mGraphics.HCENTER | mGraphics.TOP);
			num++;
		}
		else if (charID >= 0)
		{
			if (killCharId >= 0)
			{
				num += SmallImage.smallImg[1122][4];
				SmallImage.drawSmallImage(g, 1122, cx, cy - num, 0, mGraphics.HCENTER | mGraphics.TOP);
				num++;
			}
			else if (cTypePk == 3)
			{
				num += SmallImage.smallImg[1121][4];
				SmallImage.drawSmallImage(g, 1121, cx, cy - num, 0, mGraphics.HCENTER | mGraphics.TOP);
				num++;
			}
			else if (cTypePk == 2)
			{
				num += SmallImage.smallImg[1124][4];
				SmallImage.drawSmallImage(g, 1124, cx, cy - num, 0, mGraphics.HCENTER | mGraphics.TOP);
				num++;
			}
			else if (cTypePk == PK_NHOM)
			{
				num += SmallImage.smallImg[1123][4];
				SmallImage.drawSmallImage(g, 1123, cx, cy - num, 0, mGraphics.HCENTER | mGraphics.TOP);
				num++;
			}
			else if (cTypePk == PK_PHE1)
			{
				num += SmallImage.smallImg[1240][4];
				SmallImage.drawSmallImage(g, 1240, cx, cy - num, 0, mGraphics.HCENTER | mGraphics.TOP);
				num++;
			}
			else if (cTypePk == PK_PHE2)
			{
				num += SmallImage.smallImg[1241][4];
				SmallImage.drawSmallImage(g, 1241, cx, cy - num, 0, mGraphics.HCENTER | mGraphics.TOP);
				num++;
			}
			else if (testCharId > 0)
			{
				num += SmallImage.smallImg[1116][4];
				SmallImage.drawSmallImage(g, 1116, cx, cy - num, 0, mGraphics.HCENTER | mGraphics.TOP);
				num++;
			}
		}
	}

	public void loadFromServer()
	{
		for (int i = 0; i < 26; i++)
		{
			int num = getBodyPaintId() + i;
			Image image = (Image)SmallImage.imgNew.get(num + string.Empty);
			if (image == null)
			{
				SmallImage.imgNew.put(num + string.Empty, SmallImage.imgEmpty);
				Service.gI().requestIcon(num);
			}
			if (i == 25)
			{
				break;
			}
		}
	}

	private void paintCharWithoutSkill(mGraphics g)
	{
		try
		{
			int[] array = null;
			Part part = GameScr.parts[head];
			Part part2 = GameScr.parts[leg];
			Part part3 = GameScr.parts[body];
			Part part4 = GameScr.parts[wp];
			if (arrItemBody != null && arrItemBody[11] != null)
			{
				part = GameScr.parts[arrItemBody[11].template.part];
				head = arrItemBody[11].template.part;
			}
			if (part.pi == null || part.pi.Length < 8)
			{
				part = getDefaultHead(cgender);
			}
			else
			{
				for (int i = 0; i < part.pi.Length; i++)
				{
					if (part.pi[i] == null || !SmallImage.isExitsImage(part.pi[i].id))
					{
						part = getDefaultHead(cgender);
						break;
					}
				}
			}
			array = ((part.pi[CharInfo[cf][0][0]].id > 4) ? ((part.pi[CharInfo[cf][0][0]].id > 4) ? getClassCoat() : null) : null);
			if ((((statusMe == 1 || statusMe == 6) && GameCanvas.gameTick % 10 == 0) || ((statusMe == 2 || statusMe == 10) && GameCanvas.gameTick % 2 == 0) || (GameCanvas.gameTick % 3 == 0 && (statusMe == 4 || statusMe == 3))) && array != null)
			{
				tickCoat++;
				if (tickCoat >= array.Length)
				{
					tickCoat = 0;
				}
			}
			if (statusMe == 14)
			{
				if (isHaveMoto())
				{
					if (arrItemMounts[4].template.id == 485)
					{
						if (arrItemMounts[4].sys < 2)
						{
							SmallImage.drawSmallImage(g, 1800, lcx, lcy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
						}
						else
						{
							SmallImage.drawSmallImage(g, 2063, lcx, lcy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
						}
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						if (arrItemMounts[4].sys < 2)
						{
							SmallImage.drawSmallImage(g, 2064, lcx, lcy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
						}
						else
						{
							SmallImage.drawSmallImage(g, 2068, lcx, lcy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
						}
					}
				}
				SmallImage.drawSmallImage(g, 1040, cx, cy, 0, mGraphics.HCENTER | mGraphics.BOTTOM);
			}
			else if (isInvisible)
			{
				if (me)
				{
					if (GameCanvas.gameTick % 50 == 48 || GameCanvas.gameTick % 50 == 90)
					{
						SmallImage.drawSmallImage(g, 1196, cx, cy - 18, 0, mGraphics.VCENTER | mGraphics.HCENTER);
					}
					else
					{
						SmallImage.drawSmallImage(g, 1195, cx, cy - 18, 0, mGraphics.VCENTER | mGraphics.HCENTER);
					}
				}
			}
			else
			{
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				int[] array2 = geteffOngbo();
				if (array2 != null)
				{
					tickEffmoto++;
					if (tickEffmoto >= array2.Length)
					{
						tickEffmoto = 0;
					}
				}
				if (isMoto)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						if (arrItemMounts[4].sys < 2)
						{
							if (statusMe == 1 || statusMe == 6)
							{
								num = ((GameCanvas.gameTick % 20 > 12) ? 1 : 0);
							}
							else if (statusMe == 2 || statusMe == 10)
							{
								num = ((GameCanvas.gameTick % 6 > 3) ? 1 : 0);
							}
							if (statusMe == 3)
							{
								num3 = -5 * cdir;
							}
							if (cdir == 1)
							{
								if (statusMe == 3)
								{
									SmallImage.drawSmallImage(g, 1711, cx, cy + 2, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
								else
								{
									SmallImage.drawSmallImage(g, (num != 0) ? 1710 : 1709, cx, cy, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
								SmallImage.drawSmallImage(g, getHeadId(), cx + num3 + dxHead * cdir, cy - CharInfo[0][0][2] + part.pi[CharInfo[0][0][0]].dy - 12 + num + dyHead, 0, mGraphics.TOP | mGraphics.HCENTER);
								SmallImage.drawSmallImage(g, getBodyPaintId(), cx + dxBody * cdir, cy - SmallImage.getHeight(getLegId()) - 8 + num + dyBody, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
							else
							{
								if (statusMe == 3)
								{
									SmallImage.drawSmallImage(g, 1711, cx, cy + 2, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
								else
								{
									SmallImage.drawSmallImage(g, (num != 0) ? 1710 : 1709, cx, cy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
								SmallImage.drawSmallImage(g, getHeadId(), cx + num3 + dxHead * cdir, cy - CharInfo[0][0][2] + part.pi[CharInfo[0][0][0]].dy - 12 + num + dyHead, 2, mGraphics.TOP | mGraphics.HCENTER);
								SmallImage.drawSmallImage(g, getBodyPaintId(), cx + dxBody * cdir, cy - SmallImage.getHeight(getLegId()) - 8 + num + dyBody, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
						}
						else
						{
							if (statusMe == 1 || statusMe == 6)
							{
								num = ((GameCanvas.gameTick % 20 > 12) ? 1 : 0);
							}
							else if (statusMe == 2 || statusMe == 10)
							{
								num = ((GameCanvas.gameTick % 6 > 3) ? 1 : 0);
							}
							if (statusMe == 3)
							{
								num3 = -5 * cdir;
							}
							if (cdir == 1)
							{
								if (statusMe == 3)
								{
									SmallImage.drawSmallImage(g, 2057, cx, cy + 2, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
								else if (!isBocdau)
								{
									SmallImage.drawSmallImage(g, (num != 0) ? 2055 : 2056, cx, cy, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
								else
								{
									SmallImage.drawSmallImage(g, 2057, cx, cy, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
								if (statusMe == 2 && array2 != null)
								{
									SmallImage.drawSmallImage(g, array2[tickEffmoto], cx - 25, cy - 2, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
								if (!isBocdau)
								{
									SmallImage.drawSmallImage(g, getHeadId(), cx + num3 + dxHead * cdir, cy - CharInfo[0][0][2] + part.pi[CharInfo[0][0][0]].dy - 12 + num + dyHead, 0, mGraphics.TOP | mGraphics.HCENTER);
									SmallImage.drawSmallImage(g, getBodyPaintId(), cx + dxBody * cdir, cy - SmallImage.getHeight(getLegId()) - 8 + num + dxBody * cdir, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
								else
								{
									SmallImage.drawSmallImage(g, getHeadId(), cx + num3 + dxHead * cdir - 3, cy - 1 - CharInfo[0][0][2] + part.pi[CharInfo[0][0][0]].dy - 12 + num + dyHead, 0, mGraphics.TOP | mGraphics.HCENTER);
									SmallImage.drawSmallImage(g, getBodyPaintId(), cx - 3 + dxBody * cdir, cy - 1 - SmallImage.getHeight(getLegId()) - 8 + num + dyBody, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
							}
							else
							{
								if (statusMe == 3)
								{
									SmallImage.drawSmallImage(g, 2057, cx, cy + 2, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
								else if (!isBocdau)
								{
									SmallImage.drawSmallImage(g, (num != 0) ? 2055 : 2056, cx, cy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
								else
								{
									SmallImage.drawSmallImage(g, 2057, cx, cy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
								if (statusMe == 2 && array2 != null)
								{
									SmallImage.drawSmallImage(g, array2[tickEffmoto], cx + 25, cy - 2, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
								SmallImage.drawSmallImage(g, getHeadId(), cx + num3 + dxHead * cdir, cy - CharInfo[0][0][2] + part.pi[CharInfo[0][0][0]].dy - 12 + num + dyHead, 2, mGraphics.TOP | mGraphics.HCENTER);
								SmallImage.drawSmallImage(g, getBodyPaintId(), cx + dxBody * cdir, cy - SmallImage.getHeight(getLegId()) - 8 + num + dyBody, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
						}
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						if (arrItemMounts[4].sys < 2)
						{
							if (statusMe == 1 || statusMe == 6)
							{
								num = ((GameCanvas.gameTick % 20 > 12) ? 1 : 0);
							}
							else if (statusMe == 2 || statusMe == 10)
							{
								num = ((GameCanvas.gameTick % 6 > 3) ? 1 : 0);
							}
							if (statusMe == 3)
							{
								num3 = -5 * cdir;
							}
							if (cdir == 1)
							{
								if (statusMe == 3)
								{
									SmallImage.drawSmallImage(g, 2066, cx, cy + 2, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
								else
								{
									SmallImage.drawSmallImage(g, (num != 0) ? 2065 : 2064, cx, cy, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
								SmallImage.drawSmallImage(g, getHeadId(), cx + num3 + dxHead * cdir, cy - CharInfo[0][0][2] + part.pi[CharInfo[0][0][0]].dy - 12 + num + dyHead, 0, mGraphics.TOP | mGraphics.HCENTER);
								SmallImage.drawSmallImage(g, getBodyPaintId(), cx + dxBody * cdir, cy - SmallImage.getHeight(getLegId()) - 8 + num + dyBody, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
							else
							{
								if (statusMe == 3)
								{
									SmallImage.drawSmallImage(g, 2066, cx, cy + 2, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
								else
								{
									SmallImage.drawSmallImage(g, (num != 0) ? 2065 : 2064, cx, cy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
								SmallImage.drawSmallImage(g, getHeadId(), cx + num3 + dxHead * cdir, cy - CharInfo[0][0][2] + part.pi[CharInfo[0][0][0]].dy - 12 + num + dyHead, 2, mGraphics.TOP | mGraphics.HCENTER);
								SmallImage.drawSmallImage(g, getBodyPaintId(), cx + dxBody * cdir, cy - SmallImage.getHeight(getLegId()) - 8 + num + dyBody, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
						}
						else if (arrItemMounts[4].sys >= 2 && arrItemMounts[4].sys < 4)
						{
							int[] effmoto = getEffmoto();
							if (effmoto != null)
							{
								tickEffmoto++;
								if (tickEffmoto >= effmoto.Length)
								{
									tickEffmoto = 0;
								}
							}
							if (statusMe == 1 || statusMe == 6)
							{
								num = ((GameCanvas.gameTick % 20 > 12) ? 1 : 0);
							}
							else if (statusMe == 2 || statusMe == 10)
							{
								num = ((GameCanvas.gameTick % 6 > 3) ? 1 : 0);
							}
							if (statusMe == 3)
							{
								num3 = -5 * cdir;
							}
							if (cdir == 1)
							{
								if (statusMe == 3)
								{
									SmallImage.drawSmallImage(g, 2070, cx, cy + 2, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
								else if (statusMe == 4)
								{
									SmallImage.drawSmallImage(g, (num != 0) ? 2069 : 2068, cx, cy, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
								else if (statusMe == 2 || statusMe == 10)
								{
									SmallImage.drawSmallImage(g, (num != 0) ? 2069 : 2068, cx, cy, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
								else if (statusMe == 1 || statusMe == 6)
								{
									SmallImage.drawSmallImage(g, (num != 0) ? 2069 : 2068, cx, cy, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
								SmallImage.drawSmallImage(g, getHeadId(), cx + num3 + dxHead * cdir, cy - CharInfo[0][0][2] + part.pi[CharInfo[0][0][0]].dy - 12 + num + dyHead, 0, mGraphics.TOP | mGraphics.HCENTER);
								SmallImage.drawSmallImage(g, getBodyPaintId(), cx + dxBody * cdir, cy - SmallImage.getHeight(getLegId()) - 8 + num + dyBody, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
							else
							{
								if (statusMe == 3)
								{
									SmallImage.drawSmallImage(g, 2070, cx, cy + 2, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
								if (statusMe == 4)
								{
									SmallImage.drawSmallImage(g, (num != 0) ? 2069 : 2068, cx, cy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
								else if (statusMe == 2 || statusMe == 10)
								{
									SmallImage.drawSmallImage(g, (num != 0) ? 2069 : 2068, cx, cy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
								else if (statusMe == 1 || statusMe == 6)
								{
									SmallImage.drawSmallImage(g, (num != 0) ? 2069 : 2068, cx, cy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
								SmallImage.drawSmallImage(g, getHeadId(), cx + num3 + dxHead * cdir, cy - CharInfo[0][0][2] + part.pi[CharInfo[0][0][0]].dy - 12 + num + dyHead, 2, mGraphics.TOP | mGraphics.HCENTER);
								SmallImage.drawSmallImage(g, getBodyPaintId(), cx + dxBody * cdir, cy - SmallImage.getHeight(getLegId()) - 8 + num + dyBody, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
						}
						else
						{
							int[] effmoto2 = getEffmoto();
							if (effmoto2 != null)
							{
								tickEffmoto++;
								if (tickEffmoto >= effmoto2.Length)
								{
									tickEffmoto = 0;
								}
							}
							if (statusMe == 1 || statusMe == 6)
							{
								num = ((GameCanvas.gameTick % 20 > 12) ? 1 : 0);
							}
							else if (statusMe == 2 || statusMe == 10)
							{
								num = ((GameCanvas.gameTick % 6 > 3) ? 1 : 0);
							}
							if (statusMe == 3)
							{
								num3 = -5 * cdir;
							}
							if (cdir == 1)
							{
								if (statusMe == 3)
								{
									SmallImage.drawSmallImage(g, 2070, cx, cy + 2, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
									SmallImage.drawSmallImage(g, effmoto2[tickEffmoto], cx + 13, cy - 17, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
									SmallImage.drawSmallImage(g, effmoto2[tickEffmoto], cx - 24, cy + 2, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
								else if (statusMe == 4)
								{
									SmallImage.drawSmallImage(g, (num != 0) ? 2069 : 2068, cx, cy, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
									SmallImage.drawSmallImage(g, effmoto2[tickEffmoto], cx + 15, cy, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
									SmallImage.drawSmallImage(g, effmoto2[tickEffmoto], cx - 27, cy, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
								else if (statusMe == 2 || statusMe == 10)
								{
									SmallImage.drawSmallImage(g, (num != 0) ? 2069 : 2068, cx, cy, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
									SmallImage.drawSmallImage(g, effmoto2[tickEffmoto], cx + 15, cy, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
									SmallImage.drawSmallImage(g, effmoto2[tickEffmoto], cx - 27, cy, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
								else if (statusMe == 1 || statusMe == 6)
								{
									SmallImage.drawSmallImage(g, (num != 0) ? 2069 : 2068, cx, cy, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
									SmallImage.drawSmallImage(g, effmoto2[tickEffmoto], cx + 15, cy, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
									SmallImage.drawSmallImage(g, effmoto2[tickEffmoto], cx - 27, cy, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
								SmallImage.drawSmallImage(g, getHeadId(), cx + num3 + dxHead * cdir, cy - CharInfo[0][0][2] + part.pi[CharInfo[0][0][0]].dy - 12 + num + dyHead, 0, mGraphics.TOP | mGraphics.HCENTER);
								SmallImage.drawSmallImage(g, getBodyPaintId(), cx + dxBody * cdir, cy - SmallImage.getHeight(getLegId()) - 8 + num + dyBody, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
							else
							{
								if (statusMe == 3)
								{
									SmallImage.drawSmallImage(g, 2070, cx, cy + 2, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
									SmallImage.drawSmallImage(g, effmoto2[tickEffmoto], cx - 12, cy - 17, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
									SmallImage.drawSmallImage(g, effmoto2[tickEffmoto], cx + 25, cy + 3, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
								if (statusMe == 4)
								{
									SmallImage.drawSmallImage(g, (num != 0) ? 2069 : 2068, cx, cy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
									SmallImage.drawSmallImage(g, effmoto2[tickEffmoto], cx - 15, cy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
									SmallImage.drawSmallImage(g, effmoto2[tickEffmoto], cx + 27, cy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
								else if (statusMe == 2 || statusMe == 10)
								{
									SmallImage.drawSmallImage(g, (num != 0) ? 2069 : 2068, cx, cy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
									SmallImage.drawSmallImage(g, effmoto2[tickEffmoto], cx - 15, cy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
									SmallImage.drawSmallImage(g, effmoto2[tickEffmoto], cx + 27, cy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
								else if (statusMe == 1 || statusMe == 6)
								{
									SmallImage.drawSmallImage(g, (num != 0) ? 2069 : 2068, cx, cy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
									SmallImage.drawSmallImage(g, effmoto2[tickEffmoto], cx - 15, cy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
									SmallImage.drawSmallImage(g, effmoto2[tickEffmoto], cx + 27, cy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
								}
								SmallImage.drawSmallImage(g, getHeadId(), cx + num3 + dxHead * cdir, cy - CharInfo[0][0][2] + part.pi[CharInfo[0][0][0]].dy - 12 + num + dyHead, 2, mGraphics.TOP | mGraphics.HCENTER);
								SmallImage.drawSmallImage(g, getBodyPaintId(), cx + dxBody * cdir, cy - SmallImage.getHeight(getLegId()) - 8 + num + dyBody, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
						}
					}
				}
				else if (isWolf)
				{
					int[] effwolf = getEffwolf();
					if (effwolf != null)
					{
						tickEffFireW++;
						if (tickEffFireW >= effwolf.Length)
						{
							tickEffFireW = 0;
						}
					}
					if (statusMe == 1 || statusMe == 6)
					{
						tickWolf = ((GameCanvas.gameTick % 20 > 12) ? 1 : 0);
						num2 = -tickWolf;
					}
					else if (statusMe == 2 || statusMe == 10)
					{
						if (GameCanvas.gameTick % 12 <= 3)
						{
							tickWolf = 0;
						}
						else if (GameCanvas.gameTick % 12 <= 6)
						{
							tickWolf = 1;
							num2 = 2;
						}
						else if (GameCanvas.gameTick % 12 <= 9)
						{
							tickWolf = 2;
							num2 = 4;
						}
						else
						{
							tickWolf = 3;
							num2 = 2;
						}
					}
					int[] array3 = new int[4]
					{
						2050,
						2053,
						2049,
						2052
					};
					int[] array4 = new int[4]
					{
						2075,
						2078,
						2074,
						2079
					};
					int[] array5 = new int[4]
					{
						cy - 22,
						cy - 23,
						cy - 22,
						cy - 23
					};
					int[] array6 = new int[4]
					{
						cy - 22,
						cy - 23,
						cy - 22,
						cy - 22
					};
					if (statusMe == 3)
					{
						num3 = -5 * cdir;
						num4 = 5;
					}
					else
					{
						num3 = -3 * cdir;
					}
					if (arrItemMounts[4].template.id == 523)
					{
						if (cdir == 1)
						{
							SmallImage.drawSmallImage(g, part4.pi[CharInfo[cf][3][0]].id, cx + CharInfo[cf][3][1] + part4.pi[CharInfo[cf][3][0]].dx, cy - CharInfo[cf][3][2] + part4.pi[CharInfo[cf][3][0]].dy - 10, 0, 0);
							if (statusMe == 3)
							{
								SmallImage.drawSmallImage(g, 2051, cx, cy, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
							else if (statusMe == 4)
							{
								SmallImage.drawSmallImage(g, 2052, cx, cy, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
							else if (statusMe == 1 || statusMe == 6)
							{
								SmallImage.drawSmallImage(g, (tickWolf != 0) ? 2048 : 2047, cx, cy, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
							else if (statusMe == 2 || statusMe == 10)
							{
								SmallImage.drawSmallImage(g, array3[tickWolf], cx, cy - num2, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
							SmallImage.drawSmallImage(g, getHeadId(), cx + num3 + dxHead * cdir, cy - CharInfo[0][0][2] + part.pi[CharInfo[0][0][0]].dy - 12 - num4 - num2 + dyHead, 0, mGraphics.TOP | mGraphics.HCENTER);
							SmallImage.drawSmallImage(g, getBodyPaintId(), cx + num3 + dxBody * cdir, cy - SmallImage.getHeight(getLegId()) - 9 - num4 - num2 + dyBody, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
						}
						else
						{
							SmallImage.drawSmallImage(g, part4.pi[CharInfo[cf][3][0]].id, cx - CharInfo[cf][3][1] - part4.pi[CharInfo[cf][3][0]].dx, cy - CharInfo[cf][3][2] + part4.pi[CharInfo[cf][3][0]].dy - 10, 2, 24);
							if (statusMe == 3)
							{
								SmallImage.drawSmallImage(g, 2051, cx, cy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
							else if (statusMe == 4)
							{
								SmallImage.drawSmallImage(g, 2052, cx, cy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
							else if (statusMe == 1 || statusMe == 6)
							{
								SmallImage.drawSmallImage(g, (tickWolf != 0) ? 2048 : 2047, cx, cy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
							else if (statusMe == 2 || statusMe == 10)
							{
								SmallImage.drawSmallImage(g, array3[tickWolf], cx, cy - num2, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
							SmallImage.drawSmallImage(g, getHeadId(), cx + num3 + dxHead * cdir, cy - CharInfo[0][0][2] + part.pi[CharInfo[0][0][0]].dy - 12 - num4 - num2 + dyHead, 2, mGraphics.TOP | mGraphics.HCENTER);
							SmallImage.drawSmallImage(g, getBodyPaintId(), cx + num3 + dxBody * cdir, cy - SmallImage.getHeight(getLegId()) - 9 - num4 - num2 + dyBody, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
						}
					}
					else if (arrItemMounts[4].template.id == 443)
					{
						if (arrItemMounts[4].sys >= 3)
						{
							if (cdir == 1)
							{
								SmallImage.drawSmallImage(g, part4.pi[CharInfo[cf][3][0]].id, cx + CharInfo[cf][3][1] + part4.pi[CharInfo[cf][3][0]].dx, cy - CharInfo[cf][3][2] + part4.pi[CharInfo[cf][3][0]].dy - 10, 0, 0);
								if (statusMe == 3)
								{
									SmallImage.drawSmallImage(g, 2077, cx, cy, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
									g.drawRegion(GameScr.imgMatcho, 0, tickEffWolf * 3, 3, 3, 0, cx + 21, cy - 30, 0);
								}
								else if (statusMe == 4)
								{
									SmallImage.drawSmallImage(g, 2076, cx, cy, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
									g.drawRegion(GameScr.imgMatcho, 0, tickEffWolf * 3, 3, 3, 0, cx + 21, cy - 19, 0);
								}
								else if (statusMe == 1 || statusMe == 6)
								{
									SmallImage.drawSmallImage(g, (tickWolf != 0) ? 2073 : 2072, cx, cy, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
									g.drawRegion(GameScr.imgMatcho, 0, tickEffWolf * 3, 3, 3, 0, cx + 21, cy - 19, 0);
								}
								else if (statusMe == 2 || statusMe == 10)
								{
									SmallImage.drawSmallImage(g, array4[tickWolf], cx, cy - num2, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
									g.drawRegion(GameScr.imgMatcho, 0, tickEffWolf * 3, 3, 3, 0, cx + 21, array5[tickWolf], 0);
								}
								SmallImage.drawSmallImage(g, getHeadId(), cx + num3 + dxHead * cdir, cy - CharInfo[0][0][2] + part.pi[CharInfo[0][0][0]].dy - 12 - num4 - num2 + dyHead, 0, mGraphics.TOP | mGraphics.HCENTER);
								SmallImage.drawSmallImage(g, getBodyPaintId(), cx + num3 + dxBody * cdir, cy - SmallImage.getHeight(getLegId()) - 9 - num4 - num2 + dyBody, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
							else
							{
								SmallImage.drawSmallImage(g, part4.pi[CharInfo[cf][3][0]].id, cx - CharInfo[cf][3][1] - part4.pi[CharInfo[cf][3][0]].dx, cy - CharInfo[cf][3][2] + part4.pi[CharInfo[cf][3][0]].dy - 10, 2, 24);
								if (statusMe == 3)
								{
									SmallImage.drawSmallImage(g, 2077, cx, cy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
									g.drawRegion(GameScr.imgMatcho, 0, tickEffWolf * 3, 3, 3, 0, cx - 23, cy - 30, 0);
								}
								else if (statusMe == 4)
								{
									SmallImage.drawSmallImage(g, 2076, cx, cy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
									g.drawRegion(GameScr.imgMatcho, 0, tickEffWolf * 3, 3, 3, 0, cx - 24, cy - 20, 0);
								}
								else if (statusMe == 1 || statusMe == 6)
								{
									SmallImage.drawSmallImage(g, (tickWolf != 0) ? 2073 : 2072, cx, cy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
									g.drawRegion(GameScr.imgMatcho, 0, tickEffWolf * 3, 3, 3, 0, cx - 24, cy - 20, 0);
								}
								else if (statusMe == 2 || statusMe == 10)
								{
									SmallImage.drawSmallImage(g, array4[tickWolf], cx, cy - num2, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
									g.drawRegion(GameScr.imgMatcho, 0, tickEffWolf * 3, 3, 3, 0, cx - 24, array6[tickWolf], 0);
								}
								SmallImage.drawSmallImage(g, getHeadId(), cx + num3 + dxHead * cdir, cy - CharInfo[0][0][2] + part.pi[CharInfo[0][0][0]].dy - 12 - num4 - num2 + dyHead, 2, mGraphics.TOP | mGraphics.HCENTER);
								SmallImage.drawSmallImage(g, getBodyPaintId(), cx + num3 + dxBody * cdir, cy - SmallImage.getHeight(getLegId()) - 9 - num4 - num2 + dyBody, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
						}
						else if (cdir == 1)
						{
							SmallImage.drawSmallImage(g, part4.pi[CharInfo[cf][3][0]].id, cx + CharInfo[cf][3][1] + part4.pi[CharInfo[cf][3][0]].dx, cy - CharInfo[cf][3][2] + part4.pi[CharInfo[cf][3][0]].dy - 10, 0, 0);
							if (statusMe == 3)
							{
								SmallImage.drawSmallImage(g, 1716, cx, cy, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
							else if (statusMe == 4)
							{
								SmallImage.drawSmallImage(g, 1717, cx, cy, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
							else if (statusMe == 1 || statusMe == 6)
							{
								SmallImage.drawSmallImage(g, (tickWolf != 0) ? 1713 : 1712, cx, cy, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
							else if (statusMe == 2 || statusMe == 10)
							{
								SmallImage.drawSmallImage(g, idWolfW[tickWolf], cx, cy - num2, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
							SmallImage.drawSmallImage(g, getHeadId(), cx + num3 + dxHead * cdir, cy - CharInfo[0][0][2] + part.pi[CharInfo[0][0][0]].dy - 12 - num4 - num2 + dyHead, 0, mGraphics.TOP | mGraphics.HCENTER);
							SmallImage.drawSmallImage(g, getBodyPaintId(), cx + num3 + dxBody * cdir, cy - SmallImage.getHeight(getLegId()) - 9 - num4 - num2 + dyBody, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
						}
						else
						{
							SmallImage.drawSmallImage(g, part4.pi[CharInfo[cf][3][0]].id, cx - CharInfo[cf][3][1] - part4.pi[CharInfo[cf][3][0]].dx, cy - CharInfo[cf][3][2] + part4.pi[CharInfo[cf][3][0]].dy - 10, 2, 24);
							if (statusMe == 3)
							{
								SmallImage.drawSmallImage(g, 1716, cx, cy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
							else if (statusMe == 4)
							{
								SmallImage.drawSmallImage(g, 1717, cx, cy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
							else if (statusMe == 1 || statusMe == 6)
							{
								SmallImage.drawSmallImage(g, (tickWolf != 0) ? 1713 : 1712, cx, cy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
							else if (statusMe == 2 || statusMe == 10)
							{
								SmallImage.drawSmallImage(g, idWolfW[tickWolf], cx, cy - num2, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
							SmallImage.drawSmallImage(g, getHeadId(), cx + num3 + dxHead * cdir, cy - CharInfo[0][0][2] + part.pi[CharInfo[0][0][0]].dy - 12 - num4 - num2 + dyHead, 2, mGraphics.TOP | mGraphics.HCENTER);
							SmallImage.drawSmallImage(g, getBodyPaintId(), cx + num3 + dxBody * cdir, cy - SmallImage.getHeight(getLegId()) - 9 - num4 - num2 + dyBody, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
						}
					}
				}
				else if (cdir == 1)
				{
					if (isMotoBehind && !isMoto && !isWolf)
					{
						if (arrItemMounts[4].template.id == 485)
						{
							if (arrItemMounts[4].sys <= 1)
							{
								SmallImage.drawSmallImage(g, 1800, lcx, lcy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
							else
							{
								SmallImage.drawSmallImage(g, 2063, lcx, lcy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
						}
						else if (arrItemMounts[4].template.id == 524)
						{
							if (arrItemMounts[4].sys <= 1)
							{
								SmallImage.drawSmallImage(g, 2067, lcx, lcy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
							else
							{
								SmallImage.drawSmallImage(g, 2071, lcx, lcy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
						}
					}
					if (array != null)
					{
						if (tickCoat == 0)
						{
							SmallImage.drawSmallImage(g, array[tickCoat], cx - 14, cy - 18, 0, mGraphics.TOP | mGraphics.LEFT);
						}
						else if (tickCoat == 1)
						{
							SmallImage.drawSmallImage(g, array[tickCoat], cx - 22, cy - 18, 0, mGraphics.TOP | mGraphics.LEFT);
						}
						else if (tickCoat == 2)
						{
							SmallImage.drawSmallImage(g, array[tickCoat], cx - 25, cy - 18, 0, mGraphics.TOP | mGraphics.LEFT);
						}
						else
						{
							SmallImage.drawSmallImage(g, array[tickCoat], cx - 22, cy - 18, 0, mGraphics.TOP | mGraphics.LEFT);
						}
					}
					SmallImage.drawSmallImage(g, part4.pi[CharInfo[cf][3][0]].id, cx + CharInfo[cf][3][1] + part4.pi[CharInfo[cf][3][0]].dx, cy - CharInfo[cf][3][2] + part4.pi[CharInfo[cf][3][0]].dy, 0, 0);
					SmallImage.drawSmallImage(g, part2.pi[CharInfo[cf][1][0]].id, cx + CharInfo[cf][1][1] + part2.pi[CharInfo[cf][1][0]].dx, cy - CharInfo[cf][1][2] + part2.pi[CharInfo[cf][1][0]].dy, 0, 0);
					if (statusMe != 2)
					{
						paintClanEffect(g, cx + 7, cy - 2);
					}
					SmallImage.drawSmallImage(g, part.pi[CharInfo[cf][0][0]].id, cx + CharInfo[cf][0][1] + part.pi[CharInfo[cf][0][0]].dx, cy - CharInfo[cf][0][2] + part.pi[CharInfo[cf][0][0]].dy, 0, 0);
					SmallImage.drawSmallImage(g, part3.pi[CharInfo[cf][2][0]].id, cx + CharInfo[cf][2][1] + part3.pi[CharInfo[cf][2][0]].dx, cy - CharInfo[cf][2][2] + part3.pi[CharInfo[cf][2][0]].dy, 0, 0);
					if (statusMe == 2)
					{
						paintClanEffectRun(g, cx - 14, cy - 2);
						paintClanEffect2(g, cx + 7, cy - 1);
					}
					else
					{
						paintClanEffect(g, cx - 7, cy - 2);
						paintClanEffect2(g, cx + 11, cy - 2);
					}
				}
				else
				{
					if (isMotoBehind && !isMoto && !isWolf)
					{
						if (arrItemMounts[4].template.id == 485)
						{
							if (arrItemMounts[4].sys < 1)
							{
								SmallImage.drawSmallImage(g, 1800, lcx, lcy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
							else
							{
								SmallImage.drawSmallImage(g, 2063, lcx, lcy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
						}
						else if (arrItemMounts[4].template.id == 524)
						{
							if (arrItemMounts[4].sys < 1)
							{
								SmallImage.drawSmallImage(g, 2067, lcx, lcy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
							else
							{
								SmallImage.drawSmallImage(g, 2071, lcx, lcy, 2, mGraphics.BOTTOM | mGraphics.HCENTER);
							}
						}
					}
					if (array != null)
					{
						if (tickCoat == 0)
						{
							SmallImage.drawSmallImage(g, array[tickCoat], cx - 7, cy - 18, 2, mGraphics.TOP | mGraphics.LEFT);
						}
						else if (tickCoat == 1)
						{
							SmallImage.drawSmallImage(g, array[tickCoat], cx - 7, cy - 18, 2, mGraphics.TOP | mGraphics.LEFT);
						}
						else if (tickCoat == 2)
						{
							SmallImage.drawSmallImage(g, array[tickCoat], cx - 7, cy - 18, 2, mGraphics.TOP | mGraphics.LEFT);
						}
						else
						{
							SmallImage.drawSmallImage(g, array[tickCoat], cx - 7, cy - 18, 2, mGraphics.TOP | mGraphics.LEFT);
						}
					}
					SmallImage.drawSmallImage(g, part4.pi[CharInfo[cf][3][0]].id, cx - CharInfo[cf][3][1] - part4.pi[CharInfo[cf][3][0]].dx, cy - CharInfo[cf][3][2] + part4.pi[CharInfo[cf][3][0]].dy, 2, 24);
					SmallImage.drawSmallImage(g, part2.pi[CharInfo[cf][1][0]].id, cx - CharInfo[cf][1][1] - part2.pi[CharInfo[cf][1][0]].dx, cy - CharInfo[cf][1][2] + part2.pi[CharInfo[cf][1][0]].dy, 2, 24);
					if (statusMe != 2)
					{
						paintClanEffect(g, cx - 7, cy - 2);
					}
					SmallImage.drawSmallImage(g, part.pi[CharInfo[cf][0][0]].id, cx - CharInfo[cf][0][1] - part.pi[CharInfo[cf][0][0]].dx, cy - CharInfo[cf][0][2] + part.pi[CharInfo[cf][0][0]].dy, 2, 24);
					SmallImage.drawSmallImage(g, part3.pi[CharInfo[cf][2][0]].id, cx - CharInfo[cf][2][1] - part3.pi[CharInfo[cf][2][0]].dx, cy - CharInfo[cf][2][2] + part3.pi[CharInfo[cf][2][0]].dy, 2, 24);
					if (statusMe == 2)
					{
						paintClanEffectRun(g, cx + 14, cy - 2);
						paintClanEffect2(g, cx - 3, cy - 2);
					}
					else
					{
						paintClanEffect(g, cx + 5, cy - 2);
						paintClanEffect2(g, cx - 7, cy - 2);
					}
				}
			}
			if (isLockAttack)
			{
				SmallImage.drawSmallImage(g, 290, cx, cy, 0, mGraphics.BOTTOM | mGraphics.HCENTER);
			}
		}
		catch (Exception)
		{
		}
	}

	private int getLegId()
	{
		switch (leg)
		{
		case 0:
			return 26;
		case 4:
			return 58;
		case 6:
			return 86;
		case 8:
			return 114;
		case 9:
			return 123;
		case 17:
			return 353;
		case 19:
			return 379;
		case 21:
			return 405;
		case 30:
			return 484;
		case 33:
			return 518;
		case 35:
			return 544;
		case 37:
			return 571;
		case 39:
			return 810;
		case 43:
			return 982;
		case 95:
			return 1156;
		case 142:
			return 1360;
		case 155:
			return 1494;
		case 157:
			return 1519;
		default:
			return 26;
		}
	}

	private int getBodyPaintId()
	{
		dxBody = 0;
		dyBody = 0;
		if (statusMe == 3)
		{
			switch (body)
			{
			case 1:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 3;
					dyBody = -3;
					dxBody = 4;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 3;
					dyBody = -3;
					dxBody = 4;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -1;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -8;
					dyBody = -6;
				}
				return 13;
			case 3:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 4;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 4;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -1;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -8;
					dyBody = -6;
				}
				return 45;
			case 5:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 4;
					dyBody = -3;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 4;
					dyBody = -3;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -1;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -9;
					dyBody = -7;
				}
				return 73;
			case 7:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 4;
					dyBody = -3;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 4;
					dyBody = -3;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -1;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -9;
					dyBody = -7;
				}
				return 101;
			case 10:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 4;
					dyBody = -3;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 4;
					dyBody = -3;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -1;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -9;
					dyBody = -7;
				}
				return 137;
			case 18:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 4;
					dyBody = -3;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 4;
					dyBody = -3;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -1;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -9;
					dyBody = -7;
				}
				return 365;
			case 20:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 4;
					dyBody = -3;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 4;
					dyBody = -3;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -1;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -9;
					dyBody = -7;
				}
				return 391;
			case 22:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 4;
					dyBody = -3;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 4;
					dyBody = -3;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -1;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -9;
					dyBody = -7;
				}
				return 417;
			case 29:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 1;
					dyBody = -3;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 1;
					dyBody = -3;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -3;
					dyBody = -3;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -11;
					dyBody = -6;
				}
				return 472;
			case 32:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 1;
					dyBody = -3;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 1;
					dyBody = -3;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -3;
					dyBody = -3;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -11;
					dyBody = -6;
				}
				return 506;
			case 34:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 3;
					dyBody = -3;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 3;
					dyBody = -3;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -1;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -8;
					dyBody = -7;
				}
				return 531;
			case 36:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 3;
					dyBody = -3;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 3;
					dyBody = -3;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -1;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -8;
					dyBody = -7;
				}
				return 559;
			case 38:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 3;
					dyBody = -3;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 3;
					dyBody = -3;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -1;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -8;
					dyBody = -7;
				}
				return 798;
			case 42:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 3;
					dyBody = -3;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 3;
					dyBody = -3;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -1;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -8;
					dyBody = -7;
				}
				return 970;
			case 94:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 0;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 0;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -4;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -12;
					dyBody = -7;
				}
				return 1142;
			case 141:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 3;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 3;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -1;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -9;
					dyBody = -7;
				}
				return 1348;
			case 154:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = -3;
					dyBody = 0;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = -3;
					dyBody = 0;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -8;
					dyBody = 0;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -15;
					dyBody = -3;
				}
				return 1487;
			case 156:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 1;
					dyBody = -3;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 1;
					dyBody = -3;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -4;
					dyBody = -3;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -10;
					dyBody = -7;
				}
				return 1507;
			case 157:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 4;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 4;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -1;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -8;
					dyBody = -7;
				}
				return 1812;
			case 173:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 4;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 4;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -1;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -8;
					dyBody = -7;
				}
				return 1838;
			case 180:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 4;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 4;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -1;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -8;
					dyBody = -7;
				}
				return 1959;
			case 183:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 4;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 4;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -1;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -8;
					dyBody = -7;
				}
				return 1987;
			case 186:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = -3;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = -3;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -6;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -14;
					dyBody = -5;
				}
				return 2117;
			case 189:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = -3;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = -3;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -6;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -14;
					dyBody = -5;
				}
				return 2144;
			case 206:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = -1;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = -1;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -5;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -10;
					dyBody = -6;
				}
				return 2459;
			case 197:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = -1;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = -1;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -5;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -10;
					dyBody = -6;
				}
				return 2342;
			case 199:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = -1;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = -1;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -5;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -10;
					dyBody = -6;
				}
				return 2373;
			default:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 3;
					dyBody = -3;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 3;
					dyBody = -3;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = 0;
					dyBody = -4;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -7;
					dyBody = -6;
				}
				return 13;
			}
		}
		if (!isBocdau)
		{
			switch (body)
			{
			case 1:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 2;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 2;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = 0;
					dyBody = 0;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -5;
					dyBody = -2;
				}
				return 9;
			case 3:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 0;
					dyBody = -3;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 0;
					dyBody = -3;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = 0;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -5;
					dyBody = -3;
				}
				return 41;
			case 5:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 0;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 0;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -1;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -6;
					dyBody = -2;
				}
				return 70;
			case 7:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 0;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 0;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -1;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -6;
					dyBody = -2;
				}
				return 97;
			case 10:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 0;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 0;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -1;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -6;
					dyBody = -2;
				}
				return 133;
			case 18:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 0;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 0;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -1;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -6;
					dyBody = -2;
				}
				return 369;
			case 20:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 0;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 0;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -1;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -6;
					dyBody = -2;
				}
				return 395;
			case 22:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 0;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 0;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -1;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -6;
					dyBody = -2;
				}
				return 421;
			case 29:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 0;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 0;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = 0;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -6;
					dyBody = -2;
				}
				return 468;
			case 32:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 0;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 0;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = 0;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -6;
					dyBody = -2;
				}
				return 502;
			case 34:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 0;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 0;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = 0;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -5;
					dyBody = -2;
				}
				return 540;
			case 36:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 0;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 0;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = 0;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -5;
					dyBody = -2;
				}
				return 555;
			case 38:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 0;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 0;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = 0;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -5;
					dyBody = -2;
				}
				return 794;
			case 42:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 0;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 0;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = 0;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -5;
					dyBody = -2;
				}
				return 966;
			case 94:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 0;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 0;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = 0;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -5;
					dyBody = -2;
				}
				return 1139;
			case 141:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = -2;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = -2;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -3;
					dyBody = 0;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -7;
					dyBody = -1;
				}
				return 1343;
			case 154:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 0;
					dyBody = 0;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 0;
					dyBody = 0;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = 0;
					dyBody = 1;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -3;
					dyBody = -1;
				}
				return 1479;
			case 156:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 3;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 3;
					dyBody = -2;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = 0;
					dyBody = 2;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -3;
					dyBody = 0;
				}
				return 1502;
			case 157:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 0;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 0;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -1;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -6;
					dyBody = -2;
				}
				return 1808;
			case 173:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 0;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 0;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -1;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -6;
					dyBody = -2;
				}
				return 1834;
			case 180:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 0;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 0;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -1;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -6;
					dyBody = -2;
				}
				return 1955;
			case 183:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 0;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 0;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -1;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -6;
					dyBody = -2;
				}
				return 1983;
			case 186:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 0;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 0;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -2;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -8;
					dyBody = -2;
				}
				return 2135;
			case 189:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 0;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 0;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -2;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -8;
					dyBody = -2;
				}
				return 2135;
			case 206:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = -3;
					dyBody = 0;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = -3;
					dyBody = 0;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -4;
					dyBody = 0;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -9;
					dyBody = -1;
				}
				return 2456;
			case 197:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = -3;
					dyBody = 0;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = -3;
					dyBody = 0;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -4;
					dyBody = 0;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -5;
					dyBody = 1;
				}
				return 2337;
			case 199:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = -3;
					dyBody = 0;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = -3;
					dyBody = 0;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = -4;
					dyBody = 0;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -5;
					dyBody = -1;
				}
				return 2363;
			default:
				if (arrItemMounts[4].template.id == 443)
				{
					dxBody = 2;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 523)
				{
					dxBody = 2;
					dyBody = -1;
				}
				else if (arrItemMounts[4].template.id == 485)
				{
					dxBody = 0;
					dyBody = 0;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxBody = -5;
					dyBody = -2;
				}
				return 9;
			}
		}
		switch (body)
		{
		case 1:
			if (arrItemMounts[4].template.id == 443)
			{
				dxBody = 3;
				dyBody = -3;
				dxBody = 4;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 523)
			{
				dxBody = 3;
				dyBody = -3;
				dxBody = 4;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 485)
			{
				dxBody = -1;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 524)
			{
				dxBody = -8;
				dyBody = -6;
			}
			return 13;
		case 3:
			if (arrItemMounts[4].template.id == 443)
			{
				dxBody = 4;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 523)
			{
				dxBody = 4;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 485)
			{
				dxBody = -1;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 524)
			{
				dxBody = -8;
				dyBody = -6;
			}
			return 45;
		case 5:
			if (arrItemMounts[4].template.id == 443)
			{
				dxBody = 4;
				dyBody = -3;
			}
			else if (arrItemMounts[4].template.id == 523)
			{
				dxBody = 4;
				dyBody = -3;
			}
			else if (arrItemMounts[4].template.id == 485)
			{
				dxBody = -1;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 524)
			{
				dxBody = -9;
				dyBody = -7;
			}
			return 73;
		case 7:
			if (arrItemMounts[4].template.id == 443)
			{
				dxBody = 4;
				dyBody = -3;
			}
			else if (arrItemMounts[4].template.id == 523)
			{
				dxBody = 4;
				dyBody = -3;
			}
			else if (arrItemMounts[4].template.id == 485)
			{
				dxBody = -1;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 524)
			{
				dxBody = -9;
				dyBody = -7;
			}
			return 101;
		case 10:
			if (arrItemMounts[4].template.id == 443)
			{
				dxBody = 4;
				dyBody = -3;
			}
			else if (arrItemMounts[4].template.id == 523)
			{
				dxBody = 4;
				dyBody = -3;
			}
			else if (arrItemMounts[4].template.id == 485)
			{
				dxBody = -1;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 524)
			{
				dxBody = -9;
				dyBody = -7;
			}
			return 137;
		case 18:
			if (arrItemMounts[4].template.id == 443)
			{
				dxBody = 4;
				dyBody = -3;
			}
			else if (arrItemMounts[4].template.id == 523)
			{
				dxBody = 4;
				dyBody = -3;
			}
			else if (arrItemMounts[4].template.id == 485)
			{
				dxBody = -1;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 524)
			{
				dxBody = -9;
				dyBody = -7;
			}
			return 365;
		case 20:
			if (arrItemMounts[4].template.id == 443)
			{
				dxBody = 4;
				dyBody = -3;
			}
			else if (arrItemMounts[4].template.id == 523)
			{
				dxBody = 4;
				dyBody = -3;
			}
			else if (arrItemMounts[4].template.id == 485)
			{
				dxBody = -1;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 524)
			{
				dxBody = -9;
				dyBody = -7;
			}
			return 391;
		case 22:
			if (arrItemMounts[4].template.id == 443)
			{
				dxBody = 4;
				dyBody = -3;
			}
			else if (arrItemMounts[4].template.id == 523)
			{
				dxBody = 4;
				dyBody = -3;
			}
			else if (arrItemMounts[4].template.id == 485)
			{
				dxBody = -1;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 524)
			{
				dxBody = -9;
				dyBody = -7;
			}
			return 417;
		case 29:
			if (arrItemMounts[4].template.id == 443)
			{
				dxBody = 1;
				dyBody = -3;
			}
			else if (arrItemMounts[4].template.id == 523)
			{
				dxBody = 1;
				dyBody = -3;
			}
			else if (arrItemMounts[4].template.id == 485)
			{
				dxBody = -3;
				dyBody = -3;
			}
			else if (arrItemMounts[4].template.id == 524)
			{
				dxBody = -11;
				dyBody = -6;
			}
			return 472;
		case 32:
			if (arrItemMounts[4].template.id == 443)
			{
				dxBody = 1;
				dyBody = -3;
			}
			else if (arrItemMounts[4].template.id == 523)
			{
				dxBody = 1;
				dyBody = -3;
			}
			else if (arrItemMounts[4].template.id == 485)
			{
				dxBody = -3;
				dyBody = -3;
			}
			else if (arrItemMounts[4].template.id == 524)
			{
				dxBody = -11;
				dyBody = -6;
			}
			return 506;
		case 34:
			if (arrItemMounts[4].template.id == 443)
			{
				dxBody = 3;
				dyBody = -3;
			}
			else if (arrItemMounts[4].template.id == 523)
			{
				dxBody = 3;
				dyBody = -3;
			}
			else if (arrItemMounts[4].template.id == 485)
			{
				dxBody = -1;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 524)
			{
				dxBody = -8;
				dyBody = -7;
			}
			return 531;
		case 36:
			if (arrItemMounts[4].template.id == 443)
			{
				dxBody = 3;
				dyBody = -3;
			}
			else if (arrItemMounts[4].template.id == 523)
			{
				dxBody = 3;
				dyBody = -3;
			}
			else if (arrItemMounts[4].template.id == 485)
			{
				dxBody = -1;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 524)
			{
				dxBody = -8;
				dyBody = -7;
			}
			return 559;
		case 38:
			if (arrItemMounts[4].template.id == 443)
			{
				dxBody = 3;
				dyBody = -3;
			}
			else if (arrItemMounts[4].template.id == 523)
			{
				dxBody = 3;
				dyBody = -3;
			}
			else if (arrItemMounts[4].template.id == 485)
			{
				dxBody = -1;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 524)
			{
				dxBody = -8;
				dyBody = -7;
			}
			return 798;
		case 42:
			if (arrItemMounts[4].template.id == 443)
			{
				dxBody = 3;
				dyBody = -3;
			}
			else if (arrItemMounts[4].template.id == 523)
			{
				dxBody = 3;
				dyBody = -3;
			}
			else if (arrItemMounts[4].template.id == 485)
			{
				dxBody = -1;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 524)
			{
				dxBody = -8;
				dyBody = -7;
			}
			return 970;
		case 94:
			if (arrItemMounts[4].template.id == 443)
			{
				dxBody = 0;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 523)
			{
				dxBody = 0;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 485)
			{
				dxBody = -4;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 524)
			{
				dxBody = -12;
				dyBody = -7;
			}
			return 1142;
		case 141:
			if (arrItemMounts[4].template.id == 443)
			{
				dxBody = 3;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 523)
			{
				dxBody = 3;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 485)
			{
				dxBody = -1;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 524)
			{
				dxBody = -9;
				dyBody = -7;
			}
			return 1348;
		case 154:
			if (arrItemMounts[4].template.id == 443)
			{
				dxBody = -3;
				dyBody = 0;
			}
			else if (arrItemMounts[4].template.id == 523)
			{
				dxBody = -3;
				dyBody = 0;
			}
			else if (arrItemMounts[4].template.id == 485)
			{
				dxBody = -8;
				dyBody = 0;
			}
			else if (arrItemMounts[4].template.id == 524)
			{
				dxBody = -15;
				dyBody = -3;
			}
			return 1487;
		case 156:
			if (arrItemMounts[4].template.id == 443)
			{
				dxBody = 1;
				dyBody = -3;
			}
			else if (arrItemMounts[4].template.id == 523)
			{
				dxBody = 1;
				dyBody = -3;
			}
			else if (arrItemMounts[4].template.id == 485)
			{
				dxBody = -4;
				dyBody = -3;
			}
			else if (arrItemMounts[4].template.id == 524)
			{
				dxBody = -10;
				dyBody = -7;
			}
			return 1507;
		case 157:
			if (arrItemMounts[4].template.id == 443)
			{
				dxBody = 4;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 523)
			{
				dxBody = 4;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 485)
			{
				dxBody = -1;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 524)
			{
				dxBody = -8;
				dyBody = -7;
			}
			return 1812;
		case 173:
			if (arrItemMounts[4].template.id == 443)
			{
				dxBody = 4;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 523)
			{
				dxBody = 4;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 485)
			{
				dxBody = -1;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 524)
			{
				dxBody = -8;
				dyBody = -7;
			}
			return 1838;
		case 180:
			if (arrItemMounts[4].template.id == 443)
			{
				dxBody = 4;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 523)
			{
				dxBody = 4;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 485)
			{
				dxBody = -1;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 524)
			{
				dxBody = -8;
				dyBody = -7;
			}
			return 1959;
		case 183:
			if (arrItemMounts[4].template.id == 443)
			{
				dxBody = 4;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 523)
			{
				dxBody = 4;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 485)
			{
				dxBody = -1;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 524)
			{
				dxBody = -8;
				dyBody = -7;
			}
			return 1987;
		case 186:
			if (arrItemMounts[4].template.id == 443)
			{
				dxBody = -3;
				dyBody = -2;
			}
			else if (arrItemMounts[4].template.id == 523)
			{
				dxBody = -3;
				dyBody = -2;
			}
			else if (arrItemMounts[4].template.id == 485)
			{
				dxBody = -6;
				dyBody = -2;
			}
			else if (arrItemMounts[4].template.id == 524)
			{
				dxBody = -14;
				dyBody = -5;
			}
			return 2117;
		case 189:
			if (arrItemMounts[4].template.id == 443)
			{
				dxBody = -3;
				dyBody = -2;
			}
			else if (arrItemMounts[4].template.id == 523)
			{
				dxBody = -3;
				dyBody = -2;
			}
			else if (arrItemMounts[4].template.id == 485)
			{
				dxBody = -6;
				dyBody = -2;
			}
			else if (arrItemMounts[4].template.id == 524)
			{
				dxBody = -14;
				dyBody = -5;
			}
			return 2144;
		case 206:
			if (arrItemMounts[4].template.id == 443)
			{
				dxBody = -1;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 523)
			{
				dxBody = -1;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 485)
			{
				dxBody = -5;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 524)
			{
				dxBody = -10;
				dyBody = -6;
			}
			return 2459;
		case 197:
			if (arrItemMounts[4].template.id == 443)
			{
				dxBody = -1;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 523)
			{
				dxBody = -1;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 485)
			{
				dxBody = -5;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 524)
			{
				dxBody = -10;
				dyBody = -6;
			}
			return 2342;
		case 199:
			if (arrItemMounts[4].template.id == 443)
			{
				dxBody = -1;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 523)
			{
				dxBody = -1;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 485)
			{
				dxBody = -5;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 524)
			{
				dxBody = -10;
				dyBody = -6;
			}
			return 2373;
		default:
			if (arrItemMounts[4].template.id == 443)
			{
				dxBody = 3;
				dyBody = -3;
			}
			else if (arrItemMounts[4].template.id == 523)
			{
				dxBody = 3;
				dyBody = -3;
			}
			else if (arrItemMounts[4].template.id == 485)
			{
				dxBody = 0;
				dyBody = -4;
			}
			else if (arrItemMounts[4].template.id == 524)
			{
				dxBody = -7;
				dyBody = -6;
			}
			return 13;
		}
	}

	private int getHeadId()
	{
		dxHead = (dyHead = 0);
		if (statusMe == 3)
		{
			switch (head)
			{
			case 2:
				dxHead = 0;
				dyHead = -3;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 33;
			case 11:
				dxHead = 0;
				dyHead = -3;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 147;
			case 23:
				dxHead = 1;
				dyHead = -4;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 427;
			case 24:
				dxHead = 1;
				dyHead = -4;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 430;
			case 25:
				dxHead = 3;
				dyHead = -4;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 433;
			case 26:
				dxHead = 0;
				dyHead = -3;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 436;
			case 27:
				dxHead = 0;
				dyHead = -3;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 439;
			case 28:
				dxHead = 0;
				dyHead = -3;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 442;
			case 112:
				dxHead = 1;
				dyHead = -4;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 148;
			case 113:
				dxHead = -1;
				dyHead = -3;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 443;
			case 124:
				dxHead = 1;
				dyHead = -4;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 1235;
			case 125:
				dxHead = -1;
				dyHead = -3;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 1237;
			case 126:
				dxHead = -1;
				dyHead = -4;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 1255;
			case 127:
				dxHead = -1;
				dyHead = -4;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 1257;
			case 137:
				dxHead = 0;
				dyHead = -3;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 1309;
			case 138:
				dxHead = 0;
				dyHead = -3;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 1311;
			case 139:
				dxHead = 2;
				dyHead = -5;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 1315;
			case 140:
				dxHead = 3;
				dyHead = -4;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 1313;
			case 146:
				dxHead = 1;
				dyHead = -3;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 1416;
			case 147:
				dxHead = -2;
				dyHead = -4;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 1418;
			case 148:
				dxHead = 0;
				dyHead = -4;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 1422;
			case 149:
				dxHead = -2;
				dyHead = -4;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 1424;
			case 150:
				dxHead = 0;
				dyHead = -4;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 1441;
			case 151:
				dxHead = -2;
				dyHead = -4;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 1439;
			case 152:
				dxHead = 1;
				dyHead = -4;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 1447;
			case 153:
				dxHead = 0;
				dyHead = -3;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 1445;
			case 158:
				dxHead = -2;
				dyHead = -3;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 1585;
			case 159:
				dxHead = 0;
				dyHead = -3;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 1589;
			case 160:
				dxHead = 2;
				dyHead = -2;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 1587;
			case 161:
				dxHead = 3;
				dyHead = -3;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 1595;
			case 162:
				dxHead = -5;
				dyHead = -3;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 1597;
			case 163:
				dxHead = -3;
				dyHead = -2;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 1604;
			case 179:
				dxHead = 3;
				dyHead = -3;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 1978;
			case 182:
				dxHead = 3;
				dyHead = -3;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 2006;
			case 185:
				dxHead = -4;
				dyHead = -3;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 2129;
			case 188:
				dxHead = 0;
				dyHead = -3;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 2156;
			case 205:
				dxHead = 0;
				dyHead = -3;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 2451;
			case 210:
				dxHead = 0;
				dyHead = -5;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 2519;
			case 211:
				dxHead = -1;
				dyHead = -3;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 2521;
			case 212:
				dxHead = -2;
				dyHead = -2;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 2523;
			case 213:
				dxHead = 0;
				dyHead = -3;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 2525;
			case 214:
				dxHead = 1;
				dyHead = -3;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 2526;
			default:
				dxHead = 2;
				dyHead = -5;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dxHead -= 2;
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 7;
						dyHead--;
					}
				}
				return 33;
			}
		}
		if (!isBocdau)
		{
			switch (head)
			{
			case 2:
				dxHead = -1;
				dyHead = -3;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 33;
			case 11:
				dxHead = -2;
				dyHead = -1;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 147;
			case 23:
				dxHead = -1;
				dyHead = -2;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 427;
			case 24:
				dxHead = -1;
				dyHead = -2;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 430;
			case 25:
				dxHead = 1;
				dyHead = -2;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 433;
			case 26:
				dxHead = -2;
				dyHead = -1;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 436;
			case 27:
				dxHead = -2;
				dyHead = -1;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 439;
			case 28:
				dxHead = -2;
				dyHead = -1;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 442;
			case 112:
				dxHead = -1;
				dyHead = -2;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 148;
			case 113:
				dxHead = -3;
				dyHead = -1;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 443;
			case 124:
				dxHead = -1;
				dyHead = -2;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 1235;
			case 125:
				dxHead = -1;
				dyHead = -2;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 1237;
			case 126:
				dxHead = -1;
				dyHead = -2;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 1255;
			case 127:
				dxHead = -3;
				dyHead = -2;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 1257;
			case 137:
				dxHead = -2;
				dyHead = -1;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 1309;
			case 138:
				dxHead = -2;
				dyHead = -1;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 1311;
			case 139:
				dxHead = 0;
				dyHead = -3;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 1315;
			case 140:
				dxHead = 1;
				dyHead = -2;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 1313;
			case 146:
				dxHead = -1;
				dyHead = -1;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 1416;
			case 147:
				dxHead = -4;
				dyHead = -2;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 1418;
			case 148:
				dxHead = -2;
				dyHead = -2;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 1422;
			case 149:
				dxHead = -4;
				dyHead = -2;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 1424;
			case 150:
				dxHead = -2;
				dyHead = -2;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 1441;
			case 151:
				dxHead = -4;
				dyHead = -2;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 1439;
			case 152:
				dxHead = -1;
				dyHead = -2;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 1447;
			case 153:
				dxHead = -2;
				dyHead = -1;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 1445;
			case 158:
				dxHead = -4;
				dyHead = -1;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 1585;
			case 159:
				dxHead = -2;
				dyHead = -1;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 1589;
			case 160:
				dxHead = 0;
				dyHead = 0;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 1587;
			case 161:
				dxHead = 1;
				dyHead = -1;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 1595;
			case 162:
				dxHead = -7;
				dyHead = -1;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 1597;
			case 163:
				dxHead = -5;
				dyHead = 0;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 1604;
			case 179:
				dxHead = 1;
				dyHead = -1;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 1978;
			case 182:
				dxHead = 1;
				dyHead = -1;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 2006;
			case 185:
				dxHead = -6;
				dyHead = -1;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 2129;
			case 188:
				dxHead = -2;
				dyHead = -1;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 2156;
			case 205:
				dxHead = -2;
				dyHead = -1;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 2451;
			case 210:
				dxHead = -2;
				dyHead = -3;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 2519;
			case 211:
				dxHead = -3;
				dyHead = -1;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 2521;
			case 212:
				dxHead = -4;
				dyHead = 0;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 2523;
			case 213:
				dxHead = 0;
				dyHead = -1;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 2525;
			case 214:
				dxHead = -1;
				dyHead = -1;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 2526;
			default:
				dxHead = -1;
				dyHead = -3;
				if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
				{
					if (arrItemMounts[4].template.id == 485)
					{
						dyHead++;
					}
					else if (arrItemMounts[4].template.id == 524)
					{
						dxHead -= 5;
						dyHead--;
					}
				}
				return 33;
			}
		}
		switch (head)
		{
		case 2:
			dxHead = 2;
			dyHead = -5;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 33;
		case 11:
			dxHead = 0;
			dyHead = -3;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 147;
		case 23:
			dxHead = 1;
			dyHead = -4;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 427;
		case 24:
			dxHead = 1;
			dyHead = -4;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 430;
		case 25:
			dxHead = 3;
			dyHead = -4;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 433;
		case 26:
			dxHead = 0;
			dyHead = -3;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 436;
		case 27:
			dxHead = 0;
			dyHead = -3;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 439;
		case 28:
			dxHead = 0;
			dyHead = -3;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 442;
		case 112:
			dxHead = 1;
			dyHead = -4;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 148;
		case 113:
			dxHead = -1;
			dyHead = -3;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 443;
		case 124:
			dxHead = 1;
			dyHead = -4;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 1235;
		case 125:
			dxHead = -1;
			dyHead = -3;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 1237;
		case 126:
			dxHead = -1;
			dyHead = -4;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 1255;
		case 127:
			dxHead = -1;
			dyHead = -4;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 1257;
		case 137:
			dxHead = 0;
			dyHead = -3;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 1309;
		case 138:
			dxHead = 0;
			dyHead = -3;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 1311;
		case 139:
			dxHead = 2;
			dyHead = -5;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 1315;
		case 140:
			dxHead = 3;
			dyHead = -4;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 1313;
		case 146:
			dxHead = 1;
			dyHead = -3;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 1416;
		case 147:
			dxHead = -2;
			dyHead = -4;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 1418;
		case 148:
			dxHead = 0;
			dyHead = -4;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 1422;
		case 149:
			dxHead = -2;
			dyHead = -4;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 1424;
		case 150:
			dxHead = 0;
			dyHead = -4;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 1441;
		case 151:
			dxHead = -2;
			dyHead = -4;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 1439;
		case 152:
			dxHead = 1;
			dyHead = -4;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 1447;
		case 153:
			dxHead = 0;
			dyHead = -3;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 1445;
		case 158:
			dxHead = -2;
			dyHead = -3;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 1585;
		case 159:
			dxHead = 0;
			dyHead = -3;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 1589;
		case 160:
			dxHead = 2;
			dyHead = -2;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 1587;
		case 161:
			dxHead = 3;
			dyHead = -3;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 1595;
		case 162:
			dxHead = -5;
			dyHead = -3;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 1597;
		case 163:
			dxHead = -3;
			dyHead = -2;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 1604;
		case 179:
			dxHead = 3;
			dyHead = -3;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 1978;
		case 182:
			dxHead = 3;
			dyHead = -3;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 2006;
		case 185:
			dxHead = -4;
			dyHead = -3;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 2129;
		case 188:
			dxHead = 0;
			dyHead = -3;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 2156;
		case 205:
			dxHead = 0;
			dyHead = -3;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 2451;
		case 210:
			dxHead = 0;
			dyHead = -5;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 2519;
		case 211:
			dxHead = -1;
			dyHead = -3;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 2521;
		case 212:
			dxHead = -2;
			dyHead = -2;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 2523;
		case 213:
			dxHead = 0;
			dyHead = -3;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 2525;
		case 214:
			dxHead = 1;
			dyHead = -3;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 2526;
		default:
			dxHead = 2;
			dyHead = -5;
			if (arrItemMounts[4].template.id != 443 && arrItemMounts[4].template.id != 523)
			{
				if (arrItemMounts[4].template.id == 485)
				{
					dxHead -= 2;
					dyHead++;
				}
				else if (arrItemMounts[4].template.id == 524)
				{
					dxHead -= 7;
					dyHead--;
				}
			}
			return 33;
		}
	}

	private int[] getClanEffect()
	{
		if (statusMe != 6 && statusMe != 1 && statusMe != 2 && statusMe != 10 && statusMe != 11)
		{
			return null;
		}
		int[] result = null;
		if (me)
		{
			if (arrItemBody[13] != null)
			{
				if (arrItemBody[13].template.id == 425)
				{
					result = new int[5]
					{
						1687,
						1688,
						1689,
						1690,
						1691
					};
				}
				else if (arrItemBody[13].template.id == 426)
				{
					result = new int[5]
					{
						1682,
						1683,
						1684,
						1685,
						1686
					};
				}
				else if (arrItemBody[13].template.id == 427)
				{
					result = new int[5]
					{
						1677,
						1678,
						1679,
						1680,
						1681
					};
				}
			}
		}
		else
		{
			if (glove == -1)
			{
				return null;
			}
			if (glove == 425)
			{
				result = new int[5]
				{
					1687,
					1688,
					1689,
					1690,
					1691
				};
			}
			else if (glove == 426)
			{
				result = new int[5]
				{
					1682,
					1683,
					1684,
					1685,
					1686
				};
			}
			else if (glove == 427)
			{
				result = new int[5]
				{
					1677,
					1678,
					1679,
					1680,
					1681
				};
			}
		}
		return result;
	}

	public void paintClanEffect(mGraphics g, int x, int y)
	{
		int[] clanEffect = getClanEffect();
		if (clanEffect != null)
		{
			int transform = 0;
			if (statusMe == 2)
			{
				transform = ((cdir != 1) ? 5 : 6);
			}
			int num = GameCanvas.gameTick % 13;
			if (num > 9)
			{
				SmallImage.drawSmallImage(g, clanEffect[0], x, y, transform, mGraphics.HCENTER | mGraphics.BOTTOM);
			}
			else if (num > 6)
			{
				SmallImage.drawSmallImage(g, clanEffect[1], x, y, transform, mGraphics.HCENTER | mGraphics.BOTTOM);
			}
			else if (num > 3)
			{
				SmallImage.drawSmallImage(g, clanEffect[2], x - 2, y, transform, mGraphics.HCENTER | mGraphics.BOTTOM);
			}
			else
			{
				SmallImage.drawSmallImage(g, clanEffect[3], x - 2, y, transform, mGraphics.HCENTER | mGraphics.BOTTOM);
			}
		}
	}

	private void paintClanEffectRun(mGraphics g, int x, int y)
	{
		int[] clanEffect = getClanEffect();
		if (clanEffect != null)
		{
			int transform = (cdir != 1) ? 5 : 6;
			int anchor = (cdir != -1) ? (mGraphics.BOTTOM | mGraphics.LEFT) : (mGraphics.BOTTOM | mGraphics.RIGHT);
			int num = GameCanvas.gameTick % 13;
			if (num > 9)
			{
				SmallImage.drawSmallImage(g, clanEffect[0], x, y, transform, anchor);
			}
			else if (num > 6)
			{
				SmallImage.drawSmallImage(g, clanEffect[1], x, y, transform, anchor);
			}
			else if (num > 3)
			{
				SmallImage.drawSmallImage(g, clanEffect[2], x, y, transform, anchor);
			}
			else
			{
				SmallImage.drawSmallImage(g, clanEffect[3], x, y, transform, anchor);
			}
		}
	}

	public void paintClanEffect2(mGraphics g, int x, int y)
	{
		int[] clanEffect = getClanEffect();
		if (clanEffect != null)
		{
			SmallImage.drawSmallImage(g, clanEffect[4], x - 2, y, 0, mGraphics.HCENTER | mGraphics.BOTTOM);
		}
	}

	private void paintCharWithSkill(mGraphics g)
	{
		try
		{
			SkillInfoPaint[] array = skillInfoPaint1();
			cf = array[indexSkill].status;
			if (array[indexSkill].effS0Id != 0)
			{
				eff0 = GameScr.efs[array[indexSkill].effS0Id - 1];
				i0 = (dx0 = (dy0 = 0));
			}
			if (array[indexSkill].effS1Id != 0)
			{
				eff1 = GameScr.efs[array[indexSkill].effS1Id - 1];
				i1 = (dx1 = (dy1 = 0));
			}
			if (array[indexSkill].effS2Id != 0)
			{
				eff2 = GameScr.efs[array[indexSkill].effS2Id - 1];
				i2 = (dx2 = (dy2 = 0));
			}
			SkillInfoPaint[] array2 = array;
			if (array2 != null && array2[indexSkill] != null && array2[indexSkill].arrowId != 0)
			{
				arr = new Arrow(this, GameScr.arrs[array2[indexSkill].arrowId - 1]);
				arr.life = 10;
				arr.ax = cx + array2[indexSkill].adx;
				arr.ay = cy + array2[indexSkill].ady;
			}
			paintCharWithoutSkill(g);
			if (cdir == 1)
			{
				if (eff0 != null)
				{
					if (dx0 == 0)
					{
						dx0 = array[indexSkill].e0dx;
					}
					if (dy0 == 0)
					{
						dy0 = array[indexSkill].e0dy;
					}
					SmallImage.drawSmallImage(g, eff0.arrEfInfo[i0].idImg, cx + dx0 + eff0.arrEfInfo[i0].dx, cy + dy0 + eff0.arrEfInfo[i0].dy, 0, mGraphics.VCENTER | mGraphics.HCENTER);
					i0++;
					if (i0 >= eff0.arrEfInfo.Length)
					{
						eff0 = null;
						i0 = (dx0 = (dy0 = 0));
					}
				}
				if (eff1 != null)
				{
					if (dx1 == 0)
					{
						dx1 = array[indexSkill].e1dx;
					}
					if (dy1 == 0)
					{
						dy1 = array[indexSkill].e1dy;
					}
					SmallImage.drawSmallImage(g, eff1.arrEfInfo[i1].idImg, cx + dx1 + eff1.arrEfInfo[i1].dx, cy + dy1 + eff1.arrEfInfo[i1].dy, 0, mGraphics.VCENTER | mGraphics.HCENTER);
					i1++;
					if (i1 >= eff1.arrEfInfo.Length)
					{
						eff1 = null;
						i1 = (dx1 = (dy1 = 0));
					}
				}
				if (eff2 != null)
				{
					if (dx2 == 0)
					{
						dx2 = array[indexSkill].e2dx;
					}
					if (dy2 == 0)
					{
						dy2 = array[indexSkill].e2dy;
					}
					SmallImage.drawSmallImage(g, eff2.arrEfInfo[i2].idImg, cx + dx2 + eff2.arrEfInfo[i2].dx, cy + dy2 + eff2.arrEfInfo[i2].dy, 0, mGraphics.VCENTER | mGraphics.HCENTER);
					i2++;
					if (eff2.arrEfInfo != null && i2 >= eff2.arrEfInfo.Length)
					{
						eff2 = null;
						i2 = (dx2 = (dy2 = 0));
					}
				}
			}
			else
			{
				if (eff0 != null)
				{
					if (dx0 == 0)
					{
						dx0 = array[indexSkill].e0dx;
					}
					if (dy0 == 0)
					{
						dy0 = array[indexSkill].e0dy;
					}
					SmallImage.drawSmallImage(g, eff0.arrEfInfo[i0].idImg, cx - dx0 - eff0.arrEfInfo[i0].dx, cy + dy0 + eff0.arrEfInfo[i0].dy, 2, mGraphics.VCENTER | mGraphics.HCENTER);
					i0++;
					if (i0 >= eff0.arrEfInfo.Length)
					{
						eff0 = null;
						i0 = 0;
						dx0 = 0;
						dy0 = 0;
					}
				}
				if (eff1 != null)
				{
					if (dx1 == 0)
					{
						dx1 = array[indexSkill].e1dx;
					}
					if (dy1 == 0)
					{
						dy1 = array[indexSkill].e1dy;
					}
					SmallImage.drawSmallImage(g, eff1.arrEfInfo[i1].idImg, cx - dx1 - eff1.arrEfInfo[i1].dx, cy + dy1 + eff1.arrEfInfo[i1].dy, 2, mGraphics.VCENTER | mGraphics.HCENTER);
					i1++;
					if (i1 >= eff1.arrEfInfo.Length)
					{
						eff1 = null;
						i1 = 0;
						dx1 = 0;
						dy1 = 0;
					}
				}
				if (eff2 != null)
				{
					if (dx2 == 0)
					{
						dx2 = array[indexSkill].e2dx;
					}
					if (dy2 == 0)
					{
						dy2 = array[indexSkill].e2dy;
					}
					SmallImage.drawSmallImage(g, eff2.arrEfInfo[i2].idImg, cx - dx2 - eff2.arrEfInfo[i2].dx, cy + dy2 + eff2.arrEfInfo[i2].dy, 2, mGraphics.VCENTER | mGraphics.HCENTER);
					i2++;
					if (eff2.arrEfInfo != null && i2 >= eff2.arrEfInfo.Length)
					{
						eff2 = null;
						i2 = 0;
						dx2 = 0;
						dy2 = 0;
					}
				}
			}
			indexSkill++;
		}
		catch (Exception)
		{
		}
	}

	public static bool isCharInScreen(Char c)
	{
		int cmx = GameScr.cmx;
		int num = GameScr.cmx + GameCanvas.w;
		int num2 = GameScr.cmy + 10;
		int num3 = GameScr.cmy + GameScr.gH;
		if (c.statusMe != 15 && !c.isInvisible && cmx <= c.cx && c.cx <= num && num2 <= c.cy && c.cy <= num3)
		{
			return true;
		}
		return false;
	}

	public void callEff(int effId)
	{
		indexEff = 0;
		eff = GameScr.efs[effId];
	}

	public void callEffTask(int effId)
	{
		indexEffTask = 0;
		effTask = GameScr.efs[effId];
	}

	public static int getIndexChar(int ID)
	{
		for (int i = 0; i < GameScr.vCharInMap.size(); i++)
		{
			Char @char = (Char)GameScr.vCharInMap.elementAt(i);
			if (@char.charID == ID)
			{
				return i;
			}
		}
		return -1;
	}

	public void moveTo(int toX, int toY)
	{
		int dir = 0;
		int act = 0;
		int num = toX - cx;
		int num2 = toY - cy;
		if (num == 0 && num2 == 0)
		{
			act = 1;
		}
		else if (num2 == 0)
		{
			act = 2;
			if (vMovePoints.size() > 0)
			{
				MovePoint movePoint = null;
				try
				{
					movePoint = (MovePoint)vMovePoints.lastElement();
				}
				catch (Exception)
				{
				}
				if (movePoint != null && TileMap.tileTypeAt(movePoint.xEnd, movePoint.yEnd, TileMap.T_WATERFLOW) && movePoint.yEnd % TileMap.size > 8)
				{
					act = 10;
				}
			}
			if (num > 0)
			{
				dir = 1;
			}
			if (num < 0)
			{
				dir = -1;
			}
		}
		else if (num2 != 0)
		{
			if (num2 < 0)
			{
				act = 3;
			}
			if (num2 > 0)
			{
				act = 4;
			}
			if (num < 0)
			{
				dir = -1;
			}
			if (num > 0)
			{
				dir = 1;
			}
		}
		int num3 = 0;
		int num4 = 0;
		num3 = cx + num;
		num4 = cy + num2;
		vMovePoints.addElement(new MovePoint(num3, num4, act, dir));
		statusMe = 6;
	}

	public static void getcharInjure(int cID, int dx, int dy, int HP)
	{
		Char @char = (Char)GameScr.vCharInMap.elementAt(cID);
		if (@char.vMovePoints.size() != 0)
		{
			MovePoint movePoint = (MovePoint)@char.vMovePoints.lastElement();
			int xEnd = movePoint.xEnd + dx;
			int yEnd = movePoint.yEnd + dy;
			((Char)GameScr.vCharInMap.elementAt(cID)).cHP -= HP;
			if (((Char)GameScr.vCharInMap.elementAt(cID)).cHP < 0)
			{
				((Char)GameScr.vCharInMap.elementAt(cID)).cHP = 0;
			}
			((Char)GameScr.vCharInMap.elementAt(cID)).statusMe = 6;
			((Char)GameScr.vCharInMap.elementAt(cID)).HPShow = ((Char)GameScr.vCharInMap.elementAt(cID)).cHP - HP;
			((Char)GameScr.vCharInMap.elementAt(cID)).vMovePoints.addElement(new MovePoint(xEnd, yEnd, 8, ((Char)GameScr.vCharInMap.elementAt(cID)).cdir));
		}
	}

	public void searchFocus()
	{
		if (charFocus != null && charFocus.isNhanban)
		{
			charFocus = null;
		}
		if (isManualFocus && charFocus != null && (charFocus.statusMe == 15 || charFocus.isInvisible))
		{
			charFocus = null;
		}
		if (GameCanvas.gameTick % 2 == 0 || isMeCanAttackOtherPlayer(charFocus))
		{
			return;
		}
		int num = 0;
		if (nClass.classId == 0 || nClass.classId == 1 || nClass.classId == 3 || nClass.classId == 5)
		{
			num = ((GameScr.auto != 1) ? 40 : 0);
		}
		int[] array = new int[4]
		{
			-1,
			-1,
			-1,
			-1
		};
		int num2 = GameScr.cmx - 10;
		int num3 = GameScr.cmx + GameCanvas.w + 10;
		int cmy = GameScr.cmy;
		int num4 = GameScr.cmy + GameCanvas.h - GameScr.cmdBarH + 10;
		if (isManualFocus)
		{
			if ((mobFocus != null && mobFocus.status != 1 && mobFocus.status != 0 && num2 <= mobFocus.x && mobFocus.x <= num3 && cmy <= mobFocus.y && mobFocus.y <= num4) || (npcFocus != null && num2 <= npcFocus.cx && npcFocus.cx <= num3 && cmy <= npcFocus.cy && npcFocus.cy <= num4) || (charFocus != null && num2 <= charFocus.cx && charFocus.cx <= num3 && cmy <= charFocus.cy && charFocus.cy <= num4) || (itemFocus != null && num2 <= itemFocus.x && itemFocus.x <= num3 && cmy <= itemFocus.y && itemFocus.y <= num4))
			{
				return;
			}
			isManualFocus = false;
		}
		if (itemFocus == null)
		{
			for (int i = 0; i < GameScr.vItemMap.size(); i++)
			{
				ItemMap itemMap = (ItemMap)GameScr.vItemMap.elementAt(i);
				int num5 = Math.abs(getMyChar().cx - itemMap.x);
				int num6 = Math.abs(getMyChar().cy - itemMap.y);
				int num7 = (num5 <= num6) ? num6 : num5;
				if (num5 > 48 || num6 > 48 || (itemFocus != null && num7 >= array[3]))
				{
					continue;
				}
				if (GameScr.auto != 0 && GameScr.gI().isBagFull())
				{
					if (itemMap.template.type == 19)
					{
						if (GameScr.isUseitemAuto)
						{
							itemFocus = null;
						}
						else
						{
							itemFocus = itemMap;
						}
						array[3] = num7;
					}
				}
				else if (isAPickYen || isAPickYHM || isAPickYHMS || isANoPick)
				{
					if ((isAPickYen && itemMap.template.type == 19) || (isAPickYHM && (itemMap.template.type == 19 || itemMap.template.type == 16 || itemMap.template.type == 17)) || (isAPickYHMS && (itemMap.template.type == 19 || itemMap.template.type == 16 || itemMap.template.type == 17 || itemMap.template.type == 26)))
					{
						if (GameScr.isUseitemAuto)
						{
							itemFocus = null;
						}
						else
						{
							itemFocus = itemMap;
						}
						array[3] = num7;
					}
				}
				else
				{
					if (GameScr.isUseitemAuto)
					{
						itemFocus = null;
					}
					else
					{
						itemFocus = itemMap;
					}
					array[3] = num7;
				}
			}
		}
		else
		{
			if (num2 <= itemFocus.x && itemFocus.x <= num3 && cmy <= itemFocus.y && itemFocus.y <= num4)
			{
				clearFocus(3);
				return;
			}
			itemFocus = null;
			for (int j = 0; j < GameScr.vItemMap.size(); j++)
			{
				ItemMap itemMap2 = (ItemMap)GameScr.vItemMap.elementAt(j);
				int num8 = Math.abs(getMyChar().cx - itemMap2.x);
				int num9 = Math.abs(getMyChar().cy - itemMap2.y);
				int num10 = (num8 <= num9) ? num9 : num8;
				if (num2 > itemMap2.x || itemMap2.x > num3 || cmy > itemMap2.y || itemMap2.y > num4 || (itemFocus != null && num10 >= array[3]))
				{
					continue;
				}
				if (GameScr.auto != 0 && GameScr.gI().isBagFull())
				{
					if (itemMap2.template.type == 19)
					{
						if (GameScr.isUseitemAuto)
						{
							itemFocus = null;
						}
						else
						{
							itemFocus = itemMap2;
						}
						array[3] = num10;
					}
				}
				else if (isAPickYen || isAPickYHM || isAPickYHMS || isANoPick)
				{
					if ((isAPickYen && itemMap2.template.type == 19) || (isAPickYHM && (itemMap2.template.type == 19 || itemMap2.template.type == 16 || itemMap2.template.type == 17)) || (isAPickYHMS && (itemMap2.template.type == 19 || itemMap2.template.type == 16 || itemMap2.template.type == 17 || itemMap2.template.type == 26)))
					{
						if (GameScr.isUseitemAuto)
						{
							itemFocus = null;
						}
						else
						{
							itemFocus = itemMap2;
						}
						array[3] = num10;
					}
				}
				else
				{
					if (GameScr.isUseitemAuto)
					{
						itemFocus = null;
					}
					else
					{
						itemFocus = itemMap2;
					}
					array[3] = num10;
				}
			}
		}
		if (TileMap.typeMap == TileMap.MAP_CHIENTRUONG || TileMap.mapID == 111)
		{
			num2 = getMyChar().cx - getMyChar().getdxSkill();
			num3 = getMyChar().cx + getMyChar().getdxSkill();
			cmy = getMyChar().cy - getMyChar().getdySkill() - num;
			num4 = getMyChar().cy + getMyChar().getdySkill();
			if (num4 > getMyChar().cy + 30)
			{
				num4 = getMyChar().cy + 30;
			}
			if (mobFocus == null)
			{
				for (int k = 0; k < GameScr.vMob.size(); k++)
				{
					Mob mob = (Mob)GameScr.vMob.elementAt(k);
					int num11 = Math.abs(getMyChar().cx - mob.x);
					int num12 = Math.abs(getMyChar().cy - mob.y);
					int num13 = (num11 <= num12) ? num12 : num11;
					if ((mob.templateId != 97 || getMyChar().cTypePk != PK_PHE1) && (mob.templateId != 96 || getMyChar().cTypePk != PK_PHE2) && (mob.templateId != 98 || getMyChar().cTypePk != PK_PHE1) && (mob.templateId != 167 || getMyChar().cTypePk != PK_PHE1) && (mob.templateId != 99 || getMyChar().cTypePk != PK_PHE2) && (mob.templateId != 166 || getMyChar().cTypePk != PK_PHE2) && (!GameScr.isUseitemAuto || mob.levelBoss != 3) && num2 <= mob.x && mob.x <= num3 && cmy <= mob.y && mob.y <= num4 && mob.status != 0 && mob.status != 1 && (mobFocus == null || num13 < array[0]))
					{
						mobFocus = mob;
						array[0] = num13;
					}
				}
			}
			else
			{
				if (mobFocus.status != 1 && mobFocus.status != 0 && num2 <= mobFocus.x && mobFocus.x <= num3 && cmy <= mobFocus.y && mobFocus.y <= num4)
				{
					clearFocus(0);
					return;
				}
				mobFocus = null;
				for (int l = 0; l < GameScr.vMob.size(); l++)
				{
					Mob mob2 = (Mob)GameScr.vMob.elementAt(l);
					int num14 = Math.abs(getMyChar().cx - mob2.x);
					int num15 = Math.abs(getMyChar().cy - mob2.y);
					int num16 = (num14 <= num15) ? num15 : num14;
					if ((mob2.templateId != 97 || getMyChar().cTypePk != PK_PHE1) && (mob2.templateId != 96 || getMyChar().cTypePk != PK_PHE2) && (mob2.templateId != 98 || getMyChar().cTypePk != PK_PHE1) && (mob2.templateId != 167 || getMyChar().cTypePk != PK_PHE1) && (mob2.templateId != 99 || getMyChar().cTypePk != PK_PHE2) && (mob2.templateId != 166 || getMyChar().cTypePk != PK_PHE2) && (!GameScr.isUseitemAuto || mob2.levelBoss != 3) && num2 <= mob2.x && mob2.x <= num3 && cmy <= mob2.y && mob2.y <= num4 && mob2.status != 0 && mob2.status != 1 && (mobFocus == null || num16 < array[0]))
					{
						mobFocus = mob2;
						array[0] = num16;
					}
				}
			}
			num2 = getMyChar().cx - 80;
			num3 = getMyChar().cx + 80;
			cmy = getMyChar().cy - 30;
			num4 = getMyChar().cy + 30;
			if (npcFocus != null && npcFocus.template.npcTemplateId == 13)
			{
				num2 = getMyChar().cx - 20;
				num3 = getMyChar().cx + 20;
				cmy = getMyChar().cy - 10;
				num4 = getMyChar().cy + 10;
			}
			if (npcFocus == null)
			{
				for (int m = 0; m < GameScr.vNpc.size(); m++)
				{
					Npc npc = (Npc)GameScr.vNpc.elementAt(m);
					if (npc.statusMe == 15)
					{
						continue;
					}
					int num17 = Math.abs(getMyChar().cx - npc.cx);
					int num18 = Math.abs(getMyChar().cy - npc.cy);
					int num19 = (num17 <= num18) ? num18 : num17;
					num2 = getMyChar().cx - 80;
					num3 = getMyChar().cx + 80;
					cmy = getMyChar().cy - 30;
					num4 = getMyChar().cy + 30;
					if (npc.template.npcTemplateId == 13)
					{
						num2 = getMyChar().cx - 20;
						num3 = getMyChar().cx + 20;
						cmy = getMyChar().cy - 10;
						num4 = getMyChar().cy + 10;
					}
					if (num2 <= npc.cx && npc.cx <= num3 && cmy <= npc.cy && npc.cy <= num4 && (npcFocus == null || num19 < array[1]))
					{
						if (GameScr.isUseitemAuto && GameScr.auto == 1)
						{
							break;
						}
						npcFocus = npc;
						array[1] = num19;
					}
				}
			}
			else
			{
				if (num2 <= npcFocus.cx && npcFocus.cx <= num3 && cmy <= npcFocus.cy && npcFocus.cy <= num4)
				{
					clearFocus(1);
					return;
				}
				deFocusNPC();
				for (int n = 0; n < GameScr.vNpc.size(); n++)
				{
					Npc npc2 = (Npc)GameScr.vNpc.elementAt(n);
					if (npc2.statusMe == 15)
					{
						continue;
					}
					int num20 = Math.abs(getMyChar().cx - npc2.cx);
					int num21 = Math.abs(getMyChar().cy - npc2.cy);
					int num22 = (num20 <= num21) ? num21 : num20;
					num2 = getMyChar().cx - 80;
					num3 = getMyChar().cx + 80;
					cmy = getMyChar().cy - 30;
					num4 = getMyChar().cy + 30;
					if (npc2.template.npcTemplateId == 13)
					{
						num2 = getMyChar().cx - 20;
						num3 = getMyChar().cx + 20;
						cmy = getMyChar().cy - 10;
						num4 = getMyChar().cy + 10;
					}
					if (num2 <= npc2.cx && npc2.cx <= num3 && cmy <= npc2.cy && npc2.cy <= num4 && (npcFocus == null || num22 < array[1]))
					{
						if (GameScr.isUseitemAuto && GameScr.auto == 1)
						{
							break;
						}
						npcFocus = npc2;
						array[1] = num22;
					}
				}
			}
			num2 = getMyChar().cx - 40;
			num3 = getMyChar().cx + 40;
			cmy = getMyChar().cy - 30;
			num4 = getMyChar().cy + 30;
			if (charFocus == null)
			{
				for (int num23 = 0; num23 < GameScr.vCharInMap.size(); num23++)
				{
					Char @char = (Char)GameScr.vCharInMap.elementAt(num23);
					if (@char.isNhanbanz())
					{
						continue;
					}
					if (TileMap.mapID != 111)
					{
						if (@char.statusMe == 15 || @char.isInvisible || @char.cTypePk == myChar.cTypePk || wdx != 0 || wdy != 0 || @char.statusMe == 14 || @char.statusMe == 5)
						{
							continue;
						}
					}
					else
					{
						if (@char.statusMe == 15 || @char.isInvisible || wdx != 0 || wdy != 0)
						{
							continue;
						}
						if (myChar.nClass.classId == 6)
						{
							if (myChar.cTypePk == @char.cTypePk)
							{
								if (@char.statusMe != 14 || @char.statusMe != 5)
								{
									continue;
								}
							}
							else if (@char.statusMe == 14 || @char.statusMe == 5)
							{
								continue;
							}
						}
						else if (myChar.cTypePk == @char.cTypePk || @char.statusMe == 14 || @char.statusMe == 5)
						{
							continue;
						}
					}
					int num24 = Math.abs(getMyChar().cx - @char.cx);
					int num25 = Math.abs(getMyChar().cy - @char.cy);
					int num26 = (num24 <= num25) ? num25 : num24;
					if (num2 <= @char.cx && @char.cx <= num3 && cmy <= @char.cy && @char.cy <= num4 && (charFocus == null || num26 < array[2]))
					{
						charFocus = @char;
						array[2] = num26;
					}
				}
			}
			else
			{
				if (num2 <= charFocus.cx && charFocus.cx <= num3 && cmy <= charFocus.cy && charFocus.cy <= num4 && charFocus.statusMe != 15 && !charFocus.isInvisible && charFocus.statusMe != 14 && charFocus.statusMe != 5)
				{
					clearFocus(2);
					return;
				}
				charFocus = null;
				for (int num27 = 0; num27 < GameScr.vCharInMap.size(); num27++)
				{
					Char char2 = (Char)GameScr.vCharInMap.elementAt(num27);
					if (char2.isNhanbanz())
					{
						continue;
					}
					if (TileMap.mapID != 111)
					{
						if (char2.statusMe == 15 || char2.isInvisible || char2.cTypePk == myChar.cTypePk || wdx != 0 || wdy != 0 || char2.statusMe == 14 || char2.statusMe == 5)
						{
							continue;
						}
					}
					else
					{
						if (char2.statusMe == 15 || char2.isInvisible || wdx != 0 || wdy != 0)
						{
							continue;
						}
						if (myChar.nClass.classId == 6)
						{
							if (myChar.cTypePk == char2.cTypePk)
							{
								if (char2.statusMe != 14 || char2.statusMe != 5)
								{
									continue;
								}
							}
							else if (char2.statusMe == 14 || char2.statusMe == 5)
							{
								continue;
							}
						}
						else if (myChar.cTypePk == char2.cTypePk || char2.statusMe == 14 || char2.statusMe == 5)
						{
							continue;
						}
					}
					int num28 = Math.abs(getMyChar().cx - char2.cx);
					int num29 = Math.abs(getMyChar().cy - char2.cy);
					int num30 = (num28 <= num29) ? num29 : num28;
					if (num2 <= char2.cx && char2.cx <= num3 && cmy <= char2.cy && char2.cy <= num4 && (charFocus == null || num30 < array[2]))
					{
						charFocus = char2;
						array[2] = num30;
					}
				}
			}
			int num31 = -1;
			for (int num32 = 0; num32 < array.Length; num32++)
			{
				if (num31 == -1)
				{
					if (array[num32] != -1)
					{
						num31 = num32;
					}
				}
				else if (array[num32] < array[num31] && array[num32] != -1)
				{
					num31 = num32;
				}
			}
			clearFocus(num31);
			return;
		}
		num2 = getMyChar().cx - getMyChar().getdxSkill() - 10;
		num3 = getMyChar().cx + getMyChar().getdxSkill() + 10;
		cmy = getMyChar().cy - getMyChar().getdySkill() - num;
		num4 = getMyChar().cy + getMyChar().getdySkill();
		if (num4 > getMyChar().cy + 30)
		{
			num4 = getMyChar().cy + 30;
		}
		if (mobFocus == null)
		{
			for (int num33 = 0; num33 < GameScr.vMob.size(); num33++)
			{
				Mob mob3 = (Mob)GameScr.vMob.elementAt(num33);
				int num34 = Math.abs(getMyChar().cx - mob3.x);
				int num35 = Math.abs(getMyChar().cy - mob3.y);
				int num36 = (num34 <= num35) ? num35 : num34;
				if ((mob3.templateId != 97 || getMyChar().cTypePk != PK_PHE1) && (mob3.templateId != 96 || getMyChar().cTypePk != PK_PHE2) && (mob3.templateId != 98 || getMyChar().cTypePk != PK_PHE1) && (mob3.templateId != 167 || getMyChar().cTypePk != PK_PHE1) && (mob3.templateId != 99 || getMyChar().cTypePk != PK_PHE2) && (mob3.templateId != 166 || getMyChar().cTypePk != PK_PHE2) && (mob3.templateId != 202 || mob3.status != 8 || mob3.isPaint()) && num2 <= mob3.x && mob3.x <= num3 && cmy <= mob3.y && mob3.y <= num4 && mob3.status != 0 && mob3.status != 1 && (mobFocus == null || num36 < array[0]))
				{
					mobFocus = mob3;
					array[0] = num36;
				}
			}
		}
		else
		{
			if (mobFocus.status != 1 && mobFocus.status != 0 && num2 <= mobFocus.x && mobFocus.x <= num3 && cmy <= mobFocus.y && mobFocus.y <= num4)
			{
				clearFocus(0);
				return;
			}
			mobFocus = null;
			for (int num37 = 0; num37 < GameScr.vMob.size(); num37++)
			{
				Mob mob4 = (Mob)GameScr.vMob.elementAt(num37);
				int num38 = Math.abs(getMyChar().cx - mob4.x);
				int num39 = Math.abs(getMyChar().cy - mob4.y);
				int num40 = (num38 <= num39) ? num39 : num38;
				if ((mob4.templateId != 97 || getMyChar().cTypePk != PK_PHE1) && (mob4.templateId != 96 || getMyChar().cTypePk != PK_PHE2) && (mob4.templateId != 98 || getMyChar().cTypePk != PK_PHE1) && (mob4.templateId != 167 || getMyChar().cTypePk != PK_PHE1) && (mob4.templateId != 99 || getMyChar().cTypePk != PK_PHE2) && (mob4.templateId != 166 || getMyChar().cTypePk != PK_PHE2) && (mob4.templateId != 202 || mob4.status != 8 || mob4.isPaint()) && num2 <= mob4.x && mob4.x <= num3 && cmy <= mob4.y && mob4.y <= num4 && mob4.status != 0 && mob4.status != 1 && (mobFocus == null || num40 < array[0]))
				{
					mobFocus = mob4;
					array[0] = num40;
				}
			}
		}
		num2 = getMyChar().cx - 80;
		num3 = getMyChar().cx + 80;
		cmy = getMyChar().cy - 30;
		num4 = getMyChar().cy + 30;
		if (npcFocus != null && npcFocus.template.npcTemplateId == 13)
		{
			num2 = getMyChar().cx - 20;
			num3 = getMyChar().cx + 20;
			cmy = getMyChar().cy - 10;
			num4 = getMyChar().cy + 10;
		}
		if (npcFocus == null)
		{
			for (int num41 = 0; num41 < GameScr.vNpc.size(); num41++)
			{
				Npc npc3 = (Npc)GameScr.vNpc.elementAt(num41);
				if (npc3.statusMe == 15 || TileMap.typeMap == TileMap.MAP_DAUTRUONG)
				{
					continue;
				}
				int num42 = Math.abs(getMyChar().cx - npc3.cx);
				int num43 = Math.abs(getMyChar().cy - npc3.cy);
				int num44 = (num42 <= num43) ? num43 : num42;
				num2 = getMyChar().cx - 80;
				num3 = getMyChar().cx + 80;
				cmy = getMyChar().cy - 30;
				num4 = getMyChar().cy + 30;
				if (npc3.template.npcTemplateId == 13)
				{
					num2 = getMyChar().cx - 20;
					num3 = getMyChar().cx + 20;
					cmy = getMyChar().cy - 10;
					num4 = getMyChar().cy + 10;
				}
				if (num2 <= npc3.cx && npc3.cx <= num3 && cmy <= npc3.cy && npc3.cy <= num4 && (npcFocus == null || num44 < array[1]))
				{
					if (GameScr.isUseitemAuto && GameScr.auto == 1)
					{
						break;
					}
					npcFocus = npc3;
					array[1] = num44;
				}
			}
		}
		else
		{
			if (num2 <= npcFocus.cx && npcFocus.cx <= num3 && cmy <= npcFocus.cy && npcFocus.cy <= num4)
			{
				clearFocus(1);
				return;
			}
			deFocusNPC();
			for (int num45 = 0; num45 < GameScr.vNpc.size(); num45++)
			{
				Npc npc4 = (Npc)GameScr.vNpc.elementAt(num45);
				if (npc4.statusMe == 15 || TileMap.typeMap == TileMap.MAP_DAUTRUONG)
				{
					continue;
				}
				int num46 = Math.abs(getMyChar().cx - npc4.cx);
				int num47 = Math.abs(getMyChar().cy - npc4.cy);
				int num48 = (num46 <= num47) ? num47 : num46;
				num2 = getMyChar().cx - 80;
				num3 = getMyChar().cx + 80;
				cmy = getMyChar().cy - 30;
				num4 = getMyChar().cy + 30;
				if (npc4.template.npcTemplateId == 13)
				{
					num2 = getMyChar().cx - 20;
					num3 = getMyChar().cx + 20;
					cmy = getMyChar().cy - 10;
					num4 = getMyChar().cy + 10;
				}
				if (num2 <= npc4.cx && npc4.cx <= num3 && cmy <= npc4.cy && npc4.cy <= num4 && (npcFocus == null || num48 < array[1]))
				{
					if (GameScr.isUseitemAuto && GameScr.auto == 1)
					{
						break;
					}
					npcFocus = npc4;
					array[1] = num48;
				}
			}
		}
		if (charFocus == null)
		{
			for (int num49 = 0; num49 < GameScr.vCharInMap.size(); num49++)
			{
				Char char3 = (Char)GameScr.vCharInMap.elementAt(num49);
				if (!char3.isNhanbanz() && char3.statusMe != 15 && !char3.isInvisible && char3.charID < -1 && wdx == 0 && wdy == 0 && char3.statusMe != 14 && char3.statusMe != 5)
				{
					int num50 = Math.abs(getMyChar().cx - char3.cx);
					int num51 = Math.abs(getMyChar().cy - char3.cy);
					int num52 = (num50 <= num51) ? num51 : num50;
					if (num2 <= char3.cx && char3.cx <= num3 && cmy <= char3.cy && char3.cy <= num4 && (charFocus == null || num52 < array[2]))
					{
						charFocus = char3;
						array[2] = num52;
					}
				}
			}
		}
		else
		{
			if (num2 <= charFocus.cx && charFocus.cx <= num3 && cmy <= charFocus.cy && charFocus.cy <= num4 && charFocus.statusMe != 15 && !charFocus.isInvisible)
			{
				clearFocus(2);
				return;
			}
			charFocus = null;
			for (int num53 = 0; num53 < GameScr.vCharInMap.size(); num53++)
			{
				Char char4 = (Char)GameScr.vCharInMap.elementAt(num53);
				if (!char4.isNhanbanz() && char4.statusMe != 15 && !char4.isInvisible && char4.charID < 0 && wdx == 0 && wdy == 0 && char4.statusMe != 14 && char4.statusMe != 5)
				{
					int num54 = Math.abs(getMyChar().cx - char4.cx);
					int num55 = Math.abs(getMyChar().cy - char4.cy);
					int num56 = (num54 <= num55) ? num55 : num54;
					if (num2 <= char4.cx && char4.cx <= num3 && cmy <= char4.cy && char4.cy <= num4 && (charFocus == null || num56 < array[2]))
					{
						charFocus = char4;
						array[2] = num56;
					}
				}
			}
		}
		int num57 = -1;
		for (int num58 = 0; num58 < array.Length; num58++)
		{
			if (num57 == -1)
			{
				if (array[num58] != -1)
				{
					num57 = num58;
				}
			}
			else if (array[num58] < array[num57] && array[num58] != -1)
			{
				num57 = num58;
			}
		}
		if (GameScr.isUseitemAuto && GameScr.auto == 1 && !GameScr.gI().lockAutoMove)
		{
			GameScr.updateAutoMovetoMob();
		}
		clearFocus(num57);
	}

	public void clearFocus(int index)
	{
		switch (index)
		{
		case 0:
			deFocusNPC();
			charFocus = null;
			itemFocus = null;
			break;
		case 1:
			mobFocus = null;
			charFocus = null;
			itemFocus = null;
			break;
		case 2:
			mobFocus = null;
			deFocusNPC();
			itemFocus = null;
			break;
		case 3:
			mobFocus = null;
			deFocusNPC();
			charFocus = null;
			break;
		}
	}

	public void findNextFocusByKey()
	{
		if (charFocus != null && charFocus.isNhanbanz())
		{
			charFocus = null;
		}
		if (getMyChar().skillPaint != null || getMyChar().arr != null)
		{
			return;
		}
		int num = 0;
		if (nClass.classId == 0 || nClass.classId == 1 || nClass.classId == 3 || nClass.classId == 5)
		{
			num = 40;
		}
		focus.removeAllElements();
		int num2 = 0;
		int num3 = GameScr.cmx + 10;
		int num4 = GameScr.cmx + GameCanvas.w - 10;
		int num5 = GameScr.cmy + 10;
		int num6 = GameScr.cmy + GameScr.gH;
		if (TileMap.typeMap == TileMap.MAP_CHIENTRUONG || TileMap.mapID == 111)
		{
			if (TileMap.mapID == 98 || TileMap.mapID == 104)
			{
				for (int i = 0; i < GameScr.vCharInMap.size(); i++)
				{
					Char @char = (Char)GameScr.vCharInMap.elementAt(i);
					if (!@char.isNhanbanz() && @char.statusMe != 15 && !@char.isInvisible && num3 <= @char.cx && @char.cx <= num4 && num5 <= @char.cy && @char.cy <= num6)
					{
						focus.addElement(@char);
						if (charFocus != null && @char.Equals(charFocus))
						{
							num2 = focus.size();
						}
					}
				}
			}
			else
			{
				for (int j = 0; j < GameScr.vCharInMap.size(); j++)
				{
					Char char2 = (Char)GameScr.vCharInMap.elementAt(j);
					if (char2.isNhanbanz() || char2.statusMe == 15 || char2.isInvisible || num3 > char2.cx || char2.cx > num4 || num5 > char2.cy || char2.cy > num6)
					{
						continue;
					}
					if (TileMap.mapID != 111)
					{
						if (char2.cTypePk != getMyChar().cTypePk && char2.statusMe != 14 && char2.statusMe != 5)
						{
							focus.addElement(char2);
							if (charFocus != null && char2.Equals(charFocus))
							{
								num2 = focus.size();
							}
						}
					}
					else if (myChar.cTypePk == 0)
					{
						focus.addElement(char2);
						if (charFocus != null && char2.Equals(charFocus))
						{
							num2 = focus.size();
						}
					}
					else if (myChar.nClass.classId == 6)
					{
						if (myChar.cTypePk == char2.cTypePk)
						{
							if (char2.statusMe == 14 || char2.statusMe == 5)
							{
								focus.addElement(char2);
								if (charFocus != null && char2.Equals(charFocus))
								{
									num2 = focus.size();
								}
							}
						}
						else if ((myChar.cTypePk != PK_PHE1 || char2.cTypePk == PK_PHE2) && (myChar.cTypePk != PK_PHE2 || char2.cTypePk == PK_PHE1) && char2.statusMe != 14 && char2.statusMe != 5)
						{
							focus.addElement(char2);
							if (charFocus != null && char2.Equals(charFocus))
							{
								num2 = focus.size();
							}
						}
					}
					else if ((myChar.cTypePk != PK_PHE1 || char2.cTypePk == PK_PHE2) && (myChar.cTypePk != PK_PHE2 || char2.cTypePk == PK_PHE1) && char2.statusMe != 14 && char2.statusMe != 5)
					{
						focus.addElement(char2);
						if (charFocus != null && char2.Equals(charFocus))
						{
							num2 = focus.size();
						}
					}
				}
			}
			for (int k = 0; k < GameScr.vItemMap.size(); k++)
			{
				ItemMap itemMap = (ItemMap)GameScr.vItemMap.elementAt(k);
				if (num3 <= itemMap.x && itemMap.x <= num4 && num5 <= itemMap.y && itemMap.y <= num6)
				{
					focus.addElement(itemMap);
					if (itemFocus != null && itemMap.Equals(itemFocus))
					{
						num2 = focus.size();
					}
				}
			}
			for (int l = 0; l < GameScr.vMob.size(); l++)
			{
				Mob mob = (Mob)GameScr.vMob.elementAt(l);
				if ((mob.templateId != 97 || getMyChar().cTypePk != PK_PHE1) && (mob.templateId != 96 || getMyChar().cTypePk != PK_PHE2) && (mob.templateId != 98 || getMyChar().cTypePk != PK_PHE1) && (mob.templateId != 167 || getMyChar().cTypePk != PK_PHE1) && (mob.templateId != 99 || getMyChar().cTypePk != PK_PHE2) && (mob.templateId != 166 || getMyChar().cTypePk != PK_PHE2) && mob.status != 1 && mob.status != 0 && num3 <= mob.x && mob.x <= num4 && num5 <= mob.y && mob.y <= num6)
				{
					focus.addElement(mob);
					if (mobFocus != null && mob.Equals(mobFocus))
					{
						num2 = focus.size();
					}
				}
			}
			for (int m = 0; m < GameScr.vNpc.size(); m++)
			{
				Npc npc = (Npc)GameScr.vNpc.elementAt(m);
				if (npc.statusMe != 15 && num3 <= npc.cx && npc.cx <= num4 && num5 <= npc.cy && npc.cy <= num6)
				{
					focus.addElement(npc);
					if (npcFocus != null && npc.Equals(npcFocus))
					{
						num2 = focus.size();
					}
				}
			}
			if (focus.size() > 0)
			{
				if (num2 >= focus.size())
				{
					num2 = 0;
				}
				if (focus.elementAt(num2) is Char)
				{
					mobFocus = null;
					deFocusNPC();
					charFocus = (Char)focus.elementAt(num2);
					itemFocus = null;
					isManualFocus = true;
				}
				else if (focus.elementAt(num2) is Npc)
				{
					mobFocus = null;
					deFocusNPC();
					npcFocus = (Npc)focus.elementAt(num2);
					charFocus = null;
					itemFocus = null;
					isManualFocus = true;
				}
				else if (focus.elementAt(num2) is Mob)
				{
					mobFocus = (Mob)focus.elementAt(num2);
					deFocusNPC();
					charFocus = null;
					itemFocus = null;
					isManualFocus = true;
				}
				else if (focus.elementAt(num2) is ItemMap)
				{
					mobFocus = null;
					deFocusNPC();
					charFocus = null;
					itemFocus = (ItemMap)focus.elementAt(num2);
					isManualFocus = true;
				}
			}
			else
			{
				mobFocus = null;
				deFocusNPC();
				charFocus = null;
				itemFocus = null;
				isManualFocus = false;
			}
			return;
		}
		for (int n = 0; n < GameScr.vItemMap.size(); n++)
		{
			ItemMap itemMap2 = (ItemMap)GameScr.vItemMap.elementAt(n);
			if (num3 <= itemMap2.x && itemMap2.x <= num4 && num5 <= itemMap2.y && itemMap2.y <= num6)
			{
				focus.addElement(itemMap2);
				if (itemFocus != null && itemMap2.Equals(itemFocus))
				{
					num2 = focus.size();
				}
			}
		}
		for (int num7 = 0; num7 < GameScr.vMob.size(); num7++)
		{
			Mob mob2 = (Mob)GameScr.vMob.elementAt(num7);
			if ((mob2.templateId != 97 || getMyChar().cTypePk != PK_PHE1) && (mob2.templateId != 96 || getMyChar().cTypePk != PK_PHE2) && (mob2.templateId != 98 || getMyChar().cTypePk != PK_PHE1) && (mob2.templateId != 167 || getMyChar().cTypePk != PK_PHE1) && (mob2.templateId != 99 || getMyChar().cTypePk != PK_PHE2) && (mob2.templateId != 166 || getMyChar().cTypePk != PK_PHE2) && (mob2.templateId != 202 || mob2.status != 8 || mob2.isPaint()) && mob2.status != 1 && mob2.status != 0 && num3 <= mob2.x && mob2.x <= num4 && num5 <= mob2.y && mob2.y <= num6)
			{
				focus.addElement(mob2);
				if (mobFocus != null && mob2.Equals(mobFocus))
				{
					num2 = focus.size();
				}
			}
		}
		for (int num8 = 0; num8 < GameScr.vNpc.size(); num8++)
		{
			Npc npc2 = (Npc)GameScr.vNpc.elementAt(num8);
			if (npc2.statusMe != 15 && num3 <= npc2.cx && npc2.cx <= num4 && num5 <= npc2.cy && npc2.cy <= num6)
			{
				focus.addElement(npc2);
				if (npcFocus != null && npc2.Equals(npcFocus))
				{
					num2 = focus.size();
				}
			}
		}
		for (int num9 = 0; num9 < GameScr.vCharInMap.size(); num9++)
		{
			Char char3 = (Char)GameScr.vCharInMap.elementAt(num9);
			if (!char3.isNhanbanz() && char3.statusMe != 15 && !char3.isInvisible && num3 <= char3.cx && char3.cx <= num4 && num5 <= char3.cy && char3.cy <= num6)
			{
				focus.addElement(char3);
				if (charFocus != null && char3.Equals(charFocus))
				{
					num2 = focus.size();
				}
			}
		}
		if (focus.size() > 0)
		{
			if (num2 >= focus.size())
			{
				num2 = 0;
			}
			if (focus.elementAt(num2) is Mob)
			{
				mobFocus = (Mob)focus.elementAt(num2);
				deFocusNPC();
				charFocus = null;
				itemFocus = null;
				isManualFocus = true;
			}
			else if (focus.elementAt(num2) is Npc)
			{
				mobFocus = null;
				deFocusNPC();
				npcFocus = (Npc)focus.elementAt(num2);
				charFocus = null;
				itemFocus = null;
				isManualFocus = true;
			}
			else if (focus.elementAt(num2) is Char)
			{
				mobFocus = null;
				deFocusNPC();
				charFocus = (Char)focus.elementAt(num2);
				itemFocus = null;
				isManualFocus = true;
			}
			else if (focus.elementAt(num2) is ItemMap)
			{
				mobFocus = null;
				deFocusNPC();
				charFocus = null;
				itemFocus = (ItemMap)focus.elementAt(num2);
				isManualFocus = true;
			}
		}
		else
		{
			mobFocus = null;
			deFocusNPC();
			charFocus = null;
			itemFocus = null;
			isManualFocus = false;
		}
	}

	public void deFocusNPC()
	{
		if (me && npcFocus != null)
		{
			npcFocus.chatPopup = null;
			npcFocus = null;
		}
	}

	public void updateCharInBridge()
	{
		if (!GameCanvas.lowGraphic && !Main.isIpod && mGraphics.zoomLevel != 1)
		{
			if (TileMap.tileTypeAt(cx, cy + 1, TileMap.T_BRIDGE))
			{
				TileMap.setTileTypeAtPixel(cx, cy + 1, TileMap.T_DOWN1PIXEL);
				TileMap.setTileTypeAtPixel(cx, cy - 2, TileMap.T_DOWN1PIXEL);
			}
			if (TileMap.tileTypeAt(cx - TileMap.size, cy + 1, TileMap.T_DOWN1PIXEL))
			{
				TileMap.killTileTypeAt(cx - TileMap.size, cy + 1, TileMap.T_DOWN1PIXEL);
				TileMap.killTileTypeAt(cx - TileMap.size, cy - 2, TileMap.T_DOWN1PIXEL);
			}
			if (TileMap.tileTypeAt(cx + TileMap.size, cy + 1, TileMap.T_DOWN1PIXEL))
			{
				TileMap.killTileTypeAt(cx + TileMap.size, cy + 1, TileMap.T_DOWN1PIXEL);
				TileMap.killTileTypeAt(cx + TileMap.size, cy - 2, TileMap.T_DOWN1PIXEL);
			}
		}
	}

	public static void sort(int[] data)
	{
		int num = 5;
		for (int i = 0; i < num - 1; i++)
		{
			for (int j = i + 1; j < num; j++)
			{
				if (data[i] < data[j])
				{
					int num2 = data[j];
					data[j] = data[i];
					data[i] = num2;
				}
			}
		}
	}

	public static bool setInsc(int cmX, int cmWx, int x, int cmy, int cmyH, int y)
	{
		if (x > cmWx || x < cmX || y > cmyH || y < cmy)
		{
			return false;
		}
		return true;
	}

	public void itemMonToBag(Message msg)
	{
		try
		{
			readParam(msg, "itemMonToBag");
			getMyChar().eff5BuffHp = msg.reader().readShort();
			getMyChar().eff5BuffMp = msg.reader().readShort();
			int num = msg.reader().readUnsignedByte();
			Item item = arrItemMounts[num];
			item.typeUI = 3;
			arrItemMounts[num] = null;
			item.indexUI = msg.reader().readUnsignedByte();
			arrItemBag[item.indexUI] = item;
			if (num == 4)
			{
				isWolf = (isMoto = (isMotoBehind = false));
			}
			GameScr.isPaintItemInfo = false;
			GameScr.gI().setLCR();
		}
		catch (Exception)
		{
		}
	}

	public void itemBodyToBag(Message msg)
	{
		try
		{
			readParam(msg, "itemBodyToBag");
			getMyChar().eff5BuffHp = msg.reader().readShort();
			getMyChar().eff5BuffMp = msg.reader().readShort();
			Item item = arrItemBody[msg.reader().readUnsignedByte()];
			item.typeUI = 3;
			if (item.indexUI == 1)
			{
				setDefaultWeapon();
			}
			else if (item.indexUI == 2)
			{
				setDefaultBody();
			}
			else if (item.indexUI == 6)
			{
				setDefaultLeg();
			}
			arrItemBody[item.indexUI] = null;
			item.indexUI = msg.reader().readUnsignedByte();
			getMyChar().head = msg.reader().readShort();
			arrItemBag[item.indexUI] = item;
			GameScr.gI().left = (GameScr.gI().center = null);
			GameScr.gI().setLCR();
		}
		catch (Exception ex)
		{
			Out.println(ex.Message + ex.StackTrace);
			Out.println("Char.itemBodyToBag()");
		}
	}

	public void itemBagToBox(Message msg)
	{
		try
		{
			int num = msg.reader().readUnsignedByte();
			int num2 = msg.reader().readUnsignedByte();
			Item item = arrItemBag[num];
			if (item != null)
			{
				if (item.template.type == 16)
				{
					GameScr.hpPotion -= item.quantity;
				}
				if (item.template.type == 17)
				{
					GameScr.mpPotion -= item.quantity;
				}
				arrItemBag[num] = null;
				if (arrItemBox[num2] == null)
				{
					item.indexUI = num2;
					item.typeUI = 4;
					arrItemBox[num2] = item;
				}
				else
				{
					arrItemBox[num2].quantity += item.quantity;
				}
			}
			GameScr.gI().left = (GameScr.gI().center = null);
			GameScr.gI().updateKeyBuyItemUI();
		}
		catch (Exception ex)
		{
			Out.println(ex.Message + ex.StackTrace);
			Out.println("Char.itemBagToBox()");
		}
	}

	public void itemBoxToBag(Message msg)
	{
		try
		{
			int num = msg.reader().readUnsignedByte();
			int num2 = msg.reader().readUnsignedByte();
			Item item = arrItemBox[num];
			if (item != null)
			{
				if (item.template.type == 16)
				{
					GameScr.hpPotion += item.quantity;
				}
				if (item.template.type == 17)
				{
					GameScr.mpPotion += item.quantity;
				}
				arrItemBox[num] = null;
				if (arrItemBag[num2] == null)
				{
					item.indexUI = num2;
					item.typeUI = 3;
					arrItemBag[num2] = item;
				}
				else
				{
					arrItemBag[num2].quantity += item.quantity;
				}
			}
			GameScr.gI().left = (GameScr.gI().center = null);
			GameScr.gI().updateKeyBuyItemUI();
		}
		catch (Exception ex)
		{
			Out.println(ex.Message + ex.StackTrace);
			Out.println("Char.itemBoxToBag()");
		}
	}

	public void crystalCollect(Message msg, bool isCoin)
	{
		try
		{
			for (int i = 0; i < GameScr.arrItemUpPeal.Length; i++)
			{
				GameScr.arrItemUpPeal[i] = null;
			}
			int num = msg.reader().readByte();
			Item item = new Item();
			item.typeUI = 3;
			item.indexUI = msg.reader().readByte();
			item.template = ItemTemplates.get(msg.reader().readShort());
			item.isLock = msg.reader().readBoolean();
			item.isExpires = msg.reader().readBoolean();
			item.quantity = 1;
			if (isCoin)
			{
				getMyChar().xu = msg.reader().readInt();
			}
			else
			{
				getMyChar().yen = msg.reader().readInt();
				try
				{
					getMyChar().xu = msg.reader().readInt();
				}
				catch (Exception)
				{
				}
			}
			GameScr.arrItemUpPeal[0] = item;
			GameScr.effUpok = GameScr.efs[53];
			GameScr.indexEff = 0;
			GameScr.gI().left = (GameScr.gI().center = null);
			GameScr.gI().updateCommandForUI();
			GameCanvas.endDlg();
			if (num == 1)
			{
				InfoMe.addInfo(mResources.UPGRADE_SUCCESS + " " + item.template.name);
			}
			else
			{
				InfoMe.addInfo(mResources.UPGRADE + " " + ItemTemplates.get((short)(item.template.id + 1)).name + " " + mResources.UPGRADE_FAIL + " " + item.template.name, 25, mFont.tahoma_7_red);
			}
		}
		catch (Exception ex2)
		{
			Out.println(ex2.Message + ex2.StackTrace);
			Out.println("Char.itemBagToBox()");
		}
	}

	public void kickOption(Item item, int maxKick)
	{
		int num = 0;
		if (item == null || item.options == null)
		{
			return;
		}
		for (int i = 0; i < item.options.size(); i++)
		{
			ItemOption itemOption = (ItemOption)item.options.elementAt(i);
			itemOption.active = 0;
			if (itemOption.optionTemplate.type == 2)
			{
				if (num < maxKick)
				{
					itemOption.active = 1;
					num++;
				}
			}
			else if (itemOption.optionTemplate.type == 3 && item.upgrade >= 4)
			{
				itemOption.active = 1;
			}
			else if (itemOption.optionTemplate.type == 4 && item.upgrade >= 8)
			{
				itemOption.active = 1;
			}
			else if (itemOption.optionTemplate.type == 5 && item.upgrade >= 12)
			{
				itemOption.active = 1;
			}
			else if (itemOption.optionTemplate.type == 6 && item.upgrade >= 14)
			{
				itemOption.active = 1;
			}
			else if (itemOption.optionTemplate.type == 7 && item.upgrade >= 16)
			{
				itemOption.active = 1;
			}
		}
	}

	public void updateKickOption()
	{
		int num = 2;
		int num2 = 2;
		int num3 = 2;
		if (arrItemBody[0] == null)
		{
			num--;
		}
		if (arrItemBody[6] == null)
		{
			num--;
		}
		if (arrItemBody[5] == null)
		{
			num--;
		}
		kickOption(arrItemBody[0], num);
		kickOption(arrItemBody[6], num);
		kickOption(arrItemBody[5], num);
		if (arrItemBody[2] == null)
		{
			num2--;
		}
		if (arrItemBody[8] == null)
		{
			num2--;
		}
		if (arrItemBody[7] == null)
		{
			num2--;
		}
		kickOption(arrItemBody[2], num2);
		kickOption(arrItemBody[8], num2);
		kickOption(arrItemBody[7], num2);
		if (arrItemBody[4] == null)
		{
			num3--;
		}
		if (arrItemBody[3] == null)
		{
			num3--;
		}
		if (arrItemBody[9] == null)
		{
			num3--;
		}
		if (arrItemBody[1] != null)
		{
			if (arrItemBody[1].sys == getSys())
			{
				if (arrItemBody[1].options != null)
				{
					for (int i = 0; i < arrItemBody[1].options.size(); i++)
					{
						ItemOption itemOption = (ItemOption)arrItemBody[1].options.elementAt(i);
						if (itemOption.optionTemplate.type == 2)
						{
							itemOption.active = 1;
						}
					}
				}
			}
			else if (arrItemBody[1].options != null)
			{
				for (int j = 0; j < arrItemBody[1].options.size(); j++)
				{
					ItemOption itemOption2 = (ItemOption)arrItemBody[1].options.elementAt(j);
					if (itemOption2.optionTemplate.type == 2)
					{
						itemOption2.active = 0;
					}
				}
			}
		}
		kickOption(arrItemBody[4], num3);
		kickOption(arrItemBody[3], num3);
		kickOption(arrItemBody[9], num3);
	}

	public void doInjure(int HPShow, int MPShow, bool isBoss, int idBoss)
	{
		cHP -= HPShow;
		cMP -= MPShow;
		if (!me)
		{
			cHP = cHpNew;
		}
		if (cHP < 0)
		{
			cHP = 0;
		}
		if (cHP < 1 && statusMe != 14 && statusMe != 5)
		{
			cHP = 1;
		}
		if (HPShow <= 0)
		{
			if (me)
			{
				GameScr.startFlyText(string.Empty, cx, cy - ch, 0, -2, mFont.MISS_ME);
			}
			else
			{
				GameScr.startFlyText(string.Empty, cx, cy - ch, 0, -2, mFont.MISS);
			}
		}
		else
		{
			GameScr.startFlyText("-" + HPShow, cx, cy - ch, 0, -2, mFont.RED);
		}
		if (HPShow > 0)
		{
			isInjure = 4;
		}
		if (isBoss)
		{
			switch (idBoss)
			{
			case 114:
				ServerEffect.addServerEffect(32, cx, cy - chh, 1);
				break;
			case 115:
				ServerEffect.addServerEffect(85, cx, cy, 1);
				break;
			case 139:
				GameScr.shaking = 1;
				GameScr.count = 0;
				ServerEffect.addServerEffect(91, this, 2);
				break;
			case 144:
				ServerEffect.addServerEffect(91, this, 1);
				break;
			}
		}
		else
		{
			callEff(49);
		}
	}

	public void doInjure()
	{
		isInjure = 4;
		callEff(49);
	}

	public void startDie(short toX, short toY)
	{
		if (me)
		{
			isLockKey = true;
			for (int i = 0; i < GameScr.vCharInMap.size(); i++)
			{
				Char @char = (Char)GameScr.vCharInMap.elementAt(i);
				@char.killCharId = -9999;
			}
		}
		statusMe = 5;
		cp2 = toX;
		cp3 = toY;
		cp1 = 0;
		cHP = 0;
		testCharId = -9999;
		killCharId = -9999;
	}

	public void waitToDie(short toX, short toY)
	{
		wdx = toX;
		wdy = toY;
	}

	public void changeStatusStand()
	{
		timeBocdau = 0;
		statusMe = 1;
		timeSummon = mSystem.currentTimeMillis();
	}

	public void liveFromDead()
	{
		cHP = cMaxHP;
		cMP = cMaxMP;
		changeStatusStand();
		cp1 = (cp2 = (cp3 = 0));
		ServerEffect.addServerEffect(20, this, 2);
		GameScr.gI().center = null;
	}

	public bool doUsePotion(int type)
	{
		if (arrItemBag == null)
		{
			return false;
		}
		for (int i = 0; i < arrItemBag.Length; i++)
		{
			if (arrItemBag[i] != null && arrItemBag[i].template.type == type && arrItemBag[i].template.level <= myChar.clevel)
			{
				Service.gI().useItem(i);
				return true;
			}
		}
		return false;
	}

	public bool isLang()
	{
		if (TileMap.mapID == 1 || TileMap.mapID == 27 || TileMap.mapID == 72 || TileMap.mapID == 10 || TileMap.mapID == 17 || TileMap.mapID == 22 || TileMap.mapID == 32 || TileMap.mapID == 38 || TileMap.mapID == 43 || TileMap.mapID == 48)
		{
			return true;
		}
		return false;
	}

	public bool isMeCanAttackOtherPlayer(Char cAtt)
	{
		if (cAtt == null || getMyChar().myskill == null || getMyChar().myskill.template.type == 2 || getMyChar().myskill.template.type == 3 || (getMyChar().myskill.template.type == 4 && cAtt.statusMe != 14 && cAtt.statusMe != 5))
		{
			return false;
		}
		return ((((getMyChar().cTypePk == PK_PHE1 && cAtt.cTypePk == PK_PHE2) || (getMyChar().cTypePk == PK_PHE2 && cAtt.cTypePk == PK_PHE1)) && !getMyChar().isTeam(cAtt) && !isLang()) || (cAtt.cTypePk == 3 && !getMyChar().isTeam(cAtt) && !isLang()) || (getMyChar().cTypePk == 3 && !getMyChar().isTeam(cAtt) && !isLang()) || (getMyChar().cTypePk == PK_NHOM && cAtt.cTypePk == PK_NHOM && !getMyChar().isTeam(cAtt) && !isLang()) || (getMyChar().testCharId >= 0 && getMyChar().testCharId == cAtt.charID) || (getMyChar().killCharId >= 0 && getMyChar().killCharId == cAtt.charID && !isLang()) || (cAtt.killCharId >= 0 && cAtt.killCharId == getMyChar().charID && !isLang())) && cAtt.statusMe != 14 && cAtt.statusMe != 5;
	}

	public bool isTeam(Char c)
	{
		for (int i = 0; i < GameScr.vParty.size(); i++)
		{
			Party party = (Party)GameScr.vParty.elementAt(i);
			if (c.charID == party.charId)
			{
				return true;
			}
		}
		return false;
	}

	public void clearTask()
	{
		getMyChar().callEffTask(21);
		getMyChar().taskMaint = null;
		for (int i = 0; i < getMyChar().arrItemBag.Length; i++)
		{
			if (getMyChar().arrItemBag[i] != null && (getMyChar().arrItemBag[i].template.type == 25 || getMyChar().arrItemBag[i].template.type == 23 || getMyChar().arrItemBag[i].template.type == 24))
			{
				getMyChar().arrItemBag[i] = null;
			}
		}
		Npc.clearEffTask();
	}

	public static int getCT()
	{
		if (pointChienTruong >= 4000)
		{
			return 4;
		}
		if (pointChienTruong >= 1500)
		{
			return 3;
		}
		if (pointChienTruong >= 600)
		{
			return 2;
		}
		if (pointChienTruong >= 200)
		{
			return 1;
		}
		return 0;
	}

	private void updateEffectWolf()
	{
		tickEffWolf++;
		if (tickEffWolf > 5)
		{
			tickEffWolf = 0;
		}
	}

	private void updateEffwolfMove()
	{
		if (arrItemMounts[4].template.id != 443 || arrItemMounts[4].sys < 2)
		{
			return;
		}
		Effx = EffdefautX;
		Effy = EffdefautY;
		if (idWolfW[1] == 1737)
		{
			if (cdir != 1)
			{
				EffdefautY -= 5;
			}
			else
			{
				EffdefautY -= 5;
			}
		}
		Domsang o;
		Domsang o2;
		if (cdir != 1)
		{
			o = new Domsang(EffdefautX - 4, EffdefautY, 0);
			o2 = new Domsang(EffdefautX - 1, EffdefautY, 0);
		}
		else
		{
			o = new Domsang(EffdefautX + 4, EffdefautY, 0);
			o2 = new Domsang(EffdefautX + 1, EffdefautY, 0);
		}
		if (statusMe != 1)
		{
			vDomsang.addElement(o);
			vDomsang.addElement(o2);
		}
	}

	private void updateEffmotoMove()
	{
		if (arrItemMounts[4].template.id == 524 && arrItemMounts[4].sys >= 2)
		{
			Domsang o;
			Domsang o2;
			if (cdir != 1)
			{
				o = new Domsang(EffdefautX, EffdefautY, 1);
				o2 = new Domsang(EffdefautX1, EffdefautY1, 1);
			}
			else
			{
				o = new Domsang(EffdefautX, EffdefautY, 1);
				o2 = new Domsang(EffdefautX1, EffdefautY1, 1);
			}
			if ((statusMe == 2 || statusMe == 10) && GameCanvas.gameTick % 3 == 0)
			{
				vDomsang.addElement(o);
				vDomsang.addElement(o2);
			}
		}
	}

	public int[] geteffOngbo()
	{
		int[] result = null;
		if (isMoto && arrItemMounts[4].template.id == 485 && arrItemMounts[4].sys >= 3)
		{
			result = new int[3]
			{
				2094,
				2095,
				2096
			};
		}
		return result;
	}

	public int[] getEffmoto()
	{
		int[] result = null;
		if (isMoto)
		{
			result = new int[12]
			{
				2082,
				2082,
				2083,
				2083,
				2084,
				2084,
				2089,
				2089,
				2082,
				2082,
				2083,
				2083
			};
		}
		return result;
	}

	public int[] getEffwolf()
	{
		int[] result = null;
		if (isWolf)
		{
			result = new int[4]
			{
				2085,
				2086,
				2087,
				2088
			};
		}
		return result;
	}

	public bool isHumanz()
	{
		return isHuman;
	}

	public bool isNhanbanz()
	{
		return isNhanban;
	}

	public void paint_No(mGraphics g)
	{
	}

	public void update_No()
	{
	}
}
