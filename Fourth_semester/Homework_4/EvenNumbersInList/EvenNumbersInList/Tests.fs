module Tests

open Program
open NUnit.Framework
open FsUnit
open FsCheck

[<Test>]
let ``checking of equivalence of all the functions using FsCheck`` () =
    let areEqui ls = evenNums1 ls = evenNums2 ls && evenNums2 ls = evenNums3 ls
    Check.QuickThrowOnFailure areEqui

[<Test>]
let ``counting the number of even numbers`` () =
    let ls = List.init 11 id
    evenNums1 ls |> should equal 6
    let ls2 = List.append ls ls
    evenNums2 ls2 |> should equal 12
    let ls3 = List.append ls ls2
    evenNums3 ls3 |> should equal 18

[<Test>]
let ``adding of one even number to the list(number of even numbers should increase)`` () =
    let ls = List.init 5 id
    List.Cons (4, ls) |> evenNums1 |> should equal <| 1 + evenNums1 ls

[<Test>]
let ``all elements of the list are even`` () =
    let ls = List.init 100 (fun x -> x * 2)
    evenNums1 ls |> should equal <| List.length ls