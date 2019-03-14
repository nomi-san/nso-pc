using System;
using UnityEngine;

public class Controller : IMessageHandler
{
	protected static Controller me;

	public Message messWait;

	private int move;

	private int total;

	public static Controller gI()
	{
		if (me == null)
		{
			me = new Controller();
		}
		return me;
	}

	public void onConnectOK()
	{
		Out.println("Connect ok");
	}

	public void onConnectionFail()
	{
		GameCanvas.isConnectFail = true;
	}

	public void onDisconnected()
	{
		GameCanvas.instance.resetToLoginScr();
	}

	public void requestItemPlayer(Message msg)
	{
		try
		{
			int num = msg.reader().readUnsignedByte();
			Item item = GameScr.currentCharViewInfo.arrItemBody[num];
			item.expires = msg.reader().readLong();
			item.saleCoinLock = msg.reader().readInt();
			item.sys = msg.reader().readByte();
			item.options = new MyVector();
			try
			{
				while (true)
				{
					item.options.addElement(new ItemOption(msg.reader().readByte(), msg.reader().readInt()));
				}
				IL_0083:;
			}
			catch (Exception ex)
			{
				Out.println(" >>>11  loi tai requestItemPlayer" + ex.ToString());
			}
		}
		catch (Exception ex2)
		{
			Out.println(">>>222 loi tai requestItemPlayer" + ex2.ToString());
		}
	}

