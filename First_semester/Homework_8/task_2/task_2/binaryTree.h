#pragma once

struct Data;

struct Tree;

struct Node;

typedef int Value;

typedef int Key;

/// creates the tree and returns a pointer to it
Tree *createTree();

/// adds a node with key K and value V into the tree
void insert(Value value, Key key, Tree *tree);

/// checks for the existence of the node with the given key
Node *isExist(Key key, Tree *tree);

/// removes the tree node with the given key
void remove(Key key, Tree *tree);

enum inOrder
{
	Ascending,
	Descending
};

/// prints the tree in ascending or descending order
void printTree(Tree *tree, inOrder order);

/// frees all memory allocated for the tree
void deleteTree(Tree *tree);