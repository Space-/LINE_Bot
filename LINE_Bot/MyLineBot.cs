﻿using isRock.LineBot;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINE_Bot
{
    public class MyLineBot
    {
        private readonly string _adminUserId;
        private readonly string _receiveMsgUserId;
        private static string _token;
        private static Bot Bot { get; set; }

        public MyLineBot()
        {
            _token = "ufFSRRG5kRRWF7cWQfIXj5dbVHda0mwH8x5vS1OSHxWfCfqXNwvHMqfgXUFyR4Bjt8ACWpSoJwqyj+y0QAy/YB4mrF9+exiJO3YRlCewXgdk6L65H2YgBvNpHPH1ZRqkw7rmqdis2Bh6SEbWaF7X8wdB04t89/1O/w1cDnyilFU=";
            _adminUserId = "U89e2dae55874fe65fd11d313b89f0a00";
            _receiveMsgUserId = _adminUserId;
            Bot = new Bot(_token);
        }

        public void PushMessage(string message)
        {
            Bot.PushMessage(_receiveMsgUserId, message);
        }

        public void PushMessage(int packageId, int stickerId)
        {
            Bot.PushMessage(_receiveMsgUserId, 1, 2);
        }

        public void PushMessage(Uri imgUri)
        {
            Bot.PushMessage(_receiveMsgUserId, imgUri);
        }

        public void PushMessage(ButtonsTemplate buttonsTemplate)
        {
            Bot.PushMessage(_receiveMsgUserId, buttonsTemplate);
        }

        public ButtonsTemplate CreateSampleButtonsTemplate()
        {
            return new ButtonsTemplate
            {
                thumbnailImageUrl = new Uri("https://cff2.earth.com/uploads/2019/09/03150152/Fast-fashion-has-an-enormous-carbon-footprint-730x410.jpg"),
                text = "請問你想買哪一類的服飾?",
                title = "Question",
                actions = CreateSampleTemplateActions(),
                //                altText = "您目前的裝置不支援TemplateMessage，想看😙? 無法顯示啦~🤗"
            };
        }

        public List<TemplateActionBase> CreateSampleTemplateActions()
        {
            return new List<TemplateActionBase>()
            {
                new MessageAction {label = "男裝", text = "man"},
                new MessageAction {label = "女裝", text = "woman"},
                new MessageAction {label = "童裝", text = "children"},
            };
        }

        public ConfirmTemplate CreateSampleConfirmTemplate()
        {
            return new ConfirmTemplate()
            {
                text = "請問你想選擇的是...?",
                actions = CreateSampleConfirmActions(),
                altText = "您目前的裝置不支援 ConfirmTemplate，想看😙? 無法顯示啦~🤗"
            };
        }

        private List<TemplateActionBase> CreateSampleConfirmActions()
        {
            var confirmActions = CreateSampleTemplateActions();
            var lastIndex = confirmActions.Count - 1;
            confirmActions.RemoveAt(lastIndex);

            return confirmActions;
        }

        public void PushMessage(ConfirmTemplate confirmTemplate)
        {
            Bot.PushMessage(_receiveMsgUserId, confirmTemplate);
        }

        public TemplateMessageBase CreateSampleTemplate(TemplateType templateType)
        {
            var templateMessages = new Dictionary<TemplateType, TemplateMessageBase>()
            {
                {TemplateType.ButtonsTemplate, CreateSampleButtonsTemplate()},
                {TemplateType.ConfirmTemplate, CreateSampleConfirmTemplate()}
            };

            return templateMessages[templateType];
        }
    }
}