	public void viewItemAuction(Message msg)
	{
		try
		{
			Item item = null;
			int num = msg.reader().readInt();
			for (int i = 0; i < GameScr.arrItemStands.Length; i++)
			{
				if (GameScr.arrItemStands[i].item.itemId == num)
				{
					item = GameScr.arrItemStands[i].item;
					break;
				}
			}
			item.typeUI = 37;
			item.expires = -1L;
			item.saleCoinLock = msg.reader().readInt();
			if (item.isTypeBody() || item.isTypeNgocKham())
			{
				item.options = new MyVector();
				try
				{
					item.upgrade = msg.reader().readByte();
					item.sys = msg.reader().readByte();
					while (true)
					{
						item.options.addElement(new ItemOption(msg.reader().readByte(), msg.reader().readInt()));
					}
					IL_00e0:;
				}
				catch (Exception)
				{
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void onMessage(Message msg)
	{
		GameCanvas.debugSession.removeAllElements();
		GameCanvas.debug("SA1", 2);
		Friend friend = null;
		Char @char = null;
		Char char2 = null;
		int num = 0;
		Mob mob = null;
		try
		{
			switch (msg.command)
			{
			case 125:
			{
				sbyte b4 = msg.reader().readByte();
				Debug.Log("---- get :" + b4);
				if (b4 == 0)
				{
					addEffect(msg);
				}
				else if (b4 == 1)
				{
					getImgEffect(msg);
				}
				else if (b4 == 2)
				{
					getDataEffect(msg);
				}
				break;
			}
			case 124:
				khamngoc(msg);
				break;
			case 123:
			{
				sbyte b6 = msg.reader().readByte();
				if (b6 == 0)
				{
					GameCanvas.isKiemduyet_info = true;
				}
				else if (b6 == 1)
				{
					GameCanvas.isKiemduyet_info = false;
				}
				else if (b6 == 2)
				{
					RMS.saveRMSInt("isKiemduyet", 0);
					GameCanvas.isKiemduyet = true;
				}
				else
				{
					RMS.saveRMSInt("isKiemduyet", 1);
					GameCanvas.isKiemduyet = false;
				}
				break;
			}
			case 122:
			{
				sbyte b10 = msg.reader().readByte();
				if (b10 == 0)
				{
					addMob(msg);
				}
				else if (b10 == 1)
				{
					addEffAuto(msg);
				}
				else if (b10 == 2)
				{
					getImgEffAuto(msg);
				}
				else if (b10 == 3)
				{
					getDataEffAuto(msg);
				}
				break;
			}
			case 121:
			{
				GameScr.vList.removeAllElements();
				int num21 = msg.reader().readUnsignedByte();
				Ranked ranked = null;
				for (int num77 = 0; num77 < num21; num77++)
				{
					try
					{
						ranked = new Ranked();
						ranked.name = msg.reader().readUTF();
						ranked.ranked = msg.reader().readInt();
						ranked.stt = msg.reader().readUTF();
						GameScr.vList.addElement(ranked);
					}
					catch (Exception)
					{
					}
				}
				GameScr.gI().doShowRankedListUI();
				break;
			}
			case 119:
			{
				sbyte b5 = msg.reader().readByte();
				if (b5 == -1)
				{
					GameScr.isUseitemAuto = true;
					GameScr.rangeSearch = msg.reader().readInt();
					if (GameScr.rangeSearch > 360)
					{
						GameScr.isAllmap = true;
					}
					else
					{
						GameScr.isAllmap = false;
						GameScr.pointCenterX = Char.getMyChar().cx;
						GameScr.pointCenterY = Char.getMyChar().cy;
					}
				}
				else if (b5 == 0)
				{
					int charId3 = msg.reader().readInt();
					Char char5 = GameScr.findCharInMap(charId3);
					if (char5 != null)
					{
						ServerEffect.addServerEffect(141, char5.cx, char5.cy, 2);
						short num59 = (short)(char5.cxMoveLast = msg.reader().readShort());
						short num60 = (short)(char5.cyMoveLast = msg.reader().readShort());
						ServerEffect.addServerEffect(141, char5.cx, char5.cy, 2);
					}
				}
				else
				{
					GameScr.isUseitemAuto = false;
					GameScr.auto = 0;
				}
				break;
			}
			case 118:
			{
				string text8 = msg.reader().readUTF();
				RMS.saveRMSString("acc", text8);
				string text9 = msg.reader().readUTF();
				RMS.saveRMSString("pass", text9);
				SelectServerScr.uname = text8;
				SelectServerScr.pass = text9;
				SelectServerScr.unameChange = string.Empty;
				SelectServerScr.passChange = string.Empty;
				if (!text8.StartsWith("tmpusr"))
				{
					GameScr.gI().switchToMe();
				}
				break;
			}
			case 117:
				try
				{
					Mob.vEggMonter.removeAllElements();
					TileMap.itemMap.clear();
					GameScr.vItemTreeBehind.removeAllElements();
					GameScr.vItemTreeBetwen.removeAllElements();
					GameScr.vItemTreeFront.removeAllElements();
					sbyte b2 = msg.reader().readsbyte();
					for (int n = 0; n < b2; n++)
					{
						short num19 = msg.reader().readShort();
						string k2 = num19 + string.Empty;
						int num20 = msg.reader().readInt();
						sbyte[] array2 = new sbyte[num20];
						msg.reader().readz(array2);
						object v = createImage(array2);
						TileMap.itemMap.put(k2, v);
					}
					int num21 = msg.reader().readUnsignedByte();
					for (int num22 = 0; num22 < num21; num22++)
					{
						int idTree = msg.reader().readUnsignedByte();
						int x = msg.reader().readUnsignedByte();
						int y = msg.reader().readUnsignedByte();
						ItemTree itemTree = new ItemTree(x, y);
						itemTree.idTree = idTree;
						GameScr.vItemTreeBehind.addElement(itemTree);
					}
					num21 = msg.reader().readUnsignedByte();
					for (int num23 = 0; num23 < num21; num23++)
					{
						int idTree2 = msg.reader().readUnsignedByte();
						int x2 = msg.reader().readUnsignedByte();
						int y2 = msg.reader().readUnsignedByte();
						ItemTree itemTree2 = new ItemTree(x2, y2);
						itemTree2.idTree = idTree2;
						GameScr.vItemTreeBetwen.addElement(itemTree2);
					}
					num21 = msg.reader().readUnsignedByte();
					for (int num24 = 0; num24 < num21; num24++)
					{
						int idTree3 = msg.reader().readUnsignedByte();
						int x3 = msg.reader().readUnsignedByte();
						int y3 = msg.reader().readUnsignedByte();
						ItemTree itemTree3 = new ItemTree(x3, y3);
						itemTree3.idTree = idTree3;
						GameScr.vItemTreeFront.addElement(itemTree3);
					}
				}
				catch (Exception)
				{
				}
				break;
			case -21:
			{
				string text3 = msg.reader().readUTF();
				string text4 = msg.reader().readUTF();
				ChatManager.gI().addChat(mResources.GLOBALCHAT[0], text3, text4);
				if (!ChatManager.blockGlobalChat)
				{
					Info.addInfo(text3 + ": " + text4, 80, mFont.tahoma_7b_yellow);
				}
				break;
			}
			case -20:
			{
				string whoChat = msg.reader().readUTF();
				string text13 = msg.reader().readUTF();
				ChatManager.gI().addChat(mResources.PARTYCHAT[0], whoChat, text13);
				if (!GameScr.isPaintMessage || ChatManager.gI().getCurrentChatTab().type != 1)
				{
					ChatManager.isMessagePt = true;
				}
				break;
			}
			case -22:
			{
				string text10 = msg.reader().readUTF();
				string text11 = msg.reader().readUTF();
				ChatManager.gI().addChat(text10, text10, text11);
				if ((!GameScr.isPaintMessage || !ChatManager.gI().getCurrentChatTab().ownerName.Equals(text10)) && !ChatManager.blockPrivateChat)
				{
					ChatManager.gI().addWaitList(text10);
				}
				break;
			}
			case -19:
			{
				string whoChat2 = msg.reader().readUTF();
				string text16 = msg.reader().readUTF();
				ChatManager.gI().addChat(mResources.CLANCHAT[0], whoChat2, text16);
				if (!GameScr.isPaintMessage || ChatManager.gI().getCurrentChatTab().type != 4)
				{
					ChatManager.isMessageClan = true;
				}
				break;
			}
			case -26:
				GameCanvas.debug("SA2", 2);
				GameCanvas.startOKDlg(msg.reader().readUTF());
				break;
			case -24:
				GameCanvas.debug("SA3", 2);
				InfoMe.addInfo(msg.reader().readUTF(), 50, mFont.tahoma_7_yellow);
				break;
			case -25:
			{
				GameCanvas.debug("SA3", 2);
				string text6 = msg.reader().readUTF();
				Info.addInfo(text6, 150, mFont.tahoma_7b_yellow);
				ChatManager.gI().addChat(mResources.GLOBALCHAT[0], mResources.SERVER_ALERT, text6);
				break;
			}
			case 53:
			{
				GameCanvas.debug("SA4", 2);
				GameScr.gI().resetButton();
				string text15 = msg.reader().readUTF();
				if (!text15.Equals("typemoi"))
				{
					string str2 = msg.reader().readUTF();
					GameScr.gI().showAlert(text15, str2, withMenuShow: false);
				}
				else
				{
					string title = msg.reader().readUTF();
					short time = msg.reader().readShort();
					string totalMoney = msg.reader().readUTF();
					short percentWin = msg.reader().readShort();
					string percentWin2 = msg.reader().readUTF();
					short numPlayer = msg.reader().readShort();
					string winnerInfo = msg.reader().readUTF();
					sbyte typeLucky = msg.reader().readByte();
					string myMoney = msg.reader().readUTF();
					GameScr.gI().showLucky_Draw(title, time, totalMoney, percentWin, percentWin2, numPlayer, winnerInfo, myMoney, typeLucky);
				}
				break;
			}
			case 54:
				GameCanvas.debug("SA44", 2);
				GameCanvas.gI().openWeb(msg.reader().readUTF(), msg.reader().readUTF(), msg.reader().readUTF(), msg.reader().readUTF());
				break;
			case 55:
				GameCanvas.debug("SA444", 2);
				GameCanvas.gI().sendSms(msg.reader().readUTF(), msg.reader().readUTF(), msg.reader().readShort(), msg.reader().readUTF(), msg.reader().readUTF());
				break;
			case 57:
				GameCanvas.debug("SA44444", 2);
				GameCanvas.endDlg();
				GameScr.gI().resetButton();
				break;
			case 58:
				GameCanvas.debug("SA444444", 2);
				GameScr.arrItemTradeMe = null;
				GameScr.arrItemTradeOrder = null;
				if (GameScr.gI().coinTradeOrder > 0)
				{
					GameScr gameScr2 = GameScr.gI();
					string tradeItemName = gameScr2.tradeItemName;
					gameScr2.tradeItemName = tradeItemName + ", " + GameScr.gI().coinTradeOrder + " " + mResources.XU;
					GameScr.startFlyText("+" + GameScr.gI().coinTradeOrder, Char.getMyChar().cx, Char.getMyChar().cy - Char.getMyChar().ch - 10, 0, -2, mFont.ADDMONEY);
				}
				GameScr.gI().coinTrade = (GameScr.gI().coinTradeOrder = 0);
				GameScr.gI().resetButton();
				Char.getMyChar().xu = msg.reader().readInt();
				InfoDlg.hide();
				if (!GameScr.gI().tradeItemName.Equals(string.Empty))
				{
					InfoMe.addInfo(mResources.RECEIVE + " " + GameScr.gI().tradeItemName);
				}
				break;
			case 59:
			{
				GameCanvas.debug("SA48888", 2);
				string text7 = msg.reader().readUTF();
				Friend o = new Friend(text7, 4);
				GameScr.vFriendWait.addElement(o);
				InfoMe.addInfo(text7 + " " + mResources.FRIEND_ADDED, 20, mFont.tahoma_7_white);
				if (GameScr.isPaintFriend)
				{
					bool flag = false;
					for (int num57 = 0; num57 < GameScr.vFriend.size(); num57++)
					{
						friend = (Friend)GameScr.vFriend.elementAt(num57);
						if (friend.friendName.Equals(text7))
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						GameScr.vFriend.addElement(o);
						GameScr.gI().sortList(0);
						GameScr.indexRow = 0;
						GameScr.scrMain.clear();
					}
				}
				break;
			}
			case 79:
			{
				GameCanvas.debug("SA4888888", 2);
				int num66 = msg.reader().readInt();
				string str = msg.reader().readUTF();
				GameCanvas.startYesNoDlg(str + " " + mResources.INVITEPARTY, 8887, num66, 8888, num66);
				break;
			}
			case 82:
			{
				GameCanvas.debug("SXX1", 2);
				GameScr.vParty.removeAllElements();
				bool isLock = msg.reader().readBoolean();
				try
				{
					for (int num61 = 0; num61 < 6; num61++)
					{
						GameScr.vParty.addElement(new Party(msg.reader().readInt(), msg.reader().readByte(), msg.reader().readUTF(), isLock));
					}
				}
				catch (Exception)
				{
				}
				GameScr.gI().refreshTeam();
				break;
			}
			case 83:
				GameCanvas.debug("SXX2", 2);
				GameScr.vParty.removeAllElements();
				GameScr.gI().refreshTeam();
				break;
			case 84:
				GameCanvas.debug("SXX3", 2);
				friend = new Friend(msg.reader().readUTF(), msg.reader().readByte());
				GameScr.gI().actRemoveWaitAcceptFriend(friend.friendName);
				if (friend.type == 0)
				{
					InfoMe.addInfo(mResources.YOU_ADD + " " + friend.friendName + " " + mResources.TO_LIST);
					GameScr.vFriend.addElement(friend);
				}
				else if (friend.type == 1)
				{
					for (int num89 = 0; num89 < GameScr.vFriend.size(); num89++)
					{
						if (((Friend)GameScr.vFriend.elementAt(num89)).friendName.Equals(friend.friendName))
						{
							GameScr.vFriend.removeElementAt(num89);
							break;
						}
					}
					InfoMe.addInfo(mResources.YOU_AND + " " + friend.friendName + " " + mResources.BE_FRIEND);
					friend.type = 3;
					GameScr.vFriend.insertElementAt(friend, 0);
				}
				if (GameScr.isPaintFriend)
				{
					GameScr.gI().sortList(0);
					GameScr.indexRow = 0;
					GameScr.scrMain.clear();
				}
				break;
			case 107:
			{
				int num85 = msg.reader().readByte();
				GameCanvas.startYesNoDlg(msg.reader().readUTF(), 8890, num85, 8882, null);
				break;
			}
			case 85:
			{
				GameCanvas.debug("SXX4", 2);
				int iD = msg.reader().readUnsignedByte();
				Mob mob3 = Mob.get_Mob(iD);
				bool isDisable = msg.reader().readBoolean();
				if (mob3 != null)
				{
					mob3.isDisable = isDisable;
				}
				break;
			}
			case 86:
			{
				GameCanvas.debug("SXX5", 2);
				int iD = msg.reader().readUnsignedByte();
				Mob mob3 = Mob.get_Mob(iD);
				bool isDontMove = msg.reader().readBoolean();
				if (mob3 != null)
				{
					mob3.isDontMove = isDontMove;
				}
				break;
			}
			case 89:
			{
				GameCanvas.debug("SXX5", 2);
				int iD = msg.reader().readUnsignedByte();
				Mob mob3 = Mob.get_Mob(iD);
				bool isFire = msg.reader().readBoolean();
				if (mob3 != null)
				{
					mob3.isFire = isFire;
				}
				break;
			}
			case 90:
			{
				GameCanvas.debug("SXX5", 2);
				int iD = msg.reader().readUnsignedByte();
				Mob mob3 = Mob.get_Mob(iD);
				bool isIce = msg.reader().readBoolean();
				if (mob3 != null)
				{
					mob3.isIce = isIce;
					if (!mob3.isIce)
					{
						ServerEffect.addServerEffect(77, mob3.x, mob3.y - 9, 1);
					}
				}
				break;
			}
			case 91:
			{
				GameCanvas.debug("SXX5", 2);
				int iD = msg.reader().readUnsignedByte();
				Mob mob3 = Mob.get_Mob(iD);
				bool isWind = msg.reader().readBoolean();
				if (mob3 != null)
				{
					mob3.isWind = isWind;
				}
				break;
			}
			case 62:
			{
				GameCanvas.debug("SXX6", 2);
				int num9 = msg.reader().readInt();
				if (num9 == Char.getMyChar().charID)
				{
					Char char4 = Char.getMyChar();
					char4.cHP = msg.reader().readInt();
					int num10 = msg.reader().readInt();
					int num11 = 0;
					try
					{
						char4.cMP = msg.reader().readInt();
						num11 = msg.reader().readInt();
					}
					catch (Exception)
					{
					}
					num10 += num11;
					if (num10 == 0)
					{
						GameScr.startFlyText(string.Empty, char4.cx, char4.cy - char4.ch, 0, -2, mFont.MISS_ME);
					}
					else if (num10 < 0)
					{
						num10 *= -1;
						GameScr.startFlyText("-" + num10, char4.cx, char4.cy - char4.ch, 0, -2, mFont.FATAL_ME);
					}
					else
					{
						GameScr.startFlyText("-" + num10, char4.cx, char4.cy - char4.ch, 0, -2, mFont.RED);
					}
				}
				else
				{
					Char char4 = GameScr.findCharInMap(num9);
					if (char4 == null)
					{
						return;
					}
					char4.cHP = msg.reader().readInt();
					int num12 = msg.reader().readInt();
					int num13 = 0;
					try
					{
						char4.cMP = msg.reader().readInt();
						num13 = msg.reader().readInt();
					}
					catch (Exception)
					{
					}
					num12 += num13;
					if (num12 == 0)
					{
						GameScr.startFlyText(string.Empty, char4.cx, char4.cy - char4.ch, 0, -2, mFont.MISS);
					}
					else if (num12 < 0)
					{
						num12 *= -1;
						GameScr.startFlyText("-" + num12, char4.cx, char4.cy - char4.ch, 0, -2, mFont.FATAL);
					}
					else
					{
						GameScr.startFlyText("-" + num12, char4.cx, char4.cy - char4.ch, 0, -2, mFont.ORANGE);
					}
				}
				break;
			}
			case 23:
			{
				GameCanvas.debug("SXX7", 2);
				string text2 = msg.reader().readUTF();
				GameCanvas.startYesNoDlg(text2 + " " + mResources.PLEASE_PARTY, 8889, text2, 8882, null);
				break;
			}
			case 87:
			{
				GameCanvas.debug("SXX8", 2);
				int num9 = msg.reader().readInt();
				Char char4 = (num9 != Char.getMyChar().charID) ? GameScr.findCharInMap(num9) : Char.getMyChar();
				if (char4 == null)
				{
					return;
				}
				int iD = msg.reader().readUnsignedByte();
				short idSkill_atk = msg.reader().readShort();
				sbyte typeAtk = msg.reader().readByte();
				sbyte typeTool = msg.reader().readByte();
				sbyte b9 = 0;
				int charId5 = -1;
				try
				{
					b9 = msg.reader().readByte();
					if (b9 == 1)
					{
						charId5 = msg.reader().readInt();
					}
				}
				catch (Exception)
				{
				}
				if (char4.mobMe != null)
				{
					if (b9 == 0)
					{
						Mob mobToAttack = Mob.get_Mob(iD);
						char4.mobMe.attackOtherMob(mobToAttack);
					}
					else
					{
						Char charToAttack = GameScr.findCharInMap(charId5);
						char4.mobMe.attackOtherChar(charToAttack);
					}
				}
				char4.mobMe.setTypeAtk(idSkill_atk, typeAtk, typeTool);
				break;
			}
			case 88:
			{
				int num9 = msg.reader().readInt();
				Char char4;
				if (num9 == Char.getMyChar().charID)
				{
					char4 = Char.getMyChar();
				}
				else
				{
					char4 = GameScr.findCharInMap(num9);
					if (char4 == null)
					{
						return;
					}
				}
				char4.cHP = char4.cMaxHP;
				char4.cMP = char4.cMaxMP;
				char4.cx = msg.reader().readShort();
				char4.cy = msg.reader().readShort();
				char4.liveFromDead();
				break;
			}
			case 52:
				GameCanvas.debug("SA5", 2);
				Char.ischangingMap = false;
				Char.isLockKey = false;
				Char.getMyChar().cx = msg.reader().readShort();
				Char.getMyChar().cy = msg.reader().readShort();
				Char.getMyChar().cxSend = Char.getMyChar().cx;
				Char.getMyChar().cySend = Char.getMyChar().cy;
				break;
			case -29:
				messageNotLogin(msg);
				break;
			case -28:
				messageNotMap(msg);
				break;
			case -30:
				messageSubCommand(msg);
				break;
			case 8:
			{
				GameCanvas.debug("SA37", 2);
				int num5 = msg.reader().readByte();
				Char.getMyChar().arrItemBag[num5] = new Item();
				Char.getMyChar().arrItemBag[num5].typeUI = 3;
				Char.getMyChar().arrItemBag[num5].indexUI = num5;
				Char.getMyChar().arrItemBag[num5].template = ItemTemplates.get(msg.reader().readShort());
				Char.getMyChar().arrItemBag[num5].isLock = msg.reader().readBoolean();
				if (Char.getMyChar().arrItemBag[num5].isTypeBody() || Char.getMyChar().arrItemBag[num5].isTypeNgocKham())
				{
					Char.getMyChar().arrItemBag[num5].upgrade = msg.reader().readByte();
				}
				Char.getMyChar().arrItemBag[num5].isExpires = msg.reader().readBoolean();
				try
				{
					Char.getMyChar().arrItemBag[num5].quantity = msg.reader().readUnsignedShort();
				}
				catch (Exception)
				{
					Char.getMyChar().arrItemBag[num5].quantity = 1;
				}
				if (Char.getMyChar().arrItemBag[num5].template.type == 16)
				{
					GameScr.hpPotion += Char.getMyChar().arrItemBag[num5].quantity;
				}
				if (Char.getMyChar().arrItemBag[num5].template.type == 17)
				{
					GameScr.mpPotion += Char.getMyChar().arrItemBag[num5].quantity;
				}
				if (Char.getMyChar().arrItemBag[num5].template.id == 340)
				{
					GameScr.gI().numSprinLeft += Char.getMyChar().arrItemBag[num5].quantity;
				}
				if (GameScr.isPaintTrade)
				{
					if (GameScr.gI().tradeItemName.Equals(string.Empty))
					{
						GameScr.gI().tradeItemName += Char.getMyChar().arrItemBag[num5].template.name;
					}
					else
					{
						GameScr gameScr = GameScr.gI();
						gameScr.tradeItemName = gameScr.tradeItemName + ", " + Char.getMyChar().arrItemBag[num5].template.name;
					}
				}
				else if (Char.getMyChar().arrItemBag[num5].template.type != 20)
				{
					InfoMe.addInfo(mResources.RECEIVE + " " + Char.getMyChar().arrItemBag[num5].template.name);
				}
				break;
			}
			case 10:
			{
				GameCanvas.debug("SA38", 2);
				int num5 = msg.reader().readByte();
				if (Char.getMyChar().arrItemBag[num5].template.type == 16)
				{
					GameScr.hpPotion -= Char.getMyChar().arrItemBag[num5].quantity;
				}
				if (Char.getMyChar().arrItemBag[num5].template.type == 17)
				{
					GameScr.mpPotion -= Char.getMyChar().arrItemBag[num5].quantity;
				}
				Char.getMyChar().arrItemBag[num5] = null;
				if (GameScr.gI().isPaintUI())
				{
					GameScr.gI().left = (GameScr.gI().center = null);
				}
				else
				{
					GameScr.gI().resetButton();
				}
				break;
			}
			case 18:
			{
				GameCanvas.debug("SYA9", 2);
				int num5 = msg.reader().readByte();
				int num4 = 1;
				try
				{
					num4 = msg.reader().readShort();
				}
				catch (Exception)
				{
				}
				if (Char.getMyChar().arrItemBag[num5].template.type == 24)
				{
					InfoDlg.hide();
				}
				if (Char.getMyChar().arrItemBag[num5].template.type == 16)
				{
					GameScr.hpPotion--;
				}
				if (Char.getMyChar().arrItemBag[num5].template.type == 17)
				{
					GameScr.mpPotion--;
				}
				if (Char.getMyChar().arrItemBag[num5].quantity > num4)
				{
					Char.getMyChar().arrItemBag[num5].quantity -= num4;
				}
				else
				{
					Char.getMyChar().arrItemBag[num5] = null;
				}
				if (GameScr.isPaintInfoMe)
				{
					GameScr.gI().setLCR();
				}
				break;
			}
			case 9:
			{
				GameCanvas.debug("SA39", 2);
				Item item4 = Char.getMyChar().arrItemBag[msg.reader().readUnsignedByte()];
				int num4 = 0;
				try
				{
					num4 = msg.reader().readShort();
				}
				catch (Exception)
				{
					num4 = 1;
				}
				item4.quantity += num4;
				if (item4.template.type == 16)
				{
					GameScr.hpPotion += num4;
				}
				if (item4.template.type == 17)
				{
					GameScr.mpPotion += num4;
				}
				if (item4.template.id == 340)
				{
					GameScr.gI().numSprinLeft += num4;
				}
				GameCanvas.endDlg();
				if (GameScr.isPaintTrade)
				{
					if (GameScr.gI().tradeItemName.Equals(string.Empty))
					{
						GameScr.gI().tradeItemName += item4.template.name;
					}
					else
					{
						GameScr gameScr3 = GameScr.gI();
						gameScr3.tradeItemName = gameScr3.tradeItemName + ", " + item4.template.name;
					}
				}
				else if (item4.template.type != 20)
				{
					InfoMe.addInfo(mResources.RECEIVE + " " + item4.template.name);
				}
				break;
			}
			case 15:
				GameCanvas.debug("SA40", 2);
				Char.getMyChar().itemBodyToBag(msg);
				break;
			case 16:
				GameCanvas.debug("SA41", 2);
				Char.getMyChar().itemBoxToBag(msg);
				break;
			case 108:
				Char.getMyChar().itemMonToBag(msg);
				break;
			case 114:
				GameScr.gI().typeba = msg.reader().readSByte();
				break;
			case 17:
				GameCanvas.debug("SA42", 2);
				Char.getMyChar().itemBagToBox(msg);
				break;
			case 19:
				GameCanvas.debug("SA43", 2);
				Char.getMyChar().crystalCollect(msg, isCoin: true);
				break;
			case 20:
				GameCanvas.debug("SA44", 2);
				Char.getMyChar().crystalCollect(msg, isCoin: false);
				break;
			case 21:
			{
				GameCanvas.debug("SA45", 2);
				int num51 = msg.reader().readByte();
				Char.getMyChar().luong = msg.reader().readInt();
				Char.getMyChar().xu = msg.reader().readInt();
				Char.getMyChar().yen = msg.reader().readInt();
				if (GameScr.itemUpGrade != null)
				{
					GameScr.itemUpGrade.upgrade = msg.reader().readByte();
					GameScr.itemUpGrade.isLock = true;
					GameScr.itemUpGrade.clearExpire();
					if (num51 == 1)
					{
						GameScr.effUpok = GameScr.efs[53];
						GameScr.indexEff = 0;
					}
				}
				if (GameScr.arrItemUpGrade != null)
				{
					for (int num52 = 0; num52 < GameScr.arrItemUpGrade.Length; num52++)
					{
						GameScr.arrItemUpGrade[num52] = null;
					}
				}
				if (num51 == 5 || num51 == 6)
				{
					if (GameScr.itemSplit != null)
					{
						GameScr.itemSplit = null;
					}
					if (GameScr.arrItemSplit != null)
					{
						for (int num53 = 0; num53 < GameScr.arrItemSplit.Length; num53++)
						{
							GameScr.arrItemSplit[num53] = null;
						}
					}
				}
				GameScr.gI().left = (GameScr.gI().center = null);
				GameScr.gI().updateKeyBuyItemUI();
				GameCanvas.endDlg();
				switch (num51)
				{
				case 5:
					InfoMe.addInfo(mResources.TYPEKHAMNGOC[0] + GameScr.itemUpGrade.upgrade, 20, mFont.tahoma_7_white);
					break;
				case 6:
					InfoMe.addInfo(mResources.TYPEKHAMNGOC[1] + GameScr.itemUpGrade.upgrade, 20, mFont.tahoma_7_red);
					break;
				case 1:
					InfoMe.addInfo(mResources.TYPEUPGRADE[0] + GameScr.itemUpGrade.upgrade, 20, mFont.tahoma_7_white);
					break;
				default:
					InfoMe.addInfo(mResources.TYPEUPGRADE[1] + GameScr.itemUpGrade.upgrade, 20, mFont.tahoma_7_red);
					break;
				}
				break;
			}
			case 112:
			{
				Item item2 = Char.getMyChar().arrItemBag[msg.reader().readByte()];
				item2.upgrade = msg.reader().readByte();
				item2.expires = 0L;
				break;
			}
			case 22:
			{
				GameCanvas.debug("SA46", 2);
				int num15 = msg.reader().readByte();
				string text5 = mResources.SPLIT_ITEM_NAME;
				for (int j = 0; j < GameScr.arrItemSplit.Length; j++)
				{
					GameScr.arrItemSplit[j] = null;
				}
				for (int k = 0; k < num15; k++)
				{
					Item item3 = new Item();
					item3.typeUI = 3;
					item3.indexUI = msg.reader().readByte();
					item3.template = ItemTemplates.get(msg.reader().readShort());
					item3.expires = -1L;
					item3.quantity = 1;
					item3.isLock = GameScr.itemSplit.isLock;
					Char.getMyChar().arrItemBag[item3.indexUI] = item3;
					text5 += item3.template.name;
					if (k < num15 - 1)
					{
						text5 += ", ";
					}
				}
				GameScr.itemSplit.upgrade = 0;
				GameScr.itemSplit.clearExpire();
				GameScr.gI().left = (GameScr.gI().center = null);
				GameScr.gI().updateCommandForUI();
				GameCanvas.endDlg();
				InfoMe.addInfo(text5);
				GameScr.effUpok = GameScr.efs[66];
				GameScr.indexEff = 0;
				break;
			}
			case 11:
			{
				int num5 = msg.reader().readByte();
				if (Char.getMyChar().arrItemBag[num5].template.type == 24)
				{
					InfoDlg.hide();
				}
				Char.getMyChar().useItem(num5);
				Char.getMyChar().readParam(msg, "Cmd.ITEM_USE");
				Char.getMyChar().eff5BuffHp = msg.reader().readShort();
				Char.getMyChar().eff5BuffMp = msg.reader().readShort();
				GameScr.gI().setLCR();
				break;
			}
			case 43:
			{
				GameCanvas.debug("SA48", 2);
				int num95 = msg.reader().readInt();
				Char char11 = GameScr.findCharInMap(num95);
				if (char11 != null)
				{
					GameCanvas.startYesNoDlg(char11.cName + " " + mResources.INVITETRADE, 88810, num95, 88811, null);
				}
				break;
			}
			case 65:
			{
				GameCanvas.debug("SA48", 2);
				Char char10 = GameScr.findCharInMap(msg.reader().readInt());
				if (char10 != null)
				{
					GameCanvas.startYesNoDlg(char10.cName + " " + mResources.INVITETEST, 88812, char10, 8882, null);
				}
				break;
			}
			case 99:
			{
				Out.println("Vao DUN >>>>>");
				GameCanvas.debug("SA48", 2);
				Char char10 = GameScr.findCharInMap(msg.reader().readInt());
				if (char10 != null)
				{
					GameCanvas.startYesNoDlg(char10.cName + " " + mResources.INVITETESTDUN, 88840, char10, 8882, null);
				}
				break;
			}
			case 106:
			{
				GameCanvas.debug("SA48", 2);
				Char char10 = GameScr.findCharInMap(msg.reader().readInt());
				if (char10 != null)
				{
					GameCanvas.startYesNoDlg(char10.cName + " " + mResources.INVITETESTGT, 88841, char10, 8882, null);
				}
				break;
			}
			case 100:
			{
				GameScr.vList.removeAllElements();
				int num21 = msg.reader().readByte();
				DunItem dunItem = null;
				for (int num84 = 0; num84 < num21; num84++)
				{
					try
					{
						dunItem = new DunItem();
						dunItem.id = msg.reader().readByte();
						dunItem.name1 = msg.reader().readUTF();
						dunItem.name2 = msg.reader().readUTF();
						GameScr.vList.addElement(dunItem);
					}
					catch (Exception)
					{
					}
				}
				GameScr.gI().doShowListUI();
				break;
			}
			case 66:
			{
				GameCanvas.debug("SZ1", 2);
				int num6 = msg.reader().readInt();
				int num7 = msg.reader().readInt();
				if (num6 != Char.getMyChar().charID && num7 != Char.getMyChar().charID)
				{
					GameScr.findCharInMap(num6).testCharId = num7;
					GameScr.findCharInMap(num7).testCharId = num6;
				}
				else if (num6 == Char.getMyChar().charID)
				{
					Char.getMyChar().testCharId = num7;
					Char.getMyChar().npcFocus = null;
					Char.getMyChar().mobFocus = null;
					Char.getMyChar().itemFocus = null;
					Char.getMyChar().charFocus = GameScr.findCharInMap(Char.getMyChar().testCharId);
					Char.getMyChar().charFocus.testCharId = Char.getMyChar().charID;
					GameScr.gI().cPreFocusID = GameScr.gI().cLastFocusID;
					GameScr.gI().cLastFocusID = num7;
					Char.isManualFocus = true;
				}
				else if (num7 == Char.getMyChar().charID)
				{
					Char.getMyChar().testCharId = num6;
					Char.getMyChar().npcFocus = null;
					Char.getMyChar().mobFocus = null;
					Char.getMyChar().itemFocus = null;
					Char.getMyChar().charFocus = GameScr.findCharInMap(Char.getMyChar().testCharId);
					Char.getMyChar().charFocus.testCharId = Char.getMyChar().charID;
					GameScr.gI().cPreFocusID = GameScr.gI().cLastFocusID;
					GameScr.gI().cLastFocusID = num6;
					Char.isManualFocus = true;
				}
				break;
			}
			case 67:
			{
				GameCanvas.debug("SZ2", 2);
				int num6 = msg.reader().readInt();
				int num7 = msg.reader().readInt();
				int num8 = 0;
				try
				{
					num8 = msg.reader().readInt();
				}
				catch (Exception)
				{
				}
				if (num6 == Char.getMyChar().charID)
				{
					Char char4 = GameScr.findCharInMap(num7);
					if (num8 > 0)
					{
						InfoMe.addInfo(mResources.replace(mResources.YOU_LOST, char4.cName));
						Char.getMyChar().cHP = num8;
						Char.getMyChar().resultTest = 29;
						if (char4 != null)
						{
							char4.resultTest = 89;
						}
					}
					else
					{
						if (char4 != null)
						{
							char4.resultTest = 59;
						}
						Char.getMyChar().resultTest = 59;
						InfoMe.addInfo(mResources.replace(mResources.TEST_END, char4.cName));
					}
					Char.getMyChar().testCharId = -9999;
					Char.getMyChar().charFocus = null;
					if (GameScr.gI().cPreFocusID >= 0)
					{
						GameScr.gI().cLastFocusID = GameScr.gI().cPreFocusID;
						GameScr.gI().cPreFocusID = -1;
					}
					else
					{
						GameScr.gI().cLastFocusID = -1;
					}
					if (char4 != null)
					{
						char4.testCharId = -9999;
					}
				}
				else if (num7 == Char.getMyChar().charID)
				{
					Char char4 = GameScr.findCharInMap(num6);
					if (num8 > 0)
					{
						if (char4 != null)
						{
							char4.cHP = num8;
						}
						if (char4 != null)
						{
							char4.resultTest = 29;
						}
						Char.getMyChar().resultTest = 89;
						InfoMe.addInfo(mResources.replace(mResources.YOU_WIN, char4.cName));
					}
					else
					{
						if (char4 != null)
						{
							char4.resultTest = 59;
						}
						Char.getMyChar().resultTest = 59;
						InfoMe.addInfo(mResources.replace(mResources.TEST_END, char4.cName));
					}
					if (char4 != null)
					{
						char4.testCharId = -9999;
					}
					Char.getMyChar().testCharId = -9999;
					Char.getMyChar().charFocus = null;
					if (GameScr.gI().cPreFocusID >= 0)
					{
						GameScr.gI().cLastFocusID = GameScr.gI().cPreFocusID;
						GameScr.gI().cPreFocusID = -1;
					}
					else
					{
						GameScr.gI().cLastFocusID = -1;
					}
				}
				else
				{
					@char = GameScr.findCharInMap(num6);
					char2 = GameScr.findCharInMap(num7);
					if (num8 > 0)
					{
						if (@char != null)
						{
							@char.cHP = num8;
						}
						if (@char != null)
						{
							@char.resultTest = 29;
						}
						if (char2 != null)
						{
							char2.resultTest = 89;
						}
					}
					else
					{
						if (@char != null)
						{
							@char.resultTest = 59;
						}
						if (char2 != null)
						{
							char2.resultTest = 59;
						}
					}
					if (@char != null)
					{
						@char.testCharId = -9999;
					}
					if (char2 != null)
					{
						char2.testCharId = -9999;
					}
				}
				break;
			}
			case 68:
			{
				GameCanvas.debug("SZ3", 2);
				Char char4 = GameScr.findCharInMap(msg.reader().readInt());
				if (char4 != null)
				{
					char4.killCharId = Char.getMyChar().charID;
					Char.getMyChar().npcFocus = null;
					Char.getMyChar().mobFocus = null;
					Char.getMyChar().itemFocus = null;
					Char.getMyChar().charFocus = char4;
					Char.isManualFocus = true;
					InfoMe.addInfo(char4.cName + mResources.CUU_SAT, 20, mFont.tahoma_7_red);
				}
				break;
			}
			case 69:
				GameCanvas.debug("SZ4", 2);
				Char.getMyChar().killCharId = msg.reader().readInt();
				Char.getMyChar().npcFocus = null;
				Char.getMyChar().mobFocus = null;
				Char.getMyChar().itemFocus = null;
				Char.getMyChar().charFocus = GameScr.findCharInMap(Char.getMyChar().killCharId);
				Char.isManualFocus = true;
				break;
			case 70:
			{
				GameCanvas.debug("SZ5", 2);
				Char char4 = Char.getMyChar();
				try
				{
					char4 = GameScr.findCharInMap(msg.reader().readInt());
				}
				catch (Exception)
				{
				}
				char4.killCharId = -9999;
				break;
			}
			case 46:
				GameCanvas.debug("SA49", 2);
				GameScr.gI().typeTradeOrder = 2;
				if (GameScr.gI().typeTrade >= 2 && GameScr.gI().typeTradeOrder >= 2)
				{
					InfoDlg.showWait();
				}
				break;
			case 45:
			{
				GameCanvas.debug("SA50", 2);
				GameScr.gI().typeTradeOrder = 1;
				GameScr.gI().coinTradeOrder = msg.reader().readInt();
				GameScr.arrItemTradeOrder = new Item[12];
				int num86 = msg.reader().readByte();
				for (int num87 = 0; num87 < num86; num87++)
				{
					GameScr.arrItemTradeOrder[num87] = new Item();
					GameScr.arrItemTradeOrder[num87].typeUI = 3;
					GameScr.arrItemTradeOrder[num87].indexUI = num87;
					GameScr.arrItemTradeOrder[num87].template = ItemTemplates.get(msg.reader().readShort());
					GameScr.arrItemTradeOrder[num87].isLock = false;
					if (GameScr.arrItemTradeOrder[num87].isTypeBody() || GameScr.arrItemTradeOrder[num87].isTypeNgocKham())
					{
						GameScr.arrItemTradeOrder[num87].upgrade = msg.reader().readByte();
					}
					GameScr.arrItemTradeOrder[num87].isExpires = msg.reader().readBoolean();
					GameScr.arrItemTradeOrder[num87].quantity = msg.reader().readShort();
				}
				if (GameScr.gI().typeTrade == 1 && GameScr.gI().typeTradeOrder == 1)
				{
					GameScr.gI().timeTrade = (int)(mSystem.getCurrentTimeMillis() / 1000 + 5);
				}
				break;
			}
			case 63:
			{
				GameCanvas.debug("SZ6", 2);
				MyVector myVector = new MyVector();
				while (true)
				{
					try
					{
						myVector.addElement(new Command(msg.reader().readUTF(), GameCanvas.instance, 88817, null));
					}
					catch (Exception)
					{
						break;
						IL_2b0b:;
					}
				}
				GameCanvas.menu.startAt(myVector, 3);
				break;
			}
			case 27:
			{
				GameCanvas.debug("SZ7", 2);
				int iD = msg.reader().readUnsignedByte();
				Mob mob4 = Mob.get_Mob(iD);
				int num9 = msg.reader().readInt();
				if (mob4 != null)
				{
					Char char4 = (num9 != Char.getMyChar().charID) ? GameScr.findCharInMap(num9) : Char.getMyChar();
					if (char4 != null)
					{
						char4.moveFast = new short[3];
						char4.moveFast[0] = 0;
						char4.moveFast[1] = (short)mob4.x;
						char4.moveFast[2] = (short)mob4.y;
					}
				}
				break;
			}
			case 64:
			{
				GameCanvas.debug("SZ7", 2);
				int num9 = msg.reader().readInt();
				@char = ((num9 != Char.getMyChar().charID) ? GameScr.findCharInMap(num9) : Char.getMyChar());
				@char.moveFast = new short[3];
				@char.moveFast[0] = 0;
				short num81 = msg.reader().readShort();
				short num82 = msg.reader().readShort();
				@char.moveFast[1] = num81;
				@char.moveFast[2] = num82;
				try
				{
					num9 = msg.reader().readInt();
					char2 = ((num9 != Char.getMyChar().charID) ? GameScr.findCharInMap(num9) : Char.getMyChar());
					char2.cx = num81;
					char2.cy = num82;
				}
				catch (Exception)
				{
					Out.println(" loi tai cmd   " + msg.command);
				}
				break;
			}
			case 92:
			{
				string info = msg.reader().readUTF();
				short num83 = msg.reader().readShort();
				GameCanvas.inputDlg.show(info, new Command(mResources.ACCEPT, GameCanvas.instance, 88818, num83), TField.INPUT_TYPE_ANY);
				break;
			}
			case 34:
			{
				MyVector myVector = new MyVector();
				string text14 = msg.reader().readUTF();
				if (!text14.Equals(string.Empty))
				{
					GameScr.gI().showAlert(null, text14, withMenuShow: true);
				}
				int num21 = msg.reader().readByte();
				for (int num79 = 0; num79 < num21; num79++)
				{
					string caption = msg.reader().readUTF();
					short num80 = msg.reader().readShort();
					myVector.addElement(new Command(caption, GameCanvas.instance, 88819, num80));
				}
				GameCanvas.menu.startAt(myVector, 3);
				break;
			}
			case 40:
			{
				GameCanvas.debug("SA51", 2);
				InfoDlg.hide();
				GameCanvas.clearKeyHold();
				GameCanvas.clearKeyPressed();
				MyVector myVector = new MyVector();
				try
				{
					while (true)
					{
						myVector.addElement(new Command(msg.reader().readUTF(), GameCanvas.instance, 88822, null));
					}
					IL_2de8:;
				}
				catch (Exception)
				{
				}
				if (Char.getMyChar().npcFocus == null)
				{
					return;
				}
				for (int num78 = 0; num78 < Char.getMyChar().npcFocus.template.menu.Length; num78++)
				{
					string[] array7 = Char.getMyChar().npcFocus.template.menu[num78];
					myVector.addElement(new Command(array7[0], GameCanvas.instance, 88820, array7));
				}
				GameCanvas.menu.startAt(myVector, 3);
				break;
			}
			case 109:
			{
				GameCanvas.debug("SA51", 2);
				InfoDlg.hide();
				GameCanvas.clearKeyHold();
				GameCanvas.clearKeyPressed();
				MyVector myVector = new MyVector();
				try
				{
					int num73 = msg.reader().readByte();
					for (int num74 = 0; num74 < num73; num74++)
					{
						string[] array5 = new string[msg.reader().readByte()];
						for (int num75 = 0; num75 < array5.Length; num75++)
						{
							array5[num75] = msg.reader().readUTF();
						}
						myVector.addElement(new Command(array5[0], GameCanvas.instance, 88820, array5));
					}
				}
				catch (Exception)
				{
				}
				if (Char.getMyChar().npcFocus == null)
				{
					return;
				}
				GameCanvas.menu.startAt(myVector, 3);
				break;
			}
			case 47:
			{
				GameCanvas.debug("SA52", 2);
				GameCanvas.taskTick = 150;
				short taskId = msg.reader().readShort();
				sbyte index = msg.reader().readByte();
				string name = msg.reader().readUTF();
				string detail = msg.reader().readUTF();
				string[] array3 = new string[msg.reader().readByte()];
				short[] array4 = new short[array3.Length];
				short count = -1;
				for (int num70 = 0; num70 < array3.Length; num70++)
				{
					string text12 = msg.reader().readUTF();
					array4[num70] = -1;
					if (!text12.Equals(string.Empty))
					{
						array3[num70] = text12;
					}
				}
				try
				{
					count = msg.reader().readShort();
					for (int num71 = 0; num71 < array3.Length; num71++)
					{
						array4[num71] = msg.reader().readShort();
					}
				}
				catch (Exception)
				{
				}
				Char.getMyChar().taskMaint = new Task(taskId, index, name, detail, array3, array4, count);
				Char.getMyChar().callEffTask(21);
				if (Char.getMyChar().npcFocus != null)
				{
					Npc.clearEffTask();
				}
				break;
			}
			case 48:
				GameCanvas.debug("SA53", 2);
				GameCanvas.taskTick = 100;
				Char.getMyChar().taskMaint.index++;
				Char.getMyChar().taskMaint.count = 0;
				if (Char.getMyChar().npcFocus != null && Char.getMyChar().npcFocus.chatPopup != null && Char.getMyChar().taskMaint.index >= 2)
				{
					Char.getMyChar().npcFocus.chatPopup = null;
				}
				if (Char.getMyChar().taskMaint.index >= Char.getMyChar().taskMaint.subNames.Length - 1)
				{
					Char.getMyChar().callEffTask(61);
				}
				else
				{
					Char.getMyChar().callEffTask(21);
				}
				Npc.clearEffTask();
				break;
			case 49:
				GameCanvas.debug("SA54", 2);
				Char.getMyChar().ctaskId++;
				Char.getMyChar().clearTask();
				break;
			case 50:
				GameCanvas.taskTick = 50;
				GameCanvas.debug("SA55", 2);
				Char.getMyChar().taskMaint.count = msg.reader().readShort();
				if (Char.getMyChar().npcFocus != null)
				{
					Npc.clearEffTask();
				}
				break;
			case 93:
			{
				int num9 = msg.reader().readInt();
				GameScr.currentCharViewInfo = new Char();
				if (Char.getMyChar().charID == num9)
				{
					GameScr.currentCharViewInfo = Char.getMyChar();
				}
				else
				{
					Char char4 = GameScr.findCharInMap(num9);
					if (char4 == null)
					{
						GameScr.currentCharViewInfo = new Char();
					}
					else
					{
						GameScr.currentCharViewInfo = char4;
					}
					GameScr.currentCharViewInfo.charID = num9;
					GameScr.currentCharViewInfo.statusMe = 1;
					GameScr.gI().showViewInfo();
				}
				GameScr.currentCharViewInfo.cName = msg.reader().readUTF();
				GameScr.currentCharViewInfo.head = msg.reader().readShort();
				GameScr.currentCharViewInfo.cgender = msg.reader().readByte();
				int num55 = msg.reader().readByte();
				GameScr.currentCharViewInfo.nClass = GameScr.nClasss[num55];
				GameScr.currentCharViewInfo.cPk = msg.reader().readByte();
				GameScr.currentCharViewInfo.cHP = msg.reader().readInt();
				GameScr.currentCharViewInfo.cMaxHP = msg.reader().readInt();
				GameScr.currentCharViewInfo.cMP = msg.reader().readInt();
				GameScr.currentCharViewInfo.cMaxMP = msg.reader().readInt();
				GameScr.currentCharViewInfo.cspeed = msg.reader().readByte();
				GameScr.currentCharViewInfo.cResFire = msg.reader().readShort();
				GameScr.currentCharViewInfo.cResIce = msg.reader().readShort();
				GameScr.currentCharViewInfo.cResWind = msg.reader().readShort();
				GameScr.currentCharViewInfo.cdame = msg.reader().readInt();
				GameScr.currentCharViewInfo.cdameDown = msg.reader().readInt();
				GameScr.currentCharViewInfo.cExactly = msg.reader().readShort();
				GameScr.currentCharViewInfo.cMiss = msg.reader().readShort();
				GameScr.currentCharViewInfo.cFatal = msg.reader().readShort();
				GameScr.currentCharViewInfo.cReactDame = msg.reader().readShort();
				GameScr.currentCharViewInfo.sysUp = msg.reader().readShort();
				GameScr.currentCharViewInfo.sysDown = msg.reader().readShort();
				GameScr.currentCharViewInfo.clevel = msg.reader().readUnsignedByte();
				GameScr.currentCharViewInfo.pointUydanh = msg.reader().readShort();
				GameScr.currentCharViewInfo.cClanName = msg.reader().readUTF();
				if (!GameScr.currentCharViewInfo.cClanName.Equals(string.Empty))
				{
					GameScr.currentCharViewInfo.ctypeClan = msg.reader().readByte();
				}
				GameScr.currentCharViewInfo.pointUydanh = msg.reader().readShort();
				GameScr.currentCharViewInfo.pointNon = msg.reader().readShort();
				GameScr.currentCharViewInfo.pointAo = msg.reader().readShort();
				GameScr.currentCharViewInfo.pointGangtay = msg.reader().readShort();
				GameScr.currentCharViewInfo.pointQuan = msg.reader().readShort();
				GameScr.currentCharViewInfo.pointGiay = msg.reader().readShort();
				GameScr.currentCharViewInfo.pointVukhi = msg.reader().readShort();
				GameScr.currentCharViewInfo.pointLien = msg.reader().readShort();
				GameScr.currentCharViewInfo.pointNhan = msg.reader().readShort();
				GameScr.currentCharViewInfo.pointNgocboi = msg.reader().readShort();
				GameScr.currentCharViewInfo.pointPhu = msg.reader().readShort();
				GameScr.currentCharViewInfo.countFinishDay = msg.reader().readByte();
				GameScr.currentCharViewInfo.countLoopBoos = msg.reader().readByte();
				GameScr.currentCharViewInfo.countPB = msg.reader().readByte();
				GameScr.currentCharViewInfo.limitTiemnangso = msg.reader().readByte();
				GameScr.currentCharViewInfo.limitKynangso = msg.reader().readByte();
				GameScr.currentCharViewInfo.arrItemBody = new Item[16];
				try
				{
					GameScr.currentCharViewInfo.setDefaultPart();
					for (int num56 = 0; num56 < GameScr.currentCharViewInfo.arrItemBody.Length; num56++)
					{
						ItemTemplate itemTemplate = ItemTemplates.get(msg.reader().readShort());
						int num5 = itemTemplate.type;
						GameScr.currentCharViewInfo.arrItemBody[num5] = new Item();
						GameScr.currentCharViewInfo.arrItemBody[num5].indexUI = num5;
						GameScr.currentCharViewInfo.arrItemBody[num5].typeUI = 5;
						GameScr.currentCharViewInfo.arrItemBody[num5].template = itemTemplate;
						GameScr.currentCharViewInfo.arrItemBody[num5].isLock = true;
						GameScr.currentCharViewInfo.arrItemBody[num5].upgrade = msg.reader().readByte();
						GameScr.currentCharViewInfo.arrItemBody[num5].sys = msg.reader().readByte();
						switch (num5)
						{
						case 1:
							GameScr.currentCharViewInfo.wp = GameScr.currentCharViewInfo.arrItemBody[num5].template.part;
							break;
						case 2:
							GameScr.currentCharViewInfo.body = GameScr.currentCharViewInfo.arrItemBody[num5].template.part;
							break;
						case 6:
							GameScr.currentCharViewInfo.leg = GameScr.currentCharViewInfo.arrItemBody[num5].template.part;
							break;
						}
					}
				}
				catch (Exception)
				{
				}
				try
				{
				}
				catch (Exception)
				{
				}
				break;
			}
			case 101:
				try
				{
					GameScr.currentCharViewInfo.pointTinhTu = msg.reader().readInt();
					GameScr.currentCharViewInfo.limitPhongLoi = msg.reader().readByte();
					GameScr.currentCharViewInfo.limitBangHoa = msg.reader().readByte();
				}
				catch (Exception)
				{
				}
				break;
			case 42:
				GameCanvas.debug("SA57", 2);
				requestItemInfo(msg);
				break;
			case 94:
				GameCanvas.debug("SA577", 2);
				requestItemPlayer(msg);
				break;
			case 36:
				GameCanvas.debug("SA58", 2);
				GameScr.gI().openUIZone(msg);
				break;
			case 37:
				GameCanvas.debug("SA59", 2);
				GameScr.gI().tradeName = msg.reader().readUTF();
				GameScr.gI().openUITrade();
				break;
			case -15:
			{
				GameCanvas.debug("SA60", 2);
				short num18 = msg.reader().readShort();
				for (int num50 = 0; num50 < GameScr.vItemMap.size(); num50++)
				{
					ItemMap itemMap5 = (ItemMap)GameScr.vItemMap.elementAt(num50);
					if (itemMap5 != null && itemMap5.itemMapID == num18)
					{
						GameScr.vItemMap.removeElementAt(num50);
						break;
					}
				}
				break;
			}
			case -14:
			{
				GameCanvas.debug("SA61", 2);
				Char.getMyChar().itemFocus = null;
				short num18 = msg.reader().readShort();
				for (int num49 = 0; num49 < GameScr.vItemMap.size(); num49++)
				{
					ItemMap itemMap4 = (ItemMap)GameScr.vItemMap.elementAt(num49);
					if (itemMap4.itemMapID == num18)
					{
						itemMap4.setPoint(Char.getMyChar().cx, Char.getMyChar().cy - 10);
						if (itemMap4.template.type == 19)
						{
							num = msg.reader().readUnsignedShort();
							Char.getMyChar().yen += num;
							if (itemMap4.template.id != 238)
							{
								InfoMe.addInfo(mResources.RECEIVE + " " + num + " " + mResources.YEN);
							}
						}
						else if (itemMap4.template.type == 25 && itemMap4.template.id != 238)
						{
							InfoMe.addInfo(mResources.RECEIVE + " " + itemMap4.template.name, 15, mFont.tahoma_7_yellow);
						}
						break;
					}
				}
				break;
			}
			case -13:
			{
				GameCanvas.debug("SA62", 2);
				short num18 = msg.reader().readShort();
				for (int m = 0; m < GameScr.vItemMap.size(); m++)
				{
					ItemMap itemMap2 = (ItemMap)GameScr.vItemMap.elementAt(m);
					if (itemMap2 != null && itemMap2.itemMapID == num18)
					{
						Char char4 = GameScr.findCharInMap(msg.reader().readInt());
						if (char4 != null)
						{
							itemMap2.setPoint(char4.cx, char4.cy - 10);
							if (itemMap2.x < char4.cx)
							{
								char4.cdir = -1;
							}
							else if (itemMap2.x > char4.cx)
							{
								char4.cdir = 1;
							}
							break;
						}
						return;
					}
				}
				break;
			}
			case -12:
			{
				GameCanvas.debug("SA63", 2);
				int num5 = msg.reader().readByte();
				GameScr.vItemMap.addElement(new ItemMap(msg.reader().readShort(), Char.getMyChar().arrItemBag[num5].template.id, Char.getMyChar().cx, Char.getMyChar().cy, msg.reader().readShort(), msg.reader().readShort()));
				Char.getMyChar().arrItemBag[num5] = null;
				break;
			}
			case 6:
			{
				GameCanvas.debug("SA6333", 2);
				ItemMap itemMap = new ItemMap(msg.reader().readShort(), msg.reader().readShort(), msg.reader().readShort(), msg.reader().readShort());
				sbyte[] array = NinjaUtil.readByteArray_Int(msg);
				if (array != null && array.Length > 0)
				{
					itemMap.imgCaptcha = new MyImage();
					itemMap.imgCaptcha.img = createImage(array);
				}
				GameScr.vItemMap.addElement(itemMap);
				break;
			}
			case 7:
				GameCanvas.debug("SA633355", 2);
				Char.getMyChar().arrItemBag[msg.reader().readByte()].quantity = msg.reader().readShort();
				break;
			case 75:
			{
				GameCanvas.debug("SA6333e55", 2);
				BuNhin buNhin = new BuNhin(msg.reader().readUTF(), msg.reader().readShort(), msg.reader().readShort());
				GameScr.vBuNhin.addElement(buNhin);
				ServerEffect.addServerEffect(60, buNhin.x, buNhin.y, 1);
				break;
			}
			case 76:
			{
				GameCanvas.debug("SA6333e155", 2);
				int iD = msg.reader().readUnsignedByte();
				Mob mob2 = Mob.get_Mob(iD);
				if (mob2 != null)
				{
					BuNhin buNhin = GameScr.findBuNhinInMap(msg.reader().readShort());
					if (buNhin == null)
					{
						return;
					}
					short idSkill_atk = msg.reader().readShort();
					sbyte typeAtk = msg.reader().readByte();
					sbyte typeTool = msg.reader().readByte();
					mob2.setAttack(buNhin);
					mob2.setTypeAtk(idSkill_atk, typeAtk, typeTool);
				}
				break;
			}
			case 77:
			{
				GameCanvas.debug("SA6333e255", 2);
				BuNhin buNhin = (BuNhin)GameScr.vBuNhin.elementAt(msg.reader().readShort());
				if (buNhin != null)
				{
					GameScr.vBuNhin.removeElement(buNhin);
					ServerEffect.addServerEffect(60, buNhin.x, buNhin.y, 1);
				}
				break;
			}
			case -6:
			{
				GameCanvas.debug("SA64", 2);
				Char char4 = GameScr.findCharInMap(msg.reader().readInt());
				if (char4 == null)
				{
					return;
				}
				GameScr.vItemMap.addElement(new ItemMap(msg.reader().readShort(), msg.reader().readShort(), char4.cx, char4.cy, msg.reader().readShort(), msg.reader().readShort()));
				break;
			}
			case -16:
				GameCanvas.debug("SA65", 2);
				Char.isLockKey = true;
				Char.ischangingMap = true;
				if (!Main.isPC)
				{
					GameCanvas.startWaitDlgIpad(mResources.PLEASEWAIT, isIpad: true);
				}
				GameScr.gI().timeStartMap = 0;
				GameScr.gI().timeLengthMap = 0;
				Char.getMyChar().mobFocus = null;
				Char.getMyChar().npcFocus = null;
				Char.getMyChar().charFocus = null;
				Char.getMyChar().itemFocus = null;
				Char.getMyChar().focus.removeAllElements();
				Char.getMyChar().testCharId = -9999;
				Char.getMyChar().killCharId = -9999;
				GameScr.resetAllvector();
				GameCanvas.resetBg();
				if (GameScr.vParty.size() <= 1)
				{
					GameScr.vParty.removeAllElements();
				}
				GameScr.gI().resetButton();
				GameScr.gI().center = null;
				break;
			case 30:
			{
				sbyte b11 = msg.reader().readByte();
				GameScr.gI().doOpenUI(b11);
				break;
			}
			case 38:
			{
				GameCanvas.debug("SA67", 2);
				int num92 = msg.reader().readShort();
				for (int num96 = 0; num96 < GameScr.vNpc.size(); num96++)
				{
					Npc npc2 = (Npc)GameScr.vNpc.elementAt(num96);
					if (npc2 != null && npc2.template.npcTemplateId == num92 && npc2.Equals(Char.getMyChar().npcFocus))
					{
						ChatPopup.addChatPopupMultiLine(msg.reader().readUTF(), 1000, npc2);
						break;
					}
				}
				break;
			}
			case 39:
			{
				GameCanvas.debug("SA68", 2);
				int num92 = msg.reader().readShort();
				for (int num93 = 0; num93 < GameScr.vNpc.size(); num93++)
				{
					Npc npc = (Npc)GameScr.vNpc.elementAt(num93);
					if (npc != null && npc.template.npcTemplateId == num92 && npc.Equals(Char.getMyChar().npcFocus))
					{
						ChatPopup.addChatPopup(msg.reader().readUTF(), 1000, npc);
						string[] array9 = new string[msg.reader().readByte()];
						for (int num94 = 0; num94 < array9.Length; num94++)
						{
							array9[num94] = msg.reader().readUTF();
						}
						GameScr.gI().createMenu(array9, npc);
						break;
					}
				}
				break;
			}
			case 31:
				GameCanvas.debug("SA69", 2);
				Char.getMyChar().xuInBox = msg.reader().readInt();
				Char.getMyChar().arrItemBox = new Item[msg.reader().readUnsignedByte()];
				for (int num90 = 0; num90 < Char.getMyChar().arrItemBox.Length; num90++)
				{
					short num91 = msg.reader().readShort();
					if (num91 != -1)
					{
						Char.getMyChar().arrItemBox[num90] = new Item();
						Char.getMyChar().arrItemBox[num90].typeUI = 4;
						Char.getMyChar().arrItemBox[num90].indexUI = num90;
						Char.getMyChar().arrItemBox[num90].template = ItemTemplates.get(num91);
						Char.getMyChar().arrItemBox[num90].isLock = msg.reader().readBoolean();
						if (Char.getMyChar().arrItemBox[num90].isTypeBody() || Char.getMyChar().arrItemBox[num90].isTypeNgocKham())
						{
							Char.getMyChar().arrItemBox[num90].upgrade = msg.reader().readByte();
						}
						Char.getMyChar().arrItemBox[num90].isExpires = msg.reader().readBoolean();
						Char.getMyChar().arrItemBox[num90].quantity = msg.reader().readShort();
					}
				}
				break;
			case 13:
				GameCanvas.debug("SA70", 2);
				Char.getMyChar().xu = msg.reader().readInt();
				Char.getMyChar().yen = msg.reader().readInt();
				Char.getMyChar().luong = msg.reader().readInt();
				GameCanvas.endDlg();
				break;
			case 33:
			{
				GameCanvas.debug("SA72", 2);
				sbyte b3 = msg.reader().readByte();
				if (b3 == 14)
				{
					GameScr.arrItemStore = new Item[msg.reader().readByte()];
					for (int num25 = 0; num25 < GameScr.arrItemStore.Length; num25++)
					{
						GameScr.arrItemStore[num25] = new Item();
						GameScr.arrItemStore[num25].typeUI = 14;
						GameScr.arrItemStore[num25].indexUI = msg.reader().readUnsignedByte();
						GameScr.arrItemStore[num25].template = ItemTemplates.get(msg.reader().readShort());
					}
				}
				else if (b3 == 15)
				{
					GameScr.arrItemBook = new Item[msg.reader().readByte()];
					for (int num26 = 0; num26 < GameScr.arrItemBook.Length; num26++)
					{
						GameScr.arrItemBook[num26] = new Item();
						GameScr.arrItemBook[num26].typeUI = 15;
						GameScr.arrItemBook[num26].indexUI = msg.reader().readUnsignedByte();
						GameScr.arrItemBook[num26].template = ItemTemplates.get(msg.reader().readShort());
					}
				}
				else if (b3 == 32)
				{
					GameScr.arrItemFashion = new Item[msg.reader().readByte()];
					for (int num27 = 0; num27 < GameScr.arrItemFashion.Length; num27++)
					{
						GameScr.arrItemFashion[num27] = new Item();
						GameScr.arrItemFashion[num27].typeUI = 32;
						GameScr.arrItemFashion[num27].indexUI = msg.reader().readUnsignedByte();
						GameScr.arrItemFashion[num27].template = ItemTemplates.get(msg.reader().readShort());
					}
				}
				else if (b3 == 34)
				{
					GameScr.arrItemClanShop = new Item[msg.reader().readByte()];
					for (int num28 = 0; num28 < GameScr.arrItemClanShop.Length; num28++)
					{
						GameScr.arrItemClanShop[num28] = new Item();
						GameScr.arrItemClanShop[num28].typeUI = 34;
						GameScr.arrItemClanShop[num28].indexUI = msg.reader().readUnsignedByte();
						GameScr.arrItemClanShop[num28].template = ItemTemplates.get(msg.reader().readShort());
					}
				}
				else if (b3 == 35)
				{
					GameScr.arrItemElites = new Item[msg.reader().readByte()];
					for (int num29 = 0; num29 < GameScr.arrItemElites.Length; num29++)
					{
						GameScr.arrItemElites[num29] = new Item();
						GameScr.arrItemElites[num29].typeUI = 35;
						GameScr.arrItemElites[num29].indexUI = msg.reader().readUnsignedByte();
						GameScr.arrItemElites[num29].template = ItemTemplates.get(msg.reader().readShort());
					}
				}
				else if (b3 == 20)
				{
					GameScr.arrItemNonNam = new Item[msg.reader().readByte()];
					for (int num30 = 0; num30 < GameScr.arrItemNonNam.Length; num30++)
					{
						GameScr.arrItemNonNam[num30] = new Item();
						GameScr.arrItemNonNam[num30].typeUI = b3;
						GameScr.arrItemNonNam[num30].indexUI = msg.reader().readUnsignedByte();
						GameScr.arrItemNonNam[num30].template = ItemTemplates.get(msg.reader().readShort());
					}
				}
				else if (b3 == 21)
				{
					GameScr.arrItemNonNu = new Item[msg.reader().readByte()];
					for (int num31 = 0; num31 < GameScr.arrItemNonNu.Length; num31++)
					{
						GameScr.arrItemNonNu[num31] = new Item();
						GameScr.arrItemNonNu[num31].typeUI = b3;
						GameScr.arrItemNonNu[num31].indexUI = msg.reader().readUnsignedByte();
						GameScr.arrItemNonNu[num31].template = ItemTemplates.get(msg.reader().readShort());
					}
				}
				else if (b3 == 22)
				{
					GameScr.arrItemAoNam = new Item[msg.reader().readByte()];
					for (int num32 = 0; num32 < GameScr.arrItemAoNam.Length; num32++)
					{
						GameScr.arrItemAoNam[num32] = new Item();
						GameScr.arrItemAoNam[num32].typeUI = b3;
						GameScr.arrItemAoNam[num32].indexUI = msg.reader().readUnsignedByte();
						GameScr.arrItemAoNam[num32].template = ItemTemplates.get(msg.reader().readShort());
					}
				}
				else if (b3 == 23)
				{
					GameScr.arrItemAoNu = new Item[msg.reader().readByte()];
					for (int num33 = 0; num33 < GameScr.arrItemAoNu.Length; num33++)
					{
						GameScr.arrItemAoNu[num33] = new Item();
						GameScr.arrItemAoNu[num33].typeUI = b3;
						GameScr.arrItemAoNu[num33].indexUI = msg.reader().readUnsignedByte();
						GameScr.arrItemAoNu[num33].template = ItemTemplates.get(msg.reader().readShort());
					}
				}
				else if (b3 == 24)
				{
					GameScr.arrItemGangTayNam = new Item[msg.reader().readByte()];
					for (int num34 = 0; num34 < GameScr.arrItemGangTayNam.Length; num34++)
					{
						GameScr.arrItemGangTayNam[num34] = new Item();
						GameScr.arrItemGangTayNam[num34].typeUI = b3;
						GameScr.arrItemGangTayNam[num34].indexUI = msg.reader().readUnsignedByte();
						GameScr.arrItemGangTayNam[num34].template = ItemTemplates.get(msg.reader().readShort());
					}
				}
				else if (b3 == 25)
				{
					GameScr.arrItemGangTayNu = new Item[msg.reader().readByte()];
					for (int num35 = 0; num35 < GameScr.arrItemGangTayNu.Length; num35++)
					{
						GameScr.arrItemGangTayNu[num35] = new Item();
						GameScr.arrItemGangTayNu[num35].typeUI = b3;
						GameScr.arrItemGangTayNu[num35].indexUI = msg.reader().readUnsignedByte();
						GameScr.arrItemGangTayNu[num35].template = ItemTemplates.get(msg.reader().readShort());
					}
				}
				else if (b3 == 26)
				{
					GameScr.arrItemQuanNam = new Item[msg.reader().readByte()];
					for (int num36 = 0; num36 < GameScr.arrItemQuanNam.Length; num36++)
					{
						GameScr.arrItemQuanNam[num36] = new Item();
						GameScr.arrItemQuanNam[num36].typeUI = b3;
						GameScr.arrItemQuanNam[num36].indexUI = msg.reader().readUnsignedByte();
						GameScr.arrItemQuanNam[num36].template = ItemTemplates.get(msg.reader().readShort());
					}
				}
				else if (b3 == 27)
				{
					GameScr.arrItemQuanNu = new Item[msg.reader().readByte()];
					for (int num37 = 0; num37 < GameScr.arrItemQuanNu.Length; num37++)
					{
						GameScr.arrItemQuanNu[num37] = new Item();
						GameScr.arrItemQuanNu[num37].typeUI = b3;
						GameScr.arrItemQuanNu[num37].indexUI = msg.reader().readUnsignedByte();
						GameScr.arrItemQuanNu[num37].template = ItemTemplates.get(msg.reader().readShort());
					}
				}
				else if (b3 == 28)
				{
					GameScr.arrItemGiayNam = new Item[msg.reader().readByte()];
					for (int num38 = 0; num38 < GameScr.arrItemGiayNam.Length; num38++)
					{
						GameScr.arrItemGiayNam[num38] = new Item();
						GameScr.arrItemGiayNam[num38].typeUI = b3;
						GameScr.arrItemGiayNam[num38].indexUI = msg.reader().readUnsignedByte();
						GameScr.arrItemGiayNam[num38].template = ItemTemplates.get(msg.reader().readShort());
					}
				}
				else if (b3 == 29)
				{
					GameScr.arrItemGiayNu = new Item[msg.reader().readByte()];
					for (int num39 = 0; num39 < GameScr.arrItemGiayNu.Length; num39++)
					{
						GameScr.arrItemGiayNu[num39] = new Item();
						GameScr.arrItemGiayNu[num39].typeUI = b3;
						GameScr.arrItemGiayNu[num39].indexUI = msg.reader().readUnsignedByte();
						GameScr.arrItemGiayNu[num39].template = ItemTemplates.get(msg.reader().readShort());
					}
				}
				else if (b3 == 16)
				{
					GameScr.arrItemLien = new Item[msg.reader().readByte()];
					for (int num40 = 0; num40 < GameScr.arrItemLien.Length; num40++)
					{
						GameScr.arrItemLien[num40] = new Item();
						GameScr.arrItemLien[num40].typeUI = b3;
						GameScr.arrItemLien[num40].indexUI = msg.reader().readUnsignedByte();
						GameScr.arrItemLien[num40].template = ItemTemplates.get(msg.reader().readShort());
					}
				}
				else if (b3 == 17)
				{
					GameScr.arrItemNhan = new Item[msg.reader().readByte()];
					for (int num41 = 0; num41 < GameScr.arrItemNhan.Length; num41++)
					{
						GameScr.arrItemNhan[num41] = new Item();
						GameScr.arrItemNhan[num41].typeUI = b3;
						GameScr.arrItemNhan[num41].indexUI = msg.reader().readUnsignedByte();
						GameScr.arrItemNhan[num41].template = ItemTemplates.get(msg.reader().readShort());
					}
				}
				else if (b3 == 18)
				{
					GameScr.arrItemNgocBoi = new Item[msg.reader().readByte()];
					for (int num42 = 0; num42 < GameScr.arrItemNgocBoi.Length; num42++)
					{
						GameScr.arrItemNgocBoi[num42] = new Item();
						GameScr.arrItemNgocBoi[num42].typeUI = b3;
						GameScr.arrItemNgocBoi[num42].indexUI = msg.reader().readUnsignedByte();
						GameScr.arrItemNgocBoi[num42].template = ItemTemplates.get(msg.reader().readShort());
					}
				}
				else if (b3 == 19)
				{
					GameScr.arrItemPhu = new Item[msg.reader().readByte()];
					for (int num43 = 0; num43 < GameScr.arrItemPhu.Length; num43++)
					{
						GameScr.arrItemPhu[num43] = new Item();
						GameScr.arrItemPhu[num43].typeUI = b3;
						GameScr.arrItemPhu[num43].indexUI = msg.reader().readUnsignedByte();
						GameScr.arrItemPhu[num43].template = ItemTemplates.get(msg.reader().readShort());
					}
				}
				else if (b3 == 2)
				{
					GameScr.arrItemWeapon = new Item[msg.reader().readByte()];
					for (int num44 = 0; num44 < GameScr.arrItemWeapon.Length; num44++)
					{
						GameScr.arrItemWeapon[num44] = new Item();
						GameScr.arrItemWeapon[num44].typeUI = b3;
						GameScr.arrItemWeapon[num44].indexUI = msg.reader().readUnsignedByte();
						GameScr.arrItemWeapon[num44].template = ItemTemplates.get(msg.reader().readShort());
					}
				}
				else if (b3 == 6)
				{
					GameScr.arrItemStack = new Item[msg.reader().readByte()];
					for (int num45 = 0; num45 < GameScr.arrItemStack.Length; num45++)
					{
						GameScr.arrItemStack[num45] = new Item();
						GameScr.arrItemStack[num45].typeUI = b3;
						GameScr.arrItemStack[num45].indexUI = msg.reader().readUnsignedByte();
						GameScr.arrItemStack[num45].template = ItemTemplates.get(msg.reader().readShort());
					}
				}
				else if (b3 == 7)
				{
					GameScr.arrItemStackLock = new Item[msg.reader().readByte()];
					for (int num46 = 0; num46 < GameScr.arrItemStackLock.Length; num46++)
					{
						GameScr.arrItemStackLock[num46] = new Item();
						GameScr.arrItemStackLock[num46].typeUI = b3;
						GameScr.arrItemStackLock[num46].isLock = true;
						GameScr.arrItemStackLock[num46].indexUI = msg.reader().readUnsignedByte();
						GameScr.arrItemStackLock[num46].template = ItemTemplates.get(msg.reader().readShort());
					}
				}
				else if (b3 == 8)
				{
					GameScr.arrItemGrocery = new Item[msg.reader().readByte()];
					for (int num47 = 0; num47 < GameScr.arrItemGrocery.Length; num47++)
					{
						GameScr.arrItemGrocery[num47] = new Item();
						GameScr.arrItemGrocery[num47].typeUI = b3;
						GameScr.arrItemGrocery[num47].indexUI = msg.reader().readUnsignedByte();
						GameScr.arrItemGrocery[num47].template = ItemTemplates.get(msg.reader().readShort());
					}
				}
				else if (b3 == 9)
				{
					GameScr.arrItemGroceryLock = new Item[msg.reader().readByte()];
					for (int num48 = 0; num48 < GameScr.arrItemGroceryLock.Length; num48++)
					{
						GameScr.arrItemGroceryLock[num48] = new Item();
						GameScr.arrItemGroceryLock[num48].typeUI = b3;
						GameScr.arrItemGroceryLock[num48].isLock = true;
						GameScr.arrItemGroceryLock[num48].indexUI = msg.reader().readUnsignedByte();
						GameScr.arrItemGroceryLock[num48].template = ItemTemplates.get(msg.reader().readShort());
					}
				}
				break;
			}
			case 103:
				GameScr.indexMenu = msg.reader().readByte();
				GameScr.arrItemStands = new ItemStands[msg.reader().readInt()];
				for (int l = 0; l < GameScr.arrItemStands.Length; l++)
				{
					GameScr.arrItemStands[l] = new ItemStands();
					GameScr.arrItemStands[l].item = new Item();
					GameScr.arrItemStands[l].item.itemId = msg.reader().readInt();
					GameScr.arrItemStands[l].timeStart = (int)(mSystem.getCurrentTimeMillis() / 1000);
					GameScr.arrItemStands[l].timeEnd = msg.reader().readInt();
					GameScr.arrItemStands[l].item.quantity = msg.reader().readUnsignedShort();
					GameScr.arrItemStands[l].seller = msg.reader().readUTF();
					GameScr.arrItemStands[l].price = msg.reader().readInt();
					GameScr.arrItemStands[l].item.template = ItemTemplates.get(msg.reader().readShort());
				}
				GameScr.gI().doOpenUI(37);
				break;
			case 104:
				viewItemAuction(msg);
				break;
			case 102:
			{
				GameCanvas.debug("SA74565", 2);
				Item item = Char.getMyChar().arrItemBag[msg.reader().readByte()];
				if (item != null)
				{
					GameScr.itemSell = item;
				}
				Char.getMyChar().xu = msg.reader().readInt();
				if (GameScr.itemSell != null)
				{
					if (GameScr.itemSell.template.type == 16)
					{
						GameScr.hpPotion -= GameScr.itemSell.quantity;
					}
					if (GameScr.itemSell.template.type == 17)
					{
						GameScr.mpPotion -= GameScr.itemSell.quantity;
					}
					Char.getMyChar().arrItemBag[GameScr.itemSell.indexUI] = null;
					GameScr.itemSell = null;
					GameScr.gI().resetButton();
					InfoMe.addInfo(mResources.SALE_INFO);
				}
				GameCanvas.endDlg();
				break;
			}
			case 14:
			{
				Item item = Char.getMyChar().arrItemBag[msg.reader().readByte()];
				Char.getMyChar().yen = msg.reader().readInt();
				int num4 = 0;
				try
				{
					num4 = msg.reader().readShort();
				}
				catch (Exception)
				{
					num4 = 1;
				}
				item.quantity -= num4;
				if (item.template.type == 16)
				{
					GameScr.hpPotion -= num4;
				}
				if (item.template.type == 17)
				{
					GameScr.mpPotion -= num4;
				}
				if (item.quantity <= 0)
				{
					Char.getMyChar().arrItemBag[item.indexUI] = null;
				}
				GameScr.gI().left = (GameScr.gI().center = null);
				GameScr.gI().updateCommandForUI();
				GameCanvas.endDlg();
				break;
			}
			case -18:
				GameCanvas.isLoading = true;
				GameScr.resetAllvector();
				TileMap.vGo.removeAllElements();
				TileMap.mapID = msg.reader().readUnsignedByte();
				TileMap.tileID = msg.reader().readByte();
				TileMap.bgID = msg.reader().readByte();
				TileMap.typeMap = msg.reader().readByte();
				TileMap.mapName = msg.reader().readUTF();
				TileMap.zoneID = msg.reader().readByte();
				try
				{
					TileMap.loadMapFromResource(TileMap.mapID);
				}
				catch (Exception)
				{
					Out.println("load map from server: " + TileMap.mapID);
					Service.gI().requestMaptemplate(TileMap.mapID);
					messWait = msg;
					return;
					IL_53bb:;
				}
				Resources.UnloadUnusedAssets();
				GC.Collect();
				loadInfoMap(msg);
				if (Char.getMyChar().mobMe != null)
				{
					Char.getMyChar().mobMe.x = Char.getMyChar().cx;
					Char.getMyChar().mobMe.y = Char.getMyChar().cy - 40;
				}
				break;
			case 4:
			{
				GameCanvas.debug("SA76", 2);
				Char char4 = GameScr.findCharInMap(msg.reader().readInt());
				if (char4 == null)
				{
					return;
				}
				GameCanvas.debug("SA76v1", 2);
				if ((TileMap.tileTypeAtPixel(char4.cx, char4.cy) & TileMap.T_TOP) == TileMap.T_TOP)
				{
					char4.setSkillPaint(GameScr.sks[msg.reader().readByte()], 0);
				}
				else
				{
					char4.setSkillPaint(GameScr.sks[msg.reader().readByte()], 1);
				}
				if (char4.isWolf)
				{
					char4.isWolf = false;
					char4.timeSummon = mSystem.currentTimeMillis();
					if (char4.vitaWolf >= 500)
					{
						ServerEffect.addServerEffect(60, char4, 1);
					}
				}
				if (char4.isMoto)
				{
					char4.isMoto = false;
					char4.isMotoBehind = true;
				}
				GameCanvas.debug("SA76v2", 2);
				int num21 = msg.reader().readByte();
				char4.attMobs = new Mob[num21];
				for (int num88 = 0; num88 < char4.attMobs.Length; num88++)
				{
					int iD = msg.reader().readUnsignedByte();
					mob = Mob.get_Mob(iD);
					char4.attMobs[num88] = mob;
					if (num88 == 0)
					{
						if (char4.cx <= mob.x)
						{
							char4.cdir = 1;
						}
						else
						{
							char4.cdir = -1;
						}
					}
				}
				GameCanvas.debug("SA76v3", 2);
				char4.mobFocus = char4.attMobs[0];
				Char[] array6 = new Char[10];
				int num76 = 0;
				try
				{
					for (num76 = 0; num76 < array6.Length; num76++)
					{
						int num9 = msg.reader().readInt();
						Char char9 = array6[num76] = ((num9 != Char.getMyChar().charID) ? GameScr.findCharInMap(num9) : Char.getMyChar());
						if (num76 == 0)
						{
							if (char4.cx <= char9.cx)
							{
								char4.cdir = 1;
							}
							else
							{
								char4.cdir = -1;
							}
						}
					}
				}
				catch (Exception)
				{
				}
				GameCanvas.debug("SA76v4", 2);
				if (num76 > 0)
				{
					char4.attChars = new Char[num76];
					for (num76 = 0; num76 < char4.attChars.Length; num76++)
					{
						char4.attChars[num76] = array6[num76];
					}
					char4.charFocus = char4.attChars[0];
				}
				GameCanvas.debug("SA76v5", 2);
				break;
			}
			case 60:
			{
				GameCanvas.debug("SA769991", 2);
				Char char4 = GameScr.findCharInMap(msg.reader().readInt());
				if (char4 == null)
				{
					return;
				}
				if ((TileMap.tileTypeAtPixel(char4.cx, char4.cy) & TileMap.T_TOP) == TileMap.T_TOP)
				{
					sbyte b8 = msg.reader().readByte();
					char4.setSkillPaint(GameScr.sks[b8], 0);
					Mob.interestChar.myskill.template.id = b8;
				}
				else
				{
					sbyte b8 = msg.reader().readByte();
					char4.setSkillPaint(GameScr.sks[b8], 1);
					Mob.interestChar.myskill.template.id = b8;
				}
				GameCanvas.debug("SA769991v2", 2);
				if (char4.isWolf)
				{
					char4.isWolf = false;
					char4.timeSummon = mSystem.currentTimeMillis();
					if (char4.vitaWolf >= 500)
					{
						ServerEffect.addServerEffect(60, char4, 1);
					}
				}
				if (char4.isMoto)
				{
					char4.isMoto = false;
					char4.isMotoBehind = true;
					ServerEffect.addServerEffect(60, char4, 1);
				}
				Mob[] array8 = new Mob[10];
				int num76 = 0;
				try
				{
					for (num76 = 0; num76 < array8.Length; num76++)
					{
						if (msg.reader().available() <= 0)
						{
							break;
						}
						int iD = msg.reader().readUnsignedByte();
						mob = (array8[num76] = Mob.get_Mob(iD));
						if (num76 == 0)
						{
							if (char4.cx <= mob.x)
							{
								char4.cdir = 1;
							}
							else
							{
								char4.cdir = -1;
							}
						}
					}
				}
				catch (Exception)
				{
					Out.println("bi vang ra");
				}
				GameCanvas.debug("SA769992", 2);
				if (num76 > 0)
				{
					char4.attMobs = new Mob[num76];
					for (num76 = 0; num76 < char4.attMobs.Length; num76++)
					{
						char4.attMobs[num76] = array8[num76];
					}
					char4.mobFocus = char4.attMobs[0];
				}
				break;
			}
			case 61:
			{
				GameCanvas.debug("SA7666", 2);
				Char char4 = GameScr.findCharInMap(msg.reader().readInt());
				if (char4 == null)
				{
					return;
				}
				if ((TileMap.tileTypeAtPixel(char4.cx, char4.cy) & TileMap.T_TOP) == TileMap.T_TOP)
				{
					sbyte b8 = msg.reader().readByte();
					char4.setSkillPaint(GameScr.sks[b8], 0);
				}
				else
				{
					sbyte b8 = msg.reader().readByte();
					char4.setSkillPaint(GameScr.sks[b8], 1);
				}
				if (char4.isWolf)
				{
					char4.isWolf = false;
					char4.timeSummon = mSystem.getCurrentTimeMillis();
					if (char4.vitaWolf >= 500)
					{
						ServerEffect.addServerEffect(60, char4, 1);
					}
				}
				if (char4.isMoto)
				{
					char4.isMoto = false;
					char4.isMotoBehind = true;
					ServerEffect.addServerEffect(60, char4, 1);
				}
				Char[] array6 = new Char[10];
				int num76 = 0;
				try
				{
					for (num76 = 0; num76 < array6.Length; num76++)
					{
						int num9 = msg.reader().readInt();
						Char char8 = array6[num76] = ((num9 != Char.getMyChar().charID) ? GameScr.findCharInMap(num9) : Char.getMyChar());
						if (num76 == 0)
						{
							if (char4.cx <= char8.cx)
							{
								char4.cdir = 1;
							}
							else
							{
								char4.cdir = -1;
							}
						}
					}
				}
				catch (Exception)
				{
				}
				GameCanvas.debug("SA7666x7", 2);
				if (num76 > 0)
				{
					char4.attChars = new Char[num76];
					for (num76 = 0; num76 < char4.attChars.Length; num76++)
					{
						char4.attChars[num76] = array6[num76];
					}
					char4.charFocus = char4.attChars[0];
				}
				break;
			}
			case -8:
			{
				GameCanvas.debug("SA77", 22);
				int num72 = msg.reader().readInt();
				Char.getMyChar().yen += num72;
				GameScr.gI().yenTemp = num72;
				GameScr.startFlyText((num72 <= 0) ? (string.Empty + num72) : ("+" + num72), Char.getMyChar().cx, Char.getMyChar().cy - Char.getMyChar().ch - 10, 0, -2, mFont.YELLOW);
				break;
			}
			case 95:
			{
				GameCanvas.debug("SA77", 22);
				int num69 = msg.reader().readInt();
				Char.getMyChar().xu += num69;
				GameScr.startFlyText((num69 <= 0) ? (string.Empty + num69) : ("+" + num69), Char.getMyChar().cx, Char.getMyChar().cy - Char.getMyChar().ch - 10, 0, -2, mFont.YELLOW);
				break;
			}
			case 96:
				GameCanvas.debug("SA77a", 22);
				Char.getMyChar().taskOrders.addElement(new TaskOrder(msg.reader().readByte(), msg.reader().readInt(), msg.reader().readInt(), msg.reader().readUTF(), msg.reader().readUTF(), msg.reader().readUnsignedByte(), msg.reader().readUnsignedByte()));
				Char.getMyChar().callEffTask(21);
				break;
			case 97:
			{
				sbyte b7 = msg.reader().readByte();
				for (int num68 = 0; num68 < Char.getMyChar().taskOrders.size(); num68++)
				{
					TaskOrder taskOrder2 = (TaskOrder)Char.getMyChar().taskOrders.elementAt(num68);
					if (taskOrder2 != null && taskOrder2.taskId == b7)
					{
						taskOrder2.count = msg.reader().readInt();
						if (taskOrder2.count == taskOrder2.maxCount)
						{
							Char.getMyChar().callEffTask(61);
						}
						break;
					}
				}
				break;
			}
			case 98:
			{
				sbyte b7 = msg.reader().readByte();
				for (int num67 = 0; num67 < Char.getMyChar().taskOrders.size(); num67++)
				{
					TaskOrder taskOrder = (TaskOrder)Char.getMyChar().taskOrders.elementAt(num67);
					if (taskOrder != null && taskOrder.taskId == b7)
					{
						Char.getMyChar().taskOrders.removeElementAt(num67);
						break;
					}
				}
				Char.getMyChar().callEffTask(21);
				break;
			}
			case -7:
				GameCanvas.debug("SA77", 222);
				num = msg.reader().readInt();
				Char.getMyChar().xu += num;
				Char.getMyChar().yen -= num;
				GameScr.startFlyText("+" + num, Char.getMyChar().cx, Char.getMyChar().cy - Char.getMyChar().ch - 10, 0, -2, mFont.YELLOW);
				break;
			case 5:
			{
				GameCanvas.debug("SA78", 2);
				long num65 = msg.reader().readLong();
				Char.getMyChar().cExpDown = 0L;
				Char.getMyChar().cEXP += num65;
				int clevel = Char.getMyChar().clevel;
				GameScr.setLevel_Exp(Char.getMyChar().cEXP, value: true);
				if (clevel != Char.getMyChar().clevel)
				{
					ServerEffect.addServerEffect(58, Char.getMyChar(), 1);
				}
				GameScr.startFlyText("+" + num65, Char.getMyChar().cx, Char.getMyChar().cy - Char.getMyChar().ch, 0, -2, mFont.GREEN);
				if (num65 >= 1000000)
				{
					InfoMe.addInfo(mResources.RECEIVE + " " + num65 + " " + mResources.EXP, 20, mFont.tahoma_7_yellow);
				}
				break;
			}
			case 71:
			{
				long num65 = msg.reader().readLong();
				Char.getMyChar().cExpDown -= num65;
				GameScr.startFlyText("+" + num65, Char.getMyChar().cx, Char.getMyChar().cy - Char.getMyChar().ch, 0, -2, mFont.GREEN);
				break;
			}
			case 116:
			{
				int charId4 = msg.reader().readInt();
				Char char4 = GameScr.findCharInMap(charId4);
				if (char4 != null)
				{
					readCharInfo(char4, msg);
				}
				break;
			}
			case 3:
			{
				GameCanvas.debug("SA79", 2);
				Char char4 = new Char();
				char4.charID = msg.reader().readInt();
				if (readCharInfo(char4, msg))
				{
					GameScr.vCharInMap.addElement(char4);
				}
				break;
			}
			case 1:
			{
				GameCanvas.debug("SA80", 2);
				int num62 = msg.reader().readInt();
				for (int num64 = 0; num64 < GameScr.vCharInMap.size(); num64++)
				{
					Char char7 = null;
					try
					{
						char7 = (Char)GameScr.vCharInMap.elementAt(num64);
					}
					catch (Exception)
					{
					}
					if (char7 == null)
					{
						break;
					}
					if (char7.charID == num62)
					{
						GameCanvas.debug("SA8x2y" + num64, 2);
						char7.cxMoveLast = msg.reader().readShort();
						char7.cyMoveLast = msg.reader().readShort();
						char7.moveTo(char7.cxMoveLast, char7.cyMoveLast);
						char7.lastUpdateTime = mSystem.getCurrentTimeMillis();
						break;
					}
				}
				GameCanvas.debug("SA80x3", 2);
				break;
			}
			case 2:
			{
				GameCanvas.debug("SA81", 2);
				int num62 = msg.reader().readInt();
				for (int num63 = 0; num63 < GameScr.vCharInMap.size(); num63++)
				{
					Char char6 = (Char)GameScr.vCharInMap.elementAt(num63);
					if (char6 != null && char6.charID == num62)
					{
						if (!char6.isInvisible)
						{
							ServerEffect.addServerEffect(60, char6.cx, char6.cy, 1);
						}
						GameScr.vCharInMap.removeElementAt(num63);
						Party.clear(num62);
						return;
					}
				}
				break;
			}
			case -5:
				GameCanvas.debug("SA82", 2);
				try
				{
					int iD = msg.reader().readUnsignedByte();
					mob = Mob.get_Mob(iD);
					mob.sys = msg.reader().readByte();
					mob.levelBoss = msg.reader().readByte();
					mob.x = mob.xFirst;
					mob.y = mob.yFirst;
					mob.status = 5;
					mob.injureThenDie = false;
					mob.hp = msg.reader().readInt();
					mob.maxHp = mob.hp;
					if (mob.getTemplate().mobTemplateId == 202)
					{
						ServerEffect.addServerEffect(148, mob.x, mob.y, 0);
					}
					else
					{
						ServerEffect.addServerEffect(60, mob.x, mob.y, 1);
					}
				}
				catch (Exception)
				{
				}
				break;
			case -1:
				GameCanvas.debug("SA83", 2);
				mob = null;
				try
				{
					int iD = msg.reader().readUnsignedByte();
					mob = Mob.get_Mob(iD);
				}
				catch (Exception)
				{
				}
				GameCanvas.debug("SA83v1", 2);
				if (mob != null)
				{
					mob.hp = msg.reader().readInt();
					int num58 = msg.reader().readInt();
					if (num58 < 0)
					{
						num58 = Res.abs(num58) + 32767;
					}
					bool flag2 = msg.reader().readBoolean();
					try
					{
						if (msg.reader().available() > 0)
						{
							mob.levelBoss = msg.reader().readByte();
						}
						mob.maxHp = msg.reader().readInt();
					}
					catch (Exception)
					{
					}
					if (flag2)
					{
						GameScr.startFlyText("-" + num58, mob.x, mob.y - mob.h, 0, -2, mFont.FATAL);
					}
					else
					{
						GameScr.startFlyText("-" + num58, mob.x, mob.y - mob.h, 0, -2, mFont.ORANGE);
					}
				}
				break;
			case 51:
				mob = null;
				try
				{
					int iD = msg.reader().readUnsignedByte();
					mob = Mob.get_Mob(iD);
				}
				catch (Exception)
				{
				}
				if (mob != null)
				{
					mob.hp = msg.reader().readInt();
					GameScr.startFlyText(string.Empty, mob.x, mob.y - mob.h, 0, -2, mFont.MISS);
				}
				break;
			case -4:
				mob = null;
				try
				{
					int iD = msg.reader().readUnsignedByte();
					mob = Mob.get_Mob(iD);
				}
				catch (Exception)
				{
				}
				if (mob != null && mob.status != 0 && mob.status != 0)
				{
					mob.startDie();
					try
					{
						int num54 = msg.reader().readInt();
						if (num54 < 0)
						{
							num54 = Res.abs(num54) + 32767;
						}
						if (msg.reader().readBoolean())
						{
							GameScr.startFlyText("-" + num54, mob.x, mob.y - mob.h, 0, -2, mFont.FATAL);
						}
						else
						{
							GameScr.startFlyText("-" + num54, mob.x, mob.y - mob.h, 0, -2, mFont.ORANGE);
						}
						ItemMap itemMap6 = new ItemMap(msg.reader().readShort(), msg.reader().readShort(), mob.x, mob.y, msg.reader().readShort(), msg.reader().readShort());
						GameScr.vItemMap.addElement(itemMap6);
						if (Res.abs(itemMap6.y - Char.getMyChar().cy) < 24 && Res.abs(itemMap6.x - Char.getMyChar().cx) < 24)
						{
							Char.getMyChar().charFocus = null;
						}
					}
					catch (Exception)
					{
					}
				}
				break;
			case 78:
				GameCanvas.debug("SA85", 2);
				mob = null;
				try
				{
					int iD = msg.reader().readUnsignedByte();
					mob = Mob.get_Mob(iD);
				}
				catch (Exception)
				{
				}
				if (mob != null && mob.status != 0 && mob.status != 0)
				{
					mob.status = 0;
					ServerEffect.addServerEffect(60, mob.x, mob.y, 1);
					ItemMap itemMap3 = new ItemMap(msg.reader().readShort(), msg.reader().readShort(), mob.x, mob.y, msg.reader().readShort(), msg.reader().readShort());
					GameScr.vItemMap.addElement(itemMap3);
					if (Res.abs(itemMap3.y - Char.getMyChar().cy) < 24 && Res.abs(itemMap3.x - Char.getMyChar().cx) < 24)
					{
						Char.getMyChar().charFocus = null;
					}
				}
				break;
			case -3:
				GameCanvas.debug("SA86", 2);
				mob = null;
				try
				{
					int iD = msg.reader().readUnsignedByte();
					mob = Mob.get_Mob(iD);
				}
				catch (Exception)
				{
				}
				if (mob != null)
				{
					int num16 = msg.reader().readInt();
					int num17;
					try
					{
						num17 = msg.reader().readInt();
					}
					catch (Exception)
					{
						num17 = 0;
					}
					if (mob.isBusyAttackSomeOne)
					{
						Char.getMyChar().doInjure(num16, num17, isBoss: false, -1);
						mob.attackOtherInRange();
					}
					else
					{
						mob.dame = num16;
						mob.dameMp = num17;
						mob.setAttack(Char.getMyChar());
					}
					short idSkill_atk = msg.reader().readShort();
					sbyte typeAtk = msg.reader().readByte();
					sbyte typeTool = msg.reader().readByte();
					mob.setTypeAtk(idSkill_atk, typeAtk, typeTool);
				}
				break;
			case -2:
			{
				GameCanvas.debug("SA87", 2);
				mob = null;
				try
				{
					int iD = msg.reader().readUnsignedByte();
					mob = Mob.get_Mob(iD);
				}
				catch (Exception)
				{
				}
				int charId2 = msg.reader().readInt();
				int num14 = msg.reader().readInt();
				GameCanvas.debug("SA87x1", 2);
				if (mob != null)
				{
					GameCanvas.debug("SA87x2", 2);
					Char char4 = GameScr.findCharInMap(charId2);
					if (char4 == null)
					{
						return;
					}
					GameCanvas.debug("SA87x3", 2);
					mob.dame = char4.cHP - num14;
					char4.cHpNew = num14;
					GameCanvas.debug("SA87x4", 2);
					try
					{
						char4.cMP = msg.reader().readInt();
					}
					catch (Exception)
					{
					}
					GameCanvas.debug("SA87x5", 2);
					if (mob.isBusyAttackSomeOne)
					{
						char4.doInjure(mob.dame, 0, isBoss: false, -1);
						mob.attackOtherInRange();
					}
					else
					{
						mob.setAttack(char4);
					}
					short idSkill_atk = msg.reader().readShort();
					sbyte typeAtk = msg.reader().readByte();
					sbyte typeTool = msg.reader().readByte();
					mob.setTypeAtk(idSkill_atk, typeAtk, typeTool);
					GameCanvas.debug("SA87x6", 2);
				}
				break;
			}
			case -11:
				GameCanvas.debug("SA88", 2);
				Char.getMyChar().cPk = msg.reader().readByte();
				Char.getMyChar().waitToDie(msg.reader().readShort(), msg.reader().readShort());
				try
				{
					Char.getMyChar().cEXP = msg.reader().readLong();
					GameScr.setLevel_Exp(Char.getMyChar().cEXP, value: true);
				}
				catch (Exception)
				{
				}
				Char.getMyChar().countKill = 0;
				break;
			case 72:
				GameCanvas.debug("SA88", 2);
				Char.getMyChar().cPk = msg.reader().readByte();
				Char.getMyChar().waitToDie(msg.reader().readShort(), msg.reader().readShort());
				Char.getMyChar().cEXP = GameScr.getMaxExp(Char.getMyChar().clevel - 1);
				Char.getMyChar().cExpDown = msg.reader().readLong();
				GameScr.setLevel_Exp(Char.getMyChar().cEXP, value: true);
				break;
			case 0:
			{
				GameCanvas.debug("SA89", 2);
				Char char4 = GameScr.findCharInMap(msg.reader().readInt());
				if (char4 == null)
				{
					return;
				}
				char4.cPk = msg.reader().readByte();
				if (char4.charID == Char.aCID)
				{
					Char.isAFocusDie = true;
				}
				char4.waitToDie(msg.reader().readShort(), msg.reader().readShort());
				if (Char.getMyChar().charFocus == char4)
				{
					Char.getMyChar().charFocus = null;
				}
				break;
			}
			case -10:
				GameCanvas.debug("SA90", 2);
				if (Char.getMyChar().wdx != 0 || Char.getMyChar().wdy != 0)
				{
					Char.getMyChar().cx = Char.getMyChar().wdx;
					Char.getMyChar().cy = Char.getMyChar().wdy;
					Char.getMyChar().wdx = (Char.getMyChar().wdy = 0);
				}
				Char.getMyChar().liveFromDead();
				Char.isLockKey = false;
				break;
			case -23:
			{
				GameCanvas.debug("SA91", 2);
				int num3 = msg.reader().readInt();
				string text = msg.reader().readUTF();
				Char char4 = (Char.getMyChar().charID != num3) ? GameScr.findCharInMap(num3) : Char.getMyChar();
				if (char4 == null)
				{
					return;
				}
				ChatPopup.addChatPopup(text, 100, char4);
				ChatManager.gI().addChat(mResources.PUBLICCHAT[0], char4.cName, text);
				break;
			}
			case 25:
			{
				sbyte b = msg.reader().readByte();
				for (int i = 0; i < b; i++)
				{
					int charId = msg.reader().readInt();
					int cx = msg.reader().readShort();
					int cy = msg.reader().readShort();
					int hPShow = msg.reader().readInt();
					Char char3 = GameScr.findCharInMap(charId);
					if (char3 != null)
					{
						char3.cx = cx;
						char3.cy = cy;
						char3.cHP = (char3.HPShow = hPShow);
						char3.lastUpdateTime = mSystem.getCurrentTimeMillis();
					}
				}
				break;
			}
			case 26:
				Char.getMyChar().countKill = msg.reader().readUnsignedShort();
				Char.getMyChar().countKillMax = msg.reader().readUnsignedShort();
				break;
			case 126:
			{
				int num2 = msg.reader().readByte();
				GameCanvas.endDlg();
				if (num2 == 0)
				{
					GameScr.instance.resetButton();
				}
				break;
			}
			}
			GameCanvas.debug("SA92", 2);
		}
		catch (Exception ex39)
		{
			Out.println("loi tai cmd " + msg.command + " ly do >> " + ex39.ToString());
		}
		finally
		{
			msg?.cleanup();
		}
	}

	private void createItem(myReader d)
	{
		GameScr.vcItem = d.readByte();
		GameScr.iOptionTemplates = new ItemOptionTemplate[d.readByte()];
		for (int i = 0; i < GameScr.iOptionTemplates.Length; i++)
		{
			GameScr.iOptionTemplates[i] = new ItemOptionTemplate();
			GameScr.iOptionTemplates[i].id = i;
			GameScr.iOptionTemplates[i].name = d.readUTF();
			GameScr.iOptionTemplates[i].type = d.readByte();
		}
		int num = d.readShort();
		for (int j = 0; j < num; j++)
		{
			ItemTemplate it = new ItemTemplate((short)j, d.readByte(), d.readByte(), d.readUTF(), d.readUTF(), d.readByte(), d.readShort(), d.readShort(), d.readBoolean());
			ItemTemplates.add(it);
		}
	}

	private void createSkill(myReader d)
	{
		GameScr.vcSkill = d.readByte();
		GameScr.sOptionTemplates = new SkillOptionTemplate[d.readByte()];
		for (int i = 0; i < GameScr.sOptionTemplates.Length; i++)
		{
			GameScr.sOptionTemplates[i] = new SkillOptionTemplate();
			GameScr.sOptionTemplates[i].id = i;
			GameScr.sOptionTemplates[i].name = d.readUTF();
		}
		GameScr.nClasss = new NClass[d.readUnsignedByte()];
		for (int j = 0; j < GameScr.nClasss.Length; j++)
		{
			GameScr.nClasss[j] = new NClass();
			GameScr.nClasss[j].classId = j;
			GameScr.nClasss[j].name = d.readUTF();
			GameScr.nClasss[j].skillTemplates = new SkillTemplate[d.readByte()];
			for (int k = 0; k < GameScr.nClasss[j].skillTemplates.Length; k++)
			{
				GameScr.nClasss[j].skillTemplates[k] = new SkillTemplate();
				GameScr.nClasss[j].skillTemplates[k].id = d.readByte();
				GameScr.nClasss[j].skillTemplates[k].name = d.readUTF();
				GameScr.nClasss[j].skillTemplates[k].maxPoint = d.readByte();
				GameScr.nClasss[j].skillTemplates[k].type = d.readByte();
				GameScr.nClasss[j].skillTemplates[k].iconId = d.readShort();
				int lineWidth = 150;
				if (GameCanvas.w == 128 || GameCanvas.h <= 208)
				{
					lineWidth = 100;
				}
				GameScr.nClasss[j].skillTemplates[k].description = mFont.tahoma_7_white.splitFontArray(d.readUTF(), lineWidth);
				GameScr.nClasss[j].skillTemplates[k].skills = new Skill[d.readByte()];
				for (int l = 0; l < GameScr.nClasss[j].skillTemplates[k].skills.Length; l++)
				{
					GameScr.nClasss[j].skillTemplates[k].skills[l] = new Skill();
					GameScr.nClasss[j].skillTemplates[k].skills[l].skillId = d.readShort();
					GameScr.nClasss[j].skillTemplates[k].skills[l].template = GameScr.nClasss[j].skillTemplates[k];
					GameScr.nClasss[j].skillTemplates[k].skills[l].point = d.readByte();
					GameScr.nClasss[j].skillTemplates[k].skills[l].level = d.readByte();
					GameScr.nClasss[j].skillTemplates[k].skills[l].manaUse = d.readShort();
					GameScr.nClasss[j].skillTemplates[k].skills[l].coolDown = d.readInt();
					GameScr.nClasss[j].skillTemplates[k].skills[l].dx = d.readShort();
					GameScr.nClasss[j].skillTemplates[k].skills[l].dy = d.readShort();
					GameScr.nClasss[j].skillTemplates[k].skills[l].maxFight = d.readByte();
					GameScr.nClasss[j].skillTemplates[k].skills[l].options = new SkillOption[d.readByte()];
					for (int m = 0; m < GameScr.nClasss[j].skillTemplates[k].skills[l].options.Length; m++)
					{
						GameScr.nClasss[j].skillTemplates[k].skills[l].options[m] = new SkillOption();
						GameScr.nClasss[j].skillTemplates[k].skills[l].options[m].param = d.readShort();
						GameScr.nClasss[j].skillTemplates[k].skills[l].options[m].optionTemplate = GameScr.sOptionTemplates[d.readByte()];
					}
					Skills.add(GameScr.nClasss[j].skillTemplates[k].skills[l]);
				}
			}
		}
	}

	private void createMap(myReader d)
	{
		GameScr.vcMap = d.readByte();
		TileMap.mapNames = new string[d.readUnsignedByte()];
		for (int i = 0; i < TileMap.mapNames.Length; i++)
		{
			TileMap.mapNames[i] = d.readUTF();
		}
		Npc.arrNpcTemplate = new NpcTemplate[d.readByte()];
		for (sbyte b = 0; b < Npc.arrNpcTemplate.Length; b = (sbyte)(b + 1))
		{
			Npc.arrNpcTemplate[b] = new NpcTemplate();
			Npc.arrNpcTemplate[b].npcTemplateId = b;
			Npc.arrNpcTemplate[b].name = d.readUTF();
			Npc.arrNpcTemplate[b].headId = d.readShort();
			Npc.arrNpcTemplate[b].bodyId = d.readShort();
			Npc.arrNpcTemplate[b].legId = d.readShort();
			Npc.arrNpcTemplate[b].menu = new string[d.readByte()][];
			for (int j = 0; j < Npc.arrNpcTemplate[b].menu.Length; j++)
			{
				Npc.arrNpcTemplate[b].menu[j] = new string[d.readByte()];
				for (int k = 0; k < Npc.arrNpcTemplate[b].menu[j].Length; k++)
				{
					Npc.arrNpcTemplate[b].menu[j][k] = d.readUTF();
				}
			}
		}
		int num = d.readUnsignedByte();
		Mob.arrMobTemplate = new MobTemplate[num];
		for (int l = 0; l < num; l++)
		{
			Mob.arrMobTemplate[l] = new MobTemplate();
			Mob.arrMobTemplate[l].mobTemplateId = (short)l;
			Mob.arrMobTemplate[l].type = d.readByte();
			Mob.arrMobTemplate[l].name = d.readUTF();
			Mob.arrMobTemplate[l].hp = d.readInt();
			Mob.arrMobTemplate[l].rangeMove = d.readByte();
			Mob.arrMobTemplate[l].speed = d.readByte();
		}
	}

	private void createData(myReader d)
	{
		GameScr.vcData = d.readByte();
		RMS.saveRMS("nj_arrow", NinjaUtil.readByteArray(d));
		RMS.saveRMS("nj_effect", NinjaUtil.readByteArray(d));
		RMS.saveRMS("nj_image", NinjaUtil.readByteArray(d));
		RMS.saveRMS("nj_part", NinjaUtil.readByteArray(d));
		RMS.saveRMS("nj_skill", NinjaUtil.readByteArray(d));
		GameScr.tasks = new sbyte[d.readByte()][];
		GameScr.mapTasks = new sbyte[GameScr.tasks.Length][];
		for (int i = 0; i < GameScr.tasks.Length; i++)
		{
			GameScr.tasks[i] = new sbyte[d.readByte()];
			GameScr.mapTasks[i] = new sbyte[GameScr.tasks[i].Length];
			for (int j = 0; j < GameScr.tasks[i].Length; j++)
			{
				GameScr.tasks[i][j] = d.readByte();
				GameScr.mapTasks[i][j] = d.readByte();
			}
		}
		GameScr.exps = new long[d.readUnsignedByte()];
		for (int k = 0; k < GameScr.exps.Length; k++)
		{
			GameScr.exps[k] = d.readLong();
		}
		GameScr.crystals = new int[d.readByte()];
		for (int l = 0; l < GameScr.crystals.Length; l++)
		{
			GameScr.crystals[l] = d.readInt();
		}
		GameScr.upClothe = new int[d.readByte()];
		for (int m = 0; m < GameScr.upClothe.Length; m++)
		{
			GameScr.upClothe[m] = d.readInt();
		}
		GameScr.upAdorn = new int[d.readByte()];
		for (int n = 0; n < GameScr.upAdorn.Length; n++)
		{
			GameScr.upAdorn[n] = d.readInt();
		}
		GameScr.upWeapon = new int[d.readByte()];
		for (int num = 0; num < GameScr.upWeapon.Length; num++)
		{
			GameScr.upWeapon[num] = d.readInt();
		}
		GameScr.coinUpCrystals = new int[d.readByte()];
		for (int num2 = 0; num2 < GameScr.coinUpCrystals.Length; num2++)
		{
			GameScr.coinUpCrystals[num2] = d.readInt();
		}
		GameScr.coinUpClothes = new int[d.readByte()];
		for (int num3 = 0; num3 < GameScr.coinUpClothes.Length; num3++)
		{
			GameScr.coinUpClothes[num3] = d.readInt();
		}
		GameScr.coinUpAdorns = new int[d.readByte()];
		for (int num4 = 0; num4 < GameScr.coinUpAdorns.Length; num4++)
		{
			GameScr.coinUpAdorns[num4] = d.readInt();
		}
		GameScr.coinUpWeapons = new int[d.readByte()];
		for (int num5 = 0; num5 < GameScr.coinUpWeapons.Length; num5++)
		{
			GameScr.coinUpWeapons[num5] = d.readInt();
		}
		GameScr.goldUps = new int[d.readByte()];
		for (int num6 = 0; num6 < GameScr.goldUps.Length; num6++)
		{
			GameScr.goldUps[num6] = d.readInt();
		}
		GameScr.maxPercents = new int[d.readByte()];
		for (int num7 = 0; num7 < GameScr.maxPercents.Length; num7++)
		{
			GameScr.maxPercents[num7] = d.readInt();
		}
		Effect.effTemplates = new EffectTemplate[d.readByte()];
		for (int num8 = 0; num8 < Effect.effTemplates.Length; num8++)
		{
			Effect.effTemplates[num8] = new EffectTemplate();
			Effect.effTemplates[num8].id = d.readByte();
			Effect.effTemplates[num8].type = d.readByte();
			Effect.effTemplates[num8].name = d.readUTF();
			Effect.effTemplates[num8].iconId = d.readShort();
		}
	}

	public static Image createImage(sbyte[] arr)
	{
		try
		{
			return Image.createImage(arr, 0, arr.Length);
			IL_0010:;
		}
		catch (Exception)
		{
			Out.println("loi tao hinh tai createImage cua controler");
		}
		return null;
	}

	public int[] arraysbyte2Int(sbyte[] b)
	{
		int[] array = new int[b.Length];
		for (int i = 0; i < b.Length; i++)
		{
			int num = b[i];
			if (num < 0)
			{
				num += 256;
			}
			array[i] = num;
		}
		return array;
	}

	public void loadInfoMap(Message msg)
	{
		try
		{
			Char.getMyChar().cx = (Char.getMyChar().cxSend = (Char.getMyChar().cxFocus = msg.reader().readShort()));
			Char.getMyChar().cy = (Char.getMyChar().cySend = (Char.getMyChar().cyFocus = msg.reader().readShort()));
			int num = msg.reader().readByte();
			for (int i = 0; i < num; i++)
			{
				TileMap.vGo.addElement(new Waypoint(msg.reader().readShort(), msg.reader().readShort(), msg.reader().readShort(), msg.reader().readShort()));
			}
			num = msg.reader().readByte();
			for (sbyte b = 0; b < num; b = (sbyte)(b + 1))
			{
				Mob mob = new Mob(b, msg.reader().readBoolean(), msg.reader().readBoolean(), msg.reader().readBoolean(), msg.reader().readBoolean(), msg.reader().readBoolean(), msg.reader().readUnsignedByte(), msg.reader().readByte(), msg.reader().readInt(), msg.reader().readUnsignedByte(), msg.reader().readInt(), msg.reader().readShort(), msg.reader().readShort(), msg.reader().readByte(), msg.reader().readByte(), msg.reader().readBoolean(), removeWhenDie: false);
				if (Mob.arrMobTemplate[mob.templateId].type != 0)
				{
					if (b % 3 == 0)
					{
						mob.dir = -1;
					}
					else
					{
						mob.dir = 1;
					}
					mob.x += 10 - b % 20;
				}
				GameScr.vMob.addElement(mob);
			}
			num = msg.reader().readByte();
			for (byte b2 = 0; b2 < num; b2 = (byte)(b2 + 1))
			{
				GameScr.vBuNhin.addElement(new BuNhin(msg.reader().readUTF(), msg.reader().readShort(), msg.reader().readShort()));
			}
			num = msg.reader().readByte();
			for (int j = 0; j < num; j++)
			{
				GameScr.vNpc.addElement(new Npc(j, msg.reader().readByte(), msg.reader().readShort(), msg.reader().readShort(), msg.reader().readByte()));
			}
			num = msg.reader().readByte();
			for (int k = 0; k < num; k++)
			{
				ItemMap itemMap = new ItemMap(msg.reader().readShort(), msg.reader().readShort(), msg.reader().readShort(), msg.reader().readShort());
				bool flag = false;
				for (int l = 0; l < GameScr.vItemMap.size(); l++)
				{
					ItemMap itemMap2 = (ItemMap)GameScr.vItemMap.elementAt(l);
					if (itemMap2.itemMapID == itemMap.itemMapID)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					GameScr.vItemMap.addElement(itemMap);
				}
			}
			GameScr.loadCamera(fullScreen: false);
			try
			{
				TileMap.mapName1 = null;
				TileMap.mapName1 = msg.reader().readUTF();
				TileMap.mapName = TileMap.mapName1;
			}
			catch (Exception)
			{
			}
			try
			{
				TileMap.locationStand.clear();
				int num2 = msg.reader().readUnsignedByte();
				for (int m = 0; m < num2; m++)
				{
					int num3 = msg.reader().readUnsignedByte();
					int num4 = msg.reader().readUnsignedByte();
					string k2 = (short)(num4 * TileMap.tmw + num3) + string.Empty;
					TileMap.locationStand.put(k2, "location");
				}
			}
			catch (Exception ex2)
			{
				ex2.ToString();
			}
			TileMap.loadMap(TileMap.tileID);
			Char.getMyChar().cvx = 0;
			Char.getMyChar().statusMe = 4;
			GameScr.gI().loadGameScr();
			GameCanvas.loadBG(TileMap.bgID);
			Char.isLockKey = false;
			Char.ischangingMap = false;
			GameCanvas.clearKeyHold();
			GameCanvas.clearKeyPressed();
			GameScr.gI().switchToMe();
			InfoDlg.hide();
			InfoDlg.show(TileMap.mapName, mResources.ZONE + " " + TileMap.zoneID, 30);
			Party.refreshAll();
			GameCanvas.endDlg();
			GameCanvas.isLoading = false;
		}
		catch (Exception ex3)
		{
			Debug.Log("EROR: " + ex3.Message);
		}
	}

	public void messageNotMap(Message msg)
	{
		GameCanvas.debug("SA6", 2);
		try
		{
			switch (msg.reader().readByte())
			{
			case -125:
			case -124:
			case -118:
			case -105:
			case -104:
			case -103:
			case -102:
			case -101:
			case -100:
			case -94:
			case -92:
			case -91:
			case -89:
			case -87:
			case -85:
			case -82:
			case -79:
			case -78:
			case -76:
			case -75:
			case -74:
			case -73:
			case -71:
			case -69:
			case -68:
			case -65:
			case -64:
			case -63:
				break;
			case -98:
				Char.getMyChar().clearTask();
				break;
			case -99:
			{
				GameCanvas.input2Dlg.setTitle(mResources.SERI_NUM, mResources.CARD_CODE);
				string info = msg.reader().readUTF();
				GameCanvas.input2Dlg.show(info, new Command(mResources.CLOSE, GameCanvas.instance, 8882, null), new Command(mResources.CHARGE, GameCanvas.instance, 88816, null), TField.INPUT_TYPE_ANY, TField.INPUT_TYPE_NUMERIC);
				break;
			}
			case -97:
			{
				GameCanvas.isLoading = false;
				GameCanvas.endDlg();
				int num23 = msg.reader().readInt();
				GameCanvas.inputDlg.show(mResources.NAME_CHANGE, new Command("OK", GameCanvas.instance, 88829, num23), TField.INPUT_TYPE_ANY);
				break;
			}
			case -115:
			{
				int id = msg.reader().readInt();
				sbyte[] data7 = NinjaUtil.readByteArray(msg);
				SmallImage.reciveImage(id, data7);
				break;
			}
			case -117:
				Char.getMyChar().cPk = msg.reader().readByte();
				Info.addInfo(mResources.PK_NOW + " " + Char.getMyChar().cPk, 15, mFont.tahoma_7_yellow);
				Char.getMyChar().callEffTask(21);
				break;
			case -96:
				Char.getMyChar().cClanName = msg.reader().readUTF();
				Char.getMyChar().ctypeClan = 4;
				Char.getMyChar().luong = msg.reader().readInt();
				Char.getMyChar().callEffTask(21);
				break;
			case -113:
				Out.println("vao REQUEST_CLAN_INFO roi ");
				if (Char.clan == null)
				{
					Char.clan = new Clan();
				}
				Char.clan.name = msg.reader().readUTF();
				Char.clan.main_name = msg.reader().readUTF();
				Char.clan.assist_name = msg.reader().readUTF();
				Char.clan.total = msg.reader().readShort();
				Char.clan.openDun = msg.reader().readByte();
				Char.clan.level = msg.reader().readByte();
				Char.clan.exp = msg.reader().readInt();
				Char.clan.expNext = msg.reader().readInt();
				Char.clan.coin = msg.reader().readInt();
				Char.clan.freeCoin = msg.reader().readInt();
				Char.clan.coinUp = msg.reader().readInt();
				Char.clan.reg_date = msg.reader().readUTF();
				Char.clan.alert = msg.reader().readUTF();
				Char.clan.use_card = msg.reader().readInt();
				Char.clan.itemLevel = msg.reader().readByte();
				break;
			case -93:
			{
				int num = msg.reader().readInt();
				if (num == Char.getMyChar().charID)
				{
					GameScr.vClan.removeAllElements();
					Char.getMyChar().cClanName = string.Empty;
					Char.getMyChar().ctypeClan = -1;
					Char.clan = null;
				}
				else
				{
					GameScr.vClan.removeAllElements();
					Char char3 = GameScr.findCharInMap(num);
					char3.cClanName = string.Empty;
					char3.ctypeClan = -1;
				}
				break;
			}
			case -114:
				if (Char.clan == null)
				{
					Char.clan = new Clan();
				}
				Char.clan.writeLog(msg.reader().readUTF());
				break;
			case -62:
				Char.clan.itemLevel = msg.reader().readByte();
				break;
			case -81:
				Char.pointChienTruong = msg.reader().readShort();
				break;
			case -77:
				TileMap.bgID = msg.reader().readByte();
				GameCanvas.loadBG(TileMap.bgID);
				break;
			case -70:
			{
				string replacement = msg.reader().readUTF();
				GameCanvas.startYesNoDlg(NinjaUtil.replace(mResources.INVITE_TO_CBT, "#", replacement), new Command(mResources.YES, GameCanvas.instance, 88842, null), new Command(mResources.NO, GameCanvas.instance, 8882, null));
				break;
			}
			case -72:
				GameScr.gI().yenValue = new string[9];
				GameScr.arrItemSprin = new short[9];
				if (GameScr.indexSelect < 0 || GameScr.indexSelect > 8)
				{
					GameScr.indexSelect = (GameScr.indexCard = 0);
				}
				if (GameScr.indexSelect < 0 || GameScr.indexSelect > 8)
				{
					GameScr.indexSelect = (GameScr.indexCard = 0);
				}
				for (int num18 = 0; num18 < 9; num18++)
				{
					GameScr.arrItemSprin[num18] = msg.reader().readShort();
					GameScr.gI().yenValue[num18] = GameScr.gI().YenCards[NinjaUtil.randomNumber(6)];
				}
				GameScr.gI().left = new Command(mResources.CONTINUE, null, 1506, null);
				GameScr.gI().timePoint = mSystem.getCurrentTimeMillis();
				GameScr.gI().numSprinLeft--;
				GameCanvas.endDlg();
				break;
			case -88:
			{
				GameScr.gI().resetButton();
				Item item = Char.getMyChar().arrItemBag[msg.reader().readByte()];
				item.clearExpire();
				item.isLock = true;
				item.upgrade = msg.reader().readByte();
				Item item2 = Char.getMyChar().arrItemBag[msg.reader().readByte()];
				item2.clearExpire();
				item2.isLock = true;
				item2.upgrade = msg.reader().readByte();
				Info.addInfo(mResources.CONVERT_OK, 20, mFont.tahoma_7b_yellow);
				break;
			}
			case -112:
			{
				GameScr.vClan.removeAllElements();
				int num2 = msg.reader().readShort();
				for (int i = 0; i < num2; i++)
				{
					GameScr.vClan.addElement(new Member(msg.reader().readByte(), msg.reader().readByte(), msg.reader().readByte(), msg.reader().readUTF(), msg.reader().readInt(), msg.reader().readBoolean()));
				}
				try
				{
					for (int j = 0; j < num2; j++)
					{
						((Member)GameScr.vClan.elementAt(j)).pointClanWeek = msg.reader().readInt();
					}
				}
				catch (Exception)
				{
				}
				GameScr.gI().sortClan();
				break;
			}
			case -111:
			{
				Char.clan.items = new Item[30];
				int num3 = msg.reader().readByte();
				for (int k = 0; k < num3; k++)
				{
					Char.clan.items[k] = new Item();
					Char.clan.items[k].typeUI = 39;
					Char.clan.items[k].indexUI = k;
					Char.clan.items[k].quantity = msg.reader().readShort();
					Char.clan.items[k].template = ItemTemplates.get(msg.reader().readShort());
				}
				GameScr.gI().clearVecThanThu();
				sbyte b = msg.reader().readByte();
				for (int l = 0; l < b; l++)
				{
					string name = msg.reader().readUTF();
					short idIconItem = msg.reader().readShort();
					short idThanThu = msg.reader().readShort();
					int num4 = msg.reader().readInt();
					string str_trungno = string.Empty;
					MyVector myVector = new MyVector();
					int curExp = -1;
					int maxExp = -1;
					sbyte b2 = msg.reader().readByte();
					if (num4 >= 0)
					{
						str_trungno = msg.reader().readUTF();
					}
					else
					{
						for (int m = 0; m < b2; m++)
						{
							string o = msg.reader().readUTF();
							myVector.addElement(o);
						}
						curExp = msg.reader().readInt();
						maxExp = msg.reader().readInt();
					}
					sbyte stars = msg.reader().readByte();
					GameScr.gI().addInfo_ThanThu(new Clan_ThanThu(name, stars, idIconItem, idThanThu, num4, str_trungno, myVector, curExp, maxExp));
				}
				break;
			}
			case -116:
				Char.getMyChar().xu = msg.reader().readInt();
				Char.clan.coin = msg.reader().readInt();
				break;
			case -90:
				Char.getMyChar().xu = msg.reader().readInt();
				GameScr.gI().resetButton();
				break;
			case -86:
				GameCanvas.endDlg();
				GameScr.gI().resetButton();
				InfoMe.addInfo(msg.reader().readUTF(), 20, mFont.tahoma_7_yellow);
				break;
			case -106:
				GameScr.typeActive = msg.reader().readByte();
				Out.println("load Me Active: " + GameScr.typeActive);
				break;
			case -84:
				Char.pointPB = msg.reader().readShort();
				break;
			case -80:
				GameScr.gI().showAlert(mResources.RESULT, msg.reader().readUTF(), withMenuShow: false);
				if (msg.reader().readBoolean())
				{
					GameScr.gI().left = new Command(mResources.REWARD, 2000);
				}
				break;
			case -83:
			{
				int num19 = msg.reader().readShort();
				int num20 = msg.reader().readShort();
				int num21 = msg.reader().readByte();
				int num22 = msg.reader().readShort();
				if (num19 == 0)
				{
					GameScr.gI().showAlert(mResources.REVIEW, "          " + mResources.EMPTY_INFO, withMenuShow: false);
				}
				else
				{
					string text = mResources.PROPERTY + ": " + num19 + "\n\n";
					string text2;
					if (num20 == 0)
					{
						text = text + mResources.NOT_FINISH + "\n\n";
					}
					else
					{
						text2 = text;
						text = text2 + mResources.TIME_FINISH + ": " + NinjaUtil.getTime(num20) + "\n\n";
					}
					text2 = text;
					text = text2 + mResources.TEAMWORK + ": " + num21 + "\n\n";
					text2 = text;
					text = text2 + mResources.REWARD + ": " + num22 + " " + mResources.LUCKY_GIFT + "\n\n";
					GameScr.gI().showAlert(mResources.REVIEW, text, withMenuShow: false);
					if (num22 > 0)
					{
						GameScr.gI().left = new Command(mResources.REWARD, 1000);
					}
				}
				break;
			}
			case -95:
				if (Char.clan != null)
				{
					Char.clan.alert = msg.reader().readUTF();
				}
				break;
			case -126:
			{
				GameCanvas.debug("SA7", 2);
				int num3 = msg.reader().readByte();
				LoginScr.isLoggingIn = false;
				SelectCharScr.gI().initSelectChar();
				for (sbyte b3 = 0; b3 < num3; b3 = (sbyte)(b3 + 1))
				{
					SelectCharScr.gI().gender[b3] = msg.reader().readByte();
					SelectCharScr.gI().name[b3] = msg.reader().readUTF();
					SelectCharScr.gI().phai[b3] = msg.reader().readUTF();
					SelectCharScr.gI().level[b3] = msg.reader().readUnsignedByte();
					SelectCharScr.gI().parthead[b3] = msg.reader().readShort();
					SelectCharScr.gI().partWp[b3] = msg.reader().readShort();
					SelectCharScr.gI().partbody[b3] = msg.reader().readShort();
					SelectCharScr.gI().partleg[b3] = msg.reader().readShort();
					if (SelectCharScr.gI().partWp[b3] == -1)
					{
						SelectCharScr.gI().partWp[b3] = 15;
					}
					if (SelectCharScr.gI().partbody[b3] == -1)
					{
						if (SelectCharScr.gI().gender[b3] == 0)
						{
							SelectCharScr.gI().partbody[b3] = 10;
						}
						else
						{
							SelectCharScr.gI().partbody[b3] = 1;
						}
					}
					if (SelectCharScr.gI().partleg[b3] == -1)
					{
						if (SelectCharScr.gI().gender[b3] == 0)
						{
							SelectCharScr.gI().partleg[b3] = 9;
						}
						else
						{
							SelectCharScr.gI().partleg[b3] = 0;
						}
					}
				}
				SelectCharScr.gI().switchToMe();
				GameCanvas.endDlg();
				break;
			}
			case -123:
				GameCanvas.debug("SA8", 2);
				GameScr.vsData = msg.reader().readByte();
				GameScr.vsMap = msg.reader().readByte();
				GameScr.vsSkill = msg.reader().readByte();
				GameScr.vsItem = msg.reader().readByte();
				if (GameScr.vsData != GameScr.vcData)
				{
					Service.gI().updateData();
				}
				else
				{
					try
					{
						DataInputStream dataInputStream = new DataInputStream(RMS.loadRMS("data"));
						createData(dataInputStream.r);
					}
					catch (Exception)
					{
						GameScr.vcData = -1;
						Service.gI().updateData();
					}
				}
				if (GameScr.vsMap != GameScr.vcMap)
				{
					Service.gI().updateMap();
				}
				else
				{
					try
					{
						DataInputStream dataInputStream2 = new DataInputStream(RMS.loadRMS("map"));
						createMap(dataInputStream2.r);
					}
					catch (Exception)
					{
						GameScr.vcMap = -1;
						Service.gI().updateMap();
					}
				}
				if (GameScr.vsSkill != GameScr.vcSkill)
				{
					Service.gI().updateSkill();
				}
				else
				{
					try
					{
						DataInputStream dataInputStream3 = new DataInputStream(RMS.loadRMS("skill"));
						createSkill(dataInputStream3.r);
					}
					catch (Exception)
					{
						GameScr.vcSkill = -1;
						Service.gI().updateSkill();
					}
				}
				if (GameScr.vsItem != GameScr.vcItem)
				{
					Service.gI().updateItem();
				}
				else
				{
					try
					{
						DataInputStream dataInputStream4 = new DataInputStream(RMS.loadRMS("item"));
						createItem(dataInputStream4.r);
					}
					catch (Exception)
					{
						GameScr.vcItem = -1;
						Service.gI().updateItem();
					}
				}
				if (GameScr.vsData == GameScr.vcData && GameScr.vsMap == GameScr.vcMap && GameScr.vsSkill == GameScr.vcSkill && GameScr.vsItem == GameScr.vcItem)
				{
					GameScr.gI().readEfect();
					GameScr.gI().readArrow();
					GameScr.gI().readSkill();
					Service.gI().clientOk();
				}
				break;
			case -122:
			{
				Out.println("GET UPDATE_DATA " + msg.reader().available() + " sbytes");
				msg.reader().mark(100000);
				createData(msg.reader());
				msg.reader().reset();
				sbyte[] data5 = new sbyte[msg.reader().available()];
				msg.reader().readFully(ref data5);
				RMS.saveRMS("data", data5);
				sbyte[] data6 = new sbyte[1]
				{
					GameScr.vcData
				};
				RMS.saveRMS("dataVersion", data6);
				if (GameScr.vsData == GameScr.vcData && GameScr.vsMap == GameScr.vcMap && GameScr.vsSkill == GameScr.vcSkill && GameScr.vsItem == GameScr.vcItem)
				{
					GameScr.gI().readEfect();
					GameScr.gI().readArrow();
					GameScr.gI().readSkill();
					Service.gI().clientOk();
				}
				break;
			}
			case -121:
			{
				Out.println("GET UPDATE_MAP " + msg.reader().available() + " sbytes");
				msg.reader().mark(100000);
				createMap(msg.reader());
				msg.reader().reset();
				sbyte[] data3 = new sbyte[msg.reader().available()];
				msg.reader().readFully(ref data3);
				RMS.saveRMS("map", data3);
				sbyte[] data4 = new sbyte[1]
				{
					GameScr.vcMap
				};
				RMS.saveRMS("mapVersion", data4);
				if (GameScr.vsData == GameScr.vcData && GameScr.vsMap == GameScr.vcMap && GameScr.vsSkill == GameScr.vcSkill && GameScr.vsItem == GameScr.vcItem)
				{
					GameScr.gI().readEfect();
					GameScr.gI().readArrow();
					GameScr.gI().readSkill();
					Service.gI().clientOk();
				}
				break;
			}
			case -120:
			{
				Out.println("GET UPDATE_SKILL " + msg.reader().available() + " sbytes");
				msg.reader().mark(100000);
				createSkill(msg.reader());
				msg.reader().reset();
				sbyte[] data = new sbyte[msg.reader().available()];
				msg.reader().readFully(ref data);
				if (Char.getMyChar().isHumanz())
				{
					RMS.saveRMS("skill", data);
				}
				else
				{
					RMS.saveRMS("skillnhanban", data);
				}
				sbyte[] data2 = new sbyte[1]
				{
					GameScr.vcSkill
				};
				RMS.saveRMS("skillVersion", data2);
				if (GameScr.vsData == GameScr.vcData && GameScr.vsMap == GameScr.vcMap && GameScr.vsSkill == GameScr.vcSkill && GameScr.vsItem == GameScr.vcItem)
				{
					GameScr.gI().readEfect();
					GameScr.gI().readArrow();
					GameScr.gI().readSkill();
					Service.gI().clientOk();
				}
				break;
			}
			case -119:
			{
				Out.println("GET UPDATE_ITEM " + msg.reader().available() + " sbytes");
				msg.reader().mark(100000);
				createItem(msg.reader());
				msg.reader().reset();
				sbyte[] data8 = new sbyte[msg.reader().available()];
				msg.reader().readFully(ref data8);
				RMS.saveRMS("item", data8);
				sbyte[] data9 = new sbyte[1]
				{
					GameScr.vcItem
				};
				RMS.saveRMS("itemVersion", data9);
				if (GameScr.vsData == GameScr.vcData && GameScr.vsMap == GameScr.vcMap && GameScr.vsSkill == GameScr.vcSkill && GameScr.vsItem == GameScr.vcItem)
				{
					GameScr.gI().readEfect();
					GameScr.gI().readArrow();
					GameScr.gI().readSkill();
					Service.gI().clientOk();
				}
				break;
			}
			case -108:
			{
				int num6 = msg.reader().readShort();
				try
				{
					sbyte typeFly = msg.reader().readByte();
					Mob.arrMobTemplate[num6].typeFly = typeFly;
				}
				catch (Exception)
				{
				}
				sbyte b4 = msg.reader().readByte();
				Mob.arrMobTemplate[num6].imgs = new Image[b4];
				if (num6 == 98 || num6 == 99)
				{
					Mob.arrMobTemplate[num6].imgs = new Image[3];
					Image image = createImage(NinjaUtil.readByteArray(msg));
					for (int num7 = 0; num7 < Mob.arrMobTemplate[num6].imgs.Length; num7++)
					{
						Mob.arrMobTemplate[num6].imgs[num7] = image;
					}
				}
				else
				{
					for (int num8 = 0; num8 < Mob.arrMobTemplate[num6].imgs.Length; num8++)
					{
						sbyte[] arr = NinjaUtil.readByteArray(msg);
						Mob.arrMobTemplate[num6].imgs[num8] = createImage(arr);
					}
				}
				if (msg.reader().readBoolean())
				{
					int num3 = msg.reader().readByte();
					Mob.arrMobTemplate[num6].frameBossMove = new sbyte[num3];
					for (int num9 = 0; num9 < num3; num9++)
					{
						Mob.arrMobTemplate[num6].frameBossMove[num9] = msg.reader().readByte();
					}
					num3 = msg.reader().readByte();
					Mob.arrMobTemplate[num6].frameBossAttack = new sbyte[num3][];
					for (int num10 = 0; num10 < num3; num10++)
					{
						Mob.arrMobTemplate[num6].frameBossAttack[num10] = new sbyte[msg.reader().readByte()];
						for (int num11 = 0; num11 < Mob.arrMobTemplate[num6].frameBossAttack[num10].Length; num11++)
						{
							Mob.arrMobTemplate[num6].frameBossAttack[num10][num11] = msg.reader().readByte();
						}
					}
				}
				int num12 = msg.reader().readInt();
				if (num12 > 0)
				{
					Mob.arrMobTemplate[num6].imginfo = new ImageInfo[msg.reader().readByte()];
					for (int num13 = 0; num13 < Mob.arrMobTemplate[num6].imginfo.Length; num13++)
					{
						Mob.arrMobTemplate[num6].imginfo[num13] = new ImageInfo();
						Mob.arrMobTemplate[num6].imginfo[num13].ID = msg.reader().readByte();
						Mob.arrMobTemplate[num6].imginfo[num13].x0 = msg.reader().readUnsignedByte();
						Mob.arrMobTemplate[num6].imginfo[num13].y0 = msg.reader().readUnsignedByte();
						Mob.arrMobTemplate[num6].imginfo[num13].w = msg.reader().readUnsignedByte();
						Mob.arrMobTemplate[num6].imginfo[num13].h = msg.reader().readUnsignedByte();
					}
					Mob.arrMobTemplate[num6].frameBoss = new Frame[msg.reader().readShort()];
					for (int num14 = 0; num14 < Mob.arrMobTemplate[num6].frameBoss.Length; num14++)
					{
						Mob.arrMobTemplate[num6].frameBoss[num14] = new Frame();
						sbyte b5 = msg.reader().readByte();
						Mob.arrMobTemplate[num6].frameBoss[num14].dx = new short[b5];
						Mob.arrMobTemplate[num6].frameBoss[num14].dy = new short[b5];
						Mob.arrMobTemplate[num6].frameBoss[num14].idImg = new sbyte[b5];
						for (int num15 = 0; num15 < b5; num15++)
						{
							Mob.arrMobTemplate[num6].frameBoss[num14].dx[num15] = msg.reader().readShort();
							Mob.arrMobTemplate[num6].frameBoss[num14].dy[num15] = msg.reader().readShort();
							Mob.arrMobTemplate[num6].frameBoss[num14].idImg[num15] = msg.reader().readByte();
						}
					}
					short num16 = msg.reader().readShort();
					for (int num17 = 0; num17 < num16; num17++)
					{
						msg.reader().readShort();
					}
				}
				break;
			}
			case -109:
				try
				{
					GameCanvas.isLoading = true;
					TileMap.maps = null;
					TileMap.types = null;
					GameCanvas.debug("SA99", 2);
					TileMap.tmw = msg.reader().readByte();
					TileMap.tmh = msg.reader().readByte();
					TileMap.maps = new char[TileMap.tmw * TileMap.tmh];
					for (int n = 0; n < TileMap.maps.Length; n++)
					{
						int num5 = msg.reader().readByte();
						if (num5 < 0)
						{
							num5 += 256;
						}
						TileMap.maps[n] = (char)num5;
					}
					TileMap.types = new int[TileMap.maps.Length];
					msg = messWait;
					loadInfoMap(msg);
				}
				catch (Exception)
				{
					Out.println(" loi tai cmd  " + msg.command);
				}
				msg.cleanup();
				messWait.cleanup();
				msg = (messWait = null);
				break;
			case -107:
				GameCanvas.debug("SA10", 2);
				break;
			case -110:
				GameCanvas.debug("SA11", 2);
				break;
			case -67:
			{
				Mob mob = null;
				try
				{
					int iD = msg.reader().readUnsignedByte();
					mob = Mob.get_Mob(iD);
				}
				catch (Exception)
				{
				}
				if (mob != null)
				{
					int num = msg.reader().readInt();
					if (num == Char.getMyChar().charID)
					{
						GameScr.vMobSoul.addElement(new MobSoul(mob.x, mob.y, Char.getMyChar()));
					}
					else
					{
						Char char2 = GameScr.findCharInMap(num);
						if (char2 != null)
						{
							GameScr.vMobSoul.addElement(new MobSoul(mob.x, mob.y, char2));
						}
					}
				}
				break;
			}
			case -66:
			{
				int num = msg.reader().readInt();
				if (Char.getMyChar().charID == num)
				{
					GameScr.vMobSoul.addElement(new MobSoul(Char.getMyChar().cx, Char.getMyChar().cy));
				}
				else
				{
					Char @char = GameScr.findCharInMap(num);
					if (@char != null)
					{
						GameScr.vMobSoul.addElement(new MobSoul(@char.cx, @char.cy));
					}
				}
				break;
			}
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			msg?.cleanup();
		}
	}

	public void messageNotLogin(Message msg)
	{
		try
		{
			switch (msg.reader().readByte())
			{
			case -124:
			{
				string str = msg.reader().readUTF();
				string data = msg.reader().readUTF();
				GameMidlet.sendSMSRe(data, "sms://" + str, new Command(string.Empty, GameCanvas.gI(), 88825, null), new Command(string.Empty, GameCanvas.gI(), 88826, null));
				break;
			}
			case 2:
				RMS.clearRMS();
				break;
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			msg?.cleanup();
		}
	}

	public void messageSubCommand(Message msg)
	{
		try
		{
			GameCanvas.debug("SA12", 2);
			sbyte b = msg.reader().readByte();
			Skill skill = null;
			Effect effect = null;
			sbyte b2 = 0;
			Out.println("sub: " + b);
			switch (b)
			{
			case -126:
				Char.getMyChar().readParam(msg, "Cmd.ME_LOAD_SKILL");
				Char.getMyChar().potential[0] = msg.reader().readShort();
				Char.getMyChar().potential[1] = msg.reader().readShort();
				Char.getMyChar().potential[2] = msg.reader().readInt();
				Char.getMyChar().potential[3] = msg.reader().readInt();
				Char.getMyChar().callEffTask(61);
				Char.getMyChar().nClass = GameScr.nClasss[msg.reader().readByte()];
				Char.getMyChar().sPoint = msg.reader().readShort();
				Char.getMyChar().pPoint = msg.reader().readShort();
				Char.getMyChar().vSkill.removeAllElements();
				Char.getMyChar().vSkillFight.removeAllElements();
				Char.getMyChar().myskill = null;
				break;
			case -125:
				Char.getMyChar().readParam(msg, "Cmd.ME_LOAD_SKILL");
				if (Char.getMyChar().statusMe != 14 && Char.getMyChar().statusMe != 5)
				{
					Char.getMyChar().cHP = Char.getMyChar().cMaxHP;
					Char.getMyChar().cMP = Char.getMyChar().cMaxMP;
				}
				Char.getMyChar().sPoint = msg.reader().readShort();
				Char.getMyChar().vSkill.removeAllElements();
				Char.getMyChar().vSkillFight.removeAllElements();
				b2 = msg.reader().readByte();
				for (sbyte b7 = 0; b7 < b2; b7 = (sbyte)(b7 + 1))
				{
					skill = Skills.get(msg.reader().readShort());
					if (Char.getMyChar().myskill == null)
					{
						Char.getMyChar().myskill = skill;
					}
					else if (skill.template.Equals(Char.getMyChar().myskill.template))
					{
						Char.getMyChar().myskill = skill;
					}
					Char.getMyChar().vSkill.addElement(skill);
					if ((skill.template.type == 1 || skill.template.type == 4 || skill.template.type == 2 || skill.template.type == 3) && (skill.template.maxPoint == 0 || (skill.template.maxPoint > 0 && skill.point > 0)))
					{
						if (skill.template.id == Char.getMyChar().skillTemplateId)
						{
							Service.gI().selectSkill(Char.getMyChar().skillTemplateId);
						}
						Char.getMyChar().vSkillFight.addElement(skill);
					}
				}
				GameScr.gI().sortSkill();
				if (GameScr.isPaintInfoMe)
				{
					GameScr.indexRow = -1;
					GameScr.gI().setLCR();
				}
				break;
			case -109:
				Char.getMyChar().readParam(msg, "Cmd.ME_LOAD_SKILL");
				if (Char.getMyChar().statusMe != 14 && Char.getMyChar().statusMe != 5)
				{
					Char.getMyChar().cHP = Char.getMyChar().cMaxHP;
					Char.getMyChar().cMP = Char.getMyChar().cMaxMP;
				}
				Char.getMyChar().pPoint = msg.reader().readShort();
				Char.getMyChar().potential[0] = msg.reader().readShort();
				Char.getMyChar().potential[1] = msg.reader().readShort();
				Char.getMyChar().potential[2] = msg.reader().readInt();
				Char.getMyChar().potential[3] = msg.reader().readInt();
				break;
			case -107:
				GameCanvas.debug("SA16", 2);
				Char.getMyChar().bagSort();
				break;
			case -106:
				GameCanvas.debug("SA17", 2);
				Char.getMyChar().boxSort();
				break;
			case -105:
			{
				GameCanvas.debug("SA18", 2);
				int num = msg.reader().readInt();
				Char.getMyChar().xu -= num;
				Char.getMyChar().xuInBox += num;
				break;
			}
			case -104:
			{
				GameCanvas.debug("SA19", 2);
				int num15 = msg.reader().readInt();
				Char.getMyChar().xuInBox -= num15;
				Char.getMyChar().xu += num15;
				break;
			}
			case -102:
				GameCanvas.debug("SA20", 2);
				Char.getMyChar().arrItemBag[msg.reader().readByte()] = null;
				skill = Skills.get(msg.reader().readShort());
				Char.getMyChar().vSkill.addElement(skill);
				if ((skill.template.type == 1 || skill.template.type == 4 || skill.template.type == 2 || skill.template.type == 3) && (skill.template.maxPoint == 0 || (skill.template.maxPoint > 0 && skill.point > 0)))
				{
					if (skill.template.id == Char.getMyChar().skillTemplateId)
					{
						Service.gI().selectSkill(Char.getMyChar().skillTemplateId);
					}
					Char.getMyChar().vSkillFight.addElement(skill);
				}
				GameScr.gI().sortSkill();
				GameScr.gI().addSkillShortcut(skill);
				GameScr.gI().setLCR();
				InfoMe.addInfo(mResources.LEARN_SKILL + " " + skill.template.name);
				break;
			case 115:
			{
				GameScr.currentCharViewInfo = Char.getMyChar();
				Char.getMyChar().charID = msg.reader().readInt();
				Char.getMyChar().cClanName = msg.reader().readUTF();
				if (!Char.getMyChar().cClanName.Equals(string.Empty))
				{
					Char.getMyChar().ctypeClan = msg.reader().readByte();
				}
				Char.getMyChar().ctaskId = msg.reader().readByte();
				Char.getMyChar().cgender = msg.reader().readByte();
				Char.getMyChar().head = msg.reader().readShort();
				Char.getMyChar().cspeed = msg.reader().readByte();
				Char.getMyChar().cName = msg.reader().readUTF();
				Char.getMyChar().cPk = msg.reader().readByte();
				Char.getMyChar().cTypePk = msg.reader().readByte();
				Char.getMyChar().cMaxHP = msg.reader().readInt();
				Char.getMyChar().cHP = msg.reader().readInt();
				Char.getMyChar().cMaxMP = msg.reader().readInt();
				Char.getMyChar().cMP = msg.reader().readInt();
				Char.getMyChar().cEXP = msg.reader().readLong();
				Char.getMyChar().cExpDown = msg.reader().readLong();
				GameScr.setLevel_Exp(Char.getMyChar().cEXP, value: true);
				Char.getMyChar().eff5BuffHp = msg.reader().readShort();
				Char.getMyChar().eff5BuffMp = msg.reader().readShort();
				Char.getMyChar().nClass = GameScr.nClasss[msg.reader().readByte()];
				Char.getMyChar().pPoint = msg.reader().readShort();
				Char.getMyChar().potential[0] = msg.reader().readShort();
				Char.getMyChar().potential[1] = msg.reader().readShort();
				Char.getMyChar().potential[2] = msg.reader().readInt();
				Char.getMyChar().potential[3] = msg.reader().readInt();
				Char.getMyChar().sPoint = msg.reader().readShort();
				Char.getMyChar().vSkill.removeAllElements();
				Char.getMyChar().vSkillFight.removeAllElements();
				b2 = msg.reader().readByte();
				for (byte b5 = 0; b5 < b2; b5 = (byte)(b5 + 1))
				{
					skill = Skills.get(msg.reader().readShort());
					if (Char.getMyChar().myskill == null)
					{
						Char.getMyChar().myskill = skill;
					}
					Char.getMyChar().vSkill.addElement(skill);
					if ((skill.template.type == 1 || skill.template.type == 4 || skill.template.type == 2 || skill.template.type == 3) && (skill.template.maxPoint == 0 || (skill.template.maxPoint > 0 && skill.point > 0)))
					{
						if (skill.template.id == Char.getMyChar().skillTemplateId)
						{
							Service.gI().selectSkill(Char.getMyChar().skillTemplateId);
						}
						Char.getMyChar().vSkillFight.addElement(skill);
					}
				}
				GameScr.gI().sortSkill();
				Char.getMyChar().xu = msg.reader().readInt();
				Char.getMyChar().yen = msg.reader().readInt();
				Char.getMyChar().luong = msg.reader().readInt();
				Char.getMyChar().arrItemBag = new Item[msg.reader().readUnsignedByte()];
				GameScr.hpPotion = (GameScr.mpPotion = 0);
				for (int num6 = 0; num6 < Char.getMyChar().arrItemBag.Length; num6++)
				{
					short num7 = msg.reader().readShort();
					if (num7 != -1)
					{
						Char.getMyChar().arrItemBag[num6] = new Item();
						Char.getMyChar().arrItemBag[num6].typeUI = 3;
						Char.getMyChar().arrItemBag[num6].indexUI = num6;
						Char.getMyChar().arrItemBag[num6].template = ItemTemplates.get(num7);
						Char.getMyChar().arrItemBag[num6].isLock = msg.reader().readBoolean();
						if (Char.getMyChar().arrItemBag[num6].isTypeBody() || Char.getMyChar().arrItemBag[num6].isTypeMounts() || Char.getMyChar().arrItemBag[num6].isTypeNgocKham())
						{
							Char.getMyChar().arrItemBag[num6].upgrade = msg.reader().readByte();
						}
						Char.getMyChar().arrItemBag[num6].isExpires = msg.reader().readBoolean();
						Char.getMyChar().arrItemBag[num6].quantity = msg.reader().readUnsignedShort();
						if (Char.getMyChar().arrItemBag[num6].template.type == 16)
						{
							GameScr.hpPotion += Char.getMyChar().arrItemBag[num6].quantity;
						}
						if (Char.getMyChar().arrItemBag[num6].template.type == 17)
						{
							GameScr.mpPotion += Char.getMyChar().arrItemBag[num6].quantity;
						}
						if (Char.getMyChar().arrItemBag[num6].template.id == 340)
						{
							GameScr.gI().numSprinLeft += Char.getMyChar().arrItemBag[num6].quantity;
						}
					}
				}
				Char.getMyChar().arrItemBody = new Item[16];
				try
				{
					Char.getMyChar().setDefaultPart();
					for (int num8 = 0; num8 < Char.getMyChar().arrItemBody.Length; num8++)
					{
						short num9 = msg.reader().readShort();
						if (num9 != -1)
						{
							ItemTemplate itemTemplate = ItemTemplates.get(num9);
							int num10 = itemTemplate.type;
							Char.getMyChar().arrItemBody[num10] = new Item();
							Char.getMyChar().arrItemBody[num10].indexUI = num10;
							Char.getMyChar().arrItemBody[num10].typeUI = 5;
							Char.getMyChar().arrItemBody[num10].template = itemTemplate;
							Char.getMyChar().arrItemBody[num10].isLock = true;
							Char.getMyChar().arrItemBody[num10].upgrade = msg.reader().readByte();
							Char.getMyChar().arrItemBody[num10].sys = msg.reader().readByte();
							switch (num10)
							{
							case 1:
								Char.getMyChar().wp = Char.getMyChar().arrItemBody[num10].template.part;
								break;
							case 2:
								Char.getMyChar().body = Char.getMyChar().arrItemBody[num10].template.part;
								break;
							case 6:
								Char.getMyChar().leg = Char.getMyChar().arrItemBody[num10].template.part;
								break;
							}
						}
					}
				}
				catch (Exception)
				{
				}
				Char.getMyChar().isHuman = msg.reader().readBoolean();
				Char.getMyChar().isNhanban = msg.reader().readBoolean();
				short[] array2 = new short[4]
				{
					msg.reader().readShort(),
					msg.reader().readShort(),
					msg.reader().readShort(),
					msg.reader().readShort()
				};
				if (array2[0] > -1)
				{
					Char.getMyChar().head = array2[0];
				}
				if (array2[1] > -1)
				{
					Char.getMyChar().wp = array2[1];
				}
				if (array2[2] > -1)
				{
					Char.getMyChar().body = array2[2];
				}
				if (array2[3] > -1)
				{
					Char.getMyChar().leg = array2[3];
				}
				GameScr.gI().sortSkill();
				if (Char.getMyChar().isHuman)
				{
					GameScr.gI().loadSkillShortcut();
				}
				else if (Char.getMyChar().isNhanban)
				{
					GameScr.gI().loadSkillShortcutNhanban();
				}
				Char.getMyChar().statusMe = 4;
				GameScr.isViewClanInvite = ((RMS.loadRMSInt(Char.getMyChar().cName + "vci") >= 1) ? true : false);
				Service.gI().loadRMS("KSkill");
				Service.gI().loadRMS("OSkill");
				Service.gI().loadRMS("CSkill");
				break;
			}
			case -127:
			{
				GameScr.vCharInMap.removeAllElements();
				GameScr.vItemMap.removeAllElements();
				GameScr.loadImg();
				GameScr.currentCharViewInfo = Char.getMyChar();
				Char.getMyChar().charID = msg.reader().readInt();
				Char.getMyChar().cClanName = msg.reader().readUTF();
				if (!Char.getMyChar().cClanName.Equals(string.Empty))
				{
					Char.getMyChar().ctypeClan = msg.reader().readByte();
				}
				Char.getMyChar().ctaskId = msg.reader().readByte();
				Char.getMyChar().cgender = msg.reader().readByte();
				Char.getMyChar().head = msg.reader().readShort();
				Char.getMyChar().cspeed = msg.reader().readByte();
				Char.getMyChar().cName = msg.reader().readUTF();
				Char.getMyChar().cPk = msg.reader().readByte();
				Char.getMyChar().cTypePk = msg.reader().readByte();
				Char.getMyChar().cMaxHP = msg.reader().readInt();
				Char.getMyChar().cHP = msg.reader().readInt();
				Char.getMyChar().cMaxMP = msg.reader().readInt();
				Char.getMyChar().cMP = msg.reader().readInt();
				Char.getMyChar().cEXP = msg.reader().readLong();
				Char.getMyChar().cExpDown = msg.reader().readLong();
				GameScr.setLevel_Exp(Char.getMyChar().cEXP, value: true);
				Char.getMyChar().eff5BuffHp = msg.reader().readShort();
				Char.getMyChar().eff5BuffMp = msg.reader().readShort();
				Char.getMyChar().nClass = GameScr.nClasss[msg.reader().readByte()];
				Char.getMyChar().pPoint = msg.reader().readShort();
				Char.getMyChar().potential[0] = msg.reader().readShort();
				Char.getMyChar().potential[1] = msg.reader().readShort();
				Char.getMyChar().potential[2] = msg.reader().readInt();
				Char.getMyChar().potential[3] = msg.reader().readInt();
				Char.getMyChar().sPoint = msg.reader().readShort();
				Char.getMyChar().vSkill.removeAllElements();
				Char.getMyChar().vSkillFight.removeAllElements();
				b2 = msg.reader().readByte();
				for (byte b8 = 0; b8 < b2; b8 = (byte)(b8 + 1))
				{
					skill = Skills.get(msg.reader().readShort());
					if (Char.getMyChar().myskill == null)
					{
						Char.getMyChar().myskill = skill;
					}
					Char.getMyChar().vSkill.addElement(skill);
					if ((skill.template.type == 1 || skill.template.type == 4 || skill.template.type == 2 || skill.template.type == 3) && (skill.template.maxPoint == 0 || (skill.template.maxPoint > 0 && skill.point > 0)))
					{
						if (skill.template.id == Char.getMyChar().skillTemplateId)
						{
							Service.gI().selectSkill(Char.getMyChar().skillTemplateId);
						}
						Char.getMyChar().vSkillFight.addElement(skill);
					}
				}
				GameScr.gI().sortSkill();
				Char.getMyChar().xu = msg.reader().readInt();
				Char.getMyChar().yen = msg.reader().readInt();
				Char.getMyChar().luong = msg.reader().readInt();
				Char.getMyChar().arrItemBag = new Item[msg.reader().readUnsignedByte()];
				GameScr.hpPotion = (GameScr.mpPotion = 0);
				for (int num22 = 0; num22 < Char.getMyChar().arrItemBag.Length; num22++)
				{
					short num23 = msg.reader().readShort();
					if (num23 != -1)
					{
						Char.getMyChar().arrItemBag[num22] = new Item();
						Char.getMyChar().arrItemBag[num22].typeUI = 3;
						Char.getMyChar().arrItemBag[num22].indexUI = num22;
						Char.getMyChar().arrItemBag[num22].template = ItemTemplates.get(num23);
						Char.getMyChar().arrItemBag[num22].isLock = msg.reader().readBoolean();
						if (Char.getMyChar().arrItemBag[num22].isTypeBody() || Char.getMyChar().arrItemBag[num22].isTypeMounts() || Char.getMyChar().arrItemBag[num22].isTypeNgocKham())
						{
							Char.getMyChar().arrItemBag[num22].upgrade = msg.reader().readByte();
						}
						Char.getMyChar().arrItemBag[num22].isExpires = msg.reader().readBoolean();
						Char.getMyChar().arrItemBag[num22].quantity = msg.reader().readUnsignedShort();
						if (Char.getMyChar().arrItemBag[num22].template.type == 16)
						{
							GameScr.hpPotion += Char.getMyChar().arrItemBag[num22].quantity;
						}
						if (Char.getMyChar().arrItemBag[num22].template.type == 17)
						{
							GameScr.mpPotion += Char.getMyChar().arrItemBag[num22].quantity;
						}
						if (Char.getMyChar().arrItemBag[num22].template.id == 340)
						{
							GameScr.gI().numSprinLeft += Char.getMyChar().arrItemBag[num22].quantity;
						}
					}
				}
				Char.getMyChar().arrItemBody = new Item[16];
				try
				{
					Char.getMyChar().setDefaultPart();
					for (int num24 = 0; num24 < Char.getMyChar().arrItemBody.Length; num24++)
					{
						short num25 = msg.reader().readShort();
						if (num25 != -1)
						{
							ItemTemplate itemTemplate2 = ItemTemplates.get(num25);
							int num26 = itemTemplate2.type;
							Char.getMyChar().arrItemBody[num26] = new Item();
							Char.getMyChar().arrItemBody[num26].indexUI = num26;
							Char.getMyChar().arrItemBody[num26].typeUI = 5;
							Char.getMyChar().arrItemBody[num26].template = itemTemplate2;
							Char.getMyChar().arrItemBody[num26].isLock = true;
							Char.getMyChar().arrItemBody[num26].upgrade = msg.reader().readByte();
							Char.getMyChar().arrItemBody[num26].sys = msg.reader().readByte();
							switch (num26)
							{
							case 1:
								Char.getMyChar().wp = Char.getMyChar().arrItemBody[num26].template.part;
								break;
							case 2:
								Char.getMyChar().body = Char.getMyChar().arrItemBody[num26].template.part;
								break;
							case 6:
								Char.getMyChar().leg = Char.getMyChar().arrItemBody[num26].template.part;
								break;
							}
						}
					}
				}
				catch (Exception)
				{
				}
				Char.getMyChar().isHuman = msg.reader().readBoolean();
				Char.getMyChar().isNhanban = msg.reader().readBoolean();
				short[] array3 = new short[4]
				{
					msg.reader().readShort(),
					msg.reader().readShort(),
					msg.reader().readShort(),
					msg.reader().readShort()
				};
				if (array3[0] > -1)
				{
					Char.getMyChar().head = array3[0];
				}
				if (array3[1] > -1)
				{
					Char.getMyChar().wp = array3[1];
				}
				if (array3[2] > -1)
				{
					Char.getMyChar().body = array3[2];
				}
				if (array3[3] > -1)
				{
					Char.getMyChar().leg = array3[3];
				}
				if (Char.getMyChar().isHuman)
				{
					GameScr.gI().loadSkillShortcut();
				}
				else if (Char.getMyChar().isNhanban)
				{
					GameScr.gI().loadSkillShortcutNhanban();
				}
				Char.getMyChar().statusMe = 4;
				GameScr.isViewClanInvite = ((RMS.loadRMSInt(Char.getMyChar().cName + "vci") >= 1) ? true : false);
				if (Char.getMyChar().isHumanz())
				{
					DataInputStream dataInputStream = new DataInputStream(RMS.loadRMS("skill"));
					createSkill(dataInputStream.r);
				}
				else
				{
					DataInputStream dataInputStream2 = new DataInputStream(RMS.loadRMS("skill"));
					createSkill(dataInputStream2.r);
				}
				Service.gI().loadRMS("KSkill");
				Service.gI().loadRMS("OSkill");
				Service.gI().loadRMS("CSkill");
				break;
			}
			case -124:
				Char.getMyChar().readParam(msg, "Cmd.ME_LOAD_SKILL");
				Char.getMyChar().cEXP = msg.reader().readLong();
				GameScr.setLevel_Exp(Char.getMyChar().cEXP, value: true);
				Char.getMyChar().sPoint = msg.reader().readShort();
				Char.getMyChar().pPoint = msg.reader().readShort();
				Char.getMyChar().potential[0] = msg.reader().readShort();
				Char.getMyChar().potential[1] = msg.reader().readShort();
				Char.getMyChar().potential[2] = msg.reader().readInt();
				Char.getMyChar().potential[3] = msg.reader().readInt();
				break;
			case -123:
			{
				Char.getMyChar().xu = msg.reader().readInt();
				Char.getMyChar().yen = msg.reader().readInt();
				Char.getMyChar().luong = msg.reader().readInt();
				Char.getMyChar().cHP = msg.reader().readInt();
				Char.getMyChar().cMP = msg.reader().readInt();
				sbyte b6 = msg.reader().readByte();
				if (b6 == 1)
				{
					GameScr.gI().resetCaptcha();
					Char.getMyChar().isCaptcha = true;
				}
				else
				{
					Char.getMyChar().isCaptcha = false;
				}
				break;
			}
			case -122:
				GameCanvas.debug("SA24", 2);
				Char.getMyChar().cHP = msg.reader().readInt();
				break;
			case -121:
				GameCanvas.debug("SA25", 2);
				Char.getMyChar().cMP = msg.reader().readInt();
				break;
			case -120:
			{
				Char @char = GameScr.findCharInMap(msg.reader().readInt());
				if (@char != null)
				{
					readCharInfo(@char, msg);
				}
				break;
			}
			case -119:
			{
				GameCanvas.debug("SA26", 2);
				Char @char = GameScr.findCharInMap(msg.reader().readInt());
				if (@char != null)
				{
					@char.cHP = msg.reader().readInt();
					@char.cMaxHP = msg.reader().readInt();
				}
				break;
			}
			case sbyte.MinValue:
			{
				GameCanvas.debug("SA27", 2);
				Char @char = GameScr.findCharInMap(msg.reader().readInt());
				if (@char != null)
				{
					@char.cHP = msg.reader().readInt();
					@char.cMaxHP = msg.reader().readInt();
					@char.clevel = msg.reader().readUnsignedByte();
				}
				break;
			}
			case -117:
			{
				GameCanvas.debug("SA28", 2);
				Char @char = GameScr.findCharInMap(msg.reader().readInt());
				if (@char != null)
				{
					@char.cHP = msg.reader().readInt();
					@char.cMaxHP = msg.reader().readInt();
					@char.eff5BuffHp = msg.reader().readShort();
					@char.eff5BuffMp = msg.reader().readShort();
					@char.wp = msg.reader().readShort();
					if (@char.wp == -1)
					{
						@char.setDefaultWeapon();
					}
				}
				break;
			}
			case -116:
			{
				GameCanvas.debug("SA29", 2);
				Char @char = GameScr.findCharInMap(msg.reader().readInt());
				if (@char != null)
				{
					@char.cHP = msg.reader().readInt();
					@char.cMaxHP = msg.reader().readInt();
					@char.eff5BuffHp = msg.reader().readShort();
					@char.eff5BuffMp = msg.reader().readShort();
					@char.body = msg.reader().readShort();
					if (@char.body == -1)
					{
						@char.setDefaultBody();
					}
				}
				break;
			}
			case -113:
			{
				GameCanvas.debug("SA30", 2);
				Char @char = GameScr.findCharInMap(msg.reader().readInt());
				if (@char != null)
				{
					@char.cHP = msg.reader().readInt();
					@char.cMaxHP = msg.reader().readInt();
					@char.eff5BuffHp = msg.reader().readShort();
					@char.eff5BuffMp = msg.reader().readShort();
					@char.leg = msg.reader().readShort();
					if (@char.leg == -1)
					{
						@char.setDefaultLeg();
					}
				}
				break;
			}
			case -64:
			{
				GameCanvas.debug("SA30", 2);
				Char @char = GameScr.findCharInMap(msg.reader().readInt());
				if (@char != null)
				{
					@char.cHP = msg.reader().readInt();
					@char.cMaxHP = msg.reader().readInt();
					@char.eff5BuffHp = msg.reader().readShort();
					@char.eff5BuffMp = msg.reader().readShort();
					@char.head = msg.reader().readShort();
				}
				break;
			}
			case -63:
			{
				GameCanvas.debug("SA3001", 2);
				int num12 = msg.reader().readInt();
				Char char2 = GameScr.findCharInMap(num12);
				if (char2 != null)
				{
					GameCanvas.startYesNoDlg(char2.cName + " " + mResources.replace(mResources.INVITECLAN, msg.reader().readUTF()), 88830, num12, 88811, null);
				}
				break;
			}
			case -61:
			{
				GameCanvas.debug("SA30021", 2);
				int num11 = msg.reader().readInt();
				if (GameScr.isViewClanInvite)
				{
					int num12 = num11;
					Char char2 = GameScr.findCharInMap(num12);
					if (char2 != null)
					{
						GameCanvas.startYesNoDlg(char2.cName + " " + mResources.PLEASECLAN, 88831, num12, 88811, null);
					}
				}
				break;
			}
			case -62:
			{
				GameCanvas.debug("SA3001", 2);
				int num4 = msg.reader().readInt();
				string cClanName = msg.reader().readUTF();
				sbyte ctypeClan = msg.reader().readByte();
				if (Char.getMyChar().charID == num4)
				{
					Char.getMyChar().cClanName = cClanName;
					Char.getMyChar().ctypeClan = ctypeClan;
					Char.getMyChar().callEffTask(21);
				}
				else
				{
					Char @char = GameScr.findCharInMap(num4);
					if (@char != null)
					{
						@char.cClanName = cClanName;
						@char.ctypeClan = ctypeClan;
					}
				}
				break;
			}
			case -112:
			{
				GameCanvas.debug("SA31", 2);
				Char @char = GameScr.findCharInMap(msg.reader().readInt());
				if (@char != null)
				{
					@char.cHP = msg.reader().readInt();
					@char.cMaxHP = msg.reader().readInt();
					@char.eff5BuffHp = msg.reader().readShort();
					@char.eff5BuffMp = msg.reader().readShort();
				}
				break;
			}
			case -111:
			{
				GameCanvas.debug("SA32", 2);
				Char @char = GameScr.findCharInMap(msg.reader().readInt());
				if (@char != null)
				{
					@char.cHP = msg.reader().readInt();
				}
				break;
			}
			case -110:
			{
				GameCanvas.debug("SA33", 2);
				Char @char = GameScr.findCharInMap(msg.reader().readInt());
				if (@char != null)
				{
					@char.cHP = msg.reader().readInt();
					@char.cMaxHP = msg.reader().readInt();
					@char.cx = msg.reader().readShort();
					@char.cy = msg.reader().readShort();
					@char.statusMe = 1;
					ServerEffect.addServerEffect(20, @char, 2);
				}
				break;
			}
			case -101:
			{
				GameCanvas.debug("SA34", 2);
				Effect effect3 = new Effect(msg.reader().readByte(), (int)(mSystem.getCurrentTimeMillis() / 1000) - msg.reader().readInt(), msg.reader().readInt(), msg.reader().readShort());
				Char.getMyChar().vEff.addElement(effect3);
				if (effect3.template.type == 7)
				{
					Char.getMyChar().cMiss += effect3.param;
				}
				else if (effect3.template.type == 12 || effect3.template.type == 11)
				{
					Char.getMyChar().isInvisible = true;
					ServerEffect.addServerEffect(60, Char.getMyChar().cx, Char.getMyChar().cy, 1);
				}
				else if (effect3.template.type == 14)
				{
					GameCanvas.clearKeyPressed();
					GameCanvas.clearKeyHold();
					Char.getMyChar().cx = msg.reader().readShort();
					Char.getMyChar().cy = msg.reader().readShort();
					Char.getMyChar().statusMe = 1;
					Char.getMyChar().isLockMove = true;
					ServerEffect.addServerEffectWithTime(76, Char.getMyChar(), effect3.timeLenght);
				}
				else if (effect3.template.type == 1)
				{
					ServerEffect.addServerEffectWithTime(48, Char.getMyChar(), effect3.timeLenght);
				}
				else if (effect3.template.type == 2)
				{
					GameCanvas.clearKeyPressed();
					GameCanvas.clearKeyHold();
					Char.getMyChar().cx = msg.reader().readShort();
					Char.getMyChar().cy = msg.reader().readShort();
					Char.getMyChar().statusMe = 1;
					Char.getMyChar().isLockMove = true;
					Char.getMyChar().isLockAttack = true;
				}
				else if (effect3.template.type == 3)
				{
					GameCanvas.clearKeyPressed();
					GameCanvas.clearKeyHold();
					Char.getMyChar().cx = msg.reader().readShort();
					Char.getMyChar().cy = msg.reader().readShort();
					Char.getMyChar().statusMe = 1;
					Char.isLockKey = true;
					ServerEffect.addServerEffectWithTime(43, Char.getMyChar(), effect3.timeLenght);
				}
				break;
			}
			case -98:
				GameCanvas.debug("SA344", 2);
				try
				{
					Char @char = GameScr.findCharInMap(msg.reader().readInt());
					if (@char != null)
					{
						Effect effect3 = new Effect(msg.reader().readByte(), (int)(mSystem.getCurrentTimeMillis() / 1000) - msg.reader().readInt(), msg.reader().readInt(), msg.reader().readShort());
						@char.vEff.addElement(effect3);
						if (effect3.template.type == 12 || effect3.template.type == 11)
						{
							@char.isInvisible = true;
							ServerEffect.addServerEffect(60, @char.cx, @char.cy, 1);
						}
						else if (effect3.template.type == 14)
						{
							@char.cx = (@char.cxMoveLast = msg.reader().readShort());
							@char.cy = (@char.cyMoveLast = msg.reader().readShort());
							@char.statusMe = 1;
							ServerEffect.addServerEffectWithTime(76, @char, effect3.timeLenght);
						}
						else if (effect3.template.type == 1)
						{
							ServerEffect.addServerEffectWithTime(48, @char, effect3.timeLenght);
						}
						else if (effect3.template.type == 2)
						{
							@char.cx = (@char.cxMoveLast = msg.reader().readShort());
							@char.cy = (@char.cyMoveLast = msg.reader().readShort());
							@char.statusMe = 1;
							@char.isLockAttack = true;
						}
						else if (effect3.template.type == 3)
						{
							@char.cx = (@char.cxMoveLast = msg.reader().readShort());
							@char.cy = (@char.cyMoveLast = msg.reader().readShort());
							@char.statusMe = 1;
							ServerEffect.addServerEffectWithTime(43, @char, effect3.timeLenght);
						}
					}
				}
				catch (Exception)
				{
				}
				break;
			case -100:
			{
				GameCanvas.debug("SA35", 2);
				EffectTemplate effectTemplate = Effect.effTemplates[msg.reader().readByte()];
				for (int num14 = 0; num14 < Char.getMyChar().vEff.size(); num14++)
				{
					effect = (Effect)Char.getMyChar().vEff.elementAt(num14);
					if (effect != null && effect.template.type == effectTemplate.type)
					{
						if (effect.template.type == 7)
						{
							Char.getMyChar().cMiss -= effect.param;
						}
						effect.template = effectTemplate;
						effect.timeStart = (int)(mSystem.getCurrentTimeMillis() / 1000) - msg.reader().readInt();
						effect.timeLenght = msg.reader().readInt() / 1000;
						effect.param = msg.reader().readShort();
						if (effect.template.type == 7)
						{
							Char.getMyChar().cMiss += effect.param;
						}
						break;
					}
				}
				if (!GameScr.isPaintInfoMe)
				{
					GameScr.gI().resetButton();
				}
				break;
			}
			case -97:
				GameCanvas.debug("SA355", 2);
				try
				{
					Char @char = GameScr.findCharInMap(msg.reader().readInt());
					if (@char != null)
					{
						EffectTemplate effectTemplate = Effect.effTemplates[msg.reader().readByte()];
						int num13 = 0;
						while (true)
						{
							if (num13 >= @char.vEff.size())
							{
								return;
							}
							effect = (Effect)@char.vEff.elementAt(num13);
							if (effect != null && effectTemplate.type == effectTemplate.type)
							{
								break;
							}
							num13++;
						}
						effect.template = effectTemplate;
						effect.timeStart = (int)(mSystem.getCurrentTimeMillis() / 1000) - msg.reader().readInt();
						effect.timeLenght = msg.reader().readInt() / 1000;
						effect.param = msg.reader().readShort();
					}
				}
				catch (Exception)
				{
				}
				break;
			case -99:
			{
				GameCanvas.debug("SA36", 2);
				int num5 = msg.reader().readByte();
				effect = null;
				for (int num21 = 0; num21 < Char.getMyChar().vEff.size(); num21++)
				{
					effect = (Effect)Char.getMyChar().vEff.elementAt(num21);
					if (effect != null && effect.template.id == num5)
					{
						if (effect.template.type == 7)
						{
							Char.getMyChar().cMiss -= effect.param;
						}
						Char.getMyChar().vEff.removeElementAt(num21);
						break;
					}
				}
				if (effect.template.type == 0 || effect.template.type == 12)
				{
					Char.getMyChar().cHP = msg.reader().readInt();
					Char.getMyChar().cMP = msg.reader().readInt();
					if (effect.template.type == 0)
					{
						InfoMe.addInfo(mResources.EFF_REMOVE);
					}
					else if (effect.template.type == 12)
					{
						Char.getMyChar().isInvisible = false;
						ServerEffect.addServerEffect(60, Char.getMyChar().cx, Char.getMyChar().cy, 1);
					}
				}
				else if (effect.template.type == 4 || effect.template.type == 13 || effect.template.type == 17)
				{
					Char.getMyChar().cHP = msg.reader().readInt();
				}
				else if (effect.template.type == 23)
				{
					Char.getMyChar().cHP = msg.reader().readInt();
					Char.getMyChar().cMaxHP = msg.reader().readInt();
				}
				else if (effect.template.type == 11)
				{
					Char.getMyChar().isInvisible = false;
					ServerEffect.addServerEffect(60, Char.getMyChar().cx, Char.getMyChar().cy, 1);
				}
				else if (effect.template.type == 14)
				{
					Char.getMyChar().isLockMove = false;
				}
				else if (effect.template.type == 2)
				{
					Char.getMyChar().isLockMove = false;
					Char.getMyChar().isLockAttack = false;
					ServerEffect.addServerEffect(77, Char.getMyChar().cx, Char.getMyChar().cy - 9, 1);
				}
				else if (effect.template.type == 3)
				{
					Char.isLockKey = false;
				}
				break;
			}
			case -96:
			{
				GameCanvas.debug("SA366", 2);
				Char @char = GameScr.findCharInMap(msg.reader().readInt());
				GameCanvas.debug("SA366x1", 2);
				if (@char != null)
				{
					GameCanvas.debug("SA366x2", 2);
					int num5 = msg.reader().readByte();
					Effect effect2 = null;
					for (int n = 0; n < @char.vEff.size(); n++)
					{
						GameCanvas.debug("SA366x3k" + n, 2);
						effect2 = (Effect)@char.vEff.elementAt(n);
						if (effect2 != null)
						{
							if (effect2.template.id == num5)
							{
								@char.vEff.removeElementAt(n);
								break;
							}
							GameCanvas.debug("SA366x3i" + n, 2);
						}
					}
					GameCanvas.debug("SA366x5", 2);
					if (effect2 != null)
					{
						if (effect2.template.type == 0)
						{
							GameCanvas.debug("SA366x5a2", 2);
							@char.cHP = msg.reader().readInt();
							@char.cMP = msg.reader().readInt();
						}
						else if (effect2.template.type == 11)
						{
							@char.cx = (@char.cxMoveLast = msg.reader().readUnsignedShort());
							@char.cy = (@char.cyMoveLast = msg.reader().readUnsignedShort());
							@char.isInvisible = false;
							ServerEffect.addServerEffect(60, @char.cx, @char.cy, 1);
						}
						else if (effect2.template.type == 12)
						{
							@char.cHP = msg.reader().readInt();
							@char.cMP = msg.reader().readInt();
							@char.isInvisible = false;
							ServerEffect.addServerEffect(60, @char.cx, @char.cy, 1);
						}
						else if (effect2.template.type == 4 || effect2.template.type == 13 || effect2.template.type == 17)
						{
							@char.cHP = msg.reader().readInt();
						}
						else if (effect2.template.type == 23)
						{
							Char.getMyChar().cHP = msg.reader().readInt();
							Char.getMyChar().cMaxHP = msg.reader().readInt();
						}
						else if (effect2.template.type == 2)
						{
							@char.isLockAttack = false;
							ServerEffect.addServerEffect(77, @char.cx, @char.cy - 9, 1);
						}
					}
					GameCanvas.debug("SA366x7", 2);
				}
				break;
			}
			case -95:
				GameCanvas.debug("SXX9", 2);
				GameScr.gI().timeLengthMap = msg.reader().readInt();
				GameScr.gI().timeStartMap = (int)(mSystem.getCurrentTimeMillis() / 1000);
				break;
			case -94:
			{
				GameCanvas.debug("SY1", 2);
				int index2 = msg.reader().readByte();
				Npc npc2 = (Npc)GameScr.vNpc.elementAt(index2);
				npc2.statusMe = msg.reader().readByte();
				if (npc2.template.npcTemplateId == 31 && npc2.statusMe == 15)
				{
					GameScr.startLanterns(npc2.cx, npc2.cy);
				}
				break;
			}
			case -92:
			{
				GameCanvas.debug("SY3", 2);
				int charId = msg.reader().readInt();
				Char @char = (charId != Char.getMyChar().charID) ? GameScr.findCharInMap(charId) : Char.getMyChar();
				if (@char != null)
				{
					@char.cTypePk = msg.reader().readByte();
				}
				break;
			}
			case -59:
			{
				int charId = msg.reader().readInt();
				Char @char = (charId != Char.getMyChar().charID) ? GameScr.findCharInMap(charId) : Char.getMyChar();
				@char.cHP = msg.reader().readInt();
				@char.cMaxHP = msg.reader().readInt();
				break;
			}
			case -58:
				GameScr.gI().resetButton();
				GameCanvas.timeBallEffect = 70;
				GameCanvas.isBallEffect = true;
				ServerEffect.addServerEffect(119, GameScr.gW2 + GameScr.cmx, GameScr.gH2 + GameScr.cmy, 1);
				break;
			case -57:
				GameCanvas.timeBallEffect = 40;
				GameCanvas.isBallEffect = true;
				break;
			case -56:
			{
				int charId = msg.reader().readInt();
				Char @char = GameScr.findCharInMap(charId);
				if (@char != null)
				{
					@char.cHP = msg.reader().readInt();
					@char.cMaxHP = msg.reader().readInt();
					@char.coat = (short)msg.reader().readUnsignedShort();
				}
				break;
			}
			case -55:
			{
				int charId = msg.reader().readInt();
				Char @char = GameScr.findCharInMap(charId);
				if (@char != null)
				{
					@char.cHP = msg.reader().readInt();
					@char.cMaxHP = msg.reader().readInt();
					@char.glove = (short)msg.reader().readUnsignedShort();
				}
				break;
			}
			case -54:
			{
				int charId = msg.reader().readInt();
				Char @char = (Char.getMyChar().charID != charId) ? GameScr.findCharInMap(charId) : Char.getMyChar();
				if (@char != null)
				{
					@char.arrItemMounts = new Item[5];
					@char.isWolf = (@char.isMoto = (@char.isMotoBehind = false));
					for (int num17 = 0; num17 < @char.arrItemMounts.Length; num17++)
					{
						short num18 = msg.reader().readShort();
						if (num18 != -1)
						{
							@char.arrItemMounts[num17] = new Item();
							@char.arrItemMounts[num17].typeUI = 41;
							@char.arrItemMounts[num17].indexUI = num17;
							@char.arrItemMounts[num17].template = ItemTemplates.get(num18);
							@char.arrItemMounts[num17].upgrade = msg.reader().readByte();
							@char.arrItemMounts[num17].expires = msg.reader().readLong();
							@char.arrItemMounts[num17].sys = msg.reader().readByte();
							@char.arrItemMounts[num17].isLock = true;
							if (num17 == 4)
							{
								if (@char.arrItemMounts[num17].template.id == 485 || @char.arrItemMounts[num17].template.id == 524)
								{
									@char.isMotoBehind = true;
								}
								else if (@char.arrItemMounts[num17].template.id == 443 || @char.arrItemMounts[num17].template.id == 523)
								{
									@char.isWolf = true;
								}
							}
							int num19 = msg.reader().readByte();
							@char.arrItemMounts[num17].options = new MyVector();
							for (int num20 = 0; num20 < num19; num20++)
							{
								@char.arrItemMounts[num17].options.addElement(new ItemOption(msg.reader().readByte(), msg.reader().readInt()));
							}
						}
					}
				}
				break;
			}
			case -78:
				GameCanvas.debug("SY4", 2);
				ServerEffect.addServerEffect(msg.reader().readShort(), Char.getMyChar().cx, Char.getMyChar().cy, 1);
				break;
			case -73:
			{
				GameCanvas.debug("SY4", 2);
				int iD = msg.reader().readUnsignedByte();
				Mob mob = Mob.get_Mob(iD);
				ServerEffect.addServerEffect(67, mob.x, mob.y, 1);
				break;
			}
			case -72:
				GameCanvas.debug("SY4", 2);
				Char.getMyChar().luong = msg.reader().readInt();
				break;
			case -71:
			{
				GameCanvas.debug("SY422", 2);
				int num16 = msg.reader().readInt();
				Char.getMyChar().luong += num16;
				GameScr.startFlyText("+" + num16, Char.getMyChar().cx, Char.getMyChar().cy - Char.getMyChar().ch - 10, 0, -2, mFont.ADDMONEY);
				InfoMe.addInfo(mResources.RECEIVE + " " + num16 + " " + mResources.GOLD, 20, mFont.tahoma_7_yellow);
				break;
			}
			case -68:
			{
				GameCanvas.debug("SY42222E", 2);
				Char @char = GameScr.findCharInMap(msg.reader().readInt());
				if (@char != null)
				{
					int num3 = msg.reader().readUnsignedByte();
					sbyte b3 = msg.reader().readByte();
					if (num3 > 0)
					{
						short pointx2 = (short)@char.cx;
						short pointy2 = (short)(@char.cy - 40);
						@char.mobMe = new Mob(-1, isDisable: false, isDontMove: false, isFire: false, isIce: false, isWind: false, num3, 1, 0, 0, 0, pointx2, pointy2, 4, 0, (b3 != 0) ? true : false, removeWhenDie: false);
						@char.mobMe.status = 5;
					}
					else
					{
						@char.mobMe = null;
					}
				}
				break;
			}
			case -65:
			{
				string text = msg.reader().readUTF();
				sbyte[] data = new sbyte[msg.reader().readInt()];
				msg.reader().read(ref data);
				if (data.Length == 0)
				{
					data = null;
				}
				sbyte b4 = 0;
				try
				{
					b4 = msg.reader().readByte();
				}
				catch (Exception)
				{
				}
				if (text.Equals("KSkill"))
				{
					GameScr.gI().onKSkill(data);
				}
				else if (text.Equals("OSkill"))
				{
					GameScr.gI().onOSkill(data);
				}
				else if (text.Equals("CSkill"))
				{
					GameScr.gI().onCSkill(data);
				}
				break;
			}
			case -69:
			{
				GameCanvas.debug("SY42222EE", 2);
				int num3 = msg.reader().readUnsignedByte();
				sbyte b3 = msg.reader().readByte();
				if (num3 > 0)
				{
					short pointx = (short)Char.getMyChar().cx;
					short pointy = (short)(Char.getMyChar().cy - 40);
					Char.getMyChar().mobMe = new Mob(-1, isDisable: false, isDontMove: false, isFire: false, isIce: false, isWind: false, num3, 1, 0, 0, 0, pointx, pointy, 4, 0, (b3 != 0) ? true : false, removeWhenDie: false);
					Char.getMyChar().mobMe.status = 5;
				}
				else
				{
					Char.getMyChar().mobMe = null;
				}
				break;
			}
			case -77:
				GameCanvas.debug("SY5", 2);
				try
				{
					GameScr.vPtMap.removeAllElements();
					while (true)
					{
						GameScr.vPtMap.addElement(new Party(msg.reader().readByte(), msg.reader().readUnsignedByte(), msg.reader().readUTF(), msg.reader().readByte()));
					}
					IL_35ba:;
				}
				catch (Exception)
				{
				}
				GameScr.gI().refreshFindTeam();
				break;
			case -76:
				((Party)GameScr.vParty.firstElement()).isLock = msg.reader().readBoolean();
				break;
			case -75:
				Char.getMyChar().arrItemBox[msg.reader().readByte()] = null;
				break;
			case -74:
				InfoDlg.showWait(msg.reader().readUTF());
				break;
			case -80:
				Char.getMyChar().arrItemBody[msg.reader().readByte()] = null;
				break;
			case -91:
			{
				GameCanvas.debug("SY6", 2);
				int num2 = msg.reader().readUnsignedByte();
				Item[] array = new Item[num2];
				for (int m = 0; m < Char.getMyChar().arrItemBag.Length; m++)
				{
					array[m] = Char.getMyChar().arrItemBag[m];
				}
				Char.getMyChar().arrItemBag = array;
				Char.getMyChar().arrItemBag[msg.reader().readUnsignedByte()] = null;
				InfoMe.addInfo(mResources.BAG_EXPANDED + " " + Char.getMyChar().arrItemBag.Length + " ô");
				break;
			}
			case -90:
				GameCanvas.debug("SY7", 2);
				for (int l = 0; l < GameScr.vNpc.size(); l++)
				{
					Npc npc = (Npc)GameScr.vNpc.elementAt(l);
					if (npc != null && npc.statusMe == 15)
					{
						npc.statusMe = 1;
						break;
					}
				}
				switch (msg.reader().readByte())
				{
				case 1:
					InfoMe.addInfo(mResources.PROTECT_FAR, 20, mFont.tahoma_7_yellow);
					break;
				case 2:
					InfoMe.addInfo(mResources.PROTECT_INJURE, 20, mFont.tahoma_7_yellow);
					break;
				}
				break;
			case -89:
				GameCanvas.isLoading = false;
				GameCanvas.debug("SY8", 2);
				try
				{
					InfoMe.addInfo(msg.reader().readUTF(), 20, mFont.tahoma_7_yellow);
				}
				catch (Exception)
				{
				}
				InfoDlg.hide();
				GameCanvas.endDlg();
				break;
			case -87:
			{
				GameCanvas.debug("SY9", 2);
				int index = msg.reader().readByte();
				Party party = (Party)GameScr.vParty.elementAt(index);
				GameScr.vParty.setElementAt(GameScr.vParty.elementAt(0), index);
				if (party != null)
				{
					GameScr.vParty.setElementAt(party, 0);
				}
				GameScr.gI().refreshTeam();
				if (party != null)
				{
					InfoMe.addInfo(party.name + mResources.TEAMLEADER_CHANGE, 20, mFont.tahoma_7_yellow);
				}
				break;
			}
			case -86:
				GameCanvas.debug("SYA1", 2);
				GameScr.vParty.removeAllElements();
				GameScr.gI().refreshTeam();
				InfoMe.addInfo(mResources.MOVEOUT_ME, 20, mFont.tahoma_7_yellow);
				break;
			case -85:
				GameCanvas.debug("SYA2", 2);
				GameScr.vFriend.removeAllElements();
				try
				{
					while (true)
					{
						GameScr.vFriend.addElement(new Friend(msg.reader().readUTF(), msg.reader().readByte()));
					}
					IL_38ef:;
				}
				catch (Exception)
				{
				}
				for (int k = 0; k < GameScr.vFriendWait.size(); k++)
				{
					GameScr.vFriend.addElement(GameScr.vFriendWait.elementAt(k));
				}
				GameScr.gI().sortList(0);
				break;
			case -84:
				GameCanvas.debug("SYA3", 2);
				GameScr.vEnemies.removeAllElements();
				try
				{
					while (true)
					{
						GameScr.vEnemies.addElement(new Friend(msg.reader().readUTF(), msg.reader().readByte()));
					}
					IL_397f:;
				}
				catch (Exception)
				{
				}
				GameScr.gI().sortList(1);
				break;
			case -83:
			{
				GameCanvas.debug("SYA4", 2);
				string value = msg.reader().readUTF();
				for (int j = 0; j < GameScr.vFriend.size(); j++)
				{
					Friend friend2 = (Friend)GameScr.vFriend.elementAt(j);
					if (friend2 != null && friend2.friendName.Equals(value))
					{
						GameScr.indexRow = 0;
						GameScr.vFriend.removeElementAt(j);
						GameScr.gI().actRemoveWaitAcceptFriend(value);
						break;
					}
				}
				if (GameScr.isPaintFriend)
				{
					GameScr.gI().sortList(0);
					GameScr.indexRow = 0;
					GameScr.scrMain.clear();
				}
				break;
			}
			case -82:
			{
				GameCanvas.debug("SYA5", 2);
				string value = msg.reader().readUTF();
				for (int i = 0; i < GameScr.vEnemies.size(); i++)
				{
					Friend friend = (Friend)GameScr.vEnemies.elementAt(i);
					if (friend != null && friend.friendName.Equals(value))
					{
						GameScr.indexRow = 0;
						GameScr.vEnemies.removeElementAt(i);
						break;
					}
				}
				GameScr.gI().sortList(0);
				break;
			}
			case -81:
				GameCanvas.debug("SYA6", 2);
				Char.getMyChar().cPk = msg.reader().readByte();
				Char.getMyChar().charFocus = null;
				break;
			}
		}
		catch (Exception)
		{
		}
		finally
		{
			msg?.cleanup();
		}
	}

	public bool readCharInfo(Char c, Message msg)
	{
		try
		{
			c.cClanName = msg.reader().readUTF();
			if (!c.cClanName.Equals(string.Empty))
			{
				c.ctypeClan = msg.reader().readByte();
			}
			c.isInvisible = msg.reader().readBoolean();
			c.cTypePk = msg.reader().readByte();
			c.nClass = GameScr.nClasss[msg.reader().readByte()];
			c.cgender = msg.reader().readByte();
			c.head = msg.reader().readShort();
			c.cName = msg.reader().readUTF();
			c.cHP = msg.reader().readInt();
			c.cMaxHP = msg.reader().readInt();
			c.clevel = msg.reader().readUnsignedByte();
			c.wp = msg.reader().readShort();
			c.body = msg.reader().readShort();
			c.leg = msg.reader().readShort();
			sbyte b = msg.reader().readByte();
			if (c.wp == -1)
			{
				c.setDefaultWeapon();
			}
			if (c.body == -1)
			{
				c.setDefaultBody();
			}
			if (c.leg == -1)
			{
				c.setDefaultLeg();
			}
			if (b == -1)
			{
				c.mobMe = null;
			}
			else
			{
				short pointx = (short)c.cx;
				short pointy = (short)(c.cy - 40);
				c.mobMe = new Mob(-1, isDisable: false, isDontMove: false, isFire: false, isIce: false, isWind: false, b, 1, 0, 0, 0, pointx, pointy, 4, 0, isBos: false, removeWhenDie: false);
				c.mobMe.status = 5;
			}
			c.cx = (c.cxMoveLast = msg.reader().readShort());
			c.cy = (c.cyMoveLast = msg.reader().readShort());
			c.eff5BuffHp = msg.reader().readShort();
			c.eff5BuffMp = msg.reader().readShort();
			int num = msg.reader().readByte();
			for (int i = 0; i < num; i++)
			{
				Effect effect = new Effect(msg.reader().readByte(), msg.reader().readInt(), msg.reader().readInt(), msg.reader().readShort());
				c.vEff.addElement(effect);
				if (effect.template.type == 12 || effect.template.type == 11)
				{
					c.isInvisible = true;
				}
			}
			if (!c.isInvisible)
			{
				ServerEffect.addServerEffect(60, c, 1);
			}
			if (c.cHP == 0)
			{
				c.statusMe = 14;
				if (Char.getMyChar().charID == c.charID)
				{
					GameScr.gI().resetButton();
				}
			}
			if (c.charID == -Char.getMyChar().charID)
			{
				for (int j = 0; j < GameScr.vNpc.size(); j++)
				{
					Npc npc = (Npc)GameScr.vNpc.elementAt(j);
					if (npc.template.name.Equals(c.cName))
					{
						npc.hide();
						break;
					}
				}
			}
			c.isHuman = msg.reader().readBoolean();
			c.isNhanban = msg.reader().readBoolean();
			if (c.isNhanbanz())
			{
				ServerEffect.addServerEffect(141, c.cx, c.cy, 0);
			}
			short[] array = new short[4]
			{
				msg.reader().readShort(),
				msg.reader().readShort(),
				msg.reader().readShort(),
				msg.reader().readShort()
			};
			if (array[0] > -1)
			{
				c.head = array[0];
			}
			if (array[1] > -1)
			{
				c.wp = array[1];
			}
			if (array[2] > -1)
			{
				c.body = array[2];
			}
			if (array[3] > -1)
			{
				c.leg = array[3];
			}
			Party.refresh(c);
			return true;
			IL_0421:;
		}
		catch (Exception)
		{
		}
		return false;
	}

	public void requestItemInfo(Message msg)
	{
		try
		{
			int num = msg.reader().readByte();
			int num2 = msg.reader().readUnsignedByte();
			Item item = null;
			switch (num)
			{
			case 3:
				item = Char.getMyChar().arrItemBag[num2];
				if (item == null)
				{
					if (GameScr.itemSplit != null && GameScr.itemSplit.indexUI == num2)
					{
						item = GameScr.itemSplit;
					}
					if (GameScr.itemUpGrade != null && GameScr.itemUpGrade.indexUI == num2)
					{
						item = GameScr.itemUpGrade;
					}
					if (GameScr.itemSell != null && GameScr.itemSell.indexUI == num2)
					{
						item = GameScr.itemSell;
					}
					if (item == null && GameScr.arrItemUpGrade != null)
					{
						for (int i = 0; i < GameScr.arrItemUpGrade.Length; i++)
						{
							if (GameScr.arrItemUpGrade[i] != null && GameScr.arrItemUpGrade[i].indexUI == num2)
							{
								item = GameScr.arrItemUpGrade[i];
								break;
							}
						}
					}
					if (item == null && GameScr.arrItemConvert != null)
					{
						for (int j = 0; j < GameScr.arrItemConvert.Length; j++)
						{
							if (GameScr.arrItemConvert[j] != null && GameScr.arrItemConvert[j].indexUI == num2)
							{
								item = GameScr.arrItemConvert[j];
								break;
							}
						}
					}
					if (item == null && GameScr.arrItemUpPeal != null)
					{
						for (int k = 0; k < GameScr.arrItemUpPeal.Length; k++)
						{
							if (GameScr.arrItemUpPeal[k] != null && GameScr.arrItemUpPeal[k].indexUI == num2)
							{
								item = GameScr.arrItemUpPeal[k];
								break;
							}
						}
					}
					if (item == null && GameScr.arrItemTradeMe != null)
					{
						for (int l = 0; l < GameScr.arrItemTradeMe.Length; l++)
						{
							if (GameScr.arrItemTradeMe[l] != null && GameScr.arrItemTradeMe[l].indexUI == num2)
							{
								item = GameScr.arrItemTradeMe[l];
								break;
							}
						}
					}
					if (item == null && GameScr.arrItemSplit != null)
					{
						for (int m = 0; m < GameScr.arrItemSplit.Length; m++)
						{
							if (GameScr.arrItemSplit[m] != null && GameScr.arrItemSplit[m].indexUI == num2)
							{
								item = GameScr.arrItemSplit[m];
								break;
							}
						}
					}
				}
				break;
			case 4:
				item = Char.getMyChar().arrItemBox[num2];
				break;
			case 39:
				item = Char.clan.items[GameScr.indexSelect];
				break;
			case 5:
				item = Char.getMyChar().arrItemBody[num2];
				break;
			case 20:
				item = GameScr.arrItemNonNam[num2];
				break;
			case 21:
				item = GameScr.arrItemNonNu[num2];
				break;
			case 22:
				item = GameScr.arrItemAoNam[num2];
				break;
			case 23:
				item = GameScr.arrItemAoNu[num2];
				break;
			case 24:
				item = GameScr.arrItemGangTayNam[num2];
				break;
			case 25:
				item = GameScr.arrItemGangTayNu[num2];
				break;
			case 26:
				item = GameScr.arrItemQuanNam[num2];
				break;
			case 27:
				item = GameScr.arrItemQuanNu[num2];
				break;
			case 28:
				item = GameScr.arrItemGiayNam[num2];
				break;
			case 29:
				item = GameScr.arrItemGiayNu[num2];
				break;
			case 16:
				item = GameScr.arrItemLien[num2];
				break;
			case 17:
				item = GameScr.arrItemNhan[num2];
				break;
			case 18:
				item = GameScr.arrItemNgocBoi[num2];
				break;
			case 19:
				item = GameScr.arrItemPhu[num2];
				break;
			case 2:
				item = GameScr.arrItemWeapon[num2];
				break;
			case 6:
				item = GameScr.arrItemStack[num2];
				break;
			case 7:
				item = GameScr.arrItemStackLock[num2];
				break;
			case 8:
				item = GameScr.arrItemGrocery[num2];
				break;
			case 9:
				item = GameScr.arrItemGroceryLock[num2];
				break;
			case 14:
				item = GameScr.arrItemStore[num2];
				break;
			case 35:
				item = GameScr.arrItemElites[num2];
				break;
			case 15:
				item = GameScr.arrItemBook[num2];
				break;
			case 32:
				item = GameScr.arrItemFashion[num2];
				break;
			case 34:
				item = GameScr.arrItemClanShop[num2];
				break;
			case 30:
				item = GameScr.arrItemTradeOrder[num2];
				break;
			}
			item.expires = msg.reader().readLong();
			if (item.isTypeUIMe())
			{
				item.saleCoinLock = msg.reader().readInt();
			}
			else if (item.isTypeUIShop() || item.isTypeUIShopLock() || item.isTypeUIStore() || item.isTypeUIBook() || item.isTypeUIFashion() || item.isTypeUIClanShop())
			{
				item.buyCoin = msg.reader().readInt();
				item.buyCoinLock = msg.reader().readInt();
				item.buyGold = msg.reader().readInt();
			}
			if (item.isTypeBody() || item.isTypeMounts() || item.isTypeNgocKham())
			{
				item.sys = msg.reader().readByte();
				item.options = new MyVector();
				try
				{
					while (true)
					{
						item.options.addElement(new ItemOption(msg.reader().readByte(), msg.reader().readInt()));
					}
					IL_0586:;
				}
				catch (Exception)
				{
				}
			}
			else if (item.template.id == 233)
			{
				item.img = createImage(NinjaUtil.readByteArray(msg));
			}
			else if (item.template.id == 234)
			{
				item.img = createImage(NinjaUtil.readByteArray(msg));
			}
			else if (item.template.id == 235)
			{
				item.img = createImage(NinjaUtil.readByteArray(msg));
			}
			if (num == 5)
			{
				Char.getMyChar().updateKickOption();
			}
		}
		catch (Exception)
		{
			Out.println("loi tai day ham requet item info ---------------------------------------------------------");
		}
	}

	public void addMob(Message msg)
	{
		try
		{
			int num = msg.reader().readByte();
			for (sbyte b = 0; b < num; b = (sbyte)(b + 1))
			{
				short mobId = msg.reader().readUnsignedByte();
				bool isDisable = msg.reader().readBoolean();
				bool isDontMove = msg.reader().readBoolean();
				bool isFire = msg.reader().readBoolean();
				bool isIce = msg.reader().readBoolean();
				bool isWind = msg.reader().readBoolean();
				int templateId = msg.reader().readUnsignedByte();
				int sys = msg.reader().readByte();
				int hp = msg.reader().readInt();
				int level = msg.reader().readUnsignedByte();
				int maxhp = msg.reader().readInt();
				short pointx = msg.reader().readShort();
				short pointy = msg.reader().readShort();
				sbyte status = msg.reader().readByte();
				sbyte levelBoss = msg.reader().readByte();
				bool isBos = msg.reader().readBoolean();
				Mob mob = new Mob(mobId, isDisable, isDontMove, isFire, isIce, isWind, templateId, sys, hp, level, maxhp, pointx, pointy, status, levelBoss, isBos, removeWhenDie: true);
				if (Mob.arrMobTemplate[mob.templateId].type != 0)
				{
					if (b % 3 == 0)
					{
						mob.dir = -1;
					}
					else
					{
						mob.dir = 1;
					}
					mob.x += 10 - b % 20;
				}
				GameScr.vMob.addElement(mob);
			}
		}
		catch (Exception)
		{
			mSystem.println("err addMob");
		}
	}

	public void addEffAuto(Message msg)
	{
		try
		{
			short id = msg.reader().readUnsignedByte();
			int x = msg.reader().readShort();
			int y = msg.reader().readShort();
			sbyte loopCount = msg.reader().readByte();
			short time = msg.reader().readShort();
			EffectAuto.addEffectAuto(id, x, y, loopCount, time, 1);
		}
		catch (Exception)
		{
			mSystem.println("err add effAuto");
		}
	}

	public void getDataEffAuto(Message msg)
	{
		try
		{
			short id = msg.reader().readUnsignedByte();
			short num = msg.reader().readShort();
			sbyte[] data = null;
			if (num > 0)
			{
				data = new sbyte[num];
				msg.reader().read(ref data);
			}
			EffectAuto.reciveData(id, data);
		}
		catch (Exception)
		{
			mSystem.println("err add effAuto");
		}
	}

	public void getImgEffAuto(Message msg)
	{
		try
		{
			sbyte id = (sbyte)msg.reader().readUnsignedByte();
			sbyte[] data = NinjaUtil.readByteArray_Int(msg);
			EffectAuto.reciveImage(id, data);
		}
		catch (Exception)
		{
			mSystem.println("err getImgEffAuto");
		}
	}

	public void khamngoc(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			sbyte b2 = 1;
			Char.getMyChar().luong = msg.reader().readInt();
			Char.getMyChar().xu = msg.reader().readInt();
			Char.getMyChar().yen = msg.reader().readInt();
			if (b == 0)
			{
				if (GameScr.itemSplit != null)
				{
					GameScr.itemSplit = null;
				}
				if (GameScr.arrItemSplit != null)
				{
					for (int i = 0; i < GameScr.arrItemSplit.Length; i++)
					{
						GameScr.arrItemSplit[i] = null;
					}
				}
			}
			else if (b == 1)
			{
				if (GameScr.itemSplit != null)
				{
					GameScr.itemSplit.isLock = true;
					GameScr.itemSplit.upgrade = msg.reader().readByte();
					if (b2 == 1)
					{
						GameScr.effUpok = GameScr.efs[53];
						GameScr.indexEff = 0;
					}
				}
				if (GameScr.arrItemSplit != null)
				{
					for (int j = 0; j < GameScr.arrItemSplit.Length; j++)
					{
						GameScr.arrItemSplit[j] = null;
					}
				}
			}
			else if ((b == 2 || b == 3) && GameScr.arrItemSplit != null)
			{
				for (int k = 0; k < GameScr.arrItemSplit.Length; k++)
				{
					GameScr.arrItemSplit[k] = null;
				}
			}
			GameScr.gI().left = (GameScr.gI().center = null);
			GameScr.gI().updateKeyBuyItemUI();
			GameCanvas.endDlg();
		}
		catch (Exception)
		{
		}
	}

	public void addEffect(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			MainObject mainObject;
			if (b == 1)
			{
				int iD = msg.reader().readUnsignedByte();
				mainObject = Mob.get_Mob(iD);
			}
			else
			{
				int num = msg.reader().readInt();
				mainObject = ((num != Char.getMyChar().charID) ? GameScr.findCharInMap(num) : Char.getMyChar());
			}
			if (mainObject != null)
			{
				short id = msg.reader().readShort();
				int num2 = msg.reader().readInt();
				sbyte b2 = msg.reader().readByte();
				mainObject.addDataeff(id, num2 + mSystem.currentTimeMillis(), b2 * 1000);
			}
		}
		catch (Exception)
		{
		}
	}

	public void getImgEffect(Message msg)
	{
		try
		{
			short num = msg.reader().readUnsignedByte();
			sbyte[] array = NinjaUtil.readByteArray_Int(msg);
			GameData.setImgIcon(num, array);
			ImageIcon imageIcon = (ImageIcon)GameData.listImgIcon.get(string.Empty + num);
			if (imageIcon == null)
			{
				imageIcon = new ImageIcon();
				GameData.listImgIcon.put(num + string.Empty, imageIcon);
			}
			imageIcon.isLoad = false;
			imageIcon.img = createImage(array);
			if (GameMidlet.CLIENT_TYPE != 1)
			{
				RMS.saveRMSImage("ImgEffect " + num, array);
			}
		}
		catch (Exception)
		{
		}
	}

	public void getDataEffect(Message msg)
	{
		try
		{
			short num = msg.reader().readUnsignedByte();
			short num2 = msg.reader().readShort();
			sbyte[] data = null;
			if (num2 > 0)
			{
				data = new sbyte[num2];
				msg.reader().read(ref data);
			}
			((EffectData)GameData.listbyteData.get(string.Empty + num))?.setdata(data);
		}
		catch (Exception)
		{
		}
	}
}
