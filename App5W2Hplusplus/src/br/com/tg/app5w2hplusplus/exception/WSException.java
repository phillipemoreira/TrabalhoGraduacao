package br.com.tg.app5w2hplusplus.exception;


public class WSException extends Exception {
	private static final long serialVersionUID = 3660603386264740486L;
	
	private WSExceptionsType exceptionType;
	
	public WSExceptionsType getExceptionType()
	{
		return exceptionType;
	}
	public void setExceptionType(WSExceptionsType exceptionType)
	{
		this.exceptionType = exceptionType;
	}
	
	public WSException(Throwable throwable)
	{
		super(throwable);
	}
	public WSException(String wsError, WSExceptionsType exType)
	{
		super(wsError);
		this.exceptionType = exType;
	}
	
	public enum WSExceptionsType
	{
		CALL_ERROR,
		PARSE_ERROR,
		RESULT_ERROR
	}
}
