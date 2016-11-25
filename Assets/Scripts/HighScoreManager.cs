﻿using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : Singleton<HighScoreManager>
{
	public Text lengthText;
	public Text nameText;

	public const string ScoreKey = "HighScore.Score";
	public const string NameKey = "HighScore.Name";

	void Start()
	{
		DisplayText();
	}

	public void RegisterScore(float newScore, System.Action callback)
	{
		if (PlayerPrefs.GetFloat(ScoreKey, 0) > newScore)
		{
			callback();
		}
		else
		{
			UIManager.Instance.ShowHighScoreDialogue(FormatScore(newScore), s =>
			{
				PlayerPrefs.SetFloat(ScoreKey, newScore);
				PlayerPrefs.SetString(NameKey, s);
				DisplayText();
				callback();
			}
			);
		}
	}

	void DisplayText()
	{
		var score = PlayerPrefs.GetFloat(ScoreKey, 0);
		lengthText.text = FormatScore(score);
		nameText.text = PlayerPrefs.GetString(NameKey, "");
	}

	string FormatScore(float score)
	{
		return (score).ToString("0.0") + " m";
	}
}
