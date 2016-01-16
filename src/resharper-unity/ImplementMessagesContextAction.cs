using System;
using System.Linq;
using JetBrains.Annotations;
using JetBrains.Application.Progress;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Feature.Services.ContextActions;
using JetBrains.ReSharper.Feature.Services.CSharp.Analyses.Bulbs;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.TextControl;
using JetBrains.Util;

namespace JetBrains.ReSharper.Plugins.Unity
{
    [ContextAction(Group = "C#", Name = "ImplementUnity3DMessages", Description = "Implement Unity3D Messages")]
    public class ImplementMessagesContextAction : ContextActionBase
    {
        private readonly ICSharpContextActionDataProvider _context;

        public ImplementMessagesContextAction([NotNull] ICSharpContextActionDataProvider context)
        {
            _context = context;
        }

        /// <summary>
        /// Executes QuickFix or ContextAction. Returns post-execute method.
        /// </summary>
        /// <returns>
        /// Action to execute after document and PSI transaction finish.
        ///             Use to open TextControls, navigate caret, etc.
        /// </returns>
        protected override Action<ITextControl> ExecutePsiTransaction(ISolution solution, IProgressIndicator progress)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Popup menu item text
        /// </summary>
        public override string Text => "Implement Unity3D Messages";

        /// <summary>
        /// Check if this action is available at the constructed context.
        ///             Actions could store precalculated info in <paramref name="cache"/> to share it between different actions
        /// </summary>
        /// <returns>
        /// true if this bulb action is available, false otherwise.
        /// </returns>
        public override bool IsAvailable(IUserDataHolder cache)
        {
            var declaration = _context.GetSelectedElement<IClassLikeDeclaration>();
            return declaration?.DeclaredElement?.GetMessageHosts().Any() ?? false;
        }
    }
}