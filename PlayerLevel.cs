using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class PlayerLevel : MonoBehaviour
{
    [SerializeField] private Image _filledBar;
    [SerializeField] private TMP_Text _levelText;

    [SerializeField] private float _lerpSpeed;

    private void Start()
    {
        PlayerStats.OnScoreValueChanged += UpdatePlayerlevel;
    }

    public void UpdatePlayerlevel()
    {
        _levelText.text = PlayerStats.Instance.GetPlayerLevel().ToString();
        StartCoroutine(LerpBar());
    }

    private IEnumerator LerpBar()
    {
        for (float i = 0; i < 1; i+=Time.deltaTime)
        {
            _filledBar.fillAmount = Mathf.Lerp(_filledBar.fillAmount, PlayerStats.Instance.GetPlayerExp() / PlayerStats.Instance.GetCurrentExpBorder(), _lerpSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private void OnDestroy()
    {
        PlayerStats.OnScoreValueChanged -= UpdatePlayerlevel;
    }
}
