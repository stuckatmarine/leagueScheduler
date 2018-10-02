using System;
using System.Windows.Forms;
using System.Drawing;

namespace league
{
	public class LaunchForm : Form
    {
        private ListBox lbNumTeams;
        private Label lNumTeams;
        private Label lNumWeeks;
        private Label lTotalGames;
        private Label lMaxGamesPerTeam;
        public Label label5;
        private ListBox lbNumWeeks;
        private ListBox lbNumFields;
        private Label lLeagueName;
        private TextBox tbLeagueName;
        public Label label2;
        private CheckBox cbDoubleHeaders;
        private ListBox lbMaxGamesPerTeam;
        private ListBox lbNumGamesPerTeamPerWeek;
        private Panel panel1;
        private Label label8;
        private Label label7;
        private Label label4;
        private ListBox lbTeam1Pref;
        private TextBox tbTeam1Name;
        private Label label3;
        private Button bRefreshTeams;
        private CheckBox cbTeam4Sunday;
        private CheckBox checkBox22;
        private CheckBox checkBox23;
        private CheckBox checkBox24;
        private CheckBox checkBox25;
        private CheckBox checkBox26;
        private CheckBox cbTeam4Monday;
        private Label label12;
        private ListBox lbTeam4Time;
        private ListBox lbTeam4Pref;
        private TextBox tbTeam4Name;
        private CheckBox cbTeam3Sunday;
        private CheckBox checkBox15;
        private CheckBox checkBox16;
        private CheckBox checkBox17;
        private CheckBox checkBox18;
        private CheckBox checkBox19;
        private CheckBox cbTeam3Monday;
        private Label label11;
        private ListBox lbTeam3Time;
        private ListBox lbTeam3Pref;
        private TextBox tbTeam3Name;
        private CheckBox cbTeam2Sunday;
        private CheckBox checkBox8;
        private CheckBox checkBox9;
        private CheckBox checkBox10;
        private CheckBox checkBox11;
        private CheckBox checkBox12;
        private CheckBox cbTeam2Monday;
        private Label label10;
        private ListBox lbTeam2Time;
        private ListBox lbTeam2Pref;
        private TextBox tbTeam2Name;
        private CheckBox cbTeam1Sunday;
        private CheckBox cbTeam1Saturday;
        private CheckBox cbTeam1Friday;
        private CheckBox cbTeam1Thursday;
        private CheckBox cbTeam1Wednesday;
        private CheckBox cbTeam1Tuesday;
        private CheckBox cbTeam1Monday;
        private Label label9;
        private Label lTeamNum1;
        private Label label6;
        private ListBox lbTeam1Time;
        private PictureBox pictureBox1;
        private Button bRefreshFieldsList;
        private PictureBox pictureBox2;
        private Panel panel3;
        private Label label23;
        private Label label21;
        private Label label20;
        private Label label15;
        private Label label14;
        private Label label13;
        private ListBox lbField1NumGamesSunday;
        private ListBox lbField1NumGamesSaturday;
        private ListBox lbField1NumGamesFriday;
        private ListBox lbField1NumGamesThursday;
        private ListBox lbField1NumGamesWednesday;
        private ListBox lbField1NumGamesTuesday;
        private ListBox lbField1NumGamesMonday;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private TextBox tbField1Name;
        private Label label22;
        private Panel panel6;
        private Label label26;
        private Panel panel5;
        private Label label25;
        private Label label24;
        private ListBox lbF1G1Timeslot;
        private TextBox tbF1G1End;
        private TextBox tbF1G1Start;
        private Panel panel9;
        private Label label40;
        private Label label41;
        private Label label42;
        private Label label43;
        private Label label44;
        private ListBox lbF1G4Timeslot;
        private TextBox tbF1G4End;
        private TextBox tbF1G4Start;
        private Panel panel8;
        private Label label35;
        private Label label36;
        private Label label37;
        private Label label38;
        private Label label39;
        private ListBox lbF1G3Timeslot;
        private TextBox tbF1G3End;
        private TextBox tbF1G3Start;
        private Panel panel7;
        private Label label30;
        private Label label31;
        private Label label32;
        private Label label33;
        private Label label34;
        private ListBox lbF1G2Timeslot;
        private TextBox tbF1G2End;
        private TextBox tbF1G2Start;
        private Label label29;
        private Label label28;
        private Label label27;
        private Panel panel2;
        private Panel panel4;
        private Label label45;
        private Label label46;
        private Label label47;
        private Label label48;
        private Label label49;
        private ListBox lbF2G4Timeslot;
        private TextBox tbF2G4End;
        private TextBox tbF2G4Start;
        private Panel panel10;
        private Label label50;
        private Label label51;
        private Label label52;
        private Label label53;
        private Label label54;
        private ListBox lbF2G3Timeslot;
        private TextBox tbF2G3End;
        private TextBox tbF2G3Start;
        private Panel panel11;
        private Label label55;
        private Label label56;
        private Label label57;
        private Label label58;
        private Label label59;
        private ListBox lbF2G2Timeslot;
        private TextBox tbF2G2End;
        private TextBox tbF2G2Start;
        private Label label60;
        private Panel panel12;
        private Label label61;
        private Label label62;
        private Label label63;
        private Label label64;
        private Label label65;
        private ListBox lbF2G1Timeslot;
        private TextBox tbF2G1End;
        private TextBox tbF2G1Start;
        private ListBox lbF2NumGamesSunday;
        private ListBox lbF2NumGamesSaturday;
        private ListBox lbF2NumGamesFriday;
        private ListBox lbF2NumGamesThursday;
        private ListBox lbF2NumGamesWednesday;
        private ListBox lbF2NumGamesTuesday;
        private ListBox lbF2NumGamesMonday;
        private Label lField2;
        private TextBox tbF2Name;
        private Button bGenerateSchedule;
        private Button bSave;
        private Button bLoad;
        private Button bClear;
        private Label label1;

