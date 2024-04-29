using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour {

	public GameObject wordPrefab;
	public Transform wordCanvas;
	public Vector3 Location = new Vector3(-2.687f, 1.76f, -2f);

    public GameObject planePrefab;

    public WordDisplay SpawnWord ()
	{
        Vector3 localDirection = wordCanvas.forward;
        Vector3 localPosition = new Vector3(9f, 0f, Random.Range(-100, 100));
        Vector3 worldPosition = wordCanvas.TransformPoint(localPosition);

        //Vector3 randomPosition = new Vector3(0,0,0);

        GameObject wordObj = Instantiate(wordPrefab, worldPosition, Quaternion.Euler(0, 64f, 0), wordCanvas);
        //GameObject wordObj = Instantiate(wordPrefab, Location, Quaternion.Euler(0, 64f, 0), wordCanvas);
        GameObject planeObj = Instantiate(planePrefab, worldPosition, Quaternion.Euler(0, 64f, 0), wordCanvas);

        WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();

		return wordDisplay;
	}



}
