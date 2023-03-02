parser grammar SnippetLanguageParser;

options { tokenVocab=SnippetLanguageLexer; } //superClass=CSharpPreprocessorParserBase;
// @header {
// package com.example;
// }


program
    : sentences EOF
    ;

sentences
    : (useSentence | assignSentence)*
    // | ifSentence
    // | assignSentence
    ;
useSentence
    : USES DLL//{ NotifyErrorListeners($USES, "program must not end with semicolon!", null); }
    ;
    
assignSentence 
            : ASSIGN IDENTIFIER EQUAL expression
            | IDENTIFIER EQUAL expression
            ;

expression: term ((ADD | SUB) term)*;

term      : factor ((MUL | DIV) factor)*;

factor    : IDENTIFIER
          | INT
          | FLOAT
        //   | STRING
          | OPEN_PARENTESIS expression CLOSE_PARENTESIS;

// ifSentence
//     : jsonObject
//     ;

// jsonObject
//     : OPEN_BRACE keyValuePairs CLOSE_BRACE
//     ;

// keyValuePairs
//     :(keyValuePair (COMMA keyValuePair)*)?
//     ;

// keyValuePair
//     : IDENTIFIER COLON (primitive | jsonObject)
//     ;

// primitive
//     : string
//     | bool
//     ;

// string
//     : DOUBLE_STRING
//     // | SINGLE_STRING
//     ;

bool
    : TRUE
    | FALSE
    ;