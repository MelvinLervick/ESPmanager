using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ESPmanager
{
	/// <summary>
	/// Summary description for TenKeyPad.
	/// </summary>
	public class TenKeyPad : System.Windows.Forms.Form
	{
		// Define Properties
		private int _Number = 0;
		private int _MinValue = 0;
		private int _MaxValue = 0;
		private string _warnMessage1 = "";
		private string _warnMessage2 = "";
		private string _warnHeader = "";
		private string _Title = "";
		//
		private System.Windows.Forms.Button btn1;
		private System.Windows.Forms.Button btn2;
		private System.Windows.Forms.Button btn3;
		private System.Windows.Forms.Button btn6;
		private System.Windows.Forms.Button btn5;
		private System.Windows.Forms.Button btn4;
		private System.Windows.Forms.Button btn9;
		private System.Windows.Forms.Button btn8;
		private System.Windows.Forms.Button btn7;
		private System.Windows.Forms.Button btnBack;
		private System.Windows.Forms.Button btn0;
		private System.Windows.Forms.Button btnDone;
		private System.Windows.Forms.TextBox txtNumber;
		private System.Windows.Forms.Button btnClear;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TenKeyPad()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(TenKeyPad));
			this.txtNumber = new System.Windows.Forms.TextBox();
			this.btn1 = new System.Windows.Forms.Button();
			this.btn2 = new System.Windows.Forms.Button();
			this.btn3 = new System.Windows.Forms.Button();
			this.btn6 = new System.Windows.Forms.Button();
			this.btn5 = new System.Windows.Forms.Button();
			this.btn4 = new System.Windows.Forms.Button();
			this.btn9 = new System.Windows.Forms.Button();
			this.btn8 = new System.Windows.Forms.Button();
			this.btn7 = new System.Windows.Forms.Button();
			this.btnBack = new System.Windows.Forms.Button();
			this.btn0 = new System.Windows.Forms.Button();
			this.btnDone = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtNumber
			// 
			this.txtNumber.Enabled = false;
			this.txtNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtNumber.Location = new System.Drawing.Point(48, 8);
			this.txtNumber.Name = "txtNumber";
			this.txtNumber.Size = new System.Drawing.Size(168, 38);
			this.txtNumber.TabIndex = 0;
			this.txtNumber.TabStop = false;
			this.txtNumber.Text = "";
			this.txtNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// btn1
			// 
			this.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn1.Location = new System.Drawing.Point(8, 64);
			this.btn1.Name = "btn1";
			this.btn1.Size = new System.Drawing.Size(64, 64);
			this.btn1.TabIndex = 1;
			this.btn1.Text = "&1";
			this.btn1.Click += new System.EventHandler(this.btn1_Click);
			// 
			// btn2
			// 
			this.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn2.Location = new System.Drawing.Point(72, 64);
			this.btn2.Name = "btn2";
			this.btn2.Size = new System.Drawing.Size(64, 64);
			this.btn2.TabIndex = 2;
			this.btn2.Text = "&2";
			this.btn2.Click += new System.EventHandler(this.btn2_Click);
			// 
			// btn3
			// 
			this.btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn3.Location = new System.Drawing.Point(136, 64);
			this.btn3.Name = "btn3";
			this.btn3.Size = new System.Drawing.Size(64, 64);
			this.btn3.TabIndex = 3;
			this.btn3.Text = "&3";
			this.btn3.Click += new System.EventHandler(this.btn3_Click);
			// 
			// btn6
			// 
			this.btn6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn6.Location = new System.Drawing.Point(136, 128);
			this.btn6.Name = "btn6";
			this.btn6.Size = new System.Drawing.Size(64, 64);
			this.btn6.TabIndex = 6;
			this.btn6.Text = "&6";
			this.btn6.Click += new System.EventHandler(this.btn6_Click);
			// 
			// btn5
			// 
			this.btn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn5.Location = new System.Drawing.Point(72, 128);
			this.btn5.Name = "btn5";
			this.btn5.Size = new System.Drawing.Size(64, 64);
			this.btn5.TabIndex = 5;
			this.btn5.Text = "&5";
			this.btn5.Click += new System.EventHandler(this.btn5_Click);
			// 
			// btn4
			// 
			this.btn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn4.Location = new System.Drawing.Point(8, 128);
			this.btn4.Name = "btn4";
			this.btn4.Size = new System.Drawing.Size(64, 64);
			this.btn4.TabIndex = 4;
			this.btn4.Text = "&4";
			this.btn4.Click += new System.EventHandler(this.btn4_Click);
			// 
			// btn9
			// 
			this.btn9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn9.Location = new System.Drawing.Point(136, 192);
			this.btn9.Name = "btn9";
			this.btn9.Size = new System.Drawing.Size(64, 64);
			this.btn9.TabIndex = 9;
			this.btn9.Text = "&9";
			this.btn9.Click += new System.EventHandler(this.btn9_Click);
			// 
			// btn8
			// 
			this.btn8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn8.Location = new System.Drawing.Point(72, 192);
			this.btn8.Name = "btn8";
			this.btn8.Size = new System.Drawing.Size(64, 64);
			this.btn8.TabIndex = 8;
			this.btn8.Text = "&8";
			this.btn8.Click += new System.EventHandler(this.btn8_Click);
			// 
			// btn7
			// 
			this.btn7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn7.Location = new System.Drawing.Point(8, 192);
			this.btn7.Name = "btn7";
			this.btn7.Size = new System.Drawing.Size(64, 64);
			this.btn7.TabIndex = 7;
			this.btn7.Text = "&7";
			this.btn7.Click += new System.EventHandler(this.btn7_Click);
			// 
			// btnBack
			// 
			this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnBack.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnBack.Image")));
			this.btnBack.Location = new System.Drawing.Point(136, 256);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(64, 64);
			this.btnBack.TabIndex = 12;
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			// 
			// btn0
			// 
			this.btn0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn0.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn0.Location = new System.Drawing.Point(8, 256);
			this.btn0.Name = "btn0";
			this.btn0.Size = new System.Drawing.Size(64, 64);
			this.btn0.TabIndex = 10;
			this.btn0.Text = "&0";
			this.btn0.Click += new System.EventHandler(this.btn0_Click);
			// 
			// btnDone
			// 
			this.btnDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnDone.Location = new System.Drawing.Point(200, 64);
			this.btnDone.Name = "btnDone";
			this.btnDone.Size = new System.Drawing.Size(64, 256);
			this.btnDone.TabIndex = 13;
			this.btnDone.Text = "DONE";
			this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
			// 
			// btnClear
			// 
			this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnClear.Location = new System.Drawing.Point(72, 256);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(64, 64);
			this.btnClear.TabIndex = 14;
			this.btnClear.Text = "&Clear";
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// TenKeyPad
			// 
			this.AcceptButton = this.btnDone;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(270, 326);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnClear,
																		  this.btnDone,
																		  this.btnBack,
																		  this.btn0,
																		  this.btn9,
																		  this.btn8,
																		  this.btn7,
																		  this.btn6,
																		  this.btn5,
																		  this.btn4,
																		  this.btn3,
																		  this.btn2,
																		  this.btn1,
																		  this.txtNumber});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Name = "TenKeyPad";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Specify Number of Drives";
			this.Load += new System.EventHandler(this.TenKeyPad_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btn1_Click(object sender, System.EventArgs e)
		{
			Number = (Number*10)+1;
			txtNumber.Text = Number.ToString();
		}
		private void btn2_Click(object sender, System.EventArgs e)
		{
			Number = (Number*10)+2;
			txtNumber.Text = Number.ToString();
		}
		private void btn3_Click(object sender, System.EventArgs e)
		{
			Number = (Number*10)+3;
			txtNumber.Text = Number.ToString();
		}
		private void btn4_Click(object sender, System.EventArgs e)
		{
			Number = (Number*10)+4;
			txtNumber.Text = Number.ToString();
		}
		private void btn5_Click(object sender, System.EventArgs e)
		{
			Number = (Number*10)+5;
			txtNumber.Text = Number.ToString();
		}
		private void btn6_Click(object sender, System.EventArgs e)
		{
			Number = (Number*10)+6;
			txtNumber.Text = Number.ToString();
		}
		private void btn7_Click(object sender, System.EventArgs e)
		{
			Number = (Number*10)+7;
			txtNumber.Text = Number.ToString();
		}
		private void btn8_Click(object sender, System.EventArgs e)
		{
			Number = (Number*10)+8;
			txtNumber.Text = Number.ToString();
		}
		private void btn9_Click(object sender, System.EventArgs e)
		{
			Number = (Number*10)+9;
			txtNumber.Text = Number.ToString();
		}
		private void btn0_Click(object sender, System.EventArgs e)
		{
			Number = (Number*10);
			txtNumber.Text = Number.ToString();
		}

		private void btnBack_Click(object sender, System.EventArgs e)
		{
			Number = Number/10;
			txtNumber.Text = Number.ToString();
		}

		private void btnDone_Click(object sender, System.EventArgs e)
		{
			if (Number < MinValue)
			{
				MessageBox.Show(WarnMessage2+MinValue.ToString(),WarnHeader);
			}
			else if (Number <= MaxValue)
				this.Close();
			else
				MessageBox.Show(WarnMessage1+MaxValue.ToString(),WarnHeader);
		}

		private void TenKeyPad_Load(object sender, System.EventArgs e)
		{
			txtNumber.Text = Number.ToString();
			this.Text = Title;
		}

		private void btnClear_Click(object sender, System.EventArgs e)
		{
			Number = 0;
			txtNumber.Text = Number.ToString();
		}

		// =============================
		// Define Properties
		// =============================
		public int Number
		{
			get{return _Number;}
			set{_Number = value;}
		}
		public int MinValue
		{
			get{return _MinValue;}
			set{_MinValue = value;}
		}
		public int MaxValue
		{
			get{return _MaxValue;}
			set{_MaxValue = value;}
		}
		public string WarnMessage1
		{
			get{return _warnMessage1;}
			set{_warnMessage1 = value;}
		}
		public string WarnMessage2
		{
			get{return _warnMessage2;}
			set{_warnMessage2 = value;}
		}
		public string WarnHeader
		{
			get{return _warnHeader;}
			set{_warnHeader = value;}
		}
		public string Title
		{
			get{return _Title;}
			set{_Title = value;}
		}
		// =============================
	}
}
