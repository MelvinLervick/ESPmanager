using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ESPmanager
{
	/// <summary>
	/// Summary description for ReportSelect.
	/// </summary>
	public class ReportSelect : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnPrint;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnGameReconciliationYes;
		private System.Windows.Forms.Button btnGameDetailsYes;
		private System.Windows.Forms.Button btnGameSummaryYes;
		private System.Windows.Forms.Button btnScoresYes;
		private System.Windows.Forms.Label lblScoreCard;
		private System.Windows.Forms.Label lblGameSummary;
		private System.Windows.Forms.Label lblGameDetails;
		private System.Windows.Forms.Label lblGameReconciliation;
		private System.Windows.Forms.Button btnGameReconciliationNo;
		private System.Windows.Forms.Button btnGameDetailsNo;
		private System.Windows.Forms.Button btnGameSummaryNo;
		private System.Windows.Forms.Button btnScoresNo;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnPrint1;
		private System.Windows.Forms.Button btnPrint2;
		private System.Windows.Forms.Button btnPrint3;
		private System.Windows.Forms.Button btnPrint4;
		private System.Windows.Forms.Button btnPrint5;
		private System.Windows.Forms.Panel pnlPreview;

		// Constants for Scorecard
		private const float LOGO = 1.1f;
		private const float HOLES = .265f;
		private const float OUT = .32f;
		private const float INIT2 = .3f;
		private const int SPACING = 3;

		// Definitions
		private DatabaseAccessControl dac = new DatabaseAccessControl();
		private Database espDB;
		public GameMaster gm;
		public PrintDocument pd;
		private GameSummary gs;

		private bool flagRotate = false;

		private bool ScoreCardPrinted = false;
		private bool SummaryPrinted = false;
		private bool DetailsPrinted = false;
		private bool ReconciliationPrinted = false;
		private bool NewPage = false;

		public int pagesPrinted = 0;
		public float yPos = 0;
		public float leftMargin;
		public float topMargin;
		public int printerResolutionX;
		public int printerResolutionY;
		private Font espFont14 = new Font( "Times New Roman", 14);
		private Font espFont12 = new Font( "Times New Roman", 12);
		private Font espFont11 = new Font( "Times New Roman", 11);
		public Font espFont10 = new Font( "Times New Roman", 10);
		private Font espFont9 = new Font( "Times New Roman", 9);
		private Font espFont8 = new Font( "Times New Roman", 8);
		private Font espFont7 = new Font( "Times New Roman", 7);
		private Pen linePen = new Pen(Color.Blue,1);

		// Lines Per Page
		public int linesPerPage;

		// Graphics Variables
		public int pageLeft;
		public int pageRight;
		public int pageTop;
		public int pageBottom;
		public int pageHeight;
		public int pageWidth;
		public int lineHeight;

		private int xBox1;
		private int wBox1;
		private int xBox2;
		private int wBox2;
		private System.Windows.Forms.Label lblTeeTimeSelected;
		private System.Windows.Forms.Label lblCourseSelected;
		private System.Windows.Forms.Label lblTeeTime;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblPlayers;
		private System.Windows.Forms.Button btnPlayer1;
		private System.Windows.Forms.Button btnPlayer2;
		private System.Windows.Forms.Button btnPlayer3;
		private System.Windows.Forms.Button btnPlayer4;
		private System.Windows.Forms.Button btnPlayer5;
		private int yBox12;

		public ReportSelect( ref Database _espDB )
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			espDB = _espDB;
			gs = new GameSummary(ref espDB);
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnPrint = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnGameReconciliationNo = new System.Windows.Forms.Button();
			this.btnGameDetailsNo = new System.Windows.Forms.Button();
			this.btnGameSummaryNo = new System.Windows.Forms.Button();
			this.btnScoresNo = new System.Windows.Forms.Button();
			this.lblGameReconciliation = new System.Windows.Forms.Label();
			this.lblGameDetails = new System.Windows.Forms.Label();
			this.lblGameSummary = new System.Windows.Forms.Label();
			this.lblScoreCard = new System.Windows.Forms.Label();
			this.btnGameReconciliationYes = new System.Windows.Forms.Button();
			this.btnGameDetailsYes = new System.Windows.Forms.Button();
			this.btnGameSummaryYes = new System.Windows.Forms.Button();
			this.btnScoresYes = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnPrint5 = new System.Windows.Forms.Button();
			this.btnPrint4 = new System.Windows.Forms.Button();
			this.btnPrint3 = new System.Windows.Forms.Button();
			this.btnPrint2 = new System.Windows.Forms.Button();
			this.btnPrint1 = new System.Windows.Forms.Button();
			this.pnlPreview = new System.Windows.Forms.Panel();
			this.lblTeeTimeSelected = new System.Windows.Forms.Label();
			this.lblCourseSelected = new System.Windows.Forms.Label();
			this.lblTeeTime = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnPlayer5 = new System.Windows.Forms.Button();
			this.btnPlayer4 = new System.Windows.Forms.Button();
			this.btnPlayer3 = new System.Windows.Forms.Button();
			this.btnPlayer2 = new System.Windows.Forms.Button();
			this.btnPlayer1 = new System.Windows.Forms.Button();
			this.lblPlayers = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(232, 580);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(160, 72);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnPrint
			// 
			this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnPrint.Location = new System.Drawing.Point(602, 580);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(160, 72);
			this.btnPrint.TabIndex = 6;
			this.btnPrint.Text = "&Print";
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.btnGameReconciliationNo,
																					this.btnGameDetailsNo,
																					this.btnGameSummaryNo,
																					this.btnScoresNo,
																					this.lblGameReconciliation,
																					this.lblGameDetails,
																					this.lblGameSummary,
																					this.lblScoreCard,
																					this.btnGameReconciliationYes,
																					this.btnGameDetailsYes,
																					this.btnGameSummaryYes,
																					this.btnScoresYes});
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(15, 104);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(969, 300);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Select Reports to be Printed.";
			// 
			// btnGameReconciliationNo
			// 
			this.btnGameReconciliationNo.BackColor = System.Drawing.Color.SkyBlue;
			this.btnGameReconciliationNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnGameReconciliationNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnGameReconciliationNo.Location = new System.Drawing.Point(646, 216);
			this.btnGameReconciliationNo.Name = "btnGameReconciliationNo";
			this.btnGameReconciliationNo.Size = new System.Drawing.Size(200, 52);
			this.btnGameReconciliationNo.TabIndex = 11;
			this.btnGameReconciliationNo.Text = "No";
			this.btnGameReconciliationNo.Click += new System.EventHandler(this.btnGameReconciliationNo_Click);
			// 
			// btnGameDetailsNo
			// 
			this.btnGameDetailsNo.BackColor = System.Drawing.Color.SkyBlue;
			this.btnGameDetailsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnGameDetailsNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnGameDetailsNo.Location = new System.Drawing.Point(646, 156);
			this.btnGameDetailsNo.Name = "btnGameDetailsNo";
			this.btnGameDetailsNo.Size = new System.Drawing.Size(200, 52);
			this.btnGameDetailsNo.TabIndex = 10;
			this.btnGameDetailsNo.Text = "No";
			this.btnGameDetailsNo.Click += new System.EventHandler(this.btnGameDetailsNo_Click);
			// 
			// btnGameSummaryNo
			// 
			this.btnGameSummaryNo.BackColor = System.Drawing.Color.SkyBlue;
			this.btnGameSummaryNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnGameSummaryNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnGameSummaryNo.Location = new System.Drawing.Point(646, 96);
			this.btnGameSummaryNo.Name = "btnGameSummaryNo";
			this.btnGameSummaryNo.Size = new System.Drawing.Size(200, 52);
			this.btnGameSummaryNo.TabIndex = 9;
			this.btnGameSummaryNo.Text = "No";
			this.btnGameSummaryNo.Click += new System.EventHandler(this.btnGameSummaryNo_Click);
			// 
			// btnScoresNo
			// 
			this.btnScoresNo.BackColor = System.Drawing.Color.Lime;
			this.btnScoresNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnScoresNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnScoresNo.Location = new System.Drawing.Point(646, 36);
			this.btnScoresNo.Name = "btnScoresNo";
			this.btnScoresNo.Size = new System.Drawing.Size(200, 52);
			this.btnScoresNo.TabIndex = 8;
			this.btnScoresNo.Text = "No";
			this.btnScoresNo.Click += new System.EventHandler(this.btnScoresNo_Click);
			// 
			// lblGameReconciliation
			// 
			this.lblGameReconciliation.Location = new System.Drawing.Point(122, 216);
			this.lblGameReconciliation.Name = "lblGameReconciliation";
			this.lblGameReconciliation.Size = new System.Drawing.Size(240, 52);
			this.lblGameReconciliation.TabIndex = 7;
			this.lblGameReconciliation.Text = "Game Reconciliation";
			this.lblGameReconciliation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblGameDetails
			// 
			this.lblGameDetails.Location = new System.Drawing.Point(122, 156);
			this.lblGameDetails.Name = "lblGameDetails";
			this.lblGameDetails.Size = new System.Drawing.Size(240, 52);
			this.lblGameDetails.TabIndex = 6;
			this.lblGameDetails.Text = "Game Details";
			this.lblGameDetails.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblGameSummary
			// 
			this.lblGameSummary.Location = new System.Drawing.Point(122, 100);
			this.lblGameSummary.Name = "lblGameSummary";
			this.lblGameSummary.Size = new System.Drawing.Size(240, 48);
			this.lblGameSummary.TabIndex = 5;
			this.lblGameSummary.Text = "Game Summary";
			this.lblGameSummary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblScoreCard
			// 
			this.lblScoreCard.Location = new System.Drawing.Point(122, 40);
			this.lblScoreCard.Name = "lblScoreCard";
			this.lblScoreCard.Size = new System.Drawing.Size(236, 44);
			this.lblScoreCard.TabIndex = 4;
			this.lblScoreCard.Text = "Score Card";
			this.lblScoreCard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnGameReconciliationYes
			// 
			this.btnGameReconciliationYes.BackColor = System.Drawing.Color.SkyBlue;
			this.btnGameReconciliationYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnGameReconciliationYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnGameReconciliationYes.Location = new System.Drawing.Point(406, 216);
			this.btnGameReconciliationYes.Name = "btnGameReconciliationYes";
			this.btnGameReconciliationYes.Size = new System.Drawing.Size(200, 52);
			this.btnGameReconciliationYes.TabIndex = 3;
			this.btnGameReconciliationYes.Text = "Yes";
			this.btnGameReconciliationYes.Click += new System.EventHandler(this.btnGameReconciliationYes_Click);
			// 
			// btnGameDetailsYes
			// 
			this.btnGameDetailsYes.BackColor = System.Drawing.Color.SkyBlue;
			this.btnGameDetailsYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnGameDetailsYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnGameDetailsYes.Location = new System.Drawing.Point(406, 156);
			this.btnGameDetailsYes.Name = "btnGameDetailsYes";
			this.btnGameDetailsYes.Size = new System.Drawing.Size(200, 52);
			this.btnGameDetailsYes.TabIndex = 2;
			this.btnGameDetailsYes.Text = "Yes";
			this.btnGameDetailsYes.Click += new System.EventHandler(this.btnGameDetailsYes_Click);
			// 
			// btnGameSummaryYes
			// 
			this.btnGameSummaryYes.BackColor = System.Drawing.Color.SkyBlue;
			this.btnGameSummaryYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnGameSummaryYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnGameSummaryYes.Location = new System.Drawing.Point(406, 96);
			this.btnGameSummaryYes.Name = "btnGameSummaryYes";
			this.btnGameSummaryYes.Size = new System.Drawing.Size(200, 52);
			this.btnGameSummaryYes.TabIndex = 1;
			this.btnGameSummaryYes.Text = "Yes";
			this.btnGameSummaryYes.Click += new System.EventHandler(this.btnGameSummaryYes_Click);
			// 
			// btnScoresYes
			// 
			this.btnScoresYes.BackColor = System.Drawing.Color.Lime;
			this.btnScoresYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnScoresYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnScoresYes.Location = new System.Drawing.Point(406, 36);
			this.btnScoresYes.Name = "btnScoresYes";
			this.btnScoresYes.Size = new System.Drawing.Size(200, 52);
			this.btnScoresYes.TabIndex = 0;
			this.btnScoresYes.Text = "Yes";
			this.btnScoresYes.Click += new System.EventHandler(this.btnScoresYes_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.btnPrint5,
																					this.btnPrint4,
																					this.btnPrint3,
																					this.btnPrint2,
																					this.btnPrint1});
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(16, 428);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(968, 112);
			this.groupBox2.TabIndex = 9;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Select Number of Copies to Print";
			// 
			// btnPrint5
			// 
			this.btnPrint5.BackColor = System.Drawing.Color.Lime;
			this.btnPrint5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPrint5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnPrint5.Location = new System.Drawing.Point(668, 40);
			this.btnPrint5.Name = "btnPrint5";
			this.btnPrint5.Size = new System.Drawing.Size(56, 56);
			this.btnPrint5.TabIndex = 5;
			this.btnPrint5.Text = "5";
			this.btnPrint5.Click += new System.EventHandler(this.btnPrint5_Click);
			// 
			// btnPrint4
			// 
			this.btnPrint4.BackColor = System.Drawing.Color.Lime;
			this.btnPrint4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPrint4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnPrint4.Location = new System.Drawing.Point(564, 40);
			this.btnPrint4.Name = "btnPrint4";
			this.btnPrint4.Size = new System.Drawing.Size(56, 56);
			this.btnPrint4.TabIndex = 4;
			this.btnPrint4.Text = "4";
			this.btnPrint4.Click += new System.EventHandler(this.btnPrint4_Click);
			// 
			// btnPrint3
			// 
			this.btnPrint3.BackColor = System.Drawing.Color.Lime;
			this.btnPrint3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPrint3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnPrint3.Location = new System.Drawing.Point(460, 40);
			this.btnPrint3.Name = "btnPrint3";
			this.btnPrint3.Size = new System.Drawing.Size(56, 56);
			this.btnPrint3.TabIndex = 3;
			this.btnPrint3.Text = "3";
			this.btnPrint3.Click += new System.EventHandler(this.btnPrint3_Click);
			// 
			// btnPrint2
			// 
			this.btnPrint2.BackColor = System.Drawing.Color.Lime;
			this.btnPrint2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPrint2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnPrint2.Location = new System.Drawing.Point(348, 40);
			this.btnPrint2.Name = "btnPrint2";
			this.btnPrint2.Size = new System.Drawing.Size(56, 56);
			this.btnPrint2.TabIndex = 2;
			this.btnPrint2.Text = "2";
			this.btnPrint2.Click += new System.EventHandler(this.btnPrint2_Click);
			// 
			// btnPrint1
			// 
			this.btnPrint1.BackColor = System.Drawing.Color.Red;
			this.btnPrint1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPrint1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnPrint1.Location = new System.Drawing.Point(244, 40);
			this.btnPrint1.Name = "btnPrint1";
			this.btnPrint1.Size = new System.Drawing.Size(56, 56);
			this.btnPrint1.TabIndex = 1;
			this.btnPrint1.Text = "1";
			this.btnPrint1.Click += new System.EventHandler(this.btnPrint1_Click);
			// 
			// pnlPreview
			// 
			this.pnlPreview.Location = new System.Drawing.Point(465, 612);
			this.pnlPreview.Name = "pnlPreview";
			this.pnlPreview.Size = new System.Drawing.Size(64, 48);
			this.pnlPreview.TabIndex = 10;
			this.pnlPreview.Click += new System.EventHandler(this.pnlPreview_Click);
			// 
			// lblTeeTimeSelected
			// 
			this.lblTeeTimeSelected.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.lblTeeTimeSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTeeTimeSelected.Location = new System.Drawing.Point(124, 4);
			this.lblTeeTimeSelected.Name = "lblTeeTimeSelected";
			this.lblTeeTimeSelected.Size = new System.Drawing.Size(160, 32);
			this.lblTeeTimeSelected.TabIndex = 24;
			this.lblTeeTimeSelected.Text = "Time Selected";
			this.lblTeeTimeSelected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblCourseSelected
			// 
			this.lblCourseSelected.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.lblCourseSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCourseSelected.Location = new System.Drawing.Point(292, 4);
			this.lblCourseSelected.Name = "lblCourseSelected";
			this.lblCourseSelected.Size = new System.Drawing.Size(696, 32);
			this.lblCourseSelected.TabIndex = 23;
			this.lblCourseSelected.Text = "WsCourse Selected";
			this.lblCourseSelected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTeeTime
			// 
			this.lblTeeTime.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.lblTeeTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTeeTime.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblTeeTime.Location = new System.Drawing.Point(12, 4);
			this.lblTeeTime.Name = "lblTeeTime";
			this.lblTeeTime.Size = new System.Drawing.Size(112, 32);
			this.lblTeeTime.TabIndex = 22;
			this.lblTeeTime.Text = "WsTee Time:";
			this.lblTeeTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.btnPlayer5,
																				 this.btnPlayer4,
																				 this.btnPlayer3,
																				 this.btnPlayer2,
																				 this.btnPlayer1});
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(996, 88);
			this.panel1.TabIndex = 25;
			// 
			// btnPlayer5
			// 
			this.btnPlayer5.BackColor = System.Drawing.Color.PaleGreen;
			this.btnPlayer5.Enabled = false;
			this.btnPlayer5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPlayer5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnPlayer5.Location = new System.Drawing.Point(652, 40);
			this.btnPlayer5.Name = "btnPlayer5";
			this.btnPlayer5.Size = new System.Drawing.Size(80, 40);
			this.btnPlayer5.TabIndex = 10;
			this.btnPlayer5.TabStop = false;
			// 
			// btnPlayer4
			// 
			this.btnPlayer4.BackColor = System.Drawing.Color.PaleGreen;
			this.btnPlayer4.Enabled = false;
			this.btnPlayer4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPlayer4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnPlayer4.Location = new System.Drawing.Point(532, 40);
			this.btnPlayer4.Name = "btnPlayer4";
			this.btnPlayer4.Size = new System.Drawing.Size(80, 40);
			this.btnPlayer4.TabIndex = 9;
			this.btnPlayer4.TabStop = false;
			// 
			// btnPlayer3
			// 
			this.btnPlayer3.BackColor = System.Drawing.Color.PaleGreen;
			this.btnPlayer3.Enabled = false;
			this.btnPlayer3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPlayer3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnPlayer3.Location = new System.Drawing.Point(412, 40);
			this.btnPlayer3.Name = "btnPlayer3";
			this.btnPlayer3.Size = new System.Drawing.Size(80, 40);
			this.btnPlayer3.TabIndex = 8;
			this.btnPlayer3.TabStop = false;
			// 
			// btnPlayer2
			// 
			this.btnPlayer2.BackColor = System.Drawing.Color.PaleGreen;
			this.btnPlayer2.Enabled = false;
			this.btnPlayer2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnPlayer2.Location = new System.Drawing.Point(292, 40);
			this.btnPlayer2.Name = "btnPlayer2";
			this.btnPlayer2.Size = new System.Drawing.Size(80, 40);
			this.btnPlayer2.TabIndex = 7;
			this.btnPlayer2.TabStop = false;
			// 
			// btnPlayer1
			// 
			this.btnPlayer1.BackColor = System.Drawing.Color.PaleGreen;
			this.btnPlayer1.Enabled = false;
			this.btnPlayer1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnPlayer1.Location = new System.Drawing.Point(172, 40);
			this.btnPlayer1.Name = "btnPlayer1";
			this.btnPlayer1.Size = new System.Drawing.Size(80, 40);
			this.btnPlayer1.TabIndex = 6;
			this.btnPlayer1.TabStop = false;
			// 
			// lblPlayers
			// 
			this.lblPlayers.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.lblPlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblPlayers.Location = new System.Drawing.Point(12, 40);
			this.lblPlayers.Name = "lblPlayers";
			this.lblPlayers.Size = new System.Drawing.Size(112, 36);
			this.lblPlayers.TabIndex = 26;
			this.lblPlayers.Text = "Players:";
			this.lblPlayers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ReportSelect
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(994, 688);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lblPlayers,
																		  this.lblTeeTimeSelected,
																		  this.lblCourseSelected,
																		  this.lblTeeTime,
																		  this.panel1,
																		  this.pnlPreview,
																		  this.groupBox2,
																		  this.groupBox1,
																		  this.btnCancel,
																		  this.btnPrint});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "ReportSelect";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Print Selected Reports";
			this.Load += new System.EventHandler(this.ReportSelect_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			bool reprint = false;
			if (espDB.g_State.NumberOfCopies > 0)
			{
				if (dac.CreateDataAccessFile())
				{
					this.ScoreCardPrinted = false;
					this.SummaryPrinted = false;
					this.DetailsPrinted = false;
					this.ReconciliationPrinted = false;

					// Create Instance of Game Summary
					gm = new GameMaster( ref espDB );

					// Setup Page Format
					PageSetupDialog myPageSetup = new PageSetupDialog();
					pd = new PrintDocument();
					myPageSetup.Document = pd;
					myPageSetup.PageSettings.PrinterSettings.Copies = espDB.g_State.NumberOfCopies;
					myPageSetup.PageSettings.PrinterSettings.Collate = true;
					printerResolutionX = 300;
					printerResolutionY = 300;
					myPageSetup.PageSettings.Margins.Left = 25;
					myPageSetup.PageSettings.Margins.Right = 25;
					myPageSetup.PageSettings.Margins.Top = 50;
					myPageSetup.PageSettings.Margins.Bottom = 50;

					this.pagesPrinted = 0;
					this.yPos = 0;

					// Print the SELECTED REPORTS
					pd.PrintPage += new PrintPageEventHandler( this.PrintReports );

					pd.Print();

					// Set Printed Flag for the Reports associated with the selected WsTee Time
					// and remove from the ReportsToBePrinted QUEUE.
					// Remove TEE Time Entry from DataIn (UnprintedRounds)
					espDB.DeleteFromUnprintedRoundsMasterTable();

					// UUUUUUUUUUUUUUUUUUUUUUUUUUU
					// Update "UnprintedRounds" table
					espDB.UpdateUnprintedRoundsTable();
					// UUUUUUUUUUUUUUUUUUUUUUUUUUU

					myPageSetup.Dispose();
				}
				else
				{
					// Unable to Print Reselect
					reprint = true;
					MessageBox.Show("Unable to print the Report at this time.  Please Select the PRINT option again.");
				}
				// Make sure that the MANAGER data access control file is deleted
				dac.DeleteDataAccessFile();
			}

			// Return to Manager
			//pd.Dispose();
			if (!reprint)this.Close();
		}

		private void ReportSelect_Load(object sender, System.EventArgs e)
		{
			// LOAD the Rounds, Players, Games, and all associated tables
			espDB.LoadRoundAndGameData();
			//==========================

			// Display Currently Selected WsCourse and Date
			lblCourseSelected.Text = espDB.g_State.CurrentCourseName;
			lblTeeTimeSelected.Text = espDB.g_State.TeeTime;

			for (int i=0;i<espDB.g_State.NumPlayers;i++)
			{
				switch ( i )
				{
					case 0:
						btnPlayer1.Text = espDB.cPlayers[i].Initials;
						break;
					case 1:
						btnPlayer2.Text = espDB.cPlayers[i].Initials;
						break;
					case 2:
						btnPlayer3.Text = espDB.cPlayers[i].Initials;
						break;
					case 3:
						btnPlayer4.Text = espDB.cPlayers[i].Initials;
						break;
					case 4:
						btnPlayer5.Text = espDB.cPlayers[i].Initials;
						break;
				}
			}

			// Scorecard print defaults to YES
			btnScoresYes.BackColor = Color.Lime;
			espDB.g_State.PrintScoreCard = true;
			btnScoresNo.BackColor = Color.Silver;

			if (espDB.g_State.NumGames == 0)
			{
				btnGameSummaryYes.BackColor = Color.Silver;
				espDB.g_State.PrintGameSummary = false;
				btnGameSummaryNo.BackColor = Color.Silver;
				btnGameSummaryYes.Enabled = false;
				btnGameSummaryNo.Enabled = false;
		
				btnGameDetailsYes.BackColor = Color.Silver;
				espDB.g_State.PrintGameDetails = false;
				btnGameDetailsNo.BackColor = Color.Silver;
				btnGameDetailsYes.Enabled = false;
				btnGameDetailsNo.Enabled = false;
		
				btnGameReconciliationYes.BackColor = Color.Silver;
				espDB.g_State.PrintGameReconciliation = false;
				btnGameReconciliationNo.BackColor = Color.Silver;
				btnGameReconciliationYes.Enabled = false;
				btnGameReconciliationNo.Enabled = false;
			}
			else
			{
				// Game Summary Report Defaults to YES
				btnGameSummaryYes.BackColor = Color.SkyBlue;
				espDB.g_State.PrintGameSummary = true;
				btnGameSummaryNo.BackColor = Color.Silver;
				btnGameSummaryYes.Enabled = true;
				btnGameSummaryNo.Enabled = true;
		
				btnGameDetailsYes.BackColor = Color.Silver;
				espDB.g_State.PrintGameDetails = false;
				btnGameDetailsNo.BackColor = Color.SkyBlue;
				btnGameDetailsYes.Enabled = true;
				btnGameDetailsNo.Enabled = true;
		
				btnGameReconciliationYes.BackColor = Color.Silver;
				espDB.g_State.PrintGameReconciliation = false;
				btnGameReconciliationNo.BackColor = Color.SkyBlue;
				btnGameReconciliationYes.Enabled = true;
				btnGameReconciliationNo.Enabled = true;
			}

			this.btnPrint1.Visible = true;
			if (espDB.g_State.NumPlayers > 0)
			{
				this.btnPrint1.BackColor = Color.Red;
				espDB.g_State.NumberOfCopies = 1;
				this.btnPrint2.Visible = true;
				this.btnPrint3.Visible = true;
				this.btnPrint4.Visible = true;
				this.btnPrint5.Visible = true;
			}
			else
			{
				this.btnPrint1.Visible = false;
				espDB.g_State.NumberOfCopies = 0;
				this.btnPrint2.Visible = false;
				this.btnPrint3.Visible = false;
				this.btnPrint4.Visible = false;
				this.btnPrint5.Visible = false;
			}

			//if (espDB.g_State.NumPlayers > 1)
			//this.btnPrint2.Visible = false;
			this.btnPrint2.BackColor = Color.Silver;
			//this.btnPrint3.Visible = false;
			this.btnPrint3.BackColor = Color.Silver;
			//this.btnPrint4.Visible = false;
			this.btnPrint4.BackColor = Color.Silver;
			//this.btnPrint5.Visible = false;
			this.btnPrint5.BackColor = Color.Silver;
		}

		private void btnScoresYes_Click(object sender, System.EventArgs e)
		{
			btnScoresYes.BackColor = Color.Lime;
			espDB.g_State.PrintScoreCard = true;
			btnScoresNo.BackColor = Color.Silver;
		}

		private void btnScoresNo_Click(object sender, System.EventArgs e)
		{
			btnScoresYes.BackColor = Color.Silver;
			espDB.g_State.PrintScoreCard = false;
			btnScoresNo.BackColor = Color.Lime;
		}

		private void btnGameSummaryYes_Click(object sender, System.EventArgs e)
		{
			btnGameSummaryYes.BackColor = Color.SkyBlue;
			espDB.g_State.PrintGameSummary = true;
			btnGameSummaryNo.BackColor = Color.Silver;
		}

		private void btnGameSummaryNo_Click(object sender, System.EventArgs e)
		{
			btnGameSummaryYes.BackColor = Color.Silver;
			espDB.g_State.PrintGameSummary = false;
			btnGameSummaryNo.BackColor = Color.SkyBlue;
		}

		private void btnGameDetailsYes_Click(object sender, System.EventArgs e)
		{
			btnGameDetailsYes.BackColor = Color.SkyBlue;
			espDB.g_State.PrintGameDetails = true;
			btnGameDetailsNo.BackColor = Color.Silver;
		}

		private void btnGameDetailsNo_Click(object sender, System.EventArgs e)
		{
			btnGameDetailsYes.BackColor = Color.Silver;
			espDB.g_State.PrintGameDetails = false;
			btnGameDetailsNo.BackColor = Color.SkyBlue;
		}

		private void btnGameReconciliationYes_Click(object sender, System.EventArgs e)
		{
			btnGameReconciliationYes.BackColor = Color.SkyBlue;
			espDB.g_State.PrintGameReconciliation = true;
			btnGameReconciliationNo.BackColor = Color.Silver;
		}

		private void btnGameReconciliationNo_Click(object sender, System.EventArgs e)
		{
			btnGameReconciliationYes.BackColor = Color.Silver;
			espDB.g_State.PrintGameReconciliation = false;
			btnGameReconciliationNo.BackColor = Color.SkyBlue;
		}

		private void btnPrint1_Click(object sender, System.EventArgs e)
		{
			espDB.g_State.NumberOfCopies = 1;
			this.btnPrint1.BackColor = Color.Red;
			this.btnPrint2.BackColor = Color.Silver;
			this.btnPrint3.BackColor = Color.Silver;
			this.btnPrint4.BackColor = Color.Silver;
			this.btnPrint5.BackColor = Color.Silver;
		}

		private void btnPrint2_Click(object sender, System.EventArgs e)
		{
			espDB.g_State.NumberOfCopies = 2;
			this.btnPrint1.BackColor = Color.Silver;
			this.btnPrint2.BackColor = Color.Red;
			this.btnPrint3.BackColor = Color.Silver;
			this.btnPrint4.BackColor = Color.Silver;
			this.btnPrint5.BackColor = Color.Silver;
		}

		private void btnPrint3_Click(object sender, System.EventArgs e)
		{
			espDB.g_State.NumberOfCopies = 3;
			this.btnPrint1.BackColor = Color.Silver;
			this.btnPrint2.BackColor = Color.Silver;
			this.btnPrint3.BackColor = Color.Red;
			this.btnPrint4.BackColor = Color.Silver;
			this.btnPrint5.BackColor = Color.Silver;
		}

		private void btnPrint4_Click(object sender, System.EventArgs e)
		{
			espDB.g_State.NumberOfCopies = 4;
			this.btnPrint1.BackColor = Color.Silver;
			this.btnPrint2.BackColor = Color.Silver;
			this.btnPrint3.BackColor = Color.Silver;
			this.btnPrint4.BackColor = Color.Red;
			this.btnPrint5.BackColor = Color.Silver;
		}

		private void btnPrint5_Click(object sender, System.EventArgs e)
		{
			espDB.g_State.NumberOfCopies = 5;
			this.btnPrint1.BackColor = Color.Silver;
			this.btnPrint2.BackColor = Color.Silver;
			this.btnPrint3.BackColor = Color.Silver;
			this.btnPrint4.BackColor = Color.Silver;
			this.btnPrint5.BackColor = Color.Red;
		}

		private void PrintReports(object sender, PrintPageEventArgs e)
		{
				e.Graphics.PageUnit = GraphicsUnit.Document;
				this.leftMargin = ((e.MarginBounds.Left*printerResolutionX)/100);
				this.topMargin = (e.MarginBounds.Top*printerResolutionY)/100;
				this.pageLeft = e.PageBounds.Left;
				this.pageRight = e.PageBounds.Right;
				this.pageTop = e.PageBounds.Top;
				this.pageBottom = e.PageBounds.Bottom;
				this.pageHeight = (e.MarginBounds.Height/100)*printerResolutionY;
				this.pageWidth = (int)((e.MarginBounds.Width/100)*printerResolutionX);
				this.lineHeight = (int)this.espFont10.GetHeight(e.Graphics);

				this.linesPerPage = (int)(this.pageHeight / this.lineHeight);
				yPos = topMargin;

			// Print the SELECTED REPORTS
			// Scores
			if ( espDB.g_State.PrintScoreCard & !this.ScoreCardPrinted )
			{
				pdPrintScoreCard(sender,e,Global.GROSS);
				this.ScoreCardPrinted = true;
			}

			// Check to see if a new page is needed yet
			if (this.NewPage)
			{
				this.NewPage = false;
				e.HasMorePages = true;
				return;
			}

			// Game Summary
			if ( espDB.g_State.PrintGameSummary & !this.SummaryPrinted)
			{
				pdPrintGameSummary(sender,e);
				this.SummaryPrinted = true;
			}

			// Check to see if a new page is needed yet
			if (this.NewPage)
			{
				this.NewPage = false;
				e.HasMorePages = true;
				return;
			}

			// Game Details
			if ( espDB.g_State.PrintGameDetails & !this.DetailsPrinted )
			{
				pdPrintGameDetails(sender,e);
				this.DetailsPrinted = true;
			}

			// Check to see if a new page is needed yet
			if (this.NewPage)
			{
				this.NewPage = false;
				e.HasMorePages = true;
				return;
			}

			// Game Reconciliation
			if ( espDB.g_State.PrintGameReconciliation & !this.ReconciliationPrinted )
			{
				pdPrintGameReconciliation(sender,e);
				this.ReconciliationPrinted = true;
			}
		}

		public void pdPrintScoreCard(object sender, PrintPageEventArgs e, byte GrossNetFlag)
		{
			bool [,] PrintTee = new Boolean[espDB.cTees.Length,3];
			bool PrintOneHandicap = false;
			bool PrintOnePar = false;

			// Determine print order
			DeterminePrintOrder(ref PrintTee, ref PrintOneHandicap, ref PrintOnePar);

			DrawScoreCardHeader(e);
			// Get all of the Tees from Class (ordered by decreasing Length using first hole).
			int [] tee = new int[espDB.cTees.Length];
			for (int i=0;i<espDB.cTees.Length;i++)
			{
				// Draw all of the Men's Tees
				if (espDB.cTees[i].Mens)
				{
					DrawTee(e, espDB.cTees[i],"T",0,GrossNetFlag); // Length Print
					// Check to see if handicap is to be printed
					if (PrintTee[i,1])
					{
						DrawTee(e, espDB.cTees[i],"H",0,GrossNetFlag); // Handicap Print
					}
					// Check to see if par is to be printed
					if (PrintTee[i,2])
					{
						DrawTee(e, espDB.cTees[i],"P",0,GrossNetFlag); // Par Print
					}
				}
			}
			// Draw Handicap Line
			if (PrintOneHandicap)
				DrawTee(e, espDB.cTees[0],"H",0,GrossNetFlag);
			// Draw blank line or scores
			for (int i=0;i<espDB.cCourse.MaxPlayers;i++)
			{
				if (i < espDB.g_State.NumPlayers)
					DrawTee(e, espDB.cTees[0],"S",i,GrossNetFlag);
				else
					DrawTee(e, espDB.cTees[0],"B",0,GrossNetFlag);
			}
			// Draw Par Line
			if (PrintOnePar)
				DrawTee(e, espDB.cTees[0],"P",0,GrossNetFlag);

			for (int i=0;i<espDB.cTees.Length;i++)
			{
				// Draw all of the Women's Tees
				if (!espDB.cTees[i].Mens)
				{
					DrawTee(e, espDB.cTees[i],"T",0,GrossNetFlag);

					// Check to see if handicap is to be printed
					if (PrintTee[i,1])
					{
						DrawTee(e, espDB.cTees[i],"H",0,GrossNetFlag); // Handicap Print
					}
					// Check to see if par is to be printed
					if (PrintTee[i,2])
					{
						DrawTee(e, espDB.cTees[i],"P",0,GrossNetFlag); // Par Print
					}
				}
			}
			DrawScoreCardFooter(e);

			/* TTTTTTTTTTTTTTTTTTTTTTTTTT
			yPos += 2;
			e.Graphics.DrawString("Height: "+pageHeight.ToString(),espFont10,Brushes.Black,leftMargin,yPos,new StringFormat());
			yPos += lineHeight;
			e.Graphics.DrawString("Width: "+pageWidth.ToString(),espFont10,Brushes.Black,leftMargin,yPos,new StringFormat());
			yPos += lineHeight;
			e.Graphics.DrawString("Line Height: "+lineHeight.ToString(),espFont10,Brushes.Black,leftMargin,yPos,new StringFormat());
			yPos += lineHeight;
			e.Graphics.DrawString("Number of Lines per Page: "+linesPerPage.ToString(),espFont10,Brushes.Black,leftMargin,yPos,new StringFormat());
			yPos += lineHeight;
			e.Graphics.DrawString("Left Margin: "+leftMargin.ToString(),espFont10,Brushes.Black,leftMargin,yPos,new StringFormat());
			yPos += lineHeight;
			e.Graphics.DrawString("Top Margin: "+topMargin.ToString(),espFont10,Brushes.Black,leftMargin,yPos,new StringFormat());
			yPos += lineHeight;
			e.Graphics.DrawString("Printer ResolutionX: "+printerResolutionX.ToString(),espFont10,Brushes.Black,leftMargin,yPos,new StringFormat());
			yPos += lineHeight;
			e.Graphics.DrawString("Printer ResolutionY: "+printerResolutionY.ToString(),espFont10,Brushes.Black,leftMargin,yPos,new StringFormat());

			yPos += lineHeight;
			e.Graphics.DrawString("Page Left: "+pageLeft.ToString(),espFont10,Brushes.Black,leftMargin,yPos,new StringFormat());
			yPos += lineHeight;
			e.Graphics.DrawString("Page Right: "+pageRight.ToString(),espFont10,Brushes.Black,leftMargin,yPos,new StringFormat());
			yPos += lineHeight;
			e.Graphics.DrawString("Page Top: "+pageTop.ToString(),espFont10,Brushes.Black,leftMargin,yPos,new StringFormat());
			yPos += lineHeight;
			e.Graphics.DrawString("Page Bottom: "+pageBottom.ToString(),espFont10,Brushes.Black,leftMargin,yPos,new StringFormat());

			// TTTTTTTTTTTTTTTTTTTTTTTTTT
			*/
			this.NewPage = false;
			// check to see if a new page is needed
			if (espDB.g_State.PrintGameSummary | espDB.g_State.PrintGameDetails | espDB.g_State.PrintGameReconciliation)
			{
				if ((espDB.cGames.Length > 8) & espDB.g_State.PrintGameSummary)
				{
					this.NewPage = true;
					this.pagesPrinted++;
					yPos = this.topMargin;
				}
			}
			else
			{
				this.NewPage = false;
				yPos += (int)(.25*printerResolutionY);
			}
		}

		/// <summary>
		/// Determine when handicaps and par values should be printed for each tee
		/// </summary>
		/// <param name="pt"></param>
		/// <param name="poh"></param>
		/// <param name="pop"></param>
		private void DeterminePrintOrder(ref bool [,] pt, ref bool poh, ref bool pop)
		{
			// Determine printer order according to the following rules
			/* Print Header
			 * Print <WsTee Name> <WsCourse Rating> <Length> <MEN>
			 *		===================
			 *		IF all HANDICAPS for all tees are the same for each Hole
			 *		THEN
			 *			Print Single Handicap line after all MEN'S tees are printed
			 *		ELSE
			 *			Print HANDICAP immediately after the associated TEE lengths
			 * 
			 *				(if there are more than two mens or ladies tees, check the Handicap
			 *				 and Par values for each) only print handicap or par after all that are the
			 *				 same (if ALL are not the same).
			 * 
			 *		===================
			 *		IF all PARS for all tees are the same for each Hole
			 *		THEN
			 *			Print Single PAR line before the LADIES tees are printed
			 *		ELSE
			 *			Print PAR immediately after the associated TEE Lengths or Handicaps
			 *		===================
			 *		COURSE RATING
			 *			a) Print Men's rating for tees with the mens flag set to true
			 *			b) Print Ladies rating for tees with the mens rating set to false
			 *			c) If the Mens rating and Ladies rating are the same, only print one line per a) and b)
			 *				else print both ratings.
			 *		===================
			 * Print <WsTee Name> <WsCourse Rating> <Length> <LADIES>
			 * Print Footer
			 */
			// Check for ONE tee
			if (espDB.cTees.Length == 1)
			{
				pt[0,0] = true; // Length
				pt[0,1] = false; // Handicap
				pt[0,2] = false; // Par
				poh = true;
				pop = true;
			}
			else
			{
				// More than 1 tee
				poh = false;
				pop = false;
				byte multiplePar = 0;
				byte multipleHandicap = 0;
				for (int i=0;i<espDB.cTees.Length;i++)
				{
					// Always print each WsTee.Length
					pt[i,0] = true; // Length
					pt[i,1] = false; // Handicap
					pt[i,2] = false; // Par
					if ( (i+1) < espDB.cTees.Length )
					{
						// Check Handicaps
						for (int j=0;j<espDB.cTees[i].Holes.Length;j++)
						{
							if (espDB.cTees[i].Holes[j].Handicap != espDB.cTees[i+1].Holes[j].Handicap)
							{
								// Handicaps are different, set print flag for current hole
								pt[i,1] = true;
								multipleHandicap++;
								break;
							}
						} // for j

						// Check Pars
						for (int j=0;j<espDB.cTees[i].Holes.Length;j++)
						{
							if (espDB.cTees[i].Holes[j].Par != espDB.cTees[i+1].Holes[j].Par)
							{
								// Pars are different, set print flag for current hole
								pt[i,2] = true;
								multiplePar++;
								break;
							}
						} // for j
					}
					else
					{
						// LAST TEE
						// Check for Multiple Handicaps
						if (multipleHandicap > 0)
						{
							// Multiple handicaps are being printed, so print handicap for Last tee
							pt[i,1] = true;
						}
						else
						{
							poh = true;
						}

						// Check for multiple Pars
						if (multiplePar > 0)
						{
							// Multiple Pars are being printed, so print handicap for Last tee
							pt[i,2] = true;
						}
						else
						{
							pop = true;
						}
					}
				} // for i
			}
		}

		private void PrintBottomToTop(PrintPageEventArgs e,string s, Font f, int xpos, int ypos, int xt, int yt)
		{
			Graphics g = e.Graphics;
			GraphicsState myState;

			myState = g.Save();
			g.TranslateTransform(xpos+.5f*xt-.5f*this.lineHeight,ypos+yt);
			g.RotateTransform(270.0f);
			g.DrawString(s,f,Brushes.Black,new RectangleF(0,0,yt,xt));
			g.Restore(myState);
		}

		private void DrawScoreCardHeader(PrintPageEventArgs e)
		{
			int xpos = (int)leftMargin;
			int ypos = (int)yPos;
			int ymax = (int)(3.93*printerResolutionY);
			int xt = 0;
			int yt = printerResolutionY-SPACING;
			int hole = 0;

			xBox1 = xpos;
			xBox2 = xpos;
			yBox12 = ypos;

			xpos += SPACING;
			ypos += SPACING;
			xt = (int)(LOGO*printerResolutionX);
			e.Graphics.DrawRectangle(linePen,xpos,ypos,xt,yt);
			Image logo = Image.FromFile("logo.bmp");
			e.Graphics.DrawImage(logo,xpos+1,ypos+1,xt-1,yt-1);
			xpos += xt+SPACING;
			xt = (int)(HOLES*printerResolutionX);
			for (int i=0;i<9;i++)
			{
				e.Graphics.DrawRectangle(linePen,xpos,ypos,xt,yt);
				hole++;
				e.Graphics.DrawString(hole.ToString(),espFont10,Brushes.Black,xpos+(int)(.08*printerResolutionX),ypos+yt-lineHeight,new StringFormat());
				xpos += xt;
			}
			xpos += SPACING;
			xt = (int)(OUT*printerResolutionX);
			e.Graphics.DrawRectangle(linePen,xpos,ypos,xt,yt);
			//Image out9 = Image.FromFile("out.bmp");
			//e.Graphics.DrawImage(out9,xpos+1,ypos+1,xt-1,yt-1);
			PrintBottomToTop(e,"Out",espFont10,xpos,ypos,xt,yt);
			xpos += xt;
			xpos += SPACING;
			wBox1 = xpos-xBox1+1;

			xpos += (int)(.05*printerResolutionX);
			xBox2 = xpos;
			xpos += SPACING;
			xt = (int)(INIT2*printerResolutionX);
			e.Graphics.DrawRectangle(linePen,xpos,ypos,xt,yt);
			xpos += xt+SPACING;
			xt = (int)(HOLES*printerResolutionX);
			for (int i=0;i<9;i++)
			{
				e.Graphics.DrawRectangle(linePen,xpos,ypos,xt,yt);
				hole++;
				e.Graphics.DrawString(hole.ToString(),espFont10,Brushes.Black,xpos+(int)(.03*printerResolutionX),ypos+yt-lineHeight,new StringFormat());
				xpos += xt;
			}
			xpos += SPACING;
			xt = (int)(OUT*printerResolutionX);
			for (int i=0;i<2;i++)
			{
				e.Graphics.DrawRectangle(linePen,xpos,ypos,xt,yt);
				if (i == 0)
				{
					//Image in9 = Image.FromFile("in.bmp");
					//e.Graphics.DrawImage(in9,xpos+1,ypos+1,xt-1,yt-1);
					PrintBottomToTop(e,"In",espFont10,xpos,ypos,xt,yt);
				}
				else
				{
					//Image total = Image.FromFile("total.bmp");
					//e.Graphics.DrawImage(total,xpos+1,ypos+1,xt-1,yt-1);
					PrintBottomToTop(e,"Total",espFont10,xpos,ypos,xt,yt);
				}
				xpos += xt;
			}
			xt = (int)(HOLES*printerResolutionX);
			for (int i=0;i<2;i++)
			{
				e.Graphics.DrawRectangle(linePen,xpos,ypos,xt,yt);
				if (i == 0)
				{
					//Image hdcp = Image.FromFile("handicap.bmp");
					//e.Graphics.DrawImage(hdcp,xpos+1,ypos+1,xt-1,yt-1);
					PrintBottomToTop(e,"Handicap",espFont10,xpos,ypos,xt,yt);
				}
				else
				{
					//Image net = Image.FromFile("net.bmp");
					//e.Graphics.DrawImage(net,xpos+1,ypos+1,xt-1,yt-1);
					PrintBottomToTop(e,"Net",espFont10,xpos,ypos,xt,yt);
				}
				xpos += xt;
			}
			xpos += SPACING;
			wBox2 = xpos-xBox2+1;

			// Header is ONE INCH in height
			yPos += printerResolutionY;
		}

		private void DrawScoreCardFooter(PrintPageEventArgs e)
		{
			int xpos = (int)leftMargin;
			int ypos = (int)yPos;
			int xpos2 = (int)(leftMargin+5+4*SPACING+(LOGO+9*HOLES+OUT)*printerResolutionX);
			int yt = (int)(HOLES*printerResolutionY);

			// Draw TWO outer boxes
			e.Graphics.DrawRectangle(linePen,xBox1,yBox12,wBox1,(yPos-yBox12+SPACING+2));
			e.Graphics.DrawRectangle(linePen,xBox2,yBox12,wBox2,(yPos-yBox12+SPACING+2));

			// Scorer
			e.Graphics.DrawString("Scorer______________________________",
				espFont10,Brushes.Black,xpos,ypos+yt-lineHeight,new StringFormat());
			// Attest
			e.Graphics.DrawString("Attest_____________________________  Date __________",
				espFont10,Brushes.Black,xpos2,ypos+yt-lineHeight,new StringFormat());
			// Sprinkler Heads
			ypos += yt;
			yPos += yt;
			yt = (int)(.8*HOLES*printerResolutionY);
			RectangleF heads = new RectangleF(xpos,ypos,pageWidth,yt);
			StringFormat sf = new StringFormat();
			sf.Alignment = StringAlignment.Center;
			e.Graphics.DrawString("Sprinkler heads are measured to the center of the green.",
				espFont8,Brushes.Black,heads,sf);
			ypos += yt;
			yPos += yt;

			// Draw Line Separator
			ypos += 5;
			e.Graphics.DrawLine(linePen,xpos,ypos,xBox2+wBox2,ypos);
			yPos += 5;
			yPos += (int)(.25*printerResolutionY);
		}

		private void DrawTee(PrintPageEventArgs e, TEE_INFORMATION tee, string thpbs, int player, byte GrossNetFlag)
		{
			string temp = "";
			int xpos = (int)leftMargin;
			int ypos = (int)yPos;
			int xorig = xpos;
			int yorig = ypos;
			int xt = 0;
			int yt = (int)(HOLES*printerResolutionY);
			int xtcr = (int)(.5*LOGO*printerResolutionX);
			int ytcr = (int)(.02*printerResolutionY);
			int hole = 0;
			sbyte holeScore = 0;

			// Set Background color
			Brush fillBrushM = new SolidBrush(Color.LightBlue);
			Brush fillBrushF = new SolidBrush(Color.LightPink);
			Brush fillBrushH = new SolidBrush(Color.LightGray);
			Brush fillBrushP = new SolidBrush(Color.LightGreen);

			xpos += SPACING;
			ypos += SPACING;
			xt = (int)(LOGO*printerResolutionX);
			e.Graphics.DrawRectangle(linePen,xpos,ypos,xt,yt);
			switch (thpbs)
			{
				case "T":
					// Print Ratings
					if (tee.Mens)
					{
						e.Graphics.FillRectangle(fillBrushM,xpos+1,ypos+1,xt-2,yt-2);
						temp = "M: "+tee.Ratings[(int)GENDER.Male].CourseRating.ToString();
						temp += "/"+tee.Ratings[(int)GENDER.Male].Slope.ToString();
						e.Graphics.DrawString(temp,	espFont7,Brushes.Black,
							xpos+xtcr,ypos+ytcr,new StringFormat());
						if (tee.FPrint)
						{
							temp = "L: "+tee.Ratings[(int)GENDER.Female].CourseRating.ToString();
							temp += "/"+tee.Ratings[(int)GENDER.Female].Slope.ToString();
							e.Graphics.DrawString(temp,	espFont7,Brushes.Black,
								xpos+xtcr,ypos+yt-lineHeight+ytcr,new StringFormat());
						}
					}
					else
					{
						e.Graphics.FillRectangle(fillBrushF,xpos+1,ypos+1,xt-2,yt-2);
						temp = "L: "+tee.Ratings[(int)GENDER.Female].CourseRating.ToString();
						temp += "/"+tee.Ratings[(int)GENDER.Female].Slope.ToString();
						e.Graphics.DrawString(temp,	espFont7,Brushes.Black,
							xpos+xtcr,ypos+ytcr,new StringFormat());
						if (tee.MPrint)
						{
							temp = "M: "+tee.Ratings[(int)GENDER.Male].CourseRating.ToString();
							temp += "/"+tee.Ratings[(int)GENDER.Male].Slope.ToString();
							e.Graphics.DrawString(temp,	espFont7,Brushes.Black,
								xpos+xtcr,ypos+yt-lineHeight+ytcr,new StringFormat());
						}
					}

					e.Graphics.DrawString(tee.TeeName.ToString(),espFont10,Brushes.Black,
						xpos,ypos+yt-lineHeight,new StringFormat());
					break;
				case "H":
					e.Graphics.FillRectangle(fillBrushH,xpos+1,ypos+1,xt-2,yt-2);
					e.Graphics.DrawString("Handicap",espFont10,Brushes.Black,xpos,ypos+yt-lineHeight,new StringFormat());
					break;
				case "P":
					e.Graphics.FillRectangle(fillBrushP,xpos+1,ypos+1,xt-2,yt-2);
					e.Graphics.DrawString("Par",espFont10,Brushes.Black,xpos,ypos+yt-lineHeight,new StringFormat());
					break;
				case "B":
					break;
				case "S":
					if (espDB.cPlayers[player].LastName == "")
					{
						temp = espDB.cPlayers[player].Initials.ToString();
					}
					else
					{
						temp = espDB.cPlayers[player].LastName;
						if (espDB.cPlayers[player].FirstName != "")
						{
							temp += ", " + espDB.cPlayers[player].FirstName.Substring(0,1).ToUpper();
						}
					}
					e.Graphics.DrawString(temp,espFont10,Brushes.Black,xpos,ypos+yt-lineHeight,new StringFormat());
					break;
			}
			xpos += xt+SPACING;
			xt = (int)(HOLES*printerResolutionX);
			int front9 = 0;
			for (int i=0;i<9;i++)
			{
				e.Graphics.DrawRectangle(linePen,xpos,ypos,xt,yt);
				switch (thpbs)
				{
					case "T":
						if (tee.Mens)
							e.Graphics.FillRectangle(fillBrushM,xpos+1,ypos+1,xt-2,yt-2);
						else
							e.Graphics.FillRectangle(fillBrushF,xpos+1,ypos+1,xt-2,yt-2);
						e.Graphics.DrawString(tee.Holes[hole].Length.ToString(),espFont9,Brushes.Black,xpos,ypos+yt-lineHeight,new StringFormat());
						front9 += tee.Holes[hole].Length;
						break;
					case "H":
						e.Graphics.FillRectangle(fillBrushH,xpos+1,ypos+1,xt-2,yt-2);
						e.Graphics.DrawString(tee.Holes[hole].Handicap.ToString(),espFont9,Brushes.Black,xpos,ypos+yt-lineHeight,new StringFormat());
						break;
					case "P":
						e.Graphics.FillRectangle(fillBrushP,xpos+1,ypos+1,xt-2,yt-2);
						e.Graphics.DrawString(tee.Holes[hole].Par.ToString(),espFont9,Brushes.Black,xpos,ypos+yt-lineHeight,new StringFormat());
						front9 += tee.Holes[hole].Par;
						break;
					case "B":
						break;
					case "S":
						if (GrossNetFlag == Global.GROSS)
							holeScore = (sbyte)espDB.cPlayers[player].Scores[hole];
						else
							holeScore = (sbyte)(espDB.cPlayers[player].Scores[hole] - espDB.cPlayers[player].Strokes[hole]);
						if (holeScore < 0) holeScore = 0;
						e.Graphics.DrawString(holeScore.ToString(),espFont10,Brushes.Black,xpos,ypos+yt-lineHeight,new StringFormat());
						front9 += holeScore;
						break;
				}
				hole++;
				xpos += xt;
			}
			xpos += SPACING;
			xt = (int)(OUT*printerResolutionX);
			e.Graphics.DrawRectangle(linePen,xpos,ypos,xt,yt);
			switch (thpbs)
			{
				case "T":
					if (tee.Mens)
						e.Graphics.FillRectangle(fillBrushM,xpos+1,ypos+1,xt-2,yt-2);
					else
						e.Graphics.FillRectangle(fillBrushF,xpos+1,ypos+1,xt-2,yt-2);
					e.Graphics.DrawString(front9.ToString(),espFont9,Brushes.Black,xpos,ypos+yt-lineHeight,new StringFormat());
					break;
				case "H":
					e.Graphics.FillRectangle(fillBrushH,xpos+1,ypos+1,xt-2,yt-2);
					break;
				case "P":
					e.Graphics.FillRectangle(fillBrushP,xpos+1,ypos+1,xt-2,yt-2);
					e.Graphics.DrawString(front9.ToString(),espFont9,Brushes.Black,xpos,ypos+yt-lineHeight,new StringFormat());
					break;
				case "B":
					break;
				case "S":
					e.Graphics.DrawString(front9.ToString(),espFont10,Brushes.Black,xpos,ypos+yt-lineHeight,new StringFormat());
					break;
			}
			xpos += xt;
			xpos += SPACING;

			xpos += (int)(.05*printerResolutionX);
			xpos += SPACING;
			xt = (int)(INIT2*printerResolutionX);
			e.Graphics.FillRectangle(fillBrushP,xpos+1,ypos+1,xt-2,yt-2);
			e.Graphics.FillRectangle(fillBrushH,xpos+1,ypos+1,xt-2,yt-2);
			switch (thpbs)
			{
				case "T":
					if (tee.Mens)
						e.Graphics.FillRectangle(fillBrushM,xpos+1,ypos+1,xt-2,yt-2);
					else
						e.Graphics.FillRectangle(fillBrushF,xpos+1,ypos+1,xt-2,yt-2);
					break;
				case "H":
					e.Graphics.FillRectangle(fillBrushH,xpos+1,ypos+1,xt-2,yt-2);
					break;
				case "P":
					e.Graphics.FillRectangle(fillBrushP,xpos+1,ypos+1,xt-2,yt-2);
					break;
				case "B":
					break;
				case "S":
					break;
			}
			e.Graphics.DrawRectangle(linePen,xpos,ypos,xt,yt);
			xpos += xt+SPACING;
			xt = (int)(HOLES*printerResolutionX);
			int back9 = 0;
			for (int i=0;i<9;i++)
			{
				e.Graphics.DrawRectangle(linePen,xpos,ypos,xt,yt);
				switch (thpbs)
				{
					case "T":
						if (tee.Mens)
							e.Graphics.FillRectangle(fillBrushM,xpos+1,ypos+1,xt-2,yt-2);
						else
							e.Graphics.FillRectangle(fillBrushF,xpos+1,ypos+1,xt-2,yt-2);
						e.Graphics.DrawString(tee.Holes[hole].Length.ToString(),espFont9,Brushes.Black,xpos,ypos+yt-lineHeight,new StringFormat());
						back9 += tee.Holes[hole].Length;
						break;
					case "H":
						e.Graphics.FillRectangle(fillBrushH,xpos+1,ypos+1,xt-2,yt-2);
						e.Graphics.DrawString(tee.Holes[hole].Handicap.ToString(),espFont9,Brushes.Black,xpos,ypos+yt-lineHeight,new StringFormat());
						break;
					case "P":
						e.Graphics.FillRectangle(fillBrushP,xpos+1,ypos+1,xt-2,yt-2);
						e.Graphics.DrawString(tee.Holes[hole].Par.ToString(),espFont9,Brushes.Black,xpos,ypos+yt-lineHeight,new StringFormat());
						back9 += tee.Holes[hole].Par;
						break;
					case "B":
						break;
					case "S":
						if (GrossNetFlag == Global.GROSS)
							holeScore = (sbyte)espDB.cPlayers[player].Scores[hole];
						else
							holeScore = (sbyte)(espDB.cPlayers[player].Scores[hole] - espDB.cPlayers[player].Strokes[hole]);
						if (holeScore < 0) holeScore = 0;
						e.Graphics.DrawString(holeScore.ToString(),espFont10,Brushes.Black,xpos,ypos+yt-lineHeight,new StringFormat());
						back9 += holeScore;
						break;
				}
				hole++;
				xpos += xt;
			}

			xpos += SPACING;
			xt = (int)(OUT*printerResolutionX);
			int total = front9+back9;
			for (int i=0;i<2;i++)
			{
				e.Graphics.DrawRectangle(linePen,xpos,ypos,xt,yt);
				switch (thpbs)
				{
					case "T":
						if (tee.Mens)
							e.Graphics.FillRectangle(fillBrushM,xpos+1,ypos+1,xt-2,yt-2);
						else
							e.Graphics.FillRectangle(fillBrushF,xpos+1,ypos+1,xt-2,yt-2);
						if (i == 0)
						{
							e.Graphics.DrawString(back9.ToString(),espFont9,Brushes.Black,xpos,ypos+yt-lineHeight,new StringFormat());
						}
						else
						{
								e.Graphics.DrawString(total.ToString(),espFont9,Brushes.Black,xpos,ypos+yt-lineHeight,new StringFormat());
						}
						break;
					case "H":
						e.Graphics.FillRectangle(fillBrushH,xpos+1,ypos+1,xt-2,yt-2);
						break;
					case "P":
						e.Graphics.FillRectangle(fillBrushP,xpos+1,ypos+1,xt-2,yt-2);
						if (i == 0)
						{
							e.Graphics.DrawString(back9.ToString(),espFont9,Brushes.Black,xpos,ypos+yt-lineHeight,new StringFormat());
						}
						else
						{
							e.Graphics.DrawString(total.ToString(),espFont9,Brushes.Black,xpos,ypos+yt-lineHeight,new StringFormat());
						}
						break;
					case "B":
						break;
					case "S":
						if (i == 0)
						{
							e.Graphics.DrawString(back9.ToString(),espFont10,Brushes.Black,xpos,ypos+yt-lineHeight,new StringFormat());
						}
						else
						{
							if (GrossNetFlag == Global.GROSS)
								e.Graphics.DrawString(total.ToString(),espFont10,Brushes.Black,xpos,ypos+yt-lineHeight,new StringFormat());
						}
						break;
				}
				xpos += xt;
			}
			xt = (int)(HOLES*printerResolutionX);
			for (int i=0;i<2;i++)
			{
				e.Graphics.DrawRectangle(linePen,xpos,ypos,xt,yt);
				switch (thpbs)
				{
					case "T":
						if (tee.Mens)
							e.Graphics.FillRectangle(fillBrushM,xpos+1,ypos+1,xt-2,yt-2);
						else
							e.Graphics.FillRectangle(fillBrushF,xpos+1,ypos+1,xt-2,yt-2);
						break;
					case "H":
						e.Graphics.FillRectangle(fillBrushH,xpos+1,ypos+1,xt-2,yt-2);
						break;
					case "P":
						e.Graphics.FillRectangle(fillBrushP,xpos+1,ypos+1,xt-2,yt-2);
						break;
					case "B":
						break;
					case "S":
						if (i == 0)
						{
							// Player Handicap
							short Handicap = 0;
							Handicap = (short)espDB.cPlayers[player].ComputedHandicap;
							// (TEMPORARY) FOR MILL CREEK PRO
							if (espDB.cPlayers[player].Gender == GENDER.Female) Handicap += 3;
							e.Graphics.DrawString(Handicap.ToString(),espFont10,Brushes.Black,xpos,ypos+yt-lineHeight,new StringFormat());
						}
						else
						{
							int net;
							// Player NET
							if (GrossNetFlag == Global.GROSS)
							{
								short Handicap = 0;
								Handicap = (short)espDB.cPlayers[player].ComputedHandicap;
								// (TEMPORARY) FOR MILL CREEK PRO
								if (espDB.cPlayers[player].Gender == GENDER.Female) Handicap += 3;
								net = (int)(total-Handicap);
							}
							else
							{
								net = (int)total;
							}
							e.Graphics.DrawString(net.ToString(),espFont10,Brushes.Black,xpos,ypos+yt-lineHeight,new StringFormat());
						}
						break;
				}
				xpos += xt;
			}
			xpos += SPACING;

			yPos += (int)(HOLES*printerResolutionY);
		}
