using System;
using System.Data;
using System.Drawing;
using DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

namespace ESPmanager
{
	public class TL_Skins : ActiveReport
	{
		// Link to System Database
		Database espDB;
		private DataSet ds;
		private DataTable dt;
		private DataRow [] dr;
		private TOURLITE_INFORMATION tour;
		private TLGAME_INFORMATION [] game;
		private int TournamentID = 0;
		//
		public TL_Skins(ref Database db, int id)
		{
			byte gameType = 0;
			espDB = db;
			ds = espDB.GetDS();
			TournamentID = id;
			// Get the Tournament Information
			tour = GetTournamentInfo( TournamentID );
			// Get the GameScores for the specified tournament
			espDB.GetTLGameScores( TournamentID );
			//
			dt = ds.Tables["TLGameScores"];
			gameType = (byte)TOURNAMENT_GAME_TYPE.IndividualSkins;
			dr = dt.Select("GameType="+gameType.ToString(),"TLTeamID");

			InitializeReport();
		}

		private void TL_Skins_DataInitialize(object sender, System.EventArgs eArgs)
		{
			this.txtTournamentName.Text = tour.Name;
			// Header Date for SKINS Standings Report
			if (tour.DateStart == tour.DateEnd)
				this.txtDate.Text = "Held on "+tour.DateStart.ToShortDateString();
			else
				this.txtDate.Text = "From: "+tour.DateStart.ToShortDateString()+"     To: "+tour.DateEnd.ToShortDateString();

			//this.DataSource = ds;
			//this.DataMember = "TLGameScores";
			this.DataSource = dr;
			this.txtTeamID.DataField = "TLTeamID";
			this.txtTeeTime.DataField = "MilitaryTime";
			this.txtTee1.DataField = "Hole1";
			this.txtTee2.DataField = "Hole2";
			this.txtTee3.DataField = "Hole3";
			this.txtTee4.DataField = "Hole4";
			this.txtTee5.DataField = "Hole5";
			this.txtTee6.DataField = "Hole6";
			this.txtTee7.DataField = "Hole7";
			this.txtTee8.DataField = "Hole8";
			this.txtTee9.DataField = "Hole9";
			this.txtTee10.DataField = "Hole10";
			this.txtTee11.DataField = "Hole11";
			this.txtTee12.DataField = "Hole12";
			this.txtTee13.DataField = "Hole13";
			this.txtTee14.DataField = "Hole14";
			this.txtTee15.DataField = "Hole15";
			this.txtTee16.DataField = "Hole16";
			this.txtTee17.DataField = "Hole17";
			this.txtTee18.DataField = "Hole18";
			this.cbTeeX1.DataField = "HoleX1";
			this.cbTeeX2.DataField = "HoleX2";
			this.cbTeeX3.DataField = "HoleX3";
			this.cbTeeX4.DataField = "HoleX4";
			this.cbTeeX5.DataField = "HoleX5";
			this.cbTeeX6.DataField = "HoleX6";
			this.cbTeeX7.DataField = "HoleX7";
			this.cbTeeX8.DataField = "HoleX8";
			this.cbTeeX9.DataField = "HoleX9";
			this.cbTeeX10.DataField = "HoleX10";
			this.cbTeeX11.DataField = "HoleX11";
			this.cbTeeX12.DataField = "HoleX12";
			this.cbTeeX13.DataField = "HoleX13";
			this.cbTeeX14.DataField = "HoleX14";
			this.cbTeeX15.DataField = "HoleX15";
			this.cbTeeX16.DataField = "HoleX16";
			this.cbTeeX17.DataField = "HoleX17";
			this.cbTeeX18.DataField = "HoleX18";

			// Line up the Box and Lines for Tee1
			AlignBoxAndLines(this.txtTee1,this.boxTee1,this.lineTee1a,this.lineTee1b);
			AlignBoxAndLines(this.txtTee2,this.boxTee2,this.lineTee2a,this.lineTee2b);
			AlignBoxAndLines(this.txtTee3,this.boxTee3,this.lineTee3a,this.lineTee3b);
			AlignBoxAndLines(this.txtTee4,this.boxTee4,this.lineTee4a,this.lineTee4b);
			AlignBoxAndLines(this.txtTee5,this.boxTee5,this.lineTee5a,this.lineTee5b);
			AlignBoxAndLines(this.txtTee6,this.boxTee6,this.lineTee6a,this.lineTee6b);
			AlignBoxAndLines(this.txtTee7,this.boxTee7,this.lineTee7a,this.lineTee7b);
			AlignBoxAndLines(this.txtTee8,this.boxTee8,this.lineTee8a,this.lineTee8b);
			AlignBoxAndLines(this.txtTee9,this.boxTee9,this.lineTee9a,this.lineTee9b);
			AlignBoxAndLines(this.txtTee10,this.boxTee10,this.lineTee10a,this.lineTee10b);
			AlignBoxAndLines(this.txtTee11,this.boxTee11,this.lineTee11a,this.lineTee11b);
			AlignBoxAndLines(this.txtTee12,this.boxTee12,this.lineTee12a,this.lineTee12b);
			AlignBoxAndLines(this.txtTee13,this.boxTee13,this.lineTee13a,this.lineTee13b);
			AlignBoxAndLines(this.txtTee14,this.boxTee14,this.lineTee14a,this.lineTee14b);
			AlignBoxAndLines(this.txtTee15,this.boxTee15,this.lineTee15a,this.lineTee15b);
			AlignBoxAndLines(this.txtTee16,this.boxTee16,this.lineTee16a,this.lineTee16b);
			AlignBoxAndLines(this.txtTee17,this.boxTee17,this.lineTee17a,this.lineTee17b);
			AlignBoxAndLines(this.txtTee18,this.boxTee18,this.lineTee18a,this.lineTee18b);
			/*
			this.boxTee1.Left = this.txtTee1.Location.X;
			this.boxTee1.Top = this.txtTee1.Location.Y;
			this.boxTee1.Height = this.txtTee1.Height;
			this.boxTee1.Width = this.txtTee1.Width;
			this.lineTee1a.X1 = this.boxTee1.Left;
			this.lineTee1a.Y1 = this.boxTee1.Top;
			this.lineTee1a.X2 = this.boxTee1.Left+this.boxTee1.Width;
			this.lineTee1a.Y2 = this.boxTee1.Top+this.boxTee1.Height;
			this.lineTee1b.X1 = this.boxTee1.Left;
			this.lineTee1b.Y1 = this.boxTee1.Top+this.boxTee1.Height;
			this.lineTee1b.X2 = this.txtTee1.Left+this.boxTee1.Width;
			this.lineTee1b.Y2 = this.txtTee1.Top;
			*/
			// detail separator line
			this.lineDetail.Y1 = this.txtInitials.Top + this.txtInitials.Height + .01f;
			this.lineDetail.Y2 = this.txtInitials.Top + this.txtInitials.Height + .01f;

			this.Detail.CanShrink = true;
		}

