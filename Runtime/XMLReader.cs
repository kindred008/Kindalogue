using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace Kindred.Kindalogue.Runtime
{
    public class XMLReader : MonoBehaviour
    {
        [SerializeField] private string _dialogueRoot = "Dialogue";
        [SerializeField] private string _actorRoot = "ScriptableObjects/Actors";

        private ActorHelper _actorHelper;

        private void Awake()
        {
            _actorHelper = new ActorHelper();
        }

        public Conversation ReadDialogueFile(string fileName)
        {
            TextAsset xmlFile = Resources.Load<TextAsset>($"{_dialogueRoot}/{fileName}");

            if (xmlFile == null)
            {
                throw new Exception("Dialogue file not found");
            }

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlFile.text);

            XmlNode defaultActorNode = xmlDocument.SelectSingleNode("Conversation/defaultActor");
            var defaultActor = defaultActorNode.InnerText.Trim();

            XmlNodeList dialogueNodes = xmlDocument.SelectNodes("Conversation/Dialogue");
            var dialogues = CreateDialogueArray(dialogueNodes, defaultActor);

            Conversation conversation = new Conversation
                (
                    dialogues: dialogues
                );

            _actorHelper.ClearCache();

            return conversation;
        }

        private Dialogue[] CreateDialogueArray(XmlNodeList dialogueNodes, string defaultActor)
        {
            List<Dialogue> dialogues = new List<Dialogue>();

            foreach (XmlNode dialogueNode in dialogueNodes)
            {
                var actorName = dialogueNode.SelectSingleNode("Actor").InnerText;
                actorName = string.IsNullOrEmpty(actorName) ? defaultActor : actorName;

                var actor = _actorHelper.LoadActor($"{_actorRoot}/{actorName}");

                if (actor == null)
                {
                    throw new Exception("Actor asset not found");
                }

                XmlNodeList lineNodes = dialogueNode.SelectNodes("Line");

                List<String> lines = new List<String>();
                foreach (XmlNode lineNode in lineNodes)
                {
                    var line = lineNode.InnerText.Trim();
                    lines.Add(line);
                }

                Dialogue dialogue = new Dialogue
                    (
                        actor: actor,
                        dialogueLines: lines.ToArray()
                    );

                dialogues.Add(dialogue);
            }

            return dialogues.ToArray();
        }
    }
}
