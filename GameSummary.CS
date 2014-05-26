using System;

namespace ESPmanager
{
	/// <summary>
	/// Summary description for GameSummary.
	///////////////////////////////////////////////////////////////////////
	/// GameSummaryForm.c - handlers for the game summary form
	/// Copyright (c) 2002, golfESP
	/// Created for Palm by Joshua Buergel
	/// Modified for .NET by Melvin Lervick 
	///////////////////////////////////////////////////////////////////////
	/// </summary>
	public class GameSummary
	{
		Database espDB;
		// which piece of data are we looking at
		private byte	g_DataPiece = 0;
		// how big are the data pieces
		private byte	g_DataPieceSize;


		// maximum handicap
		//#define MAX_HANDICAP			(0x7FFF)
		//#define MIN_HANDICAP			(0x8000)
		//#define MAX_SCORE				(0x7F)
		private const short MAX_HANDICAP = 0x7FFF;
		private const short MIN_HANDICAP = -1;
		private const byte MAX_SCORE = 0x7F;

		public GameSummary(ref Database db)
		{
			//
			// TODO: Add constructor logic here
			//
			espDB = db;
		}

		///////////////////////////////////////////////////////////////////////
		//  GameSummaryComputeGame - computes a game
		//  Input:  pGame - the game to use
		//  Output: none
		//  Return: none
		//  Notes:
		///////////////////////////////////////////////////////////////////////
		public byte GameSummaryComputeGame(GAME_INFORMATION pGame)
		{
			byte				numHoles = 0;		// number of holes we have data for
	
			// clear the game scores valid flag on all players
			GameSummaryClearGameScoresValid();
			//
			// set the data piece info here
			GameSummarySetDataPieceInfo(pGame);
			//
			// calculate the handicaps for this game
			GameSummaryCalculateHandicaps(pGame);

			// compute based on the game data
			//switch (pGame->GameType) 
			switch (pGame.GameType) 
			{
				case GAME_TYPE.TournamentGame:
					// Computed in "TourLiteCompute"
					/* switch based on the tournament type
					switch (pGame->TournamentType) 
					{
						case TournamentBestBall:
							numHoles = GameSummaryTournamentBestBall(pGame);
							break;
					}
					*/
					break;
				case GAME_TYPE.IndividualMatch:
					numHoles = GameSummaryIndividualMatch(pGame);
					break;
				case GAME_TYPE.IndividualSkins:
					numHoles = GameSummaryIndividualSkins(pGame);
					break;
				case GAME_TYPE.IndividualStats:
					numHoles = GameSummaryIndividualStats(pGame);
					break;
				case GAME_TYPE.IndividualNines:
					numHoles = GameSummaryIndividualNines(pGame);
					break;
				case GAME_TYPE.TeamBestBall:
					numHoles = GameSummaryTeamBestBall(pGame);
					break;
				case GAME_TYPE.TeamHighLow:
					numHoles = GameSummaryTeamHighLow(pGame);
					break;
				case GAME_TYPE.TeamBestBallAggregate:
					numHoles = GameSummaryTeamBestBallAggregate(pGame);
					break;
				case GAME_TYPE.TeamSkins:
					numHoles = GameSummaryTeamSkins(pGame);
					break;
				case GAME_TYPE.TeamWolfHighLow:
					numHoles = GameSummaryTeamWolfHighLow(pGame);
					break;
				case GAME_TYPE.TeamWolfBestBall:
					numHoles = GameSummaryTeamWolfBestBall(pGame);
					break;
			}

			// compute where the presses lie
			GameSummaryComputePresses(pGame, numHoles);

			// return the number of holes
			return numHoles;
		}

		///////////////////////////////////////////////////////////////////////
		//  GameSummaryCalculateHandicaps - calculates the strokes for each player
		//  Input:  pGame - the game to use
		//  Output: none
		//  Return: none
		//  Notes:
		///////////////////////////////////////////////////////////////////////
		void GameSummaryCalculateHandicaps(GAME_INFORMATION	pGame)
		{
			byte								ii;										// loop variable
			byte								jj;										// loop variable
			sbyte							currentStrokes;				// the current strokes value
			TEE_INFORMATION	pTeeInfo;							// the information for a set of tees
			PLAYER_INFORMATION	pPlayer;					// the player info
			byte	[]							team = new byte[Global.MAX_PLAYERS];	// the team we're examining
			byte								teamNumber;					// which team we're working on

			// switch depending on the handicap type
			switch (pGame.GameFlags & Global.GAME_FLAG_HANDICAP_MASK) 
			{
				case Global.GAME_FLAG_NET_DIFF:
					//   for rotating teams or one team, we perform a different calculation
					if (((pGame.GameFlags & Global.GAME_FLAG_ONE_TEAM) == Global.GAME_FLAG_ONE_TEAM) |
						((pGame.GameFlags & Global.GAME_FLAG_ROTATE_TEAMS) == Global.GAME_FLAG_ROTATE_TEAMS))
					{
						// compute the net diff for one team
						GameSummaryComputeNetDiffNoTeam(pGame);
					} 
					else 
					{
						// compute the net diff for multiple teams
						GameSummaryComputeNetDiff(pGame);
					}
					break;
				case Global.GAME_FLAG_NET:
  					// loop over the teams
  	  				for (teamNumber = 0; true; teamNumber++) {
  	  	  				// get the next team - note that we use hole
  	  	  				// 0 here, which is fine.  If we have rotating
  	  	  				// teams, this always gives us the first teams,
  	  	  				// but it doesn't matter, since the teams aren't
  	  	  				// used in any calculations
  	  	  				if (!GameSummaryGetTeam(pGame, teamNumber, 0, ref team)) {
  	  	  	  				break;
  	  	  				}
						// loop over the players
						for (ii = 0; ii < pGame.TeamSize; ii++) 
						{
							// get the player info
							pPlayer = espDB.GetPlayerInfo(team[ii]);
							// get the course information for this player
							pTeeInfo = GameSummaryGetTeeInfo(team[ii]);
							// distribute their strokes
							GameSummaryComputeNetStrokes(pPlayer, team[ii], pTeeInfo);
						}
					}
					break;
				case Global.GAME_FLAG_GROSS:
					// nobody gets any strokes
					currentStrokes = 0;
					// loop over the teams
					for (teamNumber = 0; true; teamNumber++) 
					{
						// get the next team
						if (!GameSummaryGetTeam(pGame, teamNumber, 0, ref team)) 
						{
							break;
						}
						// loop over the players
						for (ii = 0; ii < pGame.TeamSize; ii++) 
						{
							// get the player info
							pPlayer = espDB.GetPlayerInfo(team[ii]);
							// clear out the strokes for the player on this team
							for (jj = 0; jj < Global.MAX_HOLES; jj++) 
							{
								pPlayer.Strokes[jj] = (sbyte)currentStrokes;
							}
							// write to the player
							espDB.WriteToPlayer(pPlayer, team[ii]);
						}
					}
					break;
			}
		}