// ===========================================================
		private void pdPrintGameSummary(object sender, PrintPageEventArgs e)
		{
			float summLineHeight = 0.2f;
			string temp = "";
			string tempg = "";
			int xpos = (int)leftMargin;
			int ypos = (int)yPos;
			int yt = 0;
			short [] totals = new short[Global.MAX_PLAYERS];
			byte [] team = new byte[Global.MAX_PLAYERS];	// the team we're examining
			//
			int xbox = xpos + (int)(1.0*printerResolutionX);
			int wbox = (int)(1.0*printerResolutionX);
			int yposScore = ypos + yt;
			RectangleF initialsBox = new RectangleF(xbox,ypos,wbox,yt);
			RectangleF totalBox = new RectangleF(xbox,yposScore,wbox,yt);
			StringFormat sf = new StringFormat();
			sf.Alignment = StringAlignment.Center;

			GameSummary gs = new GameSummary( ref espDB );
			GAME_INFORMATION game;

			// Print Header for Game Summary Section
			yt = 2*lineHeight;
			RectangleF header = new RectangleF(xpos,ypos,pageWidth,yt);
			e.Graphics.DrawString("Game Summaries",
				espFont14,Brushes.Black,header,sf);
			ypos += yt;
			yPos = ypos;

			// Draw Line Separator
			ypos += 5;
			e.Graphics.DrawLine(linePen,xpos,ypos,xpos+pageWidth,ypos);
			yPos += 5;

			// Verify that there are games to Print
			if (espDB.cGames.Length == 0)
			{
				// Print Message that there are no Games
				yt = (int)(summLineHeight*printerResolutionY);
				header = new RectangleF(xpos,ypos,pageWidth,yt);
				sf.Alignment = StringAlignment.Near;
				e.Graphics.DrawString("There are no Individual or Team games to be printed.",
					espFont12,Brushes.Black,header,sf);

				return;
			}

			// Loop thru the Games
			for (int i=0;i<espDB.cGames.Length;i++)
			{
				game = espDB.cGames[i];
				if (game.GameType == GAME_TYPE.TournamentGame) continue;
				// =======================
				if ((game.GameFlags & Global.GAME_FLAG_ROTATE_TEAMS) == Global.GAME_FLAG_ROTATE_TEAMS)
					flagRotate = true;
				else
					flagRotate = false;
				// =======================
				// Print User initials
				temp = "";
				for (int j=0;j<game.TeamSize;j++)
				{
					if (game.Team1[j] != 0xFF)
					{
						if (j > 0) temp += " / ";
						temp += espDB.cPlayers[game.Team1[j]].Initials;
					}
				}
				if (game.Team2[0] < 0xFF)
				{
					// There is a Member in Team2 so print VS
					// UNLESS the ROTATE flag is set.
					if (flagRotate)
						temp += " /  ";
					else
						temp += "  VS  ";
					for (int j=0;j<game.TeamSize;j++)
					{
						if (game.Team2[j] != 0xFF)
						{
							if (j > 0) temp += " / ";
							temp += espDB.cPlayers[game.Team2[j]].Initials;
						}
					}
				}
				// =======================
				// Print Game Description
				yt = (int)(summLineHeight*printerResolutionY);
				header = new RectangleF(xpos,ypos,pageWidth,yt);
				sf.Alignment = StringAlignment.Near;
				if (espDB.cGames[i].TeamGame)
				{
					// Print Team Game Header
					tempg = espDB.g_TeamGameStrings[(int)game.GameType - Global.TEAM_GAME_START];
				}
				else
				{
					// Print Individual Game Header
					tempg = espDB.g_IndividualGameStrings[(int)game.GameType - Global.INDIVIDUAL_GAME_START];
				}
				e.Graphics.DrawString(temp,
					espFont12,Brushes.Black,header,sf);
				sf.Alignment = StringAlignment.Center;
				e.Graphics.DrawString(tempg,
					espFont12,Brushes.Black,header,sf);

				ypos += yt;
				yPos = ypos;
				// ==============================================
				espDB.g_State.CurrentGame = (byte)i;
				// Compute Game Data
				gs.GameSummaryComputeGame(game);

				switch (game.GameType)
				{
					case GAME_TYPE.TeamBestBall:
					case GAME_TYPE.TeamBestBallAggregate:
					case GAME_TYPE.TeamHighLow:
					case GAME_TYPE.IndividualMatch:
						if (flagRotate)
						{
							byte currentTotal = 0;
							short segmentUnits = 0;
							short tempScore = 0;
							short [,] segmentScores = new short[Global.MAX_PLAYERS,3];
							byte [] playerIndex = new byte[Global.MAX_PLAYERS];
							// Initialize Team Score
							for (byte p=0;p<Global.MAX_PLAYERS;p++) for (byte s=0;s<3;s++) segmentScores[p,s] = 0;
							// Print rotation game
							for (byte teamNumber=0;true;teamNumber++)
							{
								// get this team - use hole zero here, it doesn't matter,
								// since we're going to look at each individual in isolation
								if (!gs.GameSummaryGetTeam(game, teamNumber, 0, ref team)) break;
								// loop over the players
								for (byte player = 0; player < game.TeamSize; player++) 
								{
									// Set Player Index
									playerIndex[currentTotal] = team[player];
									// clear this total
									totals[currentTotal] = 0;
									// we'll only look at the last hole of each rotation
									// we have three segments to look at.  Each
									// segment is worth one point, plus any presses that may
									// occur
									// we'll do three segments
									for (byte segment = 0; segment < (Global.MAX_HOLES / Global.HOLES_PER_TEAM_ROTATION); segment++) 
									{
										// for doubled games, we compute the doubled total and add it to
										// our running total
										if ((game.GameFlags & Global.GAME_PRESS_DOUBLE) == Global.GAME_PRESS_DOUBLE) 
										{
											// compute the doubled total
											segmentUnits = (short)EndComputeDoubledTotal((byte)(segment * Global.HOLES_PER_TEAM_ROTATION), 
												Global.HOLES_PER_TEAM_ROTATION, 
												espDB.cPlayers[team[player]], 
												game, 
												1);
											// not a doubled game, so we add one point for each segment and each press
										} 
										else 
										{
											// loop over this segment
											segmentUnits = 0;
											for (byte ii = (byte)(Global.HOLES_PER_TEAM_ROTATION * segment); 
												ii < (Global.HOLES_PER_TEAM_ROTATION * (segment + 1)); 
												ii++) 
											{
												// see if we have a press on this hole
												if (game.Presses[ii] > 0) 
												{
													// see if this player won this press
													if ((espDB.cPlayers[team[player]].GameScores[(Global.HOLES_PER_TEAM_ROTATION * (segment + 1)) - 1] -
														espDB.cPlayers[team[player]].GameScores[ii]) > 0) 
													{
														segmentUnits++; //totals[currentTotal]++; // = (short)(totals[currentTotal] + 1);
													} 
													else if ((espDB.cPlayers[team[player]].GameScores[(Global.HOLES_PER_TEAM_ROTATION * (segment + 1)) - 1] -
														espDB.cPlayers[team[player]].GameScores[ii]) < 0) 
													{
														segmentUnits--; //totals[currentTotal]--; // = (short)(totals[currentTotal] - 1);
													}
												} 
											} // for ii
											// award this bet to the player if they won this
											// segment
											if (espDB.cPlayers[team[player]].GameScores[(Global.HOLES_PER_TEAM_ROTATION * (segment + 1)) - 1] > 0) 
											{
												segmentUnits++; //totals[currentTotal]++; // = totals[currentTotal] + 1;
											} 
											else if (espDB.cPlayers[team[player]].GameScores[(Global.HOLES_PER_TEAM_ROTATION * (segment + 1)) - 1] < 0) 
											{
												segmentUnits--; //totals[currentTotal]--; // = totals[currentTotal] - 1;
											}
										}
										//**************
										if (NoPlayerScores((byte)(Global.HOLES_PER_TEAM_ROTATION * segment),
											(byte)(Global.HOLES_PER_TEAM_ROTATION * (segment + 1)),espDB.cPlayers[team[player]])) segmentUnits = 0;
										//**************
										segmentScores[team[player],segment] = segmentUnits;
										totals[currentTotal] += segmentUnits;
									} // for segment
									// move to the next total
									currentTotal++;
								} // for player
								//
							} // for teamNumber
							//
							// Print Team and score
							xbox = xpos + (int)(0.5*printerResolutionX);
							wbox = (int)(1.75*printerResolutionX);
							sf.Alignment = StringAlignment.Center;
							// ======================
							// Segment 1
							temp = espDB.cPlayers[playerIndex[0]].Initials + "/" + espDB.cPlayers[playerIndex[1]].Initials;
							temp += " vs ";
							temp += espDB.cPlayers[playerIndex[2]].Initials + "/" + espDB.cPlayers[playerIndex[3]].Initials;
							totalBox = new RectangleF(xbox,ypos,wbox,yt);
							e.Graphics.DrawString(temp,espFont11,Brushes.Black,totalBox,sf);
							tempScore = (short)(segmentScores[playerIndex[0],0]+segmentScores[playerIndex[1],0]);
							totalBox = new RectangleF(xbox,ypos+yt,wbox,yt);
							e.Graphics.DrawString(tempScore.ToString(),espFont11,Brushes.Black,totalBox,sf);
							// ======================
							// Segment 2
							xbox += wbox;
							temp = espDB.cPlayers[playerIndex[0]].Initials + "/" + espDB.cPlayers[playerIndex[2]].Initials;
							temp += " vs ";
							temp += espDB.cPlayers[playerIndex[1]].Initials + "/" + espDB.cPlayers[playerIndex[3]].Initials;
							totalBox = new RectangleF(xbox,ypos,wbox,yt);
							e.Graphics.DrawString(temp,espFont11,Brushes.Black,totalBox,sf);
							tempScore = (short)(segmentScores[playerIndex[0],1]+segmentScores[playerIndex[2],1]);
							totalBox = new RectangleF(xbox,ypos+yt,wbox,yt);
							e.Graphics.DrawString(tempScore.ToString(),espFont11,Brushes.Black,totalBox,sf);
							// ======================
							// Segment 3
							xbox += wbox;
							temp = espDB.cPlayers[playerIndex[0]].Initials + "/" + espDB.cPlayers[playerIndex[3]].Initials;
							temp += " vs ";
							temp += espDB.cPlayers[playerIndex[1]].Initials + "/" + espDB.cPlayers[playerIndex[2]].Initials;
							totalBox = new RectangleF(xbox,ypos,wbox,yt);
							e.Graphics.DrawString(temp,espFont11,Brushes.Black,totalBox,sf);
							tempScore = (short)(segmentScores[playerIndex[0],2]+segmentScores[playerIndex[3],2]);
							totalBox = new RectangleF(xbox,ypos+yt,wbox,yt);
							e.Graphics.DrawString(tempScore.ToString(),espFont11,Brushes.Black,totalBox,sf);
							// ======================
							// Segment Total
							xbox += wbox;
							wbox = (int)(0.4*printerResolutionX);
							for (byte p=0;p<4;p++)
							{
								temp = espDB.cPlayers[playerIndex[p]].Initials;
								totalBox = new RectangleF(xbox,ypos,wbox,yt);
								e.Graphics.DrawString(temp,espFont11,Brushes.Black,totalBox,sf);
								tempScore = (short)(totals[p]);
								totalBox = new RectangleF(xbox,ypos+yt,wbox,yt);
								e.Graphics.DrawString(tempScore.ToString(),espFont11,Brushes.Black,totalBox,sf);
								xbox += wbox;
							}
							// ======================
							ypos += yt;
							ypos += yt;
							yPos = ypos;
						}
						else
						{
							// No Rotate
							int front9 = 0, frontUnits = 0;
							int back9 = 0, backUnits = 0;
							int units = 0;
							xbox = xpos + (int)(1.0*printerResolutionX);
							wbox = (int)(2.25*printerResolutionX);
							sf.Alignment = StringAlignment.Near;

							// Do we have Doubled bets?
							if ((game.GameFlags & Global.GAME_PRESS_DOUBLE) == Global.GAME_PRESS_DOUBLE)
							{
								// DOUBLE Bets
								front9 = EndComputeDoubledTotal(0, 
									Global.HOLES_PER_HALF,
									espDB.cPlayers[game.Team1[0]],
									game,1);
								//**************
								if (NoPlayerScores(0,Global.HOLES_PER_HALF,
									espDB.cPlayers[game.Team1[0]])) front9 = 0;
								//**************
								// note that we might start with a bet of 2 for the back half, if the
								// back side was pressed
								if ((game.GameFlags & Global.GAME_FLAG_BACKSIDE_PRESS) == 
									Global.GAME_FLAG_BACKSIDE_PRESS) 
								{
									back9 = EndComputeDoubledTotal(Global.HOLES_PER_HALF, 
										Global.HOLES_PER_HALF,
										espDB.cPlayers[game.Team1[0]],
										game, 2);
								} 
								else 
								{
									back9 = EndComputeDoubledTotal(Global.HOLES_PER_HALF, 
										Global.HOLES_PER_HALF,
										espDB.cPlayers[game.Team1[0]],
										game, 1);
								}
								//**************
								if (NoPlayerScores(Global.HOLES_PER_HALF,Global.MAX_HOLES,
									espDB.cPlayers[game.Team1[0]])) back9 = 0;
								//**************

								// Assign Point for winning 18 Hole TOTAL
								units = 0;
								if ((front9 + back9) < 0) units -= 1;
								if ((front9 + back9) > 0) units += 1;

								// Assign Point for winning the half
								if (front9 < 0) units--;
								else if (front9 > 0) units++;
								if (back9 < 0) units--;
								else if (back9 > 0) units++;

								// Print front9
								// ======================
								totalBox = new RectangleF(xbox,ypos,wbox,yt);
								e.Graphics.DrawString("Front 9:  "+front9.ToString(),
									espFont12,Brushes.Black,totalBox,sf);
								// Print back9
								// ======================
								totalBox = new RectangleF(xbox+wbox,ypos,wbox,yt);
								e.Graphics.DrawString("Back 9:  "+back9.ToString(),
									espFont12,Brushes.Black,totalBox,sf);
								// Print units
								// ======================
								totalBox = new RectangleF(xbox+wbox+wbox,ypos,wbox,yt);
								e.Graphics.DrawString("Units:  "+units.ToString(),
									espFont14,Brushes.Black,totalBox,sf);
							}
							else
							{
								// Not DOUBLED
								// Print front9
								// ======================
								totalBox = new RectangleF(xbox,ypos,wbox,yt);
								e.Graphics.DrawString("Front 9:  "+
									EndPrintMatchWithPresses(0,0,Global.HOLES_PER_HALF,
									espDB.cPlayers[game.Team1[0]],game, ref units),
									espFont12,Brushes.Black,totalBox,sf);
								frontUnits = units;
								// Print back9
								// ======================
								totalBox = new RectangleF(xbox+wbox,ypos,wbox,yt);
								e.Graphics.DrawString("Back 9:  "+
									EndPrintMatchWithPresses(espDB.cPlayers[game.Team1[0]].GameScores[Global.HOLES_PER_HALF-1],
									Global.HOLES_PER_HALF,
									Global.HOLES_PER_HALF,
									espDB.cPlayers[game.Team1[0]],game, ref units),
									espFont12,Brushes.Black,totalBox,sf);
								backUnits = units;
								// Print units
								// ======================
								units = frontUnits + backUnits;
								// Check 18 Hole Total
								if (espDB.cPlayers[game.Team1[0]].GameScores[Global.MAX_HOLES-1] < 0)
									units--;
								else if (espDB.cPlayers[game.Team1[0]].GameScores[Global.MAX_HOLES-1] > 0)
									units++;

								// finally, we need to account for a backside press.  If there
								// is one, the back 9 (only!) counts for two units
								// check if we have a backside press
								if ((game.GameFlags & Global.GAME_FLAG_BACKSIDE_PRESS) == Global.GAME_FLAG_BACKSIDE_PRESS) 
								{
									// figure out who won the back side
									if ((espDB.cPlayers[game.Team1[0]].GameScores[Global.MAX_HOLES - 1] - 
										espDB.cPlayers[game.Team1[0]].GameScores[Global.HOLES_PER_HALF - 1]) > 0) 
									{
										// team 1 won it
										units++;
									} 
									else if ((espDB.cPlayers[game.Team1[0]].GameScores[Global.MAX_HOLES - 1] - 
										espDB.cPlayers[game.Team1[0]].GameScores[Global.HOLES_PER_HALF - 1]) < 0) 
									{
										// team 2 won it
										units--;
									}
								}

								totalBox = new RectangleF(xbox+wbox+wbox,ypos,wbox,yt);
								temp = "18 Holes: " + espDB.cPlayers[game.Team1[0]].GameScores[Global.MAX_HOLES-1];
								temp += "   Units: "+ units.ToString();
								e.Graphics.DrawString(temp,
									espFont14,Brushes.Black,totalBox,sf);
							}
							ypos += yt;
							yPos = ypos;
						}
						break;
					case GAME_TYPE.IndividualSkins:
					case GAME_TYPE.IndividualStats:
					case GAME_TYPE.IndividualNines:
					case GAME_TYPE.TeamWolfBestBall:
					case GAME_TYPE.TeamWolfHighLow:
						xbox = xpos + (int)(1.0*printerResolutionX);
						wbox = (int)(1.0*printerResolutionX);
						yposScore = ypos + yt;
						initialsBox = new RectangleF(xbox,ypos,wbox,yt);
						totalBox = new RectangleF(xbox,yposScore,wbox,yt);

						// Sum up individual player skins
						for (byte player=0;player<game.TeamSize;player++)
						{
							totals[player] = 0;
							// Loop over the holes
							for (int ii=0;ii<Global.MAX_HOLES;ii++)
							{
								totals[player] += espDB.cPlayers[game.Team1[player]].GameScores[ii];
							} // for (ii)

							// Print Player initials line (2) and skins line (3)
							e.Graphics.DrawString(espDB.cPlayers[game.Team1[player]].Initials.ToString(),
								espFont12,Brushes.Black,initialsBox,sf);
							e.Graphics.DrawString(totals[player].ToString(),
								espFont12,Brushes.Black,totalBox,sf);
							xbox += wbox;
							initialsBox = new RectangleF(xbox,ypos,wbox,yt);
							totalBox = new RectangleF(xbox,yposScore,wbox,yt);
						} // for (player)
						ypos += 2*yt;
						yPos = ypos;
						break;
					case GAME_TYPE.TeamSkins:
						if (flagRotate)
						{
							// ROTATE Teams
							byte pp = 0;
							short tempScore = 0;
							short [,] segmentScores = new short[Global.MAX_PLAYERS,3];
							short [] totalScores = new short[Global.MAX_PLAYERS];
							byte [] playerIndex = new byte[Global.MAX_PLAYERS];
							// Initialize Team Score
							for (byte p=0;p<Global.MAX_PLAYERS;p++) for (byte s=0;s<3;s++) segmentScores[p,s] = 0;
							// Compute rotation games
							for (byte teamNumber=0;true;teamNumber++)
							{
								// get this team - use hole zero here, it doesn't matter,
								// since we're going to look at each individual in isolation
								if (!gs.GameSummaryGetTeam(game, teamNumber, 0, ref team)) break;
								// loop over the players
								for (byte player = 0; player < game.TeamSize; player++) 
								{
									playerIndex[pp] = team[player];
									for (byte segment = 0; segment < (Global.MAX_HOLES / Global.HOLES_PER_TEAM_ROTATION); segment++) 
									{
										for (byte hole=((byte)(segment*Global.HOLES_PER_TEAM_ROTATION));hole<((byte)((segment+1)*Global.HOLES_PER_TEAM_ROTATION));hole++)
										{
											segmentScores[team[player],segment] += espDB.cPlayers[team[player]].GameScores[hole];
										}
										totalScores[pp] += segmentScores[team[player],segment];
									}
									pp++;
									// move to the next total
								} // Player
							} // TeamNumber
							//
							// Print Team and score
							xbox = xpos + (int)(0.5*printerResolutionX);
							wbox = (int)(1.75*printerResolutionX);
							sf.Alignment = StringAlignment.Center;
							// ======================
							// Segment 1
							temp = espDB.cPlayers[playerIndex[0]].Initials + "/" + espDB.cPlayers[playerIndex[1]].Initials;
							temp += " vs ";
							temp += espDB.cPlayers[playerIndex[2]].Initials + "/" + espDB.cPlayers[playerIndex[3]].Initials;
							totalBox = new RectangleF(xbox,ypos,wbox,yt);
							e.Graphics.DrawString(temp,espFont11,Brushes.Black,totalBox,sf);
							tempScore = (short)(segmentScores[playerIndex[0],0]);
							totalBox = new RectangleF(xbox,ypos+yt,wbox,yt);
							e.Graphics.DrawString(tempScore.ToString(),espFont11,Brushes.Black,totalBox,sf);
							// ======================
							// Segment 2
							xbox += wbox;
							temp = espDB.cPlayers[playerIndex[0]].Initials + "/" + espDB.cPlayers[playerIndex[2]].Initials;
							temp += " vs ";
							temp += espDB.cPlayers[playerIndex[1]].Initials + "/" + espDB.cPlayers[playerIndex[3]].Initials;
							totalBox = new RectangleF(xbox,ypos,wbox,yt);
							e.Graphics.DrawString(temp,espFont11,Brushes.Black,totalBox,sf);
							tempScore = (short)(segmentScores[playerIndex[0],1]);
							totalBox = new RectangleF(xbox,ypos+yt,wbox,yt);
							e.Graphics.DrawString(tempScore.ToString(),espFont11,Brushes.Black,totalBox,sf);
							// ======================
							// Segment 3
							xbox += wbox;
							temp = espDB.cPlayers[playerIndex[0]].Initials + "/" + espDB.cPlayers[playerIndex[3]].Initials;
							temp += " vs ";
							temp += espDB.cPlayers[playerIndex[1]].Initials + "/" + espDB.cPlayers[playerIndex[2]].Initials;
							totalBox = new RectangleF(xbox,ypos,wbox,yt);
							e.Graphics.DrawString(temp,espFont11,Brushes.Black,totalBox,sf);
							tempScore = (short)(segmentScores[playerIndex[0],2]);
							totalBox = new RectangleF(xbox,ypos+yt,wbox,yt);
							e.Graphics.DrawString(tempScore.ToString(),espFont11,Brushes.Black,totalBox,sf);
							// ======================
							// Segment Total
							xbox += wbox;
							wbox = (int)(0.4*printerResolutionX);
							for (byte p=0;p<4;p++)
							{
								temp = espDB.cPlayers[playerIndex[p]].Initials;
								totalBox = new RectangleF(xbox,ypos,wbox,yt);
								e.Graphics.DrawString(temp,espFont11,Brushes.Black,totalBox,sf);
								tempScore = (short)(totalScores[p]);
								totalBox = new RectangleF(xbox,ypos+yt,wbox,yt);
								e.Graphics.DrawString(tempScore.ToString(),espFont11,Brushes.Black,totalBox,sf);
								xbox += wbox;
							}
						}
						else
						{
							// Two scores to report
							totals[0] = 0;
							totals[1] = 0;

							// Loop over the holes for team1 and team2
							for (int ii=0;ii<Global.MAX_HOLES;ii++)
							{
								totals[0] += espDB.cPlayers[game.Team1[0]].GameScores[ii];
								totals[1] += espDB.cPlayers[game.Team2[0]].GameScores[ii];
							} // for (ii)

							// Build Team Header using each players initials
							string team1 = "";
							string team2 = "";
							for (byte player=0;player<game.TeamSize;player++)
							{
								if (player > 0)
								{
									team1 += "/";
									team2 += "/";
								}
								team1 += espDB.cPlayers[game.Team1[player]].Initials.ToString();
								team2 += espDB.cPlayers[game.Team2[player]].Initials.ToString();
							} // for (player)

							// Print Team initials line (2) and skins line (3)
							// ======================
							xbox = xpos + (int)(1.0*printerResolutionX);
							wbox = (int)(2.0*printerResolutionX);
							yposScore = ypos + yt;
							initialsBox = new RectangleF(xbox,ypos,wbox,yt);
							totalBox = new RectangleF(xbox,yposScore,wbox,yt);

							e.Graphics.DrawString(team1,
								espFont12,Brushes.Black,initialsBox,sf);
							e.Graphics.DrawString(totals[0].ToString(),
								espFont12,Brushes.Black,totalBox,sf);
							// ======================
							xbox += wbox;
							initialsBox = new RectangleF(xbox,ypos,wbox,yt);
							totalBox = new RectangleF(xbox,yposScore,wbox,yt);

							e.Graphics.DrawString(team2,
								espFont12,Brushes.Black,initialsBox,sf);
							e.Graphics.DrawString(totals[1].ToString(),
								espFont12,Brushes.Black,totalBox,sf);
						}
						// ======================
						ypos += 2*yt;
						yPos = ypos;
						break;
				}

				// ==============================================
				// Draw Line Separator
				ypos += (int)(.05*this.printerResolutionY);
				e.Graphics.DrawLine(linePen,xpos,ypos,xpos+pageWidth,ypos);
				yPos = ypos;
				// =======================
			} // End for (i)

			// check to see if a new page is needed
			if (ScoreCardPrinted & 
				(espDB.g_State.PrintGameDetails | espDB.g_State.PrintGameReconciliation))
			{
				this.NewPage = true;
				this.pagesPrinted++;
				yPos = this.topMargin;
			}
			else
			{
				this.NewPage = false;
				yPos += (int)(.5*printerResolutionY);
			}
		}

		/// <summary>
		/// Return TRUE if the player had any score in this segment.  Otherwise FALSE.
		/// </summary>
		/// <param name="start"></param>
		/// <param name="end"></param>
		/// <param name="pPlayer"></param>
		/// <returns></returns>
		bool NoPlayerScores(byte start,byte end, PLAYER_INFORMATION	pPlayer)
		{
			bool retval = true;
			for (byte hole=start;hole<end;hole++)
			{
				if (pPlayer.Scores[hole] > 0)
				{
					retval = false;
					break;
				}
			}
			return retval;
		}

		///////////////////////////////////////////////////////////////////////
		//  EndComputeDoubledTotal - computes the total for a double-bet press game
		//  Input:  StartHole - the hole to start at
		//			NumHoles - the number of holes to look at
		//			pPlayer - the player that has the game scores
		//			pGame - the game to look at
		//			StartBet - what does our bet start at?
		//  Output: none
		//  Return: the score
		//  Notes:
		///////////////////////////////////////////////////////////////////////
		int EndComputeDoubledTotal(byte StartHole,
			byte NumHoles,
			PLAYER_INFORMATION	pPlayer,
			GAME_INFORMATION		pGame,
			ushort StartBet)
		{
			ushort		currentBet;	// what is the current bet?
			short			prevScore;	// score from previous hole
			short			total;				// the accumulated total
			byte			ii;						// loop variable
				  	  
			// reset our bet
			currentBet = StartBet;
			// compute the previous score
			// for games with rotating teams, we don't have to worry
			// about it, the score is zeroed for us
			// for other games, it's the score at the end of the previous segment
			if ((pGame.GameFlags & Global.GAME_FLAG_ROTATE_TEAMS) == Global.GAME_FLAG_ROTATE_TEAMS) 
			{
				prevScore = 0;
			} 
			else 
			{
				// the previous score is zero (for the front half) or
				// the last hole of the first half (if we're doing the back)
				if (StartHole == Global.HOLES_PER_HALF) 
				{
					prevScore = pPlayer.GameScores[Global.HOLES_PER_HALF - 1];
				} 
				else 
				{
					prevScore = 0;
				}
			}
			// clear our total
			total = 0;
			// loop over the holes
			for (ii = 0; ii < NumHoles; ii++) 
			{
				// add to our running total
				total += (short)((pPlayer.GameScores[ii + StartHole] - prevScore) * currentBet);
				// record the previous score
				prevScore = pPlayer.GameScores[ii + StartHole];
				// if we're at a press, increment the bet
				if (pGame.Presses[ii + StartHole] != 0) 
				{
					// times two for the bet
					currentBet = (ushort)(currentBet * 2);
				}
			}
			return total;
		}

		///////////////////////////////////////////////////////////////////////
		//  EndPrintMatchWithPresses - prints out the result for a match (including presses)
		//  Input:  FirstHalf - the adjustment for the first half
		//			StartHole - the hole to start at
		//			NumHoles - the number of holes to look at
		//			pPlayer - the player that has the game scores
		//			pGame - the game to look at
		//  Output: none
		//  Return: the string to print
		//  Notes:
		///////////////////////////////////////////////////////////////////////
		string EndPrintMatchWithPresses(short FirstHalf,
			byte						StartHole,
			byte						NumHoles,
			PLAYER_INFORMATION	pPlayer,
			GAME_INFORMATION		pGame,
			ref int units)
		{
			string		fullString;	// string to print to the screen
			byte			ii;				// loop variable
			short			score;		// computed score
	
			// zero our full string
			fullString="";
			units = 0;
			
			// build the string for the main game
			// we need to look at the last hole, adjusted
			// for the first half (maybe)
			if (NoPlayerScores(StartHole,(byte)(StartHole+NumHoles),pPlayer)) score = 0;
			else score = (short)(pPlayer.GameScores[StartHole + NumHoles - 1] - FirstHalf);
			if (score < 0)
				units--;
			else if (score > 0)
				units++;
			
			// add it to the full string
			fullString += score.ToString();

			// see if we have presses for this game
			// if we do, we know they're new games (we looked
			// at doubled bets above
			if ((pGame.GameFlags & Global.GAME_PRESS_MASK) > 0) 
			{
				// we do, we need to loop over the holes
				// whenever we find a press, we need to record
				// it's offset from the main game, and then
				// print the press score to the screen
				// loop over the holes
				for (ii = 0; ii < NumHoles; ii++) 
				{
					// check if there is a press here
					if (pGame.Presses[ii + StartHole] != 0) 
					{
						// there is, so create the string
						// with the new score
						score = (short)((pPlayer.GameScores[StartHole + NumHoles - 1] - FirstHalf) - 
							(pPlayer.GameScores[ii + StartHole] - FirstHalf));
						// add it to the full string
						fullString += "/"+score.ToString();
						if (score < 0)
							units--;
						else if (score > 0)
							units++;
					}
				}
			}
			// return full string
			return fullString;
		}

		// ===========================================================
		private void pdPrintGameDetails(object sender, PrintPageEventArgs e)
		{
			int xpos = (int)leftMargin;
			int ypos = (int)yPos;
			int yt = 0;

			// Print Header for Game Details Section
			yt = 2*lineHeight;
			RectangleF header = new RectangleF(xpos,ypos,pageWidth,yt);
			StringFormat sf = new StringFormat();
			sf.Alignment = StringAlignment.Center;
			e.Graphics.DrawString("Game Details",
				espFont14,Brushes.Black,header,sf);
			ypos += yt;
			yPos = ypos;

			// ==============================================
			// Print DETAIL Reports
			// ==============================================

			/*
				// Compute the number of players in the Game
				if ((game.GameType == GAME_TYPE.IndividualSkins) ||
					(game.GameType == GAME_TYPE.TeamWolf))
				{
					// The number of players in the game is the team size
					playersInGame = game.TeamSize;
				}
				else
				{
					// The number of players in the game is team size TIMES 2
					playersInGame = (byte)(game.TeamSize*2);
				}
				*/

			// ==============================================
			// Draw Line Separator
			ypos += 5;
			e.Graphics.DrawLine(linePen,xpos,ypos,xpos+pageWidth,ypos);
			yPos += 5;

			// check to see if a new page is needed
			if ((ScoreCardPrinted | SummaryPrinted) & 
				espDB.g_State.PrintGameReconciliation &
				!(espDB.g_State.PrintScoreCard & espDB.g_State.PrintGameSummary))
			{
				this.NewPage = true;
				this.pagesPrinted++;
				yPos = this.topMargin;
			}
			else
			{
				this.NewPage = false;
				yPos += (int)(.5*printerResolutionY);
			}
		}

		// ===========================================================
		private void pdPrintGameReconciliation(object sender, PrintPageEventArgs e)
		{
			int xpos = (int)leftMargin;
			int ypos = (int)yPos+lineHeight;
			int yt = 0;

			// Print Header for Game Reconciliation Section
			yt = 2*lineHeight;
			RectangleF header = new RectangleF(xpos,ypos,pageWidth,yt);
			StringFormat sf = new StringFormat();
			sf.Alignment = StringAlignment.Center;
			e.Graphics.DrawString("Game Reconciliation",
				espFont14,Brushes.Black,header,sf);
			ypos += yt;
			yPos = ypos;

			// ==============================================
			// Print Reconciliation Report
			// ==============================================

			// ==============================================

			// Draw Line Separator
			ypos += 5;
			e.Graphics.DrawLine(linePen,xpos,ypos,xpos+pageWidth,ypos);
			yPos += 5;

			this.NewPage = false;
		}

		// ===========================================================
		private void pnlPreview_Click(object sender, System.EventArgs e)
		{
			if (espDB.g_State.NumberOfCopies > 0)
			{
				if (dac.CreateDataAccessFile())
				{
					this.ScoreCardPrinted = false;
					this.SummaryPrinted = false;
					this.DetailsPrinted = false;
					this.ReconciliationPrinted = false;

					// Create Instance of Game Summary
					gm = new GameMaster( ref espDB );

					// Setup Page Format
					PageSetupDialog myPageSetup = new PageSetupDialog();
					PrintDocument pd = new PrintDocument();
					myPageSetup.Document = pd;
					myPageSetup.PageSettings.PrinterSettings.Copies = espDB.g_State.NumberOfCopies;
					myPageSetup.PageSettings.PrinterSettings.Collate = true;
					printerResolutionX = 300;
					printerResolutionY = 300;
					myPageSetup.PageSettings.Margins.Left = 25;
					myPageSetup.PageSettings.Margins.Right = 25;
					myPageSetup.PageSettings.Margins.Top = 50;
					myPageSetup.PageSettings.Margins.Bottom = 50;

					this.pagesPrinted = 0;
					this.yPos = 0;

					PrintPreviewDialog ppd = new PrintPreviewDialog();

					pd.PrintPage += new PrintPageEventHandler( this.PrintReports );

					//pd.Print();
					ppd.Document = pd;
					ppd.ShowDialog();
					myPageSetup.Dispose();
				}
				else
				{
					// Unable to Print Reselect
					MessageBox.Show("Unable to DISPLAY the Report at this time.  Please Select the DISPLAY option again.");
				}
				// Make sure that the MANAGER control file is deleted.
				dac.DeleteDataAccessFile();
			}
		}

