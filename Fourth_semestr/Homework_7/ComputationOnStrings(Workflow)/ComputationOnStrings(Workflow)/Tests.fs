module Tests

open Computation
open NUnit.Framework
open FsUnit

[<Test>]
let ``Test of addition of "1" "2"`` () =
    let calculate = new ConvertingBuilder()
    let result = calculate {
            let! x = "1"
            let! y = "2"
            let z = x + y
            return z
        }
    result |> should equal <| MyInt.Value 3

[<Test>]
let ``Test of multiplication of "213" "2f3"`` () =
    let calculate = new ConvertingBuilder()
    let result = calculate {
            let! x = "213"
            let! y = "2f3"
            let z = x * y
            return z
        }
    result |> should equal MyInt.Invalid

[<Test>]
let ``Test of addition of "1" "2" (ConvertingBuilder2)`` () =
    let calculate = new ConvertingBuilder2()
    let result = calculate {
        let! x = "1"
        let! y = "2"
        let z = x + y
        return z
    }
    result |> should equal <| Some 3

[<Test>]
let ``Test of multiplication of "213" "2f3" (ConvertingBuilder2)`` () =
    let calculate = new ConvertingBuilder2()
    let result = calculate {
            let! x = "213"
            let! y = "2f3"
            let z = x * y
            return z
        }
    result |> should equal None