#pragma once

struct Stack;

typedef char Value;

struct StackElement;

Stack *createStack();

void pop(Stack *stack);

void push(Value value, Stack *stack);

Value getValue(Stack *stack);

void printStack(Stack *stack);

void deleteStack(Stack *stack);