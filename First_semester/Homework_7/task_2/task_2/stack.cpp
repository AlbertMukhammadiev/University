#include "stdafx.h"
#include "stack.h"
#include <iostream>

struct Stack
{
	StackElement *head = nullptr;
};

struct StackElement
{
	Value value = '\0';
	StackElement *next = nullptr;
};

Stack *createStack()
{
	Stack *stack = new Stack;
	return stack;
}

void push(Value value, Stack *stack)
{
	StackElement *newElement = new StackElement;
	newElement->value = value;
	if (!stack->head)
	{
		stack->head = newElement;
		return;
	}
	newElement->next = stack->head;
	stack->head = newElement;
}

void pop(Stack *stack)
{
	if (!stack->head)
	{
		std::cout << "	Stack is empty" << std::endl;
		return;
	}
	StackElement *temp = stack->head;
	stack->head = stack->head->next;
	delete temp;
}

Value getValue(Stack *stack)
{
	return stack->head->value;
}

bool empty(Stack *stack)
{
	if (!stack->head)
	{
		return true;
	}
	else
	{
		return false;
	}
}

void printStack(Stack *stack)
{
	StackElement *i = stack->head;
	while (i)
	{
		std::cout << i->value << " ";
		i = i->next;
	}
}

void deleteStack(Stack *stack)
{
	if (!stack->head)
	{
		std::cout << "Stack is empty" << std::endl;
		return;
	}

	while (stack->head)
	{
		StackElement *temp = stack->head->next;
		delete stack->head;
		stack->head = temp;
	}
}