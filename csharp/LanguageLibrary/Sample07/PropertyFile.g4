grammar PropertyFile;
file : prop+ ;
prop : ID '=' STRING '\r\n' ;
ID   : [a-z]+ ;
STRING : '"' .*? '"' ;
