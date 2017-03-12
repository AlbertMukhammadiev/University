let rec isUniqueRec list acc =
    match list with
    | [] -> true
    | head :: tail -> if List.contains head acc then false
                      else isUniqueRec (tail) (head :: acc)
                    
let isUnique list = isUniqueRec list []

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // возвращение целочисленного кода выхода
