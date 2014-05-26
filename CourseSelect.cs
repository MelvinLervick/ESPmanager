using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ESPmanager
{
	/// <summary>
	/// Summary description for CourseSelect.
	/// </summary>
	public class CourseSelect : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.TextBox txtCourseSelected;
		private System.Windows.Forms.Label lblCourseSelected;
		private System.Windows.Forms.ListBox lbCourses;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private Database db;
		private DataTable dtCourses;
//		private DataSet dsESP;

		public CourseSelect( ref Database espdb )
		{
			//
			// Required for Windows Form Designer support
			//
			DataSet ds = espdb.GetDS();
			db = espdb;

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
//			dsESP = ds;
			dtCourses = ds.Tables["Courses"];
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
			this.btnSelect = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.txtCourseSelected = new System.Windows.Forms.TextBox();
			this.lblCourseSelected = new System.Windows.Forms.Label();
			this.lbCourses = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// btnSelect
			// 
			this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnSelect.Location = new System.Drawing.Point(502, 412);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(160, 64);
			this.btnSelect.TabIndex = 0;
			this.btnSelect.Text = "&Select";
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(132, 412);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(160, 64);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// txtCourseSelected
			// 
			this.txtCourseSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtCourseSelected.Location = new System.Drawing.Point(216, 356);
			this.txtCourseSelected.Name = "txtCourseSelected";
			this.txtCourseSelected.ReadOnly = true;
			this.txtCourseSelected.Size = new System.Drawing.Size(560, 32);
			this.txtCourseSelected.TabIndex = 2;
			this.txtCourseSelected.Text = "";
			// 
			// lblCourseSelected
			// 
			this.lblCourseSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCourseSelected.Location = new System.Drawing.Point(16, 356);
			this.lblCourseSelected.Name = "lblCourseSelected";
			this.lblCourseSelected.Size = new System.Drawing.Size(196, 32);
			this.lblCourseSelected.TabIndex = 3;
			this.lblCourseSelected.Text = "Course Selected";
			this.lblCourseSelected.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lbCourses
			// 
			this.lbCourses.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbCourses.ItemHeight = 31;
			this.lbCourses.Location = new System.Drawing.Point(16, 8);
			this.lbCourses.Name = "lbCourses";
			this.lbCourses.Size = new System.Drawing.Size(764, 314);
			this.lbCourses.TabIndex = 4;
			this.lbCourses.SelectedIndexChanged += new System.EventHandler(this.lbCourses_SelectedIndexChanged);
			// 
			// CourseSelect
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(794, 500);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lbCourses,
																		  this.lblCourseSelected,
																		  this.txtCourseSelected,
																		  this.btnCancel,
																		  this.btnSelect});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CourseSelect";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select Course";
			this.Load += new System.EventHandler(this.CourseSelect_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnSelect_Click(object sender, System.EventArgs e)
		{
			db.g_State.CourseID = (int)lbCourses.SelectedValue;
			db.g_State.CurrentCourseName = lbCourses.Text;
			this.Close();
		}

		private void CourseSelect_Load(object sender, System.EventArgs e)
		{
			lbCourses.DataSource = dtCourses;
			lbCourses.DisplayMember = "Name";
			lbCourses.ValueMember = "CourseID";
		}

		private void lbCourses_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// SelectedValue contains CourseID
			txtCourseSelected.Text = lbCourses.Text;
		}
	}
}
