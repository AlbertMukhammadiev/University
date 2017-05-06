module Tests

open Rounding
open NUnit.Framework
open FsUnit

[<Test>]
let ``result of expression rounded to thousandths`` () =
    let rounding r = new RoundingBuilder(r)
    let calculate =
        rounding 3 {
            let! a = 2.0 / 12.0
            let! b = 3.5
            return a / b
            }
    calculate |> should equal 0.048
    
[<Test>]
let ``result of expression rounded to hundredths`` () =
    let rounding r = new RoundingBuilder(r)
    let calculate =
        rounding 2 {
            let! a = 2.0 / 12.0
            let! b = 3.5
            return a / b
            }
    calculate |> should equal 0.05

[<Test>]
let ``result of expression rounded to tenths`` () =
    let rounding r = new RoundingBuilder(r)
    let calculate =
        rounding 1 {
            let! a = 43.25 + 4.33
            let! b = 2.0 / 12.0
            let! c = 3.5
            return a + b + c
            }
    calculate |> should equal 51.3