module program

open PrintSquare
open Sequence


[<EntryPoint>]
let main argv = 
    //printfn "%A" argv
    print 10
    Seq.iter (fun x -> printf "%A" x) <| Seq.take 100 sequence
    0 // возвращение целочисленного кода выхода
