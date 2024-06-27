using UnityEngine;

public class CreateObjectWithMaterial : MonoBehaviour
{
    public Material material;
    public GameObject prefab;

    void Start()
    {
        // GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject cube = Instantiate(prefab, new Vector3(0f, 5f, 0f), Quaternion.identity);
        Renderer renderer = cube.GetComponent<Renderer>();
        renderer.material = material;

        // if (renderer != null)
        // {
        //     renderer.material = material;
        // }
    }
}