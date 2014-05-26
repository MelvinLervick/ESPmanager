using System;
using System.Configuration;
using System.IO;

namespace ESPmanager
{
	/// <summary>
	/// Summary description for DatabaseAccessControl.
	/// </summary>
	public class DatabaseAccessControl
	{
		public DatabaseAccessControl()
		{
			strControl = GetDataLocation();
			//
			// TODO: Add constructor logic here
			//
		}
		//================================
		private string strControl = "";
		private string DataIn = "ESPdatain.ESP";
		private string Manager = "ESPmanager.ESP";
		private string Leader = "ESPleader.ESP";
		public bool DataAccessNotAllowed()
		{
			short counter = 0;
			ESPtimers wait = new ESPtimers();
			wait.Interval = 250;
			while (true)
			{
				if (File.Exists(strControl+DataIn) | File.Exists(strControl+Leader))
				{
					wait.Enabled = true;
					wait.Wait();
				}
				else
				{
					break;
				}
				if (counter++ > 5) return true;
			}
			return false;
		}
		public bool CreateDataAccessFile()
		{
			FileStream fs;
			if (DataAccessNotAllowed()) return false;
			try
			{
				if (File.Exists(strControl+Manager) == false)
				{
					// Create the file if it does not exist
					fs = File.Create(strControl+Manager);
					fs.Close();
				}
			}
			catch
			{
				// Unable to create file
				return false;
			}
			fs = null;
			return true;
		}
		public void DeleteDataAccessFile()
		{
			try
			{
				if (File.Exists(strControl+Manager))File.Delete(strControl+Manager);
			}
			catch
			{
				// Error Deleting file.  This should only happen if the file
				// does not exist, or there was an error checking for its existance.
			}
		}
		private string GetDataLocation()
		{
			return ConfigurationSettings.AppSettings["CONTROL"];
		}
		//================================
	}
}
