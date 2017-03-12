let shift list =
    match list with
    | [] -> []
    | [x] -> list
    | head :: tail -> tail @ (head :: [])

let indexOfmaxSum list =
    let triple = List.sortDescending << List.map (fun (x, i, elem) -> (x + elem, i, elem)) <| List.zip3 (shift list) [1 .. list.Length] list
    match triple with
    | [] -> None
    | head :: tail -> match head with
                      | (x, y, z) -> Some y

[<EntryPoint>]
let main argv = 
//    printfn "%A" argv
    printfn "%A" (indexOfmaxSum [1;5;6;2])
    0 // возвращение целочисленного кода выхода
