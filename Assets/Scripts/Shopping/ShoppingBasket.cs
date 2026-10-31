using UnityEngine;

public class ShoppingBasket : MonoBehaviour
{

    public Transform granny;
    public float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, granny.position, speed * Time.deltaTime);
    }
}
