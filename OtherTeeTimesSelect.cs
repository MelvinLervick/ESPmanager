using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ESPmanager
{
	/// <summary>
	/// Summary description for OtherTeeTimesSelect.
	/// </summary>
	public class OtherTeeTimesSelect : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnSelectCourse;
		private System.Windows.Forms.Button btnSelectDate;
		private System.Windows.Forms.Button btnSelectTeeTime;
		private System.Windows.Forms.Button btnScoreCard;

		private Database espDB;
		private System.Windows.Forms.Button btnCancel;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OtherTeeTimesSelect( ref Database espdb )
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
			this.btnSelectCourse = new System.Windows.Forms.Button();
			this.btnSelectDate = new System.Windows.Forms.Button();
			this.btnSelectTeeTime = new System.Windows.Forms.Button();
			this.btnScoreCard = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnSelectCourse
			// 
			this.btnSelectCourse.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.btnSelectCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSelectCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnSelectCourse.Location = new System.Drawing.Point(33, 32);
			this.btnSelectCourse.Name = "btnSelectCourse";
			this.btnSelectCourse.Size = new System.Drawing.Size(924, 88);
			this.btnSelectCourse.TabIndex = 8;
			this.btnSelectCourse.Text = "Select Course";
			this.btnSelectCourse.Click += new System.EventHandler(this.btnSelectCourse_Click);
			// 
			// btnSelectDate
			// 
			this.btnSelectDate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.btnSelectDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSelectDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnSelectDate.Location = new System.Drawing.Point(33, 144);
			this.btnSelectDate.Name = "btnSelectDate";
			this.btnSelectDate.Size = new System.Drawing.Size(924, 88);
			this.btnSelectDate.TabIndex = 7;
			this.btnSelectDate.Text = "Select Date";
			this.btnSelectDate.Click += new System.EventHandler(this.btnSelectDate_Click);
			// 
			// btnSelectTeeTime
			// 
			this.btnSelectTeeTime.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.btnSelectTeeTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSelectTeeTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnSelectTeeTime.Location = new System.Drawing.Point(33, 260);
			this.btnSelectTeeTime.Name = "btnSelectTeeTime";
			this.btnSelectTeeTime.Size = new System.Drawing.Size(924, 88);
			this.btnSelectTeeTime.TabIndex = 5;
			this.btnSelectTeeTime.Text = "Select &Tee Time";
			this.btnSelectTeeTime.Click += new System.EventHandler(this.btnSelectTeeTime_Click);
			// 
			// btnScoreCard
			// 
			this.btnScoreCard.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(0)));
			this.btnScoreCard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnScoreCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnScoreCard.Location = new System.Drawing.Point(33, 422);
			this.btnScoreCard.Name = "btnScoreCard";
			this.btnScoreCard.Size = new System.Drawing.Size(924, 100);
			this.btnScoreCard.TabIndex = 6;
			this.btnScoreCard.Text = "&Print Score Card and Games";
			this.btnScoreCard.Click += new System.EventHandler(this.btnScoreCard_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(293, 564);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(404, 88);
			this.btnCancel.TabIndex = 12;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// OtherTeeTimesSelect
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(990, 684);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnCancel,
																		  this.btnSelectCourse,
																		  this.btnSelectDate,
																		  this.btnSelectTeeTime,
																		  this.btnScoreCard});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Name = "OtherTeeTimesSelect";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Select Tee Time to be Printed.";
			this.Load += new System.EventHandler(this.OtherTeeTimesSelect_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.OtherTeeTimesSelect_Paint);
			this.ResumeLayout(false);

		}
		#endregion

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
			//btnSelectCourse.Text = espDB.g_State.CurrentCourseName;
			this.Close();
		}

		private void OtherTeeTimesSelect_Load(object sender, System.EventArgs e)
		{
			if (espDB.g_State.CourseID != 0)
			{
				btnSelectCourse.Text = espDB.g_State.CurrentCourseName;
			}
			if (espDB.g_State.DatePlayed == "01/01/1900")
			{
				espDB.g_State.DatePlayed = DateTime.Today.ToString("d");
				espDB.g_State.sDatePlayed = DateTime.Today.ToString("D");
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void OtherTeeTimesSelect_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			this.btnSelectDate.Text = espDB.g_State.sDatePlayed.ToString();
			this.btnSelectTeeTime.Text = espDB.g_State.TeeTime.ToString();
		}
	}
}
