package br.com.tg.app5w2hplusplus.listener;

import com.smartnsoft.droid4me.ws.WebServiceClient.CallException;

import br.com.tg.app5w2hplusplus.exception.WSException;


public interface SimpleTaskListener<T> {
	public T retrieveObjectInBackground() throws CallException;
	public void onTaskCompleted(T theObject);
	public void onTaskRaisedError(WSException exception);
}
