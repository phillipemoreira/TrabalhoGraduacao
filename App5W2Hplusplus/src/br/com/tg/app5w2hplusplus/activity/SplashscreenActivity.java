package br.com.tg.app5w2hplusplus.activity;

import br.com.tg.app5w2hplusplus.R;
import br.com.tg.app5w2hplusplus.R.layout;
import br.com.tg.app5w2hplusplus.R.menu;
import android.os.Bundle;
import android.app.Activity;
import android.view.Menu;

public class SplashscreenActivity extends Activity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_splashscreen);
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.splashscreen, menu);
		return true;
	}

}
