public class Party
{
	public int charId;

	public int level;

	public short iconId;

	public string name;

	public bool isLock;

	public Char c;

	public int size;

	public Party(sbyte classId, int level, string name, int size)
	{
		switch (classId)
		{
		case 0:
			iconId = 647;
			break;
		case 1:
			iconId = 1182;
			break;
		case 2:
			iconId = 1181;
			break;
		case 3:
			iconId = 643;
			break;
		case 4:
			iconId = 645;
			break;
		case 5:
			iconId = 676;
			break;
		case 6:
			iconId = 1119;
			break;
		}
		this.name = name;
		this.level = level;
		this.size = size;
	}

	public Party(int charId, sbyte classId, string name, bool isLock)
	{
		this.charId = charId;
		this.isLock = isLock;
		switch (classId)
		{
		case 0:
			iconId = 647;
			break;
		case 1:
			iconId = 1182;
			break;
		case 2:
			iconId = 1181;
			break;
		case 3:
			iconId = 643;
			break;
		case 4:
			iconId = 645;
			break;
		case 5:
			iconId = 676;
			break;
		case 6:
			iconId = 1119;
			break;
		}
		this.name = name;
		if (charId == Char.getMyChar().charID)
		{
			c = Char.getMyChar();
		}
		else
		{
			c = GameScr.findCharInMap(charId);
		}
	}

	public static void refreshAll()
	{
		for (int i = 0; i < GameScr.vParty.size(); i++)
		{
			Party party = (Party)GameScr.vParty.elementAt(i);
			if (party.charId != Char.getMyChar().charID)
			{
				party.c = GameScr.findCharInMap(party.charId);
			}
		}
	}

	public static void refresh(Char cc)
	{
		int num = 0;
		Party party;
		while (true)
		{
			if (num < GameScr.vParty.size())
			{
				party = (Party)GameScr.vParty.elementAt(num);
				if (party.charId == cc.charID)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		party.c = cc;
	}

	public static void clear(int charId)
	{
		int num = 0;
		Party party;
		while (true)
		{
			if (num < GameScr.vParty.size())
			{
				party = (Party)GameScr.vParty.elementAt(num);
				if (party.charId == charId)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		party.c = null;
	}
}
