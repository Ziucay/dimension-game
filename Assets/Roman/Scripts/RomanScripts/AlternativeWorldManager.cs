using System.Collections;
using UnityEngine;

public class AlternativeWorldManager : MonoBehaviour
{
    public LevelManager gameLevelManager;

    private bool firstWorld;
    private InvisiblePrefab[] invisiblePrefabs;
    private ColliderPrefab[] colliderPrefabs;
    private SecondSpriteChangePrefab[] secondSpriteChangePrefabs;
    private SpriteChangePrefab[] spriteChangePrefabs;

    // Start is called before the first frame update
    void Start()
    {
        firstWorld = true;

        gameLevelManager = FindObjectOfType<LevelManager>();
        gameLevelManager.UpdateTextWorld(firstWorld);

        initializePrefabs();
    }

    private void initializePrefabs()
    {
        invisiblePrefabs = FindObjectsOfType<InvisiblePrefab>();
        for (int i = 0; i < invisiblePrefabs.Length; i++)
        {
            invisiblePrefabs[i].SetInitialVisibility();
        }

        colliderPrefabs = FindObjectsOfType<ColliderPrefab>();
        secondSpriteChangePrefabs = FindObjectsOfType<SecondSpriteChangePrefab>();
        spriteChangePrefabs = FindObjectsOfType<SpriteChangePrefab>();
    }

    public void SwitchWorld()
    {
        firstWorld = !firstWorld;
        gameLevelManager.UpdateTextWorld(firstWorld);

        switchPrefabs();
    }

    private void switchPrefabs()
    {
        switchInvisiblePrefabs();
        switchColliderPrefabs();
        switchSecondSpriteChangePrefabs();
        switchSpriteChangePrefabs();
    }

    private void switchInvisiblePrefabs()
    {
        for (int i = 0; i < invisiblePrefabs.Length; i++)
        {
            if (invisiblePrefabs[i] != null)
            {
                invisiblePrefabs[i].ChangeVisibility();
            }
        }
    }

    private void switchColliderPrefabs()
    {
        for (int i = 0; i < colliderPrefabs.Length; i++)
        {
            if (colliderPrefabs[i] != null)
            {
                colliderPrefabs[i].changeCollision();
            }
        }
    }

    private void switchSecondSpriteChangePrefabs()
    {
        for (int i = 0; i < secondSpriteChangePrefabs.Length; i++)
        {
            if (secondSpriteChangePrefabs[i] != null)
            {
                secondSpriteChangePrefabs[i].ChangeSprite();
            }
        }
    }

    private void switchSpriteChangePrefabs()
    {
        for (int i = 0; i < spriteChangePrefabs.Length; i++)
        {
            if (spriteChangePrefabs[i] != null)
            {
                spriteChangePrefabs[i].ChangeSprite();
            }
        }
    }
}