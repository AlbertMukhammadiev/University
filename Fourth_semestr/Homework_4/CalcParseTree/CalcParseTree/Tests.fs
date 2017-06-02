module Tests

open ParseTree
open NUnit.Framework
open FsUnit

[<Test>]
let ``Calculating of ((7 + 3) * (5 - 2))`` () =
    let tree =
        Node (
            Multiplication,
            Node (Addition, Tip 7, Tip 3),
            Node (Substraction, Tip 5, Tip 2)
            )
    calculate tree |> should equal 30

[<Test>]
let ``Calculating of (5 * (10 - (30 + 2)))`` () =
    let tree =
        Node (
            Multiplication,
            Tip 5,
            Node (
                Substraction,
                Tip 10,
                Node (Addition, Tip 30, Tip 2)
                )
            )
    calculate tree |> should equal -110