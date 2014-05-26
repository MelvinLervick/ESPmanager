using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ESPmanager
{
	/// <summary>
	/// Summary description for TeeTimeSelect.
	/// </summary>
	public class TeeTimeSelect : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblTimesInSystem;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.ListBox lbTeeTimes;
		private System.Windows.Forms.Label lblTeeTimeSelected;
		private System.Windows.Forms.TextBox txtTeeTimeSelected;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private Database db;
		private System.Windows.Forms.Label lblCourse;
		private System.Windows.Forms.Label lblDate;
		private System.Windows.Forms.Label lblDateSelected;
		private System.Windows.Forms.Label lblCourseSelected;
		private System.Windows.Forms.Panel panel1;
		private DataTable dtRoundTimes;

		public TeeTimeSelect( ref Database espdb )
		{
			//
			// Required for Windows Form Designer support
			//
			DataSet ds = espdb.GetDS();
			db = espdb;

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			dtRoundTimes = ds.Tables["RoundTimes"];
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
			this.lblTimesInSystem = new System.Windows.Forms.Label();
			this.lbTeeTimes = new System.Windows.Forms.ListBox();
			this.lblTeeTimeSelected = new System.Windows.Forms.Label();
			this.txtTeeTimeSelected = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSelect = new System.Windows.Forms.Button();
			this.lblCourse = new System.Windows.Forms.Label();
			this.lblDate = new System.Windows.Forms.Label();
			this.lblDateSelected = new System.Windows.Forms.Label();
			this.lblCourseSelected = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// lblTimesInSystem
			// 
			this.lblTimesInSystem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTimesInSystem.Location = new System.Drawing.Point(155, 108);
			this.lblTimesInSystem.Name = "lblTimesInSystem";
			this.lblTimesInSystem.Size = new System.Drawing.Size(349, 28);
			this.lblTimesInSystem.TabIndex = 15;
			this.lblTimesInSystem.Text = "Select Tee Time:";
			this.lblTimesInSystem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbTeeTimes
			// 
			this.lbTeeTimes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbTeeTimes.ItemHeight = 24;
			this.lbTeeTimes.Location = new System.Drawing.Point(155, 140);
			this.lbTeeTimes.Name = "lbTeeTimes";
			this.lbTeeTimes.Size = new System.Drawing.Size(349, 268);
			this.lbTeeTimes.TabIndex = 14;
			this.lbTeeTimes.SelectedIndexChanged += new System.EventHandler(this.lbTeeTimes_SelectedIndexChanged);
			// 
			// lblTeeTimeSelected
			// 
			this.lblTeeTimeSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTeeTimeSelected.Location = new System.Drawing.Point(136, 424);
			this.lblTeeTimeSelected.Name = "lblTeeTimeSelected";
			this.lblTeeTimeSelected.Size = new System.Drawing.Size(225, 32);
			this.lblTeeTimeSelected.TabIndex = 13;
			this.lblTeeTimeSelected.Text = "Tee Time Selected";
			this.lblTeeTimeSelected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtTeeTimeSelected
			// 
			this.txtTeeTimeSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtTeeTimeSelected.Location = new System.Drawing.Point(365, 424);
			this.txtTeeTimeSelected.Name = "txtTeeTimeSelected";
			this.txtTeeTimeSelected.ReadOnly = true;
			this.txtTeeTimeSelected.Size = new System.Drawing.Size(157, 32);
			this.txtTeeTimeSelected.TabIndex = 12;
			this.txtTeeTimeSelected.Text = "";
			// 
			// btnCancel
			// 
			this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(116, 472);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(160, 56);
			this.btnCancel.TabIndex = 11;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSelect
			// 
			this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnSelect.Location = new System.Drawing.Point(382, 472);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(160, 56);
			this.btnSelect.TabIndex = 10;
			this.btnSelect.Text = "&Select";
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			// 
			// lblCourse
			// 
			this.lblCourse.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.lblCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCourse.Location = new System.Drawing.Point(8, 8);
			this.lblCourse.Name = "lblCourse";
			this.lblCourse.Size = new System.Drawing.Size(112, 28);
			this.lblCourse.TabIndex = 16;
			this.lblCourse.Text = "Course:";
			this.lblCourse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblDate
			// 
			this.lblDate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDate.Location = new System.Drawing.Point(8, 48);
			this.lblDate.Name = "lblDate";
			this.lblDate.Size = new System.Drawing.Size(112, 28);
			this.lblDate.TabIndex = 17;
			this.lblDate.Text = "Date:";
			this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblDateSelected
			// 
			this.lblDateSelected.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.lblDateSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDateSelected.Location = new System.Drawing.Point(128, 48);
			this.lblDateSelected.Name = "lblDateSelected";
			this.lblDateSelected.Size = new System.Drawing.Size(356, 28);
			this.lblDateSelected.TabIndex = 19;
			this.lblDateSelected.Text = "Date Selected";
			this.lblDateSelected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblCourseSelected
			// 
			this.lblCourseSelected.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.lblCourseSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCourseSelected.Location = new System.Drawing.Point(128, 8);
			this.lblCourseSelected.Name = "lblCourseSelected";
			this.lblCourseSelected.Size = new System.Drawing.Size(508, 28);
			this.lblCourseSelected.TabIndex = 18;
			this.lblCourseSelected.Text = "Course Selected";
			this.lblCourseSelected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(656, 84);
			this.panel1.TabIndex = 20;
			// 
			// TeeTimeSelect
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(658, 544);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lblDateSelected,
																		  this.lblCourseSelected,
																		  this.lblDate,
																		  this.lblCourse,
																		  this.lblTimesInSystem,
																		  this.lbTeeTimes,
																		  this.lblTeeTimeSelected,
																		  this.txtTeeTimeSelected,
																		  this.btnCancel,
																		  this.btnSelect,
																		  this.panel1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "TeeTimeSelect";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select Tee Time.";
			this.Load += new System.EventHandler(this.TeeTimeSelect_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void lbTeeTimes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtTeeTimeSelected.Text = lbTeeTimes.Text;
		}

		private void TeeTimeSelect_Load(object sender, System.EventArgs e)
		{
			db.UpdateRoundTimesTable();
			lbTeeTimes.DataSource = dtRoundTimes;
			lbTeeTimes.ValueMember = "RoundTime";
			lbTeeTimes.DisplayMember = "RoundTime";

			// Display Currently Selected Course and Date
			lblCourseSelected.Text = db.g_State.CurrentCourseName;
			lblDateSelected.Text = db.g_State.sDatePlayed;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnSelect_Click(object sender, System.EventArgs e)
		{
			db.g_State.TeeTime = lbTeeTimes.SelectedValue.ToString();
			this.Close();
		}
	}
}
