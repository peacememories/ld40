using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairScript : MonoBehaviour {

    private SpriteRenderer spriteRenderer;

    private Sprite initialSprite;

    [SerializeField]
    private Sprite seatedSprite;

    [SerializeField]
    private List<GameObject> neighbors;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialSprite = spriteRenderer.sprite;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        spriteRenderer.sprite = seatedSprite;
    }
}
