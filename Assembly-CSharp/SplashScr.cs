public class SplashScr : mScreen
{
	public static int splashScrStat;

	public static SplashScr instance;

	public Image imgTitle = GameCanvas.loadImage("/tt");

	public SplashScr()
	{
		instance = this;
	}

	public static SplashScr gI()
	{
		return (instance != null) ? instance : (instance = new SplashScr());
	}

	public override void switchToMe()
	{
		base.switchToMe();
	}

	public static void loadSplashScr()
	{
		splashScrStat = 0;
	}

	public override void update()
	{
		if (splashScrStat > 5)
		{
			if (RMS.loadRMSInt("indLanguage") >= 0)
			{
				GameCanvas.instance.initGameCanvas();
				if (!GameMidlet.isWorldver)
				{
					GameCanvas.selectsvScr.switchToMe();
				}
				else
				{
					GameCanvas.logScrEng.switchToMe();
				}
			}
			else
			{
				GameCanvas.instance.initGameCanvas();
				if (!GameMidlet.isWorldver)
				{
					GameCanvas.languageScr.switchToMe();
				}
				else
				{
					GameCanvas.logScrEng.switchToMe();
				}
			}
		}
		splashScrStat++;
	}

	public override void paint(mGraphics g)
	{
		g.setColor(0);
		g.fillRect(0, 0, GameCanvas.w, GameCanvas.h);
		if (Main.isPC && imgTitle != null)
		{
			g.drawImage(imgTitle, GameCanvas.hw, GameCanvas.h / 2, 3);
		}
	}
}
