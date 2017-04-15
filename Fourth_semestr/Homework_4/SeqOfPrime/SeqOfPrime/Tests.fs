module Tests

open Program
open NUnit.Framework
open FsUnit
open FsCheck

[<Test>]
let ``test (the sum of the first 10 prime numbers)`` () =
    Seq.take 10 primes |> Seq.sum |> should equal 26769

[<Test>]
let ``prime number 3319 must exist in sequence`` () =
    Seq.take 500 primes |> Seq.exists (fun x -> x = 3319) |> should equal true

[<Test>]
let ``the 377-th element of sequence must equal 2593`` () =
    Seq.take 500 primes |> Seq.nth 377 |> should equal 2593