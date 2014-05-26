using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace ESPmanager
{
	/// <summary>
	/// Summary description for TourLiteCompute.
	/// </summary>
	public class TourLiteCompute
	{
		// Link to System Database
		Database espDB;
		private DataSet ds;
		private TOURLITE_INFORMATION tour;
		private TLGAME_INFORMATION [] game;
		//
		// Properties
		//
		bool _Skins = false;
		bool _BestBall = false;
		bool _123Rotation = false;
		bool _321Rotation = false;
		bool _TeamSkins = false;
		bool _Scramble = false;
		byte _Copies = 0;
		//
		// REPORT definitions
		//
		bool SkinsPrinted = false;
		bool BestBallPrinted = false;
		bool Rotation123Printed = false;
		bool Rotation321Printed = false;
		bool TeamSkinsPrinted = false;
		bool ScramblePrinted = false;
		//
		private bool NewPage = false;
		private int pagesPrinted = 0;
		private float yPos = 0;
		private float leftMargin;
		private float topMargin;
		private int printerResolutionX;
		private int printerResolutionY;
		private int linesPerPage;
		// Graphics Variables
		private int pageLeft;
		private int pageRight;
		private int pageTop;
		private int pageBottom;
		private int pageHeight;
		private int pageWidth;
		private int lineHeight;
		private Font espFont14 = new Font( "Times New Roman", 14);
		private Font espFont12 = new Font( "Times New Roman", 12);
		private Font espFont12B = new Font( "Times New Roman", 12, FontStyle.Bold);
		private Font espFont10 = new Font( "Times New Roman", 10);
		private Font espFont10B = new Font( "Times New Roman", 10, FontStyle.Bold);
		private Font espFont9 = new Font( "Times New Roman", 9);
		private Font espFont8 = new Font( "Times New Roman", 8);
		private Font espFont7 = new Font( "Times New Roman", 7);
		private Pen linePen = new Pen(Color.LightBlue,1);
		private Pen xPen = new Pen(Color.Black,1);
		//
		// maximum handicap
		private const byte MAX_HANDICAP = 0xFF;
		private const sbyte MAX_SCORE = 0x7F;
		//
		// Local Classes
		class Winners
		{
			public byte Score = 0;
			public short Count = 0;
			public ArrayList TeamID = new ArrayList();
			public Winners()
			{
				//TeamID  = new ArrayList();
			}
		}
		//
		public TourLiteCompute(ref Database db)
		{
			//
			// TODO: Add constructor logic here
			//
			espDB = db;
			ds = espDB.GetDS();
		}
		//
		/// <summary>
		/// ComputeGames - compute the TourLite game scores
		/// Input:  TournamentID - the tournament to be computed
		/// </summary>
		/// <param name="TournamentID"></param>
		/// <param name="RoundID"></param>
		public void ComputeGame(int TournamentID, int RoundID)
		{
			// Remove previously calculated Game Scores for the selected Tournament/Round
			espDB.RemoveTLGameScores( TournamentID,RoundID );
			//
			// Get the Tournament Game Information
			GetGameInfo( TournamentID );
			//
			// Load the TournamentRounds Table
			espDB.GetTournamentRounds(TournamentID);
			//
			// Process each of the Rounds Played
			DataTable dt;
			DataRow[] dr;
			DataTable dtg;
			DataRow[] drg;
			int roundid = 0;
			int courseid = 0;
			int prevCourseID = 0;
			//
			dt = ds.Tables["TournamentRounds"];
			dr = dt.Select("RoundID="+RoundID.ToString());
			for (int i=0;i<dr.Length;i++)
			{
				// Process all rounds played 
				roundid = (int)dr[i]["RoundID"];
				courseid = espDB.GetCourseID(roundid);
				if (courseid != prevCourseID)
				{
					// Only update course data if it has changed
					espDB.GetCourseData(courseid);
					espDB.UpdateAllOtherCourseData(courseid);
					prevCourseID = courseid;
				}
				// PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPlayer
				espDB.GetPlayers(roundid);
				// Compute Player/Team Handicaps
				TLComputeHandicaps();
				//
				// Compute NET Game scores for each Player
				TLComputeNetScores();
				// PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPlayer
				//
				// Game, Course, and Player data retrieved, now
				// Get the TournamentsTeams that played each round.
				//
				espDB.GetTournamentTeams(roundid);
				//
				// compute game data and store.
				// GGGGGGGGGGGGGGGGGGGGGGGGGGGGGGame
				dtg = ds.Tables["TournamentTeams"];
				for (int g=0;g<game.Length;g++)
				{
					drg = dtg.Select("TLGameID="+game[g].ID,"TLTeamID");
					// Compute Team Score (Note: individual is a team of 1)
					// TSTSTSTSTSTSTSTSTSTSTSTSTSTSTSTSTSTeamScore
					//
					switch (game[g].GameType) 
					{
						case TOURNAMENT_GAME_TYPE.IndividualSkins:
							TLIndividualSkins(game[g],drg);
							break;
						case TOURNAMENT_GAME_TYPE.TeamBestBall2Man:
						case TOURNAMENT_GAME_TYPE.TeamBestBall:
							TLBestBall(game[g],drg);
							break;
						case TOURNAMENT_GAME_TYPE.TeamSkins:
							break;
						case TOURNAMENT_GAME_TYPE.Rotation123:
							break;
						case TOURNAMENT_GAME_TYPE.Rotation321:
							break;
						case TOURNAMENT_GAME_TYPE.Scramble:
							break;
					}
					// TSTSTSTSTSTSTSTSTSTSTSTSTSTSTSTSTSTeamScore
				}
				// GGGGGGGGGGGGGGGGGGGGGGGGGGGGGGame
			}
			//
			if (!espDB.SaveTourLiteGameScores())
				MessageBox.Show("TourLite Compute","TourLite Game Scores Update Error");
			//
			// Clear the TournamentRounds Table
			ds.Tables["TournamentRounds"].Clear();
			//
			dr = null;
			dt = null;
			
			return;
		}
		//
		private void TLComputeHandicaps()
		{
			byte								currentStrokes;		// the current strokes value
			TEE_INFORMATION	pTeeInfo;					// the information for a set of tees
			//
			currentStrokes = 0;
			// loop over every player
			for (int ii = 0; ii < espDB.g_State.NumPlayers; ii++) 
			{
				// clear out the strokes for all players
				for (int jj = 0; jj < Global.MAX_HOLES; jj++) 
				{
					espDB.cPlayers[ii].Strokes[jj] = (sbyte)currentStrokes;
				}
			}
			// Compute Handicaps for all players
			for (int ii = 0; ii < espDB.g_State.NumPlayers; ii++) 
			{
				// get the course information for this player
				pTeeInfo = espDB.GetTeeInfo(espDB.cPlayers[ii].Tees);
				// distribute their strokes
				ComputeNetStrokes(ii, pTeeInfo);
			}
		}
		//
		private void ComputeNetStrokes(int index,TEE_INFORMATION pTeeInfo)
		{
			ushort		strokes;						// extra strokes to give
			ushort		baseStrokes;			// the base number of strokes
			byte			currentStrokes;		// the current strokes value
			byte			ii;									// loop variable
			ushort		Handicap;				// Adjust for computing net strokes
	
			// Get Handicap
			Handicap = (ushort)espDB.cPlayers[index].ComputedHandicap;

			// SPECIAL CODE FOR MILL CREEK (HARDWIRED) GAMES
			// If player is Female, adjust +3 strokes handicap
			if (espDB.cPlayers[index].Gender == GENDER.Female) Handicap = (ushort)Math.Round((((Handicap + 3)*90)/100)+.00001);
			// SPECIAL CODE FOR MILL CREEK (HARDWIRED) GAMES

			// calculate the base number of strokes
			// this is the number of times MAX_HOLES goes
			// into the difference between handicaps
			baseStrokes = (ushort)(Handicap / Global.MAX_HOLES);

			// get the remainder - these are the odd strokes we'll
			// hand out
			strokes = (ushort)(Handicap - (baseStrokes * Global.MAX_HOLES));

			// loop over the holes
			for (ii = 0; ii < Global.MAX_HOLES; ii++) 
			{
				// if this hole's handicap is <= strokes,
				// it gets an extra, otherwise, it gets
				// the base amount
				if (pTeeInfo.Holes[ii].Handicap <= strokes) 
				{
					// set the current strokes
					currentStrokes = (byte)(baseStrokes + 1);
				} 
				else 
				{
					// set the current strokes
					currentStrokes = (byte)baseStrokes;
				}
				// write to the player
				espDB.cPlayers[index].Strokes[ii] = (sbyte)currentStrokes;
			}
		}
		//
		/// <summary>
		/// Compute the NET Scores for each player and store in GameScores
		/// </summary>
		private void TLComputeNetScores()
		{
			// Compute and Store NET scores for each hole
			for (int ii = 0; ii < espDB.g_State.NumPlayers; ii++) 
			{
				short score = 0;
				for (int jj=0;jj<Global.MAX_HOLES;jj++)
				{
					score = (sbyte)((int)espDB.cPlayers[ii].Scores[jj]-(int)espDB.cPlayers[ii].Strokes[jj]);
					if (score < 0) score = 0;
					espDB.cPlayers[ii].GameScores[jj] = score;
				}
			}
		}
		//
		private void TLIndividualSkins(TLGAME_INFORMATION gm, DataRow [] tm)
		{
			DataTable dt;
			DataRow addrow;
			byte PlayerIndex = 99;
			string hole = "";
			string holeX = "";
			int holeno = 0;
			short total = 0;
			//
			dt = ds.Tables["TourLiteGameScores"];
			for (int i=0;i<tm.Length;i++)
			{
				PlayerIndex = espDB.GetPlayerIndexFromID((int)tm[i]["PlayerID"]);
				addrow = dt.NewRow();
				addrow["TLTeamID"] = tm[i]["TLTeamID"];
				total = 0;
				for (int j=0;j<Global.MAX_HOLES;j++)
				{
					holeno = j+1;
					hole = "Hole"+holeno.ToString();
					holeX = "HoleX"+holeno.ToString();
					if (gm.Ball1GrossNet == 1)
						addrow[hole] = espDB.cPlayers[PlayerIndex].Scores[j];
					else
						addrow[hole] = espDB.cPlayers[PlayerIndex].GameScores[j];
					//
					addrow[holeX] = espDB.cPlayers[PlayerIndex].XScores[j];
					total += espDB.cPlayers[PlayerIndex].Scores[j];
				}
				addrow["Total"] = total;
				dt.Rows.Add(addrow);
			}
			dt = null;
		}
		//
		private void TLBestBall(TLGAME_INFORMATION gm, DataRow [] tm)
		{
			DataTable dt;
			DataRow addrow;
			byte PlayerIndex = 99;
			string hole = "";
			string holeX = "";
			int holeno = 0;
			short [] cumScore = new short[Global.MAX_PLAYERS];	// Total Score for each Ball
			sbyte [,] players = new SByte[Global.MAX_PLAYERS,Global.MAX_HOLES];		// Best Player for each ball(tm player index)
			sbyte [,] scores = new SByte[Global.MAX_PLAYERS,Global.MAX_HOLES];		// Best Score for each ball
			bool [,] scoresX = new bool[Global.MAX_PLAYERS,Global.MAX_HOLES];		// X Score status for each ball
			sbyte score = 0;				// score being examined
			bool xScore = false;
			sbyte tieBreakScore = 0;
			sbyte bestScore = 0;
			bool bestxScore = false;
			sbyte bestTieBreak = 0;
			sbyte bestPlayer;
			TEE_INFORMATION pTeeInfo;
			ArrayList teamIDs = new ArrayList();
			byte teamSize = 0;
			//
			dt = ds.Tables["TourLiteGameScores"];
			//
			// Count Teams Defined for the Round by getting unique Teamid's
			for (int game=0;game<tm.Length;game++)
			{
				if (!teamIDs.Contains(tm[game]["TLTeamID"])) teamIDs.Add(tm[game]["TLTeamID"]);
			}
			// Process Each Team Playing the Game
			for (int team=0;team<teamIDs.Count;team++)
			{
				// Initialize Cumulative Score
				for (int i=0;i<Global.MAX_PLAYERS;i++) cumScore[i] = 0;
				// Count Players on the Team
				teamSize = 0;
				for (int pi=0;pi<tm.Length;pi++) if ((int)tm[pi]["TLTeamID"] == (int)teamIDs[team]) teamSize++;
				//
				// Process score for each Hole
				for (int hi=0;hi<Global.MAX_HOLES;hi++)
				{
					// Init tracking arrays
					for (int i=0;i<Global.MAX_PLAYERS;i++)
					{
						players[i,hi] = Global.INVALID_PLAYER;
						scores[i,hi] = 0;
					}
					// Determine Score for each Ball
					for (int ball=0;ball<teamSize;ball++)
					{
						if (IsBallGrossOrNet(gm,ball) == Global.BALL_HANDICAP_UNUSED)  break;
						bestScore = (sbyte)MAX_SCORE;
						bestxScore = false;
						bestTieBreak = 0;
						bestPlayer = Global.INVALID_PLAYER;
						// loop over the players
						for (int player = 0; player < tm.Length; player++) 
						{
							if ((int)tm[player]["TLTeamID"] != (int)teamIDs[team]) continue;
							PlayerIndex = espDB.GetPlayerIndexFromID((int)tm[player]["PlayerID"]);
							// check if this player is used
							bool used = false;
							for (int jj = 0; jj < Global.MAX_PLAYERS; jj++) 
							{
								// check this player
								if (players[jj,hi] == player) 
								{
									used = true;
									break;
								}
							}
							// if this player is used, move on
							if (used) 
							{
								continue;
							}
							// SgetSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
							// okay, check this player's score for this hole
							// note that we check either gross or net, depending
							// on what the ball info is
							if (IsBallGrossOrNet(gm,ball) == Global.BALL_HANDICAP_NET) 
							{
								// get the net score
								score = (sbyte)espDB.cPlayers[PlayerIndex].GameScores[hi];
								// get the gross score as our tiebreaker
								tieBreakScore = (sbyte)espDB.cPlayers[PlayerIndex].Scores[hi];
							} 
							else 
							{
								// get the gross score
								score = (sbyte)espDB.cPlayers[PlayerIndex].Scores[hi];
								// get the net score as our tiebreaker
								tieBreakScore = (sbyte)espDB.cPlayers[PlayerIndex].GameScores[hi];
							}
							xScore = espDB.cPlayers[PlayerIndex].XScores[hi];
							// if it's an X score, we'll use their adjusted max
							if (xScore) 
							{
								// get the tees for this player
								pTeeInfo = espDB.cTees[espDB.cPlayers[PlayerIndex].Tees];
								// now, get their max adjusted score
								score = (sbyte)EndGetMaxAdjustedScore((byte)MAX_SCORE, pTeeInfo, (byte)hi, espDB.cPlayers[PlayerIndex].ComputedHandicap);
								// our tiebreaker score is the same
								tieBreakScore = score;
							}
							// SgetSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
							// if this is the lowest score we've seen, note the player
							if (score < bestScore) 
							{
								// this is our best
								bestScore = score;
								bestxScore = xScore;
								bestPlayer = (sbyte)player;
								bestTieBreak = tieBreakScore;
							} 
							else if (score == bestScore) 
							{
								// this might be our best.  compare the tiebreaker
								// scores.  we want the one with the WORST tiebreaker
								// score
								if (tieBreakScore > bestTieBreak) 
								{
									// this is our best
									bestScore = score;
									bestxScore = xScore;
									bestPlayer = (sbyte)player;
									bestTieBreak = tieBreakScore;
								}
							}
						}
						// okay, we have our best player.  Record the player and
						// the add the score to our total
						players[ball,hi] = (sbyte)bestPlayer;
						scores[ball,hi] = (sbyte)bestScore;
						scoresX[ball,hi] = bestxScore;
						cumScore[ball] += bestScore;
					} // end of ball loop
				} // end of hi loop
				// Write the BALL Scores to the GameScores Table
				for (int ball=0;ball<teamSize;ball++)
				{
					if (IsBallGrossOrNet(gm,ball) == Global.BALL_HANDICAP_UNUSED)  break;
					addrow = dt.NewRow();
					addrow["TLTeamID"] = teamIDs[team]; // tm[players[ball,hi]]["TLTeamID"];
					addrow["Ball"] = (byte)ball;
					addrow["Total"] = cumScore[ball];
					for (int hi=0;hi<Global.MAX_HOLES;hi++)
					{
						holeno = hi+1;
						hole = "Hole"+holeno.ToString();
						holeX = "HoleX"+holeno.ToString();
						addrow[hole] = scores[ball,hi];
						addrow[holeX] = scoresX[ball,hi];
					}
					dt.Rows.Add(addrow);
				}
			}  // end of team loop
			dt = null;
		}
		//
		/// <summary>
		/// This fuction returns the Type of Handicap to be used for calculating this ball score
		/// </summary>
		/// <param name="ball"></param>
		/// <returns></returns>
		int IsBallGrossOrNet(TLGAME_INFORMATION gm, int ball)
		{
			byte retval = Global.BALL_HANDICAP_UNUSED;
			switch (ball)
			{
				case 0:
					retval = gm.Ball1GrossNet;
					break;
				case 1:
					retval = gm.Ball2GrossNet;
					break;
				case 2:
					retval = gm.Ball3GrossNet;
					break;
				case 3:
					retval = gm.Ball4GrossNet;
					break;
				case 4:
					retval = gm.Ball5GrossNet;
					break;
			}
			return (int)retval;
		}
		///////////////////////////////////////////////////////////////////////
		//  EndGetMaxAdjustedScore - gets the maximum allowed score for this hole and player
		//  Input:  Score - the score we're examining (X flag removed)
		//			pTeeInfo - the tee info for the player
		//			HoleNumber - the hole number
		//			Handicap - the computed handicap for this player
		//  Output: none
		//  Return: returns the max allowed score for this player
		//  Notes:
		///////////////////////////////////////////////////////////////////////
		byte EndGetMaxAdjustedScore(byte Score,
			TEE_INFORMATION	pTees,
			byte				HoleNumber,
			short				Handicap)
		{
			// look at the handicap
			if (Handicap < 10) 
			{
				// they can only take a double bogey
				if (Score > (pTees.Holes[HoleNumber].Par + 2)) 
					return (byte)(pTees.Holes[HoleNumber].Par + 2);
				else 
					return Score;
			} 
			else if (Handicap < 20) 
			{
				// they take a 7
				if (Score > 7) 
					return 7;
				else 
					return Score;
			} 
			else if (Handicap < 30) 
			{
				// they take an 8
				if (Score > 8) 
					return 8;
				else 
					return Score;
			} 
			else 
			{
				// they take a 9
				if (Score > 9) 
					return 9;
				else 
					return Score;
			}
		}

		/// <summary>
		/// Print the Tournament Standings for the specified Tournament
		/// Input:  TournamentID - the tournament to be printed
		/// </summary>
		/// <param name="id"></param>
		public void PrintGames(int id)
		{
			// Get the Tournament Information
			tour = GetTournamentInfo( id );
			//
			// Get the GameScores for the specified tournament
			espDB.GetTLGameScores( id );
			//
			// Print each Game Standing Report (TourLiteGameScores)
			//
			if (this.Copies > 0)
			{
				this.SkinsPrinted = false;
				this.BestBallPrinted = false;
				this.Rotation123Printed = false;
				this.Rotation321Printed = false;
				this.TeamSkinsPrinted = false;
				this.ScramblePrinted = false;

				// Setup Page Format
				PageSetupDialog myPageSetup = new PageSetupDialog();
				PrintDocument pd = new PrintDocument();
				myPageSetup.Document = pd;
				myPageSetup.PageSettings.PrinterSettings.Copies = this.Copies;
				myPageSetup.PageSettings.PrinterSettings.Collate = true;
				printerResolutionX = 300;
				printerResolutionY = 300;
				myPageSetup.PageSettings.Margins.Left = 25;
				myPageSetup.PageSettings.Margins.Right = 25;
				myPageSetup.PageSettings.Margins.Top = 50;
				myPageSetup.PageSettings.Margins.Bottom = 50;

				this.pagesPrinted = 0;
				this.yPos = 0;

				// Print the SELECTED REPORTS
				pd.PrintPage += new PrintPageEventHandler( this.PrintReports );

				pd.Print();

				myPageSetup.Dispose();
			}
			return;
		}
		//
		public void PreviewGames(int id)
		{
			// Get the Tournament Information
			tour = GetTournamentInfo( id );
			//
			// Get the GameScores for the specified tournament
			espDB.GetTLGameScores( id );
			//
			// Print each Game Standing Report (TourLiteGameScores)
			//
			if (this.Copies > 0)
			{
				this.SkinsPrinted = false;
				this.BestBallPrinted = false;
				this.Rotation123Printed = false;
				this.Rotation321Printed = false;
				this.TeamSkinsPrinted = false;
				this.ScramblePrinted = false;

				// Setup Page Format
				PageSetupDialog myPageSetup = new PageSetupDialog();
				PrintDocument pd = new PrintDocument();
				myPageSetup.Document = pd;
				myPageSetup.PageSettings.PrinterSettings.Copies = 1;
				myPageSetup.PageSettings.PrinterSettings.Collate = true;
				printerResolutionX = 300;
				printerResolutionY = 300;
				myPageSetup.PageSettings.Margins.Left = 25;
				myPageSetup.PageSettings.Margins.Right = 25;
				myPageSetup.PageSettings.Margins.Top = 50;
				myPageSetup.PageSettings.Margins.Bottom = 50;

				this.pagesPrinted = 0;
				this.yPos = 0;

				PrintPreviewDialog ppd = new PrintPreviewDialog();

				pd.PrintPage += new PrintPageEventHandler( this.PrintReports );

				//pd.Print();
				ppd.Document = pd;
				ppd.ShowDialog();

				myPageSetup.Dispose();
			}
			return;
		}
		//
		/// <summary>
		/// Printed report controller function
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PrintReports(object sender, PrintPageEventArgs e)
		{
			e.Graphics.PageUnit = GraphicsUnit.Document;
			this.leftMargin = ((e.MarginBounds.Left*printerResolutionX)/100);
			this.topMargin = (e.MarginBounds.Top*printerResolutionY)/100;
			this.pageLeft = e.PageBounds.Left;
			this.pageRight = e.PageBounds.Right;
			this.pageTop = e.PageBounds.Top;
			this.pageBottom = e.PageBounds.Bottom;
			this.pageHeight = (e.MarginBounds.Height/100)*printerResolutionY;
			this.pageWidth = (int)((e.MarginBounds.Width/100)*printerResolutionX);
			this.lineHeight = (int)this.espFont10.GetHeight(e.Graphics);

			this.linesPerPage = (int)(this.pageHeight / this.lineHeight);
			yPos = topMargin;

			// Print the SELECTED REPORTS
			// Scores
			if ( this.Skins & !this.SkinsPrinted )
			{
				pdPrintSkins(sender,e);
				this.SkinsPrinted = true;
				if (this.BestBall & !this.BestBallPrinted) this.NewPage = true;
			}

			// Check to see if a new page is needed yet
			if (this.NewPage)
			{
				this.NewPage = false;
				e.HasMorePages = true;
				return;
			}
			// Best Ball
			if ( this.BestBall & !this.BestBallPrinted)
			{
				pdPrintBestBall(sender,e);
				this.BestBallPrinted = true;
				if ( this.Skins & !this.SkinsPrinted ) this.NewPage = true;
			}

			// Check to see if a new page is needed yet
			if (this.NewPage)
			{
				this.NewPage = false;
				e.HasMorePages = true;
				return;
			}
			/*

						// Game Reconciliation
						if ( espDB.g_State.PrintGameReconciliation & !this.ReconciliationPrinted )
						{
							pdPrintGameReconciliation(sender,e);
							this.ReconciliationPrinted = true;
						}
			*/			
		}
		//
		private void pdPrintSkins(object sender, PrintPageEventArgs e)
		{
			Graphics graph = e.Graphics;
			int xpos = (int)leftMargin;
			int ypos = (int)yPos;
			string temp = "";
			StringFormat sf = new StringFormat();
			sf.Alignment = StringAlignment.Center;
			//
			// Print Header for SKINS Standings Report
			if (tour.DateStart == tour.DateEnd)
				temp = "Held on "+tour.DateStart.ToShortDateString();
			else
				temp = "From: "+tour.DateStart.ToShortDateString()+"     To: "+tour.DateEnd.ToShortDateString();
			PrintHeader(graph,tour.Name,"Individual SKINS Tournament",temp);
			ypos = (int)yPos;
			//
			// Get the SKINS Data AND determine winners
			DataTable dt;
			DataRow [] dr;
			byte gameType = 0;
			byte hole = 0;
			byte score = 0;
			string scoreField = "Hole";
			string scoreXField = "HoleX";
			Winners [] winners = new Winners[Global.MAX_HOLES];
			//
			for (int h=0;h<Global.MAX_HOLES;h++)
			{
				hole = (byte)(h+1);
				scoreField = "Hole"+hole.ToString();
				scoreXField = "HoleX"+hole.ToString();
				winners[h] = new Winners();
				//
				dt = ds.Tables["TLGameScores"];
				gameType = (byte)TOURNAMENT_GAME_TYPE.IndividualSkins;
				dr = dt.Select("GameType="+gameType.ToString(),scoreField);
				for (int i=0;i<dr.Length;i++)
				{
					if ((bool)dr[i][scoreXField]) continue;
					//
					score = (byte)dr[i][scoreField];
					if ((winners[h].Count == 0) | (score < winners[h].Score) )
					{
						// New Low Score
						if (winners[h].Count != 0)
						{
							winners[h].Count = 0;
							winners[h].TeamID.Clear();
						}
						winners[h].Count++;
						winners[h].Score = score;
						winners[h].TeamID.Add( (int)dr[i]["TLTeamID"] );
					}
					else
					{
						if (score == winners[h].Score)
						{
							// If same score as low score update the ArrayList
							winners[h].Count++;
							winners[h].TeamID.Add( (int)dr[i]["TLTeamID"] );
						}
					}
				}
				winners[h].TeamID.Sort();
			}
			// Winners (if any were determined), for SKINS there can
			// be only one winner per hole, so check counts and if >1
			// clear the count, score, and TeamID list
			for (int h=0;h<Global.MAX_HOLES;h++)
			{
				if (winners[h].Count > 1)
				{
					winners[h].Score = 0;
					winners[h].Count = 0;
					winners[h].TeamID.Clear();
				}
			}
			//
			// Winners were determined, now print each score
			//
			dt = ds.Tables["TLGameScores"];
			gameType = (byte)TOURNAMENT_GAME_TYPE.IndividualSkins;
			dr = dt.Select("GameType="+gameType.ToString(),"TLTeamID");
			if (dr.Length > 0)
			{
				PrintOneLine(graph,dr[0],winners,TL_PRINT.Header);
				for (int i=0;i<dr.Length;i++)
				{
					// Print 1 Line for each Player
					PrintOneLine(graph,dr[i],winners,TL_PRINT.Body);
					ypos = (int)yPos;
				}
				PrintOneLine(graph,dr[0],winners,TL_PRINT.Total);
				ypos = (int)yPos;
			}
			else
			{
				PrintNoEntries(graph);
			}
			//
			// Draw Line Separator
			//ypos += 5;
			//graph.DrawLine(linePen,xpos,ypos,xpos+pageWidth,ypos);
			//yPos += 5;
		}
		//
		private void pdPrintSkinsR(object sender, PrintPageEventArgs e)
		{
			Graphics graph = e.Graphics;
			int xpos = (int)leftMargin;
			int ypos = (int)yPos;
			string temp = "";
			StringFormat sf = new StringFormat();
			sf.Alignment = StringAlignment.Center;
			//
			// Print Header for SKINS Standings Report
			if (tour.DateStart == tour.DateEnd)
				temp = "Held on "+tour.DateStart.ToShortDateString();
			else
				temp = "From: "+tour.DateStart.ToShortDateString()+"     To: "+tour.DateEnd.ToShortDateString();
			PrintHeader(graph,tour.Name,"Individual SKINS Tournament",temp);
			ypos = (int)yPos;
			//
			// Get the SKINS Data AND determine winners
			DataTable dt;
			DataRow [] dr;
			byte gameType = 0;
			byte hole = 0;
			byte score = 0;
			string scoreField = "Hole";
			string scoreXField = "HoleX";
			Winners [] winners = new Winners[Global.MAX_HOLES];
			//
			for (int h=0;h<Global.MAX_HOLES;h++)
			{
				hole = (byte)(h+1);
				scoreField = "Hole"+hole.ToString();
				scoreXField = "HoleX"+hole.ToString();
				winners[h] = new Winners();
				//
				dt = ds.Tables["TLGameScores"];
				gameType = (byte)TOURNAMENT_GAME_TYPE.IndividualSkins;
				dr = dt.Select("GameType="+gameType.ToString(),scoreField);
				for (int i=0;i<dr.Length;i++)
				{
					if ((bool)dr[i][scoreXField]) continue;
					//
					score = (byte)dr[i][scoreField];
					if ((winners[h].Count == 0) | (score < winners[h].Score) )
					{
						// New Low Score
						if (winners[h].Count != 0)
						{
							winners[h].Count = 0;
							winners[h].TeamID.Clear();
						}
						winners[h].Count++;
						winners[h].Score = score;
						winners[h].TeamID.Add( (int)dr[i]["TLTeamID"] );
					}
					else
					{
						if (score == winners[h].Score)
						{
							// If same score as low score update the ArrayList
							winners[h].Count++;
							winners[h].TeamID.Add( (int)dr[i]["TLTeamID"] );
						}
					}
				}
				winners[h].TeamID.Sort();
			}
			// Winners (if any were determined), for SKINS there can
			// be only one winner per hole, so check counts and if >1
			// clear the count, score, and TeamID list
			for (int h=0;h<Global.MAX_HOLES;h++)
			{
				if (winners[h].Count > 1)
				{
					winners[h].Score = 0;
					winners[h].Count = 0;
					winners[h].TeamID.Clear();
				}
			}
			//
			// Winners were determined, now print each score
			//
			dt = ds.Tables["TLGameScores"];
			gameType = (byte)TOURNAMENT_GAME_TYPE.IndividualSkins;
			dr = dt.Select("GameType="+gameType.ToString(),"TLTeamID");
			if (dr.Length > 0)
			{
				PrintOneLine(graph,dr[0],winners,TL_PRINT.Header);
				for (int i=0;i<dr.Length;i++)
				{
					// Print 1 Line for each Player
					PrintOneLine(graph,dr[i],winners,TL_PRINT.Body);
					ypos = (int)yPos;
				}
				PrintOneLine(graph,dr[0],winners,TL_PRINT.Total);
				ypos = (int)yPos;
			}
			else
			{
				PrintNoEntries(graph);
			}
			//
			// Draw Line Separator
			//ypos += 5;
			//graph.DrawLine(linePen,xpos,ypos,xpos+pageWidth,ypos);
			//yPos += 5;
		}
		//
		private void pdPrintBestBall(object sender, PrintPageEventArgs e)
		{
			Graphics graph = e.Graphics;
			int xpos = (int)leftMargin;
			int ypos = (int)yPos;
			string temp = "";
			StringFormat sf = new StringFormat();
			sf.Alignment = StringAlignment.Center;
			DataTable dt, dt2;
			DataRow [] dr, dr2;
			DataRow summary, current, addrow;
			byte curval;
			short curtot;
			byte gameType = 0;
			int holeno = 0;
			string hole, holeX;
			bool process;
			//
			dt = ds.Tables["TLGameScores"];
			gameType = (byte)TOURNAMENT_GAME_TYPE.TeamBestBall;
			dr = dt.Select("GameType="+gameType.ToString(),"TLTeamID");
			dt2 = dt.Clone();
			if (dr.Length > 0)
			{
				summary = dt.NewRow();
				process = false;
				for (int i=0;i<dr.Length;i++)
				{
					current = dr[i];
					// Print 1 Line for each Team
					// Create Summary Records
					if (i == 0) process = false;
					else if ((int)current["TLTeamID"] == (int)summary["TLTeamID"]) process = true;
					else process = false;
					if (process)
					{
						// Add values to summary
						for (int hi=0;hi<Global.MAX_HOLES;hi++)
						{
							holeno = hi+1;
							hole = "Hole"+holeno.ToString();
							holeX = "HoleX"+holeno.ToString();
							curval = (byte)((byte)summary[hole] + (byte)current[hole]);
							summary[hole] = curval;
							if ((bool)current[holeX]) summary[holeX] = current[holeX];
						}
						curtot = (short)((short)summary["Total"] + (short)current["Total"]);
						summary["Total"] = curtot;
					}
					else
					{
						// if not the first record print summary before resetting
						if (i > 0)
						{
							addrow = dt2.NewRow();
							CopyDataRow(ref addrow,summary);
							dt2.Rows.Add(addrow);
						}
						// Initialize summary to current record
						summary = current;
					}
				}
				addrow = dt2.NewRow();
				CopyDataRow(ref addrow,summary);
				dt2.Rows.Add(addrow);
				// PPPPPPPPPPPPPPPPPPPPP2
				// Print 2-Man BB
				// Print Header for Best Ball Standings Report
				dr2 = dt2.Select("TeamSize=2","TeamSize, Total");
				if (dr2.Length > 0)
				{
					if (tour.DateStart == tour.DateEnd)
						temp = "Held on "+tour.DateStart.ToShortDateString();
					else
						temp = "From: "+tour.DateStart.ToShortDateString()+"     To: "+tour.DateEnd.ToShortDateString();
					PrintHeader(graph,tour.Name,"Best Ball Tournament",temp);
					ypos = (int)yPos;
					//
					// now print each score
					//
					PrintBBOneLine(graph,dr2[0],TL_PRINT.Header);
					for (int i=0;i<dr2.Length;i++)
					{
						PrintBBOneLine(graph,dr2[i],TL_PRINT.Body);
						ypos = (int)yPos;
					}
					// PPPPPPPPPPPPPPPPPPPPP2
					yPos += (int)(0.5*this.printerResolutionY);
				}
				// PPPPPPPPPPPPPPPPPPPPP5
				// Print 4-Man BB
				// Print Header for Best Ball Standings Report
				dr2 = dt2.Select("TeamSize>2","TeamSize, Total");
				if (dr2.Length > 0)
				{
					if (tour.DateStart == tour.DateEnd)
						temp = "Held on "+tour.DateStart.ToShortDateString();
					else
						temp = "From: "+tour.DateStart.ToShortDateString()+"     To: "+tour.DateEnd.ToShortDateString();
					PrintHeader(graph,tour.Name,"Best Ball Tournament",temp);
					//
					ypos = (int)yPos;
					PrintBBOneLine(graph,dr2[0],TL_PRINT.Header);
					for (int i=0;i<dr2.Length;i++)
					{
						PrintBBOneLine(graph,dr2[i],TL_PRINT.Body);
						ypos = (int)yPos;
					}
				}
				// PPPPPPPPPPPPPPPPPPPPP5
			}
			else
			{
				PrintNoEntries(graph);
			}
		}
		//
		void CopyDataRow(ref DataRow outrow, DataRow inrow)
		{
			int hole = 0;
			string holeField = "";
			string holeXField = "";

			outrow["TLTeamID"] = inrow["TLTeamID"];
			outrow["TLGameID"] = inrow["TLGameID"];
			outrow["TeamSize"] = inrow["TeamSize"];
			outrow["RoundDate"] = inrow["RoundDate"];
			outrow["MilitaryTime"] = inrow["MilitaryTime"];
			outrow["Ball"] = inrow["Ball"];
			outrow["Total"] = inrow["Total"];
			for (int i=0;i<Global.MAX_HOLES;i++)
			{
				hole = i+1;
				holeField = "Hole" + hole.ToString();
				holeXField = "HoleX" + hole.ToString();
				outrow[holeField] = inrow[holeField];
				outrow[holeXField] = inrow[holeXField];
			}
		}
		//
		private void PrintHeader(Graphics graph, string gamename, string gametype, string gamedate)
		{
			int xpos = (int)leftMargin;
			int ypos = (int)yPos;
			int yt = 0;
			StringFormat sf = new StringFormat();
			sf.Alignment = StringAlignment.Center;
			//
			// Print Header for SKINS Standings Report
			yt = ((16*lineHeight)/10);
			RectangleF header = new RectangleF(xpos,ypos,pageWidth,yt);
			graph.DrawString(gamename,espFont14,Brushes.Black,header,sf);
			ypos += yt;
			yPos = ypos;
			yt = ((12*lineHeight)/10);
			header = new RectangleF(xpos,ypos,pageWidth,yt);
			graph.DrawString(gametype,espFont12,Brushes.Black,header,sf);
			ypos += yt;
			yPos = ypos;
			header = new RectangleF(xpos,ypos,pageWidth,yt);
			graph.DrawString(gamedate,	espFont12,Brushes.Black,header,sf);
			ypos += yt;
			yPos = ypos;
			//
			// Draw Line Separator
			//ypos += 5;
			//graph.DrawLine(linePen,xpos,ypos,xpos+pageWidth,ypos);
			yPos += 15;
		}
		//
		private void PrintNoEntries(Graphics graph)
		{
			int xpos = (int)leftMargin;
			int ypos = (int)yPos;
			int yt = 0;
			StringFormat sf = new StringFormat();
			sf.Alignment = StringAlignment.Center;
			//
			// Print Header for SKINS Standings Report
			yt = ((16*lineHeight)/10);
			RectangleF header = new RectangleF(xpos,ypos,pageWidth,yt);
			graph.DrawString("There were no scores reported for this tournament.",espFont14,Brushes.Black,header,sf);
			ypos += yt;
			yPos = ypos;
		}
		//
		private void PrintOneLine(Graphics graph, DataRow dr, Winners [] winners, TL_PRINT pf)
		{
			int hole = 0;
			string holeField = "";
			string holeXField = "";
			byte score = 0;
			int xpos = (int)leftMargin;
			int ypos = (int)yPos;
			int xt = 0;
			int yt = 0;
			StringFormat sf = new StringFormat();
			//
			sf.Alignment = StringAlignment.Near;
			yt = ((12*lineHeight)/10);
			//
			// NNNNNNNNNNNNNNNNNNNNTTTTTTTTTTTTTTTTTTTTTTTTTTT
			// Print Player Initials
			xt = (int)(1.50*this.printerResolutionX);
			Rectangle box = new Rectangle(xpos,ypos,xt,yt);
			RectangleF header;
			switch (pf)
			{
				case TL_PRINT.Header:
					graph.DrawRectangle(this.linePen,box);
					sf.Alignment = StringAlignment.Center;
					header = new RectangleF(xpos,ypos,xt,yt);
					graph.DrawString("Player Initials",espFont12,Brushes.Black,header,sf);
					xpos += xt;
					xt = (int)(0.5*this.printerResolutionX);
					box = new Rectangle(xpos,ypos,xt,yt);
					graph.DrawRectangle(this.linePen,box);
					header = new RectangleF(xpos,ypos+7,xt,yt);
					graph.DrawString("Tee Time",espFont8,Brushes.Black,header,sf);
					sf.Alignment = StringAlignment.Near;
					break;
				case TL_PRINT.Body:
					graph.DrawRectangle(this.linePen,box);
					header = new RectangleF(xpos,ypos+4,xt,yt);
					graph.DrawString(espDB.GetTLGameScoreInitials((int)dr["TLTeamID"]),espFont10,Brushes.Black,header,sf);
					xpos += xt;
					sf.Alignment = StringAlignment.Center;
					xt = (int)(0.5*this.printerResolutionX);
					box = new Rectangle(xpos,ypos,xt,yt);
					graph.DrawRectangle(this.linePen,box);
					header = new RectangleF(xpos,ypos+7,xt,yt);
					graph.DrawString(dr["MilitaryTime"].ToString(),espFont9,Brushes.Black,header,sf);
					sf.Alignment = StringAlignment.Near;
					break;
				case TL_PRINT.Total:
					xt = (int)(2.0*this.printerResolutionX);
					box = new Rectangle(xpos,ypos,xt,yt);
					graph.DrawRectangle(this.linePen,box);
					header = new RectangleF(xpos,ypos,xt,yt);
					graph.DrawString("TOTAL SKINS WON",espFont12B,Brushes.Black,header,sf);
					break;
			}
			// NNNNNNNNNNNNNNNNNNNNTTTTTTTTTTTTTTTTTTTTTTTTTTT
			xpos += xt;
			//
			// SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
			// Print Each HOLE SCORE
			sf.Alignment = StringAlignment.Center;
			xt = (int)(0.28*this.printerResolutionX);
			for (int i=0;i<Global.MAX_HOLES;i++)
			{
				hole = i+1;
				box = new Rectangle(xpos,ypos,xt,yt);
				graph.DrawRectangle(this.linePen,box);
				switch (pf)
				{
					case TL_PRINT.Header:
						header = new RectangleF(xpos,ypos,xt,yt);
						graph.DrawString(hole.ToString(),espFont12,Brushes.Black,header,sf);
						break;
					case TL_PRINT.Body:
						holeField = "Hole" + hole.ToString();
						holeXField = "HoleX" + hole.ToString();
						score = (byte)dr[holeField];
						if ((bool)dr[holeXField])
						{
							// Draw an X in the score box
							graph.DrawLine(xPen,xpos+1,ypos+1,xpos+xt-1,ypos+yt-1);
							graph.DrawLine(xPen,xpos+1,ypos+yt-1,xpos+xt-1,ypos+1);
						}
						if ((winners[i].Count > 0) & ((bool)winners[i].TeamID.Contains(dr["TLTeamID"])))
						{
							// Display WINNER box
							header = new RectangleF(xpos,ypos,xt,yt);
							graph.FillRectangle(Brushes.DarkGreen,xpos,ypos,xt,yt);
							graph.DrawString(score.ToString(),espFont12B,Brushes.White,header,sf);
						}
						else
						{
							header = new RectangleF(xpos,ypos+4,xt,yt);
							graph.DrawString(score.ToString(),espFont10,Brushes.Black,header,sf);
						}
						break;
					case TL_PRINT.Total:
						/*
						header = new RectangleF(xpos,ypos,xt,yt);
						if (winners[i].Count > 0)
						{
							// Display WINNER box
							graph.DrawString("1",espFont12B,Brushes.Black,header,sf);
						}
						else
						{
							graph.DrawString("-",espFont12B,Brushes.Black,header,sf);
						}
						*/
						break;
				}
				xpos += xt;
			}
			// SSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
			// WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
			byte skinsWon = 0;
			xt = (int)(0.40*this.printerResolutionX);
			box = new Rectangle(xpos,ypos,xt,yt);
			graph.DrawRectangle(this.linePen,box);
			sf.Alignment = StringAlignment.Center;
			switch (pf)
			{
				case TL_PRINT.Header:
					header = new RectangleF(xpos,ypos+7,xt,yt);
					graph.DrawString("Won",espFont10,Brushes.Black,header,sf);
					break;
				case TL_PRINT.Body:
					for (byte i=0;i<Global.MAX_HOLES;i++)
					{
						if ((winners[i].Count > 0) & ((bool)winners[i].TeamID.Contains(dr["TLTeamID"]))) skinsWon++;
					}
					header = new RectangleF(xpos,ypos,xt,yt);
					if (skinsWon > 0) graph.DrawString(skinsWon.ToString(),espFont12B,Brushes.Black,header,sf);
					break;
				case TL_PRINT.Total:
					for (byte i=0;i<Global.MAX_HOLES;i++)
					{
						if (winners[i].Count > 0) skinsWon++;
					}
					header = new RectangleF(xpos,ypos,xt,yt);
					if (skinsWon > 0) graph.DrawString(skinsWon.ToString(),espFont12B,Brushes.Black,header,sf);
					break;
			}
			// WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW
			// Get Ready for Next Line
			ypos += yt;
			yPos = ypos;
		}
		//
		private void PrintBBOneLine(Graphics graph, DataRow dr, TL_PRINT pf)
		{
			int hole = 0;
			string holeField = "";
			string holeXField = "";
			byte score = 0;
			short front9=0, back9=0, total=0;
			int xpos = (int)leftMargin;
			int ypos = (int)yPos;
			int xt = 0, xt2=0;
			int yt = 0;
			StringFormat sf = new StringFormat();
			//
			sf.Alignment = StringAlignment.Near;
			yt = ((12*lineHeight)/10);
			//
			// Print Player Initials
			xt = (int)(1.75*this.printerResolutionX);
			Rectangle box = new Rectangle(xpos,ypos,xt,yt);
			Rectangle box2;
			RectangleF header;
			//
			graph.DrawRectangle(this.linePen,box);
			switch (pf)
			{
				case TL_PRINT.Header:
					sf.Alignment = StringAlignment.Center;
					header = new RectangleF(xpos,ypos,xt,yt);
					graph.DrawString("Team Player Initials",espFont12,Brushes.Black,header,sf);
					xpos += xt;
					xt = (int)(0.5*this.printerResolutionX);
					box = new Rectangle(xpos,ypos,xt,yt);
					graph.DrawRectangle(this.linePen,box);
					header = new RectangleF(xpos,ypos+7,xt,yt);
					graph.DrawString("Tee Time",espFont8,Brushes.Black,header,sf);
					sf.Alignment = StringAlignment.Near;
					break;
				case TL_PRINT.Body:
					header = new RectangleF(xpos,ypos+4,xt,yt);
					graph.DrawString(espDB.GetTLGameScoreInitials((int)dr["TLTeamID"]),espFont10,Brushes.Black,header,sf);
					xpos += xt;
					sf.Alignment = StringAlignment.Center;
					xt = (int)(0.5*this.printerResolutionX);
					box = new Rectangle(xpos,ypos,xt,yt);
					graph.DrawRectangle(this.linePen,box);
					header = new RectangleF(xpos,ypos+7,xt,yt);
					graph.DrawString(dr["MilitaryTime"].ToString(),espFont9,Brushes.Black,header,sf);
					sf.Alignment = StringAlignment.Near;
					break;
			}
			xpos += xt;
			//
			// Print Each HOLE SCORE
			sf.Alignment = StringAlignment.Center;
			xt = (int)(0.23*this.printerResolutionX);
			xt2 = (int)(0.4*this.printerResolutionX);
			for (int i=0;i<Global.MAX_HOLES;i++)
			{
				hole = i+1;
				box = new Rectangle(xpos,ypos,xt,yt);
				graph.DrawRectangle(this.linePen,box);
				switch (pf)
				{
					case TL_PRINT.Header:
						header = new RectangleF(xpos,ypos,xt,yt);
						graph.DrawString(hole.ToString(),espFont12,Brushes.Black,header,sf);
						xpos += xt;
						if ((hole%9) == 0)
						{
							box2 = new Rectangle(xpos,ypos,xt2,yt);
							header = new RectangleF(xpos,ypos+7,xt2,yt);
							if ((hole%18) != 0)
							{
								graph.DrawRectangle(this.linePen,box2);
								graph.DrawString("Front9",espFont9,Brushes.Black,header,sf);
							}
							else
							{
								graph.DrawRectangle(this.linePen,box2);
								graph.DrawString("Back9",espFont9,Brushes.Black,header,sf);
								xpos += xt2;
								box2 = new Rectangle(xpos,ypos,xt2,yt);
								graph.DrawRectangle(this.linePen,box2);
								header = new RectangleF(xpos,ypos+7,xt2,yt);
								graph.DrawString("Total",espFont10,Brushes.Black,header,sf);
							}
							xpos += xt2;
						}
						break;
					case TL_PRINT.Body:
						holeField = "Hole" + hole.ToString();
						holeXField = "HoleX" + hole.ToString();
						score = (byte)dr[holeField];
						if (i < 9) front9 += (short)score;
						if ((i >= 9) & (i <Global.MAX_HOLES)) back9 += (short)score;
						if ((bool)dr[holeXField])
						{
							// Draw an X in the score box
							graph.DrawLine(xPen,xpos+1,ypos+1,xpos+xt-1,ypos+yt-1);
							graph.DrawLine(xPen,xpos+1,ypos+yt-1,xpos+xt-1,ypos+1);
						}
						header = new RectangleF(xpos,ypos+4,xt,yt);
						graph.DrawString(score.ToString(),espFont10,Brushes.Black,header,sf);
						xpos += xt;
						if ((hole%9) == 0)
						{
							box2 = new Rectangle(xpos,ypos,xt2,yt);
							header = new RectangleF(xpos,ypos+4,xt2,yt);
							if ((hole%Global.MAX_HOLES) != 0)
							{
								graph.DrawRectangle(this.linePen,box2);
								graph.DrawString(front9.ToString(),espFont10,Brushes.Black,header,sf);
							}
							else
							{
								graph.DrawRectangle(this.linePen,box2);
								graph.DrawString(back9.ToString(),espFont10,Brushes.Black,header,sf);
								xpos += xt2;
								box2 = new Rectangle(xpos,ypos,xt2,yt);
								graph.DrawRectangle(this.linePen,box2);
								header = new RectangleF(xpos,ypos+4,xt2,yt);
								total = (short)dr["Total"];
								graph.DrawString(total.ToString(),espFont10,Brushes.Black,header,sf);
							}
							xpos += xt2;
						}
						break;
				}
			}
			//
			ypos += yt;
			yPos = ypos;
		}
		//
		// private definitions
		//
		private TOURLITE_INFORMATION GetTournamentInfo(int id)
		{
			TOURLITE_INFORMATION tour = new TOURLITE_INFORMATION();

			// Make sure that the selected Tournament Data is in DataSet.
			espDB.GetSelectedTournament(id);
			//
			DataTable dt;
			DataRow[] dr;
			//
			dt = ds.Tables["AEDTournament"];
			dr = dt.Select();
			tour.ID = id;
			tour.Name = dr[0]["Name"].ToString();
			tour.DateStart = DateTime.Parse(dr[0]["DateStart"].ToString());
			tour.DateEnd = DateTime.Parse(dr[0]["DateEnd"].ToString());
			dr = null;
			dt = null;
			//
			return tour;
		}
		//
		private void GetGameInfo(int id)
		{
			// Make sure that the selected Tournament Data is in DataSet.
			espDB.GetSelectedTournamentGames(id);
			//
			DataTable dt;
			DataRow[] dr;
			//
			dt = ds.Tables["TourLiteGames"];
			dr = dt.Select();

			// Add Data to the Game Info Class
			game = new TLGAME_INFORMATION[dr.Length];
			for(int i=0;i<dr.Length;i++)
			{
				game[i] = new TLGAME_INFORMATION();
				game[i].ID = (int)dr[i]["TLGameID"];
				game[i].TeamGame = (bool)dr[i]["TeamGame"];
				game[i].TeamSize = (byte)dr[i]["TeamSize"];
				game[i].NumberOfTeams = (byte)dr[i]["NumberOfTeams"];
				game[i].GameType = (TOURNAMENT_GAME_TYPE)(byte)dr[i]["GameType"];
				game[i].DrivesPerPlayer = (byte)dr[i]["DrivesPerPlayer"];
				game[i].GameFlags = (uint)(int)dr[i]["GameFlags"];
				game[i].Ball1GrossNet = (byte)dr[i]["Ball1GrossNet"];
				game[i].Ball2GrossNet = (byte)dr[i]["Ball2GrossNet"];
				game[i].Ball3GrossNet = (byte)dr[i]["Ball3GrossNet"];
				game[i].Ball4GrossNet = (byte)dr[i]["Ball4GrossNet"];
				game[i].Ball5GrossNet = (byte)dr[i]["Ball5GrossNet"];
			}
			dr = null;
			dt = null;

			return;
		}
		// ============================
		// Property Definitions
		// ============================
		public bool Skins
		{
			get{ return _Skins; }
			set{ _Skins = value; }
		}
		public bool BestBall
		{
			get{ return _BestBall; }
			set{ _BestBall = value; }
		}
		public bool Rotation123
		{
			get{ return _123Rotation; }
			set{ _123Rotation = value; }
		}
		public bool Rotation321
		{
			get{ return _321Rotation; }
			set{ _321Rotation = value; }
		}
		public bool TeamSkins
		{
			get{ return _TeamSkins; }
			set{ _TeamSkins = value; }
		}
		public bool Scramble
		{
			get{ return _Scramble; }
			set{ _Scramble = value; }
		}
		public byte Copies
		{
			get{ return _Copies; }
			set{ _Copies = value; }
		}
		// ============================
		// ============================
	}
}
