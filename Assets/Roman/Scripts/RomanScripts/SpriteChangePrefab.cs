using UnityEngine;

public class SpriteChangePrefab : MonoBehaviour
{
    public Sprite firstSprite;
    public Sprite secondSprite;
    private SpriteRenderer spriteRenderer;

    public bool firstWorld = true;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public void ChangeSprite()
    {
        firstWorld = !firstWorld;
        if (firstWorld)
        {
            spriteRenderer.sprite = firstSprite;
        }
        else
        {
            spriteRenderer.sprite = secondSprite;
        }
    }
}