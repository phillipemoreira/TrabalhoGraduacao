package br.com.tg.app5w2hplusplus.helper;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

import android.content.SharedPreferences;
import android.content.SharedPreferences.Editor;
import br.com.tg.app5w2hplusplus.App5W2HplusplusApplication;


public class Tools {

/*
 * Preferences manipulation 
 */
	/**
	 * Function checking if the splash screen needs to be shown
	 * @param preferences : The SharedPreferences of the application in which is stored the last opening date.
	 * @return True if the splash screen has not been open for <strong>Constant.SPLASH_SCREEN_INIT_TIME_VALIDITY</strong> milliseconds, 
	 * false if it has been opened sooner
	 */
//		public static boolean isSplashScreenInitialized()
//		{
//			SharedPreferences preferences = BemMeQueroApplication.getBemMeQueroPreferences();
//			String initDate = preferences.getString(Constants.PREF_KEY_INIT_SPLASH_DATE, null);
//			if(initDate == null || initDate.length() == 0)
//				return false;
//			
//			Date theDate = convertStringToDate(initDate);
//			if(theDate == null)
//				return false;
//			
//			if(theDate.getTime() < (new Date().getTime() - Constants.SPLASH_SCREEN_INIT_TIME_VALIDITY))
//				return false;
//			
//			return true;
//		}
		/**
		 * Function checking if the login activity needs to be shown
		 * @return True if there is no user logged in
		 */
		public static boolean isUserLoggedIn()
		{
			SharedPreferences preferences = App5W2HplusplusApplication.getApp5w2hPreferences();
			String usrId = preferences.getString(Constants.PREF_KEY_USER_ID, null);
			if(usrId != null)
				return true;
			
			return false;
		}
		
		/**
		 * Function saving the splash activity opening date 
		 * @param theActivity : The opened activity
		 * @param theDate : The date on which the splash screen has been opened
		 */
		public static void saveInitDateSplashScreen(Date theDate)
		{
			SharedPreferences preferences = App5W2HplusplusApplication.getApp5w2hPreferences();
			Editor editPref = preferences.edit();
			editPref.putString(Constants.PREF_KEY_INIT_SPLASH_DATE, convertDateToString(theDate));
			editPref.commit();
		}
		public static void saveUser(String userId)
		{
			SharedPreferences preferences = App5W2HplusplusApplication.getApp5w2hPreferences();
			Editor editPref = preferences.edit();
			editPref.putString(Constants.PREF_KEY_USER_ID, userId);
			editPref.commit();
		}
		public static void saveTerms(String terms)
		{
			SharedPreferences preferences = App5W2HplusplusApplication.getApp5w2hPreferences();
			Editor editPref = preferences.edit();
			editPref.putString(Constants.PREF_KEY_TERMS_ACCEPTED, terms);
			editPref.commit();
		}
/*
 * /Preferences manipulation 
 */		

/*
 * Tools functions
 */	
		/**
		 * Function used to convert a date in string format to a date.
		 * Respect the date format of the date return by the web services.
		 * @param stringDate : The string date with the format given in the constant {@link:Constants.DATE_FORMAT} 
		 * @return The converted date, null if bad format
		 */
		public static Date convertStringToDate(String stringDate)
		{
			SimpleDateFormat dateFormat = new SimpleDateFormat(Constants.DATE_FORMAT);
			try
			{
				return dateFormat.parse(stringDate);
			}
			catch(ParseException ex)
			{
				return null;
			}
		}
		/**
		 * Function used to convert a date a string date.
		 * Respect the date format of the date return by the web services.
		 * @param theDate : The date to convert 
		 * @return The string date with the format given in the constant {@link:Constants.DATE_FORMAT} 
		 */
		public static String convertDateToString(Date theDate)
		{
			SimpleDateFormat dateFormat = new SimpleDateFormat(Constants.DATE_FORMAT);
			return dateFormat.format(theDate);			
		}
/*
 * /Tools functions
 */
}
