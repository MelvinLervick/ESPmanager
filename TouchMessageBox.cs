using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ESPmanager
{
	/// <summary>
	/// Summary description for TouchMessageBox.
	/// </summary>
	public class TouchMessageBox : System.Windows.Forms.Form
	{
		private string _Header = "Message Box";
		private string _Message = "Cancel or Confirm Request";
		private byte _Buttons = 2;
		private string _Confirm = "Confirm";
		private string _Cancel = "Cancel";
		private bool _Return = false;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnConfirm;
		private System.Windows.Forms.TextBox lblMessage;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TouchMessageBox()
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnConfirm = new System.Windows.Forms.Button();
			this.lblMessage = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.BackColor = System.Drawing.Color.Red;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(16, 208);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(128, 112);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnConfirm
			// 
			this.btnConfirm.BackColor = System.Drawing.Color.Green;
			this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnConfirm.Location = new System.Drawing.Point(248, 208);
			this.btnConfirm.Name = "btnConfirm";
			this.btnConfirm.Size = new System.Drawing.Size(128, 112);
			this.btnConfirm.TabIndex = 2;
			this.btnConfirm.Text = "Confirm";
			this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
			// 
			// lblMessage
			// 
			this.lblMessage.AcceptsReturn = true;
			this.lblMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMessage.Location = new System.Drawing.Point(16, 20);
			this.lblMessage.Multiline = true;
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.ReadOnly = true;
			this.lblMessage.Size = new System.Drawing.Size(360, 168);
			this.lblMessage.TabIndex = 4;
			this.lblMessage.Text = "";
			// 
			// TouchMessageBox
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.BackColor = System.Drawing.SystemColors.ControlLight;
			this.ClientSize = new System.Drawing.Size(392, 336);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lblMessage,
																		  this.btnConfirm,
																		  this.btnCancel});
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TouchMessageBox";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Load += new System.EventHandler(this.TouchMessageBox_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void TouchMessageBox_Load(object sender, System.EventArgs e)
		{
			Return = false;
			this.Text = Header;
			this.lblMessage.Text = Message;
			this.btnCancel.Text = Cancel;
			this.btnConfirm.Text = Confirm;
			if (Buttons != 2)
			{
				// only one button.  Use the CONFIRM Button
				this.btnCancel.Visible = false;
				this.btnConfirm.Left = ((this.Width - this.btnConfirm.Width) >> 1);
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Return = false;
			this.Close();
		}

		private void btnConfirm_Click(object sender, System.EventArgs e)
		{
			Return = true;
			this.Close();
		}
		// ============================
		// Property Definitions
		// ============================
		public string Header
		{
			get{ return _Header; }
			set{ _Header = value; }
		}
		public string Message
		{
			get{ return _Message; }
			set{ _Message = value; }
		}
		public byte Buttons
		{
			get{ return _Buttons; }
			set{ _Buttons = value; }
		}
		public string Confirm
		{
			get{ return _Confirm; }
			set{ _Confirm = value; }
		}
		public string Cancel
		{
			get{ return _Cancel; }
			set{ _Cancel = value; }
		}
		public bool Return
		{
			get{ return _Return; }
			set{ _Return = value; }
		}
		// ============================
		// ============================
	}
}
