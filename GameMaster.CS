using System;

namespace ESPmanager
{
	/// <summary>
	/// Summary description for GameMaster.
	///////////////////////////////////////////////////////////////////////
	/// GameMaster.c - handlers for the game master form
	/// Copyright (c) 2002, golfESP
	/// Created for Palm by Joshua Buergel
	/// Modified for .NET by Melvin Lervick 
	///////////////////////////////////////////////////////////////////////
	/// </summary>
	public class GameMaster
	{
		// Create Instance of Database (sent from user form)
		Database espDB;
		GameSummary gs;

		// the row heights
		//#define ROW_HEIGHT				(12)
		//#define GAME_HEIGHT			(24)
		private const byte ROW_HEIGHT = 12;
		private const byte GAME_HEIGHT = 24;

		// the max width
		//#define MAX_WIDTH				(143)
		private const byte MAX_WIDTH = 143;

		// locations of the labels
		//#define START_X						(5)
		//#define START_Y						(20)
		private const byte START_X = 5;
		private const byte START_Y = 20;

		// the size of our array
		//#define MASTER_GAMES_PAGE_SIZE	(5)
		private const byte MASTER_GAMES_PAGE_SIZE = 5;

		// used to indicate that a game is not present
		//#define NO_GAME					(0xFF)
		private const byte NO_GAME = 0xFF;

		// the current scroll position
		//static UInt8	g_ScrollPosition;

		// the count of games
		//static UInt8	g_GameCount;

		// array of indices for the games
		//static UInt8	g_GameArray[MASTER_GAMES_PAGE_SIZE];

		// prototyptes
	
		// draws the labels on the screen
		//void MasterGamesDrawLabels();
	
		// initializes the form
		//void MasterGamesInitForm(FormPtr	pForm);

		// handles scrolling events
		//void MasterGamesHandleScroll(FormPtr pForm, Int8 ScrollChange);

		// draws the text for a game
		//void MasterGamesDrawGame(UInt8 Index,
		//				Boolean DrawText,
		//				Boolean DrawLine,
		//				Int16 StartX,
		//				Int16 StartY);
						 
		// draws the teams on screen
		//void MasterGamePrintTeams(PGAME_INFORMATION pGame,
		//				Boolean DrawText,
		//				Int16 StartX,
		//				Int16 StartY);

		public GameMaster( ref Database db )
		{
			//
			// TODO: Add constructor logic here
			//
			espDB = db;
			gs = new GameSummary( ref espDB );
		}
/*
		public void GamePrintController()
		{
			// Verify that there are games to Print
			if (espDB.cGames.Length == 0)
			{
				// Print Message that there are no Games

				return;
			}

			// Process and Print each Game
			for(byte i=0;i<espDB.cGames.Length;i++)
			{
				espDB.g_State.CurrentGame = i;
				// Compute Game Data
				gs.GameSummaryComputeGame(espDB.cGames[i]);
			}
		}
*/
	}
}
