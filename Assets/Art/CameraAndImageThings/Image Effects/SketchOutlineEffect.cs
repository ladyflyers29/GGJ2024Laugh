using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Image Effects Ultra/SketchOutline", order = 1)]
public class SketchOutlineEffect : BaseEffect
{
    [SerializeField]
    private float colorSensitivity = 0.1f; 

    [SerializeField]
    private float colorStrength = 1.0f;

    [SerializeField]
    private float depthSensitivity = 0.1f;

    [SerializeField]
    private float depthStrength = 1.0f;

    [SerializeField]
    private float normalsSensitivity = 0.1f;

    [SerializeField]
    private float normalsStrength = 1.0f;

    [SerializeField]
    Texture2D displace;

    // Find the Outline shader source.
    public override void OnCreate()
    {
        baseMaterial = new Material(Resources.Load<Shader>("Shaders/Outline"));
    }

    public override void Render(RenderTexture src, RenderTexture dst)
    {
        baseMaterial.SetFloat("_ColorSensitivity", colorSensitivity);
        baseMaterial.SetFloat("_ColorStrength", colorStrength);
        baseMaterial.SetFloat("_DepthSensitivity", depthSensitivity);
        baseMaterial.SetFloat("_DepthStrength", depthStrength);
        baseMaterial.SetFloat("_NormalsSensitivity", normalsSensitivity);
        baseMaterial.SetFloat("_NormalsStrength", normalsStrength);
        baseMaterial.SetTexture("_Displace", displace);

        Camera.main.depthTextureMode = DepthTextureMode.Depth;
        Graphics.Blit(src, dst, baseMaterial);
    }
}
