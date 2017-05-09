module Tests

open Program
open NUnit.Framework
open FsUnit
open FsCheck

[<Test>]
let ``checking of equivalence of all the functions using FsCheck`` () =
    let areEqui x ls = (func x ls = func'1 x ls)
                        && (func'1 x ls = func'2 x ls)
                        && (func'2 x ls = func'3 x ls)
    Check.QuickThrowOnFailure areEqui 