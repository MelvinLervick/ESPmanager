///////////////////////////////////////////////////////////////////////
// GolfESPm.cs - main header file
// Joshua Buergel/Melvin Lervick
// Copyright (c) 2002, GolfESP, LLC
///////////////////////////////////////////////////////////////////////
using System;

namespace ESPmanager
{
	// include the resources
	// enums
	// enum for gender
	public enum GENDER 
	{
		Male = 0,
		Female = 1
	};

	// enum for handicap types
	public enum HANDICAP_TYPE 
	{
		HomeHandicap = 0,
		IndexHandicap = 1,
		EstimatedScore = 2
	};

	// the game types we support
	public enum GAME_TYPE 
	{
		IndividualMatch = Global.INDIVIDUAL_GAME_START,
		IndividualSkins,
		IndividualStats,
		IndividualNines,
		TeamBestBall = Global.TEAM_GAME_START,
		TeamHighLow,
		TeamBestBallAggregate,
		TeamSkins,
		TeamWolfHighLow,
		TeamWolfBestBall,
		TournamentGame = Global.TOURNAMENT_GAME_START
	};

	// the tournament game types we support
	/*
	// the different types of tournaments
	typedef enum _TOURNAMENT_TYPE {
		TournanentSkins = TOURNAMENT_GAME_START,
		TournamentBestBall,
		TournamentRotation123,
		TournamentRotation321,
		TournamentScramble
	} TOURNAMENT_TYPE, *PTOURNAMENT_TYPE;
	*/
	public enum TOURNAMENT_GAME_TYPE 
	{
		IndividualSkins = Global.TL_INDIVIDUAL_GAME_START,
		IndividualSkinsG,
		IndividualSkinsN,
		TeamBestBall = Global.TL_TEAM_GAME_START,
		Rotation123,
		Rotation321,
		Scramble,
		TeamSkins,
		TeamBestBall2Man,
		TeamSkins2G,
		TeamSkins2N,
		TeamSkins5G,
		TeamSkins5N,
		Scramble2,
		Scramble5
	};

	// stats/specials
	public enum STATS 
	{
		Greens = 0,
		Fairways,
		Putts,
		Birdies,
		Eagles,
		SandSaves,
		ChipsIn,
		Greenies,
		PolePutts,
		Other
	};

	// different values for the stats
	public enum STAT_VALUE 
	{
		StatNoEvent = 0,
		StatYes,
		StatNo
	};

	// TL Print Flags for Header, Body, Total Line
	public enum TL_PRINT
	{
		Header = 0,
		Body,
		Total
	};

	// structs

	// course rating and slope - varies by gender, so we need a separate
	// structure
	public class COURSE_RATINGS
	{
		public double      CourseRating = 0.0;	// the course rating
		public ushort      Slope = 0;						// the slope

		public COURSE_RATINGS()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	};

	// the structure that tracks what points are available
	public class MAP_POINT 
	{
		public short			XCoord = 0;		// X coordinate of this point
		public short			YCoord = 0;		// Y coordinate of this point
		//short					Distances[0];		// distance from here to all other points
		public short []		Distances;			// distance from here to all other points

		public MAP_POINT()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	};

	// information about a hole
	public class HOLE_INFORMATION 
	{
		public ushort		Length = 0;			// length of the hole
		public byte			Par = 0;				// par for the hole
		public byte			Handicap = 0;		// handicap value for the hole

		public HOLE_INFORMATION()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	};

	// information about the tees
	public class TEE_INFORMATION 
	{
		//char Tees[30];									// what tees is this course info for
		public uint TeeID = 0;
		public string	 TeeName = "";
		public string	 ShortName = "";
		public bool Mens = true;								// is this normally a men's tee?
		//COURSE_RATINGS Ratings[2];		// the ratings (one for each gender)
		public COURSE_RATINGS [] Ratings = new COURSE_RATINGS[2];
		public bool MPrint = true;
		public bool FPrint = true;
		//char PinLocation[10];						// the current pin location
		public string PinLocation = "";					// the current pin location
		//HOLE_INFORMATION Holes[MAX_HOLES];		// the holes for the course
		public HOLE_INFORMATION [] Holes = new HOLE_INFORMATION[Global.MAX_HOLES];

