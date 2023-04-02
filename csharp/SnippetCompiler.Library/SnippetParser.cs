using Antlr4.Runtime;
using SnippetCompiler.Library.grammars;

namespace SnippetCompiler.Library
{



    public static class SnippetParser
    {
        public static ParserResult SingleParse(string expression, bool secondRun = false)
        {
            if (String.IsNullOrWhiteSpace(expression))
            {
                return new ParserResult
                {
                    IsValid = true,
                    Result = null
                };
            }

            var inputStream = new AntlrInputStream(expression);
            var lexer = new SnippetLanguageLexer(inputStream);
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new SnippetLanguageParser(tokenStream);

            lexer.RemoveErrorListeners();
            parser.RemoveErrorListeners();
            var customErrorListener = new SnippetLanguageErrorListener();
            parser.AddErrorListener(customErrorListener);
            var visitor = new SnippetLanguageVisitor();

            var adaptableExpression = parser.program();
            var result = visitor.Visit(adaptableExpression);
            var isValid = customErrorListener.IsValid;
            var errorLocation = customErrorListener.ErrorLocation;
            var errorMessage = customErrorListener.ErrorMessage;
            if (result != null)
            {
                isValid = false;
            }

            if (!isValid && !secondRun)
            {
                var cleanedFormula = string.Empty;
                var tokenList = tokenStream.GetTokens().ToList();
                for (var i = 0; i < tokenList.Count - 1; i++)
                {
                    cleanedFormula += tokenList[i].Text;
                }
                var originalErrorLocation = errorLocation;
                var retriedResult = SingleParse(cleanedFormula, true);
                if (!retriedResult.IsValid)
                {
                    retriedResult.ErrorPosition = originalErrorLocation;
                    retriedResult.ErrorMessage = errorMessage;
                }
                return retriedResult;
            }
            return new ParserResult
            {
                IsValid = isValid,
                Result = isValid || result != null
                ? result
                : null,
                ErrorPosition = errorLocation,
                ErrorMessage = isValid ? null : errorMessage
            };
        }

        public static ParserResult<List<SyntaxError>> Parse(string expression, bool secondRun = false)
        {
            if (String.IsNullOrWhiteSpace(expression))
            {
                return new ParserResult<List<SyntaxError>>
                {
                    IsValid = true,
                    Result = null
                };
            }

            var inputStream = new AntlrInputStream(expression);
            var lexer = new SnippetLanguageLexer(inputStream);
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new SnippetLanguageParser(tokenStream);

            lexer.RemoveErrorListeners();
            parser.RemoveErrorListeners();
            var customErrorListener = new SnippetLanguageErrorsListener();
            parser.AddErrorListener(customErrorListener);
            var visitor = new SnippetLanguageVisitor();

            var adaptableExpression = parser.program();
            var result = visitor.Visit(adaptableExpression);
            var isValid = customErrorListener.IsValid;
            var errors = customErrorListener.Errors;
            //var errorMessage = customErrorListener.ErrorMessage;
            if (result != null)
            {
                isValid = false;
            }

            if (!isValid && !secondRun)
            {
                var cleanedFormula = string.Empty;
                var tokenList = tokenStream.GetTokens().ToList();
                for (var i = 0; i < tokenList.Count - 1; i++)
                {
                    cleanedFormula += tokenList[i].Text;
                }
                var originalErrors = errors;
                var retriedResult = Parse(cleanedFormula, true);
                if (!retriedResult.IsValid)
                {
                    retriedResult.AddError(originalErrors.ErrorResult);
                    //retriedResult.ErrorMessage = errorMessage;
                }
                return retriedResult;
            }
            var firstResult = new ParserResult<List<SyntaxError>>
            {
                IsValid = isValid,
                Result = isValid || result != null
                ? result
                : null,
                //ErrorResult = errors.ErrorResult
                //ErrorPosition = errorLocation,
                //ErrorMessage = isValid ? null : errorMessage
            };
            firstResult.AddError(errors.ErrorResult);
            return firstResult;
        }

        public static string Parse2(string text)
        {
            var lexer = new SnippetLanguageLexer(new AntlrInputStream(text));
            lexer.RemoveErrorListeners();
            var customErrorListener = new SnippetLanguageThrowingErrorListener();
            lexer.AddErrorListener(customErrorListener);
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            var parser = new SnippetLanguageParser(tokens);
            parser.RemoveErrorListeners();
            //parser.ErrorHandler = new DefaultErrorStrategy();
            parser.AddErrorListener(customErrorListener);
            ParserRuleContext tree = parser.program(); //.RuleContext;
            SnippetLanguageVisitor extractor = new SnippetLanguageVisitor();
            return extractor.Visit(tree);
        }

    }
}