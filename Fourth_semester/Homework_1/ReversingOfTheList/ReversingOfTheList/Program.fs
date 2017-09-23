let reverse list = List.fold (fun acc elem -> elem::acc) [] list

[<EntryPoint>]
let main argv = 
    printfn "%A" (reverse [1 .. 5])
    0 // возвращение целочисленного кода выхода