		private void AlignBoxAndLines(TextBox tb, Shape box, Line line1, Line line2)
		{
			box.Left = tb.Location.X;
			box.Top = tb.Location.Y;
			box.Height = tb.Height;
			box.Width = tb.Width;
			line1.X1 = box.Left;
			line1.Y1 = box.Top;
			line1.X2 = box.Left+box.Width;
			line1.Y2 = box.Top+box.Height;
			line2.X1 = box.Left;
			line2.Y1 = box.Top+box.Height;
			line2.X2 = box.Left+box.Width;
			line2.Y2 = box.Top;
		}

		private void TL_Skins_ReportStart(object sender, System.EventArgs eArgs)
		{
		}

		private void Detail_BeforePrint(object sender, System.EventArgs eArgs)
		{
			
		}

		private void TL_Skins_FetchData(object sender, DataDynamics.ActiveReports.ActiveReport.FetchEventArgs eArgs)
		{
			
		}

		private void Detail_Format(object sender, System.EventArgs eArgs)
		{
			this.txtInitials.Text = espDB.GetTLGameScoreInitials((int)this.txtTeamID.Value);
			DisplayXBox(this.cbTeeX1,this.boxTee1,this.lineTee1a,this.lineTee1b);
			DisplayXBox(this.cbTeeX2,this.boxTee2,this.lineTee2a,this.lineTee2b);
			DisplayXBox(this.cbTeeX3,this.boxTee3,this.lineTee3a,this.lineTee3b);
			DisplayXBox(this.cbTeeX4,this.boxTee4,this.lineTee4a,this.lineTee4b);
			DisplayXBox(this.cbTeeX5,this.boxTee5,this.lineTee5a,this.lineTee5b);
			DisplayXBox(this.cbTeeX6,this.boxTee6,this.lineTee6a,this.lineTee6b);
			DisplayXBox(this.cbTeeX7,this.boxTee7,this.lineTee7a,this.lineTee7b);
			DisplayXBox(this.cbTeeX8,this.boxTee8,this.lineTee8a,this.lineTee8b);
			DisplayXBox(this.cbTeeX9,this.boxTee9,this.lineTee9a,this.lineTee9b);
			DisplayXBox(this.cbTeeX10,this.boxTee10,this.lineTee10a,this.lineTee10b);
			DisplayXBox(this.cbTeeX11,this.boxTee11,this.lineTee11a,this.lineTee11b);
			DisplayXBox(this.cbTeeX12,this.boxTee12,this.lineTee12a,this.lineTee12b);
			DisplayXBox(this.cbTeeX13,this.boxTee13,this.lineTee13a,this.lineTee13b);
			DisplayXBox(this.cbTeeX14,this.boxTee14,this.lineTee14a,this.lineTee14b);
			DisplayXBox(this.cbTeeX15,this.boxTee15,this.lineTee15a,this.lineTee15b);
			DisplayXBox(this.cbTeeX16,this.boxTee16,this.lineTee16a,this.lineTee16b);
			DisplayXBox(this.cbTeeX17,this.boxTee17,this.lineTee17a,this.lineTee17b);
			DisplayXBox(this.cbTeeX18,this.boxTee18,this.lineTee18a,this.lineTee18b);
			/*
			if (this.cbTeeX1.Checked) 
			{
				this.txtTee1.BackColor = Color.Green;
				this.txtTee1.ForeColor = Color.White;
				this.boxTee1.Visible = true;
				this.lineTee1a.Visible = true;
				this.lineTee1b.Visible = true;
			}
			else
			{
				this.txtTee1.BackColor = Color.White;
				this.txtTee1.ForeColor = Color.Black;
				this.boxTee1.Visible = false;
				this.lineTee1a.Visible = false;
				this.lineTee1b.Visible = false;
			}
			*/
		}

