using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ESPmanager
{
	/// <summary>
	/// Summary description for Tournaments.
	/// </summary>
	public class Tournaments : System.Windows.Forms.Form
	{
		private DatabaseAccessControl dac = new DatabaseAccessControl();
		private Database espDB;
		private DataTable dtTournaments;
		private DataSet ds;

		private System.Windows.Forms.Label lblTournamentSelected;
		private System.Windows.Forms.Label lblTournament;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnAED;
		private System.Windows.Forms.Button btnStandings;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Label lblSelectTournament;
		private System.Windows.Forms.ListBox lbTournaments;
		private System.Windows.Forms.Button btnPostScores;
		private System.Windows.Forms.Timer timerTL;
		private System.Windows.Forms.Button btnTeeTimes;
		private System.ComponentModel.IContainer components;

		public Tournaments( ref Database espdb )
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
			this.btnAED = new System.Windows.Forms.Button();
			this.btnStandings = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.lblTournamentSelected = new System.Windows.Forms.Label();
			this.lblTournament = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lblSelectTournament = new System.Windows.Forms.Label();
			this.lbTournaments = new System.Windows.Forms.ListBox();
			this.btnPostScores = new System.Windows.Forms.Button();
			this.timerTL = new System.Windows.Forms.Timer(this.components);
			this.btnTeeTimes = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnAED
			// 
			this.btnAED.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.btnAED.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAED.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnAED.Location = new System.Drawing.Point(8, 576);
			this.btnAED.Name = "btnAED";
			this.btnAED.Size = new System.Drawing.Size(544, 84);
			this.btnAED.TabIndex = 7;
			this.btnAED.Text = "Tournament and &Round Maintenance";
			this.btnAED.Click += new System.EventHandler(this.btnAED_Click);
			// 
			// btnStandings
			// 
			this.btnStandings.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(0)));
			this.btnStandings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnStandings.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnStandings.Location = new System.Drawing.Point(592, 336);
			this.btnStandings.Name = "btnStandings";
			this.btnStandings.Size = new System.Drawing.Size(368, 100);
			this.btnStandings.TabIndex = 6;
			this.btnStandings.Text = "&Print Tournament Standings";
			this.btnStandings.Click += new System.EventHandler(this.btnStandings_Click);
			// 
			// btnExit
			// 
			this.btnExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(128)), ((System.Byte)(255)));
			this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnExit.Location = new System.Drawing.Point(632, 580);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(272, 80);
			this.btnExit.TabIndex = 12;
			this.btnExit.Text = "E&xit";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// lblTournamentSelected
			// 
			this.lblTournamentSelected.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.lblTournamentSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTournamentSelected.Location = new System.Drawing.Point(236, 8);
			this.lblTournamentSelected.Name = "lblTournamentSelected";
			this.lblTournamentSelected.Size = new System.Drawing.Size(748, 32);
			this.lblTournamentSelected.TabIndex = 25;
			this.lblTournamentSelected.Text = "<None>";
			this.lblTournamentSelected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblTournament
			// 
			this.lblTournament.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.lblTournament.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTournament.Location = new System.Drawing.Point(8, 8);
			this.lblTournament.Name = "lblTournament";
			this.lblTournament.Size = new System.Drawing.Size(228, 32);
			this.lblTournament.TabIndex = 24;
			this.lblTournament.Text = "Tournament Selected:";
			this.lblTournament.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(996, 48);
			this.panel1.TabIndex = 26;
			// 
			// lblSelectTournament
			// 
			this.lblSelectTournament.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblSelectTournament.Location = new System.Drawing.Point(12, 60);
			this.lblSelectTournament.Name = "lblSelectTournament";
			this.lblSelectTournament.Size = new System.Drawing.Size(384, 28);
			this.lblSelectTournament.TabIndex = 28;
			this.lblSelectTournament.Text = "Select Tournament";
			this.lblSelectTournament.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbTournaments
			// 
			this.lbTournaments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbTournaments.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbTournaments.ItemHeight = 29;
			this.lbTournaments.Location = new System.Drawing.Point(8, 96);
			this.lbTournaments.Name = "lbTournaments";
			this.lbTournaments.Size = new System.Drawing.Size(544, 466);
			this.lbTournaments.TabIndex = 27;
			this.lbTournaments.SelectedIndexChanged += new System.EventHandler(this.lbTournaments_SelectedIndexChanged);
			// 
			// btnPostScores
			// 
			this.btnPostScores.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.btnPostScores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPostScores.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnPostScores.Location = new System.Drawing.Point(592, 460);
			this.btnPostScores.Name = "btnPostScores";
			this.btnPostScores.Size = new System.Drawing.Size(368, 100);
			this.btnPostScores.TabIndex = 29;
			this.btnPostScores.Text = "Print Scorecard && Post &Scores";
			this.btnPostScores.Click += new System.EventHandler(this.btnPostScores_Click);
			// 
			// timerTL
			// 
			this.timerTL.Enabled = true;
			this.timerTL.Interval = 60000;
			this.timerTL.Tick += new System.EventHandler(this.timerTL_Tick);
			// 
			// btnTeeTimes
			// 
			this.btnTeeTimes.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.btnTeeTimes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnTeeTimes.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnTeeTimes.Location = new System.Drawing.Point(592, 96);
			this.btnTeeTimes.Name = "btnTeeTimes";
			this.btnTeeTimes.Size = new System.Drawing.Size(368, 100);
			this.btnTeeTimes.TabIndex = 30;
			this.btnTeeTimes.Text = "&WsTee Times";
			this.btnTeeTimes.Click += new System.EventHandler(this.btnTeeTimes_Click);
			// 
			// Tournaments
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(994, 688);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnTeeTimes,
																		  this.btnPostScores,
																		  this.lblSelectTournament,
																		  this.lbTournaments,
																		  this.lblTournamentSelected,
																		  this.lblTournament,
																		  this.panel1,
																		  this.btnExit,
																		  this.btnAED,
																		  this.btnStandings});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "Tournaments";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Tournaments";
			this.Load += new System.EventHandler(this.Tournaments_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnAED_Click(object sender, System.EventArgs e)
		{
			TournamentDetails maint = new TournamentDetails( ref espDB);

			if (lbTournaments.Items.Count > 0)
				maint.TournamentID = (int)lbTournaments.SelectedValue;
			else
				maint.TournamentID = 0;
			timerTL.Enabled = false;
			maint.ShowDialog();
			timerTL.Enabled = true;
		}

		private void Tournaments_Load(object sender, System.EventArgs e)
		{
			espDB.UpdateTournamentsTable();

			// Set Source for lbTournaments
			dtTournaments = ds.Tables["Tournaments"];
			lbTournaments.DataSource = dtTournaments;
			lbTournaments.ValueMember = "TournamentID";
			lbTournaments.DisplayMember = "Name";
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			timerTL.Dispose();
			this.Close();
		}

		private void Tournaments_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		}

		private void lbTournaments_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lblTournamentSelected.Text = lbTournaments.Text;
		}

		private void btnStandings_Click(object sender, System.EventArgs e)
		{
			if (lbTournaments.Items.Count == 0) return;
			PrintTournamentStandings standings = new PrintTournamentStandings( ref espDB);

			standings.TournamentID = (int)lbTournaments.SelectedValue;
			timerTL.Enabled = false;
			//this.Hide();
			standings.ShowDialog();
			//this.Show();
			timerTL.Enabled = true;
		}

		private void btnPostScores_Click(object sender, System.EventArgs e)
		{
			if (lbTournaments.Items.Count == 0) return;
			TourLitePost post = new TourLitePost( ref espDB);

			post.TournamentID = (int)lbTournaments.SelectedValue;
			timerTL.Enabled = false;
			//this.Hide();
			post.ShowDialog();
			//this.Show();
			timerTL.Enabled = true;
		}

		private void timerTL_Tick(object sender, System.EventArgs e)
		{
			if (dac.CreateDataAccessFile())
			{
				// Database access allowed, lock out others
				timerTL.Enabled = false;
				espDB.UpdateTournamentsTable();
				dtTournaments.GetChanges();
				timerTL.Enabled = true;
			}
			// Make sure the access control file is deleted
			dac.DeleteDataAccessFile();
		}

		private void btnTeeTimes_Click(object sender, System.EventArgs e)
		{
			if (lbTournaments.Items.Count == 0) return;
			TourLiteTeeTimes teeTimes = new TourLiteTeeTimes( ref espDB);

			teeTimes.TournamentID = (int)lbTournaments.SelectedValue;
			teeTimes.TournamentName = lbTournaments.Text;
			timerTL.Enabled = false;
			teeTimes.ShowDialog();
			timerTL.Enabled = true;
		}
	}
}
