using System.Collections.Generic;
using System.Text;
using Febucci.TextAnimatorForUnity;
using Naninovel;
using Naninovel.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace VNPC.TextAnimatorIntegration
{
    /// <summary>
    /// Custom Naninovel text printer panel that uses Text Animator for text rendering and effects.
    /// Bypasses Naninovel's built-in RevealableText system to avoid TMPro vertex data conflicts.
    /// Naninovel controls timing; Text Animator controls all visuals (reveal, wave, shake, etc).
    /// </summary>
    [RequireComponent(typeof(CanvasGroup))]
    public class TATextPrinterPanel : UITextPrinterPanel
    {
        [Header("Text Animator Printer")]
        [Tooltip("The TextAnimator component on the text object.")]
        [SerializeField] private TextAnimatorComponentBase textAnimator;
        [Tooltip("The AuthorNamePanel for displaying character names (optional).")]
        [SerializeField] private AuthorNamePanel authorNamePanel;
        [Tooltip("MonoBehaviour implementing IInputIndicator for the continue prompt.")]
        [SerializeField] private MonoBehaviour inputIndicator;
        [Tooltip("Number of line breaks inserted between adjacent messages.")]
        [SerializeField] private int autoLineBreaks = 1;

        [Header("Events")]
        [SerializeField] private UnityEvent onRevealStarted;
        [SerializeField] private UnityEvent onRevealFinished;

        private IInputIndicator InputIndicator => inputIndicator as IInputIndicator;
        private int currentVisibleChars;
        private string currentAppearance = string.Empty;
        private readonly StringBuilder messageBuilder = new();

        public override float RevealProgress
        {
            get
            {
                if (textAnimator == null) return 0f;
                var total = textAnimator.CharactersCount;
                return total > 0 ? (float)currentVisibleChars / total : 0f;
            }
            set
            {
                if (textAnimator == null) return;
                var total = textAnimator.CharactersCount;
                var target = Mathf.RoundToInt(Mathf.Clamp01(value) * total);
                SetVisibleCharCount(target, playEffects: false);
            }
        }

        public override string Appearance
        {
            get => currentAppearance;
            set => currentAppearance = value ?? string.Empty;
        }

        protected override void Awake()
        {
            base.Awake();
            this.AssertRequiredObjects(textAnimator, inputIndicator);
        }

        public override void SetMessages(IReadOnlyList<PrintedMessage> messages)
        {
            Messages.Clear();
            foreach (var msg in messages) Messages.Add(msg);
            ApplyTextToAnimator();
            currentVisibleChars = 0;
            UpdateAuthor(messages.Count > 0 ? messages[^1] : default);
        }

        public override void AddMessage(PrintedMessage message)
        {
            Messages.Add(message);
            var previousVisible = currentVisibleChars;
            ApplyTextToAnimator();
            // Restore visibility of previously shown characters (no effects replay).
            SetVisibleCharCount(previousVisible, playEffects: false);
            UpdateAuthor(message);
        }

        public override void AppendText(LocalizableText text)
        {
            if (Messages.Count == 0)
            {
                AddMessage(new PrintedMessage(text));
                return;
            }
            var last = Messages[^1];
            Messages[^1] = new PrintedMessage(last.Text + text, last.Author ?? default);
            var previousVisible = currentVisibleChars;
            ApplyTextToAnimator();
            SetVisibleCharCount(previousVisible, playEffects: false);
        }

        public override async Awaitable RevealMessages(float delay, AsyncToken token)
        {
            onRevealStarted?.Invoke();
            InputIndicator?.Hide();

            var totalChars = textAnimator.CharactersCount;

            if (delay <= 0 || totalChars == 0)
            {
                textAnimator.SetVisibilityEntireText(true, false);
                currentVisibleChars = totalChars;
                onRevealFinished?.Invoke();
                return;
            }

            var startIndex = currentVisibleChars;
            float elapsed = 0f;

            for (int i = startIndex; i < totalChars; i++)
            {
                token.ThrowIfCanceled(this);

                if (token.Completed)
                {
                    // User clicked to skip: show remaining instantly without effects.
                    for (int j = i; j < totalChars; j++)
                        textAnimator.SetVisibilityChar(j, true, false);
                    currentVisibleChars = totalChars;
                    break;
                }

                textAnimator.SetVisibilityChar(i, true, true);
                currentVisibleChars = i + 1;

                // Wait for per-character delay.
                elapsed = 0f;
                while (elapsed < delay)
                {
                    token.ThrowIfCanceled(this);
                    if (token.Completed) break;
                    elapsed += Time.deltaTime;
                    await Awaitable.NextFrameAsync();
                }
            }

            currentVisibleChars = totalChars;
            onRevealFinished?.Invoke();
        }

        public override void SetAwaitInputIndicatorVisible(bool visible)
        {
            if (InputIndicator == null) return;
            if (visible) InputIndicator.Show();
            else InputIndicator.Hide();
        }

        private void ApplyTextToAnimator()
        {
            var formatted = BuildFormattedText();
            textAnimator.SetText(formatted, hideText: true);
        }

        private string BuildFormattedText()
        {
            if (Messages.Count == 0) return string.Empty;

            messageBuilder.Clear();
            for (int i = 0; i < Messages.Count; i++)
            {
                if (i > 0)
                    for (int lb = 0; lb < Mathf.Max(1, autoLineBreaks); lb++)
                        messageBuilder.Append('\n');
                messageBuilder.Append(FormatMessage(Messages[i]));
            }
            return messageBuilder.ToString();
        }

        private void UpdateAuthor(PrintedMessage message)
        {
            if (authorNamePanel == null) return;
            if (message.Author is { Id: { Length: > 0 } authorId })
            {
                var label = message.Author?.Label ?? LocalizableText.Empty;
                authorNamePanel.Text = label.IsEmpty
                    ? Characters.GetAuthorName(authorId) ?? authorId
                    : (string)label;
            }
            else
            {
                authorNamePanel.Text = string.Empty;
            }
        }

        private void SetVisibleCharCount(int count, bool playEffects)
        {
            if (textAnimator == null) return;
            var total = textAnimator.CharactersCount;
            count = Mathf.Clamp(count, 0, total);

            if (count > currentVisibleChars)
            {
                for (int i = currentVisibleChars; i < count; i++)
                    textAnimator.SetVisibilityChar(i, true, playEffects);
            }
            else if (count < currentVisibleChars)
            {
                for (int i = count; i < currentVisibleChars; i++)
                    textAnimator.SetVisibilityChar(i, false, false);
            }
            currentVisibleChars = count;
        }
    }
}
