using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairScript : MonoBehaviour {

    private SpriteRenderer spriteRenderer;

    private Sprite initialSprite;

    [SerializeField]
    private Sprite seatedSprite = null;

    [SerializeField]
    private List<GameObject> neighbors;

    private Person Person = null;

    private GameScript GlobalScript = null;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialSprite = spriteRenderer.sprite;

        GameScript[] gameScripts = FindObjectsOfType<GameScript>();

        if(gameScripts.Length >= 1)
        {
            GlobalScript = gameScripts[0];
            if(gameScripts.Length > 1)
            {
                Debug.LogWarningFormat("Expected one GameScript in scene but found %d. Using the first one found.", gameScripts.Length);
            }
        } else
        {
            throw new System.Exception("No GameScript components found in scene");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        
        if (GlobalScript.ToBeSeated.Count > 0)
        {
            Person p = GlobalScript.ToBeSeated.Dequeue();
            spriteRenderer.sprite = seatedSprite;
            GlobalScript.SeatedPeople.Add(p);
        }
    }
}