		public TEE_INFORMATION()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	};

	// overall course information - max players, etc - which doesn't
	// change for the tees
	public class MASTER_COURSE_INFORMATION 
	{
		public string CourseName = "Select WsCourse";
		public string ShortCourseName = "";
		public byte NumTees;								// the number of tees this course has
		public HANDICAP_TYPE DefaultHandicapType;	// default value for home vs. index handicaps
		public byte MaxPlayers;							// the max golfers allowed
		//byte NumPoints[MAX_HOLES];			// number of points for each hole (count from DB)
		public byte [] NumPoints = new byte[Global.MAX_HOLES];

		public MASTER_COURSE_INFORMATION()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	};

	// information about a player
	public class PLAYER_INFORMATION 
	{
		public int PlayerID;
		//char Initials[4]; (NUM_INITIALS+1)			// tees is this course info for
		public string Initials;
		public bool Posted;
		public double Handicap;								// the ratings (one for each gender)
		//char HandicapStr[MAX_HANDICAP_STR+1];	// the string for the handicap
		public string HandicapStr;
		public bool PlusHandicap;							// is this a positive handicap?
		public short ComputedHandicap;				// the ratings (one for each gender)
		//char ComputedHandicapStr[5];				// the string for the computed handicap
		public string ComputedHandicapStr;
		public GENDER Gender;							// the gender of the player
		public uint Tees;											// what tees are they playing from?
		public HANDICAP_TYPE HandicapType;	// the handicap type for this player
		public uint InGameStats;								// the stats this player must track in game
		//sbyte Strokes[MAX_HOLES];					// where does the player get strokes?
		public sbyte [] Strokes = new sbyte[Global.MAX_HOLES];
		//sbyte GameScores[MAX_HOLES];			// the scores for this player in their game
		//Int16			GameScores[MAX_HOLES];// the scores for this player in their game
		//Boolean		GameScoresValid;					// are the game scores valid for this player?
		public short [] GameScores = new short[Global.MAX_HOLES];
		public bool GameScoresValid;
		//bool Stats[MAX_HOLES][NUM_STATS];	// stats for every player
		public byte [,]Stats = new byte[Global.MAX_HOLES,Global.NUM_STATS];
		//byte Scores[MAX_HOLES];						// scores for the holes
		public byte [] Scores = new byte[Global.MAX_HOLES];
		public bool [] XScores = new bool[Global.MAX_HOLES];
		public bool TrackStats;								// Is player Tracking Stats
		public uint TrackingStats;							// the stats this player is tracking in game
		//public short TeeTimeMinutes;					// minutes for the tee time
		//public short TeeTimeHours;						// hours for the tee time
		//public string CourseDB;							// which course is this player playing?
		public bool Valid;											// is this player valid?
		public string FirstName;								// the player's first name
		public string LastName;								// the player's last name
		public string ClubNumber;							// the player's club number
		public string GHIN;										// the player's GHIN
		public string LocalNumber;						// the player's local number

		public PLAYER_INFORMATION()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	};

	// game information
	public class GAME_INFORMATION 
	{
		public bool TeamGame;					// is this a team game?
		public byte TeamSize;						// the size of the teams
		//byte	Team1[MAX_PLAYERS];		// the first team
		public byte [] Team1 = new byte[Global.MAX_PLAYERS];
		//byte	Team2[MAX_PLAYERS];		// the second team
		public byte [] Team2 = new byte[Global.MAX_PLAYERS];
		public uint [] HoleInfo = new uint[Global.MAX_HOLES];	// game specific info stored for each hole
		public GAME_TYPE GameType;	// type of game?
		public uint GameFlags;						// flags for the game
		//byte Presses[MAX_HOLES];			// where do the presses fall?
		public byte [] Presses = new byte[Global.MAX_HOLES];
		public TOURNAMENT_GAME_TYPE TournamentType;			// type of game?
		public byte [] BallInfo = new byte[Global.MAX_PLAYERS];	// information on each ball - net vs. gross
		public string TournamentName;		// name of associated tournament
		public byte Drives;								// required drivers per player (for scrambles)
		public string TournamentID;				// unique ID for the tournament Game
		public short HandicapPercent;			// Handicap Percentage as a whole number (70, 83, 90, etc)

