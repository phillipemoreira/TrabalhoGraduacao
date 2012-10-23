package br.com.tg.app5w2hplusplus.model;

import java.io.Serializable;
import java.util.List;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonProperty;


public class Program extends WSObject implements Serializable {
	private static final long serialVersionUID = 942755064445378231L;

	private long id;
	@JsonProperty("nome")
	private String name;
	@JsonIgnore
	private List<Exercise> exercises;
	
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
	public List<Exercise> getExercises()
	{
		return exercises;
	}
	public void setExercises(List<Exercise> exercises)
	{
		this.exercises = exercises;
	}
	
	public Program(){}
	
}
