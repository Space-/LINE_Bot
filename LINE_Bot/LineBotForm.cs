﻿using System;
using System.Windows.Forms;
using isRock.LineBot;

namespace LINE_Bot
{
    public partial class LineBotForm : Form
    {
        private MyLineBot _lineBot;

        public LineBotForm()
        {
            InitializeComponent();
            CreateBot();
        }

        private void Btn_Send_Text_Click(object sender, EventArgs e)
        {
            _lineBot.PushMessage("Hello handsome man!");
            _lineBot.PushMessage("Good~");
        }

        private void Btn_Send_Emoticon_Click(object sender, EventArgs e)
        {
            _lineBot.PushMessage(1, 2);
        }

        private void Btn_Send_Image_Click(object sender, EventArgs e)
        {
            string imgUrl = TextBox_Image_Url.Text;
            var imgUri = new Uri(imgUrl);

            _lineBot.PushMessage(imgUri);
        }

        private void CreateBot()
        {
            _lineBot = new MyLineBot();
        }

        private void Send_Button_Template_Click(object sender, EventArgs e)
        {
            var buttonsTemplate = _lineBot.CreateSampleTemplate(TemplateType.ButtonsTemplate);

            _lineBot.PushMessage((ButtonsTemplate)buttonsTemplate);
        }

        private void Send_Confirm_Template_Click(object sender, EventArgs e)
        {
            var confirmTemplate = _lineBot.CreateSampleTemplate(TemplateType.ConfirmTemplate);
            _lineBot.PushMessage((ConfirmTemplate)confirmTemplate);
        }

        private void Send_Carousel_Template_Click(object sender, EventArgs e)
        {
            var carouselTemplate = _lineBot.CreateSampleTemplate(TemplateType.CarouselTemplate);
            _lineBot.PushMessage((CarouselTemplate)carouselTemplate);
        }

        private void Send_Image_Carousel_Template_Click(object sender, EventArgs e)
        {
            var imageCarouselTemplate = _lineBot.CreateSampleTemplate(TemplateType.ImageCarouselTemplate);
            _lineBot.PushMessage((ImageCarouselTemplate)imageCarouselTemplate);
        }
    }
}