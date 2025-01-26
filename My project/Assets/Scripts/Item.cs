using UnityEngine;

public class Item : MonoBehaviour
{
    public enum InteractionType {   None, Examine   };
    public InteractionType type;
    
    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
