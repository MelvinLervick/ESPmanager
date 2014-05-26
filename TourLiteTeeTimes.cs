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
		private bool SetDataFlag = false;
		private int _TournamentID = 0;
		private string _TournamentName = "";
		//
		DataView dvHH;
		DataView dvTeeTimes;
		DataView dvPlayers;
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
		private System.Windows.Forms.GroupBox gbHH;
		private System.Windows.Forms.RadioButton rbHHUnassigned;
		private System.Windows.Forms.RadioButton rbHHAll;
		private System.Windows.Forms.RadioButton rbTeeTimesUnassigned;
		private System.Windows.Forms.RadioButton rbTeeTimesAll;
		private System.Windows.Forms.DataGrid dgHH;
		private System.Windows.Forms.Button btnHHselect;
		private System.Windows.Forms.Button btnTeeTimeSelect;
		private System.Windows.Forms.Button btnSetUnit;
		private System.Windows.Forms.GroupBox gbTeeTimes;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.CheckBox cbSendGames;
		private System.Windows.Forms.Button btnSelectPlayers;
		private System.Windows.Forms.DataGrid dgPlayers;
		private System.Windows.Forms.Button btnRemoveHH;
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
			this.dgPlayers = new System.Windows.Forms.DataGrid();
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
			this.btnSend = new System.Windows.Forms.Button();
			this.cbSendGames = new System.Windows.Forms.CheckBox();
			this.btnSelectPlayers = new System.Windows.Forms.Button();
			this.btnRemoveHH = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgTeeTimes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgPlayers)).BeginInit();
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
			this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnRefresh.Location = new System.Drawing.Point(8, 636);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(152, 40);
			this.btnRefresh.TabIndex = 32;
			this.btnRefresh.Text = "&Refresh";
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
			this.dgTeeTimes.Size = new System.Drawing.Size(680, 424);
			this.dgTeeTimes.TabIndex = 33;
			this.dgTeeTimes.CurrentCellChanged += new System.EventHandler(this.dgTeeTimes_CurrentCellChanged);
			this.dgTeeTimes.Leave += new System.EventHandler(this.dgTeeTimes_Leave);
			// 
			// dgPlayers
			// 
			this.dgPlayers.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.dgPlayers.BackgroundColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.dgPlayers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dgPlayers.CaptionFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.dgPlayers.CaptionText = "Players Assigned to the Selected Tee Time";
			this.dgPlayers.DataMember = "";
			this.dgPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgPlayers.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgPlayers.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgPlayers.Location = new System.Drawing.Point(168, 516);
			this.dgPlayers.Name = "dgPlayers";
			this.dgPlayers.Size = new System.Drawing.Size(680, 160);
			this.dgPlayers.TabIndex = 34;
			// 
			// btnPlayers
			// 
			this.btnPlayers.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.btnPlayers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnPlayers.Location = new System.Drawing.Point(856, 580);
			this.btnPlayers.Name = "btnPlayers";
			this.btnPlayers.Size = new System.Drawing.Size(128, 40);
			this.btnPlayers.TabIndex = 36;
			this.btnPlayers.Text = "&Players";
			this.btnPlayers.Click += new System.EventHandler(this.btnPlayers_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnAdd.Location = new System.Drawing.Point(856, 264);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(128, 40);
			this.btnAdd.TabIndex = 37;
			this.btnAdd.Text = "&Add";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnModify
			// 
			this.btnModify.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnModify.Location = new System.Drawing.Point(856, 312);
			this.btnModify.Name = "btnModify";
			this.btnModify.Size = new System.Drawing.Size(128, 40);
			this.btnModify.TabIndex = 38;
			this.btnModify.Text = "&Modify";
			this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnDelete.Location = new System.Drawing.Point(856, 360);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(128, 40);
			this.btnDelete.TabIndex = 39;
			this.btnDelete.Text = "&Delete";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnExit
			// 
			this.btnExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(128)), ((System.Byte)(255)));
			this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnExit.Location = new System.Drawing.Point(856, 628);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(128, 48);
			this.btnExit.TabIndex = 42;
			this.btnExit.Text = "E&xit";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// gbHH
			// 
			this.gbHH.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
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
			this.rbHHAll.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
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
			this.dgHH.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.dgHH.BackgroundColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
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
			this.btnSetUnit.Text = "SET &HH";
			this.btnSetUnit.Click += new System.EventHandler(this.btnSetUnit_Click);
			// 
			// btnSend
			// 
			this.btnSend.BackColor = System.Drawing.Color.Yellow;
			this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnSend.Location = new System.Drawing.Point(856, 408);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(128, 52);
			this.btnSend.TabIndex = 52;
			this.btnSend.Text = "Send &Tee Time to HH";
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// cbSendGames
			// 
			this.cbSendGames.Checked = true;
			this.cbSendGames.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbSendGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cbSendGames.Location = new System.Drawing.Point(868, 464);
			this.cbSendGames.Name = "cbSendGames";
			this.cbSendGames.Size = new System.Drawing.Size(108, 16);
			this.cbSendGames.TabIndex = 53;
			this.cbSendGames.Text = "Send Games";
			// 
			// btnSelectPlayers
			// 
			this.btnSelectPlayers.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(128)));
			this.btnSelectPlayers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSelectPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnSelectPlayers.Location = new System.Drawing.Point(856, 516);
			this.btnSelectPlayers.Name = "btnSelectPlayers";
			this.btnSelectPlayers.Size = new System.Drawing.Size(128, 56);
			this.btnSelectPlayers.TabIndex = 54;
			this.btnSelectPlayers.Text = "&Select Player(s)";
			this.btnSelectPlayers.Click += new System.EventHandler(this.btnSelectPlayers_Click);
			// 
			// btnRemoveHH
			// 
			this.btnRemoveHH.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(192)));
			this.btnRemoveHH.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRemoveHH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnRemoveHH.Location = new System.Drawing.Point(856, 216);
			this.btnRemoveHH.Name = "btnRemoveHH";
			this.btnRemoveHH.Size = new System.Drawing.Size(128, 40);
			this.btnRemoveHH.TabIndex = 55;
			this.btnRemoveHH.Text = "Remove HH From Tee Time";
			this.btnRemoveHH.Click += new System.EventHandler(this.btnRemoveHH_Click);
			// 
			// TourLiteTeeTimes
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.ClientSize = new System.Drawing.Size(992, 686);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnRemoveHH,
																		  this.btnSelectPlayers,
																		  this.cbSendGames,
																		  this.btnSend,
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
																		  this.dgPlayers,
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
			((System.ComponentModel.ISupportInitialize)(this.dgPlayers)).EndInit();
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
			hh.DS.Tables.Clear();
			hh = null;
			//ds.Relations.Remove("TeeTimePlayers");
			this.Close();
		}

		private void TourLiteTeeTimes_Load(object sender, System.EventArgs e)
		{
			// Display Tournament Name
			lblTournamentSelected.Text = _TournamentName;
			//
			// get the PlayersMaster table
			espDB.GetPlayerMaster();
			//
			// Set DataSource for HH Devices
			dvHH = new DataView(hh.DS.Tables["HHnames"]);
			dvHH.AllowNew = false;
			dgHH.DataSource = dvHH;
			ConfigureHHGrid();
			//
			// Get Tee Times and set up the DataGrid associated with the TeeTimes
			espDB.GetRoundTimes(this._TournamentID);
			dvTeeTimes = new DataView( ds.Tables["RoundTeeTimes"] );
			dvTeeTimes.AllowNew = false;
			dgTeeTimes.DataSource = dvTeeTimes;
			ConfigureTeeTimesGrid();

			espDB.GetRoundTimesPlayers();
			dvPlayers = new DataView( ds.Tables["RoundTimesPlayers"] );
			dvPlayers.AllowNew = false;
			dgPlayers.DataSource = dvPlayers;
			ConfigurePlayersGrid();
			//
			// Initialize Display sort orders
			Order = 2;
			this.gbHH.Enabled = false;
			this.gbTeeTimes.Enabled = true;
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
			ts.RowHeaderWidth = 20;
			ts.ReadOnly = true;

			// Add first column style.
			DataGridTextBoxColumn TextCol1 = new DataGridTextBoxColumn();
			TextCol1.MappingName = "TeeTime";
			TextCol1.HeaderText = "Tee Time";
			TextCol1.Width = 100;
			ts.GridColumnStyles.Add(TextCol1);

			// Add second column style.
			DataGridTextBoxColumn TextCol2 = new DataGridTextBoxColumn();
			TextCol2.MappingName = "HHunit";
			TextCol2.HeaderText = "Unit";
			TextCol2.Width = 80;
			ts.GridColumnStyles.Add(TextCol2);

			// Add third column style.
			DataGridTextBoxColumn TextCol3 = new DataGridTextBoxColumn();
			TextCol3.MappingName = "TeeDate";
			TextCol3.HeaderText = "Date";
			TextCol3.Width = 90;
			ts.GridColumnStyles.Add(TextCol3);

			// Add 4th column style.
			DataGridTextBoxColumn TextCol4 = new DataGridTextBoxColumn();
			TextCol4.MappingName = "RoundNumber";
			TextCol4.HeaderText = "Round";
			TextCol4.Width = 80;
			TextCol4.Alignment = HorizontalAlignment.Center;
			ts.GridColumnStyles.Add(TextCol4);

			// Add 5th column style.
			DataGridTextBoxColumn TextCol5 = new DataGridTextBoxColumn();
			TextCol5.MappingName = "HoleStart";
			TextCol5.HeaderText = "Starting Hole";
			TextCol5.Width = 130;
			TextCol5.Alignment = HorizontalAlignment.Center;
			ts.GridColumnStyles.Add(TextCol5);

			// Add 6th column style.
			DataGridTextBoxColumn TextCol6 = new DataGridTextBoxColumn();
			TextCol6.MappingName = "HHset";
			TextCol6.HeaderText = "Set";
			TextCol6.Width = 60;
			TextCol6.Alignment = HorizontalAlignment.Center;
			ts.GridColumnStyles.Add(TextCol6);

			// Add 7th column style.
			DataGridTextBoxColumn TextCol7 = new DataGridTextBoxColumn();
			TextCol7.MappingName = "PlayerCount";
			TextCol7.HeaderText = "Assigned";
			TextCol7.Width = 100;
			TextCol7.Alignment = HorizontalAlignment.Center;
			ts.GridColumnStyles.Add(TextCol7);

			dgTeeTimes.TableStyles.Add(ts);
		}
		//
		private void ConfigurePlayersGrid()
		{
			DataGridTextBoxColumn TextCol2;
			DataGridTableStyle ts = new DataGridTableStyle();
			ts.MappingName = "RoundTimesPlayers";
			// Set other properties.
			ts.RowHeaderWidth = 20;

			// Add column style.
			DataGridTextBoxColumn TextCol0 = new DataGridTextBoxColumn();
			TextCol0.MappingName = "HHPosition";
			TextCol0.HeaderText = "Position";
			TextCol0.Width = 75;
			TextCol0.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol0);

			// Add column style.
			DataGridTextBoxColumn TextCol1 = new DataGridTextBoxColumn();
			TextCol1.MappingName = "Name";
			TextCol1.HeaderText = "Name";
			TextCol1.Width = 210;
			TextCol1.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol1);

			// Add column style.
			TextCol2 = new DataGridTextBoxColumn();
			TextCol2.MappingName = "Initials";
			TextCol2.HeaderText = "Initials";
			TextCol2.Width = 65;
			TextCol2.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol2);

			// Add column style.
			TextCol2 = new DataGridTextBoxColumn();
			TextCol2.MappingName = "Handicap";
			TextCol2.HeaderText = "Handicap";
			TextCol2.Width = 75;
			TextCol2.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol2);

			// Add column style.
			TextCol2 = new DataGridTextBoxColumn();
			TextCol2.MappingName = "TeeName";
			TextCol2.HeaderText = "Tee";
			TextCol2.Width = 100;
			TextCol2.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol2);

			// Add column style.
			DataGridBoolColumn Col = new DataGridBoolColumn();
			Col.MappingName = "Professional";
			Col.HeaderText = "PRO";
			Col.Width = 50;
			Col.ReadOnly = true;
			ts.GridColumnStyles.Add(Col);

			// Add column style.
			TextCol2 = new DataGridTextBoxColumn();
			TextCol2.MappingName = "DisplayGender";
			TextCol2.HeaderText = "Gender";
			TextCol2.Width = 75;
			TextCol2.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol2);

			dgPlayers.TableStyles.Add(ts);
		}

		private void btnPlayers_Click(object sender, System.EventArgs e)
		{
			// Current Record in DataView is used to locate PlayerID
			PlayerMaster players = new PlayerMaster(ref espDB);
			if (dvPlayers[dgPlayers.CurrentRowIndex]["PlayerMasterGUID"] != System.DBNull.Value)
				players.PlayerGUID = (Guid)dvPlayers[dgPlayers.CurrentRowIndex]["PlayerMasterGUID"];
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
			dgHH.Select(dgHH.CurrentRowIndex);
		}

		private void dgTeeTimes_CurrentCellChanged(object sender, System.EventArgs e)
		{
			SetDataGridFiltersAndValues();
			dgTeeTimes.Select(dgTeeTimes.CurrentRowIndex);
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
			SetDataFlag = true;
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
					//
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
					//
					break;
			}
			this.dgHH.Refresh();
			this.dgTeeTimes.Refresh();
			//
			if (dgTeeTimes.CurrentRowIndex < 0)
				dvPlayers.RowFilter = "RoundTimeGUID = '0000'";
			else
			{
				Guid rtGUID = (Guid)dvTeeTimes[dgTeeTimes.CurrentRowIndex]["RoundTimeGUID"];
				dvPlayers.RowFilter = "RoundTimeGUID = '"+rtGUID.ToString("D")+"'";
			}
			//
			myCM = null;
			SetDataFlag = false;
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

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			RoundTimes rt = new RoundTimes(ref espDB);
			rt.AddMode = true;
			rt.TournamentID = _TournamentID;
			rt.RoundTimeID = 0;
			if (dgTeeTimes.CurrentRowIndex >= 0) dgTeeTimes.UnSelect(dgTeeTimes.CurrentRowIndex);
			rt.ShowDialog();
			if (rt.ReturnStatus == 2)
			{
				// Set focus to new round
				for (int i=0;i<dvTeeTimes.Count;i++)
				{
					if ((int)dvTeeTimes[i]["RoundTimeID"] == rt.RoundTimeID)
					{
						dgTeeTimes.CurrentRowIndex = i;
						dgTeeTimes.Select(dgTeeTimes.CurrentRowIndex);
						return;
					}
				}
			}
			if (dvTeeTimes.Count > 0)
			{
				dgTeeTimes.CurrentRowIndex = 0;
				dgTeeTimes.Select(dgTeeTimes.CurrentRowIndex);
			}
		}

		private void btnModify_Click(object sender, System.EventArgs e)
		{
			if (dvTeeTimes.Count  > 0)
			{
				RoundTimes rt = new RoundTimes(ref espDB);
				rt.AddMode = false;
				rt.TournamentID = _TournamentID;
				rt.RoundTimeID = (int)dvTeeTimes[dgTeeTimes.CurrentRowIndex]["RoundTimeID"];
				if (dgTeeTimes.CurrentRowIndex >= 0) dgTeeTimes.UnSelect(dgTeeTimes.CurrentRowIndex);
				rt.ShowDialog();
				if (rt.ReturnStatus == 2)
				{
					// Set focus to modified round
					for (int i=0;i<dvTeeTimes.Count;i++)
					{
						if ((int)dvTeeTimes[i]["RoundTimeID"] == rt.RoundTimeID)
						{
							dgTeeTimes.CurrentRowIndex = i;
							dgTeeTimes.Select(dgTeeTimes.CurrentRowIndex);
							return;
						}
					}
				}
				dgTeeTimes.CurrentRowIndex = 0;
				dgTeeTimes.Select(dgTeeTimes.CurrentRowIndex);
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
				if (dvTeeTimes.Count > 0)
				{
					hh.ClearAssignedUnitUsingName(dvTeeTimes[dgTeeTimes.CurrentRowIndex]["HHunit"].ToString());
					espDB.DeleteFromRoundTimesPlayersTable((Guid)dvTeeTimes[dgTeeTimes.CurrentRowIndex]["RoundTimeGUID"]);
					dvTeeTimes[dgTeeTimes.CurrentRowIndex].Delete();
					espDB.SaveRoundTimeChanges();
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
			if (TournamentID == 0) return;
			DataRowView drv;
			CurrencyManager myCM = (CurrencyManager)this.BindingContext[dvTeeTimes];
			if (myCM.List.Count > 0)
			{
				drv = (DataRowView)myCM.Current;
			}
			else
			{
				// No Tee Times
				MessageBox.Show("There are currently no Tee Times defined.");
				return;
			}
			if (dvPlayers.Count == 0)
			{
				// No Tee Times
				MessageBox.Show("There are currently no Players assigned to the Selected Tee Time.");
				return;
			}
			try
			{
				if (drv["HHunit"].ToString() != "")
				{
					TourLiteSend send = new TourLiteSend( ref espDB);
					// Send Players table to the specified Handheld
					send.PlayerFlag = true;
					send.TeeTimeID = (int)drv["RoundTimeID"];
					send.Destination = drv["HHunit"].ToString();

					// Send Games to the specified Handheld (temporary Code)
					send.TournamentFlag = cbSendGames.Checked;
					send.TournamentID = (int)TournamentID;
					//
					send.ShowDialog();
				}
				else
					MessageBox.Show("A valid HandHeld Unit must first be assigned to the selected Tee Time.");
			}
			catch
			{
				MessageBox.Show("Check to insure that a valid HandHeld unit has been assigned to the selected Tee Time.");
			}
			//
			drv = null;
			myCM = null;
		}

		private void btnSelectPlayers_Click(object sender, System.EventArgs e)
		{
			CurrencyManager myCM = (CurrencyManager)this.BindingContext[dvTeeTimes];
			if (myCM.List.Count > 0)
			{
				SelectPlayersForTeeTime sp = new SelectPlayersForTeeTime(ref espDB);
				sp.TournamentID = this.TournamentID;
				sp.TournamentName = this.lblTournamentSelected.Text;
				//
				sp.DRV = (DataRowView)myCM.Current;
				sp.ShowDialog();
				sp = null;
			}
		}

		private void btnRemoveHH_Click(object sender, System.EventArgs e)
		{
			if (dgTeeTimes.CurrentRowIndex < 0) return;
			string curvalTT = "";
			curvalTT = dvTeeTimes[dgTeeTimes.CurrentRowIndex]["HHunit"].ToString();
			if (curvalTT != "")
			{
				// A different unit was previously assigned.  Verify that the new unit is to replace
				// the previously defined unit.  Also make sure the previous unit is marked as
				// not assigned.
				hh.ClearAssignedUnitUsingName(curvalTT);
				dvTeeTimes[dgTeeTimes.CurrentRowIndex]["HHunit"] = "";
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
				try
				{
					if (!strPath.EndsWith(@"\")) strPath += @"\";
				}
				catch
				{
					strPath = "";
					MessageBox.Show("There was an error accessing the USERROOT definition.  The file ESPmanager.exe.config needs to have a definition added for USERROOT.");
				}
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
				if (UserRootPath == "") return;
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
