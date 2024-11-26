using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TitleTarget : MonoBehaviour
{
    [SerializeField] private Image cursorImage; //カーソルの画像
    [SerializeField] private Vector2 offset = new Vector2(10f, -10f);// マウス位置からのオフセット

    // カーソルの移動範囲（スクリーン座標で指定）
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    void Start()
    {
        // カーソルを非表示にする
        Cursor.visible = false;
    }
    void Update()
    {
        // マウスの位置を取得し、オフセットを適用
        Vector3 mousePosition = Input.mousePosition;

        // XとYの位置に制限をかける
        mousePosition.x = Mathf.Clamp(mousePosition.x, minX, maxX);
        mousePosition.y = Mathf.Clamp(mousePosition.y, minY, maxY);

        // カーソル画像の位置を更新
        cursorImage.transform.position = mousePosition + (Vector3)offset;

        // 左クリックを検出
        if (Input.GetMouseButtonDown(0))
        {
            HandleClick(mousePosition);
        }
    }

    // クリック時の処理を記述
    private void HandleClick(Vector3 mousePosition)
    {
        Debug.Log("クリックしました！ マウス位置: " + mousePosition);

        // Raycastを使ってクリック対象を取得
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit.collider != null)
        {
            Debug.Log("クリック対象: " + hit.collider.gameObject.name);

            // 対象のオブジェクトに特定の処理を追加したい場合
            if (hit.collider.CompareTag("Clickable"))
            {
                Debug.Log(hit.collider.gameObject.name + " をクリックしました！");
                // ここに処理を追加
            }
        }
    }

    void OnDestroy()
    {
        // スクリプトが削除されたときにカーソルを表示に戻す
        Cursor.visible = true;
    }
}