		public GAME_INFORMATION()
		{
			//
			// TODO: Add constructor logic here
			//
			for (int i=0;i<Global.MAX_PLAYERS;i++)
			{
				Team1[i] = 0xFF;
				Team2[i] = 0xFF;
			}
		}
	};
	// Used to hold user selected data on the Appliance (golfESPmanager)
	// NOTE DIFFERENT FROM PALM VERSION
	public class PROGRAM_STATE 
	{
		public int			CourseID = 0;							// In APPLIANCE data held in the course structure
		public int			NumberOfCourses = 0;			// Set when WsCourse Names are retrieved
		public string		CurrentCourseName = "";		// Set by user or system when WsCourse Names are
																				// retrieved (if there is only one course defined)
		public string		ShortCourseName = "";
		public string		DatePlayed = "01/01/1900";	// Date round was played
		public string		sDatePlayed = "01/01/1900";	// Date round was played
		public string		TeeTime = "00:00 AM";			// WsTee Time of the round
		public byte		StartHole = 0;								// the starting hole number
		public byte    	NumPlayers = 0;						// the number of players
		public byte    	NumGames = 0;						// the number of games
		public byte		HoleNumber = 0;					// the current hole number
		public byte		CurrentGame = 0;					// index to the current game we're working on
		public uint		TrackingStats = 0;					// the pure tracking stats
		public byte 		StatPlayer = 0;						// the player that we're retrieving stats for
		public bool		PrintScoreCard = false;
		public bool		PrintGameSummary = false;
		public bool		PrintGameDetails = false;
		public bool		PrintGameReconciliation = false;
		public byte		NumberOfCopies = 1;

		public PROGRAM_STATE()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	};

	// ======================================================
	// START OF Tournament Lite Definitions
	// ======================================================
	// Tournament Information
	public class TOURLITE_INFORMATION
	{
		public int ID = 0;
		public string Name = "";
		public DateTime DateStart;
		public DateTime DateEnd;
		//
		public TOURLITE_INFORMATION()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	}
	/*
	// game information
	// tournament information
	typedef struct _TOURNAMENT_INFORMATION {
		char									TournamentName[TOURNAMENT_NAME_SIZE]; // name of this tournament
		Boolean							TeamGame;			// is this a team game?
		UInt8								TeamSize;					// the size of the teams
		TOURNAMENT_TYPE	GameType;		// type of game?
		UInt8									Drives;						// required drivers per player (for scrambles)
		UInt32								GameFlags;			// flags for the game
		UInt8									BallInfo[MAX_PLAYERS];	// information on each ball - net vs. gross
		Boolean							Seen;							// has this tournament been seen by the palm?
	} TOURNAMENT_INFORMATION, *PTOURNAMENT_INFORMATION;

	*/
	public class TLGAME_INFORMATION 
	{
		public int ID;										// convert autonumber to string and ViceVersa
		public bool TeamGame;
		public byte TeamSize;
		public byte NumberOfTeams;
		public TOURNAMENT_GAME_TYPE GameType;
		public byte DrivesPerPlayer;
		public uint GameFlags;					// flags for the game
		public byte Ball1GrossNet;
		public byte Ball2GrossNet;
		public byte Ball3GrossNet;
		public byte Ball4GrossNet;
		public byte Ball5GrossNet;
		public bool Seen = false;
		public string TournamentID;				// unique ID for the tournament Game(may not be needed, see ID)
		public short HandicapPercent;			// Handicap Percentage as a whole number (70, 83, 90, etc)

		public TLGAME_INFORMATION()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	};
	// ======================================================
	// END OF Tournament Lite Definitions
	// ======================================================

