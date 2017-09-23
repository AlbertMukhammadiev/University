let rec isUniqueRec list acc =
    match list with
    | [] -> true
    | head :: tail -> if List.contains head acc then false
                      else isUniqueRec (tail) (head :: acc)
                    
let isUnique list = isUniqueRec list []

let rec isUnique1 list =
    match list with
    | [] -> true
    | head :: tail -> if List.contains head tail then false
                      else isUnique1 (tail)

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // возвращение целочисленного кода выхода
