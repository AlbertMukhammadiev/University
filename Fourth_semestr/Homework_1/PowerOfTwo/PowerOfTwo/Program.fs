let rec create2 m list acc =
    if m <= 0 then
        list
    else
        create2
            (m - 1)
            (acc :: list)
            (acc * 2)

let rec pow n acc =
    if n = 0 then
        acc
    else
        pow
            (n - 1)
            (acc * 2)

let create n m = List.fold (fun acc elem -> elem::acc) [] (create2 m [] (pow n 1))

let printList list = List.fold(fun acc elem -> printfn "%A" elem) () list

[<EntryPoint>] 
let main argv = 
//    printfn "%A" argv
    printList(create 3 5)
    0 // возвращение целочисленного кода выхода
