parser grammar SnippetLanguageParser;

options { tokenVocab=SnippetLanguageLexer; } //superClass=CSharpPreprocessorParserBase;
// @header {
// package com.example;
// }


program
    : sentences EOF
    ;

sentences
    : (useSentence )*
    // | ifSentence
    // | assignSentence
    ;

// assignSentence
//     : jsonObject
//     ;

// ifSentence
//     : jsonObject
//     ;

useSentence
    : USES DOUBLE_QUOTE DLL_NAME DOUBLE_QUOTE//{ NotifyErrorListeners($USES, "program must not end with semicolon!", null); }
    ;

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