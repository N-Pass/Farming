using UnityEngine;

public class MainMenuFallingObjects : MonoBehaviour
{
    public float minFallSpeed = 2f, maxFallSpeed = 5f, minRotationSpeed = -360f, maxRotationSpeed = 360f;
    
    private float fallSpeed, rotationSpeed;
    private float rotationValue;

    public float destroyHeight = -6f;

    private void Start()
    {
        fallSpeed = Random.Range(minFallSpeed, maxFallSpeed);
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
    }

    private void Update()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        rotationValue += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationValue);

        if(transform.position.y < destroyHeight)
        {
            Destroy(gameObject);
        }
    }
}
