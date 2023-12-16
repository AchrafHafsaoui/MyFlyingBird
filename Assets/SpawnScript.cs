using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public bool update;
    public GameObject pipe;
    public GameObject smallCloud;
    public GameObject bigCloud;

    public float pipeSpawnRate=3;
    public float smallCloudSpawnRate=2;
    public float bigCloudSpawnRate=8;
    public float pipeHeightOffset=10;
    public float cloudHeightOffset=15;

    private float pipeTimer=0;
    private float smallCloudTimer=0;
    private float bigCloudTimer=0;
    private int numberOfPipes=0;
    private float reachedPipeSpawnRate=0;

    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if(smallCloudTimer<smallCloudSpawnRate)smallCloudTimer+=Time.deltaTime;
        else{
            Instantiate(smallCloud, new Vector3(transform.position.x, Random.Range(transform.position.y-cloudHeightOffset, transform.position.y+cloudHeightOffset), 0), transform.rotation);
            smallCloudTimer=0;
        } 
        if(bigCloudTimer<bigCloudSpawnRate)bigCloudTimer+=Time.deltaTime;
        else{
            Instantiate(bigCloud);
            bigCloudTimer=0;
        } 
        if(pipeTimer<pipeSpawnRate)pipeTimer+=Time.deltaTime;
        else{
            spawnPipe();
            pipeTimer=0;
        } 
    }

    void spawnPipe(){
        numberOfPipes++;
        float lowestPoint=transform.position.y-pipeHeightOffset;
        float highestPoint=transform.position.y+pipeHeightOffset;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        if(update){
            if(BirdScript.alive){
                if(!(reachedPipeSpawnRate==0)){
                    pipeSpawnRate=reachedPipeSpawnRate;
                    reachedPipeSpawnRate=0;
                }
                pipeSpawnRate*=0.98f;
            }
            else{
                reachedPipeSpawnRate=pipeSpawnRate;
                pipeSpawnRate=5;
            }
            PipeMoveScript.increaseSpeed(numberOfPipes);
        }
    }
}