/*
		private void pdPrintPage(object sender, PrintPageEventArgs e)
		{
			float yPos = 0;
			float leftMargin = e.MarginBounds.Left;
			float topMargin = e.MarginBounds.Top;
			string line = null;
			Font mainFont = new Font( "Arial", 10);

			// Lines Per Page
			int linesPerPage = (int)(e.MarginBounds.Height / mainFont.GetHeight(e.Graphics));
			int lineNo = this.pagesPrinted * linesPerPage;

			yPos += 2;
			e.Graphics.DrawString("Height: "+pageHeight.ToString(),espFont10,Brushes.Black,leftMargin,yPos,new StringFormat());
			yPos += lineHeight;
			e.Graphics.DrawString("Width: "+pageWidth.ToString(),espFont10,Brushes.Black,leftMargin,yPos,new StringFormat());
			yPos += lineHeight;
			e.Graphics.DrawString("Line Height: "+lineHeight.ToString(),espFont10,Brushes.Black,leftMargin,yPos,new StringFormat());
			yPos += lineHeight;
			e.Graphics.DrawString("Number of Lines per Page: "+linesPerPage.ToString(),espFont10,Brushes.Black,leftMargin,yPos,new StringFormat());
			yPos += lineHeight;
			e.Graphics.DrawString("Left Margin: "+leftMargin.ToString(),espFont10,Brushes.Black,leftMargin,yPos,new StringFormat());
			yPos += lineHeight;
			e.Graphics.DrawString("Top Margin: "+topMargin.ToString(),espFont10,Brushes.Black,leftMargin,yPos,new StringFormat());
			yPos += lineHeight;
			e.Graphics.DrawString("Printer ResolutionX: "+printerResolutionX.ToString(),espFont10,Brushes.Black,leftMargin,yPos,new StringFormat());
			yPos += lineHeight;
			e.Graphics.DrawString("Printer ResolutionY: "+printerResolutionY.ToString(),espFont10,Brushes.Black,leftMargin,yPos,new StringFormat());

			yPos += lineHeight;
			e.Graphics.DrawString("Page Left: "+pageLeft.ToString(),espFont10,Brushes.Black,leftMargin,yPos,new StringFormat());
			yPos += lineHeight;
			e.Graphics.DrawString("Page Right: "+pageRight.ToString(),espFont10,Brushes.Black,leftMargin,yPos,new StringFormat());
			yPos += lineHeight;
			e.Graphics.DrawString("Page Top: "+pageTop.ToString(),espFont10,Brushes.Black,leftMargin,yPos,new StringFormat());
			yPos += lineHeight;
			e.Graphics.DrawString("Page Bottom: "+pageBottom.ToString(),espFont10,Brushes.Black,leftMargin,yPos,new StringFormat());

			int count = 0;
			int nLines = 15;
			while (count < linesPerPage && lineNo < nLines)
			{
				line = "This is fixed text to be printed on Line " + lineNo.ToString() + ".";
				yPos = topMargin + (count * mainFont.GetHeight(e.Graphics));
				e.Graphics.DrawString(line,mainFont,Brushes.Black,leftMargin,yPos,new StringFormat());
				lineNo++;
				count++;
			}

			// If more lines exist, print another page.
			if (nLines > lineNo)
				e.HasMorePages = true;
			else
				e.HasMorePages = false;
			this.pagesPrinted++;
		}
*/
	}
}
