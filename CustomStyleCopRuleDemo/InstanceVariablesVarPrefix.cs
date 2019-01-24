
namespace DotNetExtensions.StyleCop.Rules
{
    using Microsoft.StyleCop;
    using Microsoft.StyleCop.CSharp;

    /// <summary>
    /// This StyleCop Rule makes sure that instance variables are prefixed with an underscore.
    /// </summary>
    [SourceAnalyzer(typeof(CsParser))]
    public class InstanceVariablesVarPrefix : SourceAnalyzer
    {
        public override void AnalyzeDocument(CodeDocument document)
        {
            CsDocument csdocument = (CsDocument)document;
            if (csdocument.RootElement != null && !csdocument.RootElement.Generated)
            {
                csdocument.WalkDocument(new CodeWalkerElementVisitor<object>(this.VisitElement), null, null);
            }

        }

        private bool VisitElement(CsElement element, CsElement parentElement, object context)
        {
            if (!element.Generated && element.ElementType == ElementType.Field && element.Declaration.Name.StartsWith("var"))
            {
                AddViolation(element, "InstanceVariablesVarPrefix");

            }

            return true;
        }
    }
}