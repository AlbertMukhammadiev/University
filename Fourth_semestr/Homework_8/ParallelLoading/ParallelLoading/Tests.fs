module Tests

open LoadingAndProcessing
open NUnit.Framework
open FsUnit

[<Test>]
let ``correctness of references`` () =
    let ls = references "https://translate.google.com"
    List.forall (fun x -> x.ToString().StartsWith("http://")) ls |> should equal true

[<Test>]
let ``Checking that some information has downloaded`` () =
    let ls = references "https://translate.google.com"
    let results = List.fold (fun acc x -> (Async.RunSynchronously << fetchAsync <| x) :: acc) [] ls
    List.forall (fun x -> x <> 0) results |> should equal true
