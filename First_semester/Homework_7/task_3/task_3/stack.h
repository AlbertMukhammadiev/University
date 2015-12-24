#pragma once

struct Stack;

typedef char Value;

struct StackElement;

Stack *createStack();

///removes the top element
void pop(Stack *stack);

///pushes the value to the top of the stack
void push(Value value, Stack *stack);

///gets the top value of the stack
Value getValue(Stack *stack);

bool isEmpty(Stack *stack);

void printStack(Stack *stack);

void deleteStack(Stack *stack);