        public LaunchForm()
		{
            InitializeComponent();
            Text = "Launch Form";
			CenterToScreen();
            Show();
		}

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lbNumTeams = new System.Windows.Forms.ListBox();
            this.lNumTeams = new System.Windows.Forms.Label();
            this.lNumWeeks = new System.Windows.Forms.Label();
            this.lTotalGames = new System.Windows.Forms.Label();
            this.lMaxGamesPerTeam = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbNumWeeks = new System.Windows.Forms.ListBox();
            this.lbNumFields = new System.Windows.Forms.ListBox();
            this.lLeagueName = new System.Windows.Forms.Label();
            this.tbLeagueName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbDoubleHeaders = new System.Windows.Forms.CheckBox();
            this.lbMaxGamesPerTeam = new System.Windows.Forms.ListBox();
            this.lbNumGamesPerTeamPerWeek = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bRefreshTeams = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTeam1Name = new System.Windows.Forms.TextBox();
            this.lbTeam1Pref = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbTeam1Time = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lTeamNum1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbTeam1Monday = new System.Windows.Forms.CheckBox();
            this.cbTeam1Tuesday = new System.Windows.Forms.CheckBox();
            this.cbTeam1Wednesday = new CheckBox();
            this.cbTeam1Thursday = new System.Windows.Forms.CheckBox();
            this.cbTeam1Friday = new System.Windows.Forms.CheckBox();
            this.cbTeam1Saturday = new System.Windows.Forms.CheckBox();
            this.cbTeam1Sunday = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbTeam2Sunday = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.cbTeam2Monday = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lbTeam2Time = new System.Windows.Forms.ListBox();
            this.lbTeam2Pref = new System.Windows.Forms.ListBox();
            this.tbTeam2Name = new System.Windows.Forms.TextBox();
            this.cbTeam3Sunday = new System.Windows.Forms.CheckBox();
            this.checkBox15 = new System.Windows.Forms.CheckBox();
            this.checkBox16 = new System.Windows.Forms.CheckBox();
            this.checkBox17 = new System.Windows.Forms.CheckBox();
            this.checkBox18 = new System.Windows.Forms.CheckBox();
            this.checkBox19 = new System.Windows.Forms.CheckBox();
            this.cbTeam3Monday = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lbTeam3Time = new System.Windows.Forms.ListBox();
            this.lbTeam3Pref = new System.Windows.Forms.ListBox();
            this.tbTeam3Name = new System.Windows.Forms.TextBox();
            this.cbTeam4Sunday = new System.Windows.Forms.CheckBox();
            this.checkBox22 = new System.Windows.Forms.CheckBox();
            this.checkBox23 = new System.Windows.Forms.CheckBox();
            this.checkBox24 = new System.Windows.Forms.CheckBox();
            this.checkBox25 = new System.Windows.Forms.CheckBox();
            this.checkBox26 = new System.Windows.Forms.CheckBox();
            this.cbTeam4Monday = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lbTeam4Time = new System.Windows.Forms.ListBox();
            this.lbTeam4Pref = new System.Windows.Forms.ListBox();
            this.tbTeam4Name = new System.Windows.Forms.TextBox();
            this.bRefreshFieldsList = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tbField1Name = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.lbField1NumGamesMonday = new System.Windows.Forms.ListBox();
            this.lbField1NumGamesTuesday = new System.Windows.Forms.ListBox();
            this.lbField1NumGamesWednesday = new System.Windows.Forms.ListBox();
            this.lbField1NumGamesThursday = new System.Windows.Forms.ListBox();
            this.lbField1NumGamesFriday = new System.Windows.Forms.ListBox();
            this.lbField1NumGamesSaturday = new System.Windows.Forms.ListBox();
            this.lbField1NumGamesSunday = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tbF1G1Start = new System.Windows.Forms.TextBox();
            this.tbF1G1End = new System.Windows.Forms.TextBox();
            this.lbF1G1Timeslot = new System.Windows.Forms.ListBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.lbF1G2Timeslot = new System.Windows.Forms.ListBox();
            this.tbF1G2End = new System.Windows.Forms.TextBox();
            this.tbF1G2Start = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.lbF1G3Timeslot = new System.Windows.Forms.ListBox();
            this.tbF1G3End = new System.Windows.Forms.TextBox();
            this.tbF1G3Start = new System.Windows.Forms.TextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label40 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.lbF1G4Timeslot = new System.Windows.Forms.ListBox();
            this.tbF1G4End = new System.Windows.Forms.TextBox();
            this.tbF1G4Start = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.lbF2G4Timeslot = new System.Windows.Forms.ListBox();
            this.tbF2G4End = new System.Windows.Forms.TextBox();
            this.tbF2G4Start = new System.Windows.Forms.TextBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.lbF2G3Timeslot = new System.Windows.Forms.ListBox();
            this.tbF2G3End = new System.Windows.Forms.TextBox();
            this.tbF2G3Start = new System.Windows.Forms.TextBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.lbF2G2Timeslot = new System.Windows.Forms.ListBox();
            this.tbF2G2End = new System.Windows.Forms.TextBox();
            this.tbF2G2Start = new System.Windows.Forms.TextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label61 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.lbF2G1Timeslot = new System.Windows.Forms.ListBox();
            this.tbF2G1End = new System.Windows.Forms.TextBox();
            this.tbF2G1Start = new System.Windows.Forms.TextBox();
            this.lbF2NumGamesSunday = new System.Windows.Forms.ListBox();
            this.lbF2NumGamesSaturday = new System.Windows.Forms.ListBox();
            this.lbF2NumGamesFriday = new System.Windows.Forms.ListBox();
            this.lbF2NumGamesThursday = new System.Windows.Forms.ListBox();
            this.lbF2NumGamesWednesday = new System.Windows.Forms.ListBox();
            this.lbF2NumGamesTuesday = new System.Windows.Forms.ListBox();
            this.lbF2NumGamesMonday = new System.Windows.Forms.ListBox();
            this.lField2 = new System.Windows.Forms.Label();
            this.tbF2Name = new System.Windows.Forms.TextBox();
            this.bGenerateSchedule = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.bLoad = new System.Windows.Forms.Button();
            this.bClear = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(141, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "League Scheduler v0.1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbNumTeams
            // 
            this.lbNumTeams.FormattingEnabled = true;
            this.lbNumTeams.ItemHeight = 16;
            this.lbNumTeams.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.lbNumTeams.Location = new System.Drawing.Point(138, 172);
            this.lbNumTeams.Name = "lbNumTeams";
            this.lbNumTeams.Size = new System.Drawing.Size(53, 20);
            this.lbNumTeams.TabIndex = 1;
            // 
            // lNumTeams
            // 
            this.lNumTeams.AutoSize = true;
            this.lNumTeams.Location = new System.Drawing.Point(36, 172);
            this.lNumTeams.Name = "lNumTeams";
            this.lNumTeams.Size = new System.Drawing.Size(84, 17);
            this.lNumTeams.TabIndex = 2;
            this.lNumTeams.Text = "Num Teams";
            // 
            // lNumWeeks
            // 
            this.lNumWeeks.AutoSize = true;
            this.lNumWeeks.Location = new System.Drawing.Point(36, 133);
            this.lNumWeeks.Name = "lNumWeeks";
            this.lNumWeeks.Size = new System.Drawing.Size(84, 17);
            this.lNumWeeks.TabIndex = 3;
            this.lNumWeeks.Text = "Num Weeks";
            // 
            // lTotalGames
            // 
            this.lTotalGames.AutoSize = true;
            this.lTotalGames.Location = new System.Drawing.Point(36, 433);
            this.lTotalGames.Name = "lTotalGames";
            this.lTotalGames.Size = new System.Drawing.Size(78, 17);
            this.lTotalGames.TabIndex = 4;
            this.lTotalGames.Text = "Num Fields";
            // 
            // lMaxGamesPerTeam
            // 
            this.lMaxGamesPerTeam.AutoEllipsis = true;
            this.lMaxGamesPerTeam.AutoSize = true;
            this.lMaxGamesPerTeam.Location = new System.Drawing.Point(221, 133);
            this.lMaxGamesPerTeam.Name = "lMaxGamesPerTeam";
            this.lMaxGamesPerTeam.Size = new System.Drawing.Size(148, 17);
            this.lMaxGamesPerTeam.TabIndex = 5;
            this.lMaxGamesPerTeam.Text = "Max Games Per Team";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(455, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 41);
            this.label5.TabIndex = 6;
            this.label5.Text = "Desired num games per team each week";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // lbNumWeeks
            // 
            this.lbNumWeeks.FormattingEnabled = true;
            this.lbNumWeeks.ItemHeight = 16;
            this.lbNumWeeks.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.lbNumWeeks.Location = new System.Drawing.Point(137, 133);
            this.lbNumWeeks.Name = "lbNumWeeks";
            this.lbNumWeeks.Size = new System.Drawing.Size(53, 20);
            this.lbNumWeeks.TabIndex = 8;
            // 
            // lbNumFields
            // 
            this.lbNumFields.FormattingEnabled = true;
            this.lbNumFields.ItemHeight = 16;
            this.lbNumFields.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.lbNumFields.Location = new System.Drawing.Point(132, 433);
            this.lbNumFields.Name = "lbNumFields";
            this.lbNumFields.Size = new System.Drawing.Size(53, 20);
            this.lbNumFields.TabIndex = 9;
            // 
            // lLeagueName
            // 
            this.lLeagueName.AutoSize = true;
            this.lLeagueName.Location = new System.Drawing.Point(36, 88);
            this.lLeagueName.Name = "lLeagueName";
            this.lLeagueName.Size = new System.Drawing.Size(97, 17);
            this.lLeagueName.TabIndex = 10;
            this.lLeagueName.Text = "League Name";
            // 
            // tbLeagueName
            // 
            this.tbLeagueName.Location = new System.Drawing.Point(137, 88);
            this.tbLeagueName.Name = "tbLeagueName";
            this.tbLeagueName.Size = new System.Drawing.Size(274, 22);
            this.tbLeagueName.TabIndex = 11;
            this.tbLeagueName.Text = "Leauge Name Here";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(721, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 41);
            this.label2.TabIndex = 12;
            this.label2.Text = "Double Headers?";
            // 
            // cbDoubleHeaders
            // 
            this.cbDoubleHeaders.AutoSize = true;
            this.cbDoubleHeaders.Location = new System.Drawing.Point(840, 137);
            this.cbDoubleHeaders.Name = "cbDoubleHeaders";
            this.cbDoubleHeaders.Size = new System.Drawing.Size(116, 21);
            this.cbDoubleHeaders.TabIndex = 13;
            this.cbDoubleHeaders.Text = "Check for yes";
            this.cbDoubleHeaders.UseVisualStyleBackColor = true;
            // 
            // lbMaxGamesPerTeam
            // 
            this.lbMaxGamesPerTeam.FormattingEnabled = true;
            this.lbMaxGamesPerTeam.ItemHeight = 16;
            this.lbMaxGamesPerTeam.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30"});
            this.lbMaxGamesPerTeam.Location = new System.Drawing.Point(375, 133);
            this.lbMaxGamesPerTeam.Name = "lbMaxGamesPerTeam";
            this.lbMaxGamesPerTeam.Size = new System.Drawing.Size(53, 20);
            this.lbMaxGamesPerTeam.TabIndex = 14;
            // 
            // lbNumGamesPerTeamPerWeek
            // 
            this.lbNumGamesPerTeamPerWeek.FormattingEnabled = true;
            this.lbNumGamesPerTeamPerWeek.ItemHeight = 16;
            this.lbNumGamesPerTeamPerWeek.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.lbNumGamesPerTeamPerWeek.Location = new System.Drawing.Point(629, 137);
            this.lbNumGamesPerTeamPerWeek.Name = "lbNumGamesPerTeamPerWeek";
            this.lbNumGamesPerTeamPerWeek.Size = new System.Drawing.Size(53, 20);
            this.lbNumGamesPerTeamPerWeek.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbTeam4Sunday);
            this.panel1.Controls.Add(this.checkBox22);
            this.panel1.Controls.Add(this.checkBox23);
            this.panel1.Controls.Add(this.checkBox24);
            this.panel1.Controls.Add(this.checkBox25);
            this.panel1.Controls.Add(this.checkBox26);
            this.panel1.Controls.Add(this.cbTeam4Monday);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.lbTeam4Time);
            this.panel1.Controls.Add(this.lbTeam4Pref);
            this.panel1.Controls.Add(this.tbTeam4Name);
            this.panel1.Controls.Add(this.cbTeam3Sunday);
            this.panel1.Controls.Add(this.checkBox15);
            this.panel1.Controls.Add(this.checkBox16);
            this.panel1.Controls.Add(this.checkBox17);
            this.panel1.Controls.Add(this.checkBox18);
            this.panel1.Controls.Add(this.checkBox19);
            this.panel1.Controls.Add(this.cbTeam3Monday);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.lbTeam3Time);
            this.panel1.Controls.Add(this.lbTeam3Pref);
            this.panel1.Controls.Add(this.tbTeam3Name);
            this.panel1.Controls.Add(this.cbTeam2Sunday);
            this.panel1.Controls.Add(this.checkBox8);
            this.panel1.Controls.Add(this.checkBox9);
            this.panel1.Controls.Add(this.checkBox10);
            this.panel1.Controls.Add(this.checkBox11);
            this.panel1.Controls.Add(this.checkBox12);
            this.panel1.Controls.Add(this.cbTeam2Monday);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.lbTeam2Time);
            this.panel1.Controls.Add(this.lbTeam2Pref);
            this.panel1.Controls.Add(this.tbTeam2Name);
            this.panel1.Controls.Add(this.cbTeam1Sunday);
            this.panel1.Controls.Add(this.cbTeam1Saturday);
            this.panel1.Controls.Add(this.cbTeam1Friday);
            this.panel1.Controls.Add(this.cbTeam1Thursday);
            this.panel1.Controls.Add(this.cbTeam1Wednesday);
            this.panel1.Controls.Add(this.cbTeam1Tuesday);
            this.panel1.Controls.Add(this.cbTeam1Monday);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.lTeamNum1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lbTeam1Time);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lbTeam1Pref);
            this.panel1.Controls.Add(this.tbTeam1Name);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(39, 211);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(917, 211);
            this.panel1.TabIndex = 16;
            // 
            // bRefreshTeams
            // 
            this.bRefreshTeams.Location = new System.Drawing.Point(224, 169);
            this.bRefreshTeams.Name = "bRefreshTeams";
            this.bRefreshTeams.Size = new System.Drawing.Size(145, 23);
            this.bRefreshTeams.TabIndex = 17;
            this.bRefreshTeams.Text = "Refresh Teams List";
            this.bRefreshTeams.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Team Name";
            // 
            // tbTeam1Name
            // 
            this.tbTeam1Name.Location = new System.Drawing.Point(43, 57);
            this.tbTeam1Name.Name = "tbTeam1Name";
            this.tbTeam1Name.Size = new System.Drawing.Size(274, 22);
            this.tbTeam1Name.TabIndex = 18;
            // 
            // lbTeam1Pref
            // 
            this.lbTeam1Pref.FormattingEnabled = true;
            this.lbTeam1Pref.ItemHeight = 16;
            this.lbTeam1Pref.Items.AddRange(new object[] {
            "Day",
            "Time",
            "Any"});
            this.lbTeam1Pref.Location = new System.Drawing.Point(336, 57);
            this.lbTeam1Pref.Name = "lbTeam1Pref";
            this.lbTeam1Pref.Size = new System.Drawing.Size(69, 20);
            this.lbTeam1Pref.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(635, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "Time";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(435, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 17);
            this.label7.TabIndex = 21;
            this.label7.Text = "Day(s)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(333, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "Pref Type";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // lbTeam1Time
            // 
            this.lbTeam1Time.FormattingEnabled = true;
            this.lbTeam1Time.ItemHeight = 16;
            this.lbTeam1Time.Items.AddRange(new object[] {
            "Early",
            "Late",
            "Any"});
            this.lbTeam1Time.Location = new System.Drawing.Point(638, 57);
            this.lbTeam1Time.Name = "lbTeam1Time";
            this.lbTeam1Time.Size = new System.Drawing.Size(69, 20);
            this.lbTeam1Time.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 17);
            this.label6.TabIndex = 24;
            this.label6.Text = "#";
            // 
            // lTeamNum1
            // 
            this.lTeamNum1.AutoSize = true;
            this.lTeamNum1.Location = new System.Drawing.Point(16, 60);
            this.lTeamNum1.Name = "lTeamNum1";
            this.lTeamNum1.Size = new System.Drawing.Size(16, 17);
            this.lTeamNum1.TabIndex = 25;
            this.lTeamNum1.Text = "1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(435, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(161, 17);
            this.label9.TabIndex = 27;
            this.label9.Text = "M   T    W   R    F   S    S";
            // 
            // cbTeam1Monday
            // 
            this.cbTeam1Monday.AutoSize = true;
            this.cbTeam1Monday.Location = new System.Drawing.Point(435, 60);
            this.cbTeam1Monday.Name = "cbTeam1Monday";
            this.cbTeam1Monday.Size = new System.Drawing.Size(18, 17);
            this.cbTeam1Monday.TabIndex = 28;
            this.cbTeam1Monday.UseVisualStyleBackColor = true;
            // 
            // cbTeam1Tuesday
            // 
            this.cbTeam1Tuesday.AutoSize = true;
            this.cbTeam1Tuesday.Location = new System.Drawing.Point(459, 60);
            this.cbTeam1Tuesday.Name = "cbTeam1Tuesday";
            this.cbTeam1Tuesday.Size = new System.Drawing.Size(18, 17);
            this.cbTeam1Tuesday.TabIndex = 29;
            this.cbTeam1Tuesday.UseVisualStyleBackColor = true;
            // 
            // cbTeam1Wednesday
            // 
            this.cbTeam1Wednesday.AutoSize = true;
            this.cbTeam1Wednesday.Location = new System.Drawing.Point(483, 60);
            this.cbTeam1Wednesday.Name = "cbTeam1Wednesday";
            this.cbTeam1Wednesday.Size = new System.Drawing.Size(18, 17);
            this.cbTeam1Wednesday.TabIndex = 30;
            this.cbTeam1Wednesday.UseVisualStyleBackColor = true;
            // 
            // cbTeam1Thursday
            // 
            this.cbTeam1Thursday.AutoSize = true;
            this.cbTeam1Thursday.Location = new System.Drawing.Point(507, 60);
            this.cbTeam1Thursday.Name = "cbTeam1Thursday";
            this.cbTeam1Thursday.Size = new System.Drawing.Size(18, 17);
            this.cbTeam1Thursday.TabIndex = 31;
            this.cbTeam1Thursday.UseVisualStyleBackColor = true;
            // 
            // cbTeam1Friday
            // 
            this.cbTeam1Friday.AutoSize = true;
            this.cbTeam1Friday.Location = new System.Drawing.Point(531, 60);
            this.cbTeam1Friday.Name = "cbTeam1Friday";
            this.cbTeam1Friday.Size = new System.Drawing.Size(18, 17);
            this.cbTeam1Friday.TabIndex = 32;
            this.cbTeam1Friday.UseVisualStyleBackColor = true;
            // 
            // cbTeam1Saturday
            // 
            this.cbTeam1Saturday.AutoSize = true;
            this.cbTeam1Saturday.Location = new System.Drawing.Point(555, 60);
            this.cbTeam1Saturday.Name = "cbTeam1Saturday";
            this.cbTeam1Saturday.Size = new System.Drawing.Size(18, 17);
            this.cbTeam1Saturday.TabIndex = 33;
            this.cbTeam1Saturday.UseVisualStyleBackColor = true;
            // 
            // cbTeam1Sunday
            // 
            this.cbTeam1Sunday.AutoSize = true;
            this.cbTeam1Sunday.Location = new System.Drawing.Point(579, 60);
            this.cbTeam1Sunday.Name = "cbTeam1Sunday";
            this.cbTeam1Sunday.Size = new System.Drawing.Size(18, 17);
            this.cbTeam1Sunday.TabIndex = 34;
            this.cbTeam1Sunday.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Schedulerv1.Properties.Resources.images;
            this.pictureBox1.Location = new System.Drawing.Point(39, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // cbTeam2Sunday
            // 
            this.cbTeam2Sunday.AutoSize = true;
            this.cbTeam2Sunday.Location = new System.Drawing.Point(579, 98);
            this.cbTeam2Sunday.Name = "cbTeam2Sunday";
            this.cbTeam2Sunday.Size = new System.Drawing.Size(18, 17);
            this.cbTeam2Sunday.TabIndex = 45;
            this.cbTeam2Sunday.UseVisualStyleBackColor = true;
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(555, 98);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(18, 17);
            this.checkBox8.TabIndex = 44;
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(531, 98);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(18, 17);
            this.checkBox9.TabIndex = 43;
            this.checkBox9.UseVisualStyleBackColor = true;
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(507, 98);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(18, 17);
            this.checkBox10.TabIndex = 42;
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Location = new System.Drawing.Point(483, 98);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(18, 17);
            this.checkBox11.TabIndex = 41;
            this.checkBox11.UseVisualStyleBackColor = true;
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.Location = new System.Drawing.Point(459, 98);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(18, 17);
            this.checkBox12.TabIndex = 40;
            this.checkBox12.UseVisualStyleBackColor = true;
            // 
            // cbTeam2Monday
            // 
            this.cbTeam2Monday.AutoSize = true;
            this.cbTeam2Monday.Location = new System.Drawing.Point(435, 98);
            this.cbTeam2Monday.Name = "cbTeam2Monday";
            this.cbTeam2Monday.Size = new System.Drawing.Size(18, 17);
            this.cbTeam2Monday.TabIndex = 39;
            this.cbTeam2Monday.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 98);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(16, 17);
            this.label10.TabIndex = 38;
            this.label10.Text = "2";
            // 
            // lbTeam2Time
            // 
            this.lbTeam2Time.FormattingEnabled = true;
            this.lbTeam2Time.ItemHeight = 16;
            this.lbTeam2Time.Items.AddRange(new object[] {
            "Early",
            "Late"});
            this.lbTeam2Time.Location = new System.Drawing.Point(638, 95);
            this.lbTeam2Time.Name = "lbTeam2Time";
            this.lbTeam2Time.Size = new System.Drawing.Size(69, 20);
            this.lbTeam2Time.TabIndex = 37;
            // 
            // lbTeam2Pref
            // 
            this.lbTeam2Pref.FormattingEnabled = true;
            this.lbTeam2Pref.ItemHeight = 16;
            this.lbTeam2Pref.Items.AddRange(new object[] {
            "Day",
            "Time",
            "Any"});
            this.lbTeam2Pref.Location = new System.Drawing.Point(336, 95);
            this.lbTeam2Pref.Name = "lbTeam2Pref";
            this.lbTeam2Pref.Size = new System.Drawing.Size(69, 20);
            this.lbTeam2Pref.TabIndex = 36;
            // 
            // tbTeam2Name
            // 
            this.tbTeam2Name.Location = new System.Drawing.Point(43, 95);
            this.tbTeam2Name.Name = "tbTeam2Name";
            this.tbTeam2Name.Size = new System.Drawing.Size(274, 22);
            this.tbTeam2Name.TabIndex = 35;
            // 
            // cbTeam3Sunday
            // 
            this.cbTeam3Sunday.AutoSize = true;
            this.cbTeam3Sunday.Location = new System.Drawing.Point(579, 138);
            this.cbTeam3Sunday.Name = "cbTeam3Sunday";
            this.cbTeam3Sunday.Size = new System.Drawing.Size(18, 17);
            this.cbTeam3Sunday.TabIndex = 56;
            this.cbTeam3Sunday.UseVisualStyleBackColor = true;
            // 
            // checkBox15
            // 
            this.checkBox15.AutoSize = true;
            this.checkBox15.Location = new System.Drawing.Point(555, 138);
            this.checkBox15.Name = "checkBox15";
            this.checkBox15.Size = new System.Drawing.Size(18, 17);
            this.checkBox15.TabIndex = 55;
            this.checkBox15.UseVisualStyleBackColor = true;
            // 
            // checkBox16
            // 
            this.checkBox16.AutoSize = true;
            this.checkBox16.Location = new System.Drawing.Point(531, 138);
            this.checkBox16.Name = "checkBox16";
            this.checkBox16.Size = new System.Drawing.Size(18, 17);
            this.checkBox16.TabIndex = 54;
            this.checkBox16.UseVisualStyleBackColor = true;
            // 
            // checkBox17
            // 
            this.checkBox17.AutoSize = true;
            this.checkBox17.Location = new System.Drawing.Point(507, 138);
            this.checkBox17.Name = "checkBox17";
            this.checkBox17.Size = new System.Drawing.Size(18, 17);
            this.checkBox17.TabIndex = 53;
            this.checkBox17.UseVisualStyleBackColor = true;
            // 
            // checkBox18
            // 
            this.checkBox18.AutoSize = true;
            this.checkBox18.Location = new System.Drawing.Point(483, 138);
            this.checkBox18.Name = "checkBox18";
            this.checkBox18.Size = new System.Drawing.Size(18, 17);
            this.checkBox18.TabIndex = 52;
            this.checkBox18.UseVisualStyleBackColor = true;
            // 
            // checkBox19
            // 
            this.checkBox19.AutoSize = true;
            this.checkBox19.Location = new System.Drawing.Point(459, 138);
            this.checkBox19.Name = "checkBox19";
            this.checkBox19.Size = new System.Drawing.Size(18, 17);
            this.checkBox19.TabIndex = 51;
            this.checkBox19.UseVisualStyleBackColor = true;
            // 
            // cbTeam3Monday
            // 
            this.cbTeam3Monday.AutoSize = true;
            this.cbTeam3Monday.Location = new System.Drawing.Point(435, 138);
            this.cbTeam3Monday.Name = "cbTeam3Monday";
            this.cbTeam3Monday.Size = new System.Drawing.Size(18, 17);
            this.cbTeam3Monday.TabIndex = 50;
            this.cbTeam3Monday.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 138);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 17);
            this.label11.TabIndex = 49;
            this.label11.Text = "3";
            // 
            // lbTeam3Time
            // 
            this.lbTeam3Time.FormattingEnabled = true;
            this.lbTeam3Time.ItemHeight = 16;
            this.lbTeam3Time.Items.AddRange(new object[] {
            "Early",
            "Late"});
            this.lbTeam3Time.Location = new System.Drawing.Point(638, 135);
            this.lbTeam3Time.Name = "lbTeam3Time";
            this.lbTeam3Time.Size = new System.Drawing.Size(69, 20);
            this.lbTeam3Time.TabIndex = 48;
            // 
            // lbTeam3Pref
            // 
            this.lbTeam3Pref.FormattingEnabled = true;
            this.lbTeam3Pref.ItemHeight = 16;
            this.lbTeam3Pref.Items.AddRange(new object[] {
            "Day",
            "Time",
            "Any"});
            this.lbTeam3Pref.Location = new System.Drawing.Point(336, 135);
            this.lbTeam3Pref.Name = "lbTeam3Pref";
            this.lbTeam3Pref.Size = new System.Drawing.Size(69, 20);
            this.lbTeam3Pref.TabIndex = 47;
            // 
            // tbTeam3Name
            // 
            this.tbTeam3Name.Location = new System.Drawing.Point(43, 135);
            this.tbTeam3Name.Name = "tbTeam3Name";
            this.tbTeam3Name.Size = new System.Drawing.Size(274, 22);
            this.tbTeam3Name.TabIndex = 46;
            // 
            // cbTeam4Sunday
            // 
            this.cbTeam4Sunday.AutoSize = true;
            this.cbTeam4Sunday.Location = new System.Drawing.Point(579, 173);
            this.cbTeam4Sunday.Name = "cbTeam4Sunday";
            this.cbTeam4Sunday.Size = new System.Drawing.Size(18, 17);
            this.cbTeam4Sunday.TabIndex = 67;
            this.cbTeam4Sunday.UseVisualStyleBackColor = true;
            // 
            // checkBox22
            // 
            this.checkBox22.AutoSize = true;
            this.checkBox22.Location = new System.Drawing.Point(555, 173);
            this.checkBox22.Name = "checkBox22";
            this.checkBox22.Size = new System.Drawing.Size(18, 17);
            this.checkBox22.TabIndex = 66;
            this.checkBox22.UseVisualStyleBackColor = true;
            // 
            // checkBox23
            // 
            this.checkBox23.AutoSize = true;
            this.checkBox23.Location = new System.Drawing.Point(531, 173);
            this.checkBox23.Name = "checkBox23";
            this.checkBox23.Size = new System.Drawing.Size(18, 17);
            this.checkBox23.TabIndex = 65;
            this.checkBox23.UseVisualStyleBackColor = true;
            // 
            // checkBox24
            // 
            this.checkBox24.AutoSize = true;
            this.checkBox24.Location = new System.Drawing.Point(507, 173);
            this.checkBox24.Name = "checkBox24";
            this.checkBox24.Size = new System.Drawing.Size(18, 17);
            this.checkBox24.TabIndex = 64;
            this.checkBox24.UseVisualStyleBackColor = true;
            // 
            // checkBox25
            // 
            this.checkBox25.AutoSize = true;
            this.checkBox25.Location = new System.Drawing.Point(483, 173);
            this.checkBox25.Name = "checkBox25";
            this.checkBox25.Size = new System.Drawing.Size(18, 17);
            this.checkBox25.TabIndex = 63;
            this.checkBox25.UseVisualStyleBackColor = true;
            // 
            // checkBox26
            // 
            this.checkBox26.AutoSize = true;
            this.checkBox26.Location = new System.Drawing.Point(459, 173);
            this.checkBox26.Name = "checkBox26";
            this.checkBox26.Size = new System.Drawing.Size(18, 17);
            this.checkBox26.TabIndex = 62;
            this.checkBox26.UseVisualStyleBackColor = true;
            // 
            // cbTeam4Monday
            // 
            this.cbTeam4Monday.AutoSize = true;
            this.cbTeam4Monday.Location = new System.Drawing.Point(435, 173);
            this.cbTeam4Monday.Name = "cbTeam4Monday";
            this.cbTeam4Monday.Size = new System.Drawing.Size(18, 17);
            this.cbTeam4Monday.TabIndex = 61;
            this.cbTeam4Monday.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 173);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 17);
            this.label12.TabIndex = 60;
            this.label12.Text = "4";
            // 
            // lbTeam4Time
            // 
            this.lbTeam4Time.FormattingEnabled = true;
            this.lbTeam4Time.ItemHeight = 16;
            this.lbTeam4Time.Items.AddRange(new object[] {
            "Early",
            "Late"});
            this.lbTeam4Time.Location = new System.Drawing.Point(638, 170);
            this.lbTeam4Time.Name = "lbTeam4Time";
            this.lbTeam4Time.Size = new System.Drawing.Size(69, 20);
            this.lbTeam4Time.TabIndex = 59;
            // 
            // lbTeam4Pref
            // 
            this.lbTeam4Pref.FormattingEnabled = true;
            this.lbTeam4Pref.ItemHeight = 16;
            this.lbTeam4Pref.Items.AddRange(new object[] {
            "Day",
            "Time",
            "Any"});
            this.lbTeam4Pref.Location = new System.Drawing.Point(336, 170);
            this.lbTeam4Pref.Name = "lbTeam4Pref";
            this.lbTeam4Pref.Size = new System.Drawing.Size(69, 20);
            this.lbTeam4Pref.TabIndex = 58;
            // 
            // tbTeam4Name
            // 
            this.tbTeam4Name.Location = new System.Drawing.Point(43, 170);
            this.tbTeam4Name.Name = "tbTeam4Name";
            this.tbTeam4Name.Size = new System.Drawing.Size(274, 22);
            this.tbTeam4Name.TabIndex = 57;
            // 
            // bRefreshFieldsList
            // 
            this.bRefreshFieldsList.Location = new System.Drawing.Point(224, 433);
            this.bRefreshFieldsList.Name = "bRefreshFieldsList";
            this.bRefreshFieldsList.Size = new System.Drawing.Size(145, 23);
            this.bRefreshFieldsList.TabIndex = 19;
            this.bRefreshFieldsList.Text = "Refresh Fields List";
            this.bRefreshFieldsList.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pictureBox2.Location = new System.Drawing.Point(39, 62);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(917, 10);
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.lbF2NumGamesSunday);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.lbF2NumGamesSaturday);
            this.panel3.Controls.Add(this.label23);
            this.panel3.Controls.Add(this.lbF2NumGamesFriday);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Controls.Add(this.lbF2NumGamesThursday);
            this.panel3.Controls.Add(this.label20);
            this.panel3.Controls.Add(this.lbF2NumGamesWednesday);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.lbF2NumGamesTuesday);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.lbF2NumGamesMonday);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.lField2);
            this.panel3.Controls.Add(this.lbField1NumGamesSunday);
            this.panel3.Controls.Add(this.tbF2Name);
            this.panel3.Controls.Add(this.lbField1NumGamesSaturday);
            this.panel3.Controls.Add(this.lbField1NumGamesFriday);
            this.panel3.Controls.Add(this.lbField1NumGamesThursday);
            this.panel3.Controls.Add(this.lbField1NumGamesWednesday);
            this.panel3.Controls.Add(this.lbField1NumGamesTuesday);
            this.panel3.Controls.Add(this.lbField1NumGamesMonday);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.tbField1Name);
            this.panel3.Controls.Add(this.label22);
            this.panel3.Location = new System.Drawing.Point(39, 463);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(917, 545);
            this.panel3.TabIndex = 68;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(353, 27);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(19, 17);
            this.label16.TabIndex = 27;
            this.label16.Text = "M";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(16, 46);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(16, 17);
            this.label17.TabIndex = 25;
            this.label17.Text = "1";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(16, 10);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(16, 17);
            this.label18.TabIndex = 24;
            this.label18.Text = "#";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(480, 5);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(145, 17);
            this.label19.TabIndex = 22;
            this.label19.Text = "Num games each day";
            // 
            // tbField1Name
            // 
            this.tbField1Name.Location = new System.Drawing.Point(43, 43);
            this.tbField1Name.Name = "tbField1Name";
            this.tbField1Name.Size = new System.Drawing.Size(274, 22);
            this.tbField1Name.TabIndex = 18;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(40, 10);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(79, 17);
            this.label22.TabIndex = 18;
            this.label22.Text = "Field Name";
            // 
            // lbField1NumGamesMonday
            // 
            this.lbField1NumGamesMonday.FormattingEnabled = true;
            this.lbField1NumGamesMonday.ItemHeight = 16;
            this.lbField1NumGamesMonday.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.lbField1NumGamesMonday.Location = new System.Drawing.Point(332, 46);
            this.lbField1NumGamesMonday.Name = "lbField1NumGamesMonday";
            this.lbField1NumGamesMonday.Size = new System.Drawing.Size(53, 20);
            this.lbField1NumGamesMonday.TabIndex = 29;
            // 
            // lbField1NumGamesTuesday
            // 
            this.lbField1NumGamesTuesday.FormattingEnabled = true;
            this.lbField1NumGamesTuesday.ItemHeight = 16;
            this.lbField1NumGamesTuesday.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.lbField1NumGamesTuesday.Location = new System.Drawing.Point(402, 46);
            this.lbField1NumGamesTuesday.Name = "lbField1NumGamesTuesday";
            this.lbField1NumGamesTuesday.Size = new System.Drawing.Size(53, 20);
            this.lbField1NumGamesTuesday.TabIndex = 30;
            // 
            // lbField1NumGamesWednesday
            // 
            this.lbField1NumGamesWednesday.FormattingEnabled = true;
            this.lbField1NumGamesWednesday.ItemHeight = 16;
            this.lbField1NumGamesWednesday.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.lbField1NumGamesWednesday.Location = new System.Drawing.Point(472, 46);
            this.lbField1NumGamesWednesday.Name = "lbField1NumGamesWednesday";
            this.lbField1NumGamesWednesday.Size = new System.Drawing.Size(53, 20);
            this.lbField1NumGamesWednesday.TabIndex = 31;
            // 
            // lbField1NumGamesThursday
            // 
            this.lbField1NumGamesThursday.FormattingEnabled = true;
            this.lbField1NumGamesThursday.ItemHeight = 16;
            this.lbField1NumGamesThursday.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.lbField1NumGamesThursday.Location = new System.Drawing.Point(542, 46);
            this.lbField1NumGamesThursday.Name = "lbField1NumGamesThursday";
            this.lbField1NumGamesThursday.Size = new System.Drawing.Size(53, 20);
            this.lbField1NumGamesThursday.TabIndex = 32;
            // 
            // lbField1NumGamesFriday
            // 
            this.lbField1NumGamesFriday.FormattingEnabled = true;
            this.lbField1NumGamesFriday.ItemHeight = 16;
            this.lbField1NumGamesFriday.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.lbField1NumGamesFriday.Location = new System.Drawing.Point(612, 46);
            this.lbField1NumGamesFriday.Name = "lbField1NumGamesFriday";
            this.lbField1NumGamesFriday.Size = new System.Drawing.Size(53, 20);
            this.lbField1NumGamesFriday.TabIndex = 33;
            // 
            // lbField1NumGamesSaturday
            // 
            this.lbField1NumGamesSaturday.FormattingEnabled = true;
            this.lbField1NumGamesSaturday.ItemHeight = 16;
            this.lbField1NumGamesSaturday.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.lbField1NumGamesSaturday.Location = new System.Drawing.Point(682, 46);
            this.lbField1NumGamesSaturday.Name = "lbField1NumGamesSaturday";
            this.lbField1NumGamesSaturday.Size = new System.Drawing.Size(53, 20);
            this.lbField1NumGamesSaturday.TabIndex = 34;
            // 
            // lbField1NumGamesSunday
            // 
            this.lbField1NumGamesSunday.FormattingEnabled = true;
            this.lbField1NumGamesSunday.ItemHeight = 16;
            this.lbField1NumGamesSunday.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.lbField1NumGamesSunday.Location = new System.Drawing.Point(752, 46);
            this.lbField1NumGamesSunday.Name = "lbField1NumGamesSunday";
            this.lbField1NumGamesSunday.Size = new System.Drawing.Size(53, 20);
            this.lbField1NumGamesSunday.TabIndex = 35;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(423, 27);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 17);
            this.label13.TabIndex = 36;
            this.label13.Text = "T";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(491, 27);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 17);
            this.label14.TabIndex = 37;
            this.label14.Text = "W";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(563, 27);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(18, 17);
            this.label15.TabIndex = 38;
            this.label15.Text = "R";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(632, 27);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(16, 17);
            this.label20.TabIndex = 39;
            this.label20.Text = "F";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(699, 27);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(17, 17);
            this.label21.TabIndex = 40;
            this.label21.Text = "S";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(767, 27);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(17, 17);
            this.label23.TabIndex = 41;
            this.label23.Text = "S";
            this.label23.Click += new System.EventHandler(this.label23_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label29);
            this.panel5.Controls.Add(this.label28);
            this.panel5.Controls.Add(this.label27);
            this.panel5.Controls.Add(this.label25);
            this.panel5.Controls.Add(this.label24);
            this.panel5.Controls.Add(this.lbF1G1Timeslot);
            this.panel5.Controls.Add(this.tbF1G1End);
            this.panel5.Controls.Add(this.tbF1G1Start);
            this.panel5.Location = new System.Drawing.Point(14, 39);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(390, 70);
            this.panel5.TabIndex = 42;
            // 
            // tbF1G1Start
            // 
            this.tbF1G1Start.Location = new System.Drawing.Point(96, 39);
            this.tbF1G1Start.Name = "tbF1G1Start";
            this.tbF1G1Start.Size = new System.Drawing.Size(67, 22);
            this.tbF1G1Start.TabIndex = 19;
            // 
            // tbF1G1End
            // 
            this.tbF1G1End.Location = new System.Drawing.Point(206, 39);
            this.tbF1G1End.Name = "tbF1G1End";
            this.tbF1G1End.Size = new System.Drawing.Size(67, 22);
            this.tbF1G1End.TabIndex = 20;
            // 
            // lbF1G1Timeslot
            // 
            this.lbF1G1Timeslot.FormattingEnabled = true;
            this.lbF1G1Timeslot.ItemHeight = 16;
            this.lbF1G1Timeslot.Items.AddRange(new object[] {
            "Early",
            "Late"});
            this.lbF1G1Timeslot.Location = new System.Drawing.Point(314, 39);
            this.lbF1G1Timeslot.Name = "lbF1G1Timeslot";
            this.lbF1G1Timeslot.Size = new System.Drawing.Size(69, 20);
            this.lbF1G1Timeslot.TabIndex = 68;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel9);
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.label26);
            this.panel6.Controls.Add(this.panel5);
            this.panel6.Location = new System.Drawing.Point(16, 77);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(877, 210);
            this.panel6.TabIndex = 43;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(94, 10);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(38, 17);
            this.label24.TabIndex = 69;
            this.label24.Text = "Start";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(203, 10);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(33, 17);
            this.label25.TabIndex = 70;
            this.label25.Text = "End";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(11, 10);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(58, 17);
            this.label26.TabIndex = 70;
            this.label26.Text = "Monday";
            this.label26.Click += new System.EventHandler(this.label26_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(10, 10);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(58, 17);
            this.label27.TabIndex = 71;
            this.label27.Text = "Game #";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(29, 39);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(16, 17);
            this.label28.TabIndex = 72;
            this.label28.Text = "1";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(309, 10);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(72, 17);
            this.label29.TabIndex = 73;
            this.label29.Text = "Early/Late";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label30);
            this.panel7.Controls.Add(this.label31);
            this.panel7.Controls.Add(this.label32);
            this.panel7.Controls.Add(this.label33);
            this.panel7.Controls.Add(this.label34);
            this.panel7.Controls.Add(this.lbF1G2Timeslot);
            this.panel7.Controls.Add(this.tbF1G2End);
            this.panel7.Controls.Add(this.tbF1G2Start);
            this.panel7.Location = new System.Drawing.Point(456, 39);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(390, 70);
            this.panel7.TabIndex = 74;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(309, 10);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(72, 17);
            this.label30.TabIndex = 73;
            this.label30.Text = "Early/Late";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(29, 39);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(16, 17);
            this.label31.TabIndex = 72;
            this.label31.Text = "2";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(10, 10);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(58, 17);
            this.label32.TabIndex = 71;
            this.label32.Text = "Game #";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(203, 10);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(33, 17);
            this.label33.TabIndex = 70;
            this.label33.Text = "End";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(94, 10);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(38, 17);
            this.label34.TabIndex = 69;
            this.label34.Text = "Start";
            // 
            // lbF1G2Timeslot
            // 
            this.lbF1G2Timeslot.FormattingEnabled = true;
            this.lbF1G2Timeslot.ItemHeight = 16;
            this.lbF1G2Timeslot.Items.AddRange(new object[] {
            "Early",
            "Late"});
            this.lbF1G2Timeslot.Location = new System.Drawing.Point(314, 39);
            this.lbF1G2Timeslot.Name = "lbF1G2Timeslot";
            this.lbF1G2Timeslot.Size = new System.Drawing.Size(69, 20);
            this.lbF1G2Timeslot.TabIndex = 68;
            // 
            // tbF1G2End
            // 
            this.tbF1G2End.Location = new System.Drawing.Point(206, 39);
            this.tbF1G2End.Name = "tbF1G2End";
            this.tbF1G2End.Size = new System.Drawing.Size(67, 22);
            this.tbF1G2End.TabIndex = 20;
            // 
            // tbF1G2Start
            // 
            this.tbF1G2Start.Location = new System.Drawing.Point(96, 39);
            this.tbF1G2Start.Name = "tbF1G2Start";
            this.tbF1G2Start.Size = new System.Drawing.Size(67, 22);
            this.tbF1G2Start.TabIndex = 19;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.label35);
            this.panel8.Controls.Add(this.label36);
            this.panel8.Controls.Add(this.label37);
            this.panel8.Controls.Add(this.label38);
            this.panel8.Controls.Add(this.label39);
            this.panel8.Controls.Add(this.lbF1G3Timeslot);
            this.panel8.Controls.Add(this.tbF1G3End);
            this.panel8.Controls.Add(this.tbF1G3Start);
            this.panel8.Location = new System.Drawing.Point(14, 135);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(390, 70);
            this.panel8.TabIndex = 74;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(309, 10);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(72, 17);
            this.label35.TabIndex = 73;
            this.label35.Text = "Early/Late";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(29, 39);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(16, 17);
            this.label36.TabIndex = 72;
            this.label36.Text = "3";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(10, 10);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(58, 17);
            this.label37.TabIndex = 71;
            this.label37.Text = "Game #";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(203, 10);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(33, 17);
            this.label38.TabIndex = 70;
            this.label38.Text = "End";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(94, 10);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(38, 17);
            this.label39.TabIndex = 69;
            this.label39.Text = "Start";
            // 
            // lbF1G3Timeslot
            // 
            this.lbF1G3Timeslot.FormattingEnabled = true;
            this.lbF1G3Timeslot.ItemHeight = 16;
            this.lbF1G3Timeslot.Items.AddRange(new object[] {
            "Early",
            "Late"});
            this.lbF1G3Timeslot.Location = new System.Drawing.Point(314, 39);
            this.lbF1G3Timeslot.Name = "lbF1G3Timeslot";
            this.lbF1G3Timeslot.Size = new System.Drawing.Size(69, 20);
            this.lbF1G3Timeslot.TabIndex = 68;
            // 
            // tbF1G3End
            // 
            this.tbF1G3End.Location = new System.Drawing.Point(206, 39);
            this.tbF1G3End.Name = "tbF1G3End";
            this.tbF1G3End.Size = new System.Drawing.Size(67, 22);
            this.tbF1G3End.TabIndex = 20;
            // 
            // tbF1G3Start
            // 
            this.tbF1G3Start.Location = new System.Drawing.Point(96, 39);
            this.tbF1G3Start.Name = "tbF1G3Start";
            this.tbF1G3Start.Size = new System.Drawing.Size(67, 22);
            this.tbF1G3Start.TabIndex = 19;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label40);
            this.panel9.Controls.Add(this.label41);
            this.panel9.Controls.Add(this.label42);
            this.panel9.Controls.Add(this.label43);
            this.panel9.Controls.Add(this.label44);
            this.panel9.Controls.Add(this.lbF1G4Timeslot);
            this.panel9.Controls.Add(this.tbF1G4End);
            this.panel9.Controls.Add(this.tbF1G4Start);
            this.panel9.Location = new System.Drawing.Point(456, 135);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(390, 70);
            this.panel9.TabIndex = 74;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(309, 10);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(72, 17);
            this.label40.TabIndex = 73;
            this.label40.Text = "Early/Late";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(29, 39);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(16, 17);
            this.label41.TabIndex = 72;
            this.label41.Text = "4";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(10, 10);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(58, 17);
            this.label42.TabIndex = 71;
            this.label42.Text = "Game #";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(203, 10);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(33, 17);
            this.label43.TabIndex = 70;
            this.label43.Text = "End";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(94, 10);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(38, 17);
            this.label44.TabIndex = 69;
            this.label44.Text = "Start";
            // 
            // lbF1G4Timeslot
            // 
            this.lbF1G4Timeslot.FormattingEnabled = true;
            this.lbF1G4Timeslot.ItemHeight = 16;
            this.lbF1G4Timeslot.Items.AddRange(new object[] {
            "Early",
            "Late"});
            this.lbF1G4Timeslot.Location = new System.Drawing.Point(314, 39);
            this.lbF1G4Timeslot.Name = "lbF1G4Timeslot";
            this.lbF1G4Timeslot.Size = new System.Drawing.Size(69, 20);
            this.lbF1G4Timeslot.TabIndex = 68;
            // 
            // tbF1G4End
            // 
            this.tbF1G4End.Location = new System.Drawing.Point(206, 39);
            this.tbF1G4End.Name = "tbF1G4End";
            this.tbF1G4End.Size = new System.Drawing.Size(67, 22);
            this.tbF1G4End.TabIndex = 20;
            // 
            // tbF1G4Start
            // 
            this.tbF1G4Start.Location = new System.Drawing.Point(96, 39);
            this.tbF1G4Start.Name = "tbF1G4Start";
            this.tbF1G4Start.Size = new System.Drawing.Size(67, 22);
            this.tbF1G4Start.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel10);
            this.panel2.Controls.Add(this.panel11);
            this.panel2.Controls.Add(this.label60);
            this.panel2.Controls.Add(this.panel12);
            this.panel2.Location = new System.Drawing.Point(16, 327);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(877, 210);
            this.panel2.TabIndex = 84;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label45);
            this.panel4.Controls.Add(this.label46);
            this.panel4.Controls.Add(this.label47);
            this.panel4.Controls.Add(this.label48);
            this.panel4.Controls.Add(this.label49);
            this.panel4.Controls.Add(this.lbF2G4Timeslot);
            this.panel4.Controls.Add(this.tbF2G4End);
            this.panel4.Controls.Add(this.tbF2G4Start);
            this.panel4.Location = new System.Drawing.Point(456, 135);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(390, 70);
            this.panel4.TabIndex = 74;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(309, 10);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(72, 17);
            this.label45.TabIndex = 73;
            this.label45.Text = "Early/Late";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(29, 39);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(16, 17);
            this.label46.TabIndex = 72;
            this.label46.Text = "4";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(10, 10);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(58, 17);
            this.label47.TabIndex = 71;
            this.label47.Text = "Game #";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(203, 10);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(33, 17);
            this.label48.TabIndex = 70;
            this.label48.Text = "End";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(94, 10);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(38, 17);
            this.label49.TabIndex = 69;
            this.label49.Text = "Start";
            // 
            // lbF2G4Timeslot
            // 
            this.lbF2G4Timeslot.FormattingEnabled = true;
            this.lbF2G4Timeslot.ItemHeight = 16;
            this.lbF2G4Timeslot.Items.AddRange(new object[] {
            "Early",
            "Late"});
            this.lbF2G4Timeslot.Location = new System.Drawing.Point(314, 39);
            this.lbF2G4Timeslot.Name = "lbF2G4Timeslot";
            this.lbF2G4Timeslot.Size = new System.Drawing.Size(69, 20);
            this.lbF2G4Timeslot.TabIndex = 68;
            // 
            // tbF2G4End
            // 
            this.tbF2G4End.Location = new System.Drawing.Point(206, 39);
            this.tbF2G4End.Name = "tbF2G4End";
            this.tbF2G4End.Size = new System.Drawing.Size(67, 22);
            this.tbF2G4End.TabIndex = 20;
            // 
            // tbF2G4Start
            // 
            this.tbF2G4Start.Location = new System.Drawing.Point(96, 39);
            this.tbF2G4Start.Name = "tbF2G4Start";
            this.tbF2G4Start.Size = new System.Drawing.Size(67, 22);
            this.tbF2G4Start.TabIndex = 19;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.label50);
            this.panel10.Controls.Add(this.label51);
            this.panel10.Controls.Add(this.label52);
            this.panel10.Controls.Add(this.label53);
            this.panel10.Controls.Add(this.label54);
            this.panel10.Controls.Add(this.lbF2G3Timeslot);
            this.panel10.Controls.Add(this.tbF2G3End);
            this.panel10.Controls.Add(this.tbF2G3Start);
            this.panel10.Location = new System.Drawing.Point(14, 135);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(390, 70);
            this.panel10.TabIndex = 74;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(309, 10);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(72, 17);
            this.label50.TabIndex = 73;
            this.label50.Text = "Early/Late";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(29, 39);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(16, 17);
            this.label51.TabIndex = 72;
            this.label51.Text = "3";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(10, 10);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(58, 17);
            this.label52.TabIndex = 71;
            this.label52.Text = "Game #";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(203, 10);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(33, 17);
            this.label53.TabIndex = 70;
            this.label53.Text = "End";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(94, 10);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(38, 17);
            this.label54.TabIndex = 69;
            this.label54.Text = "Start";
            // 
            // lbF2G3Timeslot
            // 
            this.lbF2G3Timeslot.FormattingEnabled = true;
            this.lbF2G3Timeslot.ItemHeight = 16;
            this.lbF2G3Timeslot.Items.AddRange(new object[] {
            "Early",
            "Late"});
            this.lbF2G3Timeslot.Location = new System.Drawing.Point(314, 39);
            this.lbF2G3Timeslot.Name = "lbF2G3Timeslot";
            this.lbF2G3Timeslot.Size = new System.Drawing.Size(69, 20);
            this.lbF2G3Timeslot.TabIndex = 68;
            // 
            // tbF2G3End
            // 
            this.tbF2G3End.Location = new System.Drawing.Point(206, 39);
            this.tbF2G3End.Name = "tbF2G3End";
            this.tbF2G3End.Size = new System.Drawing.Size(67, 22);
            this.tbF2G3End.TabIndex = 20;
            // 
            // tbF2G3Start
            // 
            this.tbF2G3Start.Location = new System.Drawing.Point(96, 39);
            this.tbF2G3Start.Name = "tbF2G3Start";
            this.tbF2G3Start.Size = new System.Drawing.Size(67, 22);
            this.tbF2G3Start.TabIndex = 19;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.label55);
            this.panel11.Controls.Add(this.label56);
            this.panel11.Controls.Add(this.label57);
            this.panel11.Controls.Add(this.label58);
            this.panel11.Controls.Add(this.label59);
            this.panel11.Controls.Add(this.lbF2G2Timeslot);
            this.panel11.Controls.Add(this.tbF2G2End);
            this.panel11.Controls.Add(this.tbF2G2Start);
            this.panel11.Location = new System.Drawing.Point(456, 39);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(390, 70);
            this.panel11.TabIndex = 74;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(309, 10);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(72, 17);
            this.label55.TabIndex = 73;
            this.label55.Text = "Early/Late";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(29, 39);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(16, 17);
            this.label56.TabIndex = 72;
            this.label56.Text = "2";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(10, 10);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(58, 17);
            this.label57.TabIndex = 71;
            this.label57.Text = "Game #";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(203, 10);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(33, 17);
            this.label58.TabIndex = 70;
            this.label58.Text = "End";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(94, 10);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(38, 17);
            this.label59.TabIndex = 69;
            this.label59.Text = "Start";
            // 
            // lbF2G2Timeslot
            // 
            this.lbF2G2Timeslot.FormattingEnabled = true;
            this.lbF2G2Timeslot.ItemHeight = 16;
            this.lbF2G2Timeslot.Items.AddRange(new object[] {
            "Early",
            "Late"});
            this.lbF2G2Timeslot.Location = new System.Drawing.Point(314, 39);
            this.lbF2G2Timeslot.Name = "lbF2G2Timeslot";
            this.lbF2G2Timeslot.Size = new System.Drawing.Size(69, 20);
            this.lbF2G2Timeslot.TabIndex = 68;
            // 
            // tbF2G2End
            // 
            this.tbF2G2End.Location = new System.Drawing.Point(206, 39);
            this.tbF2G2End.Name = "tbF2G2End";
            this.tbF2G2End.Size = new System.Drawing.Size(67, 22);
            this.tbF2G2End.TabIndex = 20;
            // 
            // tbF2G2Start
            // 
            this.tbF2G2Start.Location = new System.Drawing.Point(96, 39);
            this.tbF2G2Start.Name = "tbF2G2Start";
            this.tbF2G2Start.Size = new System.Drawing.Size(67, 22);
            this.tbF2G2Start.TabIndex = 19;
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(11, 10);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(58, 17);
            this.label60.TabIndex = 70;
            this.label60.Text = "Monday";
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.label61);
            this.panel12.Controls.Add(this.label62);
            this.panel12.Controls.Add(this.label63);
            this.panel12.Controls.Add(this.label64);
            this.panel12.Controls.Add(this.label65);
            this.panel12.Controls.Add(this.lbF2G1Timeslot);
            this.panel12.Controls.Add(this.tbF2G1End);
            this.panel12.Controls.Add(this.tbF2G1Start);
            this.panel12.Location = new System.Drawing.Point(14, 39);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(390, 70);
            this.panel12.TabIndex = 42;
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(309, 10);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(72, 17);
            this.label61.TabIndex = 73;
            this.label61.Text = "Early/Late";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(29, 39);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(16, 17);
            this.label62.TabIndex = 72;
            this.label62.Text = "1";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(10, 10);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(58, 17);
            this.label63.TabIndex = 71;
            this.label63.Text = "Game #";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(203, 10);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(33, 17);
            this.label64.TabIndex = 70;
            this.label64.Text = "End";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(94, 10);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(38, 17);
            this.label65.TabIndex = 69;
            this.label65.Text = "Start";
            // 
            // lbF2G1Timeslot
            // 
            this.lbF2G1Timeslot.FormattingEnabled = true;
            this.lbF2G1Timeslot.ItemHeight = 16;
            this.lbF2G1Timeslot.Items.AddRange(new object[] {
            "Early",
            "Late"});
            this.lbF2G1Timeslot.Location = new System.Drawing.Point(314, 39);
            this.lbF2G1Timeslot.Name = "lbF2G1Timeslot";
            this.lbF2G1Timeslot.Size = new System.Drawing.Size(69, 20);
            this.lbF2G1Timeslot.TabIndex = 68;
            // 
            // tbF2G1End
            // 
            this.tbF2G1End.Location = new System.Drawing.Point(206, 39);
            this.tbF2G1End.Name = "tbF2G1End";
            this.tbF2G1End.Size = new System.Drawing.Size(67, 22);
            this.tbF2G1End.TabIndex = 20;
            // 
            // tbF2G1Start
            // 
            this.tbF2G1Start.Location = new System.Drawing.Point(96, 39);
            this.tbF2G1Start.Name = "tbF2G1Start";
            this.tbF2G1Start.Size = new System.Drawing.Size(67, 22);
            this.tbF2G1Start.TabIndex = 19;
            // 
            // lbF2NumGamesSunday
            // 
            this.lbF2NumGamesSunday.FormattingEnabled = true;
            this.lbF2NumGamesSunday.ItemHeight = 16;
            this.lbF2NumGamesSunday.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.lbF2NumGamesSunday.Location = new System.Drawing.Point(752, 296);
            this.lbF2NumGamesSunday.Name = "lbF2NumGamesSunday";
            this.lbF2NumGamesSunday.Size = new System.Drawing.Size(53, 20);
            this.lbF2NumGamesSunday.TabIndex = 83;
            // 
            // lbF2NumGamesSaturday
            // 
            this.lbF2NumGamesSaturday.FormattingEnabled = true;
            this.lbF2NumGamesSaturday.ItemHeight = 16;
            this.lbF2NumGamesSaturday.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.lbF2NumGamesSaturday.Location = new System.Drawing.Point(682, 296);
            this.lbF2NumGamesSaturday.Name = "lbF2NumGamesSaturday";
            this.lbF2NumGamesSaturday.Size = new System.Drawing.Size(53, 20);
            this.lbF2NumGamesSaturday.TabIndex = 82;
            // 
            // lbF2NumGamesFriday
            // 
            this.lbF2NumGamesFriday.FormattingEnabled = true;
            this.lbF2NumGamesFriday.ItemHeight = 16;
            this.lbF2NumGamesFriday.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.lbF2NumGamesFriday.Location = new System.Drawing.Point(612, 296);
            this.lbF2NumGamesFriday.Name = "lbF2NumGamesFriday";
            this.lbF2NumGamesFriday.Size = new System.Drawing.Size(53, 20);
            this.lbF2NumGamesFriday.TabIndex = 81;
            // 
            // lbF2NumGamesThursday
            // 
            this.lbF2NumGamesThursday.FormattingEnabled = true;
            this.lbF2NumGamesThursday.ItemHeight = 16;
            this.lbF2NumGamesThursday.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.lbF2NumGamesThursday.Location = new System.Drawing.Point(542, 296);
            this.lbF2NumGamesThursday.Name = "lbF2NumGamesThursday";
            this.lbF2NumGamesThursday.Size = new System.Drawing.Size(53, 20);
            this.lbF2NumGamesThursday.TabIndex = 80;
            // 
            // lbF2NumGamesWednesday
            // 
            this.lbF2NumGamesWednesday.FormattingEnabled = true;
            this.lbF2NumGamesWednesday.ItemHeight = 16;
            this.lbF2NumGamesWednesday.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.lbF2NumGamesWednesday.Location = new System.Drawing.Point(472, 296);
            this.lbF2NumGamesWednesday.Name = "lbF2NumGamesWednesday";
            this.lbF2NumGamesWednesday.Size = new System.Drawing.Size(53, 20);
            this.lbF2NumGamesWednesday.TabIndex = 79;
            // 
            // lbF2NumGamesTuesday
            // 
            this.lbF2NumGamesTuesday.FormattingEnabled = true;
            this.lbF2NumGamesTuesday.ItemHeight = 16;
            this.lbF2NumGamesTuesday.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.lbF2NumGamesTuesday.Location = new System.Drawing.Point(402, 296);
            this.lbF2NumGamesTuesday.Name = "lbF2NumGamesTuesday";
            this.lbF2NumGamesTuesday.Size = new System.Drawing.Size(53, 20);
            this.lbF2NumGamesTuesday.TabIndex = 78;
            // 
            // lbF2NumGamesMonday
            // 
            this.lbF2NumGamesMonday.FormattingEnabled = true;
            this.lbF2NumGamesMonday.ItemHeight = 16;
            this.lbF2NumGamesMonday.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.lbF2NumGamesMonday.Location = new System.Drawing.Point(332, 296);
            this.lbF2NumGamesMonday.Name = "lbF2NumGamesMonday";
            this.lbF2NumGamesMonday.Size = new System.Drawing.Size(53, 20);
            this.lbF2NumGamesMonday.TabIndex = 77;
            // 
            // lField2
            // 
            this.lField2.AutoSize = true;
            this.lField2.Location = new System.Drawing.Point(16, 296);
            this.lField2.Name = "lField2";
            this.lField2.Size = new System.Drawing.Size(16, 17);
            this.lField2.TabIndex = 76;
            this.lField2.Text = "2";
            // 
            // tbF2Name
            // 
            this.tbF2Name.Location = new System.Drawing.Point(43, 293);
            this.tbF2Name.Name = "tbF2Name";
            this.tbF2Name.Size = new System.Drawing.Size(274, 22);
            this.tbF2Name.TabIndex = 75;
            // 
            // bGenerateSchedule
            // 
            this.bGenerateSchedule.Location = new System.Drawing.Point(395, 1020);
            this.bGenerateSchedule.Name = "bGenerateSchedule";
            this.bGenerateSchedule.Size = new System.Drawing.Size(171, 23);
            this.bGenerateSchedule.TabIndex = 69;
            this.bGenerateSchedule.Text = "Generate Schedule";
            this.bGenerateSchedule.UseVisualStyleBackColor = true;
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(721, 1018);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 70;
            this.bSave.Text = "save";
            this.bSave.UseVisualStyleBackColor = true;
            // 
            // bLoad
            // 
            this.bLoad.Location = new System.Drawing.Point(802, 1018);
            this.bLoad.Name = "bLoad";
            this.bLoad.Size = new System.Drawing.Size(75, 23);
            this.bLoad.TabIndex = 71;
            this.bLoad.Text = "load";
            this.bLoad.UseVisualStyleBackColor = true;
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(883, 1018);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(75, 23);
            this.bClear.TabIndex = 72;
            this.bClear.Text = "clear";
            this.bClear.UseVisualStyleBackColor = true;
            // 
            // LaunchForm
            // 
            this.ClientSize = new System.Drawing.Size(995, 1055);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.bLoad);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.bGenerateSchedule);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.bRefreshFieldsList);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bRefreshTeams);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbNumGamesPerTeamPerWeek);
            this.Controls.Add(this.lbMaxGamesPerTeam);
            this.Controls.Add(this.cbDoubleHeaders);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbLeagueName);
            this.Controls.Add(this.lLeagueName);
            this.Controls.Add(this.lbNumFields);
            this.Controls.Add(this.lbNumWeeks);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lMaxGamesPerTeam);
            this.Controls.Add(this.lTotalGames);
            this.Controls.Add(this.lNumWeeks);
            this.Controls.Add(this.lNumTeams);
            this.Controls.Add(this.lbNumTeams);
            this.Controls.Add(this.label1);
            this.Name = "LaunchForm";
            this.Load += new System.EventHandler(this.LaunchForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       private void LaunchForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }
    }
}

