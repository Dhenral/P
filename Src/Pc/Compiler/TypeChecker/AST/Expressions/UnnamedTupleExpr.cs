using Antlr4.Runtime;
using Microsoft.Pc.TypeChecker.Types;

namespace Microsoft.Pc.TypeChecker.AST.Expressions
{
    public class UnnamedTupleExpr : IPExpr
    {
        public UnnamedTupleExpr(ParserRuleContext sourceLocation, IPExpr[] tupleFields, PLanguageType type)
        {
            SourceLocation = sourceLocation;
            TupleFields = tupleFields;
            Type = type;
        }

        public IPExpr[] TupleFields { get; }

        public ParserRuleContext SourceLocation { get; }

        public PLanguageType Type { get; }
    }
}
