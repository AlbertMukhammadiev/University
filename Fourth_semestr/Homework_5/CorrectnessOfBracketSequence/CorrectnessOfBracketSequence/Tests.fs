module Tests

open Program
open NUnit.Framework
open FsUnit
open FsCheck

[<Test>]
let   ``an example of correct string`` () =
    check "{}[{{}[]}()]" |> should equal true

[<Test>]
let ``an example of incorrect string`` () =
    check "[{]}()[]([])" |> should equal false

[<Test>]
let ``null string`` () =
    check null |> should equal true

[<Test>]
let ``empty string`` () =
    check "" |> should equal true

[<Test>]
Check.Quick check