let rec indexOf elem list i =
    match list with
    | [] -> None
    | head :: tail -> if (head <> elem) then indexOf (elem) (tail) (i + 1)
                      else Some i

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // возвращение целочисленного кода выхода
