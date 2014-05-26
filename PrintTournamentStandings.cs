using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ESPmanager
{
	/// <summary>
	/// Summary description for PrintTournamentStandings.
	/// </summary>
	public class PrintTournamentStandings : System.Windows.Forms.Form
	{
		private DatabaseAccessControl dac = new DatabaseAccessControl();
		private Database espDB;
		private DataSet ds;
		private int _TournamentID = 0;
		private TourLiteCompute tlc;
		private bool printBestBallFlag = false;
		private bool print123RotationFlag = false;
		private bool print321RotationFlag = false;
		private bool printSkinsFlag = false;
		private bool printTeamSkinsFlag = false;
		private bool printScrambleFlag = false;

		private System.Windows.Forms.Panel pnlPreview;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnCopies;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btn123RotationNo;
		private System.Windows.Forms.Button btnSkinsNo;
		private System.Windows.Forms.Label lbl123Rotation;
		private System.Windows.Forms.Label lblIndividualSkins;
		private System.Windows.Forms.Button btn123RotationYes;
		private System.Windows.Forms.Button btnSkinsYes;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnPrint;
		private System.Windows.Forms.TextBox txtCopies;
		private System.Windows.Forms.Button btnTeamSkinsNo;
		private System.Windows.Forms.Label lblTeamSkins;
		private System.Windows.Forms.Button btnTeamSkinsYes;
		private System.Windows.Forms.Button btnScrambleNo;
		private System.Windows.Forms.Label lblScramble;
		private System.Windows.Forms.Button btnScrambleYes;
		private System.Windows.Forms.Button btn321RotationNo;
		private System.Windows.Forms.Label lbl321Rotation;
		private System.Windows.Forms.Button btn321RotationYes;
		private System.Windows.Forms.Button btnCompute;
		private System.Windows.Forms.Button btnBestBallNo;
		private System.Windows.Forms.Label lblBestBall;
		private System.Windows.Forms.Button btnBestBallYes;
		private System.Windows.Forms.Label lblComputed;
		private System.Windows.Forms.Timer timerStandings;
		private System.ComponentModel.IContainer components;

		public PrintTournamentStandings( ref Database espdb )
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
			this.pnlPreview = new System.Windows.Forms.Panel();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtCopies = new System.Windows.Forms.TextBox();
			this.btnCopies = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btn321RotationNo = new System.Windows.Forms.Button();
			this.lbl321Rotation = new System.Windows.Forms.Label();
			this.btn321RotationYes = new System.Windows.Forms.Button();
			this.btnScrambleNo = new System.Windows.Forms.Button();
			this.lblScramble = new System.Windows.Forms.Label();
			this.btnScrambleYes = new System.Windows.Forms.Button();
			this.btnTeamSkinsNo = new System.Windows.Forms.Button();
			this.lblTeamSkins = new System.Windows.Forms.Label();
			this.btnTeamSkinsYes = new System.Windows.Forms.Button();
			this.btn123RotationNo = new System.Windows.Forms.Button();
			this.btnBestBallNo = new System.Windows.Forms.Button();
			this.btnSkinsNo = new System.Windows.Forms.Button();
			this.lbl123Rotation = new System.Windows.Forms.Label();
			this.lblBestBall = new System.Windows.Forms.Label();
			this.lblIndividualSkins = new System.Windows.Forms.Label();
			this.btn123RotationYes = new System.Windows.Forms.Button();
			this.btnBestBallYes = new System.Windows.Forms.Button();
			this.btnSkinsYes = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnPrint = new System.Windows.Forms.Button();
			this.btnCompute = new System.Windows.Forms.Button();
			this.lblComputed = new System.Windows.Forms.Label();
			this.timerStandings = new System.Windows.Forms.Timer(this.components);
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlPreview
			// 
			this.pnlPreview.Location = new System.Drawing.Point(466, 648);
			this.pnlPreview.Name = "pnlPreview";
			this.pnlPreview.Size = new System.Drawing.Size(64, 24);
			this.pnlPreview.TabIndex = 15;
			this.pnlPreview.Click += new System.EventHandler(this.pnlPreview_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.txtCopies,
																					this.btnCopies});
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(107, 484);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(456, 100);
			this.groupBox2.TabIndex = 14;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Specify the Number of Copies to Print";
			// 
			// txtCopies
			// 
			this.txtCopies.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtCopies.Location = new System.Drawing.Point(248, 45);
			this.txtCopies.Name = "txtCopies";
			this.txtCopies.Size = new System.Drawing.Size(148, 32);
			this.txtCopies.TabIndex = 2;
			this.txtCopies.Text = "";
			this.txtCopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btnCopies
			// 
			this.btnCopies.BackColor = System.Drawing.Color.Red;
			this.btnCopies.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCopies.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCopies.Location = new System.Drawing.Point(60, 36);
			this.btnCopies.Name = "btnCopies";
			this.btnCopies.Size = new System.Drawing.Size(160, 50);
			this.btnCopies.TabIndex = 1;
			this.btnCopies.Text = "Copies";
			this.btnCopies.Click += new System.EventHandler(this.btnCopies_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.btn321RotationNo,
																					this.lbl321Rotation,
																					this.btn321RotationYes,
																					this.btnScrambleNo,
																					this.lblScramble,
																					this.btnScrambleYes,
																					this.btnTeamSkinsNo,
																					this.lblTeamSkins,
																					this.btnTeamSkinsYes,
																					this.btn123RotationNo,
																					this.btnBestBallNo,
																					this.btnSkinsNo,
																					this.lbl123Rotation,
																					this.lblBestBall,
																					this.lblIndividualSkins,
																					this.btn123RotationYes,
																					this.btnBestBallYes,
																					this.btnSkinsYes});
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(24, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(948, 400);
			this.groupBox1.TabIndex = 13;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Standings to be Printed.";
			// 
			// btn321RotationNo
			// 
			this.btn321RotationNo.BackColor = System.Drawing.Color.SkyBlue;
			this.btn321RotationNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn321RotationNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn321RotationNo.Location = new System.Drawing.Point(628, 212);
			this.btn321RotationNo.Name = "btn321RotationNo";
			this.btn321RotationNo.Size = new System.Drawing.Size(244, 48);
			this.btn321RotationNo.TabIndex = 20;
			this.btn321RotationNo.Text = "No";
			this.btn321RotationNo.Click += new System.EventHandler(this.btn321RotationNo_Click);
			// 
			// lbl321Rotation
			// 
			this.lbl321Rotation.Location = new System.Drawing.Point(48, 224);
			this.lbl321Rotation.Name = "lbl321Rotation";
			this.lbl321Rotation.Size = new System.Drawing.Size(280, 24);
			this.lbl321Rotation.TabIndex = 19;
			this.lbl321Rotation.Text = "3-2-1 Ball Rotation";
			// 
			// btn321RotationYes
			// 
			this.btn321RotationYes.BackColor = System.Drawing.Color.SkyBlue;
			this.btn321RotationYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn321RotationYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn321RotationYes.Location = new System.Drawing.Point(344, 212);
			this.btn321RotationYes.Name = "btn321RotationYes";
			this.btn321RotationYes.Size = new System.Drawing.Size(244, 48);
			this.btn321RotationYes.TabIndex = 18;
			this.btn321RotationYes.Text = "Yes";
			this.btn321RotationYes.Click += new System.EventHandler(this.btn321RotationYes_Click);
			// 
			// btnScrambleNo
			// 
			this.btnScrambleNo.BackColor = System.Drawing.Color.SkyBlue;
			this.btnScrambleNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnScrambleNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnScrambleNo.Location = new System.Drawing.Point(628, 324);
			this.btnScrambleNo.Name = "btnScrambleNo";
			this.btnScrambleNo.Size = new System.Drawing.Size(244, 48);
			this.btnScrambleNo.TabIndex = 17;
			this.btnScrambleNo.Text = "No";
			this.btnScrambleNo.Click += new System.EventHandler(this.btnScrambleNo_Click);
			// 
			// lblScramble
			// 
			this.lblScramble.Location = new System.Drawing.Point(48, 336);
			this.lblScramble.Name = "lblScramble";
			this.lblScramble.Size = new System.Drawing.Size(280, 24);
			this.lblScramble.TabIndex = 16;
			this.lblScramble.Text = "Scramble";
			// 
			// btnScrambleYes
			// 
			this.btnScrambleYes.BackColor = System.Drawing.Color.SkyBlue;
			this.btnScrambleYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnScrambleYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnScrambleYes.Location = new System.Drawing.Point(344, 324);
			this.btnScrambleYes.Name = "btnScrambleYes";
			this.btnScrambleYes.Size = new System.Drawing.Size(244, 48);
			this.btnScrambleYes.TabIndex = 15;
			this.btnScrambleYes.Text = "Yes";
			this.btnScrambleYes.Click += new System.EventHandler(this.btnScrambleYes_Click);
			// 
			// btnTeamSkinsNo
			// 
			this.btnTeamSkinsNo.BackColor = System.Drawing.Color.SkyBlue;
			this.btnTeamSkinsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnTeamSkinsNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnTeamSkinsNo.Location = new System.Drawing.Point(628, 268);
			this.btnTeamSkinsNo.Name = "btnTeamSkinsNo";
			this.btnTeamSkinsNo.Size = new System.Drawing.Size(244, 48);
			this.btnTeamSkinsNo.TabIndex = 14;
			this.btnTeamSkinsNo.Text = "No";
			this.btnTeamSkinsNo.Click += new System.EventHandler(this.btnTeamSkinsNo_Click);
			// 
			// lblTeamSkins
			// 
			this.lblTeamSkins.Location = new System.Drawing.Point(48, 280);
			this.lblTeamSkins.Name = "lblTeamSkins";
			this.lblTeamSkins.Size = new System.Drawing.Size(280, 24);
			this.lblTeamSkins.TabIndex = 13;
			this.lblTeamSkins.Text = "Team Skins";
			// 
			// btnTeamSkinsYes
			// 
			this.btnTeamSkinsYes.BackColor = System.Drawing.Color.SkyBlue;
			this.btnTeamSkinsYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnTeamSkinsYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnTeamSkinsYes.Location = new System.Drawing.Point(344, 268);
			this.btnTeamSkinsYes.Name = "btnTeamSkinsYes";
			this.btnTeamSkinsYes.Size = new System.Drawing.Size(244, 48);
			this.btnTeamSkinsYes.TabIndex = 12;
			this.btnTeamSkinsYes.Text = "Yes";
			this.btnTeamSkinsYes.Click += new System.EventHandler(this.btnTeamSkinsYes_Click);
			// 
			// btn123RotationNo
			// 
			this.btn123RotationNo.BackColor = System.Drawing.Color.SkyBlue;
			this.btn123RotationNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn123RotationNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn123RotationNo.Location = new System.Drawing.Point(628, 156);
			this.btn123RotationNo.Name = "btn123RotationNo";
			this.btn123RotationNo.Size = new System.Drawing.Size(244, 48);
			this.btn123RotationNo.TabIndex = 11;
			this.btn123RotationNo.Text = "No";
			this.btn123RotationNo.Click += new System.EventHandler(this.btn123RotationNo_Click);
			// 
			// btnBestBallNo
			// 
			this.btnBestBallNo.BackColor = System.Drawing.Color.SkyBlue;
			this.btnBestBallNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBestBallNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnBestBallNo.Location = new System.Drawing.Point(628, 100);
			this.btnBestBallNo.Name = "btnBestBallNo";
			this.btnBestBallNo.Size = new System.Drawing.Size(244, 48);
			this.btnBestBallNo.TabIndex = 9;
			this.btnBestBallNo.Text = "No";
			this.btnBestBallNo.Click += new System.EventHandler(this.btnBestBallNo_Click);
			// 
			// btnSkinsNo
			// 
			this.btnSkinsNo.BackColor = System.Drawing.Color.Lime;
			this.btnSkinsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSkinsNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnSkinsNo.Location = new System.Drawing.Point(628, 44);
			this.btnSkinsNo.Name = "btnSkinsNo";
			this.btnSkinsNo.Size = new System.Drawing.Size(244, 48);
			this.btnSkinsNo.TabIndex = 8;
			this.btnSkinsNo.Text = "No";
			this.btnSkinsNo.Click += new System.EventHandler(this.btnSkinsNo_Click);
			// 
			// lbl123Rotation
			// 
			this.lbl123Rotation.Location = new System.Drawing.Point(48, 168);
			this.lbl123Rotation.Name = "lbl123Rotation";
			this.lbl123Rotation.Size = new System.Drawing.Size(280, 24);
			this.lbl123Rotation.TabIndex = 7;
			this.lbl123Rotation.Text = "1-2-3 Ball Rotation";
			// 
			// lblBestBall
			// 
			this.lblBestBall.Location = new System.Drawing.Point(48, 112);
			this.lblBestBall.Name = "lblBestBall";
			this.lblBestBall.Size = new System.Drawing.Size(264, 24);
			this.lblBestBall.TabIndex = 5;
			this.lblBestBall.Text = "Best Ball";
			// 
			// lblIndividualSkins
			// 
			this.lblIndividualSkins.Location = new System.Drawing.Point(48, 56);
			this.lblIndividualSkins.Name = "lblIndividualSkins";
			this.lblIndividualSkins.Size = new System.Drawing.Size(272, 24);
			this.lblIndividualSkins.TabIndex = 4;
			this.lblIndividualSkins.Text = "Individual Skins";
			// 
			// btn123RotationYes
			// 
			this.btn123RotationYes.BackColor = System.Drawing.Color.SkyBlue;
			this.btn123RotationYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn123RotationYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn123RotationYes.Location = new System.Drawing.Point(344, 156);
			this.btn123RotationYes.Name = "btn123RotationYes";
			this.btn123RotationYes.Size = new System.Drawing.Size(244, 48);
			this.btn123RotationYes.TabIndex = 3;
			this.btn123RotationYes.Text = "Yes";
			this.btn123RotationYes.Click += new System.EventHandler(this.btn123RotationYes_Click);
			// 
			// btnBestBallYes
			// 
			this.btnBestBallYes.BackColor = System.Drawing.Color.SkyBlue;
			this.btnBestBallYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBestBallYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnBestBallYes.Location = new System.Drawing.Point(344, 100);
			this.btnBestBallYes.Name = "btnBestBallYes";
			this.btnBestBallYes.Size = new System.Drawing.Size(244, 48);
			this.btnBestBallYes.TabIndex = 1;
			this.btnBestBallYes.Text = "Yes";
			this.btnBestBallYes.Click += new System.EventHandler(this.btnBestBallYes_Click);
			// 
			// btnSkinsYes
			// 
			this.btnSkinsYes.BackColor = System.Drawing.Color.Lime;
			this.btnSkinsYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSkinsYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnSkinsYes.Location = new System.Drawing.Point(344, 44);
			this.btnSkinsYes.Name = "btnSkinsYes";
			this.btnSkinsYes.Size = new System.Drawing.Size(244, 48);
			this.btnSkinsYes.TabIndex = 0;
			this.btnSkinsYes.Text = "Yes";
			this.btnSkinsYes.Click += new System.EventHandler(this.btnSkinsYes_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(214, 604);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(199, 68);
			this.btnCancel.TabIndex = 12;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnPrint
			// 
			this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnPrint.Location = new System.Drawing.Point(584, 604);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(197, 68);
			this.btnPrint.TabIndex = 11;
			this.btnPrint.Text = "&Print";
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			// 
			// btnCompute
			// 
			this.btnCompute.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCompute.Location = new System.Drawing.Point(580, 496);
			this.btnCompute.Name = "btnCompute";
			this.btnCompute.Size = new System.Drawing.Size(307, 88);
			this.btnCompute.TabIndex = 16;
			this.btnCompute.Text = "Update Tournament Standings";
			this.btnCompute.Click += new System.EventHandler(this.btnCompute_Click);
			// 
			// lblComputed
			// 
			this.lblComputed.BackColor = System.Drawing.Color.Yellow;
			this.lblComputed.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblComputed.Location = new System.Drawing.Point(211, 428);
			this.lblComputed.Name = "lblComputed";
			this.lblComputed.Size = new System.Drawing.Size(572, 40);
			this.lblComputed.TabIndex = 17;
			this.lblComputed.Text = "Tournament Standings Updated";
			this.lblComputed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblComputed.Visible = false;
			// 
			// timerStandings
			// 
			this.timerStandings.Interval = 5000;
			this.timerStandings.Tick += new System.EventHandler(this.timerStandings_Tick);
			// 
			// PrintTournamentStandings
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(994, 688);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lblComputed,
																		  this.btnCompute,
																		  this.pnlPreview,
																		  this.groupBox2,
																		  this.groupBox1,
																		  this.btnCancel,
																		  this.btnPrint});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "PrintTournamentStandings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Print Tournament Standings";
			this.Load += new System.EventHandler(this.PrintTournamentStandings_Load);
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			bool reprint = false;
			// Add Logic that determines whether to recompute all scores.
			// If this doesn't work, remove ComputeGames and require the
			// user to select compute manually in order to allow printing the standings
			// without recomputing the world.
			//tlc.ComputeGames(TournamentID);
			//TL_Skins SkinsReport = new TL_Skins(ref espDB,TournamentID);
			tlc.Skins = printSkinsFlag;
			tlc.BestBall = printBestBallFlag;
			tlc.Rotation123 = print123RotationFlag;
			tlc.Rotation321 = print321RotationFlag;
			tlc.TeamSkins = printTeamSkinsFlag;
			tlc.Scramble = printScrambleFlag;
			tlc.Copies = Byte.Parse(this.txtCopies.Text);
			if (tlc.Copies > 0 & 
				(printSkinsFlag | 
				printBestBallFlag | 
				print123RotationFlag | 
				print321RotationFlag | 
				printTeamSkinsFlag | 
				printScrambleFlag))
			{
				if (dac.CreateDataAccessFile())
				{
					tlc.PrintGames(TournamentID);
					//SkinsReport.Run(true); 
					//SkinsReport.Document.Print(false,true);
				}
				else
				{
					// Unable to Print Reselect
					reprint = true;
					MessageBox.Show("Unable to print the Report at this time.  Please Select the PRINT option again.");
				}
				// Make sure that the MANAGER control file is deleted
				dac.DeleteDataAccessFile();
			}
			if ( !reprint ) this.Close();
		}

		private void pnlPreview_Click(object sender, System.EventArgs e)
		{
			// Add Logic that determines whether to recompute all scores.
			// If this doesn't work, remove ComputeGames and require the
			// user to select compute manually in order to allow printing the standings
			// without recomputing the world.
			//tlc.ComputeGames(TournamentID);
			tlc.Skins = printSkinsFlag;
			tlc.BestBall = printBestBallFlag;
			tlc.Rotation123 = print123RotationFlag;
			tlc.Rotation321 = print321RotationFlag;
			tlc.TeamSkins = printTeamSkinsFlag;
			tlc.Scramble = printScrambleFlag;
			tlc.Copies = Byte.Parse(this.txtCopies.Text);
			if (tlc.Copies > 0 & 
				(printSkinsFlag | 
				printBestBallFlag | 
				print123RotationFlag | 
				print321RotationFlag | 
				printTeamSkinsFlag | 
				printScrambleFlag)) 
			{
				if (dac.CreateDataAccessFile())
				{
					tlc.PreviewGames(TournamentID);
				}
				else
				{
					// Unable to Print Reselect
					MessageBox.Show("Unable to print the Report at this time.  Please Select the PRINT option again.");
				}
				// Make sure that the MANAGER control file is deleted
				dac.DeleteDataAccessFile();
			}
		}

		private void btnCompute_Click(object sender, System.EventArgs e)
		{
			espDB.GetPostedRounds(this.TournamentID);
			for (int i=0;i<ds.Tables["RoundsPosted"].Rows.Count;i++)
			{
				tlc.ComputeGame(this.TournamentID, (int)ds.Tables["RoundsPosted"].Rows[i]["RoundID"]);
			}
			lblComputed.Visible = true;
			timerStandings.Enabled = true;
		}

		private void PrintTournamentStandings_Load(object sender, System.EventArgs e)
		{
			tlc = new TourLiteCompute(ref espDB);
			//
			// set Form defaults
			UpdateDisplay();
			this.txtCopies.Text = "1";
		}

		private void UpdateDisplay()
		{
			if (printSkinsFlag)
			{
				btnSkinsYes.BackColor = Color.Lime;
				btnSkinsNo.BackColor = Color.Silver;
			}
			else
			{
				btnSkinsYes.BackColor = Color.Silver;
				btnSkinsNo.BackColor = Color.Lime;
			}
			if (printBestBallFlag)
			{
				btnBestBallYes.BackColor = Color.Lime;
				btnBestBallNo.BackColor = Color.Silver;
			}
			else
			{
				btnBestBallYes.BackColor = Color.Silver;
				btnBestBallNo.BackColor = Color.Lime;
			}
			if (print123RotationFlag)
			{
				btn123RotationYes.BackColor = Color.Lime;
				btn123RotationNo.BackColor = Color.Silver;
			}
			else
			{
				btn123RotationYes.BackColor = Color.Silver;
				btn123RotationNo.BackColor = Color.Lime;
			}
			if (print321RotationFlag)
			{
				btn321RotationYes.BackColor = Color.Lime;
				btn321RotationNo.BackColor = Color.Silver;
			}
			else
			{
				btn321RotationYes.BackColor = Color.Silver;
				btn321RotationNo.BackColor = Color.Lime;
			}
			if (printTeamSkinsFlag)
			{
				btnTeamSkinsYes.BackColor = Color.Lime;
				btnTeamSkinsNo.BackColor = Color.Silver;
			}
			else
			{
				btnTeamSkinsYes.BackColor = Color.Silver;
				btnTeamSkinsNo.BackColor = Color.Lime;
			}
			if (printScrambleFlag)
			{
				btnScrambleYes.BackColor = Color.Lime;
				btnScrambleNo.BackColor = Color.Silver;
			}
			else
			{
				btnScrambleYes.BackColor = Color.Silver;
				btnScrambleNo.BackColor = Color.Lime;
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnSkinsYes_Click(object sender, System.EventArgs e)
		{
			printSkinsFlag = true;
			UpdateDisplay();
		}

		private void btnSkinsNo_Click(object sender, System.EventArgs e)
		{
			printSkinsFlag = false;
			UpdateDisplay();
		}

		private void btnBestBallYes_Click(object sender, System.EventArgs e)
		{
			printBestBallFlag = true;
			UpdateDisplay();
		}

		private void btnBestBallNo_Click(object sender, System.EventArgs e)
		{
			printBestBallFlag = false;
			UpdateDisplay();
		}

		private void btn123RotationYes_Click(object sender, System.EventArgs e)
		{
			print123RotationFlag = true;
			UpdateDisplay();
		}

		private void btn123RotationNo_Click(object sender, System.EventArgs e)
		{
			print123RotationFlag = false;
			UpdateDisplay();
		}

		private void btn321RotationYes_Click(object sender, System.EventArgs e)
		{
			print321RotationFlag = true;
			UpdateDisplay();
		}

		private void btn321RotationNo_Click(object sender, System.EventArgs e)
		{
			print321RotationFlag = false;
			UpdateDisplay();
		}

		private void btnTeamSkinsYes_Click(object sender, System.EventArgs e)
		{
			printTeamSkinsFlag = true;
			UpdateDisplay();
		}

		private void btnTeamSkinsNo_Click(object sender, System.EventArgs e)
		{
			printTeamSkinsFlag = false;
			UpdateDisplay();
		}

		private void btnScrambleYes_Click(object sender, System.EventArgs e)
		{
			printScrambleFlag = true;
			UpdateDisplay();
		}

		private void btnScrambleNo_Click(object sender, System.EventArgs e)
		{
			printScrambleFlag = false;
			UpdateDisplay();
		}

		private void btnCopies_Click(object sender, System.EventArgs e)
		{
			// Popup Screen to select the number of drives
			TenKeyPad tenKey = new TenKeyPad();
			tenKey.MaxValue = 99;
			tenKey.Title = "Select Number of Copies to be Printed.";
			tenKey.WarnHeader = "Invalid Number of Copies";
			tenKey.WarnMessage1 = "The maximum number of copies is ";
			tenKey.Number = Int32.Parse(this.txtCopies.Text);
			tenKey.ShowDialog();
			this.txtCopies.Text = tenKey.Number.ToString();
			tenKey = null;
		}

		private void timerStandings_Tick(object sender, System.EventArgs e)
		{
			timerStandings.Enabled = false;
			this.lblComputed.Visible = false;
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
