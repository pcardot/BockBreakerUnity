using UnityEngine;
using System.Collections;

public class BonusSpawner : MonoBehaviour {
    public static BonusSpawner bonusSpawner = null;

    //TODO Create bonus class
    private Stack<Bonuses> bonusNotInUse;
	// Use this for initialization
	void Awake () {
	    if (!bonusSpawner){
            bonusSpawner = this;
        }else{
            Destroy(this);
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void BrickDestroyed(Vector2 position){
        //2 times out of ten we spawn a random bonus or malus between (multiball, extra life, padle enlarging or narrowing)
        if (Random.Range(0f, 100f) < 20f){
            SpawnRandomBonus(position);
        }
    }


    //TODO make bonus spawn really
    private void SpawnRandomBonus(Vector2 position){
        Debug.Log("Bonus should spawn at position" + position);
    }
}
