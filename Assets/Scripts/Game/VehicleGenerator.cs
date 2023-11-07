using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VehicleGenerator : MonoBehaviour
{
    public static VehicleGenerator instance;
    public List<GameObject> Vehicles = new List<GameObject>();
    private float time_to_create = 2f;
    private float actual_time = 0f;
    private float limitSuperior;
    private float limitInferior;
    public List<GameObject> actual_vehicles = new List<GameObject>();

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        SetMinMax();
    }

    // Update is called once per frame
    void Update()
    {
        actual_time += Time.deltaTime;
        if (time_to_create <= actual_time)
        {
            GameObject vehicle = Instantiate(Vehicles[Random.Range(0, Vehicles.Count)],
            new Vector3(transform.position.x, Random.Range(limitInferior, limitSuperior), 0f), Quaternion.identity);
            vehicle.GetComponent<Rigidbody2D>().velocity = new Vector2(-2f, 0);
            actual_time = 0f;
            actual_vehicles.Add(vehicle);
        }
    }

    void SetMinMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        limitInferior = -(bounds.y * 0.9f);
        limitSuperior = (bounds.y * 0.9f);
    }

    public void ManageVehicle(VehicleController vehicle_script, PlayerMovement player_script = null)
    {
        if (player_script == null)
        {
            Destroy(vehicle_script.gameObject);
            return;
        }
        if (vehicle_script.frame == 3)
        {
            SceneManager.LoadScene("GameOver");
            return;
        }
        int lives = player_script.player_lives;
        int live_changer = vehicle_script.lifeChanges;
        lives += live_changer;
        print(lives);
        if (lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        player_script.player_lives = lives;
        Destroy(vehicle_script.gameObject);
    }


}
