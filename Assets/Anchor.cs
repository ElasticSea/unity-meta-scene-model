using System;
using System.Collections;
using UnityEngine;

public class Anchor : MonoBehaviour
{
	[SerializeField] private Material material;
	
    private IEnumerator Start()
    {
        var _sceneAnchor = GetComponent<OVRSceneAnchor>();

        while (_sceneAnchor.Uuid == Guid.Empty) yield return null;

        OVRSemanticClassification semanticClassification;
        while (!TryGetComponent(out semanticClassification)) yield return null;

        var volume = GetComponent<OVRSceneVolume>();
        if (volume)
        {
            // Anchor is aligned from the top
            var bounds = new Bounds(volume.Offset - new Vector3(0, 0, volume.Dimensions.z/2), volume.Dimensions);

            var meshFilter = gameObject.AddComponent<MeshFilter>();
            meshFilter.sharedMesh = MeshUtils.CreateCubeMesh(bounds.center, bounds.size);

            var meshRenderer = gameObject.AddComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = material;
        }
            
        gameObject.name = $"{semanticClassification.Labels[0]}_{(ushort)_sceneAnchor.Space.Handle:X4}_{(volume ? "V" : "P")}";
    }
}