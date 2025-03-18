using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class ScoreCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI current;
    [SerializeField] private TextMeshProUGUI toUpdate;
    [SerializeField] private Transform scorePointsContainer;
    [SerializeField] private float duration;

    private float containerInitPosition;
    private float moveAmount;

    private void Start()
    {
        Canvas.ForceUpdateCanvases();
        current.SetText("0");
        toUpdate.SetText("0");
        containerInitPosition = scorePointsContainer.localPosition.y;
        moveAmount = current.rectTransform.rect.height;
    }

    public void UpdateScore(int score)
    {
        toUpdate.SetText($"{score}");
        scorePointsContainer.DOLocalMoveY(containerInitPosition + moveAmount,duration);
    }

}
