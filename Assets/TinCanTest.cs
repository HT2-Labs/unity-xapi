using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TinCan;
using TinCan.LRSResponses;

public class TinCanInterface{

	private string endpoint;
	private string user;
	private string pass;

	private RemoteLRS lrs = null;

	public TinCanInterface(string endpoint, string user, string password){
		this.endpoint = endpoint;
		this.user = user;
		this.pass = password;
		this.lrs = new RemoteLRS (endpoint, user, password);
	}

	public LRSResponse SendStatement(Statement statement) {
		return this.lrs.SaveStatement(statement);
	}
}

public class TinCanTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log("Hello World!");
		string endpoint = "https://ORG_NAME.learninglocker.net/data/xAPI";
		string user = "KEY";
		string password = "SECRET";
		TinCanInterface lrsConnection = new TinCanInterface(endpoint, user, password);

		var actor = new Agent();
		actor.mbox = "mailto:info@tincanapi.com";

		var verb = new Verb();
		verb.id = new Uri ("http://adlnet.gov/expapi/verbs/experienced");
		verb.display = new LanguageMap();
		verb.display.Add("en-US", "experienced");

		var activity = new Activity();
		activity.id = "http://rusticisoftware.github.io/TinCan.NET";

		var statement = new Statement();
		statement.actor = actor;
		statement.verb = verb;
		statement.target = activity;

		var response = lrsConnection.SendStatement (statement);
		Debug.Log(response);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
