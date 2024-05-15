using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Kindred.Kindalogue.Runtime
{
    public class DialogueUI : MonoBehaviour
    {
        [Header("UI Panels")]
        [SerializeField] private GameObject _dialoguePanel;
        [SerializeField] private GameObject _choicesPanel;

        [Header("UI Text")]
        [SerializeField] private TextMeshProUGUI _dialogueText;
        [SerializeField] private TextMeshProUGUI _actorText;

        [Header("UI Prefabs")]
        [SerializeField] private GameObject _choiceTextPrefab;

        [Header("Images")]
        [SerializeField] private Image _actorImage;

        private void OnEnable()
        {
            DialogueManager.DialogueUpdated.AddListener(UpdateUI);
        }

        private void OnDisable()
        {
            DialogueManager.DialogueUpdated.RemoveListener(UpdateUI);
        }

        private void UpdateUI(Dialogue newDialogue)
        {
            foreach(Transform choiceTransform in _choicesPanel.transform)
            {
                Destroy(choiceTransform.gameObject);
            }

            _choicesPanel.SetActive(false);
            _actorImage.enabled = false;

            if (newDialogue == null)
            {
                _dialoguePanel.SetActive(false);
                return;
            }

            _dialoguePanel.SetActive(true);

            _actorText.text = newDialogue.Actor.ActorName;

            var actorImage = newDialogue.Actor.GetActorSprite(newDialogue.Emotion);

            if (actorImage != null)
            {
                _actorImage.sprite = actorImage;
                _actorImage.enabled = true;
            }

            StringBuilder sb = new StringBuilder();
            foreach (var line in newDialogue.DialogueLines)
            {
                sb.AppendLine(line);
            }
            _dialogueText.text = sb.ToString();

            if (newDialogue.Choices.Length > 0)
            {
                _choicesPanel.SetActive(true);

                for (int i = 0; i < newDialogue.Choices.Length; i++)
                {
                    var choice = newDialogue.Choices[i];
                    var choiceObject = Instantiate(_choiceTextPrefab, _choicesPanel.transform);
                    var choiceText = choiceObject.GetComponent<TextMeshProUGUI>();

                    choiceText.text = $"{i+1}. {choice}";
                }
            }
        }
    }
}