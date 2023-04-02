parser grammar SnippetLanguageParser;

options { tokenVocab=SnippetLanguageLexer; } //superClass=CSharpPreprocessorParserBase;
// @header {
// package com.example;
// }


program
    : sentences
    EOF
    ;

sentences
    : (assignSentence
    | useSentence)+
    // | ifSentence
    // | assignSentence
    ;

assignSentence
    : jsonObject
    ;

ifSentence
    : jsonObject
    ;

useSentence
    : USES DLL_NAME //{ NotifyErrorListeners($USES, "program must not end with semicolon!", null); }
    ;

jsonObject
    : OPEN_BRACE keyValuePairs CLOSE_BRACE
    ;

keyValuePairs
    :(keyValuePair (COMMA keyValuePair)*)?
    ;

keyValuePair
    : IDENTIFIER COLON (primitive | jsonObject)
    ;

primitive
    : string
    | bool
    ;

string
    : SINGLE_STRING
    // | DOUBLE_STRING
    ;

bool
    : TRUE
    | FALSE
    ;