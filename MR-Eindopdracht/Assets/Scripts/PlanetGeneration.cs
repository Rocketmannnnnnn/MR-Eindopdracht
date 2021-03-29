using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGeneration : MonoBehaviour
{

    // need to be generated
    public GameObject[] objects;

    public float size;
    public float value;
    public float noiseFactor;
    public float objectFactor;
    public float indexFactor;
    public float scaleFactor;

    // Start is called before the first frame update
    void Start()
    {

        this.Shuffle(new System.Random(), this.objects);

        for (float x = 0; x < this.size; x++)
            for (float y = 0; y < this.size; y++)
                for (float z = 0; z < this.size; z++)
                {

                    float perlin = this.perlin3D(x * this.noiseFactor, y * this.noiseFactor, z * this.noiseFactor);

                    if (perlin >= this.value)
                        this.createObject(x, y, z, perlin);
                }
    }

    private void createObject(float x, float y, float z, float perlin)
    {

        Vector3 position = new Vector3(x - (this.size / 2), y - (this.size / 2), z - (this.size / 2));
        position *= (2 * this.objectFactor);

        float objectIndex = ((perlin - this.value) * this.indexFactor) % 1;
        objectIndex *= this.objects.Length;

        float objectScale = ((perlin - this.value) * this.indexFactor) % 2;
        objectScale = Mathf.Pow(objectScale, this.scaleFactor) + 0.5f;

        GameObject obj = Instantiate(this.objects[Mathf.RoundToInt(objectIndex)], position, new Quaternion());
        obj.transform.localScale *= objectScale;
        
        Debug.Log("Object created! || XYZ: " + x + ", " + y + ", " + z + " || index: " + objectIndex + " || scale: " + objectScale);
    } 

    private void Shuffle(System.Random rng, GameObject[] array)
    {

        int n = array.Length;
        while (n > 1)
        {

            int k = rng.Next(n--);
            GameObject temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
    }

    private float perlin3D(float x, float y, float z)
    {

        // all permutations
        float xy = Mathf.PerlinNoise(x, y);
        float yz = Mathf.PerlinNoise(y, z);
        float xz = Mathf.PerlinNoise(x, z);

        // all reverses
        float yx = Mathf.PerlinNoise(y, x);
        float zy = Mathf.PerlinNoise(z, y);
        float zx = Mathf.PerlinNoise(z, x);

        // average
        float xyz = (xy + yz + xz + yx + zy + zx);

        return xyz / 6;
    }
}
