using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public GameObject goText;
    public static GameObject cam;
    public static GameObject pPlayer;
    public static GameObject pGotext;
    static bool isShaked = false;

    private void Start() {
        cam = this.gameObject;
        pPlayer = player;
        pGotext = goText;
    }

    void Update() {

        if(!isShaked) {
            Vector3 playerPos = this.player.transform.position;
        
            transform.position = new Vector3(playerPos.x+2, playerPos.y+3, transform.position.z);
        }
        
    }
    public static void Shake(MonoBehaviour i_behaviour, float duration, float magnitude)
    {
        i_behaviour.StartCoroutine(DoShake(duration, magnitude, cam));
    }

    private static IEnumerator DoShake(float duration, float magnitude, GameObject cam) {

        isShaked = true;

        var pos = cam.transform.localPosition;

        var elapsed = 0f;

        while ( elapsed < duration )
        {
            var x = pos.x + Random.Range( -1f, 1f ) * magnitude;
            var y = pos.y + Random.Range( -1f, 1f ) * magnitude;

            cam.transform.localPosition = new Vector3( x, y, pos.z );

            elapsed += Time.deltaTime;

            yield return null;
        }

        cam.transform.localPosition = pos;
        pGotext.SetActive(true);
        Destroy(pPlayer);
    }

}
