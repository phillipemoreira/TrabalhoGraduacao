package br.com.tg.app5w2hplusplus.activity;

import android.os.Bundle;
import android.view.Menu;
import br.com.tg.app5w2hplusplus.R;
import br.com.tg.app5w2hplusplus.parents.App5W2HplusplusActivity;

public class HomeActivity extends App5W2HplusplusActivity {

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.activity_home, menu);
        return true;
    }
}
