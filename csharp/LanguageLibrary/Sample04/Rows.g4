grammar Rows;

@parser::members { // add members to generated RowsParser
    int col;
    public RowsParser(ITokenStream input, int col): base(input) { // custom constructor
        this.col = col;
        _interp = new ParserATNSimulator(this,_ATN); //this line is required in C# Why I'm not totally sure
    }
}

file: (row NL)+ ;

row
locals [int i=0]
    : (   STUFF
          {
          $i++;
          if ( $i == col ) Console.WriteLine($STUFF.text);
          }
      )+
    ;

TAB  :  '\t' -> skip ;   // match but don't pass to the parser
NL   :  '\r'? '\n' ;     // match and pass to the parser
STUFF:  ~[\t\r\n]+ ;     // match any chars except tab, newline
