using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ESPmanager
{
	/// <summary>
	/// Summary description for DateSelect.
	/// </summary>
	public class DateSelect : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblDateSelected;
		private System.Windows.Forms.TextBox txtDateSelected;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.ListBox lbDates;
		private System.Windows.Forms.Label lblDatesInSystem;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private Database db;
		private System.Windows.Forms.Label lblCourseSelected;
		private System.Windows.Forms.Label lblCourse;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.MonthCalendar monthCalendar1;
		private DataTable dtRoundDates;
		private string dateSelected = "";

		public DateSelect( ref Database espdb )
		{
			//
			// Required for Windows Form Designer support
			//
			DataSet ds = espdb.GetDS();
			db = espdb;

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			dtRoundDates = ds.Tables["RoundDates"];
			InitializeComponent();
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
			this.lblDateSelected = new System.Windows.Forms.Label();
			this.txtDateSelected = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSelect = new System.Windows.Forms.Button();
			this.lbDates = new System.Windows.Forms.ListBox();
			this.lblDatesInSystem = new System.Windows.Forms.Label();
			this.lblCourseSelected = new System.Windows.Forms.Label();
			this.lblCourse = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
			this.SuspendLayout();
			// 
			// lblDateSelected
			// 
			this.lblDateSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDateSelected.Location = new System.Drawing.Point(209, 556);
			this.lblDateSelected.Name = "lblDateSelected";
			this.lblDateSelected.Size = new System.Drawing.Size(164, 24);
			this.lblDateSelected.TabIndex = 7;
			this.lblDateSelected.Text = "Date Selected";
			// 
			// txtDateSelected
			// 
			this.txtDateSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtDateSelected.Location = new System.Drawing.Point(376, 552);
			this.txtDateSelected.Name = "txtDateSelected";
			this.txtDateSelected.ReadOnly = true;
			this.txtDateSelected.Size = new System.Drawing.Size(410, 32);
			this.txtDateSelected.TabIndex = 6;
			this.txtDateSelected.Text = "";
			// 
			// btnCancel
			// 
			this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(279, 608);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(152, 64);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSelect
			// 
			this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnSelect.Location = new System.Drawing.Point(570, 608);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(145, 64);
			this.btnSelect.TabIndex = 4;
			this.btnSelect.Text = "&Select";
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			// 
			// lbDates
			// 
			this.lbDates.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbDates.ItemHeight = 25;
			this.lbDates.Location = new System.Drawing.Point(572, 88);
			this.lbDates.Name = "lbDates";
			this.lbDates.Size = new System.Drawing.Size(412, 429);
			this.lbDates.TabIndex = 8;
			this.lbDates.SelectedIndexChanged += new System.EventHandler(this.lbDates_SelectedIndexChanged);
			// 
			// lblDatesInSystem
			// 
			this.lblDatesInSystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDatesInSystem.Location = new System.Drawing.Point(576, 56);
			this.lblDatesInSystem.Name = "lblDatesInSystem";
			this.lblDatesInSystem.Size = new System.Drawing.Size(408, 28);
			this.lblDatesInSystem.TabIndex = 9;
			this.lblDatesInSystem.Text = "Dates that Rounds were played.";
			this.lblDatesInSystem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblCourseSelected
			// 
			this.lblCourseSelected.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.lblCourseSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCourseSelected.Location = new System.Drawing.Point(128, 8);
			this.lblCourseSelected.Name = "lblCourseSelected";
			this.lblCourseSelected.Size = new System.Drawing.Size(844, 28);
			this.lblCourseSelected.TabIndex = 22;
			this.lblCourseSelected.Text = "WsCourse Selected";
			this.lblCourseSelected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblCourse
			// 
			this.lblCourse.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.lblCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCourse.Location = new System.Drawing.Point(8, 8);
			this.lblCourse.Name = "lblCourse";
			this.lblCourse.Size = new System.Drawing.Size(116, 28);
			this.lblCourse.TabIndex = 21;
			this.lblCourse.Text = "WsCourse:";
			this.lblCourse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(996, 44);
			this.panel1.TabIndex = 23;
			// 
			// monthCalendar1
			// 
			this.monthCalendar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.monthCalendar1.Location = new System.Drawing.Point(8, 56);
			this.monthCalendar1.MaxSelectionCount = 1;
			this.monthCalendar1.Name = "monthCalendar1";
			this.monthCalendar1.TabIndex = 24;
			this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
			// 
			// DateSelect
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(994, 688);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.monthCalendar1,
																		  this.lblCourseSelected,
																		  this.lblCourse,
																		  this.panel1,
																		  this.lblDatesInSystem,
																		  this.lbDates,
																		  this.lblDateSelected,
																		  this.txtDateSelected,
																		  this.btnCancel,
																		  this.btnSelect});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "DateSelect";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select the Date that your Round was played.";
			this.Load += new System.EventHandler(this.DateSelect_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnSelect_Click(object sender, System.EventArgs e)
		{
			if (db.IsThisARoundDate(dateSelected))
			{
				db.g_State.DatePlayed = lbDates.SelectedValue.ToString();
				db.g_State.sDatePlayed = lbDates.Text;
				db.UpdateRoundTimesTable();
				this.Close();
			}
			else
				MessageBox.Show("There were no rounds played on the selected date.  Select another date.","Round Date Selection");
		}

		private void lbDates_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtDateSelected.Text = lbDates.Text;
			dateSelected = lbDates.SelectedValue.ToString();
		}

		private void DateSelect_Load(object sender, System.EventArgs e)
		{
			lbDates.DataSource = dtRoundDates;
			lbDates.ValueMember = "rdate";
			lbDates.DisplayMember = "dispdate";

			// Display Currently Selected WsCourse
			lblCourseSelected.Text = db.g_State.CurrentCourseName;

			monthCalendar1.MaxSelectionCount = 1;
		}

		private void monthCalendar1_DateChanged(object sender, System.Windows.Forms.DateRangeEventArgs e)
		{
			txtDateSelected.Text = monthCalendar1.SelectionStart.Date.ToLongDateString();
			dateSelected = monthCalendar1.SelectionStart.Date.ToShortDateString();
		}
	}
}
