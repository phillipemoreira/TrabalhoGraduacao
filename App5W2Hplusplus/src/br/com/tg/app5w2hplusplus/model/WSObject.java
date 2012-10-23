package br.com.tg.app5w2hplusplus.model;



public class WSObject {
	private String result;

	public String getResult()
	{
		return result;
	}
	public void setResult(String result)
	{
		this.result = result;
	}
	
	public boolean isResultOk()
	{
		if(result != null && result.equals("OK"))
			return true;
		
		return false;
	}
}
