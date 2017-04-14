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
let ``test of llsad`` () =
    let seq = Seq.take 15 sequence
    Seq.

//[<Test>]
//Check.Quick getSeq