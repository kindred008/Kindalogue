using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace Kindred.Kindalogue.Runtime
{
    public class XMLReader : MonoBehaviour
    {
        private void Start()
        {
            var convo = ReadDialogueFile("TestDialogue");

            foreach (var dialogue in convo.Dialogues)
            {
                var dialogueActor = dialogue.Actor;
                Debug.Log(string.IsNullOrEmpty(dialogueActor) ? convo.DefaultActor : dialogueActor);
            }
        }

        public Conversation ReadDialogueFile(string fileName)
        {
            TextAsset xmlFile = Resources.Load<TextAsset>(fileName);

            if (xmlFile == null)
            {
                throw new Exception("Dialogue file not found");
            }

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlFile.text);

            XmlNode defaultActorNode = xmlDocument.SelectSingleNode("Conversation/defaultActor");
            var defaultActor = defaultActorNode.InnerText.Trim();

            XmlNodeList dialogueNodes = xmlDocument.SelectNodes("Conversation/Dialogue");
            var dialogues = CreateDialogueArray(dialogueNodes);

            Conversation conversation = new Conversation
                (
                    defaultActor: defaultActor,
                    dialogues: dialogues
                );

            return conversation;
        }

        private Dialogue[] CreateDialogueArray(XmlNodeList dialogueNodes)
        {
            List<Dialogue> dialogues = new List<Dialogue>();

            foreach (XmlNode dialogueNode in dialogueNodes)
            {
                var actor = dialogueNode.SelectSingleNode("Actor").InnerText;

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
