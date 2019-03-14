using System.Threading;
using UnityEngine;

public class Sound
{
	private const int INTERVAL = 5;

	private const int MAXTIME = 100;

	public static int status;

	public static int postem;

	public static int timestart;

	private static string filenametemp;

	private static float volumetem;

	public static bool isSound = true;

	public static AudioSource SoundWater;

	public static AudioSource SoundRun;

	public static AudioSource SoundBGLoop;

	public static AudioClip[] mysound;

	public static GameObject[] player;

	public static string[] fileName = new string[34]
	{
		"0",
		"1",
		"2",
		"3",
		"4",
		"5",
		"6",
		"7",
		"8",
		"9",
		"10",
		"11",
		"12",
		"13",
		"14",
		"15",
		"16",
		"17",
		"18",
		"19",
		"29",
		"21",
		"22",
		"23",
		"24",
		"25",
		"26",
		"27",
		"28",
		"29",
		"30",
		"31",
		"32",
		"33"
	};

	public static sbyte MLogin = 0;

	public static sbyte MBClick = 1;

	public static sbyte MTone = 2;

	public static sbyte MSanzu = 3;

	public static sbyte MChakumi = 4;

	public static sbyte MChai = 5;

	public static sbyte MOshin = 6;

	public static sbyte MEchigo = 7;

	public static sbyte MKojin = 8;

	public static sbyte MHaruna = 9;

	public static sbyte MHirosaki = 10;

	public static sbyte MOokaza = 11;

	public static sbyte MGiotuyet = 12;

	public static sbyte MHangdong = 13;

	public static sbyte MDeKeu = 14;

	public static sbyte MChimKeu = 15;

	public static sbyte MBuocChan = 16;

	public static sbyte MNuocChay = 17;

	public static sbyte MBomMau = 18;

	public static sbyte MKiemGo = 19;

	public static sbyte MKiem = 20;

	public static sbyte MTieu = 21;

	public static sbyte MKunai = 22;

	public static sbyte MCung = 23;

	public static sbyte MDao = 24;

	public static sbyte MQuat = 25;

	public static sbyte MCung2 = 26;

	public static sbyte MTieu2 = 27;

	public static sbyte MTieu3 = 28;

	public static sbyte MKiem2 = 29;

	public static sbyte MKiem3 = 30;

	public static sbyte MDao2 = 31;

	public static sbyte MDao3 = 32;

	public static sbyte MCung3 = 33;

	public static bool bMuzikDisable;

	public static void stop()
	{
		for (int i = 0; i < player.Length; i++)
		{
			if (player[i] != null)
			{
				player[i].GetComponent<AudioSource>().Pause();
			}
		}
	}

	public static void init()
	{
		GameObject gameObject = new GameObject();
		gameObject.name = "Audio Player Water";
		gameObject.transform.position = Vector3.zero;
		gameObject.AddComponent<AudioListener>();
		SoundWater = gameObject.AddComponent<AudioSource>();
		GameObject gameObject2 = new GameObject();
		gameObject2.name = "Audio Player";
		gameObject2.transform.position = Vector3.zero;
		gameObject2.AddComponent<AudioListener>();
		SoundBGLoop = gameObject2.AddComponent<AudioSource>();
		GameObject gameObject3 = new GameObject();
		gameObject3.name = "Audio Player Run";
		gameObject3.transform.position = Vector3.zero;
		gameObject3.AddComponent<AudioListener>();
		SoundRun = gameObject3.AddComponent<AudioSource>();
		player = new GameObject[34];
		mysound = new AudioClip[34];
		for (int i = 0; i < player.Length; i++)
		{
			getAssetSoundFile(fileName[i], i);
		}
		if (Main.isIpod && mGraphics.zoomLevel == 1)
		{
			bMuzikDisable = true;
		}
		else
		{
			bMuzikDisable = false;
		}
	}

	public static void getAssetSoundFile(string fileName, int type)
	{
		stop(type);
		string empty = string.Empty;
		empty = Main.res + "/music/" + fileName;
		load(empty, type);
	}

	public static void stopAll()
	{
		bMuzikDisable = true;
		for (int i = 0; i < mysound.Length; i++)
		{
			stop(i);
		}
	}

	public static void stopAllBg()
	{
		for (int i = 0; i < mysound.Length; i++)
		{
			stop(i);
		}
		sTopSoundBG(0);
		sTopSoundRun();
		stopSoundNatural(0);
	}

	public static void update()
	{
	}

	public static void stopMusic(int x)
	{
		if (!bMuzikDisable)
		{
			stop(x);
		}
	}

	public static void play(int id, float volume)
	{
		if (!bMuzikDisable)
		{
			start(volume, id);
		}
	}

	public static void playSoundRun(int id, float volume)
	{
		if (!bMuzikDisable && !(SoundRun == null))
		{
			SoundRun.GetComponent<AudioSource>().GetComponent<AudioSource>().clip = mysound[id];
			SoundRun.GetComponent<AudioSource>().GetComponent<AudioSource>().volume = volume;
			SoundRun.GetComponent<AudioSource>().GetComponent<AudioSource>().Play();
		}
	}

	public static void sTopSoundRun()
	{
		SoundRun.GetComponent<AudioSource>().GetComponent<AudioSource>().Stop();
	}

