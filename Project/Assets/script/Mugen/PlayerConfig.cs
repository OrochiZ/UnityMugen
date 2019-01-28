
using System;

namespace Mugen
{
	public class PlayerFiles: IConfigPropertys
	{
		public string ConfigName
		{
			get
			{
				return string.Empty;
			}
		}

		public string cmd
		{
			get; protected set;
		}

		public string cns
		{
			get; protected set;
		}

		// state
		public string st
		{
			get; protected set;
		}

		public string st2
		{
			get; protected set;
		}

		public string st3
		{
			get; protected set;
		}

		public string st4
		{
			get; protected set;
		}

		public string anim
		{
			get; protected set;
		}

		public string sound
		{
			get; protected set;
		}

		public string stcommon
		{
			get; protected set;
		}

		public string sprite
		{
			get; protected set;
		}

		public string pal1
		{
			get; protected set;
		}

		public string pal2
		{
			get; protected set;
		}

		public string pal3
		{
			get; protected set;
		}

		public string pal4
		{
			get; protected set;
		}

		public string pal5
		{
			get; protected set;
		}

		public string pal6
		{
			get; protected set;
		}

		public string pal7
		{
			get; protected set;
		}

		public string pal8
		{
			get; protected set;
		}

		public string pal9
		{
			get; protected set;
		}

		public string pal10
		{
			get; protected set;
		}

		public string pal11
		{
			get; protected set;
		}

		public string pal12
		{
			get; protected set;
		}

        public string ai
        {
            get; protected set;
        }
	}

	public class PlayerInfo: IConfigPropertys
	{
		public string ConfigName
		{
			get
			{
				return string.Empty;
			}
		}

		public string name {get; protected set;}
		public string displayname {get; protected set;}

	}

    public class PalletKeyMap: IConfigPropertys
    {
        public string ConfigName
        {
            get
            {
                return string.Empty;
            }
        }

        public int x
        {
            get;
            protected set;
        }

        public int y
        {
            get;
            protected set;
        }

        public int z
        {
            get;
            protected set;
        }

        public int a
        {
            get;
            protected set;
        }

        public int b
        {
            get;
            protected set;
        }

        public int c
        {
            get;
            protected set;
        }
    }

	public class PlayerConfig
	{
		public void LoadPlayer(string playerName)
		{
			if (string.IsNullOrEmpty(playerName))
				return;
			string fileName = string.Format("{0}@{1}/{2}.def.txt", AppConfig.GetInstance().PlayerRootDir, playerName, playerName);
			fileName = fileName.ToLower();
			string str = AppConfig.GetInstance().Loader.LoadText(fileName);
			LoadString(str);
		}

		public void LoadString(string str)
		{
			if (string.IsNullOrEmpty(str))
				return;
			ConfigReader reader = new ConfigReader();
			reader.LoadString(str);
			var section = reader.GetSection("Files");
			if (section == null)
				return;
			mPlayerFiles = new PlayerFiles();
			if (!section.GetPropertysValues(mPlayerFiles))
				mPlayerFiles = null;

			section = reader.GetSection("Info");
			mPlayerInfo = new PlayerInfo();
			if (section != null) {
				if (!section.GetPropertysValues (mPlayerInfo))
					mPlayerInfo = null;
			}
            section = reader.GetSection("Palette Keymap");
            mKeyMap = new PalletKeyMap();
            if (section != null)
            {
                if (!section.GetPropertysValues(mKeyMap))
                    mKeyMap = null;
            }
		}

		public bool HasFilesConfig
		{
			get
			{
				return (mPlayerFiles != null) && (mPlayerInfo != null);
			}
		}

		public bool IsVaild
		{
			get
			{
				return HasFilesConfig;
			}
		}

		public PlayerFiles Files
		{
			get
			{
				return  mPlayerFiles;
			}
		}

		public PlayerInfo Info
		{
			get
			{
				return mPlayerInfo;
			}
		}

        public PalletKeyMap KeyMap
        {
            get
            {
                return mKeyMap;
            }
        }

		private PlayerFiles mPlayerFiles = null;
		private PlayerInfo mPlayerInfo = null;
        private PalletKeyMap mKeyMap = null;
	}
}
