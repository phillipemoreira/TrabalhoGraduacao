package br.com.tg.app5w2hplusplus.activity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.Toast;
import br.com.tg.app5w2hplusplus.R;
import br.com.tg.app5w2hplusplus.helper.Tools;
import br.com.tg.app5w2hplusplus.parents.App5W2HplusplusActivity;

public class LoginActivity extends App5W2HplusplusActivity {

	private Button mBtnLogin; 
	
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        
        mBtnLogin = (Button) this.findViewById(R.id.login_btnTeste);
		mBtnLogin.setOnClickListener(new OnClickListener() {
			@Override
			public void onClick(View v) {
				Tools.saveUser("1");
				Toast.makeText(v.getContext(), "Teste", Toast.LENGTH_LONG).show();
				v.getContext().startActivity(new Intent(v.getContext(), HomeActivity.class));
			}
		});
    }
}