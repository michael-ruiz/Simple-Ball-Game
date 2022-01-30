using UnityEngine;

public class Generation : MonoBehaviour
{
    // Define script variables
    public static int NUM_PICKUP = 8;
    public GameObject ballPrefab;
    public GameObject capsulePrefab;
    public GameObject cubePrefab;
    private GameObject _pickupObject;

    // Start is called before the first frame update
    void Start()
    {
        // Coordonates in play area for pickup item placement
        int[][] pos = new int[8][];
        pos[0] = new int[] {-20, 6};
        pos[1] = new int[] {-26, 0};
        pos[2] = new int[] {-20, -6};
        pos[3] = new int[] {-14, 0};
        pos[4] = new int[] {-20, 26};
        pos[5] = new int[] {-26, 20};
        pos[6] = new int[] {-14, 20};
        pos[7] = new int[] {-8, 0};

        for (int i = 0; i < NUM_PICKUP; i++) // 8 object placed (said in handout)
        {
            /*
             * objNum is to choose which Prefab will be used
             * 0 -> Ball
             * 1 -> Capsule
             * 2 -> Cube
             */
            int objNum = Random.Range(0, 3);

            switch (objNum)
            {
                case 0: // Place ball
                    PlacePickup(ballPrefab, pos[i]);
                    break;

                case 1: // Place capsule
                    PlacePickup(capsulePrefab, pos[i]);
                    break;

                case 2: // Place cube
                    PlacePickup(cubePrefab, pos[i]);
                    break;

                default:
                    // Do nothing
                    break;
            }
        }
    }

    // Function Places given prefab in a 1 of the preset locations
    void PlacePickup(GameObject prefab, int[] posArray)
    {
        Vector3 pos = new Vector3(posArray[0], 0, posArray[1]);

        _pickupObject = Instantiate(prefab);
        _pickupObject.transform.position = pos;
    }
}
