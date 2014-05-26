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
	/// Summary description for TourLiteMaintenance.
	/// </summary>
	public class TourLiteMaintenance : System.Windows.Forms.Form
	{
		private int _TournamentID = 0;
		private bool AddMode = false;
		private Database espDB;
		private DataSet ds;
		OleDbDataAdapter tlgAdapter = null;
		OleDbDataAdapter tlAdapter = null;

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.Panel panel11;
		private System.Windows.Forms.Panel panel12;
		private System.Windows.Forms.Panel panel13;
		private System.Windows.Forms.Panel panel14;
		private System.Windows.Forms.Panel panel15;
		private System.Windows.Forms.Panel panel16;
		private System.Windows.Forms.Panel panel17;
		private System.Windows.Forms.Panel panel18;
		private System.Windows.Forms.Panel panel19;
		private System.Windows.Forms.Panel panel20;
		private System.Windows.Forms.Panel panel21;
		private System.Windows.Forms.Button Gross2Drives;
		private System.Windows.Forms.Button Net2Drives;
		private System.Windows.Forms.Button Net5Drives;
		private System.Windows.Forms.Button Gross5Drives;
		private System.Windows.Forms.TextBox txtTournamentName;
		private System.Windows.Forms.Label lblTournamentName;
		private System.Windows.Forms.Label lblStartDate;
		private System.Windows.Forms.Label lblEnddate;
		private System.Windows.Forms.Button btnDate;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.TextBox txtEndDate;
		private System.Windows.Forms.TextBox txtStartDate;
		private System.Windows.Forms.Button btnDelete;
		private ESPmanager.LargeCheckBox Gross21;
		private ESPmanager.LargeCheckBox Net21;
		private ESPmanager.LargeCheckBox Net22;
		private ESPmanager.LargeCheckBox Gross22;
		private ESPmanager.LargeCheckBox Net55;
		private ESPmanager.LargeCheckBox Gross55;
		private ESPmanager.LargeCheckBox Net54;
		private ESPmanager.LargeCheckBox Gross54;
		private ESPmanager.LargeCheckBox Net53;
		private ESPmanager.LargeCheckBox Gross53;
		private ESPmanager.LargeCheckBox Net52;
		private ESPmanager.LargeCheckBox Net51;
		private ESPmanager.LargeCheckBox Gross51;
		private ESPmanager.LargeCheckBox Net2SkinsT;
		private ESPmanager.LargeCheckBox Gross2SkinsT;
		private ESPmanager.LargeCheckBox Net2Scramble;
		private ESPmanager.LargeCheckBox Gross2Scramble;
		private ESPmanager.LargeCheckBox Net5123;
		private ESPmanager.LargeCheckBox Gross5123;
		private ESPmanager.LargeCheckBox Net5321;
		private ESPmanager.LargeCheckBox Gross5321;
		private ESPmanager.LargeCheckBox Net5SkinsI;
		private ESPmanager.LargeCheckBox Gross5SkinsI;
		private ESPmanager.LargeCheckBox Net5SkinsT;
		private ESPmanager.LargeCheckBox Gross5SkinsT;
		private ESPmanager.LargeCheckBox Net5Scramble;
		private ESPmanager.LargeCheckBox Gross5Scramble;
		private ESPmanager.LargeCheckBox Gross52;
		private System.Windows.Forms.Label lblMaxPlayers;
		private System.Windows.Forms.Button maxPlayersBB;
		private System.Windows.Forms.Label lblBestBall;
		private System.Windows.Forms.Label lblBall5;
		private System.Windows.Forms.Label lblBall4;
		private System.Windows.Forms.Label lblBall3;
		private System.Windows.Forms.Label lblBall2;
		private System.Windows.Forms.Label lblBall1;
		private System.Windows.Forms.Label lbl123Rotation;
		private System.Windows.Forms.Label lbl321Rotation;
		private System.Windows.Forms.Label lblSkinsIndiv;
		private System.Windows.Forms.Label lblSkinsTeam;
		private System.Windows.Forms.Label lblDrives;
		private System.Windows.Forms.Label lblScramble;
		private System.Windows.Forms.Label lbl2Player;
		private System.Windows.Forms.Label lbl2to5Players;
		private System.Windows.Forms.Label lblNet1;
		private System.Windows.Forms.Label lblGross1;
		private System.Windows.Forms.Label lblNet2;
		private System.Windows.Forms.Label lblGross2;
		private System.Windows.Forms.Label lblHdcp1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnHdcp2;
		private System.Windows.Forms.Button btnHdcp1;
		private System.Windows.Forms.Button btnHdcp5;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TourLiteMaintenance( ref Database espdb )
		{
			//
			// Required for Windows Form Designer support
			//
			DataSet ds = espdb.GetDS();
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnDate = new System.Windows.Forms.Button();
			this.txtEndDate = new System.Windows.Forms.TextBox();
			this.txtStartDate = new System.Windows.Forms.TextBox();
			this.lblEnddate = new System.Windows.Forms.Label();
			this.lblStartDate = new System.Windows.Forms.Label();
			this.txtTournamentName = new System.Windows.Forms.TextBox();
			this.lblTournamentName = new System.Windows.Forms.Label();
			this.btnExit = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lblBestBall = new System.Windows.Forms.Label();
			this.lblBall5 = new System.Windows.Forms.Label();
			this.lblBall4 = new System.Windows.Forms.Label();
			this.lblBall3 = new System.Windows.Forms.Label();
			this.lblBall2 = new System.Windows.Forms.Label();
			this.lblBall1 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.lbl123Rotation = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.lbl321Rotation = new System.Windows.Forms.Label();
			this.panel6 = new System.Windows.Forms.Panel();
			this.lblSkinsIndiv = new System.Windows.Forms.Label();
			this.panel7 = new System.Windows.Forms.Panel();
			this.lblSkinsTeam = new System.Windows.Forms.Label();
			this.panel8 = new System.Windows.Forms.Panel();
			this.lblDrives = new System.Windows.Forms.Label();
			this.lblScramble = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.lblNet1 = new System.Windows.Forms.Label();
			this.lblGross1 = new System.Windows.Forms.Label();
			this.Net22 = new ESPmanager.LargeCheckBox();
			this.Gross22 = new ESPmanager.LargeCheckBox();
			this.Net21 = new ESPmanager.LargeCheckBox();
			this.Gross21 = new ESPmanager.LargeCheckBox();
			this.panel9 = new System.Windows.Forms.Panel();
			this.panel10 = new System.Windows.Forms.Panel();
			this.panel11 = new System.Windows.Forms.Panel();
			this.panel12 = new System.Windows.Forms.Panel();
			this.Net2SkinsT = new ESPmanager.LargeCheckBox();
			this.Gross2SkinsT = new ESPmanager.LargeCheckBox();
			this.panel13 = new System.Windows.Forms.Panel();
			this.Net2Scramble = new ESPmanager.LargeCheckBox();
			this.Gross2Scramble = new ESPmanager.LargeCheckBox();
			this.Net2Drives = new System.Windows.Forms.Button();
			this.Gross2Drives = new System.Windows.Forms.Button();
			this.panel14 = new System.Windows.Forms.Panel();
			this.lblNet2 = new System.Windows.Forms.Label();
			this.lblGross2 = new System.Windows.Forms.Label();
			this.maxPlayersBB = new System.Windows.Forms.Button();
			this.lblMaxPlayers = new System.Windows.Forms.Label();
			this.Net55 = new ESPmanager.LargeCheckBox();
			this.Gross55 = new ESPmanager.LargeCheckBox();
			this.Net54 = new ESPmanager.LargeCheckBox();
			this.Gross54 = new ESPmanager.LargeCheckBox();
			this.Net53 = new ESPmanager.LargeCheckBox();
			this.Gross53 = new ESPmanager.LargeCheckBox();
			this.Net52 = new ESPmanager.LargeCheckBox();
			this.Gross52 = new ESPmanager.LargeCheckBox();
			this.Net51 = new ESPmanager.LargeCheckBox();
			this.Gross51 = new ESPmanager.LargeCheckBox();
			this.panel15 = new System.Windows.Forms.Panel();
			this.Net5123 = new ESPmanager.LargeCheckBox();
			this.Gross5123 = new ESPmanager.LargeCheckBox();
			this.panel16 = new System.Windows.Forms.Panel();
			this.Net5321 = new ESPmanager.LargeCheckBox();
			this.Gross5321 = new ESPmanager.LargeCheckBox();
			this.panel17 = new System.Windows.Forms.Panel();
			this.Net5SkinsI = new ESPmanager.LargeCheckBox();
			this.Gross5SkinsI = new ESPmanager.LargeCheckBox();
			this.panel18 = new System.Windows.Forms.Panel();
			this.Net5SkinsT = new ESPmanager.LargeCheckBox();
			this.Gross5SkinsT = new ESPmanager.LargeCheckBox();
			this.panel19 = new System.Windows.Forms.Panel();
			this.Net5Scramble = new ESPmanager.LargeCheckBox();
			this.Gross5Scramble = new ESPmanager.LargeCheckBox();
			this.Net5Drives = new System.Windows.Forms.Button();
			this.Gross5Drives = new System.Windows.Forms.Button();
			this.panel20 = new System.Windows.Forms.Panel();
			this.lbl2Player = new System.Windows.Forms.Label();
			this.panel21 = new System.Windows.Forms.Panel();
			this.lbl2to5Players = new System.Windows.Forms.Label();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.lblHdcp1 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnHdcp2 = new System.Windows.Forms.Button();
			this.btnHdcp1 = new System.Windows.Forms.Button();
			this.btnHdcp5 = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel7.SuspendLayout();
			this.panel8.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel12.SuspendLayout();
			this.panel13.SuspendLayout();
			this.panel14.SuspendLayout();
			this.panel15.SuspendLayout();
			this.panel16.SuspendLayout();
			this.panel17.SuspendLayout();
			this.panel18.SuspendLayout();
			this.panel19.SuspendLayout();
			this.panel20.SuspendLayout();
			this.panel21.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.btnDate,
																				 this.txtEndDate,
																				 this.txtStartDate,
																				 this.lblEnddate,
																				 this.lblStartDate,
																				 this.txtTournamentName,
																				 this.lblTournamentName});
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(996, 100);
			this.panel1.TabIndex = 0;
			// 
			// btnDate
			// 
			this.btnDate.BackColor = System.Drawing.Color.Navy;
			this.btnDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnDate.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.btnDate.Location = new System.Drawing.Point(472, 48);
			this.btnDate.Name = "btnDate";
			this.btnDate.Size = new System.Drawing.Size(184, 43);
			this.btnDate.TabIndex = 1;
			this.btnDate.Text = "Change Date";
			this.btnDate.Click += new System.EventHandler(this.btnDate_Click);
			// 
			// txtEndDate
			// 
			this.txtEndDate.Enabled = false;
			this.txtEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtEndDate.Location = new System.Drawing.Point(820, 56);
			this.txtEndDate.Name = "txtEndDate";
			this.txtEndDate.ReadOnly = true;
			this.txtEndDate.Size = new System.Drawing.Size(156, 31);
			this.txtEndDate.TabIndex = 37;
			this.txtEndDate.Text = "";
			// 
			// txtStartDate
			// 
			this.txtStartDate.Enabled = false;
			this.txtStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtStartDate.Location = new System.Drawing.Point(820, 16);
			this.txtStartDate.Name = "txtStartDate";
			this.txtStartDate.ReadOnly = true;
			this.txtStartDate.Size = new System.Drawing.Size(156, 31);
			this.txtStartDate.TabIndex = 36;
			this.txtStartDate.Text = "";
			// 
			// lblEnddate
			// 
			this.lblEnddate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.lblEnddate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblEnddate.Location = new System.Drawing.Point(668, 56);
			this.lblEnddate.Name = "lblEnddate";
			this.lblEnddate.Size = new System.Drawing.Size(144, 32);
			this.lblEnddate.TabIndex = 35;
			this.lblEnddate.Text = "End Date";
			this.lblEnddate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblStartDate
			// 
			this.lblStartDate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.lblStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblStartDate.Location = new System.Drawing.Point(668, 16);
			this.lblStartDate.Name = "lblStartDate";
			this.lblStartDate.Size = new System.Drawing.Size(144, 32);
			this.lblStartDate.TabIndex = 34;
			this.lblStartDate.Text = "Start Date";
			this.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtTournamentName
			// 
			this.txtTournamentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtTournamentName.Location = new System.Drawing.Point(212, 8);
			this.txtTournamentName.Name = "txtTournamentName";
			this.txtTournamentName.ReadOnly = true;
			this.txtTournamentName.Size = new System.Drawing.Size(444, 31);
			this.txtTournamentName.TabIndex = 0;
			this.txtTournamentName.Text = "";
			// 
			// lblTournamentName
			// 
			this.lblTournamentName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.lblTournamentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTournamentName.Location = new System.Drawing.Point(8, 8);
			this.lblTournamentName.Name = "lblTournamentName";
			this.lblTournamentName.Size = new System.Drawing.Size(204, 32);
			this.lblTournamentName.TabIndex = 33;
			this.lblTournamentName.Text = "Tournament Name";
			this.lblTournamentName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnExit
			// 
			this.btnExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(128)), ((System.Byte)(255)));
			this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnExit.Location = new System.Drawing.Point(836, 616);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(140, 56);
			this.btnExit.TabIndex = 16;
			this.btnExit.Text = "E&xit";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.lblBestBall,
																				 this.lblBall5,
																				 this.lblBall4,
																				 this.lblBall3,
																				 this.lblBall2,
																				 this.lblBall1});
			this.panel2.Enabled = false;
			this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.panel2.Location = new System.Drawing.Point(12, 120);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(284, 212);
			this.panel2.TabIndex = 45;
			// 
			// lblBestBall
			// 
			this.lblBestBall.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.lblBestBall.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblBestBall.Location = new System.Drawing.Point(8, 4);
			this.lblBestBall.Name = "lblBestBall";
			this.lblBestBall.Size = new System.Drawing.Size(144, 29);
			this.lblBestBall.TabIndex = 46;
			this.lblBestBall.Text = "Best Ball";
			// 
			// lblBall5
			// 
			this.lblBall5.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.lblBall5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblBall5.Location = new System.Drawing.Point(139, 174);
			this.lblBall5.Name = "lblBall5";
			this.lblBall5.Size = new System.Drawing.Size(96, 28);
			this.lblBall5.TabIndex = 45;
			this.lblBall5.Text = "Ball 5";
			// 
			// lblBall4
			// 
			this.lblBall4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.lblBall4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblBall4.Location = new System.Drawing.Point(139, 144);
			this.lblBall4.Name = "lblBall4";
			this.lblBall4.Size = new System.Drawing.Size(96, 28);
			this.lblBall4.TabIndex = 44;
			this.lblBall4.Text = "Ball 4";
			// 
			// lblBall3
			// 
			this.lblBall3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.lblBall3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblBall3.Location = new System.Drawing.Point(139, 114);
			this.lblBall3.Name = "lblBall3";
			this.lblBall3.Size = new System.Drawing.Size(96, 28);
			this.lblBall3.TabIndex = 43;
			this.lblBall3.Text = "Ball 3";
			// 
			// lblBall2
			// 
			this.lblBall2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.lblBall2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblBall2.Location = new System.Drawing.Point(139, 84);
			this.lblBall2.Name = "lblBall2";
			this.lblBall2.Size = new System.Drawing.Size(96, 28);
			this.lblBall2.TabIndex = 42;
			this.lblBall2.Text = "Ball 2";
			// 
			// lblBall1
			// 
			this.lblBall1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.lblBall1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblBall1.Location = new System.Drawing.Point(139, 54);
			this.lblBall1.Name = "lblBall1";
			this.lblBall1.Size = new System.Drawing.Size(96, 28);
			this.lblBall1.TabIndex = 41;
			this.lblBall1.Text = "Ball 1";
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.Silver;
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.lbl123Rotation});
			this.panel3.Enabled = false;
			this.panel3.Location = new System.Drawing.Point(12, 332);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(284, 36);
			this.panel3.TabIndex = 52;
			// 
			// lbl123Rotation
			// 
			this.lbl123Rotation.BackColor = System.Drawing.Color.Silver;
			this.lbl123Rotation.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbl123Rotation.Location = new System.Drawing.Point(12, 0);
			this.lbl123Rotation.Name = "lbl123Rotation";
			this.lbl123Rotation.Size = new System.Drawing.Size(256, 36);
			this.lbl123Rotation.TabIndex = 47;
			this.lbl123Rotation.Text = "1-2-3 Ball Rotation";
			this.lbl123Rotation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel5
			// 
			this.panel5.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel5.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.lbl321Rotation});
			this.panel5.Enabled = false;
			this.panel5.Location = new System.Drawing.Point(12, 368);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(284, 36);
			this.panel5.TabIndex = 53;
			// 
			// lbl321Rotation
			// 
			this.lbl321Rotation.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.lbl321Rotation.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbl321Rotation.Location = new System.Drawing.Point(12, 0);
			this.lbl321Rotation.Name = "lbl321Rotation";
			this.lbl321Rotation.Size = new System.Drawing.Size(256, 36);
			this.lbl321Rotation.TabIndex = 48;
			this.lbl321Rotation.Text = "3-2-1 Ball Rotation";
			this.lbl321Rotation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel6
			// 
			this.panel6.BackColor = System.Drawing.Color.Silver;
			this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel6.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.lblSkinsIndiv});
			this.panel6.Enabled = false;
			this.panel6.Location = new System.Drawing.Point(12, 404);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(284, 36);
			this.panel6.TabIndex = 54;
			// 
			// lblSkinsIndiv
			// 
			this.lblSkinsIndiv.BackColor = System.Drawing.Color.Silver;
			this.lblSkinsIndiv.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblSkinsIndiv.Location = new System.Drawing.Point(12, 0);
			this.lblSkinsIndiv.Name = "lblSkinsIndiv";
			this.lblSkinsIndiv.Size = new System.Drawing.Size(256, 36);
			this.lblSkinsIndiv.TabIndex = 49;
			this.lblSkinsIndiv.Text = "Skins Individual";
			this.lblSkinsIndiv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel7
			// 
			this.panel7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel7.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.lblSkinsTeam});
			this.panel7.Enabled = false;
			this.panel7.Location = new System.Drawing.Point(12, 440);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(284, 36);
			this.panel7.TabIndex = 55;
			// 
			// lblSkinsTeam
			// 
			this.lblSkinsTeam.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.lblSkinsTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblSkinsTeam.Location = new System.Drawing.Point(12, 0);
			this.lblSkinsTeam.Name = "lblSkinsTeam";
			this.lblSkinsTeam.Size = new System.Drawing.Size(256, 36);
			this.lblSkinsTeam.TabIndex = 50;
			this.lblSkinsTeam.Text = "Skins Team";
			this.lblSkinsTeam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.Silver;
			this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel8.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.lblDrives,
																				 this.lblScramble});
			this.panel8.Enabled = false;
			this.panel8.Location = new System.Drawing.Point(12, 476);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(284, 88);
			this.panel8.TabIndex = 56;
			// 
			// lblDrives
			// 
			this.lblDrives.BackColor = System.Drawing.Color.Silver;
			this.lblDrives.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDrives.Location = new System.Drawing.Point(48, 48);
			this.lblDrives.Name = "lblDrives";
			this.lblDrives.Size = new System.Drawing.Size(228, 28);
			this.lblDrives.TabIndex = 53;
			this.lblDrives.Text = "Drives per Participant";
			// 
			// lblScramble
			// 
			this.lblScramble.BackColor = System.Drawing.Color.Silver;
			this.lblScramble.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblScramble.Location = new System.Drawing.Point(12, 12);
			this.lblScramble.Name = "lblScramble";
			this.lblScramble.Size = new System.Drawing.Size(144, 28);
			this.lblScramble.TabIndex = 52;
			this.lblScramble.Text = "Scramble";
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel4.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.btnHdcp1,
																				 this.label1,
																				 this.lblNet1,
																				 this.lblGross1,
																				 this.Net22,
																				 this.Gross22,
																				 this.Net21,
																				 this.Gross21});
			this.panel4.Location = new System.Drawing.Point(296, 152);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(304, 180);
			this.panel4.TabIndex = 1;
			// 
			// lblNet1
			// 
			this.lblNet1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.lblNet1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblNet1.Location = new System.Drawing.Point(156, 0);
			this.lblNet1.Name = "lblNet1";
			this.lblNet1.Size = new System.Drawing.Size(136, 20);
			this.lblNet1.TabIndex = 41;
			this.lblNet1.Text = "Net";
			this.lblNet1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblGross1
			// 
			this.lblGross1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.lblGross1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblGross1.Location = new System.Drawing.Point(12, 0);
			this.lblGross1.Name = "lblGross1";
			this.lblGross1.Size = new System.Drawing.Size(136, 20);
			this.lblGross1.TabIndex = 40;
			this.lblGross1.Text = "Gross";
			this.lblGross1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Net22
			// 
			this.Net22.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(0)));
			this.Net22.Checked = false;
			this.Net22.Location = new System.Drawing.Point(154, 52);
			this.Net22.Name = "Net22";
			this.Net22.Size = new System.Drawing.Size(140, 28);
			this.Net22.TabIndex = 3;
			this.Net22.Click += new System.EventHandler(this.Net22_Click);
			// 
			// Gross22
			// 
			this.Gross22.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.Gross22.Checked = false;
			this.Gross22.Location = new System.Drawing.Point(8, 52);
			this.Gross22.Name = "Gross22";
			this.Gross22.Size = new System.Drawing.Size(140, 28);
			this.Gross22.TabIndex = 2;
			this.Gross22.Click += new System.EventHandler(this.Gross22_Click);
			// 
			// Net21
			// 
			this.Net21.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(0)));
			this.Net21.Checked = false;
			this.Net21.Location = new System.Drawing.Point(154, 22);
			this.Net21.Name = "Net21";
			this.Net21.Size = new System.Drawing.Size(140, 28);
			this.Net21.TabIndex = 1;
			this.Net21.Click += new System.EventHandler(this.Net21_Click);
			// 
			// Gross21
			// 
			this.Gross21.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.Gross21.Checked = false;
			this.Gross21.Location = new System.Drawing.Point(8, 22);
			this.Gross21.Name = "Gross21";
			this.Gross21.Size = new System.Drawing.Size(140, 28);
			this.Gross21.TabIndex = 0;
			this.Gross21.Click += new System.EventHandler(this.Gross21_Click);
			// 
			// panel9
			// 
			this.panel9.BackColor = System.Drawing.Color.Silver;
			this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel9.Enabled = false;
			this.panel9.Location = new System.Drawing.Point(296, 332);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(304, 36);
			this.panel9.TabIndex = 58;
			// 
			// panel10
			// 
			this.panel10.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel10.Enabled = false;
			this.panel10.Location = new System.Drawing.Point(296, 368);
			this.panel10.Name = "panel10";
			this.panel10.Size = new System.Drawing.Size(304, 36);
			this.panel10.TabIndex = 59;
			// 
			// panel11
			// 
			this.panel11.BackColor = System.Drawing.Color.Silver;
			this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel11.Enabled = false;
			this.panel11.Location = new System.Drawing.Point(296, 404);
			this.panel11.Name = "panel11";
			this.panel11.Size = new System.Drawing.Size(304, 36);
			this.panel11.TabIndex = 5;
			// 
			// panel12
			// 
			this.panel12.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel12.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.Net2SkinsT,
																				  this.Gross2SkinsT});
			this.panel12.Location = new System.Drawing.Point(296, 440);
			this.panel12.Name = "panel12";
			this.panel12.Size = new System.Drawing.Size(304, 36);
			this.panel12.TabIndex = 7;
			// 
			// Net2SkinsT
			// 
			this.Net2SkinsT.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.Net2SkinsT.Checked = false;
			this.Net2SkinsT.Enabled = false;
			this.Net2SkinsT.Location = new System.Drawing.Point(154, 2);
			this.Net2SkinsT.Name = "Net2SkinsT";
			this.Net2SkinsT.Size = new System.Drawing.Size(140, 28);
			this.Net2SkinsT.TabIndex = 1;
			// 
			// Gross2SkinsT
			// 
			this.Gross2SkinsT.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.Gross2SkinsT.Checked = false;
			this.Gross2SkinsT.Enabled = false;
			this.Gross2SkinsT.Location = new System.Drawing.Point(8, 2);
			this.Gross2SkinsT.Name = "Gross2SkinsT";
			this.Gross2SkinsT.Size = new System.Drawing.Size(140, 28);
			this.Gross2SkinsT.TabIndex = 0;
			// 
			// panel13
			// 
			this.panel13.BackColor = System.Drawing.Color.Silver;
			this.panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel13.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.Net2Scramble,
																				  this.Gross2Scramble,
																				  this.Net2Drives,
																				  this.Gross2Drives});
			this.panel13.Location = new System.Drawing.Point(296, 476);
			this.panel13.Name = "panel13";
			this.panel13.Size = new System.Drawing.Size(304, 88);
			this.panel13.TabIndex = 9;
			// 
			// Net2Scramble
			// 
			this.Net2Scramble.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.Net2Scramble.Checked = false;
			this.Net2Scramble.Enabled = false;
			this.Net2Scramble.Location = new System.Drawing.Point(152, 8);
			this.Net2Scramble.Name = "Net2Scramble";
			this.Net2Scramble.Size = new System.Drawing.Size(140, 32);
			this.Net2Scramble.TabIndex = 2;
			// 
			// Gross2Scramble
			// 
			this.Gross2Scramble.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.Gross2Scramble.Checked = false;
			this.Gross2Scramble.Enabled = false;
			this.Gross2Scramble.Location = new System.Drawing.Point(7, 8);
			this.Gross2Scramble.Name = "Gross2Scramble";
			this.Gross2Scramble.Size = new System.Drawing.Size(140, 32);
			this.Gross2Scramble.TabIndex = 0;
			// 
			// Net2Drives
			// 
			this.Net2Drives.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.Net2Drives.Enabled = false;
			this.Net2Drives.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Net2Drives.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Net2Drives.Location = new System.Drawing.Point(152, 48);
			this.Net2Drives.Name = "Net2Drives";
			this.Net2Drives.Size = new System.Drawing.Size(140, 28);
			this.Net2Drives.TabIndex = 3;
			this.Net2Drives.Text = "0";
			this.Net2Drives.Click += new System.EventHandler(this.Net2Drives_Click);
			// 
			// Gross2Drives
			// 
			this.Gross2Drives.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.Gross2Drives.Enabled = false;
			this.Gross2Drives.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Gross2Drives.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Gross2Drives.Location = new System.Drawing.Point(7, 48);
			this.Gross2Drives.Name = "Gross2Drives";
			this.Gross2Drives.Size = new System.Drawing.Size(140, 28);
			this.Gross2Drives.TabIndex = 1;
			this.Gross2Drives.Text = "0";
			this.Gross2Drives.Click += new System.EventHandler(this.Gross2Drives_Click);
			// 
			// panel14
			// 
			this.panel14.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.panel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel14.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.btnHdcp2,
																				  this.lblNet2,
																				  this.lblGross2,
																				  this.maxPlayersBB,
																				  this.lblMaxPlayers,
																				  this.Net55,
																				  this.Gross55,
																				  this.Net54,
																				  this.Gross54,
																				  this.Net53,
																				  this.Gross53,
																				  this.Net52,
																				  this.Gross52,
																				  this.Net51,
																				  this.Gross51});
			this.panel14.Location = new System.Drawing.Point(600, 152);
			this.panel14.Name = "panel14";
			this.panel14.Size = new System.Drawing.Size(380, 180);
			this.panel14.TabIndex = 2;
			// 
			// lblNet2
			// 
			this.lblNet2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.lblNet2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblNet2.Location = new System.Drawing.Point(176, 0);
			this.lblNet2.Name = "lblNet2";
			this.lblNet2.Size = new System.Drawing.Size(76, 16);
			this.lblNet2.TabIndex = 46;
			this.lblNet2.Text = "Net";
			this.lblNet2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblGross2
			// 
			this.lblGross2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.lblGross2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblGross2.Location = new System.Drawing.Point(24, 0);
			this.lblGross2.Name = "lblGross2";
			this.lblGross2.Size = new System.Drawing.Size(76, 16);
			this.lblGross2.TabIndex = 45;
			this.lblGross2.Text = "Gross";
			this.lblGross2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// maxPlayersBB
			// 
			this.maxPlayersBB.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(192)));
			this.maxPlayersBB.Enabled = false;
			this.maxPlayersBB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.maxPlayersBB.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.maxPlayersBB.Location = new System.Drawing.Point(304, 104);
			this.maxPlayersBB.Name = "maxPlayersBB";
			this.maxPlayersBB.Size = new System.Drawing.Size(64, 66);
			this.maxPlayersBB.TabIndex = 44;
			this.maxPlayersBB.Text = "0";
			this.maxPlayersBB.Click += new System.EventHandler(this.maxPlayersBB_Click);
			// 
			// lblMaxPlayers
			// 
			this.lblMaxPlayers.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.lblMaxPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMaxPlayers.Location = new System.Drawing.Point(300, 60);
			this.lblMaxPlayers.Name = "lblMaxPlayers";
			this.lblMaxPlayers.Size = new System.Drawing.Size(66, 44);
			this.lblMaxPlayers.TabIndex = 43;
			this.lblMaxPlayers.Text = "Max Players";
			this.lblMaxPlayers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Net55
			// 
			this.Net55.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(0)));
			this.Net55.Checked = false;
			this.Net55.Location = new System.Drawing.Point(152, 142);
			this.Net55.Name = "Net55";
			this.Net55.Size = new System.Drawing.Size(140, 28);
			this.Net55.TabIndex = 9;
			this.Net55.Click += new System.EventHandler(this.Net55_Click);
			// 
			// Gross55
			// 
			this.Gross55.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.Gross55.Checked = false;
			this.Gross55.Location = new System.Drawing.Point(8, 142);
			this.Gross55.Name = "Gross55";
			this.Gross55.Size = new System.Drawing.Size(140, 28);
			this.Gross55.TabIndex = 8;
			this.Gross55.Click += new System.EventHandler(this.Gross55_Click);
			// 
			// Net54
			// 
			this.Net54.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(0)));
			this.Net54.Checked = false;
			this.Net54.Location = new System.Drawing.Point(152, 112);
			this.Net54.Name = "Net54";
			this.Net54.Size = new System.Drawing.Size(140, 28);
			this.Net54.TabIndex = 7;
			this.Net54.Click += new System.EventHandler(this.Net54_Click);
			// 
			// Gross54
			// 
			this.Gross54.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.Gross54.Checked = false;
			this.Gross54.Location = new System.Drawing.Point(8, 112);
			this.Gross54.Name = "Gross54";
			this.Gross54.Size = new System.Drawing.Size(140, 28);
			this.Gross54.TabIndex = 6;
			this.Gross54.Click += new System.EventHandler(this.Gross54_Click);
			// 
			// Net53
			// 
			this.Net53.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(0)));
			this.Net53.Checked = false;
			this.Net53.Location = new System.Drawing.Point(152, 82);
			this.Net53.Name = "Net53";
			this.Net53.Size = new System.Drawing.Size(140, 28);
			this.Net53.TabIndex = 5;
			this.Net53.Click += new System.EventHandler(this.Net53_Click);
			// 
			// Gross53
			// 
			this.Gross53.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.Gross53.Checked = false;
			this.Gross53.Location = new System.Drawing.Point(8, 82);
			this.Gross53.Name = "Gross53";
			this.Gross53.Size = new System.Drawing.Size(140, 28);
			this.Gross53.TabIndex = 4;
			this.Gross53.Click += new System.EventHandler(this.Gross53_Click);
			// 
			// Net52
			// 
			this.Net52.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(0)));
			this.Net52.Checked = false;
			this.Net52.Location = new System.Drawing.Point(152, 52);
			this.Net52.Name = "Net52";
			this.Net52.Size = new System.Drawing.Size(140, 28);
			this.Net52.TabIndex = 3;
			this.Net52.Click += new System.EventHandler(this.Net52_Click);
			// 
			// Gross52
			// 
			this.Gross52.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.Gross52.Checked = false;
			this.Gross52.Location = new System.Drawing.Point(8, 52);
			this.Gross52.Name = "Gross52";
			this.Gross52.Size = new System.Drawing.Size(140, 28);
			this.Gross52.TabIndex = 2;
			this.Gross52.Click += new System.EventHandler(this.Gross52_Click);
			// 
			// Net51
			// 
			this.Net51.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(0)));
			this.Net51.Checked = false;
			this.Net51.Location = new System.Drawing.Point(152, 22);
			this.Net51.Name = "Net51";
			this.Net51.Size = new System.Drawing.Size(140, 28);
			this.Net51.TabIndex = 1;
			this.Net51.Click += new System.EventHandler(this.Net51_Click);
			// 
			// Gross51
			// 
			this.Gross51.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.Gross51.Checked = false;
			this.Gross51.Location = new System.Drawing.Point(8, 22);
			this.Gross51.Name = "Gross51";
			this.Gross51.Size = new System.Drawing.Size(140, 28);
			this.Gross51.TabIndex = 0;
			this.Gross51.Click += new System.EventHandler(this.Gross51_Click);
			// 
			// panel15
			// 
			this.panel15.BackColor = System.Drawing.Color.Silver;
			this.panel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel15.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.Net5123,
																				  this.Gross5123});
			this.panel15.Location = new System.Drawing.Point(600, 332);
			this.panel15.Name = "panel15";
			this.panel15.Size = new System.Drawing.Size(380, 36);
			this.panel15.TabIndex = 3;
			// 
			// Net5123
			// 
			this.Net5123.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.Net5123.Checked = false;
			this.Net5123.Enabled = false;
			this.Net5123.Location = new System.Drawing.Point(152, 3);
			this.Net5123.Name = "Net5123";
			this.Net5123.Size = new System.Drawing.Size(140, 28);
			this.Net5123.TabIndex = 1;
			// 
			// Gross5123
			// 
			this.Gross5123.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.Gross5123.Checked = false;
			this.Gross5123.Enabled = false;
			this.Gross5123.Location = new System.Drawing.Point(7, 3);
			this.Gross5123.Name = "Gross5123";
			this.Gross5123.Size = new System.Drawing.Size(140, 28);
			this.Gross5123.TabIndex = 0;
			// 
			// panel16
			// 
			this.panel16.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel16.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.Net5321,
																				  this.Gross5321});
			this.panel16.Location = new System.Drawing.Point(600, 368);
			this.panel16.Name = "panel16";
			this.panel16.Size = new System.Drawing.Size(380, 36);
			this.panel16.TabIndex = 4;
			// 
			// Net5321
			// 
			this.Net5321.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.Net5321.Checked = false;
			this.Net5321.Enabled = false;
			this.Net5321.Location = new System.Drawing.Point(152, 4);
			this.Net5321.Name = "Net5321";
			this.Net5321.Size = new System.Drawing.Size(140, 28);
			this.Net5321.TabIndex = 1;
			// 
			// Gross5321
			// 
			this.Gross5321.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.Gross5321.Checked = false;
			this.Gross5321.Enabled = false;
			this.Gross5321.Location = new System.Drawing.Point(7, 4);
			this.Gross5321.Name = "Gross5321";
			this.Gross5321.Size = new System.Drawing.Size(140, 28);
			this.Gross5321.TabIndex = 0;
			// 
			// panel17
			// 
			this.panel17.BackColor = System.Drawing.Color.Silver;
			this.panel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel17.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.btnHdcp5,
																				  this.Net5SkinsI,
																				  this.Gross5SkinsI});
			this.panel17.Location = new System.Drawing.Point(600, 404);
			this.panel17.Name = "panel17";
			this.panel17.Size = new System.Drawing.Size(380, 36);
			this.panel17.TabIndex = 6;
			// 
			// Net5SkinsI
			// 
			this.Net5SkinsI.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(0)));
			this.Net5SkinsI.Checked = false;
			this.Net5SkinsI.Location = new System.Drawing.Point(152, 3);
			this.Net5SkinsI.Name = "Net5SkinsI";
			this.Net5SkinsI.Size = new System.Drawing.Size(140, 28);
			this.Net5SkinsI.TabIndex = 1;
			// 
			// Gross5SkinsI
			// 
			this.Gross5SkinsI.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.Gross5SkinsI.Checked = false;
			this.Gross5SkinsI.Location = new System.Drawing.Point(7, 3);
			this.Gross5SkinsI.Name = "Gross5SkinsI";
			this.Gross5SkinsI.Size = new System.Drawing.Size(140, 28);
			this.Gross5SkinsI.TabIndex = 0;
			// 
			// panel18
			// 
			this.panel18.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.panel18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel18.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.Net5SkinsT,
																				  this.Gross5SkinsT});
			this.panel18.Location = new System.Drawing.Point(600, 440);
			this.panel18.Name = "panel18";
			this.panel18.Size = new System.Drawing.Size(380, 36);
			this.panel18.TabIndex = 8;
			// 
			// Net5SkinsT
			// 
			this.Net5SkinsT.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.Net5SkinsT.Checked = false;
			this.Net5SkinsT.Enabled = false;
			this.Net5SkinsT.Location = new System.Drawing.Point(152, 3);
			this.Net5SkinsT.Name = "Net5SkinsT";
			this.Net5SkinsT.Size = new System.Drawing.Size(140, 28);
			this.Net5SkinsT.TabIndex = 1;
			// 
			// Gross5SkinsT
			// 
			this.Gross5SkinsT.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.Gross5SkinsT.Checked = false;
			this.Gross5SkinsT.Enabled = false;
			this.Gross5SkinsT.Location = new System.Drawing.Point(8, 4);
			this.Gross5SkinsT.Name = "Gross5SkinsT";
			this.Gross5SkinsT.Size = new System.Drawing.Size(140, 28);
			this.Gross5SkinsT.TabIndex = 0;
			// 
			// panel19
			// 
			this.panel19.BackColor = System.Drawing.Color.Silver;
			this.panel19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel19.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.Net5Scramble,
																				  this.Gross5Scramble,
																				  this.Net5Drives,
																				  this.Gross5Drives});
			this.panel19.Location = new System.Drawing.Point(600, 476);
			this.panel19.Name = "panel19";
			this.panel19.Size = new System.Drawing.Size(380, 88);
			this.panel19.TabIndex = 10;
			// 
			// Net5Scramble
			// 
			this.Net5Scramble.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.Net5Scramble.Checked = false;
			this.Net5Scramble.Enabled = false;
			this.Net5Scramble.Location = new System.Drawing.Point(152, 8);
			this.Net5Scramble.Name = "Net5Scramble";
			this.Net5Scramble.Size = new System.Drawing.Size(140, 32);
			this.Net5Scramble.TabIndex = 2;
			// 
			// Gross5Scramble
			// 
			this.Gross5Scramble.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.Gross5Scramble.Checked = false;
			this.Gross5Scramble.Enabled = false;
			this.Gross5Scramble.Location = new System.Drawing.Point(7, 8);
			this.Gross5Scramble.Name = "Gross5Scramble";
			this.Gross5Scramble.Size = new System.Drawing.Size(140, 32);
			this.Gross5Scramble.TabIndex = 0;
			// 
			// Net5Drives
			// 
			this.Net5Drives.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.Net5Drives.Enabled = false;
			this.Net5Drives.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Net5Drives.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Net5Drives.Location = new System.Drawing.Point(152, 48);
			this.Net5Drives.Name = "Net5Drives";
			this.Net5Drives.Size = new System.Drawing.Size(140, 28);
			this.Net5Drives.TabIndex = 3;
			this.Net5Drives.Text = "0";
			this.Net5Drives.Click += new System.EventHandler(this.Net5Drives_Click);
			// 
			// Gross5Drives
			// 
			this.Gross5Drives.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.Gross5Drives.Enabled = false;
			this.Gross5Drives.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Gross5Drives.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Gross5Drives.Location = new System.Drawing.Point(7, 48);
			this.Gross5Drives.Name = "Gross5Drives";
			this.Gross5Drives.Size = new System.Drawing.Size(140, 28);
			this.Gross5Drives.TabIndex = 1;
			this.Gross5Drives.Text = "0";
			this.Gross5Drives.Click += new System.EventHandler(this.Gross5Drives_Click);
			// 
			// panel20
			// 
			this.panel20.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.panel20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel20.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.lbl2Player});
			this.panel20.Enabled = false;
			this.panel20.Location = new System.Drawing.Point(296, 120);
			this.panel20.Name = "panel20";
			this.panel20.Size = new System.Drawing.Size(304, 32);
			this.panel20.TabIndex = 69;
			// 
			// lbl2Player
			// 
			this.lbl2Player.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.lbl2Player.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbl2Player.Location = new System.Drawing.Point(73, 0);
			this.lbl2Player.Name = "lbl2Player";
			this.lbl2Player.Size = new System.Drawing.Size(157, 28);
			this.lbl2Player.TabIndex = 44;
			this.lbl2Player.Text = "2 Players";
			this.lbl2Player.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel21
			// 
			this.panel21.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.panel21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel21.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.lblHdcp1,
																				  this.lbl2to5Players});
			this.panel21.Enabled = false;
			this.panel21.Location = new System.Drawing.Point(600, 120);
			this.panel21.Name = "panel21";
			this.panel21.Size = new System.Drawing.Size(380, 32);
			this.panel21.TabIndex = 70;
			// 
			// lbl2to5Players
			// 
			this.lbl2to5Players.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.lbl2to5Players.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbl2to5Players.Location = new System.Drawing.Point(104, 0);
			this.lbl2to5Players.Name = "lbl2to5Players";
			this.lbl2to5Players.Size = new System.Drawing.Size(171, 28);
			this.lbl2to5Players.TabIndex = 45;
			this.lbl2to5Players.Text = "2-5 Players";
			this.lbl2to5Players.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnAdd
			// 
			this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnAdd.Location = new System.Drawing.Point(16, 616);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(140, 56);
			this.btnAdd.TabIndex = 11;
			this.btnAdd.Text = "&Add";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(165, 616);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(140, 56);
			this.btnCancel.TabIndex = 12;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnEdit.Location = new System.Drawing.Point(314, 616);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(140, 56);
			this.btnEdit.TabIndex = 13;
			this.btnEdit.Text = "&Modify";
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnSave
			// 
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnSave.Location = new System.Drawing.Point(463, 616);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(140, 56);
			this.btnSave.TabIndex = 14;
			this.btnSave.Text = "&Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnDelete.Location = new System.Drawing.Point(612, 616);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(140, 56);
			this.btnDelete.TabIndex = 15;
			this.btnDelete.Text = "&Delete";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// lblHdcp1
			// 
			this.lblHdcp1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.lblHdcp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblHdcp1.Location = new System.Drawing.Point(296, 7);
			this.lblHdcp1.Name = "lblHdcp1";
			this.lblHdcp1.Size = new System.Drawing.Size(76, 17);
			this.lblHdcp1.TabIndex = 47;
			this.lblHdcp1.Text = "Hdcp %";
			this.lblHdcp1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(216, 92);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 20);
			this.label1.TabIndex = 48;
			this.label1.Text = "Hdcp %";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnHdcp2
			// 
			this.btnHdcp2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.btnHdcp2.Enabled = false;
			this.btnHdcp2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnHdcp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnHdcp2.Location = new System.Drawing.Point(304, 8);
			this.btnHdcp2.Name = "btnHdcp2";
			this.btnHdcp2.Size = new System.Drawing.Size(64, 44);
			this.btnHdcp2.TabIndex = 47;
			this.btnHdcp2.Text = "100";
			this.btnHdcp2.Click += new System.EventHandler(this.btnHdcp2_Click);
			// 
			// btnHdcp1
			// 
			this.btnHdcp1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.btnHdcp1.Enabled = false;
			this.btnHdcp1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnHdcp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnHdcp1.Location = new System.Drawing.Point(224, 116);
			this.btnHdcp1.Name = "btnHdcp1";
			this.btnHdcp1.Size = new System.Drawing.Size(64, 44);
			this.btnHdcp1.TabIndex = 49;
			this.btnHdcp1.Text = "100";
			this.btnHdcp1.Click += new System.EventHandler(this.btnHdcp1_Click);
			// 
			// btnHdcp5
			// 
			this.btnHdcp5.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.btnHdcp5.Enabled = false;
			this.btnHdcp5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnHdcp5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnHdcp5.Location = new System.Drawing.Point(304, 3);
			this.btnHdcp5.Name = "btnHdcp5";
			this.btnHdcp5.Size = new System.Drawing.Size(64, 28);
			this.btnHdcp5.TabIndex = 48;
			this.btnHdcp5.Text = "100";
			this.btnHdcp5.Click += new System.EventHandler(this.btnHdcp5_Click);
			// 
			// TourLiteMaintenance
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 17);
			this.ClientSize = new System.Drawing.Size(994, 688);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnDelete,
																		  this.btnSave,
																		  this.btnEdit,
																		  this.btnCancel,
																		  this.btnAdd,
																		  this.btnExit,
																		  this.panel1,
																		  this.panel2,
																		  this.panel3,
																		  this.panel5,
																		  this.panel6,
																		  this.panel7,
																		  this.panel8,
																		  this.panel4,
																		  this.panel9,
																		  this.panel10,
																		  this.panel11,
																		  this.panel12,
																		  this.panel13,
																		  this.panel14,
																		  this.panel15,
																		  this.panel16,
																		  this.panel17,
																		  this.panel18,
																		  this.panel19,
																		  this.panel21,
																		  this.panel20});
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "TourLiteMaintenance";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Tournament Lite Maintenance";
			this.Load += new System.EventHandler(this.TourLiteMaintenance_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel12.ResumeLayout(false);
			this.panel13.ResumeLayout(false);
			this.panel14.ResumeLayout(false);
			this.panel15.ResumeLayout(false);
			this.panel16.ResumeLayout(false);
			this.panel17.ResumeLayout(false);
			this.panel18.ResumeLayout(false);
			this.panel19.ResumeLayout(false);
			this.panel20.ResumeLayout(false);
			this.panel21.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void TourLiteMaintenance_Load(object sender, System.EventArgs e)
		{
			//this.lblTournamentSelected.Text = TournamentSelectedName;
			UpdateButtonsToAED();
			SetFieldsToReadOnly();

			// Get Selected Tournament Definitions
			tlAdapter = espDB.GetSelectedTournament(this.TournamentID);
			tlgAdapter = espDB.GetSelectedTournamentGames(this.TournamentID);
			ds = espDB.GetDS();

			DisplayTournamentData();
			DisplayTournamentGameData();
		}

		private void DisplayTournamentData()
		{
			DateTime date;
			// Get Tournament Data
			DataTable dt;
			DataRow[] dr;

			dt = ds.Tables["AEDTournament"];
			dr = dt.Select();
			if (dr.Length > 0)
			{
			    try
			    {
                    txtTournamentName.Text = dr[0]["Name"].ToString();
                }
			    catch
			    {
                    txtTournamentName.Text = dr[0]["TournamentName"].ToString();
                }
				date = (DateTime)dr[0]["DateStart"];
				txtStartDate.Text = date.ToShortDateString();
				date = (DateTime)dr[0]["DateEnd"];
				txtEndDate.Text = date.ToShortDateString();
			}
			else
			{
				// There are no tournaments defined
				txtTournamentName.Text = "There are no Tournaments defined.";
				txtStartDate.Text = "";
				txtEndDate.Text = "";
			}
			dr = null;
			dt = null;
		}

		private void DisplayTournamentGameData()
		{
			// Get Tournament Data
			bool gross = false;
			bool net = false;
			byte maxPlayers = 0;
			short percent = 100;

			DataTable dt;
			DataRow[] dr;

			dt = ds.Tables["TourLiteGames"];
			dr = dt.Select();
			if (dr.Length > 0)
			{
				for (int i=0;i<dr.Length;i++)
				{
					switch ((byte)dr[i]["GameType"])
					{
						case (byte)TOURNAMENT_GAME_TYPE.TeamBestBall2Man:
							DisplayGrossNet((byte)dr[i]["Ball1GrossNet"], true, ref gross, ref net);
							Gross21.Checked = gross;
							Net21.Checked = net;
							DisplayGrossNet((byte)dr[i]["Ball2GrossNet"], true, ref gross, ref net);
							Gross22.Checked = gross;
							Net22.Checked = net;
							percent = (short)dr[i]["HandicapPercent"];
							btnHdcp1.Text = percent.ToString();
							break;
						case (byte)TOURNAMENT_GAME_TYPE.TeamBestBall:
							DisplayGrossNet((byte)dr[i]["Ball1GrossNet"], true, ref gross, ref net);
							Gross51.Checked = gross;
							Net51.Checked = net;
							DisplayGrossNet((byte)dr[i]["Ball2GrossNet"], true, ref gross, ref net);
							Gross52.Checked = gross;
							Net52.Checked = net;
							DisplayGrossNet((byte)dr[i]["Ball3GrossNet"], true, ref gross, ref net);
							Gross53.Checked = gross;
							Net53.Checked = net;
							DisplayGrossNet((byte)dr[i]["Ball4GrossNet"], true, ref gross, ref net);
							Gross54.Checked = gross;
							Net54.Checked = net;
							DisplayGrossNet((byte)dr[i]["Ball5GrossNet"], true, ref gross, ref net);
							Gross55.Checked = gross;
							Net55.Checked = net;
							maxPlayers = (byte)dr[i]["TeamSize"];
							maxPlayersBB.Text = maxPlayers.ToString();
							percent = (short)dr[i]["HandicapPercent"];
							btnHdcp2.Text = percent.ToString();
							break;
						case (byte)TOURNAMENT_GAME_TYPE.Rotation123:
							break;
						case (byte)TOURNAMENT_GAME_TYPE.Rotation321:
							break;
						case (byte)TOURNAMENT_GAME_TYPE.IndividualSkins:
							DisplayGrossNet((byte)dr[i]["Ball1GrossNet"], false, ref gross, ref net);
							Gross5SkinsI.Checked = gross;
							Net5SkinsI.Checked = net;
							percent = (short)dr[i]["HandicapPercent"];
							btnHdcp5.Text = percent.ToString();
							break;
						case (byte)TOURNAMENT_GAME_TYPE.TeamSkins:
							if ((byte)dr[i]["TeamSize"] == 2)
							{
								DisplayGrossNet((byte)dr[i]["Ball1GrossNet"], true, ref gross, ref net);
								Gross2SkinsT.Checked = gross;
								Net2SkinsT.Checked = net;
							}
							else
							{
								DisplayGrossNet((byte)dr[i]["Ball1GrossNet"], true, ref gross, ref net);
								Gross5SkinsT.Checked = gross;
								Net5SkinsT.Checked = net;
							}
							break;
						case (byte)TOURNAMENT_GAME_TYPE.Scramble:
							break;
					}
				}
			}
			else
			{
				// There is no tournament defined, clear all fields.
				Gross21.Checked = gross;
				Net21.Checked = net;
				Gross22.Checked = gross;
				Net22.Checked = net;
				//
				Gross51.Checked = gross;
				Net51.Checked = net;
				Gross52.Checked = gross;
				Net52.Checked = net;
				Gross53.Checked = gross;
				Net53.Checked = net;
				Gross54.Checked = gross;
				Net54.Checked = net;
				Gross55.Checked = gross;
				Net55.Checked = net;
				maxPlayers = 5;
				maxPlayersBB.Text = maxPlayers.ToString();
				//
				Gross5SkinsI.Checked = gross;
				Net5SkinsI.Checked = net;
				//
				Gross2SkinsT.Checked = gross;
				Net2SkinsT.Checked = net;
				Gross5SkinsT.Checked = gross;
				Net5SkinsT.Checked = net;
				UpdateButtonsToAED();
				this.Refresh();
			}
			dr = null;
			dt.Dispose();
		}

		private void DisplayGrossNet(byte gn,bool toggle,ref bool gross,ref bool net)
		{
			switch (gn)
			{
				case 1:
					gross = true;
					if (toggle) net = false;
					break;
				case 2:
					net = true;
					if (toggle) gross = false;
					break;
				default:
					gross = false;
					net = false;
					break;
			}
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void Gross2Drives_Click(object sender, System.EventArgs e)
		{
			// Popup Screen to select the number of drives
			TenKeyPad tenKey = new TenKeyPad();
			tenKey.MaxValue = 9;
			tenKey.Title = "Select Number of Drives.";
			tenKey.WarnHeader = "Invalid Number of Drives";
			tenKey.WarnMessage1 = "The maximum number of Drives is ";
			tenKey.ShowDialog();
			Gross2Drives.Text = tenKey.Number.ToString();
			tenKey = null;
		}

		private void Net2Drives_Click(object sender, System.EventArgs e)
		{
			// Popup Screen to select the number of drives
			TenKeyPad tenKey = new TenKeyPad();
			tenKey.MaxValue = 9;
			tenKey.Title = "Select Number of Drives.";
			tenKey.WarnHeader = "Invalid Number of Drives";
			tenKey.WarnMessage1 = "The maximum number of Drives is ";
			tenKey.ShowDialog();
			Net2Drives.Text = tenKey.Number.ToString();
			tenKey = null;
		}

		private void Gross5Drives_Click(object sender, System.EventArgs e)
		{
			// Popup Screen to select the number of drives
			TenKeyPad tenKey = new TenKeyPad();
			tenKey.MaxValue = 9;
			tenKey.Title = "Select Number of Drives.";
			tenKey.WarnHeader = "Invalid Number of Drives";
			tenKey.WarnMessage1 = "The maximum number of Drives is ";
			tenKey.ShowDialog();
			Gross5Drives.Text = tenKey.Number.ToString();
			tenKey = null;
		}

		private void Net5Drives_Click(object sender, System.EventArgs e)
		{
			// Popup Screen to select the number of drives
			TenKeyPad tenKey = new TenKeyPad();
			tenKey.MaxValue = 9;
			tenKey.Title = "Select Number of Drives.";
			tenKey.WarnHeader = "Invalid Number of Drives";
			tenKey.WarnMessage1 = "The maximum number of Drives is ";
			tenKey.ShowDialog();
			Net5Drives.Text = tenKey.Number.ToString();
			tenKey = null;
		}

		private void btnDate_Click(object sender, System.EventArgs e)
		{
			TourLiteDates getDates = new TourLiteDates();
			getDates.ShowDialog();
			if (getDates.StartDate != "") txtStartDate.Text = getDates.StartDate;
			if (getDates.EndDate != "") txtEndDate.Text = getDates.EndDate;
			getDates = null;
		}

		// ============================
		// EDIT Control Functions
		// ============================
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			// Update Button Status
			UpdateButtonsToSC();

			// Update Fields to allow Edit
			SetFieldsToEdit();
			AddMode = false;
			txtTournamentName.Focus();
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			// Update Button Status
			UpdateButtonsToSC();

			// Update Fields to allow a record to be added and clear all existing values
			SetFieldsToEdit();
			txtTournamentName.Text = "";
			txtStartDate.Text = DateTime.Today.ToShortDateString();
			txtEndDate.Text = txtStartDate.Text;
			//
			Gross21.Checked = false;
			Gross22.Checked = false;
			Net21.Checked = false;
			Net22.Checked = false;
			//
			Gross51.Checked = false;
			Gross52.Checked = false;
			Gross53.Checked = false;
			Gross54.Checked = false;
			Gross55.Checked = false;
			Net51.Checked = false;
			Net52.Checked = false;
			Net53.Checked = false;
			Net54.Checked = false;
			Net55.Checked = false;
			maxPlayersBB.Text = "4";
			//
			Gross5SkinsI.Checked = false;
			Net5SkinsI.Checked = false;
			//
			AddMode = true;
			this.Refresh();
			txtTournamentName.Focus();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			// Reset Changes to Original Values, if any were made
			CancelChanges();

			// Update Button Status
			UpdateButtonsToAED();

			// Update Fields to Read Only
			SetFieldsToReadOnly();

		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			// Save Changes, if any were made
			if (SaveChanges())
			{
				// Update Button Status
				UpdateButtonsToAED();

				// Update Fields to Read Only
				SetFieldsToReadOnly();
				AddMode = false;
			}
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			TouchMessageBox confirm = new TouchMessageBox();
			confirm.Header = "Delete Confirmation";
			confirm.Message = "Do you really want to DELETE Tournament {"+txtTournamentName.Text.ToString()+"}?";
			confirm.Confirm = "&Yes";
			confirm.Cancel = "&No";
			confirm.ShowDialog();
			if (confirm.Return)
			{
				DataTable dt;
				DataRow [] dr;
		
				dt = ds.Tables["AEDTournament"];
				dr = dt.Select();
				dr[0].Delete();
				try
				{
					tlAdapter.Update(ds,"AEDTournament");
				}
				catch (OleDbException ee)
				{
					MessageBox.Show(ee.Message,"Update");
				}
				//
				// Refresh Tournament List
				espDB.UpdateTournamentsTable();
				dt = ds.Tables["Tournaments"];
				dr = dt.Select();
				if (dr.Length > 0)
					this.TournamentID = (int)dr[0]["TournamentID"];
				else
					this.TournamentID = 0;
				//
				// Get Selected Tournament Definitions
				tlAdapter = espDB.GetSelectedTournament(this.TournamentID);
				tlgAdapter = espDB.GetSelectedTournamentGames(this.TournamentID);
				//
				DisplayTournamentData();
				DisplayTournamentGameData();
			}
			confirm.Dispose();
		}

		private void CancelChanges()
		{
			/*
			dsBatch.Tables["Batch"].RejectChanges();
			*/
			DisplayTournamentData();
			DisplayTournamentGameData();
			AddMode = false;
		}

		private bool SaveChanges()
		{
			byte temp = 0;
			Guid myguid = Guid.NewGuid();
			DataTable dt;
			DataRow [] dr;
			DataRow addrow;

			if (AddMode)
			{
				// Add a Dummy Row to Tournaments
				dt = ds.Tables["AEDTournament"];
				addrow = dt.NewRow();
				addrow["Name"] = txtTournamentName.Text;
				addrow["DateStart"] = DateTime.Parse(txtStartDate.Text);
				addrow["DateEnd"] = DateTime.Parse(txtEndDate.Text);
				addrow["NumberOfRounds"] = 1;
				addrow["NumberOfDivisions"] = 1;
				addrow["TournamentGuid"] = myguid;
				dt.Rows.Add(addrow);
				try
				{
					tlAdapter.Update(ds,"AEDTournament");
				}
				catch (OleDbException e)
				{
					MessageBox.Show(e.Message,"Update");
				}

				// Refresh Tournament List
				espDB.UpdateTournamentsTable();
				//
				// Locate new Tournament and set ID
				dt = ds.Tables["Tournaments"];
				string sel = "TournamentGuid='"+myguid.ToString("D")+"'";
				dr = dt.Select(sel);
				//
				this.TournamentID = (int)dr[0]["TournamentID"];
				// Update HHID
				espDB.UpdateTourLiteHHID(this.TournamentID);
				//
				// New Tournament added
				//
				// Get Selected Tournament Definitions
				tlAdapter = espDB.GetSelectedTournament(this.TournamentID);
				tlgAdapter = espDB.GetSelectedTournamentGames(this.TournamentID);
			}
			else
			{
				// Update Tournament MASTER record
				dt = ds.Tables["AEDTournament"];
				dr = dt.Select();
				dr[0].BeginEdit();
				dr[0]["Name"] = txtTournamentName.Text;
				dr[0]["DateStart"] = DateTime.Parse(txtStartDate.Text);
				dr[0]["DateEnd"] = DateTime.Parse(txtEndDate.Text);
				dr[0]["HHID"] = "TL"+TournamentID.ToString();
				dr[0].EndEdit();
				try
				{
					tlAdapter.Update(ds,"AEDTournament");
				}
				catch (OleDbException e)
				{
					MessageBox.Show(e.Message,"Update");
				}

				// Refresh Tournament List
				espDB.UpdateTournamentsTable();
			}
			//
			// UPDATE/ADD Game Records
			//
			dt = ds.Tables["TourLiteGames"];
			//==========================Start=Individual=Skins==============
			// NOTE:	when saving individual skins, there can be two games.  Always
			//					remove existing games and re-add as necessary.  This is fast
			//					and easier than figuring out which record needs to be updated,etc.
			//
			temp = (byte)TOURNAMENT_GAME_TYPE.IndividualSkins;
			dr = dt.Select("GameType="+temp.ToString());
			// Remove all previously defined  INDIVIDUAL SKINS game(s).
			if (dr.Length > 0)
			{
				for (int i=0;i<dr.Length;i++)
				{
					dr[i].Delete();
				}
			}
			// ADD
			if (Gross5SkinsI.Checked)
			{
				// Add Game
				addrow = dt.NewRow();
				addrow["TournamentID"] = TournamentID;
				addrow["TeamGame"] = false;
				addrow["TeamSize"] = 5;
				addrow["NumberOfTeams"] = 1; // Field Not Currently Used on HH (1/27/03MCL)
				addrow["GameType"] = (byte)TOURNAMENT_GAME_TYPE.IndividualSkins;
				addrow["DrivesPerPlayer"] = 0;
				addrow["GameFlags"] = Global.GAME_FLAG_GROSS | Global.GAME_FLAG_ONE_TEAM;
				addrow["Ball1GrossNet"] = 1;
				addrow["Ball2GrossNet"] = 0;
				addrow["Ball3GrossNet"] = 0;
				addrow["Ball4GrossNet"] = 0;
				addrow["Ball5GrossNet"] = 0;
				addrow["HandicapPercent"] = Int16.Parse(btnHdcp5.Text);
				dt.Rows.Add(addrow);
			}
			if (Net5SkinsI.Checked)
			{
				// Add Game
				addrow = dt.NewRow();
				addrow["TournamentID"] = TournamentID;
				addrow["TeamGame"] = false;
				addrow["TeamSize"] = 5;
				addrow["NumberOfTeams"] = 1; // Field Not Currently Used on HH (1/27/03MCL)
				addrow["GameType"] = (byte)TOURNAMENT_GAME_TYPE.IndividualSkins;
				addrow["DrivesPerPlayer"] = 0;
				addrow["GameFlags"] = Global.GAME_FLAG_NET | Global.GAME_FLAG_ONE_TEAM;
				addrow["Ball1GrossNet"] = 2;
				addrow["Ball2GrossNet"] = 0;
				addrow["Ball3GrossNet"] = 0;
				addrow["Ball4GrossNet"] = 0;
				addrow["Ball5GrossNet"] = 0;
				addrow["HandicapPercent"] = Int16.Parse(btnHdcp5.Text);
				dt.Rows.Add(addrow);
			}
			//==========================End=Individual=Skins==============
			//
			//==========================Start=Best=Ball============
			//==========================Start=2=Man=Best=Ball============
			// NOTE:	when saving games always 	remove existing games and re-add as 
			//					necessary.  This is fast and easier than figuring out which record 
			//					needs to be updated,etc.
			//
			temp = (byte)TOURNAMENT_GAME_TYPE.TeamBestBall2Man;
			dr = dt.Select("GameType="+temp.ToString());
			// REMOVE all Best Ball game(s).
			if (dr.Length > 0)
			{
				for (int i=0;i<dr.Length;i++)
				{
					dr[i].Delete();
				}
			}
			if (Gross21.Checked | Net21.Checked)
			{
				// Add Game
				addrow = dt.NewRow();
				addrow["TournamentID"] = TournamentID;
				addrow["TeamGame"] = true;
				addrow["TeamSize"] = 2;
				addrow["NumberOfTeams"] = 1; // Field Not Currently Used on HH (1/27/03MCL)
				addrow["GameType"] = (byte)TOURNAMENT_GAME_TYPE.TeamBestBall2Man;
				addrow["DrivesPerPlayer"] = 0;
				addrow["GameFlags"] =  Global.GAME_FLAG_ONE_TEAM;
				addrow["Ball1GrossNet"] = (Gross21.Checked?1:(Net21.Checked?2:0));
				addrow["Ball2GrossNet"] = (Gross22.Checked?1:(Net22.Checked?2:0));
				addrow["Ball3GrossNet"] = 0;
				addrow["Ball4GrossNet"] = 0;
				addrow["Ball5GrossNet"] = 0;
				addrow["HandicapPercent"] = Int16.Parse(btnHdcp1.Text);
				dt.Rows.Add(addrow);
			}
			//==========================End=2=Man=Best=Ball=============
			//
			//==========================Start=2-5=Man=Best=Ball============
			// NOTE:	when saving games always 	remove existing games and re-add as 
			//					necessary.  This is fast and easier than figuring out which record 
			//					needs to be updated,etc.
			//
			temp = (byte)TOURNAMENT_GAME_TYPE.TeamBestBall;
			dr = dt.Select("GameType="+temp.ToString());
			// REMOVE all Best Ball game(s).
			if (dr.Length > 0)
			{
				for (int i=0;i<dr.Length;i++)
				{
					dr[i].Delete();
				}
			}
			if (Gross51.Checked | Net51.Checked)
			{
				// User is defining/updating a 2-5-Man Best Ball game.  If previously defined,
				// Check settings and update if necessary.  If not previously defined, ADD.
				// Add Game
				addrow = dt.NewRow();
				addrow["TournamentID"] = TournamentID;
				addrow["TeamGame"] = true;
				addrow["TeamSize"] = Byte.Parse(maxPlayersBB.Text.ToString());
				addrow["NumberOfTeams"] = 1; // Field Not Currently Used on HH (1/27/03MCL)
				addrow["GameType"] = (byte)TOURNAMENT_GAME_TYPE.TeamBestBall;
				addrow["DrivesPerPlayer"] = 0;
				addrow["GameFlags"] = Global.GAME_FLAG_ONE_TEAM;
				addrow["Ball1GrossNet"] = (Gross51.Checked?1:(Net51.Checked?2:0));
				addrow["Ball2GrossNet"] = (Gross52.Checked?1:(Net52.Checked?2:0));
				addrow["Ball3GrossNet"] = (Gross53.Checked?1:(Net53.Checked?2:0));
				addrow["Ball4GrossNet"] = (Gross54.Checked?1:(Net54.Checked?2:0));
				addrow["Ball5GrossNet"] = (Gross55.Checked?1:(Net55.Checked?2:0));
				addrow["HandicapPercent"] = Int16.Parse(btnHdcp2.Text);
				dt.Rows.Add(addrow);
			}
			//==========================End=4=Man=Best=Ball============
			//==========================End=Best=Ball============
			//
			//==========================Start=1-2-3=Rotation==============
			// <Not Defined>
			//==========================End=1-2-3=Rotation==============
			//
			//==========================Start=3-2-1=Rotation==============
			// <Not Defined>
			//==========================End=3-2-1=Rotation==============
			//
			//==========================Start=Team=Skins===============
			// <Not Defined>
			//==========================End=Team=Skins===============
			//
			//==========================Start=Scramble==================
			// <Not Defined>
			//==========================End=Scramble==================
			//
			// Update Tournament Lite Games
			//
			try
			{
				tlgAdapter.Update(ds,"TourLiteGames");
			}
			catch (OleDbException e)
			{
				MessageBox.Show(e.Message,"Update");
			}
			//
			// Refresh Tournament(s) and Tournament Games
			// Get Selected Tournament Definitions
			tlAdapter = espDB.GetSelectedTournament(this.TournamentID);
			tlgAdapter = espDB.GetSelectedTournamentGames(this.TournamentID);

			DisplayTournamentData();
			DisplayTournamentGameData();

			return true;
			/*
			int recsupdated = 0;

			// Save Edits
			this.BindingContext[dsBatch,"Batch"].EndCurrentEdit();

			// Update Data Source(Table)
			recsupdated = this.daBatch.Update(dsBatch,"Batch");
			*/
		}

		private void SetFieldsToEdit()
		{
			txtTournamentName.ReadOnly = false;
			txtTournamentName.TabStop = true;
			btnDate.Enabled = true;
			// 2-Man BB
			Gross21.Enabled = true;
			Gross21.TabStop = true;
			Gross22.Enabled = true;
			Gross22.TabStop = true;
			Net21.Enabled = true;
			Net21.TabStop = true;
			Net22.Enabled = true;
			Net22.TabStop = true;
			// 3-5 Man BB
			Gross51.Enabled = true;
			Gross51.TabStop = true;
			Gross52.Enabled = true;
			Gross52.TabStop = true;
			Gross53.Enabled = true;
			Gross53.TabStop = true;
			Gross54.Enabled = true;
			Gross54.TabStop = true;
			Gross55.Enabled = true;
			Gross55.TabStop = true;
			Net51.Enabled = true;
			Net51.TabStop = true;
			Net52.Enabled = true;
			Net52.TabStop = true;
			Net53.Enabled = true;
			Net53.TabStop = true;
			Net54.Enabled = true;
			Net54.TabStop = true;
			Net55.Enabled = true;
			Net55.TabStop = true;
			maxPlayersBB.Enabled = true;
			//
			Gross5SkinsI.Enabled = true;
			Gross5SkinsI.TabStop = true;
			Net5SkinsI.Enabled = true;
			Net5SkinsI.TabStop = true;
			//
			btnHdcp1.Enabled = true;
			btnHdcp2.Enabled = true;
			btnHdcp5.Enabled = true;
		}

		private void SetFieldsToReadOnly()
		{
			txtTournamentName.ReadOnly = true;
			txtTournamentName.TabStop = false;
			btnDate.Enabled = false;
			// 2 Man BB
			Gross21.Enabled = false;
			Gross21.TabStop = false;
			Gross22.Enabled = false;
			Gross22.TabStop = false;
			Net21.Enabled = false;
			Net21.TabStop = false;
			Net22.Enabled = false;
			Net22.TabStop = false;
			// 3-5 Man BB
			Gross51.Enabled = false;
			Gross51.TabStop = false;
			Gross52.Enabled = false;
			Gross52.TabStop = false;
			Gross53.Enabled = false;
			Gross53.TabStop = false;
			Gross54.Enabled = false;
			Gross54.TabStop = false;
			Gross55.Enabled = false;
			Gross55.TabStop = false;
			Net51.Enabled = false;
			Net51.TabStop = false;
			Net52.Enabled = false;
			Net52.TabStop = false;
			Net53.Enabled = false;
			Net53.TabStop = false;
			Net54.Enabled = false;
			Net54.TabStop = false;
			Net55.Enabled = false;
			Net55.TabStop = false;
			maxPlayersBB.Enabled = false;
			//
			Gross5SkinsI.Enabled = false;
			Gross5SkinsI.TabStop = false;
			Net5SkinsI.Enabled = false;
			Net5SkinsI.TabStop = false;
			//
			btnHdcp1.Enabled = false;
			btnHdcp2.Enabled = false;
			btnHdcp5.Enabled = false;
		}

		private void UpdateButtonsToSC()
		{
			btnAdd.Visible = false;
			btnEdit.Visible = false;
			btnDelete.Visible = false;
			btnCancel.Visible = true;
			btnSave.Visible = true;
			btnExit.Visible = false;
		}

		private void UpdateButtonsToAED()
		{
			btnAdd.Visible = true;
			if (TournamentID > 0)btnEdit.Visible = true;
			else btnEdit.Visible = false;
			if (TournamentID > 0)btnDelete.Visible = true;
			else btnDelete.Visible = false;
			btnCancel.Visible = false;
			btnSave.Visible = false;
			btnExit.Visible = true;
		}

		private void Gross21_Click(object sender, System.EventArgs e)
		{
			if ( !(Gross21.Checked | Net21.Checked) )
			{
				// Make sure that Ball 2 options are removed
				Gross22.Checked = false;
				Net22.Checked = false;
			}

			if (Gross21.Checked)
			{
				Net21.Checked = false;
			}
			this.Refresh();
		}

		private void Net21_Click(object sender, System.EventArgs e)
		{
			if ( !(Gross21.Checked | Net21.Checked) )
			{
				// Make sure that Ball 2 options are removed
				Gross22.Checked = false;
				Net22.Checked = false;
			}

			if (Net21.Checked)
			{
				Gross21.Checked = false;
			}
			this.Refresh();
		}

		private void Gross22_Click(object sender, System.EventArgs e)
		{
			if (Gross21.Checked | Net21.Checked)
			{
				if (Gross22.Checked) 
				{
					Net22.Checked = false;
					this.Refresh();
				}
			}
			else
			{
				//MessageBox.Show("You must select the BALL 1 Gross OR Net option before selecting the BALL 2 option.", "Ball 2 Gross");
				Gross22.Checked = false;
				this.Refresh();
			}
		}

		private void Net22_Click(object sender, System.EventArgs e)
		{
			if (Gross21.Checked | Net21.Checked)
			{
				if (Net22.Checked) 
				{
					Gross22.Checked = false;
					this.Refresh();
				}
			}
			else
			{
				//MessageBox.Show("You must select the BALL 1 Gross OR Net option before selecting the BALL 2 option.", "Ball 2 Net");
				Net22.Checked = false;
				this.Refresh();
			}
		}

		private void Gross51_Click(object sender, System.EventArgs e)
		{
			if ( !(Gross51.Checked | Net51.Checked) )
			{
				// Make sure that Ball 2,3,4,5 options are removed
				Gross52.Checked = false;
				Net52.Checked = false;
				Gross53.Checked = false;
				Net53.Checked = false;
				Gross54.Checked = false;
				Net54.Checked = false;
				Gross55.Checked = false;
				Net55.Checked = false;
			}

			if (Gross51.Checked)
			{
				Net51.Checked = false;
			}
			this.Refresh();
		}

		private void Net51_Click(object sender, System.EventArgs e)
		{
			if ( !(Gross51.Checked | Net51.Checked) )
			{
				// Make sure that Ball 2,3,4,5 options are removed
				Gross52.Checked = false;
				Net52.Checked = false;
				Gross53.Checked = false;
				Net53.Checked = false;
				Gross54.Checked = false;
				Net54.Checked = false;
				Gross55.Checked = false;
				Net55.Checked = false;
			}

			if (Net51.Checked)
			{
				Gross51.Checked = false;
			}
			this.Refresh();
		}

		private void Gross52_Click(object sender, System.EventArgs e)
		{
			if ( !(Gross52.Checked | Net52.Checked) )
			{
				// Make sure that Ball 3,4,5 options are removed
				Gross53.Checked = false;
				Net53.Checked = false;
				Gross54.Checked = false;
				Net54.Checked = false;
				Gross55.Checked = false;
				Net55.Checked = false;
			}

			if (Gross51.Checked | Net51.Checked)
			{
				if (Gross52.Checked)
				{
					Net52.Checked = false;
				}
				this.Refresh();
			}
			else
			{
				//MessageBox.Show("You must select the BALL 1 Gross OR Net option before selecting the BALL 2 option.", "Ball 2 Gross");
				Gross52.Checked = false;
				this.Refresh();
			}
		}

		private void Net52_Click(object sender, System.EventArgs e)
		{
			if ( !(Gross52.Checked | Net52.Checked) )
			{
				// Make sure that Ball 3,4,5 options are removed
				Gross53.Checked = false;
				Net53.Checked = false;
				Gross54.Checked = false;
				Net54.Checked = false;
				Gross55.Checked = false;
				Net55.Checked = false;
			}

			if (Gross51.Checked | Net51.Checked)
			{
				if (Net52.Checked)
				{
					Gross52.Checked = false;
				}
				this.Refresh();
			}
			else
			{
				//MessageBox.Show("You must select the BALL 1 Gross OR Net option before selecting the BALL 2 option.", "Ball 2 Net");
				Net52.Checked = false;
				this.Refresh();
			}
		}

		private void Gross53_Click(object sender, System.EventArgs e)
		{
			if ( !(Gross53.Checked | Net53.Checked) )
			{
				// Make sure that Ball 4,5 options are removed
				Gross54.Checked = false;
				Net54.Checked = false;
				Gross55.Checked = false;
				Net55.Checked = false;
			}

			if (Gross52.Checked | Net52.Checked)
			{
				if (Gross53.Checked)
				{
					Net53.Checked = false;
				}
				this.Refresh();
			}
			else
			{
				//MessageBox.Show("You must select the BALL 2 Gross OR Net option before selecting the BALL 3 option.", "Ball 3 Gross");
				Gross53.Checked = false;
				this.Refresh();
			}
		}

		private void Net53_Click(object sender, System.EventArgs e)
		{
			if ( !(Gross53.Checked | Net53.Checked) )
			{
				// Make sure that Ball 4,5 options are removed
				Gross54.Checked = false;
				Net54.Checked = false;
				Gross55.Checked = false;
				Net55.Checked = false;
			}

			if (Gross52.Checked | Net52.Checked)
			{
				if (Net53.Checked)
				{
					Gross53.Checked = false;
				}
				this.Refresh();
			}
			else
			{
				//MessageBox.Show("You must select the BALL 2 Gross OR Net option before selecting the BALL 3 option.", "Ball 3 Net");
				Net53.Checked = false;
				this.Refresh();
			}
		}

		private void Gross54_Click(object sender, System.EventArgs e)
		{
			if ( !(Gross54.Checked | Net54.Checked) )
			{
				// Make sure that Ball 5 options are removed
				Gross55.Checked = false;
				Net55.Checked = false;
			}

			if (Gross53.Checked | Net53.Checked)
			{
				if (Gross54.Checked)
				{
					Net54.Checked = false;
				}
				this.Refresh();
			}
			else
			{
				//MessageBox.Show("You must select the BALL 3 Gross OR Net option before selecting the BALL 4 option.", "Ball 4 Gross");
				Gross54.Checked = false;
				this.Refresh();
			}
		}

		private void Net54_Click(object sender, System.EventArgs e)
		{
			if ( !(Gross54.Checked | Net54.Checked) )
			{
				// Make sure that Ball 5 options are removed
				Gross55.Checked = false;
				Net55.Checked = false;
			}

			if (Gross53.Checked | Net53.Checked)
			{
				if (Net54.Checked)
				{
					Gross54.Checked = false;
				}
				this.Refresh();
			}
			else
			{
				//MessageBox.Show("You must select the BALL 3 Gross OR Net option before selecting the BALL 4 option.", "Ball 4 Net");
				Net54.Checked = false;
				this.Refresh();
			}
		}

		private void Gross55_Click(object sender, System.EventArgs e)
		{
			if (Gross54.Checked | Net54.Checked)
			{
				if (Gross55.Checked)
				{
					Net55.Checked = false;
					this.Refresh();
				}
			}
			else
			{
				//MessageBox.Show("You must select the BALL 4 Gross OR Net option before selecting the BALL 5 option.", "Ball 5 Gross");
				Gross55.Checked = false;
				this.Refresh();
			}
		}

		private void Net55_Click(object sender, System.EventArgs e)
		{
			if (Gross54.Checked | Net54.Checked)
			{
				if (Net55.Checked)
				{
					Gross55.Checked = false;
					this.Refresh();
				}
			}
			else
			{
				//MessageBox.Show("You must select the BALL 4 Gross OR Net option before selecting the BALL 5 option.", "Ball 5 Net");
				Net55.Checked = false;
				this.Refresh();
			}
		}

		private void maxPlayersBB_Click(object sender, System.EventArgs e)
		{
			// Popup Screen to select the number of drives
			TenKeyPad tenKey = new TenKeyPad();
			tenKey.MinValue = 2;
			tenKey.MaxValue = 5;
			tenKey.Title = "Select the Maximum Number of Players.";
			tenKey.WarnHeader = "Invalid Number of Players";
			tenKey.WarnMessage1 = "The maximum number of Players is ";
			tenKey.WarnMessage2 = "The minimum number of Players is ";
			tenKey.ShowDialog();
			maxPlayersBB.Text = tenKey.Number.ToString();
			tenKey = null;
		}

		private void btnHdcp1_Click(object sender, System.EventArgs e)
		{
			// Popup Screen to select the handicap
			TenKeyPad tenKey = new TenKeyPad();
			tenKey.MinValue = 70;
			tenKey.MaxValue = 100;
			tenKey.Title = "Select the Handicap Percentage for this Game.";
			tenKey.WarnHeader = "Invalid Handicap";
			tenKey.WarnMessage1 = "The maximum Handicap is ";
			tenKey.WarnMessage2 = "The minimum Handicap is ";
			tenKey.ShowDialog();
			btnHdcp1.Text = tenKey.Number.ToString();
			tenKey = null;
		}

		private void btnHdcp2_Click(object sender, System.EventArgs e)
		{
			// Popup Screen to select the handicap
			TenKeyPad tenKey = new TenKeyPad();
			tenKey.MinValue = 70;
			tenKey.MaxValue = 100;
			tenKey.Title = "Select the Handicap Percentage for this Game.";
			tenKey.WarnHeader = "Invalid Handicap";
			tenKey.WarnMessage1 = "The maximum Handicap is ";
			tenKey.WarnMessage2 = "The minimum Handicap is ";
			tenKey.ShowDialog();
			btnHdcp2.Text = tenKey.Number.ToString();
			tenKey = null;
		}

		private void btnHdcp5_Click(object sender, System.EventArgs e)
		{
			// Popup Screen to select the handicap
			TenKeyPad tenKey = new TenKeyPad();
			tenKey.MinValue = 70;
			tenKey.MaxValue = 100;
			tenKey.Title = "Select the Handicap Percentage for this Game.";
			tenKey.WarnHeader = "Invalid Handicap";
			tenKey.WarnMessage1 = "The maximum Handicap is ";
			tenKey.WarnMessage2 = "The minimum Handicap is ";
			tenKey.ShowDialog();
			btnHdcp5.Text = tenKey.Number.ToString();
			tenKey = null;
		}

		// ============================
		// Property Definitions
		// ============================
		public int TournamentID
		{
			get{ return _TournamentID; }
			set{ _TournamentID = value; }
		}

		// ============================
		// ============================
	}
}
