#include "stdafx.h"
#include <iostream>
#include "binaryTree.h"

struct Data
{
	Value value = 0;
	Key key = 0;
};

struct Tree
{
	Node *root = nullptr;
};

struct Node
{
	Data data;
	Node *left = nullptr;
	Node *right = nullptr;
};

Tree *createTree()
{
	return new Tree;
}

void insert(Value value, Key key, Tree *tree)
{
	if (!tree->root)
	{
		tree->root = new Node;
		tree->root->data.key = key;
		tree->root->data.value = value;
		return;
	}

	if (tree->root->data.key == key)
	{
		std::cout << "the node with the same key already exists in the tree" << std::endl;
		return;
	}

	Node *i = tree->root;
	while ((i->left) || (i->right))
	{
		if (i->data.key == key)
		{
			std::cout << "the node with the same key already exists in the tree" << std::endl;
			return;
		}

		if ((i->left) && (key < i->data.key))
		{
			i = i->left;
		}
		else if ((i->right) && (key > i->data.key))
		{
			i = i->right;
		}
		else if ((!i->right) && (key > i->data.key))
		{
			i->right = new Node;
			i->right->data.key = key;
			i->right->data.value = value;
			return;
		}
		else if ((!i->left) && (key < i->data.key))
		{
			i->left = new Node;
			i->left->data.key = key;
			i->left->data.value = value;
			return;
		}
	}

	if (key < i->data.key)
	{
		i->left = new Node;
		i = i->left;
	}
	else if (key > i->data.key)
	{
		i->right = new Node;
		i = i->right;
	}
	i->data.key = key;
	i->data.value = value;
	return;
}

Node *isExist(Key key, Tree *tree)
{
	if (tree->root->data.key == key)
	{
		return tree->root;
	}

	Node *i = tree->root;
	while ((i->left) || (i->right))
	{
		if (i->data.key == key)
		{
			return i;
		}

		if (key < i->data.key)
		{
			if (i->left)
			{
				i = i->left;
			}
			else
			{
				return nullptr;
			}
		}

		if (key > i->data.key)
		{
			if (i->right)
			{
				i = i->right;
			}
			else
			{
				return nullptr;
			}
		}
	}
	if (i->data.key == key)
	{
		return i;
	}
	return nullptr;
}

void remove(Key key, Tree *tree)
{
	Node *required = isExist(key, tree);
	if (!required)
	{
		std::cout << "the tree is empty" << std::endl;
		return;
	}

	if (tree->root->data.key == key)
	{
		if ((!tree->root->left) && (!tree->root->right))
		{
			delete tree->root;
			tree->root = nullptr;
			return;
		}
		if ((tree->root->left) && (tree->root->right))
		{
			Node *i = tree->root->left;
			if (!i->right)
			{
				i->right = tree->root->right;
				tree->root = i;
				delete required;
				return;
			}
			Node *previous = i;
			while (i->right)
			{
				previous = i;
				i = i->right;
			}
			previous->right = i->left;
			i->left = tree->root->left;
			i->right = tree->root->right;
			tree->root = i;
			delete required;
			return;
		}
		if ((!tree->root->left) && (tree->root->right))
		{
			tree->root = tree->root->right;
			delete required;
			return;
		}
		if ((tree->root->left) && (!tree->root->right))
		{
			tree->root = tree->root->left;
			delete required;
			return;
		}
	}


	Node *i = tree->root;
	bool fromRight = false;
	Node *parent = i;
	//while ((i->left->data.key != key) && (i->right->data.key != key))
	while (true)
	{
		if (i->left)
		{
			if (i->left->data.key == key)
			{
				parent = i;
				i = i->left;
				fromRight = true;
				break;
			}
		}
		if (i->right)
		{
			if (i->right->data.key == key)
			{
				parent = i;
				i = i->right;
				fromRight = false;
				break;
			}
		}
		if (key < i->data.key)
		{
			i = i->left;
		}
		else if (key > i->data.key)
		{
			i = i->right;
		}
	}

	if ((!required->left) && (!required->right))
	{
		fromRight ? parent->left = nullptr : parent->right = nullptr;
		delete required;
		return;
	}
	if ((!required->left) && (required->right))
	{
		fromRight ? parent->left = required->right : parent->right = required->right;
		delete required;
		return;
	}
	if ((required->left) && (!required->right))
	{
		fromRight ? parent->left = required->left : parent->right = required->left;
		delete required;
		return;
	}
	if ((required->left) && (required->right))
	{
		i = required->left;
		if (!i->right)
		{
			parent->left = required->left;
			required->left->right = required->right;
			delete required;
			return;
		}
		Node *previous = i;
		while (i->right)
		{
			previous = i;
			i = i->right;
		}
		previous->right = i->left;
		i->left = required->left;
		i->right = required->right;
		parent->left = i;
		//fromRight ? parent->left = i : parent->right = i;
		delete required;
		return;
	}
}

void printNodes(Node *node, inOrder order)
{
	if (order == Ascending)
	{
		if (node->left)
		{
			printNodes(node->left, Ascending);
		}
		std::cout << node->data.key << " ";
		if (node->right)
		{
			printNodes(node->right, Ascending);
		}
	}
	else if (order == Descending)
	{
		if (node->right)
		{
			printNodes(node->right, Descending);
		}
		std::cout << node->data.key << " ";
		if (node->left)
		{
			printNodes(node->left, Descending);
		}
	}
}

void printTree(Tree *tree, inOrder order)
{
	if (!tree->root)
	{
		std::cout << "the tree is empty" << std::endl;
		return;
	}
	else
	{
		if ((!tree->root->right) && (!tree->root->left))
		{
			printNodes(tree->root, Ascending);
			return;
		}
		if (order == Ascending)
		{
			if (tree->root->left)
			{
				printNodes(tree->root->left, Ascending);
			}
			std::cout << tree->root->data.key << " ";
			if (tree->root->right)
			{
				printNodes(tree->root->right, Ascending);
			}
		}
		else if (order == Descending)
		{
			if (tree->root->right)
			{
				printNodes(tree->root->right, Descending);
			}
			std::cout << tree->root->data.key << " ";
			if (tree->root->left)
			{
				printNodes(tree->root->left, Descending);
			}
		}
	}
	return;
}

void recursiveRemovalOfNodes(Node *node)
{
	if (node->left)
	{
		recursiveRemovalOfNodes(node->left);
	}
	if (node->right)
	{
		recursiveRemovalOfNodes(node->right);
	}
	delete node;
}

void deleteTree(Tree *tree)
{
	if (tree->root)
	{
		recursiveRemovalOfNodes(tree->root);
	}
	delete tree;
}