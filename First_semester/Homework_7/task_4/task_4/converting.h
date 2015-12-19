#pragma once
#include "stack.h"

int priority(char operation);

void convertToPostfixForm(char string[], Stack *stack, int length);