		private void DisplayXBox(CheckBox cb, Shape box, Line line1, Line line2)
		{
			if (cb.Checked) 
			{
				box.Visible = true;
				line1.Visible = true;
				line2.Visible = true;
			}
			else
			{
				box.Visible = false;
				line1.Visible = false;
				line2.Visible = false;
			}
		}

		#region ActiveReports Designer generated code
		private ReportHeader ReportHeader = null;
		private PageHeader PageHeader = null;
		private TextBox txtTournamentName = null;
		private Label lblSkins = null;
		private TextBox txtDate = null;
		private Label lblPlayerHeader = null;
		private Label lblTeeTimes = null;
		private Label lblTee1 = null;
		private Label lblTee2 = null;
		private Label lblTee3 = null;
		private Label lblTee4 = null;
		private Label lblTee5 = null;
		private Label lblTee6 = null;
		private Label lblTee7 = null;
		private Label Label4 = null;
		private Label Label5 = null;
		private Label Label6 = null;
		private Label Label7 = null;
		private Label Label8 = null;
		private Label Label9 = null;
		private Label Label10 = null;
		private Label Label11 = null;
		private Label Label12 = null;
		private Label lblWon = null;
		private Label Label13 = null;
		private Label Label14 = null;
		private Line Line1 = null;
		private Line Line2 = null;
		private Line Line3 = null;
		private Detail Detail = null;
		private TextBox txtInitials = null;
		private TextBox txtTeeTime = null;
		private TextBox txtTee1 = null;
		private TextBox txtTee2 = null;
		private TextBox txtTee3 = null;
		private TextBox txtTee4 = null;
		private Line lineDetail = null;
		private CheckBox cbTeeX1 = null;
		private Shape boxTee1 = null;
		private Line lineTee1a = null;
		private Line lineTee1b = null;
		private TextBox txtTeamID = null;
		private TextBox txtTee5 = null;
		private TextBox txtTee6 = null;
		private TextBox txtTee7 = null;
		private TextBox txtTee8 = null;
		private TextBox txtTee9 = null;
		private TextBox txtTee10 = null;
		private TextBox txtTee11 = null;
		private TextBox txtTee12 = null;
		private TextBox txtTee13 = null;
		private TextBox txtTee14 = null;
		private TextBox txtTee15 = null;
		private TextBox txtTee16 = null;
		private TextBox txtTee17 = null;
		private TextBox txtTee18 = null;
		private TextBox txtWon = null;
		private CheckBox cbTeeX2 = null;
		private CheckBox cbTeeX3 = null;
		private CheckBox cbTeeX4 = null;
		private CheckBox cbTeeX6 = null;
		private CheckBox cbTeeX5 = null;
		private CheckBox cbTeeX8 = null;
		private CheckBox cbTeeX7 = null;
		private CheckBox cbTeeX10 = null;
		private CheckBox cbTeeX9 = null;
		private CheckBox cbTeeX12 = null;
		private CheckBox cbTeeX11 = null;
		private CheckBox cbTeeX14 = null;
		private CheckBox cbTeeX13 = null;
		private CheckBox cbTeeX16 = null;
		private CheckBox cbTeeX15 = null;
		private CheckBox cbTeeX18 = null;
		private CheckBox cbTeeX17 = null;
		private Shape boxTee2 = null;
		private Line lineTee2a = null;
		private Line lineTee2b = null;
		private Shape boxTee3 = null;
		private Line lineTee3a = null;
		private Line lineTee3b = null;
		private Shape boxTee4 = null;
		private Line lineTee4a = null;
		private Line lineTee4b = null;
		private Shape boxTee5 = null;
		private Line lineTee5a = null;
		private Line lineTee5b = null;
		private Shape boxTee6 = null;
		private Line lineTee6a = null;
		private Line lineTee6b = null;
		private Shape boxTee7 = null;
		private Line lineTee7a = null;
		private Line lineTee7b = null;
		private Shape boxTee8 = null;
		private Line lineTee8a = null;
		private Line lineTee8b = null;
		private Shape boxTee9 = null;
		private Line lineTee9a = null;
		private Line lineTee9b = null;
		private Shape boxTee10 = null;
		private Line lineTee10a = null;
		private Line lineTee10b = null;
		private Shape boxTee11 = null;
		private Line lineTee11a = null;
		private Line lineTee11b = null;
		private Shape boxTee12 = null;
		private Line lineTee12a = null;
		private Line lineTee12b = null;
		private Shape boxTee13 = null;
		private Line lineTee13a = null;
		private Line lineTee13b = null;
		private Shape boxTee14 = null;
		private Line lineTee14a = null;
		private Line lineTee14b = null;
		private Shape boxTee15 = null;
		private Line lineTee15a = null;
		private Line lineTee15b = null;
		private Shape boxTee16 = null;
		private Line lineTee16a = null;
		private Line lineTee16b = null;
		private Shape boxTee17 = null;
		private Line lineTee17a = null;
		private Line lineTee17b = null;
		private Shape boxTee18 = null;
		private Line lineTee18a = null;
		private Line lineTee18b = null;
		private PageFooter PageFooter = null;
		private ReportFooter ReportFooter = null;
		public void InitializeReport()
		{
			this.LoadLayout(this.GetType(), "ESPmanager.TL_Skins.rpx");
			this.ReportHeader = ((DataDynamics.ActiveReports.ReportHeader)(this.Sections["ReportHeader"]));
			this.PageHeader = ((DataDynamics.ActiveReports.PageHeader)(this.Sections["PageHeader"]));
			this.Detail = ((DataDynamics.ActiveReports.Detail)(this.Sections["Detail"]));
			this.PageFooter = ((DataDynamics.ActiveReports.PageFooter)(this.Sections["PageFooter"]));
			this.ReportFooter = ((DataDynamics.ActiveReports.ReportFooter)(this.Sections["ReportFooter"]));
			this.txtTournamentName = ((DataDynamics.ActiveReports.TextBox)(this.PageHeader.Controls[0]));
			this.lblSkins = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[1]));
			this.txtDate = ((DataDynamics.ActiveReports.TextBox)(this.PageHeader.Controls[2]));
			this.lblPlayerHeader = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[3]));
			this.lblTeeTimes = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[4]));
			this.lblTee1 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[5]));
			this.lblTee2 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[6]));
			this.lblTee3 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[7]));
			this.lblTee4 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[8]));
			this.lblTee5 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[9]));
			this.lblTee6 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[10]));
			this.lblTee7 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[11]));
			this.Label4 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[12]));
			this.Label5 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[13]));
			this.Label6 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[14]));
			this.Label7 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[15]));
			this.Label8 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[16]));
			this.Label9 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[17]));
			this.Label10 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[18]));
			this.Label11 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[19]));
			this.Label12 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[20]));
			this.lblWon = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[21]));
			this.Label13 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[22]));
			this.Label14 = ((DataDynamics.ActiveReports.Label)(this.PageHeader.Controls[23]));
			this.Line1 = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[24]));
			this.Line2 = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[25]));
			this.Line3 = ((DataDynamics.ActiveReports.Line)(this.PageHeader.Controls[26]));
			this.txtInitials = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[0]));
			this.txtTeeTime = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[1]));
			this.txtTee1 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[2]));
			this.txtTee2 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[3]));
			this.txtTee3 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[4]));
			this.txtTee4 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[5]));
			this.lineDetail = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[6]));
			this.cbTeeX1 = ((DataDynamics.ActiveReports.CheckBox)(this.Detail.Controls[7]));
			this.boxTee1 = ((DataDynamics.ActiveReports.Shape)(this.Detail.Controls[8]));
			this.lineTee1a = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[9]));
			this.lineTee1b = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[10]));
			this.txtTeamID = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[11]));
			this.txtTee5 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[12]));
			this.txtTee6 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[13]));
			this.txtTee7 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[14]));
			this.txtTee8 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[15]));
			this.txtTee9 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[16]));
			this.txtTee10 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[17]));
			this.txtTee11 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[18]));
			this.txtTee12 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[19]));
			this.txtTee13 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[20]));
			this.txtTee14 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[21]));
			this.txtTee15 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[22]));
			this.txtTee16 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[23]));
			this.txtTee17 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[24]));
			this.txtTee18 = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[25]));
			this.txtWon = ((DataDynamics.ActiveReports.TextBox)(this.Detail.Controls[26]));
			this.cbTeeX2 = ((DataDynamics.ActiveReports.CheckBox)(this.Detail.Controls[27]));
			this.cbTeeX3 = ((DataDynamics.ActiveReports.CheckBox)(this.Detail.Controls[28]));
			this.cbTeeX4 = ((DataDynamics.ActiveReports.CheckBox)(this.Detail.Controls[29]));
			this.cbTeeX6 = ((DataDynamics.ActiveReports.CheckBox)(this.Detail.Controls[30]));
			this.cbTeeX5 = ((DataDynamics.ActiveReports.CheckBox)(this.Detail.Controls[31]));
			this.cbTeeX8 = ((DataDynamics.ActiveReports.CheckBox)(this.Detail.Controls[32]));
			this.cbTeeX7 = ((DataDynamics.ActiveReports.CheckBox)(this.Detail.Controls[33]));
			this.cbTeeX10 = ((DataDynamics.ActiveReports.CheckBox)(this.Detail.Controls[34]));
			this.cbTeeX9 = ((DataDynamics.ActiveReports.CheckBox)(this.Detail.Controls[35]));
			this.cbTeeX12 = ((DataDynamics.ActiveReports.CheckBox)(this.Detail.Controls[36]));
			this.cbTeeX11 = ((DataDynamics.ActiveReports.CheckBox)(this.Detail.Controls[37]));
			this.cbTeeX14 = ((DataDynamics.ActiveReports.CheckBox)(this.Detail.Controls[38]));
			this.cbTeeX13 = ((DataDynamics.ActiveReports.CheckBox)(this.Detail.Controls[39]));
			this.cbTeeX16 = ((DataDynamics.ActiveReports.CheckBox)(this.Detail.Controls[40]));
			this.cbTeeX15 = ((DataDynamics.ActiveReports.CheckBox)(this.Detail.Controls[41]));
			this.cbTeeX18 = ((DataDynamics.ActiveReports.CheckBox)(this.Detail.Controls[42]));
			this.cbTeeX17 = ((DataDynamics.ActiveReports.CheckBox)(this.Detail.Controls[43]));
			this.boxTee2 = ((DataDynamics.ActiveReports.Shape)(this.Detail.Controls[44]));
			this.lineTee2a = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[45]));
			this.lineTee2b = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[46]));
			this.boxTee3 = ((DataDynamics.ActiveReports.Shape)(this.Detail.Controls[47]));
			this.lineTee3a = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[48]));
			this.lineTee3b = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[49]));
			this.boxTee4 = ((DataDynamics.ActiveReports.Shape)(this.Detail.Controls[50]));
			this.lineTee4a = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[51]));
			this.lineTee4b = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[52]));
			this.boxTee5 = ((DataDynamics.ActiveReports.Shape)(this.Detail.Controls[53]));
			this.lineTee5a = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[54]));
			this.lineTee5b = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[55]));
			this.boxTee6 = ((DataDynamics.ActiveReports.Shape)(this.Detail.Controls[56]));
			this.lineTee6a = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[57]));
			this.lineTee6b = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[58]));
			this.boxTee7 = ((DataDynamics.ActiveReports.Shape)(this.Detail.Controls[59]));
			this.lineTee7a = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[60]));
			this.lineTee7b = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[61]));
			this.boxTee8 = ((DataDynamics.ActiveReports.Shape)(this.Detail.Controls[62]));
			this.lineTee8a = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[63]));
			this.lineTee8b = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[64]));
			this.boxTee9 = ((DataDynamics.ActiveReports.Shape)(this.Detail.Controls[65]));
			this.lineTee9a = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[66]));
			this.lineTee9b = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[67]));
			this.boxTee10 = ((DataDynamics.ActiveReports.Shape)(this.Detail.Controls[68]));
			this.lineTee10a = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[69]));
			this.lineTee10b = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[70]));
			this.boxTee11 = ((DataDynamics.ActiveReports.Shape)(this.Detail.Controls[71]));
			this.lineTee11a = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[72]));
			this.lineTee11b = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[73]));
			this.boxTee12 = ((DataDynamics.ActiveReports.Shape)(this.Detail.Controls[74]));
			this.lineTee12a = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[75]));
			this.lineTee12b = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[76]));
			this.boxTee13 = ((DataDynamics.ActiveReports.Shape)(this.Detail.Controls[77]));
			this.lineTee13a = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[78]));
			this.lineTee13b = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[79]));
			this.boxTee14 = ((DataDynamics.ActiveReports.Shape)(this.Detail.Controls[80]));
			this.lineTee14a = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[81]));
			this.lineTee14b = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[82]));
			this.boxTee15 = ((DataDynamics.ActiveReports.Shape)(this.Detail.Controls[83]));
			this.lineTee15a = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[84]));
			this.lineTee15b = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[85]));
			this.boxTee16 = ((DataDynamics.ActiveReports.Shape)(this.Detail.Controls[86]));
			this.lineTee16a = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[87]));
			this.lineTee16b = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[88]));
			this.boxTee17 = ((DataDynamics.ActiveReports.Shape)(this.Detail.Controls[89]));
			this.lineTee17a = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[90]));
			this.lineTee17b = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[91]));
			this.boxTee18 = ((DataDynamics.ActiveReports.Shape)(this.Detail.Controls[92]));
			this.lineTee18a = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[93]));
			this.lineTee18b = ((DataDynamics.ActiveReports.Line)(this.Detail.Controls[94]));
			// Attach Report Events
			this.DataInitialize += new System.EventHandler(this.TL_Skins_DataInitialize);
			this.ReportStart += new System.EventHandler(this.TL_Skins_ReportStart);
			this.Detail.BeforePrint += new System.EventHandler(this.Detail_BeforePrint);
			this.FetchData += new DataDynamics.ActiveReports.ActiveReport.FetchEventHandler(this.TL_Skins_FetchData);
			this.Detail.Format += new System.EventHandler(this.Detail_Format);
		}

		#endregion
		//
		// ============================
		private TOURLITE_INFORMATION GetTournamentInfo(int id)
		{
			TOURLITE_INFORMATION tour = new TOURLITE_INFORMATION();

			// Make sure that the selected Tournament Data is in DataSet.
			espDB.GetSelectedTournament(id);
			//
			DataTable dt;
			DataRow[] dr;
			//
			dt = ds.Tables["AEDTournament"];
			dr = dt.Select();
			tour.ID = id;
			tour.Name = dr[0]["Name"].ToString();
			tour.DateStart = DateTime.Parse(dr[0]["DateStart"].ToString());
			tour.DateEnd = DateTime.Parse(dr[0]["DateEnd"].ToString());
			dr = null;
			dt = null;
			//
			return tour;
		}
		//
		private void GetGameInfo(int id)
		{
			// Make sure that the selected Tournament Data is in DataSet.
			espDB.GetSelectedTournamentGames(id);
			//
			DataTable dt;
			DataRow[] dr;
			//
			dt = ds.Tables["TourLiteGames"];
			dr = dt.Select();

			// Add Data to the Game Info Class
			game = new TLGAME_INFORMATION[dr.Length];
			for(int i=0;i<dr.Length;i++)
			{
				game[i] = new TLGAME_INFORMATION();
				game[i].ID = (int)dr[i]["TLGameID"];
				game[i].TeamGame = (bool)dr[i]["TeamGame"];
				game[i].TeamSize = (byte)dr[i]["TeamSize"];
				game[i].NumberOfTeams = (byte)dr[i]["NumberOfTeams"];
				game[i].GameType = (TOURNAMENT_GAME_TYPE)(byte)dr[i]["GameType"];
				game[i].DrivesPerPlayer = (byte)dr[i]["DrivesPerPlayer"];
				game[i].GameFlags = (uint)(int)dr[i]["GameFlags"];
				game[i].Ball1GrossNet = (byte)dr[i]["Ball1GrossNet"];
				game[i].Ball2GrossNet = (byte)dr[i]["Ball2GrossNet"];
				game[i].Ball3GrossNet = (byte)dr[i]["Ball3GrossNet"];
				game[i].Ball4GrossNet = (byte)dr[i]["Ball4GrossNet"];
				game[i].Ball5GrossNet = (byte)dr[i]["Ball5GrossNet"];
			}
			dr = null;
			dt = null;

			return;
		}
		// ============================
	}
}
