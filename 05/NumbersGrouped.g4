grammar NumbersGrouped;
// 2 9 10 3 1 2 3
// The first number says to match the two subsequent numbers, 9 and 10. 
// The 3 following the 10 says to match three more as a sequence. 
// Our goal is a grammar called Data that groups 9 and 10 together and then 1, 2, and 3 
  file : group+ ;
  group: INT sequence[$INT.int] ;
  sequence[int n]
  locals [int i = 1]
       : ( {$i<=$n}? INT {$i++;} )* // match n integers
       ;
  INT :   [0-9]+ ;             // match integers
  WS  :   [ \t\n\r]+ -> skip ; // toss out all whitespace