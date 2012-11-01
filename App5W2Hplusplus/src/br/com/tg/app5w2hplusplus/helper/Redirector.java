package br.com.tg.app5w2hplusplus.helper;

import android.app.Activity;
import android.content.Intent;
import br.com.tg.app5w2hplusplus.activity.LoginActivity;

public class Redirector {

	/**
	 * This function will check if a redirection need to be made. It's launched
	 * at the beginning of onResume()
	 * 
	 * @param activity
	 */
	public static void executeRedirector(Activity activity) {
		Intent redirectionIntent = getRedirection(activity);
		if (redirectionIntent != null) {
			redirectionIntent.addFlags(Intent.FLAG_ACTIVITY_NO_HISTORY);
			activity.startActivity(redirectionIntent);
		}
	}

	/**
	 * This redirector will allow us to launch the right activities if needed.
	 * For example, we can launch the splash screen or the login activity before
	 * the home.
	 * 
	 * @return The intent for the redirected activity, null if no redirection
	 *         needed.
	 */
	public static Intent getRedirection(Activity activity) {
		// Redirection for the SplashScreen
		// if(!Tools.isSplashScreenInitialized())
		// {
		// if(activity instanceof SplashActivity)
		// {
		// //We already are in the splash screen activity
		// return null;
		// }
		// else
		// {
		// //We are not in the splash activity
		// return new Intent(activity, SplashActivity.class);
		// }
		// }
		// Redirection for the Login
		if (!Tools.isUserLoggedIn()) {
			if (activity instanceof LoginActivity) {
				// We already are in the LoginActivity
				return null;
			} else {
				// We are not in the LoginActivity
				return new Intent(activity, LoginActivity.class);
			}
		}
		return null;
	}

}
