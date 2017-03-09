let rec indexOfRec elem list i =
    match list with
    | [] -> None
    | head :: tail -> if (head <> elem) then indexOfRec (elem) (tail) (i + 1)
                      else Some i

let indexOf elem list = indexOfRec elem list 0

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // возвращение целочисленного кода выхода
