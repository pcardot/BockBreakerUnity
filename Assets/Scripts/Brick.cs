using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
    public int timesHit;
    public Sprite[] hitSprites;
    public static int numberOfBreakableBricks = 0;
    public AudioClip crack;
    public GameObject smoke;

    private LevelManager levelManager;
    private BonusSpawner bonusSpawner;
    private bool isBreakable;
    private int maxHit;
	// Use this for initialization
	void Start () {
        timesHit = 0;
        maxHit = hitSprites.Length + 1;
        isBreakable = (this.tag == "Breakable");
        if (isBreakable){
            numberOfBreakableBricks++;
        }
        levelManager = FindObjectOfType<LevelManager>();
        bonusSpawner = FindObjectOfType<BonusSpawner>();
	}

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (isBreakable){
            AudioSource.PlayClipAtPoint(crack, transform.position);
            HandleHits();
        }
    }

    private void HandleHits(){
        timesHit += 1;
        if (timesHit >= maxHit){
            //The object doesn't have any more HP, destroying routine
            SelfDestruct();
        }
        else{
            LoadSprites();
        }
    }

    private void SelfDestruct(){
        //Update the count of breakable objects
        numberOfBreakableBricks--;

        //Create a puff smoke
        GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
        smokePuff.particleSystem.startColor = this.GetComponent<SpriteRenderer>().color;

        //Do we earn a bonus or malus ? 
        bonusSpawner.BrickDestroyed(this.transform.position);

        //Checking if it's the last block, if so, load the next level
        levelManager.BrickDestroyed();
        Destroy(this.gameObject);
    }


    private void LoadSprites(){
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex]){
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        } else {
            Debug.LogError("There is a missing sprite for a " + this.gameObject);
        }
    }
    

    // Update is called once per frame
    void Update () {
	    
	}

    private void OnDestroy()
    {   
        
    }
}
