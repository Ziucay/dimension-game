using UnityEngine;

public class ColliderPrefab : MonoBehaviour
{
    public bool isCollidesInFirstWorld;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Collider2D>().enabled = isCollidesInFirstWorld;
    }

    public void changeCollision()
    {
        isCollidesInFirstWorld = !isCollidesInFirstWorld;
        gameObject.GetComponent<Collider2D>().enabled = isCollidesInFirstWorld;
    }
}
