package br.com.fatec.apptgproject;

import android.app.Activity;
import android.content.Intent;
import android.content.pm.ActivityInfo;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;

public class SecondActivity extends Activity {

	/** Called when the activity is first created. */
	@Override
	public void onCreate(Bundle savedInstanceState) {
	    super.onCreate(savedInstanceState);
	    setRequestedOrientation (ActivityInfo.SCREEN_ORIENTATION_PORTRAIT);
	    setContentView(R.layout.activity_second);
	    
	    Intent intent = getIntent();
	    String message = intent.getStringExtra(MainActivity.MAIN_MESSAGE);
	    
	    EditText ediText = (EditText) findViewById(R.id.editText1);
	    ediText.setText(message);
	    
	}

	public void voltarView(View view) {
		Intent intent = new Intent(this, MainActivity.class);
		startActivity(intent);
	}
}