		///////////////////////////////////////////////////////////////////////
		//  GameSummaryComputeNetStrokes - figures the strokes for net for one player
		//  Input:  pPlayer - the player to modify
		//			pTeeInfo - the tee information for this player
		//  Output: none
		//  Return: 
		//  Notes:
		///////////////////////////////////////////////////////////////////////
		void GameSummaryComputeNetStrokes(PLAYER_INFORMATION pPlayer, 
			byte index,
			TEE_INFORMATION pTeeInfo)
		{
			short		strokes;						// extra strokes to give
			short		baseStrokes;				// the base number of strokes
			sbyte		currentStrokes;			// the current strokes value
			byte			ii;									// loop variable
	
			// calculate the base number of strokes
			// this is the number of times MAX_HOLES goes
			// into the difference between handicaps
			baseStrokes = (short)(pPlayer.ComputedHandicap / Global.MAX_HOLES);

			// get the remainder - these are the odd strokes we'll
			// hand out
			// note that we take the absolute value here - we only use
			// this as a threshold
			strokes = (short)Math.Abs(pPlayer.ComputedHandicap - (baseStrokes * Global.MAX_HOLES));

			// loop over the holes
			for (ii = 0; ii < Global.MAX_HOLES; ii++) 
			{
				// if this hole's handicap is <= strokes,
				// it gets an extra, otherwise, it gets
				// the base amount
				if (pTeeInfo.Holes[ii].Handicap <= strokes) 
				{
					// set the current strokes
					// note the adjustment for negative handicaps
					if (pPlayer.ComputedHandicap < 0) 
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
				pPlayer.Strokes[ii] = (sbyte)currentStrokes;
			}
			espDB.WriteToPlayer(pPlayer, index);
		}

		///////////////////////////////////////////////////////////////////////
		//  GameSummaryComputeNetDiff - figures the strokes for net diff
		//  Input:  pGame - the game to use
		//  Output: none
		//  Return: 
		//  Notes:
		///////////////////////////////////////////////////////////////////////
		void GameSummaryComputeNetDiff(GAME_INFORMATION pGame)
		{
			short []									teamHandicap = new short[Global.MAX_TEAMS];	// total team handicap
			byte										ii;									// loop variable
			byte										jj;									// loop variable
			short									strokes;						// extra strokes to give
			short									baseStrokes;				// the base number of strokes
			PLAYER_INFORMATION	pPlayer;						// the player info
			TEE_INFORMATION			pTeeInfo;						// the information for a set of tees
			sbyte									currentStrokes;			// the current strokes value
			short []									highestHandicap = new short[Global.MAX_TEAMS];	// highest handicap we've seen
			byte []									highestPlayer = new byte[Global.MAX_TEAMS];			// the player with the highest handicap
			byte []									team = new byte[Global.MAX_PLAYERS];						// the team we're examining
			byte										teamNumber;				// which team we're working on
			byte										targetPlayer;				// the player who will get strokes
	
			// set the current strokes
			currentStrokes = 0;
			// total the handicaps for each team
			for (teamNumber = 0; true; teamNumber++) 
			{
				// get the next team
				if (!GameSummaryGetTeam(pGame, teamNumber, 0, ref team)) 
				{
					break;
				}
				// clear the total handicap
				teamHandicap[teamNumber] = 0;
				// clear the highest handicap and highest player
				highestHandicap[teamNumber] = MIN_HANDICAP;
				highestPlayer[teamNumber] = 0;
				// loop through the players
				for (ii = 0; ii < pGame.TeamSize; ii++) 
				{
					// add in this player's handicap
					teamHandicap[teamNumber] += GameSummaryGetHandicap(team[ii]);
					// clear their strokes
					// get the player info
					pPlayer = espDB.GetPlayerInfo(team[ii]);
					// loop over the holes
					for (jj = 0; jj < Global.MAX_HOLES; jj++) 
					{
						// write to the player
						pPlayer.Strokes[jj] = (sbyte)currentStrokes;
					}
					espDB.WriteToPlayer(pPlayer, team[ii]);
					// see if this is the highest handicap
					if (GameSummaryGetHandicap(team[ii]) > highestHandicap[teamNumber]) 
					{
						// record this player
						highestHandicap[teamNumber] = GameSummaryGetHandicap(team[ii]);
						highestPlayer[teamNumber] = team[ii];
					}
				}
			}
			// see which one is lower
			if (teamHandicap[0] < teamHandicap[1]) 
			{
				// calculate the base number of strokes
				// this is the number of times MAX_HOLES goes
				// into the difference between handicaps
				baseStrokes = (short)((teamHandicap[1] - teamHandicap[0]) / Global.MAX_HOLES);

				// get the remainder - these are the odd strokes we'll hand out
				// take the absolute value, because it's just used as a threshold
				strokes = (short)Math.Abs((teamHandicap[1] - teamHandicap[0]) - (baseStrokes * Global.MAX_HOLES));
				// remember the index of the highest player
				targetPlayer = highestPlayer[1];
			} 
			else 
			{
				// calculate the base number of strokes
				// this is the number of times MAX_HOLES goes
				// into the difference between handicaps
				baseStrokes = (short)((teamHandicap[0] - teamHandicap[1]) / Global.MAX_HOLES);

				// get the remainder - these are the odd strokes we'll hand out
				// take the absolute value, because it's just used as a threshold
				strokes = (short)Math.Abs((teamHandicap[0] - teamHandicap[1]) - (baseStrokes * Global.MAX_HOLES));
				// remember the index of the highest player
				targetPlayer = highestPlayer[0];
			}

			// now, we give the strokes to the highest player
			// get the course information for the highest player
			pTeeInfo = GameSummaryGetTeeInfo(targetPlayer);

			// get the player info for the highest player
			pPlayer = espDB.GetPlayerInfo(targetPlayer);
			// loop over the holes
			for (jj = 0; jj < Global.MAX_HOLES; jj++) 
			{
				// if this hole's handicap is <= strokes,
				// it gets an extra, otherwise, it gets
				// the base amount
				if (pTeeInfo.Holes[jj].Handicap <= strokes) 
				{
					// set the current strokes
					// this can NEVER be negative - by definition, we're looking at
					// the worst player here
					currentStrokes = (sbyte)(baseStrokes + 1);
				} 
				else 
				{
					// set the current strokes
					currentStrokes = (sbyte)baseStrokes;
				}
				pPlayer.Strokes[jj] = (sbyte)currentStrokes;
			}
			// write to the player
			espDB.WriteToPlayer(pPlayer, targetPlayer);
		}

		///////////////////////////////////////////////////////////////////////
		//  GameSummaryComputeNetDiffNoTeam - figures the strokes for one or rotating teams/net diff
		//  Input:  pGame - the game to use
		//  Output: none
		//  Return: 
		//  Notes:
		///////////////////////////////////////////////////////////////////////
		void GameSummaryComputeNetDiffNoTeam(GAME_INFORMATION pGame)
		{
			byte										ii;								// loop variable
			byte										jj;								// loop variable
			short									strokes;					// extra strokes to give
			short									baseStrokes;			// the base number of strokes
			short									lowestHandicap = MAX_HANDICAP;	// the lowest handicap we found
			PLAYER_INFORMATION	pPlayer;					// the player info
			TEE_INFORMATION			pTeeInfo;					// the information for a set of tees
			sbyte									currentStrokes;		// the current strokes value
			byte []									team = new byte[Global.MAX_PLAYERS];				// the team we're examining
			byte										teamNumber;			// which team we're working on

			// loop over the teams	
			for (teamNumber = 0; true; teamNumber++) 
			{
				// get the next team
				if (!GameSummaryGetTeam(pGame, teamNumber, 0, ref team)) 
				{
					break;
				}
				// loop over the players
				for (ii = 0; ii < pGame.TeamSize; ii++) 
				{
					// see if this is the lowest yet
					if (GameSummaryGetHandicap(team[ii]) < lowestHandicap) 
					{
						// record this player
						lowestHandicap = GameSummaryGetHandicap(team[ii]);
					}
				}
			}
	
			// now, loop over the teams again, distributing strokes
			for (teamNumber = 0; true; teamNumber++) 
			{
				// get the next team
				if (!GameSummaryGetTeam(pGame, teamNumber, 0, ref team)) 
				{
					break;
				}	
				// loop over the players
				for (ii = 0; ii < pGame.TeamSize; ii++) 
				{
					// get the player info
					pPlayer = espDB.GetPlayerInfo(team[ii]);

					// get the course information for this player
					pTeeInfo = GameSummaryGetTeeInfo(team[ii]);

					// calculate the base number of strokes
					// this is the number of times MAX_HOLES goes
					// into the difference between handicaps
					baseStrokes = (short)((pPlayer.ComputedHandicap - lowestHandicap) / Global.MAX_HOLES);

					// get the remainder - these are the odd strokes we'll hand out
					// we take the absolute value because it's just a threshold
					strokes = (short)Math.Abs((pPlayer.ComputedHandicap - lowestHandicap) - (baseStrokes * Global.MAX_HOLES));
					// loop over the holes
					for (jj = 0; jj < Global.MAX_HOLES; jj++) 
					{
						// if this hole's handicap is <= strokes,
						// it gets an extra, otherwise, it gets
						// the base amount
						if (pTeeInfo.Holes[jj].Handicap <= strokes) 
						{
							// set the current strokes
							// this can NEVER be negative - by definition, we're looking at
							// the worst player here
							currentStrokes = (sbyte)(baseStrokes + 1);
						} 
						else 
						{
							// set the current strokes
							currentStrokes = (sbyte)baseStrokes;
						}
						// write to the player
						pPlayer.Strokes[jj] = (sbyte)currentStrokes;
					}
					// write to the player
					espDB.WriteToPlayer(pPlayer, team[ii]);
				}
			}
		}

		///////////////////////////////////////////////////////////////////////
		//  GameSummaryIndividualMatch - computes an individual match
		//  Input:  pGame - the game to use
		//  Output: none
		//  Return: none
		//  Notes:
		///////////////////////////////////////////////////////////////////////
		byte GameSummaryIndividualMatch(GAME_INFORMATION pGame)
		{
			byte				ii;						// loop variable
			short				cumScore;	// cumulative score for this match
			PLAYER_INFORMATION	pPlayer1;								// player information from team 1
			//MemHandle			hRecord1;	// the record for the player from team 1
			PLAYER_INFORMATION	pPlayer2;								// player information from team 2
			//MemHandle			hRecord2;	// the record for the player fromt team 2
			byte []				team = new byte[Global.MAX_PLAYERS];	// the team we're examining

			// get pointers to the team players
			// first player on team 1
			GameSummaryGetTeam(pGame, 0, 0, ref team);
			// set the game scores valid flag for player 0 on team 1
			// they're the only player carrying valid scores
			GameSummarySetGameScoresValidFlag(team[0], true);
			// now get the pointer - we have to do it in this order,
			// so that we don't try and get pointers twice (which will fail)
			pPlayer1 = espDB.GetPlayerInfo(team[0]);
			// first player on team 2
			GameSummaryGetTeam(pGame, 1, 0, ref team);
			pPlayer2 = espDB.GetPlayerInfo(team[0]);

			// reset our cumulative score to zero
			cumScore = 0;
			// now, run through each hole for which we have
			// complete data
			for (ii = 0; ii < Global.MAX_HOLES; ii++) 
			{
				// make sure that every player has complete data
				if (!GameSummaryFullData(pGame, ii)) 
				{
					// unlock the player info
					return ii;
				}
				// compare adjusted scores and compare them
				// first, we look at Xs - Xs cause a player to lose
				// a hole
				if (((pPlayer1.Scores[ii] & Global.X_SCORE) == Global.X_SCORE) &&
					(!((pPlayer2.Scores[ii] & Global.X_SCORE) == Global.X_SCORE))) 
				{
					// player 1 has an X, player 2 wins the hole
					cumScore--;
				} 
				else if (((pPlayer2.Scores[ii] & Global.X_SCORE) == Global.X_SCORE) &&
					(!((pPlayer1.Scores[ii] & Global.X_SCORE) == Global.X_SCORE))) 
				{
					// player 2 has an X, player 1 wins the hole
					cumScore++;
				} 
				else if ((!((pPlayer1.Scores[ii] &Global. X_SCORE) == Global.X_SCORE)) &&
					(!((pPlayer2.Scores[ii] & Global.X_SCORE) == Global.X_SCORE))) 
				{
					// no Xs, so we check adjusted scores
					if ((((sbyte) (pPlayer1.Scores[ii] & ~Global.X_SCORE)) - pPlayer1.Strokes[ii]) <
						(((sbyte) (pPlayer2.Scores[ii] & ~Global.X_SCORE)) - pPlayer2.Strokes[ii])) 
					{
						// +1 for player one
						cumScore++;
					} 
					else if ((((sbyte) (pPlayer1.Scores[ii] & ~Global.X_SCORE)) - pPlayer1.Strokes[ii]) >
						(((sbyte) (pPlayer2.Scores[ii] & ~Global.X_SCORE)) - pPlayer2.Strokes[ii])) 
					{
						// +1 for player two
						cumScore--;
					}
				}
				//
				// okay, now we need to account for the specials
				cumScore += GameSummarySpecials(pGame, ii);
				// record the score
				//WriteToPlayer(pPlayer1, GameScores[ii], ref cumScore, sizeof(sbyte));
				pPlayer1.GameScores[ii] = cumScore;
				espDB.WriteToPlayer(pPlayer1, pGame.Team1[0]);
			}
			return ii;
		}

		///////////////////////////////////////////////////////////////////////
		//  GameSummaryIndividualSkins - computes an individual skins game
		//  Input:  pGame - the game to use
		//  Output: none
		//  Return: none
		//  Notes:
		///////////////////////////////////////////////////////////////////////
		byte GameSummaryIndividualSkins(GAME_INFORMATION	pGame)
		{
			byte				ii;												// loop variable
			byte				jj;												// loop variable
			byte				carry;										// carry-over from previous holes
			sbyte				bestScore;							// best score we've seen
			byte				bestPlayer = 0;					// index for the best player
			bool				seenScore = false;			// have we seen this score twice?
			PLAYER_INFORMATION	pPlayer;	// player information
			short				gameScore = 0;					// used to record scores
			sbyte				netScore;								// the net score
			bool				xScore = false;					// X Score Flag
			byte []			team = new byte[Global.MAX_PLAYERS];	// the team we're examining

			// get the first team
			GameSummaryGetTeam(pGame, 0, 0, ref team);
			//
			// we need to clear all scores
			for (ii = 0; ii < pGame.TeamSize; ii++) 
			{
				// get the player's info
				pPlayer = espDB.GetPlayerInfo(team[ii]);
				// loop over the holes
				for (jj = 0; jj < Global.MAX_HOLES; jj++) 
				{
					// now, write out the game score
					//WriteToPlayer(pPlayer, GameScores[jj], ref gameScore, sizeof(byte));
					pPlayer.GameScores[jj] = (sbyte)gameScore;
				}
				espDB.WriteToPlayer(pPlayer,team[ii]);
			}
			// reset the carry-over
			carry = 0;
			// now, run through each hole for which we have
			// complete data
			for (ii = 0; ii < Global.MAX_HOLES; ii++) 
			{
				// make sure that every player has complete data
				if (!GameSummaryFullData(pGame, ii)) 
				{
					return ii;
				}
				// default to having seen the score - that way if
				// all scores are X scores, NOBODY gets the skin
				seenScore = true;
				// compare adjusted scores for all players
				for (jj = 0, bestScore = (sbyte)MAX_SCORE; jj < pGame.TeamSize; jj++) 
				{
					// get the net score
					netScore = (sbyte)GameSummaryGetNetScore(pGame.Team1[jj], ii, ref xScore);

					// if it's an x score, it's ignored for our calculations - it's
					// like it didn't happen
					if (xScore) 
						continue;

					// see if this betters the previous best
					if (netScore < bestScore) 
					{
						// this is the new lowest score
						bestScore = netScore;
						// record the best player
						bestPlayer = jj;
						// reset if we've seen this score
						seenScore = false;
					} 
					else if (netScore == bestScore) 
					{
						// mark that we saw another player with this
						// score
						seenScore = true;
					}
				}
				// if we saw the lowest score more than once, the skin carries over
				if (seenScore) 
				{
					// record the carry-over
					carry++;
					// go to the next hole
					// continue;
				}
				// okay, now we need to account for the specials
				// loop over the players, giving each player their specials
				// we'll also give the skin to the winner as we go through here
				for (jj = 0; jj < pGame.TeamSize; jj++) 
				{
					// get the player's info
					pPlayer = espDB.GetPlayerInfo(team[jj]);
					// count up his specials
					gameScore = GameSummaryCountSpecials(pGame.GameFlags & Global.GAME_STAT_MASK,
						pPlayer,
						ii);
					// if this is the winner, add in their skins
					if ((jj == bestPlayer) & !seenScore) 
					{
						// this player won the skin - record a point for them
						// if we're playing carry-over, give them the carry-over also
						if ((pGame.GameFlags & Global.GAME_FLAG_SKINS_CARRY) == Global.GAME_FLAG_SKINS_CARRY) 
						{
							gameScore += (byte)(1 + carry);
						} 
						else 
						{
							gameScore += 1;
						}
					}
					// now, write out the game score
					//WriteToPlayer(pPlayer, GameScores[ii], ref gameScore, sizeof(byte));
					pPlayer.GameScores[ii] = (sbyte)gameScore;
					espDB.WriteToPlayer(pPlayer, team[jj]);
				}
				// clear the carry-over
				if (!seenScore) carry = 0;
			}
			return ii;
		}

		///////////////////////////////////////////////////////////////////////
		//  GameSummaryIndividualStats - computes an individual stats game
		//  Input:  pGame - the game to use
		//  Output: none
		//  Return: none
		//  Notes:
		///////////////////////////////////////////////////////////////////////
		byte GameSummaryIndividualStats(GAME_INFORMATION pGame)
		{
			byte										ii;									// loop variable
			byte										jj;									// loop variable
			PLAYER_INFORMATION	pPlayer;				// player information
			short										gameScore = 0;		// used to record scores
			byte []			team = new byte[Global.MAX_PLAYERS];	// the team we're examining

			// get the first team
			GameSummaryGetTeam(pGame, 0, 0, ref team);
			//
			// we need to clear all scores
			for (ii = 0; ii < pGame.TeamSize; ii++) 
			{
				// get the player's info
				pPlayer = espDB.GetPlayerInfo(team[ii]);
				// loop over the holes
				for (jj = 0; jj < Global.MAX_HOLES; jj++) 
				{
					pPlayer.GameScores[jj] = (sbyte)gameScore;
				}
				// now, write out the game score
				espDB.WriteToPlayer(pPlayer, team[ii]);
				GameSummarySetGameScoresValidFlag(team[ii], true);
			}

			// now, run through each hole for which we have
			// complete data
			for (ii = 0; ii < Global.MAX_HOLES; ii++) 
			{
				// make sure that every player has complete data
				if (!GameSummaryFullData(pGame, ii)) 
				{
					return ii;
				}
				// loop over the players, giving each player their specials
				for (jj = 0; jj < pGame.TeamSize; jj++) 
				{
					// get the player's info
					pPlayer = espDB.GetPlayerInfo(team[jj]);
					// count up his specials
					gameScore = GameSummaryCountSpecials(pGame.GameFlags & Global.GAME_STAT_MASK,
							pPlayer,
							ii);
					// now, write out the game score
					pPlayer.GameScores[ii] = (sbyte)gameScore;
					espDB.WriteToPlayer(pPlayer, team[jj]);
				}
			}
			return ii;
		}

		///////////////////////////////////////////////////////////////////////
		//  GameSummaryIndividualNines - computes an individual nines game
		//  Input:  pGame - the game to use
		//  Output: none
		//  Return: none
		//  Notes:
		///////////////////////////////////////////////////////////////////////
		byte GameSummaryIndividualNines(GAME_INFORMATION	pGame)
		{
			byte					ii;												// loop variable
			byte					jj;												// loop variable
			byte					kk;											// loop variable
			sbyte					currentScore;						// the current score we're comparing
			sbyte					place;									// which place is this score?
			sbyte					ties;										// how many ties do we have for this place?
			PLAYER_INFORMATION	pPlayer;		// player information
			short []				gameScores = new short[Global.MAX_PLAYERS];	// used to record scores
			sbyte					netScore;								// the net score
			bool					xScore = false;					// is this an x score?
			byte []				team = new byte[Global.MAX_PLAYERS];					// the team we're examining

			// get the first team
			GameSummaryGetTeam(pGame, 0, 0, ref team);
			// clear the first game score (which is used to clear the values
			// stored in each player
			gameScores[0] = 0;
			// we need to clear all scores
			for (ii = 0; ii < pGame.TeamSize; ii++) 
			{
				// get the player's info
				pPlayer = espDB.GetPlayerInfo(team[ii]);
				// loop over the holes
				for (jj = 0; jj < Global.MAX_HOLES; jj++) 
				{
					// now, write out the game score
					pPlayer.GameScores[jj] = (sbyte)gameScores[0];
				}
				espDB.WriteToPlayer(pPlayer, team[ii]);
				// set the game scores valid flag for this player
				GameSummarySetGameScoresValidFlag(team[ii], true);
			}
			// now, run through each hole for which we have
			// complete data
			for (ii = 0; ii < Global.MAX_HOLES; ii++) 
			{
				// make sure that every player has complete data
				if (!GameSummaryFullData(pGame, ii)) 
				{
					return ii;
				}
				// run through every player - we'll compare their score to everyone
				// else's
				for (jj = 0; jj < pGame.TeamSize; jj++) 
				{
					// get the net score
					currentScore = (sbyte)GameSummaryGetNetScore(team[jj], ii, ref xScore);
					// if it's an x score, treat them as having MAX_SCORE
					if (xScore) 
					{
						currentScore = (sbyte)MAX_SCORE;
					}
					// reset our place to the best
					place = (sbyte)(pGame.TeamSize - 1);
					// reset the number of ties to 0
					// why 0?  we'll "tie" ourselves at least once in the following loop
					ties = 0;
					// loop over the players
					for (kk = 0; kk < pGame.TeamSize; kk++) 
					{
						// get the net score
						netScore = (sbyte)GameSummaryGetNetScore(team[kk], ii, ref xScore);
						// if it's an x score, treat them as having MAX_SCORE
						if (xScore) 
						{
							netScore = (sbyte)MAX_SCORE;
						}
						// compare it to ours - if it's less, decrement the place
						// if it's the same, increment the ties
						if (netScore < currentScore) 
						{
							place--;
						} 
						else if (netScore == currentScore) 
						{
							ties++;
						}
					}
					// clear our game score
					gameScores[jj] = 0;
					// compute how many points this player scored
					// this is the points for their rank, plus all the tied
					// ranks below him, divided by the number of ties
					for (kk = 0; kk < ties; kk++) 
					{
						// add this rank in
						gameScores[jj] += (short)(((place - kk) * 2) + 1);
					}
					// divide by the number of ties
					gameScores[jj] = (short)(gameScores[jj] / ties);
				}
				// okay, now we need to account for the specials
				// loop over the players, giving each player their specials
				// we'll also give the skin to the winner as we go through here
				for (jj = 0; jj < pGame.TeamSize; jj++) 
				{
					// get the player's info
					pPlayer = espDB.GetPlayerInfo(team[jj]);
					// count up his specials
					gameScores[jj] += GameSummaryCountSpecials(pGame.GameFlags & Global.GAME_STAT_MASK,
								pPlayer,
								ii);
					pPlayer.GameScores[ii] = (sbyte)gameScores[jj];
					// now, write out the game score
					espDB.WriteToPlayer(pPlayer, team[jj]);
				}
			}
			return ii;
		}

		///////////////////////////////////////////////////////////////////////
		//  GameSummaryTeamBestBall - computes a team best ball match
		//  Input:  pGame - the game to use
		//  Output: none
		//  Return: none
		//  Notes:
		///////////////////////////////////////////////////////////////////////
		byte GameSummaryTeamBestBall(GAME_INFORMATION pGame)
		{
			byte				ii;												// loop variable
			byte				jj;												// loop variable
			short				cumScore;							// cumulative score for this match
			sbyte []			bestScores = new sbyte[Global.MAX_TEAMS];	// the best scores for the teams
			sbyte				netScore;								// the net score
			bool				xScore = false;					// X Score Flag
			byte []			team = new byte[Global.MAX_PLAYERS];	// the team we're examining
			byte				teamNumber;						// which team we're working on

			// reset our cumulative score to zero
			cumScore = 0;
			// get the first team
			GameSummaryGetTeam(pGame, 0, 0, ref team);
			// set the game scores valid flag for this player
			GameSummarySetGameScoresValidFlag(team[0], true);

			// now, run through each hole for which we have
			// complete data
			for (ii = 0; ii < Global.MAX_HOLES; ii++) 
			{
				// make sure we have full data
				if (!GameSummaryFullData(pGame, ii)) 
				{
					return (byte)ii;
				}
				// if we have rotating teams, clear the cumulative score
				// at each breakpoint
				if (((pGame.GameFlags & Global.GAME_FLAG_ROTATE_TEAMS) == Global.GAME_FLAG_ROTATE_TEAMS) && 
					((ii % Global.HOLES_PER_TEAM_ROTATION) == 0)) 
				{
					cumScore = 0;
				}
				// init the best scores
				for (jj = 0; jj < Global.MAX_TEAMS; jj++) 
				{
					bestScores[jj] = (sbyte)MAX_SCORE;
				}
				// loop over the teams
				for (teamNumber = 0; true; teamNumber++) 
				{
					// get the next team
					if (!GameSummaryGetTeam(pGame, teamNumber, ii, ref team)) 
					{
						break;
					}
					// find the lowest adjusted score for this team
					for (jj = 0; jj < pGame.TeamSize; jj++) 
					{
						// get the net score
						netScore = (sbyte)GameSummaryGetNetScore(team[jj], ii, ref xScore);
						// if it's an x score, ignore it for determining the best
						if (xScore) 
						{
							continue;
						}
						// see if the current score is better than our lowest
						if (netScore < bestScores[teamNumber]) 
						{
							// this is the new lowest score
							bestScores[teamNumber] = netScore;
						}
					}
				}
				// see which team won - note that we are assuming two teams
				// only here
				if (bestScores[0] < bestScores[1]) 
				{
					// +1 for team 1
					cumScore++;
				} 
				else if (bestScores[1] < bestScores[0]) 
				{
					// +1 for team two
					cumScore--;
				}
				// now, account for the specials
				cumScore += GameSummarySpecials(pGame, ii);
				// record the score - if we have rotating teams, every player
				// is written to
				if ((pGame.GameFlags & Global.GAME_FLAG_ROTATE_TEAMS) == Global.GAME_FLAG_ROTATE_TEAMS) 
				{
					// get the first team
					GameSummaryGetTeam(pGame, 0, ii, ref team);
					// loop over the players
					for (jj = 0; jj < pGame.TeamSize; jj++) 
					{
						// record the score in this player
						GameSummarySetGameScore(team[jj], cumScore, ii);
					}
					// get the second team
					GameSummaryGetTeam(pGame, 1, ii, ref team);
					// loop over the players
					for (jj = 0; jj < pGame.TeamSize; jj++) 
					{
						// record the score in this player - note that it's
						// the opposite sign of the last team
						GameSummarySetGameScore(team[jj], (short)(-cumScore), ii);
					}
				} 
				else 
				{
					// get the first team
					GameSummaryGetTeam(pGame, 0, ii, ref team);
					// record the score in the first player
					GameSummarySetGameScore(team[0], cumScore, ii);
				}
			}
			return ii;
		}

		///////////////////////////////////////////////////////////////////////
		//  GameSummaryTeamBestBallAggregate - computes a team best ball aggregate match
		//  Input:  pGame - the game to use
		//  Output: none
		//  Return: none
		//  Notes:
		///////////////////////////////////////////////////////////////////////
		byte GameSummaryTeamBestBallAggregate(GAME_INFORMATION pGame)
		{
			byte				ii;																				// loop variable
			byte				jj;																				// loop variable
			short				cumScore;															// cumulative score for this match
			sbyte []			teamScore = new sbyte[Global.MAX_TEAMS];	// best score for a team
			sbyte []			teamAgg = new sbyte[Global.MAX_TEAMS];		// aggregate score for a team
			sbyte				netScore;																// the net score
			bool				xScore = false;													// is this an X score?
			bool []			teamX = new bool[Global.MAX_TEAMS];		// did the team have an X?
			byte []			team = new byte[Global.MAX_PLAYERS];		// the team we're examining
			byte				teamNumber;														// which team we're working on

			// reset our cumulative score to zero
			cumScore = 0;
			// get the first team
			GameSummaryGetTeam(pGame, 0, 0, ref team);
			// set the game scores valid flag for this player
			GameSummarySetGameScoresValidFlag(team[0], true);
			// now, run through each hole for which we have
			// complete data
			for (ii = 0; ii < Global.MAX_HOLES; ii++) 
			{
				// make sure we have full data
				if (!GameSummaryFullData(pGame, ii)) 
				{
					return ii;
				}
				// if we have rotating teams, clear the cumulative score
				// at each breakpoint
				if (((pGame.GameFlags & Global.GAME_FLAG_ROTATE_TEAMS) == Global.GAME_FLAG_ROTATE_TEAMS) && 
					((ii % Global.HOLES_PER_TEAM_ROTATION) == 0)) 
				{
					cumScore = 0;
				}
				// init the best scores and other info
				for (jj = 0; jj < Global.MAX_TEAMS; jj++) 
				{
					teamScore[jj] = (sbyte)MAX_SCORE;
					teamAgg[jj] = 0;
					teamX[jj] = false;
				}
				// loop over the teams
				for (teamNumber = 0; true; teamNumber++) 
				{
					// get the next team
					if (!GameSummaryGetTeam(pGame, teamNumber, ii, ref team)) 
					{
						break;
					}
					// find the lowest adjusted score for this team
					// also, compute the aggregate
					for (jj = 0; jj < pGame.TeamSize; jj++) 
					{
						// get the net score
						netScore = (sbyte)GameSummaryGetNetScore(team[jj], ii, ref xScore);
						// if this is an X, it's ignored for the best ball calculation
						// however, this team will lose the aggregate, always
						if (xScore) 
						{
							// note that this team had an x
							teamX[teamNumber] = true;
							continue;
						}
						// see if the current score is better than our lowest
						if (netScore < teamScore[teamNumber]) 
						{
							// this is the new lowest score
							teamScore[teamNumber] = netScore;
						}
						// add this score to the aggregate
						teamAgg[teamNumber] += netScore;
					}


				}
				// compare the best scores
				if (teamScore[0] < teamScore[1]) 
				{
					// +1 for team 1
					cumScore++;
				} 
				else if (teamScore[0] > teamScore[1]) 
				{
					// +1 for team two
					cumScore--;
				}
				// compare the aggregates
				// first, we need to compare Xs
				if ((teamX[0]) && (!teamX[1])) 
				{
					// +1 for team two
					cumScore--;
				} 
				else if ((!teamX[0]) && (teamX[1])) 
				{
					// +1 for team 1
					cumScore++;
				} 
				else if ((!teamX[0]) && (!teamX[1])) 
				{
					// no Xs, compare the scores
					if (teamAgg[0] < teamAgg[1]) 
					{
						// +1 for team 1
						cumScore++;
					} 
					else if (teamAgg[0] > teamAgg[1]) 
					{
						// +1 for team two
						cumScore--;
					}			
				}
				// now, account for the specials
				cumScore += GameSummarySpecials(pGame, ii);
				// record the score - if we have rotating teams, every player
				// is written to
				if ((pGame.GameFlags & Global.GAME_FLAG_ROTATE_TEAMS) == Global.GAME_FLAG_ROTATE_TEAMS) 
				{
					// get the first team
					GameSummaryGetTeam(pGame, 0, ii, ref team);
					// loop over the players
					for (jj = 0; jj < pGame.TeamSize; jj++) 
					{
						// record the score in this player
						GameSummarySetGameScore(team[jj], cumScore, ii);
					}
					// get the second team
					GameSummaryGetTeam(pGame, 1, ii, ref team);
					// loop over the players
					for (jj = 0; jj < pGame.TeamSize; jj++) 
					{
						// record the score in this player - note that it's
						// the opposite sign of the last team
						GameSummarySetGameScore(team[jj],(short)(-cumScore), ii);
					}
				} 
				else 
				{
					// get the first team
					GameSummaryGetTeam(pGame, 0, ii, ref team);
					// record the score in the first player
					GameSummarySetGameScore(team[0], cumScore, ii);
				}
			}
			return ii;
		}

		///////////////////////////////////////////////////////////////////////
		//  GameSummaryTeamHighLow - computes a team high/low match
		//  Input:  pGame - the game to use
		//  Output: none
		//  Return: none
		//  Notes:
		///////////////////////////////////////////////////////////////////////
		byte GameSummaryTeamHighLow(GAME_INFORMATION pGame)
		{
			byte				ii;									// loop variable
			byte				jj;									// loop variable
			short				cumScore;				// cumulative score for this match
			sbyte []			teamLow = new sbyte[Global.MAX_TEAMS];		// best score for this team
			sbyte []			teamHigh = new sbyte[Global.MAX_TEAMS];	// worst score for this team
			sbyte				netScore;					// the net score
			bool				xScore = false;		// is this an X score?
			byte []			team = new byte[Global.MAX_PLAYERS];		// the team we're examining
			byte				teamNumber;			// which team we're working on

			// reset our cumulative score to zero
			cumScore = 0;
			// get the first team
			GameSummaryGetTeam(pGame, 0, 0, ref team);
			// set the game scores valid flag for this player
			GameSummarySetGameScoresValidFlag(team[0], true);
			// now, run through each hole for which we have
			// complete data
			for (ii = 0; ii < Global.MAX_HOLES; ii++) 
			{
				// make sure we have full data
				if (!GameSummaryFullData(pGame, ii)) 
				{
					return ii;
				}
				// if we have rotating teams, clear the cumulative score
				// at each breakpoint
				if (((pGame.GameFlags & Global.GAME_FLAG_ROTATE_TEAMS) == Global.GAME_FLAG_ROTATE_TEAMS) && 
					((ii % Global.HOLES_PER_TEAM_ROTATION) == 0)) 
				{
					cumScore = 0;
				}
				// init the best scores and other info
				for (jj = 0; jj < Global.MAX_TEAMS; jj++) 
				{
					teamLow[jj] = (sbyte)MAX_SCORE;
					teamHigh[jj] = 0;
				}
				// loop over the teams
				for (teamNumber = 0; true; teamNumber++) 
				{
					// get the next team
					if (!GameSummaryGetTeam(pGame, teamNumber, ii, ref team)) 
					{
						break;
					}
					// find the lowest and highest adjusted score for this team
					for (jj = 0; jj < pGame.TeamSize; jj++) 
					{
						// get the net score
						netScore = (sbyte)GameSummaryGetNetScore(team[jj], ii, ref xScore);
						// if this is an X, this team loses the high (or, if this is their
						// second X, the low)
						if (xScore) 
						{
							// set the high score to MAX_SCORE - this ensures that this team
							// loses the high score
							// if this is the second X, the low is ALREADY set to MAX_SCORE,
							// so they'll lose it too.
							// note that if the other team has an X also, they'll end us with MAX_SCORE
							// for the high, and that point will be halved.
							teamHigh[teamNumber] = (sbyte)MAX_SCORE;
							continue;
						}
						// see if the current score is lower than our lowest
						if (netScore < teamLow[teamNumber]) 
						{
							// this is the new lowest score
							teamLow[teamNumber] = netScore;
						}
						// see if it's our highest
						if (netScore > teamHigh[teamNumber]) 
						{
							// this is the new highest score
							teamHigh[teamNumber] = netScore;
						}
					}
				}
				// compare the best scores
				if (teamLow[0] < teamLow[1]) 
				{
					// +1 for team 1
					cumScore++;
				} 
				else if (teamLow[0] > teamLow[1]) 
				{
					// +1 for team two
					cumScore--;
				}
				// compare the worst scores
				if (teamHigh[0] < teamHigh[1]) 
				{
					// +1 for team 1
					cumScore++;
				} 
				else if (teamHigh[0] > teamHigh[1]) 
				{
					// +1 for team two
					cumScore--;
				}
				// now, account for the specials
				cumScore += GameSummarySpecials(pGame, ii);
				// record the score - if we have rotating teams, every player
				// is written to
				if ((pGame.GameFlags & Global.GAME_FLAG_ROTATE_TEAMS) == Global.GAME_FLAG_ROTATE_TEAMS) 
				{
					// get the first team
					GameSummaryGetTeam(pGame, 0, ii, ref team);
					// loop over the players
					for (jj = 0; jj < pGame.TeamSize; jj++) 
					{
						// record the score in this player
						GameSummarySetGameScore(team[jj], cumScore, ii);
					}
					// get the second team
					GameSummaryGetTeam(pGame, 1, ii, ref team);
					// loop over the players
					for (jj = 0; jj < pGame.TeamSize; jj++) 
					{
						// record the score in this player - note that it's
						// the opposite sign of the last team
						GameSummarySetGameScore(team[jj],(short)(-cumScore), ii);
					}
				} 
				else 
				{
					// get the first team
					GameSummaryGetTeam(pGame, 0, ii, ref team);
					// record the score in the first player
					GameSummarySetGameScore(team[0], cumScore, ii);
				}
			}
			return ii;
		}

		///////////////////////////////////////////////////////////////////////
		//  GameSummaryTeamSkins - computes a team skins game
		//  Input:  pGame - the game to use
		//  Output: none
		//  Return: none
		//  Notes:
		///////////////////////////////////////////////////////////////////////
		byte GameSummaryTeamSkins(GAME_INFORMATION	pGame)
		{
			byte				ii;													// loop variable
			byte				jj;													// loop variable
			byte				carry;											// carry-over from previous holes
			PLAYER_INFORMATION	pPlayer;		// player information
			short []			gameScore = new short[Global.MAX_TEAMS];	// used to record scores
			sbyte				netScore;									// the net score
			bool				xScore = false;						// is this an x score?
			sbyte []			teamScore = new sbyte[Global.MAX_TEAMS];		// best score for this team
			byte []			team = new byte[Global.MAX_PLAYERS];				// the team we're examining
			byte				teamNumber;																		// which team we're working on

			// we need to clear all scores
			// loop over the teams
			for (teamNumber = 0; true; teamNumber++) 
			{
				// get the next team
				if (!GameSummaryGetTeam(pGame, teamNumber, 0, ref team)) 
				{
					break;
				}
				// loop over the holes
				for (ii = 0; ii < Global.MAX_HOLES; ii++) 
				{
					// clear this game score
					GameSummarySetGameScore(team[0], 0, ii);
				}
				// set the game scores valid flag for this player
				GameSummarySetGameScoresValidFlag(team[0], true);
				// if this is a rotating team, the other player needs their scores reset
				if ((pGame.GameFlags & Global.GAME_FLAG_ROTATE_TEAMS) == Global.GAME_FLAG_ROTATE_TEAMS) 
				{
					// loop over the holes
					for (ii = 0; ii < Global.MAX_HOLES; ii++) 
					{
						// clear this game score
						GameSummarySetGameScore(team[1], 0, ii);
					}
					// set the game scores valid flag for this player also
					GameSummarySetGameScoresValidFlag(team[1], true);
				}
			}
	
			// reset the carry-over
			carry = 0;
			// now, run through each hole for which we have
			// complete data
			for (ii = 0; ii < Global.MAX_HOLES; ii++) 
			{
				// make sure that every player has complete data
				if (!GameSummaryFullData(pGame, ii)) 
				{
					return ii;
				}
				// init the best scores and other info
				for (jj = 0; jj < Global.MAX_TEAMS; jj++) 
				{
					gameScore[jj] = 0;
					teamScore[jj] = (sbyte)MAX_SCORE;
				}
				// loop over the teams
				for (teamNumber = 0; true; teamNumber++) 
				{
					// get the next team
					if (!GameSummaryGetTeam(pGame, teamNumber, ii, ref team)) 
					{
						break;
					}
					// find the lowest adjusted score for this team
					for (jj = 0; jj < pGame.TeamSize; jj++) 
					{
						// get the player's info
						pPlayer = espDB.GetPlayerInfo(team[jj]);
						// count up the specials
						gameScore[teamNumber] += GameSummaryCountSpecials(pGame.GameFlags & Global.GAME_STAT_MASK,
							pPlayer,
							ii);
						// get the net score
						netScore = (sbyte)GameSummaryGetNetScore(team[jj], ii, ref xScore);
						// if it's an x score, ignore it for determining the best
						if (xScore) 
						{
							continue;
						}
						// see if the current score is better than our lowest
						if (netScore < teamScore[teamNumber]) 
						{
							// this is the new lowest score
							teamScore[teamNumber] = netScore;
						}
					}
				}
				// add the skins to the team that won
				if (teamScore[0] < teamScore[1]) 
				{
					// give them the skin(s)
					if ((pGame.GameFlags & Global.GAME_FLAG_SKINS_CARRY) == Global.GAME_FLAG_SKINS_CARRY) 
					{
						gameScore[0] += (short)(1 + carry);
					} 
					else 
					{
						gameScore[0] += 1;
					}
					// clear the carry
					carry = 0;
				} 
				else if (teamScore[0] > teamScore[1]) 
				{
					// give them the skin(s)
					if ((pGame.GameFlags & Global.GAME_FLAG_SKINS_CARRY) == Global.GAME_FLAG_SKINS_CARRY) 
					{
						gameScore[1] += (short)(1 + carry);
					} 
					else 
					{
						gameScore[1] += 1;
					}
					// clear the carry
					carry = 0;
				} 
				else 
				{
					// increment the carry
					carry++;
				}
				// loop over the teams
				for (teamNumber = 0; true; teamNumber++) 
				{
					// get the next team
					if (!GameSummaryGetTeam(pGame, teamNumber, ii, ref team)) 
					{
						break;
					}
					// record the score in the first player
					GameSummarySetGameScore(team[0], gameScore[teamNumber], ii);
					// if this is a rotating team, the other player needs their score
					// recorded also
					if ((pGame.GameFlags & Global.GAME_FLAG_ROTATE_TEAMS) == Global.GAME_FLAG_ROTATE_TEAMS) 
					{
						// record the score in the second player
						GameSummarySetGameScore(team[1], gameScore[teamNumber], ii);
					}
				}
			}
			return ii;
		}

		///////////////////////////////////////////////////////////////////////
		//  GameSummaryTeamWolfHighLow - computes a team wolf game
		//  Input:  pGame - the game to use
		//  Output: none
		//  Return: none
		//  Notes:
		///////////////////////////////////////////////////////////////////////
		byte GameSummaryTeamWolfHighLow(GAME_INFORMATION	pGame)
		{
			byte				ii;												// loop variable
			byte				jj;												// loop variable
			sbyte				netScore;								// the current score we're comparing
			PLAYER_INFORMATION	pPlayer;	// player information
			short				score;									// holds the score for a hole
			short				scoreToRecord;				// used to record scores
			bool				xScore = false;					// is this an x score?
			byte []			team = new byte[Global.MAX_PLAYERS];			// the team we're examining
			byte []			players = new byte[Global.MAX_PLAYERS];		// the teams for a given hole
			sbyte []			teamLow = new sbyte[Global.MAX_TEAMS];			// best score for this team
			sbyte []			teamHigh = new sbyte[Global.MAX_TEAMS];		// worst score for this team
			byte				teamNumber;						// which team we're working on

			// get the first team
			GameSummaryGetTeam(pGame, 0, 0, ref team);
			// clear the game score (which is used to clear the values
			// stored in each player
			score = 0;
			// we need to clear all scores
			for (ii = 0; ii < pGame.TeamSize; ii++) 
			{
				// get the player's info
				pPlayer = espDB.GetPlayerInfo(team[ii]);
				// loop over the holes
				for (jj = 0; jj < Global.MAX_HOLES; jj++) 
				{
					// now, write out the game score
					//WriteToPlayer(pPlayer, GameScores[jj], &score, sizeof(Int16));
					pPlayer.GameScores[jj] = score;
				}
				espDB.WriteToPlayer(pPlayer, team[ii]);
				// set the game scores valid flag for this player
				GameSummarySetGameScoresValidFlag(team[ii], true);
			}
			// now, run through each hole for which we have
			// complete data
			for (ii = 0; ii < Global.MAX_HOLES; ii++) 
			{
				// make sure that every player has complete data
				if (!GameSummaryFullData(pGame, ii)) 
				{
					return ii;
				}
				// if the hole info for this hole is 0, default the team
				if (pGame.HoleInfo[ii] == (uint) 0) 
				{
					// make a default team
					TeamMatchCreateDefaultWolfTeam(pGame, ii);
				}
				// fetch the hole info
				TeamMatchGetWolfTeam(ref players, pGame.HoleInfo[ii], pGame.TeamSize);
				// init the best scores and other info
				for (jj = 0; jj < Global.MAX_TEAMS; jj++) 
				{
					teamLow[jj] = (sbyte)MAX_SCORE;
					teamHigh[jj] = 0;
				}
				// reset our score
				score = 0;
				// run through every player - we're going to get a high and
				// low score for each team
				// also, we determine if anyone is going wolf
				for (jj = 0; jj < pGame.TeamSize; jj++) 
				{
					// get this player number
					if (players[jj] >= Global.MAX_PLAYERS) 
					{
						// get the net score
						netScore = (sbyte)GameSummaryGetNetScore(team[players[jj] - Global.MAX_PLAYERS], ii, ref xScore);
						// this is for team 2
						teamNumber = 1;
						// get the player's info
						pPlayer = espDB.GetPlayerInfo(team[players[jj] - Global.MAX_PLAYERS]);
						// subtract the specials
						score -= GameSummaryCountSpecials(pGame.GameFlags & Global.GAME_STAT_MASK,
							pPlayer,
							ii);			
					} 
					else 
					{
						// get the net score
						netScore = (sbyte)GameSummaryGetNetScore(team[players[jj]], ii, ref xScore);
						// this is for team 1
						teamNumber = 0;
						// get the player's info
						pPlayer = espDB.GetPlayerInfo(team[players[jj]]);
						// add the specials
						score += GameSummaryCountSpecials(pGame.GameFlags & Global.GAME_STAT_MASK,
							pPlayer,
							ii);			
					}
					// if this is an X, this team loses the high (or, if this is their
					// second X, the low)
					if (xScore) 
					{
						// set the high score to MAX_SCORE - this ensures that this team
						// loses the high score
						// if this is the second X, the low is ALREADY set to MAX_SCORE,
						// so they'll lose it too.
						// note that if the other team has an X also, they'll end us with MAX_SCORE
						// for the high, and that point will be halved.
						teamHigh[teamNumber] = (sbyte)MAX_SCORE;
						continue;
					}
					// see if the current score is lower than our lowest
					if (netScore < teamLow[teamNumber]) 
					{
						// this is the new lowest score
						teamLow[teamNumber] = netScore;
					}
					// see if it's our highest
					if (netScore > teamHigh[teamNumber]) 
					{
						// this is the new highest score
						teamHigh[teamNumber] = netScore;
					}
				}
				// compare the best scores
				if (teamLow[0] < teamLow[1]) 
				{
					// +1 for team 1
					score++;
				} 
				else if (teamLow[0] > teamLow[1]) 
				{
					// +1 for team two
					score--;
				}
				// now, we double the score if either team is alone
				// how?  if the second player is on team 2 or the second to last
				// player is on team 1
				// also, we only compute the high if there is no wolf player
				if ((players[1] >= Global.MAX_PLAYERS) || (players[pGame.TeamSize - 2] < Global.MAX_PLAYERS)) 
				{
					// count the low again
					if (teamLow[0] < teamLow[1]) 
					{
						// +1 for team 1
						score++;
					} 
					else if (teamLow[0] > teamLow[1]) 
					{
						// +1 for team two
						score--;
					}
					// someone went wolf, double the score
					score = (short)(score * 2);
				} 
				else 
				{
					// compare the worst scores
					if (teamHigh[0] < teamHigh[1]) 
					{
						// +1 for team 1
						score++;
					} 
					else if (teamHigh[0] > teamHigh[1]) 
					{
						// +1 for team two
						score--;
					}
				}
				// loop over the players, giving each player their score
				for (jj = 0; jj < pGame.TeamSize; jj++) 
				{
					// get this player number
					if (players[jj] >= Global.MAX_PLAYERS) 
					{
						// if the score is less than zero, record it as a positive,
						// otherwise, record 0
						if (score < 0) 
						{
							scoreToRecord = (short)(score * -1);
						} 
						else 
						{
							scoreToRecord = 0;
						}
						// get the player's info
						pPlayer = espDB.GetPlayerInfo(team[players[jj] - Global.MAX_PLAYERS]);
						// write out the game score
						//WriteToPlayer(pPlayer, GameScores[ii], &scoreToRecord, sizeof(Int16));
						pPlayer.GameScores[ii] = scoreToRecord;
						espDB.WriteToPlayer(pPlayer, team[players[jj] - Global.MAX_PLAYERS]);
					} 
					else 
					{
						// if the score is less than zero, record it as a positive,
						// otherwise, record 0
						if (score > 0) 
						{
							scoreToRecord = score;
						} 
						else 
						{
							scoreToRecord = 0;
						}
						// get the player's info
						pPlayer = espDB.GetPlayerInfo(team[players[jj]]);
						// write out the game score
						//WriteToPlayer(pPlayer, GameScores[ii], &scoreToRecord, sizeof(Int16));
						pPlayer.GameScores[ii] = scoreToRecord;
						espDB.WriteToPlayer(pPlayer, team[players[jj]]);
					}
				}
			}
			return ii;
		}

		///////////////////////////////////////////////////////////////////////
		//  GameSummaryTeamWolfBestBall - computes a team wolf game
		//  Input:  pGame - the game to use
		//  Output: none
		//  Return: none
		//  Notes:
		///////////////////////////////////////////////////////////////////////
		byte GameSummaryTeamWolfBestBall(GAME_INFORMATION	pGame)
		{
			byte				ii;												// loop variable
			byte				jj;												// loop variable
			sbyte				netScore;								// the current score we're comparing
			PLAYER_INFORMATION	pPlayer;	// player information
			short				score;									// holds the score for a hole
			short				scoreToRecord;				// used to record scores
			bool				xScore = false;									// is this an x score?
			byte []			team = new byte[Global.MAX_PLAYERS];			// the team we're examining
			byte []			players = new byte[Global.MAX_PLAYERS];		// the teams for a given hole
			sbyte []			teamLow = new sbyte[Global.MAX_TEAMS];		// best score for this team
			sbyte []			teamHigh = new sbyte[Global.MAX_TEAMS];	// worst score for this team
			byte				teamNumber;						// which team we're working on

			// get the first team
			GameSummaryGetTeam(pGame, 0, 0, ref team);
			// clear the game score (which is used to clear the values
			// stored in each player
			score = 0;
			// we need to clear all scores
			for (ii = 0; ii < pGame.TeamSize; ii++) 
			{
				// get the player's info
				pPlayer = espDB.GetPlayerInfo(team[ii]);
				// loop over the holes
				for (jj = 0; jj < Global.MAX_HOLES; jj++) 
				{
					// now, write out the game score
					//WriteToPlayer(pPlayer, GameScores[jj], &score, sizeof(Int16));
					pPlayer.GameScores[jj] = score;
				}
				espDB.WriteToPlayer(pPlayer, team[ii]);
				// set the game scores valid flag for this player
				GameSummarySetGameScoresValidFlag(team[ii], true);
			}
			// now, run through each hole for which we have
			// complete data
			for (ii = 0; ii < Global.MAX_HOLES; ii++) 
			{
				// make sure that every player has complete data
				if (!GameSummaryFullData(pGame, ii)) 
				{
					return ii;
				}
				// if the hole info for this hole is 0, default the team
				if (pGame.HoleInfo[ii] == (uint) 0) 
				{
					// make a default team
					TeamMatchCreateDefaultWolfTeam(pGame, ii);
				}
				// fetch the hole info
				TeamMatchGetWolfTeam(ref players, pGame.HoleInfo[ii], pGame.TeamSize);
				// init the best scores and other info
				for (jj = 0; jj < Global.MAX_TEAMS; jj++) 
				{
					teamLow[jj] = (sbyte)MAX_SCORE;
					teamHigh[jj] = 0;
				}
				// reset our score
				score = 0;
				// run through every player - we're going to get a high and
				// low score for each team
				// also, we determine if anyone is going wolf
				for (jj = 0; jj < pGame.TeamSize; jj++) 
				{
					// get this player number
					if (players[jj] >= Global.MAX_PLAYERS) 
					{
						// get the net score
						netScore = (sbyte)GameSummaryGetNetScore(team[players[jj] - Global.MAX_PLAYERS], ii, ref xScore);
						// this is for team 2
						teamNumber = 1;
						// get the player's info
						pPlayer = espDB.GetPlayerInfo(team[players[jj] - Global.MAX_PLAYERS]);
						// subtract the specials
						score -= GameSummaryCountSpecials(pGame.GameFlags & Global.GAME_STAT_MASK,
							pPlayer,
							ii);			
					} 
					else 
					{
						// get the net score
						netScore = (sbyte)GameSummaryGetNetScore(team[players[jj]], ii, ref xScore);
						// this is for team 1
						teamNumber = 0;
						// get the player's info
						pPlayer = espDB.GetPlayerInfo(team[players[jj]]);
						// add the specials
						score += GameSummaryCountSpecials(pGame.GameFlags & Global.GAME_STAT_MASK,
							pPlayer,
							ii);			
					}
					// if this is an X, this team loses the high (or, if this is their
					// second X, the low)
					if (xScore) 
					{
						// set the high score to MAX_SCORE - this ensures that this team
						// loses the high score
						// if this is the second X, the low is ALREADY set to MAX_SCORE,
						// so they'll lose it too.
						// note that if the other team has an X also, they'll end us with MAX_SCORE
						// for the high, and that point will be halved.
						teamHigh[teamNumber] = (sbyte)MAX_SCORE;
						continue;
					}
					// see if the current score is lower than our lowest
					if (netScore < teamLow[teamNumber]) 
					{
						// this is the new lowest score
						teamLow[teamNumber] = netScore;
					}
					// see if it's our highest
					if (netScore > teamHigh[teamNumber]) 
					{
						// this is the new highest score
						teamHigh[teamNumber] = netScore;
					}
				}
				// compare the best scores
				if (teamLow[0] < teamLow[1]) 
				{
					// +1 for team 1
					score++;
				} 
				else if (teamLow[0] > teamLow[1]) 
				{
					// +1 for team two
					score--;
				}
				// now, we double the score if either team is alone
				// how?  if the second player is on team 2 or the second to last
				// player is on team 1
				// also, we only compute the high if there is no wolf player
				if ((players[1] >= Global.MAX_PLAYERS) || (players[pGame.TeamSize - 2] < Global.MAX_PLAYERS)) 
				{
					// someone went wolf, double the score
					score = (short)(score * 2);
				} 
				else 
				{
					// compare the worst scores
					if (teamHigh[0] < teamHigh[1]) 
					{
						// +1 for team 1
						score++;
					} 
					else if (teamHigh[0] > teamHigh[1]) 
					{
						// +1 for team two
						score--;
					}
				}
				// loop over the players, giving each player their score
				for (jj = 0; jj < pGame.TeamSize; jj++) 
				{
					// get this player number
					if (players[jj] >= Global.MAX_PLAYERS) 
					{
						// if the score is less than zero, record it as a positive,
						// otherwise, record 0
						if (score < 0) 
						{
							scoreToRecord = (short)(score * -1);
						} 
						else 
						{
							scoreToRecord = 0;
						}
						// get the player's info
						pPlayer = espDB.GetPlayerInfo(team[players[jj] - Global.MAX_PLAYERS]);
						// write out the game score
						//WriteToPlayer(pPlayer, GameScores[ii], &scoreToRecord, sizeof(Int16));
						pPlayer.GameScores[ii] = scoreToRecord;
						espDB.WriteToPlayer(pPlayer, team[players[jj] - Global.MAX_PLAYERS]);
					} 
					else 
					{
						// if the score is less than zero, record it as a positive,
						// otherwise, record 0
						if (score > 0) 
						{
							scoreToRecord = score;
						} 
						else 
						{
							scoreToRecord = 0;
						}
						// get the player's info
						pPlayer = espDB.GetPlayerInfo(team[players[jj]]);
						// write out the game score
						//WriteToPlayer(pPlayer, GameScores[ii], &scoreToRecord, sizeof(Int16));
						pPlayer.GameScores[ii] = scoreToRecord;
						espDB.WriteToPlayer(pPlayer, team[players[jj]]);
					}
				}
			}
			return ii;
		}

		///////////////////////////////////////////////////////////////////////
		//  GameSummaryIndicateValidGameScores - finds the valid game scores and marks them
		//  Input:  pGame - the game to look at
		//  Output: none
		//  Return: 
		//  Notes:
		///////////////////////////////////////////////////////////////////////
		void GameSummaryIndicateValidGameScores(GAME_INFORMATION	pGame)
		{
			byte []	team = new byte[Global.MAX_PLAYERS];		// the team we're examining
			byte		teamNumber;																// which team we're working on
			byte		ii;																						// loop variable
	
			// if we have rotating teams, all players carry scores
			// otherwise, it's just player 0 on team 1
			if ((pGame.GameFlags & Global.GAME_FLAG_ROTATE_TEAMS) == Global.GAME_FLAG_ROTATE_TEAMS) 
			{
				// loop over the teams
				for (teamNumber = 0; true; teamNumber++) 
				{
					// get the next team
					if (!GameSummaryGetTeam(pGame, teamNumber, 0, ref team)) 
					{
						break;
					}
					// loop over the players
					for (ii = 0; ii < pGame.TeamSize; ii++) 
					{
						// set the game scores valid flag for this player
						GameSummarySetGameScoresValidFlag(team[ii], true);
					}
				}
			} 
			else 
			{
				// get the first team
				GameSummaryGetTeam(pGame, 0, 0, ref team);
				// set the game scores valid flag for this player
				GameSummarySetGameScoresValidFlag(team[0], true);
			}
		}

		///////////////////////////////////////////////////////////////////////
		//  GameSummaryComputePresses - computes where the presses lie (for auto presses)
		//  Input:  pGame - the game to use
		//			NumHoles - the number of holes for which we have data
		//  Output: none
		//  Return: none
		//  Notes:
		//  Notes:	always uses player 0 of team 1 to calculate the presses
		//			This will CEASE TO WORK if we ever allow presses with rotating
		//			teams!
		///////////////////////////////////////////////////////////////////////
		void GameSummaryComputePresses(GAME_INFORMATION pGame, byte NumHoles)
		{
			short				lastPress;			// where did the last press happen?
			short				trigger = 0;			// where do our presses trigger?
			byte				ii;					// loop variable
			PLAYER_INFORMATION	pPlayer;	// the player information
			byte				press = 1;				// used to record presses
			byte				totalPresses;			// total number of presses we've put in
			byte				limit;							// the limit on number of presses
			byte []			team = new byte[Global.MAX_PLAYERS];	// the team we're examining

			// if the game has no presses, we're done
			if (!((pGame.GameFlags & Global.GAME_PRESS_MASK) > 0)) 
			{
				// zero out the presses
				ClearGamePresses(ref pGame.Presses, Global.MAX_HOLES);
				espDB.WriteToGame(pGame,espDB.g_State.CurrentGame);
				return;
			}
			//
			// get the first team
			if (!GameSummaryGetTeam(pGame, 0, 0, ref team)) 
			{
				// zero out the presses
				ClearGamePresses(ref pGame.Presses, Global.MAX_HOLES);
				espDB.WriteToGame(pGame,espDB.g_State.CurrentGame);
				return;
			}	
			//
			// if we have auto presses, we need to figure out
			// where they fall
			if (!((pGame.GameFlags & Global.GAME_PRESS_MANUAL) == Global.GAME_PRESS_MANUAL)) 
			{
				// zero out the presses
				ClearGamePresses(ref pGame.Presses, Global.MAX_HOLES);
				// get the player info
				pPlayer = espDB.GetPlayerInfo(team[0]);
				// we're still going off of zero for presses
				lastPress = 0;
				// get the necessary trigger
				if ((pGame.GameFlags & Global.GAME_PRESS_1_DOWN) == Global.GAME_PRESS_1_DOWN) 
				{
					trigger = 1;
				} 
				else if ((pGame.GameFlags & Global.GAME_PRESS_2_DOWN) == Global.GAME_PRESS_2_DOWN) 
				{
					trigger = 2;
				} 
				else if ((pGame.GameFlags & Global.GAME_PRESS_3_DOWN) == Global.GAME_PRESS_3_DOWN) 
				{
					trigger = 3;
				}
				// calculate the limit
				if ((pGame.GameFlags & Global.GAME_PRESS_1_LIMIT) == Global.GAME_PRESS_1_LIMIT) 
				{
					limit = 1;
				} 
				else if ((pGame.GameFlags & Global.GAME_PRESS_2_LIMIT) == Global.GAME_PRESS_2_LIMIT) 
				{
					limit = 2;
				} 
				else 
				{
					limit = g_DataPieceSize;
				}
				//
				// reset the number of presses
				totalPresses = 0;
				//
				// loop over the holes we have
				for (ii = 0; ii < NumHoles; ii++) 
				{
					// if we're at the start of another piece, our last press
					// value changes - we start off again using the previous hole as our baseline
					if (((ii + 1) % g_DataPieceSize) == 0) 
					{
						// record the score as the baseline for the next piece
						// however, for games with rotating teams, we don't
						// need a baseline, they're zeroed automatically
						if ((pGame.GameFlags & Global.GAME_FLAG_ROTATE_TEAMS) == Global.GAME_FLAG_ROTATE_TEAMS) 
						{
							lastPress = 0;
						} 
						else 
						{
							lastPress = pPlayer.GameScores[ii];
						}
						// also, reset the number of presses
						totalPresses = 0;
						// no presses in the final hole of a half
						continue;
					}
					// if we're at the limit, move on
					if (totalPresses == limit) 
					{
						continue;
					}
					// see if the cum score has changed enough
					if (((pPlayer.GameScores[ii] - lastPress) <= (trigger * -1)) ||
						((pPlayer.GameScores[ii] - lastPress) >= trigger)) 
					{
						// yes, we have a press here
						pGame.Presses[ii] = press;
						// record the last press value
						lastPress = pPlayer.GameScores[ii];
						// increment how many presses we've put in
						totalPresses++;
					}
				}
				espDB.WriteToGame(pGame,espDB.g_State.CurrentGame);
			}
		}
		//
		void ClearGamePresses(ref byte [] presses, byte maxholes)
		{
			for(byte i=0;i<maxholes;i++)
			{
				presses[i] = 0;
			}
		}

		///////////////////////////////////////////////////////////////////////
		//  GameSummaryGetHandicap - gets the handicap for a player
		//  Input:  Index - the index of the player to query
		//  Output: none
		//  Return: the computed handicap
		//  Notes:
		///////////////////////////////////////////////////////////////////////
		short GameSummaryGetHandicap(byte	Index)
		{
			PLAYER_INFORMATION	pPlayer;		// the player we're querying

			pPlayer = (PLAYER_INFORMATION)espDB.cPlayers[Index];

			// return the handicap
			return pPlayer.ComputedHandicap;
		}

		///////////////////////////////////////////////////////////////////////
		//  GameSummaryGetTeeInfo - gets the tee info for a player index
		//  Input:  Index - the index of the player to query
		//  Output: none
		//  Return: the tee information
		//  Notes: Modified from PALM
		///////////////////////////////////////////////////////////////////////
		TEE_INFORMATION GameSummaryGetTeeInfo(byte Index)
		{
			uint 	tees;											// the tees from the player
			tees = espDB.cPlayers[Index].Tees;

			// get the tee information
			return espDB.GetTeeInfo(tees);
		}

		///////////////////////////////////////////////////////////////////////
		//  GameSummaryGetScore - gets a score from a player record
		//  Input:  Index - the index of the player to query
		//			Hole - the hole to query
		//  Output: none
		//  Return: the score
		//  Notes:
		///////////////////////////////////////////////////////////////////////
		byte GameSummaryGetScore(byte Index, byte Hole, ref bool xscore)
		{
			byte score;			// the score from the player

			// get the score
			score = espDB.cPlayers[Index].Scores[Hole];
			// Get X Score Flag
			xscore = espDB.cPlayers[Index].XScores[Hole];

			// return the score
			return score;
		}

		///////////////////////////////////////////////////////////////////////
		//  GameSummaryGetNetScore - gets a net score from a player record
		//  Input:  Index - the index of the player to query
		//			Hole - the hole to query
		//  Output: none
		//  Return: the net score
		//  Notes:
		///////////////////////////////////////////////////////////////////////
		sbyte GameSummaryGetNetScore(byte Index, byte Hole, ref bool xscore)
		{
			sbyte score;			// the score from the player

			// get the score
			score = (sbyte)(espDB.cPlayers[Index].Scores[Hole] - espDB.cPlayers[Index].Strokes[Hole]);
			if (score < 0) score = 0;
			// Get X Score Flag
			xscore = espDB.cPlayers[Index].XScores[Hole];

			// return the score
			return score;
		}

		///////////////////////////////////////////////////////////////////////
		//  GameSummaryClearGameScoresValid - clear the game scores valid flag on all players
		//  Input:  none
		//  Output: none
		//  Return: none
		//  Notes:	clears the GameScoresValid flag for all players
		///////////////////////////////////////////////////////////////////////
		void GameSummaryClearGameScoresValid()
		{
			byte				ii;					// loop variable

			// loop over all players
			for (ii = 0; ii < espDB.g_State.NumPlayers; ii++) 
			{
				// clear the flag
				GameSummarySetGameScoresValidFlag(ii, false);
			}
		}

		///////////////////////////////////////////////////////////////////////
		//  GameSummarySetGameScoresValidFlag - sets the game scores flag
		//  Input:  PlayerIndex - the player to modify
		//			Flag - the value to set
		//  Output: none
		//  Return: none
		//  Notes:	
		///////////////////////////////////////////////////////////////////////
		void GameSummarySetGameScoresValidFlag(byte	PlayerIndex, bool	Flag)
		{
			PLAYER_INFORMATION	pPlayer;			// the player info

			// get a pointer to this player
			pPlayer = espDB.GetPlayerInfo(PlayerIndex);
			pPlayer.GameScoresValid = Flag;
			// clear the flag
			espDB.WriteToPlayer(pPlayer, PlayerIndex);
		}

		///////////////////////////////////////////////////////////////////////
		//  GameSummaryGetTeam - gets the players on a team
		//  Input:  pGame - the game we're examining
		//			TeamNumber - which team to get
		//			Hole - the hole to calculate from
		//  Output: pTeam - the team we return
		//  Return: true if the team is valid
		//  Notes:	clears the GameScoresValid flag for all players
		///////////////////////////////////////////////////////////////////////
		public bool GameSummaryGetTeam(GAME_INFORMATION pGame, 
			byte				TeamNumber, 
			byte				Hole, 
			ref byte []		pTeam)
		{
			byte []	team1 = new byte[Global.MAX_PLAYERS];		// the first team (for rotating teams)
			byte []	team2 = new byte[Global.MAX_PLAYERS];		// the second team (for rotating teams)
	
			// see if we have rotating teams
			if ((pGame.GameFlags & Global.GAME_FLAG_ROTATE_TEAMS) == Global.GAME_FLAG_ROTATE_TEAMS) 
			{
				// compute the teams - this depends on the hole
				if (Hole < Global.HOLES_PER_TEAM_ROTATION) 
				{
					// first team rotation, use the stored values
					team1[0] = pGame.Team1[0];
					team1[1] = pGame.Team1[1];
					team2[0] = pGame.Team2[0];
					team2[1] = pGame.Team2[1];
				} 
				else if (Hole < (Global.HOLES_PER_TEAM_ROTATION * 2)) 
				{
					// second team rotation
					// team 1 is first player from the first team and
					// the first player from the second team
					// team 2 is the other guys
					team1[0] = pGame.Team1[0];
					team1[1] = pGame.Team2[0];
					team2[0] = pGame.Team1[1];
					team2[1] = pGame.Team2[1];
				} 
				else 
				{
					// third team rotation
					// team 1 is first player from the first team and
					// the second player from the second team
					// team 2 is the other guys
					team1[0] = pGame.Team1[0];
					team1[1] = pGame.Team2[1];
					team2[0] = pGame.Team1[1];
					team2[1] = pGame.Team2[0];
				}
				// now, see which team they want
				// if the team number is 0, copy over the values
				// from Team1
				if (TeamNumber == 0) 
				{
					// copy the team
					//MemMove(pTeam, team1, sizeof(UInt8) * MAX_PLAYERS);
					team1.CopyTo(pTeam,0);
					return true;
					// if the team number is 1, copy over the values
					// from Team2
				} 
				else if (TeamNumber == 1) 
				{
					// copy the team
					//MemMove(pTeam, team2, sizeof(UInt8) * MAX_PLAYERS);
					team2.CopyTo(pTeam,0);
					return true;
				} 
				else 
				{
					return false;
				}
			} 
			else 
			{
				// check if we have one team or not
				// note that tournaments always have one team
				if (((pGame.GameFlags & Global.GAME_FLAG_ONE_TEAM) == Global.GAME_FLAG_ONE_TEAM) ||
					(pGame.GameType == GAME_TYPE.TournamentGame)) 
				{
					// if the team number is 0, copy over the values
					// from Team1
					if (TeamNumber == 0) 
					{
						// copy the team
						//MemMove(pTeam, pGame->Team1, sizeof(UInt8) * MAX_PLAYERS);
						pGame.Team1.CopyTo(pTeam,0);
						return true;
					} 
					else 
					{
						return false;
					}
				} 
				else 
				{
					// if the team number is 0, copy over the values
					// from Team1
					if (TeamNumber == 0) 
					{
						// copy the team
						//MemMove(pTeam, pGame->Team1, sizeof(UInt8) * MAX_PLAYERS);
						pGame.Team1.CopyTo(pTeam,0);
						return true;
						// if the team number is 1, copy over the values
						// from Team2
					} 
					else if (TeamNumber == 1) 
					{
						// copy the team
						//MemMove(pTeam, pGame->Team2, sizeof(UInt8) * MAX_PLAYERS);
						pGame.Team2.CopyTo(pTeam,0);
						return true;
					} 
					else 
					{
						return false;
					}
				}
			}
		}

		///////////////////////////////////////////////////////////////////////
		//  GameSummaryGetGameScore - gets a game score for a player
		//  Input:  PlayerIndex - the player to get
		//			Hole - which hole to retrieve
		//  Output: none
		//  Return: returns the value from the player
		//  Notes:	
		///////////////////////////////////////////////////////////////////////
		short GameSummaryGetGameScore(byte PlayerIndex, byte	Hole)
		{
			PLAYER_INFORMATION	pPlayer;			// the player info
			short				gameScore;			// the game score the user wants

			// get a pointer to this player
			pPlayer = espDB.GetPlayerInfo(PlayerIndex);
			// get the value we want
			gameScore = pPlayer.GameScores[Hole];

			return gameScore;
		}

		///////////////////////////////////////////////////////////////////////
		//  GameSummarySetGameScore - records a score in a player
		//  Input:  PlayerIndex - the player to change
		//			Score - the score to record
		//			Hole - the hole number we're looking at
		//  Output: none
		//  Return: none
		//  Notes:
		///////////////////////////////////////////////////////////////////////
		void GameSummarySetGameScore(byte PlayerIndex,short Score,byte Hole)
		{
			PLAYER_INFORMATION	pPlayer;	// player information
	
			// just write to the first player
			pPlayer = espDB.GetPlayerInfo(PlayerIndex);
			pPlayer.GameScores[Hole] = Score;
			// write out the score
			espDB.WriteToPlayer(pPlayer, PlayerIndex);
		}

		///////////////////////////////////////////////////////////////////////
		//  GameSummaryTournamentBestBall - computes a best ball tournament score
		//  Input:  pGame - the game we're computing
		//  Output: none
		//  Return: the number of holes we've computed
		//  Notes:
		///////////////////////////////////////////////////////////////////////
		byte GameSummaryTournamentBestBall(GAME_INFORMATION pGame)

		{
			byte			ii;									// loop variable
			byte			jj;									// loop variable
			sbyte			ball;							// loop variable
			sbyte			player;						// loop variable
			short			cumScore;				// cumulative score for this match
			sbyte []		scores = new sbyte[Global.MAX_PLAYERS];	// the scores for each ball
			sbyte			score;						// the score we're examining
			sbyte			tieBreakScore;		// the tie break score we're examining
			sbyte			bestScore;				// the best score we've seen
			sbyte			bestTieBreak;		// the worst tiebreaker we've seen
			sbyte			bestPlayer;				// the best player we've seen
			bool			xScore = false;		// is this an x score?
			byte []		team = new byte[Global.MAX_PLAYERS];		// the team we're examining
			bool			used;							// have we used this player?
			TEE_INFORMATION	pTeeInfo;				// the tee information for the player
			PLAYER_INFORMATION	pPlayer;		// the player information

			// reset our cumulative score to zero
			cumScore = 0;
			// get the first team
			GameSummaryGetTeam(pGame, 0, 0, ref team);
			// set the game scores valid flag for the first player
			GameSummarySetGameScoresValidFlag(team[0], true);
			// now, run through each hole for which we have
			// complete data
			for (ii = 0; ii < Global.MAX_HOLES; ii++) 
			{
				// make sure we have full data
				if (!GameSummaryFullData(pGame, ii)) 
				{
					return ii;
				}
				// init the array that tracks which players we've used
				for (jj = 0; jj < Global.MAX_PLAYERS; jj++) 
				{
					scores[jj] = (sbyte)Global.INVALID_PLAYER;
				}
				// loop over each ball
				for (ball = 0; ball < pGame.TeamSize; ball++) 
				{
					// if this ball is not in play, we're done
					if (pGame.BallInfo[ball] == Global.BALL_HANDICAP_UNUSED) 
					{
						break;
					}
					// init our best scores
					bestScore = (sbyte)MAX_SCORE;
					bestTieBreak = 0;
					bestPlayer = Global.INVALID_PLAYER;
					// loop over the players
					for (player = 0; player < pGame.TeamSize; player++) 
					{
						// check if this player is used
						for (jj = 0, used = false; jj < Global.MAX_PLAYERS; jj++) 
						{
							// check this player
							if (scores[jj] == player) 
							{
								used = true;
							}
						}
						// if this player is used, move on
						if (used) 
						{
							continue;
						}
						// okay, check this player's score for this hole
						// note that we check either gross or net, depending
						// on what the ball info is
						if (pGame.BallInfo[ball] == Global.BALL_HANDICAP_NET) 
						{
							// get the net score
							score = GameSummaryGetNetScore(team[player], ii, ref xScore);
							// get the gross score as our tiebreaker
							tieBreakScore = (sbyte)GameSummaryGetScore(team[player], ii, ref xScore);
						} 
						else 
						{
							// get the gross score
							score = (sbyte)GameSummaryGetScore(team[player], ii, ref xScore);
							// get the net score as our tiebreaker
							tieBreakScore = GameSummaryGetNetScore(team[player], ii, ref xScore);
						}
						// if it's an X score, we'll use their adjusted max
						if (xScore) 
						{
							// get the tees for this player
							pTeeInfo = GameSummaryGetTeeInfo(team[player]);
							// get the player info
							pPlayer = espDB.GetPlayerInfo(team[player]);
							// now, get their max adjusted score
							score = (sbyte)EndGetMaxAdjustedScore(MAX_SCORE, pTeeInfo, ii, pPlayer.ComputedHandicap);
							// our tiebreaker score is the same
							tieBreakScore = score;
						}
						// if this is the lowest score we've seen, note the player
						if (score < bestScore) 
						{
							// this is our best
							bestScore = score;
							bestPlayer = player;
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
								bestPlayer = player;
								bestTieBreak = tieBreakScore;
							}
						}
					}
					// okay, we have our best player.  Record the player and
					// the add the score to our total
					scores[ball] = (sbyte)bestPlayer;
					cumScore += bestScore;
				}
				// record the score in the first player
				GameSummarySetGameScore(team[0], cumScore, ii);
			}
			return ii;
		}

