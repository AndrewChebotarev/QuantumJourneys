namespace QuantumJourneys.Pages.Game.HelpEssence
{
    public class GenaralPageFunctions
    {
        public void SetNewLocationStateGameplay(string newLocationState)
        {
            LocationStateGameplay.locationStateGameplay = newLocationState;
        }

        
        public void AudioOff(Button audioBtn)
        {
            audioBtn.Text = "🔇";
            WorkingAudioPlayer.audioPlayer.Volume = 0;
#if DEBUG
            MyLogger.logger.LogInformation("Звук отключен.");
#endif
        }
        public void AudioOn(Button audioBtn)
        {
            audioBtn.Text = "🔊";
            WorkingAudioPlayer.audioPlayer.Volume = WorkingAudioPlayer.valume;
#if DEBUG
            MyLogger.logger.LogInformation("Звук включен.");
#endif
        }

        public Color ChoiceColorForTitle(string color)
        {
            if (color == "White") return Colors.White;
            else if (color == "Blue") return Colors.Blue;
            else if (color == "Brown") return Colors.Brown;
            else if (color == "Green") return Colors.Green;
            else return Colors.White;
        }


        public string GetTitleText(string text) => text.Substring(1, text.IndexOf(",") - 1);
        public string GetTitleColor(string text) => text.Substring(text.IndexOf(",") + 1, (text.IndexOf(")") - text.IndexOf(",")) - 1);
        public string GetMainText(string text) => text.Remove(0, text.IndexOf(")") + 1);


        public string ChoiceMainCharacterTitleColor(СharacterСharacteristics сharacterСharacteristics)
        {
            if (сharacterСharacteristics.eyeColor == EyeColorEnum.Blue) return "Blue";
            else if (сharacterСharacteristics.eyeColor == EyeColorEnum.Brown) return "Brown";
            else if (сharacterСharacteristics.eyeColor == EyeColorEnum.Green) return "Green";
            else return "Blue";
        }

        public async Task NewScrollPosition(ScrollView ScrollArea, View view)
        {
#if DEBUG
            MyLogger.logger.LogInformation("Изменение позиции скролла.");
#endif
            await ScrollArea.ScrollToAsync(view, ScrollToPosition.End, true);
        }

        public void AddFromListBoxView(List<BoxView> boxViews, BoxView StartLine, BoxView EndLine)
        {
            boxViews.Add(StartLine);
            boxViews.Add(EndLine);
        }


        public BoxView CreateWhiteLine(VerticalStackLayout verticalStackLayout,int topMargin, int backMargin)
        {
#if DEBUG
            MyLogger.logger.LogInformation("Создание белой линии.");
#endif
            BoxView boxView = new BoxView
            {
                BackgroundColor = Colors.White,
                VerticalOptions = LayoutOptions.Start,
                HeightRequest = 5,
                Margin = new Thickness(0, topMargin, 0, backMargin)
            };

            AddToLayoutView(verticalStackLayout, boxView);

            return boxView;
        }

        public void CloseKeyboard_Clicked(Entry entry)
        {
            entry.IsEnabled = false;
            entry.IsEnabled = true;
        }


        public void SetTitleForLabel(FormattedString formattedString, string title, string color)
        {
            formattedString.Spans.Add(new Span
            {
                Text = title + ": ",
                TextColor = ChoiceColorForTitle(color),
                FontAttributes = FontAttributes.Bold
            });
        }
        public void SetTextForLabel(FormattedString formattedString, string text)
        {
            formattedString.Spans.Add(new Span
            {
                Text = text,
            });
        }

        public async Task<Label> CreateNewLabel(VerticalStackLayout verticalStackLayout, string text, WalkingAnimation walkingAnimation)
        {
#if DEBUG
            MyLogger.logger.LogInformation("Создание нового текста.");
#endif
            Label label = CreateLabelWithTitle(verticalStackLayout, GetTitleText(text), GetTitleColor(text), GetMainText(text));
            await walkingAnimation.AnimationLabel(label);
            return label;
        }

        public Label CreateLabel(VerticalStackLayout verticalStackLayout, string text)
        {
            Label label = new()
            {
                Opacity = 0,
                Text = text,
                FontSize = 20,
                HorizontalTextAlignment = TextAlignment.Center,
                LineBreakMode = LineBreakMode.WordWrap,
                VerticalOptions = LayoutOptions.Start,
                Margin = new Thickness(0, 0, 0, 20)
            };

            AddToLayoutView(verticalStackLayout, label);

            return label;
        }

        public Label CreateLabelWithTitle(VerticalStackLayout verticalStackLayout, string title, string color, string text)
        {
            Label label = new()
            {
                Opacity = 0,
                FontSize = 20,
                HorizontalTextAlignment = TextAlignment.Center,
                LineBreakMode = LineBreakMode.WordWrap,
                VerticalOptions = LayoutOptions.Start,
                Margin = new Thickness(0, 0, 0, 20)
            };

            FormattedString formattedString = new();
            SetTitleForLabel(formattedString, title, color);
            SetTextForLabel(formattedString, text);
            label.FormattedText = formattedString;
            AddToLayoutView(verticalStackLayout, label);

            return label;
        }

        public Button CreateButton(string text)
        {
            Button button = new()
            {
                Opacity = 0,
                Text = text,
                FontSize = 20,
                LineBreakMode = LineBreakMode.WordWrap,

                IsEnabled = false,

                VerticalOptions = LayoutOptions.Start,
                Margin = new Thickness(0, 0, 0, 10)
            };

            return button;
        }

        public void AddToLayoutView(VerticalStackLayout verticalStackLayout, View view)
        {
            verticalStackLayout.Add(view);
        }


        public async Task<Button> CreateNewButton(WalkingAnimation walkingAnimation, string text, ScrollView ScrollArea)
        {
#if DEBUG
            MyLogger.logger.LogInformation("Создание новой кнопки.");
#endif
            Button button = CreateButton(text);
            await walkingAnimation.AnimationButton(button);
            await NewScrollPosition(ScrollArea, button);

            return button;
        }


        public Entry CreateEntry(string text)
        {
            Entry entry = new Entry()
            {
                Opacity = 0,
                Placeholder = text,
                FontSize = 20,

                IsEnabled = false,

                Keyboard = Keyboard.Numeric,

                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Margin = new Thickness(0, 0, 0, 10)
            };

            return entry;
        }

        public void EntryEnabled(Entry entry)
        {
            entry.IsEnabled = true;
        }


        public async Task<Label> CreateLabelNameMiniGame(ScrollView ScrollArea, string text)
        {
            Label label = new()
            {
                Opacity = 0,
                Text = text,
                FontSize = 24,
                FontAttributes = FontAttributes.Bold,
                TextDecorations = TextDecorations.Underline,
                HorizontalTextAlignment = TextAlignment.Center,
                LineBreakMode = LineBreakMode.WordWrap,
                VerticalOptions = LayoutOptions.Start,
                Margin = new Thickness(0, 0, 0, 20)
            };
            await NewScrollPosition(ScrollArea, label);

            return label;
        }


        public async Task SettingMenuAudio(string audioName, bool isLoop)
        {
            await WorkWithSound.StopAudioPlayer();
            await WorkWithSound.InitNewAudioPlayer(audioName, isLoop);
        }

        public int GetIntendedNumber(Random rnd_Number, int startNumber, int endNumber)
        {
            return rnd_Number.Next(startNumber, endNumber);
        }
    }
}
