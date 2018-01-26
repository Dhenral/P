﻿using System.Collections.Generic;
using System.Text;
using Microsoft.Pc.TypeChecker;
using Microsoft.Pc.TypeChecker.AST;
using Microsoft.Pc.TypeChecker.Types;

namespace Microsoft.Pc.Backend.Debugging
{
    public abstract class IrRenderer
    {
        private readonly StringBuilder writer = new StringBuilder();
        private int depth;

        public string Render(Scope scope)
        {
            foreach (IPDecl decl in scope.AllDecls)
            {
                WriteDecl(decl);
            }

            return writer.ToString();
        }

        protected string Padding { get; private set; }

        protected void Indent() { Padding = new string(' ', ++depth * 4); }

        protected void Dedent() { Padding = new string(' ', --depth * 4); }

        protected void WriteParts(string part) { writer.Append(part); }

        protected void WriteParts(params string[] parts)
        {
            foreach (string part in parts)
            {
                writer.Append(part);
            }
        }

        protected void WriteParts(params object[] parts)
        {
            foreach (object part in parts)
            {
                switch (part)
                {
                    case IPExpr expr:
                        WriteExpr(expr);
                        break;
                    case IEnumerable<IPExpr> exprs:
                        WriteExprList(exprs);
                        break;
                    case IEnumerable<string> strs:
                        WriteStringList(strs);
                        break;
                    case IPDecl decl:
                        WriteDeclRef(decl);
                        break;
                    case PLanguageType type:
                        WriteTypeRef(type);
                        break;
                    default:
                        writer.Append(part);
                        break;
                }
            }
        }

        protected abstract void WriteDecl(IPDecl decl);

        protected abstract void WriteExpr(IPExpr expr);

        protected abstract void WriteTypeRef(PLanguageType type);

        protected abstract void WriteDeclRef(IPDecl decl);

        protected abstract void WriteStringList(IEnumerable<string> strs);

        protected abstract void WriteExprList(IEnumerable<IPExpr> exprs);
    }
}