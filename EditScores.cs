using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ESPmanager
{
	/// <summary>
	/// Summary description for EditScores.
	/// </summary>
	public class EditScores : System.Windows.Forms.Form
	{
		// Define Local Variables and Properties
		private DatabaseAccessControl dac = new DatabaseAccessControl();
		private Database espDB;
		private DataSet ds;
		private TextBox KeypadField = null;
		private Color KeypadFieldColor;
		private bool [] XScore = new bool[Global.MAX_HOLES];
		private short [] Gross = new short[Global.MAX_HOLES];
		private short [] Strokes = new short[Global.MAX_HOLES];
		private short [] Net = new short[Global.MAX_HOLES];
		byte index = 0;
		//
		private int _PlayerID = 0;
		private bool _Updated = false;
		// ==================================================
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Label lblUserInitials;
		private System.Windows.Forms.Label lblHandicap;
		private System.Windows.Forms.Label lblComputedHandicap;
		private System.Windows.Forms.TextBox txtInitials;
		private System.Windows.Forms.TextBox txtHandicap;
		private System.Windows.Forms.TextBox txtComputedHandicap;
		private System.Windows.Forms.GroupBox gbHandicap;
		private System.Windows.Forms.RadioButton rbHome;
		private System.Windows.Forms.RadioButton rbIndex;
		private System.Windows.Forms.RadioButton rbAverageScore;
		private System.Windows.Forms.Button btnChange;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.Button btnBack;
		private System.Windows.Forms.Button btn0;
		private System.Windows.Forms.Button btn9;
		private System.Windows.Forms.Button btn8;
		private System.Windows.Forms.Button btn7;
		private System.Windows.Forms.Button btn6;
		private System.Windows.Forms.Button btn5;
		private System.Windows.Forms.Button btn4;
		private System.Windows.Forms.Button btn3;
		private System.Windows.Forms.Button btn2;
		private System.Windows.Forms.Button btn1;
		private System.Windows.Forms.Panel pnlNumbers;
		private System.Windows.Forms.Button btnDone;
		private System.Windows.Forms.Panel pnlKeyboard;
		private System.Windows.Forms.Button btnQ;
		private System.Windows.Forms.Button btnW;
		private System.Windows.Forms.Button btnE;
		private System.Windows.Forms.Button btnR;
		private System.Windows.Forms.Button btnT;
		private System.Windows.Forms.Button btnY;
		private System.Windows.Forms.Button btnU;
		private System.Windows.Forms.Button btnI;
		private System.Windows.Forms.Button btnO;
		private System.Windows.Forms.Button btnP;
		private System.Windows.Forms.Button btnL;
		private System.Windows.Forms.Button btnK;
		private System.Windows.Forms.Button btnJ;
		private System.Windows.Forms.Button btnH;
		private System.Windows.Forms.Button btnG;
		private System.Windows.Forms.Button btnF;
		private System.Windows.Forms.Button btnD;
		private System.Windows.Forms.Button btnS;
		private System.Windows.Forms.Button btnA;
		private System.Windows.Forms.Button btnM;
		private System.Windows.Forms.Button btnN;
		private System.Windows.Forms.Button btnB;
		private System.Windows.Forms.Button btnV;
		private System.Windows.Forms.Button btnC;
		private System.Windows.Forms.Button btnX;
		private System.Windows.Forms.Button btnZ;
		private System.Windows.Forms.Button btnKeyDone;
		private System.Windows.Forms.Button btnKeyClear;
		private System.Windows.Forms.Button btnKeyBack;
		private System.Windows.Forms.Button btnPeriod;
		private System.Windows.Forms.CheckBox cbPlusHandicap;
		private System.Windows.Forms.Button btnK0;
		private System.Windows.Forms.Button btnK9;
		private System.Windows.Forms.Button btnK8;
		private System.Windows.Forms.Button btnK7;
		private System.Windows.Forms.Button btnK6;
		private System.Windows.Forms.Button btnK5;
		private System.Windows.Forms.Button btnK4;
		private System.Windows.Forms.Button btnK3;
		private System.Windows.Forms.Button btnK2;
		private System.Windows.Forms.Button btnK1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label lblHole;
		private System.Windows.Forms.Label lblPar;
		private System.Windows.Forms.Label lblHdcp;
		private System.Windows.Forms.Label lblGross;
		private System.Windows.Forms.Label lblNet;
		private System.Windows.Forms.TextBox txtHole1;
		private System.Windows.Forms.Label lblTee;
		private System.Windows.Forms.TextBox txtHole2;
		private System.Windows.Forms.TextBox txtHole3;
		private System.Windows.Forms.TextBox txtHole4;
		private System.Windows.Forms.TextBox txtHole5;
		private System.Windows.Forms.TextBox txtHole6;
		private System.Windows.Forms.TextBox txtHole7;
		private System.Windows.Forms.TextBox txtHole8;
		private System.Windows.Forms.TextBox txtHole9;
		private System.Windows.Forms.TextBox txtHole18;
		private System.Windows.Forms.TextBox txtHole17;
		private System.Windows.Forms.TextBox txtHole16;
		private System.Windows.Forms.TextBox txtHole15;
		private System.Windows.Forms.TextBox txtHole14;
		private System.Windows.Forms.TextBox txtHole13;
		private System.Windows.Forms.TextBox txtHole12;
		private System.Windows.Forms.TextBox txtHole11;
		private System.Windows.Forms.TextBox txtHole10;
		private System.Windows.Forms.Label lblTee1;
		private System.Windows.Forms.Label lblTee2;
		private System.Windows.Forms.Label lblTee4;
		private System.Windows.Forms.Label lblTee3;
		private System.Windows.Forms.Label lblTee8;
		private System.Windows.Forms.Label lblTee7;
		private System.Windows.Forms.Label lblTee6;
		private System.Windows.Forms.Label lblTee5;
		private System.Windows.Forms.Label lblTee9;
		private System.Windows.Forms.Label lblTee18;
		private System.Windows.Forms.Label lblTee17;
		private System.Windows.Forms.Label lblTee16;
		private System.Windows.Forms.Label lblTee15;
		private System.Windows.Forms.Label lblTee14;
		private System.Windows.Forms.Label lblTee13;
		private System.Windows.Forms.Label lblTee12;
		private System.Windows.Forms.Label lblTee11;
		private System.Windows.Forms.Label lblTee10;
		private System.Windows.Forms.TextBox Gross1;
		private System.Windows.Forms.TextBox Net1;
		private System.Windows.Forms.TextBox Net2;
		private System.Windows.Forms.TextBox Gross2;
		private System.Windows.Forms.TextBox Net3;
		private System.Windows.Forms.TextBox Gross3;
		private System.Windows.Forms.TextBox Net4;
		private System.Windows.Forms.TextBox Gross4;
		private System.Windows.Forms.TextBox Net5;
		private System.Windows.Forms.TextBox Gross5;
		private System.Windows.Forms.TextBox Net6;
		private System.Windows.Forms.TextBox Gross6;
		private System.Windows.Forms.TextBox Net7;
		private System.Windows.Forms.TextBox Gross7;
		private System.Windows.Forms.TextBox Net8;
		private System.Windows.Forms.TextBox Gross8;
		private System.Windows.Forms.TextBox Net9;
		private System.Windows.Forms.TextBox Gross9;
		private System.Windows.Forms.TextBox Net18;
		private System.Windows.Forms.TextBox Gross18;
		private System.Windows.Forms.TextBox Net17;
		private System.Windows.Forms.TextBox Gross17;
		private System.Windows.Forms.TextBox Net16;
		private System.Windows.Forms.TextBox Gross16;
		private System.Windows.Forms.TextBox Net15;
		private System.Windows.Forms.TextBox Gross15;
		private System.Windows.Forms.TextBox Net14;
		private System.Windows.Forms.TextBox Gross14;
		private System.Windows.Forms.TextBox Net13;
		private System.Windows.Forms.TextBox Gross13;
		private System.Windows.Forms.TextBox Net12;
		private System.Windows.Forms.TextBox Gross12;
		private System.Windows.Forms.TextBox Net11;
		private System.Windows.Forms.TextBox Gross11;
		private System.Windows.Forms.TextBox Net10;
		private System.Windows.Forms.TextBox Gross10;
		private System.Windows.Forms.TextBox NetFront9;
		private System.Windows.Forms.TextBox GrossFront9;
		private System.Windows.Forms.TextBox NetBack9;
		private System.Windows.Forms.TextBox GrossBack9;
		private System.Windows.Forms.TextBox NetTotal;
		private System.Windows.Forms.TextBox GrossTotal;
		private System.Windows.Forms.TextBox Par1;
		private System.Windows.Forms.TextBox HDCP1;
		private System.Windows.Forms.TextBox HDCP2;
		private System.Windows.Forms.TextBox Par2;
		private System.Windows.Forms.TextBox HDCP3;
		private System.Windows.Forms.TextBox Par3;
		private System.Windows.Forms.TextBox HDCP4;
		private System.Windows.Forms.TextBox Par4;
		private System.Windows.Forms.TextBox HDCP5;
		private System.Windows.Forms.TextBox Par5;
		private System.Windows.Forms.TextBox HDCP6;
		private System.Windows.Forms.TextBox Par6;
		private System.Windows.Forms.TextBox HDCP7;
		private System.Windows.Forms.TextBox Par7;
		private System.Windows.Forms.TextBox HDCP8;
		private System.Windows.Forms.TextBox Par8;
		private System.Windows.Forms.TextBox HDCP9;
		private System.Windows.Forms.TextBox Par9;
		private System.Windows.Forms.TextBox HDCP18;
		private System.Windows.Forms.TextBox Par18;
		private System.Windows.Forms.TextBox HDCP17;
		private System.Windows.Forms.TextBox Par17;
		private System.Windows.Forms.TextBox HDCP16;
		private System.Windows.Forms.TextBox Par16;
		private System.Windows.Forms.TextBox HDCP15;
		private System.Windows.Forms.TextBox Par15;
		private System.Windows.Forms.TextBox HDCP14;
		private System.Windows.Forms.TextBox Par14;
		private System.Windows.Forms.TextBox HDCP13;
		private System.Windows.Forms.TextBox Par13;
		private System.Windows.Forms.TextBox HDCP12;
		private System.Windows.Forms.TextBox Par12;
		private System.Windows.Forms.TextBox HDCP11;
		private System.Windows.Forms.TextBox Par11;
		private System.Windows.Forms.TextBox HDCP10;
		private System.Windows.Forms.TextBox Par10;
		private System.Windows.Forms.Label lblFront9a;
		private System.Windows.Forms.Label lblBack9a;
		private System.Windows.Forms.Label lblTotala;
		private System.Windows.Forms.TextBox ParFront9;
		private System.Windows.Forms.TextBox ParBack9;
		private System.Windows.Forms.TextBox ParTotal;
		private System.Windows.Forms.Label lblFront9;
		private System.Windows.Forms.Label lblBack9;
		private System.Windows.Forms.Label lblTotal;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox XScore1;
		private System.Windows.Forms.CheckBox XScore2;
		private System.Windows.Forms.CheckBox XScore3;
		private System.Windows.Forms.CheckBox XScore4;
		private System.Windows.Forms.CheckBox XScore8;
		private System.Windows.Forms.CheckBox XScore7;
		private System.Windows.Forms.CheckBox XScore6;
		private System.Windows.Forms.CheckBox XScore5;
		private System.Windows.Forms.CheckBox XScore9;
		private System.Windows.Forms.CheckBox XScore18;
		private System.Windows.Forms.CheckBox XScore17;
		private System.Windows.Forms.CheckBox XScore16;
		private System.Windows.Forms.CheckBox XScore15;
		private System.Windows.Forms.CheckBox XScore14;
		private System.Windows.Forms.CheckBox XScore13;
		private System.Windows.Forms.CheckBox XScore12;
		private System.Windows.Forms.CheckBox XScore11;
		private System.Windows.Forms.CheckBox XScore10;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EditScores( ref Database espdb )
		{
			//
			// Required for Windows Form Designer support
			//
			ds = espdb.GetDS();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(EditScores));
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnChange = new System.Windows.Forms.Button();
			this.gbHandicap = new System.Windows.Forms.GroupBox();
			this.cbPlusHandicap = new System.Windows.Forms.CheckBox();
			this.rbAverageScore = new System.Windows.Forms.RadioButton();
			this.rbIndex = new System.Windows.Forms.RadioButton();
			this.rbHome = new System.Windows.Forms.RadioButton();
			this.txtComputedHandicap = new System.Windows.Forms.TextBox();
			this.txtHandicap = new System.Windows.Forms.TextBox();
			this.txtInitials = new System.Windows.Forms.TextBox();
			this.lblComputedHandicap = new System.Windows.Forms.Label();
			this.lblHandicap = new System.Windows.Forms.Label();
			this.lblUserInitials = new System.Windows.Forms.Label();
			this.btnExit = new System.Windows.Forms.Button();
			this.pnlNumbers = new System.Windows.Forms.Panel();
			this.btnPeriod = new System.Windows.Forms.Button();
			this.btnDone = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnBack = new System.Windows.Forms.Button();
			this.btn0 = new System.Windows.Forms.Button();
			this.btn9 = new System.Windows.Forms.Button();
			this.btn8 = new System.Windows.Forms.Button();
			this.btn7 = new System.Windows.Forms.Button();
			this.btn6 = new System.Windows.Forms.Button();
			this.btn5 = new System.Windows.Forms.Button();
			this.btn4 = new System.Windows.Forms.Button();
			this.btn3 = new System.Windows.Forms.Button();
			this.btn2 = new System.Windows.Forms.Button();
			this.btn1 = new System.Windows.Forms.Button();
			this.pnlKeyboard = new System.Windows.Forms.Panel();
			this.btnM = new System.Windows.Forms.Button();
			this.btnN = new System.Windows.Forms.Button();
			this.btnB = new System.Windows.Forms.Button();
			this.btnV = new System.Windows.Forms.Button();
			this.btnC = new System.Windows.Forms.Button();
			this.btnX = new System.Windows.Forms.Button();
			this.btnZ = new System.Windows.Forms.Button();
			this.btnL = new System.Windows.Forms.Button();
			this.btnK = new System.Windows.Forms.Button();
			this.btnJ = new System.Windows.Forms.Button();
			this.btnH = new System.Windows.Forms.Button();
			this.btnG = new System.Windows.Forms.Button();
			this.btnF = new System.Windows.Forms.Button();
			this.btnD = new System.Windows.Forms.Button();
			this.btnS = new System.Windows.Forms.Button();
			this.btnA = new System.Windows.Forms.Button();
			this.btnP = new System.Windows.Forms.Button();
			this.btnO = new System.Windows.Forms.Button();
			this.btnI = new System.Windows.Forms.Button();
			this.btnU = new System.Windows.Forms.Button();
			this.btnY = new System.Windows.Forms.Button();
			this.btnT = new System.Windows.Forms.Button();
			this.btnR = new System.Windows.Forms.Button();
			this.btnE = new System.Windows.Forms.Button();
			this.btnW = new System.Windows.Forms.Button();
			this.btnQ = new System.Windows.Forms.Button();
			this.btnKeyDone = new System.Windows.Forms.Button();
			this.btnKeyClear = new System.Windows.Forms.Button();
			this.btnKeyBack = new System.Windows.Forms.Button();
			this.btnK0 = new System.Windows.Forms.Button();
			this.btnK9 = new System.Windows.Forms.Button();
			this.btnK8 = new System.Windows.Forms.Button();
			this.btnK7 = new System.Windows.Forms.Button();
			this.btnK6 = new System.Windows.Forms.Button();
			this.btnK5 = new System.Windows.Forms.Button();
			this.btnK4 = new System.Windows.Forms.Button();
			this.btnK3 = new System.Windows.Forms.Button();
			this.btnK2 = new System.Windows.Forms.Button();
			this.btnK1 = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lblTotal = new System.Windows.Forms.Label();
			this.lblBack9 = new System.Windows.Forms.Label();
			this.lblFront9 = new System.Windows.Forms.Label();
			this.NetTotal = new System.Windows.Forms.TextBox();
			this.GrossTotal = new System.Windows.Forms.TextBox();
			this.NetBack9 = new System.Windows.Forms.TextBox();
			this.GrossBack9 = new System.Windows.Forms.TextBox();
			this.NetFront9 = new System.Windows.Forms.TextBox();
			this.GrossFront9 = new System.Windows.Forms.TextBox();
			this.ParTotal = new System.Windows.Forms.TextBox();
			this.ParBack9 = new System.Windows.Forms.TextBox();
			this.ParFront9 = new System.Windows.Forms.TextBox();
			this.lblTotala = new System.Windows.Forms.Label();
			this.lblBack9a = new System.Windows.Forms.Label();
			this.lblFront9a = new System.Windows.Forms.Label();
			this.lblTee18 = new System.Windows.Forms.Label();
			this.lblTee17 = new System.Windows.Forms.Label();
			this.lblTee16 = new System.Windows.Forms.Label();
			this.lblTee15 = new System.Windows.Forms.Label();
			this.lblTee14 = new System.Windows.Forms.Label();
			this.lblTee13 = new System.Windows.Forms.Label();
			this.lblTee12 = new System.Windows.Forms.Label();
			this.lblTee11 = new System.Windows.Forms.Label();
			this.lblTee10 = new System.Windows.Forms.Label();
			this.lblTee9 = new System.Windows.Forms.Label();
			this.lblTee8 = new System.Windows.Forms.Label();
			this.lblTee7 = new System.Windows.Forms.Label();
			this.lblTee6 = new System.Windows.Forms.Label();
			this.lblTee5 = new System.Windows.Forms.Label();
			this.lblTee4 = new System.Windows.Forms.Label();
			this.lblTee3 = new System.Windows.Forms.Label();
			this.lblTee2 = new System.Windows.Forms.Label();
			this.lblTee1 = new System.Windows.Forms.Label();
			this.Net18 = new System.Windows.Forms.TextBox();
			this.Gross18 = new System.Windows.Forms.TextBox();
			this.HDCP18 = new System.Windows.Forms.TextBox();
			this.Par18 = new System.Windows.Forms.TextBox();
			this.txtHole18 = new System.Windows.Forms.TextBox();
			this.Net17 = new System.Windows.Forms.TextBox();
			this.Gross17 = new System.Windows.Forms.TextBox();
			this.HDCP17 = new System.Windows.Forms.TextBox();
			this.Par17 = new System.Windows.Forms.TextBox();
			this.txtHole17 = new System.Windows.Forms.TextBox();
			this.Net16 = new System.Windows.Forms.TextBox();
			this.Gross16 = new System.Windows.Forms.TextBox();
			this.HDCP16 = new System.Windows.Forms.TextBox();
			this.Par16 = new System.Windows.Forms.TextBox();
			this.txtHole16 = new System.Windows.Forms.TextBox();
			this.Net15 = new System.Windows.Forms.TextBox();
			this.Gross15 = new System.Windows.Forms.TextBox();
			this.HDCP15 = new System.Windows.Forms.TextBox();
			this.Par15 = new System.Windows.Forms.TextBox();
			this.txtHole15 = new System.Windows.Forms.TextBox();
			this.Net14 = new System.Windows.Forms.TextBox();
			this.Gross14 = new System.Windows.Forms.TextBox();
			this.HDCP14 = new System.Windows.Forms.TextBox();
			this.Par14 = new System.Windows.Forms.TextBox();
			this.txtHole14 = new System.Windows.Forms.TextBox();
			this.Net13 = new System.Windows.Forms.TextBox();
			this.Gross13 = new System.Windows.Forms.TextBox();
			this.HDCP13 = new System.Windows.Forms.TextBox();
			this.Par13 = new System.Windows.Forms.TextBox();
			this.txtHole13 = new System.Windows.Forms.TextBox();
			this.Net12 = new System.Windows.Forms.TextBox();
			this.Gross12 = new System.Windows.Forms.TextBox();
			this.HDCP12 = new System.Windows.Forms.TextBox();
			this.Par12 = new System.Windows.Forms.TextBox();
			this.txtHole12 = new System.Windows.Forms.TextBox();
			this.Net11 = new System.Windows.Forms.TextBox();
			this.Gross11 = new System.Windows.Forms.TextBox();
			this.HDCP11 = new System.Windows.Forms.TextBox();
			this.Par11 = new System.Windows.Forms.TextBox();
			this.txtHole11 = new System.Windows.Forms.TextBox();
			this.Net10 = new System.Windows.Forms.TextBox();
			this.Gross10 = new System.Windows.Forms.TextBox();
			this.HDCP10 = new System.Windows.Forms.TextBox();
			this.Par10 = new System.Windows.Forms.TextBox();
			this.txtHole10 = new System.Windows.Forms.TextBox();
			this.Net9 = new System.Windows.Forms.TextBox();
			this.Gross9 = new System.Windows.Forms.TextBox();
			this.HDCP9 = new System.Windows.Forms.TextBox();
			this.Par9 = new System.Windows.Forms.TextBox();
			this.txtHole9 = new System.Windows.Forms.TextBox();
			this.Net8 = new System.Windows.Forms.TextBox();
			this.Gross8 = new System.Windows.Forms.TextBox();
			this.HDCP8 = new System.Windows.Forms.TextBox();
			this.Par8 = new System.Windows.Forms.TextBox();
			this.txtHole8 = new System.Windows.Forms.TextBox();
			this.Net7 = new System.Windows.Forms.TextBox();
			this.Gross7 = new System.Windows.Forms.TextBox();
			this.HDCP7 = new System.Windows.Forms.TextBox();
			this.Par7 = new System.Windows.Forms.TextBox();
			this.txtHole7 = new System.Windows.Forms.TextBox();
			this.Net6 = new System.Windows.Forms.TextBox();
			this.Gross6 = new System.Windows.Forms.TextBox();
			this.HDCP6 = new System.Windows.Forms.TextBox();
			this.Par6 = new System.Windows.Forms.TextBox();
			this.txtHole6 = new System.Windows.Forms.TextBox();
			this.Net5 = new System.Windows.Forms.TextBox();
			this.Gross5 = new System.Windows.Forms.TextBox();
			this.HDCP5 = new System.Windows.Forms.TextBox();
			this.Par5 = new System.Windows.Forms.TextBox();
			this.txtHole5 = new System.Windows.Forms.TextBox();
			this.Net4 = new System.Windows.Forms.TextBox();
			this.Gross4 = new System.Windows.Forms.TextBox();
			this.HDCP4 = new System.Windows.Forms.TextBox();
			this.Par4 = new System.Windows.Forms.TextBox();
			this.txtHole4 = new System.Windows.Forms.TextBox();
			this.Net3 = new System.Windows.Forms.TextBox();
			this.Gross3 = new System.Windows.Forms.TextBox();
			this.HDCP3 = new System.Windows.Forms.TextBox();
			this.Par3 = new System.Windows.Forms.TextBox();
			this.txtHole3 = new System.Windows.Forms.TextBox();
			this.Net2 = new System.Windows.Forms.TextBox();
			this.Gross2 = new System.Windows.Forms.TextBox();
			this.HDCP2 = new System.Windows.Forms.TextBox();
			this.Par2 = new System.Windows.Forms.TextBox();
			this.txtHole2 = new System.Windows.Forms.TextBox();
			this.lblTee = new System.Windows.Forms.Label();
			this.Net1 = new System.Windows.Forms.TextBox();
			this.Gross1 = new System.Windows.Forms.TextBox();
			this.HDCP1 = new System.Windows.Forms.TextBox();
			this.Par1 = new System.Windows.Forms.TextBox();
			this.txtHole1 = new System.Windows.Forms.TextBox();
			this.lblNet = new System.Windows.Forms.Label();
			this.lblGross = new System.Windows.Forms.Label();
			this.lblHdcp = new System.Windows.Forms.Label();
			this.lblPar = new System.Windows.Forms.Label();
			this.lblHole = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.XScore1 = new System.Windows.Forms.CheckBox();
			this.XScore2 = new System.Windows.Forms.CheckBox();
			this.XScore3 = new System.Windows.Forms.CheckBox();
			this.XScore4 = new System.Windows.Forms.CheckBox();
			this.XScore8 = new System.Windows.Forms.CheckBox();
			this.XScore7 = new System.Windows.Forms.CheckBox();
			this.XScore6 = new System.Windows.Forms.CheckBox();
			this.XScore5 = new System.Windows.Forms.CheckBox();
			this.XScore9 = new System.Windows.Forms.CheckBox();
			this.XScore18 = new System.Windows.Forms.CheckBox();
			this.XScore17 = new System.Windows.Forms.CheckBox();
			this.XScore16 = new System.Windows.Forms.CheckBox();
			this.XScore15 = new System.Windows.Forms.CheckBox();
			this.XScore14 = new System.Windows.Forms.CheckBox();
			this.XScore13 = new System.Windows.Forms.CheckBox();
			this.XScore12 = new System.Windows.Forms.CheckBox();
			this.XScore11 = new System.Windows.Forms.CheckBox();
			this.XScore10 = new System.Windows.Forms.CheckBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.gbHandicap.SuspendLayout();
			this.pnlNumbers.SuspendLayout();
			this.pnlKeyboard.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.btnSave,
																				 this.btnCancel,
																				 this.btnChange,
																				 this.gbHandicap,
																				 this.txtComputedHandicap,
																				 this.txtHandicap,
																				 this.txtInitials,
																				 this.lblComputedHandicap,
																				 this.lblHandicap,
																				 this.lblUserInitials});
			this.panel1.Location = new System.Drawing.Point(4, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(784, 160);
			this.panel1.TabIndex = 0;
			// 
			// btnSave
			// 
			this.btnSave.BackColor = System.Drawing.SystemColors.Control;
			this.btnSave.Location = new System.Drawing.Point(644, 108);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(128, 40);
			this.btnSave.TabIndex = 9;
			this.btnSave.Text = "Save";
			this.btnSave.Visible = false;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
			this.btnCancel.Location = new System.Drawing.Point(644, 12);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(128, 40);
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Visible = false;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnChange
			// 
			this.btnChange.BackColor = System.Drawing.SystemColors.Control;
			this.btnChange.Location = new System.Drawing.Point(644, 60);
			this.btnChange.Name = "btnChange";
			this.btnChange.Size = new System.Drawing.Size(128, 40);
			this.btnChange.TabIndex = 7;
			this.btnChange.Text = "Change";
			this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
			// 
			// gbHandicap
			// 
			this.gbHandicap.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.cbPlusHandicap,
																					 this.rbAverageScore,
																					 this.rbIndex,
																					 this.rbHome});
			this.gbHandicap.Enabled = false;
			this.gbHandicap.Location = new System.Drawing.Point(380, 4);
			this.gbHandicap.Name = "gbHandicap";
			this.gbHandicap.Size = new System.Drawing.Size(252, 148);
			this.gbHandicap.TabIndex = 6;
			this.gbHandicap.TabStop = false;
			this.gbHandicap.Text = "Handicap Type";
			// 
			// cbPlusHandicap
			// 
			this.cbPlusHandicap.Location = new System.Drawing.Point(36, 116);
			this.cbPlusHandicap.Name = "cbPlusHandicap";
			this.cbPlusHandicap.Size = new System.Drawing.Size(192, 24);
			this.cbPlusHandicap.TabIndex = 3;
			this.cbPlusHandicap.Text = "Plus Handicap";
			this.cbPlusHandicap.CheckedChanged += new System.EventHandler(this.cbPlusHandicap_CheckedChanged);
			// 
			// rbAverageScore
			// 
			this.rbAverageScore.Location = new System.Drawing.Point(36, 80);
			this.rbAverageScore.Name = "rbAverageScore";
			this.rbAverageScore.Size = new System.Drawing.Size(192, 24);
			this.rbAverageScore.TabIndex = 2;
			this.rbAverageScore.Text = "Average Score";
			this.rbAverageScore.CheckedChanged += new System.EventHandler(this.rbAverageScore_CheckedChanged);
			// 
			// rbIndex
			// 
			this.rbIndex.Location = new System.Drawing.Point(36, 56);
			this.rbIndex.Name = "rbIndex";
			this.rbIndex.Size = new System.Drawing.Size(192, 24);
			this.rbIndex.TabIndex = 1;
			this.rbIndex.Text = "Index";
			this.rbIndex.CheckedChanged += new System.EventHandler(this.rbIndex_CheckedChanged);
			// 
			// rbHome
			// 
			this.rbHome.Location = new System.Drawing.Point(36, 32);
			this.rbHome.Name = "rbHome";
			this.rbHome.Size = new System.Drawing.Size(192, 24);
			this.rbHome.TabIndex = 0;
			this.rbHome.Text = "Home";
			this.rbHome.CheckedChanged += new System.EventHandler(this.rbHome_CheckedChanged);
			// 
			// txtComputedHandicap
			// 
			this.txtComputedHandicap.Enabled = false;
			this.txtComputedHandicap.Location = new System.Drawing.Point(228, 96);
			this.txtComputedHandicap.Name = "txtComputedHandicap";
			this.txtComputedHandicap.ReadOnly = true;
			this.txtComputedHandicap.Size = new System.Drawing.Size(108, 32);
			this.txtComputedHandicap.TabIndex = 5;
			this.txtComputedHandicap.TabStop = false;
			this.txtComputedHandicap.Text = "";
			this.txtComputedHandicap.TextChanged += new System.EventHandler(this.txtComputedHandicap_TextChanged);
			// 
			// txtHandicap
			// 
			this.txtHandicap.BackColor = System.Drawing.Color.White;
			this.txtHandicap.Enabled = false;
			this.txtHandicap.Location = new System.Drawing.Point(228, 54);
			this.txtHandicap.Name = "txtHandicap";
			this.txtHandicap.ReadOnly = true;
			this.txtHandicap.Size = new System.Drawing.Size(108, 32);
			this.txtHandicap.TabIndex = 4;
			this.txtHandicap.Text = "";
			this.txtHandicap.TextChanged += new System.EventHandler(this.txtHandicap_TextChanged);
			this.txtHandicap.Enter += new System.EventHandler(this.txtHandicap_Enter);
			// 
			// txtInitials
			// 
			this.txtInitials.BackColor = System.Drawing.Color.White;
			this.txtInitials.Enabled = false;
			this.txtInitials.Location = new System.Drawing.Point(228, 16);
			this.txtInitials.Name = "txtInitials";
			this.txtInitials.ReadOnly = true;
			this.txtInitials.Size = new System.Drawing.Size(108, 32);
			this.txtInitials.TabIndex = 3;
			this.txtInitials.Text = "";
			this.txtInitials.Enter += new System.EventHandler(this.txtInitials_Enter);
			// 
			// lblComputedHandicap
			// 
			this.lblComputedHandicap.Location = new System.Drawing.Point(12, 96);
			this.lblComputedHandicap.Name = "lblComputedHandicap";
			this.lblComputedHandicap.Size = new System.Drawing.Size(208, 32);
			this.lblComputedHandicap.TabIndex = 2;
			this.lblComputedHandicap.Text = "Computed Handicap";
			this.lblComputedHandicap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblHandicap
			// 
			this.lblHandicap.Location = new System.Drawing.Point(12, 56);
			this.lblHandicap.Name = "lblHandicap";
			this.lblHandicap.Size = new System.Drawing.Size(208, 32);
			this.lblHandicap.TabIndex = 1;
			this.lblHandicap.Text = "Handicap";
			this.lblHandicap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblUserInitials
			// 
			this.lblUserInitials.Location = new System.Drawing.Point(12, 16);
			this.lblUserInitials.Name = "lblUserInitials";
			this.lblUserInitials.Size = new System.Drawing.Size(208, 32);
			this.lblUserInitials.TabIndex = 0;
			this.lblUserInitials.Text = "User Initials";
			this.lblUserInitials.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnExit
			// 
			this.btnExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(128)), ((System.Byte)(255)));
			this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnExit.Location = new System.Drawing.Point(828, 12);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(156, 156);
			this.btnExit.TabIndex = 1;
			this.btnExit.Text = "E&xit";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// pnlNumbers
			// 
			this.pnlNumbers.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.pnlNumbers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlNumbers.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.btnPeriod,
																					 this.btnDone,
																					 this.btnClear,
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
																					 this.btn1});
			this.pnlNumbers.Location = new System.Drawing.Point(724, 420);
			this.pnlNumbers.Name = "pnlNumbers";
			this.pnlNumbers.Size = new System.Drawing.Size(264, 264);
			this.pnlNumbers.TabIndex = 2;
			this.pnlNumbers.Visible = false;
			this.pnlNumbers.Leave += new System.EventHandler(this.pnlNumbers_Leave);
			// 
			// btnPeriod
			// 
			this.btnPeriod.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnPeriod.Location = new System.Drawing.Point(72, 192);
			this.btnPeriod.Name = "btnPeriod";
			this.btnPeriod.Size = new System.Drawing.Size(60, 60);
			this.btnPeriod.TabIndex = 29;
			this.btnPeriod.Text = ".";
			this.btnPeriod.Click += new System.EventHandler(this.btnPeriod_Click);
			// 
			// btnDone
			// 
			this.btnDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnDone.Location = new System.Drawing.Point(192, 12);
			this.btnDone.Name = "btnDone";
			this.btnDone.Size = new System.Drawing.Size(60, 180);
			this.btnDone.TabIndex = 28;
			this.btnDone.Text = "DONE";
			this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
			// 
			// btnClear
			// 
			this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnClear.Location = new System.Drawing.Point(132, 192);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(60, 60);
			this.btnClear.TabIndex = 27;
			this.btnClear.Text = "&Clear";
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnBack
			// 
			this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnBack.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnBack.Image")));
			this.btnBack.Location = new System.Drawing.Point(192, 192);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(60, 60);
			this.btnBack.TabIndex = 25;
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			// 
			// btn0
			// 
			this.btn0.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btn0.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn0.Location = new System.Drawing.Point(12, 192);
			this.btn0.Name = "btn0";
			this.btn0.Size = new System.Drawing.Size(60, 60);
			this.btn0.TabIndex = 24;
			this.btn0.Text = "&0";
			this.btn0.Click += new System.EventHandler(this.btn0_Click);
			// 
			// btn9
			// 
			this.btn9.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btn9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn9.Location = new System.Drawing.Point(132, 132);
			this.btn9.Name = "btn9";
			this.btn9.Size = new System.Drawing.Size(60, 60);
			this.btn9.TabIndex = 23;
			this.btn9.Text = "&9";
			this.btn9.Click += new System.EventHandler(this.btn9_Click);
			// 
			// btn8
			// 
			this.btn8.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btn8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn8.Location = new System.Drawing.Point(72, 132);
			this.btn8.Name = "btn8";
			this.btn8.Size = new System.Drawing.Size(60, 60);
			this.btn8.TabIndex = 22;
			this.btn8.Text = "&8";
			this.btn8.Click += new System.EventHandler(this.btn8_Click);
			// 
			// btn7
			// 
			this.btn7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btn7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn7.Location = new System.Drawing.Point(12, 132);
			this.btn7.Name = "btn7";
			this.btn7.Size = new System.Drawing.Size(60, 60);
			this.btn7.TabIndex = 21;
			this.btn7.Text = "&7";
			this.btn7.Click += new System.EventHandler(this.btn7_Click);
			// 
			// btn6
			// 
			this.btn6.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btn6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn6.Location = new System.Drawing.Point(132, 72);
			this.btn6.Name = "btn6";
			this.btn6.Size = new System.Drawing.Size(60, 60);
			this.btn6.TabIndex = 20;
			this.btn6.Text = "&6";
			this.btn6.Click += new System.EventHandler(this.btn6_Click);
			// 
			// btn5
			// 
			this.btn5.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btn5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn5.Location = new System.Drawing.Point(72, 72);
			this.btn5.Name = "btn5";
			this.btn5.Size = new System.Drawing.Size(60, 60);
			this.btn5.TabIndex = 19;
			this.btn5.Text = "&5";
			this.btn5.Click += new System.EventHandler(this.btn5_Click);
			// 
			// btn4
			// 
			this.btn4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btn4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn4.Location = new System.Drawing.Point(12, 72);
			this.btn4.Name = "btn4";
			this.btn4.Size = new System.Drawing.Size(60, 60);
			this.btn4.TabIndex = 18;
			this.btn4.Text = "&4";
			this.btn4.Click += new System.EventHandler(this.btn4_Click);
			// 
			// btn3
			// 
			this.btn3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btn3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn3.Location = new System.Drawing.Point(132, 12);
			this.btn3.Name = "btn3";
			this.btn3.Size = new System.Drawing.Size(60, 60);
			this.btn3.TabIndex = 17;
			this.btn3.Text = "&3";
			this.btn3.Click += new System.EventHandler(this.btn3_Click);
			// 
			// btn2
			// 
			this.btn2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn2.Location = new System.Drawing.Point(72, 12);
			this.btn2.Name = "btn2";
			this.btn2.Size = new System.Drawing.Size(60, 60);
			this.btn2.TabIndex = 16;
			this.btn2.Text = "&2";
			this.btn2.Click += new System.EventHandler(this.btn2_Click);
			// 
			// btn1
			// 
			this.btn1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btn1.Location = new System.Drawing.Point(12, 12);
			this.btn1.Name = "btn1";
			this.btn1.Size = new System.Drawing.Size(60, 60);
			this.btn1.TabIndex = 15;
			this.btn1.Text = "&1";
			this.btn1.Click += new System.EventHandler(this.btn1_Click);
			// 
			// pnlKeyboard
			// 
			this.pnlKeyboard.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.pnlKeyboard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlKeyboard.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.btnM,
																					  this.btnN,
																					  this.btnB,
																					  this.btnV,
																					  this.btnC,
																					  this.btnX,
																					  this.btnZ,
																					  this.btnL,
																					  this.btnK,
																					  this.btnJ,
																					  this.btnH,
																					  this.btnG,
																					  this.btnF,
																					  this.btnD,
																					  this.btnS,
																					  this.btnA,
																					  this.btnP,
																					  this.btnO,
																					  this.btnI,
																					  this.btnU,
																					  this.btnY,
																					  this.btnT,
																					  this.btnR,
																					  this.btnE,
																					  this.btnW,
																					  this.btnQ,
																					  this.btnKeyDone,
																					  this.btnKeyClear,
																					  this.btnKeyBack,
																					  this.btnK0,
																					  this.btnK9,
																					  this.btnK8,
																					  this.btnK7,
																					  this.btnK6,
																					  this.btnK5,
																					  this.btnK4,
																					  this.btnK3,
																					  this.btnK2,
																					  this.btnK1});
			this.pnlKeyboard.Location = new System.Drawing.Point(4, 420);
			this.pnlKeyboard.Name = "pnlKeyboard";
			this.pnlKeyboard.Size = new System.Drawing.Size(720, 264);
			this.pnlKeyboard.TabIndex = 3;
			this.pnlKeyboard.Visible = false;
			this.pnlKeyboard.Leave += new System.EventHandler(this.pnlKeyboard_Leave);
			// 
			// btnM
			// 
			this.btnM.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnM.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnM.Location = new System.Drawing.Point(460, 192);
			this.btnM.Name = "btnM";
			this.btnM.Size = new System.Drawing.Size(60, 60);
			this.btnM.TabIndex = 55;
			this.btnM.Text = "M";
			this.btnM.Click += new System.EventHandler(this.btnM_Click);
			// 
			// btnN
			// 
			this.btnN.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnN.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnN.Location = new System.Drawing.Point(400, 192);
			this.btnN.Name = "btnN";
			this.btnN.Size = new System.Drawing.Size(60, 60);
			this.btnN.TabIndex = 54;
			this.btnN.Text = "N";
			this.btnN.Click += new System.EventHandler(this.btnN_Click);
			// 
			// btnB
			// 
			this.btnB.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnB.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnB.Location = new System.Drawing.Point(340, 192);
			this.btnB.Name = "btnB";
			this.btnB.Size = new System.Drawing.Size(60, 60);
			this.btnB.TabIndex = 53;
			this.btnB.Text = "B";
			this.btnB.Click += new System.EventHandler(this.btnB_Click);
			// 
			// btnV
			// 
			this.btnV.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnV.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnV.Location = new System.Drawing.Point(280, 192);
			this.btnV.Name = "btnV";
			this.btnV.Size = new System.Drawing.Size(60, 60);
			this.btnV.TabIndex = 52;
			this.btnV.Text = "V";
			this.btnV.Click += new System.EventHandler(this.btnV_Click);
			// 
			// btnC
			// 
			this.btnC.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnC.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnC.Location = new System.Drawing.Point(220, 192);
			this.btnC.Name = "btnC";
			this.btnC.Size = new System.Drawing.Size(60, 60);
			this.btnC.TabIndex = 51;
			this.btnC.Text = "C";
			this.btnC.Click += new System.EventHandler(this.btnC_Click);
			// 
			// btnX
			// 
			this.btnX.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnX.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnX.Location = new System.Drawing.Point(160, 192);
			this.btnX.Name = "btnX";
			this.btnX.Size = new System.Drawing.Size(60, 60);
			this.btnX.TabIndex = 50;
			this.btnX.Text = "X";
			this.btnX.Click += new System.EventHandler(this.btnX_Click);
			// 
			// btnZ
			// 
			this.btnZ.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnZ.Location = new System.Drawing.Point(100, 192);
			this.btnZ.Name = "btnZ";
			this.btnZ.Size = new System.Drawing.Size(60, 60);
			this.btnZ.TabIndex = 49;
			this.btnZ.Text = "Z";
			this.btnZ.Click += new System.EventHandler(this.btnZ_Click);
			// 
			// btnL
			// 
			this.btnL.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnL.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnL.Location = new System.Drawing.Point(552, 132);
			this.btnL.Name = "btnL";
			this.btnL.Size = new System.Drawing.Size(60, 60);
			this.btnL.TabIndex = 48;
			this.btnL.Text = "L";
			this.btnL.Click += new System.EventHandler(this.btnL_Click);
			// 
			// btnK
			// 
			this.btnK.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnK.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnK.Location = new System.Drawing.Point(492, 132);
			this.btnK.Name = "btnK";
			this.btnK.Size = new System.Drawing.Size(60, 60);
			this.btnK.TabIndex = 47;
			this.btnK.Text = "K";
			this.btnK.Click += new System.EventHandler(this.btnK_Click);
			// 
			// btnJ
			// 
			this.btnJ.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnJ.Location = new System.Drawing.Point(432, 132);
			this.btnJ.Name = "btnJ";
			this.btnJ.Size = new System.Drawing.Size(60, 60);
			this.btnJ.TabIndex = 46;
			this.btnJ.Text = "J";
			this.btnJ.Click += new System.EventHandler(this.btnJ_Click);
			// 
			// btnH
			// 
			this.btnH.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnH.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnH.Location = new System.Drawing.Point(372, 132);
			this.btnH.Name = "btnH";
			this.btnH.Size = new System.Drawing.Size(60, 60);
			this.btnH.TabIndex = 45;
			this.btnH.Text = "H";
			this.btnH.Click += new System.EventHandler(this.btnH_Click);
			// 
			// btnG
			// 
			this.btnG.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnG.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnG.Location = new System.Drawing.Point(312, 132);
			this.btnG.Name = "btnG";
			this.btnG.Size = new System.Drawing.Size(60, 60);
			this.btnG.TabIndex = 44;
			this.btnG.Text = "G";
			this.btnG.Click += new System.EventHandler(this.btnG_Click);
			// 
			// btnF
			// 
			this.btnF.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnF.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnF.Location = new System.Drawing.Point(252, 132);
			this.btnF.Name = "btnF";
			this.btnF.Size = new System.Drawing.Size(60, 60);
			this.btnF.TabIndex = 43;
			this.btnF.Text = "F";
			this.btnF.Click += new System.EventHandler(this.btnF_Click);
			// 
			// btnD
			// 
			this.btnD.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnD.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnD.Location = new System.Drawing.Point(192, 132);
			this.btnD.Name = "btnD";
			this.btnD.Size = new System.Drawing.Size(60, 60);
			this.btnD.TabIndex = 42;
			this.btnD.Text = "D";
			this.btnD.Click += new System.EventHandler(this.btnD_Click);
			// 
			// btnS
			// 
			this.btnS.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnS.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnS.Location = new System.Drawing.Point(132, 132);
			this.btnS.Name = "btnS";
			this.btnS.Size = new System.Drawing.Size(60, 60);
			this.btnS.TabIndex = 41;
			this.btnS.Text = "S";
			this.btnS.Click += new System.EventHandler(this.btnS_Click);
			// 
			// btnA
			// 
			this.btnA.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnA.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnA.Location = new System.Drawing.Point(72, 132);
			this.btnA.Name = "btnA";
			this.btnA.Size = new System.Drawing.Size(60, 60);
			this.btnA.TabIndex = 40;
			this.btnA.Text = "A";
			this.btnA.Click += new System.EventHandler(this.btnA_Click);
			// 
			// btnP
			// 
			this.btnP.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnP.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnP.Location = new System.Drawing.Point(576, 72);
			this.btnP.Name = "btnP";
			this.btnP.Size = new System.Drawing.Size(60, 60);
			this.btnP.TabIndex = 38;
			this.btnP.Text = "P";
			this.btnP.Click += new System.EventHandler(this.btnP_Click);
			// 
			// btnO
			// 
			this.btnO.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnO.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnO.Location = new System.Drawing.Point(516, 72);
			this.btnO.Name = "btnO";
			this.btnO.Size = new System.Drawing.Size(60, 60);
			this.btnO.TabIndex = 37;
			this.btnO.Text = "O";
			this.btnO.Click += new System.EventHandler(this.btnO_Click);
			// 
			// btnI
			// 
			this.btnI.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnI.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnI.Location = new System.Drawing.Point(456, 72);
			this.btnI.Name = "btnI";
			this.btnI.Size = new System.Drawing.Size(60, 60);
			this.btnI.TabIndex = 36;
			this.btnI.Text = "I";
			this.btnI.Click += new System.EventHandler(this.btnI_Click);
			// 
			// btnU
			// 
			this.btnU.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnU.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnU.Location = new System.Drawing.Point(396, 72);
			this.btnU.Name = "btnU";
			this.btnU.Size = new System.Drawing.Size(60, 60);
			this.btnU.TabIndex = 35;
			this.btnU.Text = "U";
			this.btnU.Click += new System.EventHandler(this.btnU_Click);
			// 
			// btnY
			// 
			this.btnY.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnY.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnY.Location = new System.Drawing.Point(336, 72);
			this.btnY.Name = "btnY";
			this.btnY.Size = new System.Drawing.Size(60, 60);
			this.btnY.TabIndex = 34;
			this.btnY.Text = "Y";
			this.btnY.Click += new System.EventHandler(this.btnY_Click);
			// 
			// btnT
			// 
			this.btnT.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnT.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnT.Location = new System.Drawing.Point(276, 72);
			this.btnT.Name = "btnT";
			this.btnT.Size = new System.Drawing.Size(60, 60);
			this.btnT.TabIndex = 33;
			this.btnT.Text = "T";
			this.btnT.Click += new System.EventHandler(this.btnT_Click);
			// 
			// btnR
			// 
			this.btnR.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnR.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnR.Location = new System.Drawing.Point(216, 72);
			this.btnR.Name = "btnR";
			this.btnR.Size = new System.Drawing.Size(60, 60);
			this.btnR.TabIndex = 32;
			this.btnR.Text = "R";
			this.btnR.Click += new System.EventHandler(this.btnR_Click);
			// 
			// btnE
			// 
			this.btnE.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnE.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnE.Location = new System.Drawing.Point(156, 72);
			this.btnE.Name = "btnE";
			this.btnE.Size = new System.Drawing.Size(60, 60);
			this.btnE.TabIndex = 31;
			this.btnE.Text = "E";
			this.btnE.Click += new System.EventHandler(this.btnE_Click);
			// 
			// btnW
			// 
			this.btnW.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnW.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnW.Location = new System.Drawing.Point(96, 72);
			this.btnW.Name = "btnW";
			this.btnW.Size = new System.Drawing.Size(60, 60);
			this.btnW.TabIndex = 30;
			this.btnW.Text = "W";
			this.btnW.Click += new System.EventHandler(this.btnW_Click);
			// 
			// btnQ
			// 
			this.btnQ.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnQ.Location = new System.Drawing.Point(36, 72);
			this.btnQ.Name = "btnQ";
			this.btnQ.Size = new System.Drawing.Size(60, 60);
			this.btnQ.TabIndex = 29;
			this.btnQ.Text = "Q";
			this.btnQ.Click += new System.EventHandler(this.btnQ_Click);
			// 
			// btnKeyDone
			// 
			this.btnKeyDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnKeyDone.Location = new System.Drawing.Point(652, 12);
			this.btnKeyDone.Name = "btnKeyDone";
			this.btnKeyDone.Size = new System.Drawing.Size(56, 240);
			this.btnKeyDone.TabIndex = 28;
			this.btnKeyDone.Text = "DONE";
			this.btnKeyDone.Click += new System.EventHandler(this.btnKeyDone_Click);
			// 
			// btnKeyClear
			// 
			this.btnKeyClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnKeyClear.Location = new System.Drawing.Point(520, 192);
			this.btnKeyClear.Name = "btnKeyClear";
			this.btnKeyClear.Size = new System.Drawing.Size(68, 60);
			this.btnKeyClear.TabIndex = 27;
			this.btnKeyClear.Text = "&Clear";
			this.btnKeyClear.Click += new System.EventHandler(this.btnKeyClear_Click);
			// 
			// btnKeyBack
			// 
			this.btnKeyBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnKeyBack.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnKeyBack.Image")));
			this.btnKeyBack.Location = new System.Drawing.Point(588, 192);
			this.btnKeyBack.Name = "btnKeyBack";
			this.btnKeyBack.Size = new System.Drawing.Size(64, 60);
			this.btnKeyBack.TabIndex = 25;
			this.btnKeyBack.Click += new System.EventHandler(this.btnKeyBack_Click);
			// 
			// btnK0
			// 
			this.btnK0.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnK0.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnK0.Location = new System.Drawing.Point(548, 12);
			this.btnK0.Name = "btnK0";
			this.btnK0.Size = new System.Drawing.Size(60, 60);
			this.btnK0.TabIndex = 24;
			this.btnK0.Text = "0";
			this.btnK0.Click += new System.EventHandler(this.btnK0_Click);
			// 
			// btnK9
			// 
			this.btnK9.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnK9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnK9.Location = new System.Drawing.Point(488, 12);
			this.btnK9.Name = "btnK9";
			this.btnK9.Size = new System.Drawing.Size(60, 60);
			this.btnK9.TabIndex = 23;
			this.btnK9.Text = "9";
			this.btnK9.Click += new System.EventHandler(this.btnK9_Click);
			// 
			// btnK8
			// 
			this.btnK8.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnK8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnK8.Location = new System.Drawing.Point(428, 12);
			this.btnK8.Name = "btnK8";
			this.btnK8.Size = new System.Drawing.Size(60, 60);
			this.btnK8.TabIndex = 22;
			this.btnK8.Text = "8";
			this.btnK8.Click += new System.EventHandler(this.btnK8_Click);
			// 
			// btnK7
			// 
			this.btnK7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnK7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnK7.Location = new System.Drawing.Point(368, 12);
			this.btnK7.Name = "btnK7";
			this.btnK7.Size = new System.Drawing.Size(60, 60);
			this.btnK7.TabIndex = 21;
			this.btnK7.Text = "7";
			this.btnK7.Click += new System.EventHandler(this.btnK7_Click);
			// 
			// btnK6
			// 
			this.btnK6.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnK6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnK6.Location = new System.Drawing.Point(308, 12);
			this.btnK6.Name = "btnK6";
			this.btnK6.Size = new System.Drawing.Size(60, 60);
			this.btnK6.TabIndex = 20;
			this.btnK6.Text = "6";
			this.btnK6.Click += new System.EventHandler(this.btnK6_Click);
			// 
			// btnK5
			// 
			this.btnK5.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnK5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnK5.Location = new System.Drawing.Point(248, 12);
			this.btnK5.Name = "btnK5";
			this.btnK5.Size = new System.Drawing.Size(60, 60);
			this.btnK5.TabIndex = 19;
			this.btnK5.Text = "5";
			this.btnK5.Click += new System.EventHandler(this.btnK5_Click);
			// 
			// btnK4
			// 
			this.btnK4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnK4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnK4.Location = new System.Drawing.Point(188, 12);
			this.btnK4.Name = "btnK4";
			this.btnK4.Size = new System.Drawing.Size(60, 60);
			this.btnK4.TabIndex = 18;
			this.btnK4.Text = "4";
			this.btnK4.Click += new System.EventHandler(this.btnK4_Click);
			// 
			// btnK3
			// 
			this.btnK3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnK3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnK3.Location = new System.Drawing.Point(128, 12);
			this.btnK3.Name = "btnK3";
			this.btnK3.Size = new System.Drawing.Size(60, 60);
			this.btnK3.TabIndex = 17;
			this.btnK3.Text = "3";
			this.btnK3.Click += new System.EventHandler(this.btnK3_Click);
			// 
			// btnK2
			// 
			this.btnK2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnK2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnK2.Location = new System.Drawing.Point(68, 12);
			this.btnK2.Name = "btnK2";
			this.btnK2.Size = new System.Drawing.Size(60, 60);
			this.btnK2.TabIndex = 16;
			this.btnK2.Text = "2";
			this.btnK2.Click += new System.EventHandler(this.btnK2_Click);
			// 
			// btnK1
			// 
			this.btnK1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.btnK1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnK1.Location = new System.Drawing.Point(8, 12);
			this.btnK1.Name = "btnK1";
			this.btnK1.Size = new System.Drawing.Size(60, 60);
			this.btnK1.TabIndex = 15;
			this.btnK1.Text = "1";
			this.btnK1.Click += new System.EventHandler(this.btnK1_Click);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.XScore18,
																				 this.XScore17,
																				 this.XScore16,
																				 this.XScore15,
																				 this.XScore14,
																				 this.XScore13,
																				 this.XScore12,
																				 this.XScore11,
																				 this.XScore10,
																				 this.XScore9,
																				 this.XScore8,
																				 this.XScore7,
																				 this.XScore6,
																				 this.XScore5,
																				 this.XScore4,
																				 this.XScore3,
																				 this.XScore2,
																				 this.XScore1,
																				 this.label1,
																				 this.lblTotal,
																				 this.lblBack9,
																				 this.lblFront9,
																				 this.NetTotal,
																				 this.GrossTotal,
																				 this.NetBack9,
																				 this.GrossBack9,
																				 this.NetFront9,
																				 this.GrossFront9,
																				 this.ParTotal,
																				 this.ParBack9,
																				 this.ParFront9,
																				 this.lblTotala,
																				 this.lblBack9a,
																				 this.lblFront9a,
																				 this.lblTee18,
																				 this.lblTee17,
																				 this.lblTee16,
																				 this.lblTee15,
																				 this.lblTee14,
																				 this.lblTee13,
																				 this.lblTee12,
																				 this.lblTee11,
																				 this.lblTee10,
																				 this.lblTee9,
																				 this.lblTee8,
																				 this.lblTee7,
																				 this.lblTee6,
																				 this.lblTee5,
																				 this.lblTee4,
																				 this.lblTee3,
																				 this.lblTee2,
																				 this.lblTee1,
																				 this.Net18,
																				 this.Gross18,
																				 this.HDCP18,
																				 this.Par18,
																				 this.txtHole18,
																				 this.Net17,
																				 this.Gross17,
																				 this.HDCP17,
																				 this.Par17,
																				 this.txtHole17,
																				 this.Net16,
																				 this.Gross16,
																				 this.HDCP16,
																				 this.Par16,
																				 this.txtHole16,
																				 this.Net15,
																				 this.Gross15,
																				 this.HDCP15,
																				 this.Par15,
																				 this.txtHole15,
																				 this.Net14,
																				 this.Gross14,
																				 this.HDCP14,
																				 this.Par14,
																				 this.txtHole14,
																				 this.Net13,
																				 this.Gross13,
																				 this.HDCP13,
																				 this.Par13,
																				 this.txtHole13,
																				 this.Net12,
																				 this.Gross12,
																				 this.HDCP12,
																				 this.Par12,
																				 this.txtHole12,
																				 this.Net11,
																				 this.Gross11,
																				 this.HDCP11,
																				 this.Par11,
																				 this.txtHole11,
																				 this.Net10,
																				 this.Gross10,
																				 this.HDCP10,
																				 this.Par10,
																				 this.txtHole10,
																				 this.Net9,
																				 this.Gross9,
																				 this.HDCP9,
																				 this.Par9,
																				 this.txtHole9,
																				 this.Net8,
																				 this.Gross8,
																				 this.HDCP8,
																				 this.Par8,
																				 this.txtHole8,
																				 this.Net7,
																				 this.Gross7,
																				 this.HDCP7,
																				 this.Par7,
																				 this.txtHole7,
																				 this.Net6,
																				 this.Gross6,
																				 this.HDCP6,
																				 this.Par6,
																				 this.txtHole6,
																				 this.Net5,
																				 this.Gross5,
																				 this.HDCP5,
																				 this.Par5,
																				 this.txtHole5,
																				 this.Net4,
																				 this.Gross4,
																				 this.HDCP4,
																				 this.Par4,
																				 this.txtHole4,
																				 this.Net3,
																				 this.Gross3,
																				 this.HDCP3,
																				 this.Par3,
																				 this.txtHole3,
																				 this.Net2,
																				 this.Gross2,
																				 this.HDCP2,
																				 this.Par2,
																				 this.txtHole2,
																				 this.lblTee,
																				 this.Net1,
																				 this.Gross1,
																				 this.HDCP1,
																				 this.Par1,
																				 this.txtHole1,
																				 this.lblNet,
																				 this.lblGross,
																				 this.lblHdcp,
																				 this.lblPar,
																				 this.lblHole,
																				 this.panel3,
																				 this.panel4});
			this.panel2.Location = new System.Drawing.Point(4, 176);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(984, 240);
			this.panel2.TabIndex = 4;
			// 
			// lblTotal
			// 
			this.lblTotal.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(128)));
			this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTotal.Location = new System.Drawing.Point(928, 36);
			this.lblTotal.Name = "lblTotal";
			this.lblTotal.Size = new System.Drawing.Size(49, 28);
			this.lblTotal.TabIndex = 146;
			this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblBack9
			// 
			this.lblBack9.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(128)));
			this.lblBack9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblBack9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblBack9.Location = new System.Drawing.Point(880, 36);
			this.lblBack9.Name = "lblBack9";
			this.lblBack9.Size = new System.Drawing.Size(48, 28);
			this.lblBack9.TabIndex = 145;
			this.lblBack9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblFront9
			// 
			this.lblFront9.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(128)));
			this.lblFront9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblFront9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblFront9.Location = new System.Drawing.Point(472, 36);
			this.lblFront9.Name = "lblFront9";
			this.lblFront9.Size = new System.Drawing.Size(48, 28);
			this.lblFront9.TabIndex = 144;
			this.lblFront9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// NetTotal
			// 
			this.NetTotal.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.NetTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.NetTotal.Enabled = false;
			this.NetTotal.ForeColor = System.Drawing.Color.Black;
			this.NetTotal.Location = new System.Drawing.Point(928, 172);
			this.NetTotal.Name = "NetTotal";
			this.NetTotal.ReadOnly = true;
			this.NetTotal.Size = new System.Drawing.Size(49, 32);
			this.NetTotal.TabIndex = 143;
			this.NetTotal.Text = "";
			this.NetTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// GrossTotal
			// 
			this.GrossTotal.BackColor = System.Drawing.Color.White;
			this.GrossTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.GrossTotal.Enabled = false;
			this.GrossTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.GrossTotal.Location = new System.Drawing.Point(928, 132);
			this.GrossTotal.Name = "GrossTotal";
			this.GrossTotal.ReadOnly = true;
			this.GrossTotal.Size = new System.Drawing.Size(49, 38);
			this.GrossTotal.TabIndex = 142;
			this.GrossTotal.Text = "";
			this.GrossTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// NetBack9
			// 
			this.NetBack9.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.NetBack9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.NetBack9.Enabled = false;
			this.NetBack9.ForeColor = System.Drawing.Color.Black;
			this.NetBack9.Location = new System.Drawing.Point(880, 172);
			this.NetBack9.Name = "NetBack9";
			this.NetBack9.ReadOnly = true;
			this.NetBack9.Size = new System.Drawing.Size(48, 32);
			this.NetBack9.TabIndex = 141;
			this.NetBack9.Text = "";
			this.NetBack9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// GrossBack9
			// 
			this.GrossBack9.BackColor = System.Drawing.Color.White;
			this.GrossBack9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.GrossBack9.Enabled = false;
			this.GrossBack9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.GrossBack9.Location = new System.Drawing.Point(880, 132);
			this.GrossBack9.Name = "GrossBack9";
			this.GrossBack9.ReadOnly = true;
			this.GrossBack9.Size = new System.Drawing.Size(48, 38);
			this.GrossBack9.TabIndex = 140;
			this.GrossBack9.Text = "";
			this.GrossBack9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// NetFront9
			// 
			this.NetFront9.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.NetFront9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.NetFront9.Enabled = false;
			this.NetFront9.ForeColor = System.Drawing.Color.Black;
			this.NetFront9.Location = new System.Drawing.Point(472, 172);
			this.NetFront9.Name = "NetFront9";
			this.NetFront9.ReadOnly = true;
			this.NetFront9.Size = new System.Drawing.Size(48, 32);
			this.NetFront9.TabIndex = 139;
			this.NetFront9.Text = "";
			this.NetFront9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// GrossFront9
			// 
			this.GrossFront9.BackColor = System.Drawing.Color.White;
			this.GrossFront9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.GrossFront9.Enabled = false;
			this.GrossFront9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.GrossFront9.Location = new System.Drawing.Point(472, 132);
			this.GrossFront9.Name = "GrossFront9";
			this.GrossFront9.ReadOnly = true;
			this.GrossFront9.Size = new System.Drawing.Size(48, 38);
			this.GrossFront9.TabIndex = 138;
			this.GrossFront9.Text = "";
			this.GrossFront9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ParTotal
			// 
			this.ParTotal.BackColor = System.Drawing.Color.LightGreen;
			this.ParTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ParTotal.Enabled = false;
			this.ParTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ParTotal.Location = new System.Drawing.Point(928, 92);
			this.ParTotal.Name = "ParTotal";
			this.ParTotal.ReadOnly = true;
			this.ParTotal.Size = new System.Drawing.Size(48, 29);
			this.ParTotal.TabIndex = 137;
			this.ParTotal.Text = "";
			this.ParTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ParBack9
			// 
			this.ParBack9.BackColor = System.Drawing.Color.LightGreen;
			this.ParBack9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ParBack9.Enabled = false;
			this.ParBack9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ParBack9.Location = new System.Drawing.Point(880, 92);
			this.ParBack9.Name = "ParBack9";
			this.ParBack9.ReadOnly = true;
			this.ParBack9.Size = new System.Drawing.Size(48, 29);
			this.ParBack9.TabIndex = 136;
			this.ParBack9.Text = "";
			this.ParBack9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// ParFront9
			// 
			this.ParFront9.BackColor = System.Drawing.Color.LightGreen;
			this.ParFront9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ParFront9.Enabled = false;
			this.ParFront9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ParFront9.Location = new System.Drawing.Point(472, 92);
			this.ParFront9.Name = "ParFront9";
			this.ParFront9.ReadOnly = true;
			this.ParFront9.Size = new System.Drawing.Size(48, 29);
			this.ParFront9.TabIndex = 135;
			this.ParFront9.Text = "";
			this.ParFront9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// lblTotala
			// 
			this.lblTotala.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTotala.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTotala.Location = new System.Drawing.Point(928, 4);
			this.lblTotala.Name = "lblTotala";
			this.lblTotala.Size = new System.Drawing.Size(48, 32);
			this.lblTotala.TabIndex = 134;
			this.lblTotala.Text = "Total";
			this.lblTotala.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblBack9a
			// 
			this.lblBack9a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblBack9a.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblBack9a.Location = new System.Drawing.Point(880, 4);
			this.lblBack9a.Name = "lblBack9a";
			this.lblBack9a.Size = new System.Drawing.Size(48, 32);
			this.lblBack9a.TabIndex = 133;
			this.lblBack9a.Text = "Back9";
			this.lblBack9a.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblFront9a
			// 
			this.lblFront9a.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblFront9a.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblFront9a.Location = new System.Drawing.Point(472, 4);
			this.lblFront9a.Name = "lblFront9a";
			this.lblFront9a.Size = new System.Drawing.Size(48, 32);
			this.lblFront9a.TabIndex = 132;
			this.lblFront9a.Text = "Front 9";
			this.lblFront9a.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTee18
			// 
			this.lblTee18.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(128)));
			this.lblTee18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTee18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTee18.Location = new System.Drawing.Point(840, 36);
			this.lblTee18.Name = "lblTee18";
			this.lblTee18.Size = new System.Drawing.Size(40, 28);
			this.lblTee18.TabIndex = 131;
			this.lblTee18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTee17
			// 
			this.lblTee17.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(128)));
			this.lblTee17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTee17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTee17.Location = new System.Drawing.Point(800, 36);
			this.lblTee17.Name = "lblTee17";
			this.lblTee17.Size = new System.Drawing.Size(40, 28);
			this.lblTee17.TabIndex = 130;
			this.lblTee17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTee16
			// 
			this.lblTee16.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(128)));
			this.lblTee16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTee16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTee16.Location = new System.Drawing.Point(760, 36);
			this.lblTee16.Name = "lblTee16";
			this.lblTee16.Size = new System.Drawing.Size(40, 28);
			this.lblTee16.TabIndex = 129;
			this.lblTee16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTee15
			// 
			this.lblTee15.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(128)));
			this.lblTee15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTee15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTee15.Location = new System.Drawing.Point(720, 36);
			this.lblTee15.Name = "lblTee15";
			this.lblTee15.Size = new System.Drawing.Size(40, 28);
			this.lblTee15.TabIndex = 128;
			this.lblTee15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTee14
			// 
			this.lblTee14.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(128)));
			this.lblTee14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTee14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTee14.Location = new System.Drawing.Point(680, 36);
			this.lblTee14.Name = "lblTee14";
			this.lblTee14.Size = new System.Drawing.Size(40, 28);
			this.lblTee14.TabIndex = 127;
			this.lblTee14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTee13
			// 
			this.lblTee13.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(128)));
			this.lblTee13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTee13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTee13.Location = new System.Drawing.Point(640, 36);
			this.lblTee13.Name = "lblTee13";
			this.lblTee13.Size = new System.Drawing.Size(40, 28);
			this.lblTee13.TabIndex = 126;
			this.lblTee13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTee12
			// 
			this.lblTee12.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(128)));
			this.lblTee12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTee12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTee12.Location = new System.Drawing.Point(600, 36);
			this.lblTee12.Name = "lblTee12";
			this.lblTee12.Size = new System.Drawing.Size(40, 28);
			this.lblTee12.TabIndex = 125;
			this.lblTee12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTee11
			// 
			this.lblTee11.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(128)));
			this.lblTee11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTee11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTee11.Location = new System.Drawing.Point(560, 36);
			this.lblTee11.Name = "lblTee11";
			this.lblTee11.Size = new System.Drawing.Size(40, 28);
			this.lblTee11.TabIndex = 124;
			this.lblTee11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTee10
			// 
			this.lblTee10.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(128)));
			this.lblTee10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTee10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTee10.Location = new System.Drawing.Point(520, 36);
			this.lblTee10.Name = "lblTee10";
			this.lblTee10.Size = new System.Drawing.Size(40, 28);
			this.lblTee10.TabIndex = 123;
			this.lblTee10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTee9
			// 
			this.lblTee9.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(128)));
			this.lblTee9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTee9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTee9.Location = new System.Drawing.Point(432, 36);
			this.lblTee9.Name = "lblTee9";
			this.lblTee9.Size = new System.Drawing.Size(40, 28);
			this.lblTee9.TabIndex = 122;
			this.lblTee9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTee8
			// 
			this.lblTee8.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(128)));
			this.lblTee8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTee8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTee8.Location = new System.Drawing.Point(392, 36);
			this.lblTee8.Name = "lblTee8";
			this.lblTee8.Size = new System.Drawing.Size(40, 28);
			this.lblTee8.TabIndex = 121;
			this.lblTee8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTee7
			// 
			this.lblTee7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(128)));
			this.lblTee7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTee7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTee7.Location = new System.Drawing.Point(352, 36);
			this.lblTee7.Name = "lblTee7";
			this.lblTee7.Size = new System.Drawing.Size(40, 28);
			this.lblTee7.TabIndex = 120;
			this.lblTee7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTee6
			// 
			this.lblTee6.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(128)));
			this.lblTee6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTee6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTee6.Location = new System.Drawing.Point(312, 36);
			this.lblTee6.Name = "lblTee6";
			this.lblTee6.Size = new System.Drawing.Size(40, 28);
			this.lblTee6.TabIndex = 119;
			this.lblTee6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTee5
			// 
			this.lblTee5.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(128)));
			this.lblTee5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTee5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTee5.Location = new System.Drawing.Point(272, 36);
			this.lblTee5.Name = "lblTee5";
			this.lblTee5.Size = new System.Drawing.Size(40, 28);
			this.lblTee5.TabIndex = 118;
			this.lblTee5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTee4
			// 
			this.lblTee4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(128)));
			this.lblTee4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTee4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTee4.Location = new System.Drawing.Point(232, 36);
			this.lblTee4.Name = "lblTee4";
			this.lblTee4.Size = new System.Drawing.Size(40, 28);
			this.lblTee4.TabIndex = 117;
			this.lblTee4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTee3
			// 
			this.lblTee3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(128)));
			this.lblTee3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTee3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTee3.Location = new System.Drawing.Point(192, 36);
			this.lblTee3.Name = "lblTee3";
			this.lblTee3.Size = new System.Drawing.Size(40, 28);
			this.lblTee3.TabIndex = 116;
			this.lblTee3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTee2
			// 
			this.lblTee2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(128)));
			this.lblTee2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTee2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTee2.Location = new System.Drawing.Point(152, 36);
			this.lblTee2.Name = "lblTee2";
			this.lblTee2.Size = new System.Drawing.Size(40, 28);
			this.lblTee2.TabIndex = 115;
			this.lblTee2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblTee1
			// 
			this.lblTee1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(128)));
			this.lblTee1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTee1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTee1.Location = new System.Drawing.Point(112, 36);
			this.lblTee1.Name = "lblTee1";
			this.lblTee1.Size = new System.Drawing.Size(40, 28);
			this.lblTee1.TabIndex = 114;
			this.lblTee1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Net18
			// 
			this.Net18.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.Net18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Net18.Enabled = false;
			this.Net18.ForeColor = System.Drawing.Color.Black;
			this.Net18.Location = new System.Drawing.Point(840, 172);
			this.Net18.Name = "Net18";
			this.Net18.ReadOnly = true;
			this.Net18.Size = new System.Drawing.Size(40, 32);
			this.Net18.TabIndex = 113;
			this.Net18.Text = "";
			this.Net18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Gross18
			// 
			this.Gross18.BackColor = System.Drawing.Color.White;
			this.Gross18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Gross18.Enabled = false;
			this.Gross18.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Gross18.Location = new System.Drawing.Point(840, 132);
			this.Gross18.Name = "Gross18";
			this.Gross18.ReadOnly = true;
			this.Gross18.Size = new System.Drawing.Size(40, 38);
			this.Gross18.TabIndex = 112;
			this.Gross18.Text = "";
			this.Gross18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.Gross18.TextChanged += new System.EventHandler(this.Gross18_TextChanged);
			this.Gross18.Enter += new System.EventHandler(this.Gross18_Enter);
			// 
			// HDCP18
			// 
			this.HDCP18.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.HDCP18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.HDCP18.Enabled = false;
			this.HDCP18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.HDCP18.Location = new System.Drawing.Point(840, 64);
			this.HDCP18.Name = "HDCP18";
			this.HDCP18.ReadOnly = true;
			this.HDCP18.Size = new System.Drawing.Size(40, 29);
			this.HDCP18.TabIndex = 111;
			this.HDCP18.Text = "";
			this.HDCP18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Par18
			// 
			this.Par18.BackColor = System.Drawing.Color.LightGreen;
			this.Par18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Par18.Enabled = false;
			this.Par18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Par18.Location = new System.Drawing.Point(840, 92);
			this.Par18.Name = "Par18";
			this.Par18.ReadOnly = true;
			this.Par18.Size = new System.Drawing.Size(40, 29);
			this.Par18.TabIndex = 110;
			this.Par18.Text = "";
			this.Par18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtHole18
			// 
			this.txtHole18.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.txtHole18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtHole18.Enabled = false;
			this.txtHole18.Location = new System.Drawing.Point(840, 4);
			this.txtHole18.Name = "txtHole18";
			this.txtHole18.ReadOnly = true;
			this.txtHole18.Size = new System.Drawing.Size(40, 32);
			this.txtHole18.TabIndex = 109;
			this.txtHole18.Text = "18";
			this.txtHole18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Net17
			// 
			this.Net17.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.Net17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Net17.Enabled = false;
			this.Net17.ForeColor = System.Drawing.Color.Black;
			this.Net17.Location = new System.Drawing.Point(800, 172);
			this.Net17.Name = "Net17";
			this.Net17.ReadOnly = true;
			this.Net17.Size = new System.Drawing.Size(40, 32);
			this.Net17.TabIndex = 107;
			this.Net17.Text = "";
			this.Net17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Gross17
			// 
			this.Gross17.BackColor = System.Drawing.Color.White;
			this.Gross17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Gross17.Enabled = false;
			this.Gross17.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Gross17.Location = new System.Drawing.Point(800, 132);
			this.Gross17.Name = "Gross17";
			this.Gross17.ReadOnly = true;
			this.Gross17.Size = new System.Drawing.Size(40, 38);
			this.Gross17.TabIndex = 106;
			this.Gross17.Text = "";
			this.Gross17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.Gross17.TextChanged += new System.EventHandler(this.Gross17_TextChanged);
			this.Gross17.Enter += new System.EventHandler(this.Gross17_Enter);
			// 
			// HDCP17
			// 
			this.HDCP17.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.HDCP17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.HDCP17.Enabled = false;
			this.HDCP17.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.HDCP17.Location = new System.Drawing.Point(800, 64);
			this.HDCP17.Name = "HDCP17";
			this.HDCP17.ReadOnly = true;
			this.HDCP17.Size = new System.Drawing.Size(40, 29);
			this.HDCP17.TabIndex = 105;
			this.HDCP17.Text = "";
			this.HDCP17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Par17
			// 
			this.Par17.BackColor = System.Drawing.Color.LightGreen;
			this.Par17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Par17.Enabled = false;
			this.Par17.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Par17.Location = new System.Drawing.Point(800, 92);
			this.Par17.Name = "Par17";
			this.Par17.ReadOnly = true;
			this.Par17.Size = new System.Drawing.Size(40, 29);
			this.Par17.TabIndex = 104;
			this.Par17.Text = "";
			this.Par17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtHole17
			// 
			this.txtHole17.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.txtHole17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtHole17.Enabled = false;
			this.txtHole17.Location = new System.Drawing.Point(800, 4);
			this.txtHole17.Name = "txtHole17";
			this.txtHole17.ReadOnly = true;
			this.txtHole17.Size = new System.Drawing.Size(40, 32);
			this.txtHole17.TabIndex = 103;
			this.txtHole17.Text = "17";
			this.txtHole17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Net16
			// 
			this.Net16.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.Net16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Net16.Enabled = false;
			this.Net16.ForeColor = System.Drawing.Color.Black;
			this.Net16.Location = new System.Drawing.Point(760, 172);
			this.Net16.Name = "Net16";
			this.Net16.ReadOnly = true;
			this.Net16.Size = new System.Drawing.Size(40, 32);
			this.Net16.TabIndex = 101;
			this.Net16.Text = "";
			this.Net16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Gross16
			// 
			this.Gross16.BackColor = System.Drawing.Color.White;
			this.Gross16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Gross16.Enabled = false;
			this.Gross16.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Gross16.Location = new System.Drawing.Point(760, 132);
			this.Gross16.Name = "Gross16";
			this.Gross16.ReadOnly = true;
			this.Gross16.Size = new System.Drawing.Size(40, 38);
			this.Gross16.TabIndex = 100;
			this.Gross16.Text = "";
			this.Gross16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.Gross16.TextChanged += new System.EventHandler(this.Gross16_TextChanged);
			this.Gross16.Enter += new System.EventHandler(this.Gross16_Enter);
			// 
			// HDCP16
			// 
			this.HDCP16.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.HDCP16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.HDCP16.Enabled = false;
			this.HDCP16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.HDCP16.Location = new System.Drawing.Point(760, 64);
			this.HDCP16.Name = "HDCP16";
			this.HDCP16.ReadOnly = true;
			this.HDCP16.Size = new System.Drawing.Size(40, 29);
			this.HDCP16.TabIndex = 99;
			this.HDCP16.Text = "";
			this.HDCP16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Par16
			// 
			this.Par16.BackColor = System.Drawing.Color.LightGreen;
			this.Par16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Par16.Enabled = false;
			this.Par16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Par16.Location = new System.Drawing.Point(760, 92);
			this.Par16.Name = "Par16";
			this.Par16.ReadOnly = true;
			this.Par16.Size = new System.Drawing.Size(40, 29);
			this.Par16.TabIndex = 98;
			this.Par16.Text = "";
			this.Par16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtHole16
			// 
			this.txtHole16.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.txtHole16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtHole16.Enabled = false;
			this.txtHole16.Location = new System.Drawing.Point(760, 4);
			this.txtHole16.Name = "txtHole16";
			this.txtHole16.ReadOnly = true;
			this.txtHole16.Size = new System.Drawing.Size(40, 32);
			this.txtHole16.TabIndex = 97;
			this.txtHole16.Text = "16";
			this.txtHole16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Net15
			// 
			this.Net15.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.Net15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Net15.Enabled = false;
			this.Net15.ForeColor = System.Drawing.Color.Black;
			this.Net15.Location = new System.Drawing.Point(720, 172);
			this.Net15.Name = "Net15";
			this.Net15.ReadOnly = true;
			this.Net15.Size = new System.Drawing.Size(40, 32);
			this.Net15.TabIndex = 95;
			this.Net15.Text = "";
			this.Net15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Gross15
			// 
			this.Gross15.BackColor = System.Drawing.Color.White;
			this.Gross15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Gross15.Enabled = false;
			this.Gross15.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Gross15.Location = new System.Drawing.Point(720, 132);
			this.Gross15.Name = "Gross15";
			this.Gross15.ReadOnly = true;
			this.Gross15.Size = new System.Drawing.Size(40, 38);
			this.Gross15.TabIndex = 94;
			this.Gross15.Text = "";
			this.Gross15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.Gross15.TextChanged += new System.EventHandler(this.Gross15_TextChanged);
			this.Gross15.Enter += new System.EventHandler(this.Gross15_Enter);
			// 
			// HDCP15
			// 
			this.HDCP15.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.HDCP15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.HDCP15.Enabled = false;
			this.HDCP15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.HDCP15.Location = new System.Drawing.Point(720, 64);
			this.HDCP15.Name = "HDCP15";
			this.HDCP15.ReadOnly = true;
			this.HDCP15.Size = new System.Drawing.Size(40, 29);
			this.HDCP15.TabIndex = 93;
			this.HDCP15.Text = "";
			this.HDCP15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Par15
			// 
			this.Par15.BackColor = System.Drawing.Color.LightGreen;
			this.Par15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Par15.Enabled = false;
			this.Par15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Par15.Location = new System.Drawing.Point(720, 92);
			this.Par15.Name = "Par15";
			this.Par15.ReadOnly = true;
			this.Par15.Size = new System.Drawing.Size(40, 29);
			this.Par15.TabIndex = 92;
			this.Par15.Text = "";
			this.Par15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtHole15
			// 
			this.txtHole15.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.txtHole15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtHole15.Enabled = false;
			this.txtHole15.Location = new System.Drawing.Point(720, 4);
			this.txtHole15.Name = "txtHole15";
			this.txtHole15.ReadOnly = true;
			this.txtHole15.Size = new System.Drawing.Size(40, 32);
			this.txtHole15.TabIndex = 91;
			this.txtHole15.Text = "15";
			this.txtHole15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Net14
			// 
			this.Net14.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.Net14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Net14.Enabled = false;
			this.Net14.ForeColor = System.Drawing.Color.Black;
			this.Net14.Location = new System.Drawing.Point(680, 172);
			this.Net14.Name = "Net14";
			this.Net14.ReadOnly = true;
			this.Net14.Size = new System.Drawing.Size(40, 32);
			this.Net14.TabIndex = 89;
			this.Net14.Text = "";
			this.Net14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Gross14
			// 
			this.Gross14.BackColor = System.Drawing.Color.White;
			this.Gross14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Gross14.Enabled = false;
			this.Gross14.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Gross14.Location = new System.Drawing.Point(680, 132);
			this.Gross14.Name = "Gross14";
			this.Gross14.ReadOnly = true;
			this.Gross14.Size = new System.Drawing.Size(40, 38);
			this.Gross14.TabIndex = 88;
			this.Gross14.Text = "";
			this.Gross14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.Gross14.TextChanged += new System.EventHandler(this.Gross14_TextChanged);
			this.Gross14.Enter += new System.EventHandler(this.Gross14_Enter);
			// 
			// HDCP14
			// 
			this.HDCP14.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.HDCP14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.HDCP14.Enabled = false;
			this.HDCP14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.HDCP14.Location = new System.Drawing.Point(680, 64);
			this.HDCP14.Name = "HDCP14";
			this.HDCP14.ReadOnly = true;
			this.HDCP14.Size = new System.Drawing.Size(40, 29);
			this.HDCP14.TabIndex = 87;
			this.HDCP14.Text = "";
			this.HDCP14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Par14
			// 
			this.Par14.BackColor = System.Drawing.Color.LightGreen;
			this.Par14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Par14.Enabled = false;
			this.Par14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Par14.Location = new System.Drawing.Point(680, 92);
			this.Par14.Name = "Par14";
			this.Par14.ReadOnly = true;
			this.Par14.Size = new System.Drawing.Size(40, 29);
			this.Par14.TabIndex = 86;
			this.Par14.Text = "";
			this.Par14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtHole14
			// 
			this.txtHole14.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.txtHole14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtHole14.Enabled = false;
			this.txtHole14.Location = new System.Drawing.Point(680, 4);
			this.txtHole14.Name = "txtHole14";
			this.txtHole14.ReadOnly = true;
			this.txtHole14.Size = new System.Drawing.Size(40, 32);
			this.txtHole14.TabIndex = 85;
			this.txtHole14.Text = "14";
			this.txtHole14.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Net13
			// 
			this.Net13.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.Net13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Net13.Enabled = false;
			this.Net13.ForeColor = System.Drawing.Color.Black;
			this.Net13.Location = new System.Drawing.Point(640, 172);
			this.Net13.Name = "Net13";
			this.Net13.ReadOnly = true;
			this.Net13.Size = new System.Drawing.Size(40, 32);
			this.Net13.TabIndex = 83;
			this.Net13.Text = "";
			this.Net13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Gross13
			// 
			this.Gross13.BackColor = System.Drawing.Color.White;
			this.Gross13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Gross13.Enabled = false;
			this.Gross13.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Gross13.Location = new System.Drawing.Point(640, 132);
			this.Gross13.Name = "Gross13";
			this.Gross13.ReadOnly = true;
			this.Gross13.Size = new System.Drawing.Size(40, 38);
			this.Gross13.TabIndex = 82;
			this.Gross13.Text = "";
			this.Gross13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.Gross13.TextChanged += new System.EventHandler(this.Gross13_TextChanged);
			this.Gross13.Enter += new System.EventHandler(this.Gross13_Enter);
			// 
			// HDCP13
			// 
			this.HDCP13.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.HDCP13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.HDCP13.Enabled = false;
			this.HDCP13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.HDCP13.Location = new System.Drawing.Point(640, 64);
			this.HDCP13.Name = "HDCP13";
			this.HDCP13.ReadOnly = true;
			this.HDCP13.Size = new System.Drawing.Size(40, 29);
			this.HDCP13.TabIndex = 81;
			this.HDCP13.Text = "";
			this.HDCP13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Par13
			// 
			this.Par13.BackColor = System.Drawing.Color.LightGreen;
			this.Par13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Par13.Enabled = false;
			this.Par13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Par13.Location = new System.Drawing.Point(640, 92);
			this.Par13.Name = "Par13";
			this.Par13.ReadOnly = true;
			this.Par13.Size = new System.Drawing.Size(40, 29);
			this.Par13.TabIndex = 80;
			this.Par13.Text = "";
			this.Par13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtHole13
			// 
			this.txtHole13.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.txtHole13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtHole13.Enabled = false;
			this.txtHole13.Location = new System.Drawing.Point(640, 4);
			this.txtHole13.Name = "txtHole13";
			this.txtHole13.ReadOnly = true;
			this.txtHole13.Size = new System.Drawing.Size(40, 32);
			this.txtHole13.TabIndex = 79;
			this.txtHole13.Text = "13";
			this.txtHole13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Net12
			// 
			this.Net12.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.Net12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Net12.Enabled = false;
			this.Net12.ForeColor = System.Drawing.Color.Black;
			this.Net12.Location = new System.Drawing.Point(600, 172);
			this.Net12.Name = "Net12";
			this.Net12.ReadOnly = true;
			this.Net12.Size = new System.Drawing.Size(40, 32);
			this.Net12.TabIndex = 77;
			this.Net12.Text = "";
			this.Net12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Gross12
			// 
			this.Gross12.BackColor = System.Drawing.Color.White;
			this.Gross12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Gross12.Enabled = false;
			this.Gross12.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Gross12.Location = new System.Drawing.Point(600, 132);
			this.Gross12.Name = "Gross12";
			this.Gross12.ReadOnly = true;
			this.Gross12.Size = new System.Drawing.Size(40, 38);
			this.Gross12.TabIndex = 76;
			this.Gross12.Text = "";
			this.Gross12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.Gross12.TextChanged += new System.EventHandler(this.Gross12_TextChanged);
			this.Gross12.Enter += new System.EventHandler(this.Gross12_Enter);
			// 
			// HDCP12
			// 
			this.HDCP12.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.HDCP12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.HDCP12.Enabled = false;
			this.HDCP12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.HDCP12.Location = new System.Drawing.Point(600, 64);
			this.HDCP12.Name = "HDCP12";
			this.HDCP12.ReadOnly = true;
			this.HDCP12.Size = new System.Drawing.Size(40, 29);
			this.HDCP12.TabIndex = 75;
			this.HDCP12.Text = "";
			this.HDCP12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Par12
			// 
			this.Par12.BackColor = System.Drawing.Color.LightGreen;
			this.Par12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Par12.Enabled = false;
			this.Par12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Par12.Location = new System.Drawing.Point(600, 92);
			this.Par12.Name = "Par12";
			this.Par12.ReadOnly = true;
			this.Par12.Size = new System.Drawing.Size(40, 29);
			this.Par12.TabIndex = 74;
			this.Par12.Text = "";
			this.Par12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtHole12
			// 
			this.txtHole12.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.txtHole12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtHole12.Enabled = false;
			this.txtHole12.Location = new System.Drawing.Point(600, 4);
			this.txtHole12.Name = "txtHole12";
			this.txtHole12.ReadOnly = true;
			this.txtHole12.Size = new System.Drawing.Size(40, 32);
			this.txtHole12.TabIndex = 73;
			this.txtHole12.Text = "12";
			this.txtHole12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Net11
			// 
			this.Net11.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.Net11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Net11.Enabled = false;
			this.Net11.ForeColor = System.Drawing.Color.Black;
			this.Net11.Location = new System.Drawing.Point(560, 172);
			this.Net11.Name = "Net11";
			this.Net11.ReadOnly = true;
			this.Net11.Size = new System.Drawing.Size(40, 32);
			this.Net11.TabIndex = 71;
			this.Net11.Text = "";
			this.Net11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Gross11
			// 
			this.Gross11.BackColor = System.Drawing.Color.White;
			this.Gross11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Gross11.Enabled = false;
			this.Gross11.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Gross11.Location = new System.Drawing.Point(560, 132);
			this.Gross11.Name = "Gross11";
			this.Gross11.ReadOnly = true;
			this.Gross11.Size = new System.Drawing.Size(40, 38);
			this.Gross11.TabIndex = 70;
			this.Gross11.Text = "";
			this.Gross11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.Gross11.TextChanged += new System.EventHandler(this.Gross11_TextChanged);
			this.Gross11.Enter += new System.EventHandler(this.Gross11_Enter);
			// 
			// HDCP11
			// 
			this.HDCP11.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.HDCP11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.HDCP11.Enabled = false;
			this.HDCP11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.HDCP11.Location = new System.Drawing.Point(560, 64);
			this.HDCP11.Name = "HDCP11";
			this.HDCP11.ReadOnly = true;
			this.HDCP11.Size = new System.Drawing.Size(40, 29);
			this.HDCP11.TabIndex = 69;
			this.HDCP11.Text = "";
			this.HDCP11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Par11
			// 
			this.Par11.BackColor = System.Drawing.Color.LightGreen;
			this.Par11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Par11.Enabled = false;
			this.Par11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Par11.Location = new System.Drawing.Point(560, 92);
			this.Par11.Name = "Par11";
			this.Par11.ReadOnly = true;
			this.Par11.Size = new System.Drawing.Size(40, 29);
			this.Par11.TabIndex = 68;
			this.Par11.Text = "";
			this.Par11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtHole11
			// 
			this.txtHole11.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.txtHole11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtHole11.Enabled = false;
			this.txtHole11.Location = new System.Drawing.Point(560, 4);
			this.txtHole11.Name = "txtHole11";
			this.txtHole11.ReadOnly = true;
			this.txtHole11.Size = new System.Drawing.Size(40, 32);
			this.txtHole11.TabIndex = 67;
			this.txtHole11.Text = "11";
			this.txtHole11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Net10
			// 
			this.Net10.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.Net10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Net10.Enabled = false;
			this.Net10.ForeColor = System.Drawing.Color.Black;
			this.Net10.Location = new System.Drawing.Point(520, 172);
			this.Net10.Name = "Net10";
			this.Net10.ReadOnly = true;
			this.Net10.Size = new System.Drawing.Size(40, 32);
			this.Net10.TabIndex = 65;
			this.Net10.Text = "";
			this.Net10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Gross10
			// 
			this.Gross10.BackColor = System.Drawing.Color.White;
			this.Gross10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Gross10.Enabled = false;
			this.Gross10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Gross10.Location = new System.Drawing.Point(520, 132);
			this.Gross10.Name = "Gross10";
			this.Gross10.ReadOnly = true;
			this.Gross10.Size = new System.Drawing.Size(40, 38);
			this.Gross10.TabIndex = 64;
			this.Gross10.Text = "";
			this.Gross10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.Gross10.TextChanged += new System.EventHandler(this.Gross10_TextChanged);
			this.Gross10.Enter += new System.EventHandler(this.Gross10_Enter);
			// 
			// HDCP10
			// 
			this.HDCP10.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.HDCP10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.HDCP10.Enabled = false;
			this.HDCP10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.HDCP10.Location = new System.Drawing.Point(520, 64);
			this.HDCP10.Name = "HDCP10";
			this.HDCP10.ReadOnly = true;
			this.HDCP10.Size = new System.Drawing.Size(40, 29);
			this.HDCP10.TabIndex = 63;
			this.HDCP10.Text = "";
			this.HDCP10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Par10
			// 
			this.Par10.BackColor = System.Drawing.Color.LightGreen;
			this.Par10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Par10.Enabled = false;
			this.Par10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Par10.Location = new System.Drawing.Point(520, 92);
			this.Par10.Name = "Par10";
			this.Par10.ReadOnly = true;
			this.Par10.Size = new System.Drawing.Size(40, 29);
			this.Par10.TabIndex = 62;
			this.Par10.Text = "";
			this.Par10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtHole10
			// 
			this.txtHole10.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.txtHole10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtHole10.Enabled = false;
			this.txtHole10.Location = new System.Drawing.Point(520, 4);
			this.txtHole10.Name = "txtHole10";
			this.txtHole10.ReadOnly = true;
			this.txtHole10.Size = new System.Drawing.Size(40, 32);
			this.txtHole10.TabIndex = 61;
			this.txtHole10.Text = "10";
			this.txtHole10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Net9
			// 
			this.Net9.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.Net9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Net9.Enabled = false;
			this.Net9.ForeColor = System.Drawing.Color.Black;
			this.Net9.Location = new System.Drawing.Point(432, 172);
			this.Net9.Name = "Net9";
			this.Net9.ReadOnly = true;
			this.Net9.Size = new System.Drawing.Size(40, 32);
			this.Net9.TabIndex = 59;
			this.Net9.Text = "";
			this.Net9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Gross9
			// 
			this.Gross9.BackColor = System.Drawing.Color.White;
			this.Gross9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Gross9.Enabled = false;
			this.Gross9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Gross9.Location = new System.Drawing.Point(432, 132);
			this.Gross9.Name = "Gross9";
			this.Gross9.ReadOnly = true;
			this.Gross9.Size = new System.Drawing.Size(40, 38);
			this.Gross9.TabIndex = 58;
			this.Gross9.Text = "";
			this.Gross9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.Gross9.TextChanged += new System.EventHandler(this.Gross9_TextChanged);
			this.Gross9.Enter += new System.EventHandler(this.Gross9_Enter);
			// 
			// HDCP9
			// 
			this.HDCP9.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.HDCP9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.HDCP9.Enabled = false;
			this.HDCP9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.HDCP9.Location = new System.Drawing.Point(432, 64);
			this.HDCP9.Name = "HDCP9";
			this.HDCP9.ReadOnly = true;
			this.HDCP9.Size = new System.Drawing.Size(40, 29);
			this.HDCP9.TabIndex = 57;
			this.HDCP9.Text = "";
			this.HDCP9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Par9
			// 
			this.Par9.BackColor = System.Drawing.Color.LightGreen;
			this.Par9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Par9.Enabled = false;
			this.Par9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Par9.Location = new System.Drawing.Point(432, 92);
			this.Par9.Name = "Par9";
			this.Par9.ReadOnly = true;
			this.Par9.Size = new System.Drawing.Size(40, 29);
			this.Par9.TabIndex = 56;
			this.Par9.Text = "";
			this.Par9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtHole9
			// 
			this.txtHole9.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.txtHole9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtHole9.Enabled = false;
			this.txtHole9.Location = new System.Drawing.Point(432, 4);
			this.txtHole9.Name = "txtHole9";
			this.txtHole9.ReadOnly = true;
			this.txtHole9.Size = new System.Drawing.Size(40, 32);
			this.txtHole9.TabIndex = 55;
			this.txtHole9.Text = "9";
			this.txtHole9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Net8
			// 
			this.Net8.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.Net8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Net8.Enabled = false;
			this.Net8.ForeColor = System.Drawing.Color.Black;
			this.Net8.Location = new System.Drawing.Point(392, 172);
			this.Net8.Name = "Net8";
			this.Net8.ReadOnly = true;
			this.Net8.Size = new System.Drawing.Size(40, 32);
			this.Net8.TabIndex = 53;
			this.Net8.Text = "";
			this.Net8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Gross8
			// 
			this.Gross8.BackColor = System.Drawing.Color.White;
			this.Gross8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Gross8.Enabled = false;
			this.Gross8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Gross8.Location = new System.Drawing.Point(392, 132);
			this.Gross8.Name = "Gross8";
			this.Gross8.ReadOnly = true;
			this.Gross8.Size = new System.Drawing.Size(40, 38);
			this.Gross8.TabIndex = 52;
			this.Gross8.Text = "";
			this.Gross8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.Gross8.TextChanged += new System.EventHandler(this.Gross8_TextChanged);
			this.Gross8.Enter += new System.EventHandler(this.Gross8_Enter);
			// 
			// HDCP8
			// 
			this.HDCP8.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.HDCP8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.HDCP8.Enabled = false;
			this.HDCP8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.HDCP8.Location = new System.Drawing.Point(392, 64);
			this.HDCP8.Name = "HDCP8";
			this.HDCP8.ReadOnly = true;
			this.HDCP8.Size = new System.Drawing.Size(40, 29);
			this.HDCP8.TabIndex = 51;
			this.HDCP8.Text = "";
			this.HDCP8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Par8
			// 
			this.Par8.BackColor = System.Drawing.Color.LightGreen;
			this.Par8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Par8.Enabled = false;
			this.Par8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Par8.Location = new System.Drawing.Point(392, 92);
			this.Par8.Name = "Par8";
			this.Par8.ReadOnly = true;
			this.Par8.Size = new System.Drawing.Size(40, 29);
			this.Par8.TabIndex = 50;
			this.Par8.Text = "";
			this.Par8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtHole8
			// 
			this.txtHole8.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.txtHole8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtHole8.Enabled = false;
			this.txtHole8.Location = new System.Drawing.Point(392, 4);
			this.txtHole8.Name = "txtHole8";
			this.txtHole8.ReadOnly = true;
			this.txtHole8.Size = new System.Drawing.Size(40, 32);
			this.txtHole8.TabIndex = 49;
			this.txtHole8.Text = "8";
			this.txtHole8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Net7
			// 
			this.Net7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.Net7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Net7.Enabled = false;
			this.Net7.ForeColor = System.Drawing.Color.Black;
			this.Net7.Location = new System.Drawing.Point(352, 172);
			this.Net7.Name = "Net7";
			this.Net7.ReadOnly = true;
			this.Net7.Size = new System.Drawing.Size(40, 32);
			this.Net7.TabIndex = 47;
			this.Net7.Text = "";
			this.Net7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Gross7
			// 
			this.Gross7.BackColor = System.Drawing.Color.White;
			this.Gross7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Gross7.Enabled = false;
			this.Gross7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Gross7.Location = new System.Drawing.Point(352, 132);
			this.Gross7.Name = "Gross7";
			this.Gross7.ReadOnly = true;
			this.Gross7.Size = new System.Drawing.Size(40, 38);
			this.Gross7.TabIndex = 46;
			this.Gross7.Text = "";
			this.Gross7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.Gross7.TextChanged += new System.EventHandler(this.Gross7_TextChanged);
			this.Gross7.Enter += new System.EventHandler(this.Gross7_Enter);
			// 
			// HDCP7
			// 
			this.HDCP7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.HDCP7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.HDCP7.Enabled = false;
			this.HDCP7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.HDCP7.Location = new System.Drawing.Point(352, 64);
			this.HDCP7.Name = "HDCP7";
			this.HDCP7.ReadOnly = true;
			this.HDCP7.Size = new System.Drawing.Size(40, 29);
			this.HDCP7.TabIndex = 45;
			this.HDCP7.Text = "";
			this.HDCP7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Par7
			// 
			this.Par7.BackColor = System.Drawing.Color.LightGreen;
			this.Par7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Par7.Enabled = false;
			this.Par7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Par7.Location = new System.Drawing.Point(352, 92);
			this.Par7.Name = "Par7";
			this.Par7.ReadOnly = true;
			this.Par7.Size = new System.Drawing.Size(40, 29);
			this.Par7.TabIndex = 44;
			this.Par7.Text = "";
			this.Par7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtHole7
			// 
			this.txtHole7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.txtHole7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtHole7.Enabled = false;
			this.txtHole7.Location = new System.Drawing.Point(352, 4);
			this.txtHole7.Name = "txtHole7";
			this.txtHole7.ReadOnly = true;
			this.txtHole7.Size = new System.Drawing.Size(40, 32);
			this.txtHole7.TabIndex = 43;
			this.txtHole7.Text = "7";
			this.txtHole7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Net6
			// 
			this.Net6.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.Net6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Net6.Enabled = false;
			this.Net6.ForeColor = System.Drawing.Color.Black;
			this.Net6.Location = new System.Drawing.Point(312, 172);
			this.Net6.Name = "Net6";
			this.Net6.ReadOnly = true;
			this.Net6.Size = new System.Drawing.Size(40, 32);
			this.Net6.TabIndex = 41;
			this.Net6.Text = "";
			this.Net6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Gross6
			// 
			this.Gross6.BackColor = System.Drawing.Color.White;
			this.Gross6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Gross6.Enabled = false;
			this.Gross6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Gross6.Location = new System.Drawing.Point(312, 132);
			this.Gross6.Name = "Gross6";
			this.Gross6.ReadOnly = true;
			this.Gross6.Size = new System.Drawing.Size(40, 38);
			this.Gross6.TabIndex = 40;
			this.Gross6.Text = "";
			this.Gross6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.Gross6.TextChanged += new System.EventHandler(this.Gross6_TextChanged);
			this.Gross6.Enter += new System.EventHandler(this.Gross6_Enter);
			// 
			// HDCP6
			// 
			this.HDCP6.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.HDCP6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.HDCP6.Enabled = false;
			this.HDCP6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.HDCP6.Location = new System.Drawing.Point(312, 64);
			this.HDCP6.Name = "HDCP6";
			this.HDCP6.ReadOnly = true;
			this.HDCP6.Size = new System.Drawing.Size(40, 29);
			this.HDCP6.TabIndex = 39;
			this.HDCP6.Text = "";
			this.HDCP6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Par6
			// 
			this.Par6.BackColor = System.Drawing.Color.LightGreen;
			this.Par6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Par6.Enabled = false;
			this.Par6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Par6.Location = new System.Drawing.Point(312, 92);
			this.Par6.Name = "Par6";
			this.Par6.ReadOnly = true;
			this.Par6.Size = new System.Drawing.Size(40, 29);
			this.Par6.TabIndex = 38;
			this.Par6.Text = "";
			this.Par6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtHole6
			// 
			this.txtHole6.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.txtHole6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtHole6.Enabled = false;
			this.txtHole6.Location = new System.Drawing.Point(312, 4);
			this.txtHole6.Name = "txtHole6";
			this.txtHole6.ReadOnly = true;
			this.txtHole6.Size = new System.Drawing.Size(40, 32);
			this.txtHole6.TabIndex = 37;
			this.txtHole6.Text = "6";
			this.txtHole6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Net5
			// 
			this.Net5.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.Net5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Net5.Enabled = false;
			this.Net5.ForeColor = System.Drawing.Color.Black;
			this.Net5.Location = new System.Drawing.Point(272, 172);
			this.Net5.Name = "Net5";
			this.Net5.ReadOnly = true;
			this.Net5.Size = new System.Drawing.Size(40, 32);
			this.Net5.TabIndex = 35;
			this.Net5.Text = "";
			this.Net5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Gross5
			// 
			this.Gross5.BackColor = System.Drawing.Color.White;
			this.Gross5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Gross5.Enabled = false;
			this.Gross5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Gross5.Location = new System.Drawing.Point(272, 132);
			this.Gross5.Name = "Gross5";
			this.Gross5.ReadOnly = true;
			this.Gross5.Size = new System.Drawing.Size(40, 38);
			this.Gross5.TabIndex = 34;
			this.Gross5.Text = "";
			this.Gross5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.Gross5.TextChanged += new System.EventHandler(this.Gross5_TextChanged);
			this.Gross5.Enter += new System.EventHandler(this.Gross5_Enter);
			// 
			// HDCP5
			// 
			this.HDCP5.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.HDCP5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.HDCP5.Enabled = false;
			this.HDCP5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.HDCP5.Location = new System.Drawing.Point(272, 64);
			this.HDCP5.Name = "HDCP5";
			this.HDCP5.ReadOnly = true;
			this.HDCP5.Size = new System.Drawing.Size(40, 29);
			this.HDCP5.TabIndex = 33;
			this.HDCP5.Text = "";
			this.HDCP5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Par5
			// 
			this.Par5.BackColor = System.Drawing.Color.LightGreen;
			this.Par5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Par5.Enabled = false;
			this.Par5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Par5.Location = new System.Drawing.Point(272, 92);
			this.Par5.Name = "Par5";
			this.Par5.ReadOnly = true;
			this.Par5.Size = new System.Drawing.Size(40, 29);
			this.Par5.TabIndex = 32;
			this.Par5.Text = "";
			this.Par5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtHole5
			// 
			this.txtHole5.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.txtHole5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtHole5.Enabled = false;
			this.txtHole5.Location = new System.Drawing.Point(272, 4);
			this.txtHole5.Name = "txtHole5";
			this.txtHole5.ReadOnly = true;
			this.txtHole5.Size = new System.Drawing.Size(40, 32);
			this.txtHole5.TabIndex = 31;
			this.txtHole5.Text = "5";
			this.txtHole5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Net4
			// 
			this.Net4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.Net4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Net4.Enabled = false;
			this.Net4.ForeColor = System.Drawing.Color.Black;
			this.Net4.Location = new System.Drawing.Point(232, 172);
			this.Net4.Name = "Net4";
			this.Net4.ReadOnly = true;
			this.Net4.Size = new System.Drawing.Size(40, 32);
			this.Net4.TabIndex = 29;
			this.Net4.Text = "";
			this.Net4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Gross4
			// 
			this.Gross4.BackColor = System.Drawing.Color.White;
			this.Gross4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Gross4.Enabled = false;
			this.Gross4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Gross4.Location = new System.Drawing.Point(232, 132);
			this.Gross4.Name = "Gross4";
			this.Gross4.ReadOnly = true;
			this.Gross4.Size = new System.Drawing.Size(40, 38);
			this.Gross4.TabIndex = 28;
			this.Gross4.Text = "";
			this.Gross4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.Gross4.TextChanged += new System.EventHandler(this.Gross4_TextChanged);
			this.Gross4.Enter += new System.EventHandler(this.Gross4_Enter);
			// 
			// HDCP4
			// 
			this.HDCP4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.HDCP4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.HDCP4.Enabled = false;
			this.HDCP4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.HDCP4.Location = new System.Drawing.Point(232, 64);
			this.HDCP4.Name = "HDCP4";
			this.HDCP4.ReadOnly = true;
			this.HDCP4.Size = new System.Drawing.Size(40, 29);
			this.HDCP4.TabIndex = 27;
			this.HDCP4.Text = "";
			this.HDCP4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Par4
			// 
			this.Par4.BackColor = System.Drawing.Color.LightGreen;
			this.Par4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Par4.Enabled = false;
			this.Par4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Par4.Location = new System.Drawing.Point(232, 92);
			this.Par4.Name = "Par4";
			this.Par4.ReadOnly = true;
			this.Par4.Size = new System.Drawing.Size(40, 29);
			this.Par4.TabIndex = 26;
			this.Par4.Text = "";
			this.Par4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtHole4
			// 
			this.txtHole4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.txtHole4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtHole4.Enabled = false;
			this.txtHole4.Location = new System.Drawing.Point(232, 4);
			this.txtHole4.Name = "txtHole4";
			this.txtHole4.ReadOnly = true;
			this.txtHole4.Size = new System.Drawing.Size(40, 32);
			this.txtHole4.TabIndex = 25;
			this.txtHole4.Text = "4";
			this.txtHole4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Net3
			// 
			this.Net3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.Net3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Net3.Enabled = false;
			this.Net3.ForeColor = System.Drawing.Color.Black;
			this.Net3.Location = new System.Drawing.Point(192, 172);
			this.Net3.Name = "Net3";
			this.Net3.ReadOnly = true;
			this.Net3.Size = new System.Drawing.Size(40, 32);
			this.Net3.TabIndex = 23;
			this.Net3.Text = "";
			this.Net3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Gross3
			// 
			this.Gross3.BackColor = System.Drawing.Color.White;
			this.Gross3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Gross3.Enabled = false;
			this.Gross3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Gross3.Location = new System.Drawing.Point(192, 132);
			this.Gross3.Name = "Gross3";
			this.Gross3.ReadOnly = true;
			this.Gross3.Size = new System.Drawing.Size(40, 38);
			this.Gross3.TabIndex = 22;
			this.Gross3.Text = "";
			this.Gross3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.Gross3.TextChanged += new System.EventHandler(this.Gross3_TextChanged);
			this.Gross3.Enter += new System.EventHandler(this.Gross3_Enter);
			// 
			// HDCP3
			// 
			this.HDCP3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.HDCP3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.HDCP3.Enabled = false;
			this.HDCP3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.HDCP3.Location = new System.Drawing.Point(192, 64);
			this.HDCP3.Name = "HDCP3";
			this.HDCP3.ReadOnly = true;
			this.HDCP3.Size = new System.Drawing.Size(40, 29);
			this.HDCP3.TabIndex = 21;
			this.HDCP3.Text = "";
			this.HDCP3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Par3
			// 
			this.Par3.BackColor = System.Drawing.Color.LightGreen;
			this.Par3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Par3.Enabled = false;
			this.Par3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Par3.Location = new System.Drawing.Point(192, 92);
			this.Par3.Name = "Par3";
			this.Par3.ReadOnly = true;
			this.Par3.Size = new System.Drawing.Size(40, 29);
			this.Par3.TabIndex = 20;
			this.Par3.Text = "";
			this.Par3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtHole3
			// 
			this.txtHole3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.txtHole3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtHole3.Enabled = false;
			this.txtHole3.Location = new System.Drawing.Point(192, 4);
			this.txtHole3.Name = "txtHole3";
			this.txtHole3.ReadOnly = true;
			this.txtHole3.Size = new System.Drawing.Size(40, 32);
			this.txtHole3.TabIndex = 19;
			this.txtHole3.Text = "3";
			this.txtHole3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Net2
			// 
			this.Net2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.Net2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Net2.Enabled = false;
			this.Net2.ForeColor = System.Drawing.Color.Black;
			this.Net2.Location = new System.Drawing.Point(152, 172);
			this.Net2.Name = "Net2";
			this.Net2.ReadOnly = true;
			this.Net2.Size = new System.Drawing.Size(40, 32);
			this.Net2.TabIndex = 17;
			this.Net2.Text = "";
			this.Net2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Gross2
			// 
			this.Gross2.BackColor = System.Drawing.Color.White;
			this.Gross2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Gross2.Enabled = false;
			this.Gross2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Gross2.Location = new System.Drawing.Point(152, 132);
			this.Gross2.Name = "Gross2";
			this.Gross2.ReadOnly = true;
			this.Gross2.Size = new System.Drawing.Size(40, 38);
			this.Gross2.TabIndex = 16;
			this.Gross2.Text = "";
			this.Gross2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.Gross2.TextChanged += new System.EventHandler(this.Gross2_TextChanged);
			this.Gross2.Enter += new System.EventHandler(this.Gross2_Enter);
			// 
			// HDCP2
			// 
			this.HDCP2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.HDCP2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.HDCP2.Enabled = false;
			this.HDCP2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.HDCP2.Location = new System.Drawing.Point(152, 64);
			this.HDCP2.Name = "HDCP2";
			this.HDCP2.ReadOnly = true;
			this.HDCP2.Size = new System.Drawing.Size(40, 29);
			this.HDCP2.TabIndex = 15;
			this.HDCP2.Text = "";
			this.HDCP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Par2
			// 
			this.Par2.BackColor = System.Drawing.Color.LightGreen;
			this.Par2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Par2.Enabled = false;
			this.Par2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Par2.Location = new System.Drawing.Point(152, 92);
			this.Par2.Name = "Par2";
			this.Par2.ReadOnly = true;
			this.Par2.Size = new System.Drawing.Size(40, 29);
			this.Par2.TabIndex = 14;
			this.Par2.Text = "";
			this.Par2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtHole2
			// 
			this.txtHole2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.txtHole2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtHole2.Enabled = false;
			this.txtHole2.Location = new System.Drawing.Point(152, 4);
			this.txtHole2.Name = "txtHole2";
			this.txtHole2.ReadOnly = true;
			this.txtHole2.Size = new System.Drawing.Size(40, 32);
			this.txtHole2.TabIndex = 13;
			this.txtHole2.Text = "2";
			this.txtHole2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// lblTee
			// 
			this.lblTee.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(128)));
			this.lblTee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblTee.Location = new System.Drawing.Point(8, 36);
			this.lblTee.Name = "lblTee";
			this.lblTee.Size = new System.Drawing.Size(104, 28);
			this.lblTee.TabIndex = 11;
			this.lblTee.Text = "Tee";
			this.lblTee.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Net1
			// 
			this.Net1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.Net1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Net1.Enabled = false;
			this.Net1.ForeColor = System.Drawing.Color.Black;
			this.Net1.Location = new System.Drawing.Point(112, 172);
			this.Net1.Name = "Net1";
			this.Net1.ReadOnly = true;
			this.Net1.Size = new System.Drawing.Size(40, 32);
			this.Net1.TabIndex = 10;
			this.Net1.Text = "";
			this.Net1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Gross1
			// 
			this.Gross1.BackColor = System.Drawing.Color.White;
			this.Gross1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Gross1.Enabled = false;
			this.Gross1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Gross1.Location = new System.Drawing.Point(112, 132);
			this.Gross1.Name = "Gross1";
			this.Gross1.ReadOnly = true;
			this.Gross1.Size = new System.Drawing.Size(40, 38);
			this.Gross1.TabIndex = 9;
			this.Gross1.Text = "";
			this.Gross1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.Gross1.TextChanged += new System.EventHandler(this.Gross1_TextChanged);
			this.Gross1.Enter += new System.EventHandler(this.Gross1_Enter);
			// 
			// HDCP1
			// 
			this.HDCP1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.HDCP1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.HDCP1.Enabled = false;
			this.HDCP1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.HDCP1.Location = new System.Drawing.Point(112, 64);
			this.HDCP1.Name = "HDCP1";
			this.HDCP1.ReadOnly = true;
			this.HDCP1.Size = new System.Drawing.Size(40, 29);
			this.HDCP1.TabIndex = 8;
			this.HDCP1.Text = "";
			this.HDCP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Par1
			// 
			this.Par1.BackColor = System.Drawing.Color.LightGreen;
			this.Par1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Par1.Enabled = false;
			this.Par1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Par1.Location = new System.Drawing.Point(112, 92);
			this.Par1.Name = "Par1";
			this.Par1.ReadOnly = true;
			this.Par1.Size = new System.Drawing.Size(40, 29);
			this.Par1.TabIndex = 7;
			this.Par1.Text = "";
			this.Par1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtHole1
			// 
			this.txtHole1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.txtHole1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtHole1.Enabled = false;
			this.txtHole1.Location = new System.Drawing.Point(112, 4);
			this.txtHole1.Name = "txtHole1";
			this.txtHole1.ReadOnly = true;
			this.txtHole1.Size = new System.Drawing.Size(40, 32);
			this.txtHole1.TabIndex = 6;
			this.txtHole1.Text = "1";
			this.txtHole1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// lblNet
			// 
			this.lblNet.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.lblNet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblNet.Location = new System.Drawing.Point(8, 172);
			this.lblNet.Name = "lblNet";
			this.lblNet.Size = new System.Drawing.Size(104, 32);
			this.lblNet.TabIndex = 5;
			this.lblNet.Text = "Net";
			this.lblNet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblGross
			// 
			this.lblGross.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblGross.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblGross.Location = new System.Drawing.Point(8, 132);
			this.lblGross.Name = "lblGross";
			this.lblGross.Size = new System.Drawing.Size(104, 38);
			this.lblGross.TabIndex = 4;
			this.lblGross.Text = "Gross";
			this.lblGross.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblHdcp
			// 
			this.lblHdcp.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(224)), ((System.Byte)(224)), ((System.Byte)(224)));
			this.lblHdcp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblHdcp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblHdcp.Location = new System.Drawing.Point(8, 64);
			this.lblHdcp.Name = "lblHdcp";
			this.lblHdcp.Size = new System.Drawing.Size(104, 29);
			this.lblHdcp.TabIndex = 3;
			this.lblHdcp.Text = "Handicap";
			this.lblHdcp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblPar
			// 
			this.lblPar.BackColor = System.Drawing.Color.LightGreen;
			this.lblPar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblPar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblPar.Location = new System.Drawing.Point(8, 92);
			this.lblPar.Name = "lblPar";
			this.lblPar.Size = new System.Drawing.Size(104, 29);
			this.lblPar.TabIndex = 2;
			this.lblPar.Text = "Par";
			this.lblPar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblHole
			// 
			this.lblHole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblHole.Location = new System.Drawing.Point(8, 4);
			this.lblHole.Name = "lblHole";
			this.lblHole.Size = new System.Drawing.Size(104, 32);
			this.lblHole.TabIndex = 1;
			this.lblHole.Text = "Hole";
			this.lblHole.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label1.Location = new System.Drawing.Point(8, 204);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 32);
			this.label1.TabIndex = 147;
			this.label1.Text = "X Score";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// XScore1
			// 
			this.XScore1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.XScore1.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.XScore1.Enabled = false;
			this.XScore1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.XScore1.Location = new System.Drawing.Point(113, 205);
			this.XScore1.Name = "XScore1";
			this.XScore1.Size = new System.Drawing.Size(38, 30);
			this.XScore1.TabIndex = 148;
			this.XScore1.TabStop = false;
			// 
			// XScore2
			// 
			this.XScore2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.XScore2.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.XScore2.Enabled = false;
			this.XScore2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.XScore2.Location = new System.Drawing.Point(153, 205);
			this.XScore2.Name = "XScore2";
			this.XScore2.Size = new System.Drawing.Size(38, 30);
			this.XScore2.TabIndex = 149;
			this.XScore2.TabStop = false;
			// 
			// XScore3
			// 
			this.XScore3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.XScore3.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.XScore3.Enabled = false;
			this.XScore3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.XScore3.Location = new System.Drawing.Point(193, 205);
			this.XScore3.Name = "XScore3";
			this.XScore3.Size = new System.Drawing.Size(38, 30);
			this.XScore3.TabIndex = 150;
			this.XScore3.TabStop = false;
			// 
			// XScore4
			// 
			this.XScore4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.XScore4.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.XScore4.Enabled = false;
			this.XScore4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.XScore4.Location = new System.Drawing.Point(233, 205);
			this.XScore4.Name = "XScore4";
			this.XScore4.Size = new System.Drawing.Size(38, 30);
			this.XScore4.TabIndex = 151;
			this.XScore4.TabStop = false;
			// 
			// XScore8
			// 
			this.XScore8.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.XScore8.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.XScore8.Enabled = false;
			this.XScore8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.XScore8.Location = new System.Drawing.Point(393, 205);
			this.XScore8.Name = "XScore8";
			this.XScore8.Size = new System.Drawing.Size(38, 30);
			this.XScore8.TabIndex = 155;
			this.XScore8.TabStop = false;
			// 
			// XScore7
			// 
			this.XScore7.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.XScore7.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.XScore7.Enabled = false;
			this.XScore7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.XScore7.Location = new System.Drawing.Point(353, 205);
			this.XScore7.Name = "XScore7";
			this.XScore7.Size = new System.Drawing.Size(38, 30);
			this.XScore7.TabIndex = 154;
			this.XScore7.TabStop = false;
			// 
			// XScore6
			// 
			this.XScore6.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.XScore6.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.XScore6.Enabled = false;
			this.XScore6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.XScore6.Location = new System.Drawing.Point(313, 205);
			this.XScore6.Name = "XScore6";
			this.XScore6.Size = new System.Drawing.Size(38, 30);
			this.XScore6.TabIndex = 153;
			this.XScore6.TabStop = false;
			// 
			// XScore5
			// 
			this.XScore5.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.XScore5.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.XScore5.Enabled = false;
			this.XScore5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.XScore5.Location = new System.Drawing.Point(273, 205);
			this.XScore5.Name = "XScore5";
			this.XScore5.Size = new System.Drawing.Size(38, 30);
			this.XScore5.TabIndex = 152;
			this.XScore5.TabStop = false;
			// 
			// XScore9
			// 
			this.XScore9.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.XScore9.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.XScore9.Enabled = false;
			this.XScore9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.XScore9.Location = new System.Drawing.Point(433, 205);
			this.XScore9.Name = "XScore9";
			this.XScore9.Size = new System.Drawing.Size(38, 30);
			this.XScore9.TabIndex = 156;
			this.XScore9.TabStop = false;
			// 
			// XScore18
			// 
			this.XScore18.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.XScore18.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.XScore18.Enabled = false;
			this.XScore18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.XScore18.Location = new System.Drawing.Point(841, 205);
			this.XScore18.Name = "XScore18";
			this.XScore18.Size = new System.Drawing.Size(38, 30);
			this.XScore18.TabIndex = 165;
			this.XScore18.TabStop = false;
			// 
			// XScore17
			// 
			this.XScore17.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.XScore17.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.XScore17.Enabled = false;
			this.XScore17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.XScore17.Location = new System.Drawing.Point(801, 205);
			this.XScore17.Name = "XScore17";
			this.XScore17.Size = new System.Drawing.Size(38, 30);
			this.XScore17.TabIndex = 164;
			this.XScore17.TabStop = false;
			// 
			// XScore16
			// 
			this.XScore16.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.XScore16.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.XScore16.Enabled = false;
			this.XScore16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.XScore16.Location = new System.Drawing.Point(761, 205);
			this.XScore16.Name = "XScore16";
			this.XScore16.Size = new System.Drawing.Size(38, 30);
			this.XScore16.TabIndex = 163;
			this.XScore16.TabStop = false;
			// 
			// XScore15
			// 
			this.XScore15.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.XScore15.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.XScore15.Enabled = false;
			this.XScore15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.XScore15.Location = new System.Drawing.Point(721, 205);
			this.XScore15.Name = "XScore15";
			this.XScore15.Size = new System.Drawing.Size(38, 30);
			this.XScore15.TabIndex = 162;
			this.XScore15.TabStop = false;
			// 
			// XScore14
			// 
			this.XScore14.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.XScore14.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.XScore14.Enabled = false;
			this.XScore14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.XScore14.Location = new System.Drawing.Point(681, 205);
			this.XScore14.Name = "XScore14";
			this.XScore14.Size = new System.Drawing.Size(38, 30);
			this.XScore14.TabIndex = 161;
			this.XScore14.TabStop = false;
			// 
			// XScore13
			// 
			this.XScore13.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.XScore13.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.XScore13.Enabled = false;
			this.XScore13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.XScore13.Location = new System.Drawing.Point(641, 205);
			this.XScore13.Name = "XScore13";
			this.XScore13.Size = new System.Drawing.Size(38, 30);
			this.XScore13.TabIndex = 160;
			this.XScore13.TabStop = false;
			// 
			// XScore12
			// 
			this.XScore12.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.XScore12.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.XScore12.Enabled = false;
			this.XScore12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.XScore12.Location = new System.Drawing.Point(601, 205);
			this.XScore12.Name = "XScore12";
			this.XScore12.Size = new System.Drawing.Size(38, 30);
			this.XScore12.TabIndex = 159;
			this.XScore12.TabStop = false;
			// 
			// XScore11
			// 
			this.XScore11.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.XScore11.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.XScore11.Enabled = false;
			this.XScore11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.XScore11.Location = new System.Drawing.Point(561, 205);
			this.XScore11.Name = "XScore11";
			this.XScore11.Size = new System.Drawing.Size(38, 30);
			this.XScore11.TabIndex = 158;
			this.XScore11.TabStop = false;
			// 
			// XScore10
			// 
			this.XScore10.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(128)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.XScore10.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.XScore10.Enabled = false;
			this.XScore10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.XScore10.Location = new System.Drawing.Point(521, 205);
			this.XScore10.Name = "XScore10";
			this.XScore10.Size = new System.Drawing.Size(38, 30);
			this.XScore10.TabIndex = 157;
			this.XScore10.TabStop = false;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(64)));
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Location = new System.Drawing.Point(112, 204);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(361, 32);
			this.panel3.TabIndex = 166;
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(64)));
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel4.Location = new System.Drawing.Point(520, 204);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(361, 32);
			this.panel4.TabIndex = 167;
			// 
			// EditScores
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(10, 25);
			this.ClientSize = new System.Drawing.Size(994, 688);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnExit,
																		  this.panel1,
																		  this.pnlNumbers,
																		  this.pnlKeyboard,
																		  this.panel2});
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "EditScores";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Revise Handicaps and Scores";
			this.Load += new System.EventHandler(this.EditScores_Load);
			this.panel1.ResumeLayout(false);
			this.gbHandicap.ResumeLayout(false);
			this.pnlNumbers.ResumeLayout(false);
			this.pnlKeyboard.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		// ====Properties====================================
		public int PlayerID
		{
			get{ return _PlayerID;}
			set{ _PlayerID = value;}
		}
		public bool Updated
		{
			get{ return _Updated;}
		}
		// ====Properties====================================


		private void EditScores_Load(object sender, System.EventArgs e)
		{
			index = espDB.GetPlayerIndexFromID(_PlayerID);
			InitializeHandicapAndInitials();
			InitializeTees();
			InitializeScores();
			UpdateScores();
		}

		private void txtInitials_Enter(object sender, System.EventArgs e)
		{
			txtInitials.BackColor = Color.Cyan;
			txtHandicap.BackColor = Color.White;
			pnlKeyboard.Left = 100;
			pnlKeyboard.Top = 420;
			pnlKeyboard.Visible = true;
			pnlKeyboard.Focus();
		}

		private void txtHandicap_Enter(object sender, System.EventArgs e)
		{
			txtInitials.BackColor = Color.White;
			DisplayKeypad(txtHandicap);
		}

		private void DisplayKeypad( TextBox field )
		{
			// Reset color of previous field
			if (KeypadField != null)
			{
				KeypadField.BackColor = KeypadFieldColor;
			}

			// set keypad location
			pnlNumbers.Left = 184;
			pnlNumbers.Top = 420;
			pnlNumbers.Visible = true;
			pnlNumbers.Focus();

			// Set current object
			KeypadField = field;
			KeypadFieldColor = field.BackColor;
			KeypadField.BackColor = Color.Cyan;
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void pnlNumbers_Leave(object sender, System.EventArgs e)
		{
			if (KeypadField != null)
			{
				KeypadField.BackColor = KeypadFieldColor;
			}
			pnlNumbers.Visible = false;
		}

		private void pnlKeyboard_Leave(object sender, System.EventArgs e)
		{
			pnlKeyboard.Visible = false;
		}

		private void btnDone_Click(object sender, System.EventArgs e)
		{
			if (KeypadField != null)
			{
				KeypadField.BackColor = KeypadFieldColor;
			}
			pnlNumbers.Visible = false;
		}

		private void btn1_Click(object sender, System.EventArgs e)
		{
			KeypadField.Text += "1";
		}

		private void btn2_Click(object sender, System.EventArgs e)
		{
			KeypadField.Text += "2";
		}

		private void btn3_Click(object sender, System.EventArgs e)
		{
			KeypadField.Text += "3";
		}

		private void btn4_Click(object sender, System.EventArgs e)
		{
			KeypadField.Text += "4";
		}

		private void btn5_Click(object sender, System.EventArgs e)
		{
			KeypadField.Text += "5";
		}

		private void btn6_Click(object sender, System.EventArgs e)
		{
			KeypadField.Text += "6";
		}

		private void btn7_Click(object sender, System.EventArgs e)
		{
			KeypadField.Text += "7";
		}

		private void btn8_Click(object sender, System.EventArgs e)
		{
			KeypadField.Text += "8";
		}

		private void btn9_Click(object sender, System.EventArgs e)
		{
			KeypadField.Text += "9";
		}

		private void btn0_Click(object sender, System.EventArgs e)
		{
			KeypadField.Text += "0";
		}

		private void btnPeriod_Click(object sender, System.EventArgs e)
		{
			KeypadField.Text += ".";
		}

		private void btnClear_Click(object sender, System.EventArgs e)
		{
			KeypadField.Text = "";
		}

		private void btnBack_Click(object sender, System.EventArgs e)
		{
			if (KeypadField.Text.Length > 0)
				KeypadField.Text = KeypadField.Text.Remove(KeypadField.Text.Length-1,1);
		}

		private void btnKeyDone_Click(object sender, System.EventArgs e)
		{
			pnlKeyboard.Visible = false;
		}

		private void btnKeyBack_Click(object sender, System.EventArgs e)
		{
			if (txtInitials.Text.Length > 0)
				txtInitials.Text = txtInitials.Text.Remove(txtInitials.Text.Length-1,1);
		}

		private void btnKeyClear_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = "";
		}

		private void rbAverageScore_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rbAverageScore.Checked)
			{
				this.cbPlusHandicap.Checked = false;
				this.cbPlusHandicap.Visible = false;
			}
			else
			{
				this.cbPlusHandicap.Visible = true;
			}
			if (txtHandicap.Text != "")
				this.txtComputedHandicap.Text = UpdateComputedHandicap(txtHandicap.Text).ToString();
		}

		private void rbIndex_CheckedChanged(object sender, System.EventArgs e)
		{
			this.cbPlusHandicap.Visible = true;
			if (txtHandicap.Text != "")
				this.txtComputedHandicap.Text = UpdateComputedHandicap(txtHandicap.Text).ToString();
		}

		private void rbHome_CheckedChanged(object sender, System.EventArgs e)
		{
			this.cbPlusHandicap.Visible = true;
			if (txtHandicap.Text != "")
				this.txtComputedHandicap.Text = UpdateComputedHandicap(txtHandicap.Text).ToString();
		}

		private void cbPlusHandicap_CheckedChanged(object sender, System.EventArgs e)
		{
			if (txtHandicap.Text != "")
				this.txtComputedHandicap.Text = UpdateComputedHandicap(txtHandicap.Text).ToString();
		}

		private void btnChange_Click(object sender, System.EventArgs e)
		{
			ChangeSaveCancel1(true);
			ChangeSaveCancel2(true);
		}

		private void ChangeSaveCancel1(bool flag)
		{
			// Update Fields
			txtInitials.Enabled = flag;
			txtHandicap.Enabled = flag;
			this.gbHandicap.Enabled = flag;
			//this.rbHome.Enabled = flag;
			//this.rbAverageScore.Enabled = flag;
			//this.cbPlusHandicap.Enabled = flag;

			// Update Buttons
			this.btnChange.Visible = !flag;
			this.btnCancel.Visible = flag;
			this.btnSave.Visible = flag;
			this.btnExit.Visible = !flag;

			// set the Focus
			this.txtInitials.Focus();
		}

		private void ChangeSaveCancel2(bool flag)
		{
			// Update Fields
			Gross1.Enabled = flag;
			Gross2.Enabled = flag;
			Gross3.Enabled = flag;
			Gross4.Enabled = flag;
			Gross5.Enabled = flag;
			Gross6.Enabled = flag;
			Gross7.Enabled = flag;
			Gross8.Enabled = flag;
			Gross9.Enabled = flag;
			Gross10.Enabled = flag;
			Gross11.Enabled = flag;
			Gross12.Enabled = flag;
			Gross13.Enabled = flag;
			Gross14.Enabled = flag;
			Gross15.Enabled = flag;
			Gross16.Enabled = flag;
			Gross17.Enabled = flag;
			Gross18.Enabled = flag;

			XScore1.Enabled = flag;
			XScore2.Enabled = flag;
			XScore3.Enabled = flag;
			XScore4.Enabled = flag;
			XScore5.Enabled = flag;
			XScore6.Enabled = flag;
			XScore7.Enabled = flag;
			XScore8.Enabled = flag;
			XScore9.Enabled = flag;
			XScore10.Enabled = flag;
			XScore11.Enabled = flag;
			XScore12.Enabled = flag;
			XScore13.Enabled = flag;
			XScore14.Enabled = flag;
			XScore15.Enabled = flag;
			XScore16.Enabled = flag;
			XScore17.Enabled = flag;
			XScore18.Enabled = flag;
		}

		private void InitializeHandicapAndInitials()
		{
			txtInitials.Text = espDB.cPlayers[index].Initials;
			txtHandicap.Text = espDB.cPlayers[index].Handicap.ToString();
			txtComputedHandicap.Text = espDB.cPlayers[index].ComputedHandicap.ToString();
			switch (espDB.cPlayers[index].HandicapType)
			{
				case HANDICAP_TYPE.HomeHandicap:
					this.rbHome.Checked = true;
					break;
				case HANDICAP_TYPE.IndexHandicap:
					this.rbIndex.Checked = true;
					break;
				case HANDICAP_TYPE.EstimatedScore:
					this.rbAverageScore.Checked = true;
					break;
			}
			if (espDB.cPlayers[index].PlusHandicap)this.cbPlusHandicap.Checked = true;
			else this.cbPlusHandicap.Checked = false;
			txtInitials.BackColor = Color.White;
			txtHandicap.BackColor = Color.White;
		}

		private void InitializeTees()
		{
			TEE_INFORMATION pTee;
			short front9T = 0, back9T = 0, totalT = 0;
			short front9P = 0, back9P = 0, totalP = 0;

			pTee = espDB.GetTeeInfo(espDB.cPlayers[index].Tees);
			lblTee.Text = pTee.TeeName;

			lblTee1.Text = pTee.Holes[0].Length.ToString();
			HDCP1.Text = pTee.Holes[0].Handicap.ToString();
			Par1.Text = pTee.Holes[0].Par.ToString();
			front9T += (short)pTee.Holes[0].Length;
			front9P += (short) pTee.Holes[0].Par;

			lblTee2.Text = pTee.Holes[1].Length.ToString();
			HDCP2.Text = pTee.Holes[1].Handicap.ToString();
			Par2.Text = pTee.Holes[1].Par.ToString();
			front9T += (short)pTee.Holes[1].Length;
			front9P += (short) pTee.Holes[1].Par;

			lblTee3.Text = pTee.Holes[2].Length.ToString();
			HDCP3.Text = pTee.Holes[2].Handicap.ToString();
			Par3.Text = pTee.Holes[2].Par.ToString();
			front9T += (short)pTee.Holes[2].Length;
			front9P += (short) pTee.Holes[2].Par;

			lblTee4.Text = pTee.Holes[3].Length.ToString();
			HDCP4.Text = pTee.Holes[3].Handicap.ToString();
			Par4.Text = pTee.Holes[3].Par.ToString();
			front9T += (short)pTee.Holes[3].Length;
			front9P += (short) pTee.Holes[3].Par;

			lblTee5.Text = pTee.Holes[4].Length.ToString();
			HDCP5.Text = pTee.Holes[4].Handicap.ToString();
			Par5.Text = pTee.Holes[4].Par.ToString();
			front9T += (short)pTee.Holes[4].Length;
			front9P += (short) pTee.Holes[4].Par;

			lblTee6.Text = pTee.Holes[5].Length.ToString();
			HDCP6.Text = pTee.Holes[5].Handicap.ToString();
			Par6.Text = pTee.Holes[5].Par.ToString();
			front9T += (short)pTee.Holes[5].Length;
			front9P += (short) pTee.Holes[5].Par;

			lblTee7.Text = pTee.Holes[6].Length.ToString();
			HDCP7.Text = pTee.Holes[6].Handicap.ToString();
			Par7.Text = pTee.Holes[6].Par.ToString();
			front9T += (short)pTee.Holes[6].Length;
			front9P += (short) pTee.Holes[6].Par;

			lblTee8.Text = pTee.Holes[7].Length.ToString();
			HDCP8.Text = pTee.Holes[7].Handicap.ToString();
			Par8.Text = pTee.Holes[7].Par.ToString();
			front9T += (short)pTee.Holes[7].Length;
			front9P += (short) pTee.Holes[7].Par;

			lblTee9.Text = pTee.Holes[8].Length.ToString();
			HDCP9.Text = pTee.Holes[8].Handicap.ToString();
			Par9.Text = pTee.Holes[8].Par.ToString();
			front9T += (short)pTee.Holes[8].Length;
			front9P += (short) pTee.Holes[8].Par;

			lblFront9.Text = front9T.ToString();
			ParFront9.Text = front9P.ToString();

			lblTee10.Text = pTee.Holes[9].Length.ToString();
			HDCP10.Text = pTee.Holes[9].Handicap.ToString();
			Par10.Text = pTee.Holes[9].Par.ToString();
			back9T += (short)pTee.Holes[9].Length;
			back9P += (short) pTee.Holes[9].Par;

			lblTee11.Text = pTee.Holes[10].Length.ToString();
			HDCP11.Text = pTee.Holes[10].Handicap.ToString();
			Par11.Text = pTee.Holes[10].Par.ToString();
			back9T += (short)pTee.Holes[10].Length;
			back9P += (short) pTee.Holes[10].Par;

			lblTee12.Text = pTee.Holes[11].Length.ToString();
			HDCP12.Text = pTee.Holes[11].Handicap.ToString();
			Par12.Text = pTee.Holes[11].Par.ToString();
			back9T += (short)pTee.Holes[11].Length;
			back9P += (short) pTee.Holes[11].Par;

			lblTee13.Text = pTee.Holes[12].Length.ToString();
			HDCP13.Text = pTee.Holes[12].Handicap.ToString();
			Par13.Text = pTee.Holes[12].Par.ToString();
			back9T += (short)pTee.Holes[12].Length;
			back9P += (short) pTee.Holes[12].Par;

			lblTee14.Text = pTee.Holes[13].Length.ToString();
			HDCP14.Text = pTee.Holes[13].Handicap.ToString();
			Par14.Text = pTee.Holes[13].Par.ToString();
			back9T += (short)pTee.Holes[13].Length;
			back9P += (short) pTee.Holes[13].Par;

			lblTee15.Text = pTee.Holes[14].Length.ToString();
			HDCP15.Text = pTee.Holes[14].Handicap.ToString();
			Par15.Text = pTee.Holes[14].Par.ToString();
			back9T += (short)pTee.Holes[14].Length;
			back9P += (short) pTee.Holes[14].Par;

			lblTee16.Text = pTee.Holes[15].Length.ToString();
			HDCP16.Text = pTee.Holes[15].Handicap.ToString();
			Par16.Text = pTee.Holes[15].Par.ToString();
			back9T += (short)pTee.Holes[15].Length;
			back9P += (short) pTee.Holes[15].Par;

			lblTee17.Text = pTee.Holes[16].Length.ToString();
			HDCP17.Text = pTee.Holes[16].Handicap.ToString();
			Par17.Text = pTee.Holes[16].Par.ToString();
			back9T += (short)pTee.Holes[16].Length;
			back9P += (short) pTee.Holes[16].Par;

			lblTee18.Text = pTee.Holes[17].Length.ToString();
			HDCP18.Text = pTee.Holes[17].Handicap.ToString();
			Par18.Text = pTee.Holes[17].Par.ToString();
			back9T += (short)pTee.Holes[17].Length;
			back9P += (short) pTee.Holes[17].Par;

			lblBack9.Text = back9T.ToString();
			ParBack9.Text = back9P.ToString();
			totalT = (short)(front9T + back9T);
			totalP = (short)(front9P + back9P);
			lblTotal.Text = totalT.ToString();
			ParTotal.Text = totalP.ToString();
		}

		private void InitializeScores()
		{
			// Create Local copy of scores and strokes
			for ( int i=0;i<Global.MAX_HOLES;i++)
			{
				XScore[i] = espDB.cPlayers[index].XScores[i];
				Gross[i] = espDB.cPlayers[index].Scores[i];
				Strokes[i] = espDB.cPlayers[index].Strokes[i];
				Net[i] = (short)(Gross[i]-Strokes[i]);
			}
			// Initialize GROSS
			InitializeGrossDisplayFields();

			Gross1.Text = Gross[0].ToString();
			Gross2.Text = Gross[1].ToString();
			Gross3.Text = Gross[2].ToString();
			Gross4.Text = Gross[3].ToString();
			Gross5.Text = Gross[4].ToString();
			Gross6.Text = Gross[5].ToString();
			Gross7.Text = Gross[6].ToString();
			Gross8.Text = Gross[7].ToString();
			Gross9.Text = Gross[8].ToString();
			Gross10.Text = Gross[9].ToString();
			Gross11.Text = Gross[10].ToString();
			Gross12.Text = Gross[11].ToString();
			Gross13.Text = Gross[12].ToString();
			Gross14.Text = Gross[13].ToString();
			Gross15.Text = Gross[14].ToString();
			Gross16.Text = Gross[15].ToString();
			Gross17.Text = Gross[16].ToString();
			Gross18.Text = Gross[17].ToString();

			XScore1.Checked = XScore[0];
			XScore2.Checked = XScore[1];
			XScore3.Checked = XScore[2];
			XScore4.Checked = XScore[3];
			XScore5.Checked = XScore[4];
			XScore6.Checked = XScore[5];
			XScore7.Checked = XScore[6];
			XScore8.Checked = XScore[7];
			XScore9.Checked = XScore[8];
			XScore10.Checked = XScore[9];
			XScore11.Checked = XScore[10];
			XScore12.Checked = XScore[11];
			XScore13.Checked = XScore[12];
			XScore14.Checked = XScore[13];
			XScore15.Checked = XScore[14];
			XScore16.Checked = XScore[15];
			XScore17.Checked = XScore[16];
			XScore18.Checked = XScore[17];
		}

		private void InitializeGrossDisplayFields()
		{
			if (Strokes[0] == 0)Gross1.BackColor = Color.White;
			else Gross1.BackColor = Color.LightGray;
			if (Strokes[1] == 0)Gross2.BackColor = Color.White;
			else Gross2.BackColor = Color.LightGray;
			if (Strokes[2] == 0)Gross3.BackColor = Color.White;
			else Gross3.BackColor = Color.LightGray;
			if (Strokes[3] == 0)Gross4.BackColor = Color.White;
			else Gross4.BackColor = Color.LightGray;
			if (Strokes[4] == 0)Gross5.BackColor = Color.White;
			else Gross5.BackColor = Color.LightGray;
			if (Strokes[5] == 0)Gross6.BackColor = Color.White;
			else Gross6.BackColor = Color.LightGray;
			if (Strokes[6] == 0)Gross7.BackColor = Color.White;
			else Gross7.BackColor = Color.LightGray;
			if (Strokes[7] == 0)Gross8.BackColor = Color.White;
			else Gross8.BackColor = Color.LightGray;
			if (Strokes[8] == 0)Gross9.BackColor = Color.White;
			else Gross9.BackColor = Color.LightGray;
			if (Strokes[9] == 0)Gross10.BackColor = Color.White;
			else Gross10.BackColor = Color.LightGray;
			if (Strokes[10] == 0)Gross11.BackColor = Color.White;
			else Gross11.BackColor = Color.LightGray;
			if (Strokes[11] == 0)Gross12.BackColor = Color.White;
			else Gross12.BackColor = Color.LightGray;
			if (Strokes[12] == 0)Gross13.BackColor = Color.White;
			else Gross13.BackColor = Color.LightGray;
			if (Strokes[13] == 0)Gross14.BackColor = Color.White;
			else Gross14.BackColor = Color.LightGray;
			if (Strokes[14] == 0)Gross15.BackColor = Color.White;
			else Gross15.BackColor = Color.LightGray;
			if (Strokes[15] == 0)Gross16.BackColor = Color.White;
			else Gross16.BackColor = Color.LightGray;
			if (Strokes[16] == 0)Gross17.BackColor = Color.White;
			else Gross17.BackColor = Color.LightGray;
			if (Strokes[17] == 0)Gross18.BackColor = Color.White;
			else Gross18.BackColor = Color.LightGray;
		}

		private void UpdateScores()
		{
			short front9G = 0, back9G = 0, totalG=0;
			short front9N = 0, back9N = 0, totalN=0;

			for (int i=0;i<Global.MAX_HOLES;i++)
			{
				Net[i] = (short)(Gross[i] - Strokes[i]);
				if (i < 9){ front9G += Gross[i]; front9N += Net[i]; }
				else { back9G += Gross[i]; back9N += Net[i]; }
			}
			totalG = (short)(front9G + back9G);
			totalN = (short)(front9N + back9N);

			Net1.Text = Net[0].ToString();
			Net2.Text = Net[1].ToString();
			Net3.Text = Net[2].ToString();
			Net4.Text = Net[3].ToString();
			Net5.Text = Net[4].ToString();
			Net6.Text = Net[5].ToString();
			Net7.Text = Net[6].ToString();
			Net8.Text = Net[7].ToString();
			Net9.Text = Net[8].ToString();
			GrossFront9.Text = front9G.ToString();
			NetFront9.Text = front9N.ToString();
			Net10.Text = Net[9].ToString();
			Net11.Text = Net[10].ToString();
			Net12.Text = Net[11].ToString();
			Net13.Text = Net[12].ToString();
			Net14.Text = Net[13].ToString();
			Net15.Text = Net[14].ToString();
			Net16.Text = Net[15].ToString();
			Net17.Text = Net[16].ToString();
			Net18.Text = Net[17].ToString();
			GrossBack9.Text = back9G.ToString();
			NetBack9.Text = back9N.ToString();
			GrossTotal.Text = totalG.ToString();
			NetTotal.Text = totalN.ToString();
		}

		/// <summary>
		/// Compute Player Strokes for display of edited scores
		/// </summary>
		private void ComputeStrokes()
		{
			short		computed;
			short		strokes;						// extra strokes to give
			short		baseStrokes;				// the base number of strokes
			sbyte		currentStrokes;			// the current strokes value
			TEE_INFORMATION pTeeInfo;
			// 
			computed = Int16.Parse(txtComputedHandicap.Text);
			// calculate the base number of strokes
			// this is the number of times MAX_HOLES goes
			// into the difference between handicaps
			baseStrokes = (short)(computed / Global.MAX_HOLES);
			//
			// get the remainder - these are the odd strokes we'll
			// hand out
			// note that we take the absolute value here - we only use
			// this as a threshold
			strokes = (short)Math.Abs(computed - (baseStrokes * Global.MAX_HOLES));
			pTeeInfo = espDB.GetTeeInfo(espDB.cPlayers[index].Tees);
			// loop over the holes
			for (int ii = 0; ii < Global.MAX_HOLES; ii++) 
			{
				// if this hole's handicap is <= strokes,
				// it gets an extra, otherwise, it gets
				// the base amount
				if (pTeeInfo.Holes[ii].Handicap <= strokes) 
				{
					// set the current strokes
					// note the adjustment for negative handicaps
					if (computed < 0) 
					{
						currentStrokes = (sbyte)(baseStrokes - 1);
					} 
					else 
					{
						currentStrokes = (sbyte)(baseStrokes + 1);
					}
				} 
				else 
				{
					// set the current strokes
					currentStrokes = (sbyte)baseStrokes;
				}
				// write to the player
				Strokes[ii] = (sbyte)currentStrokes;
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			// set to Original
			InitializeHandicapAndInitials();
			InitializeScores();
			UpdateScores();
			// Make sure fields and buttons are Disabled
			ChangeSaveCancel1(false);
			ChangeSaveCancel2(false);
			this.btnExit.Focus();
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			byte handicaptype;
			// Save Data To Memory Variables and to the Database
			if (WasAnyDataChanged1())
			{
				// Update Players database table.
				if (this.rbHome.Checked) handicaptype = (byte)HANDICAP_TYPE.HomeHandicap;
				else if (this.rbIndex.Checked) handicaptype = (byte)HANDICAP_TYPE.IndexHandicap;
				else handicaptype = (byte)HANDICAP_TYPE.EstimatedScore;
				espDB.UpdatePlayerInitialsAndHandicap(PlayerID,this.txtInitials.Text, 
					Double.Parse(this.txtHandicap.Text), Int16.Parse(this.txtComputedHandicap.Text), handicaptype, this.cbPlusHandicap.Checked);

				// Set Updated Flag
				_Updated = true;
			}
			// Check to see if any Scores were changed
			if (WasAnyDataChanged2())
			{
				// Update Player Scores
				for (byte hole=0;hole<Global.MAX_HOLES;hole++)
				{
					if ((Gross[hole] != espDB.cPlayers[index].Scores[hole]) | (XScore[hole] != espDB.cPlayers[index].XScores[hole]))
						espDB.UpdatePlayerScore(espDB.cPlayers[index].PlayerID,hole,(byte)Gross[hole],XScore[hole]);
				}

				// Set Updated Flag
				_Updated = true;
			}

			// Make sure fields and buttons are Disabled
			ChangeSaveCancel1(false);
			ChangeSaveCancel2(false);
			this.btnExit.Focus();
		}

		private bool WasAnyDataChanged1()
		{
			bool retval = false;

			if (txtInitials.Text != espDB.cPlayers[index].Initials) retval = true;
			else
			{
				if (txtHandicap.Text != espDB.cPlayers[index].Handicap.ToString()) retval = true;
				else
				{
					if (txtComputedHandicap.Text != espDB.cPlayers[index].ComputedHandicap.ToString()) retval = true;
					else
					{
						if (this.cbPlusHandicap.Checked != espDB.cPlayers[index].PlusHandicap) retval = true;
						else
						{
							switch (espDB.cPlayers[index].HandicapType)
							{
								case HANDICAP_TYPE.HomeHandicap:
									if (!this.rbHome.Checked) retval = true;
									break;
								case HANDICAP_TYPE.IndexHandicap:
									if (!this.rbIndex.Checked) retval = true;
									break;
								case HANDICAP_TYPE.EstimatedScore:
									if (!this.rbAverageScore.Checked) retval = true;
									break;
							}
						}
					}
				}
			}

			return retval;
		}

		private bool WasAnyDataChanged2()
		{
			bool retval = false;

			for (int i = 0; i < Global.MAX_HOLES; i++) 
			{
				if (Gross[i] != espDB.cPlayers[index].Scores[i]) {retval = true; break; }
				if (XScore[i] != espDB.cPlayers[index].XScores[i]) {retval = true; break; }
			}

			return retval;
		}

		private void btnK1_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "1";
		}

		private void btnK2_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "2";
		}

		private void btnK3_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "3";
		}

		private void btnK4_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "4";
		}

		private void btnK5_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "5";
		}

		private void btnK6_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "6";
		}

		private void btnK7_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "7";
		}

		private void btnK8_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "8";
		}

		private void btnK9_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "9";
		}

		private void btnK0_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "0";
		}

		private void btnQ_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "Q";
		}

		private void btnW_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "W";
		}

		private void btnE_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "E";
		}

		private void btnR_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "R";
		}

		private void btnT_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "T";
		}

		private void btnY_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "Y";
		}

		private void btnU_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "U";
		}

		private void btnI_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "I";
		}

		private void btnO_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "O";
		}

		private void btnP_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "P";
		}

		private void btnA_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "A";
		}

		private void btnS_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "S";
		}

		private void btnD_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "D";
		}

		private void btnF_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "F";
		}

		private void btnG_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "G";
		}

		private void btnH_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "H";
		}

		private void btnJ_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "J";
		}

		private void btnK_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "K";
		}

		private void btnL_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "L";
		}

		private void btnZ_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "Z";
		}

		private void btnX_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "X";
		}

		private void btnC_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "C";
		}

		private void btnV_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "V";
		}

		private void btnB_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "B";
		}

		private void btnN_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "N";
		}

		private void btnM_Click(object sender, System.EventArgs e)
		{
			txtInitials.Text = txtInitials.Text + "M";
		}

		private void txtHandicap_TextChanged(object sender, System.EventArgs e)
		{
			if (txtHandicap.Text != "")
				this.txtComputedHandicap.Text = UpdateComputedHandicap(txtHandicap.Text).ToString();
		}

		private short UpdateComputedHandicap(string handicap)
		{
			double ESTIMATED_HANDICAP_FACTOR = 0.95;
			double HANDICAP_DIVISOR = 113.0;
			double ROUND_FACTOR = 0.5;
			short ComputedHandicap = 0;
			double hdcp = Double.Parse(handicap);
			TEE_INFORMATION pTee;

			pTee = espDB.GetTeeInfo(espDB.cPlayers[index].Tees);

			if (this.cbPlusHandicap.Visible) if (this.cbPlusHandicap.Checked) hdcp = -hdcp;

			if (this.rbHome.Checked) ComputedHandicap = (short)hdcp;
			else if (this.rbIndex.Checked)
			{
				if (hdcp < 0)
				{
					ComputedHandicap = (short)(((hdcp * pTee.Ratings[(int)espDB.cPlayers[index].Gender].Slope) / HANDICAP_DIVISOR) - ROUND_FACTOR);
				}
				else
				{
					ComputedHandicap = (short)(((hdcp * pTee.Ratings[(int)espDB.cPlayers[index].Gender].Slope) / HANDICAP_DIVISOR) + ROUND_FACTOR);
				}
			}
			else if (this.rbAverageScore.Checked) 
				ComputedHandicap = (short)((hdcp - pTee.Ratings[(int)espDB.cPlayers[index].Gender].CourseRating) * ESTIMATED_HANDICAP_FACTOR);

			return ComputedHandicap;
		}

		private void Gross1_Enter(object sender, System.EventArgs e)
		{
			DisplayKeypad(Gross1);
		}

		private void Gross2_Enter(object sender, System.EventArgs e)
		{
			DisplayKeypad(Gross2);
		}

		private void Gross3_Enter(object sender, System.EventArgs e)
		{
			DisplayKeypad(Gross3);
		}

		private void Gross4_Enter(object sender, System.EventArgs e)
		{
			DisplayKeypad(Gross4);
		}

		private void Gross5_Enter(object sender, System.EventArgs e)
		{
			DisplayKeypad(Gross5);
		}

		private void Gross6_Enter(object sender, System.EventArgs e)
		{
			DisplayKeypad(Gross6);
		}

		private void Gross7_Enter(object sender, System.EventArgs e)
		{
			DisplayKeypad(Gross7);
		}

		private void Gross8_Enter(object sender, System.EventArgs e)
		{
			DisplayKeypad(Gross8);
		}

		private void Gross9_Enter(object sender, System.EventArgs e)
		{
			DisplayKeypad(Gross9);
		}

		private void Gross10_Enter(object sender, System.EventArgs e)
		{
			DisplayKeypad(Gross10);
		}

		private void Gross11_Enter(object sender, System.EventArgs e)
		{
			DisplayKeypad(Gross11);
		}

		private void Gross12_Enter(object sender, System.EventArgs e)
		{
			DisplayKeypad(Gross12);
		}

		private void Gross13_Enter(object sender, System.EventArgs e)
		{
			DisplayKeypad(Gross13);
		}

		private void Gross14_Enter(object sender, System.EventArgs e)
		{
			DisplayKeypad(Gross14);
		}

		private void Gross15_Enter(object sender, System.EventArgs e)
		{
			DisplayKeypad(Gross15);
		}

		private void Gross16_Enter(object sender, System.EventArgs e)
		{
			DisplayKeypad(Gross16);
		}

		private void Gross17_Enter(object sender, System.EventArgs e)
		{
			DisplayKeypad(Gross17);
		}

		private void Gross18_Enter(object sender, System.EventArgs e)
		{
			DisplayKeypad(Gross18);
		}

		private void Gross1_TextChanged(object sender, System.EventArgs e)
		{
			if (Gross1.Text != "")
				Gross[0] = Int16.Parse(Gross1.Text);
			UpdateScores();
		}

		private void Gross2_TextChanged(object sender, System.EventArgs e)
		{
			if (Gross2.Text != "")
				Gross[1] = Int16.Parse(Gross2.Text);
			UpdateScores();
		}

		private void Gross3_TextChanged(object sender, System.EventArgs e)
		{
			if (Gross3.Text != "")
				Gross[2] = Int16.Parse(Gross3.Text);
			UpdateScores();
		}

		private void Gross4_TextChanged(object sender, System.EventArgs e)
		{
			if (Gross4.Text != "")
				Gross[3] = Int16.Parse(Gross4.Text);
			UpdateScores();
		}

		private void Gross5_TextChanged(object sender, System.EventArgs e)
		{
			if (Gross5.Text != "")
				Gross[4] = Int16.Parse(Gross5.Text);
			UpdateScores();
		}

		private void Gross6_TextChanged(object sender, System.EventArgs e)
		{
			if (Gross6.Text != "")
				Gross[5] = Int16.Parse(Gross6.Text);
			UpdateScores();
		}

		private void Gross7_TextChanged(object sender, System.EventArgs e)
		{
			if (Gross7.Text != "")
				Gross[6] = Int16.Parse(Gross7.Text);
			UpdateScores();
		}

		private void Gross8_TextChanged(object sender, System.EventArgs e)
		{
			if (Gross8.Text != "")
				Gross[7] = Int16.Parse(Gross8.Text);
			UpdateScores();
		}

		private void Gross9_TextChanged(object sender, System.EventArgs e)
		{
			if (Gross9.Text != "")
				Gross[8] = Int16.Parse(Gross9.Text);
			UpdateScores();
		}

		private void Gross10_TextChanged(object sender, System.EventArgs e)
		{
			if (Gross10.Text != "")
				Gross[9] = Int16.Parse(Gross10.Text);
			UpdateScores();
		}

		private void Gross11_TextChanged(object sender, System.EventArgs e)
		{
			if (Gross11.Text != "")
				Gross[10] = Int16.Parse(Gross11.Text);
			UpdateScores();
		}

		private void Gross12_TextChanged(object sender, System.EventArgs e)
		{
			if (Gross12.Text != "")
				Gross[11] = Int16.Parse(Gross12.Text);
			UpdateScores();
		}

		private void Gross13_TextChanged(object sender, System.EventArgs e)
		{
			if (Gross13.Text != "")
				Gross[12] = Int16.Parse(Gross13.Text);
			UpdateScores();
		}

		private void Gross14_TextChanged(object sender, System.EventArgs e)
		{
			if (Gross14.Text != "")
				Gross[13] = Int16.Parse(Gross14.Text);
			UpdateScores();
		}

		private void Gross15_TextChanged(object sender, System.EventArgs e)
		{
			if (Gross15.Text != "")
				Gross[14] = Int16.Parse(Gross15.Text);
			UpdateScores();
		}

		private void Gross16_TextChanged(object sender, System.EventArgs e)
		{
			if (Gross16.Text != "")
				Gross[15] = Int16.Parse(Gross16.Text);
			UpdateScores();
		}

		private void Gross17_TextChanged(object sender, System.EventArgs e)
		{
			if (Gross17.Text != "")
				Gross[16] = Int16.Parse(Gross17.Text);
			UpdateScores();
		}

		private void Gross18_TextChanged(object sender, System.EventArgs e)
		{
			if (Gross18.Text != "")
				Gross[17] = Int16.Parse(Gross18.Text);
			UpdateScores();
		}

		private void txtComputedHandicap_TextChanged(object sender, System.EventArgs e)
		{
			ComputeStrokes();
			this.InitializeGrossDisplayFields();
			UpdateScores();
			KeypadField = this.txtHandicap;
		}
	}
}
