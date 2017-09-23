module Program

open LoadingAndProcessing

[<EntryPoint>]
let main args =
    printfn "%A" <| getLengths "https://translate.google.com"
    0