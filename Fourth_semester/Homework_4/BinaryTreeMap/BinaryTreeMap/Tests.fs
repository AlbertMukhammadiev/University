module Tests

open Tree
open NUnit.Framework
open FsUnit

[<Test>]
let ``test of "toList"`` () =
    toList tree |> should equal [1; 2; 3; 4; 5]

[<Test>]
let ``test of "sumTree" using "toList" for autogenerating tree`` () =
    let tree = generateTree 13 (Tip 1)
    let sum1 = sumTree tree
    let sum2 = List.sum <| toList tree
    sum1 |> should equal sum2

[<Test>]
let ``test of "sumTree" for small tree`` () =
    sumTree tree |> should equal 15

[<Test>]
let ``test of "map" using "toList" for small tree`` () =
    map (fun x -> x + x) tree |> toList |> should equal [2; 4; 6; 8; 10]

[<Test>]
let ``test of "map" by comparing the results: toList(map(fun tree)) VS List.map(fun toList(tree))`` () =
    let tree = generateTree 13 (Tip 1)
    let list1 = toList <| map (fun x -> x + 3) tree
    let list2 = List.map (fun x -> x + 3) <| toList tree
    list1 |> should equal list2 