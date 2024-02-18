using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class object_portal : MonoBehaviour
{
    public Transform otheportal; // 다른 포탈을 지정하기 위한 변수
    private static bool isTeleporting = false; // 정적 변수로 변경

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isTeleporting) // 플레이어가 포탈에 물리적 충돌하고 현재 텔레포트 중이 아닐 때
        {
            isTeleporting = true;
            Teleport(collision.transform);
        }
    }

    private void Teleport(Transform target)
    {
        // 플레이어의 상대적인 Y 좌표를 계산
        float playerY = target.position.y - transform.position.y;

        target.position = new Vector3(otheportal.position.x, otheportal.position.y + playerY, otheportal.position.z);

        StartCoroutine(ResetTeleportFlag());
    }

    private System.Collections.IEnumerator ResetTeleportFlag()
    {
        yield return new WaitForSeconds(0.5f); // 텔레포트 후 잠시 대기 (필요에 따라 조절)
        isTeleporting = false;
    }
}