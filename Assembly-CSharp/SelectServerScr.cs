using UnityEngine;

public class SelectServerScr : mScreen, IActionListener
{
	private int popupW;

	private int popupH;

	private int popupX;

	private int popupY;

	private static LanguageScr gI;

	private int indexRow = -1;

	public static bool isFromLogin;

	public static string[] menu;

	public static string uname;

	public static string pass;

	public static string unameChange = string.Empty;

	public static string passChange = string.Empty;

	public static Command cmdChoiMoi;

	public static Command cmdDoiTaiKhoan;

	public static Command cmdChoiTiep;

	public static Command cmdChonServer;

	public static Command[][] cmd;

	public bool isFAQ;

	public string listFAQ = string.Empty;

	public string titleFAQ;

	public string subtitleFAQ;

	public string randomResuft;

	public SelectServerScr()
	{
		GameCanvas.menu.menuSelectedItem = GameMidlet.serverST[6];
		GameMidlet.IP = GameMidlet.ipList[6];
		int num = 0;
		while (true)
		{
			if (num < GameMidlet.serverST.Length)
			{
				if (loadIndexServer() == GameMidlet.serverST[num])
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		GameCanvas.menu.menuSelectedItem = GameMidlet.serverST[num];
		GameMidlet.IP = GameMidlet.ipList[num];
	}

	public override void switchToMe()
	{
		if (RMS.loadRMSInt("isKiemduyet") == 0)
		{
			GameCanvas.isKiemduyet = true;
		}
		else
		{
			GameCanvas.isKiemduyet = false;
		}
		GameScr.gH = GameCanvas.h;
		if (GameCanvas.typeBg == 2)
		{
			GameCanvas.loadBG(0);
		}
		else
		{
			GameCanvas.loadBG(TileMap.bgID);
		}
		base.switchToMe();
		if (GameScr.instance != null)
		{
			GameScr.instance = null;
		}
		TileMap.bgID = (sbyte)(mSystem.currentTimeMillis() % 9);
		if (TileMap.bgID == 5 || TileMap.bgID == 6)
		{
			TileMap.bgID = 4;
		}
		GameScr.loadCamera(fullScreen: true);
		GameScr.cmx = 100;
		popupW = 170;
		popupH = 175;
		if (GameCanvas.w == 128 || GameCanvas.h <= 208)
		{
			popupW = 126;
			popupH = 160;
		}
		popupX = GameCanvas.w / 2 - popupW / 2;
		popupY = GameCanvas.h / 2 - popupH / 2;
		Debug.Log("popupX:" + popupX + ":" + popupY);
		if (GameCanvas.h <= 250)
		{
			popupY -= 10;
		}
		indexRow = -1;
		if (!GameCanvas.isTouch)
		{
			indexRow = 0;
		}
		if (cmdChoiMoi == null)
		{
			cmdChoiMoi = new Command((!GameCanvas.isTouch) ? mResources.OK : string.Empty, this, 1000, null);
			cmdDoiTaiKhoan = new Command((!GameCanvas.isTouch) ? mResources.OK : string.Empty, this, 1001, null);
			cmdChonServer = new Command((!GameCanvas.isTouch) ? mResources.OK : string.Empty, this, 1002, null);
			cmdChoiTiep = new Command((!GameCanvas.isTouch) ? mResources.OK : string.Empty, this, 1003, null);
			cmd = new Command[2][]
			{
				new Command[3]
				{
					cmdChoiMoi,
					cmdDoiTaiKhoan,
					cmdChonServer
				},
				new Command[4]
				{
					cmdChoiTiep,
					cmdChoiMoi,
					cmdDoiTaiKhoan,
					cmdChonServer
				}
			};
		}
		uname = RMS.loadRMSString("acc");
		pass = RMS.loadRMSString("pass");
		if (uname == null)
		{
			uname = string.Empty;
		}
		if (pass == null)
		{
			pass = string.Empty;
		}
		if ((uname == null || uname.Equals(string.Empty)) && unameChange.Equals(string.Empty))
		{
			menu = new string[3]
			{
				mResources.NEW_PLAY,
				mResources.CHANGE_ACC,
				mResources.SERVER
			};
		}
		else
		{
			menu = new string[4]
			{
				mResources.COUNTINUE_PLAY,
				mResources.NEW_PLAY,
				mResources.CHANGE_ACC,
				mResources.SERVER
			};
		}
		GameCanvas.menu.menuSelectedItem = GameMidlet.serverST[6];
		GameMidlet.IP = GameMidlet.ipList[6];
		for (int i = 0; i < GameMidlet.serverST.Length; i++)
		{
			if (loadIndexServer() == GameMidlet.serverST[i])
			{
				GameCanvas.menu.menuSelectedItem = GameMidlet.serverST[i];
				GameMidlet.IP = GameMidlet.ipList[i];
				break;
			}
		}
		if (RMS.loadRMSString("random") == null)
		{
			RMS.saveRMSString("random", randomNumberlist());
		}
		if (LoginScr.imgTitle == null)
		{
			if (Main.isAppTeam)
			{
				LoginScr.imgTitle = GameCanvas.loadImage("/tt1");
			}
			else
			{
				LoginScr.imgTitle = GameCanvas.loadImage("/tt");
			}
		}
	}

	public override void paint(mGraphics g)
	{
		g.setColor(0);
		g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
		GameCanvas.paintBGGameScr(g);
		g.drawImage(LoginScr.imgTitle, GameCanvas.hw - LoginScr.imgTitle.getWidth() / 2, popupY + 10 - LoginScr.imgTitle.getHeight() / 2, 0);
		if (GameCanvas.menu.menuSelectedItem == -1)
		{
			GameCanvas.menu.menuSelectedItem = 0;
		}
		int num = popupY + 50;
		for (int i = 0; i < menu.Length; i++)
		{
			g.setColor(Paint.COLORDARK);
			g.fillRect(popupX + 10, num + i * 35, popupW - 20, 28);
			GameCanvas.paintz.paintFrameBorder(popupX + 10, num + i * 35, popupW - 20, 28, g);
			if (i == indexRow)
			{
				g.setColor(Paint.COLORLIGHT);
				g.fillRect(popupX + 10, num + i * 35, popupW - 20, 28);
				GameCanvas.paintz.paintFrameBorder(popupX + 10, num + i * 35, popupW - 20, 28, g);
			}
			if (i >= menu.Length)
			{
				continue;
			}
			if (uname.Equals(string.Empty) && unameChange.Equals(string.Empty))
			{
				if (i == 2)
				{
					mFont.tahoma_7b_white.drawString(g, menu[i] + mResources.servername[GameCanvas.menu.menuSelectedItem], popupX + popupW / 2, num + i * 35 + 6, 2);
				}
				else
				{
					mFont.tahoma_7b_white.drawString(g, menu[i], popupX + popupW / 2, num + i * 35 + 6, 2);
				}
				continue;
			}
			switch (i)
			{
			case 0:
				mFont.tahoma_7b_white.drawString(g, menu[i] + ((!unameChange.Equals(string.Empty)) ? (": " + unameChange) : ((!uname.StartsWith("tmpusr")) ? (": " + uname) : string.Empty)), popupX + popupW / 2, num + i * 35 + 6, 2);
				break;
			case 3:
				mFont.tahoma_7b_white.drawString(g, menu[i] + mResources.servername[GameCanvas.menu.menuSelectedItem], popupX + popupW / 2, num + i * 35 + 6, 2);
				break;
			default:
				mFont.tahoma_7b_white.drawString(g, menu[i], popupX + popupW / 2, num + i * 35 + 6, 2);
				break;
			}
		}
		if (GameCanvas.currentDialog == null)
		{
			GameCanvas.paintz.paintCmdBar(g, left, center, right);
		}
		base.paint(g);
	}

	private void saveLanguageID(int languageID)
	{
		RMS.saveRMSInt("indLanguage", languageID);
	}

	public override void update()
	{
		if (uname.Equals(string.Empty) && unameChange.Equals(string.Empty))
		{
			if (indexRow > -1 && indexRow < cmd[0].Length)
			{
				center = cmd[0][indexRow];
			}
		}
		else if (indexRow > -1 && indexRow < cmd[1].Length)
		{
			center = cmd[1][indexRow];
		}
		GameScr.cmx++;
		if (GameScr.cmx > GameCanvas.w * 3 + 100)
		{
			GameScr.cmx = 100;
		}
		base.update();
	}

	public override void updateKey()
	{
		if (GameCanvas.keyPressedz[2] || GameCanvas.keyPressedz[4])
		{
			indexRow--;
			if (indexRow < 0)
			{
				indexRow = menu.Length - 1;
			}
		}
		else if (GameCanvas.keyPressedz[8] || GameCanvas.keyPressedz[6])
		{
			indexRow++;
			if (indexRow > menu.Length - 1)
			{
				indexRow = 0;
			}
		}
		if (GameCanvas.isPointerJustRelease && GameCanvas.isPointerHoldIn(popupX + 10, popupY + 45, popupW - 10, 140))
		{
			if (GameCanvas.isPointerClick)
			{
				indexRow = (GameCanvas.py - (popupY + 45)) / 35;
			}
			if (uname.Equals(string.Empty) && unameChange.Equals(string.Empty))
			{
				if (indexRow > -1 && indexRow < cmd[0].Length)
				{
					cmd[0][indexRow].performAction();
				}
			}
			else if (indexRow > -1 && indexRow < cmd[1].Length)
			{
				cmd[1][indexRow].performAction();
			}
		}
		base.updateKey();
		GameCanvas.clearKeyPressed();
	}

	protected void doSelectServer()
	{
		MyVector myVector = new MyVector();
		if (LoginScr.indexLocal == 1)
		{
			myVector.addElement(new Command("LOCAL 44", this, 200041, null));
		}
		else if (LoginScr.indexLocal == 2)
		{
			myVector.addElement(new Command("LOCAL 46", this, 200042, null));
		}
		if (GameMidlet.indexClient == 0)
		{
			myVector.addElement(new Command(mResources.servername[GameMidlet.serverST[6]] + "(" + mResources.NEW + ")", this, 20006, null));
			myVector.addElement(new Command(mResources.servername[GameMidlet.serverST[1]], this, 20001, null));
			myVector.addElement(new Command(mResources.servername[GameMidlet.serverST[2]], this, 20002, null));
			myVector.addElement(new Command(mResources.servername[GameMidlet.serverST[3]], this, 20003, null));
			myVector.addElement(new Command(mResources.servername[GameMidlet.serverST[4]], this, 20004, null));
			GameCanvas.menu.startAt(myVector, 0);
			if (loadIndexServer() != -1 && !GameCanvas.isTouch)
			{
				GameCanvas.menu.menuSelectedItem = loadIndexServer();
			}
		}
		else
		{
			GameCanvas.menu.showMenu = false;
			GameMidlet.IP = GameMidlet.ipList[6];
			saveIndexServer(GameMidlet.serverST[6]);
		}
	}

	protected void saveIndexServer(int index)
	{
		RMS.saveRMSInt("indServer", index);
	}

	protected int loadIndexServer()
	{
		return RMS.loadRMSInt("indServer");
	}

	public void doViewFAQ()
	{
		if (!listFAQ.Equals(string.Empty) || !listFAQ.Equals(string.Empty))
		{
		}
		if (!Session_ME.connected)
		{
			isFAQ = true;
			GameCanvas.connect();
		}
		GameCanvas.startWaitDlg();
	}

	public static bool isVirtualAcc()
	{
		if (uname != null && (uname.StartsWith("tmpusr") || uname.Equals(string.Empty)))
		{
			return true;
		}
		return false;
	}

	public static string randomNumberlist()
	{
		string text = string.Empty;
		for (int i = 0; i < 12; i++)
		{
			string str = Res.random(0, 9).ToString();
			text += str;
		}
		return text;
	}

	public void perform(int idAction, object p)
	{
		switch (idAction)
		{
		case 1000:
			if (isVirtualAcc() && !uname.Equals(string.Empty))
			{
				GameCanvas.startYesNoDlg(mResources.NEW_ACC_ARLET, new Command(mResources.COUNTINUE_PLAY, this, 10001, null), new Command(mResources.NO, GameCanvas.instance, 8882, null));
				break;
			}
			doViewFAQ();
			Service.gI().login("-1", "12345", "1.4.8");
			break;
		case 10001:
			doViewFAQ();
			Service.gI().login("-1", "12345", "1.4.8");
			if (!unameChange.Equals(string.Empty))
			{
				uname = unameChange;
				pass = passChange;
				unameChange = string.Empty;
				passChange = string.Empty;
				RMS.saveRMSString("acc", uname);
				RMS.saveRMSString("pass", pass);
			}
			break;
		case 1001:
			if (isVirtualAcc() && !uname.Equals(string.Empty) && unameChange.Equals(string.Empty))
			{
				GameCanvas.startYesNoDlg(mResources.NEW_ACC_ARLET, new Command(mResources.COUNTINUE, this, 10004, null), new Command(mResources.NO, GameCanvas.instance, 8882, null));
			}
			else
			{
				GameCanvas.loginScr.switchToMe();
			}
			break;
		case 10004:
			GameCanvas.currentDialog = null;
			GameCanvas.loginScr.switchToMe();
			break;
		case 1002:
			doSelectServer();
			break;
		case 1003:
			doViewFAQ();
			if (!unameChange.Equals(string.Empty))
			{
				uname = unameChange;
				pass = passChange;
				unameChange = string.Empty;
				passChange = string.Empty;
				RMS.saveRMSString("acc", uname);
				RMS.saveRMSString("pass", pass);
			}
			Service.gI().login(uname, pass, "1.4.8");
			break;
		case 20001:
			GameCanvas.menu.showMenu = false;
			GameMidlet.IP = GameMidlet.ipList[1];
			GameMidlet.PORT = GameMidlet.portList[1];
			GameMidlet.serverLogin = GameMidlet.serverLoginList[1];
			saveIndexServer(GameMidlet.serverST[1]);
			break;
		case 20002:
			GameCanvas.menu.showMenu = false;
			GameMidlet.IP = GameMidlet.ipList[2];
			GameMidlet.PORT = GameMidlet.portList[2];
			GameMidlet.serverLogin = GameMidlet.serverLoginList[2];
			saveIndexServer(GameMidlet.serverST[2]);
			break;
		case 20003:
			GameCanvas.menu.showMenu = false;
			GameMidlet.IP = GameMidlet.ipList[3];
			GameMidlet.PORT = GameMidlet.portList[3];
			GameMidlet.serverLogin = GameMidlet.serverLoginList[3];
			saveIndexServer(GameMidlet.serverST[3]);
			break;
		case 20004:
			GameCanvas.menu.showMenu = false;
			GameMidlet.IP = GameMidlet.ipList[4];
			GameMidlet.PORT = GameMidlet.portList[4];
			GameMidlet.serverLogin = GameMidlet.serverLoginList[4];
			saveIndexServer(GameMidlet.serverST[4]);
			break;
		case 20005:
			GameCanvas.menu.showMenu = false;
			GameMidlet.IP = GameMidlet.ipList[5];
			GameMidlet.PORT = GameMidlet.portList[5];
			GameMidlet.serverLogin = GameMidlet.serverLoginList[5];
			saveIndexServer(GameMidlet.serverST[5]);
			break;
		case 20006:
			GameCanvas.menu.showMenu = false;
			GameMidlet.IP = GameMidlet.ipList[6];
			GameMidlet.PORT = GameMidlet.portList[6];
			GameMidlet.serverLogin = GameMidlet.serverLoginList[6];
			saveIndexServer(GameMidlet.serverST[6]);
			break;
		case 200041:
			GameCanvas.menu.showMenu = false;
			GameMidlet.IP = GameMidlet.ipList[6];
			GameMidlet.PORT = 14444;
			GameMidlet.serverLogin = GameMidlet.serverLoginList[6];
			saveIndexServer(GameMidlet.serverST[6]);
			break;
		case 200042:
			GameCanvas.menu.showMenu = false;
			GameMidlet.IP = GameMidlet.ipList[6];
			GameMidlet.PORT = 14444;
			GameMidlet.serverLogin = GameMidlet.serverLoginList[6];
			saveIndexServer(GameMidlet.serverST[6]);
			break;
		}
	}
}
