using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PantsOnHeadMiniGame : MonoBehaviour
{
    public Button leftSectionArows;
    public Button rightSectionArows;

    public RectTransform left;
    public RectTransform right;

    float deltaLerp;
    float encreaseDelta = 0.2f;

    private void Awake()
    {
        leftSectionArows.onClick.AddListener(TapAtSection);
        rightSectionArows.onClick.AddListener(TapAtSection);
    }

    private void OnEnable()
    {
        deltaLerp = 1;
        StartCoroutine(DefaultArrowsMove());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
   
    private void TapAtSection()
    {
        deltaLerp -= encreaseDelta;
    }

    IEnumerator DefaultArrowsMove()
    {
        Vector2 leftTargetSection = new Vector2(150, 0);
        Vector2 rightTargetSection = new Vector2(-150, 0);

        while (deltaLerp > 0)
        {
            if (deltaLerp < 1)
                deltaLerp += Time.deltaTime;

            left.anchoredPosition =
                Vector2.Lerp(leftTargetSection, Vector2.zero, deltaLerp);
            right.anchoredPosition =
                Vector2.Lerp(rightTargetSection, Vector2.zero, deltaLerp);

            yield return null;
        }

        GameManager.Instance.UpdateGameState(GameManager.GameState.game);
    }
    
}
