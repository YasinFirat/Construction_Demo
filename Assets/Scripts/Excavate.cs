using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Excavate : ConstructionGame
{
    private MeshController meshController;
    private ParticleSystem particleSystem;
    private ParticleSystemRenderer systemRenderer;
    RaycastHit[] hitAll;
    public float radius=.2f;
    public float distanceExcavate = 1;
    public LayerMask layerMask;

    private void Start()
    {
        particleSystem = gameManager.particleSystem;
        meshController = gameManager.meshController;
        systemRenderer = particleSystem.GetComponent<ParticleSystemRenderer>();
        systemRenderer.material = meshController.GetComponent<MeshRenderer>().material;
    }
    void Update()
    {
        hitAll = Physics.SphereCastAll(transform.position, radius, transform.TransformDirection(Vector3.down), distanceExcavate, layerMask);
        for (int i = 0; i < hitAll.Length; i++)
        {
            particleSystem.Play();
            particleSystem.transform.position = hitAll[i].point;
            meshController.ConstructionMesh(hitAll[i], transform.hasChanged);
        }
    }
}
