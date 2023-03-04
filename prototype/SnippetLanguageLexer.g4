lexer grammar SnippetLanguageLexer;

// @header {
// package com.example;
// }

fragment InputCharacter: ~[\r\n\u0085\u2028\u2029];
fragment ESC : '\\"' | '\\\\' ; // 2-char sequences \" and \\

OPEN_BRACE:               '{'; //{ this.OnOpenBrace(); };
CLOSE_BRACE:              '}'; //{ this.OnCloseBrace(); };
OPEN_PARENTESIS:          '(';
CLOSE_PARENTESIS:         ')';
COMMA:                    ',';
COLON:                    ':'; //{ this.OnColon(); };
ADD       : '+';
SUB       : '-';
MUL       : '*';
DIV       : '/';
EQUAL     : '=';

USES: 'USES'; // {if (this.Text!="USES" && "USES".Contains(this.Text.ToLower())) { throw new Exception("USES must be in uppercase"); };};
ASSIGN: 'ASSIGN';
DOUBLE_QUOTE: '"';
// DLL_NAME: '"' IDENTIFIER '.dll' '"';
// SINGLE_STRING : '\'' ~('\'')+ '\'' ;
FALSE:         'false';
TRUE:          'true';
// SENTENCE_SEPARATOR: '\r\n';

// DLL_EXTENSION: '.' [dD][lL][lL];
// DLL_IDENTIFIER: ~["\r\n][a-zA-Z0-9_.]+;
DLL_NAME: ~["\r\n]([a-zA-Z0-9_.]+ '.' [dD][lL][lL]);
DLL: '"' DLL_NAME '"';
DOUBLE_STRING: '"' (~["\r\n] | '""')* '"';

INT       : DIGIT+;
FLOAT     : DIGIT+ '.' DIGIT*;

IDENTIFIER :  LETTER (LETTER|DIGIT)*;
fragment LETTER      :   [a-zA-Z\u0080-\u00FF_] ;
DIGIT       :   [0-9] ;
LINE_COMMENT : '//' .*? '\r'? '\n' -> skip ; // Match "//" stuff '\n'
WS
    :   [ \t\r\n]+ -> skip
    ;
//UNKNOWN : . ;