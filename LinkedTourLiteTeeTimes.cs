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
	/// Summary description for TourLiteTeeTimes.
	/// </summary>
	public class TourLiteTeeTimes : System.Windows.Forms.Form
	{
		private DatabaseAccessControl dac = new DatabaseAccessControl();
		private Database espDB;
		private DataSet ds;
		private byte Order  = 2; // 1 - HH, 2-TEETIME, 3-PLAYER
		private int _TournamentID = 0;
		private string _TournamentName = "";
		//
		DataView dvHH;
		DataView dvTeeTimes;
		//DataView dvNames;
		//DataView dvPlayers;
		DataRelation ttPlayers;
		//
		private HandHeld hh = new HandHeld();
		//
		private System.Windows.Forms.Label lblTournamentSelected;
		private System.Windows.Forms.Label lblTournament;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.Button btnPlayers;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnModify;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.DataGrid dgTeeTimes;
		private System.Windows.Forms.DataGrid dgNames;
		private System.Windows.Forms.GroupBox gbHH;
		private System.Windows.Forms.RadioButton rbHHUnassigned;
		private System.Windows.Forms.RadioButton rbHHAll;
		private System.Windows.Forms.RadioButton rbTeeTimesUnassigned;
		private System.Windows.Forms.RadioButton rbTeeTimesAll;
		private System.Windows.Forms.DataGrid dgHH;
		private System.Windows.Forms.Button btnHHselect;
		private System.Windows.Forms.Button btnTeeTimeSelect;
		private System.Windows.Forms.Button btnSetUnit;
		private System.Windows.Forms.Button btnSetPlayer;
		private System.Windows.Forms.GroupBox gbTeeTimes;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.CheckBox cbSendGames;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TourLiteTeeTimes( ref Database espdb )
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
			this.lblTournamentSelected = new System.Windows.Forms.Label();
			this.lblTournament = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.dgTeeTimes = new System.Windows.Forms.DataGrid();
			this.dgNames = new System.Windows.Forms.DataGrid();
			this.btnPlayers = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnModify = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.gbHH = new System.Windows.Forms.GroupBox();
			this.rbHHUnassigned = new System.Windows.Forms.RadioButton();
			this.rbHHAll = new System.Windows.Forms.RadioButton();
			this.gbTeeTimes = new System.Windows.Forms.GroupBox();
			this.rbTeeTimesUnassigned = new System.Windows.Forms.RadioButton();
			this.rbTeeTimesAll = new System.Windows.Forms.RadioButton();
			this.dgHH = new System.Windows.Forms.DataGrid();
			this.btnHHselect = new System.Windows.Forms.Button();
			this.btnTeeTimeSelect = new System.Windows.Forms.Button();
			this.btnSetUnit = new System.Windows.Forms.Button();
			this.btnSetPlayer = new System.Windows.Forms.Button();
			this.btnSend = new System.Windows.Forms.Button();
			this.cbSendGames = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.dgTeeTimes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgNames)).BeginInit();
			this.gbHH.SuspendLayout();
			this.gbTeeTimes.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgHH)).BeginInit();
			this.SuspendLayout();
			// 
			// lblTournamentSelected
			// 
			this.lblTournamentSelected.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.lblTournamentSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTournamentSelected.Location = new System.Drawing.Point(232, 8);
			this.lblTournamentSelected.Name = "lblTournamentSelected";
			this.lblTournamentSelected.Size = new System.Drawing.Size(748, 32);
			this.lblTournamentSelected.TabIndex = 28;
			this.lblTournamentSelected.Text = "<None>";
			this.lblTournamentSelected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTournament
			// 
			this.lblTournament.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.lblTournament.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTournament.Location = new System.Drawing.Point(4, 8);
			this.lblTournament.Name = "lblTournament";
			this.lblTournament.Size = new System.Drawing.Size(228, 32);
			this.lblTournament.TabIndex = 27;
			this.lblTournament.Text = "Tournament Selected:";
			this.lblTournament.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(996, 44);
			this.panel1.TabIndex = 29;
			// 
			// btnRefresh
			// 
			this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(224)), ((System.Byte)(192)));
			this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnRefresh.Location = new System.Drawing.Point(8, 636);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(152, 40);
			this.btnRefresh.TabIndex = 32;
			this.btnRefresh.Text = "Refresh";
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// dgTeeTimes
			// 
			this.dgTeeTimes.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.dgTeeTimes.BackgroundColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.dgTeeTimes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dgTeeTimes.CaptionText = "Tee Times";
			this.dgTeeTimes.DataMember = "";
			this.dgTeeTimes.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgTeeTimes.Location = new System.Drawing.Point(168, 88);
			this.dgTeeTimes.Name = "dgTeeTimes";
			this.dgTeeTimes.ReadOnly = true;
			this.dgTeeTimes.Size = new System.Drawing.Size(680, 348);
			this.dgTeeTimes.TabIndex = 33;
			this.dgTeeTimes.CurrentCellChanged += new System.EventHandler(this.dgTeeTimes_CurrentCellChanged);
			this.dgTeeTimes.Leave += new System.EventHandler(this.dgTeeTimes_Leave);
			// 
			// dgNames
			// 
			this.dgNames.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.dgNames.BackgroundColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.dgNames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dgNames.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.dgNames.CaptionText = "Player Names";
			this.dgNames.DataMember = "";
			this.dgNames.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgNames.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgNames.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgNames.Location = new System.Drawing.Point(168, 444);
			this.dgNames.Name = "dgNames";
			this.dgNames.Size = new System.Drawing.Size(680, 232);
			this.dgNames.TabIndex = 34;
			this.dgNames.TextChanged += new System.EventHandler(this.dgNames_TextChanged);
			this.dgNames.CurrentCellChanged += new System.EventHandler(this.dgNames_CurrentCellChanged);
			this.dgNames.Leave += new System.EventHandler(this.dgNames_Leave);
			// 
			// btnPlayers
			// 
			this.btnPlayers.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.btnPlayers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnPlayers.Location = new System.Drawing.Point(856, 572);
			this.btnPlayers.Name = "btnPlayers";
			this.btnPlayers.Size = new System.Drawing.Size(128, 40);
			this.btnPlayers.TabIndex = 36;
			this.btnPlayers.Text = "Players";
			this.btnPlayers.Click += new System.EventHandler(this.btnPlayers_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnAdd.Location = new System.Drawing.Point(856, 216);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(128, 40);
			this.btnAdd.TabIndex = 37;
			this.btnAdd.Text = "Add";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnModify
			// 
			this.btnModify.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnModify.Location = new System.Drawing.Point(856, 264);
			this.btnModify.Name = "btnModify";
			this.btnModify.Size = new System.Drawing.Size(128, 40);
			this.btnModify.TabIndex = 38;
			this.btnModify.Text = "Modify";
			this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnDelete.Location = new System.Drawing.Point(856, 312);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(128, 40);
			this.btnDelete.TabIndex = 39;
			this.btnDelete.Text = "Delete";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnExit
			// 
			this.btnExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(128)), ((System.Byte)(255)));
			this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnExit.Location = new System.Drawing.Point(856, 620);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(128, 56);
			this.btnExit.TabIndex = 42;
			this.btnExit.Text = "Exit";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// gbHH
			// 
			this.gbHH.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(224)), ((System.Byte)(192)));
			this.gbHH.Controls.AddRange(new System.Windows.Forms.Control[] {
																			   this.rbHHUnassigned,
																			   this.rbHHAll});
			this.gbHH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gbHH.Location = new System.Drawing.Point(8, 548);
			this.gbHH.Name = "gbHH";
			this.gbHH.Size = new System.Drawing.Size(152, 76);
			this.gbHH.TabIndex = 43;
			this.gbHH.TabStop = false;
			this.gbHH.Text = "Show HH Units";
			// 
			// rbHHUnassigned
			// 
			this.rbHHUnassigned.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.rbHHUnassigned.Location = new System.Drawing.Point(8, 44);
			this.rbHHUnassigned.Name = "rbHHUnassigned";
			this.rbHHUnassigned.Size = new System.Drawing.Size(136, 24);
			this.rbHHUnassigned.TabIndex = 1;
			this.rbHHUnassigned.Text = "Unassigned";
			this.rbHHUnassigned.Click += new System.EventHandler(this.rbHHUnassigned_Click);
			// 
			// rbHHAll
			// 
			this.rbHHAll.Checked = true;
			this.rbHHAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.rbHHAll.Location = new System.Drawing.Point(8, 20);
			this.rbHHAll.Name = "rbHHAll";
			this.rbHHAll.Size = new System.Drawing.Size(136, 20);
			this.rbHHAll.TabIndex = 0;
			this.rbHHAll.TabStop = true;
			this.rbHHAll.Text = "All";
			this.rbHHAll.Click += new System.EventHandler(this.rbHHAll_Click);
			// 
			// gbTeeTimes
			// 
			this.gbTeeTimes.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.gbTeeTimes.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.rbTeeTimesUnassigned,
																					 this.rbTeeTimesAll});
			this.gbTeeTimes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.gbTeeTimes.Location = new System.Drawing.Point(856, 88);
			this.gbTeeTimes.Name = "gbTeeTimes";
			this.gbTeeTimes.Size = new System.Drawing.Size(128, 72);
			this.gbTeeTimes.TabIndex = 44;
			this.gbTeeTimes.TabStop = false;
			this.gbTeeTimes.Text = "Show Tee Times";
			// 
			// rbTeeTimesUnassigned
			// 
			this.rbTeeTimesUnassigned.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.rbTeeTimesUnassigned.Location = new System.Drawing.Point(8, 44);
			this.rbTeeTimesUnassigned.Name = "rbTeeTimesUnassigned";
			this.rbTeeTimesUnassigned.Size = new System.Drawing.Size(112, 24);
			this.rbTeeTimesUnassigned.TabIndex = 1;
			this.rbTeeTimesUnassigned.Text = "Unassigned";
			this.rbTeeTimesUnassigned.Click += new System.EventHandler(this.rbTeeTimesUnassigned_Click);
			// 
			// rbTeeTimesAll
			// 
			this.rbTeeTimesAll.Checked = true;
			this.rbTeeTimesAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.rbTeeTimesAll.Location = new System.Drawing.Point(8, 20);
			this.rbTeeTimesAll.Name = "rbTeeTimesAll";
			this.rbTeeTimesAll.Size = new System.Drawing.Size(112, 20);
			this.rbTeeTimesAll.TabIndex = 0;
			this.rbTeeTimesAll.TabStop = true;
			this.rbTeeTimesAll.Text = "All";
			this.rbTeeTimesAll.Click += new System.EventHandler(this.rbTeeTimesAll_Click);
			// 
			// dgHH
			// 
			this.dgHH.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(224)), ((System.Byte)(192)));
			this.dgHH.BackgroundColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(224)), ((System.Byte)(192)));
			this.dgHH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dgHH.CaptionText = "HandHeld Units";
			this.dgHH.DataMember = "";
			this.dgHH.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgHH.Location = new System.Drawing.Point(8, 88);
			this.dgHH.Name = "dgHH";
			this.dgHH.RowHeaderWidth = 25;
			this.dgHH.Size = new System.Drawing.Size(152, 452);
			this.dgHH.TabIndex = 46;
			this.dgHH.Click += new System.EventHandler(this.dgHH_Click);
			this.dgHH.CurrentCellChanged += new System.EventHandler(this.dgHH_CurrentCellChanged);
			this.dgHH.Leave += new System.EventHandler(this.dgHH_Leave);
			// 
			// btnHHselect
			// 
			this.btnHHselect.BackColor = System.Drawing.Color.Gainsboro;
			this.btnHHselect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnHHselect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnHHselect.Location = new System.Drawing.Point(8, 48);
			this.btnHHselect.Name = "btnHHselect";
			this.btnHHselect.Size = new System.Drawing.Size(152, 32);
			this.btnHHselect.TabIndex = 47;
			this.btnHHselect.Text = "HandHeld Unit";
			this.btnHHselect.Click += new System.EventHandler(this.btnHHselect_Click);
			// 
			// btnTeeTimeSelect
			// 
			this.btnTeeTimeSelect.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.btnTeeTimeSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnTeeTimeSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnTeeTimeSelect.Location = new System.Drawing.Point(168, 48);
			this.btnTeeTimeSelect.Name = "btnTeeTimeSelect";
			this.btnTeeTimeSelect.Size = new System.Drawing.Size(152, 32);
			this.btnTeeTimeSelect.TabIndex = 48;
			this.btnTeeTimeSelect.Text = "Tee Time";
			this.btnTeeTimeSelect.Click += new System.EventHandler(this.btnTeeTimeSelect_Click);
			// 
			// btnSetUnit
			// 
			this.btnSetUnit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(128)));
			this.btnSetUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnSetUnit.Location = new System.Drawing.Point(856, 168);
			this.btnSetUnit.Name = "btnSetUnit";
			this.btnSetUnit.Size = new System.Drawing.Size(128, 40);
			this.btnSetUnit.TabIndex = 50;
			this.btnSetUnit.Text = "SET HH";
			this.btnSetUnit.Click += new System.EventHandler(this.btnSetUnit_Click);
			// 
			// btnSetPlayer
			// 
			this.btnSetPlayer.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(128)));
			this.btnSetPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnSetPlayer.Location = new System.Drawing.Point(856, 524);
			this.btnSetPlayer.Name = "btnSetPlayer";
			this.btnSetPlayer.Size = new System.Drawing.Size(128, 40);
			this.btnSetPlayer.TabIndex = 51;
			this.btnSetPlayer.Text = "SET Player";
			this.btnSetPlayer.Click += new System.EventHandler(this.btnSetPlayer_Click);
			// 
			// btnSend
			// 
			this.btnSend.BackColor = System.Drawing.Color.Yellow;
			this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnSend.Location = new System.Drawing.Point(856, 360);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(128, 52);
			this.btnSend.TabIndex = 52;
			this.btnSend.Text = "&Send Tee Time to HH";
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// cbSendGames
			// 
			this.cbSendGames.Checked = true;
			this.cbSendGames.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbSendGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cbSendGames.Location = new System.Drawing.Point(868, 416);
			this.cbSendGames.Name = "cbSendGames";
			this.cbSendGames.Size = new System.Drawing.Size(108, 16);
			this.cbSendGames.TabIndex = 53;
			this.cbSendGames.Text = "Send Games";
			// 
			// TourLiteTeeTimes
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.ClientSize = new System.Drawing.Size(992, 686);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.cbSendGames,
																		  this.btnSend,
																		  this.btnSetPlayer,
																		  this.btnSetUnit,
																		  this.btnTeeTimeSelect,
																		  this.btnHHselect,
																		  this.dgHH,
																		  this.gbTeeTimes,
																		  this.gbHH,
																		  this.btnExit,
																		  this.btnDelete,
																		  this.btnModify,
																		  this.btnAdd,
																		  this.btnPlayers,
																		  this.dgNames,
																		  this.dgTeeTimes,
																		  this.btnRefresh,
																		  this.lblTournamentSelected,
																		  this.lblTournament,
																		  this.panel1});
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "TourLiteTeeTimes";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Manage Tournament Tee Times";
			this.Load += new System.EventHandler(this.TourLiteTeeTimes_Load);
			this.Activated += new System.EventHandler(this.TourLiteTeeTimes_Activated);
			((System.ComponentModel.ISupportInitialize)(this.dgTeeTimes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgNames)).EndInit();
			this.gbHH.ResumeLayout(false);
			this.gbTeeTimes.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgHH)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			// Make Sure all TeeTime Changes are saved to the RoundTimes table;
			espDB.SaveRoundTimeChanges();
			espDB.SaveRoundTimesPlayersChanges();
			hh.DS.Tables.Clear();
			hh = null;
			ds.Relations.Remove("TeeTimePlayers");
			this.Close();
		}

		private void TourLiteTeeTimes_Load(object sender, System.EventArgs e)
		{
			// Display Tournament Name
			lblTournamentSelected.Text = _TournamentName;
			//
			// Set DataSource for HH Devices
			dvHH = new DataView(hh.DS.Tables["HHnames"]);
			dvHH.AllowNew = false;
			dgHH.DataSource = dvHH;
			//dvHH. += new System.EventHandler(this.dgTeeTimes_CurrentCellChanged);
			ConfigureHHGrid();
			//
			// Get Tee Times and set up the DataGrid associated with the TeeTimes
			espDB.GetRoundTimes(this._TournamentID);
			dvTeeTimes = new DataView( ds.Tables["RoundTeeTimes"] );
			dvTeeTimes.AllowNew = false;
			dgTeeTimes.DataSource = dvTeeTimes;

			ConfigureTeeTimesGrid();

			// Set up the DataSource for the Players DataGrid
			DataColumn parent;
			DataColumn child;
			espDB.GetRoundTimesPlayers();
			parent = ds.Tables["RoundTeeTimes"].Columns["sRoundTimeGUID"];
			child = ds.Tables["RoundTimesPlayers"].Columns["sRoundTimeGUID"];
			ttPlayers = new DataRelation("TeeTimePlayers", parent, child,true);
			ds.Relations.Add(ttPlayers);

			espDB.GetPlayerMaster();
			dgNames.SetDataBinding(ds,"RoundTeeTimes.TeeTimePlayers");
			ConfigureNamesGrid();
			// Initialize Display sort orders
			Order = 2;
			this.gbHH.Enabled = false;
			this.gbTeeTimes.Enabled = true;
		}
		//
		private void dgTeeTimesDetail_Clicked(object sender, EventArgs e)
		{
			MessageBox.Show("Details Box Clicked");
		}
		//
		private void TourLiteTeeTimes_Activated(object sender, System.EventArgs e)
		{
			// Initialize Current Records
			SetDataGridFiltersAndValues();
		}
		//
		private void ConfigureHHGrid()
		{
			DataGridTableStyle ts = new DataGridTableStyle();
			ts.MappingName = "HHnames";
			// Set other properties.
			ts.AlternatingBackColor = Color.Beige;
			ts.RowHeaderWidth = 20;

			// Add first column style.
			DataGridBoolColumn Col = new DataGridBoolColumn();
			Col.MappingName = "Assigned";
			Col.HeaderText = "";
			Col.Width = 25;
			Col.ReadOnly = true;
			ts.GridColumnStyles.Add(Col);

			// Add second column style.
			DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "Name";
			TextCol.HeaderText = "Unit";
			TextCol.Width = 75;
			TextCol.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol);

			dgHH.TableStyles.Add(ts);
		}
		//
		private void ConfigureTeeTimesGrid()
		{
			DataGridTableStyle ts = new DataGridTableStyle();
			ts.MappingName = "RoundTeeTimes";
			// Set other properties.
			ts.AlternatingBackColor = Color.Lime;
			ts.RowHeaderWidth = 30;
			ts.ReadOnly = true;

			// Add first column style.
			DataGridTextBoxColumn TextCol1 = new DataGridTextBoxColumn();
			TextCol1.MappingName = "TeeTime";
			TextCol1.HeaderText = "Tee Time";
			TextCol1.Width = 75;
			ts.GridColumnStyles.Add(TextCol1);

			// Add second column style.
			DataGridTextBoxColumn TextCol2 = new DataGridTextBoxColumn();
			TextCol2.MappingName = "HHunit";
			TextCol2.HeaderText = "Unit";
			TextCol2.Width = 125;
			ts.GridColumnStyles.Add(TextCol2);

			// Add third column style.
			DataGridTextBoxColumn TextCol3 = new DataGridTextBoxColumn();
			TextCol3.MappingName = "TeeDate";
			TextCol3.HeaderText = "Date";
			TextCol3.Width = 100;
			ts.GridColumnStyles.Add(TextCol3);

			// Add 4th column style.
			DataGridTextBoxColumn TextCol4 = new DataGridTextBoxColumn();
			TextCol4.MappingName = "NumberOfPlayers";
			TextCol4.HeaderText = "Max. Players";
			TextCol4.Width = 120;
			ts.GridColumnStyles.Add(TextCol4);

			// Add 5th column style.
			DataGridTextBoxColumn TextCol5 = new DataGridTextBoxColumn();
			TextCol5.MappingName = "StartHole";
			TextCol5.HeaderText = "Starting Hole";
			TextCol5.Width = 75;
			ts.GridColumnStyles.Add(TextCol5);

			// Add 6th column style.
			DataGridTextBoxColumn TextCol6 = new DataGridTextBoxColumn();
			TextCol6.MappingName = "HHset";
			TextCol6.HeaderText = "Set";
			TextCol6.Width = 40;
			ts.GridColumnStyles.Add(TextCol6);

			// Add 7th column style.
			DataGridTextBoxColumn TextCol7 = new DataGridTextBoxColumn();
			TextCol7.MappingName = "PlayerCount";
			TextCol7.HeaderText = "Players Assigned";
			TextCol7.Width = 140;
			TextCol7.Alignment = HorizontalAlignment.Center;
			ts.GridColumnStyles.Add(TextCol7);

			dgTeeTimes.TableStyles.Add(ts);
		}
		//
		private void ConfigureNamesGrid()
		{
			DataGridTableStyle ts = new DataGridTableStyle();
			ts.MappingName = "RoundTimesPlayers";
			// Set other properties.
			//ts.AlternatingBackColor = Color.LightBlue;
			ts.RowHeaderWidth = 20;

			DataGridTextBoxColumn TextCol1 = new DataGridTextBoxColumn();
			TextCol1.MappingName = "HHPosition";
			TextCol1.HeaderText = "Position";
			TextCol1.Width = 60;
			TextCol1.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol1);

			DataGridTextBoxColumn TextCol6 = new DataGridTextBoxColumn();
			TextCol6.MappingName = "Name";
			TextCol6.HeaderText = "Player Name";
			TextCol6.Width = 200;
			TextCol6.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol6);

			DataGridTextBoxColumn TextCol2 = new DataGridTextBoxColumn();
			TextCol2.MappingName = "Initials";
			TextCol2.HeaderText = "Initials";
			TextCol2.Width = 60;
			TextCol2.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol2);

			DataGridTextBoxColumn TextCol3 = new DataGridTextBoxColumn();
			TextCol3.MappingName = "Handicap";
			TextCol3.HeaderText = "HDCP";
			TextCol3.Width = 60;
			TextCol3.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol3);

			DataGridTextBoxColumn TextCol4 = new DataGridTextBoxColumn();
			TextCol4.MappingName = "TeeName";
			TextCol4.HeaderText = "Tee";
			TextCol4.Width = 100;
			TextCol4.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol4);

			DataGridBoolColumn Col = new DataGridBoolColumn();
			Col.MappingName = "Professional";
			Col.HeaderText = "Pro";
			Col.Width = 50;
			Col.ReadOnly = true;
			ts.GridColumnStyles.Add(Col);

			DataGridTextBoxColumn TextCol5 = new DataGridTextBoxColumn();
			TextCol5.MappingName = "DisplayGender";
			TextCol5.HeaderText = "";
			TextCol5.Width = 75;
			TextCol5.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol5);

			dgNames.TableStyles.Add(ts);
		}

		private void btnPlayers_Click(object sender, System.EventArgs e)
		{
			PlayerMaster players = new PlayerMaster(ref espDB);
			//
			players.ShowDialog();
			//
			players.Dispose();
			// Refresh Dataset from Database
			espDB.GetPlayerMaster();
		}

		private void btnRefresh_Click(object sender, System.EventArgs e)
		{
			hh.GetHHNames();
			dgHH.Refresh();
		}

		private void dgHH_CurrentCellChanged(object sender, System.EventArgs e)
		{
			SetDataGridFiltersAndValues();
		}

		private void dgHH_Click(object sender, System.EventArgs e)
		{
			SetDataGridFiltersAndValues();
		}

		private void dgNames_CurrentCellChanged(object sender, System.EventArgs e)
		{
			SetDataGridFiltersAndValues();
		}

		private void dgTeeTimes_CurrentCellChanged(object sender, System.EventArgs e)
		{
			SetDataGridFiltersAndValues();
			dgNames.Refresh();
		}

		private void btnHHselect_Click(object sender, System.EventArgs e)
		{
			btnHHselect.BackColor = dgHH.BackColor;
			btnTeeTimeSelect.BackColor = Color.Gainsboro;
			Order = 1;
			this.gbHH.Enabled = true;
			this.rbHHAll.Checked = true;
			this.gbTeeTimes.Enabled = false;
			SetDataGridFiltersAndValues();
		}

		private void btnTeeTimeSelect_Click(object sender, System.EventArgs e)
		{
			btnHHselect.BackColor = Color.Gainsboro;
			btnTeeTimeSelect.BackColor = dgTeeTimes.BackColor;
			Order = 2;
			this.gbHH.Enabled = false;
			this.gbTeeTimes.Enabled = true;
			rbTeeTimesAll.Checked = true;
			SetDataGridFiltersAndValues();
		}

		private void SetDataGridFiltersAndValues()
		{
			string filter = "";
			CurrencyManager myCM;
			// Make Sure All Temp Fields Are Set
			this.hh.UpdateAssignedFlags(ds);

			// Set Filters
			switch (Order)
			{
				case 1:
					// HH Units is the Controller
					SetHHFilter();
					//
					// Set TeeTime Filter
					rbTeeTimesUnassigned.Checked = true;
					myCM = (CurrencyManager)this.BindingContext[dvHH];
					if (myCM.List.Count > 0)
					{
						DataRowView drv = (DataRowView)myCM.Current;
						filter = "(HHunit='"+drv.Row["Name"].ToString()+"') OR HHunit=''";
						if (dvTeeTimes.RowFilter != filter)
							dvTeeTimes.RowFilter = filter;
					}
					else
					{
						filter = "(HHunit='')";
						if (dvTeeTimes.RowFilter != filter)
							dvTeeTimes.RowFilter = filter;
					}
					break;
				case 2:
					// TEETIME is the controller
					SetTeeTimeFilter();
					//
					// Set Units Filter
					if (!this.rbHHUnassigned.Checked)
						this.rbHHUnassigned.Checked = true;
					myCM = (CurrencyManager)this.BindingContext[dvTeeTimes];
					if (myCM.List.Count > 0)
					{
						DataRowView drv = (DataRowView)myCM.Current;
						filter = "(Name='"+drv.Row["HHunit"].ToString() + "') OR (Assigned = false)";
						if (dvHH.RowFilter != filter)
							dvHH.RowFilter = filter;
					}
					else
					{
						filter = "(Assigned=false)";
						if (dvHH.RowFilter != filter)
							dvHH.RowFilter = filter;
					}
					myCM.Refresh();
					this.dgHH.Refresh();
					myCM = null;
					break;
			}
			this.dgHH.Refresh();
			this.dgTeeTimes.Refresh();
			this.dgNames.Refresh();
			//
			myCM = null;
		}
		//
		private void SetHHFilter()
		{
			if (rbHHUnassigned.Checked)
			{
				if (dvHH.RowFilter == "")
					dvHH.RowFilter = "Assigned=false";
			}
			else
			{
				if (dvHH.RowFilter != "")
					dvHH.RowFilter = "";
			}
		}
		//
		private void SetTeeTimeFilter()
		{
			if (rbTeeTimesUnassigned.Checked)
			{
				if (dvTeeTimes.RowFilter == "")
					dvTeeTimes.RowFilter = "(PlayerCount<5) OR (HHunit='')";
			}
			else
			{
				if (dvTeeTimes.RowFilter != "")
					dvTeeTimes.RowFilter = "";
			}
		}
		//

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			RoundTimes rt = new RoundTimes(ref espDB);
			rt.AddMode = true;
			rt.TournamentID = _TournamentID;
			CurrencyManager myCM = (CurrencyManager)this.BindingContext[dvTeeTimes];
			if (myCM.List.Count > 0)
			{
				rt.DRV = (DataRowView)myCM.Current;
			}
			else
			{
				rt.DRV = null;
			}
			rt.ShowDialog();
			if (rt.ReturnStatus == 2)
			{
				// Save to Database and Refresh Record Set
				espDB.SaveRoundTimeChanges();
				espDB.GetRoundTimes(this._TournamentID);
			}
		}

		private void btnModify_Click(object sender, System.EventArgs e)
		{
			RoundTimes rt = new RoundTimes(ref espDB);
			rt.AddMode = false;
			rt.TournamentID = _TournamentID;
			CurrencyManager myCM = (CurrencyManager)this.BindingContext[dvTeeTimes];
			if (myCM.List.Count > 0)
			{
				rt.DRV = (DataRowView)myCM.Current;
				rt.ShowDialog();
				if (rt.ReturnStatus == 2)
				{
					// Save to Database
					espDB.SaveRoundTimeChanges();
				}
			}
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			// Verify that the Tee Time is to be Deleted
			// Verify that the current player is to be deleted
			TouchMessageBox tmb = new TouchMessageBox();
			tmb.Header = "Delete the Selected Tee Time";
			tmb.Message = "Select DELETE to confirm that you want to delete this TEE TIME.  Select CANCEL to cancel the delete of this TEE TIME.";
			tmb.Cancel = "&Cancel";
			tmb.Confirm = "&Delete";
			tmb.ShowDialog();
			if (tmb.Return)
			{
				// Delete the selected Tee Time
				CurrencyManager myCM = (CurrencyManager)this.BindingContext[dvTeeTimes];
				if (myCM.List.Count > 0)
				{
					DataRowView drv = (DataRowView)myCM.Current;
					hh.ClearAssignedUnitUsingName(drv.Row["HHunit"].ToString());
					drv.Row.Delete();
				}
			}
		}

		// TEE TIMES
		private void rbTeeTimesAll_Click(object sender, System.EventArgs e)
		{
			SetTeeTimeFilter();
		}

		private void rbTeeTimesUnassigned_Click(object sender, System.EventArgs e)
		{
			SetTeeTimeFilter();
		}
		// TEE TIMES

		// HH
		private void rbHHAll_Click(object sender, System.EventArgs e)
		{
			SetHHFilter();
		}

		private void rbHHUnassigned_Click(object sender, System.EventArgs e)
		{
			SetHHFilter();
		}
		// HH

		private void btnSetUnit_Click(object sender, System.EventArgs e)
		{
			if (Order == 3) return;
			string curvalTT = "", curvalHH = "";
			DataRowView drvTT = null, drvHH = null;
			//string test = "- - - ";
			CurrencyManager cmTT = (CurrencyManager)this.BindingContext[dvTeeTimes];
			CurrencyManager cmHH = (CurrencyManager)this.BindingContext[dvHH];
			if (cmTT.List.Count > 0)
			{
				drvTT = (DataRowView)cmTT.Current;
				curvalTT = drvTT.Row["HHunit"].ToString();
				//test += curvalTT;
			}
			//test += " * * * ";
			if (cmHH.List.Count > 0)
			{
				drvHH = (DataRowView)cmHH.Current;
				curvalHH = drvHH.Row["Name"].ToString();
				//test += curvalHH;
			}
			//test += " - - -";
			//MessageBox.Show(test);
			if (drvTT == null) return;
			if (drvHH == null) return;
			if (curvalTT != curvalHH)
			{
				bool update = true;
				if (curvalTT != "")
				{
					// A different unit was previously assigned.  Verify that the new unit is to replace
					// the previously defined unit.  Also make sure the previous unit is marked as
					// not assigned.
					hh.ClearAssignedUnitUsingName(curvalTT);
				}
				if ((bool)drvHH.Row["Assigned"])
				{
					// Unit was previously assigned to a different TeeTime.
					espDB.ClearUnitInTeeTimes(curvalHH);
				}
				if (update)
				{
					// Associate unit with tee time
					drvTT.Row.BeginEdit();
					drvTT.Row["HHunit"] = curvalHH;
					drvTT.Row.EndEdit();
					drvHH.Row.BeginEdit();
					drvHH.Row["Assigned"] = true;
					drvHH.Row.EndEdit();
				}
			}
		}

		private void btnSetPlayer_Click(object sender, System.EventArgs e)
		{
			CurrencyManager cmTT;
			DataRowView drvTT;
			string field1 = "", field2 = "";
			bool found = false;

			if (Order == 3) return;
			//cmTT = (CurrencyManager)this.BindingContext[dvTeeTimes];
			//drvTT = (DataRowView)cmTT.Current;
			if (dvTeeTimes.Count == 0)
			{
				// if there are no tee times displayed, just return
				return;
			}
			/*
			if (dvNames.Count == 0)
			{
				// if there are no names displayed, just return
				return;
			}
			*/

			// Check to see how many player names are selected.  If > 5, Display Error Message
			// CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
ReCheck:
			byte CheckedCount = 0;
			/*
			foreach (DataRowView drv in dvNames)
			{
				if (drv.Row["Assigned"] != System.DBNull.Value) if ((bool)drv.Row["Assigned"]) if (++CheckedCount > 5) break;
			}
			if (CheckedCount > 5)
			{
				// Display message and Exit
				TouchMessageBox tmb = new TouchMessageBox();
				tmb.Header = "Too many player names are selected.";
				tmb.Message = "The maximum number of player names allowed is FIVE(5).";
				tmb.Confirm = "&OK";
				tmb.Buttons = 1;
				tmb.ShowDialog();
				tmb.Dispose();
				return;
			}
			*/
			// CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC

			cmTT = (CurrencyManager)this.BindingContext[dvTeeTimes];
			drvTT = (DataRowView)cmTT.Current;
			// Check to see if any players are being removed from the current teetime
			// TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT
			/*
			foreach (DataRowView drv in dvNames)
			{
				if (drv.Row["Assigned"] == System.DBNull.Value)
				{
					drv.Row.BeginEdit();
					drv.Row["Assigned"] = false;
					drv.Row.EndEdit();
				}
				if (((bool)drv.Row["Assigned"] == false) & ((int)drv.Row["TeeTimeID"] == (int)drvTT.Row["RoundTimeID"]))
				{
					// Verify Player is to be removed from current TeeTime
					TouchMessageBox tmb = new TouchMessageBox();
					tmb.Header = "Remove Player";
					tmb.Message = "Remove "+drv.Row["Firstname"].ToString()+" "+drv.Row["Lastname"]+" from the {"+drvTT.Row["TeeTime"].ToString()+"} Tee Time?";
					tmb.Cancel = "&No";
					tmb.Confirm = "&Yes";
					tmb.ShowDialog();
					if (tmb.Return)
					{
						// Clear PlayerMaster.TeeTimeID
						drv.Row.BeginEdit();
						drv.Row["TeeTimeID"] = 0;
						drv.Row.EndEdit();
						// Locate PlayerMasterGUID Field containing Player
						field1 = "";
						field2 = "";
						found = false;
						for (byte i=1;i<=5;i++)
						{
							if (found)
							{
								field2 = "P"+i.ToString()+"GUID";
								// make sure all fill is in order {p1, p2, p3, p4, p5}GUID
								if (drvTT.Row[field2] != System.DBNull.Value)
								{
									drvTT.Row.BeginEdit();
									drvTT.Row[field1] = (Guid)drvTT.Row[field2];
									drvTT.Row[field2] = System.DBNull.Value;
									drvTT.Row.EndEdit();
									field1 = field2;
								}
								else
								{
									break;
								}
							}
							else
							{
								field1 = "P"+i.ToString()+"GUID";
								if ((Guid)drvTT.Row[field1] == (Guid)drv.Row["PlayerMasterGUID"])
								{
									// Located Player
									found = true;
									drvTT.Row.BeginEdit();
									drvTT.Row[field1] = System.DBNull.Value;
									drvTT.Row.EndEdit();
								}
							}
						}
						tmb.Dispose();
					}
					else
					{
						drv.Row.BeginEdit();
						drv.Row["Assigned"] = true;
						drv.Row.EndEdit();
						tmb.Dispose();
						goto ReCheck;
					}
				}
			}
			*/
			// TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT

			// Assign selected Players to TeeTime Selected.  No players are displayed that are
			// assigned to a different TeeTime.
			// AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
			/*
			field1 = "";
			foreach (DataRowView drv in dvNames)
			{
				if (drv.Row["Assigned"] != System.DBNull.Value) 
				{
					if (((bool)drv.Row["Assigned"]) & ((int)drv.Row["TeeTimeID"] == 0))
					{
						for (byte i=1;i<=5;i++)
						{
							field1 = "P"+i.ToString()+"GUID";
							if (drvTT.Row[field1] == System.DBNull.Value)
							{
								// Located Empty slot for the Player
								drvTT.Row.BeginEdit();
								drvTT.Row[field1] = (Guid)drv.Row["PlayerMasterGUID"];;
								drvTT.Row.EndEdit();
								break;
							}
						}
					}
				}
			}
			*/
			// AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA

			// Set TeeTime.PlayerCount = CheckedCount
			// UUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU
			/*
			drvTT.Row.BeginEdit();
			drvTT.Row["PlayerCount"] = CheckedCount;
			drvTT.Row.EndEdit();
			*/
			// UUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUUU

			// Make sure that the TeeTime changes are saved to the Database
			// AND Update the PlayerMaster From Tee Times
			// SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
			//
			espDB.SaveRoundTimeChanges();
			//
			// SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
			cmTT = null;
			
			return;
		}

		private void dgNames_TextChanged(object sender, System.EventArgs e)
		{
			MessageBox.Show("TextChanged");
		}

		private void dgNames_Leave(object sender, System.EventArgs e)
		{
			/*
			CurrencyManager cmNames = (CurrencyManager)this.BindingContext[dvNames];
			if (cmNames.Count > 0)
			{
				DataRowView drv = (DataRowView)cmNames.Current;
				if (drv.Row["Assigned"] == System.DBNull.Value)
				{
					drv.Row.BeginEdit();
					drv.Row["Assigned"] = false;
					drv.Row.EndEdit();
				}
			}
			cmNames.EndCurrentEdit();
			cmNames.Refresh();
			*/
			dgNames.Refresh();
		}

		private void dgHH_Leave(object sender, System.EventArgs e)
		{
			CurrencyManager cm = (CurrencyManager)this.BindingContext[dvHH];
			cm.EndCurrentEdit();
			cm.Refresh();
			dgHH.Refresh();
		}

		private void dgTeeTimes_Leave(object sender, System.EventArgs e)
		{
			CurrencyManager cmTeeTimes = (CurrencyManager)this.BindingContext[dvTeeTimes];
			cmTeeTimes.EndCurrentEdit();
			cmTeeTimes.Refresh();
			dgTeeTimes.Refresh();
		}

		private void btnSend_Click(object sender, System.EventArgs e)
		{
			// Send Players table to the specified Handheld

			// Send Games to the specified Handheld (temporary Code)
			if (cbSendGames.Checked)
			{
				if (TournamentID == 0) return;
				TourLiteSend send = new TourLiteSend( ref espDB);

				send.TournamentID = (int)TournamentID;
				send.ShowDialog();
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
		// ============================
		// Class Definition
		// ============================
		public class HandHeld
		{
			private DataSet ds = new DataSet();
			//
			private string UserRootPath = "";
			private DirectoryInfo diUserRootFolder;
			private int _errorstatus = 0;
			private string _StatusMessage = "";
			//
			private int _DeviceCount = 0;
			private SortedList slFolders = new SortedList();
			private IList list;
			//
			public HandHeld()
			{
				//
				// TODO: Add constructor logic here
				//
				CreateHHTable();
				GetHHNames();
			}

			public string GetUserRootLocation()
			{
				//The USERROOT path is specified in <app>.config.  Get USERROOT Folder
				// location and return as UserRoot Location String.
				string strPath = ConfigurationSettings.AppSettings["USERROOT"];
				if (!strPath.EndsWith(@"\")) strPath += @"\";
				return strPath;
			}
			//
			private string SetStatusMessage()
			{
				if (_errorstatus > 0)
				{
					return "Unable to Locate HandHelds.";
				}
				return "HandHeld Units were located.";
			}
			//
			private void CreateHHTable()
			{
				DataTable dt = new DataTable("HHnames");
				dt.Columns.Add("Key", Type.GetType("System.String"));
				dt.Columns.Add("Name", Type.GetType("System.String"));
				dt.Columns.Add("Assigned", Type.GetType("System.Boolean"));
				ds.Tables.Add(dt);
			}
			//
			private void AddHHRows(string key, string name, bool assigned)
			{
				DataTable dt = ds.Tables["HHnames"];
				DataRow dr = dt.NewRow();

				dr["Key"] = key;
				dr["Name"] = name;
				dr["Assigned"] = assigned;

				dt.Rows.Add(dr);				
			}
			//
			private void ClearAllHHRows()
			{
				ds.Tables["HHnames"].Clear();
			}
			//
			public void SetAssignedFlag(int rowindex, bool assigned)
			{
				DataTable dt = ds.Tables["HHnames"];
				DataRow [] dr = dt.Select();
				if (dr.Length > 0)
				{
					dr[rowindex].BeginEdit();
					dr[rowindex]["Assigned"] = assigned;
					dr[rowindex].EndEdit();
				}
				dr = null;
				dt = null;
			}
			//
			public void ClearAssignedUnitUsingName(string name)
			{
				DataTable dt = ds.Tables["HHnames"];
				DataRow [] dr = dt.Select();
				if (dr.Length > 0)
				{
					for (int i=0;i<dr.Length;i++)
					{
						if (dr[i]["Name"].ToString() == name)
						{
							dr[i]["Assigned"] = false;
							break;
						}
					}
				}
				dr = null;
				dt = null;
			}
			//
			public void UpdateAssignedFlags(DataSet dstt)
			{
				// Use the TEETIME table and Update ASSIGNED Flag for
				// All units that are already assigned.
				DataTable dt = dstt.Tables["RoundTeeTimes"];
				DataRow [] dr = dt.Select();
				if (dr.Length > 0)
				{
					DataTable dt2 = ds.Tables["HHnames"];
					DataRow [] dr2 = dt2.Select();
					if (dr2.Length > 0)
					{
						for (int i=0;i<dr.Length;i++)
						{
							for (int j=0;j<dr2.Length;j++)
							{
								if (dr2[j]["Name"].ToString() == dr[i]["HHunit"].ToString())
								{
									dr2[j]["Assigned"] = true;
									break;
								}
							}
						}
					}
					dr2 = null;
					dt2 = null;
				}
				dr = null;
				dt = null;
			}
			//
			public void GetHHNames()
			{
				string message = "";
				// get The UserRoot folder
				UserRootPath = GetUserRootLocation();
				message = "The specified folder location (";
				message += UserRootPath;
				message += ") could not be accessed.";

				try
				{
					diUserRootFolder = new DirectoryInfo(UserRootPath);
					if (!diUserRootFolder.Exists)
					{
						MessageBox.Show(message,"User Root Error Message");
						_errorstatus = 3;
					}
				}
				catch
				{
					MessageBox.Show(message,"User Root Error Message");
					_errorstatus = 4;
				}

				StatusMessage = this.SetStatusMessage();
				if (_errorstatus == 0)
				{
					ClearAllHHRows();
					UserData udUsers = new UserData(diUserRootFolder);
					// Copy File(s) in DataOut to all User Areas
					DirectoryInfo [] dido = diUserRootFolder.GetDirectories();
					int i = 0;
					foreach (DirectoryInfo di in dido)
					{
						// Insert Folder names in SortedList
						slFolders.Add(i.ToString(),di.Name);
						i++;
					}
					dido = null;
			
					DirectoryInfo [] diUser;
					DirectoryInfo [] diBackup;
					uint UserID = 0;
					//_slDevices.Clear();
					_DeviceCount = 0;
					// Get the Next folder name, and check to see if it contains GolfESP PDB files.
				RestartLoop:
					foreach (DictionaryEntry folder in slFolders)
					{
						// Check for UserName
						UserID = udUsers.GetUserID(folder.Value.ToString());
						if (UserID > 0)
						{
							// Check Folder
							diUser = diUserRootFolder.GetDirectories(folder.Value.ToString());
							diBackup = diUser[0].GetDirectories("Backup");
							if(diBackup.Length != 0)
							{
								if(diBackup[0].Exists)
								{
									// BACKUP folder exists, check for GolfESP PDB files
									FileInfo [] afi;
									afi = diBackup[0].GetFiles("GolfESP*.*");
									if (afi.Length > 0)
									{
										// GOLFESP Files are present, This is a valid User HH Folder
										//_slDevices.Add(_DeviceCount.ToString(),folder.Value.ToString());
										AddHHRows(_DeviceCount.ToString(),folder.Value.ToString(),false);
										_DeviceCount++;
									}
									afi = null;
								}
							}
						}
						// Folder does not contain a BACKUP folder or HH Name was stored, so remove folder.
						diUser = null;
						diBackup = null;
						slFolders.Remove(folder.Key);
						if(slFolders.Count > 0)
							goto RestartLoop;
						else
							goto Done;
					} // foreach
				}
			Done:
				return;
			}
			// PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP
			public int ErrorStatus
			{
				get{ return _errorstatus; }
			}
			public String StatusMessage
			{
				get{ return _StatusMessage; }
				set{ _StatusMessage = value; }
			}
			public int DeviceCount
			{
				get{ return _DeviceCount; }
			}
			public DataSet DS
			{
				get{ return ds; }
			}
			// PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPP
		}
		// ============================
	}
}
