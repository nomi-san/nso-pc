using System;

public class LoginScrEng : mScreen, IActionListener
{
	public TField tfUser;

	public TField tfPass;

	public TField tfRegPass;

	public TField tfEmail;

	public static LoginScrEng gI;

	public int focus;

	private int wC;

	private int yL;

	private int defYL;

	private bool isCheck;

	public bool isRes;

	private bool isAbout;

	private Command cmdLogin;

	private Command cmdCheck;

	private Command cmdFogetPass;

	private Command cmdRes;

	private Command cmdMenu;

	private Command cmdChangePass;

	public string listFAQ = string.Empty;

	public string titleFAQ;

	public string subtitleFAQ;

	private string numSupport = string.Empty;

	private string strUser;

	private string strPass;

	public static int indexLocal;

	public Image imgTitle = GameCanvas.loadImage("/tt");

	private int popupW;

	private int popupH;

	private int popupX;

	private int popupY;

	public static bool isAutoLogin;

	public static bool isPlayMusic;

	private int yt;

	private int yy = GameCanvas.hh - mScreen.ITEM_HEIGHT - 5;

	private string passRe = string.Empty;

	public bool isFAQ;

	private string[] currentTip;

	private int tipid = -1;

	private int v = 2;

	private int g;

	private int ylogo = -40;

	private int dir = 1;

	public static bool isLoggingIn;

	private string str1;

	private string str2;

	private string str3;

	public LoginScrEng()
	{
		gI = this;
		TileMap.bgID = (sbyte)(mSystem.getCurrentTimeMillis() % 9);
		if (TileMap.bgID == 5 || TileMap.bgID == 6)
		{
			TileMap.bgID = 4;
		}
		GameScr.loadCamera(fullScreen: true);
		GameScr.cmx = 100;
		if (GameCanvas.h > 200)
		{
			defYL = GameCanvas.hh - 80;
		}
		else
		{
			defYL = GameCanvas.hh - 65;
		}
		resetLogo();
		wC = GameCanvas.w - 30;
		if (wC < 70)
		{
			wC = 70;
		}
		if (wC > 99)
		{
			wC = 99;
		}
		initTF();
		isCheck = true;
		switch (RMS.loadRMSInt("check"))
		{
		case 1:
			isCheck = true;
			break;
		case 2:
			isCheck = false;
			break;
		}
		tfUser.setText(RMS.loadRMSString("acc"));
		tfPass.setText(RMS.loadRMSString("pass"));
		tfUser.setText(strUser);
		tfPass.setText(strPass);
		focus = 0;
		cmdLogin = new Command((GameCanvas.w <= 200) ? mResources.LOGIN2 : mResources.LOGIN1, this, 2000, null);
		cmdCheck = new Command(mResources.REMEMBER, this, 2001, null);
		cmdRes = new Command(mResources.REGISTER, this, 2002, null);
		cmdChangePass = new Command(mResources.CHANGEPASS, this, 2004, null);
		cmdFogetPass = new Command(mResources.FORGETPASS, this, 2005, null);
		left = (cmdMenu = new Command(mResources.MENU, this, 2003, null));
		if (GameCanvas.isTouch && GameCanvas.w >= 320)
		{
			center = null;
			right = cmdLogin;
		}
		else
		{
			center = cmdLogin;
			right = tfUser.cmdClear;
		}
	}

	public static LoginScrEng mgI()
	{
		return gI;
	}

	protected void saveLastServer(string serverInfo)
	{
		RMS.saveRMSString("lastServer", serverInfo);
	}

	public override void switchToMe()
	{
		int num = RMS.loadRMSInt("isSound");
		if (num < 0)
		{
			RMS.saveRMSInt("isSound", 1);
			Sound.isSound = true;
		}
		else
		{
			switch (num)
			{
			case 1:
				Sound.isSound = true;
				break;
			case 2:
				Sound.isSound = false;
				Sound.bMuzikDisable = true;
				break;
			}
		}
		if (RMS.loadRMSString("random") == null)
		{
			RMS.saveRMSString("random", SelectServerScr.randomNumberlist());
		}
		resetLogo();
		GameScr.gH = GameCanvas.h;
		GameCanvas.saveIDBg = -100;
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
		if (GameCanvas.menu != null)
		{
			GameCanvas.menu = new Menu();
		}
		GameCanvas.isGPRS = false;
		if (Main.isPC)
		{
			int num2 = RMS.loadRMSInt("mapKey");
			GameCanvas.isChangMapKey = ((num2 != 1) ? true : false);
			Out.println(num2 + " loai map key nao");
		}
		int num3 = RMS.loadRMSInt("isSoftKey");
		if (num3 <= 0)
		{
			RMS.saveRMSInt("isSoftKey", 1);
			GameScr.isTouchKey = true;
		}
		else
		{
			switch (num3)
			{
			case 1:
				GameScr.isTouchKey = true;
				break;
			case 2:
				GameScr.isTouchKey = false;
				break;
			}
		}
		if (isAutoLogin && !Main.isPC)
		{
			string text = RMS.loadRMSString("lastServer");
			if (text != null)
			{
				GameMidlet.IP = text;
			}
			doLogin();
		}
		Sound.stopAllBg();
		Sound.play(Sound.MLogin, 0.5f);
		if (Main.isPC)
		{
			focus = 0;
		}
	}

