package br.com.tg.app5w2hplusplus.helper;

import org.apache.http.protocol.HTTP;

import android.util.Log;


public class Constants {

	public final static int SPLASH_SCREEN_WAITING_TIME = 2000;
	/***	
	 * The time during which we don't have to show the splash screen (in millisecond)
	 */
	public final static long SPLASH_SCREEN_INIT_TIME_VALIDITY = 24 * 60 * 60 * 1000;    
	
	public final static String DATE_FORMAT = "yyyy-MM-dd";
	public final static String REPORT_LOG_RECIPIENT_EMAIL = "report@teste.com";
	
	/**
   * The logging level of the application and of the droid4me framework.
   */
	//Set to ERROR for PRODUCTION
  public static final int LOG_LEVEL = Log.VERBOSE;
  
/*
 * Web Service Constants	
 */
	public static final String WEBSERVICES_BASE_URL = "http://localhost";
	/**
   * The encoding used for wrapping the URL of the HTTP requests.
   */
	public static final String WEBSERVICES_HTML_ENCODING = HTTP.UTF_8;
	/**
   * The socket time-out expressed in milliseconds.
   */
  public static final int HTTP_SOCKET_TIMEOUT_IN_MILLISECONDS = 30 * 1000;
  /**
   * The server side response time
   */
  public static final int HTTP_CONNECTION_TIMEOUT_IN_MILLISECONDS = 60 * 1000;
/*
 * /Web Service Constants	
 */
		
/*
 * Preferences Keys 
 */
	public final static String PREF_KEY_INIT_SPLASH_DATE = "prefKeyInitSplashDate"; 
	public final static String PREF_KEY_USER_ID = "prefKeyPwd";
	public final static String PREF_KEY_TERMS_ACCEPTED = "prefKeyTerms";
/*
 * /Preferences Keys 
 */
}
