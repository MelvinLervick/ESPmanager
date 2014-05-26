using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ESPmanager
{
	/// <summary>
	/// Summary description for TourLiteSend.
	/// </summary>
	public class TourLiteSend : System.Windows.Forms.Form
	{
		private Database espDB;
		private DataSet ds;
		private bool _TournamentFlag = false;
		private int _TournamentID = 0;
		private bool _PlayerFlag = false;
		private int _TeeTimeID = 0;
		private string _Destination = "ALL";
		private bool done = false;
		private System.Windows.Forms.Button btnDoneSending;
		private System.Windows.Forms.Timer timerStatusUpdate;
		private System.Windows.Forms.TextBox txtStatus;
		private System.Windows.Forms.Label lblInsertHH;
		private System.ComponentModel.IContainer components;

		public TourLiteSend( ref Database espdb )
		{
			//
			// Required for Windows Form Designer support
			//
			ds = espdb.GetDS();
			espDB = espdb;

			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.btnDoneSending = new System.Windows.Forms.Button();
			this.timerStatusUpdate = new System.Windows.Forms.Timer(this.components);
			this.txtStatus = new System.Windows.Forms.TextBox();
			this.lblInsertHH = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnDoneSending
			// 
			this.btnDoneSending.BackColor = System.Drawing.Color.Red;
			this.btnDoneSending.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDoneSending.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnDoneSending.Location = new System.Drawing.Point(199, 235);
			this.btnDoneSending.Name = "btnDoneSending";
			this.btnDoneSending.Size = new System.Drawing.Size(224, 88);
			this.btnDoneSending.TabIndex = 0;
			this.btnDoneSending.Text = "All Handheld Units were Updated.";
			this.btnDoneSending.Click += new System.EventHandler(this.btnDoneSending_Click);
			// 
			// timerStatusUpdate
			// 
			this.timerStatusUpdate.Interval = 500;
			this.timerStatusUpdate.Tick += new System.EventHandler(this.timerStatusUpdate_Tick);
			// 
			// txtStatus
			// 
			this.txtStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtStatus.Location = new System.Drawing.Point(27, 43);
			this.txtStatus.Name = "txtStatus";
			this.txtStatus.Size = new System.Drawing.Size(568, 29);
			this.txtStatus.TabIndex = 1;
			this.txtStatus.Text = "";
			this.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// lblInsertHH
			// 
			this.lblInsertHH.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.lblInsertHH.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblInsertHH.Location = new System.Drawing.Point(111, 99);
			this.lblInsertHH.Name = "lblInsertHH";
			this.lblInsertHH.Size = new System.Drawing.Size(400, 104);
			this.lblInsertHH.TabIndex = 2;
			this.lblInsertHH.Text = "Please Insert Handheld Device in the Cradle and Press the Synchronize Button";
			this.lblInsertHH.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblInsertHH.Visible = false;
			// 
			// TourLiteSend
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(622, 366);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lblInsertHH,
																		  this.txtStatus,
																		  this.btnDoneSending});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Name = "TourLiteSend";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Send the Selected Tournament to Handheld";
			this.Load += new System.EventHandler(this.TourLiteSend_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnDoneSending_Click(object sender, System.EventArgs e)
		{
			// UpdateRecord in PDADataOut to Terminate SEND.
			// Then wait for the SEND completion
			// Tell the Transmit Program to stop sending
			espDB.TerminatePDADataOut(TournamentID);

			// Close the form
			done = true;
		}

		private void timerStatusUpdate_Tick(object sender, System.EventArgs e)
		{
			// Disable the timer until done
			this.timerStatusUpdate.Enabled = false;

			// Check to see if SEND was terminated
			if (done)
			{
				if (espDB.PDADataOutTerminated(TournamentID))
				{
					this.Close();
					return;
				}
				txtStatus.Text = "Handheld Tournament Update is being Stopped.";
				lblInsertHH.Visible = false;
			}
			else
			{
				// update the display status
				switch (espDB.PDADataOutStatus(TournamentID))
				{
					case 1:
						txtStatus.Text = "Tournament Update Files are being Created.";
						lblInsertHH.Visible = false;
						break;
					case 2:
						txtStatus.Text = "Tournament Update Files were Created.";
						lblInsertHH.Visible = false;
						break;
					case 3:
						txtStatus.Text = "Tournament Update Files are Available.";
						lblInsertHH.Visible = true;
						break;
					case 4:
						txtStatus.Text = "Handheld Tournament Update was Terminated.";
						lblInsertHH.Visible = false;
						break;
					default:
						txtStatus.Text = "Undefined Return Status";
						lblInsertHH.Visible = false;
						break;
				}
			}
			// re-enable the timer if the pgm gets here
			timerStatusUpdate.Enabled = true;
		}

		private void TourLiteSend_Load(object sender, System.EventArgs e)
		{
			// Add Record to PDADataOut
			espDB.InsertPDADataOutRecord(TournamentFlag,TournamentID,PlayerFlag,TeeTimeID,Destination);
			// Enable the Status Timer
			timerStatusUpdate.Enabled = true;
		}

		// ============================
		// Property Definitions
		// ============================
		public int TournamentID
		{
			get{ return _TournamentID; }
			set{ _TournamentID = value; }
		}
		public int TeeTimeID
		{
			get{ return _TeeTimeID; }
			set{ _TeeTimeID = value; }
		}
		public bool TournamentFlag
		{
			get{ return _TournamentFlag; }
			set{ _TournamentFlag = value; }
		}
		public bool PlayerFlag
		{
			get{ return _PlayerFlag; }
			set{ _PlayerFlag = value; }
		}
		public string Destination
		{
			get{ return _Destination; }
			set{ _Destination = value; }
		}
		// ============================
		// ============================
	}
}