	//#include "GolfESP_res.h"
	public class Global
	{
		// program wide defines
		// the creator ID for this application
		//#define GOLFESP_CREATOR		('GESPM')
		private string GOLFESP_CREATOR = "GolfESP Manager";
		public string Creator
		{
			get
			{
				return GOLFESP_CREATOR;
			}
		}

		public const byte NOTUSED = 0;
		public const byte GROSS = 1;
		public const byte NET = 2;

		// version stamp for databases
		// once we ship, this MUST CHANGE if the format of any
		// record stored in a database changes.
		// right now, that's MASTER_COURSE_INFORMATION, 
		// GAME_INFORMATION, PLAYER_INFORMATION, TEE_INFORMATION
		// and DATA_POINT
		//#define GOLFESP_DATABASE_VERSION	(1)
		public const byte GOLFESP_DATABASE_VERSION	= 1;

		// the offset into a course DB name string that indicates
		// the type of the DB (C or M)
		//#define DB_TYPE_OFFSET				(4)
		public const byte DB_TYPE_OFFSET = 4;

			// the max number of players
		//#define MAX_PLAYERS        				(5)
		public const byte MAX_PLAYERS = 5;

		// right now, we can only have two teams
		// #define MAX_TEAMS			(2)
		public const byte MAX_TEAMS = 2;

		// Number of Initials we ask for
		//#define NUM_INITIALS		(3)
		public const byte NUM_INITIALS = 3;

		// maximum handicap string
		//#define MAX_HANDICAP_STR (5)
		public const byte MAX_HANDICAP_STR = 5;

		// the index where games start
		//#define GAME_START_INDEX			(MAX_PLAYERS)
		//public const byte GAME_START_INDEX = MAX_PLAYERS;

		/* the maximum number of holes
		#define MAX_HOLES										(18)
		#define HOLES_PER_HALF							(9)
		#define HOLES_PER_TEAM_ROTATION	(6)
		#define TEE_MAX_CHARS							(30)
		#define SHORT_NAME_MAX_CHARS			(5)
		*/
		public const byte MAX_HOLES = 18;
		public const byte HOLES_PER_HALF = 9;
		public const byte HOLES_PER_TEAM_ROTATION = 6;
		public const byte TEE_MAX_CHARS = 30;
		public const byte SHORT_NAME_MAX_CHAR = 5;

		/* the start of the individual games
		#define INDIVIDUAL_GAME_START	(0)
		*/
		public const byte INDIVIDUAL_GAME_START = 0;
		public const byte TL_INDIVIDUAL_GAME_START = 200;
		
		/* the number of individual games
		#define NUM_INDIVIDUAL_GAMES		(4)
		*/
		public const byte NUM_INDIVIDUAL_GAMES = 4;
		public const byte NUM_TL_INDIVIDUAL_GAMES = 3;

		/* the start of the team games
		#define TEAM_GAME_START				(100)
		*/
		public const byte TEAM_GAME_START = 100;
		public const byte TL_TEAM_GAME_START = 210;

		/* the number of team games
		#define NUM_TEAM_GAMES				(6)
		*/
		public const byte NUM_TEAM_GAMES = 6;
		public const byte NUM_TL_TEAM_GAMES = 13;

		// the start of the tournament games
		//#define TOURNAMENT_GAME_START	(200)
		public const byte TOURNAMENT_GAME_START = 200;

		// the number of tournament games (should not be used by DataIn or Manager)
		//#define NUM_TOURNAMENT_GAMES	(5)
		public const byte NUM_TOURNAMENT_GAMES = 5;

		/* the number of players required for wolf
		#define WOLF_NUM_PLAYERS			(4)
		*/
		public const byte WOLF_NUM_PLAYERS = 4;

		// the minimum number of players we need to do 9s/16s/25s
		//#define NINES_MIN_PLAYERS		(3)
		public const byte NINES_MIN_PLAYERS = 3;

		// the minimum number of players we need to do team games
		//#define MIN_TEAM		(4)
		public const byte MIN_TEAM = 4;

		// used to indicate an invalid player in a game
		//#define INVALID_PLAYER			(0xFF)
		public const sbyte INVALID_PLAYER = -127;

