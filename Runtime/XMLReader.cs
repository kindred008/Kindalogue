using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace Kindred.Kindalogue.Runtime
{
    public class XMLReader
    {
        private string _dialogueRoot;
        private string _actorRoot;

        private ActorHelper _actorHelper;

        public XMLReader(string dialogueRoot, string actorRoot)
        {
            _dialogueRoot = dialogueRoot;
            _actorRoot = actorRoot;

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

            for (int i = 0; i < dialogueNodes.Count; i++)
            {
                var dialogueNode = dialogueNodes[i];

                // ID 
                XmlAttribute idAttribute = dialogueNode.Attributes["id"];

                if (idAttribute == null)
                {
                    throw new Exception("Dialogue's must have an id attribute.");
                }

                var id = idAttribute.Value;

                // Actor
                var actorName = dialogueNode.SelectSingleNode("Actor").InnerText;
                actorName = string.IsNullOrEmpty(actorName) ? defaultActor : actorName;

                var actor = _actorHelper.LoadActor($"{_actorRoot}/{actorName}");

                if (actor == null)
                {
                    throw new Exception("Actor asset not found");
                }

                // Emotion
                var emotion = dialogueNode.SelectSingleNode("Emotion")?.InnerText ?? "";

                // Dialogue Lines
                XmlNodeList lineNodes = dialogueNode.SelectNodes("Line");

                List<string> lines = new List<string>();
                foreach (XmlNode lineNode in lineNodes)
                {
                    var line = lineNode.InnerText.Trim();
                    lines.Add(line);
                }

                // Choices
                XmlNodeList choiceNodes = dialogueNode.SelectNodes("Choices/Choice");
                var choices = CreateChoicesArray(choiceNodes);

                // Goto
                XmlAttribute gotoAttribute = dialogueNode.Attributes["goto"];
                string gotoId;

                if (gotoAttribute == null && choices.Length == 0)
                {
                    gotoId = i < dialogueNodes.Count - 1 ? dialogueNodes[i + 1].Attributes["id"].Value : "";
                }
                else if (gotoAttribute == null && choices.Length > 0)
                {
                    gotoId = "";
                }
                else
                {
                    gotoId = gotoAttribute.Value;
                }

                // Create Dialogue
                Dialogue dialogue = new Dialogue
                    (
                        id: id,
                        gotoId: gotoId,
                        actor: actor,
                        emotion: emotion,
                        dialogueLines: lines.ToArray(),
                        choices: choices
                    );

                dialogues.Add(dialogue);
            }

            return dialogues.ToArray();
        }

        private Choice[] CreateChoicesArray(XmlNodeList choiceNodes)
        {
            List<Choice> choices = new List<Choice>();

            foreach (XmlNode choiceNode in choiceNodes)
            {
                // ID
                XmlAttribute idAttribute = choiceNode.Attributes["id"];

                if (idAttribute == null)
                {
                    throw new Exception("Choices must have an id attribute.");
                }

                var id = idAttribute.Value;

                // Goto
                XmlAttribute gotoAttribute = choiceNode.Attributes["goto"];

                string gotoId;

                if (gotoAttribute == null)
                {
                    gotoId = "";
                } else
                {
                    gotoId = gotoAttribute.Value;
                }

                // Choice text
                var choiceText = choiceNode.InnerText;

                // Create Choice
                Choice choice = new Choice
                    (
                        id: id,
                        gotoId: gotoId,
                        choiceText: choiceText
                    );

                choices.Add(choice);
            }

            return choices.ToArray();
        }
    }
}
