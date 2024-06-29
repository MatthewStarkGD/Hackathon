using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildInfo : MonoBehaviour
{
    private BuildBlock bindedBuildBlock;

    public void SetBuildBlock(BuildBlock newBindedBlock)
    { 
        bindedBuildBlock = newBindedBlock;
    }

    public BuildBlock GetBuildBlock()
    { 
        return bindedBuildBlock;
    }    
}
