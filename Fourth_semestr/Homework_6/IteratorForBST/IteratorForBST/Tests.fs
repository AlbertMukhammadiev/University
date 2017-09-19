module Tests

open BinaryTree
open NUnit.Framework
open FsUnit

type TestOfBST() =
    let tree = BinaryTree<string>()
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

    [<Test>]
    member this.``test of searching existing value`` () =
        tree.GetValue 55 |> should equal <| Some "голове"

    [<Test>]
    member this.``test of searching unexisting value`` () =
        tree.GetValue 41 |> should equal None

    [<Test>]
    member this.``test of removing from tree`` () =
        tree.Remove 70

    [<Test>]
    member this.``test of inserting to tree`` () =
        tree.Insert "yes" 69

    [<Test>]
    member this.``test of enumerator`` () =
        let mutable poem = ""
        for value in tree do
            poem <- poem + value + " "
        poem |> should equal "если я чешу в затылке не беда в. голове моей опилки да да. да.. "