	private void initTF()
	{
		yt = GameCanvas.hh - mScreen.ITEM_HEIGHT - 5;
		if (GameCanvas.h <= 160)
		{
			yt = 20;
		}
		if (isRes && GameCanvas.h <= 240)
		{
			yt = 46;
		}
		tfUser = new TField();
		tfUser.name = mResources.USERNAME;
		tfUser.x = GameCanvas.hw - 20;
		tfUser.y = yt;
		tfUser.width = wC;
		tfUser.height = mScreen.ITEM_HEIGHT + 2;
		tfUser.isFocus = true;
		tfUser.setIputType(TField.INPUT_ALPHA_NUMBER_ONLY);
		tfPass = new TField();
		tfPass.name = mResources.PASSWORD;
		tfPass.x = GameCanvas.hw - 20;
		tfPass.y = (yt += 35);
		tfPass.width = wC;
		tfPass.height = mScreen.ITEM_HEIGHT + 2;
		tfPass.isFocus = false;
		tfPass.setIputType(TField.INPUT_TYPE_PASSWORD);
		tfRegPass = new TField();
		tfRegPass.name = mResources.REPASSWORD;
		tfRegPass.x = GameCanvas.hw - 20;
		tfRegPass.y = (yt += 35);
		tfRegPass.width = wC;
		tfRegPass.height = mScreen.ITEM_HEIGHT + 2;
		tfRegPass.isFocus = false;
		tfRegPass.setIputType(TField.INPUT_TYPE_PASSWORD);
		tfEmail = new TField();
		tfEmail.name = mResources.EMAIL;
		tfEmail.x = GameCanvas.hw - 20;
		tfEmail.y = (yt += 35);
		tfEmail.width = wC;
		tfEmail.height = mScreen.ITEM_HEIGHT + 2;
		tfEmail.isFocus = false;
		tfEmail.setIputType(TField.INPUT_TYPE_ANY);
	}

	public void updateTfWhenOpenKb()
	{
		int num = (GameCanvas.h / 2 - 60) / 2;
		if (TouchScreenKeyboard.visible)
		{
			if (yy != num)
			{
				if (num - yy >> 1 == 0)
				{
					yy = num;
				}
				else
				{
					yy += num - yy >> 1;
				}
			}
			tfUser.y = yy;
			tfPass.y = yy + 35;
			tfRegPass.y = yy + 70;
			yt = yy + 70;
		}
		else
		{
			yy = GameCanvas.hh - mScreen.ITEM_HEIGHT - 5;
			tfUser.y = yy;
			tfPass.y = (yy += 35);
			tfRegPass.y = (yy += 35);
			yt = yy;
		}
	}

	private void loadPass()
	{
		sbyte[] array = RMS.loadRMS("njlogin");
		if (array != null)
		{
			DataInputStream dataInputStream = new DataInputStream(array);
			try
			{
				if (isCheck)
				{
					tfUser.setText(dataInputStream.readUTF());
					tfUser.setOffset();
					tfPass.setText(dataInputStream.readUTF());
					tfPass.setOffset();
				}
				dataInputStream.close();
			}
			catch (Exception ex)
			{
				Out.println(ex.StackTrace);
			}
		}
	}

