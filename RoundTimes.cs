using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace ESPmanager
{
	/// <summary>
	/// Summary description for RoundTimes.
	/// </summary>
	public class RoundTimes : System.Windows.Forms.Form
	{
		private DatabaseAccessControl dac = new DatabaseAccessControl();
		private Database espDB;
		private DataSet ds;
		private int _TournamentID = 0;
		private int _RoundTimeID = 0;
		private DataView dvTeeTimes;
		private sbyte _ReturnStatus = -1; // 1 - Cancel, 2-Saved
		private bool _AddMode = false;
		private bool load = false;
		Guid RoundTimeGUID;
		//
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblDate;
		private System.Windows.Forms.TextBox txtTeeTime;
		private System.Windows.Forms.Label lblTeeTime;
		private System.Windows.Forms.Label lblStartHole;
		private System.Windows.Forms.Label lblSet;
		private System.Windows.Forms.TextBox txtHHUnit;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtTeeDate;
		private System.Windows.Forms.TextBox txtHHSet;
		private System.Windows.Forms.TextBox txtHoleStart;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cboCourse;
		private System.Windows.Forms.TextBox txtNumberOfPlayers;
		private System.Windows.Forms.Label lblNumberOfPlayers;
		private System.Windows.Forms.TextBox txtRoundNumber;
		private System.Windows.Forms.Label lblRoundNumber;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public RoundTimes( ref Database espdb )
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
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.txtRoundNumber = new System.Windows.Forms.TextBox();
			this.lblRoundNumber = new System.Windows.Forms.Label();
			this.txtNumberOfPlayers = new System.Windows.Forms.TextBox();
			this.lblNumberOfPlayers = new System.Windows.Forms.Label();
			this.cboCourse = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtHHUnit = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtHHSet = new System.Windows.Forms.TextBox();
			this.lblSet = new System.Windows.Forms.Label();
			this.txtHoleStart = new System.Windows.Forms.TextBox();
			this.lblStartHole = new System.Windows.Forms.Label();
			this.txtTeeTime = new System.Windows.Forms.TextBox();
			this.lblTeeTime = new System.Windows.Forms.Label();
			this.txtTeeDate = new System.Windows.Forms.TextBox();
			this.lblDate = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnSave
			// 
			this.btnSave.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnSave.Location = new System.Drawing.Point(456, 256);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(128, 64);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "&Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(16, 256);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(128, 64);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.txtRoundNumber,
																				 this.lblRoundNumber,
																				 this.txtNumberOfPlayers,
																				 this.lblNumberOfPlayers,
																				 this.cboCourse,
																				 this.label2,
																				 this.txtHHUnit,
																				 this.label1,
																				 this.txtHHSet,
																				 this.lblSet,
																				 this.txtHoleStart,
																				 this.lblStartHole,
																				 this.txtTeeTime,
																				 this.lblTeeTime,
																				 this.txtTeeDate,
																				 this.lblDate});
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(572, 232);
			this.panel1.TabIndex = 41;
			// 
			// txtRoundNumber
			// 
			this.txtRoundNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtRoundNumber.Location = new System.Drawing.Point(148, 200);
			this.txtRoundNumber.Name = "txtRoundNumber";
			this.txtRoundNumber.Size = new System.Drawing.Size(56, 26);
			this.txtRoundNumber.TabIndex = 15;
			this.txtRoundNumber.Text = "";
			// 
			// lblRoundNumber
			// 
			this.lblRoundNumber.Location = new System.Drawing.Point(20, 200);
			this.lblRoundNumber.Name = "lblRoundNumber";
			this.lblRoundNumber.Size = new System.Drawing.Size(124, 23);
			this.lblRoundNumber.TabIndex = 16;
			this.lblRoundNumber.Text = "Round Number";
			this.lblRoundNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtNumberOfPlayers
			// 
			this.txtNumberOfPlayers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtNumberOfPlayers.Location = new System.Drawing.Point(148, 168);
			this.txtNumberOfPlayers.Name = "txtNumberOfPlayers";
			this.txtNumberOfPlayers.Size = new System.Drawing.Size(56, 26);
			this.txtNumberOfPlayers.TabIndex = 13;
			this.txtNumberOfPlayers.Text = "";
			// 
			// lblNumberOfPlayers
			// 
			this.lblNumberOfPlayers.Location = new System.Drawing.Point(20, 168);
			this.lblNumberOfPlayers.Name = "lblNumberOfPlayers";
			this.lblNumberOfPlayers.Size = new System.Drawing.Size(124, 23);
			this.lblNumberOfPlayers.TabIndex = 14;
			this.lblNumberOfPlayers.Text = "No. of Players";
			this.lblNumberOfPlayers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboCourse
			// 
			this.cboCourse.Location = new System.Drawing.Point(148, 4);
			this.cboCourse.Name = "cboCourse";
			this.cboCourse.Size = new System.Drawing.Size(400, 28);
			this.cboCourse.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(20, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(124, 23);
			this.label2.TabIndex = 12;
			this.label2.Text = "Course:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtHHUnit
			// 
			this.txtHHUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtHHUnit.Location = new System.Drawing.Point(364, 136);
			this.txtHHUnit.Name = "txtHHUnit";
			this.txtHHUnit.ReadOnly = true;
			this.txtHHUnit.Size = new System.Drawing.Size(160, 26);
			this.txtHHUnit.TabIndex = 11;
			this.txtHHUnit.TabStop = false;
			this.txtHHUnit.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(360, 112);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(164, 23);
			this.label1.TabIndex = 10;
			this.label1.Text = "HandHeld Unit:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtHHSet
			// 
			this.txtHHSet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtHHSet.Location = new System.Drawing.Point(148, 136);
			this.txtHHSet.Name = "txtHHSet";
			this.txtHHSet.Size = new System.Drawing.Size(56, 26);
			this.txtHHSet.TabIndex = 4;
			this.txtHHSet.Text = "";
			// 
			// lblSet
			// 
			this.lblSet.Location = new System.Drawing.Point(20, 136);
			this.lblSet.Name = "lblSet";
			this.lblSet.Size = new System.Drawing.Size(124, 23);
			this.lblSet.TabIndex = 6;
			this.lblSet.Text = "Set:";
			this.lblSet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtHoleStart
			// 
			this.txtHoleStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtHoleStart.Location = new System.Drawing.Point(148, 104);
			this.txtHoleStart.Name = "txtHoleStart";
			this.txtHoleStart.Size = new System.Drawing.Size(56, 26);
			this.txtHoleStart.TabIndex = 3;
			this.txtHoleStart.Text = "";
			// 
			// lblStartHole
			// 
			this.lblStartHole.Location = new System.Drawing.Point(20, 104);
			this.lblStartHole.Name = "lblStartHole";
			this.lblStartHole.Size = new System.Drawing.Size(124, 23);
			this.lblStartHole.TabIndex = 4;
			this.lblStartHole.Text = "Starting Hole:";
			this.lblStartHole.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtTeeTime
			// 
			this.txtTeeTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtTeeTime.Location = new System.Drawing.Point(148, 72);
			this.txtTeeTime.Name = "txtTeeTime";
			this.txtTeeTime.Size = new System.Drawing.Size(72, 26);
			this.txtTeeTime.TabIndex = 2;
			this.txtTeeTime.Text = "";
			// 
			// lblTeeTime
			// 
			this.lblTeeTime.Location = new System.Drawing.Point(20, 72);
			this.lblTeeTime.Name = "lblTeeTime";
			this.lblTeeTime.Size = new System.Drawing.Size(124, 23);
			this.lblTeeTime.TabIndex = 2;
			this.lblTeeTime.Text = "Tee Time:";
			this.lblTeeTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtTeeDate
			// 
			this.txtTeeDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtTeeDate.Location = new System.Drawing.Point(148, 40);
			this.txtTeeDate.Name = "txtTeeDate";
			this.txtTeeDate.Size = new System.Drawing.Size(160, 26);
			this.txtTeeDate.TabIndex = 1;
			this.txtTeeDate.Text = "";
			// 
			// lblDate
			// 
			this.lblDate.Location = new System.Drawing.Point(20, 40);
			this.lblDate.Name = "lblDate";
			this.lblDate.Size = new System.Drawing.Size(124, 23);
			this.lblDate.TabIndex = 0;
			this.lblDate.Text = "Date:";
			this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// RoundTimes
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.ClientSize = new System.Drawing.Size(598, 332);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panel1,
																		  this.btnSave,
																		  this.btnCancel});
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "RoundTimes";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "RoundTimes";
			this.Load += new System.EventHandler(this.RoundTimes_Load);
			this.Activated += new System.EventHandler(this.RoundTimes_Activated);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			_ReturnStatus = 1;
			this.Close();
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if (_AddMode)
				TransferEditFieldsToNewRecord();
			else
				TransferEditFieldsToRecord();
			espDB.SaveRoundTimeChanges();
			espDB.GetRoundTimes(this.TournamentID);
			//
			// Get ID of the RoundTime
			//
			if (_AddMode)
			{
				dvTeeTimes.RowFilter = "";
				for (int i=0;i<dvTeeTimes.Count;i++)
				{
					if ((Guid)dvTeeTimes[i]["RoundTimeGUID"] == RoundTimeGUID)
					{
						this.RoundTimeID = (int)dvTeeTimes[i]["RoundTimeID"];
						break;
					}
				}
			}

			_ReturnStatus = 2;
			this.Close();
		}

		private void RoundTimes_Load(object sender, System.EventArgs e)
		{
			load = false;
			espDB.GetCourseGUIDAndTeeNames();
			this.cboCourse.DataSource = ds.Tables["Courses"];
			this.cboCourse.DisplayMember = "Name";
			this.cboCourse.ValueMember = "GUID";
			//
			dvTeeTimes = new DataView( ds.Tables["RoundTeeTimes"] );
			dvTeeTimes.AllowNew = true;
			dvTeeTimes.RowFilter = "RoundTimeID="+_RoundTimeID.ToString();
			//
			if (_AddMode)
			{
				// New Record Being Added, clear all fields
				this.txtTeeDate.Text = "";
				this.txtTeeTime.Text = "";
				this.txtHoleStart.Text = "1";
				this.txtHHSet.Text = "0";
				this.txtNumberOfPlayers.Text = "4";
				this.txtHHUnit.Text = "";
				this.txtRoundNumber.Text = "1";

				// Check for Default Course
				if (dvTeeTimes.Count > 0)
				{
					if (dvTeeTimes[0]["CourseGUID"] != System.DBNull.Value)
					{
						this.cboCourse.SelectedValue = (Guid)dvTeeTimes[0]["CourseGUID"];
					}
				}
			}
			else
			{
				// Get the data for the specified record
				TransferRecordToEditFields();
			}
			load = true;
		}

		private void RoundTimes_Activated(object sender, System.EventArgs e)
		{
			txtTeeDate.Focus();
		}

		private void TransferRecordToEditFields()
		{
			this.cboCourse.SelectedValue = dvTeeTimes[0]["CourseGUID"];
			this.txtRoundNumber.Text = dvTeeTimes[0]["RoundNumber"].ToString();
			this.txtTeeDate.Text = DateTime.Parse(dvTeeTimes[0]["TeeDate"].ToString()).ToShortDateString();
			this.txtTeeTime.Text = dvTeeTimes[0]["TeeTime"].ToString();
			this.txtHoleStart.Text = dvTeeTimes[0]["HoleStart"].ToString();
			this.txtHHSet.Text = dvTeeTimes[0]["HHSet"].ToString();
			this.txtNumberOfPlayers.Text = dvTeeTimes[0]["NumberOfPlayers"].ToString();
			this.txtHHUnit.Text = dvTeeTimes[0]["HHUnit"].ToString();
		}

		private void TransferEditFieldsToRecord()
		{
			dvTeeTimes[0].BeginEdit();
			dvTeeTimes[0]["CourseGUID"] = (Guid)this.cboCourse.SelectedValue;
			dvTeeTimes[0]["RoundNumber"] = Byte.Parse(this.txtRoundNumber.Text);
			dvTeeTimes[0]["TeeDate"] = DateTime.Parse(this.txtTeeDate.Text);
			dvTeeTimes[0]["TeeTime"] = this.txtTeeTime.Text;
			dvTeeTimes[0]["HoleStart"] = Byte.Parse(this.txtHoleStart.Text);
			dvTeeTimes[0]["HHSet"] = Byte.Parse(this.txtHHSet.Text);
			dvTeeTimes[0]["NumberOfPlayers"] = Byte.Parse(this.txtNumberOfPlayers.Text);
			dvTeeTimes[0]["HHUnit"] = this.txtHHUnit.Text;
			dvTeeTimes[0].EndEdit();
		}

		private void TransferEditFieldsToNewRecord()
		{
			Guid guidT;
			Guid guidC;
			if (dvTeeTimes.Count == 0)
			{
				DataTable dt2 = ds.Tables["Tournaments"];
				DataRow [] dr2 = dt2.Select("TournamentID="+_TournamentID.ToString());
				guidT = (Guid)dr2[0]["TournamentGUID"];
				dr2 = null;
				dt2 = null;
			}
			else
			{
				guidT = (Guid)dvTeeTimes[0]["TournamentGUID"];
			}
			//
			DataRowView dr = dvTeeTimes.AddNew();
			//
			guidC = (Guid)cboCourse.SelectedValue;
			RoundTimeGUID = Guid.NewGuid();
			dr["RoundTimeGUID"] = RoundTimeGUID;
			dr["TournamentGUID"] = guidT;
			dr["CourseGUID"] = guidC;
			dr["TeeDate"] = DateTime.Parse(this.txtTeeDate.Text);
			dr["TeeTime"] = this.txtTeeTime.Text;
			dr["RoundNumber"] = Byte.Parse(this.txtRoundNumber.Text);
			dr["HoleStart"] = Byte.Parse(this.txtHoleStart.Text);
			dr["HHSet"] = Byte.Parse(this.txtHHSet.Text);
			dr["NumberOfPlayers"] = Byte.Parse(this.txtNumberOfPlayers.Text);
			dr["HHUnit"] = this.txtHHUnit.Text;
			dr.EndEdit();

			dr = null;
		}

		// PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP
		public sbyte ReturnStatus
		{
			get{ return _ReturnStatus; }
		}
		public int RoundTimeID
		{
			get{ return _RoundTimeID; }
			set{ _RoundTimeID = value; }
		}
		public int TournamentID
		{
			get{ return _TournamentID; }
			set{ _TournamentID = value; }
		}
		public bool AddMode
		{
			get{ return _AddMode; }
			set{ _AddMode = value; }
		}
		// PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP
	}
}
