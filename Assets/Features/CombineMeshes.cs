using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineMeshes : MonoBehaviour
{
  void Start()
      {
          // Get all mesh filters in children
          MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
          CombineInstance[] combine = new CombineInstance[meshFilters.Length];
  
          int i = 0;
          while (i < meshFilters.Length)
          {
              combine[i].mesh = meshFilters[i].sharedMesh;
              combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
              meshFilters[i].gameObject.SetActive(false);
              i++;
          }
  
          // Create a new mesh and assign it to the parent object
          MeshFilter parentMeshFilter = gameObject.AddComponent<MeshFilter>();
          parentMeshFilter.mesh = new Mesh();
          parentMeshFilter.mesh.CombineMeshes(combine);
  
          // Add a MeshRenderer if needed
          gameObject.AddComponent<MeshRenderer>();
  
          // Optionally set all child objects inactive
          foreach (MeshFilter mf in meshFilters)
          {
              mf.gameObject.SetActive(false);
          }
      }
}
