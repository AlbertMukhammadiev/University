module Tests

open ParseTree
open NUnit.Framework
open FsUnit

[<Test>]
let ``Calculating of ((7 + 3) * (5 - 2))`` () =
    let tree =
        Node (
            '*',
            Node ('+', Tip 7, Tip 3),
            Node ('-', Tip 5, Tip 2)
            )
    calculate tree |> should equal 30

[<Test>]
let ``provoking of throw of exception`` () =
    let tree =
        Node (
            'w',
            Node ('+', Tip 7, Tip 3),
            Node ('-', Tip 5, Tip 2)
            )
    (fun () -> calculate tree |> ignore) |> should (throwWithMessage "incorrect operator") typeof<System.Exception> 

[<Test>]
let ``Calculating of (5 * (10 - (30 + 2)))`` () =
    let tree =
        Node (
            '*',
            Tip 5,
            Node (
                '-',
                Tip 10,
                Node ('+', Tip 30, Tip 2)
                )
            )
    calculate tree |> should equal -110