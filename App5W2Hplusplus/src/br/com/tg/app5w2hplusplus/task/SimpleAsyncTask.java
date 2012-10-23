package br.com.tg.app5w2hplusplus.task;

import android.app.Activity;
import android.app.ProgressDialog;
import android.os.AsyncTask;
import android.util.Log;
import br.com.tg.app5w2hplusplus.R;
import br.com.tg.app5w2hplusplus.exception.WSException;
import br.com.tg.app5w2hplusplus.exception.WSException.WSExceptionsType;
import br.com.tg.app5w2hplusplus.listener.SimpleTaskListener;

import com.smartnsoft.droid4me.ws.WebServiceClient.CallException;

public class SimpleAsyncTask<T> extends AsyncTask<String, Void, T>{

	private Activity theActivity;	
	private ProgressDialog progressDialog;
	private WSException raisedException;
	private boolean needProgDiag;
	private SimpleTaskListener<T> taskListener;
	private int progressTextId;
	private boolean isStillShowing;
	
	public boolean isStillShowing()
	{
		return isStillShowing;
	}
	public void setStillShowing(boolean isStillShowing)
	{
		this.isStillShowing = isStillShowing;
	}

	public SimpleAsyncTask(Activity activity, SimpleTaskListener<T> taskListener, int progressResId) {
		this.needProgDiag = true;
		this.theActivity = activity;
		this.taskListener = taskListener;
		this.progressTextId = progressResId;
		this.isStillShowing = true;
	}
	
	public SimpleAsyncTask(Activity activity, SimpleTaskListener<T> taskListener) {
		this.needProgDiag = false;
		this.theActivity = activity;
		this.taskListener = taskListener;
		this.progressTextId = 0;
		this.isStillShowing = true;
	}
	
	@Override
	protected T doInBackground(String... params) {
		if(!isStillShowing)
			return null;
		
		T object = null;
		try
		{
			object = taskListener.retrieveObjectInBackground();
			Log.d("DEBUG VARIABLE OBJECT", object.toString());
		}
		catch(CallException callEx)
		{
			Throwable cause = callEx.getCause();
			if(cause != null)
				this.raisedException = (WSException) cause;
			else
				this.raisedException = new WSException(callEx.getMessage(), WSExceptionsType.CALL_ERROR);
			object = null;
		}
		
		return object;
	}

	@Override
  protected void onPreExecute() {
		super.onPreExecute();
		if(!this.needProgDiag || !this.isStillShowing)
			return;		
		
		if(progressDialog != null && progressDialog.isShowing())
			return;
		
		progressDialog = ProgressDialog.show(theActivity, theActivity.getResources().getString(R.string.progressDialog_title), 
				theActivity.getResources().getString(progressTextId));
  }
	
	@Override
	protected void onPostExecute(T result) {
		super.onPostExecute(result);
		
		if(!this.isStillShowing)
			return;
		
		
		if(this.needProgDiag && progressDialog != null && progressDialog.isShowing())
			progressDialog.dismiss();
		
		if(this.raisedException != null)
			taskListener.onTaskRaisedError(raisedException);
		else
			taskListener.onTaskCompleted(result);
	}	
}