		public const uint GAME_FLAG_NET_DIFF = (0x00000001);
		public const uint GAME_FLAG_NET	 = (0x00000002);
		public const uint GAME_FLAG_GROSS = (0x00000004);
		public const uint GAME_FLAG_SKINS_CARRY = (0x00000008);
		public const uint GAME_FLAG_MANY_SCORES = (0x00000010);
		public const uint GAME_FLAG_ONE_TEAM = (0x00000020);
		public const uint GAME_FLAG_HANDICAP_MASK = (0x00000007);
		public const uint GAME_FLAG_DESCRIBE_MASK = (0x0000003F);

		/* the corresponding flags
		#define GAME_STAT_FLAG(s)			((UInt32) (((UInt32) 0x00000040) << ((UInt32) (s))))
		#define GAME_STAT_MASK				((UInt32) 0x0000FFC0)
		*/
		public const uint GAME_STAT_FLAG = (0x00000040);
		public const uint GAME_STAT_MASK = (0x0000FFC0);

		/* the press flags
		// the following flag is set for manual, cleared for auto
		#define GAME_PRESS_MANUAL		(0x00010000)
		*/
		public const uint GAME_PRESS_MANUAL = (0x00010000);

		/* the following flag is set for double bets, cleared
		// for new games
		#define GAME_PRESS_DOUBLE		(0x00020000)
		*/
		public const int GAME_PRESS_DOUBLE = 0x00020000;

		/* the following three flags are mutually exclusive
		// if they are all clear, there is NO PRESS for this
		// game.  Note that the content of these flags is ignored
		// for manual presses - but one of them will still be set
		#define GAME_PRESS_1_DOWN		(0x00040000)
		#define GAME_PRESS_2_DOWN		(0x00080000)
		#define GAME_PRESS_3_DOWN		(0x00100000)
		#define GAME_PRESS_1_LIMIT		((UInt32) 0x00200000)
		#define GAME_PRESS_2_LIMIT		((UInt32) 0x00400000)
		#define GAME_PRESS_MASK			((UInt32) 0x007F0000)
		*/
		public const int GAME_PRESS_1_DOWN = 0x00040000;
		public const int GAME_PRESS_2_DOWN = 0x00080000;
		public const int GAME_PRESS_3_DOWN = 0x00100000;
		public const int GAME_PRESS_1_LIMIT = (0x00200000);
		public const int GAME_PRESS_2_LIMIT = (0x00400000);
		public const int GAME_PRESS_MASK = 0x001F0000;

		// the flag for backside presses
		//#define GAME_FLAG_BACKSIDE_PRESS	((UInt32) 0x01000000)
		public const int GAME_FLAG_BACKSIDE_PRESS = (0x01000000);

		// the flag for rotating teams
		//#define GAME_FLAG_ROTATE_TEAMS = (0x02000000);
		public const int GAME_FLAG_ROTATE_TEAMS = (0x02000000);

		// tournament flags - information on handicaps for each ball
		//#define BALL_HANDICAP_NET				(0)
		//#define BALL_HANDICAP_GROSS		(1)
		//#define BALL_HANDICAP_UNUSED		(2)
		public const int BALL_HANDICAP_UNUSED = 0;
		public const int BALL_HANDICAP_GROSS = 1;
		public const int BALL_HANDICAP_NET = 2;

		/* the number of available stats/specials
		#define NUM_STATS							(10)
		*/
		public const  byte NUM_STATS = 10;

		// indicates that a score is an X score
		//#define X_SCORE							(0x80)
		public const byte X_SCORE = 0x80;

		// the size of the name for a tournament
		//#define TOURNAMENT_NAME_SIZE	(12)
		public const byte TOURNAMENT_NAME_SIZE = 12;
		// the size of the unique ID
		//#define TOURNAMENT_ID_SIZE		(12)
		public const byte TOURNAMENT_ID_SIZE = 12;

		// global variables
		//====================================================
		// the state - this is saved in the app preferences on the PALM
		// global for equivalent of the REGISTRY (only used on PALM)
		// but used by the appliance to contain user specified data.
		// public	PROGRAM_STATE	g_State;

		// string tables

	}
}
