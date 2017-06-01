module Program

open BinaryTree

let poemTree = 
    let mutable tree = BinaryTree<string>()
    do
        tree.Insert "беда" 50
        tree.Insert "опилки" 60
        tree.Insert "не" 40
        tree.Insert "голове" 55
        tree.Insert "да" 70
        tree.Insert "я" 30
        tree.Insert "моей" 58
        tree.Insert "если" 20
        tree.Insert "в." 53
        tree.Insert "в" 35
        tree.Insert "да." 75
        tree.Insert "да.." 80
        tree.Insert "чешу" 33
        tree.Insert "затылке" 37
        tree.Remove 50
    tree

[<EntryPoint>]
let main argv = 
    let tree = poemTree
    poemTree.Print ()
    0 // возвращение целочисленного кода выхода
