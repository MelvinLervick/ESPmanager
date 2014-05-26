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
	/// Summary description for TournamentDetails.
	/// </summary>
	public class TournamentDetails : System.Windows.Forms.Form
	{
		private const bool READONLY = false;
		private const bool EDIT = true;
		private int _TournamentID = 0;
		private bool AddMode = false;
		DataView dvDetails;
		private Database espDB;
		private DataSet ds;
		OleDbDataAdapter tlAdapter = null;
		int CurrentDetailID = 0;
		//
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox txtTournamentName;
		private System.Windows.Forms.Label lblTournamentName;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Button btnDate;
		private System.Windows.Forms.TextBox txtEndDate;
		private System.Windows.Forms.Label lblEnddate;
		private System.Windows.Forms.TextBox txtStartDate;
		private System.Windows.Forms.Label lblStartDate;
		private System.Windows.Forms.Button btnDeleteTournament;
		private System.Windows.Forms.Button btnAddTournament;
		private System.Windows.Forms.Button btnSaveTournament;
		private System.Windows.Forms.Button btnCancelTournament;
		private System.Windows.Forms.Button btnEditTournament;
		private System.Windows.Forms.Panel pnlDetails;
		private System.Windows.Forms.Label lblRoundDate;
		private System.Windows.Forms.Button btnNextDate;
		private System.Windows.Forms.Button btnPrevDate;
		private System.Windows.Forms.TextBox txtRoundDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtRoundNumber;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtFirstTeeTime;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtTeeTimeSeparation;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtNumberOfTeeTimes;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtNumberOfHandhelds;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtPlayersPerHandheld;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtStartingHole;
		private System.Windows.Forms.Button btnGenerate;
		private System.Windows.Forms.Button btnDivisions;
		private System.Windows.Forms.DataGrid dgDetails;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.TextBox txtNumberOfRounds;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtNumberOfDivisions;
		private System.Windows.Forms.Label label10;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public TournamentDetails( ref Database espdb )
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.txtNumberOfDivisions = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtNumberOfRounds = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.btnDivisions = new System.Windows.Forms.Button();
			this.btnDeleteTournament = new System.Windows.Forms.Button();
			this.btnEditTournament = new System.Windows.Forms.Button();
			this.btnAddTournament = new System.Windows.Forms.Button();
			this.btnSaveTournament = new System.Windows.Forms.Button();
			this.btnCancelTournament = new System.Windows.Forms.Button();
			this.btnDate = new System.Windows.Forms.Button();
			this.txtEndDate = new System.Windows.Forms.TextBox();
			this.lblEnddate = new System.Windows.Forms.Label();
			this.txtStartDate = new System.Windows.Forms.TextBox();
			this.lblStartDate = new System.Windows.Forms.Label();
			this.txtTournamentName = new System.Windows.Forms.TextBox();
			this.lblTournamentName = new System.Windows.Forms.Label();
			this.btnExit = new System.Windows.Forms.Button();
			this.pnlDetails = new System.Windows.Forms.Panel();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.dgDetails = new System.Windows.Forms.DataGrid();
			this.txtPlayersPerHandheld = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtNumberOfHandhelds = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtStartingHole = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtNumberOfTeeTimes = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtTeeTimeSeparation = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtFirstTeeTime = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtRoundNumber = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnPrevDate = new System.Windows.Forms.Button();
			this.btnNextDate = new System.Windows.Forms.Button();
			this.txtRoundDate = new System.Windows.Forms.TextBox();
			this.lblRoundDate = new System.Windows.Forms.Label();
			this.btnGenerate = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.pnlDetails.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgDetails)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.txtNumberOfDivisions,
																				 this.label10,
																				 this.txtNumberOfRounds,
																				 this.label9,
																				 this.btnDivisions,
																				 this.btnDeleteTournament,
																				 this.btnEditTournament,
																				 this.btnAddTournament,
																				 this.btnSaveTournament,
																				 this.btnCancelTournament,
																				 this.btnDate,
																				 this.txtEndDate,
																				 this.lblEnddate,
																				 this.txtStartDate,
																				 this.lblStartDate,
																				 this.txtTournamentName,
																				 this.lblTournamentName});
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(996, 212);
			this.panel1.TabIndex = 1;
			// 
			// txtNumberOfDivisions
			// 
			this.txtNumberOfDivisions.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtNumberOfDivisions.Location = new System.Drawing.Point(688, 96);
			this.txtNumberOfDivisions.Name = "txtNumberOfDivisions";
			this.txtNumberOfDivisions.ReadOnly = true;
			this.txtNumberOfDivisions.Size = new System.Drawing.Size(84, 31);
			this.txtNumberOfDivisions.TabIndex = 4;
			this.txtNumberOfDivisions.Text = "";
			// 
			// label10
			// 
			this.label10.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label10.Location = new System.Drawing.Point(440, 96);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(244, 32);
			this.label10.TabIndex = 56;
			this.label10.Text = "Number of Divisions";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtNumberOfRounds
			// 
			this.txtNumberOfRounds.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtNumberOfRounds.Location = new System.Drawing.Point(688, 56);
			this.txtNumberOfRounds.Name = "txtNumberOfRounds";
			this.txtNumberOfRounds.ReadOnly = true;
			this.txtNumberOfRounds.Size = new System.Drawing.Size(84, 31);
			this.txtNumberOfRounds.TabIndex = 3;
			this.txtNumberOfRounds.Text = "";
			// 
			// label9
			// 
			this.label9.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label9.Location = new System.Drawing.Point(440, 56);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(244, 32);
			this.label9.TabIndex = 54;
			this.label9.Text = "Number of Rounds";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnDivisions
			// 
			this.btnDivisions.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnDivisions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDivisions.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnDivisions.Location = new System.Drawing.Point(788, 8);
			this.btnDivisions.Name = "btnDivisions";
			this.btnDivisions.Size = new System.Drawing.Size(184, 120);
			this.btnDivisions.TabIndex = 11;
			this.btnDivisions.Text = "Di&visions";
			// 
			// btnDeleteTournament
			// 
			this.btnDeleteTournament.BackColor = System.Drawing.SystemColors.Control;
			this.btnDeleteTournament.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDeleteTournament.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnDeleteTournament.Location = new System.Drawing.Point(832, 156);
			this.btnDeleteTournament.Name = "btnDeleteTournament";
			this.btnDeleteTournament.Size = new System.Drawing.Size(140, 44);
			this.btnDeleteTournament.TabIndex = 10;
			this.btnDeleteTournament.Text = "Delete";
			this.btnDeleteTournament.Click += new System.EventHandler(this.btnDeleteTournament_Click);
			// 
			// btnEditTournament
			// 
			this.btnEditTournament.BackColor = System.Drawing.SystemColors.Control;
			this.btnEditTournament.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEditTournament.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnEditTournament.Location = new System.Drawing.Point(536, 156);
			this.btnEditTournament.Name = "btnEditTournament";
			this.btnEditTournament.Size = new System.Drawing.Size(140, 44);
			this.btnEditTournament.TabIndex = 8;
			this.btnEditTournament.Text = "Modify";
			this.btnEditTournament.Click += new System.EventHandler(this.btnEditTournament_Click);
			// 
			// btnAddTournament
			// 
			this.btnAddTournament.BackColor = System.Drawing.SystemColors.Control;
			this.btnAddTournament.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAddTournament.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnAddTournament.Location = new System.Drawing.Point(236, 156);
			this.btnAddTournament.Name = "btnAddTournament";
			this.btnAddTournament.Size = new System.Drawing.Size(140, 44);
			this.btnAddTournament.TabIndex = 6;
			this.btnAddTournament.Text = "Add";
			this.btnAddTournament.Click += new System.EventHandler(this.btnAddTournament_Click);
			// 
			// btnSaveTournament
			// 
			this.btnSaveTournament.BackColor = System.Drawing.SystemColors.Control;
			this.btnSaveTournament.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSaveTournament.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnSaveTournament.Location = new System.Drawing.Point(684, 156);
			this.btnSaveTournament.Name = "btnSaveTournament";
			this.btnSaveTournament.Size = new System.Drawing.Size(140, 44);
			this.btnSaveTournament.TabIndex = 9;
			this.btnSaveTournament.Text = "&Save";
			this.btnSaveTournament.Click += new System.EventHandler(this.btnSaveTournament_Click);
			// 
			// btnCancelTournament
			// 
			this.btnCancelTournament.BackColor = System.Drawing.SystemColors.Control;
			this.btnCancelTournament.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancelTournament.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCancelTournament.Location = new System.Drawing.Point(384, 156);
			this.btnCancelTournament.Name = "btnCancelTournament";
			this.btnCancelTournament.Size = new System.Drawing.Size(140, 44);
			this.btnCancelTournament.TabIndex = 7;
			this.btnCancelTournament.Text = "&Cancel";
			this.btnCancelTournament.Click += new System.EventHandler(this.btnCancelTournament_Click);
			// 
			// btnDate
			// 
			this.btnDate.BackColor = System.Drawing.Color.Navy;
			this.btnDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnDate.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.btnDate.Location = new System.Drawing.Point(16, 140);
			this.btnDate.Name = "btnDate";
			this.btnDate.Size = new System.Drawing.Size(184, 60);
			this.btnDate.TabIndex = 5;
			this.btnDate.Text = "C&hange Dates";
			this.btnDate.Click += new System.EventHandler(this.btnDate_Click);
			// 
			// txtEndDate
			// 
			this.txtEndDate.Enabled = false;
			this.txtEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtEndDate.Location = new System.Drawing.Point(212, 96);
			this.txtEndDate.Name = "txtEndDate";
			this.txtEndDate.ReadOnly = true;
			this.txtEndDate.Size = new System.Drawing.Size(156, 31);
			this.txtEndDate.TabIndex = 2;
			this.txtEndDate.Text = "";
			// 
			// lblEnddate
			// 
			this.lblEnddate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.lblEnddate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblEnddate.Location = new System.Drawing.Point(60, 96);
			this.lblEnddate.Name = "lblEnddate";
			this.lblEnddate.Size = new System.Drawing.Size(140, 32);
			this.lblEnddate.TabIndex = 44;
			this.lblEnddate.Text = "End Date";
			this.lblEnddate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtStartDate
			// 
			this.txtStartDate.Enabled = false;
			this.txtStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtStartDate.Location = new System.Drawing.Point(212, 52);
			this.txtStartDate.Name = "txtStartDate";
			this.txtStartDate.ReadOnly = true;
			this.txtStartDate.Size = new System.Drawing.Size(156, 31);
			this.txtStartDate.TabIndex = 1;
			this.txtStartDate.Text = "";
			// 
			// lblStartDate
			// 
			this.lblStartDate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.lblStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblStartDate.Location = new System.Drawing.Point(60, 52);
			this.lblStartDate.Name = "lblStartDate";
			this.lblStartDate.Size = new System.Drawing.Size(144, 32);
			this.lblStartDate.TabIndex = 42;
			this.lblStartDate.Text = "Start Date";
			this.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtTournamentName
			// 
			this.txtTournamentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtTournamentName.Location = new System.Drawing.Point(212, 8);
			this.txtTournamentName.Name = "txtTournamentName";
			this.txtTournamentName.ReadOnly = true;
			this.txtTournamentName.Size = new System.Drawing.Size(560, 31);
			this.txtTournamentName.TabIndex = 0;
			this.txtTournamentName.Text = "";
			// 
			// lblTournamentName
			// 
			this.lblTournamentName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.lblTournamentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTournamentName.Location = new System.Drawing.Point(8, 8);
			this.lblTournamentName.Name = "lblTournamentName";
			this.lblTournamentName.Size = new System.Drawing.Size(204, 32);
			this.lblTournamentName.TabIndex = 33;
			this.lblTournamentName.Text = "Tournament Name";
			this.lblTournamentName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnExit
			// 
			this.btnExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(128)), ((System.Byte)(255)));
			this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnExit.Location = new System.Drawing.Point(840, 624);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(140, 56);
			this.btnExit.TabIndex = 47;
			this.btnExit.Text = "E&xit";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// pnlDetails
			// 
			this.pnlDetails.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.pnlDetails.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.btnDelete,
																					 this.btnEdit,
																					 this.btnAdd,
																					 this.btnSave,
																					 this.btnCancel,
																					 this.dgDetails,
																					 this.txtPlayersPerHandheld,
																					 this.label8,
																					 this.txtNumberOfHandhelds,
																					 this.label7,
																					 this.txtStartingHole,
																					 this.label6,
																					 this.txtNumberOfTeeTimes,
																					 this.label5,
																					 this.txtTeeTimeSeparation,
																					 this.label4,
																					 this.txtFirstTeeTime,
																					 this.label3,
																					 this.txtRoundNumber,
																					 this.label2,
																					 this.label1,
																					 this.btnPrevDate,
																					 this.btnNextDate,
																					 this.txtRoundDate,
																					 this.lblRoundDate});
			this.pnlDetails.Location = new System.Drawing.Point(0, 220);
			this.pnlDetails.Name = "pnlDetails";
			this.pnlDetails.Size = new System.Drawing.Size(996, 396);
			this.pnlDetails.TabIndex = 48;
			// 
			// btnDelete
			// 
			this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
			this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnDelete.Location = new System.Drawing.Point(712, 336);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(140, 44);
			this.btnDelete.TabIndex = 12;
			this.btnDelete.Text = "Delete";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.BackColor = System.Drawing.SystemColors.Control;
			this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnEdit.Location = new System.Drawing.Point(416, 336);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(140, 44);
			this.btnEdit.TabIndex = 10;
			this.btnEdit.Text = "&Modify";
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.BackColor = System.Drawing.SystemColors.Control;
			this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnAdd.Location = new System.Drawing.Point(116, 336);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(140, 44);
			this.btnAdd.TabIndex = 8;
			this.btnAdd.Text = "&Add";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnSave
			// 
			this.btnSave.BackColor = System.Drawing.SystemColors.Control;
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnSave.Location = new System.Drawing.Point(564, 336);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(140, 44);
			this.btnSave.TabIndex = 11;
			this.btnSave.Text = "&Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCancel.Location = new System.Drawing.Point(264, 336);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(140, 44);
			this.btnCancel.TabIndex = 9;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// dgDetails
			// 
			this.dgDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.dgDetails.CaptionText = "Tournament Rounds";
			this.dgDetails.DataMember = "";
			this.dgDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dgDetails.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgDetails.Location = new System.Drawing.Point(652, 8);
			this.dgDetails.Name = "dgDetails";
			this.dgDetails.Size = new System.Drawing.Size(332, 208);
			this.dgDetails.TabIndex = 62;
			this.dgDetails.CurrentCellChanged += new System.EventHandler(this.dgDetails_CurrentCellChanged);
			// 
			// txtPlayersPerHandheld
			// 
			this.txtPlayersPerHandheld.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtPlayersPerHandheld.Location = new System.Drawing.Point(564, 284);
			this.txtPlayersPerHandheld.Name = "txtPlayersPerHandheld";
			this.txtPlayersPerHandheld.ReadOnly = true;
			this.txtPlayersPerHandheld.Size = new System.Drawing.Size(64, 31);
			this.txtPlayersPerHandheld.TabIndex = 7;
			this.txtPlayersPerHandheld.Text = "";
			// 
			// label8
			// 
			this.label8.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label8.Location = new System.Drawing.Point(324, 284);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(236, 32);
			this.label8.TabIndex = 61;
			this.label8.Text = "Players per Handheld";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtNumberOfHandhelds
			// 
			this.txtNumberOfHandhelds.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtNumberOfHandhelds.Location = new System.Drawing.Point(256, 284);
			this.txtNumberOfHandhelds.Name = "txtNumberOfHandhelds";
			this.txtNumberOfHandhelds.ReadOnly = true;
			this.txtNumberOfHandhelds.Size = new System.Drawing.Size(64, 31);
			this.txtNumberOfHandhelds.TabIndex = 6;
			this.txtNumberOfHandhelds.Text = "";
			// 
			// label7
			// 
			this.label7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label7.Location = new System.Drawing.Point(16, 284);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(236, 32);
			this.label7.TabIndex = 59;
			this.label7.Text = "Number of Handhelds";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtStartingHole
			// 
			this.txtStartingHole.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtStartingHole.Location = new System.Drawing.Point(216, 156);
			this.txtStartingHole.Name = "txtStartingHole";
			this.txtStartingHole.ReadOnly = true;
			this.txtStartingHole.Size = new System.Drawing.Size(64, 31);
			this.txtStartingHole.TabIndex = 2;
			this.txtStartingHole.Text = "";
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(16, 156);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(196, 32);
			this.label6.TabIndex = 57;
			this.label6.Text = "Starting Hole";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtNumberOfTeeTimes
			// 
			this.txtNumberOfTeeTimes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtNumberOfTeeTimes.Location = new System.Drawing.Point(564, 236);
			this.txtNumberOfTeeTimes.Name = "txtNumberOfTeeTimes";
			this.txtNumberOfTeeTimes.ReadOnly = true;
			this.txtNumberOfTeeTimes.Size = new System.Drawing.Size(64, 31);
			this.txtNumberOfTeeTimes.TabIndex = 4;
			this.txtNumberOfTeeTimes.Text = "";
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(324, 236);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(236, 32);
			this.label5.TabIndex = 55;
			this.label5.Text = "Number of Tee Times";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtTeeTimeSeparation
			// 
			this.txtTeeTimeSeparation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtTeeTimeSeparation.Location = new System.Drawing.Point(892, 236);
			this.txtTeeTimeSeparation.Name = "txtTeeTimeSeparation";
			this.txtTeeTimeSeparation.ReadOnly = true;
			this.txtTeeTimeSeparation.Size = new System.Drawing.Size(80, 31);
			this.txtTeeTimeSeparation.TabIndex = 5;
			this.txtTeeTimeSeparation.Text = "";
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(652, 236);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(238, 32);
			this.label4.TabIndex = 53;
			this.label4.Text = "Next Tee Time(6-15)";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtFirstTeeTime
			// 
			this.txtFirstTeeTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtFirstTeeTime.Location = new System.Drawing.Point(216, 236);
			this.txtFirstTeeTime.Name = "txtFirstTeeTime";
			this.txtFirstTeeTime.ReadOnly = true;
			this.txtFirstTeeTime.Size = new System.Drawing.Size(84, 31);
			this.txtFirstTeeTime.TabIndex = 3;
			this.txtFirstTeeTime.Text = "";
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(16, 236);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(196, 32);
			this.label3.TabIndex = 51;
			this.label3.Text = "First Tee Time";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtRoundNumber
			// 
			this.txtRoundNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtRoundNumber.Location = new System.Drawing.Point(216, 108);
			this.txtRoundNumber.Name = "txtRoundNumber";
			this.txtRoundNumber.ReadOnly = true;
			this.txtRoundNumber.Size = new System.Drawing.Size(64, 31);
			this.txtRoundNumber.TabIndex = 1;
			this.txtRoundNumber.Text = "";
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(16, 108);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(196, 32);
			this.label2.TabIndex = 49;
			this.label2.Text = "Round Number";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(196, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(312, 32);
			this.label1.TabIndex = 48;
			this.label1.Text = "Tournament Round Details";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnPrevDate
			// 
			this.btnPrevDate.BackColor = System.Drawing.SystemColors.Control;
			this.btnPrevDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnPrevDate.Location = new System.Drawing.Point(500, 60);
			this.btnPrevDate.Name = "btnPrevDate";
			this.btnPrevDate.Size = new System.Drawing.Size(108, 32);
			this.btnPrevDate.TabIndex = 14;
			this.btnPrevDate.Text = "&Prev. Date";
			this.btnPrevDate.Click += new System.EventHandler(this.btnPrevDate_Click);
			// 
			// btnNextDate
			// 
			this.btnNextDate.BackColor = System.Drawing.SystemColors.Control;
			this.btnNextDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnNextDate.Location = new System.Drawing.Point(384, 60);
			this.btnNextDate.Name = "btnNextDate";
			this.btnNextDate.Size = new System.Drawing.Size(108, 32);
			this.btnNextDate.TabIndex = 13;
			this.btnNextDate.Text = "&Next Date";
			this.btnNextDate.Click += new System.EventHandler(this.btnNextDate_Click);
			// 
			// txtRoundDate
			// 
			this.txtRoundDate.Enabled = false;
			this.txtRoundDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtRoundDate.Location = new System.Drawing.Point(216, 60);
			this.txtRoundDate.Name = "txtRoundDate";
			this.txtRoundDate.ReadOnly = true;
			this.txtRoundDate.Size = new System.Drawing.Size(156, 31);
			this.txtRoundDate.TabIndex = 0;
			this.txtRoundDate.Text = "";
			// 
			// lblRoundDate
			// 
			this.lblRoundDate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.lblRoundDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblRoundDate.Location = new System.Drawing.Point(16, 60);
			this.lblRoundDate.Name = "lblRoundDate";
			this.lblRoundDate.Size = new System.Drawing.Size(196, 32);
			this.lblRoundDate.TabIndex = 44;
			this.lblRoundDate.Text = "Round Date";
			this.lblRoundDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnGenerate
			// 
			this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(128)));
			this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnGenerate.Location = new System.Drawing.Point(680, 624);
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.Size = new System.Drawing.Size(148, 56);
			this.btnGenerate.TabIndex = 46;
			this.btnGenerate.Text = "&Generate Round Times";
			this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
			// 
			// TournamentDetails
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(994, 688);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.pnlDetails,
																		  this.btnGenerate,
																		  this.btnExit,
																		  this.panel1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "TournamentDetails";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TournamentDetails";
			this.Load += new System.EventHandler(this.TournamentDetails_Load);
			this.panel1.ResumeLayout(false);
			this.pnlDetails.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgDetails)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void TournamentDetails_Load(object sender, System.EventArgs e)
		{
			UpdateTButtonsToAED();
			SetTFields(READONLY);
			// Get Selected Tournament Definitions
			tlAdapter = espDB.GetSelectedTournament(this.TournamentID);
			ds = espDB.GetDS();

			DisplayTournamentData();

			espDB.GetTournamentDetails(TournamentID);

			dvDetails = new DataView( ds.Tables["TournamentDetails"] );
			dvDetails.AllowNew = false;
			dgDetails.AllowSorting = false;
			dgDetails.DataSource = dvDetails;
			ConfigureDetailsGrid();

			// If there is a tournament selected, display Details
			DisplayDetails();

			// Move Data to edit fields
			DisplayDetailData();
		}

		// GGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG
		private void ConfigureDetailsGrid()
		{
			DataGridTableStyle ts = new DataGridTableStyle();
			ts.MappingName = "TournamentDetails";
			// Set other properties.
			ts.RowHeaderWidth = 25;

			// Add first column style.
			DataGridTextBoxColumn TextCol1 = new DataGridTextBoxColumn();
			TextCol1.MappingName = "RoundDate";
			TextCol1.HeaderText = "Round Date";
			TextCol1.Width = 115;
			TextCol1.ReadOnly = true;
			ts.GridColumnStyles.Add(TextCol1);

			// Add second column style.
			DataGridTextBoxColumn TextCol2 = new DataGridTextBoxColumn();
			TextCol2.MappingName = "RoundNumber";
			TextCol2.HeaderText = "Round";
			TextCol2.Width = 60;
			TextCol2.ReadOnly = true;
			TextCol2.Alignment = HorizontalAlignment.Center;
			ts.GridColumnStyles.Add(TextCol2);

			// Add third column style.
			DataGridTextBoxColumn TextCol3 = new DataGridTextBoxColumn();
			TextCol3.MappingName = "StartingHole";
			TextCol3.HeaderText = "Start at Hole";
			TextCol3.Width = 110;
			TextCol3.ReadOnly = true;
			TextCol3.Alignment = HorizontalAlignment.Center;
			ts.GridColumnStyles.Add(TextCol3);

			dgDetails.TableStyles.Add(ts);
		}
		// DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD
		private void DisplayDetails()
		{
			if (TournamentID > 0)
			{
				// Enable and Display Details
				UpdateButtonsToAED();
				SetFields(READONLY);
			}
			else
			{
				// no Tournament
				btnAdd.Visible = false;
				btnEdit.Visible = false;
				btnDelete.Visible = false;
				btnCancel.Visible = false;
				btnSave.Visible = false;
				pnlDetails.Visible = false;
			}
		}

		private void UpdateButtonsToSC()
		{
			btnAdd.Visible = false;
			btnEdit.Visible = false;
			btnDelete.Visible = false;
			btnCancel.Visible = true;
			btnSave.Visible = true;
			btnExit.Visible = false;
			btnGenerate.Visible = false;
			btnAddTournament.Visible = false;
			btnEditTournament.Visible = false;
			btnDeleteTournament.Visible = false;
		}

		private void UpdateButtonsToAED()
		{
			btnAdd.Visible = true;
			btnEdit.Visible = true;
			btnDelete.Visible = true;
			btnCancel.Visible = false;
			btnSave.Visible = false;
			btnExit.Visible = true;
			btnGenerate.Visible = true;
			btnAddTournament.Visible = true;
			if (TournamentID > 0)btnEditTournament.Visible = true;
			else btnEditTournament.Visible = false;
			if (TournamentID > 0)btnDeleteTournament.Visible = true;
			else btnDeleteTournament.Visible = false;
		}

		private void SetFields(bool flag)
		{
			this.btnNextDate.Enabled = flag;
			this.btnPrevDate.Enabled = flag;
			this.txtRoundNumber.ReadOnly = !flag;
			this.txtRoundNumber.TabStop = flag;
			this.txtStartingHole.ReadOnly = !flag;
			this.txtStartingHole.TabStop = flag;
			this.txtFirstTeeTime.ReadOnly = !flag;
			this.txtFirstTeeTime.TabStop = flag;
			this.txtTeeTimeSeparation.ReadOnly = !flag;
			this.txtTeeTimeSeparation.TabStop = flag;
			this.txtNumberOfTeeTimes.ReadOnly = !flag;
			this.txtNumberOfTeeTimes.TabStop = flag;
			this.txtNumberOfHandhelds.ReadOnly = !flag;
			this.txtNumberOfHandhelds.TabStop = flag;
			this.txtPlayersPerHandheld.ReadOnly = !flag;
			this.txtPlayersPerHandheld.TabStop = flag;
		}

		// ============================
		// EDIT Control Functions
		// ============================
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			CurrencyManager myCM;
		
			myCM = (CurrencyManager)this.BindingContext[dvDetails];
			if (myCM.List.Count >= Int16.Parse(this.txtNumberOfRounds.Text))
			{
				TouchMessageBox tmb = new TouchMessageBox();
				tmb.Header = "ADD a New Round";
				tmb.Message = "All Rounds for this tournament have already been added.";
				tmb.Buttons = 1;
				tmb.Confirm = "&OK";
				tmb.ShowDialog();
				tmb.Dispose();
				return;
			}
			//DataTable dt = ds.Tables["TournamentDetails"];
			// Update Button Status
			UpdateButtonsToSC();

			// Update Fields to allow a record to be added and clear all existing values
			SetFields(EDIT);
			txtRoundDate.Text = txtStartDate.Text;
			txtRoundNumber.Text = "1";
			txtStartingHole.Text = "1";
			this.txtFirstTeeTime.Text = "0800";
			this.txtTeeTimeSeparation.Text = "10";
			this.txtNumberOfTeeTimes.Text = "1";
			this.txtNumberOfHandhelds.Text = "1";
			this.txtPlayersPerHandheld.Text = "4";
			//
			AddMode = true;
			this.Refresh();
			txtRoundNumber.Focus();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			// Reset Changes to Original Values, if any were made
			CancelChanges();

			// Update Button Status
			UpdateButtonsToAED();

			// Update Fields to Read Only
			SetFields(READONLY);
		}

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			// Update Button Status
			UpdateButtonsToSC();

			// Update Fields to allow Edit
			SetFields(EDIT);
			AddMode = false;
			txtRoundNumber.Focus();
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			// Make sure that the Date+RoundNumber+StartHole is unique

			// Save Changes, if any were made
			if (SaveChanges())
			{
				// Update Button Status
				UpdateButtonsToAED();

				// Update Fields to Read Only
				SetFields(READONLY);

				AddMode = false;
			}
		}
		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			// Verify that the current player is to be deleted
			TouchMessageBox tmb = new TouchMessageBox();
			tmb.Header = "Delete the Selected Round";
			tmb.Message = "Select DELETE to confirm that you want to delete this Round.  Select CANCEL to cancel the delete of this Round.";
			tmb.Cancel = "&Cancel";
			tmb.Confirm = "&Delete";
			tmb.ShowDialog();
			if (tmb.Return)
			{
				// Delete the selected Person
				if (dvDetails.Count > 1)
				{
					CurrencyManager myCM = (CurrencyManager)this.BindingContext[dvDetails];
					DataRowView dr = (DataRowView)myCM.Current;
					dr.Delete();
					espDB.SaveTournamentDetailChanges();
					dr = null;
					dr = (DataRowView)myCM.Current;
					this.CurrentDetailID = (int)dr.Row["TournamentDetailID"];
					DisplayDetailData();
				}
			}
		}
		private void CancelChanges()
		{
			DisplayDetailData();
			AddMode = false;
		}
		private bool SaveChanges()
		{
			Guid myguid;
			CurrencyManager myCM;
		
			myCM = (CurrencyManager)this.BindingContext[dvDetails];

			if (AddMode)
			{
				dvDetails.AllowNew = true;
				DataRowView dr = dvDetails.AddNew();
				// Get THe GUID for the selected Tournament
				DataTable dt = ds.Tables["AEDTournament"];
				DataRow [] drr = dt.Select();
				myguid = (Guid)drr[0]["TournamentGUID"];
				drr = null;
				dt = null;
				// Add a Row to TournamentDetails
				dr.Row["TournamentGUID"] = myguid;
				dr.Row["RoundDate"] = DateTime.Parse(this.txtRoundDate.Text);
				dr.Row["RoundNumber"] = Byte.Parse(this.txtRoundNumber.Text);
				dr.Row["StartingHole"] = Byte.Parse(this.txtStartingHole.Text);
				dr.Row["FirstTeeTime"] = this.txtFirstTeeTime.Text;
				dr.Row["TeeTimeSeparation"] = Byte.Parse(this.txtTeeTimeSeparation.Text);
				dr.Row["NumberOfTeeTimes"] = Byte.Parse(this.txtNumberOfTeeTimes.Text);
				dr.Row["NumberOfHandhelds"] = Byte.Parse(this.txtNumberOfHandhelds.Text);
				dr.Row["PlayersPerHandheld"] = Byte.Parse(this.txtPlayersPerHandheld.Text);
				dr.EndEdit();
				//
				//
				// New TournamentDetails added
				//
				dvDetails.AllowNew = false;
			}
			else
			{
				DataRowView dr = (DataRowView)myCM.Current;
				// Update Tournament MASTER record
				dr.BeginEdit();
				dr.Row["RoundDate"] = DateTime.Parse(this.txtRoundDate.Text);
				dr.Row["RoundNumber"] = Byte.Parse(this.txtRoundNumber.Text);
				dr.Row["StartingHole"] = Byte.Parse(this.txtStartingHole.Text);
				dr.Row["FirstTeeTime"] = this.txtFirstTeeTime.Text;
				dr.Row["TeeTimeSeparation"] = Byte.Parse(this.txtTeeTimeSeparation.Text);
				dr.Row["NumberOfTeeTimes"] = Byte.Parse(this.txtNumberOfTeeTimes.Text);
				dr.Row["NumberOfHandhelds"] = Byte.Parse(this.txtNumberOfHandhelds.Text);
				dr.Row["PlayersPerHandheld"] = Byte.Parse(this.txtPlayersPerHandheld.Text);
				dr.EndEdit();
			}

			// Save Changes to the Database
			espDB.SaveTournamentDetailChanges();

			// Refresh TournamentDetails
			DisplayDetails();

			if (this.AddMode)
			{
				espDB.GetTournamentDetails(TournamentID);
				dgDetails.Refresh();
				dgDetails.Select(0);
				dgDetails.CurrentRowIndex = 0;

				DisplayDetailData();
			}

			return true;
		}
		private void DisplayDetailData()
		{
			DateTime date;
			// Get Tournament Detail Data
			CurrencyManager myCM;
		
			myCM = (CurrencyManager)this.BindingContext[dvDetails];
			if (myCM.List.Count > 0)
			{
				DataRowView dr = (DataRowView)myCM.Current;
				date = (DateTime)dr.Row["RoundDate"];
				this.txtRoundDate.Text = date.ToShortDateString();
				this.txtRoundNumber.Text = dr.Row["RoundNumber"].ToString();
				this.txtStartingHole.Text = dr.Row["StartingHole"].ToString();
				this.txtFirstTeeTime.Text = dr.Row["FirstTeeTime"].ToString();
				this.txtTeeTimeSeparation.Text = dr.Row["TeeTimeSeparation"].ToString();
				this.txtNumberOfTeeTimes.Text = dr.Row["NumberOfTeeTimes"].ToString();
				this.txtNumberOfHandhelds.Text = dr.Row["NumberOfHandhelds"].ToString();
				this.txtPlayersPerHandheld.Text = dr.Row["PlayersPerHandheld"].ToString();
				dr = null;
			}
			else
			{
				// There are no tournament details defined yet
				txtRoundDate.Text = txtStartDate.Text;
				txtRoundNumber.Text = "";
				txtStartingHole.Text = "";
				this.txtFirstTeeTime.Text = "";
				this.txtTeeTimeSeparation.Text = "";
				this.txtNumberOfTeeTimes.Text = "";
				this.txtNumberOfHandhelds.Text = "";
				this.txtPlayersPerHandheld.Text = "";
				btnEdit.Visible = false;
			}
		}

		private void btnNextDate_Click(object sender, System.EventArgs e)
		{
			DateTime current, end;

			current = DateTime.Parse(this.txtRoundDate.Text);
			end = DateTime.Parse(this.txtEndDate.Text);
		
			if (current < end)
			{
				current = current.AddDays(1.0);
				this.txtRoundDate.Text = current.ToShortDateString();
			}
		}

		private void btnPrevDate_Click(object sender, System.EventArgs e)
		{
			DateTime current, start;

			current = DateTime.Parse(this.txtRoundDate.Text);
			start = DateTime.Parse(this.txtStartDate.Text);
		
			if (current > start)
			{
				current = current.AddDays(-1.0);
				this.txtRoundDate.Text = current.ToShortDateString();
			}
		}
		// DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD

		private void btnDate_Click(object sender, System.EventArgs e)
		{
			TourLiteDates getDates = new TourLiteDates();
			getDates.ShowDialog();
			if (getDates.StartDate != "") txtStartDate.Text = getDates.StartDate;
			if (getDates.EndDate != "") txtEndDate.Text = getDates.EndDate;
			getDates = null;
		}

		// TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT
		private void UpdateTButtonsToSC()
		{
			btnAddTournament.Visible = false;
			btnEditTournament.Visible = false;
			btnDeleteTournament.Visible = false;
			btnCancelTournament.Visible = true;
			btnSaveTournament.Visible = true;
			btnDivisions.Visible = false;
			btnExit.Visible = false;
			btnGenerate.Visible = false;
			btnAdd.Visible = false;
			btnEdit.Visible = false;
			btnDelete.Visible = false;
		}

		private void UpdateTButtonsToAED()
		{
			btnAddTournament.Visible = true;
			if (TournamentID > 0)btnEditTournament.Visible = true;
			else btnEditTournament.Visible = false;
			if (TournamentID > 0)btnDeleteTournament.Visible = true;
			else btnDeleteTournament.Visible = false;
			btnCancelTournament.Visible = false;
			btnSaveTournament.Visible = false;
			btnDivisions.Visible = true;
			btnExit.Visible = true;
			btnGenerate.Visible = true;
			btnAdd.Visible = true;
			btnEdit.Visible = true;
			btnDelete.Visible = true;
		}

		private void DisplayTournamentData()
		{
			DateTime date;
			// Get Tournament Data
			DataTable dt;
			DataRow[] dr;

			dt = ds.Tables["AEDTournament"];
			dr = dt.Select();
			if (dr.Length > 0)
			{
				txtTournamentName.Text = dr[0]["Name"].ToString();
				date = (DateTime)dr[0]["DateStart"];
				txtStartDate.Text = date.ToShortDateString();
				date = (DateTime)dr[0]["DateEnd"];
				txtEndDate.Text = date.ToShortDateString();
				txtNumberOfRounds.Text = dr[0]["NumberOfRounds"].ToString();
				txtNumberOfDivisions.Text = dr[0]["NumberOfDivisions"].ToString();
			}
			else
			{
				// There are no tournaments defined
				txtTournamentName.Text = "There are no Tournaments defined.";
				txtStartDate.Text = "";
				txtEndDate.Text = "";
				txtNumberOfRounds.Text = "";
				txtNumberOfDivisions.Text = "";
			}
			dr = null;
			dt = null;
		}

		private void SetTFields(bool flag)
		{
			txtTournamentName.ReadOnly = !flag;
			txtTournamentName.TabStop = flag;
			btnDate.Enabled = flag;
			txtNumberOfRounds.ReadOnly = !flag;
			txtNumberOfRounds.TabStop = flag;
			txtNumberOfDivisions.ReadOnly = !flag;
			txtNumberOfDivisions.TabStop = flag;
			//
		}

		// ============================
		// EDIT Control Functions
		// ============================
		private void btnAddTournament_Click(object sender, System.EventArgs e)
		{
			// Update Button Status
			UpdateTButtonsToSC();

			// Update Fields to allow a record to be added and clear all existing values
			SetTFields(EDIT);
			txtTournamentName.Text = "";
			txtStartDate.Text = DateTime.Today.ToShortDateString();
			txtEndDate.Text = txtStartDate.Text;
			this.txtNumberOfRounds.Text = "1";
			this.txtNumberOfDivisions.Text = "1";
			//
			AddMode = true;
			this.Refresh();
			txtTournamentName.Focus();
		}

		private void btnCancelTournament_Click(object sender, System.EventArgs e)
		{
			// Reset Changes to Original Values, if any were made
			CancelTChanges();

			// Update Button Status
			UpdateTButtonsToAED();

			// Update Fields to Read Only
			SetTFields(READONLY);
		}

		private void btnEditTournament_Click(object sender, System.EventArgs e)
		{
			// Update Button Status
			UpdateTButtonsToSC();

			// Update Fields to allow Edit
			SetTFields(EDIT);
			AddMode = false;
			txtTournamentName.Focus();
		}

		private void btnSaveTournament_Click(object sender, System.EventArgs e)
		{
			// Save Changes, if any were made
			if (SaveTChanges())
			{
				// Update Button Status
				UpdateTButtonsToAED();

				// Update Fields to Read Only
				SetTFields(READONLY);
				// If a new tournament was added or selected Display details
				if (AddMode) 
				{
					DisplayDetails();
					// Move Data to edit fields
					DisplayDetailData();
				}
				AddMode = false;
			}
		}

		private void btnDeleteTournament_Click(object sender, System.EventArgs e)
		{
			TouchMessageBox confirm = new TouchMessageBox();
			confirm.Header = "Delete Confirmation";
			confirm.Message = "Do you really want to DELETE Tournament {"+txtTournamentName.Text.ToString()+"}?";
			confirm.Confirm = "&Yes";
			confirm.Cancel = "&No";
			confirm.ShowDialog();
			if (confirm.Return)
			{
				DataTable dt;
				DataRow [] dr;
		
				dt = ds.Tables["AEDTournament"];
				dr = dt.Select();
				dr[0].Delete();
				try
				{
					tlAdapter.Update(ds,"AEDTournament");
				}
				catch (OleDbException ee)
				{
					MessageBox.Show(ee.Message,"Update");
				}
				//
				// Refresh Tournament List
				espDB.UpdateTournamentsTable();
				dt = ds.Tables["Tournaments"];
				dr = dt.Select();
				if (dr.Length > 0)
					this.TournamentID = (int)dr[0]["TournamentID"];
				else
					this.TournamentID = 0;
				//
				// Get Selected Tournament Definitions
				tlAdapter = espDB.GetSelectedTournament(this.TournamentID);
				//
				DisplayTournamentData();
				// Display tournament details
				espDB.GetTournamentDetails(TournamentID);
				DisplayDetails();
				// Move Data to edit fields
				DisplayDetailData();
				/*
			// Get Selected Tournament Definitions
			//tlAdapter = espDB.GetSelectedTournament(this.TournamentID);
			//ds = espDB.GetDS();

			//DisplayTournamentData();

			//espDB.GetTournamentDetails(TournamentID);

			dvDetails = new DataView( ds.Tables["TournamentDetails"] );
			dvDetails.AllowNew = false;
			dgDetails.AllowSorting = false;
			dgDetails.DataSource = dvDetails;
			ConfigureDetailsGrid();

			// If there is a tournament selected, display Details
			DisplayDetails();

			// Move Data to edit fields
			DisplayDetailData();
				*/
			}
			confirm.Dispose();
		}
		private void CancelTChanges()
		{
			DisplayTournamentData();
			AddMode = false;
		}

		private bool SaveTChanges()
		{
			Guid myguid = Guid.NewGuid();
			DataTable dt;
			DataRow [] dr;
			DataRow addrow;

			if (AddMode)
			{
				// Add a Row to Tournaments
				dt = ds.Tables["AEDTournament"];
				addrow = dt.NewRow();
				addrow["Name"] = txtTournamentName.Text;
				addrow["DateStart"] = DateTime.Parse(txtStartDate.Text);
				addrow["DateEnd"] = DateTime.Parse(txtEndDate.Text);
				addrow["NumberOfRounds"] = Byte.Parse(txtNumberOfRounds.Text);
				addrow["NumberOfDivisions"] = Byte.Parse(txtNumberOfDivisions.Text);
				addrow["TournamentGuid"] = myguid;
				dt.Rows.Add(addrow);
				try
				{
					tlAdapter.Update(ds,"AEDTournament");
				}
				catch (OleDbException e)
				{
					MessageBox.Show(e.Message,"Update");
				}

				// Refresh Tournament List
				espDB.UpdateTournamentsTable();
				//
				// Locate new Tournament and set ID
				dt = ds.Tables["Tournaments"];
				string sel = "TournamentGuid='"+myguid.ToString("D")+"'";
				dr = dt.Select(sel);
				//
				this.TournamentID = (int)dr[0]["TournamentID"];
				// Update HHID
				espDB.UpdateTourLiteHHID(this.TournamentID);
				//
				// New Tournament added
				//
			}
			else
			{
				// Update Tournament MASTER record
				dt = ds.Tables["AEDTournament"];
				dr = dt.Select();
				dr[0].BeginEdit();
				dr[0]["Name"] = txtTournamentName.Text;
				dr[0]["DateStart"] = DateTime.Parse(txtStartDate.Text);
				dr[0]["DateEnd"] = DateTime.Parse(txtEndDate.Text);
				dr[0]["HHID"] = "TL"+TournamentID.ToString();
				dr[0]["NumberOfRounds"] = Byte.Parse(txtNumberOfRounds.Text);
				dr[0]["NumberOfDivisions"] = Byte.Parse(txtNumberOfDivisions.Text);
				dr[0].EndEdit();
				try
				{
					tlAdapter.Update(ds,"AEDTournament");
				}
				catch (OleDbException e)
				{
					MessageBox.Show(e.Message,"Update");
				}

				// Refresh Tournament List
				espDB.UpdateTournamentsTable();
			}
			//
			// Refresh Tournament(s) and Tournament Games
			// Get Selected Tournament Definitions
			tlAdapter = espDB.GetSelectedTournament(this.TournamentID);
			//
			DisplayTournamentData();
			// Display tournament details
			espDB.GetTournamentDetails(TournamentID);
			DisplayDetails();
			// Move Data to edit fields
			DisplayDetailData();

			return true;
		}
		// TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT

		// GGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG
		private void btnGenerate_Click(object sender, System.EventArgs e)
		{
			// Create the Round Time Records and the associated Player Position Records
		}

		private void dgDetails_CurrentCellChanged(object sender, System.EventArgs e)
		{
			CurrencyManager myCM;
		
			myCM = (CurrencyManager)this.BindingContext[dvDetails];
			if (myCM.List.Count > 0)
			{
				DataRowView drv = (DataRowView)myCM.Current;
				if (this.CurrentDetailID != (int)drv.Row["TournamentDetailID"])
				{
					// Display Current Record Data
					this.CurrentDetailID = (int)drv.Row["TournamentDetailID"];
					DisplayDetailData();
				}
			}
		}
		// GGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG
		// ============================
		// Property Definitions
		// ============================
		public int TournamentID
		{
			get{ return _TournamentID; }
			set{ _TournamentID = value; }
		}

		// ============================
		// ============================
	}
}
