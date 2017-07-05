using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name){
        Debug.Log("Level load requested for " + name);
        Brick.numberOfBreakableBricks = 0;
        Application.LoadLevel(name);
    }

    public void QuitRequest() {
        Debug.Log("Quit requested");
        Application.Quit();
    }

    public void BrickDestroyed(){
        if (Brick.numberOfBreakableBricks <= 0){
            LoadNextLevel();
        }
    }

    public void LoadNextLevel(){ 
        Brick.numberOfBreakableBricks = 0;
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
