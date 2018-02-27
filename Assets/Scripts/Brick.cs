using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public AudioClip crack;
	
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;
	
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		//Keep track of breakable bricks
		if (isBreakable) {
			breakableCount++;
			print (breakableCount);
		}
		
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D (Collision2D col) {
		AudioSource.PlayClipAtPoint(crack, transform.position, 0.15f);
		if (isBreakable) {
			HandleHits();
		}
	}
	
	void HandleHits() {
		int maxHits;
		timesHit++;
		//SimulateWin();
		maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed();
			print (breakableCount);
			Destroy(gameObject);
		}
		else {
			LoadSprites();
		}
	}
	
	void LoadSprites(){
		int spriteIndex = timesHit-1;
		if (hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];	
		}
	}
	
	// TODO remove this method once we can actually win
	void SimulateWin() {
		levelManager.LoadNextLevel();
	}
	
}
