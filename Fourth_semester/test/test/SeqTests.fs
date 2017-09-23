module SeqTests

open Sequence
open NUnit.Framework
open FsUnit
open FsCheck

[<Test>]
let ``test a sequence of 10 elements`` () =
    let seq = Seq.take 10 sequence
    seq |> should equal [1; 2; 2; 3; 3; 3; 4; 4; 4; 4]

[<Test>]
let ``length of sequence of 1000 elements should equal 1000`` () =
    let seq = Seq.take 1000 sequence
    Seq.length seq |> should equal 1000

[<Test>]
let ``sum of elements`` () =
    let seq = Seq.take 15 sequence
    Seq.sum seq |> should equal 55

[<Test>]
let ``counting the number of numbers in the sequence`` () =
    let seq = Seq.take 1000 sequence
    let seq2 = Seq.init 20 id
    Seq.forall (fun elem -> elem = (Seq.length <| Seq.filter (fun x -> x = elem) seq)) seq2 |> should equal true