module Program

let rec fact n acc =
    if n = 1 then
        acc
    else
        fact
            (n - 1)
            (acc * n)

let factorial n = fact n 1

[<EntryPoint>]
let main argv =
    printfn "%d ! =  %d" 7 (factorial 7)
    0 // Return an integer exit code