		///////////////////////////////////////////////////////////////////////
		//  GameSummaryGetStrokes - gets the strokes from a player record
		//  Input:  Index - the index of the player to query
		//			Hole - the hole to query
		//  Output: none
		//  Return: the strokes
		//  Notes:
		///////////////////////////////////////////////////////////////////////
		sbyte GameSummaryGetStrokes(byte Index, byte Hole)
		{
			sbyte strokes;		// the strokes from the player

			// get the strokes
			strokes = espDB.cPlayers[Index].Strokes[Hole];

			// return the strokes
			return strokes;
		}

		///////////////////////////////////////////////////////////////////////
		//  GameSummarySpecials - accounts for the specials for a game
		//  Input:  pGame - the game to use
		//			Hole - the hole to check
		//  Output: none
		//  Return: the total adjustment for specials
		//  Notes:
		///////////////////////////////////////////////////////////////////////
		sbyte GameSummarySpecials(GAME_INFORMATION pGame, byte Hole)
		{
			sbyte score;										// the score adjustment
			byte ii;													// loop variable
			PLAYER_INFORMATION	pPlayer;	// player information
			byte []		team = new byte[Global.MAX_PLAYERS];	// the team we're examining
			sbyte		specials;								// running count of specials, recorded in each player separately

			// reset our score
			score = 0;
			// get the first team
			if (!GameSummaryGetTeam(pGame, 0, Hole, ref team)) 
			{
				return score;
			}

			// we need to account for the specials
			// loop over team 1, adding each player's specials to the total
			for (ii = 0, specials = 0; ii < pGame.TeamSize; ii++) 
			{
				// get the player's info
				pPlayer = espDB.GetPlayerInfo(team[ii]);
				// count up his specials
				specials += (sbyte)GameSummaryCountSpecials(pGame.GameFlags & Global.GAME_STAT_MASK,
							pPlayer,
							Hole);
			}
			// add the specials to the score
			score += specials;
			// get the second team
			if (!GameSummaryGetTeam(pGame, 1, Hole, ref team)) 
			{
				return score;
			}
			//
			// now, loop over team 2, subtracting each player's specials from the total
			for (ii = 0, specials = 0; ii < pGame.TeamSize; ii++) 
			{
				// get the player's info
				pPlayer = espDB.GetPlayerInfo(team[ii]);
				// count up his specials
				specials += (sbyte)GameSummaryCountSpecials(pGame.GameFlags & Global.GAME_STAT_MASK,
							pPlayer,
							Hole);
			}
			// subtract the specials from the score
			score -= specials;
			return score;
		}

