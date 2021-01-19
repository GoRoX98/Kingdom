using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    StructBuild Village = new StructBuild(10, 10, 20, 100, 50, 20, 50, 0);
    StructBuild Farm = new StructBuild(10, 10, 20, 100, 50, 20, 50, 0);
    StructBuild Mine = new StructBuild(10, 10, 20, 100, 50, 20, 50, 0);
    public int NumBuild;

    public StructBuild[] BuildingsNames;


    private void Start()
    {
        BuildingsNames = new StructBuild[] {Village, Farm, Mine};
    }

    public void NewBuild()
    {

    }
}
