using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ESPmanager
{
	/// <summary>
	/// Summary description for TourLitePost.
	/// </summary>
	public class TourLitePost : System.Windows.Forms.Form
	{
		private DatabaseAccessControl dac = new DatabaseAccessControl();
		private Database espDB;
		private DataSet ds;
		private DataTable dtTeeTimes;
		private int _TournamentID = 0;
		private int RoundID = 0;
		private ReportSelect rs;
		//
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Label lblSelectTeeTime;
		private System.Windows.Forms.Label lblPlayer;
		private System.Windows.Forms.Label lblGross;
		private System.Windows.Forms.Label lblHdcp;
		private System.Windows.Forms.Label lblNet;
		private System.Windows.Forms.Label lblPost;
		private System.Windows.Forms.Button btnPrint;
		private System.Windows.Forms.ListBox lbTeeTimes;
		private System.Windows.Forms.Label lblTeeTimeSelected;
		private System.Windows.Forms.Label lblCourseSelected;
		private System.Windows.Forms.Label lblTeeTime;
		private System.Windows.Forms.Label lblDate;
		private System.Windows.Forms.Label lblDateSelected;
		private System.Windows.Forms.Panel pnlHeader;
		private System.Windows.Forms.Panel pnlPlayer1;
		private System.Windows.Forms.Button btnEdit1;
		private ESPmanager.LargeCheckBox Post1;
		private System.Windows.Forms.Panel pnlPlayer3;
		private System.Windows.Forms.Panel pnlPlayer2;
		private System.Windows.Forms.Panel pnlPlayer5;
		private System.Windows.Forms.Panel pnlPlayer4;
		private System.Windows.Forms.TextBox txtPlayer1;
		private System.Windows.Forms.TextBox txtGross1;
		private System.Windows.Forms.TextBox txtHdcp1;
		private System.Windows.Forms.TextBox txtNet1;
		private System.Windows.Forms.TextBox txtNet2;
		private System.Windows.Forms.TextBox txtHdcp2;
		private System.Windows.Forms.TextBox txtGross2;
		private System.Windows.Forms.TextBox txtPlayer2;
		private System.Windows.Forms.Button btnEdit2;
		private ESPmanager.LargeCheckBox Post2;
		private System.Windows.Forms.TextBox txtNet3;
		private System.Windows.Forms.TextBox txtHdcp3;
		private System.Windows.Forms.TextBox txtGross3;
		private System.Windows.Forms.TextBox txtPlayer3;
		private System.Windows.Forms.Button btnEdit3;
		private ESPmanager.LargeCheckBox Post3;
		private System.Windows.Forms.TextBox txtNet4;
		private System.Windows.Forms.TextBox txtHdcp4;
		private System.Windows.Forms.TextBox txtGross4;
		private System.Windows.Forms.TextBox txtPlayer4;
		private System.Windows.Forms.Button btnEdit4;
		private ESPmanager.LargeCheckBox Post4;
		private System.Windows.Forms.TextBox txtNet5;
		private System.Windows.Forms.TextBox txtHdcp5;
		private System.Windows.Forms.TextBox txtGross5;
		private System.Windows.Forms.TextBox txtPlayer5;
		private System.Windows.Forms.Button btnEdit5;
		private ESPmanager.LargeCheckBox Post5;
		private System.Windows.Forms.Timer timerTeeTimes;
		private System.Windows.Forms.Button btnCompute;
		private System.Windows.Forms.Label lblComputed;
		private System.Windows.Forms.Timer timerMessage;
		private System.ComponentModel.IContainer components;

		public TourLitePost( ref Database espdb )
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
			this.btnExit = new System.Windows.Forms.Button();
			this.lblSelectTeeTime = new System.Windows.Forms.Label();
			this.lbTeeTimes = new System.Windows.Forms.ListBox();
			this.pnlHeader = new System.Windows.Forms.Panel();
			this.lblPost = new System.Windows.Forms.Label();
			this.lblNet = new System.Windows.Forms.Label();
			this.lblHdcp = new System.Windows.Forms.Label();
			this.lblGross = new System.Windows.Forms.Label();
			this.lblPlayer = new System.Windows.Forms.Label();
			this.pnlPlayer1 = new System.Windows.Forms.Panel();
			this.txtNet1 = new System.Windows.Forms.TextBox();
			this.txtHdcp1 = new System.Windows.Forms.TextBox();
			this.txtGross1 = new System.Windows.Forms.TextBox();
			this.txtPlayer1 = new System.Windows.Forms.TextBox();
			this.btnEdit1 = new System.Windows.Forms.Button();
			this.Post1 = new ESPmanager.LargeCheckBox();
			this.pnlPlayer3 = new System.Windows.Forms.Panel();
			this.txtNet3 = new System.Windows.Forms.TextBox();
			this.txtHdcp3 = new System.Windows.Forms.TextBox();
			this.txtGross3 = new System.Windows.Forms.TextBox();
			this.txtPlayer3 = new System.Windows.Forms.TextBox();
			this.btnEdit3 = new System.Windows.Forms.Button();
			this.Post3 = new ESPmanager.LargeCheckBox();
			this.pnlPlayer2 = new System.Windows.Forms.Panel();
			this.txtNet2 = new System.Windows.Forms.TextBox();
			this.txtHdcp2 = new System.Windows.Forms.TextBox();
			this.txtGross2 = new System.Windows.Forms.TextBox();
			this.txtPlayer2 = new System.Windows.Forms.TextBox();
			this.btnEdit2 = new System.Windows.Forms.Button();
			this.Post2 = new ESPmanager.LargeCheckBox();
			this.pnlPlayer5 = new System.Windows.Forms.Panel();
			this.txtNet5 = new System.Windows.Forms.TextBox();
			this.txtHdcp5 = new System.Windows.Forms.TextBox();
			this.txtGross5 = new System.Windows.Forms.TextBox();
			this.txtPlayer5 = new System.Windows.Forms.TextBox();
			this.btnEdit5 = new System.Windows.Forms.Button();
			this.Post5 = new ESPmanager.LargeCheckBox();
			this.pnlPlayer4 = new System.Windows.Forms.Panel();
			this.txtNet4 = new System.Windows.Forms.TextBox();
			this.txtHdcp4 = new System.Windows.Forms.TextBox();
			this.txtGross4 = new System.Windows.Forms.TextBox();
			this.txtPlayer4 = new System.Windows.Forms.TextBox();
			this.btnEdit4 = new System.Windows.Forms.Button();
			this.Post4 = new ESPmanager.LargeCheckBox();
			this.btnPrint = new System.Windows.Forms.Button();
			this.lblTeeTimeSelected = new System.Windows.Forms.Label();
			this.lblCourseSelected = new System.Windows.Forms.Label();
			this.lblTeeTime = new System.Windows.Forms.Label();
			this.lblDate = new System.Windows.Forms.Label();
			this.lblDateSelected = new System.Windows.Forms.Label();
			this.timerTeeTimes = new System.Windows.Forms.Timer(this.components);
			this.btnCompute = new System.Windows.Forms.Button();
			this.lblComputed = new System.Windows.Forms.Label();
			this.timerMessage = new System.Windows.Forms.Timer(this.components);
			this.pnlHeader.SuspendLayout();
			this.pnlPlayer1.SuspendLayout();
			this.pnlPlayer3.SuspendLayout();
			this.pnlPlayer2.SuspendLayout();
			this.pnlPlayer5.SuspendLayout();
			this.pnlPlayer4.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnExit
			// 
			this.btnExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(128)), ((System.Byte)(255)));
			this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnExit.Location = new System.Drawing.Point(768, 560);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(204, 104);
			this.btnExit.TabIndex = 13;
			this.btnExit.Text = "E&xit";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// lblSelectTeeTime
			// 
			this.lblSelectTeeTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblSelectTeeTime.Location = new System.Drawing.Point(12, 12);
			this.lblSelectTeeTime.Name = "lblSelectTeeTime";
			this.lblSelectTeeTime.Size = new System.Drawing.Size(324, 28);
			this.lblSelectTeeTime.TabIndex = 23;
			this.lblSelectTeeTime.Text = "WsTee Times";
			this.lblSelectTeeTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbTeeTimes
			// 
			this.lbTeeTimes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbTeeTimes.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbTeeTimes.ItemHeight = 25;
			this.lbTeeTimes.Location = new System.Drawing.Point(8, 44);
			this.lbTeeTimes.Name = "lbTeeTimes";
			this.lbTeeTimes.Size = new System.Drawing.Size(328, 502);
			this.lbTeeTimes.TabIndex = 22;
			this.lbTeeTimes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lbTeeTimes_KeyUp);
			this.lbTeeTimes.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbTeeTimes_MouseUp);
			// 
			// pnlHeader
			// 
			this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.pnlHeader.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.lblPost,
																					this.lblNet,
																					this.lblHdcp,
																					this.lblGross,
																					this.lblPlayer});
			this.pnlHeader.Location = new System.Drawing.Point(348, 160);
			this.pnlHeader.Name = "pnlHeader";
			this.pnlHeader.Size = new System.Drawing.Size(636, 52);
			this.pnlHeader.TabIndex = 24;
			// 
			// lblPost
			// 
			this.lblPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblPost.Location = new System.Drawing.Point(436, 8);
			this.lblPost.Name = "lblPost";
			this.lblPost.Size = new System.Drawing.Size(96, 36);
			this.lblPost.TabIndex = 4;
			this.lblPost.Text = "Post";
			this.lblPost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblNet
			// 
			this.lblNet.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblNet.Location = new System.Drawing.Point(360, 8);
			this.lblNet.Name = "lblNet";
			this.lblNet.Size = new System.Drawing.Size(60, 36);
			this.lblNet.TabIndex = 3;
			this.lblNet.Text = "Net";
			this.lblNet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblHdcp
			// 
			this.lblHdcp.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblHdcp.Location = new System.Drawing.Point(292, 8);
			this.lblHdcp.Name = "lblHdcp";
			this.lblHdcp.Size = new System.Drawing.Size(68, 36);
			this.lblHdcp.TabIndex = 2;
			this.lblHdcp.Text = "Hdcp";
			this.lblHdcp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblGross
			// 
			this.lblGross.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblGross.Location = new System.Drawing.Point(224, 8);
			this.lblGross.Name = "lblGross";
			this.lblGross.Size = new System.Drawing.Size(68, 36);
			this.lblGross.TabIndex = 1;
			this.lblGross.Text = "Gross";
			this.lblGross.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblPlayer
			// 
			this.lblPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblPlayer.Location = new System.Drawing.Point(8, 8);
			this.lblPlayer.Name = "lblPlayer";
			this.lblPlayer.Size = new System.Drawing.Size(208, 36);
			this.lblPlayer.TabIndex = 0;
			this.lblPlayer.Text = "Player";
			this.lblPlayer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pnlPlayer1
			// 
			this.pnlPlayer1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.pnlPlayer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlPlayer1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.txtNet1,
																					 this.txtHdcp1,
																					 this.txtGross1,
																					 this.txtPlayer1,
																					 this.btnEdit1,
																					 this.Post1});
			this.pnlPlayer1.Location = new System.Drawing.Point(348, 212);
			this.pnlPlayer1.Name = "pnlPlayer1";
			this.pnlPlayer1.Size = new System.Drawing.Size(636, 56);
			this.pnlPlayer1.TabIndex = 25;
			// 
			// txtNet1
			// 
			this.txtNet1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtNet1.Enabled = false;
			this.txtNet1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtNet1.Location = new System.Drawing.Point(356, 12);
			this.txtNet1.Name = "txtNet1";
			this.txtNet1.ReadOnly = true;
			this.txtNet1.Size = new System.Drawing.Size(64, 32);
			this.txtNet1.TabIndex = 24;
			this.txtNet1.Text = "";
			this.txtNet1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtHdcp1
			// 
			this.txtHdcp1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtHdcp1.Enabled = false;
			this.txtHdcp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtHdcp1.Location = new System.Drawing.Point(292, 12);
			this.txtHdcp1.Name = "txtHdcp1";
			this.txtHdcp1.ReadOnly = true;
			this.txtHdcp1.Size = new System.Drawing.Size(64, 32);
			this.txtHdcp1.TabIndex = 23;
			this.txtHdcp1.Text = "";
			this.txtHdcp1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtGross1
			// 
			this.txtGross1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtGross1.Enabled = false;
			this.txtGross1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtGross1.Location = new System.Drawing.Point(228, 12);
			this.txtGross1.Name = "txtGross1";
			this.txtGross1.ReadOnly = true;
			this.txtGross1.Size = new System.Drawing.Size(64, 32);
			this.txtGross1.TabIndex = 22;
			this.txtGross1.Text = "";
			this.txtGross1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtPlayer1
			// 
			this.txtPlayer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPlayer1.Enabled = false;
			this.txtPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtPlayer1.Location = new System.Drawing.Point(4, 12);
			this.txtPlayer1.Name = "txtPlayer1";
			this.txtPlayer1.ReadOnly = true;
			this.txtPlayer1.Size = new System.Drawing.Size(224, 32);
			this.txtPlayer1.TabIndex = 21;
			this.txtPlayer1.Text = "";
			// 
			// btnEdit1
			// 
			this.btnEdit1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(0)));
			this.btnEdit1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEdit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnEdit1.Location = new System.Drawing.Point(540, 4);
			this.btnEdit1.Name = "btnEdit1";
			this.btnEdit1.Size = new System.Drawing.Size(88, 44);
			this.btnEdit1.TabIndex = 20;
			this.btnEdit1.Text = "&Edit";
			this.btnEdit1.Click += new System.EventHandler(this.btnEdit1_Click);
			// 
			// Post1
			// 
			this.Post1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.Post1.Checked = false;
			this.Post1.Location = new System.Drawing.Point(432, 4);
			this.Post1.Name = "Post1";
			this.Post1.Size = new System.Drawing.Size(100, 44);
			this.Post1.TabIndex = 1;
			this.Post1.Click += new System.EventHandler(this.Post1_Click);
			// 
			// pnlPlayer3
			// 
			this.pnlPlayer3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.pnlPlayer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlPlayer3.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.txtNet3,
																					 this.txtHdcp3,
																					 this.txtGross3,
																					 this.txtPlayer3,
																					 this.btnEdit3,
																					 this.Post3});
			this.pnlPlayer3.Location = new System.Drawing.Point(348, 336);
			this.pnlPlayer3.Name = "pnlPlayer3";
			this.pnlPlayer3.Size = new System.Drawing.Size(636, 60);
			this.pnlPlayer3.TabIndex = 27;
			// 
			// txtNet3
			// 
			this.txtNet3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtNet3.Enabled = false;
			this.txtNet3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtNet3.Location = new System.Drawing.Point(356, 12);
			this.txtNet3.Name = "txtNet3";
			this.txtNet3.ReadOnly = true;
			this.txtNet3.Size = new System.Drawing.Size(64, 32);
			this.txtNet3.TabIndex = 30;
			this.txtNet3.Text = "";
			this.txtNet3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtHdcp3
			// 
			this.txtHdcp3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtHdcp3.Enabled = false;
			this.txtHdcp3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtHdcp3.Location = new System.Drawing.Point(292, 12);
			this.txtHdcp3.Name = "txtHdcp3";
			this.txtHdcp3.ReadOnly = true;
			this.txtHdcp3.Size = new System.Drawing.Size(64, 32);
			this.txtHdcp3.TabIndex = 29;
			this.txtHdcp3.Text = "";
			this.txtHdcp3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtGross3
			// 
			this.txtGross3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtGross3.Enabled = false;
			this.txtGross3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtGross3.Location = new System.Drawing.Point(228, 12);
			this.txtGross3.Name = "txtGross3";
			this.txtGross3.ReadOnly = true;
			this.txtGross3.Size = new System.Drawing.Size(64, 32);
			this.txtGross3.TabIndex = 28;
			this.txtGross3.Text = "";
			this.txtGross3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtPlayer3
			// 
			this.txtPlayer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPlayer3.Enabled = false;
			this.txtPlayer3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtPlayer3.Location = new System.Drawing.Point(5, 12);
			this.txtPlayer3.Name = "txtPlayer3";
			this.txtPlayer3.ReadOnly = true;
			this.txtPlayer3.Size = new System.Drawing.Size(223, 32);
			this.txtPlayer3.TabIndex = 27;
			this.txtPlayer3.Text = "";
			// 
			// btnEdit3
			// 
			this.btnEdit3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(0)));
			this.btnEdit3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEdit3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnEdit3.Location = new System.Drawing.Point(540, 6);
			this.btnEdit3.Name = "btnEdit3";
			this.btnEdit3.Size = new System.Drawing.Size(88, 46);
			this.btnEdit3.TabIndex = 26;
			this.btnEdit3.Text = "&Edit";
			this.btnEdit3.Click += new System.EventHandler(this.btnEdit3_Click);
			// 
			// Post3
			// 
			this.Post3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.Post3.Checked = false;
			this.Post3.Location = new System.Drawing.Point(432, 6);
			this.Post3.Name = "Post3";
			this.Post3.Size = new System.Drawing.Size(100, 46);
			this.Post3.TabIndex = 25;
			this.Post3.Click += new System.EventHandler(this.Post3_Click);
			// 
			// pnlPlayer2
			// 
			this.pnlPlayer2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.pnlPlayer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlPlayer2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.txtNet2,
																					 this.txtHdcp2,
																					 this.txtGross2,
																					 this.txtPlayer2,
																					 this.btnEdit2,
																					 this.Post2});
			this.pnlPlayer2.Location = new System.Drawing.Point(348, 272);
			this.pnlPlayer2.Name = "pnlPlayer2";
			this.pnlPlayer2.Size = new System.Drawing.Size(636, 60);
			this.pnlPlayer2.TabIndex = 26;
			// 
			// txtNet2
			// 
			this.txtNet2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtNet2.Enabled = false;
			this.txtNet2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtNet2.Location = new System.Drawing.Point(356, 12);
			this.txtNet2.Name = "txtNet2";
			this.txtNet2.ReadOnly = true;
			this.txtNet2.Size = new System.Drawing.Size(64, 32);
			this.txtNet2.TabIndex = 30;
			this.txtNet2.Text = "";
			this.txtNet2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtHdcp2
			// 
			this.txtHdcp2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtHdcp2.Enabled = false;
			this.txtHdcp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtHdcp2.Location = new System.Drawing.Point(292, 12);
			this.txtHdcp2.Name = "txtHdcp2";
			this.txtHdcp2.ReadOnly = true;
			this.txtHdcp2.Size = new System.Drawing.Size(64, 32);
			this.txtHdcp2.TabIndex = 29;
			this.txtHdcp2.Text = "";
			this.txtHdcp2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtGross2
			// 
			this.txtGross2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtGross2.Enabled = false;
			this.txtGross2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtGross2.Location = new System.Drawing.Point(228, 12);
			this.txtGross2.Name = "txtGross2";
			this.txtGross2.ReadOnly = true;
			this.txtGross2.Size = new System.Drawing.Size(64, 32);
			this.txtGross2.TabIndex = 28;
			this.txtGross2.Text = "";
			this.txtGross2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtPlayer2
			// 
			this.txtPlayer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPlayer2.Enabled = false;
			this.txtPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtPlayer2.Location = new System.Drawing.Point(5, 12);
			this.txtPlayer2.Name = "txtPlayer2";
			this.txtPlayer2.ReadOnly = true;
			this.txtPlayer2.Size = new System.Drawing.Size(223, 32);
			this.txtPlayer2.TabIndex = 27;
			this.txtPlayer2.Text = "";
			// 
			// btnEdit2
			// 
			this.btnEdit2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(0)));
			this.btnEdit2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEdit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnEdit2.Location = new System.Drawing.Point(540, 6);
			this.btnEdit2.Name = "btnEdit2";
			this.btnEdit2.Size = new System.Drawing.Size(87, 46);
			this.btnEdit2.TabIndex = 26;
			this.btnEdit2.Text = "&Edit";
			this.btnEdit2.Click += new System.EventHandler(this.btnEdit2_Click);
			// 
			// Post2
			// 
			this.Post2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.Post2.Checked = false;
			this.Post2.Location = new System.Drawing.Point(432, 6);
			this.Post2.Name = "Post2";
			this.Post2.Size = new System.Drawing.Size(100, 46);
			this.Post2.TabIndex = 25;
			this.Post2.Click += new System.EventHandler(this.Post2_Click);
			// 
			// pnlPlayer5
			// 
			this.pnlPlayer5.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.pnlPlayer5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlPlayer5.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.txtNet5,
																					 this.txtHdcp5,
																					 this.txtGross5,
																					 this.txtPlayer5,
																					 this.btnEdit5,
																					 this.Post5});
			this.pnlPlayer5.Location = new System.Drawing.Point(348, 464);
			this.pnlPlayer5.Name = "pnlPlayer5";
			this.pnlPlayer5.Size = new System.Drawing.Size(636, 60);
			this.pnlPlayer5.TabIndex = 29;
			// 
			// txtNet5
			// 
			this.txtNet5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtNet5.Enabled = false;
			this.txtNet5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtNet5.Location = new System.Drawing.Point(356, 12);
			this.txtNet5.Name = "txtNet5";
			this.txtNet5.ReadOnly = true;
			this.txtNet5.Size = new System.Drawing.Size(64, 32);
			this.txtNet5.TabIndex = 30;
			this.txtNet5.Text = "";
			this.txtNet5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtHdcp5
			// 
			this.txtHdcp5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtHdcp5.Enabled = false;
			this.txtHdcp5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtHdcp5.Location = new System.Drawing.Point(292, 12);
			this.txtHdcp5.Name = "txtHdcp5";
			this.txtHdcp5.ReadOnly = true;
			this.txtHdcp5.Size = new System.Drawing.Size(64, 32);
			this.txtHdcp5.TabIndex = 29;
			this.txtHdcp5.Text = "";
			this.txtHdcp5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtGross5
			// 
			this.txtGross5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtGross5.Enabled = false;
			this.txtGross5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtGross5.Location = new System.Drawing.Point(228, 12);
			this.txtGross5.Name = "txtGross5";
			this.txtGross5.ReadOnly = true;
			this.txtGross5.Size = new System.Drawing.Size(64, 32);
			this.txtGross5.TabIndex = 28;
			this.txtGross5.Text = "";
			this.txtGross5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtPlayer5
			// 
			this.txtPlayer5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPlayer5.Enabled = false;
			this.txtPlayer5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtPlayer5.Location = new System.Drawing.Point(5, 12);
			this.txtPlayer5.Name = "txtPlayer5";
			this.txtPlayer5.ReadOnly = true;
			this.txtPlayer5.Size = new System.Drawing.Size(223, 32);
			this.txtPlayer5.TabIndex = 27;
			this.txtPlayer5.Text = "";
			// 
			// btnEdit5
			// 
			this.btnEdit5.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(0)));
			this.btnEdit5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEdit5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnEdit5.Location = new System.Drawing.Point(540, 6);
			this.btnEdit5.Name = "btnEdit5";
			this.btnEdit5.Size = new System.Drawing.Size(88, 46);
			this.btnEdit5.TabIndex = 26;
			this.btnEdit5.Text = "&Edit";
			this.btnEdit5.Click += new System.EventHandler(this.btnEdit5_Click);
			// 
			// Post5
			// 
			this.Post5.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.Post5.Checked = false;
			this.Post5.Location = new System.Drawing.Point(432, 6);
			this.Post5.Name = "Post5";
			this.Post5.Size = new System.Drawing.Size(100, 46);
			this.Post5.TabIndex = 25;
			this.Post5.Click += new System.EventHandler(this.Post5_Click);
			// 
			// pnlPlayer4
			// 
			this.pnlPlayer4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.pnlPlayer4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlPlayer4.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.txtNet4,
																					 this.txtHdcp4,
																					 this.txtGross4,
																					 this.txtPlayer4,
																					 this.btnEdit4,
																					 this.Post4});
			this.pnlPlayer4.Location = new System.Drawing.Point(348, 400);
			this.pnlPlayer4.Name = "pnlPlayer4";
			this.pnlPlayer4.Size = new System.Drawing.Size(636, 60);
			this.pnlPlayer4.TabIndex = 28;
			// 
			// txtNet4
			// 
			this.txtNet4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtNet4.Enabled = false;
			this.txtNet4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtNet4.Location = new System.Drawing.Point(356, 12);
			this.txtNet4.Name = "txtNet4";
			this.txtNet4.ReadOnly = true;
			this.txtNet4.Size = new System.Drawing.Size(64, 32);
			this.txtNet4.TabIndex = 30;
			this.txtNet4.Text = "";
			this.txtNet4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtHdcp4
			// 
			this.txtHdcp4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtHdcp4.Enabled = false;
			this.txtHdcp4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtHdcp4.Location = new System.Drawing.Point(292, 12);
			this.txtHdcp4.Name = "txtHdcp4";
			this.txtHdcp4.ReadOnly = true;
			this.txtHdcp4.Size = new System.Drawing.Size(64, 32);
			this.txtHdcp4.TabIndex = 29;
			this.txtHdcp4.Text = "";
			this.txtHdcp4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtGross4
			// 
			this.txtGross4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtGross4.Enabled = false;
			this.txtGross4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtGross4.Location = new System.Drawing.Point(228, 12);
			this.txtGross4.Name = "txtGross4";
			this.txtGross4.ReadOnly = true;
			this.txtGross4.Size = new System.Drawing.Size(64, 32);
			this.txtGross4.TabIndex = 28;
			this.txtGross4.Text = "";
			this.txtGross4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtPlayer4
			// 
			this.txtPlayer4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPlayer4.Enabled = false;
			this.txtPlayer4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtPlayer4.Location = new System.Drawing.Point(5, 12);
			this.txtPlayer4.Name = "txtPlayer4";
			this.txtPlayer4.ReadOnly = true;
			this.txtPlayer4.Size = new System.Drawing.Size(223, 32);
			this.txtPlayer4.TabIndex = 27;
			this.txtPlayer4.Text = "";
			// 
			// btnEdit4
			// 
			this.btnEdit4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(0)));
			this.btnEdit4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEdit4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnEdit4.Location = new System.Drawing.Point(540, 6);
			this.btnEdit4.Name = "btnEdit4";
			this.btnEdit4.Size = new System.Drawing.Size(88, 46);
			this.btnEdit4.TabIndex = 26;
			this.btnEdit4.Text = "&Edit";
			this.btnEdit4.Click += new System.EventHandler(this.btnEdit4_Click);
			// 
			// Post4
			// 
			this.Post4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.Post4.Checked = false;
			this.Post4.Location = new System.Drawing.Point(432, 6);
			this.Post4.Name = "Post4";
			this.Post4.Size = new System.Drawing.Size(100, 46);
			this.Post4.TabIndex = 25;
			this.Post4.Click += new System.EventHandler(this.Post4_Click);
			// 
			// btnPrint
			// 
			this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnPrint.Location = new System.Drawing.Point(348, 12);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(636, 84);
			this.btnPrint.TabIndex = 30;
			this.btnPrint.Text = "&Print Scorecard";
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// lblTeeTimeSelected
			// 
			this.lblTeeTimeSelected.BackColor = System.Drawing.SystemColors.Control;
			this.lblTeeTimeSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTeeTimeSelected.Location = new System.Drawing.Point(136, 600);
			this.lblTeeTimeSelected.Name = "lblTeeTimeSelected";
			this.lblTeeTimeSelected.Size = new System.Drawing.Size(256, 28);
			this.lblTeeTimeSelected.TabIndex = 33;
			this.lblTeeTimeSelected.Text = "Time Selected";
			this.lblTeeTimeSelected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblCourseSelected
			// 
			this.lblCourseSelected.BackColor = System.Drawing.SystemColors.Control;
			this.lblCourseSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCourseSelected.Location = new System.Drawing.Point(16, 636);
			this.lblCourseSelected.Name = "lblCourseSelected";
			this.lblCourseSelected.Size = new System.Drawing.Size(560, 28);
			this.lblCourseSelected.TabIndex = 32;
			this.lblCourseSelected.Text = "WsCourse Selected";
			this.lblCourseSelected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTeeTime
			// 
			this.lblTeeTime.BackColor = System.Drawing.SystemColors.Control;
			this.lblTeeTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTeeTime.Location = new System.Drawing.Point(16, 600);
			this.lblTeeTime.Name = "lblTeeTime";
			this.lblTeeTime.Size = new System.Drawing.Size(112, 28);
			this.lblTeeTime.TabIndex = 31;
			this.lblTeeTime.Text = "WsTee Time:";
			this.lblTeeTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblDate
			// 
			this.lblDate.BackColor = System.Drawing.SystemColors.Control;
			this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDate.Location = new System.Drawing.Point(16, 564);
			this.lblDate.Name = "lblDate";
			this.lblDate.Size = new System.Drawing.Size(112, 28);
			this.lblDate.TabIndex = 34;
			this.lblDate.Text = "Date:";
			this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblDateSelected
			// 
			this.lblDateSelected.BackColor = System.Drawing.SystemColors.Control;
			this.lblDateSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDateSelected.Location = new System.Drawing.Point(136, 564);
			this.lblDateSelected.Name = "lblDateSelected";
			this.lblDateSelected.Size = new System.Drawing.Size(352, 28);
			this.lblDateSelected.TabIndex = 35;
			this.lblDateSelected.Text = "Date Selected";
			this.lblDateSelected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// timerTeeTimes
			// 
			this.timerTeeTimes.Enabled = true;
			this.timerTeeTimes.Interval = 10000;
			this.timerTeeTimes.Tick += new System.EventHandler(this.timerTeeTimes_Tick);
			// 
			// btnCompute
			// 
			this.btnCompute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCompute.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCompute.Location = new System.Drawing.Point(596, 560);
			this.btnCompute.Name = "btnCompute";
			this.btnCompute.Size = new System.Drawing.Size(156, 104);
			this.btnCompute.TabIndex = 36;
			this.btnCompute.Text = "Update Round Scores";
			this.btnCompute.Click += new System.EventHandler(this.btnCompute_Click);
			// 
			// lblComputed
			// 
			this.lblComputed.BackColor = System.Drawing.Color.Yellow;
			this.lblComputed.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblComputed.Location = new System.Drawing.Point(460, 104);
			this.lblComputed.Name = "lblComputed";
			this.lblComputed.Size = new System.Drawing.Size(400, 40);
			this.lblComputed.TabIndex = 37;
			this.lblComputed.Text = "Tournament Standings Computed";
			this.lblComputed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblComputed.Visible = false;
			// 
			// timerMessage
			// 
			this.timerMessage.Interval = 5000;
			this.timerMessage.Tick += new System.EventHandler(this.timerMessage_Tick);
			// 
			// TourLitePost
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.ClientSize = new System.Drawing.Size(994, 688);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lblComputed,
																		  this.btnCompute,
																		  this.lblDateSelected,
																		  this.lblDate,
																		  this.lblTeeTimeSelected,
																		  this.lblCourseSelected,
																		  this.lblTeeTime,
																		  this.btnPrint,
																		  this.pnlPlayer5,
																		  this.pnlPlayer4,
																		  this.pnlPlayer3,
																		  this.pnlPlayer2,
																		  this.pnlPlayer1,
																		  this.pnlHeader,
																		  this.lblSelectTeeTime,
																		  this.lbTeeTimes,
																		  this.btnExit});
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "TourLitePost";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Print Scorecards and Post Tournament Scores";
			this.Load += new System.EventHandler(this.TourLitePost_Load);
			this.pnlHeader.ResumeLayout(false);
			this.pnlPlayer1.ResumeLayout(false);
			this.pnlPlayer3.ResumeLayout(false);
			this.pnlPlayer2.ResumeLayout(false);
			this.pnlPlayer5.ResumeLayout(false);
			this.pnlPlayer4.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			timerTeeTimes.Dispose();
			this.Close();
		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			if (dac.CreateDataAccessFile())
			{
				// Print Tournament Scorecard
				rs = new ReportSelect(ref espDB);
				//
				// Create Instance of Game Summary
				rs.gm = new GameMaster( ref espDB );

				// Compute Strokes for each Player
				//ComputePlayerStrokes();

				// Setup Page Format
				PageSetupDialog myPageSetup = new PageSetupDialog();
				rs.pd = new PrintDocument();
				myPageSetup.Document = rs.pd;
				myPageSetup.PageSettings.PrinterSettings.Copies = 1;
				myPageSetup.PageSettings.PrinterSettings.Collate = true;
				rs.printerResolutionX = 300;
				rs.printerResolutionY = 300;
				myPageSetup.PageSettings.Margins.Left = 25;
				myPageSetup.PageSettings.Margins.Right = 25;
				myPageSetup.PageSettings.Margins.Top = 50;
				myPageSetup.PageSettings.Margins.Bottom = 50;

				rs.pagesPrinted = 0;
				rs.yPos = 0;

				// Print the SELECTED REPORTS
				rs.pd.PrintPage += new PrintPageEventHandler( this.PrintReports );

				rs.pd.Print();

				myPageSetup.Dispose();
			}
			else
			{
				// Should never get here
				MessageBox.Show("The GolfESP Database was busy.  Please reselect 'Print Scorecard'.");
			}

			// Make sure that the MANAGER Access Control File is deleted.
			dac.DeleteDataAccessFile();
		}

		private void PrintReports(object sender, PrintPageEventArgs e)
		{
			//
			e.Graphics.PageUnit = GraphicsUnit.Document;
			rs.leftMargin = ((e.MarginBounds.Left*rs.printerResolutionX)/100);
			rs.topMargin = (e.MarginBounds.Top*rs.printerResolutionY)/100;
			rs.pageLeft = e.PageBounds.Left;
			rs.pageRight = e.PageBounds.Right;
			rs.pageTop = e.PageBounds.Top;
			rs.pageBottom = e.PageBounds.Bottom;
			rs.pageHeight = (e.MarginBounds.Height/100)*rs.printerResolutionY;
			rs.pageWidth = (int)((e.MarginBounds.Width/100)*rs.printerResolutionX);
			rs.lineHeight = (int)rs.espFont10.GetHeight(e.Graphics);

			rs.linesPerPage = (int)(rs.pageHeight / rs.lineHeight);
			rs.yPos = rs.topMargin;

			// ScoreCard
			rs.pdPrintScoreCard(sender,e,Global.GROSS);
			//rs.pdPrintScoreCard(sender,e,Global.NET);
			// Print TL Game 
			//<<<<<CODE GOES HERE>>>>>
		}

		/// <summary>
		/// Compute Player Strokes for Scorecard NET Score Printing
		/// </summary>
		private void ComputePlayerStrokes()
		{
			short		Handicap = 0;
			short		strokes;						// extra strokes to give
			short		baseStrokes;				// the base number of strokes
			sbyte		currentStrokes;			// the current strokes value
			TEE_INFORMATION pTeeInfo;
			// 
			for (int i=0;i<espDB.g_State.NumPlayers;i++)
			{
				Handicap = (short)espDB.cPlayers[i].ComputedHandicap;
				// SPECIAL FOR MILL CREEK (TEMPORARY)
				if (espDB.cPlayers[i].Gender == GENDER.Female) Handicap += 3;
				// calculate the base number of strokes
				// this is the number of times MAX_HOLES goes
				// into the difference between handicaps
				baseStrokes = (short)(Handicap / Global.MAX_HOLES);
				//
				// get the remainder - these are the odd strokes we'll
				// hand out
				// note that we take the absolute value here - we only use
				// this as a threshold
				strokes = (short)Math.Abs(Handicap - (baseStrokes * Global.MAX_HOLES));
				pTeeInfo = espDB.GetTeeInfo(espDB.cPlayers[i].Tees);
				// loop over the holes
				for (int ii = 0; ii < Global.MAX_HOLES; ii++) 
				{
					// if this hole's handicap is <= strokes,
					// it gets an extra, otherwise, it gets
					// the base amount
					if (pTeeInfo.Holes[ii].Handicap <= strokes) 
					{
						// set the current strokes
						// note the adjustment for negative handicaps
						if (Handicap < 0) 
						{
							currentStrokes = (sbyte)(baseStrokes - 1);
						} 
						else 
						{
							currentStrokes = (sbyte)(baseStrokes + 1);
						}
					} 
					else 
					{
						// set the current strokes
						currentStrokes = (sbyte)baseStrokes;
					}
					// write to the player
					espDB.cPlayers[i].Strokes[ii] = (sbyte)currentStrokes;
				}
			}
		}

		private void TourLitePost_Load(object sender, System.EventArgs e)
		{
			// Set Source for lbTeeTimes
			ds = espDB.GetDS();
			espDB.GetTournamentRoundTimes(TournamentID);
			//
			dtTeeTimes = ds.Tables["TournamentRoundTimes"];
			lbTeeTimes.DataSource = dtTeeTimes;
			lbTeeTimes.ValueMember = "RoundID";
			lbTeeTimes.DisplayMember = "RoundTime";
			if (lbTeeTimes.SelectedItem != null)
			{
				UpdateDisplay();
			}
		}

		private void lbTeeTimes_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// Get the Round Associated with the selected TeeTime
			if (lbTeeTimes.SelectedItem != null)
			{
				UpdateDisplay();
			}
		}

		private void UpdateDisplay()
		{
			string sel = "";
			short score = 0;

			sel = lbTeeTimes.SelectedValue.ToString();
			// Get the round Data and Store in espDB
			RoundID = Int32.Parse(sel);
			espDB.UnprintedRoundSelect((uint)RoundID);
			// LOAD the Rounds, Players, Games, and all associated tables
			espDB.LoadRoundAndGameData();
			// Update WsCourse Data
			espDB.GetCourseData(espDB.g_State.CourseID);
			espDB.UpdateAllOtherCourseData(espDB.g_State.CourseID);
			//==========================
			// Display Currently Selected WsCourse, Date and Time
			lblCourseSelected.Text = espDB.g_State.CurrentCourseName;
			lblTeeTimeSelected.Text = espDB.g_State.TeeTime;
			lblDateSelected.Text = espDB.g_State.DatePlayed;

			short Handicap = 0;
			for (int i=0;i<Global.MAX_PLAYERS;i++)
			{
				switch ( i )
				{
					case 0:
						if (i < espDB.g_State.NumPlayers)
						{
							txtPlayer1.Text = espDB.cPlayers[i].Initials;
							Handicap = (short)espDB.cPlayers[i].ComputedHandicap;
							// SPECIAL FOR MILL CREEK (TEMPORARY)
							if (espDB.cPlayers[i].Gender == GENDER.Female) Handicap += 3;
							txtHdcp1.Text = Handicap.ToString();
							score = ComputePlayerScore((byte)i);
							txtGross1.Text = score.ToString();
							score -= Handicap;
							txtNet1.Text = score.ToString();
							Post1.Enabled = true;
							Post1.Checked = espDB.cPlayers[i].Posted;
							Post1.Refresh();
							if (Post1.Checked) btnEdit1.Enabled = false;
							else btnEdit1.Enabled = true;
						}
						else
						{
							txtPlayer1.Text = "";
							txtHdcp1.Text = "";
							txtGross1.Text = "";
							txtNet1.Text = "";
							btnEdit1.Enabled = false;
							Post1.Enabled = false;
							Post1.Checked = false;
							Post1.Refresh();
						}
						break;
					case 1:
						if (i < espDB.g_State.NumPlayers)
						{
							txtPlayer2.Text = espDB.cPlayers[i].Initials;
							Handicap = (short)espDB.cPlayers[i].ComputedHandicap;
							// SPECIAL FOR MILL CREEK (TEMPORARY)
							if (espDB.cPlayers[i].Gender == GENDER.Female) Handicap += 3;
							txtHdcp2.Text = Handicap.ToString();
							score = ComputePlayerScore((byte)i);
							txtGross2.Text = score.ToString();
							score -= Handicap;
							txtNet2.Text = score.ToString();
							Post2.Enabled = true;
							Post2.Checked = espDB.cPlayers[i].Posted;
							Post2.Refresh();
							if (Post2.Checked) btnEdit2.Enabled = false;
							else btnEdit2.Enabled = true;
						}
						else
						{
							txtPlayer2.Text = "";
							txtHdcp2.Text = "";
							txtGross2.Text = "";
							txtNet2.Text = "";
							btnEdit2.Enabled = false;
							Post2.Enabled = false;
							Post2.Checked = false;
							Post2.Refresh();
						}
						break;
					case 2:
						if (i < espDB.g_State.NumPlayers)
						{
							txtPlayer3.Text = espDB.cPlayers[i].Initials;
							Handicap = (short)espDB.cPlayers[i].ComputedHandicap;
							// SPECIAL FOR MILL CREEK (TEMPORARY)
							if (espDB.cPlayers[i].Gender == GENDER.Female) Handicap += 3;
							txtHdcp3.Text = Handicap.ToString();
							score = ComputePlayerScore((byte)i);
							txtGross3.Text = score.ToString();
							score -= Handicap;
							txtNet3.Text = score.ToString();
							Post3.Enabled = true;
							Post3.Checked = espDB.cPlayers[i].Posted;
							Post3.Refresh();
							if (Post3.Checked) btnEdit3.Enabled = false;
							else btnEdit3.Enabled = true;
						}
						else
						{
							txtPlayer3.Text = "";
							txtHdcp3.Text = "";
							txtGross3.Text = "";
							txtNet3.Text = "";
							btnEdit3.Enabled = false;
							Post3.Enabled = false;
							Post3.Checked = false;
							Post3.Refresh();
						}
						break;
					case 3:
						if (i < espDB.g_State.NumPlayers)
						{
							txtPlayer4.Text = espDB.cPlayers[i].Initials;
							Handicap = (short)espDB.cPlayers[i].ComputedHandicap;
							// SPECIAL FOR MILL CREEK (TEMPORARY)
							if (espDB.cPlayers[i].Gender == GENDER.Female) Handicap += 3;
							txtHdcp4.Text = Handicap.ToString();
							score = ComputePlayerScore((byte)i);
							txtGross4.Text = score.ToString();
							score -= Handicap;
							txtNet4.Text = score.ToString();
							Post4.Enabled = true;
							Post4.Checked = espDB.cPlayers[i].Posted;
							Post4.Refresh();
							if (Post4.Checked) btnEdit4.Enabled = false;
							else btnEdit4.Enabled = true;
						}
						else
						{
							txtPlayer4.Text = "";
							txtHdcp4.Text = "";
							txtGross4.Text = "";
							txtNet4.Text = "";
							btnEdit4.Enabled = false;
							Post4.Enabled = false;
							Post4.Checked = false;
							Post4.Refresh();
						}
						break;
					case 4:
						if (i < espDB.g_State.NumPlayers)
						{
							txtPlayer5.Text = espDB.cPlayers[i].Initials;
							Handicap = (short)espDB.cPlayers[i].ComputedHandicap;
							// SPECIAL FOR MILL CREEK (TEMPORARY)
							if (espDB.cPlayers[i].Gender == GENDER.Female) Handicap += 3;
							txtHdcp5.Text = Handicap.ToString();
							score = ComputePlayerScore((byte)i);
							txtGross5.Text = score.ToString();
							score -= Handicap;
							txtNet5.Text = score.ToString();
							Post5.Enabled = true;
							Post5.Checked = espDB.cPlayers[i].Posted;
							Post5.Refresh();
							if (Post5.Checked) btnEdit5.Enabled = false;
							else btnEdit5.Enabled = true;
						}
						else
						{
							txtPlayer5.Text = "";
							txtHdcp5.Text = "";
							txtGross5.Text = "";
							txtNet5.Text = "";
							btnEdit5.Enabled = false;
							Post5.Enabled = false;
							Post5.Checked = false;
							Post5.Refresh();
						}
						break;
				}
			}
			if (espDB.GetTLRound(TournamentID,RoundID))
			{
				// Record for TLRound is already defined
			}
			else
			{
				// Add TLRound Record
				espDB.AddTLRound(TournamentID, RoundID);
			}
			// Compute Strokes for each Player
			ComputePlayerStrokes();
		}
		private short ComputePlayerScore(byte index)
		{
			short grossScore = 0;
			for (byte i=0;i<Global.MAX_HOLES;i++)
			{
				grossScore += espDB.cPlayers[index].Scores[i];
			}
			return grossScore;
		}

		private void timerTeeTimes_Tick(object sender, System.EventArgs e)
		{
			if (dac.CreateDataAccessFile())
			{
				string curval = "";
				// Disable LIST Timer until Table Update is complete
				timerTeeTimes.Enabled = false;
				//
				try
				{
					if (lbTeeTimes.Items.Count > 0)curval = lbTeeTimes.SelectedValue.ToString();
					espDB.GetTournamentRoundTimes(TournamentID);
					dtTeeTimes.GetChanges();
					if ((curval != "") & (lbTeeTimes.Items.Count > 0))lbTeeTimes.SelectedValue = curval;
					else this.UpdateDisplay();
				}
				catch
				{
					// If there was an error just wait till the next pass and
					// try again
					if (lbTeeTimes.Items.Count > 0)lbTeeTimes.SelectedIndex = 0;
				}
				//
				// Reenable LIST Timer
				timerTeeTimes.Enabled = true;
			}
			// Make sure that our own access control file is deleted
			dac.DeleteDataAccessFile();
		}

		private void lbTeeTimes_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			// Get the Round Associated with the selected TeeTime
			if ((lbTeeTimes.SelectedItem != null) & (e.KeyCode == Keys.Space))
			{
				UpdateDisplay();
			}
		}

		private void Post1_Click(object sender, System.EventArgs e)
		{
			// Set the POSTED Flag in PLAYERS table
			if (Post1.Checked)
			{
				// Disable Edit Button
				btnEdit1.Enabled = false;
				// Set Posted Flag and Make sure there is a record
				if (espDB.SetPlayerPostedFlag(TournamentID,RoundID,espDB.cPlayers[0].PlayerID,true))
					btnCompute_Click(sender,e);
			}
			else
			{
				// Disable Timer During User Confirm
				this.timerTeeTimes.Enabled = false;
				// Clear Posted Flag
				TouchMessageBox confirm = new TouchMessageBox();
				confirm.Header = "Clear the Posted Flag";
				confirm.Message = "Do you really want to Clear the POSTED flag for "+txtPlayer1.Text.ToString()+"?";
				confirm.Confirm = "&Yes";
				confirm.Cancel = "&No";
				confirm.ShowDialog();
				if (confirm.Return)
				{
					// Clear the posted flag and update Tournament Game Scores
					espDB.SetPlayerPostedFlag(TournamentID,RoundID,espDB.cPlayers[0].PlayerID,false);
					// Enable Edit Button
					btnEdit1.Enabled = true;
				}
				else
				{
					Post1.Checked = true;
					Post1.Refresh();
				}
				confirm.Dispose();
				// reenable the Timer
				this.timerTeeTimes.Enabled = true;
			}
		}

		private void Post2_Click(object sender, System.EventArgs e)
		{
			// Set the POSTED Flag in PLAYERS table
			if (Post2.Checked)
			{
				// Disable Edit Button
				btnEdit2.Enabled = false;
				// Set Posted Flag and Make sure there is a record
				if (espDB.SetPlayerPostedFlag(TournamentID,RoundID,espDB.cPlayers[1].PlayerID,true))
					btnCompute_Click(sender,e);
			}
			else
			{
				// Disable Timer During User Confirm
				this.timerTeeTimes.Enabled = false;
				// Clear Posted Flag
				TouchMessageBox confirm = new TouchMessageBox();
				confirm.Header = "Clear the Posted Flag";
				confirm.Message = "Do you really want to Clear the POSTED flag for "+txtPlayer2.Text.ToString()+"?";
				confirm.Confirm = "&Yes";
				confirm.Cancel = "&No";
				confirm.ShowDialog();
				if (confirm.Return)
				{
					// Clear the posted flag and update Tournament Game Scores
					espDB.SetPlayerPostedFlag(TournamentID,RoundID,espDB.cPlayers[1].PlayerID,false);
					// Enable Edit Button
					btnEdit2.Enabled = true;
				}
				else
				{
					Post2.Checked = true;
					Post2.Refresh();
				}
				confirm.Dispose();
				// reenable the Timer
				this.timerTeeTimes.Enabled = true;
			}
		}

		private void Post3_Click(object sender, System.EventArgs e)
		{
			// Set the POSTED Flag in PLAYERS table
			if (Post3.Checked)
			{
				// Disable Edit Button
				btnEdit3.Enabled = false;
				// Set Posted Flag and Make sure there is a record
				if (espDB.SetPlayerPostedFlag(TournamentID,RoundID,espDB.cPlayers[2].PlayerID,true))
					btnCompute_Click(sender,e);
			}
			else
			{
				// Disable Timer During User Confirm
				this.timerTeeTimes.Enabled = false;
				// Clear Posted Flag
				TouchMessageBox confirm = new TouchMessageBox();
				confirm.Header = "Clear the Posted Flag";
				confirm.Message = "Do you really want to Clear the POSTED flag for "+txtPlayer3.Text.ToString()+"?";
				confirm.Confirm = "&Yes";
				confirm.Cancel = "&No";
				confirm.ShowDialog();
				if (confirm.Return)
				{
					// Clear the posted flag and update Tournament Game Scores
					espDB.SetPlayerPostedFlag(TournamentID,RoundID,espDB.cPlayers[2].PlayerID,false);
					// Enable Edit Button
					btnEdit3.Enabled = true;
				}
				else
				{
					Post3.Checked = true;
					Post3.Refresh();
				}
				confirm.Dispose();
				// reenable the Timer
				this.timerTeeTimes.Enabled = true;
			}
		}

		private void Post4_Click(object sender, System.EventArgs e)
		{
			// Set the POSTED Flag in PLAYERS table
			if (Post4.Checked)
			{
				// Disable Edit Button
				btnEdit4.Enabled = false;
				// Set Posted Flag and Make sure there is a record
				if (espDB.SetPlayerPostedFlag(TournamentID,RoundID,espDB.cPlayers[3].PlayerID,true))
					btnCompute_Click(sender,e);
			}
			else
			{
				// Disable Timer During User Confirm
				this.timerTeeTimes.Enabled = false;
				// Clear Posted Flag
				TouchMessageBox confirm = new TouchMessageBox();
				confirm.Header = "Clear the Posted Flag";
				confirm.Message = "Do you really want to Clear the POSTED flag for "+txtPlayer4.Text.ToString()+"?";
				confirm.Confirm = "&Yes";
				confirm.Cancel = "&No";
				confirm.ShowDialog();
				if (confirm.Return)
				{
					// Clear the posted flag and update Tournament Game Scores
					espDB.SetPlayerPostedFlag(TournamentID,RoundID,espDB.cPlayers[3].PlayerID,false);
					// Enable Edit Button
					btnEdit4.Enabled = true;
				}
				else
				{
					Post4.Checked = true;
					Post4.Refresh();
				}
				confirm.Dispose();
				// reenable the Timer
				this.timerTeeTimes.Enabled = true;
			}
		}

		private void Post5_Click(object sender, System.EventArgs e)
		{
			// Set the POSTED Flag in PLAYERS table
			if (Post5.Checked)
			{
				// Disable Edit Button
				btnEdit2.Enabled = false;
				// Set Posted Flag and Make sure there is a record
				if (espDB.SetPlayerPostedFlag(TournamentID,RoundID,espDB.cPlayers[4].PlayerID,true))
					btnCompute_Click(sender,e);
			}
			else
			{
				// Disable Timer During User Confirm
				this.timerTeeTimes.Enabled = false;
				// Clear Posted Flag
				TouchMessageBox confirm = new TouchMessageBox();
				confirm.Header = "Clear the Posted Flag";
				confirm.Message = "Do you really want to Clear the POSTED flag for "+txtPlayer5.Text.ToString()+"?";
				confirm.Confirm = "&Yes";
				confirm.Cancel = "&No";
				confirm.ShowDialog();
				if (confirm.Return)
				{
					// Clear the posted flag and update Tournament Game Scores
					espDB.SetPlayerPostedFlag(TournamentID,RoundID,espDB.cPlayers[4].PlayerID,false);
					// Enable Edit Button
					btnEdit5.Enabled = true;
				}
				else
				{
					Post5.Checked = true;
					Post5.Refresh();
				}
				confirm.Dispose();
				// reenable the Timer
				this.timerTeeTimes.Enabled = true;
			}
		}

		private void btnCompute_Click(object sender, System.EventArgs e)
		{
			if (dac.CreateDataAccessFile())
			{
				TourLiteCompute tlc = new TourLiteCompute(ref espDB);

				tlc.ComputeGame(TournamentID,RoundID);
				lblComputed.Visible = true;
				timerMessage.Enabled = true;

				tlc = null;
			}
			else
			{
				MessageBox.Show("Unable to Update the Leader Board Scores.  Wait 5 Seconds and select Update Round Scores again.");
			}
			// Make sure that our own access control file is deleted
			dac.DeleteDataAccessFile();
		}

		private void timerMessage_Tick(object sender, System.EventArgs e)
		{
			lblComputed.Visible = false;
			timerMessage.Enabled = false;
		}

		private void btnEdit1_Click(object sender, System.EventArgs e)
		{
			if (EditPlayerScores(espDB.cPlayers[0].PlayerID))
				UpdateDisplay();
		}

		private void btnEdit2_Click(object sender, System.EventArgs e)
		{
			if (EditPlayerScores(espDB.cPlayers[1].PlayerID))
				UpdateDisplay();
		}

		private void btnEdit3_Click(object sender, System.EventArgs e)
		{
			if (EditPlayerScores(espDB.cPlayers[2].PlayerID))
				UpdateDisplay();
		}

		private void btnEdit4_Click(object sender, System.EventArgs e)
		{
			if (EditPlayerScores(espDB.cPlayers[3].PlayerID))
				UpdateDisplay();
		}

		private void btnEdit5_Click(object sender, System.EventArgs e)
		{
			if (EditPlayerScores(espDB.cPlayers[4].PlayerID))
				UpdateDisplay();
		}

		private bool EditPlayerScores(int playerid)
		{
			bool retval = false;
			// Disable Timer During User Confirm
			this.timerTeeTimes.Enabled = false;

			EditScores editScores = new EditScores(ref espDB);
			editScores.PlayerID = playerid;
			editScores.ShowDialog();
			retval = editScores.Updated;

			// Enable Timer After User Edit
			this.timerTeeTimes.Enabled = true;
			return retval;
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
