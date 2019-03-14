using System.IO;
using UnityEngine;

public class GameMidlet
{
	public const string VERSION = "1.4.8";

	public static string[] ipList = new string[7]
	{
		"nj3.teamobi.com",
		"nj1.teamobi.com",
		"nj2.teamobi.com",
		"nj2.teamobi.com",
		"nj4.teamobi.com",
		"nj3.teamobi.com",
		"nj3.teamobi.com"
	};

	public static int[] portList = new int[7]
	{
		14444,
		14444,
		14444,
		14444,
		14444,
		14444,
		14444
	};

	public static sbyte[] serverLoginList = new sbyte[7]
	{
		0,
		0,
		0,
		1,
		0,
		0,
		0
	};

	public static int[] serverST = new int[7]
	{
		0,
		1,
		2,
		3,
		4,
		5,
		0
	};

	public static sbyte CLIENT_TYPE = 4;

	public static sbyte indexClient = 0;

	public static string IP = string.Empty;

	public static int PORT = 14444;

	public static sbyte userProvider = 0;

	public static string clientAgent;

	public static bool isWorldver = false;

	public static sbyte serverLogin = 0;

	public static GameMidlet instance;

	public static int muzic = -1;

	public static bool isPlaySound;

	public static string inFoSMS;

	public GameMidlet()
	{
		MotherCanvas.instance = new MotherCanvas();
		Session_ME.gI().setHandler(Controller.gI());
		instance = this;
		mFont.init();
		mScreen.ITEM_HEIGHT = mFont.tahoma_8b.getHeight() + 6;
		clientAgent = readFileText("agent");
		if (Main.isPC)
		{
			userProvider = sbyte.Parse(readFileText("provider"));
		}
		else
		{
			userProvider = sbyte.Parse(string.Empty + iOSPlugins.getProvider());
		}
		Debug.Log("AGENT: " + clientAgent + ", PROVIDER: " + userProvider);
		SplashScr.loadSplashScr();
		GameCanvas.currentScreen = new SplashScr();
		Key.mapKeyPC();
		if (Main.isWp)
		{
			ipList = new string[7]
			{
				"112.213.94.161",
				"112.213.84.18",
				"27.0.14.73",
				"27.0.14.73",
				"112.213.94.135",
				"112.213.85.75",
				"112.213.94.161"
			};
		}
		else
		{
			ipList = new string[7]
			{
				"nj3.teamobi.com",
				"nj1.teamobi.com",
				"nj2.teamobi.com",
				"nj2.teamobi.com",
				"112.213.94.135",
				"nj1.teamobi.com",
				"nj3.teamobi.com"
			};
		}
	}

	public void exit()
	{
		GameCanvas.bRun = false;
		Main.exit();
	}

	public static void sendSMSRe(string data, string to, Command successAction, Command failAction)
	{
		if (to.Contains("sms://"))
		{
			to = to.Remove(0, 6);
		}
		if (Main.isPC)
		{
			GameCanvas.endDlg();
			GameCanvas.startOKDlg(inFoSMS + data + mResources.SEND_TO + to);
		}
		else
		{
			GameCanvas.endDlg();
			GameCanvas.startOKDlg(inFoSMS + data + mResources.SEND_TO + to);
		}
	}

	public static void sendSMS(string data, string to, Command successAction, Command failAction)
	{
		Out.println("Send SMS >> " + data + "  " + to);
	}

	public static void flatForm(string url)
	{
		Out.println("PLATFORM " + url);
	}

	public void platformRequest(string url)
	{
		Out.LogWarning("PLATFORM REQUEST: " + url);
		Application.OpenURL(url);
	}

	public void notifyDestroyed()
	{
		GameCanvas.endDlg();
		Main.exit();
	}

	public string readFileText(string fileName)
	{
		try
		{
			StringReader stringReader = null;
			TextAsset textAsset = (TextAsset)Resources.Load(Main.res + "/" + fileName, typeof(TextAsset));
			stringReader = new StringReader(textAsset.text);
			string text = stringReader.ReadLine();
			return text.ToString();
			IL_0046:
			return text;
		}
		catch (IOException)
		{
			return string.Empty;
		}
	}
}
