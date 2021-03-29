using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGeneration : MonoBehaviour
{

    // need to be generated
    public GameObject[] asteriods;
    public GameObject[] planets;
    public GameObject comet;

    // x, y, z perlin noise generation
    public float grid;
    public float value;
    public float noise;

    // distance and scale
    public float positionFactor;
    public float scaleFactor;

    // percentages
    public int asteroidPercentage;
    public int planetPercentage;

    // private
    private System.Random random;

    // Start is called before the first frame update
    void Start()
    {

        this.random = new System.Random();

        this.Shuffle(this.random, this.asteriods);
        this.Shuffle(this.random, this.planets);

        for (float x = 0; x < this.grid; x++)
            for (float y = 0; y < this.grid; y++)
                for (float z = 0; z < this.grid; z++)
                    if (this.perlin3D(x * this.noise, y * this.noise, z * this.noise) >= this.value)
                        this.createObject(x, y, z);
    }

    private void createObject(float x, float y, float z)
    {

        Debug.Log("Object placed");

        // calculate the position of the object
        Vector3 position = new Vector3(x - (this.grid / 2), y - (this.grid / 2), z - (this.grid / 2));
                position *= (2 * this.positionFactor);

        // creates a scale for the object
        float objectScale = Mathf.Pow(this.random.Next(100) / 50.0f, this.scaleFactor) + 0.5f;

        // if the object is to close to another, it won't be placed.
        if (Physics.CheckSphere(position, objectScale * 50))
            return;

        // places the object with a picked GameObject
        GameObject placed = Instantiate(this.pickObject(), position, new Quaternion());
        
        // adds scale to the object
        placed.transform.localScale *= objectScale;

       
    }

    private GameObject pickObject()
    {

        if (this.asteroidPercentage >= random.Next(100))
            return this.asteriods[this.random.Next(this.asteriods.Length)];
        
        if (this.planetPercentage >= random.Next(100))
            return this.planets[this.random.Next(this.planets.Length)];

        return this.comet;
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
}
