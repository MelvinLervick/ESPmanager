using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ESPmanager
{
	/// <summary>
	/// Summary description for Manager.
	/// </summary>
	public class Manager : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MenuItem menuFile;
		private System.Windows.Forms.MenuItem menuExit;
		private System.Windows.Forms.MenuItem menuHelp;
		private System.Windows.Forms.MenuItem menuExport;
		private System.Windows.Forms.MenuItem menuExportCourse;
		private System.Windows.Forms.MenuItem menuExportTees;
		private System.Windows.Forms.MenuItem menuExportHoles;
		private System.Windows.Forms.MenuItem menuExportPoints;
		private System.Windows.Forms.MenuItem menuExportDistances;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuExportAll;
		private System.Windows.Forms.MenuItem menuReports;
		private System.Windows.Forms.Button btnScoreCard;
		private System.Windows.Forms.MenuItem menuPlayerReports;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.Button btnManager;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Button btnSelectTeeTime;
		private System.Windows.Forms.Button btnSelectDate;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuTools;
		private System.Windows.Forms.Button btnSelectCourse;

		private System.Windows.Forms.MainMenu mainMenu;
		//====================================================
		public Global espGlobal = new Global();
		private System.Windows.Forms.ListBox lbUnprintedTimes;
		private System.Windows.Forms.Timer timerUpdatePrintList;
		private DatabaseAccessControl dac = new DatabaseAccessControl();
		public Database espDB = new Database();
		private DataTable dtUnprintedTimes;
		private System.Windows.Forms.TextBox txtDebug;
		private DataSet ds;
		private System.Windows.Forms.Label lblSelectTeeTime;
		private System.Windows.Forms.Button btnTournaments;
		private System.Windows.Forms.Button btnOtherTeeTimes;
		private System.Windows.Forms.Label lblCourse;
		private System.Windows.Forms.Button btnTutorial;
		private System.Windows.Forms.MenuItem mnuTournaments;
		private System.Windows.Forms.MenuItem mnuNames;
		private bool UserSelectFlag = false;

		public Manager()
		{
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
				if (components != null) 
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
		this.mainMenu = new System.Windows.Forms.MainMenu();
		this.menuFile = new System.Windows.Forms.MenuItem();
		this.menuPlayerReports = new System.Windows.Forms.MenuItem();
		this.menuItem11 = new System.Windows.Forms.MenuItem();
		this.menuExit = new System.Windows.Forms.MenuItem();
		this.mnuTournaments = new System.Windows.Forms.MenuItem();
		this.mnuNames = new System.Windows.Forms.MenuItem();
		this.menuExport = new System.Windows.Forms.MenuItem();
		this.menuExportCourse = new System.Windows.Forms.MenuItem();
		this.menuExportTees = new System.Windows.Forms.MenuItem();
		this.menuExportHoles = new System.Windows.Forms.MenuItem();
		this.menuExportPoints = new System.Windows.Forms.MenuItem();
		this.menuExportDistances = new System.Windows.Forms.MenuItem();
		this.menuItem7 = new System.Windows.Forms.MenuItem();
		this.menuExportAll = new System.Windows.Forms.MenuItem();
		this.menuReports = new System.Windows.Forms.MenuItem();
		this.menuTools = new System.Windows.Forms.MenuItem();
		this.menuItem2 = new System.Windows.Forms.MenuItem();
		this.menuHelp = new System.Windows.Forms.MenuItem();
		this.btnScoreCard = new System.Windows.Forms.Button();
		this.btnManager = new System.Windows.Forms.Button();
		this.btnSelectTeeTime = new System.Windows.Forms.Button();
		this.btnSelectDate = new System.Windows.Forms.Button();
		this.btnSelectCourse = new System.Windows.Forms.Button();
		this.lblSelectTeeTime = new System.Windows.Forms.Label();
		this.lbUnprintedTimes = new System.Windows.Forms.ListBox();
		this.timerUpdatePrintList = new System.Windows.Forms.Timer(this.components);
		this.txtDebug = new System.Windows.Forms.TextBox();
		this.btnTournaments = new System.Windows.Forms.Button();
		this.btnOtherTeeTimes = new System.Windows.Forms.Button();
		this.lblCourse = new System.Windows.Forms.Label();
		this.btnTutorial = new System.Windows.Forms.Button();
		this.SuspendLayout();
		// 
		// mainMenu
		// 
		this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				 this.menuFile,
																				 this.mnuTournaments,
																				 this.mnuNames,
																				 this.menuExport,
																				 this.menuReports,
																				 this.menuTools,
																				 this.menuHelp});
		// 
		// menuFile
		// 
		this.menuFile.Index = 0;
		this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				 this.menuPlayerReports,
																				 this.menuItem11,
																				 this.menuExit});
		this.menuFile.Text = "&File";
		// 
		// menuPlayerReports
		// 
		this.menuPlayerReports.Index = 0;
		this.menuPlayerReports.Text = "&Player Reports";
		this.menuPlayerReports.Click += new System.EventHandler(this.menuPlayerReports_Click);
		// 
		// menuItem11
		// 
		this.menuItem11.Index = 1;
		this.menuItem11.Text = "-";
		// 
		// menuExit
		// 
		this.menuExit.Index = 2;
		this.menuExit.Text = "E&xit";
		this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
		// 
		// mnuTournaments
		// 
		this.mnuTournaments.Index = 1;
		this.mnuTournaments.Text = "T&ournaments";
		this.mnuTournaments.Click += new System.EventHandler(this.mnuTournaments_Click);
		// 
		// mnuNames
		// 
		this.mnuNames.Index = 2;
		this.mnuNames.Text = "&Golfer Names";
		this.mnuNames.Click += new System.EventHandler(this.mnuNames_Click);
		// 
		// menuExport
		// 
		this.menuExport.Index = 3;
		this.menuExport.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				   this.menuExportCourse,
																				   this.menuExportTees,
																				   this.menuExportHoles,
																				   this.menuExportPoints,
																				   this.menuExportDistances,
																				   this.menuItem7,
																				   this.menuExportAll});
		this.menuExport.Text = "&Export";
		// 
		// menuExportCourse
		// 
		this.menuExportCourse.Index = 0;
		this.menuExportCourse.Text = "&Course";
		// 
		// menuExportTees
		// 
		this.menuExportTees.Index = 1;
		this.menuExportTees.Text = "&Tees";
		// 
		// menuExportHoles
		// 
		this.menuExportHoles.Index = 2;
		this.menuExportHoles.Text = "&Holes";
		// 
		// menuExportPoints
		// 
		this.menuExportPoints.Index = 3;
		this.menuExportPoints.Text = "Map &Points";
		// 
		// menuExportDistances
		// 
		this.menuExportDistances.Index = 4;
		this.menuExportDistances.Text = "Map &Distances";
		// 
		// menuItem7
		// 
		this.menuItem7.Index = 5;
		this.menuItem7.Text = "-";
		// 
		// menuExportAll
		// 
		this.menuExportAll.Index = 6;
		this.menuExportAll.Text = "&All";
		// 
		// menuReports
		// 
		this.menuReports.Index = 4;
		this.menuReports.Text = "&Reports";
		// 
		// menuTools
		// 
		this.menuTools.Index = 5;
		this.menuTools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				  this.menuItem2});
		this.menuTools.Text = "&Tools";
		// 
		// menuItem2
		// 
		this.menuItem2.Index = 0;
		this.menuItem2.Text = "&User Name and Password";
		// 
		// menuHelp
		// 
		this.menuHelp.Index = 6;
		this.menuHelp.Text = "&Help";
		// 
		// btnScoreCard
		// 
		this.btnScoreCard.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(0)));
		this.btnScoreCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnScoreCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.btnScoreCard.Location = new System.Drawing.Point(320, 592);
		this.btnScoreCard.Name = "btnScoreCard";
		this.btnScoreCard.Size = new System.Drawing.Size(112, 32);
		this.btnScoreCard.TabIndex = 1;
		this.btnScoreCard.Text = "&Print Score Card and Games";
		this.btnScoreCard.Visible = false;
		this.btnScoreCard.Click += new System.EventHandler(this.btnScoreCard_Click);
		// 
		// btnManager
		// 
		this.btnManager.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
		this.btnManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.btnManager.Location = new System.Drawing.Point(144, 544);
		this.btnManager.Name = "btnManager";
		this.btnManager.Size = new System.Drawing.Size(164, 72);
		this.btnManager.TabIndex = 5;
		this.btnManager.Text = "&Manager";
		this.btnManager.Click += new System.EventHandler(this.btnManager_Click);
		// 
		// btnSelectTeeTime
		// 
		this.btnSelectTeeTime.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
		this.btnSelectTeeTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnSelectTeeTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.btnSelectTeeTime.Location = new System.Drawing.Point(12, 632);
		this.btnSelectTeeTime.Name = "btnSelectTeeTime";
		this.btnSelectTeeTime.Size = new System.Drawing.Size(120, 21);
		this.btnSelectTeeTime.TabIndex = 0;
		this.btnSelectTeeTime.Text = "Select &Tee Time";
		this.btnSelectTeeTime.Visible = false;
		this.btnSelectTeeTime.Click += new System.EventHandler(this.btnSelectTeeTime_Click);
		// 
		// btnSelectDate
		// 
		this.btnSelectDate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
		this.btnSelectDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnSelectDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.btnSelectDate.Location = new System.Drawing.Point(12, 608);
		this.btnSelectDate.Name = "btnSelectDate";
		this.btnSelectDate.Size = new System.Drawing.Size(120, 20);
		this.btnSelectDate.TabIndex = 3;
		this.btnSelectDate.Text = "Select Date";
		this.btnSelectDate.Visible = false;
		this.btnSelectDate.Click += new System.EventHandler(this.btnSelectDate_Click);
		// 
		// btnSelectCourse
		// 
		this.btnSelectCourse.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
		this.btnSelectCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnSelectCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.btnSelectCourse.Location = new System.Drawing.Point(12, 584);
		this.btnSelectCourse.Name = "btnSelectCourse";
		this.btnSelectCourse.Size = new System.Drawing.Size(120, 19);
		this.btnSelectCourse.TabIndex = 4;
		this.btnSelectCourse.Text = "Select Course";
		this.btnSelectCourse.Visible = false;
		this.btnSelectCourse.Click += new System.EventHandler(this.btnSelectCourse_Click);
		// 
		// lblSelectTeeTime
		// 
		this.lblSelectTeeTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.lblSelectTeeTime.Location = new System.Drawing.Point(456, 48);
		this.lblSelectTeeTime.Name = "lblSelectTeeTime";
		this.lblSelectTeeTime.Size = new System.Drawing.Size(528, 32);
		this.lblSelectTeeTime.TabIndex = 17;
		this.lblSelectTeeTime.Text = "Select Tee Time to Print";
		this.lblSelectTeeTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		// 
		// lbUnprintedTimes
		// 
		this.lbUnprintedTimes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.lbUnprintedTimes.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.lbUnprintedTimes.ItemHeight = 25;
		this.lbUnprintedTimes.Location = new System.Drawing.Point(448, 84);
		this.lbUnprintedTimes.Name = "lbUnprintedTimes";
		this.lbUnprintedTimes.Size = new System.Drawing.Size(536, 577);
		this.lbUnprintedTimes.TabIndex = 16;
		this.lbUnprintedTimes.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbUnprintedTimes_MouseUp);
		// 
		// timerUpdatePrintList
		// 
		this.timerUpdatePrintList.Enabled = true;
		this.timerUpdatePrintList.Interval = 5000;
		this.timerUpdatePrintList.Tick += new System.EventHandler(this.timerUpdatePrintList_Tick);
		// 
		// txtDebug
		// 
		this.txtDebug.Enabled = false;
		this.txtDebug.Location = new System.Drawing.Point(320, 632);
		this.txtDebug.Name = "txtDebug";
		this.txtDebug.Size = new System.Drawing.Size(112, 20);
		this.txtDebug.TabIndex = 18;
		this.txtDebug.Text = "Debug Text Box";
		this.txtDebug.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
		this.txtDebug.Visible = false;
		// 
		// btnTournaments
		// 
		this.btnTournaments.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
		this.btnTournaments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnTournaments.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.btnTournaments.Location = new System.Drawing.Point(28, 88);
		this.btnTournaments.Name = "btnTournaments";
		this.btnTournaments.Size = new System.Drawing.Size(388, 120);
		this.btnTournaments.TabIndex = 19;
		this.btnTournaments.Text = "Tournament Games";
		this.btnTournaments.Click += new System.EventHandler(this.btnTournaments_Click);
		// 
		// btnOtherTeeTimes
		// 
		this.btnOtherTeeTimes.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
		this.btnOtherTeeTimes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOtherTeeTimes.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.btnOtherTeeTimes.Location = new System.Drawing.Point(28, 224);
		this.btnOtherTeeTimes.Name = "btnOtherTeeTimes";
		this.btnOtherTeeTimes.Size = new System.Drawing.Size(388, 120);
		this.btnOtherTeeTimes.TabIndex = 20;
		this.btnOtherTeeTimes.Text = "Other Tee Times";
		this.btnOtherTeeTimes.Click += new System.EventHandler(this.btnOtherTeeTimes_Click);
		// 
		// lblCourse
		// 
		this.lblCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.lblCourse.Location = new System.Drawing.Point(12, 8);
		this.lblCourse.Name = "lblCourse";
		this.lblCourse.Size = new System.Drawing.Size(972, 32);
		this.lblCourse.TabIndex = 21;
		this.lblCourse.Text = "Course Name";
		this.lblCourse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		// 
		// btnTutorial
		// 
		this.btnTutorial.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
		this.btnTutorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnTutorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.btnTutorial.Location = new System.Drawing.Point(44, 360);
		this.btnTutorial.Name = "btnTutorial";
		this.btnTutorial.Size = new System.Drawing.Size(356, 120);
		this.btnTutorial.TabIndex = 22;
		this.btnTutorial.Text = "Tutorial";
		// 
		// Manager
		// 
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(994, 667);
		this.ControlBox = false;
		this.Controls.AddRange(new System.Windows.Forms.Control[] {
																	  this.btnTutorial,
																	  this.lblCourse,
																	  this.btnOtherTeeTimes,
																	  this.btnTournaments,
																	  this.lblSelectTeeTime,
																	  this.lbUnprintedTimes,
																	  this.btnManager,
																	  this.btnScoreCard,
																	  this.btnSelectCourse,
																	  this.btnSelectDate,
																	  this.btnSelectTeeTime,
																	  this.txtDebug});
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.Menu = this.mainMenu;
		this.Name = "Manager";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Manager";
		this.Load += new System.EventHandler(this.Manager_Load);
		this.Paint += new System.Windows.Forms.PaintEventHandler(this.Manager_Paint);
		this.ResumeLayout(false);

	}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Manager());
		}

		private void menuExit_Click(object sender, System.EventArgs e)
		{
			timerUpdatePrintList.Enabled = false;
			this.Close();
		}

		private void Manager_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			this.btnSelectDate.Text = espDB.g_State.sDatePlayed.ToString();
			this.btnSelectTeeTime.Text = espDB.g_State.TeeTime.ToString();
		}

		private void btnManager_Click(object sender, System.EventArgs e)
		{
			// Verify the user request by asking for USER NAME and PASSWORD

			// User Verified, so display the Hidden Menu Items
			menuFile.Visible = true;
			mnuTournaments.Visible = true;
			mnuNames.Visible = true;
			menuExport.Visible = true;
			menuReports.Visible = true;
			menuTools.Visible = true;
			menuHelp.Visible = true;
		}

		private void menuPlayerReports_Click(object sender, System.EventArgs e)
		{
			// Hide the Manager Menu Items
			menuFile.Visible = false;
			mnuTournaments.Visible = false;
			mnuNames.Visible = false;
			menuExport.Visible = false;
			menuReports.Visible = false;
			menuTools.Visible = false;
			menuHelp.Visible = false;
		}

		private void btnScoreCard_Click(object sender, System.EventArgs e)
		{
			// On initial entry VERIFY that COURSE, DATE, and TEE TIME have been specified.
			// Also verify that AT LEAST one report option was specified.
			if (espDB.g_State.CourseID == 0)
			{
				// A Course must be selected.
				return;
			}
			else
			{
				// Course Selected, make sure a Round Date is available for the course
				// and it is selected.
				if (espDB.g_State.DatePlayed == "")
				{
					// Course selected, but no Round Date was specified
					return;
				}
				else
				{
					// Course and Date Selected.  Make sure that a Tee Time was also selected.
					if (espDB.g_State.TeeTime == "")
					{
						// Course selected, Round Date was specified, but no Tee Time
						return;
					}
				}
			}

			// Display POPUP selection Form to select the REPORTS
			ReportSelect reportSelect = new ReportSelect( ref espDB);
			reportSelect.ShowDialog();
			btnSelectCourse.Text = espDB.g_State.CurrentCourseName;
		}

		private void btnSelectCourse_Click(object sender, System.EventArgs e)
		{
			// Display POPUP selection Form to select the COURSE
			CourseSelect courseSelect = new CourseSelect( ref espDB);
			courseSelect.ShowDialog();
			btnSelectCourse.Text = espDB.g_State.CurrentCourseName;
			espDB.UpdateCourseData();
			this.btnSelectDate.Text = espDB.g_State.sDatePlayed.ToString();
			this.btnSelectTeeTime.Text = espDB.g_State.TeeTime.ToString();
		}

		private void btnSelectDate_Click(object sender, System.EventArgs e)
		{
			// data stored in the Database.
			// Display POPUP selection Form to select the DATE
			DateSelect dateSelect = new DateSelect( ref espDB);
			dateSelect.ShowDialog();
			this.btnSelectDate.Text = espDB.g_State.sDatePlayed.ToString();
			this.btnSelectTeeTime.Text = espDB.g_State.TeeTime.ToString();
		} 

		private void btnSelectTeeTime_Click(object sender, System.EventArgs e)
		{
			// Display POPUP selection Form to select the TEE TIME
			// 
			TeeTimeSelect timeSelect = new TeeTimeSelect( ref espDB);
			timeSelect.ShowDialog();
			this.btnSelectTeeTime.Text = espDB.g_State.TeeTime.ToString();
		}

		private void Manager_Load(object sender, System.EventArgs e)
		{
			this.Text = espGlobal.Creator;
			menuFile.Visible = false;
			mnuTournaments.Visible = false;
			mnuNames.Visible = false;
			menuExport.Visible = false;
			menuReports.Visible = false;
			menuTools.Visible = false;
			menuHelp.Visible = false;
			if (espDB.g_State.CourseID != 0)
			{
				btnSelectCourse.Text = espDB.g_State.CurrentCourseName;
				lblCourse.Text = espDB.g_State.CurrentCourseName;
			}
			if (espDB.g_State.DatePlayed == "01/01/1900")
			{
				espDB.g_State.DatePlayed = DateTime.Today.ToString("d");
				espDB.g_State.sDatePlayed = DateTime.Today.ToString("D");
			}

			// Set Source for lbUnprintedTimes
			ds = espDB.GetDS();
			dtUnprintedTimes = ds.Tables["UnprintedRounds"];
			lbUnprintedTimes.DataSource = dtUnprintedTimes;
			lbUnprintedTimes.ValueMember = "RoundID";
			lbUnprintedTimes.DisplayMember = "DisplayListName";
		}

		private void timerUpdatePrintList_Tick(object sender, System.EventArgs e)
		{
			if (dac.CreateDataAccessFile())
			{
				// UUUUUUUUUUUUUUUUUUUUUUUUUUU
				// Update "UnprintedRounds" table
				// Disable LIST Timer until Table Update is complete
				timerUpdatePrintList.Enabled = false;

				UserSelectFlag = false;
				espDB.UpdateUnprintedRoundsTable();
				dtUnprintedTimes.GetChanges();
				UserSelectFlag = true;

				// Reenable LIST Timer
				timerUpdatePrintList.Enabled = true;
				// UUUUUUUUUUUUUUUUUUUUUUUUUUU
			}
			// Make sure that my data access control file dores not exist
			dac.DeleteDataAccessFile();
		}

		private void lbUnprintedTimes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (UserSelectFlag)
			{
				string sel = "";

				// Disable LIST Timer until report is complete
				timerUpdatePrintList.Enabled = false;

				// Get the Round Associated with the selected TeeTime
				if (lbUnprintedTimes.SelectedItem != null)
				{
					sel = lbUnprintedTimes.SelectedValue.ToString();
					this.txtDebug.Text = sel;
					espDB.UnprintedRoundSelect(UInt32.Parse(sel));

					// Display POPUP selection Form to select the REPORTS
					ReportSelect reportSelect = new ReportSelect( ref espDB);
					reportSelect.ShowDialog();
				}

				// Reenable LIST Timer
				timerUpdatePrintList.Enabled = true;
			}
			else
			{
				this.txtDebug.Text = "<No Select>";
			}
		}

		private void btnOtherTeeTimes_Click(object sender, System.EventArgs e)
		{
			// Display POPUP selection Form to select the TEE TIME
			// 
			OtherTeeTimesSelect otherSelect = new OtherTeeTimesSelect( ref espDB);
			timerUpdatePrintList.Enabled = false;
			//this.Hide();
			otherSelect.ShowDialog();
			//this.Show();
			timerUpdatePrintList.Enabled = true;
		}

		private void btnTournaments_Click(object sender, System.EventArgs e)
		{
			// Display POPUP selection Form to select the REPORTS
			TourLite tourlite = new TourLite( ref espDB);
			timerUpdatePrintList.Enabled = false;
			//this.Hide();
			tourlite.ShowDialog();
			//this.Show();
			timerUpdatePrintList.Enabled = true;
		}

		private void lbUnprintedTimes_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (UserSelectFlag)
			{
				string sel = "";

				// Disable LIST Timer until report is complete
				timerUpdatePrintList.Enabled = false;

				// Get the Round Associated with the selected TeeTime
				if (lbUnprintedTimes.SelectedItem != null)
				{
					sel = lbUnprintedTimes.SelectedValue.ToString();
					this.txtDebug.Text = sel;
					espDB.UnprintedRoundSelect(UInt32.Parse(sel));

					// Display POPUP selection Form to select the REPORTS
					ReportSelect reportSelect = new ReportSelect( ref espDB);
					reportSelect.ShowDialog();
				}

				// Reenable LIST Timer
				timerUpdatePrintList.Enabled = true;
			}
			else
			{
				this.txtDebug.Text = "<No Select>";
			}
		}

		private void mnuTournaments_Click(object sender, System.EventArgs e)
		{
			Tournaments tournament = new Tournaments(ref espDB);
			tournament.ShowDialog();
			tournament.Dispose();
		}

		private void mnuNames_Click(object sender, System.EventArgs e)
		{
			espDB.GetPlayerMaster();
			PlayerMaster players = new PlayerMaster(ref espDB);
			//
			players.ShowDialog();
			//
			players.Dispose();
			// Refresh Dataset from Database
			espDB.GetPlayerMaster();
		}
	}
}
