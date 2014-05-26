using System;
using System.IO;
using System.Windows.Forms;
using System.Security;
using System.Security.Permissions;
using System.Collections;
using Microsoft.Win32;

namespace ESPmanager
{
	/// <summary>
	/// Summary description for UserData.
	/// </summary>
	[RegistryPermissionAttribute(SecurityAction.LinkDemand, Unrestricted=true)]
	public class UserData
	{
		private FileStream fsDB;
		private byte [] UsersDat;
		private SortedList slUsers = new SortedList();

		public UserData(DirectoryInfo di)
		{
			//
			// TODO: Add constructor logic here
			//
			FileInfo [] afi;
			int fileLength = 0;
			afi = di.GetFiles("Users.Dat");
			fsDB = new FileStream(afi[0].FullName,FileMode.Open,FileAccess.Read,FileShare.None);
			fileLength = (int)fsDB.Length;
			UsersDat = new Byte[fileLength];
			fsDB.Read(UsersDat,0,fileLength);
			fsDB.Close();
			fsDB = null;
			afi = null;

			ExtractUserNamesAndID();
		}
		//
		private void ExtractUserNamesAndID()
		{
			ushort usercount = 0;
			//
			usercount = (ushort)((UsersDat[1]<<8)+UsersDat[0]);
		}
		public uint GetUserID(string name)
		{
			byte [] buffer = new Byte[name.Length];
			int udStart=0, idStart=0;
			bool found;
			uint id = 0;
			// Convert Name to Byte Array
			for(int i=0;i<name.Length;i++)
			{
				buffer[i] = (byte)name[i];
			}
			// Locate Name in file
			for (int i=0;i<UsersDat.Length;i++)
			{
				if (UsersDat[i] == buffer[0])
				{
					// May be the start of the name
					udStart = i;
					if (UsersDat[udStart-1] == name.Length)
					{
						// Length is correct, now check all
						found = true;
						for (int j=1;j<name.Length;j++)
						{
							if (UsersDat[j+udStart] != buffer[j])
							{
								found = false;
								break;
							}
						}
						if (found)
						{
							// Name Match
							// Check start-1.  If it is a valid character, look for start of previous string.
							if (UsersDat[udStart-2] >= 32)
							{
								int prevCount = 0;
								for (int k=udStart-2;k>0;k--)
								{
									// check for start of prev string
									if (UsersDat[k] == prevCount)
									{
										// String Length byte located
										idStart = k-4;
										break;
									}
									prevCount++;
								}
							}
							else
								idStart = udStart - 5;
							//
							// Convert ID to uint
							id = (uint)((UsersDat[idStart+3]<<24)+(UsersDat[idStart+2]<<16)+(UsersDat[idStart+1]<<8)+(UsersDat[idStart]));
							break;
						}
					}
					// (n-1) byte is string length.  It is incorrect, so continue
				}
			}
			return id;
		} // GetUserID
		//
		public void AddRegistryEntry(uint UserID)
		{
			string keynm = "Install"+UserID.ToString();
			RegistryKey hkcu = Registry.CurrentUser;
			RegistryKey hkusrSoftware = hkcu.OpenSubKey("Software");
			RegistryKey hkUSRobotics = hkusrSoftware.OpenSubKey("U.S. Robotics");
			RegistryKey hkPilotDesktop = hkUSRobotics.OpenSubKey("Pilot Desktop");
			RegistryKey hkHotsyncManager = hkPilotDesktop.OpenSubKey("HotSync Manager",true);
			try
			{
				hkHotsyncManager.SetValue(keynm,1);
			}
			catch
			{
				MessageBox.Show("KEY: Set Value Error");			
			}
			hkHotsyncManager.Close();
			hkPilotDesktop.Close();
			hkUSRobotics.Close();
			hkusrSoftware.Close();
			hkcu.Close();
		}
		//
		public void DeleteRegistryEntry(uint UserID)
		{
			string keynm = "Install"+UserID.ToString();
			RegistryKey hkcu = Registry.CurrentUser;
			RegistryKey hkusrSoftware = hkcu.OpenSubKey("Software");
			RegistryKey hkUSRobotics = hkusrSoftware.OpenSubKey("U.S. Robotics");
			RegistryKey hkPilotDesktop = hkUSRobotics.OpenSubKey("Pilot Desktop");
			RegistryKey hkHotsyncManager = hkPilotDesktop.OpenSubKey("HotSync Manager",true);
			hkHotsyncManager.DeleteValue(keynm,false);
			hkHotsyncManager.Close();
			hkPilotDesktop.Close();
			hkUSRobotics.Close();
			hkusrSoftware.Close();
			hkcu.Close();
		}
		// ==========
	}
}