		///////////////////////////////////////////////////////////////////////
		//  GameSummaryCountSpecials - counts how many specials a player recorded
		//  Input:  Specials - the special flags that apply to this game
		//			pPlayer - the player information
		//			Hole - the hole to check
		//  Output: none
		//  Return: the number of specials recorded by the player
		//  Notes:
		///////////////////////////////////////////////////////////////////////
		byte GameSummaryCountSpecials(uint Specials, PLAYER_INFORMATION pPlayer,byte Hole)
		{
			byte		count;			// the count of specials
			byte		ii;					// loop variable
	
			// zero our count
			count = 0;
			// loop over the stats
			for (ii = 0; ii < Global.NUM_STATS; ii++) 
			{
				// see if this flag is there and they
				// recorded it
				if (((Specials & (Global.GAME_STAT_FLAG << ii)) != 0) &&
					(pPlayer.Stats[Hole,ii] == (byte)STAT_VALUE.StatYes)) 
				{
					// increment the count
					count++;
				}
			}
			return count;
		}

		///////////////////////////////////////////////////////////////////////
		//  GameSummaryFullData - do we have full data for a hole?
		//  Input:  pGame - the game to use
		//			Hole - the hole to check
		//  Output: none
		//  Return: returns true if all players have a score for a hole
		//  Notes:
		///////////////////////////////////////////////////////////////////////
		bool GameSummaryFullData(GAME_INFORMATION pGame, byte Hole)
		{
			byte			ii;			// loop variable
			bool			unused = false;
			byte []		team = new byte[Global.MAX_PLAYERS];	// the team we're examining
			byte			teamNumber;										// which team we're working on

			// make sure that every player has complete data
			// loop over the teams
			for (teamNumber = 0; true; teamNumber++) 
			{
				// get the next team
				if (!GameSummaryGetTeam(pGame, teamNumber, Hole, ref team)) 
				{
					break;
				}
				// loop over the players
				for (ii = 0; ii < pGame.TeamSize; ii++) 
				{
					// make sure this player has data
					if (GameSummaryGetScore(team[ii], Hole, ref unused) == 0) 
					{
						return false;
					}
				}
			}
			return true;
		}
		//
		///////////////////////////////////////////////////////////////////////
		//  GameSummarySetDataPieceInfo - sets the data piece and data piece size
		//  Input:  pGame - the game to look at
		//  Output: none
		//  Return: none
		//  Notes:
		///////////////////////////////////////////////////////////////////////
		void GameSummarySetDataPieceInfo(GAME_INFORMATION	pGame)
		{
			// first, check if this is a rotating game
			if ((pGame.GameFlags & Global.GAME_FLAG_ROTATE_TEAMS) == Global.GAME_FLAG_ROTATE_TEAMS) 
			{
				// note that the data piece size is one team rotation
				g_DataPieceSize = Global.HOLES_PER_TEAM_ROTATION;
			} 
			else 
			{
				// note that the data piece size is nine holes
				g_DataPieceSize	= Global.HOLES_PER_HALF;
			}
			// set which data piece we're displaying
			if (espDB.g_State.HoleNumber < g_DataPieceSize) 
			{
				this.g_DataPiece = 0;
			} 
			else if (espDB.g_State.HoleNumber < (g_DataPieceSize * 2)) 
			{
				this.g_DataPiece = 1;
			} 
			else 
			{
				this.g_DataPiece = 2;
			}
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
				{
					return (byte)(pTees.Holes[HoleNumber].Par + 2);
				} 
				else 
				{
					return Score;
				}
			} 
			else if (Handicap < 20) 
			{
				// they take a 7
				if (Score > 7) 
				{
					return 7;
				} 
				else 
				{
					return Score;
				}
			} 
			else if (Handicap < 30) 
			{
				// they take an 8
				if (Score > 8) 
				{
					return 8;
				} 
				else 
				{
					return Score;
				}
			} 
			else 
			{
				// they take a 9
				if (Score > 9) 
				{
					return 9;
				} 
				else 
				{
					return Score;
				}
			}
		}

