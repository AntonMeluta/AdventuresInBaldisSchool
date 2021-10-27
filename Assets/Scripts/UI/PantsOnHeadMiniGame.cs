using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PantsOnHeadMiniGame : MonoBehaviour
{
    public Button leftSectionArows;
    public Button rightSectionArows;

    public RectTransform left;
    public RectTransform right;
    public RectTransform pants;

    private GameManager gameManager;

    private float deltaLerp;
    private float encreaseDelta = 0.2f;

    [Inject]
    private void ConstructorLike(GameManager gm)
    {
        gameManager = gm;
    }

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
        Vector2 pantsTarget = new Vector2(-10, 410);
        Vector2 pantsStartPos = pants.anchoredPosition;

        while (deltaLerp > 0)
        {
            if (deltaLerp < 1)
                deltaLerp += Time.deltaTime * 2;

            left.anchoredPosition =
                Vector2.Lerp(leftTargetSection, Vector2.zero, deltaLerp);
            right.anchoredPosition =
                Vector2.Lerp(rightTargetSection, Vector2.zero, deltaLerp);
            pants.anchoredPosition =
                Vector2.Lerp(pantsTarget, pantsStartPos, deltaLerp);

            yield return null;
        }

        gameManager.UpdateGameState(GameManager.GameState.game);
        EventsBroker.RestartHuntingForPlayer();
    }
    
}
