/**
 * 
 */
package br.com.tg.app5w2hplusplus.parents;

import br.com.tg.app5w2hplusplus.helper.Redirector;
import android.app.Activity;

/**
 * @author Victor T. Queiroz
 *
 */
public abstract class App5W2HplusplusActivity extends Activity {

	@Override
	public void onResume() {
		Redirector.executeRedirector(this);
		super.onResume();		
	}

}
