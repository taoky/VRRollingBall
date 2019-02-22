using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private float score;
	private int life;
	private int nolifetimes;
	public GUIText scoreText;
	public GUIText lifeText;
	public bool isAlive;
	private AudioSource _gameoverAudio;
	private AudioSource _Audio;

	// Use this for initialization
	void Start () {
		score = 0;
		life = 3;
		nolifetimes = 1;
		isAlive = true;
		_gameoverAudio = this.gameObject.AddComponent<AudioSource>();
		AudioClip audioClip = Resources.Load<AudioClip>("GameOver");
		_gameoverAudio.clip = audioClip;
		UpdateScore ();
		UpdateLife ();
	}

	public void AddScore(int x){
		score += x;
		_Audio = this.gameObject.AddComponent<AudioSource>();
		AudioClip audioClip = Resources.Load<AudioClip>("Item2");
		_Audio.clip = audioClip;
		_Audio.Play();
		UpdateScore ();
	}

	public void DelLife(){
		life--;
		_Audio = this.gameObject.AddComponent<AudioSource>();
		AudioClip audioClip = Resources.Load<AudioClip>("Bite");
		_Audio.clip = audioClip;
		_Audio.Play();
		UpdateLife ();
	}

	public void AddLife() {
		life++;
		_Audio = this.gameObject.AddComponent<AudioSource>();
		AudioClip audioClip = Resources.Load<AudioClip>("Item3");
		_Audio.clip = audioClip;
		_Audio.Play();
		UpdateLife ();
	}

	void UpdateScore () {
		scoreText.text = "Score: " + score.ToString("N2");
	}

	void UpdateLife () {
		if (life <= 0) {
			lifeText.text = "GAME OVER!";
			scoreText.text = "ENJOY!";
			isAlive = false;
			// StartCoroutine(Wait());
			// SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			GameObject bgmObject = GameObject.Find("Main Camera");
			AudioSource bgmSource = bgmObject.GetComponent<AudioSource>();
			bgmSource.Pause();


			_gameoverAudio.Play();
			Invoke("Restart", 13);
		}
		else {
			lifeText.text = "Life: " + life;
		}
	}

	private void Restart() {
		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
	}

	void FixedUpdate() {
		score -= 0.005f;
		if (isAlive)
			UpdateScore();
		if (score <= nolifetimes * -5 && isAlive) {
			DelLife();
			nolifetimes++;
		}
	}
}
