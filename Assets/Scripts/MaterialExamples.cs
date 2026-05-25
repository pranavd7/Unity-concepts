using UnityEngine;

public class MaterialExamples : MonoBehaviour
{
    [SerializeField] Renderer renderer;
    private static readonly int _ColorID = Shader.PropertyToID("_Color");

    private Texture textureInstance;

    private void Examples()
    {
        renderer.material.SetFloat("_PropertyName", 0.5f);
        renderer.material.SetColor("_ColorName", Color.red);
        renderer.material.SetTexture("_TexName", textureInstance);
        renderer.material.SetVector("_VectorName", new Vector4(1, 0, 0, 1));

        // Using a cached property ID
        renderer.material.SetColor(_ColorID, Color.red);

        // renderer.material - Accessing this automatically creates a unique instance (copy) of the material 
        // for that specific object. Changes will not affect other objects and will not persist after the game stops.

        // renderer.sharedMaterial - Modifies the actual material asset. Every object using this material will change, 
        // and these changes persist even after you exit Play Mode in the Editor.

        MaterialPropertyBlock propBlock = new MaterialPropertyBlock();

        // This avoids creating hundreds of material instances, which would break GPU Batching
        // Get current state, modify, and apply
        renderer.GetPropertyBlock(propBlock);
        propBlock.SetColor("_BaseColor", Color.blue);
        renderer.SetPropertyBlock(propBlock);
    }
}