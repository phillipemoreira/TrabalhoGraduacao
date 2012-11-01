package br.com.tg.app5w2hplusplus.activity;

import android.os.Bundle;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.Toast;
import br.com.tg.app5w2hplusplus.R;
import br.com.tg.app5w2hplusplus.exception.WSException;
import br.com.tg.app5w2hplusplus.listener.SimpleTaskListener;
import br.com.tg.app5w2hplusplus.parents.App5W2HplusplusActivity;
import br.com.tg.app5w2hplusplus.task.SimpleAsyncTask;
import br.com.tg.app5w2hplusplus.ws.WebServiceApp;

import com.smartnsoft.droid4me.ws.WebServiceClient.CallException;

public class HomeActivity extends App5W2HplusplusActivity implements SimpleTaskListener<String>{

	private Button button1;
	private SimpleAsyncTask<String> asyncTask;
	
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home);
        
        button1 = (Button) this.findViewById(R.id.home_ws);
        button1.setOnClickListener(new OnClickListener() {
			@Override
			public void onClick(View v) {
				asyncTask = new SimpleAsyncTask<String>(HomeActivity.this, HomeActivity.this, R.string.login_progress);
				asyncTask.execute();
			}
		});
        
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.activity_home, menu);
        return true;
    }

	@Override
	public String retrieveObjectInBackground() throws CallException {
		return WebServiceApp.login("teste", "teste");
	}

	@Override
	public void onTaskCompleted(String theObject) {
		Toast.makeText(this, theObject, Toast.LENGTH_LONG).show();
	}

	@Override
	public void onTaskRaisedError(WSException exception) {
		// TODO Auto-generated method stub
		
	}
}
