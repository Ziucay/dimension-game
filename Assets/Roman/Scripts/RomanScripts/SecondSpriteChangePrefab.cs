using UnityEngine;

public class SecondSpriteChangePrefab : MonoBehaviour
{
    private Sprite firstSprite;
    public Sprite secondSprite;
    private SpriteRenderer spriteRenderer;

    private bool firstWorld = true;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        firstSprite = spriteRenderer.sprite;
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