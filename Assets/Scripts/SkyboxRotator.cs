using UnityEngine;

public class SkyboxRotator : MonoBehaviour
{
    [SerializeField] private float RotationPerSecond = 1;

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * RotationPerSecond);
    }

}