	public void savePass()
	{
		DataOutputStream dataOutputStream = new DataOutputStream();
		try
		{
			if (isCheck)
			{
				dataOutputStream.writeUTF(tfUser.getText());
				dataOutputStream.writeUTF(tfPass.getText());
			}
			else
			{
				dataOutputStream.writeUTF(string.Empty);
				dataOutputStream.writeUTF(string.Empty);
			}
			RMS.saveRMS("njlogin", dataOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception ex)
		{
			Out.println(ex.StackTrace);
		}
	}

	private void doAskForGPRS()
	{
		GameCanvas.msgdlg.setInfo(mResources.ASK_NETWORK, new Command("3G/Wifi", this, 3000, null), null, new Command("GPRS", this, 3001, null));
		GameCanvas.currentDialog = GameCanvas.msgdlg;
	}

	protected void doSetGPRS(bool isGPRS)
	{
		GameCanvas.isGPRS = isGPRS;
		RMS.saveRMSInt("isGPRS", isGPRS ? 1 : 2);
	}

	protected void doMenu()
	{
		MyVector myVector = new MyVector();
		myVector.addElement(new Command(mResources.NEWREGISTER, this, 1002, null));
		myVector.addElement(cmdChangePass);
		myVector.addElement(cmdFogetPass);
		myVector.addElement(new Command(mResources.CONFIG, this, 1006, null));
		myVector.addElement(new Command(mResources.ABOUT, this, 1007, null));
		myVector.addElement(new Command(mResources.FORUM, this, 1003, null));
		if (Main.isPC)
		{
			myVector.addElement(new Command(mResources.EXIT, GameCanvas.instance, 8885, null));
		}
		GameCanvas.menu.startAt(myVector, 0);
	}

	protected void doRegister()
	{
		if (tfUser.getText().Equals(string.Empty))
		{
			GameCanvas.startOKDlg(mResources.NOT_INPUT_USERNAME);
			return;
		}
		char[] array = tfUser.getText().ToCharArray();
		for (int i = 0; i < array.Length; i++)
		{
			if (!TField.setNormal(array[i]))
			{
				GameCanvas.startOKDlg(mResources.NOT_SPEC_CHARACTER);
				return;
			}
		}
		if (tfPass.getText().Equals(string.Empty))
		{
			GameCanvas.startOKDlg(mResources.NOT_INPUT_PASS1);
			return;
		}
		if (tfRegPass.getText().Equals(string.Empty))
		{
			GameCanvas.startOKDlg(mResources.NOT_INPUT_PASS2);
			return;
		}
		if (tfEmail.getText().Equals(string.Empty))
		{
			GameCanvas.startOKDlg(mResources.NOT_INPUT_EMAIL);
			return;
		}
		if (tfUser.getText().Length < 5)
		{
			GameCanvas.startOKDlg(mResources.USERNAME_LENGHT);
			return;
		}
		if (!tfPass.getText().Equals(tfRegPass.getText()))
		{
			GameCanvas.startOKDlg(mResources.WRONG_PASSWORD);
			return;
		}
		GameCanvas.msgdlg.setInfo(mResources.REGISTER_TEXT[0] + tfUser.getText() + mResources.REGISTER_TEXT[1], new Command(mResources.ACCEPT, this, 4000, null), null, new Command(mResources.NO, GameCanvas.instance, 8882, null));
		GameCanvas.currentDialog = GameCanvas.msgdlg;
	}

	protected void doRegister(string user)
	{
		isFAQ = false;
		GameMidlet.IP = GameMidlet.ipList[6];
		GameCanvas.startWaitDlg(mResources.CONNECTING);
		GameCanvas.connect();
		GameCanvas.startWaitDlg(mResources.REGISTERING);
		Service.gI().setClientType();
		passRe = tfPass.getText();
		if (!Main.isPC)
		{
			Service.gI().requestRegisterIME(user, tfPass.getText(), tfEmail.getText());
		}
		else
		{
			Service.gI().requestRegisterIME(user, tfPass.getText(), tfEmail.getText());
		}
	}

	protected void doChangePass(string user, string oldpass, string newpass)
	{
		isFAQ = false;
		GameMidlet.IP = GameMidlet.ipList[6];
		GameCanvas.startWaitDlg(mResources.CONNECTING);
		GameCanvas.connect();
		GameCanvas.startWaitDlg(mResources.PLEASEWAIT);
		Service.gI().requestChangePass(user, oldpass, newpass);
	}

	protected void doGetForgetPass(string user)
	{
		GameMidlet.inFoSMS = mResources.INFO_SEND_SMS_FOGETPASS;
		isFAQ = false;
		GameMidlet.IP = GameMidlet.ipList[6];
		GameCanvas.startWaitDlg(mResources.CONNECTING);
		GameCanvas.connect();
		GameCanvas.startWaitDlg(mResources.PLEASEWAIT);
		Service.gI().requestForgetPass(user);
	}

	protected void doGetForgetPassByIMEI(string user, string email)
	{
		GameMidlet.inFoSMS = mResources.INFO_SEND_SMS_FOGETPASS;
		isFAQ = false;
		GameMidlet.IP = GameMidlet.ipList[6];
		GameCanvas.startWaitDlg(mResources.CONNECTING);
		GameCanvas.connect();
		GameCanvas.startWaitDlg(mResources.PLEASEWAIT);
		Service.gI().requestForgetPassByIMEI(user, email, Main.IMEI);
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

	protected void doLogin()
	{
		tipid = GameCanvas.gameTick % mResources.tips[Main.isPC ? 1 : 0].Length;
		currentTip = mFont.tahoma_7_white.splitStrInLine(mResources.tips[Main.isPC ? 1 : 0][tipid], GameCanvas.w - ((!Main.isPC) ? 100 : 40));
		isFAQ = false;
		string text = tfUser.getText().ToLower().Trim();
		string text2 = tfPass.getText().ToLower().Trim();
		if (text.Equals("showimei"))
		{
			GameCanvas.startOKDlg("IMEI : " + Main.IMEI);
			return;
		}
		if (text.Equals("a") && text2.Equals("a"))
		{
			indexLocal = 1;
		}
		else if (text.Equals("b") && text2.Equals("b"))
		{
			indexLocal = 2;
		}
		if (text == null || text2 == null || false || text.Equals(string.Empty))
		{
			return;
		}
		if (text2.Equals(string.Empty))
		{
			focus = 1;
			tfUser.isFocus = false;
			tfPass.isFocus = true;
			right = tfPass.cmdClear;
			return;
		}
		if (!isAutoLogin)
		{
			GameCanvas.startWaitDlg(mResources.CONNECTING);
		}
		GameCanvas.connect();
		GameCanvas.startWaitDlg(mResources.LOGGING);
		Service.gI().setClientType();
		Service.gI().login(text, text2, "1.4.8");
		isLoggingIn = true;
		savePass(text, text2);
		focus = 0;
	}

	public void savePass(string user, string pass)
	{
		if (isCheck)
		{
			RMS.saveRMSInt("check", 1);
			savePass();
		}
		else
		{
			RMS.saveRMSInt("check", 2);
			savePass();
		}
	}

	public override void update()
	{
		GameScr.cmx++;
		if (GameScr.cmx > GameCanvas.w * 3 + 100)
		{
			GameScr.cmx = 100;
		}
		GameCanvas.debug("LGU1", 0);
		tfUser.update();
		tfPass.update();
		GameCanvas.debug("LGU2", 0);
		if (isRes)
		{
			tfRegPass.update();
			tfEmail.update();
		}
		GameCanvas.debug("LGU3", 0);
		updateLogo();
		GameCanvas.debug("LGU4", 0);
		if (GameCanvas.isTouch)
		{
			center = null;
			if (isRes)
			{
				right = cmdRes;
			}
			else
			{
				right = cmdLogin;
			}
		}
		else if (isRes)
		{
			center = cmdRes;
		}
		else if (focus == 2)
		{
			center = cmdCheck;
			if (isCheck)
			{
				center.caption = mResources.UNCHECK;
			}
			else
			{
				center.caption = mResources.REMEMBER;
			}
		}
		else
		{
			center = cmdLogin;
		}
		GameCanvas.debug("LGU5", 0);
		if (g >= 0)
		{
			ylogo += dir * g;
			g += dir * v;
			if (g <= 0)
			{
				dir *= -1;
			}
			if (ylogo > 0)
			{
				dir *= -1;
				g -= 2 * v;
			}
		}
		GameCanvas.debug("LGU6", 0);
		if (tipid >= 0 && GameCanvas.gameTick % 100 == 0)
		{
			tipid++;
			if (tipid >= mResources.tips[Main.isPC ? 1 : 0].Length)
			{
				tipid = 0;
			}
			currentTip = mFont.tahoma_7_white.splitStrInLine(mResources.tips[Main.isPC ? 1 : 0][tipid], GameCanvas.w - ((!Main.isPC) ? 100 : 40));
		}
		updateTfWhenOpenKb();
	}

	public void updateLogo()
	{
		if (defYL != yL)
		{
			yL += defYL - yL >> 1;
		}
	}

	public override void keyPress(int keyCode)
	{
		if (tfUser.isFocus)
		{
			tfUser.keyPressed(keyCode);
		}
		else if (tfPass.isFocus)
		{
			tfPass.keyPressed(keyCode);
		}
		else if (isRes)
		{
			if (tfRegPass.isFocus)
			{
				tfRegPass.keyPressed(keyCode);
			}
			else if (tfEmail.isFocus)
			{
				tfEmail.keyPressed(keyCode);
			}
		}
		base.keyPress(keyCode);
	}

	public override void paint(mGraphics g)
	{
		g.setColor(0);
		g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
		GameCanvas.debug("PLG1", 1);
		GameCanvas.paintBGGameScr(g);
		if (isAbout)
		{
			GameCanvas.debug("PLG2", 2);
			int num = tfUser.y - 45;
			if (GameCanvas.h <= 220)
			{
				num += 5;
			}
			GameCanvas.paintz.paintFrame(GameCanvas.hw - 85, tfUser.y - 15, 170, 115, g);
			if (imgTitle != null && (!isRes || GameCanvas.h >= 250))
			{
				g.drawImage(imgTitle, GameCanvas.hw, num, 3);
			}
			int num2 = popupX + 10;
			int num3 = num + 30;
			g.setColor(Paint.COLORDARK);
			g.fillRoundRect(GameCanvas.hw - mFont.tahoma_8b.getWidth(mResources.ABOUT) / 2 - 12, num3 + 7, mFont.tahoma_8b.getWidth(mResources.ABOUT) + 22, 24, 6, 6);
			g.setColor(Paint.COLORLIGHT);
			g.drawRoundRect(GameCanvas.hw - mFont.tahoma_8b.getWidth(mResources.ABOUT) / 2 - 12, num3 + 7, mFont.tahoma_8b.getWidth(mResources.ABOUT) + 22, 24, 6, 6);
			mFont.tahoma_8b.drawString(g, mResources.ABOUT, GameCanvas.hw, num3 + 12, 2);
			num3 += 35;
			mFont.tahoma_7_white.drawString(g, "Name: ", num2 + 5, num3 += 5, mFont.LEFT);
			mFont.tahoma_7b_white.drawString(g, "NinjaSchool World", num2 + 45, num3, mFont.LEFT);
			mFont.tahoma_7_white.drawString(g, "Version: ", num2 + 5, num3 += 12, mFont.LEFT);
			mFont.tahoma_7b_white.drawString(g, "1.4.8", num2 + 60, num3, mFont.LEFT);
			mFont.tahoma_7_white.drawString(g, "Company: ", num2 + 5, num3 += 12, mFont.LEFT);
			mFont.tahoma_7b_white.drawString(g, "Teamobi", num2 + 60, num3, mFont.LEFT);
			mFont.tahoma_7_white.drawString(g, "Email support: ", num2 + 5, num3 += 12, mFont.LEFT);
			mFont.tahoma_7b_blue.drawString(g, "ninja.world.cs@teamobi.com", num2 + 5, num3 += 12, mFont.LEFT);
		}
		else
		{
			GameCanvas.debug("PLG2", 2);
			int num4 = tfUser.y - 45;
			if (GameCanvas.h <= 220)
			{
				num4 += 5;
			}
			if (GameCanvas.currentDialog == null)
			{
				GameCanvas.paintz.paintFrame(GameCanvas.hw - 85, tfUser.y - 15, 170, isRes ? 150 : 115, g);
				if (GameCanvas.h > 160 && imgTitle != null)
				{
					g.drawImage(imgTitle, GameCanvas.hw, num4, 3);
				}
				GameCanvas.debug("PLG4", 1);
				tfUser.paint(g);
				tfPass.paint(g);
				if (isRes)
				{
					tfRegPass.paint(g);
					tfEmail.paint(g);
				}
				g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
				int num5 = 0;
				if (GameCanvas.w > 200)
				{
					mFont.tahoma_7b_white.drawString(g, mResources.USERNAME, tfUser.x - 57, tfUser.y + 7, 0);
					mFont.tahoma_7b_white.drawString(g, mResources.PASSWORD, tfPass.x - 57, tfPass.y + 7, 0);
					if (isRes)
					{
						mFont.tahoma_7b_white.drawString(g, mResources.REPASS, tfRegPass.x - 58, tfRegPass.y - 1, 0);
						mFont.tahoma_7b_white.drawString(g, mResources.PASSWORD, tfRegPass.x - 58, tfRegPass.y + 13, 0);
						mFont.tahoma_7b_white.drawString(g, mResources.EMAIL, tfEmail.x - 57, tfEmail.y + 7, 0);
					}
					num5 = 10;
				}
				else
				{
					mFont.tahoma_7b_white.drawString(g, mResources.USER, tfUser.x - 35, tfUser.y + 7, 0);
					mFont.tahoma_7b_white.drawString(g, mResources.PASS, tfPass.x - 35, tfPass.y + 7, 0);
					if (isRes)
					{
						mFont.tahoma_7b_white.drawString(g, mResources.RE, tfRegPass.x - 35, tfRegPass.y - 1, 0);
						mFont.tahoma_7b_white.drawString(g, mResources.PASS, tfRegPass.x - 35, tfRegPass.y + 13, 0);
					}
					num5 = 0;
				}
				if (!isRes)
				{
					GameCanvas.paintz.paintCheckPass(g, tfUser.x - 20 + num5, tfRegPass.y + 5, isCheck, focus == 2);
					mFont.tahoma_8b.drawString(g, mResources.SAVE_INFO, tfUser.x + num5, tfRegPass.y + 4, 0);
				}
			}
			else if (currentTip != null)
			{
				for (int i = 0; i < currentTip.Length; i++)
				{
					mFont.tahoma_7b_white.drawString(g, currentTip[i], GameCanvas.w / 2, tfUser.y - 15 + 10 * i, 2, mFont.tahoma_7_grey);
				}
			}
		}
		string st = "1.4.8";
		if (isLoggingIn)
		{
			st = Session_ME.strRecvByteCount;
		}
		mFont.tahoma_7_grey.drawString(g, st, GameCanvas.w - 5, 5, 1);
		base.paint(g);
	}

	public override void updateKey()
	{
		if (isAbout)
		{
			base.updateKey();
			GameCanvas.clearKeyPressed();
			return;
		}
		if (GameCanvas.keyPressedz[2] || GameCanvas.keyPressedz[24])
		{
			focus--;
			if (focus < 0)
			{
				focus = ((!isRes) ? 2 : 3);
			}
		}
		else if (GameCanvas.keyPressedz[8] || GameCanvas.keyPressedz[25] || GameCanvas.keyPressedz[32])
		{
			focus++;
			if (focus > ((!isRes) ? 2 : 3))
			{
				focus = 0;
			}
		}
		if (GameCanvas.keyPressedz[2] || GameCanvas.keyPressedz[8] || GameCanvas.keyPressedz[25] || GameCanvas.keyPressedz[24] || GameCanvas.keyPressedz[32])
		{
			GameCanvas.clearKeyPressed();
			updateFocus();
		}
		if (GameCanvas.isPointerJustRelease)
		{
			if (GameCanvas.isPointerHoldIn(tfUser.x, tfUser.y, tfUser.width, tfUser.height))
			{
				focus = 0;
				updateFocus();
			}
			else if (GameCanvas.isPointerHoldIn(tfPass.x, tfPass.y, tfPass.width, tfPass.height))
			{
				focus = 1;
				updateFocus();
			}
			else
			{
				if (isRes)
				{
					if (GameCanvas.isPointerHoldIn(tfRegPass.x, tfRegPass.y, tfRegPass.width, tfRegPass.height))
					{
						focus = 2;
					}
					if (GameCanvas.isPointerHoldIn(tfEmail.x, tfEmail.y, tfEmail.width, tfEmail.height))
					{
						focus = 3;
					}
					updateFocus();
				}
				else if (GameCanvas.isPointerHoldIn(tfUser.x - 30, GameCanvas.hh + 40, 90, 35))
				{
					isCheck = !isCheck;
				}
				focus = 2;
			}
		}
		if (Main.isPC && GameCanvas.keyPressedz[5] && right != null)
		{
			right.performAction();
		}
		base.updateKey();
		GameCanvas.clearKeyPressed();
	}

	public void updateFocus()
	{
		if (focus == 1)
		{
			tfUser.isFocus = false;
			tfPass.isFocus = true;
			tfRegPass.isFocus = false;
			tfEmail.isFocus = false;
			if (!GameCanvas.isTouch)
			{
				right = tfPass.cmdClear;
			}
		}
		else if (focus == 0)
		{
			tfUser.isFocus = true;
			tfPass.isFocus = false;
			tfRegPass.isFocus = false;
			tfEmail.isFocus = false;
			if (!GameCanvas.isTouch)
			{
				right = tfUser.cmdClear;
			}
		}
		else if (focus == 2)
		{
			tfUser.isFocus = false;
			tfPass.isFocus = false;
			tfEmail.isFocus = false;
			if (isRes)
			{
				tfRegPass.isFocus = true;
				right = (GameCanvas.isTouch ? right : tfRegPass.cmdClear);
			}
		}
		else
		{
			tfUser.isFocus = false;
			tfPass.isFocus = false;
			tfRegPass.isFocus = false;
			tfEmail.isFocus = true;
			right = (GameCanvas.isTouch ? right : tfEmail.cmdClear);
		}
	}

	public void resetLogo()
	{
		yL = -50;
	}

	protected void doSelectServer()
	{
		MyVector myVector = new MyVector();
		if (indexLocal == 1)
		{
			myVector.addElement(new Command("LOCAL 44", this, 200041, null));
		}
		else if (indexLocal == 2)
		{
			myVector.addElement(new Command("LOCAL 46", this, 200042, null));
		}
		if (!GameMidlet.isWorldver)
		{
			myVector.addElement(new Command(mResources.servername[GameMidlet.serverST[1]], this, 20001, null));
			myVector.addElement(new Command(mResources.servername[GameMidlet.serverST[2]], this, 20002, null));
			myVector.addElement(new Command(mResources.servername[GameMidlet.serverST[3]], this, 20003, null));
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
			doLogin();
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

	public void perform(int idAction, object p)
	{
		switch (idAction)
		{
		case 1002:
			actRegister();
			break;
		case 10021:
			actRegisterLeft();
			break;
		case 1003:
			try
			{
				GameMidlet.instance.platformRequest("http://ninjaschool.vn");
			}
			catch (Exception ex)
			{
				Out.println(ex.ToString() + " loi tai perform cua login");
			}
			break;
		case 1004:
			domenuConfig();
			break;
		case 10041:
			RMS.saveRMSInt("lowGraphic", 0);
			GameCanvas.startOK(mResources.RESTART, 8885, null);
			break;
		case 10042:
			RMS.saveRMSInt("lowGraphic", 1);
			GameCanvas.startOK(mResources.RESTART, 8885, null);
			break;
		case 1005:
			doAskForGPRS();
			break;
		case 1006:
			domenuConfig();
			break;
		case 10061:
			RMS.saveRMSInt("isSoftKey", 1);
			GameScr.isTouchKey = true;
			break;
		case 1008:
			NinjaUtil.downloadGame("http://teamobi.com/terms.htm");
			break;
		case 10062:
			RMS.saveRMSInt("isSoftKey", 2);
			GameScr.isTouchKey = false;
			break;
		case 1006190:
			RMS.saveRMSInt("mapKey", 1);
			GameCanvas.isChangMapKey = false;
			break;
		case 1006291:
			RMS.saveRMSInt("mapKey", 2);
			GameCanvas.isChangMapKey = true;
			break;
		case 1007:
			actAbout();
			Sound.isSound = !Sound.isSound;
			if (Sound.isSound)
			{
				RMS.saveRMSInt("isSound", 1);
				GameMidlet.isPlaySound = true;
				Sound.bMuzikDisable = false;
				if (GameCanvas.currentScreen == GameCanvas.loginScr)
				{
					Sound.play(Sound.MLogin, 0.5f);
				}
				Out.println("mo am thanh");
			}
			else
			{
				RMS.saveRMSInt("isSound", 2);
				Sound.stopAll();
				Sound.stopAllBg();
				GameMidlet.isPlaySound = false;
				Out.println("tat am thanh");
			}
			GameMidlet.isPlaySound = Sound.isSound;
			break;
		case 2000:
			doSelectServer();
			break;
		case 10081:
			doResetToSelectLanguage();
			break;
		case 10082:
			saveLanguageID(mResources.Lang_EN);
			RMS.clearRMS();
			GameCanvas.startOK(mResources.RESTART2, 8885, null);
			break;
		case 20001:
			GameCanvas.menu.showMenu = false;
			GameMidlet.IP = GameMidlet.ipList[1];
			saveIndexServer(GameMidlet.serverST[1]);
			saveLastServer(GameMidlet.IP);
			doLogin();
			break;
		case 20002:
			GameCanvas.menu.showMenu = false;
			GameMidlet.IP = GameMidlet.ipList[2];
			saveIndexServer(GameCanvas.menu.menuSelectedItem);
			saveLastServer(GameMidlet.IP);
			doLogin();
			break;
		case 20003:
			GameCanvas.menu.showMenu = false;
			GameMidlet.IP = GameMidlet.ipList[3];
			saveIndexServer(GameCanvas.menu.menuSelectedItem);
			saveLastServer(GameMidlet.IP);
			doLogin();
			break;
		case 200041:
			GameCanvas.menu.showMenu = false;
			GameMidlet.IP = GameMidlet.ipList[6];
			GameMidlet.PORT = 14444;
			saveIndexServer(GameCanvas.menu.menuSelectedItem);
			doLogin();
			break;
		case 200042:
			GameCanvas.menu.showMenu = false;
			GameMidlet.IP = GameMidlet.ipList[6];
			GameMidlet.PORT = 14444;
			saveIndexServer(GameCanvas.menu.menuSelectedItem);
			doLogin();
			break;
		case 2004:
			if (Main.isPC)
			{
				GameCanvas.inputDlg.show(mResources.INPUT_NICK, new Command(mResources.OK, this, 20041, null), TField.INPUT_TYPE_ANY);
			}
			else
			{
				GameCanvas.inputDlg.show(mResources.INPUT_NICK, new Command(mResources.OK, LoginScr.mgI(), 20041, null), TField.INPUT_TYPE_ANY);
			}
			break;
		case 200423:
			Out.println("FORGET PASS");
			str1 = GameCanvas.inputDlg.tfInput.getText().ToString();
			GameCanvas.endDlg();
			if (str1.Equals(string.Empty))
			{
				GameCanvas.startOKDlg(mResources.NOT_INPUT_USERNAME);
				break;
			}
			if (str3.Equals(string.Empty))
			{
				GameCanvas.startOKDlg(mResources.NOT_INPUT_PASS);
				break;
			}
			GameCanvas.endDlg();
			if (Main.isPC)
			{
				doGetForgetPassByIMEI(str1, str2);
			}
			else
			{
				doGetForgetPassByIMEI(str1, str2);
			}
			break;
		case 20041:
			str1 = GameCanvas.inputDlg.tfInput.getText().ToString();
			GameCanvas.endDlg();
			if (str1.Equals(string.Empty))
			{
				GameCanvas.startOKDlg(mResources.NOT_INPUT_USERNAME);
				break;
			}
			GameCanvas.input2Dlg.setTitle(mResources.OLD_PASS, mResources.NEW_PASS);
			GameCanvas.input2Dlg.show(mResources.INFO, new Command(mResources.CLOSE, this, 200422, null), new Command(mResources.OK, this, 200411, null), TField.INPUT_TYPE_PASSWORD, TField.INPUT_TYPE_PASSWORD);
			break;
		case 200411:
			str2 = GameCanvas.input2Dlg.tfInput.getText().ToString();
			str3 = GameCanvas.input2Dlg.tfInput2.getText().ToString();
			GameCanvas.endDlg();
			if (str2.Equals(string.Empty) || str3.Equals(string.Empty))
			{
				GameCanvas.startOKDlg(mResources.NOT_INPUT_PASS1);
			}
			else
			{
				GameCanvas.startYesNoDlg(mResources.replace(mResources.ASK_ACC_CHANGE, str1), new Command(string.Empty, this, 200421, null), new Command(string.Empty, this, 200422, null));
			}
			break;
		case 200421:
			GameCanvas.endDlg();
			if (Main.isPC)
			{
				doChangePass(str1, str2, str3);
			}
			else
			{
				doChangePass(str1, str2, str3);
			}
			break;
		case 200422:
			GameCanvas.endDlg();
			break;
		case 2001:
			if (isCheck)
			{
				isCheck = false;
			}
			else
			{
				isCheck = true;
			}
			break;
		case 2002:
			doRegister();
			break;
		case 2003:
			doMenu();
			break;
		case 2005:
			if (Main.isPC)
			{
				GameCanvas.input2Dlg.setTitle(mResources.USERNAME, mResources.EMAIL);
				GameCanvas.input2Dlg.show(mResources.INPUT_ACC_FORGET, new Command(mResources.CLOSE, this, 200422, null), new Command(mResources.OK, this, 20051, null), TField.INPUT_TYPE_ANY, TField.INPUT_TYPE_ANY);
			}
			else
			{
				GameCanvas.input2Dlg.setTitle(mResources.USERNAME, mResources.EMAIL);
				GameCanvas.input2Dlg.show(mResources.INPUT_ACC_FORGET, new Command(mResources.CLOSE, this, 200422, null), new Command(mResources.OK, this, 20051, null), TField.INPUT_TYPE_ANY, TField.INPUT_TYPE_ANY);
			}
			break;
		case 20051:
			str1 = GameCanvas.input2Dlg.tfInput.getText().ToString();
			str2 = GameCanvas.input2Dlg.tfInput2.getText().ToString();
			if (str1.Equals(string.Empty))
			{
				GameCanvas.startOKDlg(mResources.NOT_INPUT_USERNAME);
				break;
			}
			GameCanvas.endDlg();
			GameCanvas.startYesNoDlg(mResources.replace(mResources.ASK_ACC_FORGET, str1), new Command(string.Empty, this, 200511, null), new Command(string.Empty, this, 200422, null));
			break;
		case 200511:
			doGetForgetPassByIMEI(str1, str2);
			break;
		case 3000:
			doSetGPRS(isGPRS: false);
			GameCanvas.endDlg();
			break;
		case 3001:
			doSetGPRS(isGPRS: true);
			GameCanvas.endDlg();
			break;
		case 4000:
			doRegister(tfUser.getText());
			break;
		case 4001:
			tfUser.setFocus(isFocus: false);
			tfPass.setFocusWithKb(isFocus: true);
			break;
		case 4002:
			tfPass.setFocus(isFocus: false);
			if (isRes)
			{
				tfRegPass.setFocusWithKb(isFocus: true);
			}
			break;
		case 4003:
			tfRegPass.setFocus(isFocus: false);
			tfRegPass.setFocusWithKb(isFocus: true);
			break;
		}
	}

	private void actAbout()
	{
		isAbout = true;
		center = null;
		left = new Command(mResources.CANCEL, this, 10021, null);
		right = new Command(mResources.TERM, this, 1008, null);
		popupW = 170;
		popupH = 120;
		if (GameCanvas.w == 128 || GameCanvas.h <= 208)
		{
			popupW = 126;
			popupH = 160;
		}
		popupX = GameCanvas.w / 2 - popupW / 2;
		popupY = GameCanvas.h / 2 - popupH / 2;
		if (GameCanvas.h <= 250)
		{
			popupY -= 10;
		}
	}

	private void saveLanguageID(int languageID)
	{
		RMS.saveRMSInt("indLanguage", languageID);
	}

	private void doResetToSelectLanguage()
	{
		RMS.saveRMSInt("indLanguage", -1);
		GameMidlet.instance.notifyDestroyed();
	}

	private void domenuConfig()
	{
		MyVector myVector = new MyVector();
		if (!Main.isPC)
		{
			myVector.addElement(new Command(mResources.SOFT_KEY, this, 10061, null));
			myVector.addElement(new Command(mResources.ANALOG_KEY, this, 10062, null));
		}
		else
		{
			myVector.addElement(new Command(mResources.control1, this, 1006190, null));
			myVector.addElement(new Command(mResources.control2, this, 1006291, null));
		}
		myVector.addElement(new Command(mResources.SOUND + (Sound.isSound ? mResources.OFF : mResources.ON), this, 1007, null));
		GameCanvas.menu.startAt(myVector, 0);
	}

	public void actRegisterLeft()
	{
		isRes = (isAbout = false);
		initTF();
		tfRegPass.isFocus = (tfPass.isFocus = (tfEmail.isFocus = false));
		tfUser.isFocus = true;
		right = tfUser.cmdClear;
		left = cmdMenu;
	}

	private void actRegister()
	{
		isRes = true;
		initTF();
		tfUser.isFocus = true;
		tfRegPass.isFocus = (tfPass.isFocus = (tfEmail.isFocus = false));
		right = tfUser.cmdClear;
		left = new Command(mResources.CANCEL, this, 10021, null);
	}
}
