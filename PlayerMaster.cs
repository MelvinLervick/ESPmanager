using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace ESPmanager
{
	/// <summary>
	/// Summary description for PlayerMaster.
	/// </summary>
	public class PlayerMaster : System.Windows.Forms.Form
	{
		private DatabaseAccessControl dac = new DatabaseAccessControl();
		private Database espDB;
		private DataSet ds;
		private Guid _PlayerGUID;
		private int _SelectedPlayerRecord = -1;
		private DataView dvNames;
		private int SelectedRow = 0;
		private bool SelectedRowWasChanged = false;
		private bool UpdatePlayerMasterTable = false;
		private bool AddMode = false;
		//
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnModify;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.TabPage tabName;
		private System.Windows.Forms.TabPage tabAddress;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtFirstName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox gbGender;
		private System.Windows.Forms.RadioButton rbMale;
		private System.Windows.Forms.RadioButton rbFemale;
		private System.Windows.Forms.TextBox txtGHIN;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtClubNumber;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtIndexHandicap;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtEmail;
		private System.Windows.Forms.TextBox txtPhone;
		private System.Windows.Forms.TextBox txtAddressLine1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtAddressLine2;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtState;
		private System.Windows.Forms.TextBox txtPostalCode;
		private System.Windows.Forms.TextBox txtDateRevised;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.DataGrid dgNames;
		private System.Windows.Forms.TabControl tcNames;
		private System.Windows.Forms.TextBox txtLocalNumber;
		private System.Windows.Forms.TextBox txtInitials;
		private System.Windows.Forms.TextBox txtLastName;
		private System.Windows.Forms.TextBox txtCity;
		private System.Windows.Forms.TextBox txtHomeCourseName;
		private System.Windows.Forms.Label label13;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PlayerMaster(ref Database db)
		{
			//
			// Required for Windows Form Designer support
			//
			espDB = db;
			ds = db.GetDS();
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
			this.dgNames = new System.Windows.Forms.DataGrid();
			this.btnExit = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnModify = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.tcNames = new System.Windows.Forms.TabControl();
			this.tabName = new System.Windows.Forms.TabPage();
			this.txtHomeCourseName = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.txtDateRevised = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.txtIndexHandicap = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtLocalNumber = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtClubNumber = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtGHIN = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.gbGender = new System.Windows.Forms.GroupBox();
			this.rbFemale = new System.Windows.Forms.RadioButton();
			this.rbMale = new System.Windows.Forms.RadioButton();
			this.txtInitials = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtLastName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtFirstName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabAddress = new System.Windows.Forms.TabPage();
			this.txtPostalCode = new System.Windows.Forms.TextBox();
			this.txtState = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.txtCity = new System.Windows.Forms.TextBox();
			this.txtAddressLine2 = new System.Windows.Forms.TextBox();
			this.txtAddressLine1 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtPhone = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgNames)).BeginInit();
			this.tcNames.SuspendLayout();
			this.tabName.SuspendLayout();
			this.gbGender.SuspendLayout();
			this.tabAddress.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgNames
			// 
			this.dgNames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dgNames.CaptionText = "Select Golfer";
			this.dgNames.DataMember = "";
			this.dgNames.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgNames.Location = new System.Drawing.Point(8, 8);
			this.dgNames.Name = "dgNames";
			this.dgNames.Size = new System.Drawing.Size(980, 368);
			this.dgNames.TabIndex = 0;
			this.dgNames.CurrentCellChanged += new System.EventHandler(this.dgNames_CurrentCellChanged);
			// 
			// btnExit
			// 
			this.btnExit.BackColor = System.Drawing.Color.Blue;
			this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnExit.Location = new System.Drawing.Point(852, 548);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(128, 126);
			this.btnExit.TabIndex = 5;
			this.btnExit.Text = "Exit";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(128)), ((System.Byte)(255)));
			this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnDelete.Location = new System.Drawing.Point(692, 628);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(128, 52);
			this.btnDelete.TabIndex = 4;
			this.btnDelete.Text = "Delete";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnModify
			// 
			this.btnModify.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(128)), ((System.Byte)(255)));
			this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnModify.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnModify.Location = new System.Drawing.Point(360, 628);
			this.btnModify.Name = "btnModify";
			this.btnModify.Size = new System.Drawing.Size(128, 52);
			this.btnModify.TabIndex = 2;
			this.btnModify.Text = "Modify";
			this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(128)), ((System.Byte)(255)));
			this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnAdd.Location = new System.Drawing.Point(28, 628);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(128, 52);
			this.btnAdd.TabIndex = 0;
			this.btnAdd.Text = "Add";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// tcNames
			// 
			this.tcNames.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.tabName,
																				  this.tabAddress});
			this.tcNames.Location = new System.Drawing.Point(8, 384);
			this.tcNames.Name = "tcNames";
			this.tcNames.SelectedIndex = 0;
			this.tcNames.Size = new System.Drawing.Size(832, 236);
			this.tcNames.TabIndex = 0;
			// 
			// tabName
			// 
			this.tabName.Controls.AddRange(new System.Windows.Forms.Control[] {
																				  this.txtHomeCourseName,
																				  this.label13,
																				  this.txtDateRevised,
																				  this.label12,
																				  this.txtIndexHandicap,
																				  this.label7,
																				  this.txtLocalNumber,
																				  this.label6,
																				  this.txtClubNumber,
																				  this.label5,
																				  this.txtGHIN,
																				  this.label4,
																				  this.gbGender,
																				  this.txtInitials,
																				  this.label3,
																				  this.txtLastName,
																				  this.label2,
																				  this.txtFirstName,
																				  this.label1});
			this.tabName.Location = new System.Drawing.Point(4, 29);
			this.tabName.Name = "tabName";
			this.tabName.Size = new System.Drawing.Size(824, 203);
			this.tabName.TabIndex = 0;
			this.tabName.Text = "Name and Membership Info";
			// 
			// txtHomeCourseName
			// 
			this.txtHomeCourseName.Location = new System.Drawing.Point(544, 72);
			this.txtHomeCourseName.Name = "txtHomeCourseName";
			this.txtHomeCourseName.Size = new System.Drawing.Size(268, 26);
			this.txtHomeCourseName.TabIndex = 6;
			this.txtHomeCourseName.Text = "";
			this.txtHomeCourseName.TextChanged += new System.EventHandler(this.TextChanged);
			// 
			// label13
			// 
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label13.Location = new System.Drawing.Point(384, 72);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(152, 26);
			this.label13.TabIndex = 17;
			this.label13.Text = "Club Name:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDateRevised
			// 
			this.txtDateRevised.Location = new System.Drawing.Point(544, 168);
			this.txtDateRevised.Name = "txtDateRevised";
			this.txtDateRevised.ReadOnly = true;
			this.txtDateRevised.Size = new System.Drawing.Size(192, 26);
			this.txtDateRevised.TabIndex = 9;
			this.txtDateRevised.Text = "";
			// 
			// label12
			// 
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label12.Location = new System.Drawing.Point(384, 168);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(152, 26);
			this.label12.TabIndex = 15;
			this.label12.Text = "Last Revised:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtIndexHandicap
			// 
			this.txtIndexHandicap.Location = new System.Drawing.Point(544, 136);
			this.txtIndexHandicap.Name = "txtIndexHandicap";
			this.txtIndexHandicap.Size = new System.Drawing.Size(68, 26);
			this.txtIndexHandicap.TabIndex = 8;
			this.txtIndexHandicap.Text = "";
			this.txtIndexHandicap.TextChanged += new System.EventHandler(this.TextChanged);
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label7.Location = new System.Drawing.Point(384, 136);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(152, 26);
			this.label7.TabIndex = 13;
			this.label7.Text = "Index Handicap:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtLocalNumber
			// 
			this.txtLocalNumber.Location = new System.Drawing.Point(544, 104);
			this.txtLocalNumber.Name = "txtLocalNumber";
			this.txtLocalNumber.Size = new System.Drawing.Size(164, 26);
			this.txtLocalNumber.TabIndex = 7;
			this.txtLocalNumber.Text = "";
			this.txtLocalNumber.TextChanged += new System.EventHandler(this.TextChanged);
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(384, 104);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(152, 26);
			this.label6.TabIndex = 11;
			this.label6.Text = "Local Number:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtClubNumber
			// 
			this.txtClubNumber.Location = new System.Drawing.Point(544, 40);
			this.txtClubNumber.Name = "txtClubNumber";
			this.txtClubNumber.Size = new System.Drawing.Size(128, 26);
			this.txtClubNumber.TabIndex = 5;
			this.txtClubNumber.Text = "";
			this.txtClubNumber.TextChanged += new System.EventHandler(this.TextChanged);
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(384, 40);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(152, 26);
			this.label5.TabIndex = 9;
			this.label5.Text = "Club Number:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtGHIN
			// 
			this.txtGHIN.Location = new System.Drawing.Point(544, 8);
			this.txtGHIN.Name = "txtGHIN";
			this.txtGHIN.Size = new System.Drawing.Size(164, 26);
			this.txtGHIN.TabIndex = 4;
			this.txtGHIN.Text = "";
			this.txtGHIN.TextChanged += new System.EventHandler(this.TextChanged);
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(384, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(152, 26);
			this.label4.TabIndex = 7;
			this.label4.Text = "USGA GHIN #:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// gbGender
			// 
			this.gbGender.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.rbFemale,
																				   this.rbMale});
			this.gbGender.Location = new System.Drawing.Point(120, 104);
			this.gbGender.Name = "gbGender";
			this.gbGender.Size = new System.Drawing.Size(176, 60);
			this.gbGender.TabIndex = 3;
			this.gbGender.TabStop = false;
			// 
			// rbFemale
			// 
			this.rbFemale.Location = new System.Drawing.Point(80, 24);
			this.rbFemale.Name = "rbFemale";
			this.rbFemale.Size = new System.Drawing.Size(88, 24);
			this.rbFemale.TabIndex = 1;
			this.rbFemale.Text = "Female";
			this.rbFemale.CheckedChanged += new System.EventHandler(this.TextChanged);
			// 
			// rbMale
			// 
			this.rbMale.Location = new System.Drawing.Point(12, 24);
			this.rbMale.Name = "rbMale";
			this.rbMale.Size = new System.Drawing.Size(60, 24);
			this.rbMale.TabIndex = 0;
			this.rbMale.Text = "Male";
			this.rbMale.CheckedChanged += new System.EventHandler(this.TextChanged);
			// 
			// txtInitials
			// 
			this.txtInitials.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtInitials.Location = new System.Drawing.Point(120, 72);
			this.txtInitials.Name = "txtInitials";
			this.txtInitials.Size = new System.Drawing.Size(68, 26);
			this.txtInitials.TabIndex = 2;
			this.txtInitials.Text = "";
			this.txtInitials.TextChanged += new System.EventHandler(this.TextChanged);
			this.txtInitials.Leave += new System.EventHandler(this.txtInitials_Leave);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(8, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(112, 26);
			this.label3.TabIndex = 4;
			this.label3.Text = "Initials:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtLastName
			// 
			this.txtLastName.Location = new System.Drawing.Point(120, 40);
			this.txtLastName.Name = "txtLastName";
			this.txtLastName.Size = new System.Drawing.Size(248, 26);
			this.txtLastName.TabIndex = 1;
			this.txtLastName.Text = "";
			this.txtLastName.TextChanged += new System.EventHandler(this.TextChanged);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(8, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 26);
			this.label2.TabIndex = 2;
			this.label2.Text = "Last Name:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtFirstName
			// 
			this.txtFirstName.Location = new System.Drawing.Point(120, 8);
			this.txtFirstName.Name = "txtFirstName";
			this.txtFirstName.Size = new System.Drawing.Size(248, 26);
			this.txtFirstName.TabIndex = 0;
			this.txtFirstName.Text = "";
			this.txtFirstName.TextChanged += new System.EventHandler(this.TextChanged);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "First Name:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabAddress
			// 
			this.tabAddress.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.txtPostalCode,
																					 this.txtState,
																					 this.label11,
																					 this.txtCity,
																					 this.txtAddressLine2,
																					 this.txtAddressLine1,
																					 this.label10,
																					 this.txtPhone,
																					 this.label9,
																					 this.txtEmail,
																					 this.label8});
			this.tabAddress.Location = new System.Drawing.Point(4, 29);
			this.tabAddress.Name = "tabAddress";
			this.tabAddress.Size = new System.Drawing.Size(824, 203);
			this.tabAddress.TabIndex = 1;
			this.tabAddress.Text = "Address, Phone and Email";
			// 
			// txtPostalCode
			// 
			this.txtPostalCode.Location = new System.Drawing.Point(488, 140);
			this.txtPostalCode.Name = "txtPostalCode";
			this.txtPostalCode.Size = new System.Drawing.Size(140, 26);
			this.txtPostalCode.TabIndex = 6;
			this.txtPostalCode.Text = "";
			this.txtPostalCode.TextChanged += new System.EventHandler(this.TextChanged);
			// 
			// txtState
			// 
			this.txtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtState.Location = new System.Drawing.Point(416, 140);
			this.txtState.Name = "txtState";
			this.txtState.Size = new System.Drawing.Size(48, 26);
			this.txtState.TabIndex = 5;
			this.txtState.Text = "";
			this.txtState.TextChanged += new System.EventHandler(this.TextChanged);
			this.txtState.Leave += new System.EventHandler(this.txtState_Leave);
			// 
			// label11
			// 
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label11.Location = new System.Drawing.Point(12, 140);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(132, 26);
			this.label11.TabIndex = 10;
			this.label11.Text = "City, State, Zip";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCity
			// 
			this.txtCity.Location = new System.Drawing.Point(148, 140);
			this.txtCity.Name = "txtCity";
			this.txtCity.Size = new System.Drawing.Size(256, 26);
			this.txtCity.TabIndex = 4;
			this.txtCity.Text = "";
			this.txtCity.TextChanged += new System.EventHandler(this.TextChanged);
			// 
			// txtAddressLine2
			// 
			this.txtAddressLine2.Location = new System.Drawing.Point(148, 108);
			this.txtAddressLine2.Name = "txtAddressLine2";
			this.txtAddressLine2.Size = new System.Drawing.Size(340, 26);
			this.txtAddressLine2.TabIndex = 3;
			this.txtAddressLine2.Text = "";
			this.txtAddressLine2.TextChanged += new System.EventHandler(this.TextChanged);
			// 
			// txtAddressLine1
			// 
			this.txtAddressLine1.Location = new System.Drawing.Point(148, 76);
			this.txtAddressLine1.Name = "txtAddressLine1";
			this.txtAddressLine1.Size = new System.Drawing.Size(340, 26);
			this.txtAddressLine1.TabIndex = 2;
			this.txtAddressLine1.Text = "";
			this.txtAddressLine1.TextChanged += new System.EventHandler(this.TextChanged);
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label10.Location = new System.Drawing.Point(12, 76);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(112, 26);
			this.label10.TabIndex = 6;
			this.label10.Text = "Address:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtPhone
			// 
			this.txtPhone.Location = new System.Drawing.Point(148, 40);
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.Size = new System.Drawing.Size(204, 26);
			this.txtPhone.TabIndex = 1;
			this.txtPhone.Text = "";
			this.txtPhone.TextChanged += new System.EventHandler(this.TextChanged);
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label9.Location = new System.Drawing.Point(12, 40);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(112, 26);
			this.label9.TabIndex = 4;
			this.label9.Text = "Phone:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtEmail
			// 
			this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
			this.txtEmail.Location = new System.Drawing.Point(148, 8);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(540, 26);
			this.txtEmail.TabIndex = 0;
			this.txtEmail.Text = "";
			this.txtEmail.TextChanged += new System.EventHandler(this.TextChanged);
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label8.Location = new System.Drawing.Point(12, 8);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(136, 26);
			this.label8.TabIndex = 2;
			this.label8.Text = "Email Address:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnCancel
			// 
			this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(128)), ((System.Byte)(255)));
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(194, 628);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(128, 52);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSave
			// 
			this.btnSave.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(128)), ((System.Byte)(255)));
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnSave.Location = new System.Drawing.Point(526, 628);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(128, 52);
			this.btnSave.TabIndex = 3;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// PlayerMaster
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.ClientSize = new System.Drawing.Size(994, 688);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnSave,
																		  this.btnCancel,
																		  this.tcNames,
																		  this.btnExit,
																		  this.btnDelete,
																		  this.btnModify,
																		  this.btnAdd,
																		  this.dgNames});
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "PlayerMaster";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Maintain Golfer Information";
			this.Load += new System.EventHandler(this.PlayerMaster_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgNames)).EndInit();
			this.tcNames.ResumeLayout(false);
			this.tabName.ResumeLayout(false);
			this.gbGender.ResumeLayout(false);
			this.tabAddress.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			if (UpdatePlayerMasterTable)
			{
				espDB.SavePlayerMasterChanges();
			}
			CurrencyManager myCM = (CurrencyManager)this.BindingContext[dvNames];
			DataRowView drv = (DataRowView)myCM.Current;
			PlayerGUID = (Guid)drv.Row["PlayerMasterGUID"];
			this.Close();
		}

		private void PlayerMaster_Load(object sender, System.EventArgs e)
		{
			bool PlayerFound = false;
			// Set up the DataSource for the Players DataGrid
			dvNames = new DataView( ds.Tables["PlayerMaster"] );
			dvNames.AllowNew = false;
			dvNames.Sort = "Lastname, Firstname";
			dgNames.SetDataBinding(dvNames,null);
			//
			foreach (DataRowView drv in  dvNames)
			{
				this.SelectedPlayerRecord++;
				if ((Guid)drv.Row["PlayerMasterGUID"] == _PlayerGUID)
				{
					PlayerFound = true;
					break;
				}
			}
			ConfigureNamesGrid();
			this.UpdatePlayerMasterTable = false;

			if (SelectedPlayerRecord != -1)
			{
				// Set the initial record to the specified row.
				if (!PlayerFound)
				{
					this.SelectedPlayerRecord = 0;
				}
				dgNames.Select(SelectedPlayerRecord);
				dgNames.CurrentRowIndex = SelectedPlayerRecord;
			}
			//
			// Initialize objects to VIEW
			SetAEDObjects(false);
			//
			// Set current row info
			this.SelectedRow = dgNames.CurrentRowIndex;
			// set Form Fields to display currently selected record
			TransferRecordToEditFields();
		}

		/// <summary>
		///  If state=FALSE, View Only Else add/edit
		/// </summary>
		/// <param name="state"></param>
		private void SetAEDObjects(bool state)
		{
			// Set FORM Buttons
			this.btnCancel.Visible = state;
			this.btnSave.Visible = state;
			if (dgNames.VisibleRowCount == 0)
			{
				this.btnModify.Visible = false;
				this.btnDelete.Visible = false;
			}
			else
			{
				this.btnModify.Visible = !state;
				this.btnDelete.Visible = !state;
			}
			this.btnAdd.Visible = !state;
			this.btnExit.Visible = !state;
			//
			// Set Form Fields
			dgNames.Enabled = !state;
			this.txtFirstName.Enabled = state;
			this.txtLastName.Enabled = state;
			this.txtInitials.Enabled = state;
			this.gbGender.Enabled = state;
			this.txtGHIN.Enabled = state;
			this.txtClubNumber.Enabled = state;
			this.txtHomeCourseName.Enabled = state;
			this.txtLocalNumber.Enabled = state;
			this.txtIndexHandicap.Enabled = state;
			this.txtDateRevised.Enabled = state;
			this.txtAddressLine1.Enabled = state;
			this.txtAddressLine2.Enabled = state;
			this.txtCity.Enabled = state;
			this.txtState.Enabled = state;
			this.txtPostalCode.Enabled = state;
			this.txtPhone.Enabled = state;
			this.txtEmail.Enabled = state;
		}

		private void ConfigureNamesGrid()
		{
			DataGridTableStyle ts = new DataGridTableStyle();
			ts.MappingName = "PlayerMaster";
			// Set other properties.
			ts.AlternatingBackColor = Color.LightBlue;
			ts.RowHeaderWidth = 30;
			//ts.ReadOnly = true;

			// Add first column style.
			DataGridBoolColumn Col = new DataGridBoolColumn();
			Col.MappingName = "Assigned";
			Col.HeaderText = "";
			Col.Width = 25;
			ts.GridColumnStyles.Add(Col);

			// Add first column style.
			DataGridTextBoxColumn TextCol1 = new DataGridTextBoxColumn();
			TextCol1.MappingName = "LastName";
			TextCol1.HeaderText = "Last Name";
			TextCol1.Width = 150;
			ts.GridColumnStyles.Add(TextCol1);

			// Add second column style.
			DataGridTextBoxColumn TextCol2 = new DataGridTextBoxColumn();
			TextCol2.MappingName = "FirstName";
			TextCol2.HeaderText = "First Name";
			TextCol2.Width = 150;
			ts.GridColumnStyles.Add(TextCol2);

			// Add third column style.
			DataGridTextBoxColumn TextCol3 = new DataGridTextBoxColumn();
			TextCol3.MappingName = "Initials";
			TextCol3.HeaderText = "Initials";
			TextCol3.Width = 75;
			ts.GridColumnStyles.Add(TextCol3);

			// Add 4th column style.
			DataGridTextBoxColumn TextCol4 = new DataGridTextBoxColumn();
			TextCol4.MappingName = "IndexHandicap";
			TextCol4.HeaderText = "HDCP";
			TextCol4.Width = 75;
			ts.GridColumnStyles.Add(TextCol4);

			// Add 5th column style.
			DataGridTextBoxColumn TextCol5 = new DataGridTextBoxColumn();
			TextCol5.MappingName = "DisplayGender";
			TextCol5.HeaderText = "Gender";
			TextCol5.Width = 75;
			ts.GridColumnStyles.Add(TextCol5);

			// Add 6th column style.
			DataGridTextBoxColumn TextCol6 = new DataGridTextBoxColumn();
			TextCol6.MappingName = "GHIN";
			TextCol6.HeaderText = "GHIN";
			TextCol6.Width = 125;
			ts.GridColumnStyles.Add(TextCol6);

			// Add 7th column style.
			DataGridTextBoxColumn TextCol7 = new DataGridTextBoxColumn();
			TextCol7.MappingName = "ClubNumber";
			TextCol7.HeaderText = "Club #";
			TextCol7.Width = 125;
			ts.GridColumnStyles.Add(TextCol7);

			// Add 8th column style.
			DataGridTextBoxColumn TextCol8 = new DataGridTextBoxColumn();
			TextCol8.MappingName = "LocalNumber";
			TextCol8.HeaderText = "Local #";
			TextCol8.Width = 125;
			ts.GridColumnStyles.Add(TextCol8);

			dgNames.TableStyles.Add(ts);
		}

		private void dgNames_CurrentCellChanged(object sender, System.EventArgs e)
		{
			if (dgNames.CurrentRowIndex != this.SelectedRow)
			{
				this.SelectedRow = dgNames.CurrentRowIndex;
				this.SelectedRowWasChanged = false;
			}
			// set Form Fields to display currently selected record
			TransferRecordToEditFields();
		}

		private void TransferRecordToEditFields()
		{
			byte gender = 0;
			CurrencyManager myCM = (CurrencyManager)this.BindingContext[dvNames];
			DataRowView dr = (DataRowView)myCM.Current;
			//
			this.txtFirstName.Text = dr["FirstName"].ToString();
			this.txtLastName.Text = dr["LastName"].ToString();
			this.txtInitials.Text = dr["Initials"].ToString();
			gender = (byte)dr["Gender"];
			if (gender == 0) rbMale.Checked = true; else rbFemale.Checked = true;
			this.txtGHIN.Text = dr["GHIN"].ToString();
			this.txtClubNumber.Text = dr["ClubNumber"].ToString();
			this.txtHomeCourseName.Text = dr["HomeCourseName"].ToString();
			this.txtLocalNumber.Text = dr["LocalNumber"].ToString();
			this.txtIndexHandicap.Text = dr["IndexHandicap"].ToString();
			this.txtDateRevised.Text = dr["DateRevised"].ToString();
			this.txtAddressLine1.Text = dr["AddressLine1"].ToString();
			this.txtAddressLine2.Text = dr["AddressLine2"].ToString();
			this.txtCity.Text = dr["City"].ToString();
			this.txtState.Text = dr["State"].ToString();
			this.txtPostalCode.Text = dr["PostalCode"].ToString();
			this.txtPhone.Text = dr["Phone"].ToString();
			this.txtEmail.Text = dr["Email"].ToString();
			//
			dr = null;
			//dt = null;
		}

		private void TransferEditFieldsToRecord()
		{
			byte gender = 0;
			CurrencyManager myCM = (CurrencyManager)this.BindingContext[dvNames];
			DataRowView dr = (DataRowView)myCM.Current;

			dr.BeginEdit();
			dr["FirstName"] = this.txtFirstName.Text;
			dr["LastName"] = this.txtLastName.Text;
			dr["Initials"] = this.txtInitials.Text;
			if (rbMale.Checked) gender = 0; else gender = 1;
			dr["Gender"] = gender;
			dr["GHIN"] = this.txtGHIN.Text;
			dr["ClubNumber"] = this.txtClubNumber.Text;
			dr["HomeCourseName"] = this.txtHomeCourseName.Text;
			dr["LocalNumber"] = this.txtLocalNumber.Text;
			if (this.txtIndexHandicap.Text == "") this.txtIndexHandicap.Text = "0";
			dr["IndexHandicap"] = Double.Parse(this.txtIndexHandicap.Text);
			dr["DateRevised"] = DateTime.Now;
			dr["AddressLine1"] = this.txtAddressLine1.Text;
			dr["AddressLine2"] = this.txtAddressLine2.Text;
			dr["City"] = this.txtCity.Text;
			dr["State"] = this.txtState.Text;
			dr["PostalCode"] = this.txtPostalCode.Text;
			dr["Phone"] = this.txtPhone.Text;
			dr["Email"] = this.txtEmail.Text;
			dr.EndEdit();

			dr = null;
		}

		private void TransferEditFieldsToNewRecord()
		{
			byte gender = 0;
			Guid g = Guid.NewGuid();
			dvNames.AllowNew = true;
			DataRowView dr = dvNames.AddNew();

			dr.Row["PlayerMasterGUID"] = g;
			dr.Row["FirstName"] = this.txtFirstName.Text;
			dr.Row["LastName"] = this.txtLastName.Text;
			dr.Row["Initials"] = this.txtInitials.Text;
			if (rbMale.Checked) gender = 0; else gender = 1;
			dr.Row["Gender"] = gender;
			dr.Row["GHIN"] = this.txtGHIN.Text;
			dr.Row["ClubNumber"] = this.txtClubNumber.Text;
			dr.Row["HomeCourseName"] = this.txtHomeCourseName.Text;
			dr.Row["LocalNumber"] = this.txtLocalNumber.Text;
			if (this.txtIndexHandicap.Text == "") this.txtIndexHandicap.Text = "0";
			dr.Row["IndexHandicap"] = Double.Parse(this.txtIndexHandicap.Text);
			dr.Row["DateRevised"] = DateTime.Now;
			dr.Row["AddressLine1"] = this.txtAddressLine1.Text;
			dr.Row["AddressLine2"] = this.txtAddressLine2.Text;
			dr.Row["City"] = this.txtCity.Text;
			dr.Row["State"] = this.txtState.Text;
			dr.Row["PostalCode"] = this.txtPostalCode.Text;
			dr.Row["Phone"] = this.txtPhone.Text;
			dr.Row["Email"] = this.txtEmail.Text;
			dr.EndEdit();
			//
			_PlayerGUID = g;
			//
			dr = null;
			dvNames.AllowNew = false;
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			// Add a New Record in save
			this.AddMode = true;
			this.txtFirstName.Text = "";
			this.txtLastName.Text = "";
			this.txtInitials.Text = "";
			rbMale.Checked = true;
			this.txtGHIN.Text = "";
			this.txtClubNumber.Text = "";
			this.txtHomeCourseName.Text = "";
			this.txtLocalNumber.Text = "";
			this.txtIndexHandicap.Text = "";
			this.txtDateRevised.Text = DateTime.Now.ToLongDateString();
			this.txtAddressLine1.Text = "";
			this.txtAddressLine2.Text = "";
			this.txtCity.Text = "";
			this.txtState.Text = "";
			this.txtPostalCode.Text = "";
			this.txtPhone.Text = "";
			this.txtEmail.Text = "";
			//
			// Enable Fields and Buttons for Editing
			this.SetAEDObjects(true);
			this.SelectedRowWasChanged = false;
			this.txtFirstName.Focus();
		}

		private void btnModify_Click(object sender, System.EventArgs e)
		{
			// Enable fields and buttons for editing
			this.AddMode = false;
			this.SetAEDObjects(true);
			this.SelectedRowWasChanged = false;
			this.txtFirstName.Focus();
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			// Verify that the current player is to be deleted
			TouchMessageBox tmb = new TouchMessageBox();
			tmb.Header = "Delete the Selected Person";
			tmb.Message = "Select DELETE to confirm that you want to delete this person.  Select CANCEL to cancel the delete of this person.";
			tmb.Cancel = "&Cancel";
			tmb.Confirm = "&Delete";
			tmb.ShowDialog();
			if (tmb.Return)
			{
				// Delete the selected Person
				CurrencyManager myCM = (CurrencyManager)this.BindingContext[dvNames];
				DataRowView dr = (DataRowView)myCM.Current;
				dr.Delete();
				espDB.SavePlayerMasterChanges();
				dr = null;
				 this.SelectedRow = dgNames.CurrentRowIndex;
				TransferRecordToEditFields();
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			// Reset field values to original values
			TransferRecordToEditFields();

			// Reset fields and buttons for no editing
			this.AddMode = false;
			this.SetAEDObjects(false);
			this.SelectedRowWasChanged = false;
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if (this.SelectedRowWasChanged)
			{
				// Data in the currently selected row was changed.  Update the Table in the
				// DataSet and set flag to update the TABLE.
				if (AddMode)
				{
					// Add a New record and store user specified data
					TransferEditFieldsToNewRecord();
					//
					// Set the record to the new record.
					this.SelectedPlayerRecord = -1;
					foreach (DataRowView drv in  dvNames)
					{
						this.SelectedPlayerRecord++;
						if ((Guid)drv.Row["PlayerMasterGUID"] == _PlayerGUID) break;
					}
					//
					if (SelectedPlayerRecord != -1)
					{
						// Set the initial record to the specified row.
						dgNames.Select(SelectedPlayerRecord);
						dgNames.CurrentRowIndex = SelectedPlayerRecord;
					}
					this.SelectedRow = dgNames.CurrentRowIndex;
					TransferRecordToEditFields();
				}
				else
				{
					// Update Current Record
					TransferEditFieldsToRecord();
				}
				this.UpdatePlayerMasterTable = true;
				this.SelectedRowWasChanged = false;
			}
			// Reset fields and buttons for no editing
			this.AddMode = false;
			this.SetAEDObjects(false);
		}

		private void TextChanged(object sender, System.EventArgs e)
		{
			if (this.btnCancel.Visible)
				this.SelectedRowWasChanged = true;
		}

		private void txtState_Leave(object sender, System.EventArgs e)
		{
			this.txtState.Text = this.txtState.Text.ToUpper();
		}

		private void txtInitials_Leave(object sender, System.EventArgs e)
		{
			this.txtInitials.Text = this.txtInitials.Text.ToUpper();
		}
		// ============================
		// Property Definitions
		// ============================
		public int SelectedPlayerRecord
		{
			get{ return _SelectedPlayerRecord; }
			set{ _SelectedPlayerRecord = value; }
		}
		public Guid PlayerGUID
		{
			get{ return _PlayerGUID; }
			set{ _PlayerGUID = value; }
		}
		// ============================
		// Class Definition
		// ============================
	}
}
