# SPO2020
 Interpreter

 lang -> expr+
 expr -> VAR ASSIGN_OP value_expr
 value_expr -> value (OP value)*
 value -> VAR|DIGIT

VAR -> ^([a-zA-Z]+)$
DIGIT -> ^(0|[1-9][0-9]*)$
ASSIGN_OP -> ^=$
OP -> ^(\+|-|\*|\/)$
