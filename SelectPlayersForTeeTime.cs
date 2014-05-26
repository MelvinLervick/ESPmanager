using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace ESPmanager
{
	/// <summary>
	/// Summary description for SelectPlayersForTeeTime.
	/// </summary>
	public class SelectPlayersForTeeTime : System.Windows.Forms.Form
	{
		private Database espDB;
		private DataSet ds;
		private int _TournamentID = 0;
		private string _TournamentName = "";
		private bool DataChanged;
		//
		DataView dvPositions;
		DataView dvPlayers;
		DataView dvTeeNames;
		DataRowView _drv;
		//
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblTournament;
		private System.Windows.Forms.Label lblTournamentSelected;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblRound;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lblTeeTime;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button btnPlayers;
		private System.Windows.Forms.ComboBox cboTeeName;
		private System.Windows.Forms.Label lblTee;
		private System.Windows.Forms.Label lblDate;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DataGrid dgPlayers;
		private System.Windows.Forms.Button btnSelectPlayer;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtNoPlayers;
		private System.Windows.Forms.DataGrid dgRoundTimesPlayers;
		private System.Windows.Forms.TextBox txtInitials;
		private System.Windows.Forms.TextBox txtHandicap;
		private System.Windows.Forms.CheckBox cbPro;
		private System.Windows.Forms.TextBox txtLocate;
		private System.Windows.Forms.Label lblLocate;
		private System.Windows.Forms.Button btnLocate;
		private System.Windows.Forms.Button btnRemovePlayer;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SelectPlayersForTeeTime( ref Database espdb )
		{
			ds = espdb.GetDS();
			espDB = espdb;

			//
			// Required for Windows Form Designer support
			//
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblTournamentSelected = new System.Windows.Forms.Label();
			this.lblTournament = new System.Windows.Forms.Label();
			this.btnExit = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lblTeeTime = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.lblRound = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.lblDate = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.cbPro = new System.Windows.Forms.CheckBox();
			this.txtHandicap = new System.Windows.Forms.TextBox();
			this.txtInitials = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.cboTeeName = new System.Windows.Forms.ComboBox();
			this.lblTee = new System.Windows.Forms.Label();
			this.dgRoundTimesPlayers = new System.Windows.Forms.DataGrid();
			this.btnPlayers = new System.Windows.Forms.Button();
			this.dgPlayers = new System.Windows.Forms.DataGrid();
			this.btnSelectPlayer = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.txtNoPlayers = new System.Windows.Forms.TextBox();
			this.txtLocate = new System.Windows.Forms.TextBox();
			this.lblLocate = new System.Windows.Forms.Label();
			this.btnLocate = new System.Windows.Forms.Button();
			this.btnRemovePlayer = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgRoundTimesPlayers)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgPlayers)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.lblTournamentSelected,
																				 this.lblTournament});
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(996, 44);
			this.panel1.TabIndex = 32;
			// 
			// lblTournamentSelected
			// 
			this.lblTournamentSelected.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.lblTournamentSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTournamentSelected.Location = new System.Drawing.Point(240, 6);
			this.lblTournamentSelected.Name = "lblTournamentSelected";
			this.lblTournamentSelected.Size = new System.Drawing.Size(736, 32);
			this.lblTournamentSelected.TabIndex = 32;
			this.lblTournamentSelected.Text = "<None>";
			this.lblTournamentSelected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTournament
			// 
			this.lblTournament.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.lblTournament.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTournament.Location = new System.Drawing.Point(0, 6);
			this.lblTournament.Name = "lblTournament";
			this.lblTournament.Size = new System.Drawing.Size(228, 32);
			this.lblTournament.TabIndex = 31;
			this.lblTournament.Text = "Tournament Selected:";
			this.lblTournament.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnExit
			// 
			this.btnExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(128)), ((System.Byte)(255)));
			this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnExit.Location = new System.Drawing.Point(852, 616);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(128, 56);
			this.btnExit.TabIndex = 3;
			this.btnExit.Text = "E&xit";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.panel2.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.lblTeeTime,
																				 this.label6,
																				 this.lblRound,
																				 this.label4,
																				 this.lblDate,
																				 this.label2});
			this.panel2.Location = new System.Drawing.Point(0, 44);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(996, 44);
			this.panel2.TabIndex = 44;
			// 
			// lblTeeTime
			// 
			this.lblTeeTime.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.lblTeeTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTeeTime.Location = new System.Drawing.Point(668, 6);
			this.lblTeeTime.Name = "lblTeeTime";
			this.lblTeeTime.Size = new System.Drawing.Size(104, 32);
			this.lblTeeTime.TabIndex = 36;
			this.lblTeeTime.Text = "<None>";
			this.lblTeeTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(532, 6);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(124, 32);
			this.label6.TabIndex = 35;
			this.label6.Text = "WsTee Time:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblRound
			// 
			this.lblRound.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.lblRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblRound.Location = new System.Drawing.Point(412, 6);
			this.lblRound.Name = "lblRound";
			this.lblRound.Size = new System.Drawing.Size(92, 32);
			this.lblRound.TabIndex = 34;
			this.lblRound.Text = "<None>";
			this.lblRound.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(308, 6);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 32);
			this.label4.TabIndex = 33;
			this.label4.Text = "Round:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblDate
			// 
			this.lblDate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDate.Location = new System.Drawing.Point(68, 6);
			this.lblDate.Name = "lblDate";
			this.lblDate.Size = new System.Drawing.Size(216, 32);
			this.lblDate.TabIndex = 32;
			this.lblDate.Text = "<None>";
			this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(0, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 32);
			this.label2.TabIndex = 31;
			this.label2.Text = "Date:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.panel3.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.cbPro,
																				 this.txtHandicap,
																				 this.txtInitials,
																				 this.label5,
																				 this.label3,
																				 this.cboTeeName,
																				 this.lblTee,
																				 this.dgRoundTimesPlayers});
			this.panel3.Location = new System.Drawing.Point(450, 96);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(534, 320);
			this.panel3.TabIndex = 45;
			// 
			// cbPro
			// 
			this.cbPro.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.cbPro.Location = new System.Drawing.Point(404, 240);
			this.cbPro.Name = "cbPro";
			this.cbPro.Size = new System.Drawing.Size(76, 40);
			this.cbPro.TabIndex = 4;
			this.cbPro.Text = "PRO";
			this.cbPro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtHandicap
			// 
			this.txtHandicap.Location = new System.Drawing.Point(172, 264);
			this.txtHandicap.Name = "txtHandicap";
			this.txtHandicap.Size = new System.Drawing.Size(84, 26);
			this.txtHandicap.TabIndex = 2;
			this.txtHandicap.Text = "";
			// 
			// txtInitials
			// 
			this.txtInitials.Location = new System.Drawing.Point(80, 264);
			this.txtInitials.Name = "txtInitials";
			this.txtInitials.Size = new System.Drawing.Size(84, 26);
			this.txtInitials.TabIndex = 1;
			this.txtInitials.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(175, 240);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 23);
			this.label5.TabIndex = 48;
			this.label5.Text = "Handicap";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(83, 240);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 23);
			this.label3.TabIndex = 47;
			this.label3.Text = "Initials";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cboTeeName
			// 
			this.cboTeeName.Location = new System.Drawing.Point(263, 264);
			this.cboTeeName.Name = "cboTeeName";
			this.cboTeeName.Size = new System.Drawing.Size(132, 28);
			this.cboTeeName.TabIndex = 3;
			// 
			// lblTee
			// 
			this.lblTee.Location = new System.Drawing.Point(267, 240);
			this.lblTee.Name = "lblTee";
			this.lblTee.Size = new System.Drawing.Size(124, 23);
			this.lblTee.TabIndex = 44;
			this.lblTee.Text = "WsTee";
			this.lblTee.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dgRoundTimesPlayers
			// 
			this.dgRoundTimesPlayers.DataMember = "";
			this.dgRoundTimesPlayers.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgRoundTimesPlayers.Location = new System.Drawing.Point(8, 8);
			this.dgRoundTimesPlayers.Name = "dgRoundTimesPlayers";
			this.dgRoundTimesPlayers.Size = new System.Drawing.Size(520, 208);
			this.dgRoundTimesPlayers.TabIndex = 0;
			this.dgRoundTimesPlayers.CurrentCellChanged += new System.EventHandler(this.dgRoundTimesPlayers_CurrentCellChanged);
			// 
			// btnPlayers
			// 
			this.btnPlayers.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.btnPlayers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnPlayers.Location = new System.Drawing.Point(100, 100);
			this.btnPlayers.Name = "btnPlayers";
			this.btnPlayers.Size = new System.Drawing.Size(250, 40);
			this.btnPlayers.TabIndex = 0;
			this.btnPlayers.Text = "&New Player(s)";
			this.btnPlayers.Click += new System.EventHandler(this.btnPlayers_Click);
			// 
			// dgPlayers
			// 
			this.dgPlayers.DataMember = "";
			this.dgPlayers.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgPlayers.Location = new System.Drawing.Point(16, 180);
			this.dgPlayers.Name = "dgPlayers";
			this.dgPlayers.Size = new System.Drawing.Size(424, 492);
			this.dgPlayers.TabIndex = 47;
			this.dgPlayers.CurrentCellChanged += new System.EventHandler(this.dgPlayers_CurrentCellChanged);
			// 
			// btnSelectPlayer
			// 
			this.btnSelectPlayer.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.btnSelectPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSelectPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnSelectPlayer.Location = new System.Drawing.Point(448, 476);
			this.btnSelectPlayer.Name = "btnSelectPlayer";
			this.btnSelectPlayer.Size = new System.Drawing.Size(536, 40);
			this.btnSelectPlayer.TabIndex = 1;
			this.btnSelectPlayer.Text = "&Select Player";
			this.btnSelectPlayer.Click += new System.EventHandler(this.btnSelectPlayer_Click);
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label8.Location = new System.Drawing.Point(452, 434);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(156, 23);
			this.label8.TabIndex = 49;
			this.label8.Text = "Number of Players:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label8.Click += new System.EventHandler(this.label8_Click);
			// 
			// txtNoPlayers
			// 
			this.txtNoPlayers.Location = new System.Drawing.Point(612, 432);
			this.txtNoPlayers.Name = "txtNoPlayers";
			this.txtNoPlayers.Size = new System.Drawing.Size(76, 26);
			this.txtNoPlayers.TabIndex = 2;
			this.txtNoPlayers.Text = "";
			this.txtNoPlayers.Leave += new System.EventHandler(this.txtNoPlayers_Leave);
			// 
			// txtLocate
			// 
			this.txtLocate.Location = new System.Drawing.Point(152, 146);
			this.txtLocate.Name = "txtLocate";
			this.txtLocate.Size = new System.Drawing.Size(172, 26);
			this.txtLocate.TabIndex = 50;
			this.txtLocate.Text = "";
			// 
			// lblLocate
			// 
			this.lblLocate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblLocate.Location = new System.Drawing.Point(16, 148);
			this.lblLocate.Name = "lblLocate";
			this.lblLocate.Size = new System.Drawing.Size(140, 23);
			this.lblLocate.TabIndex = 51;
			this.lblLocate.Text = "Enter Lastname";
			this.lblLocate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblLocate.Click += new System.EventHandler(this.lblLocate_Click);
			// 
			// btnLocate
			// 
			this.btnLocate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.btnLocate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLocate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnLocate.Location = new System.Drawing.Point(336, 144);
			this.btnLocate.Name = "btnLocate";
			this.btnLocate.Size = new System.Drawing.Size(104, 32);
			this.btnLocate.TabIndex = 52;
			this.btnLocate.Text = "&Locate";
			this.btnLocate.Click += new System.EventHandler(this.btnLocate_Click);
			// 
			// btnRemovePlayer
			// 
			this.btnRemovePlayer.BackColor = System.Drawing.SystemColors.Control;
			this.btnRemovePlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRemovePlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnRemovePlayer.Location = new System.Drawing.Point(448, 528);
			this.btnRemovePlayer.Name = "btnRemovePlayer";
			this.btnRemovePlayer.Size = new System.Drawing.Size(536, 40);
			this.btnRemovePlayer.TabIndex = 53;
			this.btnRemovePlayer.Text = "&Remove Player";
			this.btnRemovePlayer.Click += new System.EventHandler(this.btnRemovePlayer_Click);
			// 
			// SelectPlayersForTeeTime
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.ClientSize = new System.Drawing.Size(994, 688);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnRemovePlayer,
																		  this.btnLocate,
																		  this.txtLocate,
																		  this.lblLocate,
																		  this.txtNoPlayers,
																		  this.label8,
																		  this.btnSelectPlayer,
																		  this.dgPlayers,
																		  this.btnPlayers,
																		  this.panel3,
																		  this.panel2,
																		  this.btnExit,
																		  this.panel1});
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "SelectPlayersForTeeTime";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SelectPlayersForTeeTime";
			this.Load += new System.EventHandler(this.SelectPlayersForTeeTime_Load);
			this.Activated += new System.EventHandler(this.SelectPlayersForTeeTime_Activated);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgRoundTimesPlayers)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgPlayers)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			if (dgRoundTimesPlayers.CurrentRowIndex >= 0)
				dvPositions[dgRoundTimesPlayers.CurrentRowIndex].EndEdit();
			espDB.SaveRoundTimesPlayersChanges();
			this.Close();
		}

		private void SelectPlayersForTeeTime_Activated(object sender, System.EventArgs e)
		{
			// Set focus to Locate
			this.txtLocate.Focus();
		}

		private void SelectPlayersForTeeTime_Load(object sender, System.EventArgs e)
		{
			this.lblTournamentSelected.Text = this._TournamentName;
			espDB.GetCourseGUIDAndTeeNames();
			// Initialize TEE List
			// TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT
			dvTeeNames = new DataView(ds.Tables["TeeNames"]);
			Guid g;
			if (DRV != null)
			{
				if (DRV.Row != null)
				{
					g = (Guid)DRV.Row["CourseGUID"];
					this.dvTeeNames.RowFilter = "GUID='"+g.ToString("D")+"'";
				}
			}
			for (int i=0;i<dvTeeNames.Count;i++)
			{
				this.cboTeeName.Items.Add(dvTeeNames[i]["TeeName"]);
			}
			// TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT

			lblDate.Text = DateTime.Parse(_drv.Row["TeeDate"].ToString()).ToShortDateString();
			lblRound.Text = _drv.Row["RoundNumber"].ToString();
			lblTeeTime.Text = _drv.Row["TeeTime"].ToString();

			// Configure players list grid
			dvPlayers = new DataView( ds.Tables["PlayerMaster"] );
			dvPlayers.AllowNew = false;
			dgPlayers.DataSource = dvPlayers;
			ConfigurePlayersGrid();

			espDB.GetRoundTimesPlayers();
			dvPositions = new DataView( ds.Tables["RoundTimesPlayers"] );
			dvPositions.AllowNew = false;
			dgRoundTimesPlayers.DataSource = dvPositions;
			ConfigureRoundTimesPlayersGrid();
			g = (Guid)DRV.Row["RoundTimeGUID"];
			dvPositions.RowFilter = "RoundTimeGUID = '"+g.ToString("D")+"'";
			//
			// Field Data Bindings
			this.txtInitials.DataBindings.Add("Text",dvPositions,"Initials");
			this.txtHandicap.DataBindings.Add("Text",dvPositions,"Handicap");
			//
			this.cboTeeName.DataBindings.Add("Text",dvPositions,"TeeName");
			//this.cboTeeName.
			//
			this.cbPro.DataBindings.Add("Checked",dvPositions,"Professional");
			//
			// Initialze Record Change/Count Field for Number of Players for round
			this.txtNoPlayers.Text = dvPositions.Count.ToString();
		}
		//
		private void ConfigurePlayersGrid()
		{
			DataGridTableStyle ts = new DataGridTableStyle();
			ts.MappingName = "PlayerMaster";
			// Set other properties.
			ts.RowHeaderWidth = 15;

			// Add first column style.
			DataGridTextBoxColumn TextCol1 = new DataGridTextBoxColumn();
			TextCol1.MappingName = "LastName";
			TextCol1.HeaderText = "Last Name";
			TextCol1.Width = 105;
			TextCol1.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol1);

			// Add second column style.
			DataGridTextBoxColumn TextCol2 = new DataGridTextBoxColumn();
			TextCol2.MappingName = "FirstName";
			TextCol2.HeaderText = "First Name";
			TextCol2.Width = 105;
			TextCol2.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol2);

			// Add 6th column style.
			DataGridTextBoxColumn TextCol6 = new DataGridTextBoxColumn();
			TextCol6.MappingName = "GHIN";
			TextCol6.HeaderText = "GHIN";
			TextCol6.Width = 100;
			TextCol6.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol6);

			// Add 7th column style.
			DataGridTextBoxColumn TextCol7 = new DataGridTextBoxColumn();
			TextCol7.MappingName = "ClubNumber";
			TextCol7.HeaderText = "Club #";
			TextCol7.Width = 70;
			TextCol7.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol7);

			dgPlayers.TableStyles.Add(ts);

			DataChanged = false;
		}
		//
		private void ConfigureRoundTimesPlayersGrid()
		{
			DataGridTableStyle ts = new DataGridTableStyle();
			ts.MappingName = "RoundTimesPlayers";
			// Set other properties.
			ts.RowHeaderWidth = 25;

			// Add column style.
			DataGridTextBoxColumn TextCol0 = new DataGridTextBoxColumn();
			TextCol0.MappingName = "HHPosition";
			TextCol0.HeaderText = "Position";
			TextCol0.Width = 100;
			TextCol0.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol0);

			// Add first column style.
			DataGridTextBoxColumn TextCol1 = new DataGridTextBoxColumn();
			TextCol1.MappingName = "Name";
			TextCol1.HeaderText = "Name";
			TextCol1.Width = 250;
			TextCol1.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol1);

			// Add second column style.
			DataGridTextBoxColumn TextCol2 = new DataGridTextBoxColumn();
			TextCol2.MappingName = "DisplayGender";
			TextCol2.HeaderText = "Gender";
			TextCol2.Width = 100;
			TextCol2.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol2);

			dgRoundTimesPlayers.TableStyles.Add(ts);
		}

		private void txtNoPlayers_Leave(object sender, System.EventArgs e)
		{
			byte currentPlayerCount = (byte)dvPositions.Count;
			// If the number of players doesn't equal the number of player positions
			// currently defined for this tee time, verify that the user wants to add or
			// remove the total number of players assigned to this tee time.  In any
			// event, the maximum number of players is 5 (MAX_PLAYERS).
			if (Byte.Parse(this.txtNoPlayers.Text) == currentPlayerCount)
			{
				return;
			}
			if (Byte.Parse(this.txtNoPlayers.Text) > 5)
			{
				MessageBox.Show( "The MAXIMUM number of players allowed is 5.");
				return;
			}
			if (Byte.Parse(this.txtNoPlayers.Text) < currentPlayerCount)
			{
				// Verify that the WsTee Time is to be Deleted
				// Verify that the current player is to be deleted
				TouchMessageBox tmb = new TouchMessageBox();
				tmb.Header = "Remove Players from this WsTee Time";
				tmb.Message = "Select DELETE to confirm that you want to remove player positions from this TEE TIME.  Select CANCEL to cancel the removal of positions from this TEE TIME.";
				tmb.Cancel = "&Cancel";
				tmb.Confirm = "&Delete";
				tmb.ShowDialog();
				if (tmb.Return)
				{
					while (dvPositions.Count > Byte.Parse(this.txtNoPlayers.Text))
					{
						dvPositions[dvPositions.Count-1].Delete();
					}
					espDB.SaveRoundTimesPlayersChanges();
					espDB.GetRoundTimesPlayers();
					if (dvPositions.Count > 0)
					{
						dgRoundTimesPlayers.CurrentRowIndex = dvPositions.Count-1;
						dgRoundTimesPlayers.Select(dgRoundTimesPlayers.CurrentRowIndex);
					}
				}
				else
					this.txtNoPlayers.Text = dvPositions.Count.ToString();
				return;
			}
			if (Byte.Parse(this.txtNoPlayers.Text) > currentPlayerCount)
			{
				dvPositions.AllowNew = true;
				while (dvPositions.Count < Byte.Parse(this.txtNoPlayers.Text))
				{
					DataRowView drv = dvPositions.AddNew();
					drv["RoundTimeGUID"] = _drv["RoundTimeGUID"];
					drv["HHPosition"] = dvPositions.Count;
					drv.EndEdit();
				}
				dvPositions.AllowNew = false;
				espDB.SaveRoundTimesPlayersChanges();
				espDB.GetRoundTimesPlayers();
				dgRoundTimesPlayers.CurrentRowIndex = dvPositions.Count-1;
				dgRoundTimesPlayers.Select(dgRoundTimesPlayers.CurrentRowIndex);
				return;
			}
		}

		private void label8_Click(object sender, System.EventArgs e)
		{
			txtNoPlayers.Focus();
		}

		private void dgPlayers_CurrentCellChanged(object sender, System.EventArgs e)
		{
			dgPlayers.Select(dgPlayers.CurrentRowIndex);
		}

		private void dgRoundTimesPlayers_CurrentCellChanged(object sender, System.EventArgs e)
		{
			dvPositions[dgRoundTimesPlayers.CurrentRowIndex].EndEdit();
			dgRoundTimesPlayers.Select(dgRoundTimesPlayers.CurrentRowIndex);
		}

		private void btnSelectPlayer_Click(object sender, System.EventArgs e)
		{
			if (dgRoundTimesPlayers.CurrentRowIndex < 0)
			{
				MessageBox.Show("The Number of Players needs to be set before you can assign Players.");
				return;
			}
			if (dvPositions[dgRoundTimesPlayers.CurrentRowIndex]["PlayerMasterGuid"] != System.DBNull.Value)
			{
				// Replace or Update Player in the Selected Position and check to make sure that the player
				// is not already assigned to this tee time.
				MessageBox.Show("Already Set :: "+dgRoundTimesPlayers.CurrentRowIndex.ToString());
			}
			else
			{
				dvPositions[dgRoundTimesPlayers.CurrentRowIndex].BeginEdit();
				dvPositions[dgRoundTimesPlayers.CurrentRowIndex]["PlayerMasterGuid"] = dvPlayers[dgPlayers.CurrentRowIndex]["PlayerMasterGUID"];
				dvPositions[dgRoundTimesPlayers.CurrentRowIndex]["Initials"] = dvPlayers[dgPlayers.CurrentRowIndex]["Initials"];
				dvPositions[dgRoundTimesPlayers.CurrentRowIndex]["Handicap"] = dvPlayers[dgPlayers.CurrentRowIndex]["IndexHandicap"];
				dvPositions[dgRoundTimesPlayers.CurrentRowIndex]["TeeName"] = dvPositions[0]["TeeName"];
				dvPositions[dgRoundTimesPlayers.CurrentRowIndex]["Name"] = dvPlayers[dgPlayers.CurrentRowIndex]["LastName"].ToString() + ", " + 
									dvPlayers[dgPlayers.CurrentRowIndex]["FirstName"].ToString();
				if ((byte)dvPlayers[dgPlayers.CurrentRowIndex]["Gender"] == 0)
					dvPositions[dgRoundTimesPlayers.CurrentRowIndex]["DisplayGender"] = "Male";
				else
					dvPositions[dgRoundTimesPlayers.CurrentRowIndex]["DisplayGender"] = "Female";
				dvPositions[dgRoundTimesPlayers.CurrentRowIndex].EndEdit();
			}
		}

		private void btnRemovePlayer_Click(object sender, System.EventArgs e)
		{
			if (dgRoundTimesPlayers.CurrentRowIndex >= 0)
			{
				int currentPosition = dgRoundTimesPlayers.CurrentRowIndex;
				//
				dvPositions[currentPosition].BeginEdit();
				dvPositions[currentPosition]["PlayerMasterGuid"] = System.DBNull.Value;
				dvPositions[currentPosition]["Name"] = "";
				dvPositions[currentPosition]["DisplayGender"] = "";
				dvPositions[currentPosition]["Initials"] = "";
				dvPositions[currentPosition]["Handicap"] = 0.0;
				dvPositions[currentPosition]["TeeName"] = "";
				dvPositions[currentPosition]["Professional"] = false;
				dvPositions[currentPosition].EndEdit();
				espDB.SaveRoundTimesPlayersChanges();
			}
		}

		private void btnLocate_Click(object sender, System.EventArgs e)
		{
			for (int i=0;i<dvPlayers.Count;i++)
			{
				if (dvPlayers[i]["Lastname"].ToString().ToLower().StartsWith(this.txtLocate.Text.ToLower()))
				{
					// Set focus
					dgPlayers.UnSelect(dgPlayers.CurrentRowIndex);
					dgPlayers.CurrentRowIndex = i;
					dgPlayers.Select(dgPlayers.CurrentRowIndex);
				}
			}
		}

		private void lblLocate_Click(object sender, System.EventArgs e)
		{
			this.txtLocate.Focus();
		}

		private void btnPlayers_Click(object sender, System.EventArgs e)
		{
			Guid PlayerGUID;
			// Current Record in DataView is used to locate PlayerID
			PlayerMaster players = new PlayerMaster(ref espDB);
			players.PlayerGUID = (Guid)dvPlayers[dgPlayers.CurrentRowIndex]["PlayerMasterGUID"];
			//
			players.ShowDialog();
			//
			PlayerGUID = (Guid)players.PlayerGUID;
			//
			players.Dispose();
			// Refresh Dataset from Database
			espDB.GetPlayerMaster();
			// Set Default Record
			for (int i=0;i<dvPlayers.Count;i++)
			{
				if ((Guid)dvPlayers[i]["PlayerMasterGUID"] == PlayerGUID)
				{
					// Set focus
					dgPlayers.UnSelect(dgPlayers.CurrentRowIndex);
					dgPlayers.CurrentRowIndex = i;
					dgPlayers.Select(dgPlayers.CurrentRowIndex);
				}
			}
		}
		// ============================
		// Property Definitions
		// ============================
		public int TournamentID
		{
			get{ return _TournamentID; }
			set{ _TournamentID = value; }
		}
		public string TournamentName
		{
			get{ return _TournamentName; }
			set{ _TournamentName = value; }
		}
		public DataRowView DRV
		{
			get{ return _drv; }
			set{ _drv = value; }
		}
	}
}
