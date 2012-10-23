package br.com.tg.app5w2hplusplus.model;

import java.io.Serializable;

import com.fasterxml.jackson.annotation.JsonProperty;


public class Exercise extends WSObject implements Serializable {
	private static final long serialVersionUID = 4093062199561027503L;

	private long id;
	@JsonProperty("nome")
	private String name;
	@JsonProperty("descricao")
	private String description;
	@JsonProperty("duracao")
	private String duration;
	@JsonProperty("consumo")
	private String consumedCalories; 
	

	public long getId()
	{
		return id;
	}
	public void setId(long id)
	{
		this.id = id;
	}
	public String getName()
	{
		return name;
	}
	public void setName(String name)
	{
		this.name = name;
	}
	public String getDescription()
	{
		return description;
	}
	public void setDescription(String description)
	{
		this.description = description;
	}
	public String getDuration()
	{
		return duration;
	}
	public void setDuration(String duration)
	{
		this.duration = duration;
	}
	public String getConsumedCalories()
	{
		return consumedCalories;
	}
	public void setConsumedCalories(String consumedCalories)
	{
		this.consumedCalories = consumedCalories;
	}
	
	public Exercise() {}
	
}
