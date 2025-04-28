using System.Collections.Generic;
using UnityEngine;

namespace Spawneur.Runtime
{
    public class SpawnQuad : MonoBehaviour
    {
        #region Publics

        

        #endregion


        #region Unity Api

        private void Start()
        {
            SpawnQuads();
        }

        private void Update()
        {
            
        }

        #endregion


        #region Utils

        

        #endregion


        #region Main Methode

        private void SpawnQuads()
        {
            for (int i = 0; i < _numQuads; i++)
            {
                GameObject quad = new GameObject("Quads_ " + i);
                MeshFilter meshFilter = quad.AddComponent<MeshFilter>();
                MeshRenderer meshRenderer = quad.AddComponent<MeshRenderer>();
                meshFilter.mesh = CreatQuadMesh();
                
                Material quadMaterial = new Material(Shader.Find("Unlit/Color"));
                quadMaterial.color = Color.black;
                _quads.Add(quad);
            }
        }

        private Mesh CreatQuadMesh()
        {
            Mesh mesh = new Mesh();
            Vector3[] vertices = new Vector3[4]
            {
                new Vector3(-0.5f, -0.5f, 0),
                new Vector3(0.5f, -0.5f, 0f),
                new Vector3(-0.5f, 0.5f, 0),
                new Vector3(0.5f, 0.5f,0)
            };

            int[] triangles = new int[6]
            {
                0, 2, 1,
                2, 3, 1
            };
            
            mesh.vertices = vertices;
            mesh.triangles = triangles;
            
            mesh.RecalculateNormals();
            return mesh;
        }

        #endregion
        
        
        #region Privates
        
        [SerializeField] private int _numQuads;
        [SerializeField] private Transform _spawnTransform;
        [SerializeField] private Vector2 _SpawnMinArea;
        [SerializeField] private Vector2 _SpawnMaxArea;
        
        private List<GameObject> _quads = new List<GameObject>();

        #endregion
    }
}