		///////////////////////////////////////////////////////////////////////
		//  TeamMatchCreateDefaultWolfTeam - creates a default wolf team
		//  Input:  pGame - the game to modify
		//			HoleNumber - the hole number to default
		//  Output: none
		//  Return: none
		//  Notes:
		///////////////////////////////////////////////////////////////////////
		void TeamMatchCreateDefaultWolfTeam(GAME_INFORMATION pGame,
			byte HoleNumber)
		{
			byte		currentPlayer;				// loop variable
			byte []	players = new byte[Global.MAX_PLAYERS];		// the array of players
			byte		ii;							// loop variable
			uint			holeInfo;					// the data to write out
	
			// they haven't been here, initialize the struct
			// we initialize it to the player going wolf
	
			// reset the player we're looking at
			currentPlayer = 1;
	
			// to determine the rotation, take the mod of the
			// hole number by the number of players in wolf,
			// and look up that player
			// anyone who ISN'T that player goes in team two
			for (ii = 0; ii < pGame.TeamSize; ii++) 
			{
				// see if this is the wolf player
				if ((HoleNumber % pGame.TeamSize) == ii) 
				{
					// it is, put them in the first position
					players[0] = ii;
				} 
				else 
				{
					// put them on team 2
					players[currentPlayer] = (byte)(ii + Global.MAX_PLAYERS);
					// advance the current player
					currentPlayer++;
				}
			}
			// convert the players to a integer to write out
			holeInfo = TeamMatchConvertWolfTeam(ref players, pGame.TeamSize);
			// write out the team to the hole info
			pGame.HoleInfo[HoleNumber] = holeInfo;
			espDB.WriteToGame(pGame, espDB.g_State.CurrentGame);
		}

