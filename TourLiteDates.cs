using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ESPmanager
{
	/// <summary>
	/// Summary description for TourLiteDates.
	/// </summary>
	public class TourLiteDates : System.Windows.Forms.Form
	{
		// Define Properties
		private string startDateSelected = "";
		private string endDateSelected = "";

		private System.Windows.Forms.MonthCalendar monthCalendar1;
		private System.Windows.Forms.Label lblStartDate;
		private System.Windows.Forms.TextBox txtStartDate;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.MonthCalendar monthCalendar2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtEndDate;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TourLiteDates()
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
			this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
			this.lblStartDate = new System.Windows.Forms.Label();
			this.txtStartDate = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSelect = new System.Windows.Forms.Button();
			this.monthCalendar2 = new System.Windows.Forms.MonthCalendar();
			this.label1 = new System.Windows.Forms.Label();
			this.txtEndDate = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// monthCalendar1
			// 
			this.monthCalendar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.monthCalendar1.Location = new System.Drawing.Point(12, 8);
			this.monthCalendar1.MaxSelectionCount = 1;
			this.monthCalendar1.Name = "monthCalendar1";
			this.monthCalendar1.TabIndex = 29;
			this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
			// 
			// lblStartDate
			// 
			this.lblStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblStartDate.Location = new System.Drawing.Point(76, 448);
			this.lblStartDate.Name = "lblStartDate";
			this.lblStartDate.Size = new System.Drawing.Size(212, 28);
			this.lblStartDate.TabIndex = 28;
			this.lblStartDate.Text = "Start Date";
			// 
			// txtStartDate
			// 
			this.txtStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtStartDate.Location = new System.Drawing.Point(72, 480);
			this.txtStartDate.Name = "txtStartDate";
			this.txtStartDate.ReadOnly = true;
			this.txtStartDate.Size = new System.Drawing.Size(352, 31);
			this.txtStartDate.TabIndex = 27;
			this.txtStartDate.Text = "";
			// 
			// btnCancel
			// 
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(280, 564);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(175, 96);
			this.btnCancel.TabIndex = 26;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSelect
			// 
			this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnSelect.Location = new System.Drawing.Point(546, 564);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(169, 96);
			this.btnSelect.TabIndex = 25;
			this.btnSelect.Text = "&Select";
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			// 
			// monthCalendar2
			// 
			this.monthCalendar2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.monthCalendar2.Location = new System.Drawing.Point(504, 8);
			this.monthCalendar2.MaxSelectionCount = 1;
			this.monthCalendar2.Name = "monthCalendar2";
			this.monthCalendar2.TabIndex = 32;
			this.monthCalendar2.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar2_DateChanged);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(564, 448);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(188, 28);
			this.label1.TabIndex = 31;
			this.label1.Text = "End Date";
			// 
			// txtEndDate
			// 
			this.txtEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtEndDate.Location = new System.Drawing.Point(560, 480);
			this.txtEndDate.Name = "txtEndDate";
			this.txtEndDate.ReadOnly = true;
			this.txtEndDate.Size = new System.Drawing.Size(352, 31);
			this.txtEndDate.TabIndex = 30;
			this.txtEndDate.Text = "";
			// 
			// TourLiteDates
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(994, 688);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.monthCalendar2,
																		  this.label1,
																		  this.txtEndDate,
																		  this.monthCalendar1,
																		  this.lblStartDate,
																		  this.txtStartDate,
																		  this.btnCancel,
																		  this.btnSelect});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "TourLiteDates";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Select Tournament Start and End Dates";
			this.Load += new System.EventHandler(this.TourLiteDates_Load);
			this.ResumeLayout(false);

		}
		#endregion

		// =============================
		// Define Properties
		// =============================
		public string StartDate
		{
			get{return startDateSelected;}
		}
		public string EndDate
		{
			get{return endDateSelected;}
		}

		// =============================
		private void monthCalendar1_DateChanged(object sender, System.Windows.Forms.DateRangeEventArgs e)
		{
			txtStartDate.Text = monthCalendar1.SelectionStart.Date.ToShortDateString();

			monthCalendar2.SelectionStart = monthCalendar1.SelectionStart;
			txtEndDate.Text = monthCalendar2.SelectionStart.Date.ToShortDateString();
		}

		private void monthCalendar2_DateChanged(object sender, System.Windows.Forms.DateRangeEventArgs e)
		{
			txtEndDate.Text = monthCalendar2.SelectionStart.Date.ToShortDateString();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnSelect_Click(object sender, System.EventArgs e)
		{
			startDateSelected = monthCalendar1.SelectionStart.Date.ToShortDateString();
			endDateSelected = monthCalendar2.SelectionStart.Date.ToShortDateString();
			this.Close();
		}

		private void TourLiteDates_Load(object sender, System.EventArgs e)
		{
			txtStartDate.Text = monthCalendar1.SelectionStart.Date.ToShortDateString();

			monthCalendar2.SelectionStart = monthCalendar1.SelectionStart;
			txtEndDate.Text = monthCalendar2.SelectionStart.Date.ToShortDateString();
		}
	}
}
