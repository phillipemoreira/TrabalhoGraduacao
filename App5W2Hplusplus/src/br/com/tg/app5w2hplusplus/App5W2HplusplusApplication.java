package br.com.tg.app5w2hplusplus;

import android.content.SharedPreferences;
import br.com.tg.app5w2hplusplus.helper.Constants;

import com.smartnsoft.droid4me.app.SmartApplication;


public class App5W2HplusplusApplication extends SmartApplication {

	private I18N i18nObject;
	private static SharedPreferences app5w2hPreferences;
		
	public static SharedPreferences getApp5w2hPreferences()
	{
		return app5w2hPreferences;
	}

	//Method used at the application creation
	@Override
	protected void onCreateCustom()
	{
		super.onCreateCustom();
		logDeviceInformation();
		app5w2hPreferences = getPreferences();
	}
	
	@Override
  protected int getLogLevel()
  {
    return Constants.LOG_LEVEL;
  }
	
	@Override
	protected I18N getI18N()
	{
		if(i18nObject == null)
			i18nObject = new SmartApplication.I18N(
					getText(R.string.problem), 
					getText(R.string.unavailableItem), 
					getText(R.string.unavailableService), 
					getText(R.string.connectivityProblem), 
					getText(R.string.connectivityProblemRetry), 
					getText(R.string.unhandledProblem), 
					getString(R.string.app_name), 
					getText(R.string.dialogButton_unhandledProblem), 
					getString(R.string.progressDialogMessage_unhandledProblem));
    return i18nObject;
	}

	@Override
	protected String getLogReportRecipient()
	{		
		return Constants.REPORT_LOG_RECIPIENT_EMAIL;
	}
	
}
