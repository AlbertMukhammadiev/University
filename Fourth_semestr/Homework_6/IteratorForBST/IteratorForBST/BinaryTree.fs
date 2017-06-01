module BinaryTree

type Tree<'a> =
    | EmptyTree
    | TreeNode of 'a * int * Tree<'a> * Tree<'a>

type BinaryTree<'a> () =
    let mutable root = EmptyTree

    let rec insert value key tree =
        match tree with
            | EmptyTree -> TreeNode (value, key, EmptyTree, EmptyTree)
            | TreeNode (v, k, left, right) when k > key -> TreeNode (v, k, insert value key left, right)
            | TreeNode (v, k, left, right) when k < key -> TreeNode (v, k, left, insert value key right)
            | _ -> tree

    /// data from node with minimum key
    let rec minimum node =
        match node with
        | TreeNode (v, k, EmptyTree, _) -> v, k
        | TreeNode (v, k, left, _) -> minimum left

    let rec remove key tree =
        match tree with
        | EmptyTree -> EmptyTree
        | TreeNode (v, k, left, right) when key < k -> TreeNode (v, k, remove key left, right)
        | TreeNode (v, k, left, right) when key > k -> TreeNode (v, k, left, remove key right)
        | TreeNode (v, k, EmptyTree, right) when key = k -> right
        | TreeNode (v, k, left, EmptyTree) when key = k -> left
        | TreeNode (v, k, left, right) when key = k -> let value, key = minimum right
                                                       let node = remove key right
                                                       TreeNode (value, key, left, node)
        | _ -> EmptyTree

    member this.Insert value key = root <- insert value key root

    member this.GetValue key =
        let rec search key node =
            match node with
            | TreeNode (v, k, left, right) when key < k -> search key left
            | TreeNode (v, k, left, right) when key > k -> search key right
            | TreeNode (v, k, _, _) when key = k -> Some v
            | _ -> None
        search key root

    member this.Remove key = root <- remove key root

    member this.Print () =
        let rec print tree =
            match tree with
            | EmptyTree -> ()
            | TreeNode (v, k, left, right) -> print left            
                                              printfn "%A" v
                                              print right
        print root


    