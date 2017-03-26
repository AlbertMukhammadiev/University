open Xunit
open FsUnit.Xunit

[<Fact>]
let ``that is perfect should get a score of 300.``() =
	scoreBowls [for i in 1..18 -> 10] |> should equal 300

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // возвращение целочисленного кода выхода
