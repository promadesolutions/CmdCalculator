A basic arithmetic expression evaluator using the Shunting Yard algorithm principles, with stacks for values and operators. Here's some feedback on logic and functionality:

Insights & Functionality Review:
1) Input Parsing:
The input expression is split into parts by space (Split(' ')). This works fine if users input expressions like 3 + 5, but it will fail for expressions like 3+5 without spaces.
Consider using Regex or manually processing the input to handle expressions without spaces, e.g., 3+5 or 7-4*2.

2) Operator Precedence & Associativity:
Your precedence system is accurate, giving * and / higher precedence over + and -.
However, it lacks parenthesis handling, which could allow users to specify the order of operations. You could extend the Evaluate method to support parentheses (()), giving them higher precedence.
calculator effectively uses Last In, First Out (LIFO) operations through the Stack data structure for both the values and operators.

3) Edge Cases:
Empty Input: You already handle empty input by breaking the loop.
Invalid Input: Your exception handler catches invalid expressions, which is good. However, you might want to provide more specific messages for unrecognized operators or invalid syntax.
Operator at End: If an expression ends with an operator like 5 +, it would currently throw an exception since there wouldn’t be a second operand. Consider handling this scenario explicitly.

4) LIFO (Last in first out)
Values Stack (values):
Numbers are pushed onto the stack as they are encountered in the expression.
When an operator needs to be applied, the last two numbers (operands) are popped from the stack, meaning the most recently pushed number is used first (LIFO).

Operators Stack (operators):
Operators are pushed onto the stack in the order they are encountered, but before applying them, the algorithm checks if the current operator has lower or equal precedence than the one on top of the stack.
If so, it pops and applies the operator (following LIFO), ensuring that the operator added most recently is the first one applied when precedence dictates.
