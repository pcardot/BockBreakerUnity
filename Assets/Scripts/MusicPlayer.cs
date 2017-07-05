using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    public static MusicPlayer instance = null;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            print("Music Player self destructing");
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }


    // Use this for initialization
    void Start () {
        Debug.Log("Music Player start" + GetInstanceID());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