	public static bool isPlayingSound()
	{
		if (SoundRun == null)
		{
			return false;
		}
		return SoundRun.GetComponent<AudioSource>().GetComponent<AudioSource>().isPlaying;
	}

	public static void playSoundNatural(int id, float volume, bool isLoop)
	{
		if (!bMuzikDisable && !(SoundBGLoop == null))
		{
			SoundWater.GetComponent<AudioSource>().GetComponent<AudioSource>().loop = isLoop;
			SoundWater.GetComponent<AudioSource>().GetComponent<AudioSource>().clip = mysound[id];
			SoundWater.GetComponent<AudioSource>().GetComponent<AudioSource>().volume = volume;
			SoundWater.GetComponent<AudioSource>().GetComponent<AudioSource>().Play();
		}
	}

	public static void stopSoundNatural(int id)
	{
		SoundWater.GetComponent<AudioSource>().GetComponent<AudioSource>().Stop();
	}

	public static bool isPlayingSoundatural(int id)
	{
		if (SoundWater == null)
		{
			return false;
		}
		return SoundWater.GetComponent<AudioSource>().GetComponent<AudioSource>().isPlaying;
	}

	public static void playSoundBGLoop(int id, float volume)
	{
		if (!bMuzikDisable && !(SoundBGLoop == null))
		{
			SoundBGLoop.GetComponent<AudioSource>().GetComponent<AudioSource>().loop = true;
			SoundBGLoop.GetComponent<AudioSource>().GetComponent<AudioSource>().clip = mysound[id];
			SoundBGLoop.GetComponent<AudioSource>().GetComponent<AudioSource>().volume = volume;
			SoundBGLoop.GetComponent<AudioSource>().GetComponent<AudioSource>().Play();
		}
	}

	public static void sTopSoundBG(int id)
	{
		SoundBGLoop.GetComponent<AudioSource>().GetComponent<AudioSource>().Stop();
	}

	public static bool isPlayingSoundBG(int id)
	{
		if (SoundBGLoop == null)
		{
			return false;
		}
		return SoundBGLoop.GetComponent<AudioSource>().GetComponent<AudioSource>().isPlaying;
	}

	public static void load(string filename, int pos)
	{
		if (Thread.CurrentThread.Name == Main.mainThreadName)
		{
			__load(filename, pos);
		}
		else
		{
			_load(filename, pos);
		}
	}

	private static void _load(string filename, int pos)
	{
		if (status != 0)
		{
			Out.LogError("CANNOT LOAD AUDIO " + filename + " WHEN LOADING " + filenametemp);
			return;
		}
		filenametemp = filename;
		postem = pos;
		status = 2;
		int i;
		for (i = 0; i < 100; i++)
		{
			Thread.Sleep(5);
			if (status == 0)
			{
				break;
			}
		}
		if (i == 100)
		{
			Debug.LogError("TOO LONG FOR LOAD AUDIO " + filename);
		}
		else
		{
			Out.Log("Load Audio " + filename + " done in " + i * 5 + "ms");
		}
	}

	private static void __load(string filename, int pos)
	{
		mysound[pos] = (AudioClip)Resources.Load(filename, typeof(AudioClip));
		GameObject.Find("Main Camera").AddComponent<AudioSource>();
		player[pos] = GameObject.Find("Main Camera");
	}

	public static void start(float volume, int pos)
	{
		if (Thread.CurrentThread.Name == Main.mainThreadName)
		{
			__start(volume, pos);
		}
		else
		{
			_start(volume, pos);
		}
	}

	public static void _start(float volume, int pos)
	{
		if (status != 0)
		{
			Debug.LogError("CANNOT START AUDIO WHEN STARTING");
			return;
		}
		volumetem = volume;
		postem = pos;
		status = 3;
		int i;
		for (i = 0; i < 100; i++)
		{
			Thread.Sleep(5);
			if (status == 0)
			{
				break;
			}
		}
		if (i == 100)
		{
			Debug.LogError("TOO LONG FOR START AUDIO");
		}
		else
		{
			Debug.Log("Start Audio done in " + i * 5 + "ms");
		}
	}

	public static void __start(float volume, int pos)
	{
		if (!(player[pos] == null))
		{
			player[pos].GetComponent<AudioSource>().GetComponent<AudioSource>().PlayOneShot(mysound[pos], volume);
		}
	}

	public static void stop(int pos)
	{
		if (Thread.CurrentThread.Name == Main.mainThreadName)
		{
			__stop(pos);
		}
		else
		{
			_stop(pos);
		}
	}

	public static void _stop(int pos)
	{
		if (status != 0)
		{
			Debug.LogError("CANNOT STOP AUDIO WHEN STOPPING");
			return;
		}
		postem = pos;
		status = 4;
		int i;
		for (i = 0; i < 100; i++)
		{
			Thread.Sleep(5);
			if (status == 0)
			{
				break;
			}
		}
		if (i == 100)
		{
			Debug.LogError("TOO LONG FOR STOP AUDIO");
		}
		else
		{
			Debug.Log("Stop Audio done in " + i * 5 + "ms");
		}
	}

	public static void __stop(int pos)
	{
		if (player[pos] != null)
		{
			player[pos].GetComponent<AudioSource>().GetComponent<AudioSource>().Stop();
		}
	}
}
