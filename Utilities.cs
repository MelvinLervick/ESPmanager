using System;

namespace ESPmanager
{
	/// <summary>
	/// Summary description for Utilities.
	/// </summary>
	public class Utilities
	{
		// formatting constants
		//#define NUM_DIGITS   15
		//#define MIN_FLOAT    4
		//#define ROUND_FACTOR 1.0000000000000005 /* NUM_DIGITS zeros */
		private const byte NUM_DIGITS = 15;
		private const byte MIN_FLOAT = 4;
		private const double ROUND_FACTOR = 1.0000000000000005;

		// FP conversion constants
		static double [] pow1 = 
			{
				1e256, 1e128, 1e064,
				1e032, 1e016, 1e008,
				1e004, 1e002, 1e001
			};

		static double [] pow2 = 
			{
				1e-256, 1e-128, 1e-064,
				1e-032, 1e-016, 1e-008,
				1e-004, 1e-002, 1e-001
			};

		public Utilities()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		///////////////////////////////////////////////////////////////////////
		//  PrintCenteredString - prints a centered string
		//  Input:  pString - the string to print
		//			StartX - the starting X value
		//			EndX - the ending X value
		//			YValue - the y value to print at
		//  Output: none
		//  Return: none
		//  Notes:	
		///////////////////////////////////////////////////////////////////////
		/* PrintCenteredString, EraseCenteredString and PrintDouble are used to display
		 * PALM data.  A similar function(s) may be necessary for reports, but
		 * probably not.
		 * 
		void PrintCenteredString(ref string pString, short StartX, short EndX, short YValue)
		{
			short		width;		// width of the string
			short		offsetX;	// offset into the cell for the string

			// get the width of this string (in pixels)
			width = FntCharsWidth(pString, StrLen(pString));
			// calculate the starting location for the string
			offsetX = ((EndX - StartX) - width) / 2;
			// draw it on screen
			WinDrawChars(pString, 
				StrLen(pString), 
				StartX + offsetX, 
				YValue);
		}

		///////////////////////////////////////////////////////////////////////
		//  EraseCenteredString - erases a centered string
		//  Input:  pString - the string to erase
		//			StartX - the starting X value
		//			EndX - the ending X value
		//			YValue - the y value to erase at
		//  Output: none
		//  Return: none
		//  Notes:	
		///////////////////////////////////////////////////////////////////////
		void EraseCenteredString(char	*pString,
			Int16	StartX,
			Int16	EndX,
			Int16	YValue)
		{
			Int16		width;		// width of the string
			Int16		offsetX;	// offset into the cell for the string

			// get the width of this string
			width = FntCharsWidth(pString, StrLen(pString));
			// calculate the starting location for the string
			offsetX = ((EndX - StartX) - width) / 2;
			// draw it on screen
			WinEraseChars(pString, 
				StrLen(pString), 
				StartX + offsetX, 
				YValue);
		}
		
		///////////////////////////////////////////////////////////////////////
		//  PrintDouble - prints a double precision number into a string
		//  Input:  Number - the number to print
		//  Output: pString - the string to print to
		//  Return: none
		//  Notes:  this function was taken from the web - that's why it's ugly
		///////////////////////////////////////////////////////////////////////
		void PrintDouble(double Number, 
						char 	*pString)
		{
			FlpCompDouble fcd;
			short e, e1, i;
			double *pd, *pd1;
			char sign = '\0';
			short dec = 0;

			/*------------------------------------------------------------------
			/* Round to desired precision                                     
			/* (this doesn't always provide a correct last digit!)    
			/*-----------------------------------------------------------------
			Number = Number * ROUND_FACTOR;

			/*------------------------------------------------------------------
			/* check for NAN, +INF, -INF, 0                                  
			/*------------------------------------------------------------------
			fcd.d = Number;
			if ((fcd.ul[0] & 0x7ff00000) == 0x7ff00000)
				if (fcd.fdb.manH == 0 && fcd.fdb.manL == 0)
					if (fcd.fdb.sign)
						StrCopy(pString, "[-inf]");
					else
						StrCopy(pString, "[inf]");
				else
					StrCopy(pString, "[nan]");
			else if (FlpIsZero(fcd))
				StrCopy(pString, "0");
			else {
				/*----------------------------------------------------------------
				/* Make positive and store sign                                
				/*----------------------------------------------------------------
				if (FlpGetSign(fcd)) {
					*pString++ = '-';
					FlpSetPositive(fcd);
				}

				if ((unsigned) fcd.fdb.exp < 0x3ff) {   /* meaning Number < 1.0 
					/*--------------------------------------------------------------
					/* Build negative exponent                                      
					/*--------------------------------------------------------------
					for (e = 1, e1 = 256, pd = pow1, pd1 = pow2; e1;
						e1 >>= 1, ++pd, ++pd1)
						if (*pd1 > fcd.d) {
							e += e1;
							fcd.d = fcd.d * *pd;
						}
					fcd.d = fcd.d * 10.0;

					/*--------------------------------------------------------------
					/* Only print big exponents                                     
					/*--------------------------------------------------------------
					if (e <= MIN_FLOAT) {
						*pString++ = '0';
						*pString++ = '.';
						dec = -1;
						while (--e)
							*pString++ = '0';
					}
					else
						sign = '-';
				}
				else {
					/*--------------------------------------------------------------
					/* Build positive exponent                                      
					/*--------------------------------------------------------------
					for (e = 0, e1 = 256, pd = pow1, pd1 = pow2; e1;
						e1 >>= 1, ++pd, ++pd1)
						if (*pd <= fcd.d) {
							e += e1;
							fcd.d = fcd.d * *pd1;
						}
					if (e < NUM_DIGITS)
						dec = e;
					else
						sign = '+';
				}

				/*----------------------------------------------------------------
				/* Extract decimal digits of mantissa                        
				/*----------------------------------------------------------------
				for (i = 0; i < NUM_DIGITS; ++i, --dec) {
					Int32 d = fcd.d;
					*pString++ = d + '0';
					if (!dec)
						*pString++ = '.';
					fcd.d = fcd.d - (double)d;
					fcd.d = fcd.d * 10.0;
				}

				/*----------------------------------------------------------------
				/* Remove trailing zeros and decimal point             
				/*----------------------------------------------------------------
				while ((pString[-1] == '0') && (pString[-2] != '.'))
					*--pString = '\0';

				/*----------------------------------------------------------------
				/* Append exponent                                                   
				/*----------------------------------------------------------------
				if (sign) {
					*pString++ = 'e';
					*pString++ = sign;
					StrIToA(pString, e);
				}
				else
					*pString = '\0';
			}
		}
		*/
		//=========================
	}
}
