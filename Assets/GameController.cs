using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject cube;
    public float currentSpeed = 0;
    public float currentDistance = 0;
    public Vector3 spawnPoint = new Vector3(0, 0, 0);
    public float timeBetweenGenerations = 0;
    public Button changeVariablesButton;
    public TMP_InputField timeText;
    public TMP_InputField distanceText;
    public TMP_InputField speedText;
    public GameObject field;

    public void GenerateCube()
    {
        GameObject cubeGameObject = Instantiate(cube);
        cubeGameObject.transform.SetParent(field.transform);
        cubeGameObject.transform.position = spawnPoint;
        CubeController cubeController = cubeGameObject.GetComponent<CubeController>();
        cubeController.distance = currentDistance;
        cubeController.spawnPoint = spawnPoint;
        cubeController.speed = currentSpeed;
    }
    public void ChangeVariables()
    {
        if (float.TryParse(timeText.text, out _) == true && float.TryParse(distanceText.text, out _) == true && float.TryParse(speedText.text, out _))
        {
            currentSpeed = float.Parse(speedText.text);
            currentDistance = float.Parse(distanceText.text);
            timeBetweenGenerations = float.Parse(timeText.text);
            CancelInvoke();
            InvokeRepeating(nameof(GenerateCube), 0.0f, timeBetweenGenerations);
        }
    }
    private void Start()
    {
        changeVariablesButton.onClick.AddListener(ChangeVariables);
        timeText.text = timeBetweenGenerations.ToString();
        distanceText.text = currentDistance.ToString();
        speedText.text = currentSpeed.ToString();
        InvokeRepeating(nameof(GenerateCube), 0.0f, timeBetweenGenerations);
    }

}
