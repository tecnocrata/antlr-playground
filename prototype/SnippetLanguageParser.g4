parser grammar SnippetLanguageParser;

options { tokenVocab=SnippetLanguageLexer; } //superClass=CSharpPreprocessorParserBase;
// @header {
// package com.example;
// }


program
    : header sentences EOF
    ;

sentences
    : (assignSentence | ifSentence)*
    // | dynamicSentence
    ;

header: useSentence*;

useSentence
    : USES DLL//{ NotifyErrorListeners($USES, "program must not end with semicolon!", null); }
    ;
    
assignSentence 
            : ASSIGN IDENTIFIER EQUAL expr
            | IDENTIFIER EQUAL expr
            ;

ifSentence: IF expr OPEN_BRACE sentences CLOSE_BRACE (ELSE OPEN_BRACE sentences CLOSE_BRACE)?;

expr: IDENTIFIER OPEN_PARENTESIS exprList? CLOSE_PARENTESIS
    | expr OPEN_BRAK expr CLOSE_BRAK
    | SUB expr
    | EXCLAMATION expr
    | expr MUL expr
    | expr (ADD|SUB) expr
    | expr (EQUAL|NOT_EQUAL|LESS|GREATER|LESS_EQUAL|GREATER_EQUAL|AND|OR) expr
    | IDENTIFIER | INT | FLOAT | DOUBLE_STRING
    | OPEN_PARENTESIS expr CLOSE_PARENTESIS
    ;
exprList : expr (',' expr)* ;

// expression: term ((ADD | SUB) term)*;

// term      : factor ((MUL | DIV) factor)*;

// factor    : IDENTIFIER
//           | INT
//           | FLOAT
//           | DOUBLE_STRING
//           | OPEN_PARENTESIS expression CLOSE_PARENTESIS;


// string
//     : DOUBLE_STRING
//     // | SINGLE_STRING
//     ;

bool
    : TRUE
    | FALSE
    ;