		///////////////////////////////////////////////////////////////////////
		//  TeamMatchConvertWolfTeam - handles events for the team match form
		//  Input:  pPlayers - the array of players
		//			NumPlayers - the number of players to convert
		//  Output: none
		//  Return: the 32 bit integer encoding the team
		//  Notes:
		///////////////////////////////////////////////////////////////////////
		uint TeamMatchConvertWolfTeam(ref byte [] pPlayers,
			byte NumPlayers)
		{
			uint		retValue;	// the value we'll return
	
			// clear the target variable
			retValue = 0;
			// now, we build it up a player at a time.
			// player 1
			retValue |= ((((uint) pPlayers[0]) & 0x0000000F) << 28);
			// player 2
			retValue |= ((((uint) pPlayers[1]) & 0x0000000F) << 24);
			// player 3
			retValue |= ((((uint) pPlayers[2]) & 0x0000000F) << 20);
			// player 4
			retValue |= ((((uint) pPlayers[3]) & 0x0000000F) << 16);
			// if appropriate, convert the fifth player
			if (NumPlayers > Global.WOLF_NUM_PLAYERS) 
			{		
				retValue |= ((((uint) pPlayers[4]) & 0x0000000F) << 12);
			}
			return retValue;
		}
	
		///////////////////////////////////////////////////////////////////////
		//  TeamMatchGetWolfTeam - fetches and converts the player info for a wolf team
		//  Input:  HoleInfo - the hole info we're converting
		//			NumPlayers - the number of players to convert
		//  Output: pPlayers - the array to return the players
		//  Return: none
		//  Notes:
		///////////////////////////////////////////////////////////////////////
		void TeamMatchGetWolfTeam(ref byte [] pPlayers,
			uint		HoleInfo,
			byte	NumPlayers)
		{
			// extract the first four players
			pPlayers[0] = (byte)((HoleInfo & ((uint) 0xF0000000)) >> 28);
			pPlayers[1] = (byte)((HoleInfo & ((uint) 0x0F000000)) >> 24);
			pPlayers[2] = (byte)((HoleInfo & ((uint) 0x00F00000)) >> 20);
			pPlayers[3] = (byte)((HoleInfo & ((uint) 0x000F0000)) >> 16);
			// if necessary, extract player five
			if (NumPlayers > Global.WOLF_NUM_PLAYERS) 
			{
				pPlayers[4] = (byte)((HoleInfo & ((uint) 0x0000F000)) >> 12);
			}
		}
		//---------------
	}
}
