using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 1f;
    public float lowPosY = -1f;

    public float holeSizeMin = 1f;
    public float holeSizeMax = 3f;  //ž�� ���� ������ ���� ũ��

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 4f;

    GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.Instance;
    }
    public Vector3 SetRandomPlace(Vector3 lastPos, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2;

        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0,-halfHoleSize);
        //localPosition�� �θ� �������� ��ġ�� ���, Position�� ���� ��ǥ(���� ��ǥ�� �����ϸ� �ǰڴ�)
        Vector3 placePosition = lastPos + new Vector3(widthPadding, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            gameManager.AddScore(1);
        }
    }
}
