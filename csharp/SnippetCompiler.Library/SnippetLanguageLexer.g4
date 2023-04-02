lexer grammar SnippetLanguageLexer;

// @header {
// package com.example;
// }

fragment InputCharacter: ~[\r\n\u0085\u2028\u2029];

OPEN_BRACE:               '{'; //{ this.OnOpenBrace(); };
CLOSE_BRACE:              '}'; //{ this.OnCloseBrace(); };
COMMA:                    ',';
COLON:                    ':'; //{ this.OnColon(); };
SINGLE_LINE_DOC_COMMENT: '//' InputCharacter* -> skip;
USES: 'USES';
DOUBLE_QUOTE: '"';
DLL_NAME: DOUBLE_QUOTE IDENTIFIER DOUBLE_QUOTE '.dll';
SINGLE_STRING : '\'' ~('\'')+ '\'' ;
IDENTIFIER :  [A-Za-z0-9./]+;
FALSE:         'false';
TRUE:          'true';


WS
    :   [ \t\r\n]+ -> skip
    ;

//UNKNOWN : . ;