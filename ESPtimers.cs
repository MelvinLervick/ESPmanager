using System;
using System.Timers;

namespace ESPmanager
{
	/// <summary>
	/// Summary description for ESPtimers.
	/// </summary>
	public class ESPtimers
	{
		System.Timers.Timer wait = new System.Timers.Timer();
		bool waitFlag = false;
		// ==============================
		public int Interval
		{
			set{ wait.Interval = value; }
		}
		public bool Enabled
		{
			set{ wait.Enabled = value; }
		}
		// ==============================
		public ESPtimers()
		{
			wait.Elapsed+=new ElapsedEventHandler(OnTimedEvent);
			wait.Interval = 50;
			wait.Enabled = false;
			//
			// TODO: Add constructor logic here
			//
		}
		public void Wait()
		{
			waitFlag = true;
			while(waitFlag);
		}
 
		// Specify what you want to happen when the Elapsed event is raised.
		private void OnTimedEvent(object source, ElapsedEventArgs e)
		{
			waitFlag = false;
			wait.Enabled = false;
		}
	}
}
